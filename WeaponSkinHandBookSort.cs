using System;
using System.Runtime.CompilerServices;

// Token: 0x0200194B RID: 6475
public class WeaponSkinHandBookSort : CommonSort<EWeaponSkinHandBookSortWayType>
{
	// Token: 0x0600B9C7 RID: 47559 RVA: 0x00317DA4 File Offset: 0x00315FA4
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
		int id = num2;
		int num4;
		if (b is int)
		{
			int num3 = (int)b;
			num4 = num3;
		}
		else
		{
			num4 = 0;
		}
		int id2 = num4;
		int qualityId = ConfigBase<WeaponConfig>.Instance.GetWeaponSkinConfig(id).QualityId;
		int qualityId2 = ConfigBase<WeaponConfig>.Instance.GetWeaponSkinConfig(id2).QualityId;
		if (qualityId != qualityId2)
		{
			return (qualityId - qualityId2) * (isAscending ? 1 : -1);
		}
		return 0;
	}

	// Token: 0x0600B9C8 RID: 47560 RVA: 0x00317E1E File Offset: 0x0031601E
	protected override void OnInitSortMap()
	{
		this.SortMap.Add(EWeaponSkinHandBookSortWayType.Quality, new TSortResult(this.SortQuality));
	}
}
