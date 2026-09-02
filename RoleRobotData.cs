using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;

// Token: 0x020027C3 RID: 10179
[NullableContext(1)]
[Nullable(0)]
public class RoleRobotData : RoleDataBase
{
	// Token: 0x06014236 RID: 82486 RVA: 0x0059FC00 File Offset: 0x0059DE00
	public RoleRobotData(int id) : base(id)
	{
		this.SetDefaultData();
	}

	// Token: 0x06014237 RID: 82487 RVA: 0x0059FC0F File Offset: 0x0059DE0F
	protected void SetDefaultData()
	{
		this.SetLevelData();
		this.SetSkillData();
		this.SetResonanceData();
		this.SetWeaponData();
		this.SetPhantomData();
		this.SetSkinData();
	}

	// Token: 0x06014238 RID: 82488 RVA: 0x0059FC38 File Offset: 0x0059DE38
	private void SetLevelData()
	{
		TrialRoleInfo? trialRoleConfig = ConfigBase<RoleConfig>.Instance.GetTrialRoleConfig(this.Id);
		if (trialRoleConfig == null)
		{
			return;
		}
		RoleLevelData levelData = base.GetLevelData();
		levelData.SetLevel(trialRoleConfig.Value.Level);
		RoleInfo roleConfig = base.GetRoleConfig();
		IReadOnlyList<RoleBreach> roleBreachList = ConfigBase<RoleConfig>.Instance.GetRoleBreachList(roleConfig.BreachId);
		if (roleBreachList == null)
		{
			return;
		}
		foreach (RoleBreach roleBreach in roleBreachList)
		{
			if (trialRoleConfig.Value.Level <= roleBreach.MaxLevel)
			{
				levelData.SetBreachLevel(roleBreach.BreachLevel);
				break;
			}
		}
	}

	// Token: 0x06014239 RID: 82489 RVA: 0x0059FCFC File Offset: 0x0059DEFC
	private void SetSkillData()
	{
		TrialRoleInfo? trialRoleConfig = ConfigBase<RoleConfig>.Instance.GetTrialRoleConfig(this.Id);
		if (trialRoleConfig == null)
		{
			return;
		}
		RoleSkillData skillData = base.GetSkillData();
		int skillId = base.GetRoleConfig().SkillId;
		int roleId = this.GetRoleId();
		bool flag = ModelBase<RoleModel>.Instance.ClientCheckRoleIsUpgradeLightMainRole(roleId);
		foreach (Aki.Config.Skill skill in skillData.GetSkillList())
		{
			int trialSkillLevel = this.GetTrialSkillLevel(skill.Id);
			int level = (trialSkillLevel < trialRoleConfig.Value.UnlockSkillLevel) ? trialSkillLevel : trialRoleConfig.Value.UnlockSkillLevel;
			SkillTree? skillTreeNodeByGroupIdAndSkillId = ConfigBase<RoleSkillConfig>.Instance.GetSkillTreeNodeByGroupIdAndSkillId(skillId, skill.Id);
			if (skillTreeNodeByGroupIdAndSkillId != null || flag)
			{
				if (skillTreeNodeByGroupIdAndSkillId != null && skillTreeNodeByGroupIdAndSkillId.Value.NodeType == 3)
				{
					skillData.SetSkillLevel(skill.Id, 0);
				}
				else
				{
					skillData.SetSkillLevel(skill.Id, level);
				}
				skillData.SetSkillReferenceMapBySkillId(skill.Id);
			}
		}
		new List<SkillNodeDataInfo>();
		Dictionary<int, SkillNodeDataInfo> dictionary = new Dictionary<int, SkillNodeDataInfo>();
		foreach (int nodeIndex in trialRoleConfig.Value.UnlockSkillNodeList())
		{
			this.AddSkillNodeData(skillId, nodeIndex, dictionary);
		}
		this.AddSkillNodeData(skillId, 8, dictionary);
		this.AddSkillNodeData(skillId, 17, dictionary);
		skillData.SetSkillNodeStateData(dictionary);
	}

