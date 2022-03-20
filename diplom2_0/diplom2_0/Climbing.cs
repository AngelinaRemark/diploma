using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diplom2_0
{
    class Climbing
    {
        public static double[] point_next(double t, double q, double ht, double hq, int Mx, int My, double minx, double miny, double[,] Pij, double epsilon)
        {
            double Splt = Spline.S220_difft(t, q, ht, hq, Mx, My, minx, miny, Pij);
            double Splq = Spline.S220_diffq(t, q, ht, hq, Mx, My, minx, miny, Pij);
            double norma = Math.Sqrt(Splt * Splt + Splq * Splq);
            double temp1 = t + epsilon * Splt / norma;
            double temp2 = q + epsilon * Splq / norma;
            double[]  res = new double[2] { temp1, temp2 };
            return res;
        }
        public static bool stoped(double[] begin, double[] locmax, double ht, double hq, int Mx, int My, double minx, double miny, double[,] Pij, double epsilon)
        {
            bool res = true;
            double dist1 = Spline.Sppl202(begin[0],begin[1],ht,hq,Mx,My,minx,miny,Pij)[2];
            double dist2 = Spline.Sppl202(locmax[0], locmax[1], ht, hq, Mx, My, minx, miny, Pij)[2];
            if (Math.Abs(dist2-dist1) <= 2 * epsilon)
                res = false;
            return res;
        }
        public static double[] index_point(List<double[]> locmax, double t, double q, double ht, double hq, int Mx, int My, double minx, double miny, double[,] Pij, double epsilon)
        {
            double[] res = new double[3];
            double[] begin = new double[2] { t, q };

            for (int i = 0; i < locmax.Count(); i++)
            {
                while (stoped(begin, locmax[i], ht, hq, Mx, My, minx, miny, Pij,epsilon))
                {
                    double[] next = point_next(begin[0], begin[1], ht, hq, Mx, My, minx, miny, Pij, epsilon);
                    begin = next;
                }
                res = new double[3] { begin[0], begin[1], i };
            }
            return res;
        }
        public static List<double[]> process(List<double[]> data, List<double[]> locmax, double ht, double hq, int Mx, int My, double minx, double miny, double[,] Pij, double epsilon)
        {
            List<double[]> res = new List<double[]>();
            for (int i = 0; i < data[0].Length; i++)
            {
                double[] temp = index_point(locmax,data[0][i],data[1][i],ht,hq,Mx,My,minx,miny,Pij,epsilon);
                res.Add(temp);
            }
            return res;
        }
        public static List<List<double[]>> cluster(List<double[]> data, List<double[]> locmax, double ht, double hq, int Mx, int My, double minx, double miny, double[,] Pij, double epsilon)
        {
            List<List<double[]>> res = new List<List<double[]>>();
            for (int i = 0; i < locmax.Count(); i++)
            {
                res.Add(new List<double[]>());
            }
            List<double[]> proc = process(data, locmax, ht, hq, Mx, My, minx, miny, Pij, epsilon);
            for (int i = 0; i < proc.Count; i++)
            {
                int ind = Convert.ToInt32(proc[i][2]);
                res[ind].Add(new double[2] { proc[i][0], proc[i][1] });
            }
            return res;
        }

        
    }
}
