
using ArmaProperty.Domain.Entities;

namespace ArmaProperty.Web.Controllers;

public class PropertiesController(IHttpContextAccessor _httpContextAccessor, IServices<Property> _servicesProperty, IServices<Owner> _servicesOwner, 
    IServices<PropertyType> _servicesPropertyType, IServices<PropertyStatus> _servicesPropertyStatus,
    IServices<Contract> _servicesContract,IMapper _mapper) : Controller
{
    public IActionResult Index() => View(new PropertiesViewModel()
        {
            Owners = _servicesOwner.GetAllAsync().Result.Select(o => new SelectListItem
            {
                Text = o.FullName,
                Value = o.Id.ToString()
            }),
            PropertyType = _servicesPropertyType.GetAllAsync().Result.Select(o => new SelectListItem
            {
                Text = o.Name,
                Value = o.Id.ToString()
            }),
            PropertyStatus = _servicesPropertyStatus.GetAllAsync().Result.Select(o => new SelectListItem
            {
                Text = o.Name,
                Value = o.Id.ToString()
            })
        });
    
    [HttpPost]
    public IActionResult GetProperties(PropertyFiltersViewModel filter)
    {
        var pageSize = int.Parse(Request.Form["length"]!);
        var skip = int.Parse(Request.Form["start"]!);
        var sortColumn = Request.Form[string.Concat("columns[", Request.Form["order[0][column]"],"][data]")];
        var sortColumnDirection = Request.Form["order[0][dir]"];


        var properties = _servicesProperty.GetAllQueryable(o => 
        ((string.IsNullOrEmpty(filter.Search) || (o.Id.ToString().Contains(filter.Search) || (o.Name.Contains(filter.Search))))
                         && (filter.OwnerId == null || filter.OwnerId == o.OwnerId)
                         && (filter.PropertyTypeId == null || filter.PropertyTypeId == o.PropertyTypeId)
                         && (filter.PropertyStatusId == null || filter.PropertyStatusId == o.PropertyStatusId)))
                         .Select(o => new GetPropertyViewModel
                         {
                             Id = o.Id,
                             PropertyStatusName = o.PropertyStatus!.Name,
                             OwnerName = o.Owner!.FullName,
                             PropertyTypeName = o.PropertyType!.Name,
                             Name = o.Name,
                             Area = o.Area,
                             Rent = o.Rent,
                             Description = o.Description,
                         });
        properties = properties.OrderBy($"{sortColumn} {sortColumnDirection}");
        var data = properties.Skip(skip).Take(pageSize).ToList();
        var recordsTotal = properties.Count();
        var jsonData = new {recordsFiltered = recordsTotal, recordsTotal, data};
        return Ok(jsonData);
    }

    public async Task<IActionResult> Details(int Id)
    {
        var property = await _servicesProperty.GetByIdAsync(Id);
        if (property is null)
            return RedirectToAction(nameof(Index));
        var result = new GetPropertyViewModel()
        {
            Id = property.Id,
            OwnerName = property.Owner!.FullName,
            PropertyStatusName = property.PropertyStatus!.Name,
            PropertyTypeName = property.PropertyType!.Name,
            Name = property.Name,
            Area = property.Area,
            Rent = property.Rent,
            Description = property.Description
        };
        return View(result);
    }

    public IActionResult Create()
        => View(new PropertyViewModel()
        {
            Owners = _servicesOwner.GetAllAsync().Result.Select(o => new SelectListItem
            {
                Text = o.FullName,
                Value = o.Id.ToString()
            }),
            PropertyType = _servicesPropertyType.GetAllAsync().Result.Select(o => new SelectListItem
            {
                Text = o.Name,
                Value = o.Id.ToString()
            }),
            PropertyStatus = _servicesPropertyStatus.GetAllAsync().Result.Select(o => new SelectListItem
            {
                Text = o.Name,
                Value = o.Id.ToString()
            }),
            PropertyAddEditViewModel = new PropertyAddEditViewModel()
        });

    [HttpPost,ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(PropertyViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);
        model.Owners = _servicesOwner.GetAllAsync().Result.Select(o => new SelectListItem
        {
            Text = o.FullName,
            Value = o.Id.ToString()
        });
        model.PropertyType = _servicesPropertyType.GetAllAsync().Result.Select(o => new SelectListItem
        {
            Text = o.Name,
            Value = o.Id.ToString()
        });
        model.PropertyStatus = _servicesPropertyStatus.GetAllAsync().Result.Select(o => new SelectListItem
        {
            Text = o.Name,
            Value = o.Id.ToString()
        });
        if (await _servicesProperty.ExistAsync(o => o.Name == model.PropertyAddEditViewModel.Name))
        {
            _httpContextAccessor.SessionMsg(ConstSession.Error, ConstMessages.NotSaved, BodyMsg.ExistCreateName);
            return View(model);
        }
        if (await _servicesProperty.SaveAsync(_mapper.Map(model.PropertyAddEditViewModel, new Property())))
        {
            _httpContextAccessor.SessionMsg(ConstSession.Success, ConstMessages.Saved, BodyMsg.Save);
            return RedirectToAction(nameof(Index));
        }  
        return View(model);
    }

    public async Task<IActionResult> Edit(int Id)
    {
        var property = await _servicesProperty.GetByIdAsync(Id);
        if (property is null)
            return RedirectToAction(nameof(Index));

        return View(new PropertyViewModel
        {
            Owners = _servicesOwner.GetAllAsync().Result.Select(o => new SelectListItem
            {
                Text = o.FullName,
                Value = o.Id.ToString()
            }),
            PropertyType = _servicesPropertyType.GetAllAsync().Result.Select(o => new SelectListItem
            {
                Text = o.Name,
                Value = o.Id.ToString()
            }),
            PropertyStatus = _servicesPropertyStatus.GetAllAsync().Result.Select(o => new SelectListItem
            {
                Text = o.Name,
                Value = o.Id.ToString()
            }),
            PropertyAddEditViewModel = _mapper.Map(property, new PropertyAddEditViewModel())
        });
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(PropertyViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);
        model.Owners = _servicesOwner.GetAllAsync().Result.Select(o => new SelectListItem
        {
            Text = o.FullName,
            Value = o.Id.ToString()
        });
        model.PropertyType = _servicesPropertyType.GetAllAsync().Result.Select(o => new SelectListItem
        {
            Text = o.Name,
            Value = o.Id.ToString()
        });
        model.PropertyStatus = _servicesPropertyStatus.GetAllAsync().Result.Select(o => new SelectListItem
        {
            Text = o.Name,
            Value = o.Id.ToString()
        });
        if (await _servicesProperty.ExistAsync(o => (o.Id != model.PropertyAddEditViewModel.Id) && (o.Name == model.PropertyAddEditViewModel.Name)))
        {
            _httpContextAccessor.SessionMsg(ConstSession.Error, ConstMessages.NotUpdate, BodyMsg.ExistEditName);
            return View(model);
        }
        var property = await _servicesProperty.GetByIdAsync(model.PropertyAddEditViewModel.Id??0);
        property = _mapper.Map(model.PropertyAddEditViewModel, property);
        
        if (await _servicesProperty.UpdateAsync(property))
        {
            _httpContextAccessor.SessionMsg(ConstSession.Success, ConstMessages.Update, BodyMsg.Edit);
            return RedirectToAction(nameof(Index));
        }
            
        return View(model); 
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int Id)
    {
        var Property = await _servicesProperty.GetByIdAsync(Id);
        if (await _servicesContract.ExistAsync(c => c.PropertyId.Equals(Property.Id)))
            return Json("ExistProperty");
        if (await _servicesProperty.DeleteAsync(Property))
            return Json("Ok");
        else
            return Json("Error");
    }
}