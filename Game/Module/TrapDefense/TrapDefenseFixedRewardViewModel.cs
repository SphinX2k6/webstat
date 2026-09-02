using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E05 RID: 19973
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseFixedRewardViewModel
	{
		// Token: 0x06033A77 RID: 211575 RVA: 0x00CE89EC File Offset: 0x00CE6BEC
		public static TrapDefenseFixedRewardViewModel Create(TrapDefenseModel model)
		{
			return new TrapDefenseFixedRewardViewModel
			{
				Model = model
			};
		}

		// Token: 0x06033A78 RID: 211576 RVA: 0x00CE89FA File Offset: 0x00CE6BFA
		private TrapDefenseFixedRewardViewModel()
		{
		}

		// Token: 0x06033A79 RID: 211577 RVA: 0x00CE8A02 File Offset: 0x00CE6C02
		public void OnViewClose()
		{
		}

		// Token: 0x06033A7A RID: 211578 RVA: 0x00CE8A04 File Offset: 0x00CE6C04
		public List<TrapDefenseRewardItemData> GetFixedRewardDataList()
		{
			this.Model.RewardData.SortFixedRewardList();
			return this.Model.RewardData.FixedRewardDataList;
		}

		// Token: 0x0401DEBB RID: 122555
		public TrapDefenseModel Model;
	}
}
