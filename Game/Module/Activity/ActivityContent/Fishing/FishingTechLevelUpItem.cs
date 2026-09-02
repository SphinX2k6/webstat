using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x0200682F RID: 26671
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class FishingTechLevelUpItem : LoopScrollMediumItemGrid<IFishingTechLevelUpItem>
	{
		// Token: 0x060427F1 RID: 272369 RVA: 0x0111143C File Offset: 0x0110F63C
		protected override void OnRefresh(IFishingTechLevelUpItem data, bool isSelected, int gridIndex)
		{
			this.ItemId = data.ItemId;
			base.BindOnCanExecuteChange((object _, bool _, EToggleState _) => false);
			int itemId = data.ItemId;
			CSharpScript.Game.Module.Inventory.ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(itemId);
			if (itemConfigData == null)
			{
				return;
			}
			int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(itemId, 0);
			string value;
			if (itemCountByConfigId < data.ItemNeedNum)
			{
				value = StringUtils.Format("<color=#c25757>{0}</color>", new string[]
				{
					itemCountByConfigId.ToString()
				});
			}
			else
			{
				value = StringUtils.Format("<color=#ffffff>{0}</color>", new string[]
				{
					itemCountByConfigId.ToString()
				});
			}
			PropMediumItemGrid propMediumItemGrid = new PropMediumItemGrid();
			propMediumItemGrid.Data = data;
			propMediumItemGrid.ItemConfigId = new int?(itemId);
			propMediumItemGrid.StarLevel = new int?(itemConfigData.QualityId);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted(value);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(data.ItemNeedNum);
			propMediumItemGrid.BottomText = defaultInterpolatedStringHandler.ToStringAndClear();
			propMediumItemGrid.IsOmitBottomText = new bool?(false);
			PropMediumItemGrid parameters = propMediumItemGrid;
			base.Apply<PropMediumItemGrid>(parameters);
		}

		// Token: 0x060427F2 RID: 272370 RVA: 0x0111155B File Offset: 0x0110F75B
		protected override void OnExtendToggleClicked()
		{
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(this.ItemId, true, null);
		}

		// Token: 0x04025036 RID: 151606
		private int ItemId;
	}
}
