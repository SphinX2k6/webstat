using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;

namespace CSharpScript.Game.Module.WorldMap.SubViews
{
	// Token: 0x02004B57 RID: 19287
	[NullableContext(2)]
	[Nullable(0)]
	public class MapSubViewRewardItem : LoopScrollSmallItemGrid<TItem>
	{
		// Token: 0x06032624 RID: 206372 RVA: 0x00C9BC04 File Offset: 0x00C99E04
		protected override void OnRefresh(TItem data, bool isSelected, int gridIndex)
		{
			this.ItemId = data.ItemData.ItemId;
			if (ConfigBase<InventoryConfig>.Instance.GetItemConfigData(this.ItemId) == null)
			{
				return;
			}
			int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(this.ItemId, 0);
			string bottomText;
			if (itemCountByConfigId < data.Count)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(24, 2);
				defaultInterpolatedStringHandler.AppendLiteral("<color=#9d2437>");
				defaultInterpolatedStringHandler.AppendFormatted<int>(itemCountByConfigId);
				defaultInterpolatedStringHandler.AppendLiteral("</color>/");
				defaultInterpolatedStringHandler.AppendFormatted<int>(data.Count);
				bottomText = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			else
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(24, 2);
				defaultInterpolatedStringHandler.AppendLiteral("<color=#ffd12f>");
				defaultInterpolatedStringHandler.AppendFormatted<int>(itemCountByConfigId);
				defaultInterpolatedStringHandler.AppendLiteral("</color>/");
				defaultInterpolatedStringHandler.AppendFormatted<int>(data.Count);
				bottomText = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			PropSmallItemGrid parameters = new PropSmallItemGrid
			{
				Data = data,
				BottomText = bottomText,
				ItemConfigId = new int?(this.ItemId)
			};
			base.Apply<PropSmallItemGrid>(parameters);
		}

		// Token: 0x06032625 RID: 206373 RVA: 0x00C9BD07 File Offset: 0x00C99F07
		protected override bool OnCanExecuteChange()
		{
			return false;
		}

		// Token: 0x06032626 RID: 206374 RVA: 0x00C9BD0A File Offset: 0x00C99F0A
		protected override void OnExtendToggleClicked()
		{
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(this.ItemId, true, null);
		}

		// Token: 0x0401D6A5 RID: 120485
		public Func<int, int> GetRolePositionFunc;

		// Token: 0x0401D6A6 RID: 120486
		public Func<int, bool> IsHighlightIndex;

		// Token: 0x0401D6A7 RID: 120487
		private int ItemId;
	}
}
