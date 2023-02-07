using System;
using System.IO;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Journal;

class Program
{ 
    public static bool isIt = false;
    public static string userNote;
    public static string pathOfFile;
    public static DateTime dateNeeded = DateTime.Today;
    static string defaultNewLine = Environment.NewLine;


    public static void Main(string[] args)
    {
        programTalking();
        gottaDelete();
        forTextDocument();
    }

    private static void gottaDelete()
    {
        var firstPart = userNote.Substring(userNote.IndexOf("start") + 6);
        var lastPart =  firstPart.Remove(firstPart.LastIndexOf("stop"));
        var finalNote = lastPart;


        userNote = Convert.ToString(finalNote);
    }

    private static void programTalking()
    {
        Console.WriteLine("Welcome to Jean-Luc's Journal!");
        Thread.Sleep(000);
        Console.Clear();
        Console.WriteLine("The thing you type before you write 'start' will be deleted!\n");
        Thread.Sleep(000);
        Console.Clear();
        Console.WriteLine("PLEASE WRITE 'START' BEFORE TYPING AND 'STOP' AFTER FINISHING OTHERWISE YOUR TEXT WONT BE SAVED!\n");
        Console.Write("=> ");
        userNote = Console.ReadLine();
    }

    private static void forTextDocument()
    {
        pathOfFile = @"C:\Users\omerb\OneDrive\Desktop\" + dateNeeded.ToString("yyyy-MM-dd") + ".txt";
        StreamWriter sw = File.CreateText(pathOfFile);
        sw.WriteLine("Captain’s log\r");
        sw.Write("Stardate <");
        sw.Write(dateNeeded.ToString("yyyy-MM-dd"));
        sw.Write(">\n\n");
        sw.WriteLine(userNote);
        sw.WriteLine("\nJean-Luc Picard");
        sw.Close();
    }
 
}