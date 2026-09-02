using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Effect;
using CSharpScript.Game.NewWorld.Pawn.Component;
using CSharpScript.Game.Utils;

namespace CSharpScript.Game.NewWorld.Character.Common.Component
{
	// Token: 0x0200490F RID: 18703
	[NullableContext(2)]
	[Nullable(0)]
	public class CharacterSelfCenterComponent : EntityComponent
	{
		// Token: 0x1700834D RID: 33613
		// (get) Token: 0x06030E09 RID: 200201 RVA: 0x00C1C4B7 File Offset: 0x00C1A6B7
		public float SelfCenterTimeDilation
		{
			get
			{
				return this.SelfCenterTimeDilationInternal;
			}
		}

		// Token: 0x06030E0A RID: 200202 RVA: 0x00C1C4C0 File Offset: 0x00C1A6C0
		private void OnCharacterSetMaster(int masterId)
		{
			CharacterSelfCenterComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterSelfCenterComponent>(masterId);
			if (component != null && component.WithFollow)
			{
				CharacterTimeScaleComponent timeScaleComp = component.TimeScaleComp;
				float timeDilation = (timeScaleComp != null) ? timeScaleComp.GetForeverTimeScale(component.SelfCenteredTimeScaleId) : 1f;
				this.SetSelfCenterTimeDilation(timeDilation, true);
			}
		}

		// Token: 0x06030E0B RID: 200203 RVA: 0x00C1C509 File Offset: 0x00C1A709
		private void OnRoleGoDownFinish()
		{
			this.ClearEffect();
		}

