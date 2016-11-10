using System;

interface IConstraint
{
    bool Check(Candidate c);

    String Name { get; }
}
