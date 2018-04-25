using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Annex.MathExtended.ComplexNumbers
{
    public partial class Complex
    {
        #region Overloaded operators
        /// <summary>
        /// Complex Conjugation
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Complex operator ~(Complex value)
        {
            return new Complex(value.Real, -value.Imaginary);
        }

        /// <summary>
        /// Addition of two complex numbers
        /// </summary>
        /// <param name="first">First parameter - Complex number</param>
        /// <param name="second">Second parameter - Complex number</param>
        /// <returns>Complex number</returns>
        public static Complex operator +(Complex first, Complex second)
        {
            return new Complex(first.Real + second.Real, first.Imaginary + second.Imaginary);
        }

        public static Complex operator +(Complex first, double second)
        {
            return new Complex(first.Real + second, first.Imaginary);
        }

        public static Complex operator +(double first, Complex second)
        {
            return new Complex(first + second.Real, second.Imaginary);
        }

        public static Complex operator -(Complex first, Complex second)
        {
            return new Complex(first.Real - second.Real, first.Imaginary - second.Imaginary);
        }

        public static Complex operator -(Complex first, double second)
        {
            return new Complex(first.Real - second, first.Imaginary);
        }

        public static Complex operator -(double first, Complex second)
        {
            return new Complex(first - second.Real, -second.Imaginary);
        }

        public static Complex operator *(Complex first, Complex second)
        {
            var _result = first.Duplicate();
            _result.Multiply(second);
            return _result;
        }

        public static Complex operator *(Complex first, double second)
        {
            var _result = first.Duplicate();
            _result.Real *= second;
            _result.Imaginary *= second;
            return _result;
        }

        public static Complex operator *(double first, Complex second)
        {
            var _result = second.Duplicate();
            _result.Real *= first;
            _result.Imaginary *= first;
            return _result;
        }

        public static Complex operator /(Complex dividend, Complex divisor)
        {
            var _dividend = dividend.Duplicate();
            _dividend.Divide(divisor);
            return _dividend;
        }

        public static Complex operator /(Complex dividend, double divisor)
        {
            var _dividend = dividend.Duplicate();
            _dividend.Real /= divisor;
            _dividend.Imaginary /= divisor;
            return _dividend;
        }

        public static Boolean operator ==(Complex first, Complex second)
        {
            return (Math.Abs(first.Real - second.Real) <= first.Epsilon)
                && (Math.Abs(first.Imaginary - second.Imaginary) <= first.Epsilon);
        }

        public static Boolean operator !=(Complex first, Complex second)
        {
            return (Math.Abs(first.Real - second.Real) > first.Epsilon)
                || (Math.Abs(first.Imaginary - second.Imaginary) > first.Epsilon);
        }

        public static Boolean operator >(Complex first, Complex second)
        {
            return (first.Size > second.Size);
        }

        public static Boolean operator <(Complex first, Complex second)
        {
            return (first.Size < second.Size);
        }

        public static Boolean operator >=(Complex first, Complex second)
        {
            return (first.Size >= second.Size);
        }

        public static Boolean operator <=(Complex first, Complex second)
        {
            return (first.Size <= second.Size);
        }

        public override bool Equals(object obj)
        {
            var value = obj as Complex;
            if (obj == null)
            {
                return false;
            }
            bool result = false;
            result = (Math.Abs(this.Real - value.Real) <= this.Epsilon)
                && (Math.Abs(this.Imaginary - value.Imaginary) <= this.Epsilon);
            return result;
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0:N3}{1}{2:N3}i", this.Real, (this.Imaginary >= 0) ? "+" : "", this.Imaginary);
        }

        #endregion
    }
}
