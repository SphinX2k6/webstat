using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.RoleDev;

// Token: 0x0200283B RID: 10299
[NullableContext(1)]
[Nullable(0)]
public abstract class RoleDevWeaponDevItemDataBase
{
	// Token: 0x060146A4 RID: 83620 RVA: 0x005AC50A File Offset: 0x005AA70A
	public void InitByRoleId(int roleId, ERoleDevDataType roleType)
	{
		this.RoleIdInternal = roleId;
		this.RoleTypeInternal = roleType;
		this.InitByRoleType(roleId);
	}

	// Token: 0x060146A5 RID: 83621
	protected abstract void InitByRoleType(int roleId);

	// Token: 0x17001A69 RID: 6761
	// (get) Token: 0x060146A6 RID: 83622 RVA: 0x005AC521 File Offset: 0x005AA721
	public int RoleId
	{
		get
		{
			return this.RoleIdInternal;
		}
	}

	// Token: 0x17001A6A RID: 6762
	// (get) Token: 0x060146A7 RID: 83623 RVA: 0x005AC529 File Offset: 0x005AA729
	public ERoleDevDataType RoleType
	{
		get
		{
			return this.RoleTypeInternal;
		}
	}

	// Token: 0x060146A8 RID: 83624
	protected abstract int GetWeaponLevel();

	// Token: 0x060146A9 RID: 83625
	protected abstract int GetWeaponBreachLevel();

	// Token: 0x060146AA RID: 83626
	protected abstract int GetWeaponGoalUpgradeLevel();

	// Token: 0x060146AB RID: 83627
	protected abstract int GetWeaponGoalBreakLevel();

	// Token: 0x060146AC RID: 83628
	protected abstract List<global::IRoleDevDetailItemData> GetDetailItems();

	// Token: 0x060146AD RID: 83629
	protected abstract string GetWeaponName();

	// Token: 0x060146AE RID: 83630
	protected abstract bool GetIsCanUpgrade();

	// Token: 0x060146AF RID: 83631
	protected abstract bool GetIsCanBreach();

	// Token: 0x060146B0 RID: 83632
	protected abstract bool GetIsCall();

	// Token: 0x060146B1 RID: 83633
	protected abstract int GetGachaId();

	// Token: 0x060146B2 RID: 83634
	protected abstract int GetWeaponConfigId();

	// Token: 0x060146B3 RID: 83635
	protected abstract bool GetIsHighQuality();

	// Token: 0x17001A6B RID: 6763
	// (get) Token: 0x060146B4 RID: 83636 RVA: 0x005AC531 File Offset: 0x005AA731
	public int WeaponLevel
	{
		get
		{
			return this.GetWeaponLevel();
		}
	}

	// Token: 0x17001A6C RID: 6764
	// (get) Token: 0x060146B5 RID: 83637 RVA: 0x005AC539 File Offset: 0x005AA739
	public int WeaponBreachLevel
	{
		get
		{
			return this.GetWeaponBreachLevel();
		}
	}

	// Token: 0x17001A6D RID: 6765
	// (get) Token: 0x060146B6 RID: 83638 RVA: 0x005AC541 File Offset: 0x005AA741
	public int WeaponGoalUpgradeLevel
	{
		get
		{
			return this.GetWeaponGoalUpgradeLevel();
		}
	}

	// Token: 0x17001A6E RID: 6766
	// (get) Token: 0x060146B7 RID: 83639 RVA: 0x005AC549 File Offset: 0x005AA749
	public int WeaponGoalBreakLevel
	{
		get
		{
			return this.GetWeaponGoalBreakLevel();
		}
	}

	// Token: 0x17001A6F RID: 6767
	// (get) Token: 0x060146B8 RID: 83640 RVA: 0x005AC551 File Offset: 0x005AA751
	public List<global::IRoleDevDetailItemData> DetailItems
	{
		get
		{
			return this.GetDetailItems();
		}
	}

