using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.RoleDev;

// Token: 0x02002822 RID: 10274
[NullableContext(1)]
[Nullable(0)]
public abstract class RoleDevRoleViewItemDataBase
{
	// Token: 0x060144D8 RID: 83160 RVA: 0x005A69F8 File Offset: 0x005A4BF8
	public void InitByRoleId(int roleId, ERoleDevDataType roleType)
	{
		this.RoleIdInternal = roleId;
		this.RoleTypeInternal = roleType;
		this.InitByRoleType(roleId);
	}

	// Token: 0x060144D9 RID: 83161
	protected abstract void InitByRoleType(int roleId);

	// Token: 0x17001A30 RID: 6704
	// (get) Token: 0x060144DA RID: 83162 RVA: 0x005A6A0F File Offset: 0x005A4C0F
	public int RoleId
	{
		get
		{
			return this.RoleIdInternal;
		}
	}

	// Token: 0x17001A31 RID: 6705
	// (get) Token: 0x060144DB RID: 83163 RVA: 0x005A6A17 File Offset: 0x005A4C17
	public ERoleDevDataType RoleType
	{
		get
		{
			return this.RoleTypeInternal;
		}
	}

	// Token: 0x060144DC RID: 83164
	protected abstract int GetRoleLevel();

	// Token: 0x060144DD RID: 83165
	protected abstract int GetRoleBreachLevel();

	// Token: 0x060144DE RID: 83166
	protected abstract int GetRoleGoalUpgradeLevel();

	// Token: 0x060144DF RID: 83167
	protected abstract int GetRoleGoalBreakLevel();

	// Token: 0x060144E0 RID: 83168
	protected abstract List<global::IRoleDevDetailItemData> GetDetailItems();

	// Token: 0x060144E1 RID: 83169
	protected abstract string GetRoleName();

	// Token: 0x060144E2 RID: 83170
	protected abstract bool GetIsCanUpgrade();

	// Token: 0x060144E3 RID: 83171
	protected abstract bool GetIsCanBreach();

	// Token: 0x060144E4 RID: 83172
	protected abstract bool GetIsCall();

	// Token: 0x060144E5 RID: 83173
	protected abstract int GetGachaId();

	// Token: 0x060144E6 RID: 83174
	protected abstract bool GetIsForecast();

	// Token: 0x17001A32 RID: 6706
	// (get) Token: 0x060144E7 RID: 83175 RVA: 0x005A6A1F File Offset: 0x005A4C1F
	public int RoleLevel
	{
		get
		{
			return this.GetRoleLevel();
		}
	}

	// Token: 0x17001A33 RID: 6707
	// (get) Token: 0x060144E8 RID: 83176 RVA: 0x005A6A27 File Offset: 0x005A4C27
	public int RoleBreachLevel
	{
		get
		{
			return this.GetRoleBreachLevel();
		}
	}

	// Token: 0x17001A34 RID: 6708
	// (get) Token: 0x060144E9 RID: 83177 RVA: 0x005A6A2F File Offset: 0x005A4C2F
	public int RoleGoalUpgradeLevel
	{
		get
		{
			return this.GetRoleGoalUpgradeLevel();
		}
	}

	// Token: 0x17001A35 RID: 6709
	// (get) Token: 0x060144EA RID: 83178 RVA: 0x005A6A37 File Offset: 0x005A4C37
	public int RoleGoalBreakLevel
	{
		get
		{
			return this.GetRoleGoalBreakLevel();
		}
	}

	// Token: 0x17001A36 RID: 6710
	// (get) Token: 0x060144EB RID: 83179 RVA: 0x005A6A3F File Offset: 0x005A4C3F
	public List<global::IRoleDevDetailItemData> DetailItems
	{
		get
		{
			return this.GetDetailItems();
		}
	}

	// Token: 0x17001A37 RID: 6711
	// (get) Token: 0x060144EC RID: 83180 RVA: 0x005A6A47 File Offset: 0x005A4C47
	public string RoleName
	{
		get
		{
			return this.GetRoleName();
		}
	}

	// Token: 0x17001A38 RID: 6712
	// (get) Token: 0x060144ED RID: 83181 RVA: 0x005A6A4F File Offset: 0x005A4C4F
	public bool IsCanUpgrade
	{
		get
		{
			return this.GetIsCanUpgrade();
		}
	}

	// Token: 0x17001A39 RID: 6713
	// (get) Token: 0x060144EE RID: 83182 RVA: 0x005A6A57 File Offset: 0x005A4C57
	public bool IsCanBreach
	{
		get
		{
			return this.GetIsCanBreach();
		}
	}

	// Token: 0x17001A3A RID: 6714
	// (get) Token: 0x060144EF RID: 83183 RVA: 0x005A6A5F File Offset: 0x005A4C5F
	public bool IsCall
	{
		get
		{
			return this.GetIsCall();
		}
	}

	// Token: 0x17001A3B RID: 6715
	// (get) Token: 0x060144F0 RID: 83184 RVA: 0x005A6A67 File Offset: 0x005A4C67
	public int GachaId
	{
		get
		{
			return this.GetGachaId();
		}
	}

	// Token: 0x17001A3C RID: 6716
	// (get) Token: 0x060144F1 RID: 83185 RVA: 0x005A6A6F File Offset: 0x005A4C6F
	public bool IsForecast
	{
		get
		{
			return this.GetIsForecast();
		}
	}

	// Token: 0x17001A3D RID: 6717
	// (get) Token: 0x060144F2 RID: 83186 RVA: 0x005A6A77 File Offset: 0x005A4C77
	public bool IsCanShowUpgradeItem
	{
		get
		{
			return this.RoleLevel < this.RoleGoalUpgradeLevel;
		}
	}

	// Token: 0x17001A3E RID: 6718
	// (get) Token: 0x060144F3 RID: 83187 RVA: 0x005A6A87 File Offset: 0x005A4C87
	public bool IsCanShowBreachItem
	{
		get
		{
			return this.RoleBreachLevel < this.RoleGoalBreakLevel;
		}
	}

	// Token: 0x17001A3F RID: 6719
	// (get) Token: 0x060144F4 RID: 83188 RVA: 0x005A6A97 File Offset: 0x005A4C97
	public bool IsFinish
	{
		get
		{
			return !this.IsCanShowUpgradeItem && !this.IsCanShowBreachItem;
		}
	}

	// Token: 0x17001A40 RID: 6720
	// (get) Token: 0x060144F5 RID: 83189 RVA: 0x005A6AAC File Offset: 0x005A4CAC
	public bool IsAllMaterialEnough
	{
		get
		{
			return RoleDevUtils.CheckAllItemsUp(this.DetailItems);
		}
	}

	// Token: 0x17001A41 RID: 6721
	// (get) Token: 0x060144F6 RID: 83190 RVA: 0x005A6AB9 File Offset: 0x005A4CB9
	public bool IsRoleObtained
	{
		get
		{
			return this.RoleType == ERoleDevDataType.Obtained;
		}
	}

	// Token: 0x17001A42 RID: 6722
	// (get) Token: 0x060144F7 RID: 83191 RVA: 0x005A6AC4 File Offset: 0x005A4CC4
	public bool RoleLevelIsMax
	{
		get
		{
			return this.RoleLevel >= this.GetMaxLevel();
		}
	}

	// Token: 0x060144F8 RID: 83192
	protected abstract int GetMaxLevel();

	// Token: 0x04009DA6 RID: 40358
	protected int RoleIdInternal;

	// Token: 0x04009DA7 RID: 40359
	protected ERoleDevDataType RoleTypeInternal;
}
