using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumberCalculator.Models
{
        internal class RomanNumber : ICloneable, IComparable
        {
                private ushort _number;
                private string _romanNumber;

                public RomanNumber(ushort number)
                {
                        if (number <= 0) throw new RomanNumberException();
                        _number = number;
                        _romanNumber = numberToRoman(number);
                }

                public RomanNumber(string number)
                {
                        ushort temp_number = romanToNumber(number);
                        if (temp_number <= 0) throw new RomanNumberException();
                        _number = temp_number;
                        _romanNumber = number;
                }

                private static string numberToRoman(ushort n)
                {
                        char[] symb = new char[] { 'M', 'D', 'C', 'L', 'X', 'V' };
                        char[] symb2 = new char[] { 'C', 'X', 'I' };
                        string res = "";
                        for (int i = 0; i < n / 1000; ++i) res += 'M';
                        int t = n % 1000;
                        for (int i = 100, k = 0; i > 0; i /= 10, ++k)
                        {
                                int x = t / i;
                                if (x == 9) res = res + symb2[k] + symb[k * 2];
                                else if (x >= 5)
                                {
                                        res += symb[1 + k * 2];
                                        for (int j = 0; j < x - 5; ++j) res += symb2[k];
                                }
                                else
                                {
                                        if (x == 4) res = res + symb2[k] + symb[1 + k * 2];
                                        else
                                        {
                                                for (int j = 0; j < x; ++j) res += symb2[k];
                                        }
                                }
                                t = t % i;
                        }
                        return res;
                }

                private static ushort romanToNumber(string romanNumber)
                {
                        Dictionary<char, ushort> match = new Dictionary<char, ushort>
                        {
                                { 'I', 1 },
                                { 'V', 5 },
                                { 'X', 10 },
                                { 'L', 50 },
                                { 'C', 100 },
                                { 'D', 500 },
                                { 'M', 1000 }
                        };
                        if (romanNumber.Length == 1)
                                return match[romanNumber[0]];

                        ushort result = 0;
                        int i = 0;

                        while (i < romanNumber.Length - 1)
                        {
                                if (match[romanNumber[i]] < match[romanNumber[i + 1]])
                                {
                                        result += (ushort)(match[romanNumber[i + 1]] - match[romanNumber[i]]);
                                        i += 2;
                                }
                                else
                                {
                                        result += match[romanNumber[i]];
                                        i++;
                                        if (i == romanNumber.Length - 1)
                                                result += match[romanNumber[i]];
                                }
                        }
                        return result;
                }

                public static RomanNumber Add(RomanNumber? romanNumber1, RomanNumber? romanNumber2)
                {
                        if (romanNumber1._number + romanNumber2._number > 3999) throw new RomanNumberException();
                        return new RomanNumber((ushort)(romanNumber1._number + romanNumber2._number));
                }

                public static RomanNumber Sub(RomanNumber? romanNumber1, RomanNumber? romanNumber2)
                {
                        if (romanNumber1._number <= romanNumber2._number) throw new RomanNumberException();
                        return new RomanNumber((ushort)(romanNumber1._number - romanNumber2._number));
                }

                public static RomanNumber Mul(RomanNumber? romanNumber1, RomanNumber? romanNumber2)
                {
                        if (romanNumber1._number * romanNumber2._number > 3999) throw new RomanNumberException();
                        return new RomanNumber((ushort)(romanNumber1._number * romanNumber2._number));
                }

                public static RomanNumber Div(RomanNumber? romanNumber1, RomanNumber? romanNumber2)
                {
                        if (romanNumber2._number == 0 || ((ushort)(romanNumber1._number / romanNumber2._number)) == 0) throw new RomanNumberException();
                        return new RomanNumber((ushort)(romanNumber1._number / romanNumber2._number));
                }

                public object Clone()
                {
                        return new RomanNumber(_number);
                }

                public int CompareTo(object? obj)
                {
                        RomanNumber another = obj as RomanNumber;
                        if (another == null) throw new ArgumentException("Bad object!");
                        return _number.CompareTo(another._number);
                }

                public override string ToString()
                {
                        return _romanNumber;
                }
                public ushort ToUInt16()
                {
                        return _number;
                }
        }
}
