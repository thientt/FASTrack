// ***********************************************************************
// Assembly         : FASTrack.Model
// Author           : tranthiencdsp@gmail.com
// Created          : 11-04-2015
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 03-22-2016
// ***********************************************************************
// <copyright file="IMSTProcessProductRepository.cs" company="Atmel Corporation">
//     Copyright © Atmel 2015
// </copyright>
// <summary></summary>
// ***********************************************************************
using FASTrack.Model.DTO;
using System.Threading.Tasks;

/// <summary>
/// The Abstracts namespace.
/// </summary>
namespace FASTrack.Model.Abstracts
{
    /// <summary>
    /// Interface IMSTProcessProductRepository
    /// </summary>
    public interface IMSTProcessProductRepository : IRepository<MSTProcessProductDto>
    {
        //MSTProcessProductDto FindBy(int processTypeId, int productId);
        MSTProcessProductDto FindBy(int processTypeId, string productName);
    }
}
