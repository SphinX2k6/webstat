using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Qte;
using AkiClient.Game.Aki.Data.QuickTimeAction;
using AkiClient.Game.Aki.Data.QuickTimeAction.Customization;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Input;
using CSharpScript.Game.Input.BattleInputData;
using UnrealEngine;

namespace CSharpScript.Game.Module.QuickTimeAction.Context
{
	// Token: 0x020052B9 RID: 21177
	[NullableContext(1)]
	[Nullable(0)]
	public class QtaCustomizationLimitedHoldLogic : QtaCustomizationBaseLogic
	{
		// Token: 0x06036223 RID: 221731 RVA: 0x00DA2264 File Offset: 0x00DA0464
		public override void OnSetConfig(QtaCustomizationContext qtaContext, SQta qtaConfig, BP_QtaCustomizationBase_C daConfig)
		{
			if (qtaConfig == null || daConfig == null)
			{
				QtaLog.Error(qtaContext, "限次长按Qta初始化：缺少配置", default(ReadOnlySpan<ValueTuple<string, object>>));
				ControllerBase<QtaController>.Instance.StopCurrentQta();
				return;
			}
			BP_QtaCustomization_LimitedHold_C bp_QtaCustomization_LimitedHold_C = daConfig as BP_QtaCustomization_LimitedHold_C;
			if (bp_QtaCustomization_LimitedHold_C == null)
			{
				QtaLog.Error(qtaContext, "限次长按Qta初始化：配置的DA类型不正确", default(ReadOnlySpan<ValueTuple<string, object>>));
				ControllerBase<QtaController>.Instance.StopCurrentQta();
				return;
			}
			SQtaCustomization_LimitedHold config = bp_QtaCustomization_LimitedHold_C.Config;
			if (config.ProgressList.Num() < 1)
			{
				QtaLog.Error(qtaContext, "限次长按Qta初始化：缺少副(背景)进度条配置", default(ReadOnlySpan<ValueTuple<string, object>>));
				ControllerBase<QtaController>.Instance.StopCurrentQta();
				return;
			}
			this.QtaConfig = qtaConfig;
			this.SubConfig = config;
			this.QtaContext = qtaContext;
			this.MainProgress.InitByConfig(config.MainProgress, config.MainProgressResetType);
			for (int i = 0; i < config.ProgressList.Num(); i++)
			{
				QtaCzBgBar qtaCzBgBar = new QtaCzBgBar();
				qtaCzBgBar.InitByConfig(config.ProgressList.Get(i));
				this.BgBarList.Add(qtaCzBgBar);
			}
			this.TimesLimit = config.TimesLimit;
			this.TimeoutOnPressCheck = config.TimeoutOnPress * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
			this.TimeoutOnIdleCheck = config.TimeoutOnIdle * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
			this.Actions.Clear();
			for (int j = 0; j < qtaConfig.BaseConfig.InputConfig.Num(); j++)
			{
				SCommonQteButton scommonQteButton = qtaConfig.BaseConfig.InputConfig.Get(j);
				TEnumAsByte<ECommonQteInputAction>? tenumAsByte = (scommonQteButton != null) ? new TEnumAsByte<ECommonQteInputAction>?(scommonQteButton.Action) : null;
				int index = (int)((tenumAsByte != null) ? tenumAsByte.GetValueOrDefault() : 0);
				if (QtaActionNames.Has(index))
				{
					this.Actions.Add(QtaActionNames.Get(index));
				}
			}
			foreach (string actionName in this.Actions)
			{
				InputModel instance = ModelBase<InputModel>.Instance;
				BattleInputData battleInputData = (instance != null) ? instance.GetCurrentInputData() : null;
				if (battleInputData != null)
				{
					EInputAction? action = battleInputData.GetAction(actionName);
					if (action != null && ControllerBase<InputController>.Instance.IsKeyDown(action.Value))
					{
						this.IsPressing = true;
						break;
					}
				}
			}
		}

