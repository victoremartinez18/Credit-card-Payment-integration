namespace Web.Api.Controllers
{
    [Route("api/checkout")]`
    [ApiController]
    public class CheckOutApiController : BaseApiController
    {
        private AppKeys _appKeys = null;
        private ICheckOutService _service = null;

        public CheckOutApiController(IOptions<AppKeys> appKeys,
            ICheckOutService service,
            ILogger<CheckOutApiController> logger) : base(logger)
        {
            _service = service;
            _appKeys = appKeys.Value;

            StripeConfiguration.ApiKey = _appKeys.StripeSecretApiKey;
        }

        [HttpPost()]
        public ActionResult<ItemResponse<string>> CreateTestSession(CheckoutAddRequest model)
        {
            Console.WriteLine(model);
            
            ObjectResult result = null;
            var domain = _appKeys.DomainUrl;
            try
            {
                string id = _service.CreateTestSession(domain, model);

                ItemResponse<string> response = new ItemResponse<string>() { Item = id };
                
                result = Created201(response);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString());
                ErrorResponse response = new ErrorResponse(ex.Message);

                result = StatusCode(500, response);
            }
            return result;
        }
    }
}
