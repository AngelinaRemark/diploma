using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diplom2_0
{
    class LocalMax
    {
        public static List<double[]> calc(List<double[]> spl, double dil, int Mx, int My, double ht, double hq, double minx, double miny, double maxx, double maxy, double[,] Pij )
        {
            List<double[]> result = new List<double[]>();
            List<double[]> result2 = new List<double[]>();
            double[] ser = new double[spl.Count];
            double[] sigma = new double[spl.Count];
            double[] p = new double[spl.Count];
            for (int i = 0; i < spl.Count(); i++)
            {
                ser[i] = spl[i][0];
                sigma[i] = spl[i][1];
                p[i] = spl[i][2];
            }
            for (int i = 0; i < spl.Count(); i++)
            {
                double t = ser[i];
                double q = sigma[i];
                double[][] tochk = new double[8][] {new double[2]{t-ht/ dil, q-hq/dil},
                                                    new double[2]{t-ht/ dil, q },
                                                    new double[2]{t-ht/ dil, q+hq/dil},
                                                    new double[2]{t,q-hq/dil },
                                                    new double[2]{t,q+hq/dil },
                                                    new double[2]{t+ht/ dil, q-hq/dil },
                                                    new double[2]{t+ht/ dil, q },
                                                    new double[2]{t+ht/ dil, q+hq/dil }};
                for (int k = 0; k < tochk.GetLength(0); k++)
                {
                    if (tochk[k][0] < minx || tochk[k][0] > maxx)
                        tochk[k][0] = t;
                    if (tochk[k][1] < miny || tochk[k][1] > maxy)
                        tochk[k][1] = q;
                }

                List<double> tp = new List<double>();

                for (int k = 0; k < tochk.GetLength(0); k++)
                {
                    tp.Add(Spline.Sppl202(tochk[k][0], tochk[k][1], ht, hq, Mx, My, minx, miny, Pij)[2]);
                }
                if (p[i] >= tp[0] && p[i] >= tp[1] && p[i] >= tp[2] && p[i] >= tp[3] && p[i] >= tp[4] && p[i] >= tp[5] && p[i] >= tp[6] && p[i] >= tp[7])
                {
                    if (Hesse(t, q, ht, hq, Mx, My, minx, miny, Pij))
                     result.Add(spl[i]);
                }
                
                //if (p[i] <= tp[0] && p[i] <= tp[1] && p[i] <= tp[2] && p[i] <= tp[3] && p[i] <= tp[4] && p[i] <= tp[5] && p[i] <= tp[6] && p[i] <= tp[7])
                //{      
                //        sidlo.Add(spl[i]);
                //}
            }


            List<double[]> ind = new List<double[]>();
            for (int i = 0; i < result.Count; i++)
            {
                for (int j = i + 1; j < result.Count; j++)
                {
                    if (i != j)
                        if (Math.Abs(result[i][0] - result[j][0]) < ht / 2 && Math.Abs(result[i][1] - result[j][1]) < hq / 2)
                            ind.Add(result[i]);
                }
            }
            for (int i = 0; i < result.Count; i++)
            {
                for (int j = 0; j < ind.Count; j++)
                {
                    if (result[i][0] == ind[j][0] && result[i][1] == ind[j][1])
                    {
                        result.RemoveAt(i);
                        ind.RemoveAt(j);
                    }
                }
            }

            return result;
        }

        public static List<double[]> calccc(List<double[]> spl, double dill, int Mx, int My, double ht, double hq, double minx, double miny, double maxx, double maxy, double[,] Pij)
        {
            List<double[]> result = new List<double[]>();
            List<double[]> result2 = new List<double[]>();
            double[] ser = new double[spl.Count];
            double[] sigma = new double[spl.Count];
            double[] p = new double[spl.Count];
            for (int i = 0; i < spl.Count(); i++)
            {
                ser[i] = spl[i][0];
                sigma[i] = spl[i][1];
                p[i] = spl[i][2];
            }
            for (int i = 0; i < spl.Count(); i++)
            {
                double t = ser[i];
                double q = sigma[i];
                double[][] tochk = new double[8][] {new double[2]{t- dill, q-dill},
                                                    new double[2]{t- dill, q },
                                                    new double[2]{t- dill, q+dill},
                                                    new double[2]{t,q-dill },
                                                    new double[2]{t,q+dill },
                                                    new double[2]{t+ dill, q-dill},
                                                    new double[2]{t+ dill, q },
                                                    new double[2]{t+ dill, q+dill }};
                for (int k = 0; k < tochk.GetLength(0); k++)
                {
                    if (tochk[k][0] < minx || tochk[k][0] > maxx)
                        tochk[k][0] = t;
                    if (tochk[k][1] < miny || tochk[k][1] > maxy)
                        tochk[k][1] = q;
                }

                List<double> tp = new List<double>();

                for (int k = 0; k < tochk.GetLength(0); k++)
                {
                    tp.Add(Spline.Sppl202(tochk[k][0], tochk[k][1], ht, hq, Mx, My, minx, miny, Pij)[2]);
                }
                if (p[i] >= tp[0] && p[i] >= tp[1] && p[i] >= tp[2] && p[i] >= tp[3] && p[i] >= tp[4] && p[i] >= tp[5] && p[i] >= tp[6] && p[i] >= tp[7])
                {
                    if (Hesse(t, q, ht, hq, Mx, My, minx, miny, Pij))
                        result.Add(spl[i]);
                }

                //if (p[i] <= tp[0] && p[i] <= tp[1] && p[i] <= tp[2] && p[i] <= tp[3] && p[i] <= tp[4] && p[i] <= tp[5] && p[i] <= tp[6] && p[i] <= tp[7])
                //{
                //    if (Hesse1(t, q, ht, hq, Mx, My, minx, miny, Pij))
                //        result.Add(spl[i]);
                //}
            }


            return result;
        }

        public static bool Hesse(double t, double q, double ht, double hq, int Mx, int My, double minx, double miny, double[,] Pij)
        {
            bool result = false;
            double A = Spline.S20_diff2tt(t, q, ht, hq, Mx, My, minx, miny, Pij);
            double B = Spline.S20_diff2tq(t, q, ht, hq, Mx, My, minx, miny, Pij);
            double C = Spline.S20_diff2qq(t, q, ht, hq, Mx, My, minx, miny, Pij);
            double det = A * C - B * B;
            if (det > 0 && A < 0)
                result = true;
            return result;
        }
        public static bool Hesse1(double t, double q, double ht, double hq, int Mx, int My, double minx, double miny, double[,] Pij)
        {
            bool result = false;
            double A = Spline.S20_diff2tt(t, q, ht, hq, Mx, My, minx, miny, Pij);
            double B = Spline.S20_diff2tq(t, q, ht, hq, Mx, My, minx, miny, Pij);
            double C = Spline.S20_diff2qq(t, q, ht, hq, Mx, My, minx, miny, Pij);
            double det = A * C - B * B;
            if (det == 0)
                result = true;
            if (det > 0 && A > 0)
                result = true;
            return result;
        }
        public static List<double[]> calcMin(List<double[]> spl,int Mx, int My, double ht, double hq, double minx, double miny, double maxx, double maxy, double[,] Pij )
        {
            List<double[]> result = new List<double[]>();
            double[] ser = new double[spl.Count];
            double[] sigma = new double[spl.Count];
            double[] p = new double[spl.Count];
            for (int i = 0; i < spl.Count(); i++)
            {
                ser[i] = spl[i][0];
                sigma[i] = spl[i][1];
                p[i] = spl[i][2];
            }
            double dil = 20;
            for (int i = 0; i < spl.Count(); i++)
            {
                double t = ser[i];
                double q = sigma[i];
                double[][] tochk = new double[8][] {new double[2]{t-ht/ dil, q-hq/dil},
                                                    new double[2]{t-ht/ dil, q },
                                                    new double[2]{t-ht/ dil, q+hq/dil},
                                                    new double[2]{t,q-hq/dil },
                                                    new double[2]{t,q+hq/dil },
                                                    new double[2]{t+ht/ dil, q-hq/dil },
                                                    new double[2]{t+ht/ dil, q },
                                                    new double[2]{t+ht/ dil, q+hq/dil }};
                for (int k = 0; k < tochk.GetLength(0); k++)
                {
                    if (tochk[k][0] < minx || tochk[k][0] > maxx)
                        tochk[k][0] = t;
                    if (tochk[k][1] < miny || tochk[k][1] > maxy)
                        tochk[k][1] = q;
                }

                List<double> tp = new List<double>();

                for (int k = 0; k < tochk.GetLength(0); k++)
                {
                    tp.Add(Spline.Sppl202(tochk[k][0], tochk[k][1], ht, hq, Mx, My, minx, miny, Pij)[2]);
                }
                if (p[i] < tp[0] && p[i] < tp[1] && p[i] < tp[2] && p[i] < tp[3] && p[i] < tp[4] && p[i] < tp[5] && p[i] < tp[6] && p[i] < tp[7])
                {
                    result.Add(spl[i]);
                }
            }
            return result;
        }
        //public static List<double[]> temp_mass(double minx, double miny, double maxx, double maxy)
        //{
        //    List<double[]> res = new List<double[]>();
        //    double t = minx, q = miny;
        //    res.Add(new double[2] { minx, miny });
        //    while (t < maxx)
        //    {
        //        t += 1;
        //        while (q < maxy)
        //        {
        //            q += 1;
        //            res.Add(new double[2] { t, q });
        //        }
        //        res.Add(new double[2] { t, maxy });
        //    }
        //    res.Add(new double[2] { maxx, maxy });
        //    return res;
        //}
        public static List<List<double>> temp_mass( double maxx, double maxy, double ht, double hq, int Mx, int My, double minx, double miny, double[,] Pij)
        {
            //List<double[]> res = new List<double[]>();
            
            double krokx = 0.01, kroky = 0.01;
            int nx = Convert.ToInt32((maxx - minx) / krokx);
            int ny = Convert.ToInt32((maxy - miny) / kroky);
            List<List<double>> res = new List<List<double>>();
            for (int i = 1; i < ny-1; i++)
            {
                double y = miny + kroky * i;
                res.Add(new List<double>());
                for (int j = 1; j < nx-1; j++)
                {
                    double x = minx + krokx * j;
                    res[i-1].Add(Spline.Sppl202(x,y,ht,hq,Mx,My,minx,miny,Pij)[2]);
                }
            }
            return res;
        }
        public static List<double[]> locminn, locmax;
        public static void locmaxx(double ht, double hq, int Mx, int My, double minx, double miny,double maxx,double maxy, double[,] Pij)
        {
            locmax = new List<double[]>(); locminn = new List<double[]>();
            double krokx = 0.01, kroky = 0.01;
            List<List<double>> mass = temp_mass(maxx, maxy,ht,hq, Mx, My, minx, miny, Pij);
            for (int i = 0; i < mass.Count-1; i++)
            {
                for (int j = 0; j < mass[0].Count-1; j++)
                {
                    double t = minx+krokx*i;
                    double q = miny + kroky * j;
                    double Spldifft = Spline.S220_difft(t, q, ht, hq, Mx, My, minx, miny, Pij);
                    double Spldiffq = Spline.S220_diffq(t, q, ht, hq, Mx, My, minx, miny, Pij);
                    int i_d = i - 1, i_u = i + 1,
                    j_d = j - 1, j_u = j + 1;
                    if (i == 0)
                        i_d = i;
                    if (i == Mx - 1)
                        i_u = i;
                    if (j == 0)
                        j_d = j;
                    if (j == My - 1)
                        j_u = j;
                    if (Spldifft == 0 && Spldiffq == 0)
                    {
                        if (mass[i][j] >= mass[i_d][j_d] && mass[i][j] >= mass[i_d][j_u] && mass[i][j] >= mass[i_u][j_d] && mass[i][j] >= mass[i_u][j_u])
                            locmax.Add(new double[2] { t, q });
                        
                        //if (Hesse(t, q, ht, hq, Mx, My, minx, miny, Pij))
                        //locmax.Add(new double[2] { t, q });
                        //else if(Hesse1(t, q, ht, hq, Mx, My, minx, miny, Pij))
                        //    locminn.Add(new double[2]{ t,q});
                    }
                }
            }
            List<double[]> ind = new List<double[]>();
            for (int i = 0; i < locmax.Count - 1; i++)
            {
                for (int j = 0; j < locmax.Count; j++)
                {
                    if (i != j)
                        if (Math.Abs(locmax[i][0] - locmax[j][0]) < ht / 8 && Math.Abs(locmax[i][1] - locmax[j][1]) < hq / 8)
                            ind.Add(locmax[i]);
                }
            }
            for (int i = 0; i < locmax.Count; i++)
            {
                for (int j = 0; j < ind.Count; j++)
                {
                    if (locmax[i][0] == ind[j][0] && locmax[i][1] == ind[j][1])
                        locmax.RemoveAt(i);
                }
            }

        }
    }
    class Classif
    {
        public static List<List<double[]>> classification(List<double[]> data, List<double[]> logmax, int Mx, int My, double hx, double hy, double xmin, double ymin,double ymax, double[,] Pij)
        {
            List<double[]> delt = calculate(logmax, data,Mx,My,hx,hy,xmin,ymin,ymax,Pij);
            List<double[]> mindist = dist(data, logmax);
            List<double[]> result = new List<double[]>();
            List<double[]> nevizn = new List<double[]>();
            List<double[]> vizn = new List<double[]>();

            for (int i = 0; i < data[0].Length; i++)
            {
                double max = delt[i].Max();
                int index1 = delt[i].ToList().IndexOf(max);
                double min = mindist[i].Min();
                int index2 = mindist[i].ToList().IndexOf(min);

                double[] mass = new double[3] { data[0][i], data[1][i], index2 };
                if (index1 == index2)
                    result.Add(mass);
                else
                    nevizn.Add(new double[2] { data[0][i], data[1][i] });
            }
            List<double[]> nevz = new List<double[]>();
            List<double[]> distPoint = dist1(nevizn, result);
            for (int i = 0; i < nevizn.Count; i++)
            {
                double[] counter = new double[logmax.Count];
                double[] t = new double[result.Count];
                for (int j = 0; j < result.Count; j++)

                {
                    if (distPoint[i][j] <= 10)
                        counter[Convert.ToInt32(result[j][2])]++;
                    //t[j] = Evklid(result[j][0], nevizn[i][0], result[j][1], nevizn[i][1]);
                }

                double maxc = counter.Max();
                if (maxc != 0)
                {
                    vizn.Add(new double[3] { nevizn[i][0], nevizn[i][1], counter.ToList().IndexOf(maxc) });
                }
                else
                    nevz.Add(new double[2] { nevizn[i][0], nevizn[i][1] });

            }
            for (int i = 0; i < vizn.Count(); i++)
            {
                result.Add(vizn[i]);
            }

            ////////////////   2 step    /////////////////////
            /////
            //vizn = new List<double[]>();
            //nevizn = new List<double[]>();
            //List<double[]> distPoint1 = dist1(nevz, result);
            ////////         
            //for (int i = 0; i < nevz.Count; i++)
            //{
            //    double[] counter = new double[logmax.Count];
            //    double[] t = new double[result.Count];
            //    for (int j = 0; j < result.Count; j++)
            //    {
            //        if (distPoint1[i][j] <= 20)
            //            counter[Convert.ToInt32(result[j][2])]++;
            //        //t[j] = Evklid(result[j][0], nevz[i][0], result[j][1], nevz[i][1]);
            //    }
            //    double maxc = counter.Max();
            //    if (maxc != 0)
            //    {
            //        vizn.Add(new double[3] { nevz[i][0], nevz[i][1], counter.ToList().IndexOf(maxc) });
            //    }
            //    else
            //        nevizn.Add(new double[3] { nevz[i][0], nevz[i][1], counter.ToList().IndexOf(maxc) });
            //}
            //for (int i = 0; i < vizn.Count(); i++)
            //{
            //    result.Add(vizn[i]);
            //}


            //for (int i = 0; i < nevz.Count; i++)
            //{
            //    double[] t = new double[logmax.Count];
            //    for (int j = 0; j < logmax.Count; j++)
            //    {
            //        t[j] = Evklid(logmax[j][0], nevz[i][0], logmax[j][1], nevz[i][1]);
            //    }
            //    double minm = t.Min();
            //    result.Add(new double[3] { nevz[i][0], nevz[i][1], t.ToList().IndexOf(minm) });
            //}



            List<List<double[]>> finish = new List<List<double[]>>();

            for (int i = 0; i < logmax.Count; i++)
                finish.Add(new List<double[]>());

            for (int j = 0; j < result.Count(); j++)
            {
                finish[Convert.ToInt32(result[j][2])].Add(new double[2] { result[j][0], result[j][1] });
            }

            return finish;
        }
        public static List<List<double[]>> classification11(List<double[]> data, List<double[]> logmax, int Mx, int My, double hx, double hy, double xmin, double ymin, double ymax, double[,] Pij)
        {
            List<double[]> delt = calculate(logmax, data, Mx, My, hx, hy, xmin, ymin, ymax, Pij);
            //List<double[]> mindist = dist(data, logmax);
            List<double[]> result = new List<double[]>();
            List<double[]> nevizn = new List<double[]>();
            List<double[]> vizn = new List<double[]>();

            for (int i = 0; i < data[0].Length; i++)
            {
                double max = delt[i].Max();
                int index1 = delt[i].ToList().IndexOf(max);
                double[] mass = new double[3] { data[0][i], data[1][i], index1 };
                    result.Add(mass);
            }
            List<List<double[]>> finish = new List<List<double[]>>();

            for (int i = 0; i < logmax.Count; i++)
                finish.Add(new List<double[]>());

            for (int j = 0; j < result.Count(); j++)
            {
                finish[Convert.ToInt32(result[j][2])].Add(new double[2] { result[j][0], result[j][1] });
            }

            return finish;
        }
        public static List<double[]> calculate(List<double[]> logmax, List<double[]> data, int Mx, int My, double hx,double hy,double xmin,double ymin,double ymax,double[,] Pij)
        {
            List<double[]> res = new List<double[]>();
            
            List<double[]> mindist = dist(data, logmax);
            List<double[]> delx = deltax(mindist, logmax, data);
            List<double[]> xx0 = x0(mindist, logmax, data);
            List<double[]> yy0 = y0(logmax, data, xx0,ymin,ymax);
            
            List<double[]> dely = deltay(logmax, data, yy0);
            List<double[]> ff0 = f0(xx0, yy0, hx, hy, Mx, My, xmin, ymin, Pij);
            List<double> ff = fPoint(data, hx, hy, Mx, My, xmin, ymin, Pij);

            for (int i = 0; i < data[0].Length; i++)
            {
                double[] temp = new double[logmax.Count];
                for (int j = 0; j < logmax.Count; j++)
                    temp[j] = Gradient.Pohidna(data[0][i],data[1][i], xx0[i][j], yy0[i][j],hx,hy,Mx,My,xmin,ymin,Pij);
                //temp[j] = (ff0[i][j] - ff[i]) / delta(delx[i][j], dely[i][j]);
                res.Add(temp);
            }
            return res;
        }
        public static List<double[]> dist(List<double[]> data, List<double[]> logmax)
        {
            List<double[]> result = new List<double[]>();

            for (int i = 0; i < data[0].Length; i++)
            {
                double[] temp = new double[logmax.Count()];
                for (int j = 0; j < logmax.Count; j++)
                    temp[j] = Evklid(logmax[j][0], data[0][i], logmax[j][1], data[1][i]);
                result.Add(temp);
            }
            return result;
        }
        public static List<double[]> dist1(List<double[]> data, List<double[]> logmax)
        {
            List<double[]> result = new List<double[]>();

            for (int i = 0; i < data.Count(); i++)
            {
                double[] temp = new double[logmax.Count()];
                for (int j = 0; j < logmax.Count(); j++)
                {
                    temp[j] = Evklid(logmax[j][0], data[i][0], logmax[j][1], data[i][1]);
                }
                result.Add(temp);
            }
            return result;
        }
        public static double Evklid(double x1, double x2, double y1, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }
        public static double y_line(double x, double x1, double x2, double y1, double y2)
        {
            double result = Convert.ToDouble((y2 - y1) * (x - x1)) / Convert.ToDouble(x2 - x1) + y1;
            return result;
        }

        // (x1,y1) - logmax   (x2,y2) - point
        public static List<double[]> deltax(List<double[]> mindist, List<double[]> logmax, List<double[]> data)// x1 - logmax x2-point
        {
            List<double[]> res = new List<double[]>();
            for (int i = 0; i < data[0].Length; i++)
            {
                double min = mindist[i].Min();
                int index = mindist[i].ToList().IndexOf(min);
                double krok = Math.Abs(logmax[index][0] - data[0][i]) / 10.0;
                
                double[] temp = new double[logmax.Count];
                for (int j = 0; j < logmax.Count; j++)
                {
                    //double krok = Math.Abs(logmax[j][0] - data[0][i]) / 2.0;
                    //double krok = 0.00001;
                    if (logmax[j][0] < data[0][i])
                        temp[j] = -1 * krok;
                    else if (logmax[j][0] > data[0][i])
                        temp[j] = krok;
                    else
                        temp[j] = 0.01;
                }
                res.Add(temp);
            }
            return res;
        }
        public static List<double[]> x0(List<double[]> mindist, List<double[]> logmax, List<double[]> data)// x1 - logmax x2-point
        {
            List<double[]> res = new List<double[]>();
            List<double[]> krok = deltax(mindist, logmax, data);
            for (int i = 0; i < data[0].Length; i++)
            {
                double[] temp = new double[logmax.Count];
                for (int j = 0; j < logmax.Count; j++)
                    temp[j] = data[0][i] + krok[i][j];
                res.Add(temp);
            }
            return res;
        }
        public static List<double[]> y0(List<double[]> logmax, List<double[]> data, List<double[]> x0, double ymin, double ymax)
        {
            List<double[]> res = new List<double[]>();
            for (int i = 0; i < data[0].Length; i++)
            {
                double[] temp = new double[logmax.Count];
                for (int j = 0; j < logmax.Count; j++)
                {
                    if (data[1][i] == logmax[j][1] || data[0][i] == logmax[j][0])
                    {
                        temp[j] = data[1][i];
                    }
                    else
                    {
                        double ttt = y_line(x0[i][j], data[0][i], logmax[j][0], data[1][i], logmax[j][1]);
                        if (ttt > ymax)
                            ttt = ymax - 0.0001;
                        if (ttt < ymin)
                            ttt = ymin + 0.0001;
                        temp[j] = ttt;
                    }
                }
                res.Add(temp);
            }
            return res;
        }
        public static List<double[]> deltay(List<double[]> logmax, List<double[]> data, List<double[]> y0)
        {
            List<double[]> res = new List<double[]>();
            for (int i = 0; i < data[0].Length; i++)
            {
                double[] temp = new double[logmax.Count];
                for (int j = 0; j < logmax.Count; j++)
                    temp[j] = y0[i][j] - data[1][i];
                res.Add(temp);
            }
            return res;
        }
        public static List<double[]> f0(List<double[]> x0, List<double[]> y0, double hx, double hy, int Mx, int My, double xmin, double ymin, double[,] Pij)
        {
            List<double[]> res = new List<double[]>();
            for (int i = 0; i < x0.Count; i++)
            {
                double[] temp = new double[x0[i].Length];
                for (int j = 0; j < x0[i].Length; j++)
                    temp[j] = Spline.Sppl202(x0[i][j], y0[i][j], hx, hy, Mx, My, xmin, ymin, Pij)[2];
                res.Add(temp);
            }
            return res;
        }
        public static List<double> fPoint(List<double[]> data, double hx, double hy, int Mx, int My, double xmin, double ymin, double[,] Pij)
        {
            List<double> res = new List<double>();
            for (int i = 0; i < data[0].Length; i++)
            {
                res.Add(Spline.Sppl202(data[0][i], data[1][i], hx, hy, Mx, My, xmin, ymin, Pij)[2]);
            }
            return res;
        }
        public static double delta(double deltax, double deltay)
        {
            return Math.Sqrt(deltax * deltax + deltay * deltay);
        }

        public static List<double[]> new_local(List<List<double[]>> cluster, double hx, double hy, int Mx, int My, double xmin, double ymin, double[,] Pij)
        {
            List<double[]> res = new List<double[]>();
            for (int i = 0; i < cluster.Count; i++)
            {
                List<double> spl = new List<double>();
                List<double> x = new List<double>();
                List<double> y = new List<double>();
                for (int j = 0; j < cluster[i].Count; j++)
                {
                    spl.Add(Spline.Sppl202(cluster[i][j][0], cluster[i][j][1], hx, hy, Mx, My, xmin, ymin, Pij)[2]);
                    x.Add(cluster[i][j][0]);
                    y.Add(cluster[i][j][1]);
                }
                double max = spl.Max();
                
                res.Add(new double[]{ Window.Average(x), Window.Average(y)});
                //res.Add(cluster[i][spl.IndexOf(max)]);
            }
            return res;
        }
        //////pohidna no naprym
        //public static double[] del(double x, double y, double locx, double locy, double delx, double dely)
        //{
        //    double dxx = x + (locx - x) * delx;
        //    double dyy = y + (locy - y) * dely;
        //    return new double[] { dxx, dyy };
        //}
        //public static List<List<double[]>> dfxy(List<double[]> data, List<double[]> locmax, double delx, double dely,double hx, double hy, int Mx, int My, double xmin, double ymin, double[,] Pij)
        //{
        //    List<List<double[]>> result = new List<List<double[]>>();
        //    for (int i = 0; i < locmax.Count; i++)
        //        result.Add(new List<double[]>());

        //    for (int i = 0; i < data[0].Length; i++)
        //    {  
        //        List<double> spl = new List<double>();
        //        for (int j = 0; j < locmax.Count; j++)
        //        {
        //            double[] temp = del(data[0][i], data[1][i], locmax[j][0], locmax[j][1], delx, dely);
        //            //double t = Spline.Sppl202(temp[0], temp[1], hx, hy, Mx, My, xmin, ymin, Pij)[2];
        //            double t = Spline.S20_B(temp[0], temp[1], hx,  hy,  Mx,  My,  xmin,  ymin,  Pij);
        //            spl.Add(t);
        //        }
        //        double max = spl.Max();
        //        int index = spl.IndexOf(max);
        //        result[index].Add(new double[] { data[0][i], data[1][i], index });
        //    }
        //    return result;
        //}
    }
    class Gradient
    {
        public static double Gradx(double t, double q, double ht, double hq, int Mx, int My, double minx, double miny, double[,] Pij)
            => Spline.S220_difft(t, q, ht, hq, Mx, My, minx, miny, Pij);
        public static double Grady(double t, double q, double ht, double hq, int Mx, int My, double minx, double miny, double[,] Pij)
            => Spline.S220_diffq(t, q, ht, hq, Mx, My, minx, miny, Pij);

        public static double[] Grad(double t, double q, double ht, double hq, int Mx, int My, double minx, double miny, double[,] Pij)
            => new double[2] { Gradx(t, q, ht, hq, Mx, My, minx, miny, Pij), Grady(t, q, ht, hq, Mx, My, minx, miny, Pij) };

        public static double[] funcParam(double ti, double qi, double gradx, double grady, double lambda)
            => new double[2] { ti + lambda * gradx, qi + lambda * grady };

        public static double funcLambd(double ti, double qi, double gradx, double grady, double lambda, double ht, double hq, int Mx, int My, double minx, double miny, double[,] Pij)
        {
            double[] param = funcParam(ti, qi, gradx, grady, lambda);
            double[] func = Spline.Sppl202(param[0], param[1], ht, hq, Mx, My, minx, miny, Pij);
            return func[2];
        }
        public static double GoldenSelection(double ti, double qi, double gradx, double grady, double a, double b, double eps, double ht, double hq, int Mx, int My, double minx, double miny, double[,] Pij)
        {
            const double fi = 1.61803398887;
            double x1, x2, y1, y2;
            x1 = b - ((b - a) / fi);
            x2 = a + ((b - a) / fi);
            y1 = funcLambd(ti, qi, gradx, grady, x1, ht, hq, Mx, My, minx, miny, Pij);
            y2 = funcLambd(ti, qi, gradx, grady, x2, ht, hq, Mx, My, minx, miny, Pij);
            while (Math.Abs(b - a) >= eps)
            {
                if (y1 >= y2)
                {
                    b = x2;
                    x2 = x1;
                    x1 = b - ((b - a) / fi);
                    y2 = y1;
                    y1 = funcLambd(ti, qi, gradx, grady, x1, ht, hq, Mx, My, minx, miny, Pij);
                }
                else
                {
                    a = x1;
                    x1 = x2;
                    x2 = a + ((b - a) / fi);
                    y1 = y2;
                    y2 = funcLambd(ti, qi, gradx, grady, x2, ht, hq, Mx, My, minx, miny, Pij);
                }
            }
            return (a + b) / 2;
        }

        public static double[] nextValue(double ti, double qi, double gradx, double grady, double lambda)
            => new double[2] { ti + lambda * gradx, qi + lambda * grady };

        public static double[] GradUp(double t0, double q0, double a, double b, double eps, double ht, double hq, int Mx, int My, double minx, double miny, double[,] Pij)// a,b - interval for searching lambda!!!! a=0; b=0.05
        {
            double[] current = new double[] { t0, q0 };
            double[] next = new double[] { t0, q0 };
            do
            {
                current = next;
                double[] grad = Grad(current[0], current[1], ht, hq, Mx, My, minx, miny, Pij);
                if (grad[0] == 0 && grad[1] == 0)
                    return next;

                double lambda = GoldenSelection(current[0], current[1], grad[0], grad[1], a, b, eps, ht, hq, Mx, My, minx, miny, Pij);
                next = nextValue(current[0], current[1], grad[0], grad[1], lambda);
                
            }
            while (Math.Abs(Spline.Sppl202(next[0], next[1], ht, hq, Mx, My, minx, miny, Pij)[2] - Spline.Sppl202(current[0], current[1], ht, hq, Mx, My, minx, miny, Pij)[2]) > eps);
            
            return next;
        }
        public static List<bool> CheckAround(List<double[]> locmax, double ht, double hq, int Mx, int My, double minx, double miny, double maxx, double maxy,double[,] Pij)
        {
            List<bool> result = new List<bool>();
            List<List<double[]>> okil = new List<List<double[]>>();
            double dil = 1;
            for (int i = 0; i < locmax.Count; i++)
            {
                List<double[]> temp = new List<double[]>();
                double t = locmax[i][0], q = locmax[i][1];
                double[][] tochk = new double[8][] {new double[2]{t-ht/ dil, q-hq/dil},
                                                    new double[2]{t- ht / dil, q },
                                                    new double[2]{t- ht / dil, q+hq/dil},
                                                    new double[2]{t,q-hq/dil },
                                                    new double[2]{t,q+hq/dil },
                                                    new double[2]{t+ ht / dil, q-hq/dil },
                                                    new double[2]{t+ ht / dil, q },
                                                    new double[2]{t+ ht / dil, q+hq/dil }};
                for (int k = 0; k < tochk.GetLength(0); k++)
                {
                    if (tochk[k][0] <= minx)
                        tochk[k][0] = minx;
                    if (tochk[k][0] >= maxx)
                        tochk[k][0] = maxx;
                    if (tochk[k][1] <= miny)
                        tochk[k][1] = miny ;
                    if (tochk[k][1] >= maxy)
                        tochk[k][1] = maxy;
                }

                List<double> tp = new List<double>();
                double p = Spline.Sppl202(t, q, ht, hq, Mx, My, minx, miny, Pij)[2];
                for (int k = 0; k < tochk.GetLength(0); k++)
                    tp.Add(Spline.Sppl202(tochk[k][0], tochk[k][1], ht, hq, Mx, My, minx, miny, Pij)[2]);

                if (p >= tp[0] && p >= tp[1] && p >= tp[2] && p >= tp[3] && p >= tp[4] && p >= tp[5] && p >= tp[6] && p >= tp[7])
                    result.Add(true);
                else
                    result.Add(false);
            }
            return result;
        }
        public static List<double[]> CalculateGradUp(List<double[]> data, double a, double b, double eps, double ht, double hq, int Mx, int My, double minx, double miny, double maxx, double maxy,double[,] Pij)
        {
            List<double[]> result = new List<double[]>();// all logmax of data
            //for (int i = 0; i < data[0].Length; i++)
            //{
            //    double[] gradUp = GradUp(data[0][i], data[1][i], a, b, eps, ht, hq, Mx, My, minx, miny, Pij);
            //    double[] grad = Grad(gradUp[0], gradUp[1], ht, hq, Mx, My, minx, miny, Pij);
            //    if(LocalMax.Hesse(gradUp[0],gradUp[1],ht,hq,Mx,My,minx,miny,Pij) && Math.Abs(Math.Round(grad[0],4))==0 && Math.Abs(Math.Round(grad[1],4))==0)
            //        result.Add(gradUp);
            //}
            List<double[]> res = new List<double[]>();
            for (int i = 0; i < Mx; i++)
                for (int j = 0; j < My; j++)
                {

                    double[] gradUp = GradUp(i*ht+minx, j*hq+miny, a, b, eps, ht, hq, Mx, My, minx, miny, Pij);
                    double[] grad = Grad(i * ht+ minx, j * hq+ miny, ht, hq, Mx, My, minx, miny, Pij);
                    if (LocalMax.Hesse(gradUp[0], gradUp[1], ht, hq, Mx, My, minx, miny, Pij))
                        res.Add(gradUp);
                }

            List<bool> check = CheckAround(res, ht, hq, Mx, My, minx, miny, maxx, maxy, Pij);

            for (int i = 0; i < res.Count; i++)
            {
                if (check[i])
                    result.Add(res[i]);
            }
            List<double[]> ind = new List<double[]>();
            for (int i = 0; i < result.Count; i++)
            {
                for (int j = i + 1; j < result.Count; j++)
                {
                    if (i != j)
                        if (Math.Abs(result[i][0] - result[j][0]) < ht && Math.Abs(result[i][1] - result[j][1]) < hq)
                            ind.Add(result[i]);
                }
            }
            for (int i = 0; i < result.Count; i++)
            {
                for (int j = 0; j < ind.Count; j++)
                {
                    if (result[i][0] == ind[j][0] && result[i][1] == ind[j][1])
                    {
                        result.RemoveAt(i);
                        ind.RemoveAt(j);
                    }
                }
            }

            return result ;
        }
        public static List<List<double[]>> ClusterGrad(List<double[]> data, List<double[]> locmax, double a, double b, double eps, double ht, double hq, int Mx, int My, double minx, double miny, double maxx, double maxy, double[,] Pij)
        {
            List<List<double[]>> result = new List<List<double[]>>();// all logmax of data
            List<double[]> gradmax = new List<double[]>();
            List<int> power = new List<int>();




            ///////////////// !!!!! походу не правильно
            //for (int i = 0; i < data[0].Length; i++)
            //{
            //    ////// !!!!!! повністю переписать
            //    double[] gradUp = GradUp(data[0][i], data[1][i], a, b, eps, ht, hq, Mx, My, minx, miny, Pij);
            //    double[] grad = Grad(gradUp[0], gradUp[1], ht, hq, Mx, My, minx, miny, Pij);
            //    //power.Add(Math.Sqrt(grad[0] * grad[0] + grad[1] * grad[1]));//////////// !!!!!!! недописано, добавиь сюди штуку з вектором і косинусами
            //                                                                //if (LocalMax.Hesse(gradUp[0], gradUp[1], ht, hq, Mx, My, minx, miny, Pij) && Math.Abs(Math.Round(grad[0], 4)) == 0 && Math.Abs(Math.Round(grad[1], 4)) == 0)
            //    gradmax.Add(gradUp);
            //}
            for (int i = 0; i < data[0].Length; i++)
            {
                double[] gradUp = GradUp(data[0][i], data[1][i], a, b, eps, ht, hq, Mx, My, minx, miny, Pij);
                List<double> pohd = new List<double>();
                for (int j = 0; j < locmax.Count; j++)
                {
                    double temp = Classif.Evklid(gradUp[0], locmax[j][0], gradUp[1], locmax[j][1]);
                    pohd.Add(temp);
                }
                double min = pohd.Min();
                power.Add(pohd.IndexOf(min));
            }
            //List<int> res = new List<int>();
            //for (int i = 0; i < gradmax.Count; i++)
            //{
            //    List<double> temp = new List<double>();
            //    //for (int j = 0; j < locmax.Count; j++)
            //    //    temp.Add();
            //    double min = temp.Min();
            //    res.Add(temp.IndexOf(min));
            //}

            for (int i = 0; i < locmax.Count; i++)
                result.Add(new List<double[]>());
            for (int i = 0; i < data[0].Length; i++)
            {
                int index = power[i];
                result[index].Add(new double[] { data[0][i], data[1][i] });
            }          
            return result;
        }

        public static double[] cos(double x1, double y1, double x2, double y2)
        {
            double modul = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            return new double[2] { (x2 - x1) / modul, (y2 - y1) / modul };
        }
        public static double Pohidna(double x1, double y1, double x2, double y2, double ht, double hq, int Mx, int My, double minx, double miny, double[,] Pij)
        {
            double Sx = Spline.S220_difft(x1, y1, ht, hq, Mx, My, minx, miny, Pij);
            double Sy = Spline.S220_diffq(x1, y1, ht, hq, Mx, My, minx, miny, Pij);
            double[] cosn = cos(x1, y1, x2, y2);
            double result = Sx * cosn[0] + Sy * cosn[1];
            return result;
        }

        public static List<List<double[]>> clasterDiff(List<double[]> data, List<double[]> locmax, double ht, double hq, int Mx, int My, double minx, double miny, double[,] Pij)
        {
            List<List<double[]>> result = new List<List<double[]>>();
            List<int> res = new List<int>();
            List<double> pohd = new List<double>();
            for (int i = 0; i < data[0].Length; i++)
            {
                List<double> temp = new List<double>();
                for (int j = 0; j < locmax.Count; j++)
                {
                    temp.Add(Pohidna(data[0][i], data[1][i], locmax[j][0], locmax[j][1], ht, hq, Mx, My, minx, miny, Pij));
                    //pohd.Add(Classif.Evklid(data[0][i], locmax[j][0], data[1][i], locmax[j][1]));
                }
                double max = temp.Max();
                //double min = pohd.Min();
                //if (temp.IndexOf(max) == pohd.IndexOf(min))
                    res.Add(temp.IndexOf(max));
                //else
                //    res.Add(pohd.IndexOf(min));
            }

            for (int i = 0; i < locmax.Count; i++)
                result.Add(new List<double[]>());
            for (int i = 0; i < data[0].Length; i++)
            {
                int index = res[i];
                result[index].Add(new double[] { data[0][i], data[1][i] });
            }
            return result;
        }
        }
}
