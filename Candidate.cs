using System;

class Candidate
{
    private int x;
    private int y;

    // c'tor
    public Candidate(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    // properties
    public int X
    {
        get
        {
            return this.x;
        }
    }

    public int Y
    {
        get
        {
            return this.y;
        }
    }

    // contract with base class 'Object'
    public override String ToString()
    {
        return String.Format("{0}, {1} -> [{2}, {3}]",
            this.x, this.y, this.x * this.x, this.y * this.y);
    }
}