using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Item;

// Token: 0x02001941 RID: 6465
[NullableContext(1)]
[Nullable(0)]
public class PinballWeaponEquipSort : CommonSort<EPinballWeaponEquipSortWayType>
{
	// Token: 0x0600B9A0 RID: 47520 RVA: 0x00316E98 File Offset: 0x00315098
	private int SortId(object a, object b, bool isAscending, params object[] parameters)
	{
		IMultiTemplateGridData multiTemplateGridData = (IMultiTemplateGridData)a;
		IMultiTemplateGridData multiTemplateGridData2 = (IMultiTemplateGridData)b;
		IPinballItemSyncWeaponGridViewData pinballItemSyncWeaponGridViewData = (IPinballItemSyncWeaponGridViewData)multiTemplateGridData.Data;
		IPinballItemSyncWeaponGridViewData pinballItemSyncWeaponGridViewData2 = (IPinballItemSyncWeaponGridViewData)multiTemplateGridData2.Data;
		int id = pinballItemSyncWeaponGridViewData.WeaponData.Id;
		int id2 = pinballItemSyncWeaponGridViewData2.WeaponData.Id;
		if (id != id2)
		{
			return (id - id2) * (isAscending ? 1 : -1);
		}
		int incId = pinballItemSyncWeaponGridViewData.WeaponData.IncId;
		int incId2 = pinballItemSyncWeaponGridViewData2.WeaponData.IncId;
		if (incId != incId2)
		{
			return (incId - incId2) * (isAscending ? 1 : -1);
		}
		return 0;
	}

	// Token: 0x0600B9A1 RID: 47521 RVA: 0x00316F24 File Offset: 0x00315124
	private int SortQuality(object a, object b, bool isAscending, params object[] parameters)
	{
		IMultiTemplateGridData multiTemplateGridData = (IMultiTemplateGridData)a;
		IMultiTemplateGridData multiTemplateGridData2 = (IMultiTemplateGridData)b;
		IPinballItemSyncWeaponGridViewData pinballItemSyncWeaponGridViewData = (IPinballItemSyncWeaponGridViewData)multiTemplateGridData.Data;
		IPinballItemSyncWeaponGridViewData pinballItemSyncWeaponGridViewData2 = (IPinballItemSyncWeaponGridViewData)multiTemplateGridData2.Data;
		int qualityId = pinballItemSyncWeaponGridViewData.QualityId;
		int qualityId2 = pinballItemSyncWeaponGridViewData2.QualityId;
		if (qualityId != qualityId2)
		{
			return (qualityId2 - qualityId) * (isAscending ? 1 : -1);
		}
		return 0;
	}

	// Token: 0x0600B9A2 RID: 47522 RVA: 0x00316F74 File Offset: 0x00315174
	private int SortEquipState(object a, object b, bool isAscending, params object[] parameters)
	{
		IMultiTemplateGridData multiTemplateGridData = (IMultiTemplateGridData)a;
		IMultiTemplateGridData multiTemplateGridData2 = (IMultiTemplateGridData)b;
		IPinballItemSyncWeaponGridViewData pinballItemSyncWeaponGridViewData = (IPinballItemSyncWeaponGridViewData)multiTemplateGridData.Data;
		IPinballItemSyncWeaponGridViewData pinballItemSyncWeaponGridViewData2 = (IPinballItemSyncWeaponGridViewData)multiTemplateGridData2.Data;
		int num = 0;
		bool isCurRoleEquip = pinballItemSyncWeaponGridViewData.IsCurRoleEquip;
		bool isCurRoleEquip2 = pinballItemSyncWeaponGridViewData2.IsCurRoleEquip;
		if (isCurRoleEquip)
		{
			num = -1;
		}
		else if (isCurRoleEquip2)
		{
			num = 1;
		}
		else
		{
			bool flag = pinballItemSyncWeaponGridViewData.WeaponData.RoleId > 0;
			bool flag2 = pinballItemSyncWeaponGridViewData2.WeaponData.RoleId > 0;
			if (flag != flag2)
			{
				num = (flag ? 1 : -1);
			}
		}
		return num * (isAscending ? 1 : -1);
	}

	// Token: 0x0600B9A3 RID: 47523 RVA: 0x00316FFC File Offset: 0x003151FC
	protected override void OnInitSortMap()
	{
		this.SortMap[EPinballWeaponEquipSortWayType.Id] = new TSortResult(this.SortId);
		this.SortMap[EPinballWeaponEquipSortWayType.Quality] = new TSortResult(this.SortQuality);
		this.SortMap[EPinballWeaponEquipSortWayType.EquipState] = new TSortResult(this.SortEquipState);
	}
}
