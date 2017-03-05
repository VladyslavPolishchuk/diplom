using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace CoreLib
{
    public enum Modification
    {
        Makkin,
        Lloid,
        Harting_Vong
    }
    internal static class Distance
    {
        public static double Evklid(Point x, Point y)
        {
            if (x.Characters.Count != y.Characters.Count)
                throw new InvalidOperationException("Length of x array is not equel to length of y array");
            double res = 0;
            for (int i = 0; i < x.Characters.Count; i++)
            {
                res += Math.Pow(x.Characters[i] - y.Characters[i], 2);
            }
            return Math.Sqrt(res);
        }
        public static double Mahalanobis(Point x, Point y, double[][] _covMatrixInv)
        {
            if (x.Characters.Count != y.Characters.Count)
                throw new InvalidOperationException("Length of x array is not equel to length of y array");

            double[] delta = new double[x.Characters.Count];
            for (int i = 0; i < x.Characters.Count; i++)
            {
                delta[i] = x.Characters[i] - y.Characters[i];
            }

            double[] deltaS = new double[x.Characters.Count];
            for (int i = 0; i < deltaS.Length; i++)
            {
                deltaS[i] = 0;
                for (int j = 0; j < x.Characters.Count; j++)
                {
                    deltaS[i] += delta[j] * _covMatrixInv[j][i];
                }
            }

            double d = 0;
            for (int i = 0; i < x.Characters.Count; i++)
            {
                d += deltaS[i] * delta[i];
            }

            return Math.Sqrt(d);
        }
    }

    internal static class DataLoader
    {
        public static string LoadData(List<Point> points)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() != DialogResult.OK) return null;
            points.Clear();
            var reader = new StreamReader(dialog.FileName);
            while (!reader.EndOfStream)
            {
                var str = reader.ReadLine().Split(new char[]{' ', ',', ';'});
                var point = new Point();
                foreach (var elem in str)
                {
                    if (string.IsNullOrEmpty(elem)) continue;
                    point.Characters.Add(Convert.ToDouble(elem));
                }
                points.Add(point);
            }
            return dialog.SafeFileName;
        }
    }
    
    public class Point
    {
        public Point()
        {
            Characters = new List<double>();
        }
        public List<double> Characters { get; set; }
    }

    public class Cluster
    {
        public List<Point> Elements { get; set; }
        public Point Center { get; set; }
        public Point PrevCenter { get; set; }
        public int ElementCount { get { return Elements.Count; } }
        public int Dimention { get { return Elements.First().Characters.Count; } }
        public Cluster()
        {
            Elements = new List<Point>();
            Center = new Point();
        }

        public void RefreshCenter()
        {
            /* Mid
            Point res = new Point();
            for (int i = 0; i < Dimention; i++)
            {
                double ch = 0;
                for (int j = 0; j < ElementCount; j++)
                {
                    ch += Elements[j].Characters[i];
                }
                res.Characters.Add((double)ch / ElementCount);
            }
            PrevCenter = Center;
            Center = res;*/

            // Me
            Point res = new Point();
            for (int i = 0; i < Dimention; i++)
            {
                Elements.Sort((el1, el2) =>
                {
                    return el1.Characters[i] > el2.Characters[i] ? 1 : -1;
                });
                res.Characters.Add(Elements[(int)ElementCount / 2].Characters[i]);
            }
            PrevCenter = Center;
            Center = res;
        }
    }

}
