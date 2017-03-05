using CoreLib;
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
            try
            {
                var fileName = helper.LoadDataFromFile();
                if (string.IsNullOrEmpty(fileName)) return;
                filename.Text = fileName;
                dimension.Text = helper.Dimension.ToString();

                cb1.Items.Clear(); cb2.Items.Clear();
                for (int i = 0; i < helper.Dimension; i++)
                {
                    cb1.Items.Add(i);
                    cb2.Items.Add(i);
                }
                axisX = 0; axisY = 1;
                cb1.SelectedIndex = axisX; cb2.SelectedIndex = axisY;
                DisplayAll();
                isSolved = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                // chouse modification
                if (makkin.Checked) helper.Modification = Modification.Makkin;
                else if (harting_vang.Checked) helper.Modification = Modification.Harting_Vong;
                else helper.Modification = Modification.Lloid;

                // chose metric
                helper.UseMahalanobisDistance = mahalanobis.Checked;

                quality.Text = helper.Solve().ToString("0.0");
                DisplayClusters();
                isSolved = true;
                operationTime.Text = helper.OperationTime.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DisplayAll()
        {
            try
            {
                chart1.Series.Clear();

                chart1.Series.Add("all");
                chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                foreach (var p in helper.AllPoints)
                {
                    chart1.Series[0].Points.AddXY(p.Characters[axisX], p.Characters[axisY]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DisplayClusters()
        {
            try
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
                    // add center point with bigger size
                    chart1.Series[i].Points.AddXY(helper.Clusters[i].Center.Characters[axisX], helper.Clusters[i].Center.Characters[axisY]);
                    chart1.Series[i].Points[chart1.Series[i].Points.Count - 1].MarkerSize = 10;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cb1_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cb1.SelectedItem != null)
                    axisX = Convert.ToByte(cb1.SelectedItem);
                if (cb2.SelectedItem != null)
                    axisY = Convert.ToByte(cb2.SelectedItem);
                if (isSolved)
                    DisplayClusters();
                else
                    DisplayAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void k_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (k.Text == string.Empty) return;
                helper.k = Convert.ToInt16(k.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                k.Text = 2.ToString();
                helper.k = 2;
            }
        }
    }
}
