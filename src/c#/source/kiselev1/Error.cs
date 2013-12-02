using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace kiselev1
{
    class Error
    {
        public Tuple<byte, string> errGood = new Tuple<byte, string>(155, "Решение задачи завершено.");
        public Tuple<byte, string> errBad = new Tuple<byte, string>(152, "Решение не найдено.");
        public Tuple<byte, string> err00 = new Tuple<byte, string>(100, "Тривиальное решение: 1 на 1.");
        public Tuple<byte, string> err001 = new Tuple<byte, string>(101, "Противоположные цифры - не одинаковые, для 1 на 1.");
        public Tuple<byte, string> err0 = new Tuple<byte, string>(0, "Нет ошибок.");
        public Tuple<byte, string> err01 = new Tuple<byte, string>(1, "Противоположные цифры - одинаковые.");
        public Tuple<byte, string> err02 = new Tuple<byte, string>(2, "Размер алфавита больше размера матрицы.");
        public Tuple<byte, string> err03 = new Tuple<byte, string>(3, "Количество повторяюзихся цифр превышает количество возможных пустых мест + 1.");
        public Tuple<byte, string> err04 = new Tuple<byte, string>(4, "Количество пар повторяющихся цифр превышает количество возможных пустых мест.");
        public Tuple<byte, string> err05 = new Tuple<byte, string>(5, "Крайняя цифра встречается в перпендикулярном массиве более N раз.");
        public Tuple<byte, string> makesure = new Tuple<byte, string>(200, "Не решение.");
        public Tuple<byte, string> makesure2 = new Tuple<byte, string>(202, "Первая цифра - не ограничивающая.");
        public Tuple<byte, string> makesure3 = new Tuple<byte, string>(203, "Более N пробелов.");
        public Tuple<byte, string> makesure4 = new Tuple<byte, string>(204, "Цифры повторяются.");
        public Tuple<byte, string> errNot = new Tuple<byte, string>(150, "решения не существует.");
        public Tuple<byte, string> errdeftime = new Tuple<byte, string>(111, "Решение не существует.");
        public Tuple<byte, string> errcolms = new Tuple<byte, string>(112, "Решение/ние не существует.");
    }
}
