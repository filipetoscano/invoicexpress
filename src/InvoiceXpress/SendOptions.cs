﻿namespace InvoiceXpress;

/// <summary />
public enum SendOptions
{
    /// <summary>
    /// Original only.
    /// </summary>
    OriginalOnly = 1,

    /// <summary>
    /// Original, and duplicate.
    /// </summary>
    Duplicate = 2,

    /// <summary>
    /// Original, duplicate and triplicate.
    /// </summary>
    Triplicate = 3,
}
