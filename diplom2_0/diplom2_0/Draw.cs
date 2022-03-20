using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZedGraph;
using ZedGraph;

namespace diplom2_0
{
    class Draw
    {
        static int Mx(List<double> x) => Parametrs.M(x);
        static int My(List<double> y) => Parametrs.M(y);
        static double hx(List<double> x) => Parametrs.h_Krok(x, Mx(x));
        static double hy(List<double> y) => Parametrs.h_Krok(y, My(y));
        static Color[] coll = new Color[5] { Color.Honeydew, Color.PaleGreen, Color.Yellow, Color.Red, Color.SaddleBrown };
        public static List<Color> GetGradientColors(Color start, Color end, int steps)
        {
            return GetGradientColors(start, end, steps, 0, steps - 1);
        }

        public static List<Color> GetGradientColors(Color start, Color end, int steps, int firstStep, int lastStep)
        {
            var colorList = new List<Color>();
            if (steps <= 0 || firstStep < 0 || lastStep > steps - 1)
                return colorList;

            double aStep = (end.A - start.A) / steps;
            double rStep = (end.R - start.R) / steps;
            double gStep = (end.G - start.G) / steps;
            double bStep = (end.B - start.B) / steps;

            for (int i = firstStep; i < lastStep; i++)
            {
                var a = start.A + (int)(aStep * i);
                var r = start.R + (int)(rStep * i);
                var g = start.G + (int)(gStep * i);
                var b = start.B + (int)(bStep * i);
                colorList.Add(Color.FromArgb(a, r, g, b));
            }

            return colorList;
        }
        //public static void Param()
        public static void Gist2vim(List<double> sered, List<double> sig, List<double> spl, ZedGraphControl zgc)
        {
            
            GraphPane myPane = zgc.GraphPane;
           
            //myPane.Title.Text=""
            myPane.CurveList.Clear();
            
            List<List<double>> x = new List<List<double>>();
            List<List<double>> y = new List<List<double>>();

            
            for (int i = 0; i < coll.Length; i++)
            {
                x.Add(new List<double>());
                y.Add(new List<double>());
            }
            List<double> help = new List<double>();
            for (int i = 0; i < spl.Count; i++)
            {
                help.Add(spl[i]);
            }
            help.Sort();
            int cc = help.Count / 5;
            double r1 = help.ElementAt(Convert.ToInt32(cc*1));
            double r2 = help.ElementAt(2 * cc);
            double r3 = help.ElementAt(3 * cc);
            double r4 = help.ElementAt(4 * cc);
            double color = (spl.Max() - spl.Min()) / 5;
            for (int i = 0; i < sered.Count(); i++)
            {
                double z = spl[i];
                
                    if (z <= r1)
                    {
                        x[0].Add(sered[i]);
                        y[0].Add(sig[i]);
                    }
                    else if (z > r1 && z <= r2)
                    {
                        x[1].Add(sered[i]);
                        y[1].Add(sig[i]);
                    }
                    else if (z > r2 && z <= r3)
                    {
                        x[2].Add(sered[i]);
                        y[2].Add(sig[i]);
                    }
                    else if (z > r3 && z <= r4)
                    {
                        x[3].Add(sered[i]);
                        y[3].Add(sig[i]);
                    }
                    else
                    {
                        x[4].Add(sered[i]);
                        y[4].Add(sig[i]);
                    }
            }
            string[] labels = { "P0", "P1", "P2", "P3", "P4", "P5", "P6" };
            CurveList cl = new CurveList();
            //List<Color> colors = GetGradientColors(Color.Red, Color.Yellow, 5);
            for (int i = 0; i < coll.Length; i++)
            {
                cl.Add(AddCurve(labels[i], x[i].ToArray(), y[i].ToArray(), coll[i], SymbolType.Circle));
                myPane.CurveList.Add(cl[i]);
                
            }
            
            //myPane.XAxis.Scale.Min = sered.Min();
            //myPane.XAxis.Scale.Max = sered.Max();
            myPane.Legend.IsVisible = false;
            myPane.YAxis.Scale.MinAuto = true;
            myPane.YAxis.Scale.MaxAuto = true;
            myPane.IsBoundedRanges = true;
            myPane.Title.IsVisible = false;
            //myPane.XAxis.Scale.Min = sered.Min();
            //myPane.XAxis.Scale.Max = 256;
            //myPane.YAxis.Scale.Min = sig.Min();
            //myPane.YAxis.Scale.Max = sig.Max()+2;
            myPane.XAxis.Title.Text = "m";
            myPane.YAxis.Title.Text = "σ";
            zgc.AxisChange();
            zgc.Invalidate(); 
        }
        public static LineItem AddCurve(string label, double[] x, double[] y, Color col, SymbolType change)
        {
            var curve = new LineItem(label)
            {
                Points = new PointPairList(x, y),
                Color = col,
                Symbol = new Symbol(change, col),

            };
            curve.Line.IsVisible = false;
            curve.Symbol.Border.IsVisible = false;
            curve.Symbol.Fill = new Fill(col);
            return curve;
        }
        public static LineItem AddCurveClas(string label, double[] x, double[] y, Color col, SymbolType change)
        {
            var curve = new LineItem(label)
            {
                Points = new PointPairList(x, y),
                Color = col,
                Symbol = new Symbol(change, col),

            };
            curve.Line.IsVisible = false;
            curve.Symbol.Border.IsVisible = true;
            curve.Symbol.Border.Color = Color.Black;
            curve.Symbol.Fill = new Fill(col);
            //curve.Symbol.Size = 4;
            return curve;
        }
        public static LineItem AddCurve(string label, double x, double y, Color col, SymbolType change, int size)
        {
            PointPairList list = new PointPairList();
            list.Add(x, y);
            var curve = new LineItem(label)
            {
                Points = list,
                Color = col,
                Symbol = new Symbol(change, col),

            };
            curve.Line.IsVisible = false;
            curve.Symbol.Border.IsVisible = true;
            curve.Symbol.Border.Color = Color.Black;
            curve.Symbol.Fill = new Fill(col);
            curve.Symbol.Size = size;
            return curve;
        }
        
