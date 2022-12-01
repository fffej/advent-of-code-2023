// See https://aka.ms/new-console-template for more information
using System.IO;

var lines = File.ReadAllText("input.txt").Split();

// Part 1
var bestSum = 0;
var currentSum = 0;
for (int i=0;i<lines.Length;++i) {
    if (lines[i].Length == 0) {
        bestSum = Math.Max(bestSum,currentSum);
        currentSum = 0;
    } else {
        currentSum += Int32.Parse(lines[i]);
    }
}
Console.Out.WriteLine("Part1: " + bestSum);

// Part2
PriorityQueue<int,int> pq = new ();
currentSum = 0;
for (int i=0;i<lines.Length;++i) {
    if (lines[i].Length == 0) {
        pq.Enqueue(currentSum,Int32.MaxValue - currentSum);
        currentSum = 0;
    } else {
        currentSum += Int32.Parse(lines[i]);
    }
}

var total = pq.Dequeue() + pq.Dequeue() + pq.Dequeue();
Console.Out.WriteLine("Part2: " + total);