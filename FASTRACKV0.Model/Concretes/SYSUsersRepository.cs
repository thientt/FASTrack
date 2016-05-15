using FASTrack.Model.Abstracts;
using FASTrack.Model.DTO;
using FASTrack.Model.Entities;
using FASTrack.Model.Types;
using FASTrack.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// 
/// </summary>
namespace FASTrack.Model.Concretes
{
    /// <summary>
    /// 
    /// </summary>
    public class SYSUsersRepository : ISYSUsersRepository
    {
        /// <summary>
        /// The _log service
        /// </summary>
        private ILogService _logService;

        /// <summary>
        /// Initializes a new instance of the <see cref="SYSUsersRepository"/> class.
        /// </summary>
        /// <param name="logService">The log service.</param>
        public SYSUsersRepository(ILogService logService)
        {
            this._logService = logService;
        }

        /// <summary>
        /// Finds the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public SYSUsersDto Single(int id)
        {
            SYSUsersDto result = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    result = (from item in context.SYS_Users
                              where item.IsDeleted == false && item.Id == id
                              select new SYSUsersDto()
                              {
                                  Id = item.Id,
                                  Email = item.Email,
                                  Salt = item.Salt,
                                  RegistedDate = item.RegistedDate,
                                  Phone = item.Phone,
                                  IsLocked = item.IsLocked,
                                  Firstname = item.Firstname,
                                  Lastname = item.Lastname,
                                  DepartmentId = item.DepartmentId,
                                  Department = new MSTDepartmentDto() { Id = item.MST_Department.Id, Name = item.MST_Department.Name, Description = item.MST_Department.Description },
                                  SiteId = item.SiteId,
                                  Sites = new SitesDto() { Id = item.MST_Sites.Id, Name = item.MST_Sites.Name, Description = item.MST_Sites.Description },
                                  RoleId = item.RoleId,
                                  Role = new SYSRolesDto() { Id = item.SYS_Roles.Id, Name = item.SYS_Roles.Name, Description = item.SYS_Roles.Description },
                                  LastLoginDate = item.LastLoginDate,
                                  IsDeleted = item.IsDeleted,
                                  IsComfiredEmail = item.IsComfiredEmail,
                                  LastUpdatedBy = item.LastUpdatedBy,
                                  LastUpdate = item.LastUpdate,


                              }).Single();
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
            }
            return result;
        }