	// Token: 0x0601423A RID: 82490 RVA: 0x0059FE80 File Offset: 0x0059E080
	private void AddSkillNodeData(int skillGroupId, int nodeIndex, Dictionary<int, SkillNodeDataInfo> skillNodeDataMap)
	{
		SkillTree? skillTreeNodeByGroupIdAndIndex = ConfigBase<RoleSkillConfig>.Instance.GetSkillTreeNodeByGroupIdAndIndex(skillGroupId, nodeIndex);
		int? num = (skillTreeNodeByGroupIdAndIndex != null) ? new int?(skillTreeNodeByGroupIdAndIndex.GetValueOrDefault().NodeType) : null;
		if (num.GetValueOrDefault() == 4 || num.GetValueOrDefault() == 3)
		{
			int id = skillTreeNodeByGroupIdAndIndex.Value.Id;
			SkillNodeDataInfo value = new SkillNodeDataInfo(id, true, skillTreeNodeByGroupIdAndIndex.Value.SkillId);
			skillNodeDataMap[id] = value;
		}
	}

	// Token: 0x0601423B RID: 82491 RVA: 0x0059FF0C File Offset: 0x0059E10C
	private int GetTrialSkillLevel(int skillId)
	{
		IReadOnlyList<SkillLevel> skillLevelConfigList = ConfigBase<RoleSkillConfig>.Instance.GetSkillLevelConfigList(skillId);
		if (skillLevelConfigList == null || skillLevelConfigList.Count == 0)
		{
			return 0;
		}
		List<SkillLevel> list = (from aConfig in skillLevelConfigList
		orderby aConfig.Id
		select aConfig).ToList<SkillLevel>();
		return list[list.Count - 1].SkillId;
	}

	// Token: 0x0601423C RID: 82492 RVA: 0x0059FF74 File Offset: 0x0059E174
	private void SetResonanceData()
	{
		TrialRoleInfo? trialRoleConfig = ConfigBase<RoleConfig>.Instance.GetTrialRoleConfig(this.Id);
		if (trialRoleConfig == null)
		{
			return;
		}
		base.GetResonanceData().SetResonantChainGroupIndex(trialRoleConfig.Value.ResonanceLevel);
	}

	// Token: 0x0601423D RID: 82493 RVA: 0x0059FFB8 File Offset: 0x0059E1B8
	private void SetWeaponData()
	{
		TrialRoleInfo? trialRoleConfig = ConfigBase<RoleConfig>.Instance.GetTrialRoleConfig(this.Id);
		if (trialRoleConfig == null)
		{
			return;
		}
		this.WeaponTrialData = new WeaponTrialData();
		this.WeaponTrialData.SetTrialId(trialRoleConfig.Value.TrailWeapon, true);
		this.WeaponTrialData.SetRoleId(this.Id);
	}

	// Token: 0x0601423E RID: 82494 RVA: 0x005A0018 File Offset: 0x0059E218
	private void SetPhantomData()
	{
		RolePhantomData phantomData = base.GetPhantomData();
		phantomData.SetIsTrial(true);
		TrialRoleInfo? trialRoleConfig = ConfigBase<RoleConfig>.Instance.GetTrialRoleConfig(this.Id);
		if (trialRoleConfig == null)
		{
			return;
		}
		int i = 0;
		int num = trialRoleConfig.Value.PhantomEquipList().Length;
		while (i < num)
		{
			IntPair intPair = trialRoleConfig.Value.PhantomEquipList()[i];
			TrailPhantomProp? trialPhantomPropConfig = ConfigBase<PhantomBattleConfig>.Instance.GetTrialPhantomPropConfig(intPair.Item2);
			if (trialPhantomPropConfig != null)
			{
				PhantomTrialBattleData phantomTrialBattleData = new PhantomTrialBattleData();
				phantomTrialBattleData.SetIncId(PhantomDataBase.GenerateLocalUniqueId(this.GetRoleId(), i));
				phantomTrialBattleData.SetConfigId(intPair.Item1);
				phantomTrialBattleData.SetPhantomLevel(trialPhantomPropConfig.Value.Level);
				phantomTrialBattleData.SetSlotIndex(i);
				phantomTrialBattleData.SetFetterGroupId(trialPhantomPropConfig.Value.FetterGroupId);
				foreach (int id in trialPhantomPropConfig.Value.MainProps())
				{
					ConfigPropValue trailPhantomPropItemById = ConfigBase<PhantomBattleConfig>.Instance.GetTrailPhantomPropItemById(id);
					int phantomGrowthValueByGrowthIdAndLevel = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomGrowthValueByGrowthIdAndLevel(trialPhantomPropConfig.Value.MainPropGrowth, trialPhantomPropConfig.Value.Level);
					double attributeValue = TipsDataTool.GetAttributeValue((double)trailPhantomPropItemById.Value, (double)phantomGrowthValueByGrowthIdAndLevel, false);
					phantomTrialBattleData.SetMainPropValue(trailPhantomPropItemById.Id, attributeValue, trailPhantomPropItemById.IsRatio);
				}
				foreach (int id2 in trialPhantomPropConfig.Value.SubPropList())
				{
					ConfigPropValue trailPhantomPropItemById2 = ConfigBase<PhantomBattleConfig>.Instance.GetTrailPhantomPropItemById(id2);
					phantomTrialBattleData.SetSubPropValue(trailPhantomPropItemById2.Id, (double)trailPhantomPropItemById2.Value, trailPhantomPropItemById2.IsRatio);
				}
				phantomData.SetDataMap(i, phantomTrialBattleData);
				ModelBase<PhantomBattleModel>.Instance.SetRobotPhantomData(phantomTrialBattleData.GetIncrId(), phantomTrialBattleData);
			}
			i++;
		}
	}

