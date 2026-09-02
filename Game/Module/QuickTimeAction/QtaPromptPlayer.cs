using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.QuickTimeAction;
using AkiClient.Game.Aki.Render.RuntimeBP.ScreenEffect.Data;
using CSharpScript.Core.Common;
using CSharpScript.Game.Effect;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.Gamepad;
using CSharpScript.Game.Module.QuickTimeAction.Context;
using CSharpScript.Game.Render.Effect.ScreenEffectSystem;
using UnrealEngine;

namespace CSharpScript.Game.Module.QuickTimeAction
{
	// Token: 0x020052B7 RID: 21175
	[NullableContext(2)]
	[Nullable(0)]
	public class QtaPromptPlayer
	{
		// Token: 0x06036200 RID: 221696 RVA: 0x00DA1889 File Offset: 0x00D9FA89
		[NullableContext(1)]
		public void SetQtaContext(QtaContextBase context)
		{
			this.Context = context;
			IQtaExtraParams extraParams = context.ExtraParams;
			if (((extraParams != null) ? extraParams.EntityHandle : null) != null)
			{
				WorldEntity entity = context.ExtraParams.EntityHandle.Entity;
				this.EntityCueComp = ((entity != null) ? entity.GetComponent<BaseGameplayCueComponent>() : null);
			}
		}

		// Token: 0x06036201 RID: 221697 RVA: 0x00DA18C8 File Offset: 0x00D9FAC8
		[NullableContext(1)]
		public void StartUiEffect(SQtaBase config)
		{
			if (Singleton<Info>.Instance.OperationType == EOperationType.Pad)
			{
				if (config.HideAllBattleUiInMobile)
				{
					this.IsHideAllBattleUi = true;
					ModelBase<BattleUiModel>.Instance.ChildViewData.HideBattleView(EBattleUiVisibleReason.PanelQta, new List<EBattleUiChild>
					{
						EBattleUiChild.PanelQta
					}, 0);
					return;
				}
			}
			else if (config.HideAllBattleUi)
			{
				this.IsHideAllBattleUi = true;
				ModelBase<BattleUiModel>.Instance.ChildViewData.HideBattleView(EBattleUiVisibleReason.PanelQta, new List<EBattleUiChild>
				{
					EBattleUiChild.PanelQta
				}, 0);
				return;
			}
			this.IsHideAllBattleUi = false;
			int num = config.HideUiElement.Num();
			if (num > 0)
			{
				List<EBattleUiChild> list = new List<EBattleUiChild>();
				for (int i = 0; i < num; i++)
				{
					list.Add((EBattleUiChild)config.HideUiElement.Get(i));
				}
				ModelBase<BattleUiModel>.Instance.ChildViewData.SetChildrenVisible(EBattleUiVisibleReason.PanelQta, list, false, true, 0);
				this.HideBattleUiChildren = list;
				return;
			}
			this.HideBattleUiChildren.Clear();
		}

		// Token: 0x06036202 RID: 221698 RVA: 0x00DA19A8 File Offset: 0x00D9FBA8
		public void RemoveUiEffect()
		{
			if (this.IsHideAllBattleUi)
			{
				ModelBase<BattleUiModel>.Instance.ChildViewData.ShowBattleView(EBattleUiVisibleReason.PanelQta, 0);
				this.IsHideAllBattleUi = false;
				return;
			}
			ModelBase<BattleUiModel>.Instance.ChildViewData.SetChildrenVisible(EBattleUiVisibleReason.PanelQta, this.HideBattleUiChildren, true, true, 0);
			this.HideBattleUiChildren.Clear();
		}

		// Token: 0x06036203 RID: 221699 RVA: 0x00DA19FA File Offset: 0x00D9FBFA
		public void PlayEffectByResult(EQtaResult resultType, int qtaHandle)
		{
			if (resultType == EQtaResult.Success)
			{
				this.PlayEffect(EQtaPromptType.结果成功提示, qtaHandle);
				return;
			}
			this.PlayEffect(EQtaPromptType.结果失败提示, qtaHandle);
		}

		// Token: 0x06036204 RID: 221700 RVA: 0x00DA1A14 File Offset: 0x00D9FC14
		public void PlayEffect(EQtaPromptType promptType, int qtaHandle)
		{
			if (this.Context == null || qtaHandle != this.Context.HandleId)
			{
				return;
			}
			if (this.Context.GetPromptResource(promptType) == null)
			{
				return;
			}
			this.StopEffect(qtaHandle);
			this.PlayCue(promptType);
			this.PlayScreenEffect(promptType);
			this.PlayCameraShake(promptType);
			this.PlayGamepadShake(promptType);
			this.StopQtaAudio(this.LastAudioHandle, null);
			this.LastAudioHandle = this.PlayQtaAudio(promptType, null);
		}

