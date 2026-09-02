using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.RoleUi;

// Token: 0x020017F3 RID: 6131
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class CalabashLevelUpRewardItemGrid : LoopScrollSmallItemGrid<CalabashRewardItemData>
{
	// Token: 0x0600AE4B RID: 44619 RVA: 0x002E5B88 File Offset: 0x002E3D88
	protected override void OnRefresh(CalabashRewardItemData data, bool isSelected, int gridIndex)
	{
		this.ConfigId = data.ItemData.Value.ItemData.ItemId;
		int count = data.ItemData.Value.Count;
		this.RefreshByConfigId(this.ConfigId, new int?(count), data);
	}

	// Token: 0x0600AE4C RID: 44620 RVA: 0x002E5BD4 File Offset: 0x002E3DD4
	[NullableContext(2)]
	private void RefreshByConfigId(int itemConfigId, int? count = null, CalabashRewardItemData data = null)
	{
		this.ConfigId = itemConfigId;
		if (ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(this.ConfigId)) == InventoryDefine.EItemDataType.RoleItem)
		{
			RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(this.ConfigId);
			CharacterSmallItemGrid characterSmallItemGrid = new CharacterSmallItemGrid();
			characterSmallItemGrid.Data = data;
			characterSmallItemGrid.ItemConfigId = new int?(this.ConfigId);
			string bottomText;
			if (count.GetValueOrDefault() <= 0)
			{
				bottomText = "";
			}
			else
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
				defaultInterpolatedStringHandler.AppendFormatted<int?>(count);
				bottomText = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			characterSmallItemGrid.BottomText = bottomText;
			characterSmallItemGrid.QualityId = new int?(roleConfig.Value.QualityId);
			characterSmallItemGrid.IsReceivedVisible = new bool?(data != null && data.ReceiveState == ECalabashRewardState.HasReceived);
			CharacterSmallItemGrid parameters = characterSmallItemGrid;
			base.Apply<CharacterSmallItemGrid>(parameters);
			return;
		}
		PropSmallItemGrid propSmallItemGrid = new PropSmallItemGrid();
		propSmallItemGrid.Data = data;
		propSmallItemGrid.ItemConfigId = new int?(this.ConfigId);
		string bottomText2;
		if (count.GetValueOrDefault() <= 0)
		{
			bottomText2 = "";
		}
		else
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
			defaultInterpolatedStringHandler.AppendFormatted<int?>(count);
			bottomText2 = defaultInterpolatedStringHandler.ToStringAndClear();
		}
		propSmallItemGrid.BottomText = bottomText2;
		propSmallItemGrid.IsReceivedVisible = new bool?(data != null && data.ReceiveState == ECalabashRewardState.HasReceived);
		PropSmallItemGrid parameters2 = propSmallItemGrid;
		base.Apply<PropSmallItemGrid>(parameters2);
	}

	// Token: 0x0600AE4D RID: 44621 RVA: 0x002E5D0C File Offset: 0x002E3F0C
	protected override bool OnCanExecuteChange()
	{
		return false;
	}

	// Token: 0x0600AE4E RID: 44622 RVA: 0x002E5D0F File Offset: 0x002E3F0F
	protected override void OnExtendToggleClicked()
	{
		ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(this.ConfigId, true, null);
	}

	// Token: 0x04005282 RID: 21122
	private int ConfigId;
}
