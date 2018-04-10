using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Annex.MathExtended.ComplexNumbers
{
    public class Complex
    {
        private double _real;
        private double _imaginary;
        private double _epsilon = 0.001;

        public double Epsilon
        {
            get { return _epsilon; }
            set { _epsilon = value; }
        }

        public static Complex Zero
        {
            get { return new Complex(); }
        }

        public double Real
        {
            get { return _real; }
            set { _real = value; }
        }

        public double Imaginary
        {
            get { return _imaginary; }
            set { _imaginary = value; }
        }

        public double Size
        {
            get
            {
                double _size = Math.Pow(_real, 2) + Math.Pow(_imaginary, 2);
                return Math.Sqrt(_size);
            }
        }

        public double Angle
        {
            get
            {
                return Math.Atan2(_imaginary, _real);
            }
        }

        public Complex() : this(0.0, 0.0)
        {

        }

        public Complex(double real) : this(real, 0.0)
        {

        }

        public Complex(double real, double imaginary)
        {
            _real = real;
            _imaginary = imaginary;
        }

        public Complex Conjugate()
        {
            return new Complex(this.Real, -this.Imaginary);
        }

        public void Multiply(Complex factor)
        {
            double _newReal = this._real * factor._real - this._imaginary * factor._imaginary;
            double _newImaginary = this._real * factor._imaginary + this.Imaginary * factor._real;
            _real = _newReal;
            _imaginary = _newImaginary;
        }

        public void Divide(Complex divisor)
        {
            double _divisor = Math.Pow(divisor.Real, 2) + Math.Pow(divisor.Imaginary, 2);
            double _newReal = this.Real * divisor.Real + this.Imaginary * divisor.Imaginary;
            double _newImaginary = this.Real * divisor.Imaginary - this.Imaginary * divisor.Real;
            _real = _newReal / _divisor;
            _imaginary = _newImaginary / _divisor;
        }

        public Complex Duplicate()
        {
            return new Complex(_real, _imaginary);
        }

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
            return new Complex(first - second.Real, second.Imaginary);
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