using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RoleLangCustomModel;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Module.InstanceDungeon;

// Token: 0x02002904 RID: 10500
[NullableContext(1)]
[Nullable(0)]
public class RoleInstance : RoleDataBase
{
	// Token: 0x06014DA6 RID: 85414 RVA: 0x005C6D6F File Offset: 0x005C4F6F
	public RoleInstance(int id) : base(id)
	{
	}

	// Token: 0x06014DA7 RID: 85415 RVA: 0x005C6D78 File Offset: 0x005C4F78
	public override bool IsTrialRole()
	{
		return false;
	}

	// Token: 0x06014DA8 RID: 85416 RVA: 0x005C6D7C File Offset: 0x005C4F7C
	public void SetRoleName(string name)
	{
		if (!StringUtils.IsEmpty(name))
		{
			this.Name = name;
			return;
		}
		RoleInfo roleConfig = base.GetRoleConfig();
		this.Name = ConfigBase<RoleConfig>.Instance.GetRoleName(roleConfig.Name);
	}

	// Token: 0x06014DA9 RID: 85417 RVA: 0x005C6DB7 File Offset: 0x005C4FB7
	public override string GetName(int? playerId = null)
	{
		if (ModelBase<PlayerInfoModel>.Instance.IsPlayerId(this.Id, playerId))
		{
			return ModelBase<FunctionModel>.Instance.GetPlayerName();
		}
		return this.GetRoleRealName();
	}

	// Token: 0x06014DAA RID: 85418 RVA: 0x005C6DE0 File Offset: 0x005C4FE0
	public string GetRoleRealName()
	{
		RoleSkinData roleSkinData = ModelBase<RoleSkinModel>.Instance.GetRoleSkinData(this.GetRoleSkinId());
		return ConfigBase<RoleConfig>.Instance.GetRoleName(roleSkinData.GetName());
	}

	// Token: 0x06014DAB RID: 85419 RVA: 0x005C6E0E File Offset: 0x005C500E
	public int GetSkillInfoLevel(long infoId)
	{
		return base.GetSkillData().GetReferencedSkillLevel(infoId, ERoleSkillReferenceType.SkillInfo, null);
	}

	// Token: 0x06014DAC RID: 85420 RVA: 0x005C6E1E File Offset: 0x005C501E
	public override int GetRoleId()
	{
		return this.Id;
	}

	// Token: 0x06014DAD RID: 85421 RVA: 0x005C6E26 File Offset: 0x005C5026
	public override int GetRoleCreateTime()
	{
		return this.CreateTime;
	}

	// Token: 0x06014DAE RID: 85422 RVA: 0x005C6E30 File Offset: 0x005C5030
	public void RefreshSkillInfo(int skillId, int skillLevel)
	{
		RoleSkillData skillData = base.GetSkillData();
		skillData.SetSkillLevel(skillId, skillLevel);
		skillData.SetSkillReferenceMapBySkillId(skillId);
		ArrayIntInt arrayIntInt = new ArrayIntInt();
		arrayIntInt.Key = skillId;
		arrayIntInt.Value = skillLevel;
		Singleton<EventSystem>.Instance.EmitWithTarget<int, ArrayIntInt>(this, EEventName.RoleSkillLevelUp, this.GetRoleId(), arrayIntInt);
	}

