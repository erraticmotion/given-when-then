// <copyright file="TestDoubleVerify.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Doubles
{
    using System;
    using System.Linq.Expressions;

    internal class TestDoubleVerify<TDependency> : IVerifiable<TDependency>
        where TDependency : class
    {
        public IStateVerify<TDependency, TIndirectOutput> Spy<TIndirectOutput>(Expression<Action<TDependency>> expression)
            where TIndirectOutput : class
        {
            return new TestSpyStateVerify<TDependency, TIndirectOutput>(expression);
        }

        public ISaboteurVerify<TDependency> Saboteur<TException>(Expression<Action<TDependency>> expression)
            where TException : Exception, new()
        {
            return new Saboteur<TDependency, TException>(expression);
        }

        public ISaboteurVerify<TDependency> Saboteur<TException>(Expression<Action<TDependency>> expression, string message)
            where TException : Exception, new()
        {
            return new Saboteur<TDependency, TException>(expression).WithException(message);
        }
    }
}