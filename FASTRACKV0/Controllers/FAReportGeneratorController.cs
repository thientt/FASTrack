using FASTrack.Model.Abstracts;
using FASTrack.ViewModel;
using Ninject;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Linq;
using System.Collections.Generic;
using FASTrack.Model.DTO;
using System.IO;
using System.Text;
using System;

namespace FASTrack.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class FAReportGeneratorController : AppController
    {
        // GET: FAReportGenerator
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Manager,Analyst")]
        [HttpGet]
        public async Task<ActionResult> Index(int id)
        {
            if (id == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            FARReportGeneratorViewModel farRequest = await BindReport(id);
            if (farRequest == null)
                return HttpNotFound();

            var devices = DeviceDetailsRepository.FindBy(id);
            var process = new ProcessHistoryViewModel();
            if (devices != null && devices.Count() > 0)
                foreach (var item in devices)
                {
                    var items = (await ProcessHisRep.GetAllAsync()).Where(x => x.DeviceId == item.Id).OrderBy(x => x.Id).ToList();
                    //foreach (var item in items)
                    //{
                    //    item.IsHasPhotos = CheckExistPhoto(item);
                    //}
                    item.ProcessHis = items;
                }
            farRequest.DeviceDetails = devices.ToList();

            return View(farRequest);
        }

        [HttpPost]
        public JsonResult Index(FARReportGeneratorViewModel model)
        {
            string folderTop = Server.MapPath("~");
            string folderMaster = Path.Combine(folderTop, "Upload", model.Id.ToString().PadLeft(10, '0'));
            string folderDevice = Path.Combine(folderMaster, "DEVICE");

            string folderDeviceDetail = String.Empty;
            string folderProcess = String.Empty;

            var dataSource = new FARReportGeneratorViewModel();
            //find user1
            var user1 = UsersRes.CheckExistEmail(this.CurrentName);
            //find user2
            var user2 = UsersRes.CheckExistEmail(model.Analyst);
            //find user3
            var user3 = UsersRes.CheckExistEmail(model.Analyst);
            //ProcessTypes
            var processTypes = ProcessTypeRep.GetAll().ToList();
            //Requestor
            var requestor = UsersRes.CheckExistEmail(model.Requestor);

            foreach (var device in model.DeviceDetails)
            {
                var deviceEnity = DeviceDetailsRepository.Single(device.Id);
                dataSource.DeviceDetails.Add(deviceEnity);

                folderDeviceDetail = Path.Combine(folderDevice, device.Id.ToString().PadLeft(10, '0'));
                foreach (var pro in device.ProcessHis)
                {
                    folderProcess = Path.Combine(folderDeviceDetail, pro.Id.ToString().PadLeft(10, '0'));
                    if (pro.IsSelected)
                    {
                        //if (!String.IsNullOrEmpty(pro.SelectPhoto) && pro.SelectPhoto.Equals("Yes"))
                        //{
                        var proHis = ProcessHisRep.Single(pro.Id);
                        proHis.SelectPhoto = pro.SelectPhoto;
                        //Get all files in folder Process
                        if (Directory.Exists(folderProcess))
                        {
                            string[] files = Directory.GetFiles(folderProcess);
                            if (files != null && files.Count() > 0)
                            {
                                proHis.Photos.AddRange(files);
                            }
                        }
                        deviceEnity.ProcessHis.Add(proHis);
                        //}

                    }
                }
            }

            FASTrack.Infrastructure.FastrackWord word = new Infrastructure.FastrackWord(folderTop);
            word.DataSource = dataSource;
            word.User1 = user1;
            word.User2 = user2;
            word.User3 = user3;
            word.Requestor = requestor;
            word.ProcessTypes = processTypes;

            string file = word.Execute();

            if (String.IsNullOrEmpty(file))
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new { code = "EX02", path = String.Empty }
                };
            }

            Response.StatusCode = (int)HttpStatusCode.OK;
            return new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new { code = "EX01", path = file }
            };
        }

        /// <summary>
        /// Downloads the specified file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns></returns>
        [HttpGet, Authorize]
        public FileResult Download(string file)
        {
            var bytes = System.IO.File.ReadAllBytes(file);
            System.IO.File.Delete(file);
            string contentType = "application/vnd.ms-word";
            string fileName = "FAReport.docx";
            return File(bytes, contentType, fileName);
        }

        private async Task<FARReportGeneratorViewModel> BindReport(int masterId)
        {
            FARReportGeneratorViewModel farRequest = new FARReportGeneratorViewModel();

            var master = await MasterRepository.SingleAsync(masterId);

            if (master != null)
            {
                farRequest.Analyst = master.Analyst;
                //farRequest.BUId = master.BUId;
                farRequest.BU = master.Bu;
                farRequest.FARNumber = master.Number;
                farRequest.FailureDesc = master.FailureDesc;
                //farRequest.FailureOriginId = master.FailureOriginId;
                farRequest.FailureOrigin = master.FARFailureOrigin;
                farRequest.FailureRate = master.FailureRate;
                //farRequest.FailureTypeId = master.FailureTypeId;
                farRequest.FailureType = master.FARFailureType;
                farRequest.Id = masterId;
                farRequest.InitialReportTargetDate = master.InitialReportTargetDate;
                farRequest.FinalReportTargetDate = master.FinalReportTargetDate;

                farRequest.Origin = master.FAROrigin;
                //farRequest.OriginId = master.OriginId;
                farRequest.Priority = master.FARPriority;
                //farRequest.PriorityId = master.PriorityId;
                farRequest.Product = master.Product;
                farRequest.RefNo = master.RefNo;
                farRequest.RequestDate = master.RequestDate;
                farRequest.Requestor = master.Requestor;
                farRequest.SamplesArriveDate = master.SamplesArriveDate;
                farRequest.StatusId = master.StatusId;
                farRequest.State = master.FARStatus;
                farRequest.Customer = master.Customer;
                //farRequest.LabSiteId = master.LabSiteId;
                farRequest.LabSite = master.LabSite;
                farRequest.Submitted = master.Submitted;
                farRequest.Site = this.Site;
                farRequest.LastUpdate = master.LastUpdate;
            }

            //farRequest.Origins = await OriginRepository.GetAllAsync();
            farRequest.Status = await StatusRepository.GetAllAsync();
            //farRequest.BUs = await BuRepository.GetAllAsync();
            //farRequest.FailureTypes = await FailureTypeRepository.GetAllAsync();
            //farRequest.FailureOrigins = await FailureOriginRepository.GetAllAsync();
            //farRequest.Priorities = await PriorityRepository.GetAllAsync();
            //farRequest.ReasonClose = await ReasonFARCloseRepository.GetAllAsync();
            //farRequest.LabSites = await LabSiteRepository.GetAllAsync();
            //farRequest.Rates = await RatingRep.GetAllAsync();

            return farRequest;
        }

        /// <summary>
        /// Gets or sets the master repository.
        /// </summary>
        /// <value>
        /// The master repository.
        /// </value>
        [Inject]
        public IFARMasterRepository MasterRepository { get; set; }

        /// <summary>
        /// Gets or sets the user repository
        /// </summary>
        [Inject]
        public ISYSUsersRepository UsersRes { get; set; }

        /// <summary>
        /// Gets or sets the device details repository.
        /// </summary>
        /// <value>
        /// The device details repository.
        /// </value>
        [Inject]
        public IFARDeviceDetailsRepository DeviceDetailsRepository { get; set; }

        /// <summary>
        /// Gets or sets the process history repository.
        /// </summary>
        /// <value>
        /// The process history repository.
        /// </value>
        [Inject]
        public IFARProcessHistoryRepository ProcessHisRep { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Inject]
        public IMSTProcessTypesRepository ProcessTypeRep { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Inject]
        public IMSTStatusRepository StatusRepository { get; set; }
    }
}