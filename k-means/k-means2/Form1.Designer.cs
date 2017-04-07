namespace k_means2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.centers = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.points = new System.Windows.Forms.DataGridView();
            this.number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cluster = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.operationTime = new System.Windows.Forms.Label();
            this.dimension = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cb1 = new System.Windows.Forms.ComboBox();
            this.cb2 = new System.Windows.Forms.ComboBox();
            this.quality = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.k = new System.Windows.Forms.TextBox();
            this.mahalanobis = new System.Windows.Forms.RadioButton();
            this.evklid = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.sampling = new System.Windows.Forms.RadioButton();
            this.refinement = new System.Windows.Forms.RadioButton();
            this.random = new System.Windows.Forms.RadioButton();
            this.k_means_plus = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.harting_vang = new System.Windows.Forms.RadioButton();
            this.lloid = new System.Windows.Forms.RadioButton();
            this.makkin = new System.Windows.Forms.RadioButton();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.iterations = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.filename = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.deletion = new System.Windows.Forms.RadioButton();
            this.combined = new System.Windows.Forms.RadioButton();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.centers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.points)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(1, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(980, 651);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel4);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.chart1);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(972, 622);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Choose file";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(1384, 487);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(168, 100);
            this.panel4.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(3, 593);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Solve";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Location = new System.Drawing.Point(105, 0);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(861, 626);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Choose file";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.centers);
            this.tabPage2.Controls.Add(this.points);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(972, 622);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Results";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(500, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 17);
            this.label9.TabIndex = 14;
            this.label9.Text = "Centers";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "Points";
            // 
            // centers
            // 
            this.centers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.centers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.centers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.count});
            this.centers.Location = new System.Drawing.Point(503, 28);
            this.centers.Name = "centers";
            this.centers.RowTemplate.Height = 24;
            this.centers.Size = new System.Drawing.Size(466, 585);
            this.centers.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "number";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 60;
            // 
            // count
            // 
            this.count.HeaderText = "Points count";
            this.count.Name = "count";
            this.count.Width = 80;
            // 
            // points
            // 
            this.points.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.points.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.points.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.number,
            this.cluster});
            this.points.Location = new System.Drawing.Point(7, 28);
            this.points.Name = "points";
            this.points.RowTemplate.Height = 24;
            this.points.Size = new System.Drawing.Size(490, 585);
            this.points.TabIndex = 0;
            // 
            // number
            // 
            this.number.HeaderText = "number";
            this.number.Name = "number";
            this.number.Width = 80;
            // 
            // cluster
            // 
            this.cluster.HeaderText = "Cluster #";
            this.cluster.Name = "cluster";
            this.cluster.Width = 70;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Time(ms)";
            // 
            // operationTime
            // 
            this.operationTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.operationTime.AutoSize = true;
            this.operationTime.Location = new System.Drawing.Point(96, 95);
            this.operationTime.Name = "operationTime";
            this.operationTime.Size = new System.Drawing.Size(12, 17);
            this.operationTime.TabIndex = 3;
            this.operationTime.Text = " ";
            // 
            // dimension
            // 
            this.dimension.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dimension.AutoSize = true;
            this.dimension.Location = new System.Drawing.Point(96, 61);
            this.dimension.Name = "dimension";
            this.dimension.Size = new System.Drawing.Size(12, 17);
            this.dimension.TabIndex = 8;
            this.dimension.Text = " ";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Dimension";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "AxisX";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(94, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "AxisY";
            // 
            // cb1
            // 
            this.cb1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cb1.FormattingEnabled = true;
            this.cb1.Location = new System.Drawing.Point(48, 3);
            this.cb1.Name = "cb1";
            this.cb1.Size = new System.Drawing.Size(39, 24);
            this.cb1.TabIndex = 11;
            this.cb1.SelectedValueChanged += new System.EventHandler(this.cb1_SelectedValueChanged);
            // 
            // cb2
            // 
            this.cb2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cb2.FormattingEnabled = true;
            this.cb2.Location = new System.Drawing.Point(132, 3);
            this.cb2.Name = "cb2";
            this.cb2.Size = new System.Drawing.Size(39, 24);
            this.cb2.TabIndex = 12;
            this.cb2.SelectedValueChanged += new System.EventHandler(this.cb1_SelectedValueChanged);
            // 
            // quality
            // 
            this.quality.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.quality.AutoSize = true;
            this.quality.Location = new System.Drawing.Point(85, 78);
            this.quality.Name = "quality";
            this.quality.Size = new System.Drawing.Size(12, 17);
            this.quality.TabIndex = 14;
            this.quality.Text = " ";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "Quality";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 17);
            this.label6.TabIndex = 15;
            this.label6.Text = "Clusters #";
            // 
            // k
            // 
            this.k.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.k.Location = new System.Drawing.Point(93, 38);
            this.k.Name = "k";
            this.k.Size = new System.Drawing.Size(28, 22);
            this.k.TabIndex = 16;
            this.k.Text = "2";
            this.k.TextChanged += new System.EventHandler(this.k_TextChanged);
            // 
            // mahalanobis
            // 
            this.mahalanobis.AutoSize = true;
            this.mahalanobis.Checked = true;
            this.mahalanobis.Location = new System.Drawing.Point(27, 101);
            this.mahalanobis.Name = "mahalanobis";
            this.mahalanobis.Size = new System.Drawing.Size(109, 21);
            this.mahalanobis.TabIndex = 17;
            this.mahalanobis.TabStop = true;
            this.mahalanobis.Text = "Mahalanobis";
            this.mahalanobis.UseVisualStyleBackColor = true;
            // 
            // evklid
            // 
            this.evklid.AutoSize = true;
            this.evklid.Location = new System.Drawing.Point(27, 121);
            this.evklid.Name = "evklid";
            this.evklid.Size = new System.Drawing.Size(66, 21);
            this.evklid.TabIndex = 18;
            this.evklid.Text = "Evklid";
            this.evklid.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 17);
            this.label8.TabIndex = 19;
            this.label8.Text = "Distance";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cb2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cb1);
            this.panel1.Location = new System.Drawing.Point(985, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(188, 33);
            this.panel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.evklid);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.mahalanobis);
            this.panel2.Controls.Add(this.k);
            this.panel2.Location = new System.Drawing.Point(985, 58);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(188, 423);
            this.panel2.TabIndex = 5;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.combined);
            this.panel6.Controls.Add(this.deletion);
            this.panel6.Controls.Add(this.sampling);
            this.panel6.Controls.Add(this.refinement);
            this.panel6.Controls.Add(this.random);
            this.panel6.Controls.Add(this.k_means_plus);
            this.panel6.Location = new System.Drawing.Point(28, 279);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(152, 135);
            this.panel6.TabIndex = 25;
            // 
            // sampling
            // 
            this.sampling.AutoSize = true;
            this.sampling.Location = new System.Drawing.Point(3, 65);
            this.sampling.Name = "sampling";
            this.sampling.Size = new System.Drawing.Size(87, 21);
            this.sampling.TabIndex = 24;
            this.sampling.Text = "Sampling";
            this.sampling.UseVisualStyleBackColor = true;
            // 
            // refinement
            // 
            this.refinement.AutoSize = true;
            this.refinement.Location = new System.Drawing.Point(3, 45);
            this.refinement.Name = "refinement";
            this.refinement.Size = new System.Drawing.Size(146, 21);
            this.refinement.TabIndex = 23;
            this.refinement.Text = "Refinement (J=10)";
            this.refinement.UseVisualStyleBackColor = true;
            // 
            // random
            // 
            this.random.AutoSize = true;
            this.random.Checked = true;
            this.random.Location = new System.Drawing.Point(3, 5);
            this.random.Name = "random";
            this.random.Size = new System.Drawing.Size(82, 21);
            this.random.TabIndex = 21;
            this.random.TabStop = true;
            this.random.Text = "Random";
            this.random.UseVisualStyleBackColor = true;
            // 
            // k_means_plus
            // 
            this.k_means_plus.AutoSize = true;
            this.k_means_plus.Location = new System.Drawing.Point(3, 25);
            this.k_means_plus.Name = "k_means_plus";
            this.k_means_plus.Size = new System.Drawing.Size(99, 21);
            this.k_means_plus.TabIndex = 22;
            this.k_means_plus.Text = "k-means++";
            this.k_means_plus.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.harting_vang);
            this.panel3.Controls.Add(this.lloid);
            this.panel3.Controls.Add(this.makkin);
            this.panel3.Location = new System.Drawing.Point(28, 178);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(117, 72);
            this.panel3.TabIndex = 5;
            // 
            // harting_vang
            // 
            this.harting_vang.AutoSize = true;
            this.harting_vang.Location = new System.Drawing.Point(3, 45);
            this.harting_vang.Name = "harting_vang";
            this.harting_vang.Size = new System.Drawing.Size(121, 21);
            this.harting_vang.TabIndex = 24;
            this.harting_vang.Text = "Hartigan-Vong";
            this.harting_vang.UseVisualStyleBackColor = true;
            // 
            // lloid
            // 
            this.lloid.AutoSize = true;
            this.lloid.Checked = true;
            this.lloid.Location = new System.Drawing.Point(3, 4);
            this.lloid.Name = "lloid";
            this.lloid.Size = new System.Drawing.Size(59, 21);
            this.lloid.TabIndex = 21;
            this.lloid.TabStop = true;
            this.lloid.Text = "Lloid";
            this.lloid.UseVisualStyleBackColor = true;
            // 
            // makkin
            // 
            this.makkin.AutoSize = true;
            this.makkin.Location = new System.Drawing.Point(3, 25);
            this.makkin.Name = "makkin";
            this.makkin.Size = new System.Drawing.Size(98, 21);
            this.makkin.TabIndex = 22;
            this.makkin.Text = "MakQueen";
            this.makkin.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(16, 259);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 17);
            this.label14.TabIndex = 26;
            this.label14.Text = "Centers";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 158);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 17);
            this.label11.TabIndex = 23;
            this.label11.Text = "Modification";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(109, 17);
            this.label10.TabIndex = 20;
            this.label10.Text = "Customization";
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.label15);
            this.panel5.Controls.Add(this.iterations);
            this.panel5.Controls.Add(this.label13);
            this.panel5.Controls.Add(this.filename);
            this.panel5.Controls.Add(this.label12);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.quality);
            this.panel5.Controls.Add(this.operationTime);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.dimension);
            this.panel5.Location = new System.Drawing.Point(985, 513);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(188, 131);
            this.panel5.TabIndex = 15;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(7, 27);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(66, 17);
            this.label15.TabIndex = 24;
            this.label15.Text = "Iterations";
            // 
            // iterations
            // 
            this.iterations.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.iterations.AutoSize = true;
            this.iterations.Location = new System.Drawing.Point(96, 27);
            this.iterations.Name = "iterations";
            this.iterations.Size = new System.Drawing.Size(12, 17);
            this.iterations.TabIndex = 25;
            this.iterations.Text = " ";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 44);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 17);
            this.label13.TabIndex = 22;
            this.label13.Text = "File name";
            // 
            // filename
            // 
            this.filename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.filename.AutoSize = true;
            this.filename.Location = new System.Drawing.Point(96, 44);
            this.filename.Name = "filename";
            this.filename.Size = new System.Drawing.Size(48, 17);
            this.filename.TabIndex = 23;
            this.filename.Text = "NONE";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(3, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 17);
            this.label12.TabIndex = 21;
            this.label12.Text = "Info";
            // 
            // deletion
            // 
            this.deletion.AutoSize = true;
            this.deletion.Location = new System.Drawing.Point(3, 85);
            this.deletion.Name = "deletion";
            this.deletion.Size = new System.Drawing.Size(130, 21);
            this.deletion.TabIndex = 25;
            this.deletion.Text = "Greedy deletion";
            this.deletion.UseVisualStyleBackColor = true;
            // 
            // combined
            // 
            this.combined.AutoSize = true;
            this.combined.Location = new System.Drawing.Point(3, 105);
            this.combined.Name = "combined";
            this.combined.Size = new System.Drawing.Size(92, 21);
            this.combined.TabIndex = 26;
            this.combined.Text = "Combined";
            this.combined.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1182, 653);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "k-means";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.centers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.points)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label operationTime;
        private System.Windows.Forms.Label dimension;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb1;
        private System.Windows.Forms.ComboBox cb2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label quality;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox k;
        private System.Windows.Forms.RadioButton mahalanobis;
        private System.Windows.Forms.RadioButton evklid;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton harting_vang;
        private System.Windows.Forms.RadioButton lloid;
        private System.Windows.Forms.RadioButton makkin;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label filename;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.RadioButton random;
        private System.Windows.Forms.RadioButton k_means_plus;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label iterations;
        private System.Windows.Forms.RadioButton sampling;
        private System.Windows.Forms.RadioButton refinement;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView centers;
        private System.Windows.Forms.DataGridView points;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn count;
        private System.Windows.Forms.DataGridViewTextBoxColumn number;
        private System.Windows.Forms.DataGridViewTextBoxColumn cluster;
        private System.Windows.Forms.RadioButton combined;
        private System.Windows.Forms.RadioButton deletion;
    }
}

