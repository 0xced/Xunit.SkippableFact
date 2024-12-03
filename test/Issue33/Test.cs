// Copyright (c) Andrew Arnott. All rights reserved.
// Licensed under the Microsoft Public License (Ms-PL). See LICENSE.txt file in the project root for full license information.

using System.Diagnostics.CodeAnalysis;

namespace Issue33;

[SuppressMessage("Style", "IDE0028:Simplify collection initialization", Justification = "How the theory data is initialized is the point of this issue")]
[SuppressMessage("ReSharper", "UseCollectionExpression", Justification = "How the theory data is initialized is the point of this issue")]
public class Test
{
    public static TheoryData<IEnumerable<string>> WorkingData() => new() { Array.Empty<string>() };

    public static TheoryData<IEnumerable<string>> FailingData() => new() { Enumerable.Empty<string>() };

    [SkippableTheory]
    [MemberData(nameof(WorkingData))]
    public void WorkingTest(IEnumerable<string> ignored)
    {
        _ = ignored;
        throw new SkipException();
    }

    [SkippableTheory]
    [MemberData(nameof(FailingData))]
    public void FailingTest(IEnumerable<string> ignored)
    {
        _ = ignored;
        throw new SkipException();
    }
}
