using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Plot;
using UnrealEngine;

// Token: 0x0200314E RID: 12622
[NullableContext(1)]
[Nullable(0)]
public abstract class SpecialSkillMorphBase : SpecialSkillBase, IStaticVariableResetter
{
	// Token: 0x0601A223 RID: 107043 RVA: 0x007AB4FD File Offset: 0x007A96FD
	static SpecialSkillMorphBase()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(SpecialSkillMorphBase.CreateStaticDefaultValue), new Action(SpecialSkillMorphBase.ResetStaticDefaultValue));
	}

	// Token: 0x0601A224 RID: 107044 RVA: 0x007AB51C File Offset: 0x007A971C
	public static void CreateStaticDefaultValue()
	{
		SpecialSkillMorphBase._morphResetConfigCache = null;
		SpecialSkillMorphBase._morphKeepConfigCache = null;
		SpecialSkillMorphBase._changeRoleResetMorphTagsCache = null;
		SpecialSkillMorphBase._morphSubMeshCache = null;
		SpecialSkillMorphBase._morphBuffsCache = null;
		SpecialSkillMorphBase._morphCueIdsCache = null;
		SpecialSkillMorphBase._tempMeshes = null;
	}

	// Token: 0x0601A225 RID: 107045 RVA: 0x007AB548 File Offset: 0x007A9748
	public static void ResetStaticDefaultValue()
	{
		SpecialSkillMorphBase._morphResetConfigCache = null;
		SpecialSkillMorphBase._morphKeepConfigCache = null;
		SpecialSkillMorphBase._changeRoleResetMorphTagsCache = null;
		SpecialSkillMorphBase._morphSubMeshCache = null;
		SpecialSkillMorphBase._morphBuffsCache = null;
		SpecialSkillMorphBase._morphCueIdsCache = null;
		SpecialSkillMorphBase._tempMeshes = null;
	}

	// Token: 0x17002382 RID: 9090
	// (get) Token: 0x0601A226 RID: 107046
	protected abstract string MorphBuffsConfigKey { get; }

	// Token: 0x17002383 RID: 9091
	// (get) Token: 0x0601A227 RID: 107047
	protected abstract string MorphCueIdConfigKey { get; }

	// Token: 0x17002384 RID: 9092
	// (get) Token: 0x0601A228 RID: 107048
	protected abstract string ResetMorphSkillsConfigKey { get; }

	// Token: 0x17002385 RID: 9093
	// (get) Token: 0x0601A229 RID: 107049
	protected abstract string NotResetMorphSkillsConfigKey { get; }

	// Token: 0x17002386 RID: 9094
	// (get) Token: 0x0601A22A RID: 107050
	protected abstract string ChangeRoleResetMorphTagsConfigKey { get; }

	// Token: 0x17002387 RID: 9095
	// (get) Token: 0x0601A22B RID: 107051
	protected abstract string Morph0SubMeshConfigKey { get; }

	// Token: 0x17002388 RID: 9096
	// (get) Token: 0x0601A22C RID: 107052
	protected abstract string Morph1SubMeshConfigKey { get; }

	// Token: 0x17002389 RID: 9097
	// (get) Token: 0x0601A22D RID: 107053 RVA: 0x007AB574 File Offset: 0x007A9774
	protected virtual string LogPrefix
	{
		get
		{
			return base.GetType().Name;
		}
	}

	// Token: 0x0601A22E RID: 107054 RVA: 0x007AB581 File Offset: 0x007A9781
	protected SpecialSkillMorphBase(CharacterSpecialSkillComponent specialSkillComponent) : base(specialSkillComponent)
	{
	}

	// Token: 0x0601A22F RID: 107055 RVA: 0x007AB594 File Offset: 0x007A9794
	public override void OnStart()
	{
		Entity entity = this.SpecialSkillComponent.Entity;
		this.ActorComp = entity.GetComponent<CharacterActorComponent>();
		this.AnimComp = entity.GetComponent<BaseAnimationComponent>();
		this.MorphComp = entity.GetComponent<CharacterMorphComponent>();
		this.SkillComp = entity.GetComponent<BaseSkillComponent>();
		this.MontageComp = entity.GetComponent<CharacterMontageComponent>();
		this.BuffComp = entity.GetComponent<BaseBuffComponent>();
		this.CueComp = entity.GetComponent<BaseGameplayCueComponent>();
		this.TagComp = entity.GetComponent<BaseTagComponent>();
		this.RoleQteComp = entity.GetComponent<RoleQteComponent>();
		this.RegisterMorphEvents();
	}

	// Token: 0x0601A230 RID: 107056 RVA: 0x007AB61F File Offset: 0x007A981F
	public override void OnEnd()
	{
		this.UnregisterMorphEvents();
		ITagTask glideStateListener = this.GlideStateListener;
		if (glideStateListener != null)
		{
			glideStateListener.EndTask();
		}
		this.GlideStateListener = null;
	}

	// Token: 0x0601A231 RID: 107057 RVA: 0x007AB640 File Offset: 0x007A9840
	public override void OnActivate()
	{
		CharacterMorphComponent morphComp = this.MorphComp;
		EMorphType? emorphType = (morphComp != null) ? new EMorphType?(morphComp.GetMorphType()) : null;
		if (emorphType != null)
		{
			this.RefreshNoUpdateMeshes(emorphType.Value);
		}
	}

	// Token: 0x0601A232 RID: 107058 RVA: 0x007AB684 File Offset: 0x007A9884
	protected void RegisterMorphEvents()
	{
		Entity entity = this.SpecialSkillComponent.Entity;
		Singleton<EventSystem>.Instance.Add<EntityHandle, EntityHandle>(EEventName.OnBeforeChangeRole, new Action<EntityHandle, EntityHandle>(this.OnBeforeChangeRole));
		Singleton<EventSystem>.Instance.Add(EEventName.OnExecuteAfterSetPlotMode, new Action(this.OnExecuteAfterSetPlotMode));
		Singleton<EventSystem>.Instance.AddWithTarget<int, bool>(entity, EEventName.CharBeforeSkillWithTarget, new Action<int, bool>(this.OnCharBeforeSkill));
		Singleton<EventSystem>.Instance.AddWithTarget<ECharacterActionType>(entity, EEventName.OnBeforeCharActionWithTarget, new Action<ECharacterActionType>(this.OnBeforeCharAction));
		Singleton<EventSystem>.Instance.AddWithTarget<ECharMoveState, ECharMoveState>(entity, EEventName.CharOnUnifiedMoveStateChanged, new Action<ECharMoveState, ECharMoveState>(this.OnCharOnUnifiedMoveStateChanged));
		Singleton<EventSystem>.Instance.AddWithTarget(entity, EEventName.CharOnRoleDeadEnd, new Action(this.OnRoleDeadEnd));
		Singleton<EventSystem>.Instance.AddWithTarget(entity, EEventName.CharOnRevive, new Action(this.OnRoleRevive));
		Singleton<EventSystem>.Instance.AddWithTarget<Entity, EMorphType, EMorphType>(entity, EEventName.OnCharacterMorphTypeChanged, new Action<Entity, EMorphType, EMorphType>(this.OnCharacterMorphTypeChanged));
		Singleton<EventSystem>.Instance.AddWithTarget<int, int, int, float>(entity, EEventName.OnBeforeSkillSimulateMontage, new Action<int, int, int, float>(this.OnBeforeSkillSimulateMontage));
		SpecialSkillMorphBase specialSkillMorphBase = this;
		BaseTagComponent tagComp = this.TagComp;
		specialSkillMorphBase.GlideStateListener = ((tagComp != null) ? tagComp.ListenForTagAddOrRemove(new int?(GameplayTagDefine.EGameplayTagId["行为状态.动作状态.滑翔"]), new BaseTagComponent.TTagSwitchedCallback(this.OnGlideStateChanged), null) : null);
	}

	// Token: 0x0601A233 RID: 107059 RVA: 0x007AB7D4 File Offset: 0x007A99D4
	protected void UnregisterMorphEvents()
	{
		Entity entity = this.SpecialSkillComponent.Entity;
		Singleton<EventSystem>.Instance.Remove<EntityHandle, EntityHandle>(EEventName.OnBeforeChangeRole, new Action<EntityHandle, EntityHandle>(this.OnBeforeChangeRole));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnExecuteAfterSetPlotMode, new Action(this.OnExecuteAfterSetPlotMode));
		Singleton<EventSystem>.Instance.RemoveWithTarget<int, bool>(entity, EEventName.CharBeforeSkillWithTarget, new Action<int, bool>(this.OnCharBeforeSkill));
		Singleton<EventSystem>.Instance.RemoveWithTarget<ECharacterActionType>(entity, EEventName.OnBeforeCharActionWithTarget, new Action<ECharacterActionType>(this.OnBeforeCharAction));
		Singleton<EventSystem>.Instance.RemoveWithTarget<ECharMoveState, ECharMoveState>(entity, EEventName.CharOnUnifiedMoveStateChanged, new Action<ECharMoveState, ECharMoveState>(this.OnCharOnUnifiedMoveStateChanged));
		Singleton<EventSystem>.Instance.RemoveWithTarget(entity, EEventName.CharOnRoleDeadEnd, new Action(this.OnRoleDeadEnd));
		Singleton<EventSystem>.Instance.RemoveWithTarget(entity, EEventName.CharOnRevive, new Action(this.OnRoleRevive));
		Singleton<EventSystem>.Instance.RemoveWithTarget<Entity, EMorphType, EMorphType>(entity, EEventName.OnCharacterMorphTypeChanged, new Action<Entity, EMorphType, EMorphType>(this.OnCharacterMorphTypeChanged));
		Singleton<EventSystem>.Instance.RemoveWithTarget<int, int, int, float>(entity, EEventName.OnBeforeSkillSimulateMontage, new Action<int, int, int, float>(this.OnBeforeSkillSimulateMontage));
	}

	// Token: 0x0601A234 RID: 107060 RVA: 0x007AB8EC File Offset: 0x007A9AEC
	protected void ResetMorph(bool needAddCue = true)
	{
		CharacterMorphComponent morphComp = this.MorphComp;
		if (morphComp == null || !morphComp.IsMorphing())
		{
			return;
		}
		foreach (long buffId in SpecialSkillMorphBase.GetMorphBuffsFromConfig(this.MorphBuffsConfigKey))
		{
			BaseBuffComponent buffComp = this.BuffComp;
			if (buffComp != null && buffComp.HasBuff(buffId, false))
			{
				this.BuffComp.RemoveBuff(buffId, -1, this.LogPrefix + ".ResetMorph", null, null, null);
			}
		}
		if (needAddCue)
		{
			foreach (long num in SpecialSkillMorphBase.GetMorphCueIdsFromConfig(this.MorphCueIdConfigKey))
			{
				if (num > 0L)
				{
					BaseGameplayCueComponent cueComp = this.CueComp;
					if (cueComp != null)
					{
						cueComp.AddCue(num, new GameplayCueParam?(new GameplayCueParam
						{
							Instant = true
						}));
					}
				}
			}
		}
	}

	// Token: 0x0601A235 RID: 107061 RVA: 0x007ABA18 File Offset: 0x007A9C18
	protected void RefreshNoUpdateMeshes(EMorphType morphType)
	{
		if (!this.IsEnableOptimize)
		{
			return;
		}
		CharacterActorComponent actorComp = this.ActorComp;
		TsBaseCharacter tsBaseCharacter = (actorComp != null) ? actorComp.Actor : null;
		if (tsBaseCharacter == null || this.AnimComp == null)
		{
			return;
		}
		if (SpecialSkillMorphBase._tempMeshes == null)
		{
			SpecialSkillMorphBase._tempMeshes = new HashSet<USkeletalMeshComponent>();
		}
		else
		{
			SpecialSkillMorphBase._tempMeshes.Clear();
		}
		List<string> list = (morphType == EMorphType.默认形态) ? SpecialSkillMorphBase.GetSubMeshNamesFromConfig(this.Morph1SubMeshConfigKey) : SpecialSkillMorphBase.GetSubMeshNamesFromConfig(this.Morph0SubMeshConfigKey);
		if (list.Count > 0)
		{
			TArray<UActorComponent> tarray = tsBaseCharacter.K2_GetComponentsByClass(USkeletalMeshComponent.StaticClass());
			for (int i = 0; i < tarray.Num(); i++)
			{
				USkeletalMeshComponent uskeletalMeshComponent = tarray.Get(i) as USkeletalMeshComponent;
				string text = (uskeletalMeshComponent != null) ? uskeletalMeshComponent.GetName() : null;
				if (uskeletalMeshComponent != null && text != null && list.Contains(text))
				{
					SpecialSkillMorphBase._tempMeshes.Add(uskeletalMeshComponent);
				}
			}
		}
		this.AnimComp.SetNoUpdateMeshes(SpecialSkillMorphBase._tempMeshes);
		SpecialSkillMorphBase._tempMeshes.Clear();
	}

	// Token: 0x0601A236 RID: 107062 RVA: 0x007ABB08 File Offset: 0x007A9D08
	protected void LogResetMorph(EResetMorphReason reason, [ParamCollection] [ScopedRef] [Nullable(new byte[]
	{
		0,
		0,
		1,
		2
	})] ReadOnlySpan<ValueTuple<string, object>> extraPairs)
	{
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Reason", reason);
		ReadOnlySpan<ValueTuple<string, object>> readOnlySpan = extraPairs;
		int num = 0;
		ValueTuple<string, object>[] array = new ValueTuple<string, object>[1 + readOnlySpan.Length];
		array[num] = valueTuple;
		num++;
		readOnlySpan.CopyTo(new Span<ValueTuple<string, object>>(array).Slice(num, readOnlySpan.Length));
		num += readOnlySpan.Length;
		ReadOnlySpan<ValueTuple<string, object>> pairs = new ReadOnlySpan<ValueTuple<string, object>>(array);
		Singleton<CombatLog>.Instance.Info(CombatLog.EDebugModule.Skill, this.SpecialSkillComponent.Entity, "还原形态", pairs);
	}

	// Token: 0x0601A237 RID: 107063 RVA: 0x007ABB98 File Offset: 0x007A9D98
	protected void OnBeforeChangeRole(EntityHandle newEntity, [Nullable(2)] EntityHandle oldEntity)
	{
		RoleQteComponent roleQteComp = this.RoleQteComp;
		if (roleQteComp != null && roleQteComp.IsInQte)
		{
			return;
		}
		int? num = this.ShouldResetMorphOnChangeRole(newEntity, oldEntity);
		if (num == null)
		{
			return;
		}
		EResetMorphReason reason = EResetMorphReason.ChangeRole;
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("TagId", num.Value);
		this.LogResetMorph(reason, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		this.ResetMorph(true);
	}

	// Token: 0x0601A238 RID: 107064 RVA: 0x007ABBFC File Offset: 0x007A9DFC
	protected void OnCharBeforeSkill(int skillId, bool isAutonomousProxy)
	{
		if (!this.ShouldResetMorphBeforeSkill(skillId))
		{
			return;
		}
		EResetMorphReason reason = EResetMorphReason.BeforeSkill;
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("SkillId", skillId);
		this.LogResetMorph(reason, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		this.ResetMorph(true);
	}

	// Token: 0x0601A239 RID: 107065 RVA: 0x007ABC3C File Offset: 0x007A9E3C
	protected void OnBeforeCharAction(ECharacterActionType actionType)
	{
		CharacterMorphComponent morphComp = this.MorphComp;
		if (morphComp == null || !morphComp.IsMorphing())
		{
			return;
		}
		EResetMorphReason reason = EResetMorphReason.BeforeAction;
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ActionType", actionType);
		this.LogResetMorph(reason, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		this.ResetMorph(true);
	}

	// Token: 0x0601A23A RID: 107066 RVA: 0x007ABC88 File Offset: 0x007A9E88
	protected unsafe void OnCharOnUnifiedMoveStateChanged(ECharMoveState oldMoveState, ECharMoveState newMoveState)
	{
		CharacterMorphComponent morphComp = this.MorphComp;
		if (morphComp == null || !morphComp.IsMorphing())
		{
			return;
		}
		if (newMoveState == ECharMoveState.NormalSki)
		{
			EResetMorphReason reason = EResetMorphReason.MoveStateChanged;
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("OldMoveState", oldMoveState);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("NewMoveState", newMoveState);
			this.LogResetMorph(reason, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			this.ResetMorph(true);
		}
	}

	// Token: 0x0601A23B RID: 107067 RVA: 0x007ABD0C File Offset: 0x007A9F0C
	protected void OnRoleDeadEnd()
	{
		CharacterMorphComponent morphComp = this.MorphComp;
		if (morphComp != null && morphComp.IsMorphing())
		{
			this.LogResetMorph(EResetMorphReason.RoleDead, default(ReadOnlySpan<ValueTuple<string, object>>));
			this.ResetMorph(false);
		}
	}

	// Token: 0x0601A23C RID: 107068 RVA: 0x007ABD44 File Offset: 0x007A9F44
	protected void OnRoleRevive()
	{
		CharacterMorphComponent morphComp = this.MorphComp;
		if (morphComp != null && morphComp.IsMorphing())
		{
			this.LogResetMorph(EResetMorphReason.RoleRevive, default(ReadOnlySpan<ValueTuple<string, object>>));
			this.ResetMorph(false);
		}
	}

	// Token: 0x0601A23D RID: 107069 RVA: 0x007ABD7C File Offset: 0x007A9F7C
	protected void OnExecuteAfterSetPlotMode()
	{
		if (!this.ShouldResetMorphOnPlotMode())
		{
			return;
		}
		this.LogResetMorph(EResetMorphReason.BeforePlot, default(ReadOnlySpan<ValueTuple<string, object>>));
		this.ResetMorph(true);
	}

	// Token: 0x0601A23E RID: 107070 RVA: 0x007ABDA9 File Offset: 0x007A9FA9
	protected virtual void OnCharacterMorphTypeChanged(Entity entity, EMorphType newMorphType, EMorphType oldMorphType)
	{
		this.RefreshNoUpdateMeshes(newMorphType);
	}

	// Token: 0x0601A23F RID: 107071 RVA: 0x007ABDB2 File Offset: 0x007A9FB2
	protected void OnBeforeSkillSimulateMontage(int entityId, int skillId, int montageIndex, float startTimeSeconds)
	{
		CharacterActorComponent actorComp = this.ActorComp;
		if (actorComp != null && actorComp.IsRoleAndCtrlByMe)
		{
			return;
		}
		this.SyncRemoteSkillMontage(skillId);
	}

	// Token: 0x0601A240 RID: 107072 RVA: 0x007ABDD0 File Offset: 0x007A9FD0
	protected void OnGlideStateChanged(int tagId, bool bTagExists)
	{
		if (bTagExists)
		{
			CharacterMorphComponent morphComp = this.MorphComp;
			if (morphComp != null && morphComp.IsMorphing())
			{
				int id = this.SpecialSkillComponent.Entity.Id;
				SceneTeamModel instance = ModelBase<SceneTeamModel>.Instance;
				int? num;
				if (instance == null)
				{
					num = null;
				}
				else
				{
					EntityHandle getCurrentEntity = instance.GetCurrentEntity;
					if (getCurrentEntity == null)
					{
						num = null;
					}
					else
					{
						WorldEntity entity = getCurrentEntity.Entity;
						num = ((entity != null) ? new int?(entity.Id) : null);
					}
				}
				int? num2 = num;
				if (id == num2.GetValueOrDefault() & num2 != null)
				{
					this.LogResetMorph(EResetMorphReason.EnterGlide, default(ReadOnlySpan<ValueTuple<string, object>>));
					this.ResetMorph(true);
				}
			}
		}
	}

	// Token: 0x0601A241 RID: 107073 RVA: 0x007ABE7C File Offset: 0x007AA07C
	protected bool ShouldResetMorphBeforeSkill(int skillId)
	{
		if (this.SkillComp == null)
		{
			return false;
		}
		SSkillInfo skillInfo = this.SkillComp.GetSkillInfo(skillId);
		if (skillInfo == null)
		{
			return false;
		}
		bool flag = false;
		if (SpecialSkillMorphBase.IsSkillInConfig(skillId, this.ResetMorphSkillsConfigKey, ref SpecialSkillMorphBase._morphResetConfigCache))
		{
			flag = true;
		}
		else if (SpecialSkillMorphBase.IsSkillInConfig(skillId, this.NotResetMorphSkillsConfigKey, ref SpecialSkillMorphBase._morphKeepConfigCache))
		{
			flag = false;
		}
		else if (skillInfo.GroupId != 1)
		{
			flag = false;
		}
		else if (skillInfo.SkillGenre == ESkillGenre.探索幻象技10)
		{
			flag = true;
		}
		CharacterMorphComponent morphComp = this.MorphComp;
		bool flag2 = morphComp != null && morphComp.IsMorphing() && !flag;
		global::Skill skill = this.SkillComp.GetSkill(skillId);
		Entity entity = this.SkillComp.Entity;
		if (skill != null && skillInfo.MontagePaths.Num() > 0)
		{
			TArray<string> montagePaths = skillInfo.MontagePaths;
			for (int i = 0; i < montagePaths.Num(); i++)
			{
				string name = montagePaths.Get(i);
				UAnimMontage montageByIndex = skill.GetMontageByIndex(i);
				UAnimMontage uanimMontage;
				if (!flag2)
				{
					CharacterMontageComponent montageComp = this.MontageComp;
					uanimMontage = ((montageComp != null) ? montageComp.GetMontageByName(name, false, false) : null);
				}
				else
				{
					CharacterMorphComponent morphComp2 = this.MorphComp;
					uanimMontage = ((morphComp2 != null) ? morphComp2.GetMontageByName(name) : null);
				}
				UAnimMontage uanimMontage2 = uanimMontage;
				if (montageByIndex != null && uanimMontage2 != null && montageByIndex != uanimMontage2)
				{
					skill.SetMontageByIndex(i, uanimMontage2);
					if (entity != null)
					{
					}
				}
				else if (montageByIndex == null && uanimMontage2 != null)
				{
					skill.SetMontageByIndex(i, uanimMontage2);
					if (entity != null)
					{
					}
				}
				else if (montageByIndex != null && uanimMontage2 == null)
				{
					if (flag2)
					{
						flag = true;
					}
				}
			}
		}
		return flag;
	}

	// Token: 0x0601A242 RID: 107074 RVA: 0x007AC004 File Offset: 0x007AA204
	protected int? ShouldResetMorphOnChangeRole(EntityHandle newEntity, [Nullable(2)] EntityHandle oldEntity)
	{
		WorldEntity entity = newEntity.Entity;
		int? result = (entity != null) ? new int?(entity.Id) : null;
		int id = this.SpecialSkillComponent.Entity.Id;
		if (!(result.GetValueOrDefault() == id & result != null))
		{
			result = null;
			return result;
		}
		CharacterMorphComponent morphComp = this.MorphComp;
		if (morphComp == null || !morphComp.IsMorphing())
		{
			result = null;
			return result;
		}
		ECharPositionState? echarPositionState;
		if (oldEntity == null)
		{
			echarPositionState = null;
		}
		else
		{
			WorldEntity entity2 = oldEntity.Entity;
			if (entity2 == null)
			{
				echarPositionState = null;
			}
			else
			{
				CharacterUnifiedStateComponent component = entity2.GetComponent<CharacterUnifiedStateComponent>();
				echarPositionState = ((component != null) ? new ECharPositionState?(component.PositionState) : null);
			}
		}
		ECharPositionState? echarPositionState2 = echarPositionState;
		ECharPositionState echarPositionState3 = ECharPositionState.Ground;
		if (echarPositionState2.GetValueOrDefault() == echarPositionState3 & echarPositionState2 != null)
		{
			result = null;
			return result;
		}
		List<int> tagsFromConfig = SpecialSkillMorphBase.GetTagsFromConfig(ref SpecialSkillMorphBase._changeRoleResetMorphTagsCache, this.ChangeRoleResetMorphTagsConfigKey);
		if (tagsFromConfig.Count > 0)
		{
			BaseTagComponent baseTagComponent;
			if (oldEntity == null)
			{
				baseTagComponent = null;
			}
			else
			{
				WorldEntity entity3 = oldEntity.Entity;
				baseTagComponent = ((entity3 != null) ? entity3.GetComponent<BaseTagComponent>() : null);
			}
			BaseTagComponent baseTagComponent2 = baseTagComponent;
			foreach (int num in tagsFromConfig)
			{
				if (baseTagComponent2 != null && baseTagComponent2.HasTag(num))
				{
					return new int?(num);
				}
			}
		}
		return null;
	}

	// Token: 0x0601A243 RID: 107075 RVA: 0x007AC180 File Offset: 0x007AA380
	protected bool ShouldResetMorphOnPlotMode()
	{
		PlotModel instance = ModelBase<PlotModel>.Instance;
		PlotConfig plotConfig = (instance != null) ? instance.PlotConfig : null;
		if (plotConfig == null)
		{
			return false;
		}
		EPlotLevel? plotLevel = plotConfig.PlotLevel;
		bool shouldSwitchMainRole = plotConfig.ShouldSwitchMainRole;
		if (plotLevel != EPlotLevel.LevelC || shouldSwitchMainRole)
		{
			return false;
		}
		SceneTeamModel instance2 = ModelBase<SceneTeamModel>.Instance;
		EntityHandle entityHandle = (instance2 != null) ? instance2.GetCurrentEntity : null;
		int? num;
		if (entityHandle == null)
		{
			num = null;
		}
		else
		{
			WorldEntity entity = entityHandle.Entity;
			num = ((entity != null) ? new int?(entity.Id) : null);
		}
		int? num2 = num;
		int id = this.SpecialSkillComponent.Entity.Id;
		if (!(num2.GetValueOrDefault() == id & num2 != null))
		{
			return false;
		}
		CharacterMorphComponent morphComp = this.MorphComp;
		return morphComp != null && morphComp.IsMorphing();
	}

	// Token: 0x0601A244 RID: 107076 RVA: 0x007AC258 File Offset: 0x007AA458
	protected void SyncRemoteSkillMontage(int skillId)
	{
		BaseSkillComponent skillComp = this.SkillComp;
		global::Skill skill = (skillComp != null) ? skillComp.GetSkill(skillId) : null;
		SSkillInfo sskillInfo = (skill != null) ? skill.SkillInfo : null;
		if (skill == null || sskillInfo == null)
		{
			return;
		}
		CharacterMorphComponent morphComp = this.MorphComp;
		bool flag = morphComp != null && morphComp.IsMorphing();
		if (sskillInfo.MontagePaths.Num() > 0)
		{
			TArray<string> montagePaths = sskillInfo.MontagePaths;
			for (int i = 0; i < montagePaths.Num(); i++)
			{
				string name = montagePaths.Get(i);
				UAnimMontage montageByIndex = skill.GetMontageByIndex(i);
				UAnimMontage uanimMontage;
				if (!flag)
				{
					CharacterMontageComponent montageComp = this.MontageComp;
					uanimMontage = ((montageComp != null) ? montageComp.GetMontageByName(name, false, false) : null);
				}
				else
				{
					CharacterMorphComponent morphComp2 = this.MorphComp;
					uanimMontage = ((morphComp2 != null) ? morphComp2.GetMontageByName(name) : null);
				}
				UAnimMontage uanimMontage2 = uanimMontage;
				if ((montageByIndex != null && uanimMontage2 != null && montageByIndex != uanimMontage2) || (montageByIndex == null && uanimMontage2 != null))
				{
					skill.SetMontageByIndex(i, uanimMontage2);
					BaseSkillComponent skillComp2 = this.SkillComp;
					if (skillComp2 != null)
					{
						Entity entity = skillComp2.Entity;
					}
				}
			}
		}
	}

	// Token: 0x0601A245 RID: 107077 RVA: 0x007AC350 File Offset: 0x007AA550
	private static HashSet<long> GetSkillsFromConfig([Nullable(new byte[]
	{
		2,
		1,
		1
	})] ref Dictionary<string, HashSet<long>> cache, [Nullable(2)] string configKey)
	{
		if (string.IsNullOrEmpty(configKey))
		{
			return new HashSet<long>();
		}
		if (cache == null)
		{
			cache = new Dictionary<string, HashSet<long>>();
		}
		HashSet<long> hashSet;
		if (!cache.TryGetValue(configKey, out hashSet))
		{
			hashSet = new HashSet<long>();
			IReadOnlyList<int> intArrayConfig = ConfigCommonParamById.GetIntArrayConfig(configKey);
			if (intArrayConfig != null)
			{
				foreach (int num in intArrayConfig)
				{
					hashSet.Add((long)num);
				}
			}
			cache[configKey] = hashSet;
		}
		return hashSet;
	}

	// Token: 0x0601A246 RID: 107078 RVA: 0x007AC3DC File Offset: 0x007AA5DC
	[NullableContext(2)]
	private static bool IsSkillInConfig(int skillId, string configKey, [Nullable(new byte[]
	{
		2,
		1,
		1
	})] ref Dictionary<string, HashSet<long>> cache)
	{
		return !string.IsNullOrEmpty(configKey) && SpecialSkillMorphBase.GetSkillsFromConfig(ref cache, configKey).Contains((long)skillId);
	}

	// Token: 0x0601A247 RID: 107079 RVA: 0x007AC3F8 File Offset: 0x007AA5F8
	private static List<int> GetTagsFromConfig([Nullable(new byte[]
	{
		2,
		1,
		1
	})] ref Dictionary<string, List<int>> cache, [Nullable(2)] string configKey)
	{
		if (string.IsNullOrEmpty(configKey))
		{
			return new List<int>();
		}
		if (cache == null)
		{
			cache = new Dictionary<string, List<int>>();
		}
		List<int> list;
		if (!cache.TryGetValue(configKey, out list))
		{
			list = new List<int>();
			IReadOnlyList<string> stringArrayConfig = ConfigCommonParamById.GetStringArrayConfig(configKey);
			if (stringArrayConfig != null)
			{
				foreach (string tagName in stringArrayConfig)
				{
					list.Add(GameplayTagUtils.GetTagIdByName(tagName));
				}
			}
			cache[configKey] = list;
		}
		return list;
	}

	// Token: 0x0601A248 RID: 107080 RVA: 0x007AC484 File Offset: 0x007AA684
	private static List<string> GetSubMeshNamesFromConfig([Nullable(2)] string configKey)
	{
		if (string.IsNullOrEmpty(configKey))
		{
			return new List<string>();
		}
		if (SpecialSkillMorphBase._morphSubMeshCache == null)
		{
			SpecialSkillMorphBase._morphSubMeshCache = new Dictionary<string, List<string>>();
		}
		List<string> list;
		if (!SpecialSkillMorphBase._morphSubMeshCache.TryGetValue(configKey, out list))
		{
			list = new List<string>();
			IReadOnlyList<string> stringArrayConfig = ConfigCommonParamById.GetStringArrayConfig(configKey);
			if (stringArrayConfig != null)
			{
				list.AddRange(stringArrayConfig);
			}
			SpecialSkillMorphBase._morphSubMeshCache[configKey] = list;
		}
		return list;
	}

	// Token: 0x0601A249 RID: 107081 RVA: 0x007AC4E4 File Offset: 0x007AA6E4
	private static List<long> GetMorphBuffsFromConfig([Nullable(2)] string configKey)
	{
		if (string.IsNullOrEmpty(configKey))
		{
			return new List<long>();
		}
		if (SpecialSkillMorphBase._morphBuffsCache == null)
		{
			SpecialSkillMorphBase._morphBuffsCache = new Dictionary<string, List<long>>();
		}
		List<long> list;
		if (!SpecialSkillMorphBase._morphBuffsCache.TryGetValue(configKey, out list))
		{
			list = new List<long>();
			IReadOnlyList<long> long54ArrayConfig = ConfigCommonParamById.GetLong54ArrayConfig(configKey);
			if (long54ArrayConfig != null)
			{
				list.AddRange(long54ArrayConfig);
			}
			SpecialSkillMorphBase._morphBuffsCache[configKey] = list;
		}
		return list;
	}

	// Token: 0x0601A24A RID: 107082 RVA: 0x007AC544 File Offset: 0x007AA744
	private static List<long> GetMorphCueIdsFromConfig([Nullable(2)] string configKey)
	{
		if (string.IsNullOrEmpty(configKey))
		{
			return new List<long>();
		}
		if (SpecialSkillMorphBase._morphCueIdsCache == null)
		{
			SpecialSkillMorphBase._morphCueIdsCache = new Dictionary<string, List<long>>();
		}
		List<long> list;
		if (!SpecialSkillMorphBase._morphCueIdsCache.TryGetValue(configKey, out list))
		{
			list = new List<long>();
			IReadOnlyList<long> long54ArrayConfig = ConfigCommonParamById.GetLong54ArrayConfig(configKey);
			if (long54ArrayConfig != null)
			{
				list.AddRange(long54ArrayConfig);
			}
			SpecialSkillMorphBase._morphCueIdsCache[configKey] = list;
		}
		return list;
	}

	// Token: 0x0400D1E0 RID: 53728
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private static Dictionary<string, HashSet<long>> _morphResetConfigCache;

	// Token: 0x0400D1E1 RID: 53729
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private static Dictionary<string, HashSet<long>> _morphKeepConfigCache;

	// Token: 0x0400D1E2 RID: 53730
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private static Dictionary<string, List<int>> _changeRoleResetMorphTagsCache;

	// Token: 0x0400D1E3 RID: 53731
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	private static Dictionary<string, List<string>> _morphSubMeshCache;

	// Token: 0x0400D1E4 RID: 53732
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private static Dictionary<string, List<long>> _morphBuffsCache;

	// Token: 0x0400D1E5 RID: 53733
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private static Dictionary<string, List<long>> _morphCueIdsCache;

	// Token: 0x0400D1E6 RID: 53734
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static HashSet<USkeletalMeshComponent> _tempMeshes;

	// Token: 0x0400D1E7 RID: 53735
	[Nullable(2)]
	protected CharacterActorComponent ActorComp;

	// Token: 0x0400D1E8 RID: 53736
	[Nullable(2)]
	protected BaseAnimationComponent AnimComp;

	// Token: 0x0400D1E9 RID: 53737
	[Nullable(2)]
	protected CharacterMorphComponent MorphComp;

	// Token: 0x0400D1EA RID: 53738
	[Nullable(2)]
	protected BaseSkillComponent SkillComp;

	// Token: 0x0400D1EB RID: 53739
	[Nullable(2)]
	protected CharacterMontageComponent MontageComp;

	// Token: 0x0400D1EC RID: 53740
	[Nullable(2)]
	protected BaseBuffComponent BuffComp;

	// Token: 0x0400D1ED RID: 53741
	[Nullable(2)]
	protected BaseGameplayCueComponent CueComp;

	// Token: 0x0400D1EE RID: 53742
	[Nullable(2)]
	protected BaseTagComponent TagComp;

	// Token: 0x0400D1EF RID: 53743
	[Nullable(2)]
	protected RoleQteComponent RoleQteComp;

	// Token: 0x0400D1F0 RID: 53744
	[Nullable(2)]
	protected ITagTask GlideStateListener;

	// Token: 0x0400D1F1 RID: 53745
	protected readonly bool IsEnableOptimize = true;
}
