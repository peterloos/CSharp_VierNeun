using System;

class CheckVier : IConstraint
{
    public String Name
    {
        get
        {
            return "Constraint-VIER";
        }
    }

    public bool Check(Candidate cand)
    {
        int square = cand.X * cand.X;

        int[] four = new int[]
        {
            square / 1000,
            (square % 1000) / 100,
            (square % 100) / 10,
            (square % 10)
        };

        if (four[0] == four[1] ||
            four[0] == four[2] ||
            four[0] == four[3])
            return false;

        if (four[1] == four[2] ||
            four[1] == four[3])
            return false;

        if (four[2] == four[3])
            return false;

        return true;
    }
}

