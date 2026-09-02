using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;

namespace CSharpScript.Game.Module.Infrastructure
{
	// Token: 0x02005C61 RID: 23649
	[NullableContext(1)]
	[Nullable(0)]
	public class InfrMaterialsDeliveryConsumeItem : LoopScrollMediumItemGrid<TItem>
	{
		// Token: 0x0603BBF9 RID: 244729 RVA: 0x00F23958 File Offset: 0x00F21B58
		protected override void OnRefresh(TItem data, bool isSelected, int gridIndex)
		{
			this.ItemId = data.ItemData.ItemId;
			CSharpScript.Game.Module.Inventory.ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(this.ItemId);
			if (itemConfigData == null)
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
			PropMediumItemGrid parameters = new PropMediumItemGrid
			{
				Data = data,
				IsOmitBottomText = new bool?(true),
				BottomText = bottomText,
				ItemConfigId = new int?(this.ItemId),
				StarLevel = new int?(itemConfigData.QualityId)
			};
			base.Apply<PropMediumItemGrid>(parameters);
		}

		// Token: 0x0603BBFA RID: 244730 RVA: 0x00F23A7A File Offset: 0x00F21C7A
		protected override bool OnCanExecuteChange()
		{
			return false;
		}

		// Token: 0x0603BBFB RID: 244731 RVA: 0x00F23A7D File Offset: 0x00F21C7D
		protected override void OnExtendToggleClicked()
		{
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(this.ItemId, true, null);
		}

		// Token: 0x0402194F RID: 137551
		public Func<int, int> GetRolePositionFunc;

		// Token: 0x04021950 RID: 137552
		public Func<int, bool> IsHighlightIndex;

		// Token: 0x04021951 RID: 137553
		private int ItemId;
	}
}