		// Token: 0x06036205 RID: 221701 RVA: 0x00DA1A8D File Offset: 0x00D9FC8D
		public void StopEffect(int qtaHandle)
		{
			if (this.Context == null || qtaHandle != this.Context.HandleId)
			{
				return;
			}
			this.StopEffectInner();
		}

		// Token: 0x06036206 RID: 221702 RVA: 0x00DA1AAC File Offset: 0x00D9FCAC
		private void StopEffectInner()
		{
			this.RemoveCueHandle();
			this.RemoveScreenEffect();
			this.RemoveCameraShake(false);
			this.StopGamepadShake();
			this.StopQtaAudio(this.LastAudioHandle, null);
			this.LastAudioHandle = 0;
		}

		// Token: 0x06036207 RID: 221703 RVA: 0x00DA1AEE File Offset: 0x00D9FCEE
		public void RemoveEffect()
		{
			this.RemoveUiEffect();
			this.StopEffectInner();
		}

		// Token: 0x06036208 RID: 221704 RVA: 0x00DA1AFC File Offset: 0x00D9FCFC
		private void PlayCue(EQtaPromptType promptType)
		{
			if (this.EntityCueComp == null)
			{
				return;
			}
			this.RemoveCueHandle();
			IQtaPromptResource promptResource = this.Context.GetPromptResource(promptType);
			List<long> list = (promptResource != null) ? promptResource.CueIds : null;
			if (list != null && list.Count > 0)
			{
				foreach (long cueId in list)
				{
					int item = this.EntityCueComp.AddCue(cueId, null);
					this.CueHandleIds.Add(item);
				}
			}
		}

		// Token: 0x06036209 RID: 221705 RVA: 0x00DA1B9C File Offset: 0x00D9FD9C
		private void RemoveCueHandle()
		{
			if (this.EntityCueComp != null && this.CueHandleIds.Count > 0)
			{
				foreach (int num in this.CueHandleIds)
				{
					this.EntityCueComp.RemoveCueByHandle((long)num);
				}
				this.CueHandleIds.Clear();
			}
		}

		// Token: 0x0603620A RID: 221706 RVA: 0x00DA1C18 File Offset: 0x00D9FE18
		private void PlayScreenEffect(EQtaPromptType promptType)
		{
			QtaPromptPlayer.<>c__DisplayClass21_0 CS$<>8__locals1 = new QtaPromptPlayer.<>c__DisplayClass21_0();
			CS$<>8__locals1.<>4__this = this;
			if (this.Context == null)
			{
				return;
			}
			if (this.IsPlayingScreenEffect())
			{
				return;
			}
			QtaPromptPlayer.<>c__DisplayClass21_0 CS$<>8__locals2 = CS$<>8__locals1;
			IQtaPromptResource promptResource = this.Context.GetPromptResource(promptType);
			CS$<>8__locals2.screenEffect = ((promptResource != null) ? promptResource.ScreenEffect1 : null);
			if (CS$<>8__locals1.screenEffect != null)
			{
				this.ScreenEffectInst = CS$<>8__locals1.screenEffect;
				ScreenEffectSystem.GetInstance().PlayScreenEffect(CS$<>8__locals1.screenEffect);
				if (CS$<>8__locals1.screenEffect.Loop == 0f)
				{
					float currentValue = (CS$<>8__locals1.screenEffect.Start + CS$<>8__locals1.screenEffect.End) * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
					this.ScreenEffectTimer = TimerSystem.Instance.Delay(delegate(float _)
					{
						ScreenEffectSystem.GetInstance().EndScreenEffect(CS$<>8__locals1.screenEffect);
						CS$<>8__locals1.<>4__this.ScreenEffectInst = null;
						CS$<>8__locals1.<>4__this.ScreenEffectTimer = null;
					}, Singleton<MathUtils>.Instance.Clamp(currentValue, 20f, 180000f), null, null, true, 1f);
				}
			}
			IQtaPromptResource promptResource2 = this.Context.GetPromptResource(promptType);
			EffectModelPostProcess effectModelPostProcess = (promptResource2 != null) ? promptResource2.ScreenEffect2 : null;
			if (effectModelPostProcess != null)
			{
				IQtaPromptResource promptResource3 = this.Context.GetPromptResource(promptType);
				string text = (promptResource3 != null) ? promptResource3.ScreenEffect2Path : null;
				if (!string.IsNullOrEmpty(text))
				{
					EffectSystem instance = Singleton<EffectSystem>.Instance;
					UObject world = GlobalData.World;
					FTransformDouble? ftransformDouble = new FTransformDouble?(Transform.Create().ToUeTransform());
					this.ScreenEffectHandle = instance.SpawnEffect(world, ftransformDouble, text, "[QtaController.PlayScreenEffect]", null, EEffectType.Scene, null, null, null, false, false);
					if (effectModelPostProcess.LoopTime == 0f)
					{
						float currentValue2 = (effectModelPostProcess.StartTime + effectModelPostProcess.EndTime) * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
						this.ScreenEffectTimer = TimerSystem.Instance.Delay(delegate(float _)
						{
							Singleton<EffectSystem>.Instance.StopEffectById(CS$<>8__locals1.<>4__this.ScreenEffectHandle, "[QtaController.ScreenEffectTimer]", true, null);
							CS$<>8__locals1.<>4__this.ScreenEffectHandle = -1;
							CS$<>8__locals1.<>4__this.ScreenEffectTimer = null;
						}, Singleton<MathUtils>.Instance.Clamp(currentValue2, 20f, 180000f), null, null, true, 1f);
					}
				}
			}
		}

