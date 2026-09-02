using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay;

// Token: 0x020027C0 RID: 10176
[NullableContext(1)]
[Nullable(0)]
public class RoleSkillData : RoleModuleDataBase
{
	// Token: 0x060141F2 RID: 82418 RVA: 0x0059EB48 File Offset: 0x0059CD48
	public RoleSkillData(int roleId) : base(roleId)
	{
	}

	// Token: 0x060141F3 RID: 82419 RVA: 0x0059EBA0 File Offset: 0x0059CDA0
	public int GetSkillNodeLevel(SkillTree config)
	{
		int result = 0;
		ESkillTreeNodeType nodeType = (ESkillTreeNodeType)config.NodeType;
		if (nodeType == ESkillTreeNodeType.InnerSkill || nodeType == ESkillTreeNodeType.InnerPassiveSkill)
		{
			int skillId = config.SkillId;
			result = this.GetSkillLevel(skillId);
		}
		else if (this.IsSkillTreeNodeActive(config.Id))
		{
			result = 1;
		}
		return result;
	}

	// Token: 0x060141F4 RID: 82420 RVA: 0x0059EBE3 File Offset: 0x0059CDE3
	public int GetSkillLevel(int skillId)
	{
		if (!this.RoleSkillMap.ContainsKey(skillId))
		{
			return 0;
		}
		return this.RoleSkillMap[skillId];
	}

	// Token: 0x060141F5 RID: 82421 RVA: 0x0059EC04 File Offset: 0x0059CE04
	public void SetSkillLevel(int key, int level)
	{
		this.RoleSkillMap[key] = level;
		if (level > 0)
		{
			int upgradeSkillId = ConfigBase<RoleSkillConfig>.Instance.GetSkillConfigById(key).Value.UpgradeSkillId;
			if (upgradeSkillId > 0)
			{
				this.RoleUpgradeSkillMap[upgradeSkillId] = key;
			}
		}
	}

	// Token: 0x060141F6 RID: 82422 RVA: 0x0059EC50 File Offset: 0x0059CE50
	public int[] GetAllSkillLevel()
	{
		int[] array = new int[this.RoleSkillMap.Values.Count];
		this.RoleSkillMap.Values.CopyTo(array, 0);
		return array;
	}

	// Token: 0x060141F7 RID: 82423 RVA: 0x0059EC88 File Offset: 0x0059CE88
	public Aki.Config.Skill[] GetSkillList()
	{
		if (this.SkillConfigList.Count > 0)
		{
			return this.SkillConfigList.ToArray();
		}
		int skillId = base.GetRoleConfig().SkillId;
		List<Aki.Config.Skill> list = ConfigCommon.ToList<Aki.Config.Skill>(ConfigBase<RoleSkillConfig>.Instance.GetSkillList(skillId));
		list.Sort((Aki.Config.Skill aSkill, Aki.Config.Skill bSkill) => aSkill.SortIndex - bSkill.SortIndex);
		this.InitSkillConfigCache(list.ToList<Aki.Config.Skill>());
		return list.ToArray();
	}

	// Token: 0x060141F8 RID: 82424 RVA: 0x0059ED08 File Offset: 0x0059CF08
	private void InitSkillConfigCache(List<Aki.Config.Skill> skillConfigs)
	{
		int count = skillConfigs.Count;
		for (int i = 0; i < count; i++)
		{
			Aki.Config.Skill skill = skillConfigs[i];
			this.SkillConfigList.Add(skill);
			this.SkillConfigMap[skill.Id] = skill;
		}
	}

	// Token: 0x060141F9 RID: 82425 RVA: 0x0059ED50 File Offset: 0x0059CF50
	public Aki.Config.Skill? GetSkillConfigFromCache(int id)
	{
		if (this.SkillConfigMap.Count == 0)
		{
			this.GetSkillList();
		}
		if (!this.SkillConfigMap.ContainsKey(id))
		{
			return null;
		}
		return new Aki.Config.Skill?(this.SkillConfigMap[id]);
	}

	// Token: 0x060141FA RID: 82426 RVA: 0x0059ED9A File Offset: 0x0059CF9A
	public bool IsHasSkill(int id)
	{
		return this.RoleSkillMap.ContainsKey(id);
	}

