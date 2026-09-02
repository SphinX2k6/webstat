using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.Protocol.Summon;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Character.Role.FemaleM.Xiakong.Abilities.GA;
using CSharpScript.Game;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.NewWorld.Pawn.Component;
using UnrealEngine;

// Token: 0x02003153 RID: 12627
[NullableContext(2)]
[Nullable(0)]
public class SpecialSkillXiaKong : SpecialSkillBase
{
	// Token: 0x0601A264 RID: 107108 RVA: 0x007ACEDC File Offset: 0x007AB0DC
	[NullableContext(1)]
	public SpecialSkillXiaKong(CharacterSpecialSkillComponent specialSkillComponent) : base(specialSkillComponent)
	{
	}

	// Token: 0x0601A265 RID: 107109 RVA: 0x007ACF3C File Offset: 0x007AB13C
	public override void OnStart()
	{
		this.Entity = this.SpecialSkillComponent.Entity;
		this.EntityId = this.Entity.Id;
		CreatureDataComponent component = this.Entity.GetComponent<CreatureDataComponent>();
		this.CreatureDataId = component.GetCreatureDataId();
		this.CharacterSkillComponent = this.Entity.GetComponent<CharacterSkillComponent>();
		this.CharacterTimeScaleComponent = this.Entity.GetComponent<CharacterTimeScaleComponent>();
		this.TagComponent = this.Entity.GetComponent<RoleTagComponent>();
		this.AttrComponent = this.Entity.GetComponent<BaseAttributeComponent>();
		this.BuffComponent = this.Entity.GetComponent<RoleBuffComponent>();
		this.TimeScaleCompList = new CharacterTimeScaleComponent[4];
		this.IsAutonomous = (ModelBase<CreatureModel>.Instance.GetPlayerId() == component.GetPlayerId());
		if (this.IsAutonomous)
		{
			Singleton<EventSystem>.Instance.AddWithTarget<int, int, bool>(this.Entity, EEventName.CharUseSkill, new Action<int, int, bool>(this.OnCharUseSkill));
			Singleton<EventSystem>.Instance.AddWithTarget<int, int>(this.Entity, EEventName.OnSkillEnd, new Action<int, int>(this.OnSkillEnd));
			Singleton<EventSystem>.Instance.Add(EEventName.OnBeforeChangeRole, new Action<EntityHandle, EntityHandle>(this.OnBeforeChangeRole));
			Singleton<EventSystem>.Instance.Add(EEventName.OnBeforeUpdateSceneTeam, new Action<EntityHandle, EntityHandle>(this.OnBeforeUpdateSceneTeam));
			Singleton<EventSystem>.Instance.Add<EntityHandle, EntityHandle>(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole));
		}
		this.InitSummonedEntity();
		this.InitSimulateEntity();
	}

	// Token: 0x0601A266 RID: 107110 RVA: 0x007AD0A8 File Offset: 0x007AB2A8
	private void InitSummonedEntity()
	{
		if (!this.IsAutonomous)
		{
			return;
		}
		for (int i = 1; i <= 3; i++)
		{
			EntityHandle summonedEntity = PhantomUtil.GetSummonedEntity(this.Entity, ESummonType.ConcomitantCustom, i);
			if (summonedEntity == null || !summonedEntity.Valid)
			{
				CombatLog instance = Singleton<CombatLog>.Instance;
				CombatLog.EDebugModule flag = CombatLog.EDebugModule.Skill;
				Entity entity = this.Entity;
				string message = "夏空Start获取幻影实体失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("pos", i);
				instance.Info(flag, entity, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				this.SummonedEntityList.Add(null);
				this.SummonedEntityHandleIdList.Add(0);
			}
			else
			{
				this.SummonedEntityList.Add(summonedEntity);
				int item = summonedEntity.Entity.GetComponent<CharacterActorComponent>().DisableActor("夏空幻影Start");
				this.SummonedEntityHandleIdList.Add(item);
			}
		}
		this.Timer = TimerSystem.Instance.Forever(delegate(float _)
		{
			this.CheckSummonedDistance();
		}, 1000f, 1f, null, null, true);
	}

	// Token: 0x0601A267 RID: 107111 RVA: 0x007AD190 File Offset: 0x007AB390
	public override void OnActivate()
	{
		if (!this.IsAutonomous)
		{
			return;
		}
		for (int i = 0; i < this.SummonedEntityList.Count; i++)
		{
			EntityHandle entityHandle = this.SummonedEntityList[i];
			if (entityHandle == null)
			{
				entityHandle = PhantomUtil.GetSummonedEntity(this.Entity, ESummonType.ConcomitantCustom, i + 1);
			}
			if (entityHandle == null || !entityHandle.Valid)
			{
				CombatLog instance = Singleton<CombatLog>.Instance;
				CombatLog.EDebugModule flag = CombatLog.EDebugModule.Skill;
				Entity entity = this.Entity;
				string message = "夏空Activate获取幻影实体失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("pos", i + 1);
				instance.Error(flag, entity, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			else
			{
				SpecialSkillXiaKongSummoned specialSkillXiaKongSummoned = new SpecialSkillXiaKongSummoned();
				specialSkillXiaKongSummoned.Init(entityHandle);
				this.SummonedList.Add(specialSkillXiaKongSummoned);
				ControllerBase<CreatureController>.Instance.SetEntityEnable(entityHandle.Entity, true, "夏空幻影初始化", true);
				ControllerBase<CreatureController>.Instance.SetActorVisible(entityHandle.Entity, false, false, false, "夏空幻影Activate", true);
				if (this.SummonedEntityHandleIdList[i] != 0)
				{
					CharacterActorComponent component = entityHandle.Entity.GetComponent<CharacterActorComponent>();
					if (component != null)
					{
						component.EnableActor(this.SummonedEntityHandleIdList[i]);
					}
				}
			}
		}
	}

	// Token: 0x0601A268 RID: 107112 RVA: 0x007AD2A0 File Offset: 0x007AB4A0
	private void InitSimulateEntity()
	{
		if (this.IsAutonomous)
		{
			return;
		}
		Singleton<EventSystem>.Instance.AddWithTarget<int, int, int, float>(this.Entity, EEventName.OnSkillSimulateMontage, new Action<int, int, int, float>(this.OnSkillSimulateMontage));
		this.WaitSummonedEntityMap.Clear();
		for (int i = 0; i < 3; i++)
		{
			long num = this.Entity.GetComponent<CreatureDataComponent>().CustomServerEntityIds[i];
			EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity((long)((int)num));
			if (entity == null || !entity.Valid)
			{
				this.WaitSummonedEntityMap[num] = i;
				this.SummonedEntityList.Add(null);
			}
			else
			{
				this.SummonedEntityList.Add(entity);
				Singleton<EventSystem>.Instance.AddWithTargetUseHoldKey<int, int, int, float>(this, entity.Entity, EEventName.OnSkillSimulateMontage, new Action<int, int, int, float>(this.OnSkillSimulateMontage));
			}
		}
		if (this.WaitSummonedEntityMap.Count > 0)
		{
			Singleton<EventSystem>.Instance.Add<CreatureDataComponent, EntityHandle>(EEventName.CreateEntity, new Action<CreatureDataComponent, EntityHandle>(this.OnCreateEntity));
		}
	}

	// Token: 0x0601A269 RID: 107113 RVA: 0x007AD39C File Offset: 0x007AB59C
	[NullableContext(1)]
	private void OnCreateEntity(CreatureDataComponent creatureData, EntityHandle entityHandle)
	{
		long creatureDataId = creatureData.GetCreatureDataId();
		int index;
		if (!this.WaitSummonedEntityMap.TryGetValue(creatureDataId, out index))
		{
			return;
		}
		this.WaitSummonedEntityMap.Remove(creatureDataId);
		this.SummonedEntityList[index] = entityHandle;
		Singleton<EventSystem>.Instance.AddWithTargetUseHoldKey<int, int, int, float>(this, entityHandle.Entity, EEventName.OnSkillSimulateMontage, new Action<int, int, int, float>(this.OnSkillSimulateMontage));
		if (this.WaitSummonedEntityMap.Count <= 0)
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.CreateEntity, new Action<CreatureDataComponent, EntityHandle>(this.OnCreateEntity));
		}
	}

	// Token: 0x0601A26A RID: 107114 RVA: 0x007AD428 File Offset: 0x007AB628
	public override void OnTick(float delta)
	{
		if (this.IsUltraSkillState && this.StartFrame != Singleton<Time>.Instance.Frame)
		{
			this.OnUltraSkillTick(delta * this.GetTimeScale());
		}
		CharacterTimeScaleComponent characterTimeScaleComponent = this.UpdateSummonedTimeScale();
		if (characterTimeScaleComponent != this.LastTimeScaleComp)
		{
			CharacterTimeScaleComponent lastTimeScaleComp = this.LastTimeScaleComp;
			if (lastTimeScaleComp != null && lastTimeScaleComp.Valid)
			{
				this.LastTimeScaleComp.RemoveForceTimeScale("SpecialSkillXiaKong.SummonedSync", false);
			}
			this.LastTimeScaleComp = characterTimeScaleComponent;
		}
	}

	// Token: 0x0601A26B RID: 107115 RVA: 0x007AD49C File Offset: 0x007AB69C
	private CharacterTimeScaleComponent UpdateSummonedTimeScale()
	{
		if (this.TimeScaleCompList == null)
		{
			return null;
		}
		int? intValueByEntity = ControllerBase<BlackboardController>.Instance.GetIntValueByEntity(this.EntityId, "VisionId");
		if (intValueByEntity == null || intValueByEntity.Value == 0)
		{
			return null;
		}
		int value = intValueByEntity.Value;
		if (value < 0 || value >= this.TimeScaleCompList.Length)
		{
			return null;
		}
		CharacterTimeScaleComponent characterTimeScaleComponent = this.TimeScaleCompList[value];
		if (characterTimeScaleComponent == null)
		{
			EntityHandle summonedEntity = PhantomUtil.GetSummonedEntity(this.Entity, ESummonType.ConcomitantCustom, value);
			if (summonedEntity == null || !summonedEntity.Valid)
			{
				return null;
			}
			WorldEntity entity = summonedEntity.Entity;
			characterTimeScaleComponent = ((entity != null) ? entity.GetComponent<CharacterTimeScaleComponent>() : null);
			if (characterTimeScaleComponent != null)
			{
				this.TimeScaleCompList[value] = characterTimeScaleComponent;
			}
		}
		if (characterTimeScaleComponent != null)
		{
			characterTimeScaleComponent.AddForceTimeScale(this.CharacterTimeScaleComponent.CurrentTimeScale, "SpecialSkillXiaKong.SummonedSync", false, ETimeScaleSourceType.InnerForceTimeScale);
			return characterTimeScaleComponent;
		}
		return null;
	}

	// Token: 0x0601A26C RID: 107116 RVA: 0x007AD564 File Offset: 0x007AB764
	private void CheckSummonedDistance()
	{
		if (!this.IsAutonomous)
		{
			return;
		}
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		global::Vector vector;
		if (baseCharacter == null)
		{
			vector = null;
		}
		else
		{
			CharacterActorComponent characterActorComponent = baseCharacter.CharacterActorComponent;
			vector = ((characterActorComponent != null) ? characterActorComponent.ActorLocationProxy : null);
		}
		global::Vector vector2 = vector;
		if (vector2 == null)
		{
			return;
		}
		foreach (EntityHandle entityHandle in this.SummonedEntityList)
		{
			if (entityHandle != null && entityHandle.Valid)
			{
				WorldEntity entity = entityHandle.Entity;
				BaseActorComponent baseActorComponent = (entity != null) ? entity.GetComponent<BaseActorComponent>() : null;
				if (baseActorComponent != null && baseActorComponent.DisableActorHandle.Empty && global::Vector.DistSquared(baseActorComponent.ActorLocationProxy, vector2) > 900000000.0)
				{
					CharacterSkillComponent component = entityHandle.Entity.GetComponent<CharacterSkillComponent>();
					if (component != null)
					{
						component.StopAllSkills("幻影距离主体过远");
					}
				}
			}
		}
	}

	// Token: 0x0601A26D RID: 107117 RVA: 0x007AD648 File Offset: 0x007AB848
	public override void OnEnd()
	{
		if (this.Timer != null)
		{
			TimerSystem.Instance.Remove(this.Timer);
			this.Timer = null;
		}
		if (this.IsAutonomous)
		{
			if (this.IsUltraSkillState)
			{
				Singleton<EventSystem>.Instance.Emit<int, int, bool>(EEventName.BattleUiSpecialSkillEnableChanged, this.Entity.Id, 1407, false);
				this.IsUltraSkillState = false;
			}
			Singleton<EventSystem>.Instance.Remove(EEventName.OnBeforeChangeRole, new Action<EntityHandle, EntityHandle>(this.OnBeforeChangeRole));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnBeforeUpdateSceneTeam, new Action<EntityHandle, EntityHandle>(this.OnBeforeUpdateSceneTeam));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole));
			if (this.Entity != null)
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget<int, int, bool>(this.Entity, EEventName.CharUseSkill, new Action<int, int, bool>(this.OnCharUseSkill));
				Singleton<EventSystem>.Instance.RemoveWithTarget<int, int>(this.Entity, EEventName.OnSkillEnd, new Action<int, int>(this.OnSkillEnd));
				this.Entity = null;
			}
			foreach (SpecialSkillXiaKongSummoned specialSkillXiaKongSummoned in this.SummonedList)
			{
				specialSkillXiaKongSummoned.Destroy();
			}
			this.SummonedList.Clear();
		}
		else
		{
			if (Singleton<EventSystem>.Instance.Has(EEventName.CreateEntity, new Action<CreatureDataComponent, EntityHandle>(this.OnCreateEntity)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.CreateEntity, new Action<CreatureDataComponent, EntityHandle>(this.OnCreateEntity));
			}
			foreach (EntityHandle entityHandle in this.SummonedEntityList)
			{
				if (((entityHandle != null) ? entityHandle.Entity : null) != null)
				{
					Singleton<EventSystem>.Instance.RemoveWithTargetUseKey<int, int, int, float>(this, entityHandle.Entity, EEventName.OnSkillSimulateMontage, new Action<int, int, int, float>(this.OnSkillSimulateMontage));
				}
			}
			Singleton<EventSystem>.Instance.RemoveAllTargetUseKey(this);
			if (this.Entity != null)
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget<int, int, int, float>(this.Entity, EEventName.OnSkillSimulateMontage, new Action<int, int, int, float>(this.OnSkillSimulateMontage));
				this.Entity = null;
			}
		}
		this.SummonedEntityList.Clear();
		this.CharacterSkillComponent = null;
		this.CharacterTimeScaleComponent = null;
		this.UltraSkill = null;
		this.TimeScaleCompList = null;
	}

	// Token: 0x0601A26E RID: 107118 RVA: 0x007AD8A8 File Offset: 0x007ABAA8
	private void OnCharUseSkill(int entityId, int skillId, bool isAutonomousProxy)
	{
		if (skillId != 1407200)
		{
			return;
		}
		this.IsUltraSkillState = true;
		this.StartFrame = Singleton<Time>.Instance.Frame;
		CharacterSkillComponent characterSkillComponent = this.CharacterSkillComponent;
		this.UltraSkill = ((characterSkillComponent != null) ? characterSkillComponent.GetSkill(1407200) : null);
		if (this.BuffList.Count == 0)
		{
			CharacterSkillComponent characterSkillComponent2 = this.CharacterSkillComponent;
			TArray<long> tarray;
			if (characterSkillComponent2 == null)
			{
				tarray = null;
			}
			else
			{
				SSkillInfo skillInfo = characterSkillComponent2.GetSkillInfo(1407200);
				tarray = ((skillInfo != null) ? skillInfo.SpecialBuffInCode : null);
			}
			TArray<long> tarray2 = tarray;
			if (tarray2 != null && tarray2.Num() > 0)
			{
				for (int i = 0; i < tarray2.Num(); i++)
				{
					long num = tarray2.Get(i);
					if (num != 0L)
					{
						this.BuffList.Add(num);
					}
				}
			}
		}
		this.OnUltraSkillBegin();
	}

	// Token: 0x0601A26F RID: 107119 RVA: 0x007AD95D File Offset: 0x007ABB5D
	private void OnSkillEnd(int entityId, int skillId)
	{
		if (skillId != 1407200)
		{
			return;
		}
		this.IsUltraSkillState = false;
		this.OnUltraSkillEnd();
	}

	// Token: 0x0601A270 RID: 107120 RVA: 0x007AD978 File Offset: 0x007ABB78
	private void OnSkillSimulateMontage(int entityId, int skillId, int montageIndex, float startTimeSeconds)
	{
		foreach (EntityHandle entityHandle in this.SummonedEntityList)
		{
			if (entityHandle != null)
			{
				WorldEntity entity = entityHandle.Entity;
				int? num = (entity != null) ? new int?(entity.Id) : null;
				if (num.GetValueOrDefault() == entityId & num != null)
				{
					ControllerBase<CreatureController>.Instance.SetActorMovable(entityHandle.Entity, true, "同步幻影技能动作");
					break;
				}
			}
		}
		if (skillId != 1407004)
		{
			return;
		}
		if (startTimeSeconds < 22.333334f)
		{
			return;
		}
		float num2 = 18.333334f;
		float position = startTimeSeconds - MathF.Floor((startTimeSeconds - 4f) / num2) * num2;
		CharacterAnimationComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterAnimationComponent>(entityId);
		if (component != null && component.Valid)
		{
			component.MontageSetPosition(position);
		}
	}

	// Token: 0x0601A271 RID: 107121 RVA: 0x007ADA6C File Offset: 0x007ABC6C
	[NullableContext(1)]
	private void OnBeforeChangeRole(EntityHandle newEntity, [Nullable(2)] EntityHandle oldEntity)
	{
		if (newEntity == oldEntity)
		{
			return;
		}
		this.StopUltraSkillBeforeChangeRole(newEntity);
	}

	// Token: 0x0601A272 RID: 107122 RVA: 0x007ADA7A File Offset: 0x007ABC7A
	private void OnBeforeUpdateSceneTeam(EntityHandle newEntity, EntityHandle oldEntity)
	{
		if (newEntity == oldEntity)
		{
			return;
		}
		this.StopUltraSkillBeforeChangeRole(newEntity);
	}

	// Token: 0x0601A273 RID: 107123 RVA: 0x007ADA88 File Offset: 0x007ABC88
	private void StopUltraSkillBeforeChangeRole(EntityHandle newEntity)
	{
		if (!this.IsUltraSkillState)
		{
			return;
		}
		if (((newEntity != null) ? newEntity.Entity : null) == this.Entity)
		{
			float nextEndCircleAttrValue = this.GetNextEndCircleAttrValue(0);
			if (nextEndCircleAttrValue >= 22857f && nextEndCircleAttrValue < 30000f)
			{
				this.OnResult(true, false);
			}
			Entity entity = this.Entity;
			if (entity == null)
			{
				return;
			}
			RoleTeamComponent component = entity.GetComponent<RoleTeamComponent>();
			if (component == null)
			{
				return;
			}
			component.DisableRoleWithoutEffect();
		}
	}

	// Token: 0x0601A274 RID: 107124 RVA: 0x007ADAEC File Offset: 0x007ABCEC
	[NullableContext(1)]
	private void OnChangeRole(EntityHandle newEntity, [Nullable(2)] EntityHandle oldEntity)
	{
		bool flag = newEntity.Entity == this.Entity;
		if (this.IsForeground == flag)
		{
			return;
		}
		this.IsForeground = flag;
		if (!this.IsUltraSkillState)
		{
			return;
		}
		if (this.IsForeground)
		{
			Skill ultraSkill = this.UltraSkill;
			GA_Xiakong_Burst_C ga_Xiakong_Burst_C = ((ultraSkill != null) ? ultraSkill.ActiveAbility : null) as GA_Xiakong_Burst_C;
			if (ga_Xiakong_Burst_C != null)
			{
				ga_Xiakong_Burst_C.SetIsInterrupt(true);
			}
			CharacterSkillComponent characterSkillComponent = this.CharacterSkillComponent;
			if (characterSkillComponent == null)
			{
				return;
			}
			characterSkillComponent.EndSkill(1407200, "夏空大招从后台切回来");
		}
	}

	// Token: 0x0601A275 RID: 107125 RVA: 0x007ADB67 File Offset: 0x007ABD67
	private float GetTimeScale()
	{
		if (this.Entity == null || this.CharacterTimeScaleComponent == null)
		{
			return 1f;
		}
		return this.Entity.TimeDilation * this.CharacterTimeScaleComponent.CurrentTimeScale;
	}

	// Token: 0x0601A276 RID: 107126 RVA: 0x007ADB98 File Offset: 0x007ABD98
	private void OnUltraSkillBegin()
	{
		this.NextGenCircleIndex = 0;
		this.NextEndCircleIndex = 0;
		this.GenBuffList.Clear();
		this.CircleSpeed = 14.285714f;
		RoleTagComponent tagComponent = this.TagComponent;
		this.IsForeground = (tagComponent != null && tagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.前台"]));
		this.CircleGenCountDown = 2332f * this.CircleSpeed;
		this.TotalTime = 0f;
		this.InputType = 0;
		this.IsStopGenCircle = false;
		this.InputStartCountDown = 3664f;
		this.ColorType = 1;
		RoleTagComponent tagComponent2 = this.TagComponent;
		if (tagComponent2 != null)
		{
			tagComponent2.TagContainer.UpdateExactTag(ETagChannel.Common, GameplayTagDefine.EGameplayTagId["角色.Common.切人不隐藏"], 1);
		}
		Singleton<EventSystem>.Instance.Emit<int, int, bool>(EEventName.BattleUiSpecialSkillEnableChanged, this.Entity.Id, 1407, true);
	}

	// Token: 0x0601A277 RID: 107127 RVA: 0x007ADC78 File Offset: 0x007ABE78
	private void OnUltraSkillTick(float delta)
	{
		if (!this.IsStopGenCircle)
		{
			this.TotalTime += delta;
			if (this.TotalTime > 34000f)
			{
				this.IsStopGenCircle = true;
			}
		}
		if (this.InputStartCountDown > 0f)
		{
			this.InputStartCountDown -= delta;
		}
		float addValue = this.CircleSpeed * delta;
		this.AddAttrValue(EAttributeType.SpecialEnergy1, addValue);
		this.AddAttrValue(EAttributeType.SpecialEnergy2, addValue);
		this.CheckInput();
		this.ClearInputType();
		this.CheckCircleGen(delta);
	}

	// Token: 0x0601A278 RID: 107128 RVA: 0x007ADCF8 File Offset: 0x007ABEF8
	private void OnUltraSkillEnd()
	{
		for (int i = this.NextEndCircleIndex; i < this.NextGenCircleIndex; i++)
		{
			long buffId = this.GenBuffList[i];
			RoleBuffComponent buffComponent = this.BuffComponent;
			if (buffComponent != null)
			{
				buffComponent.RemoveBuff(buffId, 1, "夏空大招结束清理", this.UltraSkill.CombatMessageId, null, null);
			}
		}
		this.NextEndCircleIndex = this.NextGenCircleIndex;
		RoleTagComponent tagComponent = this.TagComponent;
		if (tagComponent != null)
		{
			tagComponent.TagContainer.UpdateExactTag(ETagChannel.Common, GameplayTagDefine.EGameplayTagId["角色.Common.切人不隐藏"], -1);
		}
		Singleton<EventSystem>.Instance.Emit<int, int, bool>(EEventName.BattleUiSpecialSkillEnableChanged, this.Entity.Id, 1407, false);
	}

	// Token: 0x0601A279 RID: 107129 RVA: 0x007ADDB4 File Offset: 0x007ABFB4
	private void CheckInput()
	{
		if (this.NextEndCircleIndex >= this.NextGenCircleIndex)
		{
			return;
		}
		float nextEndCircleAttrValue = this.GetNextEndCircleAttrValue(0);
		if (!this.IsForeground)
		{
			if (nextEndCircleAttrValue >= 25000f)
			{
				this.OnResult(true, true);
			}
			return;
		}
		int inputType = this.GetInputType();
		if (inputType <= 0)
		{
			if (nextEndCircleAttrValue >= 30000f)
			{
				this.OnResult(false, false);
			}
			return;
		}
		if ((inputType == 1 || inputType == 2) && nextEndCircleAttrValue <= 30000f && nextEndCircleAttrValue >= 22857f)
		{
			this.ColorType = inputType;
			this.OnResult(true, false);
		}
	}

	// Token: 0x0601A27A RID: 107130 RVA: 0x007ADE34 File Offset: 0x007AC034
	private void CheckCircleGen(float delta)
	{
		if (this.IsStopGenCircle)
		{
			return;
		}
		this.CircleGenCountDown -= delta * this.CircleSpeed;
		if (this.CircleGenCountDown > 0f)
		{
			return;
		}
		if (this.CreateNewCircle())
		{
			this.CircleGenCountDown = ((this.NextGenCircleIndex == 1) ? (1332f * this.CircleSpeed) : 23285.7f);
		}
	}

	// Token: 0x0601A27B RID: 107131 RVA: 0x007ADE97 File Offset: 0x007AC097
	private int GetAttrIndex(int circleIndex)
	{
		return circleIndex % 2;
	}

	// Token: 0x0601A27C RID: 107132 RVA: 0x007ADE9C File Offset: 0x007AC09C
	private EAttributeType GetAttrId(int attrIndex)
	{
		return EAttributeType.SpecialEnergy1 + attrIndex * 2;
	}

	// Token: 0x0601A27D RID: 107133 RVA: 0x007ADEA4 File Offset: 0x007AC0A4
	private long GetBuffId(int attrIndex)
	{
		List<long> buffList = this.BuffList;
		if (buffList.Count <= attrIndex || buffList[attrIndex] == 0L)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Battle;
			ELogAuthor author = ELogAuthor.CFT;
			string message = "[SpecialSkillXiaKong]不存在对应buff";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("index", attrIndex);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return 0L;
		}
		return buffList[attrIndex];
	}

	// Token: 0x0601A27E RID: 107134 RVA: 0x007ADF04 File Offset: 0x007AC104
	private bool CreateNewCircle()
	{
		if (this.NextGenCircleIndex - this.NextEndCircleIndex >= 2)
		{
			return false;
		}
		int attrIndex = this.GetAttrIndex(this.NextGenCircleIndex);
		EAttributeType attrId = this.GetAttrId(attrIndex);
		BaseAttributeComponent attrComponent = this.AttrComponent;
		if (attrComponent != null)
		{
			attrComponent.SetBaseValue(attrId, 0f);
		}
		long buffId = this.GetBuffId(attrIndex);
		this.GenBuffList.Add(buffId);
		long? combatMessageId = this.UltraSkill.CombatMessageId;
		RoleBuffComponent buffComponent = this.BuffComponent;
		if (buffComponent != null)
		{
			buffComponent.AddBuff(buffId, new AddBuffParam
			{
				InstigatorId = this.CreatureDataId,
				Reason = "夏空大招逻辑添加",
				PreMessageId = combatMessageId
			});
		}
		this.NextGenCircleIndex++;
		return true;
	}

	// Token: 0x0601A27F RID: 107135 RVA: 0x007ADFB4 File Offset: 0x007AC1B4
	private void DestroyNextEndCircle()
	{
		int nextEndCircleIndex = this.NextEndCircleIndex;
		int nextGenCircleIndex = this.NextGenCircleIndex;
		long buffId = this.GenBuffList[this.NextEndCircleIndex];
		RoleBuffComponent buffComponent = this.BuffComponent;
		if (buffComponent != null)
		{
			buffComponent.RemoveBuff(buffId, 1, "夏空大招逻辑移除", this.UltraSkill.CombatMessageId, null, null);
		}
		this.NextEndCircleIndex++;
	}

	// Token: 0x0601A280 RID: 107136 RVA: 0x007AE024 File Offset: 0x007AC224
	public float GetNextEndCircleAttrValue(int nextIndex = 0)
	{
		int attrIndex = this.GetAttrIndex(this.NextEndCircleIndex + nextIndex);
		EAttributeType attrId = this.GetAttrId(attrIndex);
		BaseAttributeComponent attrComponent = this.AttrComponent;
		if (attrComponent == null)
		{
			return 0f;
		}
		return attrComponent.GetCurrentValue(attrId);
	}

	// Token: 0x0601A281 RID: 107137 RVA: 0x007AE05E File Offset: 0x007AC25E
	private void OnResult(bool isSucceed, bool isAuto = false)
	{
		this.DestroyNextEndCircle();
		Skill ultraSkill = this.UltraSkill;
		GA_Xiakong_Burst_C ga_Xiakong_Burst_C = ((ultraSkill != null) ? ultraSkill.ActiveAbility : null) as GA_Xiakong_Burst_C;
		if (ga_Xiakong_Burst_C == null)
		{
			return;
		}
		ga_Xiakong_Burst_C.判定结果(isSucceed, isAuto, this.ColorType);
	}

	// Token: 0x0601A282 RID: 107138 RVA: 0x007AE090 File Offset: 0x007AC290
	private void AddAttrValue(EAttributeType attrId, float addValue)
	{
		if (this.AttrComponent == null)
		{
			return;
		}
		float value = this.AttrComponent.GetCurrentValue(attrId) + addValue;
		this.AttrComponent.SetBaseValue(attrId, value);
	}

	// Token: 0x0601A283 RID: 107139 RVA: 0x007AE0C2 File Offset: 0x007AC2C2
	private void ClearInputType()
	{
		this.InputType = 0;
	}

	// Token: 0x0601A284 RID: 107140 RVA: 0x007AE0CB File Offset: 0x007AC2CB
	private int GetInputType()
	{
		return this.InputType;
	}

	// Token: 0x0601A285 RID: 107141 RVA: 0x007AE0D4 File Offset: 0x007AC2D4
	public void SetInputType(int inputType)
	{
		if (!this.IsUltraSkillState || this.InputStartCountDown > 0f)
		{
			return;
		}
		if (inputType == 4)
		{
			this.InputType = 0;
			if (this.UltraSkill != null && this.NextGenCircleIndex > 0)
			{
				GA_Xiakong_Burst_C ga_Xiakong_Burst_C = this.UltraSkill.ActiveAbility as GA_Xiakong_Burst_C;
				if (ga_Xiakong_Burst_C != null)
				{
					ga_Xiakong_Burst_C.SetIsInterrupt(true);
				}
				CharacterSkillComponent characterSkillComponent = this.CharacterSkillComponent;
				if (characterSkillComponent != null)
				{
					characterSkillComponent.EndSkill(1407200, "夏空大招主动按键结束");
				}
				CharacterSkillComponent characterSkillComponent2 = this.CharacterSkillComponent;
				if (characterSkillComponent2 == null)
				{
					return;
				}
				characterSkillComponent2.BeginSkill(1407201, new SkillParam
				{
					Reason = "夏空主动结束大招触发"
				});
			}
			return;
		}
		this.InputType = inputType;
	}

	// Token: 0x0601A286 RID: 107142 RVA: 0x007AE178 File Offset: 0x007AC378
	public float GetMinAttrValue()
	{
		return 22857f;
	}

	// Token: 0x0601A287 RID: 107143 RVA: 0x007AE17F File Offset: 0x007AC37F
	public int GetNextGenCircleIndex()
	{
		return this.NextGenCircleIndex;
	}

	// Token: 0x0601A288 RID: 107144 RVA: 0x007AE187 File Offset: 0x007AC387
	public int GetNextEndCircleIndex()
	{
		return this.NextEndCircleIndex;
	}

	// Token: 0x0601A289 RID: 107145 RVA: 0x007AE18F File Offset: 0x007AC38F
	public bool GetIsUltraSkillState()
	{
		return this.IsUltraSkillState;
	}

	// Token: 0x0400D20C RID: 53772
	private const float CHECK_DISTANCE_INTERVAL = 1000f;

	// Token: 0x0400D20D RID: 53773
	private const float MAX_DISTANCE_SQUARED = 900000000f;

	// Token: 0x0400D20E RID: 53774
	private const int ULTRA_SKILL_ID = 1407200;

	// Token: 0x0400D20F RID: 53775
	private const int ULTRA_SECOND_SKILL_ID = 1407201;

	// Token: 0x0400D210 RID: 53776
	private const int LOOP_SKILL_ID = 1407004;

	// Token: 0x0400D211 RID: 53777
	private const float LOOP_START_TIME = 4f;

	// Token: 0x0400D212 RID: 53778
	private const float LOOP_END_TIME = 22.333334f;

	// Token: 0x0400D213 RID: 53779
	private const int CIRCLE_NUM = 2;

	// Token: 0x0400D214 RID: 53780
	private const float MAX_ATRR_VALUE = 30000f;

	// Token: 0x0400D215 RID: 53781
	private const float SUCC_MAX_ATTR_VALUE = 30000f;

	// Token: 0x0400D216 RID: 53782
	private const float SUCC_MIN_ATTR_VALUE = 22857f;

	// Token: 0x0400D217 RID: 53783
	private const float SUCC_BACKSTAGE_ATRR_VALUE = 25000f;

	// Token: 0x0400D218 RID: 53784
	private const float CIRCLE_SPEED_INIT = 14.285714f;

	// Token: 0x0400D219 RID: 53785
	private const float FRIST_CIRCLE_TIME = 2332f;

	// Token: 0x0400D21A RID: 53786
	private const float SECOND_CIRCLE_TIME = 1332f;

	// Token: 0x0400D21B RID: 53787
	private const float CIRCLE_INTERVAL = 23285.7f;

	// Token: 0x0400D21C RID: 53788
	private const float ULTRA_SKILL_TOTAL_TIME = 34000f;

	// Token: 0x0400D21D RID: 53789
	private const float INPUT_START_TIME = 3664f;

	// Token: 0x0400D21E RID: 53790
	[Nullable(1)]
	private const string FORCE_TIME_SCALE_LOCK_KEY = "SpecialSkillXiaKong.SummonedSync";

	// Token: 0x0400D21F RID: 53791
	private Entity Entity;

	// Token: 0x0400D220 RID: 53792
	private int EntityId;

	// Token: 0x0400D221 RID: 53793
	private long CreatureDataId;

	// Token: 0x0400D222 RID: 53794
	private CharacterSkillComponent CharacterSkillComponent;

	// Token: 0x0400D223 RID: 53795
	private CharacterTimeScaleComponent CharacterTimeScaleComponent;

	// Token: 0x0400D224 RID: 53796
	private RoleTagComponent TagComponent;

	// Token: 0x0400D225 RID: 53797
	private BaseAttributeComponent AttrComponent;

	// Token: 0x0400D226 RID: 53798
	private RoleBuffComponent BuffComponent;

	// Token: 0x0400D227 RID: 53799
	private Skill UltraSkill;

	// Token: 0x0400D228 RID: 53800
	private bool IsUltraSkillState;

	// Token: 0x0400D229 RID: 53801
	private int StartFrame;

	// Token: 0x0400D22A RID: 53802
	private CharacterTimeScaleComponent LastTimeScaleComp;

	// Token: 0x0400D22B RID: 53803
	private CharacterTimeScaleComponent[] TimeScaleCompList;

	// Token: 0x0400D22C RID: 53804
	[Nullable(new byte[]
	{
		1,
		2
	})]
	private readonly List<EntityHandle> SummonedEntityList = new List<EntityHandle>();

	// Token: 0x0400D22D RID: 53805
	[Nullable(1)]
	private readonly List<int> SummonedEntityHandleIdList = new List<int>();

	// Token: 0x0400D22E RID: 53806
	[Nullable(1)]
	private readonly List<SpecialSkillXiaKongSummoned> SummonedList = new List<SpecialSkillXiaKongSummoned>();

	// Token: 0x0400D22F RID: 53807
	private TimerHandle Timer;

	// Token: 0x0400D230 RID: 53808
	private bool IsAutonomous;

	// Token: 0x0400D231 RID: 53809
	[Nullable(1)]
	private readonly List<long> BuffList = new List<long>();

	// Token: 0x0400D232 RID: 53810
	private int NextGenCircleIndex;

	// Token: 0x0400D233 RID: 53811
	private int NextEndCircleIndex;

	// Token: 0x0400D234 RID: 53812
	[Nullable(1)]
	private readonly List<long> GenBuffList = new List<long>();

	// Token: 0x0400D235 RID: 53813
	private float CircleSpeed;

	// Token: 0x0400D236 RID: 53814
	private bool IsForeground;

	// Token: 0x0400D237 RID: 53815
	private float CircleGenCountDown;

	// Token: 0x0400D238 RID: 53816
	private float TotalTime;

	// Token: 0x0400D239 RID: 53817
	private int InputType;

	// Token: 0x0400D23A RID: 53818
	private bool IsStopGenCircle;

	// Token: 0x0400D23B RID: 53819
	private float InputStartCountDown;

	// Token: 0x0400D23C RID: 53820
	private int ColorType = 1;

	// Token: 0x0400D23D RID: 53821
	[Nullable(1)]
	private readonly Dictionary<long, int> WaitSummonedEntityMap = new Dictionary<long, int>();
}
