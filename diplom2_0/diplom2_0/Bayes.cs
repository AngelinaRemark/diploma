using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diplom2_0
{
    class Bayes
    {
        public static List<double> impirich(List<List<double[]>> cluster, int N)
        {
            List<double> res = new List<double>();

            for (int i = 0; i < cluster.Count; i++)
                for (int j = 0; j < cluster[i].Count; j++)
                {
                    res.Add(cluster[i].Count / N);
                }     
            return res;
        }
        public static List<double[]> anomalni = new List<double[]>();
        public static List<List<double[]>> anomal_impir(List<List<double[]>> cluster, int N)
        {
            List<List<double[]>> res = new List<List<double[]>>();
            List<List<double[]>> vylucheni = new List<List<double[]>>();

            List<double> impir = impirich(cluster, N);
            double anomal = 0.01;
            for (int i = 0; i < cluster.Count; i++)
            {
                if (impir[i] <= anomal)
                {
                    res.Add(new List<double[]>());
                    vylucheni.Add(cluster[i]);
                }
                res.Add(cluster[i]);
            }
            for (int i = 0; i < vylucheni.Count; i++)
            {
                for (int j = 0; j < vylucheni[i].Count; j++)
                {
                    anomalni.Add(vylucheni[i][j]);
                }
            }
            return res;
        }
        public static List<List<double[]>> anomal_count(List<List<double[]>> cluster, int N, double procent)
        {
            List<List<double[]>> res = new List<List<double[]>>();
            List<List<double[]>> vylucheni = new List<List<double[]>>();
            for (int i = 0; i < cluster.Count; i++)
            {
                if (cluster[i].Count <= procent*N)
                {
                    res.Add(new List<double[]>());
                    vylucheni.Add(cluster[i]);
                }
                else
                    res.Add(cluster[i]);
            }
            for (int i = 0; i < vylucheni.Count; i++)
            {
                for (int j = 0; j < vylucheni[i].Count; j++)
                {
                    anomalni.Add(vylucheni[i][j]);
                }
            }

            return res;
        }

        //public static List<double[]> without_anomal(List<List<double[]>> cluster)
        //{
        //    List<double[]> res = new List<double[]>();
        //    for (int i = 0; i < cluster.Count; i++)
        //        for (int j = 0; j < cluster[i].Count; j++)
        //            if (cluster[i].Count != 0)
        //                res.Add(cluster[i][j]);

        //    return res;
        //}
        
        public static List<double[]> without_anomal(List<List<double[]>> cluster, int N, double procent)
        {
            List<double[]> res = new List<double[]>();
            List<double[]> res1 = new List<double[]>();
            anomalni = new List<double[]>();
            List<List<double[]>> anomal = anomal_count(cluster, N, procent);
            for (int i = 0; i < anomal.Count; i++)
            {
                for (int j = 0; j < anomal[i].Count; j++)
                {
                    if (anomal[i].Count != 0)
                        res.Add(anomal[i][j]);
                }
            }
            double[] x = new double[res.Count];
            double[] y = new double[res.Count];
            for (int i = 0; i < res.Count; i++)
            {
                x[i] = res[i][0];
                y[i] = res[i][1];
            }
            res1.Add(x); res1.Add(y);

            return res1;
        }
        static List<double> anomalX, anomalY;
        public static int Mx_anm => Parametrs.M(anomalX);
        public static int My_anm => Parametrs.M(anomalY);
        public static double hx_anm => Parametrs.h_Krok(anomalX, Mx_anm - 1);
        public static double hy_anm => Parametrs.h_Krok(anomalY, My_anm - 1);
        public static double[,] p_anm => Parametrs.pij(anomalX, anomalY, Mx_anm, My_anm, hx_anm, hy_anm);
        public static void Anomal(List<double[]> data_anomal)
        {
            anomalX = new List<double>(); anomalY = new List<double>();
            for (int i = 0; i < data_anomal[0].Length; i++)
            {
                anomalX.Add(data_anomal[0][i]);
                anomalY.Add(data_anomal[1][i]);
            }
            List<double[]> spline_anm = Spline.splinen1(Mx_anm, My_anm, hx_anm, hy_anm, anomalX.Min(), anomalY.Min(), p_anm);
        }

        public static List<List<double[]>> joined(List<List<double[]>> without, List<double[]> anomaln)
        {
            List<List<double[]>> res = new List<List<double[]>>();
            
            for (int i = 0; i < without.Count; i++)
                res.Add(without[i]);
            res.Add(anomaln);
            return res;
        }


        public static List<double[]> goodData(List<double[]> data)
        {
            List<double[]> res = new List<double[]>();
            for (int i = 0; i < data[0].Length; i++)
                res.Add(new double[2] { data[0][i], data[1][i] });
            return res;
        }
        public static List<double[]> finish_visual(List<double[]> data, List<List<double[]>> without)
        {
            List<double[]> res = new List<double[]>();
            List<List<double[]>> alldata = joined(without, anomalni);
            List<double[]> goodata = goodData(data);
            double[] x = new double[data[0].Length], y = new double[data[0].Length], index_color = new double[data[0].Length];
            for (int k = 0; k < data[0].Length; k++)
                for (int i = 0; i < alldata.Count; i++)
                    for (int j = 0; j < alldata[i].Count; j++)
                        if (goodata[k][0] == alldata[i][j][0] && goodata[k][1] == alldata[i][j][1])
                        {
                            x[k] = goodata[k][0];
                            y[k] = goodata[k][1];
                            index_color[k] = i;
                        }
            res.Add(x); res.Add(y); res.Add(index_color);
            return res;
        }
        public static List<double[]> ohneAnomal;
        //public static List<double[]> Anomalne(List<double[]> data, List<double[]> splin, double procent, double ht, double hq,int Mx, int My, double minx, double miny, double[,] Pij)
        //{
        //    List<double[]> result = new List<double[]>();
        //    ohneAnomal = new List<double[]>();
        //    //List<double> temp = new List<double>();
        //    //for (int i = 0; i < splin.Count; i++)
        //    //    temp.Add(splin[i][2]);
        //    //double max = temp.Max();
        //    List<double> x = new List<double>();
        //    List<double> x1 = new List<double>();
        //    List<double> y = new List<double>();
        //    List<double> y1 = new List<double>();
        //    //for (int i = 0; i < data[0].Length; i++)
        //    //{
        //    //    double tmp = Spline.Sppl202(data[0][i], data[1][i], ht, hq, Mx, My, minx, miny, Pij)[2];
        //    //    if (temp[i] <= max * procent)
        //    //    {
        //    //        x.Add(data[0][i]); y.Add(data[1][i]);
        //    //    }
                    
        //    //    else
        //    //    {
        //    //        x1.Add(data[0][i]); y1.Add(data[1][i]);
        //    //    }
        //    //}
        //    for (int i = 0; i < Mx; i++)
        //    {
        //        for (int j = 0; j < My; j++)
        //        {
        //            if (Pij[i, j] <= 100/data[0].Length)
        //            {
        //                for (int k = 0; k < data[0].Length; k++)
        //                {
        //                    if(data[0][k]>=i*ht+minx&&data[0][k]<=(i+1)*ht+minx&& data[1][k] >= j * hq + miny && data[1][k] <= (j + 1) * hq + miny)
        //                    {
        //                        x.Add(data[0][k]); y.Add(data[1][k]);
        //                    }
        //                }
        //            }

        //        }
        //    }
            
        //    result.Add(x.ToArray()); result.Add(y.ToArray());
        //    List<double[]> temp = result;
        //    ohneAnomal = data;
        //    for (int j = 0; j < temp[0].Length; j++)
        //    {
        //        for (int i = 0; i < ohneAnomal[0].Length; i++)
        //        {
        //            if (ohneAnomal[0][i] == temp[0][j] && ohneAnomal[1][i] == temp[1][j])
        //            {
        //                ohneAnomal[0].;
        //                ohneAnomal[1].ToList().RemoveAt(i);
        //                temp[0].ToList().RemoveAt(j);
        //                temp[1].ToList().RemoveAt(j);
        //            }
        //        }
        //    }
            
        //    //ohneAnomal.Add(x1.ToArray());
        //    //ohneAnomal.Add(y1.ToArray());
        //    return result;
        //}
        public static List<double[]> Ident(List<double[]> data, double hx, double hy, int Mx, int My, double xmin, double ymin, double[,] Pij, double dilitel)
        {
            List<double> spl = new List<double>();
            List<double[]> anomal = new List<double[]>();
            for (int i = 0; i < data[0].Length; i++)
            {
                spl.Add(Spline.Sppl202(data[0][i], data[1][i], hx, hy, Mx, My, xmin, ymin, Pij)[2]);
            }
            for (int i = 0; i < Pij.GetLength(0); i++)
            {
                for (int j = 0; j < Pij.GetLength(0); j++)
                {
                    if (Pij[i, j] <= 0.001)
                    {
                        for (int k = 0; k < data[0].Length; k++)
                        {
                            if (data[0][k] >= i * hx + xmin && data[0][k] < (i + 1) * hx + xmin && data[1][k] >= j * hy + ymin && data[1][k] < (j + 1) * hy + ymin)
                                anomal.Add(new double[] { data[0][k], data[1][k] });
                        }
                    }
                        
                }
            }
            List<double[]> data1 = new List<double[]>();
            for (int i = 0; i < data[0].Length; i++)
                data1.Add(new double[] { data[0][i], data[1][i] });

            List<double[]> res = new List<double[]>();
            double step = (spl.Max() - spl.Min()) / dilitel;
            double meza = spl.Min() + step;
            for (int i = 0; i < data[0].Length; i++)
            {
                if (spl[i] <= meza)
                {
                    for (int j = 0; j < anomal.Count; j++)
                    {
                        if (data1[i][0] == anomal[j][0] && data1[i][1] == anomal[j][1])
                            res.Add(data1[i]);
                    }
                }

            }
            return res;
        }

        
    }
}
