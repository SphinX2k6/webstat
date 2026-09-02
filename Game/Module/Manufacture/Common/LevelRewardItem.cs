using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Item;

namespace CSharpScript.Game.Module.Manufacture.Common
{
	// Token: 0x020059EB RID: 23019
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class LevelRewardItem : LoopScrollSmallItemGrid<IRewardData>
	{
		// Token: 0x0603A508 RID: 238856 RVA: 0x00EC8A08 File Offset: 0x00EC6C08
		protected override void OnRefresh(IRewardData data, bool isSelected, int gridIndex)
		{
			PropSmallItemGrid propSmallItemGrid = new PropSmallItemGrid();
			propSmallItemGrid.Data = data;
			propSmallItemGrid.ItemConfigId = new int?(data.RewardId);
			string bottomText;
			if (data.Count <= 0)
			{
				bottomText = "";
			}
			else
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
				defaultInterpolatedStringHandler.AppendFormatted<int>(data.Count);
				bottomText = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			propSmallItemGrid.BottomText = bottomText;
			propSmallItemGrid.IsReceivedVisible = new bool?(data.IsGet);
			PropSmallItemGrid parameters = propSmallItemGrid;
			base.Apply<PropSmallItemGrid>(parameters);
		}

		// Token: 0x0603A509 RID: 238857 RVA: 0x00EC8A7E File Offset: 0x00EC6C7E
		protected override bool OnCanExecuteChange()
		{
			return false;
		}

		// Token: 0x0603A50A RID: 238858 RVA: 0x00EC8A84 File Offset: 0x00EC6C84
		protected override void OnExtendToggleClicked()
		{
			IRewardData rewardData = this.Data as IRewardData;
			if (rewardData == null)
			{
				return;
			}
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(rewardData.RewardId, true, null);
		}
	}
}