        /// <summary>
        /// Finds the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<SYSUsersDto> SingleAsync(int id)
        {
            SYSUsersDto result = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    result = await (from item in context.SYS_Users
                                    where item.IsDeleted == false && item.Id == id
                                    select new SYSUsersDto()
                                    {
                                        Id = item.Id,
                                        Email = item.Email,
                                        Salt = item.Salt,
                                        RegistedDate = item.RegistedDate,
                                        Phone = item.Phone,
                                        IsLocked = item.IsLocked,
                                        Firstname = item.Firstname,
                                        Lastname = item.Lastname,
                                        DepartmentId = item.DepartmentId,
                                        Department = new MSTDepartmentDto() { Id = item.MST_Department.Id, Name = item.MST_Department.Name, Description = item.MST_Department.Description },
                                        SiteId = item.SiteId,
                                        Sites = new SitesDto() { Id = item.MST_Sites.Id, Name = item.MST_Sites.Name, Description = item.MST_Sites.Description },
                                        RoleId = item.RoleId,
                                        Role = new SYSRolesDto() { Id = item.SYS_Roles.Id, Name = item.SYS_Roles.Name, Description = item.SYS_Roles.Description },
                                        LastLoginDate = item.LastLoginDate,
                                        IsDeleted = item.IsDeleted,
                                        IsComfiredEmail = item.IsComfiredEmail,
                                        LastUpdatedBy = item.LastUpdatedBy,
                                        LastUpdate = item.LastUpdate,


                                    }).SingleAsync();
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
            }
            return result;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SYSUsersDto> GetAll()
        {
            IEnumerable<SYSUsersDto> results = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    results = (from item in context.SYS_Users
                               where item.IsDeleted == false
                               orderby item.Email
                               select new SYSUsersDto()
                               {
                                   Id = item.Id,
                                   Email = item.Email,
                                   Salt = item.Salt,
                                   RegistedDate = item.RegistedDate,
                                   Phone = item.Phone,
                                   IsLocked = item.IsLocked,
                                   Firstname = item.Firstname,
                                   Lastname = item.Lastname,
                                   DepartmentId = item.DepartmentId,
                                   Department = new MSTDepartmentDto() { Id = item.MST_Department.Id, Name = item.MST_Department.Name, Description = item.MST_Department.Description },
                                   SiteId = item.SiteId,
                                   Sites = new SitesDto() { Id = item.MST_Sites.Id, Name = item.MST_Sites.Name, Description = item.MST_Sites.Description },
                                   RoleId = item.RoleId,
                                   Role = new SYSRolesDto() { Id = item.SYS_Roles.Id, Name = item.SYS_Roles.Name, Description = item.SYS_Roles.Description },
                                   LastLoginDate = item.LastLoginDate,
                                   IsDeleted = item.IsDeleted,
                                   IsComfiredEmail = item.IsComfiredEmail,
                                   LastUpdatedBy = item.LastUpdatedBy,
                                   LastUpdate = item.LastUpdate,
                               }).ToList();
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
            }
            return results;
        }

        /// <summary>
        /// Gets all asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<SYSUsersDto>> GetAllAsync()
        {
            IEnumerable<SYSUsersDto> results = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    results = await (from item in context.SYS_Users
                                     where item.IsDeleted == false
                                     orderby item.Email
                                     select new SYSUsersDto()
                                     {
                                         Id = item.Id,
                                         Email = item.Email,
                                         Salt = item.Salt,
                                         RegistedDate = item.RegistedDate,
                                         Phone = item.Phone,
                                         IsLocked = item.IsLocked,
                                         Firstname = item.Firstname,
                                         Lastname = item.Lastname,
                                         DepartmentId = item.DepartmentId,
                                         Department = new MSTDepartmentDto() { Id = item.MST_Department.Id, Name = item.MST_Department.Name, Description = item.MST_Department.Description },
                                         SiteId = item.SiteId,
                                         Sites = new SitesDto() { Id = item.MST_Sites.Id, Name = item.MST_Sites.Name, Description = item.MST_Sites.Description },
                                         RoleId = item.RoleId,
                                         Role = new SYSRolesDto() { Id = item.SYS_Roles.Id, Name = item.SYS_Roles.Name, Description = item.SYS_Roles.Description },
                                         LastLoginDate = item.LastLoginDate,
                                         IsComfiredEmail = item.IsComfiredEmail,
                                         IsDeleted = item.IsDeleted,
                                         LastUpdatedBy = item.LastUpdatedBy,
                                         LastUpdate = item.LastUpdate,
                                     }).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
            }
            return results;
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public SaveResult Update(SYSUsersDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var update = context.SYS_Users.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    update.RoleId = entity.RoleId;
                    update.Salt = entity.Salt;
                    update.Phone = entity.Phone;
                    update.IsLocked = entity.IsLocked;
                    update.Firstname = entity.Firstname;
                    update.Lastname = entity.Lastname;
                    update.DepartmentId = entity.DepartmentId;
                    update.SiteId = entity.SiteId;
                    update.IsComfiredEmail = entity.IsComfiredEmail;
                    update.RecoverPass = entity.RecoverPass;
                    update.Guid = entity.Guid;
                    update.IsDeleted = entity.IsDeleted;
                    update.LastUpdatedBy = entity.LastUpdatedBy;
                    update.LastUpdate = DateTime.Now;

                    context.Entry<SYS_Users>(update).State = System.Data.Entity.EntityState.Modified;
                    result = context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = SaveResult.FAILURE;
            }

            return result;
        }

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public async Task<SaveResult> UpdateAsync(SYSUsersDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var update = context.SYS_Users.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    update.Salt = entity.Salt;
                    update.RoleId = entity.RoleId;
                    update.Phone = entity.Phone;
                    update.IsLocked = entity.IsLocked;
                    update.Firstname = entity.Firstname;
                    update.Lastname = entity.Lastname;
                    update.DepartmentId = entity.DepartmentId;
                    update.SiteId = entity.SiteId;
                    update.IsComfiredEmail = entity.IsComfiredEmail;
                    update.RecoverPass = entity.RecoverPass;
                    update.Guid = entity.Guid;
                    update.IsDeleted = entity.IsDeleted;
                    update.LastUpdatedBy = entity.LastUpdatedBy;
                    update.LastUpdate = DateTime.Now;

                    context.Entry<SYS_Users>(update).State = System.Data.Entity.EntityState.Modified;
                    result = await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = SaveResult.FAILURE;
            }

            return result;
        }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public SaveResult Add(SYSUsersDto entity)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    SYS_Users add = context.SYS_Users.Create();

                    add.Email = entity.Email;
                    add.PasswordHash = AppCipher.EncryptCipher(entity.PasswordHash);
                    add.RecoverPass = entity.RecoverPass;
                    add.RoleId = entity.RoleId;
                    add.Salt = entity.Salt;
                    add.RegistedDate = entity.RegistedDate;
                    add.Phone = entity.Phone;
                    add.IsLocked = entity.IsLocked;
                    add.Firstname = entity.Firstname;
                    add.Lastname = entity.Lastname;
                    add.DepartmentId = entity.DepartmentId;
                    add.SiteId = entity.SiteId;
                    add.LastLoginDate = entity.LastLoginDate;
                    add.IsComfiredEmail = entity.IsComfiredEmail;
                    add.Guid = entity.Guid;
                    add.IsDeleted = entity.IsDeleted;
                    add.LastUpdatedBy = entity.LastUpdatedBy;
                    add.LastUpdate = DateTime.Now;

                    context.Entry<SYS_Users>(add).State = System.Data.Entity.EntityState.Added;
                    result = context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = SaveResult.FAILURE;
            }
            return result;
        }

        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public async Task<SaveResult> AddAsync(SYSUsersDto entity)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    SYS_Users add = context.SYS_Users.Create();

                    add.Email = entity.Email;
                    add.PasswordHash = AppCipher.EncryptCipher(entity.PasswordHash);
                    add.RecoverPass = entity.RecoverPass;
                    add.RoleId = entity.RoleId;
                    add.Salt = entity.Salt;
                    add.RegistedDate = entity.RegistedDate;
                    add.Phone = entity.Phone;
                    add.IsLocked = entity.IsLocked;
                    add.Firstname = entity.Firstname;
                    add.Lastname = entity.Lastname;
                    add.DepartmentId = entity.DepartmentId;
                    add.SiteId = entity.SiteId;
                    add.LastLoginDate = entity.LastLoginDate;
                    add.IsComfiredEmail = entity.IsComfiredEmail;
                    add.Guid = entity.Guid;
                    add.IsDeleted = entity.IsDeleted;
                    add.LastUpdatedBy = entity.LastUpdatedBy;
                    add.LastUpdate = DateTime.Now;

                    context.Entry<SYS_Users>(add).State = System.Data.Entity.EntityState.Added;
                    result = await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = SaveResult.FAILURE;
            }
            return result;
        }

        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        public SaveResult AddRange(IEnumerable<SYSUsersDto> entities)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    SYS_Users add = null;
                    foreach (var entity in entities)
                    {
                        add = context.SYS_Users.Create();

                        add.Email = entity.Email;
                        add.PasswordHash = AppCipher.EncryptCipher(entity.PasswordHash);
                        add.RecoverPass = entity.RecoverPass;
                        add.RoleId = entity.RoleId;
                        add.Salt = entity.Salt;
                        add.RegistedDate = entity.RegistedDate;
                        add.Phone = entity.Phone;
                        add.IsLocked = entity.IsLocked;
                        add.Firstname = entity.Firstname;
                        add.Lastname = entity.Lastname;
                        add.DepartmentId = entity.DepartmentId;
                        add.SiteId = entity.SiteId;
                        add.LastLoginDate = entity.LastLoginDate;
                        add.IsComfiredEmail = entity.IsComfiredEmail;
                        add.Guid = entity.Guid;
                        add.IsDeleted = entity.IsDeleted;
                        add.LastUpdatedBy = entity.LastUpdatedBy;
                        add.LastUpdate = DateTime.Now;

                        context.Entry<SYS_Users>(add).State = System.Data.Entity.EntityState.Added;
                    }
                    result = context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = SaveResult.FAILURE;
            }
            return result;
        }

        /// <summary>
        /// Adds the range asynchronous.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        public async Task<SaveResult> AddRangeAsync(IEnumerable<SYSUsersDto> entities)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    SYS_Users add = null;
                    foreach (var entity in entities)
                    {
                        add = context.SYS_Users.Create();

                        add.Email = entity.Email;
                        add.PasswordHash = AppCipher.EncryptCipher(entity.PasswordHash);
                        add.RecoverPass = entity.RecoverPass;
                        add.RoleId = entity.RoleId;
                        add.Salt = entity.Salt;
                        add.RegistedDate = entity.RegistedDate;
                        add.Phone = entity.Phone;
                        add.IsLocked = entity.IsLocked;
                        add.Firstname = entity.Firstname;
                        add.Lastname = entity.Lastname;
                        add.DepartmentId = entity.DepartmentId;
                        add.SiteId = entity.SiteId;
                        add.LastLoginDate = entity.LastLoginDate;
                        add.IsComfiredEmail = entity.IsComfiredEmail;
                        add.Guid = entity.Guid;
                        add.IsDeleted = entity.IsDeleted;
                        add.LastUpdatedBy = entity.LastUpdatedBy;
                        add.LastUpdate = DateTime.Now;

                        context.Entry<SYS_Users>(add).State = System.Data.Entity.EntityState.Added;
                    }
                    result = await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = SaveResult.FAILURE;
            }
            return result;
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public SaveResult Delete(SYSUsersDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var assembly = context.SYS_Users.Single(x => x.Id == entity.Id && x.IsDeleted == false);
                    assembly.IsDeleted = true;

                    context.Entry<SYS_Users>(assembly).State = System.Data.Entity.EntityState.Modified;
                    result = context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = SaveResult.FAILURE;
            }

            return result;
        }

        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public async Task<SaveResult> DeleteAsync(SYSUsersDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var assembly = context.SYS_Users.Single(x => x.Id == entity.Id && x.IsDeleted == false);
                    assembly.IsDeleted = true;

                    context.Entry<SYS_Users>(assembly).State = System.Data.Entity.EntityState.Modified;
                    result = await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = SaveResult.FAILURE;
            }

            return result;
        }

        /// <summary>
        /// Deletes the by.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public SaveResult DeleteBy(int Id)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var assembly = context.SYS_Users.Single(x => x.Id == Id && x.IsDeleted == false);
                    assembly.IsDeleted = true;

                    context.Entry<SYS_Users>(assembly).State = System.Data.Entity.EntityState.Modified;
                    result = context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = SaveResult.FAILURE;
            }

            return result;
        }

        /// <summary>
        /// Deletes the by asynchronous.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public async Task<SaveResult> DeleteByAsync(int Id)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var assembly = context.SYS_Users.Single(x => x.Id == Id && x.IsDeleted == false);
                    assembly.IsDeleted = true;

                    context.Entry<SYS_Users>(assembly).State = System.Data.Entity.EntityState.Modified;
                    result = await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = SaveResult.FAILURE;
            }

            return result;
        }

        /// <summary>
        /// Logins the specified email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public SYSUsersDto Login(string email, string password)
        {
            SYSUsersDto result = null;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    string passHash = AppCipher.EncryptCipher(password);
                    result = (from item in context.SYS_Users
                              where item.Email == email &&
                              item.PasswordHash == passHash
                              select new SYSUsersDto()
                              {
                                  Id = item.Id,
                                  Email = item.Email,
                                  DepartmentId = item.DepartmentId,
                                  Department = new MSTDepartmentDto() { Id = item.MST_Department.Id, Name = item.MST_Department.Name, Description = item.MST_Department.Description },
                                  Firstname = item.Firstname,
                                  Lastname = item.Lastname,
                                  Phone = item.Phone,
                                  RegistedDate = item.RegistedDate,
                                  Salt = item.Salt,
                                  IsComfiredEmail = item.IsComfiredEmail,
                                  SiteId = item.SiteId,
                                  Sites = new SitesDto() { Id = item.MST_Sites.Id, Name = item.MST_Sites.Name, Description = item.MST_Sites.Description },
                                  RoleId = item.RoleId,
                                  Role = new SYSRolesDto() { Id = item.SYS_Roles.Id, Name = item.SYS_Roles.Name, Description = item.SYS_Roles.Description },
                              }).Single();

                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = null;
            }
            return result;
        }

        /// <summary>
        /// Logins the asynchronous.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public async Task<SYSUsersDto> LoginAsync(string email, string password)
        {
            SYSUsersDto result = null;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    string passHash = AppCipher.EncryptCipher(password);
                    result = await (from item in context.SYS_Users
                                    where item.Email == email &&
                                    item.PasswordHash == passHash
                                    select new SYSUsersDto()
                                    {
                                        Id = item.Id,
                                        Email = item.Email,
                                        DepartmentId = item.DepartmentId,
                                        Department = new MSTDepartmentDto() { Id = item.MST_Department.Id, Name = item.MST_Department.Name, Description = item.MST_Department.Description },
                                        Firstname = item.Firstname,
                                        Lastname = item.Lastname,
                                        Phone = item.Phone,
                                        RegistedDate = item.RegistedDate,
                                        Salt = item.Salt,
                                        IsComfiredEmail = item.IsComfiredEmail,
                                        SiteId = item.SiteId,
                                        Sites = new SitesDto() { Id = item.MST_Sites.Id, Name = item.MST_Sites.Name, Description = item.MST_Sites.Description },
                                        RoleId = item.RoleId,
                                        Role = new SYSRolesDto() { Id = item.SYS_Roles.Id, Name = item.SYS_Roles.Name, Description = item.SYS_Roles.Description },
                                    }).SingleAsync();

                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = null;
            }
            return result;
        }

        /// <summary>
        /// Unlockeds the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public SaveResult Unlocked(int id)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var assembly = context.SYS_Users.Single(x => x.Id == id && x.IsDeleted == false);

                    assembly.IsLocked = false;
                    assembly.LastUpdate = DateTime.Now;

                    context.Entry<SYS_Users>(assembly).State = System.Data.Entity.EntityState.Modified;
                    result = context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = SaveResult.FAILURE;
            }

            return result;
        }

        /// <summary>
        /// Lockeds the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public SaveResult Locked(int id)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var assembly = context.SYS_Users.Single(x => x.Id == id && x.IsDeleted == false);

                    assembly.IsLocked = true;
                    assembly.LastUpdate = DateTime.Now;

                    context.Entry<SYS_Users>(assembly).State = System.Data.Entity.EntityState.Modified;
                    result = context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = SaveResult.FAILURE;
            }

            return result;
        }

        /// <summary>
        /// Unlockeds the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<SaveResult> UnlockedAsync(int id)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var assembly = context.SYS_Users.Single(x => x.Id == id && x.IsDeleted == false);

                    assembly.IsLocked = false;
                    assembly.LastUpdate = DateTime.Now;

                    context.Entry<SYS_Users>(assembly).State = System.Data.Entity.EntityState.Modified;
                    result = await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = SaveResult.FAILURE;
            }

            return result;
        }

        /// <summary>
        /// Lockeds the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<SaveResult> LockedAsync(int id)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var assembly = context.SYS_Users.Single(x => x.Id == id && x.IsDeleted == false);

                    assembly.IsLocked = true;
                    assembly.LastUpdate = DateTime.Now;

                    context.Entry<SYS_Users>(assembly).State = System.Data.Entity.EntityState.Modified;
                    result = await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = SaveResult.FAILURE;
            }

            return result;
        }

        /// <summary>
        /// Gets all unlocked.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SYSUsersDto> FindAllUnlocked()
        {
            IEnumerable<SYSUsersDto> results = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    results = (from item in context.SYS_Users
                               where item.IsDeleted == false && item.IsLocked == false
                               select new SYSUsersDto()
                               {
                                   Id = item.Id,
                                   Email = item.Email,
                                   Salt = item.Salt,
                                   RegistedDate = item.RegistedDate,
                                   Phone = item.Phone,
                                   IsLocked = item.IsLocked,
                                   Firstname = item.Firstname,
                                   Lastname = item.Lastname,
                                   DepartmentId = item.DepartmentId,
                                   Department = new MSTDepartmentDto() { Id = item.MST_Department.Id, Name = item.MST_Department.Name, Description = item.MST_Department.Description },
                                   SiteId = item.SiteId,
                                   Sites = new SitesDto() { Id = item.MST_Sites.Id, Name = item.MST_Sites.Name, Description = item.MST_Sites.Description },
                                   LastLoginDate = item.LastLoginDate,
                                   IsDeleted = item.IsDeleted,
                                   LastUpdatedBy = item.LastUpdatedBy,
                                   LastUpdate = item.LastUpdate,


                               });
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                results = null;
            }
            return results;
        }

        /// <summary>
        /// Gets all unlocked asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<SYSUsersDto>> FindAllUnlockedAsync()
        {
            IEnumerable<SYSUsersDto> results = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    results = await (from item in context.SYS_Users
                                     where item.IsDeleted == false && item.IsLocked == false
                                     select new SYSUsersDto()
                                     {
                                         Id = item.Id,
                                         Email = item.Email,
                                         Salt = item.Salt,
                                         RegistedDate = item.RegistedDate,
                                         Phone = item.Phone,
                                         IsLocked = item.IsLocked,
                                         Firstname = item.Firstname,
                                         Lastname = item.Lastname,
                                         DepartmentId = item.DepartmentId,
                                         Department = new MSTDepartmentDto() { Id = item.MST_Department.Id, Name = item.MST_Department.Name, Description = item.MST_Department.Description },
                                         SiteId = item.SiteId,
                                         Sites = new SitesDto() { Id = item.MST_Sites.Id, Name = item.MST_Sites.Name, Description = item.MST_Sites.Description },
                                         LastLoginDate = item.LastLoginDate,
                                         IsDeleted = item.IsDeleted,
                                         LastUpdatedBy = item.LastUpdatedBy,
                                         LastUpdate = item.LastUpdate,


                                     }).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                results = null;
            }
            return results;
        }

        /// <summary>
        /// Gets all locked.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SYSUsersDto> FindAllLocked()
        {
            IEnumerable<SYSUsersDto> results = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    results = (from item in context.SYS_Users
                               where item.IsDeleted == false && item.IsLocked == true
                               select new SYSUsersDto()
                               {
                                   Id = item.Id,
                                   Email = item.Email,
                                   Salt = item.Salt,
                                   RegistedDate = item.RegistedDate,
                                   Phone = item.Phone,
                                   IsLocked = item.IsLocked,
                                   Firstname = item.Firstname,
                                   Lastname = item.Lastname,
                                   DepartmentId = item.DepartmentId,
                                   Department = new MSTDepartmentDto() { Id = item.MST_Department.Id, Name = item.MST_Department.Name, Description = item.MST_Department.Description },
                                   SiteId = item.SiteId,
                                   Sites = new SitesDto() { Id = item.MST_Sites.Id, Name = item.MST_Sites.Name, Description = item.MST_Sites.Description },
                                   LastLoginDate = item.LastLoginDate,
                                   IsDeleted = item.IsDeleted,
                                   LastUpdatedBy = item.LastUpdatedBy,
                                   LastUpdate = item.LastUpdate,


                               });
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                results = null;
            }
            return results;
        }

        /// <summary>
        /// Gets all locked asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<SYSUsersDto>> FindAllLockedAsync()
        {
            IEnumerable<SYSUsersDto> results = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    results = await (from item in context.SYS_Users
                                     where item.IsDeleted == false && item.IsLocked == true
                                     select new SYSUsersDto()
                                     {
                                         Id = item.Id,
                                         Email = item.Email,
                                         Salt = item.Salt,
                                         RegistedDate = item.RegistedDate,
                                         Phone = item.Phone,
                                         IsLocked = item.IsLocked,
                                         Firstname = item.Firstname,
                                         Lastname = item.Lastname,
                                         DepartmentId = item.DepartmentId,
                                         Department = new MSTDepartmentDto() { Id = item.MST_Department.Id, Name = item.MST_Department.Name, Description = item.MST_Department.Description },
                                         SiteId = item.SiteId,
                                         Sites = new SitesDto() { Id = item.MST_Sites.Id, Name = item.MST_Sites.Name, Description = item.MST_Sites.Description },
                                         LastLoginDate = item.LastLoginDate,
                                         IsDeleted = item.IsDeleted,
                                         LastUpdatedBy = item.LastUpdatedBy,
                                         LastUpdate = item.LastUpdate,


                                     }).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                results = null;
            }
            return results;
        }

        /// <summary>
        /// Sets the role.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="roleType">Type of the role.</param>
        /// <returns></returns>
        public SaveResult SetRole(int id, RoleType roleType)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var user = context.SYS_Users.Single(x => x.Id == id && x.IsDeleted == false);

                    user.RoleId = (int)roleType;
                    user.LastUpdate = DateTime.Now;

                    context.Entry<SYS_Users>(user).State = System.Data.Entity.EntityState.Modified;
                    result = context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = SaveResult.FAILURE;
            }

            return result;
        }

        /// <summary>
        /// Sets the role asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="roleType">Type of the role.</param>
        /// <returns></returns>
        public async Task<SaveResult> SetRoleAsync(int id, RoleType roleType)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var user = context.SYS_Users.Single(x => x.Id == id && x.IsDeleted == false);

                    user.RoleId = (int)roleType;
                    user.LastUpdate = DateTime.Now;

                    context.Entry<SYS_Users>(user).State = System.Data.Entity.EntityState.Modified;
                    result = await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = SaveResult.FAILURE;
            }

            return result;
        }

        /// <summary>
        /// Checks the exist email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public SYSUsersDto CheckExistEmail(string email)
        {
            SYSUsersDto exist = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var user = context.SYS_Users.SingleOrDefault(x => x.Email == email);
                    if (user != null)
                        exist = new SYSUsersDto
                        {
                            Id = user.Id,
                            Email = user.Email,
                            Salt = user.Salt,
                            RegistedDate = user.RegistedDate,
                            Phone = user.Phone,
                            IsLocked = user.IsLocked,
                            Firstname = user.Firstname,
                            Lastname = user.Lastname,
                            DepartmentId = user.DepartmentId,
                            Department = new MSTDepartmentDto() { Id = user.MST_Department.Id, Name = user.MST_Department.Name, Description = user.MST_Department.Description },
                            SiteId = user.SiteId,
                            Sites = new SitesDto() { Id = user.MST_Sites.Id, Name = user.MST_Sites.Name, Description = user.MST_Sites.Description },
                            RoleId = user.RoleId,
                            Role = new SYSRolesDto() { Id = user.SYS_Roles.Id, Name = user.SYS_Roles.Name, Description = user.SYS_Roles.Description },
                            LastLoginDate = user.LastLoginDate,
                            IsDeleted = user.IsDeleted,
                            IsComfiredEmail = user.IsComfiredEmail,
                            LastUpdatedBy = user.LastUpdatedBy,
                            LastUpdate = user.LastUpdate,
                        };
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                exist = null;
            }
            return exist;
        }

        /// <summary>
        /// Checks the exist email asynchronous.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public async Task<SYSUsersDto> CheckExistEmailAsync(string email)
        {
            SYSUsersDto exist = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var user = await context.SYS_Users.SingleOrDefaultAsync(x => x.Email == email);
                    if (user != null)
                        exist = new SYSUsersDto
                        {
                            Id = user.Id,
                            Email = user.Email,
                            Salt = user.Salt,
                            RegistedDate = user.RegistedDate,
                            Phone = user.Phone,
                            IsLocked = user.IsLocked,
                            Firstname = user.Firstname,
                            Lastname = user.Lastname,
                            DepartmentId = user.DepartmentId,
                            Department = new MSTDepartmentDto() { Id = user.MST_Department.Id, Name = user.MST_Department.Name, Description = user.MST_Department.Description },
                            SiteId = user.SiteId,
                            Sites = new SitesDto() { Id = user.MST_Sites.Id, Name = user.MST_Sites.Name, Description = user.MST_Sites.Description },
                            RoleId = user.RoleId,
                            Role = new SYSRolesDto() { Id = user.SYS_Roles.Id, Name = user.SYS_Roles.Name, Description = user.SYS_Roles.Description },
                            LastLoginDate = user.LastLoginDate,
                            IsDeleted = user.IsDeleted,
                            IsComfiredEmail = user.IsComfiredEmail,
                            LastUpdatedBy = user.LastUpdatedBy,
                            LastUpdate = user.LastUpdate,
                        };
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                exist = null;
            }
            return exist;
        }

        /// <summary>
        /// Resets the password.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="newPassword">The new password.</param>
        /// <returns></returns>
        public SaveResult ResetPassword(int id, string newPassword)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var update = context.SYS_Users.Single(x => x.Id == id && x.IsDeleted == false);

                    update.PasswordHash = AppCipher.EncryptCipher(newPassword);

                    context.Entry<SYS_Users>(update).State = System.Data.Entity.EntityState.Modified;
                    result = context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = SaveResult.FAILURE;
            }

            return result;
        }

        /// <summary>
        /// Resets the password asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="newPassword">The new password.</param>
        /// <returns></returns>
        public async Task<SaveResult> ResetPasswordAsync(int id, string newPassword)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var update = context.SYS_Users.Single(x => x.Id == id && x.IsDeleted == false);

                    update.PasswordHash = AppCipher.EncryptCipher(newPassword);

                    context.Entry<SYS_Users>(update).State = System.Data.Entity.EntityState.Modified;
                    result = await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = SaveResult.FAILURE;
            }

            return result;
        }

        /// <summary>
        /// Confirms the register.
        /// </summary>
        /// <param name="guid">The unique identifier.</param>
        /// <returns></returns>
        public SaveResult ConfirmRegister(string guid)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var user = context.SYS_Users.Single(w => w.Guid == guid);
                    user.IsComfiredEmail = true;
                    context.Entry<SYS_Users>(user).State = EntityState.Modified;
                    context.SaveChanges();

                    result = SaveResult.SUCCESS;
                }
            }
            catch (Exception ex)
            {
                result = SaveResult.FAILURE;
                _logService.Error(ex.Message, ex);
            }
            return result;
        }

        /// <summary>
        /// Confirms the register asynchronous.
        /// </summary>
        /// <param name="guid">The unique identifier.</param>
        /// <returns></returns>
        public async Task<SaveResult> ConfirmRegisterAsync(string guid)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var user = await context.SYS_Users.SingleAsync(w => w.Guid == guid);
                    user.IsComfiredEmail = true;
                    context.Entry<SYS_Users>(user).State = EntityState.Modified;
                    await context.SaveChangesAsync();

                    result = SaveResult.SUCCESS;
                }
            }
            catch (Exception ex)
            {
                result = SaveResult.FAILURE;
                _logService.Error(ex.Message, ex);
            }
            return result;
        }

        /// <summary>
        /// Confirms the recover pass.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="guid">The unique identifier.</param>
        /// <returns></returns>
        public SaveResult ConfirmRecoverPass(int id, string guid)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var user = context.SYS_Users.Single(w => w.Id == id && w.Guid == guid);
                    string newPass = AppCipher.EncryptCipher(user.RecoverPass);
                    user.PasswordHash = newPass;
                    user.RecoverPass = null;

                    context.Entry<SYS_Users>(user).State = EntityState.Modified;
                    context.SaveChanges();

                    result = SaveResult.SUCCESS;
                }
            }
            catch (Exception ex)
            {
                result = SaveResult.FAILURE;
                _logService.Error(ex.Message, ex);
            }
            return result;
        }

        /// <summary>
        /// Confirms the recover pass asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="guid">The unique identifier.</param>
        /// <returns></returns>
        public async Task<SaveResult> ConfirmRecoverPassAsync(int id, string guid)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var user = await context.SYS_Users.SingleAsync(w => w.Id == id && w.Guid == guid);
                    string newPass = AppCipher.EncryptCipher(user.RecoverPass);
                    user.PasswordHash = newPass;
                    user.RecoverPass = null;

                    context.Entry<SYS_Users>(user).State = EntityState.Modified;
                    await context.SaveChangesAsync();

                    result = SaveResult.SUCCESS;
                }
            }
            catch (Exception ex)
            {
                result = SaveResult.FAILURE;
                _logService.Error(ex.Message, ex);
            }
            return result;
        }
    }
}
