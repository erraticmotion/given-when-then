// <copyright file="GivenWhenThen.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Fixtures
{
    using System.Diagnostics.CodeAnalysis;
    using ErraticMotion.Test.Fixtures.Containers;
    using NUnit.Framework;

    /// <summary>
    /// Given-When-Then, a pattern for arranging and formatting code in
    /// unit, integration and customer acceptance test fixtures.
    /// </summary>
    [TestFixture]
    public abstract class GivenWhenThen : GivenWhenThenBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GivenWhenThen"/> class.
        /// </summary>
        protected GivenWhenThen()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GivenWhenThen"/> class.
        /// </summary>
        /// <param name="fixtureIoC">The fixture io c.</param>
        protected GivenWhenThen(IFixtureKernel fixtureIoC)
            : base(fixtureIoC)
        {
        }

        /// <inheritdoc />
        [SetUp]
        public override void TestSetup()
        {
            base.TestSetup();
            this.Given();
            this.When();
        }

        /// <summary>
        /// Cleans the test environment after the test methods have been executed
        /// and also clears the IoC cache.
        /// </summary>
        [TearDown]
        public void TestCleanup()
        {
            this.Cleanup();
        }

        /// <summary>
        /// Extension point for sub-classes to arrange all necessary preconditions and inputs.
        /// </summary>
        protected virtual void Given()
        {
        }

        /// <summary>
        /// Extension point for sub-classes to act on the object or method under test.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", MessageId = "When", Justification = "Given When Then")]
        protected virtual void When()
        {
        }

        /// <summary>
        /// Extension point for sub-classes to cleans up the environment after the test is verified.
        /// </summary>
        protected virtual void Cleanup()
        {
        }
    }
}