using System.Threading.Tasks;
using System.Web.Mvc;
using MixERP.Purchases.DAL.Backend.Service;

namespace MixERP.Purchases.Controllers.Backend.Tasks
{
    public class ItemController : PurchaseDashboardController
    {
        [Route("dashboard/purchase/tasks/items")]
        public async Task<ActionResult> Inde()
        {
            var model = await Items.GetItems(this.Tenant).ConfigureAwait(true);
            return this.Ok(model);
        }

        [Route("dashboard/purchase/tasks/cost-price/{itemId}/{supplierId}/{unitId}")]
        public async Task<ActionResult> CostPrice(int itemId, int supplierId, int unitId)
        {
            if (itemId < 0 || unitId < 0)
            {
                return this.InvalidModelState();
            }

            decimal model = await Items.GetCostPrice(this.Tenant, itemId, supplierId, unitId).ConfigureAwait(true);
            return this.Ok(model);
        }
    }
}