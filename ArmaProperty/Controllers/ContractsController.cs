
namespace ArmaProperty.Web.Controllers
{
    public class ContractsController(IServices<Contract>_contractServices,IMapper _mapper) : Controller
    {

        /*private readonly IMapper _mapper;
            _mapper = mapper;*/
     /*   public ContractsController(IMapper mapper)//don't do that it will fail
        {
            _mapper = mapper;
        }*/

        public IActionResult getAllContracts()
        {
            var result = _mapper.Map<IEnumerable<ContractViewModel>>(_contractServices.GetAll());
            return View(result);
        }

        public IActionResult getContract(int id )
        {
            var result = _mapper.Map<ContractViewModel>(_contractServices.GetById(id));
            return View(result);
        }
        public IActionResult TenantDetails(int id )//this is the id of the contract 
        {
            var result=_contractServices.GetById(id).Tenant;
            //mapping
            var result2 = _mapper.Map<ContractViewModel>(result);
            return View(result2);
        }

        /*public IActionResult OwnersDetails()
        {
            var result=_contractServices.GetAll().Select(x=>x.Property.Owner).ToList();
            //mapping
            var result2 = _mapper.Map<IEnumerable<ContractViewModel>>(result);//how it doesnt make confilt when it was a single object not a collection
            return View(result2);
        }*/

        public IActionResult OwnerDetails(int id )
        {
            var result = _contractServices.GetById(id).Property.Owner;
            var result2 = _mapper.Map<ContractViewModel>(result);
            return View(result2);
        }
        [Route("Contracts/create")]
        public IActionResult createContract(Contract contract)
        {
            var result = _contractServices.Save(contract);//contract
            var result2 = _mapper.Map<ContractViewModel>(result);
            return View(result2);
        }
        public IActionResult isValidContract(int id)
        {
            var contract = _contractServices.GetById(id);

            if (contract == null) return NotFound();
            
            bool match = contract.FromDate < contract.ToDate;
            return match ? Ok() : BadRequest("The contract here is invalid");
        }
        
        public IActionResult calculateTotalPayment(int id)
        {
            var contract= _contractServices.GetById(id);
            var result = _mapper.Map<ContractViewModel>(contract.Insurance + contract.Rent);
            return View(result);
        }
        
        public IActionResult DeleteContract(Contract contract)
        {
            bool result = _contractServices.Delete(contract);
            return result ? Ok() : NotFound();
        }
       
        public IActionResult updateContract(Contract contract)
        {
            var result=_contractServices.Update(contract);
            return View(result);
        }

    }
}