		// Token: 0x06036224 RID: 221732 RVA: 0x00DA24B8 File Offset: 0x00DA06B8
		public override void OnQtaStart()
		{
			if (this.SubConfig == null || this.QtaContext == null)
			{
				return;
			}
			QtaCustomizationLimitedHoldLogic qtaCustomizationLimitedHoldLogic = (QtaCustomizationLimitedHoldLogic)this.QtaContext.QtaCustomizationLogic;
			this.BgAnchor.InitParam(qtaCustomizationLimitedHoldLogic.GetBgValue(0), 1f);
			this.AddEvents();
		}

		// Token: 0x06036225 RID: 221733 RVA: 0x00DA250C File Offset: 0x00DA070C
		private void AddEvents()
		{
			SQtaCustomization_LimitedHold subConfig = this.SubConfig;
			int num = (subConfig != null) ? subConfig.SpeedTriggerList.Num() : 0;
			if (num > 0)
			{
				this.EventParamMap.Clear();
				for (int i = 0; i < num; i++)
				{
					SQtaCustomizationParam_Event sqtaCustomizationParam_Event = this.SubConfig.SpeedTriggerList.Get(i);
					if (sqtaCustomizationParam_Event.EventTag.TagId() == 0)
					{
						QtaLog.Error(this.QtaContext, "限次长按Qta初始化：事件触发配置缺少tag", default(ReadOnlySpan<ValueTuple<string, object>>));
					}
					else
					{
						this.EventParamMap[sqtaCustomizationParam_Event.EventTag.TagId()] = new List<float>
						{
							sqtaCustomizationParam_Event.Param1,
							sqtaCustomizationParam_Event.Param2
						};
					}
				}
				if (this.EventParamMap.Count > 0 && !Singleton<EventSystem>.Instance.Has(EEventName.CheckClientEvent, new Action<FGameplayTag>(this.OnCheckClientEvent)))
				{
					Singleton<EventSystem>.Instance.Add(EEventName.CheckClientEvent, new Action<FGameplayTag>(this.OnCheckClientEvent));
				}
			}
		}

		// Token: 0x06036226 RID: 221734 RVA: 0x00DA2603 File Offset: 0x00DA0803
		private void RemoveEvents()
		{
			if (Singleton<EventSystem>.Instance.Has(EEventName.CheckClientEvent, new Action<FGameplayTag>(this.OnCheckClientEvent)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.CheckClientEvent, new Action<FGameplayTag>(this.OnCheckClientEvent));
			}
		}

		// Token: 0x06036227 RID: 221735 RVA: 0x00DA2640 File Offset: 0x00DA0840
		private void OnCheckClientEvent(FGameplayTag tag)
		{
			List<float> list;
			if (this.EventParamMap.TryGetValue(tag.TagId(), out list))
			{
				this.SetSpeed(list[0], list[1]);
			}
		}

		// Token: 0x06036228 RID: 221736 RVA: 0x00DA2676 File Offset: 0x00DA0876
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override List<string> OnGetActions()
		{
			return this.Actions;
		}

		// Token: 0x06036229 RID: 221737 RVA: 0x00DA2680 File Offset: 0x00DA0880
		private void SetSpeed(float frontSpeed, float bgSpeed)
		{
			this.MainProgress.SetSpeed(frontSpeed);
			foreach (QtaCzBgBar qtaCzBgBar in this.BgBarList)
			{
				qtaCzBgBar.CzProgress.SetSpeed(bgSpeed);
			}
		}

		// Token: 0x0603622A RID: 221738 RVA: 0x00DA26E4 File Offset: 0x00DA08E4
		public override void OnQtaResponse(bool press = true)
		{
			if (press)
			{
				this.OnResponseStart();
				return;
			}
			this.OnResponseEnd();
		}

