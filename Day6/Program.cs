using System.IO;
using System.Collections.Generic;

var line = File.ReadAllText("input.txt");

bool Distinct(LinkedList<char> items, int n) {
    HashSet<char> c = new ();
    foreach(var item in items) 
        c.Add(item);

    return c.Count == n;
}

int FindMarker(string line, int n) {
    LinkedList<char> buf = new ();
    for (int i=0;i<n;++i) 
        buf.AddLast(line[i]);

    for (int i=4;i<line.Length;++i) {
        
        if (Distinct(buf,n)) {
            return i;
        }

        buf.RemoveFirst();
        buf.AddLast(line[i]);
    }

    return -1;
}

Console.Out.WriteLine("Part 1: " + FindMarker(line,4));
Console.Out.WriteLine("Part 2: " + FindMarker(line,14));