        public static void Localmax(List<double[]> loc, ZedGraphControl zgc, Color [] color)
        {

            GraphPane myPane = zgc.GraphPane;

            double[] loc_x = new double[loc.Count];
            double[] loc_y = new double[loc.Count];
            for (int i = 0; i < loc.Count; i++)
            {
                loc_x[i] = loc[i][0];
                loc_y[i] = loc[i][1];
            }

            
            //string[] labels = { "LM0", "LM1", "LM2", "LM3", "LM4", "LM5", "LM6", "LM7", "LM8", "LM9", "LM10", "LM11", "LM12", "LM13", "LM14", "LM15", "LM16", "LM17", "LM18", "LM19", "LM20" };
            CurveList cl = new CurveList();
            for (int i = 0; i < loc.Count; i++)
            {
                cl.Add(AddCurve("LM"+i.ToString(), loc_x[i], loc_y[i], color[i], SymbolType.TriangleDown,15));
                myPane.CurveList.Add(cl[i]);
                myPane.CurveList.Move(myPane.CurveList.IndexOf("LM" + i.ToString()), -999);

            }

            myPane.YAxis.Scale.MinAuto = true;
            myPane.YAxis.Scale.MaxAuto = true;
            myPane.IsBoundedRanges = true;
            myPane.Title.IsVisible = false;
            zgc.AxisChange();
            myPane.Legend.IsVisible = false;

            zgc.Invalidate();
        }
        public static void Localmin(List<double[]> loc, ZedGraphControl zgc, Color[] color)
        {

            GraphPane myPane = zgc.GraphPane;

            double[] loc_x = new double[loc.Count];
            double[] loc_y = new double[loc.Count];
            for (int i = 0; i < loc.Count; i++)
            {
                loc_x[i] = loc[i][0];
                loc_y[i] = loc[i][1];
            }
            LineItem curve = myPane.AddCurve("border", loc_x,loc_y, Color.Black, SymbolType.Diamond);
            curve.Line.IsVisible = false;
            curve.Symbol.Border.IsVisible = true;
            curve.Symbol.Fill = new Fill(Color.Black);
            curve.Symbol.Size = 10;
            myPane.CurveList.Move(myPane.CurveList.IndexOf("border"), -999);

            

            myPane.YAxis.Scale.MinAuto = true;
            myPane.YAxis.Scale.MaxAuto = true;
            myPane.IsBoundedRanges = true;
            myPane.Title.IsVisible = false;
            zgc.AxisChange();


            zgc.Invalidate();
        }
        public static void Classif(List<List<double[]>> clasif, ZedGraphControl zgc, Color[] color)
        {

            GraphPane myPane = zgc.GraphPane;

            List<double[]> cls_x = new List<double[]>();
            List<double[]> cls_y = new List<double[]>();
            for (int i = 0; i < clasif.Count; i++)
            {
                double[] tmpx = new double[clasif[i].Count];
                double[] tmpy = new double[clasif[i].Count];
                for (int j = 0; j < clasif[i].Count; j++)
                {
                    tmpx[j] = clasif[i][j][0];
                    tmpy[j] = clasif[i][j][1];
                }
                cls_x.Add(tmpx);
                cls_y.Add(tmpy);
            }


            //string[] labels = { "Class0", "Class1", "Class2", "Class3", "Class4", "Class5", "Class6", "Class7", "Class8", "Class9", "Class10", "Class11", "Class12" };
            CurveList cl = new CurveList();
            for (int i = 0; i < cls_x.Count; i++)
            {
                cl.Add(AddCurveClas("Class"+i.ToString(), cls_x[i], cls_y[i], color[i], SymbolType.Diamond));
                myPane.CurveList.Add(cl[i]);
                myPane.CurveList.Move(myPane.CurveList.IndexOf("Class" + i.ToString()), -coll.Length);

            }

            myPane.YAxis.Scale.MinAuto = true;
            myPane.YAxis.Scale.MaxAuto = true;
            myPane.IsBoundedRanges = true;
            myPane.Legend.IsVisible = false;
            zgc.AxisChange();
            zgc.Invalidate();
        }

        public static void Pointts(List<double[]> data, ZedGraphControl zgc)
        {

            GraphPane myPane = zgc.GraphPane;
            PointPairList list = new PointPairList();
            for (int i = 0; i < data[0].Length; i++)
            {
                list.Add(data[0][i], data[1][i]);
            }

            LineItem curve = myPane.AddCurve("points", list, Color.White, SymbolType.Circle);
            curve.Line.IsVisible = false;
            curve.Symbol.Border.IsVisible = true;
            curve.Symbol.Border.Color = Color.Black;
            curve.Symbol.Fill = new Fill(Color.White);
            //curve.Symbol.Size = 10;
            myPane.CurveList.Move(myPane.CurveList.IndexOf("points"), -999);
            
            myPane.YAxis.Scale.MinAuto = true;
            myPane.YAxis.Scale.MaxAuto = true;
            myPane.IsBoundedRanges = true;
            //myPane.Title.IsVisible = false;
            zgc.AxisChange();
            zgc.Invalidate();
        }



    }
    
}
