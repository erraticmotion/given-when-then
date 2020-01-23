// <copyright file="GivenWhenThenBase.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Fixtures
{
    using System;

    using Containers;
    using NUnit.Framework;

    /// <summary>
    /// Acts as a base class for Given-When-Then test fixture types.
    /// </summary>
    [TestFixture]
    public abstract class GivenWhenThenBase : IDisposable
    {
        /// <summary>
        /// The kernel
        /// </summary>
        private readonly IFixtureKernel kernel;

        /// <summary>
        /// Indicated whether this instance has been disposed
        /// </summary>
        private bool disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="GivenWhenThenBase"/> class.
        /// </summary>
        protected GivenWhenThenBase()
            : this(new NinjectFixtureKernel())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GivenWhenThenBase" /> class.
        /// </summary>
        /// <param name="kernel">The fixture IoC kernel container.</param>
        protected GivenWhenThenBase(IFixtureKernel kernel)
        {
            this.kernel = kernel;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="GivenWhenThenBase"/> class.
        /// </summary>
        ~GivenWhenThenBase()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Gets the kernel.
        /// </summary>
        protected IFixtureKernel Kernel => this.kernel;

        /// <summary>
        /// Called once before any tests are executed.
        /// </summary>
        [OneTimeSetUp]
        public virtual void TestFixtureSetup()
        {
            this.Background(this.Kernel);
        }

        /// <summary>
        /// Creates a test fixture by first binding objects against the IoC container,
        /// arranging all pre-conditions and inputs, and then acting on the SUT.
        /// </summary>
        [SetUp]
        public virtual void TestSetup()
        {
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Extension point for sub-classes to bind to the IoC kernel.
        /// </summary>
        /// <param name="container">The fixture kernel IoC container.</param>
        protected virtual void Background(IFixtureKernel container)
        {
        }

        /// <summary>
        /// Gets an instance of the type specified by the<typeparamref name="T"/> from the underlying IoC container.
        /// </summary>
        /// <typeparam name = "T" >The type of interface to be returned.</typeparam>
        /// <returns>
        /// An object that implements the <typeparamref name = "T" /> from the underlying IoC container.
        /// </returns>
        protected T Get<T>()
            where T : class
        {
            return this.kernel.Get<T>();
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged
        /// resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.kernel.Dispose();
                }

                this.disposed = true;
            }
        }
    }
}