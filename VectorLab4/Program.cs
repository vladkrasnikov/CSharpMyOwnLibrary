using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using VectorLibrary;


/*static class MyExtensionClass
{
    public static bool iscomPositive(this double num)
    {
        if (num >= 0) return true;
        else return false;
    }
}*/
var one = new Vector(2.1, -5, 7);
var two = new Vector(5, 1, 2);
var oneclone =(Vector) one.Clone();
//oneclone.X = 222;

Console.WriteLine($"vector is: {oneclone}");
//oneclone.changeX(222);
var plus = one + two;
var minus = one - two;
var div = one * two;
Console.WriteLine($"Vector one is == to new Vector? {one == new Vector(2, -5, 7)}");
Console.WriteLine($"Vector one is equal to Vector oneclone? {one.Equals((2.1, -5, 7))}");
Console.WriteLine($"Method isIntegerX: {Vector.isInteger(one.X)}");
Console.WriteLine($"Method isInteger Vector two: {Vector.isInteger(two)}");
Console.WriteLine($"Method isPositiveX: {Vector.isPositive(one.X)}");
Console.WriteLine($"Method isPositive Vector one: {Vector.isPositive(one)}");
//Console.WriteLine($"one is: {one.getX()}, {one.getY()}, {one.getZ()}");
Console.WriteLine($"one is: {one}");
Console.WriteLine($"one - two Gap is: {Vector.Gap(one, two)}");
Console.WriteLine($"one LENGTH is: {one.Length()}");
Console.WriteLine($"one CLONE is: {oneclone}");
Console.WriteLine($"ans for PLUS + action is: {plus}");
Console.WriteLine($"ans for MINUS - action is: {plus}");
Console.WriteLine($"ans for plus action is: {plus}");
Console.WriteLine($"Scal dobytok of one and two: {Vector.scalDobytok(one, two)}");
Console.WriteLine($"one isPositive? {one.X.isPositive()}");
var vectors = new List<Vector> { one, two, oneclone, plus, minus };
var rand = one + new Somebody(2,1);
Vector.scalDobytok(one, rand);
one.Inverse();
vectors.Sort();
foreach(var n in vectors)
{
    Console.WriteLine($"Sort of vectors: {n}");
}
var writer = new FileStream("F:/Labs_C#/newxML1.xml", FileMode.Create);
var serializer = new DataContractSerializer(vectors.GetType());
serializer.WriteObject(writer, vectors);
writer.Close();
//Console.WriteLine("Десереалізація даних: ");
var reader = new FileStream("F:/Labs_C#/newxML1.xml", FileMode.Open);
serializer = new DataContractSerializer(vectors.GetType());
var t = (List<Vector>) serializer.ReadObject(reader);
foreach (var n in t)
{
    Console.WriteLine($"Deserealization of vectors: {n}");
}

var vr = new Somebody(2, 1);

Console.WriteLine($"Somebody length of v is: {vr == new Vector(2, 1, 0)}");
var v = new Vector(-100, -100, -100);

Console.WriteLine($"Gap between v is: {Vector.Gap(v, new Vector(-100, -100, -100))}");
var v1 = new Vector(21, 22, 12.2);
var vr1 = new Vector(0, 2, 52.2);
Console.WriteLine(Vector.Gap(v1, vr1));
var v11 = new Vector(2, 22, 12.2);
Console.WriteLine($"Vector(2, 22, 12.2), {v11}");

var nv = new Vector(2, 22, 12);
Console.WriteLine($"Length of NV is: {nv.Length()}");
Console.WriteLine($" of NV is: {Vector.scalDobytok(new Vector(2, 22, 12), new Vector(2, 2, 3))}");