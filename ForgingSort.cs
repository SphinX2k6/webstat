using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Manufacture.Forging;

// Token: 0x02001936 RID: 6454
[NullableContext(1)]
[Nullable(0)]
public class ForgingSort : CommonSort<EForgingSortWayType>
{
	// Token: 0x0600B949 RID: 47433 RVA: 0x00314728 File Offset: 0x00312928
	private int SortMake(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		IWeaponForgingData weaponForgingData = a as IWeaponForgingData;
		if (weaponForgingData == null)
		{
			return 0;
		}
		IWeaponForgingData weaponForgingData2 = b as IWeaponForgingData;
		if (weaponForgingData2 == null)
		{
			return 0;
		}
		int num = (ControllerBase<ForgingController>.Instance.CheckCanForgingOrCanUnlock(weaponForgingData.ItemId) > false) ? 1 : 0;
		int num2 = (ControllerBase<ForgingController>.Instance.CheckCanForgingOrCanUnlock(weaponForgingData2.ItemId) > false) ? 1 : 0;
		if (num == 1 && num == num2)
		{
			if (weaponForgingData.IsUnlock != weaponForgingData2.IsUnlock)
			{
				return (weaponForgingData.IsUnlock - weaponForgingData2.IsUnlock) * (isAscending ? -1 : 1);
			}
			return weaponForgingData.SortId - weaponForgingData2.SortId;
		}
		else
		{
			if (num != 0 || num != num2)
			{
				return (num2 - num) * (isAscending ? -1 : 1);
			}
			if (weaponForgingData.IsUnlock != weaponForgingData2.IsUnlock)
			{
				return (weaponForgingData2.IsUnlock - weaponForgingData.IsUnlock) * (isAscending ? -1 : 1);
			}
			return weaponForgingData.SortId - weaponForgingData2.SortId;
		}
	}

	// Token: 0x0600B94A RID: 47434 RVA: 0x003147F4 File Offset: 0x003129F4
	private int SortType(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		IWeaponForgingData weaponForgingData = a as IWeaponForgingData;
		if (weaponForgingData == null)
		{
			return 0;
		}
		IWeaponForgingData weaponForgingData2 = b as IWeaponForgingData;
		if (weaponForgingData2 == null)
		{
			return 0;
		}
		if (weaponForgingData2.WeaponType != weaponForgingData.WeaponType)
		{
			return (weaponForgingData2.WeaponType - weaponForgingData.WeaponType) * (isAscending ? -1 : 1);
		}
		return weaponForgingData.SortId - weaponForgingData2.SortId;
	}

	// Token: 0x0600B94B RID: 47435 RVA: 0x0031484C File Offset: 0x00312A4C
	private int SortId(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		IWeaponForgingData weaponForgingData = a as IWeaponForgingData;
		if (weaponForgingData == null)
		{
			return 0;
		}
		IWeaponForgingData weaponForgingData2 = b as IWeaponForgingData;
		if (weaponForgingData2 == null)
		{
			return 0;
		}
		if (weaponForgingData.ItemId != weaponForgingData2.ItemId)
		{
			return (weaponForgingData2.ItemId - weaponForgingData.ItemId) * (isAscending ? -1 : 1);
		}
		return weaponForgingData.SortId - weaponForgingData2.SortId;
	}

	// Token: 0x0600B94C RID: 47436 RVA: 0x003148A4 File Offset: 0x00312AA4
	protected override void OnInitSortMap()
	{
		this.SortMap.Add(EForgingSortWayType.Make, new TSortResult(this.SortMake));
		this.SortMap.Add(EForgingSortWayType.Type, new TSortResult(this.SortType));
		this.SortMap.Add(EForgingSortWayType.Id, new TSortResult(this.SortId));
	}
}
