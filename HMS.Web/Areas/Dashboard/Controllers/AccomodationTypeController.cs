using HMS.Entities;
using HMS.Services;
using HMS.Web.Areas.Dashboard.ViewModels;
using System.Web.Mvc;



namespace HMS.Web.Areas.Dashboard.Controllers
{
    public class AccomodationTypeController : Controller
    {
        AccomodationTypesServices AccomodationTypesServices = new AccomodationTypesServices();

        // GET: Dashboard/AccomodationType
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Listing()
        {
            AccomodationTypeListingModel model = new AccomodationTypeListingModel();

            model.AccomodationTypes = AccomodationTypesServices.GetAllAccomodationTypes();

            return PartialView("_listing", model);
        }
        [HttpGet]
        public ActionResult Action(int? id)
        {
            AccomodationTypeActionModel model = new AccomodationTypeActionModel();

            if (id.HasValue)
            {
                var accomodationtype = AccomodationTypesServices.GetAccomodationTypesById(id.Value);
                model.Id = accomodationtype.Id;
                model.Name = accomodationtype.Name;
                model.Description = accomodationtype.Description;
            }
            return PartialView("_Action", model);
        }

        [HttpPost]
        public JsonResult Action(AccomodationTypeActionModel model)
        {
            JsonResult json = new JsonResult();

            var result = false;



            if (model.Id > 0)
            {
                var accomodationType = AccomodationTypesServices.GetAccomodationTypesById(model.Id);

                accomodationType.Name = model.Name;
                accomodationType.Description = model.Description;

                result = AccomodationTypesServices.UpdateChangesAccomodationType(accomodationType);
            }
            else
            {
                AccomodationType accomodationType = new AccomodationType();
                accomodationType.Name = model.Name;
                accomodationType.Description = model.Description;

                result = AccomodationTypesServices.SaveChangesAccomodationType(accomodationType);
            }

            if (result)
            {
                json.Data = new { Success = "true" };
            }
            else
            {
                json.Data = new { Success = "false", Message = "Failed" };
            }

            return json;
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            AccomodationTypeActionModel model = new AccomodationTypeActionModel();

           
                var accomodationtype = AccomodationTypesServices.GetAccomodationTypesById(id);
                model.Id = accomodationtype.Id;
           
            
            return PartialView("_Delete", model);
        }

        [HttpPost]
        public JsonResult Delete(int? id)
        {
            JsonResult json = new JsonResult();

            var result = false;

            var accomodationtype = AccomodationTypesServices.GetAccomodationTypesById(id.Value);

            result = AccomodationTypesServices.DeleteAccomodationType(accomodationtype);
            

            if (result)
            {
                json.Data = new { Success = "true" };
            }
            else
            {
                json.Data = new { Success = "false", Message = "Failed" };
            }

            return json;
        }

    }
}