using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Inventory;

namespace CSharpScript.Game.Module.Birthday.View
{
	// Token: 0x02005F13 RID: 24339
	public class BirthdayRewardItem : CommonItemSmallItemGrid
	{
		// Token: 0x0603D1FE RID: 250366 RVA: 0x00F87D0C File Offset: 0x00F85F0C
		protected override void OnRefresh(TItem data, bool isSelected, int gridIndex)
		{
			InventoryDefine.IGetItemData itemData = data.ItemData;
			int count = data.Count;
			this.ConfigId = itemData.ItemId;
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
			Func<TItem, bool> showReceivedCallBack = this.ShowReceivedCallBack;
			propSmallItemGrid.IsReceivedVisible = ((showReceivedCallBack != null) ? new bool?(showReceivedCallBack(data)) : null);
			propSmallItemGrid.IsBirthdayEffectVisible = new bool?(base.GridIndex == 0);
			PropSmallItemGrid parameters = propSmallItemGrid;
			base.Apply<PropSmallItemGrid>(parameters);
		}
	}
}
