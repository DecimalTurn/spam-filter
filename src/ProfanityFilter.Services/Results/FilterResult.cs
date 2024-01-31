﻿// Copyright (c) David Pine. All rights reserved.
// Licensed under the MIT License.

namespace ProfanityFilter.Services.Results;

/// <summary>
/// Represents the result of a filter operation.
/// </summary>
/// <param name="Input">The value to check for profane content.</param>
/// <param name="Steps">The steps fo</param>
public record class FilterResult(
    string Input,
    List<FilterStep>? Steps = null)
{
    /// <summary>
    /// Gets a value indicating whether the input is filtered.
    /// </summary>
    [MemberNotNullWhen(true, nameof(Steps), nameof(FinalOutput))]
    public bool IsFiltered
        => FinalOutput is not null;

    /// <summary>
    /// Gets the final result of a filter operation. If the input is not
    /// filtered, <see langword="null"/> is returned.
    /// </summary>
    public string? FinalOutput
        => Steps?.LastOrDefault(static step => step.IsFiltered)?.Output;
}
