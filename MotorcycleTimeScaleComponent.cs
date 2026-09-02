using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.Pawn.Component;
using UnrealEngine;

// Token: 0x0200329F RID: 12959
[NullableContext(1)]
[Nullable(0)]
public class MotorcycleTimeScaleComponent : PawnTimeScaleComponent
{
	// Token: 0x0601B2A5 RID: 111269 RVA: 0x0082AA92 File Offset: 0x00828C92
	protected override bool OnStart()
	{
		if (!base.OnStart())
		{
			return false;
		}
		this.IsInSpecialMap = ControllerBase<EffectAudioController>.Instance.CheckInSpecialInstanceDungeon();
		this.VehiclePerformComp = base.Entity.GetComponent<VehiclePerformComponent>();
		return true;
	}

	// Token: 0x0601B2A6 RID: 111270 RVA: 0x0082AAC0 File Offset: 0x00828CC0
	protected override bool OnEnd()
	{
		return true;
	}

	// Token: 0x0601B2A7 RID: 111271 RVA: 0x0082AAC4 File Offset: 0x00828CC4
	protected override bool IsTimescaleValid(TimeScale timescale, float currentTime)
	{
		if (ModelBase<GameModeModel>.Instance != null && ModelBase<GameModeModel>.Instance.IsMulti)
		{
			ETimeScaleSourceType sourceType = timescale.SourceType;
			if (sourceType - ETimeScaleSourceType.Counter > 4)
			{
				return false;
			}
		}
		return base.IsTimescaleValid(timescale, currentTime);
	}

	// Token: 0x0601B2A8 RID: 111272 RVA: 0x0082AAFC File Offset: 0x00828CFC
	protected override void OnTick(float delta)
	{
		float num = 1f;
		float num2 = 1f;
		float num3 = 1f;
		VehiclePerformComponent vehiclePerformComp = this.VehiclePerformComp;
		CharacterTimeScaleComponent characterTimeScaleComponent;
		if (vehiclePerformComp == null)
		{
			characterTimeScaleComponent = null;
		}
		else
		{
			Entity driver = vehiclePerformComp.Driver;
			characterTimeScaleComponent = ((driver != null) ? driver.GetComponent<CharacterTimeScaleComponent>() : null);
		}
		CharacterTimeScaleComponent characterTimeScaleComponent2 = characterTimeScaleComponent;
		if (characterTimeScaleComponent2 != null)
		{
			this.FreezeTimeScaleInternal = characterTimeScaleComponent2.FreezeTimeScale;
			num = characterTimeScaleComponent2.CurrentTimeScale;
			num2 = characterTimeScaleComponent2.LastAkCompTimeScale;
		}
		else
		{
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
					ETimeScaleSourceType sourceType = top.SourceType;
					num2 = ((top.EndTime - top.StartTime >= 0.800000011920929) ? num : this.LastAkCompTimeScale);
					break;
				}
				this.TimeScaleMap.Remove(top.Id);
				this.TimeScaleList.Pop();
			}
			float topForeverTimeScale = base.GetTopForeverTimeScale(null);
			this.FreezeTimeScaleInternal = num;
			num *= topForeverTimeScale;
			num3 = num2 * base.Entity.TimeDilation * ModelBase<CharacterModel>.Instance.SelfCenteredTimeDilation * topForeverTimeScale;
		}
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
			base.Entity.SetTimeDilation(base.TimeDilation);
		}
	}

	// Token: 0x0601B2A9 RID: 111273 RVA: 0x0082AD04 File Offset: 0x00828F04
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		MotorcycleTimeScaleComponent motorcycleTimeScaleComponent = (MotorcycleTimeScaleComponent)componentTemplate;
		if (base.CanResetComponentProperty("LastAkTimeScale"))
		{
			this.LastAkTimeScale = motorcycleTimeScaleComponent.LastAkTimeScale;
		}
		if (base.CanResetComponentProperty("LastAkCompTimeScale"))
		{
			this.LastAkCompTimeScale = motorcycleTimeScaleComponent.LastAkCompTimeScale;
		}
		if (base.CanResetComponentProperty("VehiclePerformComp"))
		{
			if (motorcycleTimeScaleComponent.VehiclePerformComp == null)
			{
				this.VehiclePerformComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<VehiclePerformComponent>(this.VehiclePerformComp), "VehiclePerformComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("IsInSpecialMap"))
		{
			this.IsInSpecialMap = motorcycleTimeScaleComponent.IsInSpecialMap;
		}
		return true;
	}

	// Token: 0x0400DD4A RID: 56650
	private float LastAkTimeScale = 1f;

	// Token: 0x0400DD4B RID: 56651
	private float LastAkCompTimeScale = 1f;

	// Token: 0x0400DD4C RID: 56652
	[Nullable(2)]
	protected VehiclePerformComponent VehiclePerformComp;

	// Token: 0x0400DD4D RID: 56653
	private bool IsInSpecialMap;
}
