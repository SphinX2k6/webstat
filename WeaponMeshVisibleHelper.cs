using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200316A RID: 12650
[NullableContext(1)]
[Nullable(0)]
public class WeaponMeshVisibleHelper
{
	// Token: 0x170023A0 RID: 9120
	// (get) Token: 0x0601A383 RID: 107395 RVA: 0x007B45CC File Offset: 0x007B27CC
	public Dictionary<EWeaponExtraVisibleType, WeaponVisibleState> WeaponVisibleTable { get; } = new Dictionary<EWeaponExtraVisibleType, WeaponVisibleState>();

	// Token: 0x170023A1 RID: 9121
	// (get) Token: 0x0601A384 RID: 107396 RVA: 0x007B45D4 File Offset: 0x007B27D4
	// (set) Token: 0x0601A385 RID: 107397 RVA: 0x007B45DC File Offset: 0x007B27DC
	public EWeaponBaseVisibleType DefaultVisibleType { get; set; }

	// Token: 0x170023A2 RID: 9122
	// (get) Token: 0x0601A386 RID: 107398 RVA: 0x007B45E5 File Offset: 0x007B27E5
	public WeaponVisibleState DefaultVisibleState { get; } = new WeaponVisibleState(false, true, 0);

	// Token: 0x170023A3 RID: 9123
	// (get) Token: 0x0601A387 RID: 107399 RVA: 0x007B45ED File Offset: 0x007B27ED
	public WeaponVisibleTagHelper WeaponHiddenTag { get; } = new WeaponVisibleTagHelper();

	// Token: 0x170023A4 RID: 9124
	// (get) Token: 0x0601A388 RID: 107400 RVA: 0x007B45F5 File Offset: 0x007B27F5
	public WeaponVisibleTagHelper WeaponVisibleTag { get; } = new WeaponVisibleTagHelper();

	// Token: 0x170023A5 RID: 9125
	// (get) Token: 0x0601A389 RID: 107401 RVA: 0x007B45FD File Offset: 0x007B27FD
	public CharacterWeapon Owner { get; }

	// Token: 0x0601A38A RID: 107402 RVA: 0x007B4605 File Offset: 0x007B2805
	public WeaponMeshVisibleHelper(CharacterWeapon owner)
	{
		this.Owner = owner;
	}

	// Token: 0x0601A38B RID: 107403 RVA: 0x007B4644 File Offset: 0x007B2844
	public void InitBaseTable(EWeaponBaseVisibleType normalType)
	{
		this.DefaultVisibleType = normalType;
		WeaponVisibleState value = new WeaponVisibleState(false, false, 0);
		this.WeaponVisibleTable[EWeaponExtraVisibleType.LowCustom] = value;
		WeaponVisibleState value2 = new WeaponVisibleState(false, false, 1);
		this.WeaponVisibleTable[EWeaponExtraVisibleType.HighCustom] = value2;
		WeaponVisibleState value3 = new WeaponVisibleState(false, false, 2);
		this.WeaponVisibleTable[EWeaponExtraVisibleType.ExtraTag] = value3;
	}

	// Token: 0x0601A38C RID: 107404 RVA: 0x007B469C File Offset: 0x007B289C
	public void InitTagHelper(BaseTagComponent tagComp, string visibleTagNames, Action<bool, CharacterWeapon> visibleCallBack, string hiddenTagNames, Action<bool, CharacterWeapon> hiddenCallBack)
	{
		this.WeaponVisibleTag.Init(this.Owner, tagComp, (visibleTagNames != null) ? visibleTagNames.Split('#', StringSplitOptions.None) : null, visibleCallBack);
		this.WeaponHiddenTag.Init(this.Owner, tagComp, (hiddenTagNames != null) ? hiddenTagNames.Split('#', StringSplitOptions.None) : null, hiddenCallBack);
	}

	// Token: 0x0601A38D RID: 107405 RVA: 0x007B46F0 File Offset: 0x007B28F0
	public void ClearTagHelper()
	{
		this.WeaponVisibleTag.Clear();
		this.WeaponHiddenTag.Clear();
	}

	// Token: 0x0601A38E RID: 107406 RVA: 0x007B4708 File Offset: 0x007B2908
	public bool RequestAndUpdateHiddenInGame(bool bHidden, bool isNormal = true, EWeaponExtraVisibleType type = EWeaponExtraVisibleType.LowCustom)
	{
		bool result = false;
		EWeaponBaseVisibleType defaultVisibleType = this.DefaultVisibleType;
		if (defaultVisibleType != EWeaponBaseVisibleType.Normal)
		{
			if (defaultVisibleType == EWeaponBaseVisibleType.AlwaysHidden)
			{
				result = true;
				if (isNormal)
				{
					this.DefaultVisibleState.IsHidden = true;
				}
			}
		}
		else
		{
			result = bHidden;
			if (isNormal)
			{
				this.DefaultVisibleState.IsHidden = bHidden;
			}
		}
		WeaponVisibleState weaponVisibleState;
		if (!isNormal && this.WeaponVisibleTable.TryGetValue(type, out weaponVisibleState))
		{
			weaponVisibleState.IsHidden = bHidden;
		}
		WeaponVisibleState hiddenInGameByExtraVisibleType = this.GetHiddenInGameByExtraVisibleType();
		if (hiddenInGameByExtraVisibleType != null)
		{
			if (hiddenInGameByExtraVisibleType.Priority == 0 && isNormal && hiddenInGameByExtraVisibleType.Active)
			{
				hiddenInGameByExtraVisibleType.Active = false;
			}
			else
			{
				result = hiddenInGameByExtraVisibleType.IsHidden;
			}
		}
		return result;
	}

	// Token: 0x0601A38F RID: 107407 RVA: 0x007B4798 File Offset: 0x007B2998
	public void EnableHiddenInGameByExtraVisibleType(EWeaponExtraVisibleType type, bool newEnable)
	{
		WeaponVisibleState weaponVisibleState;
		if (this.WeaponVisibleTable.TryGetValue(type, out weaponVisibleState))
		{
			weaponVisibleState.Active = newEnable;
		}
	}

	// Token: 0x0601A390 RID: 107408 RVA: 0x007B47BC File Offset: 0x007B29BC
	[NullableContext(2)]
	private WeaponVisibleState GetHiddenInGameByExtraVisibleType()
	{
		int num = -1;
		WeaponVisibleState result = null;
		foreach (WeaponVisibleState weaponVisibleState in this.WeaponVisibleTable.Values)
		{
			if (weaponVisibleState.Active && weaponVisibleState.Priority > num)
			{
				num = weaponVisibleState.Priority;
				result = weaponVisibleState;
			}
		}
		return result;
	}
}
