using System;
using System.Globalization;
class FixedPointBaseConverter{
    private const string digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz+/";

    public static void Main(){ 
        System.Console.WriteLine("Enter a number, with decimals separated via a period: ");
        string entry = Console.ReadLine();
        System.Console.WriteLine("Enter the base of the number, up to 64: ");
        int sourceBase = int.Parse(Console.ReadLine());
        System.Console.WriteLine("Enter the base to be converted to, up to 64: ");
        int targetBase = int.Parse(Console.ReadLine());
        entry = ConvertS2D(entry, sourceBase);
        System.Console.WriteLine("Number converted to base 10: " + entry);
        entry = ConvertD2T(entry, targetBase);
        System.Console.WriteLine("Number converted to base " + targetBase + ": " + entry);
    }

    public static string ConvertS2D(string number, int sourceBase){
        string fractionalPart, integerPart;
        if(number.IndexOf('.') != -1){
            fractionalPart = number[(number.IndexOf('.') + 1)..];
            integerPart = number[..number.IndexOf('.')];
            return ConvertSIntegerPart(integerPart, sourceBase) + ConvertSFractionalPart(fractionalPart, sourceBase);
        } else {
            return ConvertSIntegerPart(number, sourceBase);
        }
    }

    public static string ConvertSIntegerPart(string number, int sourceBase){
        double result = 0;
        for(int i = 0; i < number.Length; i++)
            result += digits.IndexOf(number[i].ToString()) * Math.Pow(sourceBase, number.Length - i - 1);
        return result.ToString();
    }

    public static string ConvertSFractionalPart(string number, int sourceBase){
        double result = 0;
        for(int i = 0; i < number.Length; i++)
            result += digits.IndexOf(number[i].ToString()) * Math.Pow(sourceBase, -i - 1);
        return result.ToString().Substring(result.ToString().IndexOf('.'), 2);
    }

    public static string ConvertD2T(string number, int targetBase){
        string fractionalPart, integerPart;
        if(number.IndexOf('.') != -1){
            fractionalPart = number[(number.IndexOf('.') + 1)..];
            integerPart = number[..number.IndexOf('.')];
            return ConvertDIntegerPart(integerPart, targetBase) + ConvertDFractionalPart(fractionalPart, targetBase);
        } else {
            return ConvertDIntegerPart(number, targetBase);
        }
    }

    public static string ConvertDIntegerPart(string integerPart, int targetBase){
        int number = int.Parse(integerPart);
        string converted = "";
        while(number > 0){
            converted += digits[number % targetBase];
            number /= targetBase;
        }
        char[] revArray = converted.ToCharArray();
        Array.Reverse(revArray);
        return new string(revArray);
    }

    public static string ConvertDFractionalPart(string fractionalPart, int targetBase){
        double number = double.Parse("0." + fractionalPart);
        string converted = ".";
        for(int i = 0; i < 10 && number != 0; i++){
            number *= targetBase;
            converted += digits[(int)number];
            number -= (int)number;
        }
        return converted;
    }
}
