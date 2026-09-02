using System;
using System.Runtime.CompilerServices;

// Token: 0x02001943 RID: 6467
[NullableContext(1)]
[Nullable(0)]
public class PinballWeaponSort : CommonSort<EPinballWeaponSortWayType>
{
	// Token: 0x0600B9A5 RID: 47525 RVA: 0x0031705C File Offset: 0x0031525C
	private int SortQuality(object a, object b, bool isAscending, params object[] parameters)
	{
		PinballWeaponData pinballWeaponData = (PinballWeaponData)a;
		PinballWeaponData pinballWeaponData2 = (PinballWeaponData)b;
		int qualityId = ConfigBase<PinballConfig>.Instance.GetPinballWeaponConfigById(pinballWeaponData.Id).Value.QualityId;
		int qualityId2 = ConfigBase<PinballConfig>.Instance.GetPinballWeaponConfigById(pinballWeaponData2.Id).Value.QualityId;
		if (qualityId != qualityId2)
		{
			return (qualityId - qualityId2) * (isAscending ? 1 : -1);
		}
		return 0;
	}

	// Token: 0x0600B9A6 RID: 47526 RVA: 0x003170D0 File Offset: 0x003152D0
	private int SortEquipLast(object a, object b, bool isAscending, params object[] parameters)
	{
		PinballWeaponData pinballWeaponData = (PinballWeaponData)a;
		PinballWeaponData pinballWeaponData2 = (PinballWeaponData)b;
		if (pinballWeaponData.RoleId > 0 && pinballWeaponData2.RoleId <= 0)
		{
			return 1;
		}
		if (pinballWeaponData.RoleId <= 0 && pinballWeaponData2.RoleId > 0)
		{
			return -1;
		}
		return 0;
	}

	// Token: 0x0600B9A7 RID: 47527 RVA: 0x00317114 File Offset: 0x00315314
	private int SortLockLast(object a, object b, bool isAscending, params object[] parameters)
	{
		PinballWeaponData pinballWeaponData = (PinballWeaponData)a;
		PinballWeaponData pinballWeaponData2 = (PinballWeaponData)b;
		if (pinballWeaponData.GetIsLock() && !pinballWeaponData2.GetIsLock())
		{
			return 1;
		}
		if (!pinballWeaponData.GetIsLock() && pinballWeaponData2.GetIsLock())
		{
			return -1;
		}
		return 0;
	}

	// Token: 0x0600B9A8 RID: 47528 RVA: 0x00317154 File Offset: 0x00315354
	protected override void OnInitSortMap()
	{
		this.SortMap[EPinballWeaponSortWayType.Quality] = new TSortResult(this.SortQuality);
		this.SortMap[EPinballWeaponSortWayType.EquipLast] = new TSortResult(this.SortEquipLast);
		this.SortMap[EPinballWeaponSortWayType.LockLast] = new TSortResult(this.SortLockLast);
	}
}
