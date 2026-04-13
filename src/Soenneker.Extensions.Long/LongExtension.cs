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
        return unixTime.ToDateTimeOffsetFromUnixTime()
                       .UtcDateTime;
    }

    /// <summary>
    /// Converts a Unix time, expressed as the number of seconds that have elapsed since 1970-01-01T00:00:00Z (the Unix
    /// epoch), to a corresponding <see cref="DateTimeOffset"/> value.
    /// </summary>
    /// <remarks>If <paramref name="unixTime"/> is less than -62,135,596,800 or greater than 253,402,300,799,
    /// an <see cref="ArgumentOutOfRangeException"/> is thrown.</remarks>
    /// <param name="unixTime">The number of seconds that have elapsed since 1970-01-01T00:00:00Z (the Unix epoch).</param>
    /// <returns>A <see cref="DateTimeOffset"/> representing the specified Unix time.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTimeOffset ToDateTimeOffsetFromUnixTime(this long unixTime)
    {
        return DateTimeOffset.FromUnixTimeSeconds(unixTime);
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

    /// <summary>
    /// Returns the number of decimal digits in the specified <see cref="long"/> value.
    /// </summary>
    /// <param name="value">The value whose digits should be counted.</param>
    /// <returns>
    /// The number of digits in the absolute value of <paramref name="value"/>.
    /// For example, -123 returns 3, and 0 returns 1.
    /// </returns>
    /// <remarks>
    /// This method handles negative values by evaluating their absolute value.
    /// Special handling is applied for <see cref="long.MinValue"/>, which contains 19 digits.
    /// </remarks>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int DigitCount(this long value)
    {
        if (value >= 0)
            return DigitCountPositiveOnly(value);

        if (value == long.MinValue)
            return 19;

        return DigitCountPositiveOnly(-value);
    }

    /// <summary>
    /// Returns the number of decimal digits in a non-negative <see cref="long"/> value.
    /// </summary>
    /// <param name="value">
    /// A non-negative value (zero or greater) whose digits should be counted.
    /// </param>
    /// <returns>
    /// The number of digits in <paramref name="value"/>.
    /// For example, 0 returns 1, and 123 returns 3.
    /// </returns>
    /// <remarks>
    /// This method assumes <paramref name="value"/> is non-negative and does not perform validation.
    /// Passing a negative value will result in undefined or incorrect behavior.
    /// Use this method in performance-critical paths where the input is guaranteed to be non-negative.
    /// </remarks>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int DigitCountPositiveOnly(this long value)
    {
        if (value < 10L)
            return 1;
        if (value < 100L)
            return 2;
        if (value < 1_000L)
            return 3;
        if (value < 10_000L)
            return 4;
        if (value < 100_000L)
            return 5;
        if (value < 1_000_000L)
            return 6;
        if (value < 10_000_000L)
            return 7;
        if (value < 100_000_000L)
            return 8;
        if (value < 1_000_000_000L)
            return 9;
        if (value < 10_000_000_000L)
            return 10;
        if (value < 100_000_000_000L)
            return 11;
        if (value < 1_000_000_000_000L)
            return 12;
        if (value < 10_000_000_000_000L)
            return 13;
        if (value < 100_000_000_000_000L)
            return 14;
        if (value < 1_000_000_000_000_000L)
            return 15;
        if (value < 10_000_000_000_000_000L)
            return 16;
        if (value < 100_000_000_000_000_000L)
            return 17;
        if (value < 1_000_000_000_000_000_000L)
            return 18;

        return 19;
    }
}