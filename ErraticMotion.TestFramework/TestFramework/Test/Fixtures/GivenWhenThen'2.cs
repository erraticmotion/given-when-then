// <copyright file="GivenWhenThen'2.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Fixtures
{
    using ErraticMotion.Test.Fixtures.Containers;
    using NUnit.Framework;

    /// <summary>
    /// Given-When-Then, a pattern for arranging and formatting code in
    /// unit, integration and customer acceptance test fixtures.
    /// </summary>
    /// <typeparam name="TSut">The Software/System Under Test.</typeparam>
    /// <typeparam name="TFixtureKernel">The IoC fixture kernel.</typeparam>
    [TestFixture]
    public abstract class GivenWhenThen<TSut, TFixtureKernel> : GivenWhenThen<TSut>
        where TSut : class
        where TFixtureKernel : IFixtureKernel, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GivenWhenThen{TSut, TFixtureKernel}"/> class.
        /// </summary>
        protected GivenWhenThen()
            : base(new TFixtureKernel())
        {
        }
    }
}