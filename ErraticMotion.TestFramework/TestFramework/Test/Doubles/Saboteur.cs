// <copyright file="Saboteur.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Doubles
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq.Expressions;
    using Moq;

    internal class Saboteur<TDependency, TException> : ISaboteurVerify<TDependency>
        where TDependency : class
        where TException : Exception, new()
    {
        private readonly Expression<Action<TDependency>> expression;
        private readonly Mock<TDependency> mock = new Mock<TDependency>();
        private TException ex = new TException();

        public Saboteur(Expression<Action<TDependency>> expression)
        {
            this.expression = expression;
        }

        public TDependency Dependency => this.Build();

        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Test code, ensure that an exception is thrown and handled.")]
        public bool Thrown
        {
            get
            {
                try
                {
                    this.mock.Verify(this.expression, Times.AtLeastOnce);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public Saboteur<TDependency, TException> WithException(string message)
        {
            this.ex = Activator.CreateInstance(typeof(TException), message) as TException;
            return this;
        }

        private TDependency Build()
        {
            this.mock.Setup(this.expression).Throws(this.ex).Verifiable();
            return this.mock.Object;
        }
    }
}