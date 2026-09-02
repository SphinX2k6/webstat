using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using AkiClient.Game.Aki.Render.RuntimeBP.ScreenEffect.Data;
using CSharpScript.Core.Common;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Effect;
using CSharpScript.Game.Input;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.LevelGamePlay.OperationRestrict;
using CSharpScript.Game.Module.Gamepad;
using CSharpScript.Game.Render.Effect.ScreenEffectSystem;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Interaction
{
	// Token: 0x02005B9A RID: 23450
	[NullableContext(2)]
	[Nullable(0)]
	public class LongPressInteractionProcessor : InteractionProcessor
	{
		// Token: 0x0603B4DC RID: 242908 RVA: 0x00F03DDE File Offset: 0x00F01FDE
		public override void SetTriggerAction(EInputAction? action)
		{
			this.TriggerAction = action;
		}

		// Token: 0x17009765 RID: 38757
		// (get) Token: 0x0603B4DD RID: 242909 RVA: 0x00F03DE7 File Offset: 0x00F01FE7
		public ELongPressInteractStyle? StyleType
		{
			get
			{
				return this.StyleTypeInternal;
			}
		}

		// Token: 0x17009766 RID: 38758
		// (get) Token: 0x0603B4DE RID: 242910 RVA: 0x00F03DEF File Offset: 0x00F01FEF
		public string TidContent
		{
			get
			{
				return this.TidContentInternal;
			}
		}

		// Token: 0x17009767 RID: 38759
		// (get) Token: 0x0603B4DF RID: 242911 RVA: 0x00F03DF7 File Offset: 0x00F01FF7
		public float? StartProgress
		{
			get
			{
				return this.StartProgressInternal;
			}
		}

		// Token: 0x0603B4E0 RID: 242912 RVA: 0x00F03E00 File Offset: 0x00F02000
		[NullableContext(1)]
		public LongPressInteractionProcessor([Nullable(2)] Entity entity, int index, ILongPressInteractConfig config) : base(entity, index, EInteractionType.LongPress)
		{
			this.Duration = config.PressDuration * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
			this.PressEffect = config.PressEffect;
			ILongPressInteractStyleConfig style = config.Style;
			this.StyleTypeInternal = ((style != null) ? new ELongPressInteractStyle?(style.Type) : null);
			ILongPressInteractStyleConfig style2 = config.Style;
			if (style2 != null && style2.Type == ELongPressInteractStyle.TimeBackInteract)
			{
				ILongPressInteractStyleConfigTimeBackInteract longPressInteractStyleConfigTimeBackInteract = config.Style as ILongPressInteractStyleConfigTimeBackInteract;
				this.TidContentInternal = ((longPressInteractStyleConfigTimeBackInteract != null) ? longPressInteractStyleConfigTimeBackInteract.TidContent : null);
				ILongPressInteractStyleConfigTimeBackInteract longPressInteractStyleConfigTimeBackInteract2 = config.Style as ILongPressInteractStyleConfigTimeBackInteract;
				this.StartProgressInternal = ((longPressInteractStyleConfigTimeBackInteract2 != null) ? longPressInteractStyleConfigTimeBackInteract2.StartProgress : null);
			}
			this.ResetFromCurrentProgress = config.ResetFromCurrentProgress.GetValueOrDefault();
			this.StartActions = config.LongPressStartActions;
			this.InterruptedActions = config.LongPressInterruptedActions;
			this.SuccessActions = config.LongPressSuccessActions;
		}

		// Token: 0x0603B4E1 RID: 242913 RVA: 0x00F03F08 File Offset: 0x00F02108
		public override void OnPress()
		{
			if (!this.LongPressingEffectsReady)
			{
				return;
			}
			Singleton<global::Log>.Instance.Info(ELogModule.Interaction, ELogAuthor.WRY, "[LongPress] 阶段=开始", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.IsInterruptPending = true;
			this.RunPhaseActions(this.StartActions);
			if (this.IsSwordRiderStyle)
			{
				this.LockSwordRiderOperation();
			}
			base.IsPressing = true;
			this.StopReverseTick();
			if (!this.ResetFromCurrentProgress)
			{
				this.AccumulatedTime = 0f;
				this.Progress = 0f;
			}
			this.LongPressTimerId = TimerSystem.Instance.Forever(new TTimerAction(this.OnLongPressTick), 20f, 1f, null, null, true);
			if (this.CameraShakeAsset != null && this.CameraShakeAsset.IsValid() && this.CameraShakeInstanceId == null)
			{
				this.CameraShakeInstanceId = new int?(ControllerBase<CameraController>.Instance.PlayCameraShake(this.CameraShakeAsset, new float?(ControllerBase<CameraController>.Instance.MainModel.ShakeModify), null, null, true, true, "MainCamera"));
			}
			this.PlayLongPressingSound();
			this.PlayLongPressingForceFeedback();
			this.PlayLongPressingScreenEffect();
			this.PlayLongPressingEffects();
		}

		// Token: 0x0603B4E2 RID: 242914 RVA: 0x00F04034 File Offset: 0x00F02234
		public override void OnRelease()
		{
			if (this.ResetFromCurrentProgress)
			{
				this.StartReverse();
				return;
			}
			this.OnReset();
		}

		// Token: 0x0603B4E3 RID: 242915 RVA: 0x00F0404C File Offset: 0x00F0224C
		private void StartReverse()
		{
			this.TryTriggerInterrupt();
			base.IsPressing = false;
			if (this.CameraShakeInstanceId != null)
			{
				ControllerBase<CameraController>.Instance.StopCameraShake(this.CameraShakeInstanceId.Value, false, "MainCamera");
				this.CameraShakeInstanceId = null;
			}
			if (this.LongPressTimerId != null && TimerSystem.Instance.Has(this.LongPressTimerId))
			{
				TimerSystem.Instance.Remove(this.LongPressTimerId);
				this.LongPressTimerId = null;
			}
			this.StopLongPressingSound();
			this.StopLongPressingForceFeedback();
			this.StopLongPressingScreenEffect();
			this.StopLongPressingEffects();
			if (this.Progress <= 0f || this.Duration <= 0f)
			{
				return;
			}
			if (this.ReverseTimerId != null && TimerSystem.Instance.Has(this.ReverseTimerId))
			{
				return;
			}
			this.ReverseTimerId = TimerSystem.Instance.Forever(new TTimerAction(this.OnReverseTick), 20f, 1f, null, null, true);
		}

		// Token: 0x0603B4E4 RID: 242916 RVA: 0x00F04144 File Offset: 0x00F02344
		private void OnReverseTick(float deltaTime)
		{
			this.AccumulatedTime = Math.Max(0f, this.AccumulatedTime - 20f);
			this.Progress = Singleton<MathUtils>.Instance.Clamp(this.AccumulatedTime / this.Duration, 0f, 1f);
			if (base.Entity != null)
			{
				Singleton<EventSystem>.Instance.EmitWithTarget<float>(base.Entity, EEventName.OnInteractionLongPressProgressChange, this.Progress);
			}
			if (this.Progress <= 0f)
			{
				this.StopReverseTick();
			}
		}

		// Token: 0x0603B4E5 RID: 242917 RVA: 0x00F041CB File Offset: 0x00F023CB
		private void StopReverseTick()
		{
			if (this.ReverseTimerId != null && TimerSystem.Instance.Has(this.ReverseTimerId))
			{
				TimerSystem.Instance.Remove(this.ReverseTimerId);
				this.ReverseTimerId = null;
			}
		}

		// Token: 0x0603B4E6 RID: 242918 RVA: 0x00F04200 File Offset: 0x00F02400
		public override void OnReset()
		{
			this.TryTriggerInterrupt();
			base.IsPressing = false;
			this.AccumulatedTime = 0f;
			this.Progress = 0f;
			if (base.Entity != null)
			{
				Singleton<EventSystem>.Instance.EmitWithTarget<float>(base.Entity, EEventName.OnInteractionLongPressProgressChange, 0f);
			}
			if (this.CameraShakeInstanceId != null)
			{
				ControllerBase<CameraController>.Instance.StopCameraShake(this.CameraShakeInstanceId.Value, false, "MainCamera");
				this.CameraShakeInstanceId = null;
			}
			if (this.LongPressTimerId != null && TimerSystem.Instance.Has(this.LongPressTimerId))
			{
				TimerSystem.Instance.Remove(this.LongPressTimerId);
				this.LongPressTimerId = null;
			}
			this.StopReverseTick();
			this.StopLongPressingSound();
			this.StopLongPressingForceFeedback();
			this.StopLongPressingScreenEffect();
			this.StopLongPressingEffects();
		}

		// Token: 0x0603B4E7 RID: 242919 RVA: 0x00F042D8 File Offset: 0x00F024D8
		private void OnLongPressTick(float deltaTime)
		{
			if (!base.IsPressing)
			{
				return;
			}
			this.AccumulatedTime += deltaTime;
			this.Progress = Singleton<MathUtils>.Instance.Clamp(this.AccumulatedTime / this.Duration, 0f, 1f);
			if (base.Entity != null)
			{
				Singleton<EventSystem>.Instance.EmitWithTarget<float>(base.Entity, EEventName.OnInteractionLongPressProgressChange, this.Progress);
			}
			if (this.Progress >= 1f)
			{
				this.IsInterruptPending = false;
				base.TriggerComplete();
				this.RunPhaseActions(this.SuccessActions);
				if (this.IsSwordRiderStyle)
				{
					this.UnlockSwordRiderOperation();
				}
				base.IsPressing = false;
				if (this.CameraShakeInstanceId != null)
				{
					ControllerBase<CameraController>.Instance.StopCameraShake(this.CameraShakeInstanceId.Value, false, "MainCamera");
					this.CameraShakeInstanceId = null;
				}
				this.StopLongPressingSound();
				this.StopLongPressingForceFeedback();
				this.StopLongPressingScreenEffect();
				this.StopLongPressingEffects();
				this.PlayLongPressFinishedForceFeedback();
			}
		}

		// Token: 0x0603B4E8 RID: 242920 RVA: 0x00F043D8 File Offset: 0x00F025D8
		private void RunPhaseActions([Nullable(new byte[]
		{
			2,
			1
		})] List<ActionInfo> actions)
		{
			if (actions == null || actions.Count == 0 || base.Entity == null)
			{
				return;
			}
			EntityContext context = EntityContext.Create(base.Entity.Id, null);
			ControllerBase<LevelGeneralController>.Instance.ExecuteActionsNew(actions, context, null);
		}

		// Token: 0x17009768 RID: 38760
		// (get) Token: 0x0603B4E9 RID: 242921 RVA: 0x00F04420 File Offset: 0x00F02620
		private bool IsSwordRiderStyle
		{
			get
			{
				return this.StyleTypeInternal.GetValueOrDefault() == ELongPressInteractStyle.SwordRiderInteract;
			}
		}

		// Token: 0x0603B4EA RID: 242922 RVA: 0x00F04430 File Offset: 0x00F02630
		private void LockSwordRiderOperation()
		{
			IDisableModulePlayerOperation operationRestrictByOption = this.BuildSwordRiderLockOption();
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Interaction;
			ELogAuthor author = ELogAuthor.WRY;
			string message = "[LongPress] 御剑长按交互-锁定玩家操作";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("触发键", this.TriggerAction);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			Singleton<OperationRestrictUtils>.Instance.SetOperationRestrictByOption(operationRestrictByOption);
		}

		// Token: 0x0603B4EB RID: 242923 RVA: 0x00F04484 File Offset: 0x00F02684
		private void UnlockSwordRiderOperation()
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Interaction;
			ELogAuthor author = ELogAuthor.WRY;
			string message = "[LongPress] 御剑长按交互-解锁玩家操作";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("触发键", this.TriggerAction);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			Singleton<OperationRestrictUtils>.Instance.SetOperationRestrictEnableAll();
		}

		// Token: 0x0603B4EC RID: 242924 RVA: 0x00F044D0 File Offset: 0x00F026D0
		[NullableContext(1)]
		private IDisableModulePlayerOperation BuildSwordRiderLockOption()
		{
			EInputAction? triggerAction = this.TriggerAction;
			return new IDisableModulePlayerOperation
			{
				Type = EPlayerOperationType.DisableModule,
				MoveOption = new IDisableMoveOperation
				{
					Type = EMoveOperationType.Disable,
					Forward = false,
					Back = false,
					Left = false,
					Right = false
				},
				SkillOption = new IDisableSectionalSkillOperation
				{
					Type = ESkillOperationType.DisableSection,
					DisplayMode = new EDisplayModeInSkillOp?(EDisplayModeInSkillOp.Disable),
					DisableBattleSkill = new IDisableBattleSkillOptions
					{
						IsDisablePhantomSkill = new bool?(triggerAction != EInputAction.幻象2),
						IsDisableCharacterSectionalSkill = new IDisableCharacterSectionalSkillOption
						{
							DisableShowClimb = new bool?(triggerAction != EInputAction.攀爬),
							DisableAttack = new bool?(triggerAction != EInputAction.攻击),
							DisableDodge = new bool?(triggerAction != EInputAction.闪避),
							DisableSkill1 = new bool?(triggerAction != EInputAction.技能1),
							DisableUltimateSkill = new bool?(triggerAction != EInputAction.大招),
							DisableExploreInput = new bool?(triggerAction != EInputAction.幻象1),
							DisableLock = new bool?(triggerAction != EInputAction.锁定目标),
							DisableAim = new bool?(triggerAction != EInputAction.瞄准),
							DisableJump = new bool?(triggerAction != EInputAction.跳跃),
							DisableSwitchRole1 = new bool?(triggerAction != EInputAction.切换角色1),
							DisableSwitchRole2 = new bool?(triggerAction != EInputAction.切换角色2),
							DisableSwitchRole3 = new bool?(triggerAction != EInputAction.切换角色3)
						}
					},
					DisableSwitchRole = new bool?(true)
				},
				CameraOption = new IDisableCameraOperation
				{
					Type = ECameraOperationType.Disable
				},
				UiOption = new IDisableUiOperation
				{
					Type = EUiOperationType.Disable
				},
				SceneInteractionOption = new IEnableSceneInteractionOperation
				{
					Type = ESceneInteractionOperationType.Enable
				}
			};
		}

		// Token: 0x0603B4ED RID: 242925 RVA: 0x00F047D0 File Offset: 0x00F029D0
		private void TryTriggerInterrupt()
		{
			if (!this.IsInterruptPending)
			{
				return;
			}
			this.IsInterruptPending = false;
			Singleton<global::Log>.Instance.Info(ELogModule.Interaction, ELogAuthor.WRY, "[LongPress] 阶段=打断", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.RunPhaseActions(this.InterruptedActions);
			if (this.IsSwordRiderStyle)
			{
				this.UnlockSwordRiderOperation();
			}
		}

		// Token: 0x0603B4EE RID: 242926 RVA: 0x00F04828 File Offset: 0x00F02A28
		[NullableContext(0)]
		public override UniTask<bool> LoadAsset()
		{
			LongPressInteractionProcessor.<LoadAsset>d__47 <LoadAsset>d__;
			<LoadAsset>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<LoadAsset>d__.<>4__this = this;
			<LoadAsset>d__.<>1__state = -1;
			<LoadAsset>d__.<>t__builder.Start<LongPressInteractionProcessor.<LoadAsset>d__47>(ref <LoadAsset>d__);
			return <LoadAsset>d__.<>t__builder.Task;
		}

		// Token: 0x0603B4EF RID: 242927 RVA: 0x00F0486C File Offset: 0x00F02A6C
		[NullableContext(0)]
		private UniTask<bool> LoadLongPressCameraShake([Nullable(1)] string bpPath)
		{
			LongPressInteractionProcessor.<LoadLongPressCameraShake>d__48 <LoadLongPressCameraShake>d__;
			<LoadLongPressCameraShake>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<LoadLongPressCameraShake>d__.<>4__this = this;
			<LoadLongPressCameraShake>d__.bpPath = bpPath;
			<LoadLongPressCameraShake>d__.<>1__state = -1;
			<LoadLongPressCameraShake>d__.<>t__builder.Start<LongPressInteractionProcessor.<LoadLongPressCameraShake>d__48>(ref <LoadLongPressCameraShake>d__);
			return <LoadLongPressCameraShake>d__.<>t__builder.Task;
		}

		// Token: 0x0603B4F0 RID: 242928 RVA: 0x00F048B8 File Offset: 0x00F02AB8
		[NullableContext(1)]
		[return: Nullable(0)]
		private UniTask<bool> LoadForceFeedbackEffect(string effectPath, Action<UKuroForceFeedbackEffect> onLoaded, string errorMsg)
		{
			LongPressInteractionProcessor.<LoadForceFeedbackEffect>d__49 <LoadForceFeedbackEffect>d__;
			<LoadForceFeedbackEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<LoadForceFeedbackEffect>d__.effectPath = effectPath;
			<LoadForceFeedbackEffect>d__.onLoaded = onLoaded;
			<LoadForceFeedbackEffect>d__.errorMsg = errorMsg;
			<LoadForceFeedbackEffect>d__.<>1__state = -1;
			<LoadForceFeedbackEffect>d__.<>t__builder.Start<LongPressInteractionProcessor.<LoadForceFeedbackEffect>d__49>(ref <LoadForceFeedbackEffect>d__);
			return <LoadForceFeedbackEffect>d__.<>t__builder.Task;
		}

		// Token: 0x0603B4F1 RID: 242929 RVA: 0x00F0490C File Offset: 0x00F02B0C
		private void PlayLongPressingSound()
		{
			ILongPressEffectConfig pressEffect = this.PressEffect;
			string text = (pressEffect != null) ? pressEffect.LongPressSound : null;
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			string text2 = Singleton<AudioSystem>.Instance.parseAudioEventPath(text);
			if (!string.IsNullOrEmpty(text2))
			{
				this.LongPressingSoundHandle = new int?(Singleton<AudioSystem>.Instance.PostEvent(text2));
			}
		}

		// Token: 0x0603B4F2 RID: 242930 RVA: 0x00F04960 File Offset: 0x00F02B60
		private void StopLongPressingSound()
		{
			if (this.LongPressingSoundHandle != null)
			{
				Singleton<AudioSystem>.Instance.ExecuteAction(this.LongPressingSoundHandle.Value, EAudioActionType.Stop, null);
				this.LongPressingSoundHandle = null;
			}
		}

		// Token: 0x0603B4F3 RID: 242931 RVA: 0x00F049A8 File Offset: 0x00F02BA8
		private void PlayLongPressingForceFeedback()
		{
			if (!Singleton<Info>.Instance.IsInGamepad())
			{
				return;
			}
			if (this.LongPressingFeedbackAsset != null && this.LongPressingFeedbackAsset.IsValid())
			{
				ControllerBase<GamepadController>.Instance.PlayKuroForceFeedback(this.LongPressingFeedbackAsset, null, true, false, false, "LongPressInteraction");
			}
		}

		// Token: 0x0603B4F4 RID: 242932 RVA: 0x00F049F8 File Offset: 0x00F02BF8
		private void StopLongPressingForceFeedback()
		{
			if (!Singleton<Info>.Instance.IsInGamepad())
			{
				return;
			}
			if (this.LongPressingFeedbackAsset != null && this.LongPressingFeedbackAsset.IsValid())
			{
				GamepadController.StopKuroForceFeedback(this.LongPressingFeedbackAsset, FNameUtil.NONE);
			}
		}

		// Token: 0x0603B4F5 RID: 242933 RVA: 0x00F04A2C File Offset: 0x00F02C2C
		[NullableContext(0)]
		private UniTask<bool> PreloadLongPressingEffects()
		{
			LongPressInteractionProcessor.<PreloadLongPressingEffects>d__54 <PreloadLongPressingEffects>d__;
			<PreloadLongPressingEffects>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<PreloadLongPressingEffects>d__.<>4__this = this;
			<PreloadLongPressingEffects>d__.<>1__state = -1;
			<PreloadLongPressingEffects>d__.<>t__builder.Start<LongPressInteractionProcessor.<PreloadLongPressingEffects>d__54>(ref <PreloadLongPressingEffects>d__);
			return <PreloadLongPressingEffects>d__.<>t__builder.Task;
		}

		// Token: 0x0603B4F6 RID: 242934 RVA: 0x00F04A70 File Offset: 0x00F02C70
		[NullableContext(1)]
		private UniTask PreloadOneEffect(string path)
		{
			CustomPromise promise = new CustomPromise();
			Singleton<ResourceSystem>.Instance.LoadAsync<UEffectModelBase>(path, delegate([Nullable(2)] UEffectModelBase asset, string loadedPath)
			{
				if (asset != null)
				{
					this.PreloadedEffectAssets.Add(asset);
				}
				else
				{
					global::Log instance = Singleton<global::Log>.Instance;
					ELogModule module = ELogModule.Interaction;
					ELogAuthor author = ELogAuthor.WRY;
					string message = "[LongPressInteractionProcessor] 预加载特效DA失败";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Path", loadedPath);
					instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				promise.SetResult();
			}, ResourceSystem.EResourceLoadPriority.Default, "js_undefined");
			return promise.Promise;
		}

		// Token: 0x0603B4F7 RID: 242935 RVA: 0x00F04AC0 File Offset: 0x00F02CC0
		[NullableContext(0)]
		private UniTask<bool> PreloadLongPressingScreenEffect([Nullable(1)] string path)
		{
			LongPressInteractionProcessor.<PreloadLongPressingScreenEffect>d__56 <PreloadLongPressingScreenEffect>d__;
			<PreloadLongPressingScreenEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<PreloadLongPressingScreenEffect>d__.<>4__this = this;
			<PreloadLongPressingScreenEffect>d__.path = path;
			<PreloadLongPressingScreenEffect>d__.<>1__state = -1;
			<PreloadLongPressingScreenEffect>d__.<>t__builder.Start<LongPressInteractionProcessor.<PreloadLongPressingScreenEffect>d__56>(ref <PreloadLongPressingScreenEffect>d__);
			return <PreloadLongPressingScreenEffect>d__.<>t__builder.Task;
		}

		// Token: 0x0603B4F8 RID: 242936 RVA: 0x00F04B0C File Offset: 0x00F02D0C
		private void PlayLongPressingScreenEffect()
		{
			ILongPressEffectConfig pressEffect = this.PressEffect;
			string text = (pressEffect != null) ? pressEffect.LongPressScreenEffect : null;
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			EffectScreenPlayData_C preloadedScreenEffectAsset = this.PreloadedScreenEffectAsset;
			if (preloadedScreenEffectAsset == null || !preloadedScreenEffectAsset.IsValid())
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Interaction;
				ELogAuthor author = ELogAuthor.WRY;
				string message = "[LongPressInteractionProcessor] 屏幕特效资源未就绪，跳过播放";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ScreenEffect", text);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			ScreenEffectModel instance2 = ModelBase<ScreenEffectModel>.Instance;
			if (instance2 == null)
			{
				global::Log instance3 = Singleton<global::Log>.Instance;
				ELogModule module2 = ELogModule.Interaction;
				ELogAuthor author2 = ELogAuthor.WRY;
				string message2 = "[LongPressInteractionProcessor] 屏幕特效未播放: ScreenEffectModel 不可用";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("ScreenEffect", text);
				instance3.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return;
			}
			this.StopLongPressingScreenEffect();
			this.LongPressingScreenEffectHandle = new int?(instance2.PlayScreenEffect(text, null, null));
		}

		// Token: 0x0603B4F9 RID: 242937 RVA: 0x00F04BC8 File Offset: 0x00F02DC8
		private void StopLongPressingScreenEffect()
		{
			if (this.LongPressingScreenEffectHandle == null)
			{
				return;
			}
			ScreenEffectModel instance = ModelBase<ScreenEffectModel>.Instance;
			if (instance == null)
			{
				this.LongPressingScreenEffectHandle = null;
				return;
			}
			instance.EndScreenEffect(this.LongPressingScreenEffectHandle.Value);
			this.LongPressingScreenEffectHandle = null;
		}

		// Token: 0x0603B4FA RID: 242938 RVA: 0x00F04C18 File Offset: 0x00F02E18
		private void PlayLongPressingEffects()
		{
			ILongPressEffectConfig pressEffect = this.PressEffect;
			List<string> list = (pressEffect != null) ? pressEffect.PlayEffects : null;
			bool flag = (((list != null) ? new int?(list.Count) : null) ?? 0) == 0;
			if (flag)
			{
				return;
			}
			this.StopLongPressingEffects();
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			if (baseCharacter == null || !baseCharacter.IsValid())
			{
				Singleton<global::Log>.Instance.Warn(ELogModule.Interaction, ELogAuthor.WRY, "[LongPressInteractionProcessor] 播放长按特效失败: 取不到玩家", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			foreach (string text in list)
			{
				if (!StringUtils.IsEmpty(text))
				{
					EffectSystem instance = Singleton<EffectSystem>.Instance;
					UObject world = GlobalData.World;
					FTransformDouble? ftransformDouble = new FTransformDouble?(Singleton<MathUtils>.Instance.DefaultTransformDouble);
					int num = instance.SpawnEffect(world, ftransformDouble, text, "[LongPressInteractionProcessor] PlayEffects", new EffectContext(null, baseCharacter, false), global::EEffectType.Scene, null, null, null, false, false);
					if (Singleton<EffectSystem>.Instance.IsValid(num))
					{
						this.LongPressingEffectIds.Add(num);
						OneOf<KuroEffectActorHandle, AActor> effectActor = Singleton<EffectSystem>.Instance.GetEffectActor(num);
						AActor parent = baseCharacter;
						FName? fname = null;
						effectActor.K2_AttachToActor(parent, fname, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, false);
					}
				}
			}
		}

		// Token: 0x0603B4FB RID: 242939 RVA: 0x00F04D74 File Offset: 0x00F02F74
		private void StopLongPressingEffects()
		{
			if (this.LongPressingEffectIds.Count == 0)
			{
				return;
			}
			foreach (int num in this.LongPressingEffectIds)
			{
				if (Singleton<EffectSystem>.Instance.IsValid(num))
				{
					Singleton<EffectSystem>.Instance.StopEffectById(num, "[LongPressInteractionProcessor] StopEffects", false, null);
				}
			}
			this.LongPressingEffectIds.Clear();
		}

		// Token: 0x0603B4FC RID: 242940 RVA: 0x00F04E04 File Offset: 0x00F03004
		private void PlayLongPressFinishedForceFeedback()
		{
			if (!Singleton<Info>.Instance.IsInGamepad())
			{
				return;
			}
			if (this.LongPressFinishedFeedbackAsset != null && this.LongPressFinishedFeedbackAsset.IsValid())
			{
				ControllerBase<GamepadController>.Instance.PlayKuroForceFeedback(this.LongPressFinishedFeedbackAsset, null, false, false, false, "LongPressInteractionFinished");
			}
		}

		// Token: 0x040216DA RID: 136922
		private float AccumulatedTime;

		// Token: 0x040216DB RID: 136923
		private float Progress;

		// Token: 0x040216DC RID: 136924
		private readonly float Duration;

		// Token: 0x040216DD RID: 136925
		private readonly ILongPressEffectConfig PressEffect;

		// Token: 0x040216DE RID: 136926
		private readonly ELongPressInteractStyle? StyleTypeInternal;

		// Token: 0x040216DF RID: 136927
		private readonly string TidContentInternal;

		// Token: 0x040216E0 RID: 136928
		private readonly float? StartProgressInternal;

		// Token: 0x040216E1 RID: 136929
		private readonly bool ResetFromCurrentProgress;

		// Token: 0x040216E2 RID: 136930
		private UClass CameraShakeAsset;

		// Token: 0x040216E3 RID: 136931
		private int? CameraShakeInstanceId;

		// Token: 0x040216E4 RID: 136932
		private TimerHandle LongPressTimerId;

		// Token: 0x040216E5 RID: 136933
		private TimerHandle ReverseTimerId;

		// Token: 0x040216E6 RID: 136934
		private int? LongPressingSoundHandle;

		// Token: 0x040216E7 RID: 136935
		private UKuroForceFeedbackEffect LongPressingFeedbackAsset;

		// Token: 0x040216E8 RID: 136936
		private UKuroForceFeedbackEffect LongPressFinishedFeedbackAsset;

		// Token: 0x040216E9 RID: 136937
		[Nullable(1)]
		private readonly List<int> LongPressingEffectIds = new List<int>();

		// Token: 0x040216EA RID: 136938
		private int? LongPressingScreenEffectHandle;

		// Token: 0x040216EB RID: 136939
		private bool LongPressingEffectsReady;

		// Token: 0x040216EC RID: 136940
		[Nullable(1)]
		private readonly List<UEffectModelBase> PreloadedEffectAssets = new List<UEffectModelBase>();

		// Token: 0x040216ED RID: 136941
		private EffectScreenPlayData_C PreloadedScreenEffectAsset;

		// Token: 0x040216EE RID: 136942
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private readonly List<ActionInfo> StartActions;

		// Token: 0x040216EF RID: 136943
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private readonly List<ActionInfo> InterruptedActions;

		// Token: 0x040216F0 RID: 136944
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private readonly List<ActionInfo> SuccessActions;

		// Token: 0x040216F1 RID: 136945
		private bool IsInterruptPending;

		// Token: 0x040216F2 RID: 136946
		private EInputAction? TriggerAction;
	}
}
