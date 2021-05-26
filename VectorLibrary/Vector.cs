using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

/*Написати клас для реалізації векторів 3-вимірного простору з дійсними
коефіцієнтами. Реалізація має містити:
a) функцію обчислення довжини вектора, метод Length та статичну функцію
знаходження відстані між векторами;
b) властивості для звертання до координат вектора та властивості IsInteger та
IsPositive.
c) операції над векторами (+, –, скалярний та векторний добутки);
d) підтримку інтерфейсів ICloneable, IEnumerable, IComparable*/

namespace VectorLibrary
{
    public static class VectorExt
    {
        public static Vector Inverse(this Vector vector) =>
            new Vector(-vector.X , -vector.Y, -vector.Z);
    }
    [DataContract]
    public class Vector : ICloneable, IEquatable<Vector>, IComparable<Vector>, IVector, IComparer<Vector>, IEnumerable 
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
        public Vector(double a)
        {
            X = a;
            Y = a;
            Z = a;
        }
        public static double Gap(Vector one, Vector other) =>
            Math.Sqrt(Math.Pow(other.X - one.X, 2) + Math.Pow(other.Y - one.Y, 2) + Math.Pow(other.Z - one.Z, 2));
        
        public override string ToString() => $"Vector({X}, {Y}, {Z})";

        public bool IsInteger =>
            Convert.ToInt64(X) == X && Convert.ToInt64(Y) == Y && Convert.ToInt64(Z) == Z;

        public bool IsPositive => X >= 0 && Y >= 0 && Z >= 0;

        public double Length() => Math.Sqrt(X * X + Y * Y + Z * Z);

        public static Vector operator +(Vector one, Vector other) => 
            new (one.X + other.X, one.Y + other.Y, one.Z + other.Z);

        public static Vector operator -(Vector one, Vector other) => 
            new (one.X - other.X, one.Y - other.Y, one.Z - other.Z);

        public static Vector operator *(Vector one, Vector other) => 
            new (one.Y * other.Z - one.Z * other.Y, one.Z * other.X - one.X * other.Z, one.X * other.Y - one.Y * other.X);
            /*a × b = {aybz - azby; azbx - axbz; axby - aybx}*/
        public static double operator ^(Vector one, Vector other) => 
            one.X * other.X + one.Y * other.Y + one.Z * other.Z;
        public static bool operator !=(Vector one, Vector other) => !(one == other);
        public static bool operator ==(Vector one, Vector other) => one.X * other.Z == one.Z * other.X && one.Y == other.Y;
        public object Clone() => new Vector(X, Y, Z);
        public bool Equals(Vector other) => X == other?.X && Y == other?.Y && Z == other?.Z;

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
            if(this.Length() == other.Length())
            {
                return 0;
            }
            return (this.Length() > other.Length()) ? 1 : -1;
        }

        public IEnumerator GetEnumerator()
        {
            double[] mas = new double[3] { X, Y, Z };
            foreach(var i in mas)
            {
                yield return i;
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return(IEnumerator)GetEnumerator();
        }

        public int Compare(Vector x, Vector y)
        {
            if (x.Length() == y.Length())
            {
               return 0;
            }
            return (x.Length() > y.Length()) ? 1 : -1;
        }
    }
    public class Somebody : Vector
    {
        public Somebody(double a, double b) : base(a, b, 0) { }
        public Somebody ToOtherSector => new(-X, Y);
        public Somebody Swap => new(Y, X);

    }

}
