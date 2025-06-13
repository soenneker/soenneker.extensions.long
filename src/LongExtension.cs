using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace Soenneker.Extensions.Long;

/// <summary>
/// A collection of helpful Long (64 bit integer) extension methods
/// </summary>
public static class LongExtension
{
    /// <summary>
    /// Converts a Unix timestamp to a <see cref="DateTime"/> in UTC.
    /// </summary>
    /// <remarks>
    /// This method extends the <see cref="long"/> type, allowing a Unix timestamp
    /// (which counts the number of seconds since the Unix Epoch at 00:00:00 UTC on 1 January 1970)
    /// to be directly converted into a <see cref="DateTime"/> object.
    /// The result is a UTC <see cref="DateTime"/> representing the same moment in time as the Unix timestamp.
    /// </remarks>
    /// <param name="unixTime">The Unix timestamp to convert, represented as the number of seconds since the Unix Epoch.</param>
    /// <returns>A UTC <see cref="DateTime"/> object representing the same moment in time as the specified Unix timestamp.</returns>
    /// <example>
    /// This example shows how to convert a Unix timestamp to a <see cref="DateTime"/>:
    /// <code>
    /// long unixTimestamp = 1588305600;
    /// DateTime dateTime = unixTimestamp.ToDateTimeFromUnixTime();
    /// Console.WriteLine(dateTime); // Output: 5/1/2020 12:00:00 AM (Depending on the system's time zone, output might vary)
    /// </code>
    /// </example>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime ToDateTimeFromUnixTime(this long unixTime)
    {
        return DateTimeOffset.FromUnixTimeSeconds(unixTime).UtcDateTime;
    }

    /// <summary>
    /// Converts the specified 64-bit signed integer to a 32-bit signed integer, throwing an <see cref="OverflowException"/>
    /// if the value is outside the range of the <see cref="Int32"/> type.
    /// </summary>
    /// <param name="value">The 64-bit signed integer to convert.</param>
    /// <returns>The 32-bit signed integer representation of the input value.</returns>
    /// <exception cref="OverflowException">
    /// Thrown when <paramref name="value"/> is less than <see cref="Int32.MinValue"/> or greater than <see cref="Int32.MaxValue"/>.
    /// </exception>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int ToInt(this long value)
    {
        // this cast will throw OverflowException if value is out of Int32 range
        return checked((int)value);
    }
}