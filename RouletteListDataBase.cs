using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

// Token: 0x02002921 RID: 10529
[NullableContext(1)]
[Nullable(0)]
public abstract class RouletteListDataBase
{
	// Token: 0x17001B72 RID: 7026
	// (get) Token: 0x06014E15 RID: 85525
	public abstract ERouletteType RouletteType { get; }

	// Token: 0x17001B73 RID: 7027
	// (get) Token: 0x06014E16 RID: 85526
	public abstract ERoulettePriority Priority { get; }

	// Token: 0x06014E17 RID: 85527
	public abstract List<int> GetRouletteIdList();

	// Token: 0x06014E18 RID: 85528
	public abstract int GetExtraItemId();

	// Token: 0x06014E19 RID: 85529
	public abstract int GetEquipExploreSkillId();

	// Token: 0x06014E1A RID: 85530
	public abstract void Init();

	// Token: 0x06014E1B RID: 85531
	public abstract void Clear();

	// Token: 0x06014E1C RID: 85532
	public abstract bool IsActivate();

	// Token: 0x06014E1D RID: 85533
	public abstract bool IsRouletteReplace();

	// Token: 0x06014E1E RID: 85534
	public abstract bool IsRouletteOpen();

	// Token: 0x06014E1F RID: 85535
	public abstract bool IsMainRouletteCanOpenView(bool checkTips);

	// Token: 0x06014E20 RID: 85536 RVA: 0x005C7AE2 File Offset: 0x005C5CE2
	public virtual void UpdateData(ExploreSkillRoulette exploreList)
	{
		this.RouletteIdListServer = exploreList.SkillIds.ToList<int>();
		this.ExtraItemIdServer = exploreList.ExtraItemId;
		this.EquipExploreSkillIdServer = exploreList.ExploreSkill;
	}

	// Token: 0x06014E21 RID: 85537 RVA: 0x005C7B0D File Offset: 0x005C5D0D
	public bool IsFirstExplorePriority()
	{
		return ModelBase<RouletteModel>.Instance.GetCurrentExploreRouletteListData().RouletteType == this.RouletteType;
	}

	// Token: 0x06014E22 RID: 85538 RVA: 0x005C7B28 File Offset: 0x005C5D28
	public bool IsExploreSkillIdAllowEquip(int skillId)
	{
		ExploreTools exploreTools;
		return ModelBase<RouletteModel>.Instance.UnlockExploreSkillDataMap.TryGetValue(skillId, out exploreTools) && exploreTools.GetRouletteTypeArray().Contains((int)this.RouletteType);
	}

	// Token: 0x06014E23 RID: 85539 RVA: 0x005C7B5D File Offset: 0x005C5D5D
	public IRouletteListSaveData GetRouletteListSaveData()
	{
		return new RouletteListSaveData
		{
			RouletteType = this.RouletteType,
			RouletteIdList = new List<int>(this.RouletteIdListServer),
			ExtraItemId = this.ExtraItemIdServer,
			EquipExploreSkillId = this.EquipExploreSkillIdServer
		};
	}

	// Token: 0x06014E24 RID: 85540
	public abstract Dictionary<ERouletteGridType, List<AssemblyGridData>> CreateAssemblyGridData();

	// Token: 0x06014E25 RID: 85541
	public abstract int? GetRouletteGridId(int index, ERouletteGridType type, bool useDisplay);

	// Token: 0x06014E26 RID: 85542
	public abstract RouletteMainViewProxyBase GetRouletteMainViewProxy();

	// Token: 0x06014E27 RID: 85543
	[return: Nullable(new byte[]
	{
		1,
		0,
		1
	})]
	public abstract List<ValueTuple<List<int>, ERouletteComponentNode, ERouletteGridType>> GetRouletteDataMap();

	// Token: 0x0400A104 RID: 41220
	public List<int> RouletteIdListServer = new List<int>(new int[8]);

	// Token: 0x0400A105 RID: 41221
	public int ExtraItemIdServer;

	// Token: 0x0400A106 RID: 41222
	public int EquipExploreSkillIdServer;
}
