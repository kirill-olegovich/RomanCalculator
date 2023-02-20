using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumberCalculator.Models
{
        internal class RomanNumberExtend : RomanNumber
        {
                public RomanNumberExtend(ushort number) : base(number)
                {
                }

                public RomanNumberExtend(string number) : base(number)
                {
                }

                public static RomanNumber operator +(RomanNumberExtend? romanNumber1, RomanNumberExtend? romanNumber2)
                {
                        return Add(romanNumber1, romanNumber2);
                }

                public static RomanNumber operator -(RomanNumberExtend? romanNumber1, RomanNumberExtend? romanNumber2)
                {
                        return Sub(romanNumber1, romanNumber2);
                }

                public static RomanNumber operator *(RomanNumberExtend? romanNumber1, RomanNumberExtend? romanNumber2)
                {
                        return Mul(romanNumber1, romanNumber2);
                }

                public static RomanNumber operator /(RomanNumberExtend? romanNumber1, RomanNumberExtend? romanNumber2)
                {
                        return Div(romanNumber1, romanNumber2);
                }
        }
}
