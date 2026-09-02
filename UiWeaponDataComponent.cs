using System;
using System.Runtime.CompilerServices;

// Token: 0x02002CBB RID: 11451
[NullableContext(2)]
[Nullable(0)]
public class UiWeaponDataComponent : UiModelComponentBase
{
	// Token: 0x17001E3C RID: 7740
	// (get) Token: 0x06016FB1 RID: 94129 RVA: 0x0065ED59 File Offset: 0x0065CF59
	public int WeaponConfigId
	{
		get
		{
			WeaponDataBase weaponDataInternal = this.WeaponDataInternal;
			if (weaponDataInternal == null)
			{
				return 0;
			}
			return weaponDataInternal.GetItemId();
		}
	}

	// Token: 0x17001E3D RID: 7741
	// (get) Token: 0x06016FB2 RID: 94130 RVA: 0x0065ED6C File Offset: 0x0065CF6C
	public WeaponDataBase WeaponData
	{
		get
		{
			return this.WeaponDataInternal;
		}
	}

	// Token: 0x06016FB3 RID: 94131 RVA: 0x0065ED74 File Offset: 0x0065CF74
	[NullableContext(1)]
	public void SetWeaponData(WeaponDataBase weaponData)
	{
		this.WeaponDataInternal = weaponData;
	}

	// Token: 0x0400B132 RID: 45362
	private WeaponDataBase WeaponDataInternal;
}
