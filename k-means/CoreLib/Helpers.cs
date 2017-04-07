using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreLib
{
    public class Helper
    {
        public Helper(bool ConcreteCenters = false)
        {
            k = 2;
            Modification = Modification.Lloid;
            UseMahalanobisDistance = true;
            CenterMode = CenterMode.Random;
            Clusters = new List<Cluster>();
            AllPoints = new List<Point>();
            this._concreteCenters = ConcreteCenters;
        }
        #region Variables
        public int k { get; set; }
        public List<Cluster> Clusters { get; set; }
        public List<Point> AllPoints { get; set; }
        public int Dimension { get { return AllPoints.FirstOrDefault().Characters.Count; } }
        public Modification Modification { get; set; }
        public bool UseMahalanobisDistance { get; set; }
        public CenterMode CenterMode { get; set; }
        public int IterationCount { get; private set; }
        public double OperationTime { get; private set; }
        private double[][] _covMatrix;
        private bool _concreteCenters { get; set; }
        private bool _stopFlag
        {
            get
            {
                double eps = 0.001;
                foreach (var cluster in Clusters)
                {
                    for (int i = 0; i < cluster.Dimention; i++)
                    {
                        if (Math.Abs(cluster.Center.Characters[i] - cluster.PrevCenter.Characters[i]) > eps)
                            return false;
                    }
                }
                return true;
            }
        }
        #endregion
        #region Private logic
        private async Task _setConcreteCenters(List<Cluster> centers)
        {
            Clusters = centers;
            foreach (var item in Clusters)
            {
                item.Elements.Clear();
            }
        }
        private async Task _setRandomCenters()
        {
            Random r = new Random();
            var indexes = new List<int>();
            for (int i = 0; i < k; i++)
            {
                Clusters.Add(new Cluster());
                int index = -1;
                do
                {
                    index = r.Next(0, AllPoints.Count);
                }
                while(indexes.Contains(index));
                indexes.Add(index);
                Clusters[i].Elements.Add(AllPoints[index]);
                await Clusters[i].RefreshCenter();
            }
        }
        private async Task _setCleverCenters()
        {
            Random r = new Random();
            Clusters.Add(new Cluster());
            Clusters[0].Elements.Add(AllPoints[r.Next(0, AllPoints.Count)]);
            await Clusters[0].RefreshCenter();
            while (Clusters.Count < k)
            {
                double sum = 0;
                foreach (var point in AllPoints)
                {
                    foreach (var cluster in Clusters)
                    {
                        var curDist = await _getDistance(point, cluster.Center);
                        if (point.Distance > curDist)
                            point.Distance = curDist;
                    }
                    point.Distance = Math.Pow(point.Distance, 2);
                    sum += point.Distance;
                }
                var rnd = (double)r.Next(0, 100000) / 100000;
                rnd = rnd * sum;
                sum = 0;
                foreach (var point in AllPoints)
                {
                    if (sum < rnd)
                        sum += point.Distance;
                    else
                    {
                        Clusters.Add(new Cluster());
                        Clusters[Clusters.Count - 1].Elements.Add(point);
                        await Clusters[Clusters.Count - 1].RefreshCenter();
                        break;
                    }
                }
            }
        }
        private async Task _setRefinedCenters()
        {
            Random r = new Random();
            List<Helper> helpers = new List<Helper>();
            List<Point> CM = new List<Point>();
            double quality = double.PositiveInfinity;
            List<Cluster> res = new List<Cluster>();

            for (int j = 0; j < 10; j++)
            {
                helpers.Add(new Helper() { UseMahalanobisDistance = false, k = this.k});
                for (int i = 0; i < AllPoints.Count/10; i++)
			    {
                    helpers[j].AllPoints.Add(AllPoints[r.Next(0, AllPoints.Count)]);
			    }
                await helpers[j].Solve(new Action<Point, int>( (p,i) => { }));
                CM.AddRange(helpers[j].AllPoints);
            }
            for (int j = 0; j < 10; j++)
            {
                var clusters = helpers[j].Clusters;
                helpers[j] = new Helper(true) { UseMahalanobisDistance = false, k = this.k };
                helpers[j].AllPoints = CM;
                await helpers[j]._setConcreteCenters(clusters);

                var qual = await helpers[j].Solve(new Action<Point, int>((p, i) => { }));
                if(qual<quality)
                {
                    quality = qual;
                    res = helpers[j].Clusters;
                }
            }
            foreach (var clust in res)
	        {
                Clusters.Add(new Cluster() { Center = clust.Center });
	        }
        }
        private async Task _setSampledCenters()
        {
            double sum = 0;
            Random r = new Random();
            Clusters.Add(new Cluster() { Center = AllPoints[0] });
            Clusters.Add(new Cluster() { Center = AllPoints[1] });
            double centerDist = await _getDistance(Clusters[0].Center, Clusters[1].Center);
            for (int i = 0; i < AllPoints.Count-1; i++)
            {
                for (int j = i+1; j < AllPoints.Count; j++)
                {
                    var norm = await _getDistance(AllPoints[i], AllPoints[j]);
                    if (norm > centerDist)
                    {
                        AllPoints[i].Distance = norm;
                        sum += norm;
                        centerDist = norm;
                    }
                }
            }
            var rnd = (double)r.Next(0, 100000) / 100000;
            rnd = rnd * sum;
            sum = 0;
            foreach (var point in AllPoints)
            {
                if (sum < rnd)
                    sum += point.Distance;
                else
                {
                    Clusters[0].Center = point;
                    break;
                }
            }
            sum = 0;
            foreach (var point in AllPoints)
            {
                if (sum < rnd)
                    sum += point.Distance;
                else
                {
                    Clusters[1].Center = point;
                    break;
                }
            }
            
            while (Clusters.Count < k)
            {
                sum = 0;
                double min = double.NegativeInfinity;
                foreach (var point in AllPoints)
                {
                    point.Distance = 0;
                    foreach (var cluster in Clusters)
                    {
                        var norm = await _getDistance(point, cluster.Center);
                        if (norm > min)
                        {
                            min = norm;
                            point.Distance = norm;
                            sum += norm;
                        }
                    }
                }
                rnd = (double)r.Next(0, 100000) / 100000;
                rnd = rnd * sum;
                sum = 0;
                foreach (var point in AllPoints)
                {
                    if (sum < rnd)
                        sum += point.Distance;
                    else
                    {
                        Clusters.Add(new Cluster() { Center = point});
                        break;
                    }
                }
            }
        }
        private async Task _setGreedyCenters(List<Cluster> clust = null)
        {
            //// copy points
            //Point[] tmp = new Point[AllPoints.Count];
            //AllPoints.CopyTo(tmp);
            //var X = tmp.ToList();
            ////
            var clusters = new List<Cluster>();
            //object lockObj = new object();
            if (clust == null)
            {
                foreach (var p in AllPoints)
                {
                    var c = new Cluster() { Center = p };
                    clusters.Add(c);
                }
            }
            else
            {
                clusters = clust;
            }
            while (clusters.Count > k)
            {
                Console.WriteLine(clusters.Count);
                double T = 0;
                clusters = await _quickDistr(clusters);
                //foreach (var center in Clusters)
                //{
                //    foreach (var point in center.Elements)
                //    {
                //        T += Math.Pow(l2(center.Center, point), 2);
                //    }
                //}
                double TxMin = double.NegativeInfinity;
                var centr = new Cluster();
                //
                //var tasks = new List<Task>();
                //var lc = new Object();
                //
                foreach (var c in clusters)
                {
                    //tasks.Add( Task.Run( async () =>
                    //{
                        double Tx = 0;
                        Cluster[] pnt = new Cluster[clusters.Count];
                        clusters.CopyTo(pnt);
                        var clst = pnt.ToList();
                        //clst = await QuickDistr(clst, X);
                        clst = await _distrPoint(c, clst);
                        foreach (var center in clst)
                        {
                            if (c == center) continue;
                            foreach (var point in center.Elements)
                            {
                                Tx += Math.Pow(await _getDistance(center.Center, point), 2);
                            }
                        }
                        if (TxMin <= Tx - T)
                        {
                            //lock (lc)
                            //{
                                TxMin = Tx - T;
                                centr = c;
                            //}
                        }
                    //}));
                }
                //await Task.WhenAll(tasks);
                clusters.Remove(centr);
            }
            foreach (var c in clusters)
            {
                c.Elements.Clear();
            }
            this.Clusters = clusters;
        }
        private async Task _setCombinedCenters()
        {
            int n = (int)(Math.Sqrt(AllPoints.Count));
            int tmpK = k;
            k = n;
            await _setSampledCenters();
            //var tmpAllPoints = AllPoints;
            //AllPoints = this.Clusters;
            k = tmpK;
            await _setGreedyCenters(this.Clusters);
        }
        private async Task<List<Cluster>> _quickDistr(List<Cluster> Clusters)
        {
            object lockObj = new object();
            foreach (var cluster in Clusters)
                cluster.Elements.Clear();
            foreach (var point in AllPoints)
            {
                double min = double.PositiveInfinity;
                int clusterIndex = -1;
                for (int i = 0; i < Clusters.Count; i++)
                {
                    double val = await Distance.Evklid(point, Clusters[i].Center);
                    if (val < min)
                    {
                        min = val;
                        clusterIndex = i;
                    }
                }
                Clusters[clusterIndex].Elements.Add(point);
            }
            return Clusters;
        }
        private async Task<List<Cluster>> _distrPoint(Cluster cluster, List<Cluster> clusters)
        {
            clusters.Remove(cluster);
            foreach (var p in cluster.Elements)
            {
                double min = double.PositiveInfinity;
                int clusterIndex = -1;
                for (int i = 0; i < clusters.Count; i++)
                {
                    double val = await Distance.Evklid(p, clusters[i].Center);
                    if (val < min)
                    {
                        min = val;
                        clusterIndex = i;
                    }
                }
                clusters[clusterIndex].Elements.Add(p);
            }
            return clusters;
        }
        private async Task _setCovMatrix()
        {
            //var tasks = new List<Task>();
            //object lc = new object();
            _covMatrix = new double[AllPoints.Count][];
            for (int i = 0; i < Dimension; i++)
            {
                _covMatrix[i] = new double[AllPoints.Count];
                for (int j = 0; j < Dimension; j++)
                {
                    //tasks.Add(Task.Run(() =>
                    //{
                        double val = -1;
                        for (int k = 0; k < AllPoints.Count; k++)
                        {
                            var avI = AllPoints.Average(el => el.Characters[i]);
                            var avJ = AllPoints.Average(el => el.Characters[j]);
                            val += (AllPoints[k].Characters[i] - avI) * (AllPoints[k].Characters[j] - avJ);
                        }
                        //lock (lc)
                        //{
                            _covMatrix[i][j] = (double)val / (AllPoints.Count - 1);
                        //}
                    //}));
                }
            }
            //await Task.WhenAll(tasks);
        }
        private async Task<double> _getDistance(Point x, Point y)
        {
            return UseMahalanobisDistance
                            ? await Distance.Mahalanobis(x, y, _covMatrix)
                            : await Distance.Evklid(x, y);
        }
        #endregion
        #region Public Logic
        public async Task<string> LoadDataFromFile(Action<Point> callback)
        {
            var res = await DataLoader.LoadData(AllPoints, callback);
            if(!string.IsNullOrEmpty(res))
                await _setCovMatrix();
            return res;
        }
        public async Task SetCentersFirstTime()
        {
            if (_concreteCenters)
                return;
            Clusters = new List<Cluster>();
            if (AllPoints.Count < k)
                throw new InvalidOperationException("Points count is less then clusters");
            if (CenterMode == CoreLib.CenterMode.Random)
                await _setRandomCenters();
            else if (CenterMode == CoreLib.CenterMode.K_means_plus)
                await _setCleverCenters();
            else if (CenterMode == CenterMode.Refinement)
                await _setRefinedCenters();
            else if (CenterMode == CoreLib.CenterMode.Sampling)
                await _setSampledCenters();
            else if (CenterMode == CoreLib.CenterMode.Deletion)
                await _setGreedyCenters();
            else if (CenterMode == CoreLib.CenterMode.Combined)
                await _setCombinedCenters();
        }
        public async Task SetCenters()
        {
            //var tasks = new List<Task>();
            foreach (var cluster in Clusters)
            {
                //tasks.Add(async () =>
                //{
                    await cluster.RefreshCenter();
                //});
            }
        }
        public async Task<double> GetQuality()
        {
            double quality = 0;
            foreach (var cluster in Clusters)
            {
                quality += cluster.Elements.Sum(elem =>
                {
                    var val = Distance.Evklid(cluster.Center, elem);
                    val.Wait();
                    return val.Result;
                });
            }
            return quality;
        }
        public async Task Distribute(Action<Point, int> callback = null, int K=-1)
        {
            object lockObj = new object();
            if (K == -1) K = k;
            foreach (var cluster in Clusters)
            {
                lock (lockObj)
                {
                    cluster.Elements.Clear();
                }
            }
            foreach (var point in AllPoints)
            {
                double min = double.PositiveInfinity;
                int clusterIndex = -1;
                for (int i = 0; i < K; i++)
                {
                    double val = await _getDistance(point, Clusters[i].Center);
                    if (val < min)
                    {
                        min = val;
                        clusterIndex = i;
                    }
                }
                lock (lockObj)
                {
                    Clusters[clusterIndex].Elements.Add(point);
                }
                if(callback!= null)
                    callback(point, clusterIndex);
                if (Modification == Modification.Makkin)
                    lock (lockObj)
                    {
                        Clusters[clusterIndex].RefreshCenter().Wait();
                    }
            }
        }
        public async Task DistributeByHarting_Wong(Action<Point, int> callback) 
        {
            var liveSet = new List<Cluster>();
            var newLiveSet = new List<Cluster>();

            // clear clusters
            foreach (var cluster in Clusters)
            {
                cluster.Elements.Clear();
                liveSet.Add(cluster);
            }

            // find closest and second closest cluster for each point
            foreach (var point in AllPoints)
            {
                Clusters.Sort( (cl1, cl2) => 
                {
                    var val1 = Distance.Evklid(point, cl1.Center);
                    var val2 = Distance.Evklid(point, cl2.Center);
                    val1.Wait();
                    val2.Wait();
                    return val1.Result < val2.Result ? -1 : 1;
                });
                point.ClosestCluster = Clusters[0];
                point.SecodClosestCluster = Clusters[1];
                Clusters[0].Elements.Add(point);
            }

            // refresh centers
            foreach (var cluster in Clusters)
            {
                await cluster.RefreshCenter();
            }

            while (IterationCount < 1000)
            {
                foreach (var point in AllPoints)
                {
                    double min = double.PositiveInfinity;
                    Cluster clust = null;
                    foreach (var cluster in Clusters.Where(cl =>
                                                                    {
                                                                        if (liveSet.Contains(point.ClosestCluster))
                                                                            return cl != point.ClosestCluster;
                                                                        else
                                                                            return cl != point.ClosestCluster && liveSet.Contains(cl);
                                                                    }))
                    {
                        var r2 = (double)(cluster.ElementCount * Math.Pow(await Distance.Evklid(point, cluster.Center), 2)) / (cluster.ElementCount + 1);
                        if (r2 < min)
                        {
                            min = r2;
                            clust = cluster;
                        }
                    }
                    var r1 = (double)(point.ClosestCluster.ElementCount * Math.Pow(await Distance.Evklid(point, point.ClosestCluster.Center), 2)) / (point.ClosestCluster.ElementCount - 1);
                    if (min > r1)
                    {
                        point.SecodClosestCluster = clust;
                        point.Distance = r1;
                    }
                    else
                    {
                        point.ClosestCluster.Elements.Remove(point);
                        clust.Elements.Add(point);
                        point.SecodClosestCluster = point.ClosestCluster;
                        point.ClosestCluster = clust;
                        if (!newLiveSet.Contains(point.ClosestCluster))
                            newLiveSet.Add(point.ClosestCluster);
                        if (!newLiveSet.Contains(point.SecodClosestCluster))
                            newLiveSet.Add(point.SecodClosestCluster);
                        foreach (var cluster in liveSet)
                        {
                            await cluster.RefreshCenter();
                        }
                    }
                }

                if (liveSet.Count == 0)
                {
                    return;
                }

                bool flag = true;
                while (flag)
                {
                    flag = false;
                    foreach (var point in AllPoints)
                    {
                        // possible check from step 6
                        var r1 = (double)(point.ClosestCluster.ElementCount * Math.Pow(await Distance.Evklid(point, point.ClosestCluster.Center), 2)) / (point.ClosestCluster.ElementCount - 1);
                        var r2 = (double)(point.SecodClosestCluster.ElementCount * Math.Pow(await Distance.Evklid(point, point.SecodClosestCluster.Center), 2)) / (point.SecodClosestCluster.ElementCount - 1);
                        if (r1 > r2)
                        {
                            flag = true;
                            //
                            point.ClosestCluster.Elements.Remove(point);
                            point.SecodClosestCluster.Elements.Add(point);
                            //
                            var tmp = point.ClosestCluster;
                            point.ClosestCluster = point.SecodClosestCluster;
                            point.SecodClosestCluster = tmp;
                            if (!newLiveSet.Contains(point.ClosestCluster))
                                newLiveSet.Add(point.ClosestCluster);
                            if (!newLiveSet.Contains(point.SecodClosestCluster))
                                newLiveSet.Add(point.SecodClosestCluster);
                            await point.ClosestCluster.RefreshCenter();
                            await point.SecodClosestCluster.RefreshCenter();
                        }
                    }
                }
                IterationCount++;
                liveSet = newLiveSet;
                newLiveSet = new List<Cluster>();
            }
        }
        public async Task<double> Solve(Action<Point, int> callback)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            IterationCount = 0;
            await SetCentersFirstTime();

            if (Modification == Modification.Harting_Vong)
                await DistributeByHarting_Wong(callback);
            else
            {
                do
                {
                    await Distribute(callback);
                    await SetCenters();
                    IterationCount++;
                }
                while (!_stopFlag && IterationCount < 10000);
            }

            watch.Stop();
            OperationTime = (double)watch.ElapsedMilliseconds;
            return await this.GetQuality();
        }
        #endregion
    }
}