	// Token: 0x060141FB RID: 82427 RVA: 0x0059EDA8 File Offset: 0x0059CFA8
	protected IList<long> GetReferenceList(int skillId, ERoleSkillReferenceType type)
	{
		Aki.Config.Skill? skillConfigById = ConfigBase<RoleSkillConfig>.Instance.GetSkillConfigById(skillId);
		switch (type)
		{
		case ERoleSkillReferenceType.SkillInfo:
		{
			IList<long> list = new List<long>();
			foreach (int num in skillConfigById.Value.SkillInfoListIter())
			{
				list.Add((long)num);
			}
			return list;
		}
		case ERoleSkillReferenceType.Buff:
			return skillConfigById.Value.GetBuffListArray();
		case ERoleSkillReferenceType.Damage:
			return skillConfigById.Value.GetDamageListArray();
		default:
			return new List<long>();
		}
	}

	// Token: 0x060141FC RID: 82428 RVA: 0x0059EE50 File Offset: 0x0059D050
	protected int GetDefaultSkillLevel(ERoleSkillReferenceType type)
	{
		switch (type)
		{
		case ERoleSkillReferenceType.SkillInfo:
			return 1;
		case ERoleSkillReferenceType.Buff:
			return -1;
		case ERoleSkillReferenceType.Damage:
			return -1;
		default:
			return -1;
		}
	}

	// Token: 0x060141FD RID: 82429 RVA: 0x0059EE70 File Offset: 0x0059D070
	public void SetSkillReferenceMapBySkillId(int skillId)
	{
		foreach (ERoleSkillReferenceType eroleSkillReferenceType in Enum.GetValues<ERoleSkillReferenceType>())
		{
			if (!this.RoleSkillReferenceMap.ContainsKey(eroleSkillReferenceType))
			{
				this.RoleSkillReferenceMap[eroleSkillReferenceType] = new Dictionary<long, int>();
			}
			Dictionary<long, int> dictionary = this.RoleSkillReferenceMap[eroleSkillReferenceType];
			foreach (long num in this.GetReferenceList(skillId, eroleSkillReferenceType))
			{
				if (!dictionary.ContainsKey(num))
				{
					dictionary[num] = skillId;
				}
				else if (dictionary[num] != skillId)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Role;
					ELogAuthor author = ELogAuthor.LZK;
					string message = "技能表里的这个ID不能对应多个技能";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ID", num);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
			}
		}
	}

	// Token: 0x060141FE RID: 82430 RVA: 0x0059EF58 File Offset: 0x0059D158
	[NullableContext(2)]
	public int GetReferencedSkillLevel(long id, ERoleSkillReferenceType type, Entity entity = null)
	{
		if (!this.RoleSkillReferenceMap.ContainsKey(type) || !this.RoleSkillReferenceMap[type].ContainsKey(id))
		{
			return this.GetDefaultSkillLevel(type);
		}
		int num = this.RoleSkillReferenceMap[type][id];
		int skillLevel = this.GetSkillLevel(num);
		Aki.Config.Skill? skillConfigFromCache = this.GetSkillConfigFromCache(num);
		if (entity != null && skillConfigFromCache != null)
		{
			return AddSkillLevelEffect.ApplyEffects(entity, skillConfigFromCache.Value, skillLevel);
		}
		return skillLevel;
	}

	// Token: 0x060141FF RID: 82431 RVA: 0x0059EFCE File Offset: 0x0059D1CE
	public void SetSkillNodeStateData(Dictionary<int, SkillNodeDataInfo> skillNodeState)
	{
		this.SkillNodeDataMap = skillNodeState;
		Singleton<EventSystem>.Instance.Emit(EEventName.SkillTreeRefresh);
	}

	// Token: 0x06014200 RID: 82432 RVA: 0x0059EFE7 File Offset: 0x0059D1E7
	public Dictionary<int, SkillNodeDataInfo> GetSkillNodeStateData()
	{
		return this.SkillNodeDataMap;
	}

	// Token: 0x06014201 RID: 82433 RVA: 0x0059EFEF File Offset: 0x0059D1EF
	public ESkillTreeNodeState GetSkillTreeNodeState(SkillTree skillTree, int roleId)
	{
		if (skillTree.SkillId > 0 && skillTree.NodeType != 3)
		{
			return this.GetSkillTreeSkillNodeState(skillTree, roleId);
		}
		return this.GetSkillTreeAttributeNodeState(skillTree, roleId);
	}