	// Token: 0x17001A70 RID: 6768
	// (get) Token: 0x060146B9 RID: 83641 RVA: 0x005AC559 File Offset: 0x005AA759
	public string WeaponName
	{
		get
		{
			return this.GetWeaponName();
		}
	}

	// Token: 0x17001A71 RID: 6769
	// (get) Token: 0x060146BA RID: 83642 RVA: 0x005AC561 File Offset: 0x005AA761
	public bool IsCanUpgrade
	{
		get
		{
			return this.GetIsCanUpgrade();
		}
	}

	// Token: 0x17001A72 RID: 6770
	// (get) Token: 0x060146BB RID: 83643 RVA: 0x005AC569 File Offset: 0x005AA769
	public bool IsCanBreach
	{
		get
		{
			return this.GetIsCanBreach();
		}
	}

	// Token: 0x17001A73 RID: 6771
	// (get) Token: 0x060146BC RID: 83644 RVA: 0x005AC571 File Offset: 0x005AA771
	public bool IsCall
	{
		get
		{
			return this.GetIsCall();
		}
	}

	// Token: 0x17001A74 RID: 6772
	// (get) Token: 0x060146BD RID: 83645 RVA: 0x005AC579 File Offset: 0x005AA779
	public int GachaId
	{
		get
		{
			return this.GetGachaId();
		}
	}

	// Token: 0x17001A75 RID: 6773
	// (get) Token: 0x060146BE RID: 83646 RVA: 0x005AC581 File Offset: 0x005AA781
	public int WeaponConfigId
	{
		get
		{
			return this.GetWeaponConfigId();
		}
	}

	// Token: 0x17001A76 RID: 6774
	// (get) Token: 0x060146BF RID: 83647 RVA: 0x005AC589 File Offset: 0x005AA789
	public bool IsHighQuality
	{
		get
		{
			return this.GetIsHighQuality();
		}
	}

	// Token: 0x17001A77 RID: 6775
	// (get) Token: 0x060146C0 RID: 83648 RVA: 0x005AC591 File Offset: 0x005AA791
	public bool IsCanShowUpgradeItem
	{
		get
		{
			return this.WeaponLevel < this.WeaponGoalUpgradeLevel;
		}
	}

	// Token: 0x17001A78 RID: 6776
	// (get) Token: 0x060146C1 RID: 83649 RVA: 0x005AC5A1 File Offset: 0x005AA7A1
	public bool IsCanShowBreachItem
	{
		get
		{
			return this.WeaponBreachLevel < this.WeaponGoalBreakLevel;
		}
	}

	// Token: 0x17001A79 RID: 6777
	// (get) Token: 0x060146C2 RID: 83650 RVA: 0x005AC5B1 File Offset: 0x005AA7B1
	public bool IsFinish
	{
		get
		{
			return !this.IsCanShowUpgradeItem && !this.IsCanShowBreachItem;
		}
	}

	// Token: 0x17001A7A RID: 6778
	// (get) Token: 0x060146C3 RID: 83651 RVA: 0x005AC5C6 File Offset: 0x005AA7C6
	public bool IsAllMaterialEnough
	{
		get
		{
			return RoleDevUtils.CheckAllItemsUp(this.DetailItems);
		}
	}

	// Token: 0x17001A7B RID: 6779
	// (get) Token: 0x060146C4 RID: 83652 RVA: 0x005AC5D3 File Offset: 0x005AA7D3
	public bool IsRoleObtained
	{
		get
		{
			return this.RoleType == ERoleDevDataType.Obtained;
		}
	}

	// Token: 0x17001A7C RID: 6780
	// (get) Token: 0x060146C5 RID: 83653 RVA: 0x005AC5DE File Offset: 0x005AA7DE
	public bool WeaponIsMaxLevel
	{
		get
		{
			return this.WeaponLevel >= this.GetMaxLevel();
		}
	}

	// Token: 0x060146C6 RID: 83654
	protected abstract int GetMaxLevel();

	// Token: 0x04009E06 RID: 40454
	protected int RoleIdInternal;

	// Token: 0x04009E07 RID: 40455
	protected ERoleDevDataType RoleTypeInternal;
}
