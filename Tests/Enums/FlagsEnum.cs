using System;

namespace Tests.Enums
{
    [Flags]
    public enum FlagsEnum
    {
        None = 0,
        Flag0 = 1 << 0,
        Flag1 = 1 << 1,
        Flag2 = 1 << 2
    }
}