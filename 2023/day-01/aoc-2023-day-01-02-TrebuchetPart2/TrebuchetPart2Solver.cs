using System.Linq;

namespace AdventOfCode2023;

public class TrebuchetPart2Solver {

    
    public async Task<int> Solve( string filepath ){

        int totalSum = 0;
        using( StreamReader file = new StreamReader( filepath ) ){
            string? line = await file.ReadLineAsync();
            while( line is not null ){
                totalSum += this.GetLineCalibration( line.ToCharArray());
                line = await file.ReadLineAsync();
            }//END while
        }//END using
        return totalSum;
    }//END Solve()


    public int Solve(){
        int totalSum = 0;
        string? line = Console.ReadLine();
        while( line is not null ){
            totalSum += this.GetLineCalibration( line.ToCharArray());
            line = Console.ReadLine();
        }
        return totalSum;
    }
    
    public int GetLineCalibration( char[] line ){
        int i = 0, j = line.Length-1;
        
        string leftMostNumber = "_";
        string rightMostNumber = "_";
        bool hasFoundLeftMostNumber = false;
        bool hasFoundRightMostNumber = false;
        int lineCalibration = -1;

        for( i = 0, j = line.Length-1; this.ContinueSearchingForNumbers( hasFoundLeftMostNumber, hasFoundRightMostNumber); i++, j-- ){
            if( !hasFoundLeftMostNumber ){
                leftMostNumber = this.FindNumberAsDigitOrText( line, i );
                if( leftMostNumber != "" ){
                    hasFoundLeftMostNumber = true;
                }
            }
            if( !hasFoundRightMostNumber ){
                rightMostNumber = this.FindNumberAsDigitOrText( line, j, true );
                if( rightMostNumber != "" ){
                    hasFoundRightMostNumber = true;
                }
            }
            if( hasFoundLeftMostNumber && hasFoundRightMostNumber ){
                string calibrationNumber = string.Concat( leftMostNumber, rightMostNumber );
                lineCalibration = int.Parse( calibrationNumber );
            }
        }
        return lineCalibration;
    }
    
    private string FindNumberAsDigitOrText( char[] line, int index, bool searchFromRight=false ){
        if( char.IsDigit(line[index]) ){
            return line[index].ToString();
        }else{
            string numberFound = this.FindNumberAsText( line, index, searchFromRight );
            return numberFound;
        }
    }

    private string FindNumberAsText( char[] line, int wordIdx, bool searchFromRight=false ){

        var numbersText = this.CreatePossiblNumbers();

        int indexOperator = searchFromRight ? -1 : 1;
        var iteration = 1;
        bool found = false;
        while( numbersText.Any() && !found ){
            var keys = numbersText.Keys;
            foreach( var key in keys ){
                int charIdx = searchFromRight ? numbersText[key].Length - iteration : iteration-1;
                if( !line[wordIdx].Equals( numbersText[key][charIdx] ) ){
                    numbersText.Remove(key);
                }else if( iteration == numbersText[key].Length ){
                    found = true;
                }
            }
            iteration++;
            wordIdx += indexOperator;
        }
        if( found && numbersText.Count == 1 ){
            KeyValuePair<int, char[]> pair = numbersText.First();
            return pair.Key.ToString();
        }
        return "";
    }

    private bool ContinueSearchingForNumbers( bool hasFoundLeftMostDigit, bool hasFoundRightMostDigit ){
        bool continueSearching;
        continueSearching = hasFoundLeftMostDigit == false || hasFoundRightMostDigit == false;
        return continueSearching;
    }
    
    private Dictionary<int,char[]> CreatePossiblNumbers(){
        var numbersText = new Dictionary<int, char[]>{
            {1,"one".ToCharArray()},
            {2,"two".ToCharArray()},
            {3,"three".ToCharArray()},
            {4,"four".ToCharArray()},
            {5,"five".ToCharArray()},
            {6,"six".ToCharArray()},
            {7,"seven".ToCharArray()},
            {8,"eight".ToCharArray()},
            {9,"nine".ToCharArray()}, 
        };
        return numbersText;
    }



}//END class