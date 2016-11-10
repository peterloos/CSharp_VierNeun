using System;
using System.Text;
using System.Collections.Generic;

class VierNeun
{
    private List<Candidate> candidates;

    public VierNeun()
    {
        this.candidates = new List<Candidate>();
    }

    // properties
    public int Count
    {
        get
        {
            return this.candidates.Count;
        }
    }

    public List<Candidate> Candidates
    {
        get
        {
            return new List<Candidate>(this.candidates);
        }
    }

    // public interface
    public void ComputeCandidates()
    {
        // compute all numbers that have squares with 4 digits
        List<int> numbers = new List<int>();
        for (int i = 1; i < 100; i++)
        {
            int square = i * i;
            if (square >= 1000 && square <= 9999)
            {
                numbers.Add(i);
            }
        }

        // generate cross product (number x number)
        for (int i = 0; i < numbers.Count; i++)
        {
            for (int j = 0; j < numbers.Count; j++)
            {
                Candidate c = new Candidate(numbers[i], numbers[j]);
                this.candidates.Add(c);
            }
        }
    }

    public void ApplyConstraint(IConstraint c)
    {
        List<Candidate> tmp = new List<Candidate>();

        for (int i = 0; i < this.candidates.Count; i++)
        {
            if (c.Check(this.candidates[i]))
                tmp.Add(this.candidates[i]);
        }

        // reduce list of possible candidates
        this.candidates = tmp;
    }

    public Candidate Unique()
    {
        for (int i = 0; i < this.candidates.Count; i++)
        {
            bool unique = true;
            for (int j = 0; j < this.candidates.Count; j++)
            {
                if (j == i)
                    continue;

                if (this.candidates[i].X == this.candidates[j].X)
                {
                    unique = false;
                    break;
                }
            }

            if (unique)
            {
                for (int k = 0; k < this.candidates.Count; k++)
                {
                    if (k == i)
                        continue;

                    if (this.candidates[k].Y == this.candidates[i].Y)
                    {
                        unique = false;
                        break;
                    }
                }

                if (unique)
                    return this.candidates[i];
            }
        }

        return null;  // should never be reached
    }

    // contract with base class 'Object'
    public override String ToString()
    {
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < this.candidates.Count; i ++)
            sb.Append(this.candidates[i].ToString() + Environment.NewLine);

        return sb.ToString();
    }
}

