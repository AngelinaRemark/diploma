using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace diplom2_0
{
    public partial class Form1 : Form
    {
        public static Bitmap start, //початкове
            neww, //після перетворень
            changeNoSize, //зменшене для швидкого обрахунку дисперсії
            restart;//копія початкового
        public static double[,] pix1, //початкове в масиві
            pix2;
        List<double> sig, sered, anomalX, anomalY;
        double[,] sered1, sig1;

        public static List<double[]> logmax, logmin, logmax_anomal;
        public static List<double[]> spline, vyluch_anomalni/*, final_clust*/;
        public static List<List<double[]>> classif, cluster_anomal, clust_anom2;
        static double b = 0.01, a = 0, eps = 0.000001;
        static List<List<double[]>> join;
        List<double[]> data, data_anomal, anomal;


        static Color[] col;

        static int Mx, My, Mx_anm, My_anm;

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        static double hx, hy, xmin, ymin, xmax, ymax, hx_anm, hy_anm;

        static double[,] Pij, p_anm;
       
        public Form1()
        {
            InitializeComponent();
        }

       
        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileWindow = new OpenFileDialog();
                if (openFileWindow.ShowDialog() == DialogResult.OK)
                {
                    start = new Bitmap(openFileWindow.FileName);
                    changeNoSize = start;
                    start = ReSize.ResizeImage(start, pictureBox1.Width, pictureBox1.Height);
                    pictureBox1.Image = start;
                    neww = start;
                }
            }
            catch { }
                int n = Convert.ToInt32(textBox1.Text);
                Window.Find(start, n);
                sered1 = Window.Averag;
                sig1 = Window.Sigm;
                sered = Window.sered;
                sig = Window.sigma;

                data = new List<double[]>();
                data.Add(sered.ToArray());
                data.Add(sig.ToArray());
                int t1, t2;
                try
                {
                    Mx = Convert.ToInt32(textBox2.Text);
                    My = Convert.ToInt32(textBox3.Text);
                }
                catch
                {
                    Mx = Parametrs.M(sered);
                    My = Parametrs.M(sig);
                }
                hx = Parametrs.h_Krok(sered, Mx - 1);
                hy = Parametrs.h_Krok(sig, My - 1);
                xmin = sered.Min();
                xmax = sered.Max();
                ymin = sig.Min();
                ymax = sig.Max();
                Pij = Parametrs.pij(sered, sig, Mx, My, hx, hy);
                col = new Color[100];

                Random r = new Random();
                Random g = new Random();
                Random b = new Random();
                for (int i = 0; i < col.Length; i++)
                {

                    int r1 = r.Next(0, 255);
                    int r2 = g.Next(0, 255);
                    int r3 = b.Next(0, 255);
                    //col[i] = Color.FromArgb(r1,r2,r3);
                    col[i] = Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));

                }
            listBox1.Items.Add("Mx = "+Mx+"  My = "+My);
            listBox1.Items.Add("n = " + n);
            anomal = new List<double[]>();
        }


        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                StreamWriter sw = new StreamWriter("D:\\Imag1.txt", true, Encoding.ASCII);
                for (int i = 0; i < data[0].Length; i++)
                    sw.Write(data[0][i].ToString("0.00", CultureInfo.InvariantCulture).Replace(',','.') + " " + data[1][i].ToString("0.00", CultureInfo.InvariantCulture).Replace(',', '.') + Environment.NewLine);
                sw.Close();
            }
            catch
            {
            }
        }
       
        static List<double> t, q;
        private void splineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zedGraphControl1.GraphPane.CurveList.Clear();
            spline = Spline.splinen1(Mx,My,hx,hy,xmin,ymin,Pij);
            

            t = new List<double>();
            q = new List<double>();
            List<double> p = new List<double>();
            for (int i = 0; i < spline.Count; i++)
            {
                t.Add(spline[i][0]);
                q.Add(spline[i][1]);
                p.Add(spline[i][2]);
            }
            Draw.Gist2vim(t, q, p, zedGraphControl1);
            
            //Draw.Pointts(data, zedGraphControl1);

        }
        private void localMaxToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            //logmax = LocalMax.calc(spline, dill, Mx, My, hx, hy, xmin, ymin,xmax,ymax, Pij);

            //double b = Convert.ToDouble(textBox6.Text);
            
            //logmax_anomal = LocalMax.calccc(spline, 0.2, Mx, My, hx, hy, xmin, ymin, xmax, ymax, Pij);
            //Draw.Localmax(logmax_anomal, zedGraphControl2, col);
            logmax = Gradient.CalculateGradUp(data,a,b,eps,hx,hy,Mx,My,xmin,ymin,xmax,ymax,Pij);
            Draw.Localmax(logmax, zedGraphControl1, col);
            
            //listBox1.Items.Add(b + "     " + eps);
        }
        
        private void localMinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //logmin = LocalMax.calcMin(spline, Mx, My, hx, hy, xmin, ymin, xmax, ymax, Pij);
            //logmin = LocalMax.locminn;
            logmin=LocalMax.calccc(spline, 0.15, Mx, My, hx, hy, xmin, ymin, xmax, ymax, Pij);
            Draw.Localmin(logmin, zedGraphControl1, col);
        }
        private void clusterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double b = Convert.ToDouble(textBox5.Text);
            //double eps = Convert.ToDouble(textBox7.Text);
            //classif = Classif.classificatin(data, logmax, Mx, My, hx, hy, xmin, ymin,ymax, Pij);
            //classif = Gradient.clasterDiff(data, logmax, hx, hy, Mx, My, xmin, ymin, Pij);
            classif = Classif.classification(data, logmax, Mx, My, hx, hy, xmin, ymin, ymax, Pij);
            Draw.Classif(classif, zedGraphControl1, col);
            //List<List<double[]>> classif1 = Gradient.ClusterGrad(data, logmax, 0, b, eps, hx, hy, Mx, My,  xmin,ymin,xmax, ymax, Pij);
            //Draw.Classif(classif1, zedGraphControl2, col);
        }

        private void visualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            // Clear picture box with blue color
            float width = pictureBox1.Width;
            float height = pictureBox1.Height;
            int n = Convert.ToInt32(textBox1.Text);
            // Create a pen to draw Ellipse
            int size = (n - 1) / 2;
            //int maxi = Convert.ToInt32((pictureBox1.Width - 2 * size) / n) + 1;
            //int maxj = Convert.ToInt32((pictureBox1.Height - 2 * size) / n) + 1;
            int maxi = pictureBox1.Width - 2 * size;
            int maxj = pictureBox1.Height - 2 * size;
            int[,] points = new int[maxi, maxj];
            //List<double[]> vyluch = Bayes.anomalni;
            //join = Bayes.joined(cluster_anomal, vyluch);
            join = Bayes.joined(classif, anomal);

            col[join.Count - 1] = Color.White;
            for (int i = 0; i < maxi; i++)
            {
                int hi = size + i;
                for (int j = 0; j < maxj; j++)
                {
                    int hj = size + j;
                    for (int k = 0; k < join.Count(); k++)
                    {
                        for (int m = 0; m < join[k].Count(); m++)
                        {
                            if (sered1[i, j] == join[k][m][0] && sig1[i, j] == join[k][m][1])
                                points[i, j] = k;
                        }
                    }

                    //SolidBrush pen = new SolidBrush(col[points[i, j]]);
                    //if (points[i, j] == join.Count - 1)
                    //    g.FillEllipse(pen, hi - 1, hj - 1, 2, 2);
                    //else
                    //    g.FillEllipse(pen, hi - 1, hj - 1 , 4, 4);
                }
            }
            for (int i = 0; i < maxi-5; i=+5)
            {
                int hi = size + i;
                for (int j = 0; j < maxj-5; j=+5)
                {
                    int hj = size + j;
                    SolidBrush pen = new SolidBrush(col[points[i, j]]);
                    if (points[i, j] == join.Count - 1)
                        g.FillEllipse(pen, hi - 1, hj - 1, 4, 4);
                    else
                        g.FillEllipse(pen, hi - 1, hj - 1, 2, 2);
                }
            }
        }


        private void borderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double step = Convert.ToDouble(textBox5.Text);
            List<double[]> temp = Bayes.Ident(data, hx, hy, Mx, My, xmin, ymin, Pij,step);
            List<double[]> data1 = new List<double[]>();

            for (int i = 0; i < temp.Count; i++)
            {
                anomal.Add(temp[i]);
                 
            }
            for (int i = 0; i < data[0].Length; i++)
            {
                bool t = true;
                for (int j = 0; j < anomal.Count; j++)
                {
                    if (anomal[j][0] == data[0][i] && anomal[j][1] == data[1][i])
                        t = false;
                }
                if (t)
                    data1.Add(new double[] { data[0][i], data[1][i] });
               
            }
            data=new List<double[]>();
            double[] xx = new double[data1.Count];
            double[] yy = new double[data1.Count];
            for (int i = 0; i < data1.Count; i++)
            {
                xx[i] = data1[i][0];
                yy[i] = data1[i][1];
            }
            data.Add(xx); data.Add(yy);

            try
            {
                Mx = Convert.ToInt32(textBox2.Text);
                My = Convert.ToInt32(textBox3.Text);
            }
            catch
            {
                Mx = Parametrs.M(xx.ToList());
                My = Parametrs.M(yy.ToList());
            }
            hx = Parametrs.h_Krok(xx.ToList(), Mx - 1);
            hy = Parametrs.h_Krok(yy.ToList(), My - 1);
            xmin = xx.ToList().Min();
            xmax = xx.ToList().Max();
            ymin = yy.ToList().Min();
            ymax = yy.ToList().Max();
            Pij = Parametrs.pij(xx.ToList(), yy.ToList(), Mx, My, hx, hy);
            zedGraphControl1.GraphPane.CurveList.Clear();
            spline = Spline.splinen1(Mx, My, hx, hy, xmin, ymin, Pij);


            t = new List<double>();
            q = new List<double>();
            List<double> p = new List<double>();
            for (int i = 0; i < spline.Count; i++)
            {
                t.Add(spline[i][0]);
                q.Add(spline[i][1]);
                p.Add(spline[i][2]);
            }
            Draw.Gist2vim(t, q, p, zedGraphControl1);
        }
        private void diffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Border.DrawBorder(Mx, My, hx, hy, xmin, ymin, Pij, zedGraphControl1);
        }
        private void climbingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //classif = Classif.classification(data, logmax,  Mx, My, hx, hy, xmin, ymin,ymax, Pij);
            //Draw.Classif(classif, zedGraphControl1, col);
            pictureBox1.Refresh();
            Graphics g = pictureBox1.CreateGraphics();
            //pictureBox1.Image = neww;
            int width = pictureBox1.Width;
            int height = pictureBox1.Height;
            int n = Convert.ToInt32(textBox1.Text);
            // Create a pen to draw Ellipse
            int size = (n - 1) / 2;
            //int maxi = Convert.ToInt32((width - 2 * size) / n) + 1;
            //int maxj = Convert.ToInt32((height - 2 * size) / n) + 1;

            int maxi = width - 2 * size;
            int maxj = height - 2 * size;
            int[,] points = new int[maxi, maxj];

            join = Bayes.joined(classif, anomal);
            col[join.Count - 1] = Color.White;
            for (int i = 0; i < maxi; i++)
            {
                int hi = size + i;
                for (int j = 0; j < maxj; j++)
                {
                    int hj = size + j;
                    for (int k = 0; k < join.Count(); k++)
                    {
                        for (int m = 0; m < join[k].Count(); m++)
                        {
                            if (sered1[i, j] == join[k][m][0] && sig1[i, j] == join[k][m][1])
                            {
                                SolidBrush pen = new SolidBrush(col[k]);
                                if (k == join.Count - 1)
                                    g.FillEllipse(pen, hi, hj, 6, 6);
                                else
                                    g.FillEllipse(pen, hi, hj, 3, 3);
                            }
                            //points[i, j] = k;
                            //start.SetPixel(hi, hj, col[k]);
                        }
                    }

                    //start.SetPixel(hi, hj, col[points[i,j]]);

                    //SolidBrush pen = new SolidBrush(col[points[i, j]]);
                    //if(points[i,j]==join.Count-1)
                    //    g.FillEllipse(pen, hi - 1, hj - 1, 10, 10);
                    //else
                    //g.FillEllipse(pen, hi - 1, hj - 1, 5, 5);
                }
            }
            //pictureBox1.Image = start;

        }

        private void qualityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            double Q1 = Quality.SumOfInsClustDisp(cluster_anomal, logmax2),
                Q2 = Quality.SumOfPairInsClustDisp(cluster_anomal),
                Q3 = Quality.TotalInsClustDisp(cluster_anomal),
                Q4 = Quality.q4(cluster_anomal);
            listBox1.Items.Add("Сума («зважена») внутрішньокластерних дисперсій = "+ Math.Round(Q1, 4));
            listBox1.Items.Add("Сума попарних внутрішньокластерних відстаней = " + Math.Round(Q2, 4));
            listBox1.Items.Add("Загальна внутрішньокластерна дисперсія = " + Math.Round(Q3, 4));
            listBox1.Items.Add("Cередня внутркластр відстань/середня міжкластерна відстань = " + Math.Round(Q4, 4));
        }

        List<double> tanm, qanm, panm; List<double[]> logmax2;
        private void anomalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            double dill = 0.1;
            double procent = Convert.ToDouble(textBox5.Text);
            #region
            data_anomal = Bayes.without_anomal(classif, data[0].Length, procent);
            anomalX = new List<double>(); anomalY = new List<double>();
            for (int i = 0; i < data_anomal[0].Length; i++)
            {
                anomalX.Add(data_anomal[0][i]);
                anomalY.Add(data_anomal[1][i]);
            }

            Mx_anm = Parametrs.M(anomalX);
            My_anm = Parametrs.M(anomalY);
            hx_anm = Parametrs.h_Krok(anomalX, Mx_anm - 1);
            hy_anm = Parametrs.h_Krok(anomalY, My_anm - 1);
            p_anm = Parametrs.pij(anomalX, anomalY, Mx_anm, My_anm, hx_anm, hy_anm);
            //listBox1.Items.Add("M_anomal = " + Mx_anm);
            List<double[]> spline_anm = Spline.splinen1(Mx_anm, My_anm, hx_anm, hy_anm, anomalX.Min(), anomalY.Min(), p_anm);

            tanm = new List<double>(); qanm = new List<double>(); panm = new List<double>();
            for (int i = 0; i < spline_anm.Count; i++)
            {
                tanm.Add(spline_anm[i][0]);
                qanm.Add(spline_anm[i][1]);
                panm.Add(spline_anm[i][2]);
            }
            //Draw.Gist2vim(tanm, qanm, panm, zedGraphControl1);

            logmax_anomal = Gradient.CalculateGradUp(spline_anm, a, b, eps, hx_anm, hy_anm, Mx_anm, My_anm, anomalX.Min(), anomalY.Min(), anomalX.Max(), anomalY.Max(), p_anm);
            //Draw.Localmax(logmax_anomal, zedGraphControl2, col);
            //cluster_anomal = Gradient.ClusterGrad(data_anomal, logmax_anomal, a, b, eps, hx_anm, hy_anm, Mx_anm, My_anm, anomalX.Min(), anomalY.Min(), anomalX.Max(), anomalY.Max(), p_anm);
            cluster_anomal = Classif.classification(data_anomal, logmax_anomal, Mx_anm, My_anm, hx_anm, hy_anm, anomalX.Min(), anomalY.Min(), anomalY.Max(), p_anm);
            //Draw.Classif(cluster_anomal, zedGraphControl2, col);

            logmax2 = new List<double[]>();
            int n = Parametrs.N(cluster_anomal);
            for (int i = 0; i < cluster_anomal.Count; i++)
            {
                if (cluster_anomal[i].Count > dill * n)
                    logmax2.Add(logmax_anomal[i]);
            }
            Draw.Gist2vim(tanm, qanm, panm, zedGraphControl1);

            cluster_anomal = Classif.classification(data_anomal, logmax2,  Mx_anm, My_anm, hx_anm, hy_anm, anomalX.Min(), anomalY.Min(),  anomalY.Max(), p_anm);

            logmax2 = Classif.new_local(cluster_anomal, hx_anm, hy_anm, Mx_anm, My_anm, anomalX.Min(), anomalY.Min(), p_anm);

            Draw.Localmax(logmax2, zedGraphControl1, col);
            Draw.Classif(cluster_anomal, zedGraphControl1, col);
            //final_clust = Bayes.finish_visual(data, clust_anom2);
            
            #endregion
            //anomal = Bayes.Anomal(data, spline, procent, hx,hy,Mx,My,xmin,ymin,Pij);
            //data_anomal = Bayes.ohneAnomal;
            //data = new List<double[]>();
            //data = data_anomal;
            //listBox1.Items.Add("Anomal   " + data[0].Length);
            //for (int i = 0; i < anomal[0].Length; i++)
            //{
            //    listBox1.Items.Add(anomal[0][i] + "     " + anomal[1][i] + Environment.NewLine);
            //}

            //    Mx = Parametrs.M(data[0].ToList());
            //    My = Parametrs.M(data[1].ToList());
            //hx = Parametrs.h_Krok(data[0].ToList(), Mx - 1);
            //hy = Parametrs.h_Krok(data[1].ToList(), My - 1);
            //xmin = data[0].ToList().Min();
            //xmax = data[0].ToList().Max();
            //ymin = data[1].ToList().Min();
            //ymax = data[1].ToList().Max();
            //Pij = Parametrs.pij(data[0].ToList(), data[1].ToList(), Mx, My, hx, hy);

        }
        

        private void probaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            // Clear picture box with blue color
            int width = pictureBox1.Width;
            int height = pictureBox1.Height;
            int n = Convert.ToInt32(textBox1.Text);
            // Create a pen to draw Ellipse
            int size = (n - 1) / 2;
            //int maxi = Convert.ToInt32((width - 2 * size) / n) + 1;
            //int maxj = Convert.ToInt32((height - 2 * size) / n) + 1;

            int maxi = width - 2 * size;
            int maxj = height - 2 * size;
            int[,] points = new int[maxi, maxj];

            
            //for (int i = 0; i < maxi - 1; i++)
            //{
            //    int hi = size + i * n;
            //    for (int j = 0; j < maxj - 1; j++)
            //    {
            //        int hj = size + j * n;
            //        for (int k = 0; k < final_clust[0].Length; k++)
            //        {
            //            points[i, j] = Convert.ToInt32(final_clust[2][k]);
            //        }

            //        SolidBrush pen = new SolidBrush(col[points[i, j]]);
            //        g.FillEllipse(pen, hi - 1, hj - 1, 5, 5);
            //    }
            //}
            
            join = Bayes.joined(classif, anomal);
            double N = 0; double N_anomal = 0;
            col[join.Count - 1] = Color.White;
            for (int i = 0; i < maxi - 1; i+=3)
            {
                int hi = size + i;
                for (int j = 0; j < maxj - 1; j+=3)
                {
                    int hj = size + j;
                    for (int k = 0; k < join.Count(); k++)
                    {
                        
                        for (int m = 0; m < join[k].Count(); m++)
                        {
                            if (sered1[i, j] == join[k][m][0] && sig1[i, j] == join[k][m][1])
                                points[i, j] = k;
                        }
                    }
                    if (points[i, j] != join.Count - 1)
                        Window.NewPixel111(hi, hj, start, n,50);

                    //SolidBrush pen = new SolidBrush(col[points[i, j]]);
                    //if(points[i,j]==join.Count-1)
                    //    g.FillEllipse(pen, hi - 1, hj - 1, 10, 10);
                    //else
                    //g.FillEllipse(pen, hi - 1, hj - 1, 5, 5);
                }
            }
            for (int i = 0; i < join.Count(); i++)
            {
                if (i == join.Count - 1)
                    N_anomal = join[i].Count;
                else
                    N += join[i].Count;
            }
            textBox4.Text = Convert.ToString(Math.Round(N_anomal / N * 100,5));
            pictureBox1.Image = start;
        }



    }
}
