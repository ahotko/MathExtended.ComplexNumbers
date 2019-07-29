using System;

namespace Data.Annex.MathExtended.ComplexNumbers
{
    public partial class Complex
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

        public Complex() : this(0.0, 0.0) { }

        public Complex(double real) : this(real, 0.0) { }

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

    }
}