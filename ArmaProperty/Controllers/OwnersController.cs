using ArmaProperty.Domain.Entities;
using ArmaProperty.Domain.IServices;
using ArmaProperty.Infrastructure.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ArmaProperty.Web.Controllers;
//injecting like what done in the constructor
public class OwnersController(IServices<Owner> _servicesOwner,IMapper _mapper) : Controller
{
    public async Task<IActionResult> Index()
    {
        var result =  _servicesOwner.GetAllAsync().Result
                                    .Select(o => new OwnerViewModel
                                    {
                                        Id = o.Id,
                                        FullName = o.FullName,
                                        Details = o.Details,
                                        ImageNationalId_B = o.ImageNationalId_B,
                                        ImageNationalId_F = o.ImageNationalId_F,
                                        NationalId = o.NationalId,
                                        PhoneNumber = o.PhoneNumber,
                                    });

        return View(result);
    }

    public async Task<IActionResult> Create(Owner model)
    {
       var result=_servicesOwner.Save(model);
        var result2=_mapper.Map<Owner>(model);
        return View(result2);
    }

   
    //get owner by id
    //create contract
    //get properties
    //create property
}
