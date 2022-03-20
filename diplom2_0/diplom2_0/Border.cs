using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZedGraph;

namespace diplom2_0
{
    class Border
    {
        public static List<double[]> Firstdiff(int Mx, int My, double ht, double hq, double minx, double miny, double[,] Pij)
        {
            List<double[]> result = new List<double[]>();

            double krokx = 1.0 / 10.0;
            double kroky = 1.0 / 10.0;

            for (int i = 0; i < Mx; i++)
            {
                for (int j = 0; j < My; j++)
                {
                    if (i == 0)
                    {
                        for (double x = 0.0; x < 1.0; x += krokx)
                        {
                            double t = x * ht / 2.0 + i * ht + minx;
                            if (j == 0)
                            {
                                for (double y = 0.0; y < 1.0; y += kroky)
                                {
                                    double q = y * hq / 2.0 + j * hq + miny;
                                    double spt = Spline.S220_difft(t, q, ht, hq, Mx, My, minx, miny, Pij);
                                    double spq = Spline.S220_diffq(t, q, ht, hq, Mx, My, minx, miny, Pij);
                                    double[] res = new double[4] { t, q, spt, spq };
                                    result.Add(res);
                                }
                            }
                            else if (j == My - 1)
                            {
                                for (double y = -1.0; y < 0.0; y += kroky)
                                {
                                    double q = y * hq / 2.0 + j * hq + miny;
                                    double spt = Spline.S220_difft(t, q, ht, hq, Mx, My, minx, miny, Pij);
                                    double spq = Spline.S220_diffq(t, q, ht, hq, Mx, My, minx, miny, Pij);
                                    double[] res = new double[4] { t, q, spt, spq };
                                    result.Add(res);
                                }
                            }
                            else
                            {
                                for (double y = -1.0; y < 1.0; y += kroky)
                                {
                                    double q = y * hq / 2.0 + j * hq + miny;
                                    double spt = Spline.S220_difft(t, q, ht, hq, Mx, My, minx, miny, Pij);
                                    double spq = Spline.S220_diffq(t, q, ht, hq, Mx, My, minx, miny, Pij);
                                    double[] res = new double[4] { t, q, spt, spq };
                                    result.Add(res);
                                }
                            }
                        }
                    }
                    else if (i == Mx - 1)
                    {
                        for (double x = -1.0; x < 0.0; x += krokx)
                        {
                            double t = x * ht / 2.0 + i * ht + minx;
                            if (j == 0)
                            {
                                for (double y = 0.0; y < 1.0; y += kroky)
                                {
                                    double q = y * hq / 2.0 + j * hq + miny;
                                    double spt = Spline.S220_difft(t, q, ht, hq, Mx, My, minx, miny, Pij);
                                    double spq = Spline.S220_diffq(t, q, ht, hq, Mx, My, minx, miny, Pij);
                                    double[] res = new double[4] { t, q, spt, spq };
                                    result.Add(res);
                                }
                            }
                            else if (j == My - 1)
                            {
                                for (double y = -1.0; y < 0.0; y += kroky)
                                {
                                    double q = y * hq / 2.0 + j * hq + miny;
                                    double spt = Spline.S220_difft(t, q, ht, hq, Mx, My, minx, miny, Pij);
                                    double spq = Spline.S220_diffq(t, q, ht, hq, Mx, My, minx, miny, Pij);
                                    double[] res = new double[4] { t, q, spt, spq };
                                    result.Add(res);
                                }
                            }
                            else
                            {
                                for (double y = -1.0; y < 1.0; y += kroky)
                                {
                                    double q = y * hq / 2.0 + j * hq + miny;
                                    double spt = Spline.S220_difft(t, q, ht, hq, Mx, My, minx, miny, Pij);
                                    double spq = Spline.S220_diffq(t, q, ht, hq, Mx, My, minx, miny, Pij);
                                    double[] res = new double[4] { t, q, spt, spq };
                                    result.Add(res);
                                }
                            }
                        }
                    }
                    else
                    {
                        for (double x = -1.0; x < 1.0; x += krokx)
                        {
                            double t = x * ht / 2.0 + i * ht + minx;
                            if (j == 0)
                            {
                                for (double y = 0.0; y < 1.0; y += kroky)
                                {
                                    double q = y * hq / 2.0 + j * hq + miny;
                                    double spt = Spline.S220_difft(t, q, ht, hq, Mx, My, minx, miny, Pij);
                                    double spq = Spline.S220_diffq(t, q, ht, hq, Mx, My, minx, miny, Pij);
                                    double[] res = new double[4] { t, q, spt, spq };
                                    result.Add(res);
                                }
                            }
                            else if (j == My - 1)
                            {
                                for (double y = -1.0; y < 0.0; y += kroky)
                                {
                                    double q = y * hq / 2.0 + j * hq + miny;
                                    double spt = Spline.S220_difft(t, q, ht, hq, Mx, My, minx, miny, Pij);
                                    double spq = Spline.S220_diffq(t, q, ht, hq, Mx, My, minx, miny, Pij);
                                    double[] res = new double[4] { t, q, spt, spq };
                                    result.Add(res);
                                }
                            }
                            else
                            {
                                for (double y = -1.0; y < 1.0; y += kroky)
                                {
                                    double q = y * hq / 2.0 + j * hq + miny;
                                    double spt = Spline.S220_difft(t, q, ht, hq, Mx, My, minx, miny, Pij);
                                    double spq = Spline.S220_diffq(t, q, ht, hq, Mx, My, minx, miny, Pij);
                                    double[] res = new double[4] { t, q, spt, spq };
                                    result.Add(res);
                                }
                            }
                        }
                    }
                }
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
            if (Math.Round(det,1) == 0)
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
            return result;
        }
        public static List<double[]> Stacionar(int Mx, int My, double ht, double hq, double minx, double miny, double[,] Pij)
        {
            List<double[]> result = new List<double[]>();
            List<double[]> res = new List<double[]>();
            List<double[]> firstdiff = Firstdiff(Mx, My, ht, hq, minx, miny, Pij);
            for (int i = 0; i < firstdiff.Count; i++)
                if (Math.Round(firstdiff[i][2], 2) == 0.0 && Math.Round(firstdiff[i][3], 2) == 0.0)
                    result.Add(firstdiff[i]);

            for (int i = 0; i < result.Count; i++)
                if (Hesse1(result[i][0], result[i][1], ht, hq, Mx, My, minx, miny, Pij))
                    res.Add(result[i]);

            return res;
        }

        public static void DrawBorder(int Mx, int My, double ht, double hq, double minx, double miny, double[,] Pij, ZedGraphControl zgc)
        {
            GraphPane myPane = zgc.GraphPane;
            List<double[]> stacionar = Stacionar(Mx, My, ht, hq, minx, miny, Pij);
            PointPairList list = new PointPairList();

            for (int i = 0; i < stacionar.Count; i++)
                list.Add(stacionar[i][0], stacionar[i][1]);


            LineItem curve = myPane.AddCurve("border", list, Color.Black, SymbolType.Diamond);
            curve.Line.IsVisible = false;
            curve.Symbol.Border.IsVisible = true;
            curve.Symbol.Fill = new Fill(Color.Black);
            //curve.Symbol.Size = 10;
            myPane.CurveList.Move(myPane.CurveList.IndexOf("border"), -999);

            myPane.YAxis.Scale.MinAuto = true;
            myPane.YAxis.Scale.MaxAuto = true;
            myPane.IsBoundedRanges = true;

            zgc.AxisChange();
            zgc.Invalidate();
        }
    }
}
