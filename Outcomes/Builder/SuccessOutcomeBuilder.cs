﻿using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Ether.Outcomes.Builder
{
    /// <summary>
    /// Uses the builder pattern to create a fluent interface for success scenarios.
    /// </summary>
    public class SuccessOutcomeBuilder<TValue> : OutcomeResult<TValue>
    {
        internal SuccessOutcomeBuilder(bool success) : base(success)
        {
        }

        /// <summary>
        /// Add a string to the end of the outcome's message collection.
        /// </summary>
        /// <param name="message">String to add.</param>
        /// <param name="paramList">Shorthand for String.Format</param>
        /// <returns></returns>
        [StringFormatMethod("message")]
        public SuccessOutcomeBuilder<TValue> WithMessage(string message, params object[] paramList)
        {
            message = string.Format(message, paramList);

            base.Messages.Add(message);
            return this;
        }

        /// <summary>
        /// Append a list of strings to the end of the outcome's message collection.
        /// </summary>
        /// <param name="messages">The strings to add.</param>
        /// <returns></returns>
        public SuccessOutcomeBuilder<TValue> WithMessage(IEnumerable<string> messages)
        {
            if (messages == null)
                return this;

            base.Messages.AddRange(messages);
            return this;
        }

        /// <summary>
        /// Sets the value for a success outcome. The outcome object is just a wrapper for the value.
        /// </summary>
        /// <param name="value">Specifies the value to wrap.</param>
        /// <returns></returns>
        public SuccessOutcomeBuilder<TValue> WithValue(TValue value)
        {
            base.Value = value;
            return this; 
        }

        /// <summary>
        /// (optional) Sets the StatusCode, which is an additional piece of metadata you can use for your own purposes.
        /// </summary>
        public SuccessOutcomeBuilder<TValue> WithStatusCode(int? statusCode)
        {
            base.StatusCode = statusCode;
            return this;
        }
    }
}
