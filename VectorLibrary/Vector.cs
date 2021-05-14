using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VectorLibrary
{
    public static class VectorExt
    {
        public static Vector Inverse(this Vector vector) =>
            new Vector(-vector.X , -vector.Y, -vector.Z);
        public static bool isPositive(this double num) => num > 0;
        public static bool isInteger(this double num) => Convert.ToInt64(num) == num;
    }
    [DataContract]
    public class Vector : ICloneable, IEquatable<Vector>, IComparable<Vector>
    {
        [DataMember]
        public double X { get; set; }
        [DataMember] 
        public double Y { get; set; }
        [DataMember]
        public double Z { get; set; }
        public Vector(double a, double b, double c)
        {
            X = a;
            Y = b;
            Z = c;
        }

        public static double Gap(Vector one, Vector other)
        {
            return Math.Round(Math.Sqrt(Math.Pow(other.X - one.X, 2) + Math.Pow(other.Y - one.Y, 2) + Math.Pow(other.Z - one.Z, 2)), 3);
        }

        public override string ToString() => $"Vector({X}, {Y}, {Z})";
        /*public void changeX(double any)
        {
            X = any;
        }
        public void changeY(double any)
        {
            Y = any;
        }
        public void changeZ(double any)
        {
            Z = any;
        }*/
        public static bool isInteger(Vector num)
        {
            if (Convert.ToInt64(num.X)== num.X && Convert.ToInt64(num.Y) == num.Y && Convert.ToInt64(num.Z) == num.Z) return true;
            else return false;
        }
        public static bool isInteger(double num)
        {
            if (Convert.ToInt64(num) == num) return true;
            else return false;
        }
        public bool IsPositive =>
            X >= 0 && Y >= 0 && Z >= 0;
        public static bool isPositive(Vector num)
        {
            if (num.X >= 0 && num.Y >= 0 && num.Z >= 0) return true;
            else return false;
        }
        public static bool isPositive(double num)
        {
            if (num >= 0) return true;
            else return false;
        }
        /*public double getX()
        {
            return X;
        }

        public double getY()
        {
            return Y;
        }

        public double getZ()
        {
            return Z;
        }*/

        public double Length()
        {
            return Math.Round(Math.Sqrt(X * X + Y * Y + Z * Z), 3);
        }
        public static Vector operator +(Vector one, Vector other)
        {
            return new Vector(one.X + other.X, one.Y + other.Y, one.Z + other.Z);
        }
        public static Vector operator -(Vector one, Vector other)
        {
            return new Vector(one.X - other.X, one.Y - other.Y, one.Z - other.Z);
        }
        public static Vector operator *(Vector one, Vector other)
        {
            return new Vector(one.Y * other.Z - one.Z * other.Y, one.Z * other.X - one.X * other.Z, one.X * other.Y - one.Y * other.X);
            /*a × b = {aybz - azby; azbx - axbz; axby - aybx}*/

        }
        public static double scalDobytok(Vector one, Vector other)
        {
            return Math.Round((one.X * other.X + one.Y * other.Y + one.Z * other.Z), 3);
        }
        public static bool operator !=(Vector one, Vector other) => !(one == other);
        public static bool operator ==(Vector one, Vector other) => one.X * other.Z == one.Z * other.X && one.Y == other.Y;

        public object Clone() => new Vector(X, Y, Z);

        public bool Equals(Vector other) => this.X == other?.X && this.Y == other?.Y && this.Z == other?.Z;

        public override bool Equals(object obj)
        {
            if(obj is Vector v)
            {
                return Equals(v);
            }
            return false;
        }

        public override int GetHashCode() => HashCode.Combine(X, Y, Z);

        public int CompareTo(Vector other)
        {
            if(this == other)
            {
                return 0;
            }
            return (this.Length() > other.Length()) ? 1 : -1;
        }
    }
    public class Somebody : Vector
    { 
        public Somebody(double a, double b) : base(a,b,0)
        {

        }
    }

}
