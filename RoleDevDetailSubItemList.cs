using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Item;

// Token: 0x02002801 RID: 10241
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class RoleDevDetailSubItemList : LoopScrollSmallItemGrid<IMaterialItemData>
{
	// Token: 0x06014377 RID: 82807 RVA: 0x005A1737 File Offset: 0x0059F937
	protected override void OnStart()
	{
	}

	// Token: 0x06014378 RID: 82808 RVA: 0x005A1739 File Offset: 0x0059F939
	protected override void OnRefresh(IMaterialItemData data, bool isSelected, int gridIndex)
	{
		this.CurrentData = data;
		this.SetSelected(isSelected, false);
		this.RefreshMaterialItem(data);
	}

	// Token: 0x06014379 RID: 82809 RVA: 0x005A1751 File Offset: 0x0059F951
	public override void Refresh(IMaterialItemData data, bool isSelected, int gridIndex)
	{
		this.OnRefresh(data, false, 0);
	}

	// Token: 0x0601437A RID: 82810 RVA: 0x005A175C File Offset: 0x0059F95C
	public override void OnSelected(bool fireEvent)
	{
		this.SetSelected(true, false);
	}

	// Token: 0x0601437B RID: 82811 RVA: 0x005A1766 File Offset: 0x0059F966
	public override void OnDeselected(bool fireEvent)
	{
		this.SetSelected(false, true);
	}

	// Token: 0x0601437C RID: 82812 RVA: 0x005A1770 File Offset: 0x0059F970
	private void RefreshMaterialItem(IMaterialItemData data)
	{
		base.SetSelectVisible(false);
		base.SetExtendToggleEnable(false, false);
		RoleDevCulProjectConfig? roleDevStaticConfig = ConfigBase<RoleDevConfig>.Instance.GetRoleDevStaticConfig();
		int itemId = data.ItemId;
		int? num = (roleDevStaticConfig != null) ? new int?(roleDevStaticConfig.GetValueOrDefault().UnknownItemId) : null;
		if (itemId == num.GetValueOrDefault() & num != null)
		{
			base.SetIconByPath(((roleDevStaticConfig != null) ? roleDevStaticConfig.GetValueOrDefault().UnknownItemIcon : null) ?? "");
			base.SetToggleInteractive(false);
			base.SetBottomTextVisible(false);
			base.SetQuality(null);
			return;
		}
		int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(data.ItemId, 0);
		string bottomText = StringUtils.Format((itemCountByConfigId >= data.RequiredCount) ? "<color=#f7eba6>{0}</color>/{1}" : "<color=#f55e66>{0}</color>/{1}", new string[]
		{
			itemCountByConfigId.ToString(),
			data.RequiredCount.ToString()
		});
		PropSmallItemGrid parameters = new PropSmallItemGrid
		{
			ItemConfigId = new int?(data.ItemId),
			BottomText = bottomText,
			Data = data
		};
		base.Apply<PropSmallItemGrid>(parameters);
		base.SetToggleInteractive(true);
	}

	// Token: 0x0601437D RID: 82813 RVA: 0x005A18AD File Offset: 0x0059FAAD
	public static IMaterialItemData CreateMaterialData(int itemId, int requiredCount)
	{
		return new MaterialItemData
		{
			ItemId = itemId,
			RequiredCount = requiredCount
		};
	}

	// Token: 0x0601437E RID: 82814 RVA: 0x005A18C4 File Offset: 0x0059FAC4
	protected override void OnExtendToggleClicked()
	{
		IMaterialItemData currentData = this.CurrentData;
		if (currentData == null)
		{
			return;
		}
		int itemId = currentData.ItemId;
		RoleDevCulProjectConfig? roleDevCulProjectConfig;
		int? num = (ConfigBase<RoleDevConfig>.Instance.GetRoleDevStaticConfig() != null) ? new int?(roleDevCulProjectConfig.GetValueOrDefault().UnknownItemId) : null;
		if (itemId == num.GetValueOrDefault() & num != null)
		{
			return;
		}
		ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(currentData.ItemId, true, null);
	}

	// Token: 0x0601437F RID: 82815 RVA: 0x005A193D File Offset: 0x0059FB3D
	protected override bool OnCanExecuteChange()
	{
		return false;
	}

	// Token: 0x04009D64 RID: 40292
	[Nullable(2)]
	private IMaterialItemData CurrentData;
}
