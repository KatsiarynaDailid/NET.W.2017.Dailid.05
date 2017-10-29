using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Polynomial
    {

        private double[] coefficients;

        private int degree;

        public double[] Coefficients
        {
            get
            {
                return this.coefficients;
            }
        }

        public int Degree
        {
            get
            {
                return this.degree;
            }
        }

        public Polynomial(int degree)
        {
            this.degree = degree;
            var coeff = new double[degree + 1];
            for(int i = 0; i <= degree; i++)
            {
                coeff[i] = 1;
            }
            this.coefficients = coeff;
        }

        public Polynomial(double[] coefficients)
        {
            this.degree = coefficients.Length - 1;

            if (coefficients.Length == 1)
            {
                this.coefficients = new double[] { 0 };
            }
            else
            {
                this.coefficients = coefficients;
            }
        }


        public override bool Equals(object obj)
        {
            Polynomial poly;

            if (ReferenceEquals(this, obj))
                return true;

            if (obj is Polynomial)
                poly = obj as Polynomial;
             else
                throw new ArgumentException("Wrong type of the input parameter."); 

            if (this.Degree != poly.Degree)
                return false;
            
            for(int i = 0; i < this.Degree; i++)
            {
                if (poly.coefficients[i] != this.coefficients[i]) return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public override String ToString()
        {
            string result = "";

            if(coefficients.Length == 1 && coefficients[0] != 0)
            {
                return $"{coefficients[0]}x = 0";
            } else if(coefficients.Length == 1 && coefficients[0] == 0)
            {
                return "0 = 0";
            }

            for (int i = 0; i < coefficients.Length; i++)
            {
                int degree = Degree - i;

                if (i != Degree)
                {
                    if (coefficients[i] != 0 && i == 0)
                    {
                        result += $"{coefficients[i]}x^{degree}";
                    }
                    else if (coefficients[i] != 0 && coefficients[i] > 0)
                    {
                        result += $"+{coefficients[i]}x^{degree}";
                    }
                    else if (coefficients[i] != 0 && coefficients[i] < 0)
                    {
                        result += $"{coefficients[i]}x^{degree}";
                    }
                }
                else if (i == Degree && coefficients[i] > 0)
                {
                    result += $"+{coefficients[i]} = 0";
                }
                else if (i == Degree && coefficients[i] < 0)
                {
                    result += $"{coefficients[i]} = 0";
                }
            }
             
            return result;
        }

        public static Polynomial operator +(Polynomial firstPoly, Polynomial secondPoly)
        {
            return Add(firstPoly, secondPoly);
        }

        public static Polynomial Add(Polynomial first, Polynomial second)
        {
            var result = new double[Math.Max(second.Degree, first.Degree) + 1];

            if (first.Degree > second.Degree)
            {
                for (int i = 0; i <= first.Degree; i++)
                    result[i] = first.Coefficients[i];

                for (int i = 0; i <= second.Degree; i++)
                    result[i + first.Degree - second.Degree] += second.Coefficients[i];
            }
            else
            {
                for (int i = 0; i <= second.Degree; i++)
                    result[i] = second.Coefficients[i];

                for (int i = 0; i <= first.Degree; i++)
                    result[i + second.Degree - first.Degree] += first.Coefficients[i];
            }

            return new Polynomial(result);
        }

        public static Polynomial operator -(Polynomial firstPoly, Polynomial secondPoly)
        {
            return Subtract(firstPoly, secondPoly);
        }

        public static Polynomial Subtract(Polynomial first, Polynomial second)
        {
            var result = new double[Math.Max(second.degree, first.degree) + 1];

            if (first.Degree > second.Degree)
            {
                for (int i = 0; i <= first.Degree; i++)
                    result[i] += first.Coefficients[i];

                for (int i = 0; i <= second.Degree; i++)
                    result[i + first.Degree - second.Degree] -= second.Coefficients[i];
            }
            else
            {
                for (int i = 0; i <= first.Degree; i++)
                    result[i + second.Degree - first.Degree] += first.Coefficients[i];

                for (int i = 0; i <= second.Degree; i++)
                    result[i] -= second.Coefficients[i];
            }

            return new Polynomial(result);
        }

        public static Polynomial operator *(Polynomial firstPoly, Polynomial secondPoly)
        {
            return Multiply(firstPoly, secondPoly);
        }

        public static Polynomial Multiply(Polynomial first, Polynomial second)
        {
            var result = new double[second.Degree + first.Degree + 1];

            for (int i = 0; i <= first.Degree; i++)
            {
                for (int j = 0; j <= second.Degree; j++)
                {
                    result[i + j] += first.Coefficients[i] * second.Coefficients[j];
                }
            }
            return new Polynomial(result);
        }

        public static bool operator ==(Polynomial firstPoly, Polynomial secondPoly)
        {
            return firstPoly.Equals(secondPoly);
        }

        public static bool operator !=(Polynomial firstPoly, Polynomial secondPoly)
        {
            return !firstPoly.Equals(secondPoly);
        }


    }
}
