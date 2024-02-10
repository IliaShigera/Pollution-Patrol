﻿#pragma warning disable CS8602 // Dereference of a possibly null reference.

namespace PollutionPatrol.BuildingBlocks.Domain;

[SuppressMessage("Design", "CA1062:Validate arguments of public methods")]
[SuppressMessage("Blocker Code Smell", "S3875:\"operator==\" should not be overloaded on reference types")]
public abstract class ValueObject
{
    protected static bool EqualOperator(ValueObject? left, ValueObject? right)
    {
        if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
            return false;

        return ReferenceEquals(left, right) || left.Equals(right);
    }

    protected static bool NotEqualOperator(ValueObject left, ValueObject right) => !EqualOperator(left, right);

    protected abstract IEnumerable<object> GetEqualityComponents();

    public override bool Equals(object? obj)
    {
        if (obj == null || obj.GetType() != GetType())
            return false;

        var other = (ValueObject)obj;

        return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }

    public override int GetHashCode() =>
        GetEqualityComponents()
            .Select(x => x.GetHashCode())
            .Aggregate((x, y) => x ^ y);

    public static bool operator ==(ValueObject one, ValueObject two) => EqualOperator(one, two);

    public static bool operator !=(ValueObject one, ValueObject two) => NotEqualOperator(one, two);
}