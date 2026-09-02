using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Character.Input.Enum;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Battle;
using UnrealEngine;

// Token: 0x02003156 RID: 12630
[NullableContext(2)]
[Nullable(0)]
public class VisionSkillComponent : CharacterSkillComponent
{
	// Token: 0x0601A2A5 RID: 107173 RVA: 0x007AF264 File Offset: 0x007AD464
	protected override bool OnStart()
	{
		CreatureDataComponent component = base.Entity.GetComponent<CreatureDataComponent>();
		this.CreatureDataId = component.GetCreatureDataId();
		return base.OnStart();
	}

	// Token: 0x0601A2A6 RID: 107174 RVA: 0x007AF290 File Offset: 0x007AD490
	[NullableContext(1)]
	public void InitVisionSkill(EntityHandle summonerEntity, bool isMorphVision = false)
	{
		if (this.SummonerEntity != summonerEntity)
		{
			this.TryRemoveEvents(true, true);
			this.SummonerEntity = summonerEntity;
			this.CurWorldSkillCdData = ModelBase<SkillCdModel>.Instance.GetCurWorldSkillCdData();
			int id = base.Entity.Id;
			if (this.MultiSkillData == null)
			{
				this.MultiSkillData = this.CurWorldSkillCdData.InitMultiSkill(id);
				this.MultiSkillData.Init(this.SummonerEntity.Id, id);
				this.MultiSkillData.InitMultiSkillInfo(this.LoadedSkills);
			}
		}
		this.IsMorphVision = isMorphVision;
		this.KeepMultiSkillOnMorphEnd = false;
		this.KeepMultiSkillOnGoDown = false;
		this.EnableAttackInputAction = true;
	}

