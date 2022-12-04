// See https://aka.ms/new-console-template for more information
using System.IO;

var lines = File.ReadAllText("input.txt").Split("\n");

// Part 1 - sorry
var score = 0;
foreach(var line in lines) {

    int[] common = new int[52];

    var first = line.Substring(0, line.Length / 2);
    var second = line.Substring(line.Length / 2);

   for (int i=0;i<first.Length;++i) {
        var idx = Char.IsLower(first[i]) ? first[i] - 'a' : 26 + first[i] - 'A';
        common[idx] = 1;
    }

    for (int i=0;i<second.Length;++i) {
        var idx = Char.IsLower(second[i]) ? second[i] - 'a' : 26 + second[i] - 'A' ;
        if (common[idx] == 1)
            common[idx] = 2;
    }


    for (int i=0;i<52;++i) {
        if (common[i] == 2) 
            score += (1+i);
    }      
} 
Console.Out.WriteLine(score);

// Part 2
score = 0;
for (int i=0;i<lines.Length;i+=6) {

    int[] common = new int[52];

    for (int j=0;j<3;++j) {
        for (int k=0;k<lines[i+j].Length;++k) {
            var item = lines[i+j][k];
            var idx = Char.IsLower(item) ? item - 'a' : 26 + item - 'A';

            common[idx] |= (1 << j);
        }            
    }

    for (int k=0;k<common.Length;++k) 
        if (common[k] == 7)
            score += 1+k;

    Array.Fill(common,0);
    for (int j=3;j<6;++j) {
        for (int k=0;k<lines[i+j].Length;++k) {
            var item = lines[i+j][k];
            var idx = Char.IsLower(item) ? item - 'a' : 26 + item - 'A';
            
            common[idx] |= 1 << (j-3);
        }            
    }

    for (int k=0;k<common.Length;++k) 
        if (common[k] == 7)
            score += 1+k;
}

Console.Out.WriteLine(score);