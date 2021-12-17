using System;

namespace lab3
{
    public class OptimalAssignmentSolver
    {
        public static int[] AppointEmployee(int[,] a)
        {
            var N = a.GetLength(0);
            if (N == 0) return Array.Empty<int>();

            var lx = new int[N];
            var ly = new int[N];

            var mx = new int[N];
            var my = new int[N];

            var px = new int[N];
            var py = new int[N];
            var stack = new int[N];

            for (var i = 0; i < N; i++)
            {
                lx[i] = a[i, 0];
                
                for (int j = 0; j < N; j++)
                {
                    if (a[i, j] > lx[i]) lx[i] = a[i, j];
                }
                
                ly[i] = 0;
                mx[i] = my[i] = -1;
            }

            for (int size = 0; size < N;)
            {
                int s;
                for (s = 0; mx[s] != -1; s++);
                
                for (var i = 0; i < N; i++)
                {
                    px[i] = py[i] = -1;
                }
                px[s] = s;

                var t = -1;
                stack[0] = s;
                for (var top = 1; top > 0;)
                {
                    var u = stack[--top];
                    for (var v = 0; v < N; v++)
                    {
                        if (lx[u] + ly[v] == a[u, v] && py[v] == -1)
                        {
                            if (my[v] == -1)
                            {
                                t = v;
                                py[t] = u;
                                top = 0;
                                break;
                            }

                            py[v] = u;
                            px[my[v]] = v;
                            stack[top++] = my[v];
                        }
                    }
                }

                if (t != -1)
                {
                    while (true)
                    {
                        int u = py[t];
                        mx[u] = t;
                        my[t] = u;
                        if (u == s) break;
                        t = px[u];
                    }

                    ++size;
                }
                else
                {
                    int delta = int.MaxValue;
                    for (int u = 0; u < N; u++)
                    {
                        if (px[u] == -1) continue;
                        for (int v = 0; v < N; v++)
                        {
                            if (py[v] != -1) continue;
                            int z = lx[u] + ly[v] - a[u, v];
                            if (z < delta)
                                delta = z;
                        }
                    }

                    for (int i = 0; i < N; i++)
                    {
                        if (px[i] != -1) lx[i] -= delta;
                        if (py[i] != -1) ly[i] += delta;
                    }
                }
            }

            return mx;
        }
    }
}