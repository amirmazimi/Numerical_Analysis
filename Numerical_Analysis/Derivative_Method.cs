using System;
using System.Collections.Generic;

public class Derivative_Method
{
    public static double Exp(double x)
    {
        return Math.Exp(x);
    }

    public static double Derivative(Func<double, double> f, string formula, double x)
    {
        double h = 0.05;
        double fi = f(x);
        double fi_1 = f(x - h);
        double fi_2 = f(x - 2 * h);
        double fi_3 = f(x - 3 * h);

        if (formula == "forward")
        {
            return (f(x + h) - fi) / h;
        }
        else if (formula == "central")
        {
            return (fi_1 - 2 * fi + fi_2) / (2 * h);
        }
        else if (formula == "backward")
        {
            return (3 * fi - 3 * fi_1 + fi_2 - fi_3) / (3 * h);
        }

        return 0;
    }

    public static void Main()
    {
        List<double> xi = new List<double>();
        List<double> yi = new List<double>();
        List<double> dfwd = new List<double>();
        List<double> dccent = new List<double>();
        List<double> dback = new List<double>();
        List<double> e_fwd = new List<double>();
        List<double> e_cent = new List<double>();
        List<double> e_back = new List<double>();

        for (int i = 0; i < 5; i++)
        {
            xi.Add(0.1 + 0.05 * i);
            yi.Add(Exp(xi[i]));
            dfwd.Add(Derivative(Exp, "forward", xi[i]));
            dccent.Add(Derivative(Exp, "central", xi[i]));
            dback.Add(Derivative(Exp, "backward", xi[i]));
            e_fwd.Add(Math.Abs(dfwd[i] - Exp(xi[i])));
            e_cent.Add(Math.Abs((dccent[i] - dfwd[i]) / 2));
            e_back.Add(Math.Abs((dback[i] - dfwd[i]) / 6));
        }

        Console.WriteLine("Values:");
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("{0:F4}", yi[i]);
        }

        Console.WriteLine("Derivatives using forward formula:");
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("{0:F4}", dfwd[i]);
        }

        Console.WriteLine("Derivatives using central formula:");
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("{0:F4}", dccent[i]);
        }

        Console.WriteLine("Derivatives using backward formula:");
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("{0:F4}", dback[i]);
        }

        Console.WriteLine("Errors of differentiation using forward formula:");
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("{0:F4}", e_fwd[i]);
        }

        Console.WriteLine("Errors of differentiation using central formula:");
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("{0:F4}", e_cent[i]);
        }

        Console.WriteLine("Errors of differentiation using backward formula:");
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("{0:F4}", e_back[i]);
        }
    }
}