	// Token: 0x06014DAF RID: 85423 RVA: 0x005C6E80 File Offset: 0x005C5080
	public void RefreshRoleAttr(ArrayIntInt[] baseAttr, ArrayIntInt[] addAttr)
	{
		RoleAttributeData attributeData = base.GetAttributeData();
		Dictionary<int, int> oldRoleBaseAttr = attributeData.GetOldRoleBaseAttr();
		attributeData.ClearRoleBaseAttr();
		foreach (ArrayIntInt arrayIntInt in baseAttr)
		{
			attributeData.SetRoleBaseAttr(arrayIntInt.Key, arrayIntInt.Value);
			oldRoleBaseAttr[arrayIntInt.Key] = arrayIntInt.Value;
		}
		Dictionary<int, int> oldRoleAddAttr = attributeData.GetOldRoleAddAttr();
		attributeData.ClearRoleAddAttr();
		foreach (ArrayIntInt arrayIntInt2 in addAttr)
		{
			attributeData.SetRoleAddAttr(arrayIntInt2.Key, arrayIntInt2.Value);
			oldRoleAddAttr[arrayIntInt2.Key] = arrayIntInt2.Value;
		}
		int instanceId = ModelBase<InstanceDungeonEntranceModel>.Instance.InstanceId;
		if (instanceId != 0 && ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId).Value.ShareAttri == 0)
		{
			oldRoleBaseAttr.Remove(3);
			oldRoleAddAttr.Remove(3);
		}
		Singleton<EventSystem>.Instance.EmitWithTarget<IReadOnlyDictionary<int, int>, IReadOnlyDictionary<int, int>>(this, EEventName.RoleRefreshAttribute, oldRoleBaseAttr, oldRoleAddAttr);
		Singleton<EventSystem>.Instance.Emit<IReadOnlyDictionary<int, int>, IReadOnlyDictionary<int, int>>(EEventName.RoleRefreshAttribute, oldRoleBaseAttr, oldRoleAddAttr);
	}

	// Token: 0x06014DB0 RID: 85424 RVA: 0x005C6F9C File Offset: 0x005C519C
	public void RefreshRoleInfo(roleInfo roleInfo)
	{
		this.SetRoleName(roleInfo.Name);
		this.CreateTime = (int)roleInfo.CreateTime;
		RoleLevelData levelData = base.GetLevelData();
		levelData.SetLevel(roleInfo.Level);
		levelData.SetExp(roleInfo.Exp);
		levelData.SetBreachLevel(roleInfo.Breakthrough);
		RoleSkillData skillData = base.GetSkillData();
		foreach (ArrayIntInt arrayIntInt in roleInfo.Skills)
		{
			skillData.SetSkillLevel(arrayIntInt.Key, arrayIntInt.Value);
			skillData.SetSkillReferenceMapBySkillId(arrayIntInt.Key);
		}
		RolePhantomData phantomData = base.GetPhantomData();
		foreach (ArrayIntInt arrayIntInt2 in roleInfo.Phantom)
		{
			phantomData.RefreshPhantom(arrayIntInt2.Key, arrayIntInt2.Value);
		}
		int count = roleInfo.SkillNodeState.Count;
		Dictionary<int, SkillNodeDataInfo> dictionary = new Dictionary<int, SkillNodeDataInfo>();
		for (int i = 0; i < count; i++)
		{
			ArraySkillNode arraySkillNode = roleInfo.SkillNodeState[i];
			int skillNodeId = arraySkillNode.SkillNodeId;
			SkillNodeDataInfo value = new SkillNodeDataInfo(skillNodeId, arraySkillNode.IsActive, arraySkillNode.SkillId);
			dictionary.Add(skillNodeId, value);
		}
		skillData.SetSkillNodeStateData(dictionary);
		this.RefreshRoleAttr(roleInfo.BaseProp.ToArray<ArrayIntInt>(), roleInfo.AddProp.ToArray<ArrayIntInt>());
		foreach (ResonInfo resonance in roleInfo.Reson)
		{
			this.RefreshResonance(resonance);
		}
		base.GetResonanceData().SetResonantChainGroupIndex(roleInfo.ResonantChainGroupIndex);
		base.SetRoleSkinId(roleInfo.SkinId);
		base.SetBackgroundMusicEnabled(roleInfo.EnableSelfBgm);
		if (ModelBase<RoleLangCustomModel>.Instance.GetStartLoadingInited())
		{
			ModelBase<RoleLangCustomModel>.Instance.ApplyPlayerVoice(roleInfo.RoleId, false);
		}
	}

	// Token: 0x06014DB1 RID: 85425 RVA: 0x005C71B0 File Offset: 0x005C53B0
	public void RefreshResonance(ResonInfo resonance)
	{
		RoleResonanceData resonanceData = base.GetResonanceData();
		ResonanceDataInfo resonance2 = new ResonanceDataInfo(resonance.ResonId, resonance.IsOpen, resonance.Increase);
		resonanceData.SetResonance(resonance2);
	}

	// Token: 0x06014DB2 RID: 85426 RVA: 0x005C71E4 File Offset: 0x005C53E4
	public override bool CanChangeName()
	{
		return !ModelBase<PlayerInfoModel>.Instance.IsPlayerId(this.Id, null) || !ConfigBase<PlayerInfoConfig>.Instance.GetIsUseAccountName();
	}

	// Token: 0x06014DB3 RID: 85427 RVA: 0x005C721B File Offset: 0x005C541B
	public override bool IsOnlineRole()
	{
		return false;
	}

	// Token: 0x06014DB4 RID: 85428 RVA: 0x005C721E File Offset: 0x005C541E
	public override bool GetIsNew()
	{
		return ModelBase<NewFlagModel>.Instance.HasNewFlag(ELocalStoragePlayerKey.RoleDataItem, this.Id);
	}

	// Token: 0x06014DB5 RID: 85429 RVA: 0x005C7232 File Offset: 0x005C5432
	public override bool TryRemoveNewFlag()
	{
		if (ModelBase<NewFlagModel>.Instance.HasNewFlag(ELocalStoragePlayerKey.RoleDataItem, this.Id))
		{
			ModelBase<NewFlagModel>.Instance.RemoveNewFlag(ELocalStoragePlayerKey.RoleDataItem, this.Id);
			return true;
		}
		return false;
	}

	// Token: 0x0400A079 RID: 41081
	protected int CreateTime;
}
