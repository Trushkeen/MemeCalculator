using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace CodeGenerator
{
    class Program
    {
        private static int MaxRange = 201;

        static void Main(string[] args)
        {
            Console.WriteLine("Max range is " + MaxRange);
            Console.WriteLine("Enter filename: ");
            string path = Console.ReadLine();
            Generate(path);
            Console.ReadKey();
        }

        private static void Generate(string path)
        {
            string code = File.ReadAllText(path);
            Console.WriteLine(code);
            int openingColonIndex = code.LastIndexOf("{") + 1;
            code = code.Insert(openingColonIndex, SumStrings());
            code = code.Insert(openingColonIndex, SubStrings());
            code = code.Insert(openingColonIndex, MulStrings());
            code = code.Insert(openingColonIndex, DivStrings());
            File.WriteAllText(path, code);
        }

        private static string SumStrings()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("if (firstNum==0 && oper==\"+\" && secondNum==0) Console.WriteLine(\"0\");");
            for (int i = 0; i < MaxRange; i++)
            {
                for (int j = 0; j < MaxRange; j++)
                {
                    sb.AppendLine($"else if (firstNum=={i} && oper==\"+\" && secondNum=={j}) Console.WriteLine(\"{i + j}\");");
                }
            }
            Console.WriteLine("Generating sum strings completed");
            return sb.ToString();
        }

        private static string SubStrings()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("if (firstNum==0 && oper==\"-\" && secondNum==0) Console.WriteLine(\"0\");");
            for (int i = 0; i < MaxRange; i++)
            {
                for (int j = 0; j < MaxRange; j++)
                {
                    sb.AppendLine($"else if (firstNum=={i} && oper==\"-\" && secondNum=={j}) Console.WriteLine(\"{i - j}\");");
                }
            }
            Console.WriteLine("Generating sub strings completed");
            return sb.ToString();
        }

        private static string MulStrings()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("if (firstNum==0 && oper==\"*\" && secondNum==0) Console.WriteLine(\"0\");");
            for (int i = 0; i < MaxRange; i++)
            {
                for (int j = 0; j < MaxRange; j++)
                {
                    sb.AppendLine($"else if (firstNum=={i} && oper==\"*\" && secondNum=={j}) Console.WriteLine(\"{i * j}\");");
                }
            }
            Console.WriteLine("Generating mul strings completed");
            return sb.ToString();
        }

        private static string DivStrings()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("if (firstNum==0 && oper==\"/\" && secondNum==0) Console.WriteLine(\"0\");");
            for (int i = 0; i < MaxRange; i++)
            {
                for (int j = 0; j < MaxRange; j++)
                {
                    if (j != 0)
                    {
                        sb.AppendLine($"else if (firstNum=={i} && oper==\"/\" && secondNum=={j}) Console.WriteLine(\"{i / j}\");");
                    }
                    else
                    {
                        sb.AppendLine($"else if (firstNum=={i} && oper==\"/\" && secondNum=={j}) Console.WriteLine(\"We don't do it here\");");
                    }
                }
            }
            Console.WriteLine("Generating div strings completed");
            return sb.ToString();
        }

        private static string Finish()
        {
            StringBuilder sb = new StringBuilder();
            return sb.AppendLine("else Console.WriteLine(\"Sorry, something doesn't work," +
                " but we will fix it when code be generated up to 1000 numbers\");").ToString();
        }
    }
}
