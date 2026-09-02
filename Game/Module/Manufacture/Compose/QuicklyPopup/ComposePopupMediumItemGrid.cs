using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.RoleUi.RoleBreach;

namespace CSharpScript.Game.Module.Manufacture.Compose.QuicklyPopup
{
	// Token: 0x020059D0 RID: 22992
	[NullableContext(1)]
	[Nullable(0)]
	public class ComposePopupMediumItemGrid : CostMediumItemGrid
	{
		// Token: 0x0603A422 RID: 238626 RVA: 0x00EC47BC File Offset: 0x00EC29BC
		protected override void OnRefresh(ISelectedData data, bool isSelected, int gridIndex)
		{
			if (data.ItemId == 2)
			{
				this.RefreshCoinItem(data);
				return;
			}
			base.OnRefresh(data, isSelected, gridIndex);
		}

		// Token: 0x0603A423 RID: 238627 RVA: 0x00EC47D8 File Offset: 0x00EC29D8
		private void RefreshCoinItem(ISelectedData data)
		{
			int itemId = data.ItemId;
			ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(itemId);
			if (itemConfigData == null)
			{
				return;
			}
			PropMediumItemGrid propMediumItemGrid = new PropMediumItemGrid
			{
				Data = data,
				ItemConfigId = new int?(itemId),
				StarLevel = new int?(itemConfigData.QualityId),
				IsOmitBottomText = new bool?(false)
			};
			bool flag = data.SelectedCount >= data.Count;
			if (this.UseSelectedCoin)
			{
				propMediumItemGrid.BottomTextId = (flag ? "AutoSynthesis_CellCreditEnough_Num" : "AutoSynthesis_CellCreditLack_Num");
				MediumItemGridBase mediumItemGridBase = propMediumItemGrid;
				object[] bottomTextParameter = new string[]
				{
					data.SelectedCount.ToString()
				};
				mediumItemGridBase.BottomTextParameter = bottomTextParameter;
			}
			else if (flag)
			{
				propMediumItemGrid.BottomTextId = "AutoSynthesis_CellCreditEnough_Num";
				MediumItemGridBase mediumItemGridBase2 = propMediumItemGrid;
				object[] bottomTextParameter = new string[]
				{
					data.Count.ToString()
				};
				mediumItemGridBase2.BottomTextParameter = bottomTextParameter;
			}
			else
			{
				propMediumItemGrid.BottomText = data.Count.ToString();
			}
			base.Apply<PropMediumItemGrid>(propMediumItemGrid);
		}

		// Token: 0x04021041 RID: 135233
		public bool UseSelectedCoin = true;
	}
}
