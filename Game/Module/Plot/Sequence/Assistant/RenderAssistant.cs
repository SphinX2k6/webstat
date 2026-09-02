using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Sequence.Manager;
using CSharpScript.Core.Common;
using CSharpScript.Game.GameSettings;
using CSharpScript.Game.Render;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.Sequence.Assistant
{
	// Token: 0x020053A4 RID: 21412
	[NullableContext(2)]
	[Nullable(0)]
	public class RenderAssistant : SeqBaseAssistant
	{
		// Token: 0x060369AB RID: 223659 RVA: 0x00DD17CC File Offset: 0x00DCF9CC
		public override void PreAllPlay(Action<bool> callback = null)
		{
			this.IsEnableMobileKuroSpotlightsShadow = UKismetSystemLibrary.GetConsoleVariableFloatValue("r.Mobile.EnableKuroSpotlightsShadow");
			RenderUtil.CloseToonSceneShadow();
			RenderUtil.OpenMobileSpotLightShadow();
			if (!this.Model.IsControlEntity)
			{
				Singleton<GameSettingsDeviceRender>.Instance.SetSequenceFrameRateLimit();
			}
			if (Singleton<Info>.Instance.IsLowMemoryDevice)
			{
				int value = UStreamableRenderAsset.EncodeStreamingLODBiasMapping(0, 0, 0, 3, 4);
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(47, 1);
				defaultInterpolatedStringHandler.AppendLiteral("r.Streaming.RuntimeLODBiasDeviceMappingIndices ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(value);
				UKuroSequencePerformanceManager.SimpleExecuteCommand(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			if (Singleton<Info>.Instance.IsPcOrGamepadPlatform())
			{
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.Kuro.AutoExposure 0", null);
			}
			this.Model.PreviousMotionBlur = new float?(UKismetSystemLibrary.GetConsoleVariableFloatValue("r.MotionBlur.Amount"));
			float? previousMotionBlur = this.Model.PreviousMotionBlur;
			float num = 0f;
			if (!(previousMotionBlur.GetValueOrDefault() == num & previousMotionBlur != null))
			{
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.MotionBlur.Amount 0", null);
			}
			UKismetMaterialLibrary.SetScalarParameterValue(GlobalData.World, Singleton<RenderDataManager>.Instance.GetEyesParameterMaterialParameterCollection(), this.EyesLightName, 0f);
			Singleton<GameSettingsDeviceRender>.Instance.TemporaryDisableFrameGeneration("PrePlaySequence");
			ULevelSequence currentSequence = this.Model.GetCurrentSequence();
			UKuroSequencePerformanceManager.OpenKuroPerformanceMode(currentSequence);
			if (UKuroStaticLibrary.GetEnableMobileLowStreaming(currentSequence))
			{
				float? num2;
				if (currentSequence == null)
				{
					num2 = null;
				}
				else
				{
					UKuroSequenceConsoleCommandDataAsset sequenceDataAsset = currentSequence.SequenceDataAsset;
					num2 = ((sequenceDataAsset != null) ? new float?(sequenceDataAsset.MobileLowStreamingScale) : null);
				}
				float? num3 = num2;
				if (num3 != null)
				{
					ModelBase<GameModeModel>.Instance.ScaleStreamingSource(EStreamingSourceScaleType.Plot, num3.Value);
				}
			}
			if (PerfSightController.IsEnable)
			{
				UPerfSightHelper.PostEvent(819, UKuroSequencePerformanceManager.GetPerformanceMode().ToString());
			}
			this.IsAllSet = true;
			int? currentValue = Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.METALFX, true, true);
			EPlotSequenceType? type = this.Model.GetType();
			EPlotSequenceType eplotSequenceType = EPlotSequenceType.过场;
			if ((type.GetValueOrDefault() == eplotSequenceType & type != null) && Singleton<GameSettingsDeviceRender>.Instance.IsMetalFxDevice() && currentValue != null)
			{
				int? num4 = currentValue;
				int num5 = 0;
				if (num4.GetValueOrDefault() > num5 & num4 != null)
				{
					this.IsMuteMetalFxDevice = true;
					GameSettingsUtils.ApplyMetalFxEnable(0);
				}
			}
		}

		// Token: 0x060369AC RID: 223660 RVA: 0x00DD19EC File Offset: 0x00DCFBEC
		public override void PreEachPlay()
		{
			this.IsEachSet = true;
		}

		// Token: 0x060369AD RID: 223661 RVA: 0x00DD19F5 File Offset: 0x00DCFBF5
		public override void EachStop()
		{
			this.IsEachSet = false;
		}

		// Token: 0x060369AE RID: 223662 RVA: 0x00DD1A00 File Offset: 0x00DCFC00
		public override void AllStop(Action<bool> callback = null)
		{
			RenderUtil.OpenToonSceneShadow();
			UObject world = GlobalData.World;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(36, 1);
			defaultInterpolatedStringHandler.AppendLiteral("r.Mobile.EnableKuroSpotlightsShadow ");
			defaultInterpolatedStringHandler.AppendFormatted<float>(this.IsEnableMobileKuroSpotlightsShadow);
			UKismetSystemLibrary.ExecuteConsoleCommand(world, defaultInterpolatedStringHandler.ToStringAndClear(), null);
			if (Singleton<Info>.Instance.IsLowMemoryDevice)
			{
				int value = UStreamableRenderAsset.EncodeStreamingLODBiasMapping(0, 1, 2, 3, 4);
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(47, 1);
				defaultInterpolatedStringHandler.AppendLiteral("r.Streaming.RuntimeLODBiasDeviceMappingIndices ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(value);
				UKuroSequencePerformanceManager.SimpleExecuteCommand(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			if (!this.Model.IsControlEntity)
			{
				Singleton<GameSettingsDeviceRender>.Instance.CancleSequenceFrameRateLimit();
			}
			if (Singleton<Info>.Instance.IsPcOrGamepadPlatform())
			{
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.Kuro.AutoExposure 1", null);
			}
			float? previousMotionBlur = this.Model.PreviousMotionBlur;
			float num = 0f;
			if (!(previousMotionBlur.GetValueOrDefault() == num & previousMotionBlur != null))
			{
				UObject world2 = GlobalData.World;
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(20, 1);
				defaultInterpolatedStringHandler.AppendLiteral("r.MotionBlur.Amount ");
				defaultInterpolatedStringHandler.AppendFormatted<float?>(this.Model.PreviousMotionBlur);
				UKismetSystemLibrary.ExecuteConsoleCommand(world2, defaultInterpolatedStringHandler.ToStringAndClear(), null);
			}
			UKismetMaterialLibrary.SetScalarParameterValue(GlobalData.World, Singleton<RenderDataManager>.Instance.GetEyesParameterMaterialParameterCollection(), this.EyesLightName, 1f);
			Singleton<GameSettingsDeviceRender>.Instance.CancelTemporaryDisableFrameGeneration("PrePlaySequence");
			UKuroSequencePerformanceManager.CloseKuroPerformanceMode();
			ModelBase<GameModeModel>.Instance.CleanScaleStreamingSource(EStreamingSourceScaleType.Plot);
			if (PerfSightController.IsEnable)
			{
				UPerfSightHelper.PostEvent(819, UKuroSequencePerformanceManager.GetPerformanceMode().ToString());
			}
			this.ReleaseSeqStreamingData();
			if (this.IsMuteMetalFxDevice)
			{
				this.IsMuteMetalFxDevice = false;
				GameSettingsUtils.ApplyMetalFxEnable(1);
			}
			this.IsAllSet = false;
		}

		// Token: 0x060369AF RID: 223663 RVA: 0x00DD1BA1 File Offset: 0x00DCFDA1
		public override void End()
		{
			if (this.IsEachSet)
			{
				this.EachStop();
			}
			if (this.IsAllSet)
			{
				this.AllStop(null);
			}
		}

		// Token: 0x060369B0 RID: 223664 RVA: 0x00DD1BC0 File Offset: 0x00DCFDC0
		public bool CheckSeqStreamingData()
		{
			bool result = true;
			if (!SequenceRenderSettings.GetTexureStreamingEnable((EGameQualitySettingLevel)((Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.IMAGEQUALITY, true, true) != null) ? Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.IMAGEQUALITY, true, true).Value : 2)))
			{
				Singleton<Log>.Instance.Info(ELogModule.Plot, ELogAuthor.YZH, "当前画质等级不开启纹理流送", default(ReadOnlySpan<ValueTuple<string, object>>));
				return result;
			}
			BP_SequenceData_C sequenceData = this.Model.SequenceData;
			bool gmForceCollectExtraTexture = ControllerBase<SequenceController>.Instance.GmForceCollectExtraTexture;
			for (int i = 0; i < sequenceData.剧情资源.Num(); i++)
			{
				ULevelSequence levelSequences = sequenceData.剧情资源.Get(i);
				bool bCollectExtraTexture = sequenceData.CollectExtraTexture || gmForceCollectExtraTexture;
				if (!UKuroSequenceRuntimeFunctionLibrary.HandleSeqTexStreaming(levelSequences, true, bCollectExtraTexture))
				{
					result = false;
				}
			}
			if (!this.Model.DoNotHandlePlayerForControlEntityMode && this.Model.SequenceData.NeedSwitchMainCharacter && this.Model.MainSeqCharacterMesh != null && !UKuroMeshTextureFunctionLibrary.IsSkeletalMeshComponentStreamingComplete(this.Model.MainSeqCharacterMesh))
			{
				result = false;
			}
			return result;
		}

		// Token: 0x060369B1 RID: 223665 RVA: 0x00DD1CBC File Offset: 0x00DCFEBC
		public void ReleaseSeqStreamingData()
		{
			if (!SequenceRenderSettings.GetTexureStreamingEnable((EGameQualitySettingLevel)((Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.IMAGEQUALITY, true, true) != null) ? Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.IMAGEQUALITY, true, true).Value : 2)))
			{
				Singleton<Log>.Instance.Info(ELogModule.Plot, ELogAuthor.YZH, "当前画质等级不开启纹理流送", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			BP_SequenceData_C sequenceData = this.Model.SequenceData;
			bool gmForceCollectExtraTexture = ControllerBase<SequenceController>.Instance.GmForceCollectExtraTexture;
			for (int i = 0; i < sequenceData.剧情资源.Num(); i++)
			{
				ULevelSequence levelSequences = sequenceData.剧情资源.Get(i);
				bool bCollectExtraTexture = sequenceData.CollectExtraTexture || gmForceCollectExtraTexture;
				UKuroSequenceRuntimeFunctionLibrary.HandleSeqTexStreaming(levelSequences, false, bCollectExtraTexture);
			}
			if (!this.Model.DoNotHandlePlayerForControlEntityMode && this.Model.SequenceData.NeedSwitchMainCharacter && this.Model.MainSeqCharacterMesh != null)
			{
				UKuroMeshTextureFunctionLibrary.HandleSkeletalMeshComponentStreaming(this.Model.MainSeqCharacterMesh, false);
			}
		}

		// Token: 0x060369B2 RID: 223666 RVA: 0x00DD1DAB File Offset: 0x00DCFFAB
		public void SetMotionBlurState(bool isEnable)
		{
			if (isEnable)
			{
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.MotionBlurQuality 4", null);
				return;
			}
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.MotionBlurQuality 0", null);
		}

		// Token: 0x060369B3 RID: 223667 RVA: 0x00DD1DD1 File Offset: 0x00DCFFD1
		public override void CmdShadowUpdate()
		{
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.Shadow.CacheMode3CacheUpdateIntervalsOverride 0,0,0", null);
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.Shadow.CSMMode3EnableUpdateIntervalOverride 1", null);
		}

		// Token: 0x0401F735 RID: 128821
		private bool IsEachSet;

		// Token: 0x0401F736 RID: 128822
		private bool IsAllSet;

		// Token: 0x0401F737 RID: 128823
		private readonly FName EyesLightName = new FName("LightDisableSwitch");

		// Token: 0x0401F738 RID: 128824
		private float IsEnableMobileKuroSpotlightsShadow;

		// Token: 0x0401F739 RID: 128825
		private bool IsMuteMetalFxDevice;
	}
}