		// Token: 0x06030E0C RID: 200204 RVA: 0x00C1C514 File Offset: 0x00C1A714
		protected override bool OnStart()
		{
			this.Inited = true;
			this.CreatureDataComp = base.Entity.GetComponent<CreatureDataComponent>();
			this.ActorComp = base.Entity.GetComponent<CharacterActorComponent>();
			this.TimeScaleComp = base.Entity.GetComponent<CharacterTimeScaleComponent>();
			this.FollowComp = base.Entity.GetComponent<CharacterFollowComponent>();
			this.FrozenComp = base.Entity.GetComponent<BaseFrozenComponent>();
			this.PawnTimeScaleComp = base.Entity.GetComponent<PawnTimeScaleComponent>();
			this.EffectHandleSet = new HashSet<int>();
			this.ToRemoveEffectHandleSet = new HashSet<int>();
			CharacterModel instance = ModelBase<CharacterModel>.Instance;
			if (instance != null && instance.EnabledSelfCentered && ModelBase<CharacterModel>.Instance.SelfCenteredMode == ESelfCenteredMode.Skill)
			{
				this.InitEntityBornDilation(ModelBase<CharacterModel>.Instance.SelfCenteredMode, ModelBase<CharacterModel>.Instance.SelfCenteredTimeDilation);
			}
			Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.OnCharacterSetMaster, new Action<int>(this.OnCharacterSetMaster));
			Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.OnRoleGoDownFinish, new Action(this.OnRoleGoDownFinish));
			Singleton<EventSystem>.Instance.Add(EEventName.OnSwitchSelfCenteredMode, new Action<ESelfCenteredMode, float>(this.InitEntityBornDilation));
			return true;
		}

		// Token: 0x06030E0D RID: 200205 RVA: 0x00C1C640 File Offset: 0x00C1A840
		protected override bool OnEnd()
		{
			this.ClearEffect();
			Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.OnCharacterSetMaster, new Action<int>(this.OnCharacterSetMaster));
			Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.OnRoleGoDownFinish, new Action(this.OnRoleGoDownFinish));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSwitchSelfCenteredMode, new Action<ESelfCenteredMode, float>(this.InitEntityBornDilation));
			return true;
		}

		// Token: 0x06030E0E RID: 200206 RVA: 0x00C1C6B4 File Offset: 0x00C1A8B4
		protected void InitEntityBornDilation(ESelfCenteredMode selfCenteredMode, float globalTimeDilation)
		{
			if (this.ActorComp.CreatureData.GetEntityType() == EEntityType.Monster)
			{
				float buffBaseForeverTimeScale = 0f;
				if (selfCenteredMode == ESelfCenteredMode.Skill)
				{
					buffBaseForeverTimeScale = (Singleton<MathUtils>.Instance.IsNearlyEqual((double)globalTimeDilation, 1.0, null) ? 0f : ConfigCommonParamById.GetFloatConfig("MonsterSlowTimeDilation").GetValueOrDefault());
				}
				BaseFrozenComponent frozenComp = this.FrozenComp;
				if (frozenComp == null)
				{
					return;
				}
				frozenComp.SetBuffBaseForeverTimeScale(buffBaseForeverTimeScale);
			}
		}

		// Token: 0x06030E0F RID: 200207 RVA: 0x00C1C72C File Offset: 0x00C1A92C
		public void SetSelfCenterTimeDilation(float timeDilation, bool withFollow = true)
		{
			this.SelfCenterTimeDilationInternal = timeDilation;
			if (this.SelfCenteredTimeScaleId > 0)
			{
				CharacterTimeScaleComponent timeScaleComp = this.TimeScaleComp;
				if (timeScaleComp != null)
				{
					timeScaleComp.RemoveForeverTimeScale(this.SelfCenteredTimeScaleId, false);
				}
			}
			CharacterTimeScaleComponent timeScaleComp2 = this.TimeScaleComp;
			this.SelfCenteredTimeScaleId = ((timeScaleComp2 != null) ? timeScaleComp2.SetForeverTimeScale(ETimeScaleSourceType.SelfCentered, timeDilation, 0, true) : 0);
			if (withFollow)
			{
				CharacterFollowComponent followComp = this.FollowComp;
				List<int> list = (followComp != null) ? followComp.AttributeSharerIds : null;
				if (list != null)
				{
					foreach (int id in list)
					{
						CharacterSelfCenterComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterSelfCenterComponent>(id);
						if (component != null)
						{
							component.SetSelfCenterTimeDilation(timeDilation, withFollow);
						}
					}
				}
				IList<long> customServerEntityIds = this.CreatureDataComp.CustomServerEntityIds;
				if (customServerEntityIds.Count > 0)
				{
					foreach (long creatureDataId in customServerEntityIds)
					{
						CharacterSelfCenterComponent component2 = Singleton<EntitySystem>.Instance.GetComponent<CharacterSelfCenterComponent>(ModelBase<CreatureModel>.Instance.GetEntityId(creatureDataId));
						if (component2 != null)
						{
							component2.SetSelfCenterTimeDilation(timeDilation, withFollow);
						}
					}
				}
			}
			this.WithFollow = (!Singleton<MathUtils>.Instance.IsNearlyEqual((double)timeDilation, 1.0, null) && withFollow);
		}

		// Token: 0x06030E10 RID: 200208 RVA: 0x00C1C884 File Offset: 0x00C1AA84
		public void SetSelfBeHitTimeDilation(float timeDilation)
		{
			if (this.SelfBeHitTimeScaleId > 0)
			{
				CharacterTimeScaleComponent timeScaleComp = this.TimeScaleComp;
				if (timeScaleComp != null)
				{
					timeScaleComp.RemoveForeverTimeScale(this.SelfBeHitTimeScaleId, false);
				}
			}
			CharacterTimeScaleComponent timeScaleComp2 = this.TimeScaleComp;
			this.SelfBeHitTimeScaleId = ((timeScaleComp2 != null) ? timeScaleComp2.SetForeverTimeScale(ETimeScaleSourceType.SelfBeHit, timeDilation, 0, false) : 0);
		}

		// Token: 0x06030E11 RID: 200209 RVA: 0x00C1C8C4 File Offset: 0x00C1AAC4
		public void RemoveSelfBeHitTimeDilation()
		{
			CharacterTimeScaleComponent timeScaleComp = this.TimeScaleComp;
			if (timeScaleComp != null)
			{
				timeScaleComp.RemoveForeverTimeScale(this.SelfBeHitTimeScaleId, false);
			}
			this.SelfBeHitTimeScaleId = 0;
		}

		// Token: 0x06030E12 RID: 200210 RVA: 0x00C1C8E8 File Offset: 0x00C1AAE8
		public void SetBeHitTimeDilation(float timeDilation, float duration = 200f)
		{
			if (!Singleton<MathUtils>.Instance.IsNearlyEqual((double)this.SelfCenterTimeDilationInternal, 1.0, null))
			{
				return;
			}
			this.SetSelfBeHitTimeDilation(timeDilation);
			TimerHandle timerHandle = this.TimerHandle;
			if (timerHandle != null && timerHandle.Valid())
			{
				TimerSystem.Instance.Remove(this.TimerHandle);
				this.TimerHandle = null;
			}
			this.TimerHandle = TimerSystem.Instance.Delay(delegate(float delta)
			{
				this.RemoveSelfBeHitTimeDilation();
			}, duration, null, null, true, ModelBase<CharacterModel>.Instance.InverseSelfCenteredTimeDilation);
		}

		// Token: 0x06030E13 RID: 200211 RVA: 0x00C1C978 File Offset: 0x00C1AB78
		public void AddEffect(int handleId)
		{
			if (!this.CheckValid() || !base.Active)
			{
				return;
			}
			if (!Singleton<EffectSystem>.Instance.IsValid(handleId))
			{
				return;
			}
			this.EffectHandleSet.Add(handleId);
			PawnTimeScaleComponent pawnTimeScaleComp = this.PawnTimeScaleComp;
			if (pawnTimeScaleComp != null && pawnTimeScaleComp.Valid)
			{
				EffectUtil.SetEffectTimeScale(handleId, this.PawnTimeScaleComp, this.PawnTimeScaleComp.TimeDilation, ETimeScaleType.FollowEntity);
			}
		}

		// Token: 0x06030E14 RID: 200212 RVA: 0x00C1C9DD File Offset: 0x00C1ABDD
		public void RemoveEffect(int effectHandle)
		{
			if (!this.CheckValid())
			{
				return;
			}
			this.ToRemoveEffectHandleSet.Add(effectHandle);
		}

		// Token: 0x06030E15 RID: 200213 RVA: 0x00C1C9F8 File Offset: 0x00C1ABF8
		private void ClearEffect()
		{
			if (!this.CheckValid())
			{
				return;
			}
			if (this.EffectHandleSet.Count <= 0)
			{
				return;
			}
			foreach (int id in this.EffectHandleSet)
			{
				if (Singleton<EffectSystem>.Instance.IsValid(id))
				{
					Singleton<EffectSystem>.Instance.SetTimeScale(id, 1f, true);
				}
			}
			this.EffectHandleSet.Clear();
			this.ToRemoveEffectHandleSet.Clear();
		}

		// Token: 0x06030E16 RID: 200214 RVA: 0x00C1CA90 File Offset: 0x00C1AC90
		protected override void OnChangeTimeDilation(float timeDilation)
		{
			if (!this.CheckValid())
			{
				return;
			}
			if (this.EffectHandleSet.Count <= 0)
			{
				return;
			}
			foreach (int num in this.EffectHandleSet)
			{
				if (!Singleton<EffectSystem>.Instance.IsValid(num))
				{
					this.ToRemoveEffectHandleSet.Add(num);
				}
				else
				{
					PawnTimeScaleComponent pawnTimeScaleComp = this.PawnTimeScaleComp;
					if (pawnTimeScaleComp != null && pawnTimeScaleComp.Valid)
					{
						EffectUtil.SetEffectTimeScale(num, this.PawnTimeScaleComp, this.PawnTimeScaleComp.TimeDilation, ETimeScaleType.FollowEntity);
					}
					else
					{
						Singleton<EffectSystem>.Instance.SetTimeScale(num, 1f, true);
					}
				}
			}
			foreach (int item in this.ToRemoveEffectHandleSet)
			{
				this.EffectHandleSet.Remove(item);
			}
			this.ToRemoveEffectHandleSet.Clear();
		}

		// Token: 0x06030E17 RID: 200215 RVA: 0x00C1CBA4 File Offset: 0x00C1ADA4
		private bool CheckValid()
		{
			return this.Inited;
		}

		// Token: 0x06030E18 RID: 200216 RVA: 0x00C1CBAC File Offset: 0x00C1ADAC
		[NullableContext(1)]
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			CharacterSelfCenterComponent characterSelfCenterComponent = (CharacterSelfCenterComponent)componentTemplate;
			if (base.CanResetComponentProperty("CreatureDataComp"))
			{
				if (characterSelfCenterComponent.CreatureDataComp == null)
				{
					this.CreatureDataComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CreatureDataComponent>(this.CreatureDataComp), "CreatureDataComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("ActorComp"))
			{
				if (characterSelfCenterComponent.ActorComp == null)
				{
					this.ActorComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterActorComponent>(this.ActorComp), "ActorComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("TimeScaleComp"))
			{
				if (characterSelfCenterComponent.TimeScaleComp == null)
				{
					this.TimeScaleComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterTimeScaleComponent>(this.TimeScaleComp), "TimeScaleComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("FrozenComp"))
			{
				if (characterSelfCenterComponent.FrozenComp == null)
				{
					this.FrozenComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseFrozenComponent>(this.FrozenComp), "FrozenComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("FollowComp"))
			{
				if (characterSelfCenterComponent.FollowComp == null)
				{
					this.FollowComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterFollowComponent>(this.FollowComp), "FollowComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("PawnTimeScaleComp"))
			{
				if (characterSelfCenterComponent.PawnTimeScaleComp == null)
				{
					this.PawnTimeScaleComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<PawnTimeScaleComponent>(this.PawnTimeScaleComp), "PawnTimeScaleComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("EffectHandleSet"))
			{
				if (characterSelfCenterComponent.EffectHandleSet == null)
				{
					this.EffectHandleSet = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<int>(this.EffectHandleSet), "EffectHandleSet"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("ToRemoveEffectHandleSet"))
			{
				if (characterSelfCenterComponent.ToRemoveEffectHandleSet == null)
				{
					this.ToRemoveEffectHandleSet = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<int>(this.ToRemoveEffectHandleSet), "ToRemoveEffectHandleSet"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("SelfCenterTimeDilationInternal"))
			{
				this.SelfCenterTimeDilationInternal = characterSelfCenterComponent.SelfCenterTimeDilationInternal;
			}
			if (base.CanResetComponentProperty("WithFollow"))
			{
				this.WithFollow = characterSelfCenterComponent.WithFollow;
			}
			if (base.CanResetComponentProperty("TimerHandle"))
			{
				if (characterSelfCenterComponent.TimerHandle == null)
				{
					this.TimerHandle = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<TimerHandle>(this.TimerHandle), "TimerHandle"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("SelfCenteredTimeScaleId"))
			{
				this.SelfCenteredTimeScaleId = characterSelfCenterComponent.SelfCenteredTimeScaleId;
			}
			if (base.CanResetComponentProperty("SelfBeHitTimeScaleId"))
			{
				this.SelfBeHitTimeScaleId = characterSelfCenterComponent.SelfBeHitTimeScaleId;
			}
			if (base.CanResetComponentProperty("Inited"))
			{
				this.Inited = characterSelfCenterComponent.Inited;
			}
			return true;
		}

		// Token: 0x0401C18B RID: 115083
		private const int DEFAULT_BE_HIT_SELF_CENTER_DURATION = 200;

		// Token: 0x0401C18C RID: 115084
		private CreatureDataComponent CreatureDataComp;

		// Token: 0x0401C18D RID: 115085
		private CharacterActorComponent ActorComp;

		// Token: 0x0401C18E RID: 115086
		private CharacterTimeScaleComponent TimeScaleComp;

		// Token: 0x0401C18F RID: 115087
		private BaseFrozenComponent FrozenComp;

		// Token: 0x0401C190 RID: 115088
		private CharacterFollowComponent FollowComp;

		// Token: 0x0401C191 RID: 115089
		private PawnTimeScaleComponent PawnTimeScaleComp;

		// Token: 0x0401C192 RID: 115090
		private HashSet<int> EffectHandleSet;

		// Token: 0x0401C193 RID: 115091
		private HashSet<int> ToRemoveEffectHandleSet;

		// Token: 0x0401C194 RID: 115092
		private float SelfCenterTimeDilationInternal = 1f;

		// Token: 0x0401C195 RID: 115093
		private bool WithFollow;

		// Token: 0x0401C196 RID: 115094
		private TimerHandle TimerHandle;

		// Token: 0x0401C197 RID: 115095
		private int SelfCenteredTimeScaleId;

		// Token: 0x0401C198 RID: 115096
		private int SelfBeHitTimeScaleId;

		// Token: 0x0401C199 RID: 115097
		private bool Inited;
	}
}