	// Token: 0x0601423F RID: 82495 RVA: 0x005A020C File Offset: 0x0059E40C
	private void SetSkinData()
	{
		TrialRoleInfo? trialRoleConfig = ConfigBase<RoleConfig>.Instance.GetTrialRoleConfig(this.Id);
		if (trialRoleConfig == null)
		{
			return;
		}
		if (trialRoleConfig.Value.RoleSkin > 0)
		{
			base.SetRoleSkinId(trialRoleConfig.Value.RoleSkin);
		}
	}

	// Token: 0x06014240 RID: 82496 RVA: 0x005A025C File Offset: 0x0059E45C
	public override int GetRoleId()
	{
		TrialRoleInfo? trialRoleConfig = ConfigBase<RoleConfig>.Instance.GetTrialRoleConfig(this.Id);
		if (trialRoleConfig == null)
		{
			return 0;
		}
		return trialRoleConfig.Value.ParentId;
	}

	// Token: 0x06014241 RID: 82497 RVA: 0x005A0294 File Offset: 0x0059E494
	public override bool IsTrialRole()
	{
		return true;
	}

	// Token: 0x06014242 RID: 82498 RVA: 0x005A0298 File Offset: 0x0059E498
	public override string GetName(int? playerId = null)
	{
		return ConfigBase<RoleConfig>.Instance.GetRoleName(base.GetRoleConfig().Name);
	}

	// Token: 0x06014243 RID: 82499 RVA: 0x005A02BD File Offset: 0x0059E4BD
	public void SetName(string name)
	{
		this.Name = name;
	}

	// Token: 0x06014244 RID: 82500 RVA: 0x005A02C6 File Offset: 0x0059E4C6
	public override bool CanChangeName()
	{
		return false;
	}

	// Token: 0x06014245 RID: 82501 RVA: 0x005A02C9 File Offset: 0x0059E4C9
	[NullableContext(2)]
	public WeaponTrialData GetWeaponData()
	{
		return this.WeaponTrialData;
	}

	// Token: 0x06014246 RID: 82502 RVA: 0x005A02D1 File Offset: 0x0059E4D1
	public override bool IsOnlineRole()
	{
		return false;
	}

	// Token: 0x06014247 RID: 82503 RVA: 0x005A02D4 File Offset: 0x0059E4D4
	public override int GetRoleCreateTime()
	{
		return 0;
	}

	// Token: 0x06014248 RID: 82504 RVA: 0x005A02D7 File Offset: 0x0059E4D7
	public override bool GetIsNew()
	{
		return false;
	}

	// Token: 0x06014249 RID: 82505 RVA: 0x005A02DA File Offset: 0x0059E4DA
	public virtual bool CanEditInFormation()
	{
		return false;
	}

	// Token: 0x0601424A RID: 82506 RVA: 0x005A02DD File Offset: 0x0059E4DD
	public virtual bool IsVisibleInFormation()
	{
		return false;
	}

	// Token: 0x0601424B RID: 82507 RVA: 0x005A02E0 File Offset: 0x0059E4E0
	public int GetTrialRoleId()
	{
		return this.Id;
	}

	// Token: 0x04009C8E RID: 40078
	[Nullable(2)]
	private WeaponTrialData WeaponTrialData;
}
