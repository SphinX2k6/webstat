using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02003165 RID: 12645
[NullableContext(1)]
[Nullable(0)]
public class CharacterWeaponMesh
{
	// Token: 0x0601A370 RID: 107376 RVA: 0x007B4290 File Offset: 0x007B2490
	public bool Init(List<USkeletalMeshComponent> components, USkeletalMeshComponent parentComponent, TsBaseCharacter actor, bool bInUsed)
	{
		this.MeshPool = new SkeletalMeshComponentPool();
		this.MeshPool.Init(3, parentComponent, actor, components, bInUsed, false);
		this.Actor = actor;
		if (components.Count == 0)
		{
			return true;
		}
		int num = 0;
		foreach (USkeletalMeshComponent mesh in components)
		{
			this.Weapons.Add(new CharacterWeapon(num, mesh, actor.WeaponHideEffect, new int?(this.Actor.EntityId)));
			num++;
		}
		return true;
	}

	// Token: 0x0601A371 RID: 107377 RVA: 0x007B4334 File Offset: 0x007B2534
	public void Destroy()
	{
		foreach (CharacterWeapon characterWeapon in this.Weapons)
		{
			characterWeapon.Destroy();
		}
		this.Weapons.Clear();
		this.MeshPool = null;
	}

	// Token: 0x0601A372 RID: 107378 RVA: 0x007B4398 File Offset: 0x007B2598
	public CharacterWeapon[] ChangeCharacterWeapons(int num)
	{
		int count = this.Weapons.Count;
		if (num > 3)
		{
			return Array.Empty<CharacterWeapon>();
		}
		SkeletalMeshComponentPool meshPool = this.MeshPool;
		List<USkeletalMeshComponent> list = (meshPool != null) ? meshPool.GetComponents(num, true, false) : null;
		if (list == null)
		{
			return Array.Empty<CharacterWeapon>();
		}
		if (num < count)
		{
			int count2 = count - num;
			this.Weapons.RemoveRange(num, count2);
			for (int i = 0; i < num; i++)
			{
				this.Weapons[i].Mesh = list[i];
			}
		}
		else if (num > count)
		{
			int num2 = num - count;
			for (int j = 0; j < count; j++)
			{
				this.Weapons[j].Mesh = list[j];
			}
			for (int k = 0; k < num2; k++)
			{
				this.Weapons.Add(new CharacterWeapon(k + count, list[k + count], this.Actor.WeaponHideEffect, new int?(this.Actor.EntityId)));
			}
		}
		return this.Weapons.ToArray();
	}

	// Token: 0x1700239C RID: 9116
	// (get) Token: 0x0601A373 RID: 107379 RVA: 0x007B449D File Offset: 0x007B269D
	public CharacterWeapon[] CharacterWeapons
	{
		get
		{
			return this.Weapons.ToArray();
		}
	}

	// Token: 0x0601A374 RID: 107380 RVA: 0x007B44AA File Offset: 0x007B26AA
	public void Clean()
	{
		this.ChangeCharacterWeapons(0);
	}

	// Token: 0x0601A375 RID: 107381 RVA: 0x007B44B4 File Offset: 0x007B26B4
	public void ShrinkPool()
	{
		this.MeshPool.Shrink();
	}

	// Token: 0x0601A376 RID: 107382 RVA: 0x007B44C1 File Offset: 0x007B26C1
	public int GetUsedLength()
	{
		return this.MeshPool.GetUsedLength();
	}

	// Token: 0x0400D2E4 RID: 53988
	public const string WEAPON_HIDDEN_EFFECT = "/Game/Aki/Effect/EffectGroup/Common/DA_Fx_Group_WeaponEnd.DA_Fx_Group_WeaponEnd";

	// Token: 0x0400D2E5 RID: 53989
	private const int WEAPON_POOL_MAX_SIZE = 3;

	// Token: 0x0400D2E6 RID: 53990
	private readonly List<CharacterWeapon> Weapons = new List<CharacterWeapon>();

	// Token: 0x0400D2E7 RID: 53991
	[Nullable(2)]
	private SkeletalMeshComponentPool MeshPool;

	// Token: 0x0400D2E8 RID: 53992
	[Nullable(2)]
	private TsBaseCharacter Actor;
}
