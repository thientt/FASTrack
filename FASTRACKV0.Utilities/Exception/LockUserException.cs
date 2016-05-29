// ***********************************************************************
// Assembly         : FASTrack
// Author           : tranthiencdsp@gmail.com
// Created          : 02-25-2016
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 03-13-2016
// ***********************************************************************
// <copyright file="LockUserException.cs" company="Atmel">
//     Copyright © Atmel 2016
// </copyright>
// <summary></summary>
// **********************************************************************

using System;

/// <summary>
/// 
/// </summary>
namespace FASTrack.Utilities
{
    /// <summary>
    /// 
    /// </summary>
    public class LockUserException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LockUserException"/> class.
        /// </summary>
        public LockUserException()
            : base()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="LockUserException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public LockUserException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LockUserException"/> class.
        /// </summary>
        /// <param name="messsage">The messsage.</param>
        /// <param name="ex">The ex.</param>
        public LockUserException(string messsage, Exception ex)
            : base(messsage, ex)
        {

        }
    }
}
