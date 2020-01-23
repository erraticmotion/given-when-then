// <copyright file="FixtureKernelTestDoubleExtensions.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Fixtures.Containers
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq.Expressions;
    using Doubles;

    /// <summary>
    /// Contains extension methods for the <see cref="IFixtureKernel"/> interface
    /// that creates registers <see cref="Doubles.ITestDouble{T}"/>
    /// types and add them into the underlying IoC container.
    /// </summary>
    public static class FixtureKernelTestDoubleExtensions
    {
        /// <summary>
        /// Binds the test double builder into the underlying IoC container.
        /// </summary>
        /// <typeparam name="T">The type of interface to add to the underlying IoC container.</typeparam>
        /// <param name="kernel">The kernel.</param>
        /// <param name="builder">The test double builder.</param>
        public static void BindBuilder<T>(this IFixtureKernel kernel, ITestDoubleBuilder<T> builder)
            where T : class
        {
            kernel.Bind(builder.Build());
        }

        /// <summary>
        /// Binds the specified factory into the underlying IoC container.
        /// </summary>
        /// <typeparam name="T">The type of interface to add to the underlying IoC container.</typeparam>
        /// <param name="kernel">The kernel.</param>
        /// <param name="factory">The factory.</param>
        /// <returns>An object that support the <typeparamref name="T"/> interface.</returns>
        public static T Bind<T>(this IFixtureKernel kernel, Func<IFixtureKernel, T> factory)
            where T : class
        {
            var result = factory(kernel);
            kernel.Bind(result);
            return result;
        }

        /// <summary>
        /// Creates and binds the dummy into the underlying IoC container.
        /// </summary>
        /// <typeparam name="T">The type of interface to create the dummy for.</typeparam>
        /// <param name="kernel">The test fixture kernel container.</param>
        /// <returns>An object that support the <typeparamref name="T"/> interface.</returns>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "Well understood IoC binding syntax")]
        public static T BindDummy<T>(this IFixtureKernel kernel)
            where T : class
        {
            var result = TestDouble.For<T>().Dummy();
            kernel.Bind(result);
            return result;
        }

        /// <summary>
        /// Creates and binds a test spy into the underlying IoC container.
        /// </summary>
        /// <typeparam name="T">The type of interface to create the test spy for.</typeparam>
        /// <typeparam name="TIndirectOutput">The type of the indirect output.</typeparam>
        /// <param name="kernel">The test fixture kernel container.</param>
        /// <param name="expression">The expression used to bind the test spy to capture the indirect outputs of the software under test.</param>
        /// <returns>An object that supports the <see cref="ITestSpy{T, TIndirectOutput}"/> interface.</returns>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "Well understood IoC binding syntax")]
        public static ITestSpy<T, TIndirectOutput> ReplaceWithTestSpy<T, TIndirectOutput>(
            this IFixtureKernel kernel,
            Expression<Action<T>> expression)
            where T : class
            where TIndirectOutput : class
        {
            var result = TestDouble.Spy<T, TIndirectOutput>(expression);
            kernel.Bind(result.Dependency);
            return result;
        }

        /// <summary>
        /// <para>
        /// Creates, binds, and returns a<see cref="ISaboteurVerify{T}" /> Test Double.
        /// </para>
        /// </summary>
        /// <typeparam name = "T" >
        /// The type of interface to create a saboteur for.
        /// </typeparam>
        /// <typeparam name = "TException" >
        /// The type of the exception to raise when the behaviour specified in the<paramref name="expression"/> is met.
        /// </typeparam>
        /// <param name = "kernel" >
        /// The test fixture kernel container to add the saboteur.
        /// </param>
        /// <param name = "expression" >
        /// The expression that when met will cause the exception specified by the<typeparamref name="TException"/> to be raised.
        /// </param>
        /// <returns>
        /// An object that supports the<see cref= "ISaboteurVerify{T}" /> interface.
        ///     </returns>
        /// <remarks>
        /// The new binding will replace any existing binding for the<typeparamref name="T"/> type
        /// within the underlying IoC container.
        /// </remarks>
        /// <example>
        /// <para>
        /// The following code fragment demonstrates how to specify a test double saboteur that will raise an exception
        /// when a method on it's interface is called.
        /// </para>
        /// <code language = "c#" >
        /// protected override void Bind(IFixtureKernel fixtureKernel)
        /// {
        ///   fixtureKernel.ReplaceWithSaboteur&lt;IBindable, ArgumentOutOfRangeException&gt;(x => x.MethodImpl());
        ///   var result = fixtureKernel.Get&lt;IBindable&gt;();
        ///   Should.Throw&lt;ArgumentOutOfRangeException&gt;(() => result.MethodImpl());
        /// }
        /// </code>
        /// <para>
        /// The saboteur is injected into the underlying test fixture IoC container.When an instance of the IBindable
        /// interface is retrieved from the container, and the IBindable.MethodImpl() method called, the
        /// ArgumentOutOfRangeException exception is raised.
        /// </para>
        /// <para>
        /// The following code fragment demonstrates how to verify that a test double saboteur has been raised.
        /// </para>
        /// <code language = "c#" >
        /// protected override void Bind(IFixtureKernel fixtureKernel)
        /// {
        ///   var verifiable = fixtureKernel.ReplaceWithSaboteur&lt;IBindable, ArgumentOutOfRangeException&gt;(x => x.MethodImpl());
        ///   var result = fixtureKernel.Get&lt;IBindable&gt;();
        ///   try
        ///   {
        ///     // Simulate the sabotuer being called within a client, and the client handling the exception.
        ///     result.MethodImpl();
        ///   }
        ///   catch { }
        ///
        ///   // check to ensure the exception was thrown.
        ///   verifiable.Thrown.Should().BeTrue();
        /// }
        /// </code>
        /// </example>
        /// <seealso cref ="Doubles.ISaboteurVerify{T}" />
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "Well understood IoC binding syntax")]
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "Well understood IoC binding syntax")]
        public static ISaboteurVerify<T> ReplaceWithSaboteur<T, TException>(
            this IFixtureKernel kernel,
            Expression<Action<T>> expression)
            where T : class
            where TException : Exception, new()
        {
            var result = TestDouble.For<T>().Verifiable.Saboteur<TException>(expression);
            kernel.Bind(result.Dependency);
            return result;
        }

        /// <summary>
        /// <para>
        /// Creates, binds, and returns a<see cref="ISaboteurVerify{T}" /> Test Double.
        /// </para>
        /// </summary>
        /// <typeparam name = "T" >
        /// The type of interface to create a saboteur for.
        /// </typeparam>
        /// <typeparam name = "TException" >
        /// The type of the exception to raise when the behaviour specified in the<paramref name="expression"/> is met.
        /// </typeparam>
        /// <param name = "kernel" >
        /// The test fixture kernel container to add the saboteur.
        /// </param>
        /// <param name = "expression" >
        /// The expression that when met will cause the exception specified by the<typeparamref name="TException"/> to be raised.
        /// </param>
        /// <param name="message">The exception message value.</param>
        /// <returns>
        /// An object that supports the<see cref= "ISaboteurVerify{T}" /> interface.
        ///     </returns>
        /// <remarks>
        /// The new binding will replace any existing binding for the<typeparamref name="T"/> type
        /// within the underlying IoC container.
        /// </remarks>
        /// <example>
        /// <para>
        /// The following code fragment demonstrates how to specify a test double saboteur that will raise an exception
        /// when a method on it's interface is called.
        /// </para>
        /// <code language = "c#" >
        /// protected override void Bind(IFixtureKernel fixtureKernel)
        /// {
        ///   fixtureKernel.ReplaceWithSaboteur&lt;IBindable, ArgumentOutOfRangeException&gt;(x => x.MethodImpl());
        ///   var result = fixtureKernel.Get&lt;IBindable&gt;();
        ///   Should.Throw&lt;ArgumentOutOfRangeException&gt;(() => result.MethodImpl());
        /// }
        /// </code>
        /// <para>
        /// The saboteur is injected into the underlying test fixture IoC container.When an instance of the IBindable
        /// interface is retrieved from the container, and the IBindable.MethodImpl() method called, the
        /// ArgumentOutOfRangeException exception is raised.
        /// </para>
        /// <para>
        /// The following code fragment demonstrates how to verify that a test double saboteur has been raised.
        /// </para>
        /// <code language = "c#" >
        /// protected override void Bind(IFixtureKernel fixtureKernel)
        /// {
        ///   var verifiable = fixtureKernel.ReplaceWithSaboteur&lt;IBindable, ArgumentOutOfRangeException&gt;(x => x.MethodImpl());
        ///   var result = fixtureKernel.Get&lt;IBindable&gt;();
        ///   try
        ///   {
        ///     // Simulate the sabotuer being called within a client, and the client handling the exception.
        ///     result.MethodImpl();
        ///   }
        ///   catch { }
        ///
        ///   // check to ensure the exception was thrown.
        ///   verifiable.Thrown.Should().BeTrue();
        /// }
        /// </code>
        /// </example>
        /// <seealso cref ="Doubles.ISaboteurVerify{T}" />
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "Well understood IoC binding syntax")]
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "Well understood IoC binding syntax")]
#pragma warning disable 1573 // documentation for arguments within xml_include.xml
        public static ISaboteurVerify<T> ReplaceWithSaboteur<T, TException>(
            this IFixtureKernel kernel,
            Expression<Action<T>> expression,
            string message)
#pragma warning restore 1573
            where T : class
            where TException : Exception, new()
        {
            var result = TestDouble.For<T>().Verifiable.Saboteur<TException>(expression, message);
            kernel.Bind(result.Dependency);
            return result;
        }
    }
}