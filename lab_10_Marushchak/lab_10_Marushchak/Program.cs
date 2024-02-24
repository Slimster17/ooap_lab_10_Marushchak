using System;

namespace lab_10_Marushchak
{
    public enum PaperSize
    {
        A4,
        Letter,
        A3,
        Legal,
        A5,
        R4
    }

    public interface IPrinterStrategy
    {
        void Print(PaperSize paperSize, int pageCount, bool isColor);
    }

    public class LaserPrinter : IPrinterStrategy
    {
        public void Print(PaperSize paperSize, int pageCount, bool isColor)
        {
            Console.WriteLine($"Printing {pageCount} " +
                              $"{(isColor ? "color" : "black and white")} pages on a laser printer");
        }

    }
    
    public class ColorPrinter : IPrinterStrategy
    {
        public void Print(PaperSize paperSize, int pageCount, bool isColor)
        {
            Console.WriteLine($"Printing {pageCount} " +
                              $"{(isColor ? "color" : "black and white")} pages on a color printer");
        }

    }
    
    public class PlotterPrinter : IPrinterStrategy
    {
        public void Print(PaperSize paperSize, int pageCount, bool isColor)
        {
            Console.WriteLine($"Printing {pageCount} " +
                              $"{(isColor ? "color" : "black and white")} pages on a plotter printer");
        }

    }

    public class PrintContext
    {
        private IPrinterStrategy _strategy;

        public void SetStrategy(IPrinterStrategy strategy)
        {
            _strategy = strategy;
        }

        public void Print(PaperSize paperSize, int pageCount, bool isColor)
        {
            _strategy.Print(paperSize, pageCount, isColor);
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            PrintContext printContext = new PrintContext();

            PaperSize paperSize = PaperSize.A4;
            int pageCount = 10;
            bool isColor = true;

            if (!isColor)
            {
                printContext.SetStrategy(new LaserPrinter());
            }
            else if (paperSize == PaperSize.A3)
            {
                printContext.SetStrategy(new PlotterPrinter());
            }
            else if (isColor)
            {
                printContext.SetStrategy(new ColorPrinter());
            }
            
            printContext.Print(paperSize, pageCount, isColor);

        }
    }
}