	// Token: 0x0601A2A7 RID: 107175 RVA: 0x007AF330 File Offset: 0x007AD530
	public unsafe override bool BeginSkill(int skillId, ISkillParam skillParam = null)
	{
		if (skillParam == null)
		{
			skillParam = new SkillParam();
		}
		if (!this.IsMorphVision)
		{
			return base.BeginSkill(skillId, skillParam);
		}
		int num = skillId;
		if (skillParam.CheckMultiSkill.GetValueOrDefault() && this.CurMultiSkillId != 0)
		{
			MultiSkillInfo multiSkillInfo = this.MultiSkillData.GetMultiSkillInfo(this.CurMultiSkillId);
			if (multiSkillInfo != null && multiSkillInfo.NextSkillId.GetValueOrDefault() != 0)
			{
				int? nextSkillId = multiSkillInfo.NextSkillId;
				int firstSkillId = multiSkillInfo.FirstSkillId;
				if (!(nextSkillId.GetValueOrDefault() == firstSkillId & nextSkillId != null))
				{
					num = multiSkillInfo.NextSkillId.Value;
				}
			}
		}
		SSkillInfo skillInfo = base.GetSkillInfo(num);
		if (skillInfo == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Battle;
			ELogAuthor author = ELogAuthor.CFT;
			string message = "幻象缺少技能";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("skillId", num);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		bool flag = this.MultiSkillData.IsMultiSkill(skillInfo);
		if (flag)
		{
			this.TargetMultiSkillId = num;
		}
		if (!base.BeginSkill(num, skillParam))
		{
			CombatLog instance2 = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag2 = CombatLog.EDebugModule.Skill;
			EntityHandle summonerEntity = this.SummonerEntity;
			Entity entity = (summonerEntity != null) ? summonerEntity.Entity : null;
			string message2 = "角色开始幻象变身技能失败";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("技能Id", num);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("技能名", (skillInfo != null) ? new FName?(skillInfo.SkillName) : null);
			instance2.Warn(flag2, entity, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return false;
		}
		Skill skill = base.GetSkill(num);
		if (flag && this.TargetMultiSkillId == num)
		{
			this.TryAddEvents(true, true);
			if (this.MultiSkillData.StartMultiSkill(skill, false))
			{
				this.CurMultiSkillId = num;
			}
		}
		this.IsMorph = true;
		return true;
	}

	// Token: 0x0601A2A8 RID: 107176 RVA: 0x007AF4F0 File Offset: 0x007AD6F0
	public void OnMorphEnd()
	{
		if (!this.KeepMultiSkillOnMorphEnd)
		{
			this.ClearMultiSkillState();
		}
		this.IsMorph = false;
	}

	// Token: 0x0601A2A9 RID: 107177 RVA: 0x007AF507 File Offset: 0x007AD707
	public void ExitMultiSkillState()
	{
		this.ClearMultiSkillState();
	}

	// Token: 0x0601A2AA RID: 107178 RVA: 0x007AF50F File Offset: 0x007AD70F
	public void SetKeepMultiSkillState(bool keepOnMorphEnd, bool keepOnGoDown)
	{
		this.KeepMultiSkillOnMorphEnd = keepOnMorphEnd;
		this.KeepMultiSkillOnGoDown = keepOnGoDown;
	}

	// Token: 0x0601A2AB RID: 107179 RVA: 0x007AF51F File Offset: 0x007AD71F
	public void SetEnableAttackInputAction(bool bEnable)
	{
		this.EnableAttackInputAction = bEnable;
	}

	// Token: 0x0601A2AC RID: 107180 RVA: 0x007AF528 File Offset: 0x007AD728
	public bool CanSummonerStartNextMultiSkill()
	{
		if (this.CurMultiSkillId <= 0)
		{
			return false;
		}
		if (this.IsMorph)
		{
			return false;
		}
		MultiSkillInfo multiSkillInfo = this.MultiSkillData.GetMultiSkillInfo(this.CurMultiSkillId);
		if (((multiSkillInfo != null) ? multiSkillInfo.NextSkillId : null).GetValueOrDefault() == 0)
		{
			return false;
		}
		int value = multiSkillInfo.NextSkillId.Value;
		Skill skill = base.GetSkill(value);
		if (skill == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Battle;
			ELogAuthor author = ELogAuthor.CFT;
			string message = "幻象缺少技能";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("skillId", value);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		return this.MultiSkillData.CanStartMultiSkill(skill);
	}

	// Token: 0x0601A2AD RID: 107181 RVA: 0x007AF5D4 File Offset: 0x007AD7D4
	public bool IsInMultiSkill()
	{
		if (this.CurMultiSkillId <= 0)
		{
			return false;
		}
		MultiSkillInfo multiSkillInfo = this.MultiSkillData.GetMultiSkillInfo(this.CurMultiSkillId);
		return ((multiSkillInfo != null) ? multiSkillInfo.NextSkillId : null).GetValueOrDefault() != 0;
	}

	// Token: 0x0601A2AE RID: 107182 RVA: 0x007AF620 File Offset: 0x007AD820
	public void OnVisionAbilityDestroy()
	{
		if (this.CurWorldSkillCdData != null)
		{
			this.CurWorldSkillCdData.RemoveMultiSkill(base.Entity.Id);
			MultiSkillData multiSkillData = this.MultiSkillData;
			if (multiSkillData != null)
			{
				multiSkillData.ClearAllSkill();
			}
		}
		if (this.SummonerEntity != null)
		{
			this.TryRemoveEvents(true, true);
			this.SummonerEntity = null;
		}
		this.CurWorldSkillCdData = null;
		this.MultiSkillData = null;
		this.CurMultiSkillId = 0;
	}

	// Token: 0x0601A2AF RID: 107183 RVA: 0x007AF688 File Offset: 0x007AD888
	protected override bool OnEnd()
	{
		this.OnVisionAbilityDestroy();
		return base.OnEnd();
	}

	// Token: 0x0601A2B0 RID: 107184 RVA: 0x007AF696 File Offset: 0x007AD896
	private void ClearMultiSkillState()
	{
		if (this.CurMultiSkillId != 0)
		{
			this.MultiSkillData.ResetMultiSkills(this.CurMultiSkillId, true);
			this.CurMultiSkillId = 0;
		}
		this.TargetMultiSkillId = 0;
		this.TryRemoveEvents(true, false);
	}

	// Token: 0x0601A2B1 RID: 107185 RVA: 0x007AF6C8 File Offset: 0x007AD8C8
	private void TryAddEvents(bool bCharInputPress, bool bChangeRole)
	{
		EntityHandle summonerEntity = this.SummonerEntity;
		if (summonerEntity == null || !summonerEntity.Valid)
		{
			return;
		}
		this.EnableInput = true;
		WorldEntity entity = this.SummonerEntity.Entity;
		if (bChangeRole && !Singleton<EventSystem>.Instance.HasWithTarget<double>(entity, EEventName.OnChangeRoleCoolDownChanged, new Action<double>(this.OnSummonerDown)))
		{
			Singleton<EventSystem>.Instance.AddWithTarget<double>(entity, EEventName.OnChangeRoleCoolDownChanged, new Action<double>(this.OnSummonerDown));
		}
	}

	// Token: 0x0601A2B2 RID: 107186 RVA: 0x007AF740 File Offset: 0x007AD940
	private void TryRemoveEvents(bool bCharInputPress, bool bChangeRole)
	{
		EntityHandle summonerEntity = this.SummonerEntity;
		if (summonerEntity == null || !summonerEntity.Valid)
		{
			return;
		}
		this.EnableInput = false;
		WorldEntity entity = this.SummonerEntity.Entity;
		if (bChangeRole && Singleton<EventSystem>.Instance.HasWithTarget<double>(entity, EEventName.OnChangeRoleCoolDownChanged, new Action<double>(this.OnSummonerDown)))
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget<double>(entity, EEventName.OnChangeRoleCoolDownChanged, new Action<double>(this.OnSummonerDown));
		}
	}

	// Token: 0x0601A2B3 RID: 107187 RVA: 0x007AF7B8 File Offset: 0x007AD9B8
	private unsafe bool OnCharInputPress(EInputAction action)
	{
		if (action != EInputAction.幻象2 && (action != EInputAction.攻击 || !this.EnableAttackInputAction))
		{
			return false;
		}
		CharacterVisionComponent component = this.SummonerEntity.Entity.GetComponent<CharacterVisionComponent>();
		long creatureDataId = this.CreatureDataId;
		long? num = (component != null) ? new long?(component.GetVisionCreatureDataId()) : null;
		if (!(creatureDataId == num.GetValueOrDefault() & num != null))
		{
			return false;
		}
		if (this.CurMultiSkillId <= 0)
		{
			return false;
		}
		MultiSkillInfo multiSkillInfo = this.MultiSkillData.GetMultiSkillInfo(this.CurMultiSkillId);
		if (multiSkillInfo == null || multiSkillInfo.NextSkillId.GetValueOrDefault() == 0)
		{
			return false;
		}
		int value = multiSkillInfo.NextSkillId.Value;
		Skill skill = base.GetSkill(value);
		if (skill == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Battle;
			ELogAuthor author = ELogAuthor.CFT;
			string message = "幻象缺少技能";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("skillId", value);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		if (!this.MultiSkillData.CanStartMultiSkill(skill))
		{
			return false;
		}
		EntityHandle summonerEntity = this.SummonerEntity;
		if (summonerEntity == null || !summonerEntity.Valid)
		{
			return false;
		}
		if (this.IsMorph)
		{
			CombatLog instance2 = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Skill;
			Entity entity = base.Entity;
			string message2 = "使用幻象技能（输入触发下一段）";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("skillId", multiSkillInfo.NextSkillId);
			instance2.Info(flag, entity, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			this.AbilityComp.SendGameplayEventToActor(GameplayTagUtils.GetGameplayTagById(VisionSkillComponent._useNextSkillTagId).Value, null);
			CharacterSkillComponent characterSkillComponent = summonerEntity.Entity.CheckGetComponent<CharacterSkillComponent>();
			int skillId = value;
			SkillParam skillParam = new SkillParam();
			EntityHandle skillTarget = characterSkillComponent.SkillTarget;
			skillParam.Target = ((skillTarget != null) ? skillTarget.Entity : null);
			skillParam.SocketName = characterSkillComponent.SkillTargetSocket;
			skillParam.Reason = "VisionSkill.OnCharInputPress";
			if (!base.BeginSkill(skillId, skillParam))
			{
				CombatLog instance3 = Singleton<CombatLog>.Instance;
				CombatLog.EDebugModule flag2 = CombatLog.EDebugModule.Skill;
				Entity entity2 = base.Entity;
				string message3 = "角色幻象变身中使用下一段技能失败";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("技能Id", (skill != null) ? new int?(skill.SkillId) : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("技能名", (skill != null) ? skill.SkillName : null);
				instance3.Warn(flag2, entity2, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return false;
			}
			CombatLog instance4 = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag3 = CombatLog.EDebugModule.Skill;
			Entity entity3 = base.Entity;
			string message4 = "角色幻象变身中使用下一段技能成功";
			ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("skillId", multiSkillInfo.NextSkillId);
			instance4.Info(flag3, entity3, message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
			if (this.MultiSkillData.StartMultiSkill(skill, true))
			{
				this.CurMultiSkillId = value;
				return true;
			}
		}
		return false;
	}

	// Token: 0x0601A2B4 RID: 107188 RVA: 0x007AFA3C File Offset: 0x007ADC3C
	private void OnSummonerDown(double _)
	{
		if (!this.KeepMultiSkillOnGoDown)
		{
			this.ClearMultiSkillState();
		}
	}

	// Token: 0x0601A2B5 RID: 107189 RVA: 0x007AFA4C File Offset: 0x007ADC4C
	public bool HandlePress(EInputAction action, float time)
	{
		return this.EnableInput && this.OnCharInputPress(action);
	}

	// Token: 0x0601A2B6 RID: 107190 RVA: 0x007AFA60 File Offset: 0x007ADC60
	[NullableContext(1)]
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		VisionSkillComponent visionSkillComponent = (VisionSkillComponent)componentTemplate;
		if (base.CanResetComponentProperty("CreatureDataId"))
		{
			this.CreatureDataId = visionSkillComponent.CreatureDataId;
		}
		if (base.CanResetComponentProperty("CurWorldSkillCdData"))
		{
			if (visionSkillComponent.CurWorldSkillCdData == null)
			{
				this.CurWorldSkillCdData = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<WorldSkillCdData>(this.CurWorldSkillCdData), "CurWorldSkillCdData"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("SummonerEntity"))
		{
			if (visionSkillComponent.SummonerEntity == null)
			{
				this.SummonerEntity = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<EntityHandle>(this.SummonerEntity), "SummonerEntity"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("MultiSkillData"))
		{
			if (visionSkillComponent.MultiSkillData == null)
			{
				this.MultiSkillData = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<MultiSkillData>(this.MultiSkillData), "MultiSkillData"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("CurMultiSkillId"))
		{
			this.CurMultiSkillId = visionSkillComponent.CurMultiSkillId;
		}
		if (base.CanResetComponentProperty("TargetMultiSkillId"))
		{
			this.TargetMultiSkillId = visionSkillComponent.TargetMultiSkillId;
		}
		if (base.CanResetComponentProperty("IsMorphVision"))
		{
			this.IsMorphVision = visionSkillComponent.IsMorphVision;
		}
		if (base.CanResetComponentProperty("IsMorph"))
		{
			this.IsMorph = visionSkillComponent.IsMorph;
		}
		if (base.CanResetComponentProperty("KeepMultiSkillOnMorphEnd"))
		{
			this.KeepMultiSkillOnMorphEnd = visionSkillComponent.KeepMultiSkillOnMorphEnd;
		}
		if (base.CanResetComponentProperty("KeepMultiSkillOnGoDown"))
		{
			this.KeepMultiSkillOnGoDown = visionSkillComponent.KeepMultiSkillOnGoDown;
		}
		if (base.CanResetComponentProperty("EnableAttackInputAction"))
		{
			this.EnableAttackInputAction = visionSkillComponent.EnableAttackInputAction;
		}
		if (base.CanResetComponentProperty("EnableInput"))
		{
			this.EnableInput = visionSkillComponent.EnableInput;
		}
		return true;
	}

	// Token: 0x0400D267 RID: 53863
	[StaticVariableRuleIgnore]
	private static int _useNextSkillTagId = GameplayTagDefine.EGameplayTagId["幻象.技能.使用下一段技能"];

	// Token: 0x0400D268 RID: 53864
	private long CreatureDataId;

	// Token: 0x0400D269 RID: 53865
	private WorldSkillCdData CurWorldSkillCdData;

	// Token: 0x0400D26A RID: 53866
	private EntityHandle SummonerEntity;

	// Token: 0x0400D26B RID: 53867
	private MultiSkillData MultiSkillData;

	// Token: 0x0400D26C RID: 53868
	private int CurMultiSkillId;

	// Token: 0x0400D26D RID: 53869
	private int TargetMultiSkillId;

	// Token: 0x0400D26E RID: 53870
	private bool IsMorphVision;

	// Token: 0x0400D26F RID: 53871
	private bool IsMorph;

	// Token: 0x0400D270 RID: 53872
	private bool KeepMultiSkillOnMorphEnd;

	// Token: 0x0400D271 RID: 53873
	private bool KeepMultiSkillOnGoDown;

	// Token: 0x0400D272 RID: 53874
	private bool EnableAttackInputAction = true;

	// Token: 0x0400D273 RID: 53875
	private bool EnableInput;
}
