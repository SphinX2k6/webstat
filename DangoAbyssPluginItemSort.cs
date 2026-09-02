using System;
using System.Runtime.CompilerServices;

// Token: 0x02001932 RID: 6450
[NullableContext(1)]
[Nullable(0)]
public class DangoAbyssPluginItemSort : CommonSort<DangoAbyssPluginItemSort.EComposeExchangeSortWayType>
{
	// Token: 0x0600B93A RID: 47418 RVA: 0x0031430C File Offset: 0x0031250C
	private int SortCurrentRoleFirst(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		int num = (param != null && param.Length != 0 && param[0] is int) ? ((int)param[0]) : 0;
		AbyssPluginItemInfo abyssPluginItemInfo = a as AbyssPluginItemInfo;
		AbyssPluginItemInfo abyssPluginItemInfo2 = b as AbyssPluginItemInfo;
		int num2 = (abyssPluginItemInfo.GetRoleId() == num) ? -1 : 1;
		int num3 = (abyssPluginItemInfo2.GetRoleId() == num) ? -1 : 1;
		return num2 - num3;
	}

	// Token: 0x0600B93B RID: 47419 RVA: 0x00314364 File Offset: 0x00312564
	private int SortOtherRoleLast(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		int num = (param != null && param.Length != 0 && param[0] is int) ? ((int)param[0]) : 0;
		AbyssPluginItemInfo abyssPluginItemInfo = a as AbyssPluginItemInfo;
		AbyssPluginItemInfo abyssPluginItemInfo2 = b as AbyssPluginItemInfo;
		int num2 = (abyssPluginItemInfo.GetRoleId() != num) ? 1 : -1;
		int num3 = (abyssPluginItemInfo2.GetRoleId() != num) ? 1 : -1;
		return num2 - num3;
	}

	// Token: 0x0600B93C RID: 47420 RVA: 0x003143BC File Offset: 0x003125BC
	private int SortRoleId(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		AbyssPluginItemInfo abyssPluginItemInfo = a as AbyssPluginItemInfo;
		AbyssPluginItemInfo abyssPluginItemInfo2 = b as AbyssPluginItemInfo;
		int num = abyssPluginItemInfo.GetRoleId() - abyssPluginItemInfo2.GetRoleId();
		if (!isAscending)
		{
			return -num;
		}
		return num;
	}

	// Token: 0x0600B93D RID: 47421 RVA: 0x003143EC File Offset: 0x003125EC
	private int SortQuality(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		ItemDataBase itemDataBase = a as AbyssPluginItemInfo;
		AbyssPluginItemInfo abyssPluginItemInfo = b as AbyssPluginItemInfo;
		int num = itemDataBase.GetQuality() - abyssPluginItemInfo.GetQuality();
		if (!isAscending)
		{
			return -num;
		}
		return num;
	}

	// Token: 0x0600B93E RID: 47422 RVA: 0x0031441C File Offset: 0x0031261C
	private int SortItemId(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		AbyssPluginItemInfo abyssPluginItemInfo = a as AbyssPluginItemInfo;
		AbyssPluginItemInfo abyssPluginItemInfo2 = b as AbyssPluginItemInfo;
		int num = abyssPluginItemInfo.GetItemId() - abyssPluginItemInfo2.GetItemId();
		if (!isAscending)
		{
			return -num;
		}
		return num;
	}

	// Token: 0x0600B93F RID: 47423 RVA: 0x0031444C File Offset: 0x0031264C
	private int SortLockLast(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		ItemDataBase itemDataBase = a as AbyssPluginItemInfo;
		AbyssPluginItemInfo abyssPluginItemInfo = b as AbyssPluginItemInfo;
		int num = itemDataBase.GetIsLock() ? 1 : -1;
		int num2 = abyssPluginItemInfo.GetIsLock() ? 1 : -1;
		return num - num2;
	}

