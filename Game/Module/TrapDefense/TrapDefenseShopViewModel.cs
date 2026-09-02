using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E0A RID: 19978
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseShopViewModel
	{
		// Token: 0x06033A9E RID: 211614 RVA: 0x00CE93DB File Offset: 0x00CE75DB
		public static TrapDefenseShopViewModel Create()
		{
			return new TrapDefenseShopViewModel();
		}

		// Token: 0x06033A9F RID: 211615 RVA: 0x00CE93E2 File Offset: 0x00CE75E2
		public void AddOnSelectGoodsDelegate(Action<ITrapDefenseShopGoods> @delegate)
		{
			this.DelegatesOnSelectGoods.Add(@delegate);
		}

		// Token: 0x06033AA0 RID: 211616 RVA: 0x00CE93F0 File Offset: 0x00CE75F0
		public void RemoveOnSelectGoodsDelegate(Action<ITrapDefenseShopGoods> @delegate)
		{
			int num = this.DelegatesOnSelectGoods.IndexOf(@delegate);
			if (num >= 0)
			{
				this.DelegatesOnSelectGoods.RemoveAt(num);
			}
		}

		// Token: 0x06033AA1 RID: 211617 RVA: 0x00CE941C File Offset: 0x00CE761C
		public void SelectGoods(ITrapDefenseShopGoods goods)
		{
			this.SelectedGoods = goods;
			foreach (Action<ITrapDefenseShopGoods> action in this.DelegatesOnSelectGoods)
			{
				action(goods);
			}
		}

		// Token: 0x06033AA2 RID: 211618 RVA: 0x00CE9474 File Offset: 0x00CE7674
		public void OnViewClose()
		{
			this.SelectedGoods = null;
			this.DelegatesOnSelectGoods.Clear();
		}

		// Token: 0x0401DED1 RID: 122577
		[Nullable(2)]
		public ITrapDefenseShopGoods SelectedGoods;

		// Token: 0x0401DED2 RID: 122578
		private readonly List<Action<ITrapDefenseShopGoods>> DelegatesOnSelectGoods = new List<Action<ITrapDefenseShopGoods>>();
	}
}
