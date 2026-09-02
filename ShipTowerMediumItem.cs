using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.RoleUi;

// Token: 0x020029BE RID: 10686
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class ShipTowerMediumItem : LoopScrollMediumItemGrid<ShipTowerMediumItemData>
{
	// Token: 0x060154FC RID: 87292 RVA: 0x005E812A File Offset: 0x005E632A
	protected override void OnStart()
	{
		base.SetToggleInteractive(false);
	}

	// Token: 0x060154FD RID: 87293 RVA: 0x005E8133 File Offset: 0x005E6333
	protected override void OnRefresh(ShipTowerMediumItemData data, bool isSelected, int gridIndex)
	{
		Action<ShipTowerMediumItemData> refreshCallBack = this.RefreshCallBack;
		if (refreshCallBack == null)
		{
			return;
		}
		refreshCallBack(data);
	}

	// Token: 0x060154FE RID: 87294 RVA: 0x005E8146 File Offset: 0x005E6346
	private bool IsRoleItem(ShipTowerMediumItemData data)
	{
		return !data.IsBuff.GetValueOrDefault();
	}

	// Token: 0x060154FF RID: 87295 RVA: 0x005E8156 File Offset: 0x005E6356
	public void RefreshRecommend(ShipTowerMediumItemData data)
	{
		if (this.IsRoleItem(data))
		{
			this.RefreshRecommendRole(data);
			return;
		}
		this.RefreshRecommendBuff(data);
	}

	// Token: 0x06015500 RID: 87296 RVA: 0x005E8170 File Offset: 0x005E6370
	public void RefreshRecommendRole(ShipTowerMediumItemData data)
	{
		RoleInstance roleInstanceById = ModelBase<RoleModel>.Instance.GetRoleInstanceById(data.Id);
		RoleInfo value = ((roleInstanceById != null) ? new RoleInfo?(roleInstanceById.GetRoleConfig()) : ConfigBase<RoleConfig>.Instance.GetRoleConfig(data.Id)).Value;
		bool flag = roleInstanceById != null;
		int roleBranchIndexById = ModelBase<RoleModel>.Instance.GetRoleBranchIndexById(data.Id, data.SkillBranchId);
		CharacterMediumItemGrid parameters = new CharacterMediumItemGrid
		{
			ItemConfigId = new int?(data.Id),
			SkinId = value.SkinId,
			BottomTextId = value.Name,
			IsDisable = new bool?(!flag),
			ElementId = new int?(value.ElementId),
			SkillBranchIndex = ((roleBranchIndexById >= 0) ? new int?(roleBranchIndexById) : null)
		};
		base.Apply<CharacterMediumItemGrid>(parameters);
	}

	// Token: 0x06015501 RID: 87297 RVA: 0x005E824C File Offset: 0x005E644C
	public void RefreshRecommendBuff(ShipTowerMediumItemData data)
	{
		ShipTowerModel instance = ModelBase<ShipTowerModel>.Instance;
		ShipTowerBuffData shipTowerBuffData = (instance != null) ? instance.GetBuffDataByBuffId(data.Id) : null;
		ShipTowerConfig instance2 = ConfigBase<ShipTowerConfig>.Instance;
		SlashBuffToItem? slashBuffToItem = (instance2 != null) ? instance2.GetBuffCfgById(data.Id) : null;
		ItemInfo? itemConfig = ConfigBase<InventoryConfig>.Instance.GetItemConfig((slashBuffToItem != null) ? slashBuffToItem.GetValueOrDefault().ItemId : 1);
		PropMediumItemGrid parameters = new PropMediumItemGrid
		{
			Data = data,
			ItemConfigId = new int?(itemConfig.Value.Id),
			BottomTextId = itemConfig.Value.Name,
			IsDisable = new bool?(shipTowerBuffData == null || !shipTowerBuffData.IsCanUse(this.GetStageIdCallback()))
		};
		base.Apply<PropMediumItemGrid>(parameters);
	}

	// Token: 0x06015502 RID: 87298 RVA: 0x005E8323 File Offset: 0x005E6523
	public void RefreshRecord(ShipTowerMediumItemData data)
	{
		if (this.IsRoleItem(data))
		{
			this.RefreshRecordRole(data);
			return;
		}
		this.RefreshRecordBuff(data);
	}

	// Token: 0x06015503 RID: 87299 RVA: 0x005E8340 File Offset: 0x005E6540
	public void RefreshRecordRole(ShipTowerMediumItemData data)
	{
		RoleInfo value = ConfigBase<RoleConfig>.Instance.GetRoleConfig(data.Id).Value;
		int roleBranchIndexById = ModelBase<RoleModel>.Instance.GetRoleBranchIndexById(data.Id, data.SkillBranchId);
		CharacterMediumItemGrid parameters = new CharacterMediumItemGrid
		{
			ItemConfigId = new int?(data.Id),
			SkinId = value.SkinId,
			BottomTextId = "Text_LevelShow_Text",
			BottomTextParameter = new object[]
			{
				data.Count
			},
			ElementId = new int?(value.ElementId),
			SkillBranchIndex = ((roleBranchIndexById >= 0) ? new int?(roleBranchIndexById) : null)
		};
		base.Apply<CharacterMediumItemGrid>(parameters);
	}

	// Token: 0x06015504 RID: 87300 RVA: 0x005E8408 File Offset: 0x005E6608
	public void RefreshRecordBuff(ShipTowerMediumItemData data)
	{
		ShipTowerConfig instance = ConfigBase<ShipTowerConfig>.Instance;
		SlashBuffToItem? slashBuffToItem = (instance != null) ? instance.GetBuffCfgById(data.Id) : null;
		ItemInfo? itemConfig = ConfigBase<InventoryConfig>.Instance.GetItemConfig((slashBuffToItem != null) ? slashBuffToItem.GetValueOrDefault().ItemId : 1);
		PropMediumItemGrid parameters = new PropMediumItemGrid
		{
			Data = data,
			ItemConfigId = new int?(itemConfig.Value.Id),
			BottomTextId = itemConfig.Value.Name
		};
		base.Apply<PropMediumItemGrid>(parameters);
	}

	// Token: 0x06015505 RID: 87301 RVA: 0x005E84A1 File Offset: 0x005E66A1
	public void OnForceSelected()
	{
		this.SetSelected(true, true);
	}

	// Token: 0x06015506 RID: 87302 RVA: 0x005E84AB File Offset: 0x005E66AB
	public override void OnSelected(bool fireEvent)
	{
		this.SetSelected(true, false);
	}

	// Token: 0x06015507 RID: 87303 RVA: 0x005E84B5 File Offset: 0x005E66B5
	public override void OnDeselected(bool fireEvent)
	{
		this.SetSelected(false, false);
	}

	// Token: 0x0400A43F RID: 42047
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<ShipTowerMediumItemData> RefreshCallBack;

	// Token: 0x0400A440 RID: 42048
	[Nullable(2)]
	public Func<int?> GetStageIdCallback;
}
