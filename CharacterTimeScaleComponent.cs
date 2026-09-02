using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.NewWorld.Pawn.Component;
using UnrealEngine;

// Token: 0x02003074 RID: 12404
[NullableContext(1)]
[Nullable(0)]
public class CharacterTimeScaleComponent : PawnTimeScaleComponent
{
	// Token: 0x06019809 RID: 104457 RVA: 0x00763030 File Offset: 0x00761230
	protected override bool OnStart()
	{
		if (!base.OnStart())
		{
			return false;
		}
		this.IsInSpecialMap = ControllerBase<EffectAudioController>.Instance.CheckInSpecialInstanceDungeon();
		return true;
	}

	// Token: 0x0601980A RID: 104458 RVA: 0x00763050 File Offset: 0x00761250
	protected override bool IsTimescaleValid(TimeScale timescale, float currentTime)
	{
		GameModeModel instance = ModelBase<GameModeModel>.Instance;
		if (instance != null && instance.IsMulti)
		{
			ETimeScaleSourceType sourceType = timescale.SourceType;
			if (sourceType - ETimeScaleSourceType.Counter > 4)
			{
				return false;
			}
		}
		return base.IsTimescaleValid(timescale, currentTime);
	}

	// Token: 0x0601980B RID: 104459 RVA: 0x00763088 File Offset: 0x00761288
	protected override void OnTick(float delta)
	{
		float num = 1f;
		ETimeScaleSourceType p = ETimeScaleSourceType.DefaultTimeScale;
		float num2 = 1f;
		while (!this.TimeScaleList.Empty)
		{
			TimeScale top = this.TimeScaleList.Top;
			if (top == null)
			{
				break;
			}
			if (this.IsTimescaleValid(top, delta))
			{
				num = top.CalculateTimeScale();
				p = top.SourceType;
				num2 = ((top.EndTime - top.StartTime >= 0.800000011920929) ? num : this.LastAkCompTimeScale);
				break;
			}
			this.TimeScaleMap.Remove(top.Id);
			this.TimeScaleList.Pop();
		}
		BaseDeathComponent component = base.Entity.GetComponent<BaseDeathComponent>();
		if (this.ActorComp != null && !this.ActorComp.IsMoveAutonomousProxy && (component == null || !component.IsDead()))
		{
			num = this.MoveSyncTimeScale;
			num2 = this.MoveSyncTimeScale;
		}
		this.FreezeTimeScaleInternal = num;
		float topForeverTimeScale = base.GetTopForeverTimeScale(null);
		num *= topForeverTimeScale;
		float num3 = num2 * base.Entity.TimeDilation * ModelBase<CharacterModel>.Instance.SelfCenteredTimeDilation * topForeverTimeScale;
		if (num3 != this.LastAkTimeScale)
		{
			BaseActorComponent actorComp = this.ActorComp;
			AActor aactor = (actorComp != null) ? actorComp.Owner : null;
			if (aactor != null)
			{
				if (!this.IsInSpecialMap)
				{
					Singleton<AudioSystem>.Instance.SetRtpcValue("entity_time_scale_combat", num3, new SetRtpcValueArgs?(new SetRtpcValueArgs
					{
						Actor = aactor
					}));
				}
				if (num3 < 0.0625f && this.LastAkTimeScale >= 0.0625f)
				{
					Singleton<AudioSystem>.Instance.PostEvent("time_scale_pause", aactor, null);
				}
				else if (num3 >= 0.0625f && this.LastAkTimeScale < 0.0625f)
				{
					Singleton<AudioSystem>.Instance.PostEvent("time_scale_resume", aactor, null);
				}
			}
		}
		this.LastAkTimeScale = num3;
		this.LastAkCompTimeScale = num2;
		if (num != this.TimeScaleInternal)
		{
			this.TimeScaleInternal = num;
			Singleton<EventSystem>.Instance.EmitWithTarget<float, ETimeScaleSourceType>(base.Entity, EEventName.CharBeHitTimeScale, num, p);
			base.Entity.SetTimeDilation(base.TimeDilation);
		}
	}

	// Token: 0x0601980C RID: 104460 RVA: 0x0076329C File Offset: 0x0076149C
	public void SetMoveSyncTimeScale(float scale)
	{
		this.MoveSyncTimeScale = scale;
	}

