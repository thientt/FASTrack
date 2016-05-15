// ***********************************************************************
// Assembly         : FASTrack
// Author           : tranthiencdsp@gmail.com
// Created          : 02-25-2016
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 03-13-2016
// ***********************************************************************
// <copyright file="ExistUserException.cs" company="Atmel">
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
    public class ExistUserException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExistUserException"/> class.
        /// </summary>
        public ExistUserException():base()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ExistUserException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ExistUserException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExistUserException"/> class.
        /// </summary>
        /// <param name="messsage">The messsage.</param>
        /// <param name="ex">The ex.</param>
        public ExistUserException(string messsage, Exception ex)
            : base(messsage, ex)
        {

        }
    }
}
