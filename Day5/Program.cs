// See https://aka.ms/new-console-template for more information
using System.IO;
using System.Collections;

Stack<char> MkStack(string s) {
    Stack<char> r = new ();
    for (int i=s.Length-1;i>=0;--i)
        r.Push(s[i]);

    return r;
}

List<Stack<char>> Start() => new List<Stack<char>>{
    MkStack("FHMTVLD"),
    MkStack("PNTCJGQH"),
    MkStack("HPMDSR"),
    MkStack("FVBL"),
    MkStack("QLGHN"),
    MkStack("PMRGDBW"),
    MkStack("QLHCRNMG"),
    MkStack("WLC"),
    MkStack("TMZJQLDR")
};

var s = Start();

// Part 1
var lines = File.ReadAllText("input.txt").Split("\n");
foreach(var line in lines) {
    var l = line.Split(" ");

    var n = Int32.Parse(l[1]);
    var src = Int32.Parse(l[3])-1;
    var tgt = Int32.Parse(l[5])-1;

    for (int i=0;i<n;++i) {
        var c = s[src].Pop();
        s[tgt].Push(c);
    }
}

foreach (var q in s) {
    Console.Out.Write(q.Peek());
}
Console.Out.WriteLine();

// Part 2
s = Start();
foreach(var line in lines) {
    var l = line.Split(" ");

    var n = Int32.Parse(l[1]);
    var src = Int32.Parse(l[3])-1;
    var tgt = Int32.Parse(l[5])-1;

    LinkedList<char> x = new ();

    for (int i=0;i<n;++i) {
        var c = s[src].Pop();
        x.AddFirst(c);
    }

    foreach(var c in x) {
        s[tgt].Push(c);
    }
}

foreach (var q in s) {
    Console.Out.Write(q.Peek());
}
Console.Out.WriteLine();