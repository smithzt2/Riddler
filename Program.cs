using System.Text;


namespace Program{
    class World {
        public static void Main(string[] args) {
            Console.WriteLine("Enter a word:");

            var choice = "";
            var n = -1;
            var x = -1;


            Console.WriteLine("====================");
            Console.WriteLine("Select an option. \n1. Alpha-Calculate a word\n2.Spell out a number.\n3.Alpha-Calulate a number.\n4.Riddler.");
            Console.WriteLine("====================");
            x = Int32.Parse(Console.ReadLine());
            switch (x) {
                case 1:
                    Console.WriteLine("Enter a word to be alpha-calulated:");
                    choice = Console.ReadLine().ToLower();
                    Console.WriteLine($"{choice}'s calculated value is: {wordValueCalculate(choice)}");
                    break;
                case 2:
                    Console.WriteLine("Enter a number to spell out:");
                    choice = Console.ReadLine();
                    n = Int32.Parse(choice);
                    Console.WriteLine($"{n} spelled out is: {numberToWord(n)}");
                    break;
                case 3:
                    Console.WriteLine("Enter a number to be alpha-calculated:");
                    choice = Console.ReadLine();
                    n = Int32.Parse(choice);
                    Console.WriteLine($"{choice} Alpha-Calculated is: {numberToValue(n)}");
                    
                    break;
                case 4:
                    Console.WriteLine($"Highest value less than its alpha-calcualted self is: {riddler.riddlerExpress()}");
                    break;
                default:
                    Console.WriteLine("Input not understood.");
                    break;
            }
        }


        // Sum the value of a word where letters are assigned values based on their alphabetical position
        // a = 1
        // b = 2
        // ...
        // y = 25
        // z = 26
        public static int wordValueCalculate(string word) {
            int value = 0;

            
            word = word.ToLower();
            // TODO: Remove ALL Special characters
            
            // Get ASCII value of each letter
            // Subtract 96 to get alphabetical ordering position
            // Sum those values

            //Do not count spaces
            foreach(char letter in word) {
                if(letter is not ' ') {
                    value += letter - 96;
                }
                
            }

            return value;
        }


        // Takes an (int) and converts it to a written form
        // omits any '...hundred and ...' 
        // 30 = Thirty
        // -3 = Negative Three
        // 293 = Two Hundred Ninty Three
        public static StringBuilder numberToWord(int number) {
            StringBuilder word = new StringBuilder("");
            StringBuilder numberString = new StringBuilder(number.ToString());
            

            // Base forms 
            String[] subTwenty = new string[]{"", "One ", "Two ", "Three ", "Four ", "Five ", "Six ", "Seven ", "Eight ", "Nine ", "Ten"};
            String[] teens = new string[]{"Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"};
            String[] tens = new string[]{"", "Ten", "Twenty ", "Thirty ", "Fourty ", "Fifty ", "Sixty ", "Seventy ", "Eighty ", "Ninety "};
            String hundreds = "Hundred ";
            String thousands = "Thousand ";
            String millions = "Million ";
            String billions = "Billion ";

            // Build String by comparing values and adding appropriate terms to StringBuilder
            // Sequence through number, reducing by 10^1 each time

            //Check negative
            if(number < 0) {
                word.Append("Negative ");
                numberString.Remove(0,1);
                number = number * -1;
            }
            
        
            //  1B <= number <= intMax
            // add digit + billion to SB
            if(number >= 1000000000) {
                word.Append(subTwenty[(int)Char.GetNumericValue(numberString[0])]);
                word.Append(billions);
                // Shift number to the right
                number = number % 1000000000;
                // Trim string
                numberString.Remove(0, 1);
            }

            // 100M <= number < 1B
            if(number >= 100000000){
                word.Append(subTwenty[(int)Char.GetNumericValue(numberString[0])]);
                word.Append(hundreds);
                // Shift number to the right
                number = number % 100000000;
                // Trim string
                numberString.Remove(0, 1);
            }

            // 10M <= number < 100M
            if(number >= 10000000){
                word.Append(tens[(int)Char.GetNumericValue(numberString[0])]);
                // Shift number to the right
                number = number % 10000000;
                // Trim string
                numberString.Remove(0, 1);
            }
            
            // 1M <= number < 10M
            if(number >= 1000000){
                word.Append(subTwenty[(int)Char.GetNumericValue(numberString[0])]);
                word.Append(millions);
                // Shift number to the right
                number = number % 1000000;
                // Trim string
                numberString.Remove(0, 1);
            }
             
            // 100T <= number < 1M
            if(number >= 100000){
                word.Append(subTwenty[(int)Char.GetNumericValue(numberString[0])]);
                word.Append(hundreds);
                // Shift number to the right
                number = number % 100000;
                // Trim string
                numberString.Remove(0, 1);
            }

            // 10T <= number < 100T
            if(number >= 10000){
                word.Append(tens[(int)Char.GetNumericValue(numberString[0])]);
                
                // Shift number to the right
                number = number % 10000;
                // Trim string
                numberString.Remove(0, 1);
            }

            // 1T <= number < 10T
            if(number >= 1000){
                word.Append(subTwenty[(int)Char.GetNumericValue(numberString[0])]);
                word.Append(thousands);
                // Shift number to the right
                number = number % 1000;
                // Trim string
                numberString.Remove(0, 1);
            }
           
            // 100 <= number < 1T
            if(number >= 100){
                word.Append(subTwenty[(int)Char.GetNumericValue(numberString[0])]);
                word.Append(hundreds);
                // Shift number to the right
                number = number % 100;
                // Trim string
                numberString.Remove(0, 1);
                
            }
                    
            // 20 <= number < 100
            if(number >= 20){
                word.Append(tens[(int)Char.GetNumericValue(numberString[0])]);
                // Shift number to the right
                   number = number % 10;
                // Trim string
                numberString.Remove(0, 1);
             
            }
           
              // 0 <= number < 20
            if(number >= 0){
                if(number > 10) {
                    word.Append(teens[Int32.Parse(numberString.ToString()) - 11]);
                }
                else {
                    word.Append(subTwenty[(int)Char.GetNumericValue(numberString[0])]);
                    // Shift number to the right
                }
                // Trim string
                numberString.Remove(0, 1);
                
            }
           
            return word;
        }

        // Takes an (int) and calculates the wordValue of the fully spelled out version of the word
        // 34 = thirty four
        // thirty four = 96 
        public static int numberToValue(int num) {
            return (wordValueCalculate(numberToWord(num).ToString()));
        }
    }

    class riddler {
        
        // Identify largest value less than its Alpha-Calculated form
        //
        // ex. 34 = thirty four = 160
        // 160 > 34 
        // 1000 = one thousand = 136
        // 136 < 1000
        public static int riddlerExpress() {
            var canditate = -1;

            // Arbitrary Number, one thousand > zzz zzzzzzzz
            // so at some point the numbers cannot keep up
            int maxLoops = 1000;
            for(var i = 0; i<= maxLoops; i++) {
                if(World.numberToValue(i) > i) {
                    canditate = i;
                }
            }
            return canditate;
        } 
    }
}

