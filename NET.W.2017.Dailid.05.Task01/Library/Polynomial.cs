using System;

namespace Library
{
    public sealed class Polynomial
    {
        private double[] coefficients = { };

        public int Degree
        {
            get
            {
                if (coefficients.Length > 0)
                {
                    return coefficients.Length - 1;
                }
                else return 0;
            }
        }

        public Polynomial(params double[] coefficients)
        {
            // not sure if it's a good idea
            if (coefficients.Length == 0 || coefficients.Length == 1)
                return;

            int i = 0;
            for (i = coefficients.Length; i > 0; i--)
            {
                if (Math.Abs(coefficients[i - 1]) <= AppConfiguration.Epsilon) continue;
                else break;
            }

            double[] temp = new double[i];
            if (temp.Length == 0) throw new ArgumentException();
            Array.Copy(coefficients, temp, i);

            this.coefficients = temp;
        }

        public double this[int n]
        {
            get
            {
                if (n <= Degree)
                {
                    return coefficients[n];
                }
                else throw new ArgumentOutOfRangeException();
            }

            private set
            {
                if (n >= 0 && n <= Degree)
                {
                    this.coefficients[n] = value;
                }
                else throw new ArgumentOutOfRangeException();

            }
        }

        #region Object methods

        public bool Equals(Polynomial poly)
        {
            if (ReferenceEquals(null, poly))
                return false;

            if (ReferenceEquals(this, poly))
                return true;

            if (this.Degree != poly.Degree )
                return false;

            if (this.Degree == 0)
                return true;

            for (int i = 0; i <= this.Degree; i++)
            {
                if(!(Math.Abs((poly.coefficients[i] - this.coefficients[i])) < AppConfiguration.Epsilon))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Overrided Equals for obj
        /// </summary>
        /// <param name="obj">Object</param>
        /// <returns>True if polynoms are the same
        /// False if not
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (obj.GetType() != this.GetType())
                return false;

            return Equals((Polynomial)obj);
        }

        public override int GetHashCode()
        {
            int result = 0;
            for (int i = 0; i <= this.Degree; i++)
            {
                result += this.coefficients[i].GetHashCode();
            }
            return result;
        }

        public override String ToString()
        {
            string result = "";

            if (coefficients.Length == 0 || coefficients.Length == 1)
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
                else if (i == Degree && coefficients[i] == 0)
                {
                    result += "=0";
                }
            }

            return result;
        }

        #endregion

        #region Overloaded operations

        public static Polynomial operator -(Polynomial poly)
        {
            if (poly.Degree == 0 || poly == null)
                throw new ArgumentNullException();

            Double[] newCoeff = new double[poly.Degree + 1];

            for (int i = 0; i <= poly.Degree; i++)
            {
                newCoeff[i] = -poly.coefficients[i];
            }
            return new Polynomial(newCoeff);
        }

        public static Polynomial operator +(Polynomial lhs, Polynomial rhs)
        {
            if (ReferenceEquals(lhs, null))
                throw new ArgumentNullException();
            if (ReferenceEquals(rhs, null))
                throw new ArgumentNullException();

            return Add(lhs, rhs);
        }

        public static Polynomial Add(Polynomial lhs, Polynomial rhs)
        {
            if (ReferenceEquals(lhs, null))
                throw new ArgumentNullException();
            if (ReferenceEquals(rhs, null))
                throw new ArgumentNullException();

            var result = new double[Math.Max(rhs.Degree, lhs.Degree) + 1];

            if (lhs.Degree > rhs.Degree)
            {
                for (int i = 0; i <= lhs.Degree; i++)
                    result[i] = lhs.coefficients[i];

                for (int i = 0; i <= rhs.Degree; i++)
                    result[i + lhs.Degree - rhs.Degree] += rhs.coefficients[i];
            }
            else
            {
                for (int i = 0; i <= rhs.Degree; i++)
                    result[i] = rhs.coefficients[i];

                for (int i = 0; i <= lhs.Degree; i++)
                    result[i + rhs.Degree - lhs.Degree] += lhs.coefficients[i];
            }

            return new Polynomial(result);
        }

        public static Polynomial operator -(Polynomial lhs, Polynomial rhs)
        {
            if (ReferenceEquals(lhs, null))
                throw new ArgumentNullException();
            if (ReferenceEquals(rhs, null))
                throw new ArgumentNullException();

            return Subtract(lhs, rhs);
        }

        public static Polynomial Subtract(Polynomial lhs, Polynomial rhs)
        {
            if (ReferenceEquals(lhs, null))
                throw new ArgumentNullException();
            if (ReferenceEquals(rhs, null))
                throw new ArgumentNullException();

            return Add(lhs, -rhs);
        }

        public static Polynomial operator *(Polynomial lhs, Polynomial rhs)
        {
            if (ReferenceEquals(lhs, null))
                throw new ArgumentNullException();
            if (ReferenceEquals(rhs, null))
                throw new ArgumentNullException();

            return Multiply(lhs, rhs);
        }

        public static Polynomial Multiply(Polynomial lhs, Polynomial rhs)
        {
            if (ReferenceEquals(lhs, null))
                throw new ArgumentNullException();
            if (ReferenceEquals(rhs, null))
                throw new ArgumentNullException();

            var result = new double[rhs.Degree + lhs.Degree + 1];

            for (int i = 0; i <= lhs.Degree; i++)
            {
                for (int j = 0; j <= rhs.Degree; j++)
                {
                    result[i + j] += lhs.coefficients[i] * rhs.coefficients[j];
                }
            }
            return new Polynomial(result);
        }

        public static bool operator ==(Polynomial lhs, Polynomial rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Polynomial lhs, Polynomial rhs)
        {
            return !lhs.Equals(rhs);
        }

        #endregion

    }
}
