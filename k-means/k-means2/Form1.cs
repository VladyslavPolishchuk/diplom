using CoreLib;
using System;
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
            chart1.Series.Add("all");
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                chart1.Series.Clear();
                chart1.Series.Add("all");
                chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                helper.LoadDataFromFile(new Action<CoreLib.Point>(point =>
                    {
                        this.Invoke( new Action<CoreLib.Point>( p => {
                            chart1.Series[0].Points.AddXY(p.Characters[axisX], p.Characters[axisY]);
                        }),point);
                    })).ContinueWith<string>( task =>
                {
                    this.Invoke( new Action(() =>
                    {
                        var fileName = task.Result;
                        if (string.IsNullOrEmpty(fileName)) return;
                        filename.Text = fileName;
                        dimension.Text = helper.Dimension.ToString();

                        isSolved = false;
                        cb1.Items.Clear(); cb2.Items.Clear();
                        for (int i = 0; i < helper.Dimension; i++)
                        {
                            cb1.Items.Add(i);
                            cb2.Items.Add(i);
                        }
                        axisX = 0; axisY = 1;
                        cb1.SelectedIndex = axisX; cb2.SelectedIndex = axisY;
                    }));
                    return "";
                });
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

                // chose center selection type
                if (random.Checked) helper.CenterMode = CenterMode.Random;
                else if (k_means_plus.Checked) helper.CenterMode = CenterMode.K_means_plus;
                else if (refinement.Checked) helper.CenterMode = CenterMode.Refinement;
                else if (sampling.Checked) helper.CenterMode = CenterMode.Sampling;
                else if (deletion.Checked) helper.CenterMode = CenterMode.Deletion;
                else helper.CenterMode = CenterMode.Combined;

                chart1.Series.Clear();
                for (int i = 0; i < helper.k; i++)
                {
                    chart1.Series.Add(i.ToString());
                    chart1.Series[i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                }
                helper.Solve(null).ContinueWith(res => {
                    this.Invoke(new Action(() => 
                    { 
                        quality.Text = res.Result.ToString("0.000");
                        DisplayClusters();
                        isSolved = true;
                        operationTime.Text = helper.OperationTime.ToString();
                        iterations.Text = helper.IterationCount.ToString();
                    }));
                });
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
                // print points to chart
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
                
                //print points to grid
                if(points.ColumnCount > 2)
                    for (int i = 0; i < helper.Dimension; i++)
                    {
                        points.Columns.RemoveAt(2);
                        centers.Columns.RemoveAt(2);
                        points.Rows.Clear();
                        centers.Rows.Clear();
                    }
                for (int i = 0; i < helper.Dimension; i++)
                {
                    points.Columns.Add(string.Format("x{0}", i + 1), string.Format("char{0}", i + 1));
                    centers.Columns.Add(string.Format("x{0}", i + 1), string.Format("char{0}", i + 1));
                }
                int pointIndex = 0;
                for (int i = 0; i < helper.Clusters.Count; i++)
                {
                    centers.Rows.Add();
                    centers.Rows[i].Cells[0].Value = (i + 1).ToString();
                    centers.Rows[i].Cells[1].Value = helper.Clusters[i].ElementCount;
                    for (int j = 0; j < helper.Dimension; j++)
                    {
                        centers.Rows[i].Cells[j + 2].Value = helper.Clusters[i].Center.Characters[j];
                    }
                    for (int j = 0; j < helper.Clusters[i].ElementCount; j++)
                    {
                        points.Rows.Add();
                        points.Rows[pointIndex].Cells[0].Value = pointIndex + 1;
                        points.Rows[pointIndex].Cells[1].Value = i + 1;
                        for (int k = 0; k < helper.Dimension; k++)
                        {
                            points.Rows[pointIndex].Cells[k + 2].Value = helper.Clusters[i].Elements[j].Characters[k];
                        }
                        pointIndex++;
                    }
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
