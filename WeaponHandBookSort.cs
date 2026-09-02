using System;
using System.Runtime.CompilerServices;

// Token: 0x02001949 RID: 6473
public class WeaponHandBookSort : CommonSort<EWeaponHandBookSortWayType>
{
	// Token: 0x0600B9C4 RID: 47556 RVA: 0x00317CF4 File Offset: 0x00315EF4
	[NullableContext(2)]
	private int SortQuality(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] parameters = null)
	{
		int num2;
		if (a is int)
		{
			int num = (int)a;
			num2 = num;
		}
		else
		{
			num2 = 0;
		}
		int num3 = num2;
		int num5;
		if (b is int)
		{
			int num4 = (int)b;
			num5 = num4;
		}
		else
		{
			num5 = 0;
		}
		int num6 = num5;
		int qualityId = ConfigBase<WeaponConfig>.Instance.GetWeaponConfigByItemId(num3).Value.QualityId;
		int qualityId2 = ConfigBase<WeaponConfig>.Instance.GetWeaponConfigByItemId(num6).Value.QualityId;
		if (qualityId != qualityId2)
		{
			return (qualityId - qualityId2) * (isAscending ? 1 : -1);
		}
		return num6 - num3;
	}

	// Token: 0x0600B9C5 RID: 47557 RVA: 0x00317D82 File Offset: 0x00315F82
	protected override void OnInitSortMap()
	{
		this.SortMap.Add(EWeaponHandBookSortWayType.Quality, new TSortResult(this.SortQuality));
	}
}
