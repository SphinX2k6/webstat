using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006C15 RID: 27669
	public class LevelEventSystemFunction : LevelEventBase
	{
		// Token: 0x0604418A RID: 278922 RVA: 0x011AE8A1 File Offset: 0x011ACAA1
		public LevelEventSystemFunction(int id) : base(id)
		{
		}

		// Token: 0x0604418B RID: 278923 RVA: 0x011AE8AC File Offset: 0x011ACAAC
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			IBuyGoods systemFunction = ((RequestSystemFunction)inParams).SystemFunction;
			if (systemFunction != null)
			{
				IBuyGoods buyGoods = systemFunction;
				ControllerBase<PayShopController>.Instance.SendRequestPayShopBuy(buyGoods.GoodsId, 1);
			}
		}
	}
}
