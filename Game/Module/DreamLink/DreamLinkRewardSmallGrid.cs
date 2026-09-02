using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Item;

namespace CSharpScript.Game.Module.DreamLink
{
	// Token: 0x02005DBF RID: 23999
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class DreamLinkRewardSmallGrid : LoopScrollSmallItemGrid<IDreamLinkRewardGridData>
	{
		// Token: 0x0603C6C0 RID: 247488 RVA: 0x00F56B9C File Offset: 0x00F54D9C
		protected override void OnRefresh(IDreamLinkRewardGridData data, bool isSelected, int gridIndex)
		{
			this.RewardData = data;
			TItem item = data.Item;
			int count = item.Count;
			this.ConfigId = item.ItemData.ItemId;
			PropSmallItemGrid propSmallItemGrid = new PropSmallItemGrid();
			propSmallItemGrid.Data = data;
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
			propSmallItemGrid.IsReceivedVisible = new bool?(data.Status == EActivityTaskState.FinishedAndClaimed);
			PropSmallItemGrid parameters = propSmallItemGrid;
			base.Apply<PropSmallItemGrid>(parameters);
			base.SetReceivableVisible(data.Status == EActivityTaskState.FinishedAndUnclaimed);
		}

		// Token: 0x0603C6C1 RID: 247489 RVA: 0x00F56C40 File Offset: 0x00F54E40
		protected override bool OnCanExecuteChange()
		{
			return false;
		}

		// Token: 0x0603C6C2 RID: 247490 RVA: 0x00F56C43 File Offset: 0x00F54E43
		protected override void OnExtendToggleClicked()
		{
			if (this.RewardData.Status == EActivityTaskState.FinishedAndUnclaimed)
			{
				this.RewardData.ReceiveDelegate();
				return;
			}
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(this.ConfigId, true, null);
		}

		// Token: 0x04021F7D RID: 139133
		[Nullable(2)]
		private IDreamLinkRewardGridData RewardData;

		// Token: 0x04021F7E RID: 139134
		private int ConfigId;
	}
}
