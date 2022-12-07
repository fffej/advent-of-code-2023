using System.IO;
using System.Collections.Generic;

var lines = File.ReadAllText("input.txt").Split("\n");

DirNode root = new DirNode("/");
DirNode current = null;

Stack<DirNode> dirNodes = new ();

foreach(var line in lines) {
    if (line.StartsWith("$ cd")) {
        var dir = line.Split(" ")[2];
        if (dir == "/") {
            dirNodes.Push(current);
            current = root;            
        } else if (dir == "..") {
            current = dirNodes.Pop();
        } else {
            dirNodes.Push(current);
            current = (DirNode)current.Children.Single(x => x.Name == dir);            
        }
    } else if (line.StartsWith("$ ls")) {
        // No need to do anything here.
    } else if (line.StartsWith("dir "))  {
        var dirName = line.Split(" ")[1];

        current.Children.Add(new DirNode(dirName));
    } else {
        var s = line.Split(" ");
        var size = Int32.Parse(s[0]);
        var name = s[1];

        current.Children.Add(new FileNode(name, size));
    }
}

Stack<DirNode> toVisit = new ();
toVisit.Push(root);
int sum = 0;

while (toVisit.Count != 0) {

    var node = toVisit.Pop();
    var size = node.Size();
    if (size <= 100000) {
        sum += size;
    }

    foreach(var c in node.Children) {
        if (c is DirNode) {
            toVisit.Push((DirNode)c);
        }
    }
}

Console.Out.WriteLine("Size: " + sum);


abstract class Node {

    private string name;

    public Node(string name) { this.name = name; }

    public string Name { get { return name; } }

    public abstract int Size();
}
class DirNode : Node {
    
    private List<Node> children = new();
    
    public DirNode(string name) : base(name){  }

    public List<Node> Children { get { return children; }}

    public override int Size() {
        return children.Sum(x => x.Size());
    }
}
class FileNode : Node{

    private int size;

    public FileNode(string name, int size) : base(name) {
        this.size = size;
    }

    public override int Size() { return size; }
}