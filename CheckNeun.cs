using System;

class CheckNeun : IConstraint
{
    public String Name
    {
        get
        {
            return "Constraint-NEUN";
        }
    }

    public bool Check(Candidate cand)
    {
        int square = cand.Y * cand.Y;

        int[] nine = new int[]
        {
            square / 1000,
            (square % 1000) / 100,
            (square % 100) / 10,
            (square % 10)
        };

        if (nine[0] != nine[3])
            return false;

        if (nine[1] == nine[2])
            return false;

        if (nine[0] == nine[1] || nine[0] == nine[2])
            return false;

        if (nine[1] == nine[3] || nine[2] == nine[3])
            return false;

        return true;
    }
}
