﻿using CoreLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace k_means2
{
    public partial class Form1 : Form
    {
        Helper helper = new Helper();
        byte axisX = 0;
        byte axisY = 1;
        bool isSolved = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!helper.LoadDataFromFile()) return;

            dimension.Text = helper.Dimension.ToString();

            cb1.Items.Clear();  cb2.Items.Clear();
            for (int i = 0; i < helper.Dimension; i++)
            {
                cb1.Items.Add(i);
                cb2.Items.Add(i);
            }
            cb1.SelectedIndex = axisX; cb2.SelectedIndex = axisY;
            DisplayAll();
            isSolved = false;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            helper.Solve();
            DisplayClusters();
            isSolved = true;
            operationTime.Text = helper.OperationTime.ToString();
        }

        private void DisplayAll()
        {
            chart1.Series.Clear();

            chart1.Series.Add("all");
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            foreach (var p in helper.AllPoints)
            {
                chart1.Series[0].Points.AddXY(p.Characters[axisX], p.Characters[axisY]);
            }
        }

        private void DisplayClusters()
        {
            chart1.Series.Clear();
            for (int i = 0; i < helper.k; i++)
            {
                chart1.Series.Add(i.ToString());
                chart1.Series[i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                for (int j = 0; j < helper.Clusters[i].ElementCount; j++)
                {
                    chart1.Series[i].Points.AddXY(helper.Clusters[i].Elements[j].Characters[axisX], helper.Clusters[i].Elements[j].Characters[axisY]);
                }
            }
        }

        private void cb1_SelectedValueChanged(object sender, EventArgs e)
        {
            if(cb1.SelectedItem!= null)
                axisX = Convert.ToByte(cb1.SelectedItem);
            if (cb2.SelectedItem != null)
                axisY = Convert.ToByte(cb2.SelectedItem);
            if (isSolved)
                DisplayClusters();
            else
                DisplayAll();
        }
    }
}