	// Token: 0x0600B940 RID: 47424 RVA: 0x00314480 File Offset: 0x00312680
	private int SortDeprecateFirst(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		ItemDataBase itemDataBase = a as AbyssPluginItemInfo;
		AbyssPluginItemInfo abyssPluginItemInfo = b as AbyssPluginItemInfo;
		int num = itemDataBase.GetIsDeprecated() ? -1 : 1;
		int num2 = abyssPluginItemInfo.GetIsDeprecated() ? -1 : 1;
		return num - num2;
	}

	// Token: 0x0600B941 RID: 47425 RVA: 0x003144B4 File Offset: 0x003126B4
	private int SortValidFirst(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		int roleId = (param != null && param.Length != 0 && param[0] is int) ? ((int)param[0]) : 0;
		AbyssPluginItemInfo item = a as AbyssPluginItemInfo;
		AbyssPluginItemInfo item2 = b as AbyssPluginItemInfo;
		int num = ModelBase<DangoAbyssModel>.Instance.IsPluginHasValidTag(roleId, item) ? -1 : 1;
		int num2 = ModelBase<DangoAbyssModel>.Instance.IsPluginHasValidTag(roleId, item2) ? -1 : 1;
		return num - num2;
	}

	// Token: 0x0600B942 RID: 47426 RVA: 0x00314518 File Offset: 0x00312718
	private int SortEquipLast(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		AbyssPluginItemInfo abyssPluginItemInfo = a as AbyssPluginItemInfo;
		AbyssPluginItemInfo abyssPluginItemInfo2 = b as AbyssPluginItemInfo;
		return abyssPluginItemInfo.GetRoleId() - abyssPluginItemInfo2.GetRoleId();
	}

	// Token: 0x0600B943 RID: 47427 RVA: 0x00314540 File Offset: 0x00312740
	protected override void OnInitSortMap()
	{
		this.SortMap.Add(DangoAbyssPluginItemSort.EComposeExchangeSortWayType.CurrentRoleFirst, new TSortResult(this.SortCurrentRoleFirst));
		this.SortMap.Add(DangoAbyssPluginItemSort.EComposeExchangeSortWayType.OtherRoleLast, new TSortResult(this.SortOtherRoleLast));
		this.SortMap.Add(DangoAbyssPluginItemSort.EComposeExchangeSortWayType.RoleId, new TSortResult(this.SortRoleId));
		this.SortMap.Add(DangoAbyssPluginItemSort.EComposeExchangeSortWayType.Quality, new TSortResult(this.SortQuality));
		this.SortMap.Add(DangoAbyssPluginItemSort.EComposeExchangeSortWayType.ItemId, new TSortResult(this.SortItemId));
		this.SortMap.Add(DangoAbyssPluginItemSort.EComposeExchangeSortWayType.LockLast, new TSortResult(this.SortLockLast));
		this.SortMap.Add(DangoAbyssPluginItemSort.EComposeExchangeSortWayType.DeprecateFirst, new TSortResult(this.SortDeprecateFirst));
		this.SortMap.Add(DangoAbyssPluginItemSort.EComposeExchangeSortWayType.ValidFirst, new TSortResult(this.SortValidFirst));
		this.SortMap.Add(DangoAbyssPluginItemSort.EComposeExchangeSortWayType.EquipLast, new TSortResult(this.SortEquipLast));
	}

	// Token: 0x02007C72 RID: 31858
	[NullableContext(0)]
	public enum EComposeExchangeSortWayType
	{
		// Token: 0x0402A805 RID: 174085
		CurrentRoleFirst = 1,
		// Token: 0x0402A806 RID: 174086
		OtherRoleLast,
		// Token: 0x0402A807 RID: 174087
		RoleId,
		// Token: 0x0402A808 RID: 174088
		Quality,
		// Token: 0x0402A809 RID: 174089
		ItemId,
		// Token: 0x0402A80A RID: 174090
		LockLast,
		// Token: 0x0402A80B RID: 174091
		DeprecateFirst,
		// Token: 0x0402A80C RID: 174092
		ValidFirst,
		// Token: 0x0402A80D RID: 174093
		EquipLast
	}
}
