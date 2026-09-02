using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Battle;
using UnrealEngine;

// Token: 0x02003120 RID: 12576
[NullableContext(1)]
[Nullable(0)]
public class CharacterSkillCdComponent : BaseSkillCdComponent
{
	// Token: 0x0601A07A RID: 106618 RVA: 0x0079FB04 File Offset: 0x0079DD04
	protected override bool OnInit()
	{
		base.OnInit();
		this.SkillComp = base.Entity.CheckGetComponent<BaseSkillComponent>();
		this.AttrComp = base.Entity.CheckGetComponent<BaseAttributeComponent>();
		this.CurWorldSkillCdData = ModelBase<SkillCdModel>.Instance.GetCurWorldSkillCdData();
		this.GroupSkillCdInfoMap = new Dictionary<long, GroupSkillCdInfo>();
		this.SkillInfoMap = new Dictionary<long, SSkillInfo>();
		this.MultiSkillData = this.CurWorldSkillCdData.InitMultiSkill(base.Entity.Id);
		this.MultiSkillData.Init(base.Entity.Id, 0);
		return true;
	}

	// Token: 0x0601A07B RID: 106619 RVA: 0x0079FB94 File Offset: 0x0079DD94
	protected override bool OnStart()
	{
		if (this.SkillComp != null)
		{
			foreach (int skillId in this.SkillComp.GetAllSkillId(EFightDataTableSourceType.All))
			{
				SSkillInfo skillInfo = this.SkillComp.GetSkillInfo(skillId);
				if (skillInfo != null)
				{
					this.InitSkillCdBySkillInfo(skillId, skillInfo);
				}
			}
		}
		this.InitSkillCdTags();
		if (GlobalData.IsPlayInEditor)
		{
			foreach (GroupSkillCdInfo groupSkillCdInfo in this.GroupSkillCdInfoMap.Values)
			{
				groupSkillCdInfo.CheckConfigValid();
			}
		}
		Singleton<EventSystem>.Instance.AddWithTarget<double>(base.Entity, EEventName.OnChangeRoleCoolDownChanged, new Action<double>(this.GoDown));
		return true;
	}

