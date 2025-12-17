using System.Runtime.CompilerServices;
using System.Threading;
using Soenneker.Atomics.Bools.Abstract;

namespace Soenneker.Atomics.Bools;

///<inheritdoc cref="IAtomicBool"/>
public sealed class AtomicBool : IAtomicBool
{
    private const int _false = 0;
    private const int _true = 1;

    private int _flag;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public AtomicBool(bool initialValue = false) => _flag = initialValue ? _true : _false;

    public bool Value
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => Volatile.Read(ref _flag) != _false;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Volatile.Write(ref _flag, value ? _true : _false);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool CompareAndSet(bool expected, bool newValue)
    {
        int e = expected ? _true : _false;
        int n = newValue ? _true : _false;
        return Interlocked.CompareExchange(ref _flag, n, e) == e;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TrySetTrue() => Interlocked.Exchange(ref _flag, _true) == _false;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TrySetFalse() => Interlocked.Exchange(ref _flag, _false) == _true;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Exchange(bool newValue) => Interlocked.Exchange(ref _flag, newValue ? _true : _false) == _true;

    public bool IsTrue
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => Value;
    }

    public bool IsFalse
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => !Value;
    }

    public override string ToString() => Value ? "True" : "False";
}