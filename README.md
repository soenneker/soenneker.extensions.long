[![](https://img.shields.io/nuget/v/soenneker.extensions.long.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.long/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.long/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.long/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.extensions.long.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.long/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.long/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.long/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Extensions.Long
Unix-time conversion, checked `Int32` conversion, and allocation-free decimal digit counts for `long` values.

## Installation

```bash
dotnet add package Soenneker.Extensions.Long
```

## Convert Unix seconds

```csharp
using Soenneker.Extensions.Long;

long unixSeconds = 1_588_305_600;

DateTime utc = unixSeconds.ToDateTimeFromUnixTime();
DateTimeOffset instant = unixSeconds.ToDateTimeOffsetFromUnixTime();
```

Both methods interpret the value as seconds since `1970-01-01T00:00:00Z`, not milliseconds. `ToDateTimeFromUnixTime()` returns a `DateTime` whose `Kind` is `Utc`; `ToDateTimeOffsetFromUnixTime()` returns an offset-zero value for the same instant.

The supported Unix-second range is `-62,135,596,800` through `253,402,300,799`. Values outside it throw `ArgumentOutOfRangeException`.

## Narrow to an integer

```csharp
int count = longCount.ToInt();
```

`ToInt()` performs a checked conversion. Values below `Int32.MinValue` or above `Int32.MaxValue` throw `OverflowException`; they are not truncated or wrapped.

## Count decimal digits

```csharp
int digits = (-12345L).DigitCount(); // 5
int zeroDigits = 0L.DigitCount();    // 1
```

`DigitCount()` counts digits in the absolute numeric value and does not count the minus sign. It handles the full `long` range, including `long.MinValue`, without converting to a string.

When the caller already guarantees a non-negative value, `DigitCountPositiveOnly()` exposes the shorter fast path:

```csharp
int digits = positiveValue.DigitCountPositiveOnly();
```

`DigitCountPositiveOnly()` does not validate its precondition; negative inputs produce an incorrect result. Use `DigitCount()` unless non-negativity is established by the surrounding logic.