	// Token: 0x0601980D RID: 104461 RVA: 0x007632A8 File Offset: 0x007614A8
	[NullableContext(2)]
	public override int SetTimeScale(int priority, float timeDilation, UCurveFloat curve, float duration, ETimeScaleSourceType sourceType, bool needAddSceneItemTag = false, bool immuneSelfCenter = false)
	{
		CharacterBuffComponent component = base.Entity.GetComponent<CharacterBuffComponent>();
		SyncTimeScaleEffect syncTimeScaleEffect;
		if (component == null)
		{
			syncTimeScaleEffect = null;
		}
		else
		{
			ExtraEffectManager buffEffectManager = component.BuffEffectManager;
			syncTimeScaleEffect = ((buffEffectManager != null) ? buffEffectManager.FilterFirstById<SyncTimeScaleEffect>(EExtraEffectId.SyncTimeScaleEffect, null) : null);
		}
		SyncTimeScaleEffect syncTimeScaleEffect2 = syncTimeScaleEffect;
		if (syncTimeScaleEffect2 != null)
		{
			return syncTimeScaleEffect2.SetTimeScale(priority, timeDilation, curve, duration, sourceType, needAddSceneItemTag, immuneSelfCenter);
		}
		return base.SetTimeScale(priority, timeDilation, curve, duration, sourceType, needAddSceneItemTag, immuneSelfCenter);
	}

	// Token: 0x0601980E RID: 104462 RVA: 0x00763304 File Offset: 0x00761504
	public override void RemoveTimeScale(int id)
	{
		CharacterBuffComponent component = base.Entity.GetComponent<CharacterBuffComponent>();
		SyncTimeScaleEffect syncTimeScaleEffect;
		if (component == null)
		{
			syncTimeScaleEffect = null;
		}
		else
		{
			ExtraEffectManager buffEffectManager = component.BuffEffectManager;
			syncTimeScaleEffect = ((buffEffectManager != null) ? buffEffectManager.FilterFirstById<SyncTimeScaleEffect>(EExtraEffectId.SyncTimeScaleEffect, null) : null);
		}
		SyncTimeScaleEffect syncTimeScaleEffect2 = syncTimeScaleEffect;
		if (syncTimeScaleEffect2 != null)
		{
			syncTimeScaleEffect2.RemoveTimeScale(id, true);
			return;
		}
		base.RemoveTimeScale(id);
	}

	// Token: 0x0601980F RID: 104463 RVA: 0x0076334C File Offset: 0x0076154C
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		CharacterTimeScaleComponent characterTimeScaleComponent = (CharacterTimeScaleComponent)componentTemplate;
		if (base.CanResetComponentProperty("LastAkTimeScale"))
		{
			this.LastAkTimeScale = characterTimeScaleComponent.LastAkTimeScale;
		}
		if (base.CanResetComponentProperty("LastAkCompTimeScale"))
		{
			this.LastAkCompTimeScale = characterTimeScaleComponent.LastAkCompTimeScale;
		}
		if (base.CanResetComponentProperty("MoveSyncTimeScale"))
		{
			this.MoveSyncTimeScale = characterTimeScaleComponent.MoveSyncTimeScale;
		}
		if (base.CanResetComponentProperty("TimeStopEntitySet"))
		{
			if (characterTimeScaleComponent.TimeStopEntitySet == null)
			{
				this.TimeStopEntitySet = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<EntityHandle>(this.TimeStopEntitySet), "TimeStopEntitySet"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("IsInSpecialMap"))
		{
			this.IsInSpecialMap = characterTimeScaleComponent.IsInSpecialMap;
		}
		return true;
	}

	// Token: 0x0400CA61 RID: 51809
	private const float AUDIO_SCALE_ENABLE_THRESHOLD = 0.8f;

	// Token: 0x0400CA62 RID: 51810
	private const float AUDIO_SCALE_PAUSE_THRESHOLD = 0.0625f;

	// Token: 0x0400CA63 RID: 51811
	public float LastAkTimeScale = 1f;

	// Token: 0x0400CA64 RID: 51812
	public float LastAkCompTimeScale = 1f;

	// Token: 0x0400CA65 RID: 51813
	private float MoveSyncTimeScale = 1f;

	// Token: 0x0400CA66 RID: 51814
	public HashSet<EntityHandle> TimeStopEntitySet = new HashSet<EntityHandle>();

	// Token: 0x0400CA67 RID: 51815
	private bool IsInSpecialMap;
}
