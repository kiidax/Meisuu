﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meisuu
{
    public class JapaneseKansuuji
    {
        private const string SuujiChars = "一二三四五六七八九";
        private const string SmallKuraiChars = "十百千";
        private static readonly ulong[] Pow10Values;
        private static readonly ulong[] Pow10000Values;
        private const string DaijiSuujiChars = "壱弐参";
        private const string DaijiSmallKuraiChars = "拾";
        private const string LargeKuraiChars = "万億兆京垓𥝱";
        private const char ZeroChar = '零';

        static JapaneseKansuuji()
        {
            Pow10Values = new ulong[3];
            ulong v = 1;
            for (ulong i = 0; i < (ulong)Pow10Values.Length; i++)
            {
                v *= 10;
                Pow10Values[i] = v;
            }
            Pow10000Values = new ulong[16];
            v = 1;
            for (ulong i = 0; i < (ulong)Pow10000Values.Length; i++)
            {
                v *= 10000;
                Pow10000Values[i] = v;
            }
        }

        public static bool TryParse(string s, out ulong result)
        {
            int endIndex;
            if (!TryParse(s, 0, out endIndex, out result)) return false;
            if (endIndex != s.Length) return false;
            return true;
        }

        public static bool TryParse(string s, ulong style, out int endIndex, out ulong result)
        {
            endIndex = 0;
            result = 0;
            if (s.Length > 0 && s[0] == ZeroChar)
            {
                endIndex = 1;
                return true;
            }
            ulong underKuraiValue = 0;
            ulong smallKuraiValue = 0;
            ulong largeKuraiValue = 0;
            int i;
            for (i = 0; i < s.Length; i++)
            {
                char ch = s[i];
                int index = SuujiChars.IndexOf(ch);
                if (index != -1)
                {
                    if (underKuraiValue != 0) return false; // We have already had a suuji char.
                    underKuraiValue = (ulong) index + 1;
                    continue;
                }
                index = SmallKuraiChars.IndexOf(ch);
                if (index != -1)
                {
                    if (underKuraiValue == 0) underKuraiValue = 1; // If we haven't have a suuji char, then it is one.
                    if (smallKuraiValue != 0 && smallKuraiValue < Pow10Values[index]) return false; // We already have bigger small-kurai.
                    smallKuraiValue += Pow10Values[index] * underKuraiValue;
                    underKuraiValue = 0;
                    continue;
                }
                index = LargeKuraiChars.IndexOf(ch);
                if (index != -1)
                {
                    smallKuraiValue += underKuraiValue;
                    underKuraiValue = 0;
                    if (smallKuraiValue == 0) return false;
                    largeKuraiValue += Pow10000Values[index] * smallKuraiValue;
                    smallKuraiValue = 0;
                    continue;
                }
                break;
            }

            if (i == 0) return false;
            smallKuraiValue += underKuraiValue;
            largeKuraiValue += smallKuraiValue;
            result = largeKuraiValue;
            endIndex = i;
            return true;
        }
    }
}