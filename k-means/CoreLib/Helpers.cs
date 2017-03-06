using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLib
{
    public class Helper
    {
        public Helper()
        {
            k = 2;
            Modification = Modification.Lloid;
            UseMahalanobisDistance = true;
            IsRandomCentres = true;
            Clusters = new List<Cluster>();
            AllPoints = new List<Point>();
        }
        public int k { get; set; }
        public List<Cluster> Clusters { get; set; }
        public List<Point> AllPoints { get; set; }
        public int Dimension { get { return AllPoints.FirstOrDefault().Characters.Count; } }
        public Modification Modification { get; set; }
        public bool UseMahalanobisDistance { get; set; }
        public bool IsRandomCentres { get; set; }
        public int IterationCount { get; private set; }
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
        private double[][] _covMatrix;
        public double OperationTime { get; private set; }
        
        #region Private logic
        private void SetRandomCenters()
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
                Clusters[i].RefreshCenter();
            }
        }
        private void SetCleverCenters()
        {
            Random r = new Random();
            Clusters.Add(new Cluster());
            Clusters[0].Elements.Add(AllPoints[r.Next(0, AllPoints.Count)]);
            Clusters[0].RefreshCenter();
            while (Clusters.Count < k)
            {
                double sum = 0;
                foreach (var point in AllPoints)
                {
                    foreach (var cluster in Clusters)
                    {
                        var curDist = UseMahalanobisDistance ?
                            Distance.Mahalanobis(point, cluster.Center, _covMatrix) : Distance.Evklid(point, cluster.Center);
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
                        Clusters[Clusters.Count - 1].RefreshCenter();
                        break;
                    }
                }
            }
        }
        private void SetCovMatrix()
        {
            _covMatrix = new double[AllPoints.Count][];
            for (int i = 0; i < Dimension; i++)
            {
                _covMatrix[i] = new double[AllPoints.Count];
                for (int j = 0; j < Dimension; j++)
                {
                    double val = -1;
                    for (int k = 0; k < AllPoints.Count; k++)
                    {
                        var avI = AllPoints.Average(el => el.Characters[i]);
                        var avJ = AllPoints.Average(el => el.Characters[j]);
                        val += (AllPoints[k].Characters[i] - avI)*(AllPoints[k].Characters[j] - avJ);
                    }
                    _covMatrix[i][j] = (double)val / (AllPoints.Count - 1);
                }
            }
        }
        #endregion
        public string LoadDataFromFile()
        {
            var res =  DataLoader.LoadData(AllPoints);
            if(!string.IsNullOrEmpty(res))
                SetCovMatrix();
            return res;
        }
        public void SetCentersFirstTime()
        {
            Clusters = new List<Cluster>();
            //foreach (var cluster in Clusters)
            //{
            //    cluster.Elements.Clear();
            //    cluster.Center = null;
            //}
            if (AllPoints.Count < k)
                throw new InvalidOperationException("Points count is less then clusters");
            if (IsRandomCentres)
                SetRandomCenters();
            else
                SetCleverCenters();
        }

        public void SetCenters()
        {
            foreach (var cluster in Clusters)
            {
                cluster.RefreshCenter();
            }
        }
        public double GetQuality()
        {
            double quality = 0;
            foreach (var cluster in Clusters)
            {
                quality += cluster.Elements.Sum(elem => Distance.Evklid(cluster.Center, elem));
            }
            return quality;
        }

        public void Distribute()
        {
            foreach (var cluster in Clusters)
            {
                cluster.Elements.Clear();
            }
            foreach (var point in AllPoints)
            {
                double min = double.PositiveInfinity;
                int clusterIndex = -1;
                for (int i = 0; i < k; i++)
                {
                    double val = UseMahalanobisDistance ?
                        Distance.Mahalanobis(point, Clusters[i].Center, _covMatrix) : Distance.Evklid(point, Clusters[i].Center);
                    if (val < min)
                    {
                        min = val;
                        clusterIndex = i;
                    }
                }
                Clusters[clusterIndex].Elements.Add(point);
                if (Modification == Modification.Makkin)
                    Clusters[clusterIndex].RefreshCenter();
            }
        }
        public void DistributeByHarting_Wong() 
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
                    return Distance.Evklid(point, cl1.Center) < Distance.Evklid(point, cl2.Center) ? -1 : 1;
                });
                point.ClosestCluster = Clusters[0];
                point.SecodClosestCluster = Clusters[1];
                Clusters[0].Elements.Add(point);
            }

            // refresh centers
            foreach (var cluster in Clusters)
            {
                cluster.RefreshCenter();
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
                        var r2 = (double)(cluster.ElementCount * Math.Pow(Distance.Evklid(point, cluster.Center), 2)) * (cluster.ElementCount + 1);
                        if (r2 < min)
                        {
                            min = r2;
                            clust = cluster;
                        }
                    }
                    var r1 = (double)(point.ClosestCluster.ElementCount * Math.Pow(Distance.Evklid(point, point.ClosestCluster.Center), 2)) * (point.ClosestCluster.ElementCount - 1);
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
                            cluster.RefreshCenter();
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
                        var r1 = (double)(point.ClosestCluster.ElementCount * Math.Pow(Distance.Evklid(point, point.ClosestCluster.Center), 2)) * (point.ClosestCluster.ElementCount - 1);
                        var r2 = (double)(point.SecodClosestCluster.ElementCount * Math.Pow(Distance.Evklid(point, point.SecodClosestCluster.Center), 2)) * (point.SecodClosestCluster.ElementCount + 1);
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
                            point.ClosestCluster.RefreshCenter();
                            point.SecodClosestCluster.RefreshCenter();
                        }
                    }
                }
                IterationCount++;
                liveSet = newLiveSet;
                newLiveSet = new List<Cluster>();
            }
        }
        public double Solve()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            IterationCount = 0;
            SetCentersFirstTime();

            if (Modification == Modification.Harting_Vong)
                DistributeByHarting_Wong();
            else
            {
                do
                {
                    Distribute();
                    SetCenters();
                    IterationCount++;
                }
                while (!_stopFlag && IterationCount < 10000);
            }

            watch.Stop();
            OperationTime = (double)watch.ElapsedMilliseconds;
            return this.GetQuality();
        }

    }

}
