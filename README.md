[![](https://img.shields.io/nuget/v/soenneker.atomics.bools.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.atomics.bools/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.atomics.bools/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.atomics.bools/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.atomics.bools.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.atomics.bools/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.atomics.bools/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.atomics.bools/actions/workflows/codeql.yml)

# Soenneker.Atomics.Bools

A lightweight atomic boolean wrapper implemented on top of `ValueAtomicBool`. This is a reference type so it can be safely shared without accidental struct copying.

## Install

```bash
dotnet add package Soenneker.Atomics.Bools
```

## What you get

- `AtomicBool` — A lightweight atomic boolean wrapper implemented on top of `ValueAtomicBool`. This is a reference type so it can be safely shared without accidental struct copying.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `AtomicBool.Read()` | Reads the current value of the atomic boolean. | true if reads the current value of the atomic boolean; otherwise, false. |
| `AtomicBool.Write(value)` | Writes a new value to the atomic boolean. | Returns no value; the requested change is complete when the method returns. |
| `AtomicBool.Exchange(value)` | Atomically replaces the current value with `value` and returns the previous value. | true if atomically replaces the current value with and returns the previous value; otherwise, false. |
| `AtomicBool.CompareAndSet(expected, newValue)` | Atomically sets the value to `newValue` if the current value equals `expected`. | true if atomically sets the value to if the current value equals; otherwise, false. |
| `AtomicBool.Value` | Gets or sets the current value of the atomic boolean. | Gets or sets the current value of the atomic boolean. |
| `AtomicBool.TrySetTrue()` | Attempts to atomically transition the value from false to true. | true if the requested update was applied; otherwise, false. |
| `AtomicBool.TrySetFalse()` | Attempts to atomically transition the value from true to false. | true if the requested update was applied; otherwise, false. |
| `AtomicBool.ToString()` | Returns a string representation of the current instance. | The result of the operation. |
