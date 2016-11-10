using System;

class CheckCorrelation : IConstraint
{
    public String Name
    {
        get
        {
            return "Constraint-CORRELATION";
        }
    }

    public bool Check(Candidate cand)
    {
        int squareX = cand.X * cand.X;
        int squareY = cand.Y * cand.Y;

        int[] four = new int[]
        {
            squareX / 1000,
            (squareX % 1000) / 100,
            (squareX % 100) / 10,
            (squareX % 10)
        };

        int[] nine = new int[]
        {
            squareY / 1000,
            (squareY % 1000) / 100,
            (squareY % 100) / 10,
            (squareY % 10)
        };


        if (nine[1] != four[2])
            return false;

        if (nine[0] == four[0] ||
            nine[0] == four[1] ||
            nine[0] == four[2] ||
            nine[0] == four[3])
            return false;

        if (nine[2] == four[0] ||
            nine[2] == four[1] ||
            nine[2] == four[2] ||
            nine[2] == four[3])
            return false;

        return true;
    }
}