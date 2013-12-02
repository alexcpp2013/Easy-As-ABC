using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace kiselev1
{
    public class Game : IGame
    {
        private const int count = 8; //количетсво эллементов
        private const int alfCnt = 6; //максимальное значение выборки
        private const int alfCntSpace = alfCnt + 1; //максимальное значение выборки + 1 (not number)
        public const byte notNumber = 0; //значение по умолчанию, не может встречаться в выборке
        public const byte notNumber1 = 7; //значение по умолчанию, не может встречаться в выборке
        public const byte notTheNumber = 8; //такого числа нет
        private const int balance = count - alfCnt; //количетсво эллементов в остатке по строкам и столбцам (пустые ячейки)
        private byte[] allEl = new byte[alfCntSpace] { notNumber, 1, 2, 3, 4, 5, 6 }; //все возможны денные в ячейке матрицы
        private const int numbRows = count; //количество строк
        private const int numbColums = count; //количество колонок
        private const byte howMuchNumb = 1; //сколько раз может повторяться каждая цифра в строке или столбце
        private int yes = 0; //флаг нахождения решения
        public int RC = numbRows * numbColums; //размер матрицы
        public Tuple<byte, string> flagGL; //временный флаг для ошибок
        public int K = -1; //переменная для контроля принадлежности элемента строке
        public int NNN = 0; //переменная для контроля количества пробелов в строке
        public byte[] array = new byte[alfCntSpace];
        public byte[] time = new byte[numbColums];
        public int YYY = 3000000; //остановка по количетсву итераций
        public int nnn = 0; //количетсво решений

        //public System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\WriteLines2.txt");

        private Error err = new Error();

        public int hmN
        {
            get
            {
                return howMuchNumb;
            }
        }

        public int alfC
        {
            get
            {
                return alfCnt;
            }
        }

        public int cnt
        {
            get
            {
                return count;
            }
        }

        public int bal
        {
            get
            {
                return balance;
            }
        }

        public int alfSpace
        {
            get
            {
                return alfCntSpace;
            }
        }

        public int nRows
        {
            get
            {
                return numbRows;
            }
        }

        public int nColms
        {
            get
            {
                return numbColums;
            }
        }

        public byte notN
        {
            //обвертка для notNumber
            get
            {
                return notNumber;
            }
        }

        public byte notN1
        {
            //обвертка для notNumber
            get
            {
                return notNumber1;
            }
        }

        public bool IsNotN(int x)
        {
            if (x == notNumber)
                return true;
            else
                return false;
        }

        public bool IsNumb(int x)
        {
            return !IsNotN(x);
        }

        public class Restrictions
        {
            public byte[] left = new byte[numbRows]; //вектор входных ограничений - левый
            public byte[] right = new byte[numbRows]; //вектор входных ограничений - правый
            public byte[] top = new byte[numbColums]; //вектор входных ограничений - верхний
            public byte[] bottom = new byte[numbColums]; //вектор входных ограничений - нижний
        }

        public class Log
        {
            public System.IO.StreamWriter file;

            public void init()
            {
                file = new System.IO.StreamWriter(@"C:\WriteLines2.txt");
            }

            public void writeNewLine()
            {
                file.Write("\n");
            }

            public void writeTimeData()
            {
                file.WriteLine("hi");
            }

            public void writeArray(int nRows, int nColms, byte[] timeArray)
            {
                for (int h = 0; h < nRows * nColms; ++h)
                    file.Write(timeArray[h].ToString() + " ");
            }

            public void writeFind()
            {
                file.Write(" !!!");
            }

            public void close()
            {
                file.Close();
            }
        }

        public Restrictions restrictions = new Restrictions();
        private Rules rules = new Rules();

        public class Test
        {
            public void init0(byte[] left, byte[] right, byte[] top, byte[] bottom)
            {
                left[0] = 1; left[1] = 1; left[2] = 2; left[3] = 3;
                left[4] = 4; left[5] = 5; left[6] = 6; left[7] = 0;

                right[0] = 2; right[1] = 3; right[2] = 1; right[3] = 4;
                right[4] = 5; right[5] = 6;  right[6] = 1; right[7] = 0;

                top[0] = 1; top[1] = 1; top[2] = 2; top[3] = 3;
                top[4] = 4; top[5] = 5; top[6] = 6; top[7] = 0;

                bottom[0] = 2; bottom[1] = 3; bottom[2] = 1; bottom[3] = 4; 
                bottom[4] = 5; bottom[5] = 6; bottom[6] = 1; bottom[7] = 0;
            }

            public void init1(List<byte>[,] arr, int nRows, int nColms)
            {
                for (int i = 0; i < nRows; ++i)
                    for (int j = 0; j < nColms; ++j)
                    {
                        arr[i, j].Clear();
                        arr[i, j].Add(1);
                    }
            }

            public void init2(List<byte>[,] arr, int nRows, int nColms)
            {
                byte[] tt = new byte[]{1,2,3,4,5,6,0,0,
                                     0,1,2,3,4,5,6,0,
                                     0,0,1,2,3,4,5,6,
                                     6,0,0,1,2,3,4,5,
                                     5,6,0,0,1,2,3,4,
                                     4,5,6,0,0,1,2,3,
                                     3,4,5,6,0,0,1,2,
                                     2,3,4,5,6,0,0,1};
                for (int i = 0; i < nRows; ++i)
                    for (int j = 0; j < nColms; ++j)
                    {
                        arr[i, j].Clear();
                        arr[i, j].Add(tt[j + i * nRows]);
                    }
            }

            public void init3(byte[] left, byte[] right, byte[] top, byte[] bottom)
            {
                left[0] = 1; left[1] = 1; left[2] = 1; left[3] = 6;
                left[4] = 5; left[5] = 4; left[6] = 3; left[7] = 2;

                right[0] = 6; right[1] = 6; right[2] = 6; right[3] = 5;
                right[4] = 4; right[5] = 3; right[6] = 2; right[7] = 1;

                top[0] = 1; top[1] = 2; top[2] = 3; top[3] = 4;
                top[4] = 5; top[5] = 6; top[6] = 6; top[7] = 6;

                bottom[0] = 2; bottom[1] = 3; bottom[2] = 4; bottom[3] = 5;
                bottom[4] = 6; bottom[5] = 1; bottom[6] = 1; bottom[7] = 1;
            }

            public void initTest1(byte[] left, byte[] right, byte[] top, byte[] bottom)
            {
                left[0] = 0; left[1] = 4; left[2] = 3; left[3] = 6;
                left[4] = 1; left[5] = 0; left[6] = 5; left[7] = 0;

                right[0] = 0; right[1] = 6; right[2] = 5; right[3] = 0;
                right[4] = 5; right[5] = 4; right[6] = 3; right[7] = 0;

                top[0] = 0; top[1] = 1; top[2] = 6; top[3] = 2;
                top[4] = 3; top[5] = 2; top[6] = 0; top[7] = 0;

                bottom[0] = 1; bottom[1] = 3; bottom[2] = 5; bottom[3] = 4;
                bottom[4] = 2; bottom[5] = 3; bottom[6] = 6; bottom[7] = 6;
            }

            public void initTest0(List<byte>[,] arr, int nRows, int nColms, byte[] left, byte[] right, byte[] top, byte[] bottom)
            {
                left[0] = 0; left[1] = 4; left[2] = 3; left[3] = 6;
                left[4] = 1; left[5] = 0; left[6] = 5; left[7] = 0;

                right[0] = 0; right[1] = 6; right[2] = 5; right[3] = 0;
                right[4] = 5; right[5] = 4; right[6] = 3; right[7] = 0;

                top[0] = 0; top[1] = 1; top[2] = 6; top[3] = 2;
                top[4] = 3; top[5] = 2; top[6] = 0; top[7] = 0;

                bottom[0] = 1; bottom[1] = 3; bottom[2] = 5; bottom[3] = 4;
                bottom[4] = 2; bottom[5] = 3; bottom[6] = 6; bottom[7] = 6;

                byte[] tt = new byte[]{5,0,6,0,3,2,4,1,
                                       4,1,3,2,5,6,0,0,
                                       3,2,4,6,0,1,5,0,
                                       6,4,0,0,1,5,3,2,
                                       0,0,1,3,6,4,2,5,
                                       2,6,0,5,0,3,1,4,
                                       0,5,2,1,4,0,6,3,
                                       1,3,5,4,2,0,0,6};
                for (int i = 0; i < nRows; ++i)
                    for (int j = 0; j < nColms; ++j)
                    {
                        arr[i, j].Clear();
                        arr[i, j].Add(tt[j + i * nRows]);
                    }
            }

            public void initTest02(List<byte>[,] arr, int nRows, int nColms, byte[] left, byte[] right, byte[] top, byte[] bottom)
            {
                left[0] = 0; left[1] = 4; left[2] = 3; left[3] = 6;
                left[4] = 1; left[5] = 0; left[6] = 5; left[7] = 0;

                right[0] = 0; right[1] = 6; right[2] = 5; right[3] = 0;
                right[4] = 5; right[5] = 4; right[6] = 3; right[7] = 0;

                top[0] = 0; top[1] = 1; top[2] = 6; top[3] = 2;
                top[4] = 3; top[5] = 2; top[6] = 0; top[7] = 0;

                bottom[0] = 1; bottom[1] = 3; bottom[2] = 5; bottom[3] = 4;
                bottom[4] = 2; bottom[5] = 3; bottom[6] = 6; bottom[7] = 6;

                byte[] tt = new byte[]{5,0,6,0,3,2,4,1,
                                       4,1,4,2,5,6,0,0,
                                       3,2,4,6,0,1,5,0,
                                       6,4,0,0,1,5,3,2,
                                       0,0,1,3,6,4,2,5,
                                       2,6,0,5,0,3,1,4,
                                       0,5,2,1,4,0,6,3,
                                       1,3,5,4,2,0,0,6};
                for (int i = 0; i < nRows; ++i) //[1, 2] = 3
                    for (int j = 0; j < nColms; ++j)
                    {
                        arr[i, j].Clear();
                        arr[i, j].Add(tt[j + i * nRows]);
                    }
                arr[1, 2].Add(3);
                arr[1, 2].Add(6);
            }
        }

        public Test test = new Test();

        public Log log = new Log();

        public List<byte>[,] arr = new List<byte>[numbRows, numbColums]; //матрица решения
        public List<byte[]> timeAllCombs = new List<byte[]>(); //все комбинации из 8 цифр в массиве на 8 еллментов
        private byte[,] timeArray = new byte[numbRows, numbColums]; //временный массив значений решения
        private int[] timeArrayRows = new int[numbColums]; //временный массив значений решения массива индексов
        private byte[,] theResolve = new byte[numbRows, numbColums]; //временный массив значений решения
        private byte[] theRow = new byte[numbRows * numbColums]; //временная строка для проверки
        public byte[] fl = new byte[numbColums]; //временный массив для для строк и их проверки
        public List<int>[] rowsArr = new List<int>[numbColums]; //Возмоные варианты для каждой строки

        class comp : IEqualityComparer<byte[]>
        {
            public bool Equals(byte[] x, byte[] y)
            {
                for (int i = 0; i < x.Length; ++i)
                    if (x[i] != y[i])
                        return false;
                return true;
            }
            public int GetHashCode(byte[] x)
            {
                return 0;
            }
        }

        //singleton
        protected Game()
        {
            for (int i = 0; i < numbRows; ++i)
                for (int j = 0; j < numbColums; ++j)
                {
                    arr[i, j] = new List<byte>(alfCntSpace);
                }

            initArrays();
        }

        private sealed class TaskCreator
        {
            private static readonly Game instance = new Game();

            public static Game Instance
            {
                get
                {
                    return instance;
                }
            }
        }

        public static Game Instance
        {
            get
            {
                return TaskCreator.Instance;
            }
        }

        public override void clearArrays()
        {
            //очистка
            initArrays();
        }

        public void initNotAll()
        {
            for (int i = 0; i < numbRows; ++i)
                for (int j = 0; j < numbColums; ++j)
                {
                    arr[i, j].Clear();
                    for (int k = 0; k < alfCntSpace; ++k)
                    {
                        arr[i, j].Add(allEl[k]);
                    }
                }

            //timeAllCombs.Clear();

            for (int i = 0; i < rowsArr.Length; ++i)
                if (rowsArr[i] != null)
                    rowsArr[i].Clear();

            for (int i = 0; i < nRows; ++i)
                for (int j = 0; j < nColms; ++j)
                    timeArray[i, j] = notN;

            for (int i = 0; i < nRows; ++i)
                for (int j = 0; j < nColms; ++j)
                    theResolve[i, j] = notN;

            for (int i = 0; i < nRows; ++i)
                theRow[i] = notN;
            for (int i = 0; i < alfCntSpace; ++i)
                array[i] = notN;

            yes = 0;
        }

        public override void initArrays()
        {
            //инициализация данными по умолчанию
            for (int i = 0; i < numbRows; ++i)
                for (int j = 0; j < numbColums; ++j)
                {
                    arr[i, j].Clear();
                    for (int k = 0; k < alfCntSpace; ++k)
                    {
                        arr[i, j].Add(allEl[k]);
                    }
                }

            timeAllCombs.Clear();

            for (int i = 0; i < rowsArr.Length; ++i)
                if(rowsArr[i] != null) 
                    rowsArr[i].Clear();

            for (int i = 0; i < numbRows; ++i)
            {
                restrictions.left[i] = notNumber;
            }

            for (int i = 0; i < numbRows; ++i)
            {
                restrictions.right[i] = notNumber;
            }

            for (int i = 0; i < numbColums; ++i)
            {
                restrictions.top[i] = notNumber;
            }

            for (int i = 0; i < numbColums; ++i)
            {
                restrictions.bottom[i] = notNumber;
            }

            for (int i = 0; i < nRows; ++i)
                for (int j = 0; j < nColms; ++j)
                    timeArray[i, j] = notN;

            for (int i = 0; i < nRows; ++i)
                for (int j = 0; j < nColms; ++j )
                    theResolve[i, j] = notN;

            for (int i = 0; i < nRows; ++i)
                theRow[i] = notN;
            for (int i = 0; i < alfCntSpace; ++i)
                array[i] = notN;
        }

        public void swap(byte a, byte b)
        {
            byte t = time[a];
            time[a] = time[b];
            time[b] = t;
        }

        public void generate(byte index)
        {
            if (index == time.Length)
            {
                byte[] y = new byte[nColms];
                for (int i = 0; i < nColms; ++i)
                {
                    y[i] = time[i];
                }
                timeAllCombs.Add(y);
            }
            else
            {
                for(byte j = index; j < time.Length; ++j)
                {
                    swap(index, j);
                    generate((byte)(index + 1));
                    swap(index, j);
                }
            }
        }
        
        public void timeData()
        {        
            for (byte i = 0; i < nColms; ++i)
                time[i] = i;

            generate((byte)0);

            //for (int j = 0; j < timeAllCombs.Count; ++j)
            //{
            //    for (int i = 0; i < nColms; ++i)
            //        file.Write(timeAllCombs[j][i].ToString() + " ");
            //    file.Write("\n");
            //}
            //file.Write("\n\n\n");
        }

        public override Tuple<byte, string> doneAlgorithmTask()
        {
            //основной алгоритм
            //нужен сугубо для последовательного вызова функций-фаз
            //обеспечивает логику восприятия
            Tuple<byte, string> flag;
            rules.init(this);

            initNotAll();

            //провреим является ли матрица чатсным случаем: 1 на 1
            flag = rules.rule00(this, err);
            if (flag.Item1 == err.err00.Item1)
                return flag;
            if (flag.Item1 == err.err001.Item1)
                return flag;

            //возможно стоит возвращать сложную сумму ошибок, по которой можно понять какая комбинация ошибок сработала
            flag = rules.rules0(this, err);
            if (flag.Item1 != err.err0.Item1)
            {
                return flag;
            }

            //Для тех кому нужно позволить пройти уничтожение ненужных цифр
            //test.init0(restrictions.left, restrictions.right, restrictions.top, restrictions.bottom);
            //test.init1(arr, nRows, nColms);
            //test.init2(arr, nRows, nColms);
            //test.initTest1(restrictions.left, restrictions.right, restrictions.top, restrictions.bottom);
            //test.initTest0(arr, nRows, nColms, restrictions.left, restrictions.right, restrictions.top, restrictions.bottom);
            //test.initTest02(arr, nRows, nColms, restrictions.left, restrictions.right, restrictions.top, restrictions.bottom);
            //test.init3(restrictions.left, restrictions.right, restrictions.top, restrictions.bottom);

            rules.rules1(this);

            //Для тех кому не нужно позволять проходить уничтожение ненужных цифр
            //test.init0(restrictions.left, restrictions.right, restrictions.top, restrictions.bottom);
            //test.init1(arr, nRows, nColms);
            //test.init2(arr, nRows, nColms);
            //test.initTest1(restrictions.left, restrictions.right, restrictions.top, restrictions.bottom);
            //test.initTest0(arr, nRows, nColms, restrictions.left, restrictions.right, restrictions.top, restrictions.bottom);
            //test.initTest02(arr, nRows, nColms, restrictions.left, restrictions.right, restrictions.top, restrictions.bottom);
            //test.init3(restrictions.left, restrictions.right, restrictions.top, restrictions.bottom);

            //log.init();

            timeData();

            makeRows();

            //file.Close();

            for (int i = 0; i < nRows; ++i)
            {
                if (rowsArr[i].Count == 0)
                    return err.errcolms;
            }

            try
            {
                ruleMakeTree();
            }
            catch (Exception e)
            {
                ;
            }

            //file.Close();

            if (yes == 0)
            {
                return err.errdeftime;
            }
            if (yes > 0)
            {
                for (int i = 0; i < nRows; ++i)
                {
                    for (int j = 0; j < nColms; ++j)
                    {
                        arr[i, j].Clear();
                        arr[i, j].Add(theResolve[i, j]);
                    }
                }
            }

            return err.err0;
        }

        void makeRows()
        {
            for (int i = 0; i < timeAllCombs.Count; ++i)
                for (int j = 0; j < nColms; ++j)
                    if (timeAllCombs[i][j] == notNumber1)
                        timeAllCombs[i][j] = notNumber;

            comp c1 = new comp();
            timeAllCombs = timeAllCombs.Distinct(c1).ToList();

            //System.IO.StreamWriter filevv = new System.IO.StreamWriter(@"C:\W.txt");
            //for (int j = 0; j < timeAllCombs.Count; ++j)
            //{
            //    for (int i = 0; i < nColms; ++i)
            //        filevv.Write(timeAllCombs[j][i].ToString() + " ");
            //    filevv.Write("\n");
            //}
            //filevv.Write("\n\n\n");

            //filevv.Close();

            for (int i = 0; i < nRows; ++i)
            {
                rowsArr[i] = new List<int>();
                rules.verifRow(this, i);
            }
        }

        private void ruleMakeTree(byte index = 0)
        {
            if ((index == nRows))
            {
                //Проверить что созданный массив не содержит одинаковых индексов
                //if (timeArrayRows.Distinct().Count() != timeArrayRows.Length)
                //    return;

                //file.Write("\n!!!\n");
                //for (int i = 0; i < nRows; ++i)
                //{
                //    for (int j = 0; j < nColms; ++j)
                //    {
                //        //timeArray[i, j] = timeAllCombs[timeArrayRows[i]][j];
                //        file.Write(timeArray[i, j]);
                //        file.Write(" ");
                //    }
                //    file.Write("\n");
                //}
                //file.Write("\n\n");
                    
                //--YYY;
                if(rules.MakeSure(this, timeArray) == 1) // || yyy == 0
                {
                    ++yes;
                    for (int i = 0; i < nRows; ++i)
                        for (int j = 0; j < nColms; ++j)
                        {
                            theResolve[i, j] = timeArray[i, j];
                        }
                    //++nnn
                    throw new Exception(); //если не делать выход то можно будет подсчитать количетсво решений, если их более одного
                }
                return;
            }
            if (index < RC)
            {
                for (int j = 0; j < rowsArr[index].Count; ++j)//for (int j = rowsArr[index].Count - 1; j >= 0; --j)
                {

                    timeArrayRows[index] = rowsArr[index][j];

                    //Проверка что это не такая же строка
                    int[] f = new int[index + 1];
                    for (int t = 0; t <= index; ++t)
                        f[t] = timeArrayRows[t];
                    if (f.Distinct().Count() != f.Length)
                        continue;

                    //заполним текущую строку временной матрицы
                    for (int j1 = 0; j1 < nColms; ++j1)
                    {
                        timeArray[index, j1] = timeAllCombs[timeArrayRows[index]][j1];
                    }

                    /*----Доп проверки для матрицы-----*/
                    //количетсов пробелов в столбцах не более bal
                    int flag0 = 0;
                    int flagN = 0;

                    for (int y = 0; y < nColms; ++y)
                    {
                        for (int x = 0; x <= index; ++x)
                            if (timeArray[x, y] == notN)
                            {
                                ++flagN;
                                if (flagN > bal)
                                {
                                    flag0 = 1;
                                    break;
                                }
                            }
                        if (flag0 == 1)
                            break;
                        flagN = 0;
                    }
                    if (flag0 == 1)
                        continue;

                    //Первая цифра сверху - ограничивающая
                    flag0 = 0;
                    if (index == bal + 1)
                    {
                        for (int x = 0; x < nColms; ++x)
                        {
                            if (restrictions.top[x] == notN)
                                continue;
                            
                            //file.WriteLine(x);
                            for (int y = 0; y <= index; ++y)
                            {
                                //file.WriteLine(timeAllCombs[timeArrayRows[y]][x]);
                                //file.Write(" ");
                                //file.Write(restrictions.top[x]);
                                //file.Write("\n");
                                if ((timeArray[y, x] != notN) &&
                                    (timeArray[y, x] != restrictions.top[x]))
                                {
                                    flag0 = 1;
                                    break;
                                }
                                if ((timeArray[y, x] != notN) &&
                                    (timeArray[y, x] == restrictions.top[x]))
                                {
                                    break;
                                }
                            }
                            if (flag0 == 1)
                                break;
                        }
                        if (flag0 == 1)
                            continue;
                    }

                    //проврека что под цифрой в одной строке не стоит такая же цифра в другой
                    //file.Write("\n");
                    //file.Write(index);
                    //file.Write(" -> ");
                    //for (int yu = 0; yu < nColms; ++yu)
                    //{
                    //    file.Write(timeArray[index, yu]);
                    //    file.Write(" ");
                    //}

                    flag0 = 0;
                    for (int y = 0; y < nColms; ++y) //index <= nRows
                    {
                        for (int x = 0; x <= index; ++x)
                        {
                            for (int x0 = x + 1; x0 <= index; ++x0)
                            {
                                if ((timeArray[x, y] == timeArray[x0, y])
                                    && (timeArray[x, y] != notN))
                                {
                                    flag0 = 1;
                                    break;
                                }
                            }
                            if (flag0 == 1)
                                break;
                        }
                        if (flag0 == 1)
                            break;
                    }
                    if (flag0 == 1)
                        continue;
                    /*--------------------*/

                    ruleMakeTree((byte)(index + 1));
                }
            }

            return;
        }

        public Form1 Form1
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        internal Rules Rules
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
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

        public Form1 Form11
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        internal Rules Rules1
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
    }
}
