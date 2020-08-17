using System;
using System.Threading;

namespace pdf2image
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            try
            {
                var output = "pdftoppm -r 300 -png input.pdf output".Bash();
                Console.WriteLine($"Exec {output}");
                //check output dir
                var lsoutput = "ls -la".Bash();
                Console.WriteLine($"Exec {lsoutput}");
                Thread.Sleep(3000);
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }        
    }
}
