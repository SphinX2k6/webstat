using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using AkiClient.Game.Aki.Core;
using CSharpScript.Core.Framework;
using CSharpScript.Game.Common.Event;
using UnrealEngine;
using UnrealEngine.Extension;

namespace CSharpScript.Game.Module.Season
{
	// Token: 0x02004FF3 RID: 20467
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	[TickController(0)]
	public class SeasonController : ControllerBase<SeasonController>
	{
		// Token: 0x06034C30 RID: 216112 RVA: 0x00D3DCF4 File Offset: 0x00D3BEF4
		protected override void OnTick(float delta)
		{
			SeasonModel instance = ModelBase<SeasonModel>.Instance;
			if (!instance.IsMaterialReady)
			{
				return;
			}
			float num = delta * 0.001f;
			this.AdvanceDriver(instance, (double)num);
			this.WriteSeasonScalar(instance);
			this.WriteSeasonAudioState(instance);
		}

		// Token: 0x06034C31 RID: 216113 RVA: 0x00D3DD2F File Offset: 0x00D3BF2F
		protected override bool OnLeaveLevel()
		{
			ModelBase<SeasonModel>.Instance.ResetRuntime();
			return true;
		}

		// Token: 0x06034C32 RID: 216114 RVA: 0x00D3DD3C File Offset: 0x00D3BF3C
		public void ApplyConfig(int volumeId, IClientSetSeasonStateConfig config, [Nullable(2)] TSeasonSwitchCallback onComplete = null)
		{
			SeasonModel instance = ModelBase<SeasonModel>.Instance;
			EClientSetSeasonStateType type = config.Type;
			if (type != EClientSetSeasonStateType.SwitchSeason)
			{
				if (type == EClientSetSeasonStateType.LoopSeasonChange)
				{
					ILoopSeasonChange loopSeasonChange = (ILoopSeasonChange)config;
					if (!loopSeasonChange.EnableLoop)
					{
						this.DeactivateAreaWithEvents(instance, volumeId);
						this.StopLoop(instance);
					}
					else
					{
						this.ActivateAreaWithEvents(instance, volumeId);
						this.StartOrReplaceLoop(instance, loopSeasonChange);
					}
					if (onComplete != null)
					{
						onComplete(true);
						return;
					}
				}
				else if (onComplete != null)
				{
					onComplete(true);
				}
				return;
			}
			this.ActivateAreaWithEvents(instance, volumeId);
			this.PushSwitchJob(instance, (ISwitchSeason)config, onComplete);
		}

		// Token: 0x06034C33 RID: 216115 RVA: 0x00D3DDB9 File Offset: 0x00D3BFB9
		public void RegisterVolume(TsTriggerVolume volume)
		{
			ModelBase<SeasonModel>.Instance.RegisterVolume(volume);
		}

		// Token: 0x06034C34 RID: 216116 RVA: 0x00D3DDC6 File Offset: 0x00D3BFC6
		public void UnregisterVolume(TsTriggerVolume volume)
		{
			ModelBase<SeasonModel>.Instance.UnregisterVolume(volume);
		}

		// Token: 0x06034C35 RID: 216117 RVA: 0x00D3DDD4 File Offset: 0x00D3BFD4
		public void HandleVolumeEnter(TsTriggerVolume volume)
		{
			SeasonModel instance = ModelBase<SeasonModel>.Instance;
			int seasonAreaId = volume.SeasonAreaId;
			instance.MarkPlayerInside(seasonAreaId);
			if (instance.IsAreaActive(seasonAreaId))
			{
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnSeasonAreaEffectBegin, seasonAreaId);
			}
		}