		// Token: 0x0603622B RID: 221739 RVA: 0x00DA26F8 File Offset: 0x00DA08F8
		private void OnResponseStart()
		{
			if (this.SubConfig == null || this.QtaConfig == null)
			{
				return;
			}
			if (this.QtaContext == null)
			{
				return;
			}
			if (!this.QtaContext.IsPending() && !this.QtaContext.IsPendingSuccess())
			{
				return;
			}
			if (this.QtaContext.IsPending())
			{
				this.IsPressing = true;
				ControllerBase<QtaController>.Instance.PlayEffect(EQtaPromptType.按下提示, this.QtaContext.HandleId);
			}
			this.CheckCanEnd();
		}

		// Token: 0x0603622C RID: 221740 RVA: 0x00DA2777 File Offset: 0x00DA0977
		private void OnResponseEnd()
		{
			this.IsPressing = false;
			this.TimesRelease++;
			if (this.QtaContext != null)
			{
				ControllerBase<QtaController>.Instance.PlayEffect(EQtaPromptType.抬起提示, this.QtaContext.HandleId);
				this.CheckCanEnd();
			}
		}

		// Token: 0x0603622D RID: 221741 RVA: 0x00DA27B4 File Offset: 0x00DA09B4
		public override void OnUpdateTime(float delta)
		{
			if (this.SubConfig == null)
			{
				QtaLog.Error(this.QtaContext, "Context中获取不到Config", default(ReadOnlySpan<ValueTuple<string, object>>));
				ControllerBase<QtaController>.Instance.StopCurrentQta();
				return;
			}
			if (this.QtaContext == null)
			{
				return;
			}
			this.PassTime += delta;
			this.PassTimeWithDilation += delta * Singleton<Time>.Instance.TimeDilation * Singleton<Time>.Instance.FlowTimeDilation;
			this.MainProgress.Update(delta, this.IsPressing);
			foreach (QtaCzBgBar qtaCzBgBar in this.BgBarList)
			{
				qtaCzBgBar.CzProgress.Update(delta, false);
			}
			if (this.CheckCanEnd())
			{
				return;
			}
			this.CheckEnterValidRange();
			if (!this.QtaContext.IsPermanent && this.PassTime > this.QtaContext.Duration)
			{
				this.QtaContext.SetQtaResult(EQtaResult.Timeout);
			}
		}

		// Token: 0x0603622E RID: 221742 RVA: 0x00DA28C8 File Offset: 0x00DA0AC8
		public override float GetProgress()
		{
			return this.MainProgress.Progress;
		}

		// Token: 0x0603622F RID: 221743 RVA: 0x00DA28D5 File Offset: 0x00DA0AD5
		public override float GetBgProgress(int index = 0)
		{
			if (index >= 0 && index < this.BgBarList.Count)
			{
				return this.BgBarList[index].CzProgress.Progress;
			}
			return 0f;
		}

		// Token: 0x06036230 RID: 221744 RVA: 0x00DA2908 File Offset: 0x00DA0B08
		public QtaCzBgBarValue GetBgValue(int index = 0)
		{
			QtaCzBgBarValue qtaCzBgBarValue = new QtaCzBgBarValue();
			if (index >= 0 && index < this.BgBarList.Count)
			{
				qtaCzBgBarValue.Anchor = this.BgBarList[index].Anchor;
				qtaCzBgBarValue.Angle = this.BgBarList[index].Angle;
				qtaCzBgBarValue.Progress = this.BgBarList[index].CzProgress.Progress;
			}
			return qtaCzBgBarValue;
		}

		// Token: 0x06036231 RID: 221745 RVA: 0x00DA2978 File Offset: 0x00DA0B78
		private void CheckEnterValidRange()
		{
			bool flag = this.CheckIsValid();
			if (this.IsValidState == flag)
			{
				return;
			}
			if (flag)
			{
				if (!this.IsEnterFxPlayed)
				{
					this.IsEnterFxPlayed = true;
					ControllerBase<QtaController>.Instance.PlayEffect(EQtaPromptType.进入有效范围提示, this.QtaContext.HandleId);
					ControllerBase<QtaController>.Instance.OnQtaMoment(this.QtaContext.HandleId, EQtaMomentName.EnterValidRange);
				}
			}
			else if (this.IsEnterFxPlayed)
			{
				this.IsEnterFxPlayed = false;
				ControllerBase<QtaController>.Instance.PlayEffect(EQtaPromptType.离开有效范围提示, this.QtaContext.HandleId);
				ControllerBase<QtaController>.Instance.OnQtaMoment(this.QtaContext.HandleId, EQtaMomentName.ExitValidRange);
			}
			this.IsValidState = flag;
		}

