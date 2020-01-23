// <copyright file="TestSpy.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Doubles
{
    using System;
    using System.Linq.Expressions;
    using Moq;

    internal class TestSpy<TDoC, TIndirectOutput> : TestSpyBase<TIndirectOutput>, ITestSpy<TDoC, TIndirectOutput>
        where TDoC : class
        where TIndirectOutput : class
    {
        private readonly MethodCallExpression expressionBody;

        public TestSpy(Expression<Action<TDoC>> expression)
        {
            this.expressionBody = (MethodCallExpression)expression.Body;
            var spy = new Mock<TDoC>();
            spy.Setup(expression).Callback<TIndirectOutput>(this.CallBack);
            this.Dependency = spy.Object;
        }

        public TDoC Dependency { get; }

        public void ActAsWiretapFor(TDoC destination)
        {
            this.Received += (sender, e) => this.expressionBody.Method.Invoke(destination, new object[] { e.Value });
        }

        protected virtual void CallBack(TIndirectOutput item)
        {
            this.RaiseAddIndirectOutputReceived(item);
        }
    }
}