		// Token: 0x0603620B RID: 221707 RVA: 0x00DA1DD4 File Offset: 0x00D9FFD4
		private void RemoveScreenEffect()
		{
			if (this.ScreenEffectTimer != null)
			{
				TimerSystem.Instance.Remove(this.ScreenEffectTimer);
				this.ScreenEffectTimer = null;
			}
			if (this.ScreenEffectInst != null)
			{
				ScreenEffectSystem.GetInstance().EndScreenEffect(this.ScreenEffectInst);
				this.ScreenEffectInst = null;
			}
			if (this.ScreenEffectHandle != -1)
			{
				Singleton<EffectSystem>.Instance.StopEffectById(this.ScreenEffectHandle, "[QtaController.RemoveScreenEffect]", true, null);
				this.ScreenEffectHandle = -1;
			}
		}

		// Token: 0x0603620C RID: 221708 RVA: 0x00DA1E50 File Offset: 0x00DA0050
		private bool IsPlayingScreenEffect()
		{
			return this.ScreenEffectInst != null || this.ScreenEffectHandle != -1;
		}

		// Token: 0x0603620D RID: 221709 RVA: 0x00DA1E68 File Offset: 0x00DA0068
		private void PlayCameraShake(EQtaPromptType promptType)
		{
			if (this.Context == null)
			{
				return;
			}
			if (this.CameraShakeInst != null)
			{
				return;
			}
			IQtaPromptResource promptResource = this.Context.GetPromptResource(promptType);
			UClass uclass = (promptResource != null) ? promptResource.CameraShake : null;
			if (uclass != null)
			{
				this.CameraShakeInst = Global.CharacterCameraManager.StartMatineeCameraShake(uclass, 1f, ECameraShakePlaySpace.CameraLocal, default(FRotator), 1f);
				if (this.CameraShakeInst != null)
				{
					float currentValue = this.CameraShakeInst.OscillatorTimeRemaining * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
					this.CameraShakeTimer = TimerSystem.Instance.Delay(delegate(float _)
					{
						Global.CharacterCameraManager.StopCameraShake(this.CameraShakeInst, false);
						this.CameraShakeInst = null;
						this.CameraShakeTimer = null;
					}, Singleton<MathUtils>.Instance.Clamp(currentValue, 20f, 180000f), null, null, true, 1f);
				}
			}
		}

		// Token: 0x0603620E RID: 221710 RVA: 0x00DA1F2C File Offset: 0x00DA012C
		private void RemoveCameraShake(bool immediately = true)
		{
			if (this.CameraShakeTimer != null)
			{
				TimerSystem.Instance.Remove(this.CameraShakeTimer);
				this.CameraShakeTimer = null;
			}
			if (this.CameraShakeInst != null)
			{
				Global.CharacterCameraManager.StopCameraShake(this.CameraShakeInst, immediately);
				this.CameraShakeInst = null;
			}
		}

		// Token: 0x0603620F RID: 221711 RVA: 0x00DA1F7C File Offset: 0x00DA017C
		private void PlayGamepadShake(EQtaPromptType promptType)
		{
			if (this.Context == null)
			{
				return;
			}
			IQtaPromptResource promptResource = this.Context.GetPromptResource(promptType);
			UKuroForceFeedbackEffect ukuroForceFeedbackEffect = (promptResource != null) ? promptResource.GamepadShake : null;
			if (ukuroForceFeedbackEffect == null || this.Context.Type == null)
			{
				return;
			}
			this.LastGamepadShakePromptType = (int)promptType;
			ControllerBase<GamepadController>.Instance.TriggerGamepadShakeByQte((ECommonQteContextType)this.Context.Type.Value, ukuroForceFeedbackEffect);
		}

