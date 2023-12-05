using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program {
        static void Main(string[] args)
        {
            string? line = "";
            int totalSum = 0;

            line = Console.ReadLine();
            while( line is not null ){
                var lineAsChars = line?.ToCharArray();
                totalSum += GetLineCalibration(lineAsChars);
                line = Console.ReadLine();
            }
            Console.Write(totalSum);
            return;
        }//main


        static int GetLineCalibration( char[] lineAsChars ){
            int leftMostDigitIndex = -1;
            int rightMostDigitIndex = -1;
            bool hasFoundLeftMostDigit = false;
            bool hasFoundRightMostDigit = false;
            for( int i = 0, j = lineAsChars.Length-1 ; hasFoundLeftMostDigit == false || 
                hasFoundRightMostDigit == false ; i++, j-- ){
                if( !hasFoundLeftMostDigit && char.IsDigit(lineAsChars[i] ) ){
                    hasFoundLeftMostDigit = true;
                    leftMostDigitIndex = i;
                }
                if( !hasFoundRightMostDigit && char.IsDigit( lineAsChars[j] ) ){
                    hasFoundRightMostDigit = true;
                    rightMostDigitIndex = j;
                }
                if( hasFoundLeftMostDigit && hasFoundRightMostDigit ){
                    string lineCalibration = string.Concat(lineAsChars[leftMostDigitIndex], lineAsChars[rightMostDigitIndex]);
                    return int.Parse(lineCalibration);
                }
            }
            return 0;
        }

        private bool ContinueSearchingForDigits( bool hasFoundLeftMostDigit, bool hasFoundRightMostDigit, int lineLength, int i, int j ){
            bool continueSearching = true;
            continueSearching = (hasFoundLeftMostDigit == false || hasFoundRightMostDigit == false) &&
                ( i < lineLength || j > 0 );
            return continueSearching;
        }
    }//END Program
}//END namespace

