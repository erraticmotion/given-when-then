// <copyright file="TestDoubleCore.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Doubles
{
    using System;
    using System.Linq.Expressions;
    using Moq;

    internal class TestDoubleCore<TDependency> : ITestDouble<TDependency>
        where TDependency : class
    {
        public IVerifiable<TDependency> Verifiable => new TestDoubleVerify<TDependency>();

        public Mock<TDependency> Mock => CreateMock();

        public TDependency Saboteur<TException>(Expression<Action<TDependency>> expression)
            where TException : Exception, new()
        {
            return new Saboteur<TDependency, TException>(expression).Dependency;
        }

        public TDependency Saboteur<TException>(Expression<Action<TDependency>> expression, string message)
            where TException : Exception, new()
        {
            return new Saboteur<TDependency, TException>(expression).WithException(message).Dependency;
        }

        public ITestSpy<TDependency, TIndirectOutput> Spy<TIndirectOutput>(Expression<Action<TDependency>> expression)
            where TIndirectOutput : class
        {
            return new TestSpy<TDependency, TIndirectOutput>(expression);
        }

        public TDependency Stub<TProperty>(Expression<Func<TDependency, TProperty>> expression, TProperty value)
        {
            var result = CreateMock();
            result.SetupGet(expression).Returns(value);
            return result.Object;
        }

        public TDependency Dummy()
        {
            return CreateMock().Object;
        }

        private static Mock<TDependency> CreateMock()
        {
#if STRICT
            return new Mock<TDependency>(MockBehavior.Strict);
#else
            return new Mock<TDependency>();
#endif
        }
    }
}