	// Token: 0x06014202 RID: 82434 RVA: 0x0059F018 File Offset: 0x0059D218
	public ESkillTreeNodeState GetSkillTreeSkillNodeState(SkillTree skillTree, int roleId)
	{
		int skillId = skillTree.SkillId;
		Aki.Config.Skill value = ConfigBase<RoleSkillConfig>.Instance.GetSkillConfigById(skillId).Value;
		int skillLevel = this.GetSkillLevel(skillId);
		int maxSkillLevel = value.MaxSkillLevel;
		if (skillLevel == maxSkillLevel)
		{
			return ESkillTreeNodeState.Active;
		}
		if (this.GetSkillTreeUnsatisfiedCondition(skillTree) != null)
		{
			return ESkillTreeNodeState.Lock;
		}
		int roleSkillTreeNodeUnlockConditionId = this.GetRoleSkillTreeNodeUnlockConditionId(skillTree);
		if (!ControllerBase<LevelGeneralController>.Instance.CheckCondition(roleSkillTreeNodeUnlockConditionId.ToString(), null, true, new object[]
		{
			roleId
		}))
		{
			return ESkillTreeNodeState.Lock;
		}
		return ESkillTreeNodeState.Inactive;
	}

	// Token: 0x06014203 RID: 82435 RVA: 0x0059F09C File Offset: 0x0059D29C
	public ESkillTreeNodeState GetSkillTreeAttributeNodeState(SkillTree skillTree, int roleId)
	{
		if (this.IsSkillTreeNodeActive(skillTree.Id))
		{
			return ESkillTreeNodeState.Active;
		}
		if (this.GetSkillTreeUnsatisfiedCondition(skillTree) != null)
		{
			return ESkillTreeNodeState.Lock;
		}
		int roleSkillTreeNodeUnlockConditionId = this.GetRoleSkillTreeNodeUnlockConditionId(skillTree);
		if (roleSkillTreeNodeUnlockConditionId > 0 && !ControllerBase<LevelGeneralController>.Instance.CheckCondition(roleSkillTreeNodeUnlockConditionId.ToString(), null, true, new object[]
		{
			roleId
		}))
		{
			return ESkillTreeNodeState.Lock;
		}
		return ESkillTreeNodeState.Inactive;
	}

	// Token: 0x06014204 RID: 82436 RVA: 0x0059F104 File Offset: 0x0059D304
	[NullableContext(2)]
	public string GetUnlockConditionTextId(SkillTree skillTree)
	{
		SkillCondition? skillTreeUnsatisfiedCondition = this.GetSkillTreeUnsatisfiedCondition(skillTree);
		if (skillTreeUnsatisfiedCondition != null)
		{
			return skillTreeUnsatisfiedCondition.Value.Description;
		}
		int roleSkillTreeNodeUnlockConditionId = this.GetRoleSkillTreeNodeUnlockConditionId(skillTree);
		if (roleSkillTreeNodeUnlockConditionId > 0)
		{
			return LevelGeneralCommons.GetConditionGroupHintText(roleSkillTreeNodeUnlockConditionId);
		}
		return null;
	}

	// Token: 0x06014205 RID: 82437 RVA: 0x0059F148 File Offset: 0x0059D348
	public int GetRoleSkillTreeNodeUnlockConditionId(SkillTree skillTree)
	{
		int skillId = skillTree.SkillId;
		if (skillId > 0)
		{
			Aki.Config.Skill? skillConfigById = ConfigBase<RoleSkillConfig>.Instance.GetSkillConfigById(skillId);
			int skillLevel = this.GetSkillLevel(skillId);
			return ConfigBase<RoleSkillConfig>.Instance.GetSkillLevelConfigByGroupIdAndLevel(skillConfigById.Value.SkillLevelGroupId, skillLevel + 1).Value.Condition;
		}
		return skillTree.UnLockCondition;
	}

	// Token: 0x06014206 RID: 82438 RVA: 0x0059F1AC File Offset: 0x0059D3AC
	public bool IsSkillTreeNodeActive(int id)
	{
		SkillNodeDataInfo valueOrDefault = this.GetSkillNodeStateData().GetValueOrDefault(id);
		return valueOrDefault != null && valueOrDefault.IsActive;
	}

