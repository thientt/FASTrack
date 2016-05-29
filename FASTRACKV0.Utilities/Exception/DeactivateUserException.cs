// ***********************************************************************
// Assembly         : FASTrack
// Author           : tranthiencdsp@gmail.com
// Created          : 02-25-2016
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 03-13-2016
// ***********************************************************************
// <copyright file="DeactivateUserException.cs" company="Atmel">
//     Copyright © Atmel 2016
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace FASTrack.Utilities
{
    /// <summary>
    /// 
    /// </summary>
    public class DeactivateUserException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeactivateUserException"/> class.
        /// </summary>
        public DeactivateUserException()
            : base()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DeactivateUserException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public DeactivateUserException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeactivateUserException"/> class.
        /// </summary>
        /// <param name="messsage">The messsage.</param>
        /// <param name="ex">The ex.</param>
        public DeactivateUserException(string messsage, Exception ex)
            : base(messsage, ex)
        {

        }
    }
}
