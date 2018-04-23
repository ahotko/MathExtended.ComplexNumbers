using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Annex.MathExtended.ComplexNumbers
{
    public partial class Complex
    {
        public Complex Log()
        {
            return new Complex(Math.Log(this.Size), Math.Atan2(_imaginary, _real));
        }

        public Complex Log(Complex logBase)
        {
            var _a = Log();
            var _b = logBase.Log();
            return _a / _b;
        }

        public Complex Log(double logBase)
        {
            var _a = Log();
            var _b = new Complex(logBase);
            return _a / _b.Log();
        }
    }
}
