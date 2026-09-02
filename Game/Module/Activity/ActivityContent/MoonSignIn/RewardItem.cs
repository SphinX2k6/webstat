using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MoonSignIn
{
	// Token: 0x02006732 RID: 26418
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	internal class RewardItem : LoopScrollSmallItemGrid<IRewardItemData>
	{
		// Token: 0x06041E53 RID: 269907 RVA: 0x010E892C File Offset: 0x010E6B2C
		protected override void OnRefresh(IRewardItemData data, bool isSelected, int gridIndex)
		{
			InventoryDefine.IGetItemData itemData = data.ItemData.ItemData;
			int count = data.ItemData.Count;
			this.ConfigId = itemData.ItemId;
			PropSmallItemGrid propSmallItemGrid = new PropSmallItemGrid();
			propSmallItemGrid.Data = data;
			propSmallItemGrid.IsReceivedVisible = new bool?(data.HaveFinish);
			propSmallItemGrid.ItemConfigId = new int?(this.ConfigId);
			string bottomText;
			if (count <= 0)
			{
				bottomText = "";
			}
			else
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
				defaultInterpolatedStringHandler.AppendFormatted<int>(count);
				bottomText = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			propSmallItemGrid.BottomText = bottomText;
			PropSmallItemGrid parameters = propSmallItemGrid;
			base.Apply<PropSmallItemGrid>(parameters);
		}

		// Token: 0x06041E54 RID: 269908 RVA: 0x010E89BC File Offset: 0x010E6BBC
		protected override bool OnCanExecuteChange()
		{
			return false;
		}

		// Token: 0x06041E55 RID: 269909 RVA: 0x010E89BF File Offset: 0x010E6BBF
		protected override void OnExtendToggleClicked()
		{
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(this.ConfigId, true, null);
		}

		// Token: 0x04024C2E RID: 150574
		private int ConfigId = -1;
	}
}
