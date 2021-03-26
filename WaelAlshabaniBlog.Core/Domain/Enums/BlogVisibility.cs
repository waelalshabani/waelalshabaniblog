using System;

namespace WaelAlshabaniBlog.Core.Domain
{
    [Flags]
    public enum BlogVisibility
    {
        SuperAdmin = 1,
        Admin = 2,
        Publisher = 4,
        Editor = 8,
    }
}
