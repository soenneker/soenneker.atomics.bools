using Soenneker.Atomics.ValueBools;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Soenneker.Atomics.Bools;

/// <summary>
/// A lightweight atomic boolean wrapper implemented on top of <see cref="ValueAtomicBool"/>.
/// <para/>
/// This is a reference type so it can be safely shared without accidental struct copying.
/// </summary>
[DebuggerDisplay("{Value}")]
public sealed class AtomicBool
{
    private ValueAtomicBool _value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public AtomicBool(bool initialValue = false)
    {
        _value = new ValueAtomicBool(initialValue);
    }

    /// <summary>
    /// Reads the current value of the atomic boolean.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Read() => _value.Read();

    /// <summary>
    /// Writes a new value to the atomic boolean.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Write(bool value) => _value.Write(value);

    /// <summary>
    /// Atomically replaces the current value with <paramref name="value"/> and returns the previous value.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Exchange(bool value) => _value.Exchange(value);

    /// <summary>
    /// Atomically sets the value to <paramref name="newValue"/> if the current value equals <paramref name="expected"/>.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool CompareAndSet(bool expected, bool newValue) => _value.CompareAndSet(expected, newValue);

    /// <summary>
    /// Gets or sets the current value of the atomic boolean.
    /// </summary>
    public bool Value
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => _value.Value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => _value.Value = value;
    }

    /// <summary>
    /// Attempts to atomically transition the value from false to true.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TrySetTrue() => _value.TrySetTrue();

    /// <summary>
    /// Attempts to atomically transition the value from true to false.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TrySetFalse() => _value.TrySetFalse();

    /// <summary>
    /// Returns a string representation of the current instance.
    /// </summary>
    /// <returns>The result of the operation.</returns>
    public override string ToString() => Read() ? "true" : "false";
}
