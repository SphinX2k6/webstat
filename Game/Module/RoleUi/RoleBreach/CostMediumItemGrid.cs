using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Inventory;

namespace CSharpScript.Game.Module.RoleUi.RoleBreach
{
	// Token: 0x020050DC RID: 20700
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class CostMediumItemGrid : LoopScrollMediumItemGrid<ISelectedData>
	{
		// Token: 0x060355ED RID: 218605 RVA: 0x00D62F40 File Offset: 0x00D61140
		protected override void OnRefresh(ISelectedData data, bool isSelected, int gridIndex)
		{
			int itemId = data.ItemId;
			ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(itemId);
			if (itemConfigData == null)
			{
				return;
			}
			PropMediumItemGrid propMediumItemGrid = new PropMediumItemGrid();
			if (data.OnlyTextFlag.GetValueOrDefault())
			{
				propMediumItemGrid.Data = data;
				propMediumItemGrid.ItemConfigId = new int?(itemId);
				propMediumItemGrid.StarLevel = new int?(itemConfigData.QualityId);
				propMediumItemGrid.BottomText = data.Count.ToString();
				propMediumItemGrid.IsOmitBottomText = new bool?(false);
			}
			else
			{
				int selectedCount = data.SelectedCount;
				int count = data.Count;
				string bottomTextId = "Text_ItemEnoughText_Text";
				if (selectedCount < count)
				{
					bottomTextId = "Text_ItemNotEnoughText_Text";
				}
				object[] bottomTextParameter = new object[]
				{
					selectedCount,
					count
				};
				propMediumItemGrid.Data = data;
				propMediumItemGrid.ItemConfigId = new int?(itemId);
				propMediumItemGrid.StarLevel = new int?(itemConfigData.QualityId);
				propMediumItemGrid.BottomTextId = bottomTextId;
				propMediumItemGrid.BottomTextParameter = bottomTextParameter;
				propMediumItemGrid.IsOmitBottomText = new bool?(false);
			}
			base.Apply<PropMediumItemGrid>(propMediumItemGrid);
		}
	}
}
