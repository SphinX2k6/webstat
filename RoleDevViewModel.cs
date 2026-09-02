using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.RoleDev;
using CSharpScript.Game.Module.RoleUi.RoleDevelop;

// Token: 0x0200282E RID: 10286
[NullableContext(2)]
[Nullable(0)]
public class RoleDevViewModel
{
	// Token: 0x060145EE RID: 83438 RVA: 0x005AA84C File Offset: 0x005A8A4C
	public void InitHotRoleDataList()
	{
		this.HotRoleDataListInternal.Clear();
		IReadOnlyList<IRoleDevProsConfig> allRoleDevProsListConfig = ConfigBase<RoleDevConfig>.Instance.GetAllRoleDevProsListConfig();
		foreach (IRoleDevProsConfig roleDevProsConfig in allRoleDevProsListConfig)
		{
			if (roleDevProsConfig.TypeId != 6 && roleDevProsConfig.TypeId != 0)
			{
				RoleDevUtils.IsProspectTimeValid(roleDevProsConfig.Id);
				RoleDevUtils.IsGachaValid(roleDevProsConfig.GachaId);
			}
		}
		List<int> list = new List<int>();
		foreach (IRoleDevProsConfig roleDevProsConfig2 in allRoleDevProsListConfig)
		{
			if (roleDevProsConfig2.TypeId != 6 && roleDevProsConfig2.TypeId != 0)
			{
				bool flag = RoleDevUtils.IsProspectTimeValid(roleDevProsConfig2.Id);
				bool flag2 = RoleDevUtils.IsGachaValid(roleDevProsConfig2.GachaId);
				if (flag || flag2)
				{
					list.Add(roleDevProsConfig2.Id);
				}
			}
		}
		List<RoleDisplayModelBase> list2 = new List<RoleDisplayModelBase>();
		foreach (int roleId in list)
		{
			list2.Add(RoleDisplayModelFactory.Instance.BuildRoleDisplayModel(roleId, false));
		}
		this.HotRoleDataListInternal.AddRange(list2);
		this.SortRoleDisplayModelList();
	}

	// Token: 0x060145EF RID: 83439 RVA: 0x005AA9AC File Offset: 0x005A8BAC
	private void SortRoleDisplayModelList()
	{
		this.HotRoleDataListInternal.Sort((RoleDisplayModelBase a, RoleDisplayModelBase b) => RoleDevViewModel.<SortRoleDisplayModelList>g__GetSortId|11_0(a) - RoleDevViewModel.<SortRoleDisplayModelList>g__GetSortId|11_0(b));
	}

	// Token: 0x060145F0 RID: 83440 RVA: 0x005AA9D8 File Offset: 0x005A8BD8
	[NullableContext(1)]
	public void SetRoleDataList(List<RoleDataBase> dataList)
	{
		this.RoleDataListInternal = dataList;
	}

	// Token: 0x060145F1 RID: 83441 RVA: 0x005AA9E4 File Offset: 0x005A8BE4
	public void InitAllDevItemDataByRoleId(int roleId)
	{
		this.RoleDevRoleViewItemDataInternal = RoleDevRoleViewItemDataFactory.Create(roleId);
		this.RoleDevWeaponViewItemDataInternal = RoleDevWeaponViewItemDataFactory.Create(roleId, this);
		this.RoleDevSkillViewItemDataInternal = RoleDevSkillViewItemDataFactory.Create(roleId, this);
		this.RoleDevPhantomViewItemDataInternal = RoleDevPhantomViewItemDataFactory.Create(roleId, this);
		this.CreatedRoleIdSet.Add(roleId);
	}

	// Token: 0x060145F2 RID: 83442 RVA: 0x005AAA34 File Offset: 0x005A8C34
	public bool GetRoleSkillPlanState(int roleId)
	{
		bool result;
		if (this.RoleIdToSkillPlanStateMap.TryGetValue(roleId, out result))
		{
			return result;
		}
		return RoleDevUtils.GetDefaultSkillPlanByRoleId(roleId);
	}

	// Token: 0x060145F3 RID: 83443 RVA: 0x005AAA59 File Offset: 0x005A8C59
	public void SetRoleSkillPlanState(int roleId, bool isPerfectPlan)
	{
		this.RoleIdToSkillPlanStateMap[roleId] = isPerfectPlan;
	}

	// Token: 0x060145F4 RID: 83444 RVA: 0x005AAA68 File Offset: 0x005A8C68
	public ERoleDevWeaponTabType GetRoleWeaponTabType(int roleId)
	{
		ERoleDevWeaponTabType result;
		if (this.RoleIdToWeaponTabTypeMap.TryGetValue(roleId, out result))
		{
			return result;
		}
		return ERoleDevWeaponTabType.None;
	}

	// Token: 0x060145F5 RID: 83445 RVA: 0x005AAA88 File Offset: 0x005A8C88
	public void SetRoleWeaponTabType(int roleId, ERoleDevWeaponTabType weaponTabType)
	{
		this.RoleIdToWeaponTabTypeMap[roleId] = weaponTabType;
	}

	// Token: 0x060145F6 RID: 83446 RVA: 0x005AAA98 File Offset: 0x005A8C98
	public int GetRoleRecommendPlanId(int roleId)
	{
		int result;
		if (this.RoleIdToRecommendPlanIdMap.TryGetValue(roleId, out result))
		{
			return result;
		}
		return 0;
	}

