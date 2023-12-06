// See https://aka.ms/new-console-template for more information

namespace AdventOfCode2023;

internal class TrebuchetPart2Main {
    

    static async Task Main(  string[] args ){
        string filepath = "";
        if( args.Length == 1 ){
            filepath = args[0];
        }
        var solver = new TrebuchetPart2Solver();
        
        var totalSum = string.IsNullOrWhiteSpace( filepath ) ? 
            solver.Solve() : await solver.Solve( filepath );
        Console.WriteLine(totalSum);

    }//END main

    
}//END class