	// Token: 0x06014207 RID: 82439 RVA: 0x0059F1D4 File Offset: 0x0059D3D4
	public SkillCondition? GetSkillTreeUnsatisfiedCondition(SkillTree skillTree)
	{
		foreach (int skillConditionId in skillTree.ConditionIter())
		{
			SkillCondition? skillConditionById = ConfigBase<RoleSkillConfig>.Instance.GetSkillConditionById(skillConditionId);
			int nodeGroup = skillTree.NodeGroup;
			if (skillConditionById != null)
			{
				if (skillConditionById.Value.ConditionType == 1)
				{
					using (IEnumerator<DicIntInt> enumerator2 = skillConditionById.Value.ConditionParamIter().GetEnumerator())
					{
						while (enumerator2.MoveNext())
						{
							DicIntInt dicIntInt = enumerator2.Current;
							int key = dicIntInt.Key;
							int value = dicIntInt.Value;
							if (this.GetSkillNodeLevel(ConfigBase<RoleSkillConfig>.Instance.GetSkillTreeNodeByGroupIdAndIndex(nodeGroup, key).Value) < value)
							{
								return skillConditionById;
							}
						}
						continue;
					}
				}
				if (skillConditionById.Value.ConditionType == 2)
				{
					int parentNodesLength = skillTree.ParentNodesLength;
					for (int i = 0; i < parentNodesLength; i++)
					{
						int nodeIndex = skillTree.ParentNodes()[i];
						if (this.GetSkillNodeLevel(ConfigBase<RoleSkillConfig>.Instance.GetSkillTreeNodeByGroupIdAndIndex(nodeGroup, nodeIndex).Value) == 0)
						{
							return skillConditionById;
						}
					}
				}
			}
		}
		return null;
	}

	// Token: 0x06014208 RID: 82440 RVA: 0x0059F354 File Offset: 0x0059D554
	public bool IsSkillTreeNodeConsumeSatisfied(int nodeId)
	{
		int skillNodeLevel = this.GetSkillNodeLevel(ConfigBase<RoleSkillConfig>.Instance.GetSkillTreeNode(nodeId).Value);
		IEnumerable<DicIntInt?> roleSkillTreeConsume = ConfigBase<RoleSkillConfig>.Instance.GetRoleSkillTreeConsume(nodeId, skillNodeLevel + 1);
		if (roleSkillTreeConsume != null)
		{
			foreach (DicIntInt? dicIntInt in roleSkillTreeConsume)
			{
				int key = dicIntInt.Value.Key;
				int value = dicIntInt.Value.Value;
				if (ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(key, 0) < value)
				{
					return false;
				}
			}
			return true;
		}
		return true;
	}

	// Token: 0x06014209 RID: 82441 RVA: 0x0059F400 File Offset: 0x0059D600
	public int GetSkillIdAfterUpgrade(int skillIdBeforeUpgrade)
	{
		if (!this.RoleUpgradeSkillMap.ContainsKey(skillIdBeforeUpgrade))
		{
			return 0;
		}
		return this.RoleUpgradeSkillMap[skillIdBeforeUpgrade];
	}

	// Token: 0x0601420A RID: 82442 RVA: 0x0059F41E File Offset: 0x0059D61E
	public bool HasAnySkillUpgrade()
	{
		return this.RoleUpgradeSkillMap.Count > 0;
	}

	// Token: 0x0601420B RID: 82443 RVA: 0x0059F430 File Offset: 0x0059D630
	public ESkillShowTagType GetSkillShowTagType(int skillId)
	{
		Aki.Config.Skill? skillConfigById = ConfigBase<RoleSkillConfig>.Instance.GetSkillConfigById(skillId);
		if (skillConfigById != null)
		{
			return (ESkillShowTagType)skillConfigById.Value.SkillShowTagType;
		}
		return ESkillShowTagType.None;
	}

	// Token: 0x04009C80 RID: 40064
	protected Dictionary<int, int> RoleSkillMap = new Dictionary<int, int>();

	// Token: 0x04009C81 RID: 40065
	protected Dictionary<int, int> RoleUpgradeSkillMap = new Dictionary<int, int>();

	// Token: 0x04009C82 RID: 40066
	protected Dictionary<ERoleSkillReferenceType, Dictionary<long, int>> RoleSkillReferenceMap = new Dictionary<ERoleSkillReferenceType, Dictionary<long, int>>();

	// Token: 0x04009C83 RID: 40067
	protected Dictionary<int, SkillNodeDataInfo> SkillNodeDataMap = new Dictionary<int, SkillNodeDataInfo>();

	// Token: 0x04009C84 RID: 40068
	private readonly Dictionary<int, Aki.Config.Skill> SkillConfigMap = new Dictionary<int, Aki.Config.Skill>();

	// Token: 0x04009C85 RID: 40069
	private readonly List<Aki.Config.Skill> SkillConfigList = new List<Aki.Config.Skill>();
}