		// Token: 0x06036232 RID: 221746 RVA: 0x00DA2A18 File Offset: 0x00DA0C18
		public bool IsWithinRange()
		{
			return this.CheckIsValid();
		}

		// Token: 0x06036233 RID: 221747 RVA: 0x00DA2A20 File Offset: 0x00DA0C20
		protected override bool CheckIsValid()
		{
			float mainPct = 1f - this.GetProgress();
			float bgProgress = this.GetBgProgress(0);
			return this.BgAnchor.CheckIsValid(mainPct, bgProgress);
		}

		// Token: 0x06036234 RID: 221748 RVA: 0x00DA2A4F File Offset: 0x00DA0C4F
		private bool CheckCanEnd()
		{
			if (this.QtaContext.State != EQtaState.Pending)
			{
				return true;
			}
			if (this.CheckCanEndInner())
			{
				this.QtaContext.SetQtaResult(this.CheckIsValid() ? EQtaResult.Success : EQtaResult.Fail);
				return true;
			}
			return false;
		}

		// Token: 0x06036235 RID: 221749 RVA: 0x00DA2A84 File Offset: 0x00DA0C84
		private bool CheckCanEndInner()
		{
			return this.TimesRelease >= this.TimesLimit || (this.IsPressing && this.TimeoutOnPressCheck > 0f && this.PassTimeWithDilation > this.TimeoutOnPressCheck) || (!this.IsPressing && this.TimeoutOnIdleCheck > 0f && this.PassTimeWithDilation > this.TimeoutOnIdleCheck) || this.MainProgress.IsFinish;
		}

		// Token: 0x06036236 RID: 221750 RVA: 0x00DA2AF4 File Offset: 0x00DA0CF4
		public override void OnQtaEnd(bool success = false)
		{
			this.RemoveEvents();
			QtaLog.Info(this.QtaContext, "OnQtaEnd:定制型-限次长按型", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x0401F197 RID: 127383
		[Nullable(2)]
		private SQtaCustomization_LimitedHold SubConfig;

		// Token: 0x0401F198 RID: 127384
		private readonly QtaCzProgress MainProgress = new QtaCzProgress();

		// Token: 0x0401F199 RID: 127385
		private readonly List<QtaCzBgBar> BgBarList = new List<QtaCzBgBar>();

		// Token: 0x0401F19A RID: 127386
		private int TimesRelease;

		// Token: 0x0401F19B RID: 127387
		private int TimesLimit;

		// Token: 0x0401F19C RID: 127388
		private float TimeoutOnPressCheck;

		// Token: 0x0401F19D RID: 127389
		private float TimeoutOnIdleCheck;

		// Token: 0x0401F19E RID: 127390
		private float PassTimeWithDilation;

		// Token: 0x0401F19F RID: 127391
		private readonly QtaCzBgAnchor BgAnchor = new QtaCzBgAnchor();

		// Token: 0x0401F1A0 RID: 127392
		private readonly List<string> Actions = new List<string>();

		// Token: 0x0401F1A1 RID: 127393
		private bool IsPressing;

		// Token: 0x0401F1A2 RID: 127394
		private readonly Dictionary<int, List<float>> EventParamMap = new Dictionary<int, List<float>>();

		// Token: 0x0401F1A3 RID: 127395
		private bool IsEnterFxPlayed;

		// Token: 0x0401F1A4 RID: 127396
		private bool IsValidState;
	}
}
