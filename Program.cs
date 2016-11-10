using System;
using System.Collections.Generic;

class Program
{
    public static void Main()
    {
        Test01a();
        Test01b();
        Test02();
        Test03();
        Test04();
    }

    private static void Test01a()
    {
        VierNeun vn = new VierNeun();
        vn.ComputeCandidates();
        Console.WriteLine("Initial Candidates: {0}", vn.Count);
    }


    private static void Test01b()
    {
        VierNeun vn = new VierNeun();
        vn.ComputeCandidates();
        Console.WriteLine(vn);
    }

    private static void Test02()
    {
        VierNeun vn = new VierNeun();

        vn.ComputeCandidates();
        Console.WriteLine("Initial Candidates:       {0}", vn.Count);

        IConstraint c1 = new CheckVier();
        Console.WriteLine("Processing constraint:   '{0}'", c1.Name);
        vn.ApplyConstraint(c1);
        Console.WriteLine("-> Remaining candidates:  {0}", vn.Count);

        IConstraint c2 = new CheckNeun();
        Console.WriteLine("Processing constraint:   '{0}'", c2.Name);
        vn.ApplyConstraint(c2);
        Console.WriteLine("-> Remaining candidates:  {0}", vn.Count);

        IConstraint c3 = new CheckCorrelation();
        Console.WriteLine("Processing constraint:   '{0}'", c3.Name);
        vn.ApplyConstraint(c3);
        Console.WriteLine("-> Remaining candidates:  {0}", vn.Count);
        Console.WriteLine();

        Console.WriteLine("Solution Candidates:      {0}", vn.Count);
        Console.WriteLine(vn);
    }

    private static void Test03()
    {
        VierNeun vn = new VierNeun();
        vn.ComputeCandidates();
        Console.WriteLine("Initial Candidates:      {0}", vn.Count);

        // create list of constraints
        List<IConstraint> constraints = new List<IConstraint>();
        constraints.Add(new CheckVier());
        constraints.Add(new CheckNeun());
        constraints.Add(new CheckCorrelation());

        for (int i = 0; i < constraints.Count; i++)
        {
            Console.WriteLine("Processing constraint:   '{0}'",
                constraints[i].Name);
            vn.ApplyConstraint(constraints[i]);
            Console.WriteLine("-> Remaining candidates:  {0}", vn.Count);
        }
    }

    private static void Test04()
    {
        VierNeun vn = new VierNeun();
        vn.ComputeCandidates();

        // create list of constraints
        List<IConstraint> constraints = new List<IConstraint>();
        constraints.Add(new CheckVier());
        constraints.Add(new CheckNeun());
        constraints.Add(new CheckCorrelation());

        // apply constraints
        for (int i = 0; i < constraints.Count; i++)
            vn.ApplyConstraint(constraints[i]);

        Candidate unique = vn.Unique();
        Console.WriteLine("Unique Solution: {0}", unique);
    }
}
