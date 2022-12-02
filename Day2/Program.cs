using System.IO;

var lines = File.ReadAllText("input.txt").Split("\n");

// Part 1
var score = 0;
const int ROCK = 1;
const int PAPER = 2;
const int SCISSORS = 3;

foreach(var line in lines) {
    var tokens = line.Split(" ");

    var l = 1 + tokens[0][0] - 'A';
    var r = 1 + tokens[1][0] - 'X';

    score += r;

    if (l == r) 
        score += 3;
    else if (l == ROCK && r == PAPER || l == PAPER && r == SCISSORS ||  l == SCISSORS && r == ROCK) 
        score += 6;           
}

Console.Out.WriteLine("Part 1: " + score);

// Part 2
score = 0;
foreach(var line in lines) {
    var tokens = line.Split(" ");

    var l = 1 + tokens[0][0] - 'A';
    var r = 1 + tokens[1][0] - 'X';

    if (r == 1) {
        // Have to lose
        score += l switch {
            ROCK => SCISSORS,
            SCISSORS =>  PAPER,
            PAPER => ROCK,
            _ => throw new Exception("Something went Pete Tong") 
        };
    }
    else if (r == 2) {
        score += l + 3;
    } else {
        score += l switch {
            ROCK => PAPER,
            SCISSORS => ROCK, 
            PAPER => SCISSORS,
            _ => throw new Exception("Something went Pete Tong") 
        };
        score+=6;
    }  
}  

Console.Out.WriteLine("Part 2: " + score);

