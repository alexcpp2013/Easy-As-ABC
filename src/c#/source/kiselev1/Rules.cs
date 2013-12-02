using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace kiselev1
{
    class Rules
    {
        private byte tt = 0;

        public Rules()
        {
            //не делал вложенным классом, что бы уменьшить количетсво кода в Game
            //из-за этого приходится передавать this
            ;
        }

        internal Error Error
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        internal Error Error1
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public void init(Game ourGame)
        {
            ;
        }

        public int verifRow(Game ourGame, int i0)
        {
            //---проверка что первая цифра в строке - ограничивающая + меньше ourGame.bal + 1 пробелов подряд----
            byte left0 = ourGame.restrictions.left[i0];
            byte right0 = ourGame.restrictions.right[i0];
            int t1 = ourGame.nColms - 1 - (ourGame.bal + 1);
            int t0 = ourGame.bal + 1;
            int y = 0;

            for (int h = 0; h < ourGame.timeAllCombs.Count; ++h)
            {
                try
                {
                    if (left0 != ourGame.notN)
                    {
                        y = 0;
                        for (int i = 0; i < t0; ++i)
                        {
                            if ((ourGame.timeAllCombs[h][i] != ourGame.notN) && ourGame.timeAllCombs[h][i] == left0)
                            {
                                y = 1;
                                break;
                            }
                            if ((ourGame.timeAllCombs[h][i] != ourGame.notN) && ourGame.timeAllCombs[h][i] != left0)
                                throw new Exception();
                        }
                        if (y != 1)
                            throw new Exception();
                    }

                    if (right0 != ourGame.notN)
                    {
                        y = 0;
                        for (int i = ourGame.nColms - 1; i > t1; --i)
                        {
                            if ((ourGame.timeAllCombs[h][i] != ourGame.notN) && ourGame.timeAllCombs[h][i] == right0)
                            {
                                y = 1;
                                break;
                            }
                            if ((ourGame.timeAllCombs[h][i] != ourGame.notN) && ourGame.timeAllCombs[h][i] != right0)
                                throw new Exception();
                        }
                        if (y != 1)
                            throw new Exception();
                    }

                    ourGame.rowsArr[i0].Add(h);
                }
                catch (Exception e)
                {
                    continue;
                }
            }


            //System.IO.StreamWriter file0 = new System.IO.StreamWriter(@"C:\t_" + i0.ToString() + "0" + ".txt");
            //for (int i = 0; i < ourGame.rowsArr[i0].Count; ++i)
            //    file0.Write(ourGame.rowsArr[i0][i] + "\n");
            //file0.Close();


            //Проверка что каждая цифра может находится в данной позиции
            List<int> ttt = new List<int>();
            for (int i = 0; i < ourGame.rowsArr[i0].Count; ++i)
            {
                for (int j = 0; j < ourGame.timeAllCombs[ourGame.rowsArr[i0][i]].Length; ++j)
                {
                    tt = ourGame.timeAllCombs[ourGame.rowsArr[i0][i]][j];
                    if (ourGame.arr[i0, j].FindIndex(u => u == tt) < 0)
                    {
                        ttt.Add(ourGame.rowsArr[i0][i]);
                        break;
                    }
                }
            }


            //System.IO.StreamWriter file1 = new System.IO.StreamWriter(@"C:\t_" + i0.ToString() + "1" + ".txt");
            //for (int i = 0; i < ourGame.rowsArr[i0].Count; ++i)
            //    file1.Write(ourGame.rowsArr[i0][i] + " ");
            //file1.Close();

            //System.IO.StreamWriter filettt = new System.IO.StreamWriter(@"C:\ttt_" + i0.ToString().ToString() + ".txt");
            //for (int i = 0; i < ttt.Count; ++i)
            //    filettt.Write(ttt[i] + "\n");
            //filettt.Close();


            for (int i = 0; i < ttt.Count; ++i)
                ourGame.rowsArr[i0].Remove(ttt[i]);


            //System.IO.StreamWriter file2 = new System.IO.StreamWriter(@"C:\t_" + i0.ToString() + "2" + ".txt");
            //for (int i = 0; i < ourGame.rowsArr[i0].Count; ++i)
            //    file2.Write(ourGame.rowsArr[i0][i] + "\n");
            //file2.Close();


            return 0;
        }

        public int IsNoEqualElls(int[] a, int h = 1)
        {
            //int[] fl = new int[a.Length];
            //for (int j = 0; j < fl.Length; ++j)
            //{
            //    fl[j] = a[j];
            //}
            //Array.Sort(fl);
            //int n = h;
            //for (int k = 0; k < (fl.Length - 1); ++k)
            //{
            //    if ((fl[k] == fl[k + 1]))
            //    {
            //        ++n;
            //        if (n > h)
            //            return 0;
            //    }
            //}
            
            if(a.Distinct().Count() != a.Length)
                return 0;

            return 1;
        }

        public Tuple<byte, string> rules0(Game ourGame, Error err)
        {
            //нет ли взаимоисключающих данных в управляющих векторах 
            Tuple<byte, string> e = rule01(ourGame, err);
            if (e.Item1 != err.err0.Item1)
                return e;
            e = rule02(ourGame, err);
            if (e.Item1 != err.err0.Item1)
                return e;
            e = rule03(ourGame, err);
            if (e.Item1 != err.err0.Item1)
                return e;
            e = rule04(ourGame, err);
            if (e.Item1 != err.err0.Item1)
                return e;
            e = rule05(ourGame, err);
            if (e.Item1 != err.err0.Item1)
                return e;
            return err.err0;
        }

        public void rules1(Game ourGame)
        {
            rule11(ourGame);

            rule12(ourGame);

            rule13(ourGame);

            return;
        }

        public Tuple<byte, string> rule00(Game ourGame, Error err)
        {
            //для матрицы 1 на 1
            if (ourGame.nColms == 1
                && ourGame.nRows == 1
                && (ourGame.restrictions.top[0] == ourGame.restrictions.bottom[0]
                    || ourGame.restrictions.top[0] != ourGame.notN
                    || ourGame.restrictions.bottom[0] != ourGame.notN)
                && (ourGame.restrictions.left[0] == ourGame.restrictions.right[0]
                    || ourGame.restrictions.left[0] != ourGame.notN
                    || ourGame.restrictions.right[0] != ourGame.notN)
                )
                return err.err00;
            if (ourGame.nColms == 1
                && ourGame.nRows == 1
                && ourGame.restrictions.top[0] != ourGame.restrictions.bottom[0]
                    && (ourGame.restrictions.top[0] != ourGame.notN
                    || ourGame.restrictions.bottom[0] != ourGame.notN)
                && ourGame.restrictions.left[0] != ourGame.restrictions.right[0]
                    && (ourGame.restrictions.left[0] != ourGame.notN
                    || ourGame.restrictions.right[0] != ourGame.notN)
                )
                return err.err001;
            return err.err0;
        }

        private Tuple<byte, string> rule01(Game ourGame, Error err)
        {
            //нет ли взаимоисключающих данных в управляющих векторах 
            for (int i = 0; i < ourGame.nColms; ++i)
                if (ourGame.restrictions.top[i] == ourGame.restrictions.bottom[i] 
                    && ourGame.restrictions.top[i] != ourGame.notN
                    && ourGame.restrictions.bottom[i] != ourGame.notN)
                    return err.err01;
            for (int i = 0; i < ourGame.nRows; ++i)
                if (ourGame.restrictions.left[i] == ourGame.restrictions.right[i]
                    && ourGame.restrictions.left[i] != ourGame.notN
                    && ourGame.restrictions.right[i] != ourGame.notN)
                    return err.err01;
            return err.err0;
        }

        private Tuple<byte, string> rule02(Game ourGame, Error err)
        {
            //размер алфавита должен быть меньше размера матрицы
            if (ourGame.alfC >= ourGame.cnt)
                return err.err02;
            return err.err0;
        }

        private Tuple<byte, string> rule03(Game ourGame, Error err)
        {
            int[] a = new int[ourGame.cnt - 1];
            
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = 0;
            }
            for (int i = 0; i < ourGame.cnt; i++)
            {
                a[ourGame.restrictions.left[i]]++;
                if ((a[ourGame.restrictions.left[i]] > (ourGame.bal + 1)) && ourGame.IsNumb(ourGame.restrictions.left[i]))
                    return err.err03;
            }

            for (int i = 0; i < a.Length; i++)
            {
                a[i] = 0;
            }
            for (int i = 0; i < ourGame.cnt; i++)
            {
                a[ourGame.restrictions.right[i]]++;
                if ((a[ourGame.restrictions.right[i]] > (ourGame.bal + 1)) && ourGame.IsNumb(ourGame.restrictions.right[i]))
                    return err.err03;
            }

            for (int i = 0; i < a.Length; i++)
            {
                a[i] = 0;
            }
            for (int i = 0; i < ourGame.cnt; i++)
            {
                a[ourGame.restrictions.top[i]]++;
                if ((a[ourGame.restrictions.top[i]] > (ourGame.bal + 1)) && ourGame.IsNumb(ourGame.restrictions.top[i]))
                    return err.err03;
            }

            for (int i = 0; i < a.Length; i++)
            {
                a[i] = 0;
            }
            for (int i = 0; i < ourGame.cnt; i++)
            {
                a[ourGame.restrictions.bottom[i]]++;
                if ((a[ourGame.restrictions.bottom[i]] > (ourGame.bal + 1)) && ourGame.IsNumb(ourGame.restrictions.bottom[i]))
                    return err.err03;
            }

            return err.err0;
        }

        private Tuple<byte, string> rule04(Game ourGame, Error err)
        {
            int[] a = new int[ourGame.cnt];
            //лучше было бы загрнать все ограничаения в матрицу [N, ourGame.cnt]

            ourGame.restrictions.left.CopyTo(a, 0);
            Array.Sort(a);
            int n = 0;
            for (int i = 0; i < (a.Length - 1); ++i)
            {
                if ((a[i] == a[i + 1]) && (ourGame.IsNumb(a[i])))
                {
                    ++n;
                    if (n > ourGame.bal)
                        return err.err04;
                }
            }

            ourGame.restrictions.right.CopyTo(a, 0);
            Array.Sort(a);
            n = 0;
            for (int i = 0; i < (a.Length - 1); ++i)
            {
                if ((a[i] == a[i + 1]) && (ourGame.IsNumb(a[i])))
                {
                    ++n;
                    if (n > ourGame.bal)
                        return err.err04;
                }
            }

            ourGame.restrictions.top.CopyTo(a, 0);
            Array.Sort(a);
            n = 0;
            for (int i = 0; i < (a.Length - 1); ++i)
            {
                if ((a[i] == a[i + 1]) && (ourGame.IsNumb(a[i])))
                {
                    ++n;
                    if (n > ourGame.bal)
                        return err.err04;
                }
            }

            ourGame.restrictions.bottom.CopyTo(a, 0);
            Array.Sort(a);
            n = 0;
            for (int i = 0; i < (a.Length - 1); ++i)
            {
                if ((a[i] == a[i + 1]) && (ourGame.IsNumb(a[i])))
                {
                    ++n;
                    if (n > ourGame.bal)
                        return err.err04;
                }
            }

            return err.err0;
        }

        private Tuple<byte, string> rule05(Game ourGame, Error err)
        {
            //нет ли взаимоисключающих данных в управляющих векторах 
            if (ourGame.IsNumb(ourGame.restrictions.top[0]))
            {
                int a = ourGame.restrictions.top[0];
                int n = 0;
                for (int i = 1; i < ourGame.restrictions.left.Length; ++i)
                {
                    if (ourGame.restrictions.left[i] == a)
                        ++n;
                }
                if (n > ourGame.bal)
                    return err.err05;
            }

            if (ourGame.IsNumb(ourGame.restrictions.top[ourGame.restrictions.top.Length - 1]))
            {
                int a = ourGame.restrictions.top[ourGame.restrictions.top.Length - 1];
                int n = 0;
                for (int i = 1; i < ourGame.restrictions.right.Length; ++i)
                {
                    if (ourGame.restrictions.right[i] == a)
                        ++n;
                }
                if (n > ourGame.bal)
                    return err.err05;
            }

            if (ourGame.IsNumb(ourGame.restrictions.left[0]))
            {
                int a = ourGame.restrictions.left[0];
                int n = 0;
                for (int i = 1; i < ourGame.restrictions.top.Length; ++i)
                {
                    if (ourGame.restrictions.top[i] == a)
                        ++n;
                }
                if (n > ourGame.bal)
                    return err.err05;
            }

            if (ourGame.IsNumb(ourGame.restrictions.left[ourGame.restrictions.left.Length - 1]))
            {
                int a = ourGame.restrictions.left[ourGame.restrictions.left.Length - 1];
                int n = 0;
                for (int i = 1; i < ourGame.restrictions.bottom.Length; ++i)
                {
                    if (ourGame.restrictions.bottom[i] == a)
                        ++n;
                }
                if (n > ourGame.bal)
                    return err.err05;
            }

            if (ourGame.IsNumb(ourGame.restrictions.right[0]))
            {
                int a = ourGame.restrictions.right[0];
                int n = 0;
                for (int i = ourGame.restrictions.top.Length - 1 - 1; i > 0; --i)
                {
                    if (ourGame.restrictions.top[i] == a)
                        ++n;
                }
                if (n > ourGame.bal)
                    return err.err05;
            }

            if (ourGame.IsNumb(ourGame.restrictions.right[ourGame.restrictions.right.Length - 1]))
            {
                int a = ourGame.restrictions.right[ourGame.restrictions.right.Length - 1];
                int n = 0;
                for (int i = ourGame.restrictions.bottom.Length - 1 - 1; i > 0; --i)
                {
                    if (ourGame.restrictions.bottom[i] == a)
                        ++n;
                }
                if (n > ourGame.bal)
                    return err.err05;
            }

            if (ourGame.IsNumb(ourGame.restrictions.bottom[0]))
            {
                int a = ourGame.restrictions.bottom[0];
                int n = 0;
                for (int i = ourGame.restrictions.left.Length - 1 - 1; i > 0; --i)
                {
                    if (ourGame.restrictions.left[i] == a)
                        ++n;
                }
                if (n > ourGame.bal)
                    return err.err05;
            }

            if (ourGame.IsNumb(ourGame.restrictions.bottom[ourGame.restrictions.bottom.Length - 1]))
            {
                int a = ourGame.restrictions.bottom[ourGame.restrictions.bottom.Length - 1];
                int n = 0;
                for (int i = ourGame.restrictions.right.Length - 1 - 1; i > 0; --i)
                {
                    if (ourGame.restrictions.right[i] == a)
                        ++n;
                }
                if (n > ourGame.bal)
                    return err.err05;
            }

            return err.err0;
        }

        private void rule11(Game ourGame)
        {
            for (int i = 0; i < ourGame.restrictions.left.Length; ++i)
            {
                for (int j = (ourGame.bal + 2 - 1); j < ourGame.nColms; ++j)
                {
                    if (ourGame.IsNumb(ourGame.restrictions.left[i]))
                    {
                        ourGame.arr[i, j].Remove(ourGame.restrictions.left[i]);
                    }
                }
            }

            for (int i = 0; i < ourGame.restrictions.right.Length; ++i)
            {
                for (int j = ourGame.nColms - 1 - (ourGame.bal + 2 - 1); j >= 0; --j)
                {
                    if (ourGame.IsNumb(ourGame.restrictions.right[i]))
                    {
                        ourGame.arr[i, j].Remove(ourGame.restrictions.right[i]);
                    }
                }
            }

            for (int i = 0; i < ourGame.restrictions.top.Length; ++i)
            {
                for (int j = (ourGame.bal + 2 - 1); j < ourGame.nColms; ++j)
                {
                    if (ourGame.IsNumb(ourGame.restrictions.top[i]))
                    {
                        ourGame.arr[j, i].Remove(ourGame.restrictions.top[i]);
                    }
                }
            }

            for (int i = 0; i < ourGame.restrictions.bottom.Length; ++i)
            {
                for (int j = ourGame.nRows - 1 - (ourGame.bal + 2 - 1); j >= 0; --j)
                {
                    if (ourGame.IsNumb(ourGame.restrictions.bottom[i]))
                    {
                        ourGame.arr[j, i].Remove(ourGame.restrictions.bottom[i]);
                    }
                }
            }

            return;
        }

        private void rule12(Game ourGame)
        {
            for (int i = 0; i < ourGame.restrictions.left.Length; ++i)
            {
                byte a = ourGame.restrictions.left[i];
                if (ourGame.IsNumb(ourGame.restrictions.left[i]))
                {
                    ourGame.arr[i, 0].Clear();
                    ourGame.arr[i, 0].Add(ourGame.notN);
                    ourGame.arr[i, 0].Add(a);
                }
            }

            for (int i = 0; i < ourGame.restrictions.right.Length; ++i)
            {
                byte a = ourGame.restrictions.right[i];
                if (ourGame.IsNumb(ourGame.restrictions.right[i]))
                {
                    ourGame.arr[i, ourGame.nColms - 1].Clear();
                    ourGame.arr[i, ourGame.nColms - 1].Add(ourGame.notN);
                    ourGame.arr[i, ourGame.nColms - 1].Add(a);
                }
            }

            for (int i = 0; i < ourGame.restrictions.top.Length; ++i)
            {
                byte a = ourGame.restrictions.top[i];
                if (ourGame.IsNumb(ourGame.restrictions.top[i]))
                {
                    ourGame.arr[0, i].Clear();
                    ourGame.arr[0, i].Add(ourGame.notN);
                    ourGame.arr[0, i].Add(a);
                }
            }

            for (int i = 0; i < ourGame.restrictions.bottom.Length; ++i)
            {
                byte a = ourGame.restrictions.bottom[i];
                if (ourGame.IsNumb(ourGame.restrictions.bottom[i]))
                {
                    ourGame.arr[ourGame.nRows - 1, i].Clear();
                    ourGame.arr[ourGame.nRows - 1, i].Add(ourGame.notN);
                    ourGame.arr[ourGame.nRows - 1, i].Add(a);
                }
            }

            return;
        }

        private void rule13(Game ourGame)
        {
            int[] a = new int[ourGame.cnt];
            //лучше было бы загрнать все ограничаения в матрицу [N, ourGame.cnt]

            ourGame.restrictions.left.CopyTo(a, 0);
            Array.Sort(a);
            int n = 0;
            for (int i = 0; i < (a.Length - 1); ++i)
            {
                if ((a[i] == a[i + 1]) && (ourGame.IsNumb(a[i])))
                {
                    ++n;
                }
            }
            if (n == ourGame.bal)
            {
                for (int i = 0; i < ourGame.restrictions.left.Length; ++i)
                {
                    int fl = 0;
                    for (int j = 0; j < ourGame.restrictions.left.Length; ++j)
                    {
                        if ((ourGame.restrictions.left[i] == ourGame.restrictions.left[j])
                            && (i != j)
                            && (ourGame.IsNumb(ourGame.restrictions.left[i])))
                            fl = 1;
                    }
                    if (fl == 0)
                        ourGame.arr[i, 0].Remove(ourGame.notN);
                }
            }

            ourGame.restrictions.right.CopyTo(a, 0);
            Array.Sort(a);
            n = 0;
            for (int i = 0; i < (a.Length - 1); ++i)
            {
                if ((a[i] == a[i + 1]) && (ourGame.IsNumb(a[i])))
                {
                    ++n;
                }
            }
            if (n == ourGame.bal)
            {
                for (int i = 0; i < ourGame.restrictions.right.Length; ++i)
                {
                    int fl = 0;
                    for (int j = 0; j < ourGame.restrictions.right.Length; ++j)
                    {
                        if ((ourGame.restrictions.right[i] == ourGame.restrictions.right[j])
                            && (i != j)
                            && (ourGame.IsNumb(ourGame.restrictions.right[i])))
                            fl = 1;
                    }
                    if (fl == 0)
                        ourGame.arr[i, ourGame.nColms - 1].Remove(ourGame.notN);
                }
            }

            ourGame.restrictions.top.CopyTo(a, 0);
            Array.Sort(a);
            n = 0;
            for (int i = 0; i < (a.Length - 1); ++i)
            {
                if ((a[i] == a[i + 1]) && (ourGame.IsNumb(a[i])))
                {
                    ++n;
                }
            }
            if (n == ourGame.bal)
            {
                for (int i = 0; i < ourGame.restrictions.top.Length; ++i)
                {
                    int fl = 0;
                    for (int j = 0; j < ourGame.restrictions.top.Length; ++j)
                    {
                        if ((ourGame.restrictions.top[i] == ourGame.restrictions.top[j])
                            && (i != j)
                            && (ourGame.IsNumb(ourGame.restrictions.top[i])))
                            fl = 1;
                    }
                    if (fl == 0)
                        ourGame.arr[0, i].Remove(ourGame.notN);
                }
            }

            ourGame.restrictions.bottom.CopyTo(a, 0);
            Array.Sort(a);
            n = 0;
            for (int i = 0; i < (a.Length - 1); ++i)
            {
                if ((a[i] == a[i + 1]) && (ourGame.IsNumb(a[i])))
                {
                    ++n;
                }
            }
            if (n == ourGame.bal)
            {
                for (int i = 0; i < ourGame.restrictions.bottom.Length; ++i)
                {
                    int fl = 0;
                    for (int j = 0; j < ourGame.restrictions.bottom.Length; ++j)
                    {
                        if ((ourGame.restrictions.bottom[i] == ourGame.restrictions.bottom[j])
                            && (i != j)
                            && (ourGame.IsNumb(ourGame.restrictions.bottom[i])))
                            fl = 1;
                    }
                    if (fl == 0)
                        ourGame.arr[ourGame.nRows - 1, i].Remove(ourGame.notN);
                }
            }

            return;
        }

        public int MakeSure(Game ourGame, byte[,] timeArray)
        {
            //первая цифра - ограничивающая
            for (int j = 0; j < ourGame.nColms; ++j)
            {
                byte top0 = ourGame.restrictions.top[j];
                byte bottom0 = ourGame.restrictions.bottom[j];
                int t1 = ourGame.nRows - 1 - (ourGame.bal + 1);
                int t0 = ourGame.bal + 1;
                int y = 0;

                //if (top0 != ourGame.notN)
                //{
                //    y = 0;
                //    for (int g = 0; g < t0; ++g)
                //    {
                //        if ((timeArray[g, j] != ourGame.notN) && (timeArray[g, j] == top0))
                //        {
                //            y = 1;
                //            break;
                //        }
                //        if ((timeArray[g, j] != ourGame.notN) && (timeArray[g, j] != top0))
                //            return 0;
                //    }
                //    if (y != 1)
                //        return 0;
                //}

                if (bottom0 != ourGame.notN)
                {
                    y = 0;
                    for (int g = ourGame.nColms - 1; g > t1; --g)
                    {
                        if ((timeArray[g, j] != ourGame.notN) && (timeArray[g, j] == bottom0))
                        {
                            y = 1;
                            break;
                        }
                        if ((timeArray[g, j] != ourGame.notN) && (timeArray[g, j] != bottom0))
                            return 0;
                    }
                    if (y != 1)
                        return 0;
                }

            }

            //не более bal пробелов и каждый еллемент встречает не более 1 раза
            //const int h = 1;
            //int n = h;
            //int[] fl = new int[ourGame.nRows];
            //for (int j = 0; j < ourGame.nColms; ++j)
            //{
            //    for (int i = 0; i < fl.Length; ++i)
            //    {
            //        fl[i] = timeArray[i, j];
            //    }
            //    Array.Sort(fl);
            //    if (fl[0] != 0)
            //        return 0;
            //    if (fl[1] != 0)
            //        return 0;
            //    if (fl[2] == 0)
            //        return 0;
            //    n = h;
            //    for (int k = 2; k < (fl.Length - 1); ++k)
            //    {
            //        if ((fl[k] == fl[k + 1]))
            //        {
            //            ++n;
            //            if (n > h)
            //                return 0;
            //        }
            //    }
            //}
            
            return 1;
        }
    }
}