		// Token: 0x06034C36 RID: 216118 RVA: 0x00D3DE10 File Offset: 0x00D3C010
		public void HandleVolumeExit(TsTriggerVolume volume)
		{
			SeasonModel instance = ModelBase<SeasonModel>.Instance;
			int seasonAreaId = volume.SeasonAreaId;
			bool flag = instance.IsPlayerInside(seasonAreaId);
			instance.MarkPlayerOutside(seasonAreaId);
			if (flag && instance.IsAreaActive(seasonAreaId))
			{
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnSeasonAreaEffectEnd, seasonAreaId);
			}
		}

		// Token: 0x06034C37 RID: 216119 RVA: 0x00D3DE54 File Offset: 0x00D3C054
		public ESeason? GetSeasonByAreaId(int areaId)
		{
			SeasonModel instance = ModelBase<SeasonModel>.Instance;
			if (!instance.IsAreaActive(areaId))
			{
				return null;
			}
			return new ESeason?(this.LocateLoopPosition(instance.CurrentValue).Season);
		}

		// Token: 0x06034C38 RID: 216120 RVA: 0x00D3DE90 File Offset: 0x00D3C090
		private void StopLoop(SeasonModel model)
		{
			model.LoopConfig = null;
			model.LoopState = null;
			if (model.DriverPhase == ESeasonDriverPhase.Looping)
			{
				this.SetDriverPhase(model, ESeasonDriverPhase.Idle);
			}
		}

		// Token: 0x06034C39 RID: 216121 RVA: 0x00D3DEB1 File Offset: 0x00D3C0B1
		private void StartOrReplaceLoop(SeasonModel model, ILoopSeasonChange config)
		{
			model.LoopConfig = config;
			if (model.DriverPhase == ESeasonDriverPhase.Switching)
			{
				return;
			}
			this.EnterLoopFromCurrentValue(model);
		}

		// Token: 0x06034C3A RID: 216122 RVA: 0x00D3DECC File Offset: 0x00D3C0CC
		private void EnterLoopFromCurrentValue(SeasonModel model)
		{
			if (model.LoopConfig == null)
			{
				this.SetDriverPhase(model, ESeasonDriverPhase.Idle);
				return;
			}
			ILocatedLoopPosition locatedLoopPosition = this.LocateLoopPosition(model.CurrentValue);
			double phaseElapsed = this.ComputePhaseElapsed(model.CurrentValue, locatedLoopPosition, model);
			model.LoopState = new SeasonLoopState
			{
				CurrentSeason = locatedLoopPosition.Season,
				Phase = locatedLoopPosition.Phase,
				PhaseElapsed = phaseElapsed
			};
			this.SetDriverPhase(model, ESeasonDriverPhase.Looping);
		}

		// Token: 0x06034C3B RID: 216123 RVA: 0x00D3DF38 File Offset: 0x00D3C138
		private void ActivateAreaWithEvents(SeasonModel model, int areaId)
		{
			if (areaId == 0 || model.IsAreaActive(areaId))
			{
				return;
			}
			model.ActivateArea(areaId);
			if (model.IsPlayerInside(areaId))
			{
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnSeasonAreaEffectBegin, areaId);
			}
		}

		// Token: 0x06034C3C RID: 216124 RVA: 0x00D3DF68 File Offset: 0x00D3C168
		private void DeactivateAreaWithEvents(SeasonModel model, int areaId)
		{
			if (areaId == 0 || !model.IsAreaActive(areaId))
			{
				return;
			}
			if (model.IsPlayerInside(areaId))
			{
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnSeasonAreaEffectEnd, areaId);
			}
			model.DeactivateArea(areaId);
		}

		// Token: 0x06034C3D RID: 216125 RVA: 0x00D3DF98 File Offset: 0x00D3C198
		private void PushSwitchJob(SeasonModel model, ISwitchSeason job, [Nullable(2)] TSeasonSwitchCallback onComplete = null)
		{
			double seasonTimelineValue = SeasonDefine.GetSeasonTimelineValue(job.Season);
			double forwardDistance = this.ForwardDistance(model.CurrentValue, seasonTimelineValue);
			model.PushSwitchJob(job, seasonTimelineValue, forwardDistance, onComplete);
			if (model.DriverPhase != ESeasonDriverPhase.Switching)
			{
				this.SetDriverPhase(model, ESeasonDriverPhase.Switching);
			}
		}

		// Token: 0x06034C3E RID: 216126 RVA: 0x00D3DFDC File Offset: 0x00D3C1DC
		private void InvokeJobComplete(ISeasonSwitchJob job, bool success)
		{
			TSeasonSwitchCallback onComplete = job.OnComplete;
			if (onComplete == null)
			{
				return;
			}
			job.OnComplete = null;
			try
			{
				onComplete(success);
			}
			catch (Exception ex)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Season;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "切换回调抛异常";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("error", ex.Message);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
		}

		// Token: 0x06034C3F RID: 216127 RVA: 0x00D3E048 File Offset: 0x00D3C248
		private void SetDriverPhase(SeasonModel model, ESeasonDriverPhase next)
		{
			if (model.DriverPhase == next)
			{
				return;
			}
			model.DriverPhase = next;
		}

		// Token: 0x06034C40 RID: 216128 RVA: 0x00D3E05C File Offset: 0x00D3C25C
		private void AdvanceDriver(SeasonModel model, double delta)
		{
			switch (model.DriverPhase)
			{
			case ESeasonDriverPhase.Idle:
				break;
			case ESeasonDriverPhase.Looping:
				this.AdvanceLooping(model, delta);
				break;
			case ESeasonDriverPhase.Switching:
				this.AdvanceSwitching(model, delta);
				return;
			default:
				return;
			}
		}

		// Token: 0x06034C41 RID: 216129 RVA: 0x00D3E094 File Offset: 0x00D3C294
		private void AdvanceSwitching(SeasonModel model, double delta)
		{
			ISeasonSwitchJob seasonSwitchJob = model.PeekSwitchHead();
			if (seasonSwitchJob == null)
			{
				this.LeaveSwitching(model);
				return;
			}
			double num = seasonSwitchJob.Speed * delta;
			if (num < seasonSwitchJob.RemainDistance)
			{
				model.CurrentValue = this.WrapValue(model.CurrentValue + num);
				seasonSwitchJob.RemainDistance -= num;
				return;
			}
			model.CurrentValue = seasonSwitchJob.TargetValue;
			ISeasonSwitchJob seasonSwitchJob2 = model.PopSwitchHead();
			if (seasonSwitchJob2 != null)
			{
				this.InvokeJobComplete(seasonSwitchJob2, true);
			}
			if (model.PeekSwitchHead() == null)
			{
				this.LeaveSwitching(model);
			}
		}

		// Token: 0x06034C42 RID: 216130 RVA: 0x00D3E115 File Offset: 0x00D3C315
		private void LeaveSwitching(SeasonModel model)
		{
			if (model.LoopConfig != null)
			{
				this.EnterLoopFromCurrentValue(model);
				return;
			}
			this.SetDriverPhase(model, ESeasonDriverPhase.Idle);
		}

		// Token: 0x06034C43 RID: 216131 RVA: 0x00D3E130 File Offset: 0x00D3C330
		private void AdvanceLooping(SeasonModel model, double delta)
		{
			bool loopConfig = model.LoopConfig != null;
			ISeasonLoopState loopState = model.LoopState;
			if (!loopConfig || loopState == null)
			{
				this.SetDriverPhase(model, ESeasonDriverPhase.Idle);
				return;
			}
			double phaseDuration = this.GetPhaseDuration(model, loopState.CurrentSeason, loopState.Phase);
			if (phaseDuration <= 0.0)
			{
				this.CompletePhase(model, loopState);
				return;
			}
			double num = phaseDuration - loopState.PhaseElapsed;
			if (delta < num)
			{
				loopState.PhaseElapsed += delta;
				model.CurrentValue = this.ComputePhaseValue(loopState, phaseDuration);
				return;
			}
			this.CompletePhase(model, loopState);
		}

		// Token: 0x06034C44 RID: 216132 RVA: 0x00D3E1B4 File Offset: 0x00D3C3B4
		private double GetPhaseDuration(SeasonModel model, ESeason season, ESeasonLoopPhase phase)
		{
			ISeasonLoopConfig seasonConfig = this.GetSeasonConfig(model, season);
			return (double)((phase == ESeasonLoopPhase.Hold) ? seasonConfig.HoldTime : seasonConfig.SwitchTime);
		}

		// Token: 0x06034C45 RID: 216133 RVA: 0x00D3E1DC File Offset: 0x00D3C3DC
		private double ComputePhaseValue(ISeasonLoopState state, double duration)
		{
			if (state.Phase == ESeasonLoopPhase.Hold)
			{
				return SeasonDefine.GetSeasonTimelineValue(state.CurrentSeason);
			}
			return this.LerpForward(state.CurrentSeason, SeasonDefine.GetNextSeasonInLoop(state.CurrentSeason), state.PhaseElapsed / duration);
		}

		// Token: 0x06034C46 RID: 216134 RVA: 0x00D3E214 File Offset: 0x00D3C414
		private void CompletePhase(SeasonModel model, ISeasonLoopState state)
		{
			if (state.Phase == ESeasonLoopPhase.Hold)
			{
				state.Phase = ESeasonLoopPhase.Transition;
			}
			else
			{
				state.CurrentSeason = SeasonDefine.GetNextSeasonInLoop(state.CurrentSeason);
				state.Phase = ESeasonLoopPhase.Hold;
			}
			state.PhaseElapsed = 0.0;
			model.CurrentValue = SeasonDefine.GetSeasonTimelineValue(state.CurrentSeason);
		}

		// Token: 0x06034C47 RID: 216135 RVA: 0x00D3E26C File Offset: 0x00D3C46C
		private ILocatedLoopPosition LocateLoopPosition(double value)
		{
			double num = this.WrapValue(value);
			int num2 = (int)Math.Floor(num * 4.0 + 0.0004) % 4;
			double num3 = (double)num2 / 4.0;
			double num4 = Math.Abs(num - num3);
			ESeasonLoopPhase phase = (num4 < 0.0001 || num4 > 0.9999) ? ESeasonLoopPhase.Hold : ESeasonLoopPhase.Transition;
			return new LocatedLoopPosition
			{
				Season = SeasonController.SeasonByQuarter[num2],
				Phase = phase
			};
		}

		// Token: 0x06034C48 RID: 216136 RVA: 0x00D3E2EC File Offset: 0x00D3C4EC
		private double ComputePhaseElapsed(double value, ILocatedLoopPosition located, SeasonModel model)
		{
			if (located.Phase == ESeasonLoopPhase.Hold)
			{
				return 0.0;
			}
			float switchTime = this.GetSeasonConfig(model, located.Season).SwitchTime;
			if (switchTime <= 0f)
			{
				return 0.0;
			}
			double seasonTimelineValue = SeasonDefine.GetSeasonTimelineValue(located.Season);
			double num = SeasonDefine.GetSeasonTimelineValue(SeasonDefine.GetNextSeasonInLoop(located.Season));
			if (num <= seasonTimelineValue)
			{
				num += 1.0;
			}
			return (((value < seasonTimelineValue) ? (value + 1.0) : value) - seasonTimelineValue) / (num - seasonTimelineValue) * (double)switchTime;
		}

		// Token: 0x06034C49 RID: 216137 RVA: 0x00D3E378 File Offset: 0x00D3C578
		private double LerpForward(ESeason from, ESeason to, double t)
		{
			double seasonTimelineValue = SeasonDefine.GetSeasonTimelineValue(from);
			double num = SeasonDefine.GetSeasonTimelineValue(to);
			if (num <= seasonTimelineValue)
			{
				num += 1.0;
			}
			return this.WrapValue(seasonTimelineValue + (num - seasonTimelineValue) * t);
		}

		// Token: 0x06034C4A RID: 216138 RVA: 0x00D3E3B0 File Offset: 0x00D3C5B0
		private double ForwardDistance(double from, double to)
		{
			double num = (to - from) % 1.0;
			if (num >= 0.0)
			{
				return num;
			}
			return num + 1.0;
		}

		// Token: 0x06034C4B RID: 216139 RVA: 0x00D3E3E4 File Offset: 0x00D3C5E4
		private double WrapValue(double v)
		{
			return v % 1.0;
		}

		// Token: 0x06034C4C RID: 216140 RVA: 0x00D3E3F1 File Offset: 0x00D3C5F1
		private ISeasonLoopConfig GetSeasonConfig(SeasonModel model, ESeason season)
		{
			return model.LoopConfigByIndex[(int)season];
		}

		// Token: 0x06034C4D RID: 216141 RVA: 0x00D3E400 File Offset: 0x00D3C600
		private void WriteSeasonScalar(SeasonModel model)
		{
			if (object.Equals(model.LastWrittenValue, model.CurrentValue))
			{
				if (SeasonController._writeBurstActive)
				{
					SeasonController._writeBurstActive = false;
				}
				return;
			}
			UMaterialParameterCollection materialAsset = model.MaterialAsset;
			FName? timelineParamName = model.TimelineParamName;
			BP_MainGameInstance_C gameInstance = GlobalData.GameInstance;
			UWorld uworld = (gameInstance != null) ? gameInstance.GetWorld() : null;
			if (materialAsset == null || timelineParamName == null || uworld == null)
			{
				return;
			}
			try
			{
				UKismetMaterialLibrary.SetScalarParameterValue(uworld, materialAsset, timelineParamName.Value, (float)model.CurrentValue);
				Singleton<AudioSystem>.Instance.SetRtpcValue("season_mpc_value", (float)model.CurrentValue, null);
				if (!SeasonController._writeBurstActive)
				{
					SeasonController._writeBurstActive = true;
				}
				model.LastWrittenValue = new double?(model.CurrentValue);
			}
			catch (Exception ex)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Season;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "写 MPC 失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("error", ex.Message);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
		}

		// Token: 0x06034C4E RID: 216142 RVA: 0x00D3E504 File Offset: 0x00D3C704
		private void WriteSeasonAudioState(SeasonModel model)
		{
			ESeason season = this.LocateLoopPosition(model.CurrentValue).Season;
			ESeason? lastReportedSeason = model.LastReportedSeason;
			ESeason eseason = season;
			if (lastReportedSeason.GetValueOrDefault() == eseason & lastReportedSeason != null)
			{
				return;
			}
			model.LastReportedSeason = new ESeason?(season);
			Singleton<AudioSystem>.Instance.SetState("game_scene_season", SeasonDefine.GetSeasonAudioName(season), true);
		}

		// Token: 0x06034C50 RID: 216144 RVA: 0x00D3E56B File Offset: 0x00D3C76B
		// Note: this type is marked as 'beforefieldinit'.
		static SeasonController()
		{
			ESeason[] array = new ESeason[4];
			RuntimeHelpers.InitializeArray(array, fieldof(<PrivateImplementationDetails>.6256A4B0BE4127B6FF9FA076FE7595961BC296521BD01220F64C6F95768C1FDD).FieldHandle);
			SeasonController.SeasonByQuarter = array;
		}

		// Token: 0x0401E65D RID: 124509
		[StaticVariableRuleIgnore]
		private static readonly ESeason[] SeasonByQuarter;

		// Token: 0x0401E65E RID: 124510
		private const int QUARTER_COUNT = 4;

		// Token: 0x0401E65F RID: 124511
		private const double HOLD_EPSILON = 0.0001;

		// Token: 0x0401E660 RID: 124512
		[StaticVariableRuleIgnore]
		private static bool _writeBurstActive;
	}
}
