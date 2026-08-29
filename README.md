[![](https://img.shields.io/nuget/v/soenneker.extensions.long.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.long/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.long/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.long/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.extensions.long.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.long/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.long/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.long/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Extensions.Long
A collection of helpful Long (64 bit integer) extension methods.

## Installation

```bash
dotnet add package Soenneker.Extensions.Long
```

## Quick start

```csharp
using Soenneker.Extensions.Long;

long unixTime = 42;
var result = unixTime.ToDateTimeFromUnixTime();
```

## Common operations

- `ToDateTimeFromUnixTime()` - Converts a Unix timestamp to a `DateTime` in UTC. Returns a UTC `DateTime` object representing the same moment in time as the specified Unix timestamp. This method extends the `long` type, allowing a Unix timestamp (which counts the number of seconds since the Unix Epoch at 00:00:00 UTC on 1 January 1970) to be directly converted into a `DateTime` object.
- `ToDateTimeOffsetFromUnixTime()` - Converts a Unix time, expressed as the number of seconds that have elapsed since 1970-01-01T00:00:00Z (the Unix epoch), to a corresponding `DateTimeOffset` value. If `unixTime` is less than -62,135,596,800 or greater than 253,402,300,799, an `ArgumentOutOfRangeException` is thrown.
- `ToInt()` - Converts the specified 64-bit signed integer to a 32-bit signed integer, throwing an `OverflowException` if the value is outside the range of the `Int32` type.
- `DigitCount()` - Returns the number of decimal digits in the specified `long` value.
- `DigitCountPositiveOnly()` - Returns the number of decimal digits in a non-negative `long` value. This method assumes `value` is non-negative and does not perform validation.
