using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Item;

namespace CSharpScript.Game.Module.Cook.View
{
	// Token: 0x02005E17 RID: 24087
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class LevelRewardItem : LoopScrollSmallItemGrid<IRewardData>
	{
		// Token: 0x0603C9A7 RID: 248231 RVA: 0x00F63948 File Offset: 0x00F61B48
		protected override void OnRefresh(IRewardData data, bool isSelected, int gridIndex)
		{
			PropSmallItemGrid parameters = new PropSmallItemGrid
			{
				Data = data,
				ItemConfigId = new int?(data.RewardId),
				BottomText = ((data.Count > 0) ? data.Count.ToString() : ""),
				IsReceivedVisible = new bool?(data.IsGet)
			};
			base.Apply<PropSmallItemGrid>(parameters);
		}

		// Token: 0x0603C9A8 RID: 248232 RVA: 0x00F639AF File Offset: 0x00F61BAF
		protected override bool OnCanExecuteChange()
		{
			return false;
		}

		// Token: 0x0603C9A9 RID: 248233 RVA: 0x00F639B4 File Offset: 0x00F61BB4
		protected override void OnExtendToggleClicked()
		{
			IRewardData rewardData = this.Data as IRewardData;
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(rewardData.RewardId, true, null);
		}
	}
}