	// Token: 0x060145F7 RID: 83447 RVA: 0x005AAAB8 File Offset: 0x005A8CB8
	public void SetRoleRecommendPlanId(int roleId, int recommendPlanId)
	{
		this.RoleIdToRecommendPlanIdMap[roleId] = recommendPlanId;
	}

	// Token: 0x17001A5E RID: 6750
	// (get) Token: 0x060145F8 RID: 83448 RVA: 0x005AAAC7 File Offset: 0x005A8CC7
	[Nullable(1)]
	public List<RoleDataBase> RoleDataList
	{
		[NullableContext(1)]
		get
		{
			return this.RoleDataListInternal;
		}
	}

	// Token: 0x17001A5F RID: 6751
	// (get) Token: 0x060145F9 RID: 83449 RVA: 0x005AAACF File Offset: 0x005A8CCF
	public RoleDevRoleViewItemDataBase RoleDevRoleViewItemData
	{
		get
		{
			return this.RoleDevRoleViewItemDataInternal;
		}
	}

	// Token: 0x17001A60 RID: 6752
	// (get) Token: 0x060145FA RID: 83450 RVA: 0x005AAAD7 File Offset: 0x005A8CD7
	public RoleDevWeaponViewItemDataBase RoleDevWeaponViewItemData
	{
		get
		{
			return this.RoleDevWeaponViewItemDataInternal;
		}
	}

	// Token: 0x17001A61 RID: 6753
	// (get) Token: 0x060145FB RID: 83451 RVA: 0x005AAADF File Offset: 0x005A8CDF
	public RoleDevPhantomViewItemDataBase RoleDevPhantomViewItemData
	{
		get
		{
			return this.RoleDevPhantomViewItemDataInternal;
		}
	}

	// Token: 0x17001A62 RID: 6754
	// (get) Token: 0x060145FC RID: 83452 RVA: 0x005AAAE7 File Offset: 0x005A8CE7
	public RoleDevSkillViewItemDataBase RoleDevSkillViewItemData
	{
		get
		{
			return this.RoleDevSkillViewItemDataInternal;
		}
	}

	// Token: 0x17001A63 RID: 6755
	// (get) Token: 0x060145FD RID: 83453 RVA: 0x005AAAEF File Offset: 0x005A8CEF
	[Nullable(1)]
	public List<RoleDisplayModelBase> HotRoleDataList
	{
		[NullableContext(1)]
		get
		{
			return this.HotRoleDataListInternal;
		}
	}

	// Token: 0x060145FE RID: 83454 RVA: 0x005AAAF7 File Offset: 0x005A8CF7
	public bool CheckRoleIdIsCreated(int roleId)
	{
		return this.CreatedRoleIdSet.Contains(roleId);
	}

	// Token: 0x06014600 RID: 83456 RVA: 0x005AAB5D File Offset: 0x005A8D5D
	[NullableContext(1)]
	[CompilerGenerated]
	internal static int <SortRoleDisplayModelList>g__GetSortId|11_0(RoleDisplayModelBase item)
	{
		IRoleDevProsConfig roleDevProsListConfig = ConfigBase<RoleDevConfig>.Instance.GetRoleDevProsListConfig(item.Id);
		if (roleDevProsListConfig == null)
		{
			return int.MaxValue;
		}
		return roleDevProsListConfig.SortId;
	}

	// Token: 0x04009DEA RID: 40426
	[Nullable(1)]
	private List<RoleDataBase> RoleDataListInternal = new List<RoleDataBase>();

	// Token: 0x04009DEB RID: 40427
	[Nullable(1)]
	private readonly List<RoleDisplayModelBase> HotRoleDataListInternal = new List<RoleDisplayModelBase>();

	// Token: 0x04009DEC RID: 40428
	private RoleDevRoleViewItemDataBase RoleDevRoleViewItemDataInternal;

	// Token: 0x04009DED RID: 40429
	private RoleDevWeaponViewItemDataBase RoleDevWeaponViewItemDataInternal;

	// Token: 0x04009DEE RID: 40430
	private RoleDevPhantomViewItemDataBase RoleDevPhantomViewItemDataInternal;

	// Token: 0x04009DEF RID: 40431
	private RoleDevSkillViewItemDataBase RoleDevSkillViewItemDataInternal;

	// Token: 0x04009DF0 RID: 40432
	[Nullable(1)]
	private readonly HashSet<int> CreatedRoleIdSet = new HashSet<int>();

	// Token: 0x04009DF1 RID: 40433
	[Nullable(1)]
	private readonly Dictionary<int, bool> RoleIdToSkillPlanStateMap = new Dictionary<int, bool>();

	// Token: 0x04009DF2 RID: 40434
	[Nullable(1)]
	private readonly Dictionary<int, ERoleDevWeaponTabType> RoleIdToWeaponTabTypeMap = new Dictionary<int, ERoleDevWeaponTabType>();

	// Token: 0x04009DF3 RID: 40435
	[Nullable(1)]
	private readonly Dictionary<int, int> RoleIdToRecommendPlanIdMap = new Dictionary<int, int>();
}
