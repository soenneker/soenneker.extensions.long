using System;

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
    public static DateTime ToDateTimeFromUnixTime(this long unixTime)
    {
        return DateTimeOffset.FromUnixTimeSeconds(unixTime).UtcDateTime;
    }
}
