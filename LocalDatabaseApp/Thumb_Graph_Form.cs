﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace LocalDatabaseApp
{
    public partial class Thumb_Graph_Form : Form
    {
        StreamReader Thumb_file = new StreamReader("C:\\Users\\knguyen\\Desktop\\out2.txt");
        public Thumb_Graph_Form()
        {
            InitializeComponent();
            InitializeGraph();
        }

        private void InitializeGraph()
        {
            GenerateGraph(Thumb_file, ThumbChart, "Thumb");
            //Change colors
            ThumbChart.Series["Thumb"].Color = Color.Teal;

        }
        private void GenerateGraph(StreamReader File_name, Chart ChartSerial, string chartName)
        {
            string line = "";
            Series filePoints = new Series();
            while ((line = File_name.ReadLine()) != null)
            {
                //find the ',' so that you know were to split the string
                int split = line.IndexOf(",");
                float X = float.Parse(line.Substring(0, split));
                float Y = float.Parse(line.Substring(split + 1, line.Length - (split + 1)));

                //add the points
                //filePoints.Points.AddXY(X, Y);
                ChartSerial.Series[chartName].Points.AddXY(X, Y);    // Create ForeFoot graph Graph by X,Y points

            }
        }
    }
}
