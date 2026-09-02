using System;
using System.Runtime.CompilerServices;

// Token: 0x0200193F RID: 6463
[NullableContext(1)]
[Nullable(0)]
public class PinballRoleSelectSort : CommonSort<EPinballRoleSelectSortWayType>
{
	// Token: 0x0600B99A RID: 47514 RVA: 0x00316D04 File Offset: 0x00314F04
	private int SortId(object a, object b, bool isAscending, params object[] parameters)
	{
		IPinballRoleSelectGridItemData pinballRoleSelectGridItemData = (IPinballRoleSelectGridItemData)a;
		IPinballRoleSelectGridItemData pinballRoleSelectGridItemData2 = (IPinballRoleSelectGridItemData)b;
		int id = pinballRoleSelectGridItemData.RoleData.GetId();
		int id2 = pinballRoleSelectGridItemData2.RoleData.GetId();
		if (id != id2)
		{
			return (id - id2) * (isAscending ? 1 : -1);
		}
		return 0;
	}

	// Token: 0x0600B99B RID: 47515 RVA: 0x00316D48 File Offset: 0x00314F48
	private int SortLevel(object a, object b, bool isAscending, params object[] parameters)
	{
		IPinballRoleSelectGridItemData pinballRoleSelectGridItemData = (IPinballRoleSelectGridItemData)a;
		IPinballRoleSelectGridItemData pinballRoleSelectGridItemData2 = (IPinballRoleSelectGridItemData)b;
		int level = pinballRoleSelectGridItemData.RoleData.GetLevel();
		int level2 = pinballRoleSelectGridItemData2.RoleData.GetLevel();
		if (level != level2)
		{
			return (level2 - level) * (isAscending ? 1 : -1);
		}
		return 0;
	}

	// Token: 0x0600B99C RID: 47516 RVA: 0x00316D8C File Offset: 0x00314F8C
	private int SortLockState(object a, object b, bool isAscending, params object[] parameters)
	{
		IPinballRoleSelectGridItemData pinballRoleSelectGridItemData = (IPinballRoleSelectGridItemData)a;
		IPinballRoleSelectGridItemData pinballRoleSelectGridItemData2 = (IPinballRoleSelectGridItemData)b;
		bool flag = pinballRoleSelectGridItemData.RoleData.IsLocked();
		bool flag2 = pinballRoleSelectGridItemData2.RoleData.IsLocked();
		if (flag == flag2)
		{
			return 0;
		}
		if (!flag)
		{
			return -1;
		}
		return 1;
	}

	// Token: 0x0600B99D RID: 47517 RVA: 0x00316DCC File Offset: 0x00314FCC
	private int SortFormationFirst(object a, object b, bool isAscending, params object[] parameters)
	{
		IPinballRoleSelectGridItemData pinballRoleSelectGridItemData = (IPinballRoleSelectGridItemData)a;
		IPinballRoleSelectGridItemData pinballRoleSelectGridItemData2 = (IPinballRoleSelectGridItemData)b;
		bool flag = pinballRoleSelectGridItemData.FormationIndex >= 0;
		bool flag2 = pinballRoleSelectGridItemData2.FormationIndex >= 0;
		if (flag != flag2)
		{
			if (!flag)
			{
				return 1;
			}
			return -1;
		}
		else
		{
			if (flag && flag2)
			{
				return pinballRoleSelectGridItemData.FormationIndex - pinballRoleSelectGridItemData2.FormationIndex;
			}
			return 0;
		}
	}

	// Token: 0x0600B99E RID: 47518 RVA: 0x00316E20 File Offset: 0x00315020
	protected override void OnInitSortMap()
	{
		this.SortMap[EPinballRoleSelectSortWayType.Id] = new TSortResult(this.SortId);
		this.SortMap[EPinballRoleSelectSortWayType.Level] = new TSortResult(this.SortLevel);
		this.SortMap[EPinballRoleSelectSortWayType.LockState] = new TSortResult(this.SortLockState);
		this.SortMap[EPinballRoleSelectSortWayType.FormationFirst] = new TSortResult(this.SortFormationFirst);
	}
}
