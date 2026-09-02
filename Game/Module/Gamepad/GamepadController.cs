using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using CSharpScript.Core.Common;
using CSharpScript.Game.InputSetting;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Gamepad
{
	// Token: 0x02005D03 RID: 23811
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class GamepadController : ControllerBase<GamepadController>
	{
		// Token: 0x0603C07C RID: 245884 RVA: 0x00F3A564 File Offset: 0x00F38764
		protected override bool OnInit()
		{
			this.HitForceFeedbackPaths.Add(ConfigCommonParamById.GetStringConfig("FKHitForceFeedbackPath"));
			this.HitForceFeedbackPaths.Add(ConfigCommonParamById.GetStringConfig("LightHitForceFeedbackPath"));
			this.HitForceFeedbackPaths.Add(ConfigCommonParamById.GetStringConfig("HeavyHitForceFeedbackPath"));
			this.GamepadPsFeedbackListenTagModule.Init();
			return true;
		}

		// Token: 0x0603C07D RID: 245885 RVA: 0x00F3A5BC File Offset: 0x00F387BC
		protected override bool OnClear()
		{
			this.ClearFeedbackReason();
			this.GamepadPsFeedbackLoadModule.Clear();
			this.GamepadPsFeedbackListenTagModule.Clear();
			return true;
		}

		// Token: 0x0603C07E RID: 245886 RVA: 0x00F3A5DC File Offset: 0x00F387DC
		public void PlayForceFeedbackByHit(EHitFeedbackType type)
		{
			if (!Singleton<Info>.Instance.IsInGamepad())
			{
				return;
			}
			if (type < (EHitFeedbackType)this.HitForceFeedbackEffects.Count)
			{
				UKuroForceFeedbackEffect ukuroForceFeedbackEffect;
				this.HitForceFeedbackEffects.TryGetValue((int)type, out ukuroForceFeedbackEffect);
				if (ukuroForceFeedbackEffect != null)
				{
					this.PlayKuroForceFeedback(ukuroForceFeedbackEffect, null, false, false, false, "Hit");
					return;
				}
			}
			if (type < (EHitFeedbackType)this.HitForceFeedbackPaths.Count)
			{
				string path = this.HitForceFeedbackPaths[(int)type];
				Singleton<ResourceSystem>.Instance.LoadAsync<UKuroForceFeedbackEffect>(path, delegate([Nullable(2)] UKuroForceFeedbackEffect result, string loadPath)
				{
					if (result != null)
					{
						this.PlayKuroForceFeedback(result, null, false, false, false, "Hit");
					}
				}, ResourceSystem.EResourceLoadPriority.Default, "Ui.GamepadUi");
			}
		}

		// Token: 0x0603C07F RID: 245887 RVA: 0x00F3A66C File Offset: 0x00F3886C
		private void RefreshPsFeedbackMode()
		{
			GamepadPsFeedbackData.FeedbackInfo lastFeedbackInfo = this.GamepadPsFeedbackData.GetLastFeedbackInfo();
			if (lastFeedbackInfo != null)
			{
				this.GamepadPsFeedbackLoadModule.PlayFeedback(lastFeedbackInfo.Mode, lastFeedbackInfo.Path);
				return;
			}
			this.GamepadPsFeedbackLoadModule.StopFeedback();
		}

		// Token: 0x0603C080 RID: 245888 RVA: 0x00F3A6AC File Offset: 0x00F388AC
		private ETriggerEffectSide? GetActionNameMode(string actionName)
		{
			TArray<FInputActionKeyMapping> actionMappings = Singleton<InputSettings>.Instance.GetActionMappings(actionName);
			if (actionMappings.Num() <= 0)
			{
				return null;
			}
			bool flag = false;
			bool flag2 = false;
			for (int i = actionMappings.Num() - 1; i >= 0; i--)
			{
				FInputActionKeyMapping finputActionKeyMapping = actionMappings.Get(i);
				string text = (finputActionKeyMapping != null) ? finputActionKeyMapping.Key.KeyName.ToString() : null;
				InputKey key = Singleton<InputSettings>.Instance.GetKey(text);
				if (key != null && key.IsGamepadKey)
				{
					if (text == EKey.Gamepad_LeftTrigger)
					{
						flag = true;
					}
					else if (text == EKey.Gamepad_RightTrigger)
					{
						flag2 = true;
					}
				}
			}
			if (flag && flag2)
			{
				return new ETriggerEffectSide?(ETriggerEffectSide.Both);
			}
			if (flag)
			{
				return new ETriggerEffectSide?(ETriggerEffectSide.Left);
			}
			if (flag2)
			{
				return new ETriggerEffectSide?(ETriggerEffectSide.Right);
			}
			return null;
		}

		// Token: 0x0603C081 RID: 245889 RVA: 0x00F3A790 File Offset: 0x00F38990
		private static ETriggerEffectSide? GetAxisNameMode(string axisName)
		{
			TArray<FInputAxisKeyMapping> axisMappings = Singleton<InputSettings>.Instance.GetAxisMappings(axisName);
			if (axisMappings.Num() <= 0)
			{
				return null;
			}
			bool flag = false;
			bool flag2 = false;
			for (int i = axisMappings.Num() - 1; i >= 0; i--)
			{
				string text = axisMappings.Get(i).Key.KeyName.ToString();
				InputKey key = Singleton<InputSettings>.Instance.GetKey(text);
				if (key != null && key.IsGamepadKey)
				{
					if (text == EKey.Gamepad_LeftTriggerAxis)
					{
						if (key.IsInputKeyDown())
						{
							flag = true;
						}
					}
					else if (text == EKey.Gamepad_RightTriggerAxis && key.IsInputKeyDown())
					{
						flag2 = true;
					}
				}
			}
			if (flag && flag2)
			{
				return new ETriggerEffectSide?(ETriggerEffectSide.Both);
			}
			if (flag)
			{
				return new ETriggerEffectSide?(ETriggerEffectSide.Left);
			}
			if (flag2)
			{
				return new ETriggerEffectSide?(ETriggerEffectSide.Right);
			}
			return null;
		}

		// Token: 0x0603C082 RID: 245890 RVA: 0x00F3A884 File Offset: 0x00F38A84
		private ETriggerEffectSide? GetOperationNameMode(string operationName, bool isAxis)
		{
			if (!Singleton<Info>.Instance.IsInGamepad())
			{
				return null;
			}
			if (isAxis)
			{
				return GamepadController.GetAxisNameMode(operationName);
			}
			return this.GetActionNameMode(operationName);
		}

		// Token: 0x0603C083 RID: 245891 RVA: 0x00F3A8B8 File Offset: 0x00F38AB8
		public void TryAddFeedbackReason(EGamepadPsFeedbackReason reason, string feedbackId)
		{
			PsFeedback? psFeedbackReason = ConfigBase<GamepadConfig>.Instance.GetPsFeedbackReason(feedbackId);
			if (psFeedbackReason == null)
			{
				return;
			}
			ETriggerEffectSide? operationNameMode = this.GetOperationNameMode(psFeedbackReason.Value.ActionName, psFeedbackReason.Value.IsAxis);
			if (operationNameMode == null)
			{
				this.RemoveFeedbackReason(reason);
				return;
			}
			this.AddFeedbackReason(reason, operationNameMode.Value, psFeedbackReason.Value.FeedbackPath);
		}

		// Token: 0x0603C084 RID: 245892 RVA: 0x00F3A92E File Offset: 0x00F38B2E
		private void AddFeedbackReason(EGamepadPsFeedbackReason reason, ETriggerEffectSide mode, string path)
		{
			this.GamepadPsFeedbackData.AddFeedbackReason(reason, mode, path);
			this.RefreshPsFeedbackMode();
		}

		// Token: 0x0603C085 RID: 245893 RVA: 0x00F3A944 File Offset: 0x00F38B44
		public void RemoveFeedbackReason(EGamepadPsFeedbackReason reason)
		{
			if (this.GamepadPsFeedbackData.RemoveFeedbackReason(reason))
			{
				this.RefreshPsFeedbackMode();
			}
		}

		// Token: 0x0603C086 RID: 245894 RVA: 0x00F3A95A File Offset: 0x00F38B5A
		private void ClearFeedbackReason()
		{
			this.GamepadPsFeedbackData.ClearFeedbackReason();
			this.RefreshPsFeedbackMode();
		}

		// Token: 0x0603C087 RID: 245895 RVA: 0x00F3A970 File Offset: 0x00F38B70
		[NullableContext(2)]
		public void PlayKuroForceFeedback(UKuroForceFeedbackEffect forceFeedbackEffect, FName? tag, bool bLooping, bool bIgnoreTimeDilation, bool bPlayWhilePaused, string reason = null)
		{
			if (Global.PlayerController != null)
			{
				FName tag2 = tag ?? FNameUtil.NONE;
				TsCharacterController tsCharacterController = Global.PlayerController as TsCharacterController;
				if (tsCharacterController == null)
				{
					return;
				}
				tsCharacterController.PlayKuroForceFeedback(forceFeedbackEffect, tag2, bLooping, bIgnoreTimeDilation, bPlayWhilePaused);
			}
		}

		// Token: 0x0603C088 RID: 245896 RVA: 0x00F3A9BC File Offset: 0x00F38BBC
		public void TriggerGamepadShakeByQte(ECommonQteContextType qteType, UKuroForceFeedbackEffect gamepadShakeAsset)
		{
			FName? dynamicFName = FNameUtil.GetDynamicFName("Qte_GamepadShake");
			if (dynamicFName == null)
			{
				return;
			}
			if (qteType <= ECommonQteContextType.SingleButtonContinuousClick)
			{
				this.PlayKuroForceFeedback(gamepadShakeAsset, new FName?(dynamicFName.Value), false, true, false, null);
				return;
			}
			if (qteType - ECommonQteContextType.SingleButtonLongPress > 1)
			{
				return;
			}
			this.PlayKuroForceFeedback(gamepadShakeAsset, new FName?(dynamicFName.Value), false, false, false, null);
		}

		// Token: 0x0603C089 RID: 245897 RVA: 0x00F3AA18 File Offset: 0x00F38C18
		public void StopQteGamepadShake(ECommonQteContextType qteType, UKuroForceFeedbackEffect gamepadShakeAsset)
		{
			FName? dynamicFName = FNameUtil.GetDynamicFName("Qte_GamepadShake");
			if (dynamicFName == null)
			{
				return;
			}
			GamepadController.StopKuroForceFeedback(gamepadShakeAsset, dynamicFName.Value);
		}

		// Token: 0x0603C08A RID: 245898 RVA: 0x00F3AA48 File Offset: 0x00F38C48
		public void TriggerGamepadShakeByManipulatable(UKuroForceFeedbackEffect gamepadShakeAsset)
		{
			FName? dynamicFName = FNameUtil.GetDynamicFName("Manipulatable_GamepadShake");
			if (dynamicFName == null)
			{
				return;
			}
			this.PlayKuroForceFeedback(gamepadShakeAsset, new FName?(dynamicFName.Value), false, false, false, null);
		}

		// Token: 0x0603C08B RID: 245899 RVA: 0x00F3AA84 File Offset: 0x00F38C84
		public void StopManipulatableGamepadShake(UKuroForceFeedbackEffect gamepadShakeAsset)
		{
			FName? dynamicFName = FNameUtil.GetDynamicFName("Manipulatable_GamepadShake");
			if (dynamicFName == null)
			{
				return;
			}
			GamepadController.StopKuroForceFeedback(gamepadShakeAsset, dynamicFName.Value);
		}

		// Token: 0x0603C08C RID: 245900 RVA: 0x00F3AAB4 File Offset: 0x00F38CB4
		[NullableContext(2)]
		public static void StopKuroForceFeedback(UKuroForceFeedbackEffect forceFeedbackEffect, FName tag)
		{
			TsCharacterController tsCharacterController = Global.PlayerController as TsCharacterController;
			if (tsCharacterController != null)
			{
				tsCharacterController.StopKuroForceFeedback(forceFeedbackEffect, tag);
			}
		}

		// Token: 0x0603C08D RID: 245901 RVA: 0x00F3AAD8 File Offset: 0x00F38CD8
		public UniTask TriggerGamepadShakeEvent(IGamepadShakeOptions config, [Nullable(2)] IStopGamepadShake stopGamepadShakeParam = null)
		{
			GamepadController.<TriggerGamepadShakeEvent>d__27 <TriggerGamepadShakeEvent>d__;
			<TriggerGamepadShakeEvent>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<TriggerGamepadShakeEvent>d__.<>4__this = this;
			<TriggerGamepadShakeEvent>d__.config = config;
			<TriggerGamepadShakeEvent>d__.stopGamepadShakeParam = stopGamepadShakeParam;
			<TriggerGamepadShakeEvent>d__.<>1__state = -1;
			<TriggerGamepadShakeEvent>d__.<>t__builder.Start<GamepadController.<TriggerGamepadShakeEvent>d__27>(ref <TriggerGamepadShakeEvent>d__);
			return <TriggerGamepadShakeEvent>d__.<>t__builder.Task;
		}

		// Token: 0x0603C08E RID: 245902 RVA: 0x00F3AB2C File Offset: 0x00F38D2C
		private void TriggerMp4GamepadShake(UKuroForceFeedbackEffect asset, IMp4GamepadShake mp4Config, IStopGamepadShake stopGamepadShake)
		{
			GamepadController.<>c__DisplayClass28_0 CS$<>8__locals1 = new GamepadController.<>c__DisplayClass28_0();
			CS$<>8__locals1.<>4__this = this;
			stopGamepadShake.Tag = FNameUtil.GetDynamicFName("LevelEventTriggerGamepadShake").Value;
			CS$<>8__locals1.shakeScale = mp4Config.ShakeScale.GetValueOrDefault(1f);
			CS$<>8__locals1.assetDuration = asset.Duration;
			GamepadController.<>c__DisplayClass28_0 CS$<>8__locals2 = CS$<>8__locals1;
			IMp4GamepadShakeFadeInConfig fadeInConfig = mp4Config.FadeInConfig;
			CS$<>8__locals2.fadeInTime = ((fadeInConfig != null) ? fadeInConfig.FadeInTime : null).GetValueOrDefault();
			GamepadController.<>c__DisplayClass28_0 CS$<>8__locals3 = CS$<>8__locals1;
			IMp4GamepadShakeFadeOutConfig fadeOutConfig = mp4Config.FadeOutConfig;
			CS$<>8__locals3.fadeOutTime = ((fadeOutConfig != null) ? fadeOutConfig.FadeOutTime : null).GetValueOrDefault();
			GamepadController.<>c__DisplayClass28_0 CS$<>8__locals4 = CS$<>8__locals1;
			IMp4GamepadShakeFadeInConfig fadeInConfig2 = mp4Config.FadeInConfig;
			CS$<>8__locals4.fadeInCurve = ((fadeInConfig2 != null) ? fadeInConfig2.FadeInCurve : null).GetValueOrDefault(EMp4GamepadShakeCurve.InSine);
			GamepadController.<>c__DisplayClass28_0 CS$<>8__locals5 = CS$<>8__locals1;
			IMp4GamepadShakeFadeOutConfig fadeOutConfig2 = mp4Config.FadeOutConfig;
			CS$<>8__locals5.fadeOutCurve = ((fadeOutConfig2 != null) ? fadeOutConfig2.FadeOutCurve : null).GetValueOrDefault(EMp4GamepadShakeCurve.OutSine);
			bool flag = (CS$<>8__locals1.fadeInTime > 0f || CS$<>8__locals1.fadeOutTime > 0f) && CS$<>8__locals1.assetDuration > 0f;
			stopGamepadShake.FeedbackComponent = UGameplayStatics.D_SpawnForceFeedbackAtLocation(GlobalData.World, asset, global::Vector.ZeroVectorDouble, Rotator.ZeroRotator, false, (flag && CS$<>8__locals1.fadeInTime > 0f) ? 0f : CS$<>8__locals1.shakeScale, 0f, null, true);
			UForceFeedbackComponent feedbackComponent = stopGamepadShake.FeedbackComponent;
			if (feedbackComponent == null || !feedbackComponent.IsValid())
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.YSQ, "执行行为LevelEventTriggerGamepadShake失败，MP4手柄震动创建FeedbackComponent失败", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (!flag)
			{
				return;
			}
			CS$<>8__locals1.component = stopGamepadShake.FeedbackComponent;
			CS$<>8__locals1.startMs = TimerSystem.Instance.Now;
			TimerSystem.Instance.Delay(new TTimerAction(CS$<>8__locals1.<TriggerMp4GamepadShake>g__tick|0), 50f, null, null, true, 1f);
		}

		// Token: 0x0603C08F RID: 245903 RVA: 0x00F3AD10 File Offset: 0x00F38F10
		private float GetMp4FadeEasedValue(EMp4GamepadShakeCurve curve, float t)
		{
			float num = Math.Clamp(t, 0f, 1f);
			switch (curve)
			{
			case EMp4GamepadShakeCurve.InSine:
				return 1f - MathF.Cos(num * 3.1415927f / 2f);
			case EMp4GamepadShakeCurve.OutSine:
				return MathF.Sin(num * 3.1415927f / 2f);
			}
			return num;
		}

		// Token: 0x0603C090 RID: 245904 RVA: 0x00F3AD70 File Offset: 0x00F38F70
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		public UniTask<UKuroForceFeedbackEffect> LoadGamepadShakeAsset(string path)
		{
			GamepadController.<LoadGamepadShakeAsset>d__30 <LoadGamepadShakeAsset>d__;
			<LoadGamepadShakeAsset>d__.<>t__builder = AsyncUniTaskMethodBuilder<UKuroForceFeedbackEffect>.Create();
			<LoadGamepadShakeAsset>d__.path = path;
			<LoadGamepadShakeAsset>d__.<>1__state = -1;
			<LoadGamepadShakeAsset>d__.<>t__builder.Start<GamepadController.<LoadGamepadShakeAsset>d__30>(ref <LoadGamepadShakeAsset>d__);
			return <LoadGamepadShakeAsset>d__.<>t__builder.Task;
		}

		// Token: 0x0603C091 RID: 245905 RVA: 0x00F3ADB4 File Offset: 0x00F38FB4
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		private UniTask<UForceFeedbackAttenuation> LoadFeedbackAttenuationAsset(string path)
		{
			GamepadController.<LoadFeedbackAttenuationAsset>d__31 <LoadFeedbackAttenuationAsset>d__;
			<LoadFeedbackAttenuationAsset>d__.<>t__builder = AsyncUniTaskMethodBuilder<UForceFeedbackAttenuation>.Create();
			<LoadFeedbackAttenuationAsset>d__.path = path;
			<LoadFeedbackAttenuationAsset>d__.<>1__state = -1;
			<LoadFeedbackAttenuationAsset>d__.<>t__builder.Start<GamepadController.<LoadFeedbackAttenuationAsset>d__31>(ref <LoadFeedbackAttenuationAsset>d__);
			return <LoadFeedbackAttenuationAsset>d__.<>t__builder.Task;
		}

		// Token: 0x04021B8F RID: 138127
		private const string QTE_GAMEPAD_SHAKE = "Qte_GamepadShake";

		// Token: 0x04021B90 RID: 138128
		private const string MANIPULATABLE_GAMEPAD_SHAKE = "Manipulatable_GamepadShake";

		// Token: 0x04021B91 RID: 138129
		private const string LEVELEVENT_GAMEPAD_SHAKE = "LevelEventTriggerGamepadShake";

		// Token: 0x04021B92 RID: 138130
		private const float MP4_GAMEPAD_SHAKE_TICK_MS = 50f;

		// Token: 0x04021B93 RID: 138131
		private List<string> HitForceFeedbackPaths = new List<string>();

		// Token: 0x04021B94 RID: 138132
		private List<UKuroForceFeedbackEffect> HitForceFeedbackEffects = new List<UKuroForceFeedbackEffect>();

		// Token: 0x04021B95 RID: 138133
		private GamepadPsFeedbackData GamepadPsFeedbackData = new GamepadPsFeedbackData();

		// Token: 0x04021B96 RID: 138134
		private GamepadPsFeedbackModule GamepadPsFeedbackLoadModule = new GamepadPsFeedbackModule();

		// Token: 0x04021B97 RID: 138135
		private GamepadPsFeedbackListenTagModule GamepadPsFeedbackListenTagModule = new GamepadPsFeedbackListenTagModule();

		// Token: 0x04021B98 RID: 138136
		private int GamepadActorIndex;
	}
}
