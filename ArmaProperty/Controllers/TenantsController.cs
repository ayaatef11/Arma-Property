namespace ArmaProperty.Web.Controllers
{
    public class TenantsController(IServices<Tenant> _serviceTenant, IMapper _mapper) : Controller
    {
        public IActionResult Index()
        {
            var Result = _mapper.Map<IEnumerable<TenantViewModel>>(_serviceTenant.GetAll());
            return View(Result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TenantViewModel model)
        {
            var result = _mapper.Map(model,new Tenant());
            if (_serviceTenant.Save(result))
                return RedirectToAction(nameof(Index));
            return View(result);    
        }

        public IActionResult Edit(int Id)
        {
            var result = _mapper.Map(_serviceTenant.GetById(Id), new TenantViewModel());
            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(TenantViewModel model)
        {
            var Result = _mapper.Map(model, new Tenant());
;            if (_serviceTenant.Update(Result))
              return RedirectToAction(nameof(Index));
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            var result = _serviceTenant.GetById(Id);
            if (result is null)
                return NotFound();

            if(_serviceTenant.Delete(result))
                return RedirectToAction(nameof(Index));
            return NotFound();
        }

    }
}
