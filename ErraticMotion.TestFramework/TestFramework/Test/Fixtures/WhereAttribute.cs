// <copyright file="WhereAttribute.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Fixtures
{
    /// <summary>
    /// Syntactic sugar for Give-When-Then test fixtures that use the NUnit Framework.
    /// </summary>
    public sealed class WhereAttribute : NUnit.Framework.TestCaseAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhereAttribute"/> class.
        /// </summary>
        /// <param name="arguments">A collection of test case arguments.</param>
        public WhereAttribute(params object[] arguments)
            : base(arguments)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhereAttribute"/> class.
        /// </summary>
        /// <param name="arg">A test case argument.</param>
        public WhereAttribute(object arg)
            : base(arg)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhereAttribute"/> class.
        /// </summary>
        /// <param name="arg1">The first test case argument.</param>
        /// <param name="arg2">The second test case argument.</param>
        public WhereAttribute(object arg1, object arg2)
            : base(arg1, arg2)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhereAttribute"/> class.
        /// </summary>
        /// <param name="arg1">The first test case argument.</param>
        /// <param name="arg2">The second test case argument.</param>
        /// <param name="arg3">The third test case argument.</param>
        public WhereAttribute(object arg1, object arg2, object arg3)
            : base(arg1, arg2, arg3)
        {
        }
    }
}