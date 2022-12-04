using System.IO;

var lines = File.ReadAllText("input.txt").Split("\n");

// Part1
var score = 0;

foreach(var line in lines) {
    var r = line.Split(",");
    var leftRange = r[0]; // a-b
    var rightRange = r[1]; // c-d

    var a = Int32.Parse(r[0].Split("-")[0]);
    var b = Int32.Parse(r[0].Split("-")[1]);
    var c = Int32.Parse(r[1].Split("-")[0]);
    var d = Int32.Parse(r[1].Split("-")[1]);

    if (a >= c && b <= d || c >=a && d <= b)
        score++;
}

Console.Out.WriteLine(score);

// Part 2
score = 0;

foreach(var line in lines) {
    var r = line.Split(",");
    var leftRange = r[0]; // a-b
    var rightRange = r[1]; // c-d

    var a = Int32.Parse(r[0].Split("-")[0]);
    var b = Int32.Parse(r[0].Split("-")[1]);
    var c = Int32.Parse(r[1].Split("-")[0]);
    var d = Int32.Parse(r[1].Split("-")[1]);

    if (!(d < a || c > b))
        score++;
}

Console.Out.WriteLine(score);