	// Token: 0x0601A07C RID: 106620 RVA: 0x0079FC7C File Offset: 0x0079DE7C
	protected override bool OnEnd()
	{
		base.OnEnd();
		foreach (GroupSkillCdInfo groupSkillCdInfo in this.GroupSkillCdInfoMap.Values)
		{
			groupSkillCdInfo.ClearCdTags(base.Entity.Id);
		}
		if (this.CurWorldSkillCdData != null)
		{
			this.CurWorldSkillCdData.RemoveEntity(base.Entity);
			this.CurWorldSkillCdData = null;
		}
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.OnChangeRoleCoolDownChanged, new Action<double>(this.GoDown));
		return true;
	}

	// Token: 0x0601A07D RID: 106621 RVA: 0x0079FD28 File Offset: 0x0079DF28
	[NullableContext(2)]
	public MultiSkillInfo GetMultiSkillInfo(int skillId)
	{
		return this.MultiSkillData.GetMultiSkillInfo(skillId);
	}

	// Token: 0x0601A07E RID: 106622 RVA: 0x0079FD38 File Offset: 0x0079DF38
	public long GetNextMultiSkillId(int skillId)
	{
		if (GlobalData.IsPlayInEditor)
		{
			foreach (KeyValuePair<long, SSkillInfo> keyValuePair in this.SkillInfoMap)
			{
				if (keyValuePair.Key == (long)skillId)
				{
					if (!this.IsMultiSkill(keyValuePair.Value))
					{
						Log instance = Singleton<Log>.Instance;
						ELogModule module = ELogModule.Battle;
						ELogAuthor author = ELogAuthor.CFT;
						string message = "获取多段技能下一段技能Id时，传入的技能Id不是多段技能";
						ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("skillId", skillId);
						instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
						break;
					}
					break;
				}
			}
		}
		return this.MultiSkillData.GetNextMultiSkillId(skillId);
	}

	// Token: 0x0601A07F RID: 106623 RVA: 0x0079FDE0 File Offset: 0x0079DFE0
	public bool IsMultiSkill(SSkillInfo skillInfo)
	{
		return this.MultiSkillData.IsMultiSkill(skillInfo);
	}

	// Token: 0x0601A080 RID: 106624 RVA: 0x0079FDEE File Offset: 0x0079DFEE
	public bool CanStartMultiSkill(Skill skill)
	{
		SkillCdModel instance = ModelBase<SkillCdModel>.Instance;
		return (instance != null && instance.SkillDebugMode) || this.MultiSkillData.CanStartMultiSkill(skill);
	}

	// Token: 0x0601A081 RID: 106625 RVA: 0x0079FE11 File Offset: 0x0079E011
	public bool StartMultiSkill(Skill skill, bool bCheck = true)
	{
		return ModelBase<SkillCdModel>.Instance.SkillDebugMode || this.MultiSkillData.StartMultiSkill(skill, bCheck);
	}

	// Token: 0x0601A082 RID: 106626 RVA: 0x0079FE2E File Offset: 0x0079E02E
	public void ResetMultiSkills(int skillId)
	{
		this.MultiSkillData.ResetMultiSkills(skillId, false);
	}

	// Token: 0x0601A083 RID: 106627 RVA: 0x0079FE3D File Offset: 0x0079E03D
	private void GoDown(double coolDownTime)
	{
		this.MultiSkillData.ResetOnChangeRole();
	}

	// Token: 0x0601A084 RID: 106628 RVA: 0x0079FE4C File Offset: 0x0079E04C
	[return: Nullable(2)]
	public unsafe GroupSkillCdInfo InitSkillCdBySkillInfo(int skillId, SSkillInfo skillInfo)
	{
		GroupSkillCdInfo groupSkillCdInfo;
		if (this.GroupSkillCdInfoMap.TryGetValue((long)skillId, out groupSkillCdInfo))
		{
			return groupSkillCdInfo;
		}
		try
		{
			SSkillCooldownInfo cooldownConfig = skillInfo.CooldownConfig;
			if (cooldownConfig.SectionCount - cooldownConfig.SectionRemaining > 1)
			{
				return null;
			}
			groupSkillCdInfo = this.CurWorldSkillCdData.InitSkillCd(base.Entity, skillId, skillInfo);
			this.GroupSkillCdInfoMap[(long)skillId] = groupSkillCdInfo;
			this.SkillInfoMap[(long)skillId] = skillInfo;
			return groupSkillCdInfo;
		}
		catch (Exception ex)
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Skill;
			Entity entity = base.Entity;
			string message = "初始化技能CD异常";
			Exception e = ex;
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("skillId", skillId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("skillId", (skillInfo != null) ? new FName?(skillInfo.SkillName) : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("error", ex.Message);
			instance.ErrorWithStack(flag, entity, message, e, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		}
		return null;
	}

	// Token: 0x0601A085 RID: 106629 RVA: 0x0079FF74 File Offset: 0x0079E174
	private void InitSkillCdTags()
	{
		EntityHandle handleByEntity = ModelBase<CharacterModel>.Instance.GetHandleByEntity(base.Entity);
		foreach (GroupSkillCdInfo groupSkillCdInfo in this.GroupSkillCdInfoMap.Values)
		{
			groupSkillCdInfo.InitCdTags(handleByEntity);
		}
	}

	// Token: 0x0601A086 RID: 106630 RVA: 0x0079FFDC File Offset: 0x0079E1DC
	public GroupSkillCdInfo GetGroupSkillCdInfo(int skillId)
	{
		return this.GroupSkillCdInfoMap.GetValueOrDefault((long)skillId);
	}

	// Token: 0x0601A087 RID: 106631 RVA: 0x0079FFEC File Offset: 0x0079E1EC
	public bool IsSkillInCd(int skillId, bool checkCount = true)
	{
		GroupSkillCdInfo groupSkillCdInfo;
		if (!this.GroupSkillCdInfoMap.TryGetValue((long)skillId, out groupSkillCdInfo))
		{
			return false;
		}
		if (checkCount)
		{
			return !groupSkillCdInfo.HasRemainingCount();
		}
		return groupSkillCdInfo.IsInCd();
	}

	// Token: 0x0601A088 RID: 106632 RVA: 0x007A0020 File Offset: 0x0079E220
	public bool ModifyCdInfo(int skillId, float skillCd)
	{
		if (this.GroupSkillCdInfoMap == null)
		{
			Singleton<Log>.Instance.Warn(ELogModule.Battle, ELogAuthor.CFT, "角色技能组件还没有初始化，不允许修改技能CD", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		GroupSkillCdInfo groupSkillCdInfo;
		if (!this.GroupSkillCdInfoMap.TryGetValue((long)skillId, out groupSkillCdInfo))
		{
			return false;
		}
		groupSkillCdInfo.SkillCdInfoMap[skillId].SkillCd = skillCd;
		return true;
	}

	// Token: 0x0601A089 RID: 106633 RVA: 0x007A007C File Offset: 0x0079E27C
	[NullableContext(2)]
	public void ModifyCdTime(long[] skillIds, float modifyTime, float changeTimePercentage)
	{
		if (skillIds == null || skillIds.Length == 0)
		{
			return;
		}
		if (skillIds.Length == 1)
		{
			GroupSkillCdInfo groupSkillCdInfo;
			if (this.GroupSkillCdInfoMap.TryGetValue(skillIds[0], out groupSkillCdInfo))
			{
				groupSkillCdInfo.ModifyRemainingCd(modifyTime, changeTimePercentage);
			}
			return;
		}
		HashSet<GroupSkillCdInfo> hashSet = new HashSet<GroupSkillCdInfo>();
		foreach (long key in skillIds)
		{
			GroupSkillCdInfo item;
			if (this.GroupSkillCdInfoMap.TryGetValue(key, out item))
			{
				hashSet.Add(item);
			}
		}
		foreach (GroupSkillCdInfo groupSkillCdInfo2 in hashSet)
		{
			groupSkillCdInfo2.ModifyRemainingCd(modifyTime, changeTimePercentage);
		}
	}

	// Token: 0x0601A08A RID: 106634 RVA: 0x007A0128 File Offset: 0x0079E328
	public void ModifyCdTimeBySkillGenres(int[] skillGenres, float modifyTime, float changeTimePercentage)
	{
		List<int> list = new List<int>();
		foreach (int item in skillGenres)
		{
			list.Add(item);
		}
		HashSet<GroupSkillCdInfo> hashSet = new HashSet<GroupSkillCdInfo>();
		foreach (KeyValuePair<long, SSkillInfo> keyValuePair in this.SkillInfoMap)
		{
			GroupSkillCdInfo item2;
			if (list.Contains((int)keyValuePair.Value.SkillGenre) && this.GroupSkillCdInfoMap.TryGetValue(keyValuePair.Key, out item2))
			{
				hashSet.Add(item2);
			}
		}
		foreach (GroupSkillCdInfo groupSkillCdInfo in hashSet)
		{
			groupSkillCdInfo.ModifyRemainingCd(modifyTime, changeTimePercentage);
		}
	}

	// Token: 0x0601A08B RID: 106635 RVA: 0x007A0214 File Offset: 0x0079E414
	public bool StartCd(int skillId, int skillGenre)
	{
		GroupSkillCdInfo groupSkillCdInfo;
		if (!this.GroupSkillCdInfoMap.TryGetValue((long)skillId, out groupSkillCdInfo))
		{
			return false;
		}
		BaseAttributeComponent attrComp = this.AttrComp;
		float cdProportion = ((attrComp != null) ? attrComp.GetCurrentValue(EAttributeType.CdReduse) : 10000f) / 10000f;
		groupSkillCdInfo.StartCd(skillId, cdProportion, ModelBase<CharacterModel>.Instance.GetHandleByEntity(base.Entity), this, skillGenre);
		return true;
	}

	// Token: 0x0601A08C RID: 106636 RVA: 0x007A0270 File Offset: 0x0079E470
	public float CalcExtraEffectCd(float skillCd, int skillId, int skillGenre)
	{
		float num = 0f;
		float num2 = 1f;
		if (this.HasModifyCdEffect)
		{
			foreach (ModifyCd modifyCd in this.BuffComp.BuffEffectManager.FilterById<ModifyCd>(EExtraEffectId.ModifyCd, null))
			{
				if (this.IsBuffEffectSkillCd(modifyCd, skillId, skillGenre))
				{
					if (modifyCd.ModifyType == EModifyCdType.Add || modifyCd.ModifyType == EModifyCdType.AddPerTenThousand)
					{
						num += modifyCd.ModifyValue;
					}
					else if (modifyCd.ModifyType == EModifyCdType.Multiply)
					{
						num2 *= modifyCd.ModifyValue;
					}
				}
			}
		}
		WorldEntity playerEntity = ControllerBase<FormationDataController>.Instance.GetPlayerEntity(ModelBase<CreatureModel>.Instance.GetPlayerId());
		BaseSkillCdComponent baseSkillCdComponent = (playerEntity != null) ? playerEntity.GetComponent<BaseSkillCdComponent>() : null;
		if (baseSkillCdComponent != null && baseSkillCdComponent.HasModifyCdEffect)
		{
			BaseBuffComponent baseBuffComponent = (playerEntity != null) ? playerEntity.GetComponent<BaseBuffComponent>() : null;
			if (baseBuffComponent != null)
			{
				foreach (ModifyCd modifyCd2 in baseBuffComponent.BuffEffectManager.FilterById<ModifyCd>(EExtraEffectId.ModifyCd, null))
				{
					if (this.IsBuffEffectSkillCd(modifyCd2, skillId, skillGenre))
					{
						if (modifyCd2.ModifyType == EModifyCdType.Add || modifyCd2.ModifyType == EModifyCdType.AddPerTenThousand)
						{
							num += modifyCd2.ModifyValue;
						}
						else if (modifyCd2.ModifyType == EModifyCdType.Multiply)
						{
							num2 *= modifyCd2.ModifyValue;
						}
					}
				}
			}
		}
		return (skillCd + num) * num2;
	}

	// Token: 0x0601A08D RID: 106637 RVA: 0x007A03E0 File Offset: 0x0079E5E0
	private bool IsBuffEffectSkillCd(ModifyCd effect, int skillId, int skillGenre)
	{
		if (effect.SkillType == 0)
		{
			return effect.SkillIdOrGenres.Contains((long)skillId);
		}
		return effect.SkillType == 1 && effect.SkillIdOrGenres.Contains((long)skillGenre);
	}

	// Token: 0x0601A08E RID: 106638 RVA: 0x007A0410 File Offset: 0x0079E610
	public unsafe bool SetLimitCount(int skillId, int? limitCount = null)
	{
		Dictionary<long, GroupSkillCdInfo> groupSkillCdInfoMap = this.GroupSkillCdInfoMap;
		GroupSkillCdInfo groupSkillCdInfo = (groupSkillCdInfoMap != null) ? groupSkillCdInfoMap.GetValueOrDefault((long)skillId) : null;
		if (groupSkillCdInfo == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Battle;
			ELogAuthor author = ELogAuthor.CFT;
			string message = "SetLimitCount 不存在该技能:";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", base.Entity.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("limitCount", limitCount);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("skillID", skillId);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return false;
		}
		groupSkillCdInfo.SetLimitCount(limitCount);
		return true;
	}

	// Token: 0x0601A08F RID: 106639 RVA: 0x007A04C8 File Offset: 0x0079E6C8
	public unsafe bool AddLimitCount(int skillId, int limitCount)
	{
		Dictionary<long, GroupSkillCdInfo> groupSkillCdInfoMap = this.GroupSkillCdInfoMap;
		GroupSkillCdInfo groupSkillCdInfo = (groupSkillCdInfoMap != null) ? groupSkillCdInfoMap.GetValueOrDefault((long)skillId) : null;
		if (groupSkillCdInfo == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Battle;
			ELogAuthor author = ELogAuthor.CFT;
			string message = "AddLimitCount 不存在该技能:";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", base.Entity.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("limitCount", limitCount);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("skillID", skillId);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return false;
		}
		groupSkillCdInfo.AddLimitCount(limitCount);
		return true;
	}

	// Token: 0x0601A090 RID: 106640 RVA: 0x007A0580 File Offset: 0x0079E780
	public bool ResetCdDelayTime(int skillId)
	{
		GroupSkillCdInfo groupSkillCdInfo;
		if (!this.GroupSkillCdInfoMap.TryGetValue((long)skillId, out groupSkillCdInfo))
		{
			return false;
		}
		if (groupSkillCdInfo.ResetDelayCd())
		{
			InterruptSkillInDelayPush message = new InterruptSkillInDelayPush
			{
				SkillId = (long)skillId
			};
			Singleton<CombatNet>.Instance.Send(EPushMessageId.InterruptSkillInDelayPush, base.Entity, message, null, null, null);
			MultiSkillData multiSkillData = this.MultiSkillData;
			if (multiSkillData != null)
			{
				multiSkillData.ResetMultiSkills(skillId, true);
			}
		}
		return true;
	}

	// Token: 0x0601A091 RID: 106641 RVA: 0x007A05FC File Offset: 0x0079E7FC
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		CharacterSkillCdComponent characterSkillCdComponent = (CharacterSkillCdComponent)componentTemplate;
		if (base.CanResetComponentProperty("SkillComp"))
		{
			if (characterSkillCdComponent.SkillComp == null)
			{
				this.SkillComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseSkillComponent>(this.SkillComp), "SkillComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("AttrComp"))
		{
			if (characterSkillCdComponent.AttrComp == null)
			{
				this.AttrComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseAttributeComponent>(this.AttrComp), "AttrComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("CurWorldSkillCdData"))
		{
			if (characterSkillCdComponent.CurWorldSkillCdData == null)
			{
				this.CurWorldSkillCdData = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<WorldSkillCdData>(this.CurWorldSkillCdData), "CurWorldSkillCdData"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("GroupSkillCdInfoMap"))
		{
			if (characterSkillCdComponent.GroupSkillCdInfoMap == null)
			{
				this.GroupSkillCdInfoMap = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<long, GroupSkillCdInfo>>(this.GroupSkillCdInfoMap), "GroupSkillCdInfoMap"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("SkillInfoMap"))
		{
			if (characterSkillCdComponent.SkillInfoMap == null)
			{
				this.SkillInfoMap = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<long, SSkillInfo>>(this.SkillInfoMap), "SkillInfoMap"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("MultiSkillData"))
		{
			if (characterSkillCdComponent.MultiSkillData == null)
			{
				this.MultiSkillData = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<MultiSkillData>(this.MultiSkillData), "MultiSkillData"))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0400D0C9 RID: 53449
	private const int DEFAULT_PROPORTTION_VALUE = 10000;

	// Token: 0x0400D0CA RID: 53450
	[Nullable(2)]
	private BaseSkillComponent SkillComp;

	// Token: 0x0400D0CB RID: 53451
	[Nullable(2)]
	private BaseAttributeComponent AttrComp;

	// Token: 0x0400D0CC RID: 53452
	[Nullable(2)]
	private WorldSkillCdData CurWorldSkillCdData;

	// Token: 0x0400D0CD RID: 53453
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<long, GroupSkillCdInfo> GroupSkillCdInfoMap;

	// Token: 0x0400D0CE RID: 53454
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<long, SSkillInfo> SkillInfoMap;

	// Token: 0x0400D0CF RID: 53455
	[Nullable(2)]
	private MultiSkillData MultiSkillData;
}
