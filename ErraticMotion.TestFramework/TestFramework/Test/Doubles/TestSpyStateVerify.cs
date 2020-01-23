// <copyright file="TestSpyStateVerify.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Doubles
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    internal class TestSpyStateVerify<TDoC, TIndirectOutput>
        : TestSpy<TDoC, TIndirectOutput>, IStateVerify<TDoC, TIndirectOutput>
        where TDoC : class
        where TIndirectOutput : class
    {
        public TestSpyStateVerify(Expression<Action<TDoC>> expression)
            : base(expression)
        {
        }

        public int Count => this.IndirectOutput.Count;

        public bool Verify(Func<TIndirectOutput, bool> expectation)
        {
            return this.IndirectOutput.Any(expectation);
        }
    }
}