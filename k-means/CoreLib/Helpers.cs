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
            Clusters = new List<Cluster>();
            AllPoints = new List<Point>();
        }
        public int k { get; set; }
        public List<Cluster> Clusters { get; set; }
        public List<Point> AllPoints { get; set; }
        public int Dimension { get { return AllPoints.FirstOrDefault().Characters.Count; } }
        public Modification Modification { get; set; }
        public bool UseMahalanobisDistance { get; set; }
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
                            return true;
                    }
                }
                return false;
            }
        }
        private double[][] _covMatrix;
        public double OperationTime { get; private set; }
        /* todo
        public bool tmp()
        {
            double eps = 0.001;
            foreach (var cluster in Clusters)
            {
                for (int i = 0; i < cluster.Dimention; i++)
                {
                    if (Math.Abs(cluster.Center.Characters[i] - cluster.PrevCenter.Characters[i]) > eps)
                        return true;
                }
            }
            return false;
        }
        */
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
            SetRandomCenters();
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
        public double Solve()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            var count = 0;
            SetCentersFirstTime();
            while (count < 100)
            //do
            {
                SetCenters();
                Distribute();
                count++;
            }
            //while (!tmp());

            watch.Stop();
            OperationTime = (double)watch.ElapsedMilliseconds;
            return this.GetQuality();
        }

    }

}