		// Token: 0x06036210 RID: 221712 RVA: 0x00DA1FE4 File Offset: 0x00DA01E4
		private void StopGamepadShake()
		{
			if (this.Context == null)
			{
				return;
			}
			IQtaPromptResource promptResource = this.Context.GetPromptResource((EQtaPromptType)this.LastGamepadShakePromptType);
			UKuroForceFeedbackEffect ukuroForceFeedbackEffect = (promptResource != null) ? promptResource.GamepadShake : null;
			this.LastGamepadShakePromptType = 0;
			if (ukuroForceFeedbackEffect == null || this.Context.Type == null)
			{
				return;
			}
			ControllerBase<GamepadController>.Instance.StopQteGamepadShake((ECommonQteContextType)this.Context.Type.Value, ukuroForceFeedbackEffect);
		}

		// Token: 0x06036211 RID: 221713 RVA: 0x00DA2051 File Offset: 0x00DA0251
		public int PlayQtaAudio(EQtaPromptType promptType, AActor actor = null)
		{
			QtaContextBase context = this.Context;
			string audioEvent;
			if (context == null)
			{
				audioEvent = null;
			}
			else
			{
				IQtaPromptResource promptResource = context.GetPromptResource(promptType);
				audioEvent = ((promptResource != null) ? promptResource.Audio : null);
			}
			return this.PlayQtaAudioWithPath(audioEvent, actor);
		}

		// Token: 0x06036212 RID: 221714 RVA: 0x00DA207C File Offset: 0x00DA027C
		private int PlayQtaAudioWithPath(string audioEvent, AActor actor = null)
		{
			if (string.IsNullOrEmpty(audioEvent))
			{
				return 0;
			}
			string text = Singleton<AudioSystem>.Instance.parseAudioEventPath(audioEvent);
			if (string.IsNullOrEmpty(text))
			{
				QtaContextBase context = this.Context;
				string message = "PlayQtaAudioWithPath 缺少有效路径";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("", audioEvent ?? string.Empty);
				QtaLog.Info(context, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return 0;
			}
			if (actor != null)
			{
				return Singleton<AudioSystem>.Instance.PostEvent(text, actor, null);
			}
			return Singleton<AudioSystem>.Instance.PostEvent(text);
		}

		// Token: 0x06036213 RID: 221715 RVA: 0x00DA20FC File Offset: 0x00DA02FC
		[NullableContext(1)]
		public void SeekQtaAudio(int position, string audioEvent, [Nullable(2)] AActor actor = null, int? handle = null)
		{
			if (string.IsNullOrEmpty(audioEvent))
			{
				return;
			}
			string text = Singleton<AudioSystem>.Instance.parseAudioEventPath(audioEvent);
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			Singleton<AudioSystem>.Instance.SeekOnEvent(text, position, new SeekOnEventArgs?(new SeekOnEventArgs
			{
				Actor = actor,
				Handle = handle
			}));
		}

		// Token: 0x06036214 RID: 221716 RVA: 0x00DA2154 File Offset: 0x00DA0354
		public void StopQtaAudio(int handle, int? blendOutTime = null)
		{
			if (handle == 0)
			{
				return;
			}
			Singleton<AudioSystem>.Instance.ExecuteAction(handle, EAudioActionType.Stop, new ExecuteActionArgs?(new ExecuteActionArgs
			{
				TransitionDuration = new int?(blendOutTime.GetValueOrDefault())
			}));
		}

		// Token: 0x0401F188 RID: 127368
		private QtaContextBase Context;

		// Token: 0x0401F189 RID: 127369
		private BaseGameplayCueComponent EntityCueComp;

		// Token: 0x0401F18A RID: 127370
		private EffectScreenPlayData_C ScreenEffectInst;

		// Token: 0x0401F18B RID: 127371
		private int ScreenEffectHandle = -1;

		// Token: 0x0401F18C RID: 127372
		private TimerHandle ScreenEffectTimer;

		// Token: 0x0401F18D RID: 127373
		private UMatineeCameraShake CameraShakeInst;

		// Token: 0x0401F18E RID: 127374
		private TimerHandle CameraShakeTimer;

		// Token: 0x0401F18F RID: 127375
		private bool IsHideAllBattleUi;

		// Token: 0x0401F190 RID: 127376
		[Nullable(1)]
		private List<EBattleUiChild> HideBattleUiChildren = new List<EBattleUiChild>();

		// Token: 0x0401F191 RID: 127377
		private int LastAudioHandle;

		// Token: 0x0401F192 RID: 127378
		[Nullable(1)]
		private readonly List<int> CueHandleIds = new List<int>();

		// Token: 0x0401F193 RID: 127379
		private int LastGamepadShakePromptType;
	}
}
