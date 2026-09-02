using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.InputSetting;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.RoleLangCustomModel;
using CSharpScript.Game.Render;
using CSharpScript.Typing;
using UnrealEngine;
using UnrealEngine.Extension;

namespace CSharpScript.Game.GameSettings
{
	// Token: 0x0200701D RID: 28701
	[NullableContext(1)]
	[Nullable(0)]
	public class GameSettingsUtils : IStaticVariableResetter
	{
		// Token: 0x060457C0 RID: 284608 RVA: 0x01229ED8 File Offset: 0x012280D8
		static GameSettingsUtils()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(GameSettingsUtils.CreateStaticDefaultValue), new Action(GameSettingsUtils.ResetStaticDefaultValue));
		}

		// Token: 0x060457C1 RID: 284609 RVA: 0x01229EF8 File Offset: 0x012280F8
		public static void CreateStaticDefaultValue()
		{
			GameSettingsUtils.Fsr3FgSwitchStates = new Dictionary<int, int>
			{
				{
					0,
					0
				},
				{
					1,
					0
				},
				{
					3,
					0
				},
				{
					4,
					0
				}
			};
			GameSettingsUtils.GrassCullDistanceCache = null;
			GameSettingsUtils.GrassMobileCullDistanceCache = null;
			GameSettingsUtils.GrassLODDistanceScaleCache = null;
		}

		// Token: 0x060457C2 RID: 284610 RVA: 0x01229F50 File Offset: 0x01228150
		public static void ResetStaticDefaultValue()
		{
			GameSettingsUtils.NvidiaSuperSamplingQualityCache = null;
			GameSettingsUtils.KuroLocalRenderSettingIndexCache = null;
			GameSettingsUtils.XessEnabled = false;
			GameSettingsUtils.Fsr3FgEnable = false;
			GameSettingsUtils.Fsr3FgApplyMode = EFFXFIApplyMode.Default;
			GameSettingsUtils.Fsr3FgInTemporaryApplyState = false;
			GameSettingsUtils.Fsr3FgSwitchStates = null;
			GameSettingsUtils.GrassCullDistanceCache = null;
			GameSettingsUtils.GrassMobileCullDistanceCache = null;
			GameSettingsUtils.GrassLODDistanceScaleCache = null;
		}

		// Token: 0x060457C3 RID: 284611 RVA: 0x01229FB4 File Offset: 0x012281B4
		public static bool ApplyVolume(float value, string volumeTag)
		{
			UAkGameplayStatics.SetRTPCValue(null, value, 0, null, FNameUtil.GetDynamicFName(volumeTag).Value);
			return true;
		}

		// Token: 0x060457C4 RID: 284612 RVA: 0x01229FDC File Offset: 0x012281DC
		private static int GetRTRCCycleFrameCount(int value)
		{
			switch (value)
			{
			case 0:
				return 720;
			case 1:
				return 600;
			case 2:
				return 480;
			case 3:
				return 240;
			case 4:
				return 120;
			case 5:
				return 60;
			default:
				return 60;
			}
		}

		// Token: 0x060457C5 RID: 284613 RVA: 0x0122A02C File Offset: 0x0122822C
		public unsafe static bool ApplyImageQualityOnly(int value)
		{
			if (UKuroRenderingRuntimeBPPluginBPLibrary.GetCVarFloat("r.Kuro.Movie.EnableCGMovieRendering") > 0f)
			{
				Singleton<Log>.Instance.Info(ELogModule.Render, ELogAuthor.HCS, "当前在movie 渲染模式下不应用配置", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			if (PerfSightController.IsEnable)
			{
				UPerfSightHelper.PostEvent(800, value.ToString());
				UPerfSightHelper.PostEvent(814, Singleton<GameSettingsDeviceRender>.Instance.GetD3D12Type().ToString());
				UPerfSightHelper.PostEvent(815, Singleton<GameSettingsDeviceRender>.Instance.CPUFrequency.ToString());
				UPerfSightHelper.PostEvent(816, Singleton<GameSettingsDeviceRender>.Instance.CPUCoresIncludingHyperthreads.ToString());
				UPerfSightHelper.PostEvent(825, Singleton<GameSettingsDeviceRender>.Instance.IsVulkanRHI().ToString());
			}
			FCrashSightProxy.SetCustomData("DX12", Singleton<GameSettingsDeviceRender>.Instance.GetD3D12Type().ToString());
			FCrashSightProxy.SetCustomData("Vulkan", Singleton<GameSettingsDeviceRender>.Instance.IsVulkanRHI().ToString());
			UGameUserSettings gameUserSettings = UGameUserSettings.GetGameUserSettings();
			if (gameUserSettings == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.GameSettings;
				ELogAuthor author = ELogAuthor.WZ;
				string message = "GetGameUserSettings失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("qualityLevel", value);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			bool flag = Singleton<Info>.Instance.IsPcOrGamepadPlatform();
			bool flag2 = Singleton<Info>.Instance.IsMobilePlatform();
			bool flag3 = Singleton<Info>.Instance.IsPs5Platform() || (Singleton<Info>.Instance.IsXboxPlatform() && !Singleton<Info>.Instance.IsWinGDKPlatform());
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.GameSettings;
			ELogAuthor author2 = ELogAuthor.WZ;
			string message2 = "ApplyImageQualityOnly: ";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("isPcOrGamepadPlatform", flag.ToString());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("isMobilePlatform", flag2.ToString());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("isSingleImageQualityOption", flag3.ToString());
			instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			if (flag)
			{
				if (flag3)
				{
					int num;
					if (value == 3)
					{
						num = 1;
					}
					else
					{
						num = 0;
					}
					Log instance3 = Singleton<Log>.Instance;
					ELogModule module3 = ELogModule.GameSettings;
					ELogAuthor author3 = ELogAuthor.ZYT;
					string message3 = "优先应用的画质等级[done]@[PS5/XSX]";
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("PS5/XSX quality level", num);
					instance3.Info(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
					gameUserSettings.SetGameQualitySettingLevel((float)num);
				}
				else
				{
					gameUserSettings.SetGameQualitySettingLevel((float)value);
					if (Singleton<Info>.Instance.IsMacPlatform())
					{
						if (value > 2)
						{
							UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.ScreenPercentage 70", null);
						}
						else if (value == 2)
						{
							UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.ScreenPercentage 65", null);
						}
						else if (value == 1)
						{
							UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.ScreenPercentage 60", null);
						}
						else if (value == 0)
						{
							UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.ScreenPercentage 55", null);
						}
					}
					Log instance4 = Singleton<Log>.Instance;
					ELogModule module4 = ELogModule.GameSettings;
					ELogAuthor author4 = ELogAuthor.WZ;
					string message4 = "优先应用的画质等级[done]@[Pc或手柄平台]";
					ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("quality level", value);
					instance4.Info(module4, author4, message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
				}
				gameUserSettings.ApplySettings(true);
				if (Singleton<Info>.Instance.IsWindowsPlatform())
				{
					UObject world = GlobalData.World;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(22, 1);
					defaultInterpolatedStringHandler.AppendLiteral("r.RTRCCycleFrameCount ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(GameSettingsUtils.GetRTRCCycleFrameCount(value));
					UKismetSystemLibrary.ExecuteConsoleCommand(world, defaultInterpolatedStringHandler.ToStringAndClear(), null);
				}
			}
			else if (flag2)
			{
				gameUserSettings.SetMobileGameQualitySettingLevel((float)value);
				Log instance5 = Singleton<Log>.Instance;
				ELogModule module5 = ELogModule.GameSettings;
				ELogAuthor author5 = ELogAuthor.WZ;
				string message5 = "优先应用的画质等级[done]@[移动端平台]";
				ValueTuple<string, object> valueTuple4 = new ValueTuple<string, object>("quality level", value);
				instance5.Info(module5, author5, message5, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple4));
			}
			GameSettingsUtils.ReApplyMaterialQualityLevel(new int?(value));
			GameSettingsUtils.GrassCullDistanceCache = new float?(UKismetSystemLibrary.GetConsoleVariableFloatValue("r.Kuro.Foliage.GrassCullDistanceMax"));
			GameSettingsUtils.GrassMobileCullDistanceCache = new float?(UKismetSystemLibrary.GetConsoleVariableFloatValue("r.Kuro.Foliage.MobileGrassCullDistanceMax"));
			GameSettingsUtils.GrassLODDistanceScaleCache = new float?(UKismetSystemLibrary.GetConsoleVariableFloatValue("foliage.LODDistanceScale"));
			return true;
		}

		// Token: 0x060457C6 RID: 284614 RVA: 0x0122A3E0 File Offset: 0x012285E0
		public static void SetIsCustomImageQuality(bool value)
		{
			LocalStorage.SetGlobal<bool>(ELocalStorageGlobalKey.IsCustomImageQuality, value);
		}

		// Token: 0x060457C7 RID: 284615 RVA: 0x0122A3EC File Offset: 0x012285EC
		public static bool ReApplyMaterialQualityLevel(int? value = null)
		{
			int? num = value;
			int? num2 = (num != null) ? num : Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.IMAGEQUALITY, true, true);
			if (num2 == null)
			{
				return false;
			}
			UKismetMaterialLibrary.SetScalarParameterValue(GlobalData.World, Singleton<RenderDataManager>.Instance.GetGlobalShaderParameters(), new FName("KuroMaterialQualityLevel"), (float)num2.Value);
			return true;
		}

		// Token: 0x060457C8 RID: 284616 RVA: 0x0122A448 File Offset: 0x01228648
		public static bool ApplyShadowQuality(int value)
		{
			UObject world = GlobalData.World;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(17, 1);
			defaultInterpolatedStringHandler.AppendLiteral("sg.ShadowQuality ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(value);
			UKismetSystemLibrary.ExecuteConsoleCommand(world, defaultInterpolatedStringHandler.ToStringAndClear(), null);
			Singleton<GameSettingsManager>.Instance.ReApply(EFunction.SCENEAO, EGameSettingsApplyReason.AnyTime, true);
			if (PerfSightController.IsEnable)
			{
				UPerfSightHelper.PostEvent(808, value.ToString());
			}
			return true;
		}

		// Token: 0x060457C9 RID: 284617 RVA: 0x0122A4B0 File Offset: 0x012286B0
		public static bool ApplyDisplayMode(int value)
		{
			EWindowMode[] array = new EWindowMode[]
			{
				EWindowMode.WindowedFullscreen,
				EWindowMode.Windowed
			};
			int num = Singleton<MathUtils>.Instance.Clamp(value, 0, array.Length - 1);
			EWindowMode fullscreenMode = array[num];
			UGameUserSettings gameUserSettings = UGameUserSettings.GetGameUserSettings();
			gameUserSettings.SetFullscreenMode(fullscreenMode);
			gameUserSettings.ApplySettings(true);
			Singleton<EventSystem>.Instance.Emit(EEventName.SetDisplayMode);
			return true;
		}

		// Token: 0x060457CA RID: 284618 RVA: 0x0122A508 File Offset: 0x01228708
		public static bool ApplyResolution(int value)
		{
			FIntPoint resolutionByList = Singleton<GameSettingsDeviceRender>.Instance.GetResolutionByList(value);
			UGameUserSettings gameUserSettings = UGameUserSettings.GetGameUserSettings();
			gameUserSettings.SetScreenResolution(resolutionByList);
			gameUserSettings.ApplySettings(true);
			if (PerfSightController.IsEnable)
			{
				int num = 1;
				if (resolutionByList.X > 4000)
				{
					num = 4;
				}
				else if (resolutionByList.X > 3000)
				{
					num = 3;
				}
				else if (resolutionByList.X > 2000)
				{
					num = 2;
				}
				UPerfSightHelper.PostEvent(803, num.ToString());
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.SetResolution);
			return true;
		}

		// Token: 0x060457CB RID: 284619 RVA: 0x0122A590 File Offset: 0x01228790
		public static bool ApplyBrightness(float value)
		{
			float num;
			if (value < 0f)
			{
				num = Singleton<MathUtils>.Instance.Lerp(1.5f, 2.2f, value + 1f);
			}
			else
			{
				num = Singleton<MathUtils>.Instance.Lerp(2.2f, 3.5f, value);
			}
			UObject world = GlobalData.World;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(18, 1);
			defaultInterpolatedStringHandler.AppendLiteral("r.TonemapperGamma ");
			defaultInterpolatedStringHandler.AppendFormatted<float>(num);
			UKismetSystemLibrary.ExecuteConsoleCommand(world, defaultInterpolatedStringHandler.ToStringAndClear(), null);
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.LUT.Regenerate 1", null);
			UKismetMaterialLibrary.SetScalarParameterValue(GlobalData.World, Singleton<RenderDataManager>.Instance.GetUiShowBrightnessMaterialParameterCollection(), RenderConfig.UIShowBrightness, num);
			return true;
		}

		// Token: 0x060457CC RID: 284620 RVA: 0x0122A63C File Offset: 0x0122883C
		public static bool ApplyHighestFps(int value)
		{
			int frameByList = Singleton<GameSettingsDeviceRender>.Instance.GetFrameByList(value);
			Singleton<GameSettingsDeviceRender>.Instance.ApplyFrameRate(frameByList);
			return true;
		}

		// Token: 0x060457CD RID: 284621 RVA: 0x0122A664 File Offset: 0x01228864
		public static bool ApplyNiagaraQuality(int value)
		{
			UGameUserSettings gameUserSettings = UGameUserSettings.GetGameUserSettings();
			if (!Singleton<Info>.Instance.IsPcOrGamepadPlatform())
			{
				bool flag = Singleton<GameSettingsDeviceRender>.Instance.IsIosAndAndroidHighDevice();
				UObject world = GlobalData.World;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(20, 1);
				defaultInterpolatedStringHandler.AppendLiteral("r.DisableDistortion ");
				defaultInterpolatedStringHandler.AppendFormatted<int>((value > 0 && flag) ? 0 : 1);
				UKismetSystemLibrary.ExecuteConsoleCommand(world, defaultInterpolatedStringHandler.ToStringAndClear(), null);
				UObject world2 = GlobalData.World;
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(24, 1);
				defaultInterpolatedStringHandler.AppendLiteral("fx.Niagara.QualityLevel ");
				defaultInterpolatedStringHandler.AppendFormatted<int>((value > 0) ? 1 : 0);
				UKismetSystemLibrary.ExecuteConsoleCommand(world2, defaultInterpolatedStringHandler.ToStringAndClear(), null);
			}
			else
			{
				int value2 = value + 1;
				UObject world3 = GlobalData.World;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(24, 1);
				defaultInterpolatedStringHandler.AppendLiteral("fx.Niagara.QualityLevel ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(value2);
				UKismetSystemLibrary.ExecuteConsoleCommand(world3, defaultInterpolatedStringHandler.ToStringAndClear(), null);
			}
			gameUserSettings.ApplySettings(true);
			if (PerfSightController.IsEnable)
			{
				UPerfSightHelper.PostEvent(807, value.ToString());
			}
			return true;
		}

		// Token: 0x060457CE RID: 284622 RVA: 0x0122A750 File Offset: 0x01228950
		public unsafe static bool ApplyImageDetail(int value)
		{
			if (PerfSightController.IsEnable)
			{
				UPerfSightHelper.PostEvent(805, value.ToString());
			}
			if (!Singleton<Info>.Instance.IsPcOrGamepadPlatform())
			{
				UObject world = GlobalData.World;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(37, 1);
				defaultInterpolatedStringHandler.AppendLiteral("r.Kuro.ToonOutlineDrawDistanceMobile ");
				defaultInterpolatedStringHandler.AppendFormatted<int>((value > 1) ? 500 : 500);
				UKismetSystemLibrary.ExecuteConsoleCommand(world, defaultInterpolatedStringHandler.ToStringAndClear(), null);
				int value2 = Singleton<MathUtils>.Instance.Clamp(value, 0, 2);
				UObject world2 = GlobalData.World;
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(20, 1);
				defaultInterpolatedStringHandler.AppendLiteral("foliage.DensityType ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(value2);
				UKismetSystemLibrary.ExecuteConsoleCommand(world2, defaultInterpolatedStringHandler.ToStringAndClear(), null);
				bool flag = Singleton<GameSettingsDeviceRender>.Instance.IsAndroidPlatformScreenBetter();
				UObject world3 = GlobalData.World;
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(27, 1);
				defaultInterpolatedStringHandler.AppendLiteral("r.Mobile.SceneObjMobileSSR ");
				defaultInterpolatedStringHandler.AppendFormatted<int>((value > 2 && flag) ? 1 : 0);
				UKismetSystemLibrary.ExecuteConsoleCommand(world3, defaultInterpolatedStringHandler.ToStringAndClear(), null);
				bool flag2 = Singleton<GameSettingsDeviceRender>.Instance.IsAndroidPlatformNotLow();
				UObject world4 = GlobalData.World;
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(22, 1);
				defaultInterpolatedStringHandler.AppendLiteral("r.Mobile.TreeRimLight ");
				defaultInterpolatedStringHandler.AppendFormatted<int>((value > 2 && flag2) ? 1 : 0);
				UKismetSystemLibrary.ExecuteConsoleCommand(world4, defaultInterpolatedStringHandler.ToStringAndClear(), null);
				AWorldSettings aworldSettings = GlobalData.World.GetWorld().K2_GetWorldSettings();
				int num = Singleton<MathUtils>.Instance.Clamp(value, 0, 2) + 1;
				if (aworldSettings != null && aworldSettings.bEnableWorldPartition)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.GameSettings;
					ELogAuthor author = ELogAuthor.ZYT;
					string message = "UpdateFoliageDataLayer";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("foliageDataLayerValue", num);
					instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					UKuroRenderingRuntimeBPPluginBPLibrary.UpdateFoliageDataLayer(GlobalData.World, num);
				}
				bool flag3 = flag && Singleton<GameSettingsDeviceRender>.Instance.IsAndroidAdreno();
				UObject world5 = GlobalData.World;
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(20, 1);
				defaultInterpolatedStringHandler.AppendLiteral("r.Kuro.AutoExposure ");
				defaultInterpolatedStringHandler.AppendFormatted<int>((value > 2 && flag3) ? 1 : 0);
				UKismetSystemLibrary.ExecuteConsoleCommand(world5, defaultInterpolatedStringHandler.ToStringAndClear(), null);
				UStreamableRenderAsset.SetKuroStreamingQualityLevel(value);
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.GameSettings;
				ELogAuthor author2 = ELogAuthor.LQX;
				string message2 = "SetKuroStreamingQualityLevel";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("streamingQualityLevel", value);
				instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			}
			else
			{
				UObject world6 = GlobalData.World;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(33, 1);
				defaultInterpolatedStringHandler.AppendLiteral("r.Kuro.ToonOutlineDrawDistancePc ");
				defaultInterpolatedStringHandler.AppendFormatted<int>((value > 1) ? 4000 : 2000);
				UKismetSystemLibrary.ExecuteConsoleCommand(world6, defaultInterpolatedStringHandler.ToStringAndClear(), null);
				int videoMemoryGB = UKuroStaticLibrary.GetVideoMemoryGB();
				int num2;
				if (videoMemoryGB <= 2)
				{
					num2 = ((value < 2) ? 0 : (value - 1));
				}
				else
				{
					num2 = ((value == 0) ? 0 : (value + 1));
				}
				UStreamableRenderAsset.SetKuroStreamingQualityLevel(num2);
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.GameSettings;
				ELogAuthor author3 = ELogAuthor.LQX;
				string message3 = "SetKuroStreamingQualityLevel";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("videoMemoryGB", videoMemoryGB);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("streamingQualityLevel", num2);
				instance3.Info(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			return true;
		}

		// Token: 0x060457CF RID: 284623 RVA: 0x0122AA54 File Offset: 0x01228C54
		public static bool ApplyAntiAliasing(int value)
		{
			if (!Singleton<Info>.Instance.IsPcOrGamepadPlatform())
			{
				UObject world = GlobalData.World;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(30, 1);
				defaultInterpolatedStringHandler.AppendLiteral("r.DefaultFeature.AntiAliasing ");
				defaultInterpolatedStringHandler.AppendFormatted<int>((value == 0) ? 0 : 2);
				UKismetSystemLibrary.ExecuteConsoleCommand(world, defaultInterpolatedStringHandler.ToStringAndClear(), null);
			}
			else
			{
				UObject world2 = GlobalData.World;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(30, 1);
				defaultInterpolatedStringHandler.AppendLiteral("r.DefaultFeature.AntiAliasing ");
				defaultInterpolatedStringHandler.AppendFormatted<int>((value == 0) ? 0 : 2);
				UKismetSystemLibrary.ExecuteConsoleCommand(world2, defaultInterpolatedStringHandler.ToStringAndClear(), null);
			}
			if (PerfSightController.IsEnable)
			{
				UPerfSightHelper.PostEvent(802, value.ToString());
			}
			return true;
		}

		// Token: 0x060457D0 RID: 284624 RVA: 0x0122AAF4 File Offset: 0x01228CF4
		public static bool ApplySceneAo(int value)
		{
			if (Singleton<Info>.Instance.IsPcOrGamepadPlatform())
			{
				int value2 = (value > 0) ? -1 : 0;
				UObject world = GlobalData.World;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(25, 1);
				defaultInterpolatedStringHandler.AppendLiteral("r.AmbientOcclusionLevels ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(value2);
				UKismetSystemLibrary.ExecuteConsoleCommand(world, defaultInterpolatedStringHandler.ToStringAndClear(), null);
				Singleton<RenderDataManager>.Instance.SetGrassAo((float)value);
				if (value > 1)
				{
					UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.DistanceFieldAO 1", null);
					UObject world2 = GlobalData.World;
					defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(25, 1);
					defaultInterpolatedStringHandler.AppendLiteral("r.DistanceFieldAOQuality ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(value);
					UKismetSystemLibrary.ExecuteConsoleCommand(world2, defaultInterpolatedStringHandler.ToStringAndClear(), null);
				}
				else
				{
					UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.DistanceFieldAO 0", null);
				}
				if (PerfSightController.IsEnable)
				{
					UPerfSightHelper.PostEvent(810, value.ToString());
				}
			}
			else
			{
				bool flag = Singleton<GameSettingsDeviceRender>.Instance.IsAndroidPlatformAOValid() || Singleton<GameSettingsDeviceRender>.Instance.IsIOSPlatformAOValid();
				int? currentValue = Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.SHADOWQUALITY, true, true);
				if (currentValue == null)
				{
					Singleton<Log>.Instance.Error(ELogModule.GameSettings, ELogAuthor.WZ, "【移动端】设定场景AO时，不能获得阴影质量保存值", default(ReadOnlySpan<ValueTuple<string, object>>));
					return false;
				}
				int num = (currentValue.Value > 0 && flag) ? value : 0;
				UObject world3 = GlobalData.World;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(14, 1);
				defaultInterpolatedStringHandler.AppendLiteral("r.Mobile.SSAO ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(num);
				UKismetSystemLibrary.ExecuteConsoleCommand(world3, defaultInterpolatedStringHandler.ToStringAndClear(), null);
				UKismetMaterialLibrary.SetScalarParameterValue(GlobalData.World, Singleton<RenderDataManager>.Instance.GetGlobalShaderParameters(), new FName("EnableMobileScreenAO"), (float)num);
				Singleton<RenderDataManager>.Instance.SetGrassAo((float)num);
				if (PerfSightController.IsEnable)
				{
					UPerfSightHelper.PostEvent(810, num.ToString());
				}
			}
			return true;
		}

		// Token: 0x060457D1 RID: 284625 RVA: 0x0122ACAC File Offset: 0x01228EAC
		public static bool ApplyNpcDensity(int value)
		{
			int num = value;
			int kuroRenderQualityLocalIndex = ControllerBase<GameSettingsController>.Instance.KuroRenderQualityLocalIndex;
			if (kuroRenderQualityLocalIndex >= 30 && kuroRenderQualityLocalIndex <= 39 && num > 1)
			{
				num = 1;
				Singleton<Log>.Instance.Info(ELogModule.GameSettings, ELogAuthor.ZYT, "KuroLocalRenderSettingIndex Change npcDensity 2", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			if (UKuroStaticLibrary.IsLowMemoryDevice() && num > 1)
			{
				num = 1;
			}
			ControllerBase<CreatureController>.Instance.RefreshDensityLevel(num);
			if (PerfSightController.IsEnable)
			{
				UPerfSightHelper.PostEvent(806, num.ToString());
			}
			return true;
		}

		// Token: 0x060457D2 RID: 284626 RVA: 0x0122AD28 File Offset: 0x01228F28
		public static bool ApplyNvidiaSuperSamplingEnable(int value, EGameSettingsApplyReason reason)
		{
			if (Singleton<Info>.Instance.IsPs5Platform())
			{
				return false;
			}
			if (!Singleton<GameSettingsDeviceRender>.Instance.IsDlssGpuDevice())
			{
				return false;
			}
			if (Singleton<GameSettingsDeviceRender>.Instance.IsNvidiaDlessPluginLoaded())
			{
				if (value == 1)
				{
					UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.NGX.DLSS.Enable 1", null);
					UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.TemporalAASamples 8", null);
					UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.TemporalAAFilterSize 1", null);
					UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.FidelityFX.FSR.SecondaryUpscale 0", null);
					Singleton<GameSettingsManager>.Instance.ReApply(EFunction.NVIDIADLSSFG, EGameSettingsApplyReason.AnyTime, false);
					Singleton<GameSettingsManager>.Instance.ReApply(EFunction.NVIDIAREFLEX, EGameSettingsApplyReason.AnyTime, false);
				}
				else
				{
					UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.NGX.DLSS.Enable 0", null);
					UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.TemporalAASamples 4", null);
					GameSettingsUtils.ApplyNvidiaSuperSamplingFrameGenerate(0);
				}
				if (reason != EGameSettingsApplyReason.WhenLoading)
				{
					Singleton<GameSettingsManager>.Instance.ReApply(EFunction.PCVSYNC, reason, false);
				}
				if (Singleton<GameSettingsDeviceRender>.Instance.InCacheSceneColorMode == 1)
				{
					UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.CacheSceneColor.Start", null);
				}
				if (PerfSightController.IsEnable)
				{
					UPerfSightHelper.PostEvent(804, value.ToString());
				}
			}
			return true;
		}

		// Token: 0x060457D3 RID: 284627 RVA: 0x0122AE34 File Offset: 0x01229034
		public static bool ApplyNvidiaSuperSamplingFrameGenerate(int value)
		{
			if (!Singleton<GameSettingsDeviceRender>.Instance.IsDlss3GpuDevice())
			{
				return false;
			}
			if (Singleton<GameSettingsDeviceRender>.Instance.IsNvidiaStreamlinePluginLoaded())
			{
				Singleton<GameSettingsDeviceRender>.Instance.EnableDLSSG(value);
				if (PerfSightController.IsEnable)
				{
					UPerfSightHelper.PostEvent(820, value.ToString());
				}
			}
			return true;
		}

		// Token: 0x060457D4 RID: 284628 RVA: 0x0122AE74 File Offset: 0x01229074
		public static bool ApplyPcVsync(int value)
		{
			UGameUserSettings gameUserSettings = UGameUserSettings.GetGameUserSettings();
			gameUserSettings.SetVSyncEnabled(value == 1);
			gameUserSettings.ApplySettings(true);
			if (PerfSightController.IsEnable)
			{
				UPerfSightHelper.PostEvent(834, value.ToString());
			}
			return true;
		}

		// Token: 0x060457D5 RID: 284629 RVA: 0x0122AEA4 File Offset: 0x012290A4
		public static bool ApplyNvidiaSuperSamplingQuality(int value)
		{
			if (!Singleton<GameSettingsDeviceRender>.Instance.IsDlssGpuDevice())
			{
				return false;
			}
			int kuroRenderQualityLocalIndex = ControllerBase<GameSettingsController>.Instance.KuroRenderQualityLocalIndex;
			int? num = GameSettingsUtils.NvidiaSuperSamplingQualityCache;
			int num2 = value;
			if (num.GetValueOrDefault() == num2 & num != null)
			{
				num = GameSettingsUtils.KuroLocalRenderSettingIndexCache;
				num2 = kuroRenderQualityLocalIndex;
				if (num.GetValueOrDefault() == num2 & num != null)
				{
					return false;
				}
			}
			GameSettingsUtils.KuroLocalRenderSettingIndexCache = new int?(kuroRenderQualityLocalIndex);
			GameSettingsUtils.NvidiaSuperSamplingQualityCache = new int?(value);
			if (Singleton<GameSettingsDeviceRender>.Instance.IsNvidiaDlssPluginLoaded())
			{
				if (value == 99)
				{
					if (kuroRenderQualityLocalIndex >= 30 && kuroRenderQualityLocalIndex <= 39)
					{
						FIntPoint screenResolution = UGameUserSettings.GetGameUserSettings().GetScreenResolution();
						int x = screenResolution.X;
						int y = screenResolution.Y;
						if (x > 3000 || y > 3000)
						{
							UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.NGX.DLSS.Quality.Auto 0", null);
							UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.NGX.DLSS.Quality -2", null);
							Singleton<Log>.Instance.Info(ELogModule.GameSettings, ELogAuthor.ZYT, "KuroLocalRenderSettingIndex Change DLSS.Quality -2", default(ReadOnlySpan<ValueTuple<string, object>>));
						}
						else
						{
							UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.NGX.DLSS.Quality.Auto 0", null);
							UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.NGX.DLSS.Quality -1", null);
							Singleton<Log>.Instance.Info(ELogModule.GameSettings, ELogAuthor.ZYT, "KuroLocalRenderSettingIndex Change DLSS.Quality -1", default(ReadOnlySpan<ValueTuple<string, object>>));
						}
					}
					else
					{
						UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.NGX.DLSS.Quality.Auto 1", null);
					}
				}
				else
				{
					UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.NGX.DLSS.Quality.Auto 0", null);
					UObject world = GlobalData.World;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(19, 1);
					defaultInterpolatedStringHandler.AppendLiteral("r.NGX.DLSS.Quality ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(value);
					UKismetSystemLibrary.ExecuteConsoleCommand(world, defaultInterpolatedStringHandler.ToStringAndClear(), null);
				}
				if (PerfSightController.IsEnable)
				{
					UPerfSightHelper.PostEvent(812, value.ToString());
				}
			}
			return true;
		}

		// Token: 0x060457D6 RID: 284630 RVA: 0x0122B05C File Offset: 0x0122925C
		public static bool ApplyNvidiaSuperSamplingSharpness(float value)
		{
			if (!Singleton<GameSettingsDeviceRender>.Instance.IsDlssGpuDevice())
			{
				return false;
			}
			if (Singleton<GameSettingsDeviceRender>.Instance.IsNvidiaDlssPluginLoaded())
			{
				UDLSSLibrary.SetDLSSSharpness(value);
			}
			return true;
		}

		// Token: 0x060457D7 RID: 284631 RVA: 0x0122B07F File Offset: 0x0122927F
		public static bool ApplyNvidiaReflex(int value)
		{
			return true;
		}

		// Token: 0x060457D8 RID: 284632 RVA: 0x0122B084 File Offset: 0x01229284
		public static bool ApplyHdrEnable(int value)
		{
			UObject world = GlobalData.World;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(22, 1);
			defaultInterpolatedStringHandler.AppendLiteral("r.HDR.EnableHDROutput ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(value);
			UKismetSystemLibrary.ExecuteConsoleCommand(world, defaultInterpolatedStringHandler.ToStringAndClear(), null);
			return true;
		}

		// Token: 0x060457D9 RID: 284633 RVA: 0x0122B0C4 File Offset: 0x012292C4
		public static bool ApplyFsrEnable(int value)
		{
			if (Singleton<GameSettingsDeviceRender>.Instance.IsDlssGpuDevice())
			{
				return false;
			}
			if (Singleton<GameSettingsDeviceRender>.Instance.IsMetalFxDevice())
			{
				return false;
			}
			if (Singleton<Info>.Instance.IsXSXPlatform())
			{
				return false;
			}
			if (Singleton<Info>.Instance.IsGamepadPlatform())
			{
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.TemporalAASamples 4", null);
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.FidelityFX.FSR.PrimaryUpscale 1", null);
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.ScreenPercentage 77", null);
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.MipMapLODBias -0.3765", null);
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.TemporalAACurrentFrameWeight 0.09", null);
				return true;
			}
			if (!Singleton<Info>.Instance.IsPcPlatform())
			{
				if (value == 1)
				{
					UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.FidelityFX.FSR.RCAS.Enabled 1", null);
					UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.TemporalAA.ClampTolerant 0", null);
					UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.TemporalAA.SharpenLimitDepth 10", null);
				}
				else
				{
					UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.FidelityFX.FSR.RCAS.Enabled 0", null);
					UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.TemporalAA.ClampTolerant 2", null);
					UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.TemporalAA.SharpenLimitDepth -1", null);
				}
			}
			else
			{
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.NGX.DLSS.Enable 0", null);
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.TemporalAASamples 4", null);
				if (value == 1)
				{
					UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.FidelityFX.FSR.PrimaryUpscale 1", null);
					UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.ScreenPercentage 77", null);
					UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.MipMapLODBias -0.3765", null);
					UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.TemporalAACurrentFrameWeight 0.09", null);
				}
				else
				{
					UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.FidelityFX.FSR.PrimaryUpscale 0", null);
					UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.ScreenPercentage 100", null);
					UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.MipMapLODBias 0.0", null);
					UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.TemporalAACurrentFrameWeight 0.25", null);
				}
			}
			if (PerfSightController.IsEnable)
			{
				UPerfSightHelper.PostEvent(813, value.ToString());
			}
			return true;
		}

		// Token: 0x060457DA RID: 284634 RVA: 0x0122B294 File Offset: 0x01229494
		public static bool ApplyXessEnable(int value)
		{
			UObject world = GlobalData.World;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(15, 1);
			defaultInterpolatedStringHandler.AppendLiteral("r.XeSS.Enabled ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(value);
			UKismetSystemLibrary.ExecuteConsoleCommand(world, defaultInterpolatedStringHandler.ToStringAndClear(), null);
			return true;
		}

		// Token: 0x060457DB RID: 284635 RVA: 0x0122B2D4 File Offset: 0x012294D4
		public static bool ApplyXessQuality(int value)
		{
			UObject world = GlobalData.World;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(15, 1);
			defaultInterpolatedStringHandler.AppendLiteral("r.XeSS.Quality ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(value);
			UKismetSystemLibrary.ExecuteConsoleCommand(world, defaultInterpolatedStringHandler.ToStringAndClear(), null);
			return true;
		}

		// Token: 0x060457DC RID: 284636 RVA: 0x0122B314 File Offset: 0x01229514
		public static bool ApplyXess2Enable(int value)
		{
			bool flag = value != 0;
			if (flag != GameSettingsUtils.XessEnabled)
			{
				GameSettingsUtils.XessEnabled = flag;
				Singleton<GameSettingsDeviceRender>.Instance.EnableXeSS(GameSettingsUtils.XessEnabled);
			}
			if (PerfSightController.IsEnable)
			{
				UPerfSightHelper.PostEvent(830, value.ToString());
			}
			return true;
		}

		// Token: 0x060457DD RID: 284637 RVA: 0x0122B35C File Offset: 0x0122955C
		public static bool ApplyXess2Fg(int value)
		{
			Singleton<GameSettingsDeviceRender>.Instance.EnableXefg(value);
			if (PerfSightController.IsEnable)
			{
				UPerfSightHelper.PostEvent(827, value.ToString());
			}
			return true;
		}

		// Token: 0x060457DE RID: 284638 RVA: 0x0122B384 File Offset: 0x01229584
		public static bool ApplyXess2Quality(int value)
		{
			UObject world = GlobalData.World;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(15, 1);
			defaultInterpolatedStringHandler.AppendLiteral("r.XeSS.Quality ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(value + 2);
			UKismetSystemLibrary.ExecuteConsoleCommand(world, defaultInterpolatedStringHandler.ToStringAndClear(), null);
			if (PerfSightController.IsEnable)
			{
				UPerfSightHelper.PostEvent(831, value.ToString());
			}
			return true;
		}

		// Token: 0x060457DF RID: 284639 RVA: 0x0122B3DC File Offset: 0x012295DC
		public static bool ApplyFsr3Enable(int value)
		{
			if (!UKuroFFXFSR3BlueprintLibrary.IsGlobalSwitchOn())
			{
				return false;
			}
			UObject world = GlobalData.World;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(26, 1);
			defaultInterpolatedStringHandler.AppendLiteral("r.FidelityFX.FSR3.Enabled ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(value);
			UKismetSystemLibrary.ExecuteConsoleCommand(world, defaultInterpolatedStringHandler.ToStringAndClear(), null);
			UObject world2 = GlobalData.World;
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(24, 1);
			defaultInterpolatedStringHandler.AppendLiteral("r.TemporalAA.Upsampling ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(value);
			UKismetSystemLibrary.ExecuteConsoleCommand(world2, defaultInterpolatedStringHandler.ToStringAndClear(), null);
			if (PerfSightController.IsEnable)
			{
				UPerfSightHelper.PostEvent(832, value.ToString());
			}
			return true;
		}

		// Token: 0x060457E0 RID: 284640 RVA: 0x0122B46C File Offset: 0x0122966C
		public static bool ApplyFsr3Fg(int value, EFFXFIApplyMode mode)
		{
			if (!UKuroFFXFSR3BlueprintLibrary.IsGlobalSwitchOn())
			{
				return false;
			}
			if (!Singleton<GameSettingsDeviceRender>.Instance.IsFFXFISupported())
			{
				return false;
			}
			GameSettingsUtils.Fsr3FgApplyMode = mode;
			GameSettingsUtils.Fsr3FgSwitchStates[(int)mode] = value;
			GameSettingsUtils.Fsr3FgEnable = (value != 0);
			if (GameSettingsUtils.IsInTemporaryFFXFIApplyState() && !GameSettingsUtils.IsTemporaryFFXFIApplyMode(mode))
			{
				return true;
			}
			Singleton<GameSettingsDeviceRender>.Instance.ApplyUnlimitedFrameRate(GameSettingsUtils.Fsr3FgEnable);
			UObject world = GlobalData.World;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(24, 1);
			defaultInterpolatedStringHandler.AppendLiteral("r.FidelityFX.FI.Enabled ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(value);
			UKismetSystemLibrary.ExecuteConsoleCommand(world, defaultInterpolatedStringHandler.ToStringAndClear(), null);
			if (PerfSightController.IsEnable)
			{
				UPerfSightHelper.PostEvent(826, value.ToString());
			}
			return true;
		}

		// Token: 0x060457E1 RID: 284641 RVA: 0x0122B514 File Offset: 0x01229714
		public static bool IsFsr3FgEnable()
		{
			return GameSettingsUtils.Fsr3FgEnable;
		}

		// Token: 0x060457E2 RID: 284642 RVA: 0x0122B51B File Offset: 0x0122971B
		public static EFFXFIApplyMode GetFsr3FgApplyMode()
		{
			return GameSettingsUtils.Fsr3FgApplyMode;
		}

		// Token: 0x060457E3 RID: 284643 RVA: 0x0122B524 File Offset: 0x01229724
		public static int GetFsr3FgSwitchState(EFFXFIApplyMode mode)
		{
			int result;
			if (!GameSettingsUtils.Fsr3FgSwitchStates.TryGetValue((int)mode, out result))
			{
				return 0;
			}
			return result;
		}

		// Token: 0x060457E4 RID: 284644 RVA: 0x0122B543 File Offset: 0x01229743
		public static bool IsTemporaryFFXFIApplyMode(EFFXFIApplyMode mode)
		{
			return mode > EFFXFIApplyMode.Default;
		}

		// Token: 0x060457E5 RID: 284645 RVA: 0x0122B549 File Offset: 0x01229749
		public static bool IsInTemporaryFFXFIApplyState()
		{
			return GameSettingsUtils.Fsr3FgInTemporaryApplyState;
		}

		// Token: 0x060457E6 RID: 284646 RVA: 0x0122B550 File Offset: 0x01229750
		public static void EnterTemporaryFFXFIApplyState()
		{
			GameSettingsUtils.Fsr3FgInTemporaryApplyState = true;
		}

		// Token: 0x060457E7 RID: 284647 RVA: 0x0122B558 File Offset: 0x01229758
		public static void LeaveTemporaryFFXFIApplyState()
		{
			GameSettingsUtils.Fsr3FgInTemporaryApplyState = false;
		}

		// Token: 0x060457E8 RID: 284648 RVA: 0x0122B560 File Offset: 0x01229760
		public static bool ApplyFsr3Quality(int value)
		{
			if (!UKuroFFXFSR3BlueprintLibrary.IsGlobalSwitchOn())
			{
				return false;
			}
			int value2 = 2 - value;
			UObject world = GlobalData.World;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(30, 1);
			defaultInterpolatedStringHandler.AppendLiteral("r.FidelityFX.FSR3.QualityMode ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(value2);
			UKismetSystemLibrary.ExecuteConsoleCommand(world, defaultInterpolatedStringHandler.ToStringAndClear(), null);
			if (PerfSightController.IsEnable)
			{
				UPerfSightHelper.PostEvent(833, value.ToString());
			}
			return true;
		}

		// Token: 0x060457E9 RID: 284649 RVA: 0x0122B5C4 File Offset: 0x012297C4
		public static bool ApplyMetalFxEnable(int value)
		{
			UObject world = GlobalData.World;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(17, 1);
			defaultInterpolatedStringHandler.AppendLiteral("r.MetalFxUpscale ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(value);
			UKismetSystemLibrary.ExecuteConsoleCommand(world, defaultInterpolatedStringHandler.ToStringAndClear(), null);
			UObject world2 = GlobalData.World;
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(31, 1);
			defaultInterpolatedStringHandler.AppendLiteral("r.TemporalAA.SharpenLimitDepth ");
			defaultInterpolatedStringHandler.AppendFormatted<int>((value == 1) ? 20 : -1);
			UKismetSystemLibrary.ExecuteConsoleCommand(world2, defaultInterpolatedStringHandler.ToStringAndClear(), null);
			if (PerfSightController.IsEnable)
			{
				UPerfSightHelper.PostEvent(818, value.ToString());
			}
			return true;
		}

		// Token: 0x060457EA RID: 284650 RVA: 0x0122B654 File Offset: 0x01229854
		public static bool ApplyBloomEnable(int value)
		{
			UObject world = GlobalData.World;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(23, 1);
			defaultInterpolatedStringHandler.AppendLiteral("r.Kuro.KuroBloomEnable ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(value);
			UKismetSystemLibrary.ExecuteConsoleCommand(world, defaultInterpolatedStringHandler.ToStringAndClear(), null);
			if (PerfSightController.IsEnable)
			{
				UPerfSightHelper.PostEvent(811, value.ToString());
			}
			return true;
		}

		// Token: 0x060457EB RID: 284651 RVA: 0x0122B6AA File Offset: 0x012298AA
		public static bool ApplyIrxEnable(int value)
		{
			if (value == 1)
			{
				Singleton<GameSettingsDeviceRender>.Instance.TurnOnIRX();
			}
			else
			{
				Singleton<GameSettingsDeviceRender>.Instance.TurnOffIRX();
			}
			return true;
		}

		// Token: 0x060457EC RID: 284652 RVA: 0x0122B6C8 File Offset: 0x012298C8
		public static bool ApplySceneLightQuality(int value)
		{
			if (!Singleton<Info>.Instance.IsMobilePlatform())
			{
				int[] array = new int[]
				{
					4,
					4,
					4,
					4,
					5,
					5
				};
				int num = Singleton<MathUtils>.Instance.Clamp(value, 0, array.Length - 1);
				UObject world = GlobalData.World;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(26, 1);
				defaultInterpolatedStringHandler.AppendLiteral("r.Kuro.GlobalLightQuality ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(array[num]);
				UKismetSystemLibrary.ExecuteConsoleCommand(world, defaultInterpolatedStringHandler.ToStringAndClear(), null);
				return true;
			}
			if (Singleton<GameSettingsDeviceRender>.Instance.IsIosAndAndroidHighDevice())
			{
				int[] array2 = new int[]
				{
					1,
					2,
					3,
					4,
					4
				};
				UObject world2 = GlobalData.World;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(26, 1);
				defaultInterpolatedStringHandler.AppendLiteral("r.Kuro.GlobalLightQuality ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(array2[value]);
				UKismetSystemLibrary.ExecuteConsoleCommand(world2, defaultInterpolatedStringHandler.ToStringAndClear(), null);
			}
			else
			{
				int[] array3 = new int[]
				{
					1,
					2,
					3,
					3,
					3
				};
				UObject world3 = GlobalData.World;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(26, 1);
				defaultInterpolatedStringHandler.AppendLiteral("r.Kuro.GlobalLightQuality ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(array3[value]);
				UKismetSystemLibrary.ExecuteConsoleCommand(world3, defaultInterpolatedStringHandler.ToStringAndClear(), null);
			}
			return true;
		}

		// Token: 0x060457ED RID: 284653 RVA: 0x0122B7D4 File Offset: 0x012299D4
		public static bool ApplyVolumeFog(int value)
		{
			if (!Singleton<GameSettingsDeviceRender>.Instance.IsEnableVolumeFog())
			{
				return false;
			}
			if (Singleton<Info>.Instance.IsPcOrGamepadPlatform())
			{
				int value2 = (value > 0) ? 1 : 0;
				UObject world = GlobalData.World;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(16, 1);
				defaultInterpolatedStringHandler.AppendLiteral("r.volumetricfog ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(value2);
				UKismetSystemLibrary.ExecuteConsoleCommand(world, defaultInterpolatedStringHandler.ToStringAndClear(), null);
				UObject world2 = GlobalData.World;
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(30, 1);
				defaultInterpolatedStringHandler.AppendLiteral("r.Kuro.VRS.VolumeCloudQuality ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(value);
				UKismetSystemLibrary.ExecuteConsoleCommand(world2, defaultInterpolatedStringHandler.ToStringAndClear(), null);
				if (PerfSightController.IsEnable)
				{
					UPerfSightHelper.PostEvent(809, value.ToString());
				}
			}
			return true;
		}

		// Token: 0x060457EE RID: 284654 RVA: 0x0122B87C File Offset: 0x01229A7C
		public static bool ApplyVolumeLight(int value)
		{
			if (Singleton<Info>.Instance.IsPcOrGamepadPlatform())
			{
				UObject world = GlobalData.World;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(20, 1);
				defaultInterpolatedStringHandler.AppendLiteral("r.lightShaftQuality ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(value);
				UKismetSystemLibrary.ExecuteConsoleCommand(world, defaultInterpolatedStringHandler.ToStringAndClear(), null);
			}
			if (Singleton<Info>.Instance.IsMobilePlatform())
			{
				bool flag = Singleton<GameSettingsDeviceRender>.Instance.IsIosAndAndroidHighDevice();
				UObject world2 = GlobalData.World;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(19, 1);
				defaultInterpolatedStringHandler.AppendLiteral("r.MobileLightShaft ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(flag ? value : 0);
				UKismetSystemLibrary.ExecuteConsoleCommand(world2, defaultInterpolatedStringHandler.ToStringAndClear(), null);
			}
			if (PerfSightController.IsEnable)
			{
				UPerfSightHelper.PostEvent(835, value.ToString());
			}
			return true;
		}

		// Token: 0x060457EF RID: 284655 RVA: 0x0122B92C File Offset: 0x01229B2C
		public static bool ApplyMotionBlur(float value)
		{
			CameraModel instance = ModelBase<CameraModel>.Instance;
			double num = (instance != null) ? instance.MainModel.MotionBlurModifier : 0.2;
			UObject world = GlobalData.World;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(20, 1);
			defaultInterpolatedStringHandler.AppendLiteral("r.MotionBlur.Amount ");
			defaultInterpolatedStringHandler.AppendFormatted<double>((double)value * num);
			UKismetSystemLibrary.ExecuteConsoleCommand(world, defaultInterpolatedStringHandler.ToStringAndClear(), null);
			if (PerfSightController.IsEnable)
			{
				UPerfSightHelper.PostEvent(836, ((int)value).ToString());
			}
			return true;
		}

		// Token: 0x060457F0 RID: 284656 RVA: 0x0122B9A8 File Offset: 0x01229BA8
		public unsafe static bool ApplyMobileResolution(int value)
		{
			if (!Singleton<Info>.Instance.IsMobilePlatform())
			{
				return false;
			}
			if (Singleton<Info>.Instance.PlatformType == ESourcePlatformType.Android)
			{
				if (value == 0)
				{
					UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.TemporalAA.SharpenLimitDepth 50", null);
				}
				else
				{
					UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.TemporalAA.SharpenLimitDepth -1", null);
				}
				if (Singleton<GameSettingsDeviceRender>.Instance.IsAndroidPlatformScreenBetter())
				{
					UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.TemporalAA.Sharpness 0.5", null);
				}
				if (Singleton<GameSettingsDeviceRender>.Instance.IsAndroidPlatformScreenBad())
				{
					UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.TemporalAA.Sharpness 0.1", null);
				}
			}
			if (Singleton<GameSettingsDeviceRender>.Instance.InCacheSceneColorMode == 1)
			{
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.CacheSceneColor.Start", null);
			}
			int num = Singleton<GameSettingsDeviceRender>.Instance.GetMobileResolutionByIndex(value);
			float consoleVariableFloatValue = UKismetSystemLibrary.GetConsoleVariableFloatValue("r.MobileContentScaleFactor");
			float consoleVariableFloatValue2 = UKismetSystemLibrary.GetConsoleVariableFloatValue("r.SecondaryScreenPercentage.GameViewport");
			float num2 = 1f;
			FVector2D physicalScreenResolutionV = UKuroScreenBlueprintFunctionLibrary.GetPhysicalScreenResolutionV2();
			float x = physicalScreenResolutionV.X;
			float y = physicalScreenResolutionV.Y;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler;
			if (Singleton<GameSettingsDeviceRender>.Instance.IsAndroidHighResolutionDevice() && y > 0f)
			{
				if (y > x && y < 1280f * consoleVariableFloatValue)
				{
					num2 = 1280f * consoleVariableFloatValue / y;
				}
				else if (y < x && y < 720f * consoleVariableFloatValue)
				{
					num2 = 720f * consoleVariableFloatValue / y;
				}
				float num3 = Math.Min(consoleVariableFloatValue2 * num2, 100f);
				UObject world = GlobalData.World;
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(41, 1);
				defaultInterpolatedStringHandler.AppendLiteral("r.SecondaryScreenPercentage.GameViewport ");
				defaultInterpolatedStringHandler.AppendFormatted<float>(num3);
				UKismetSystemLibrary.ExecuteConsoleCommand(world, defaultInterpolatedStringHandler.ToStringAndClear(), null);
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Game;
				ELogAuthor author = ELogAuthor.ZJF;
				string message = "分辨率校正";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("deviceScaleCorrect", num2);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("secondaryScreenPercentage", consoleVariableFloatValue2);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("newSecondaryScreenPercentage", num3);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			}
			if (Singleton<GameSettingsDeviceRender>.Instance.GetDefaultScreenResolution().Y < 750 && consoleVariableFloatValue2 < 70f)
			{
				num = (int)Math.Min((float)num * 1.5f, 100f);
			}
			if (PerfSightController.IsEnable)
			{
				UPerfSightHelper.PostEvent(803, value.ToString());
			}
			UObject world2 = GlobalData.World;
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(19, 1);
			defaultInterpolatedStringHandler.AppendLiteral("r.ScreenPercentage ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(num);
			UKismetSystemLibrary.ExecuteConsoleCommand(world2, defaultInterpolatedStringHandler.ToStringAndClear(), null);
			return true;
		}

		// Token: 0x060457F1 RID: 284657 RVA: 0x0122BC11 File Offset: 0x01229E11
		public static bool ApplySuperResolution(int value)
		{
			return false;
		}

		// Token: 0x060457F2 RID: 284658 RVA: 0x0122BC14 File Offset: 0x01229E14
		public static void ApplyHorizontalViewSensitivity(float value)
		{
			ModelBase<CameraModel>.Instance.MainModel.SetCameraBaseYawSensitivity((double)value);
		}

		// Token: 0x060457F3 RID: 284659 RVA: 0x0122BC27 File Offset: 0x01229E27
		public static void ApplyVerticalViewSensitivity(float value)
		{
			ModelBase<CameraModel>.Instance.MainModel.SetCameraBasePitchSensitivity((double)value);
		}

		// Token: 0x060457F4 RID: 284660 RVA: 0x0122BC3A File Offset: 0x01229E3A
		public static void ApplyAimHorizontalViewSensitivity(float value)
		{
			ModelBase<CameraModel>.Instance.MainModel.SetCameraAimingYawSensitivity((double)value);
		}

		// Token: 0x060457F5 RID: 284661 RVA: 0x0122BC4D File Offset: 0x01229E4D
		public static void ApplyAimVerticalViewSensitivity(float value)
		{
			ModelBase<CameraModel>.Instance.MainModel.SetCameraAimingPitchSensitivity((double)value);
		}

		// Token: 0x060457F6 RID: 284662 RVA: 0x0122BC60 File Offset: 0x01229E60
		public static void ApplyCameraShakeStrength(int value)
		{
			int num = 0;
			if (Singleton<Info>.Instance.IsMobilePlatform())
			{
				num = value;
			}
			else
			{
				switch (value)
				{
				case 0:
					num = (int)ModelBase<MenuModel>.Instance.LowShake;
					break;
				case 1:
					num = (int)ModelBase<MenuModel>.Instance.MiddleShake;
					break;
				case 2:
					num = (int)ModelBase<MenuModel>.Instance.HighShake;
					break;
				}
			}
			ModelBase<CameraModel>.Instance.MainModel.SetCameraShakeModify((double)num);
		}

		// Token: 0x060457F7 RID: 284663 RVA: 0x0122BCCC File Offset: 0x01229ECC
		public static bool ApplyTextLanguage(int value)
		{
			string languageCodeById = Singleton<GameSettingsManager>.Instance.GetLanguageCodeById(value);
			if (string.IsNullOrEmpty(languageCodeById))
			{
				return false;
			}
			string packageLanguage = Singleton<LanguageSystem>.Instance.PackageLanguage;
			Singleton<LanguageSystem>.Instance.PackageLanguage = languageCodeById;
			ControllerBase<KuroSdkController>.Instance.PostKuroSdkEvent(EKuroSdkEventKey.KuroNotiLanguage);
			Singleton<EventSystem>.Instance.Emit<string, string>(EEventName.TextLanguageChange, packageLanguage, languageCodeById);
			return true;
		}

		// Token: 0x060457F8 RID: 284664 RVA: 0x0122BD24 File Offset: 0x01229F24
		public static bool ApplyTextLanguageOnGameStart(int value)
		{
			string languageCodeById = Singleton<GameSettingsManager>.Instance.GetLanguageCodeById(value);
			if (languageCodeById == null)
			{
				return false;
			}
			Singleton<LanguageSystem>.Instance.PackageLanguage = languageCodeById;
			return true;
		}

		// Token: 0x060457F9 RID: 284665 RVA: 0x0122BD50 File Offset: 0x01229F50
		public static bool ApplyLanguageAudio(int value)
		{
			string audioCodeById = Singleton<GameSettingsManager>.Instance.GetAudioCodeById(value);
			if (string.IsNullOrEmpty(audioCodeById))
			{
				return false;
			}
			Singleton<LanguageSystem>.Instance.SetPackageAudio(audioCodeById, GlobalData.World);
			if (LocalStorage.HasPlayerId() && ModelBase<RoleLangCustomModel>.Instance != null)
			{
				if (!ModelBase<RoleLangCustomModel>.Instance.CanSetCustom)
				{
					ModelBase<RoleLangCustomModel>.Instance.CanSetCustom = true;
					ModelBase<RoleLangCustomModel>.Instance.CheckAndApplyPlayerVoiceAll();
				}
				else
				{
					ModelBase<RoleLangCustomModel>.Instance.ApplyPlayerVoiceAll();
				}
			}
			return true;
		}

		// Token: 0x060457FA RID: 284666 RVA: 0x0122BDBF File Offset: 0x01229FBF
		public static void ApplyMobileHorizontalViewSensitivity(float value)
		{
			ModelBase<CameraModel>.Instance.MainModel.SetCameraBaseYawSensitivity((double)value);
		}

		// Token: 0x060457FB RID: 284667 RVA: 0x0122BDD2 File Offset: 0x01229FD2
		public static void ApplyMobileVerticalViewSensitivity(float value)
		{
			ModelBase<CameraModel>.Instance.MainModel.SetCameraBasePitchSensitivity((double)value);
		}

		// Token: 0x060457FC RID: 284668 RVA: 0x0122BDE5 File Offset: 0x01229FE5
		public static void ApplyMobileAimHorizontalViewSensitivity(float value)
		{
			ModelBase<CameraModel>.Instance.MainModel.SetCameraAimingYawSensitivity((double)value);
		}

		// Token: 0x060457FD RID: 284669 RVA: 0x0122BDF8 File Offset: 0x01229FF8
		public static void ApplyMobileAimVerticalViewSensitivity(float value)
		{
			ModelBase<CameraModel>.Instance.MainModel.SetCameraAimingPitchSensitivity((double)value);
		}

		// Token: 0x060457FE RID: 284670 RVA: 0x0122BE0B File Offset: 0x0122A00B
		public static void ApplyCommonSpringArmLength(float value)
		{
			ModelBase<CameraModel>.Instance.MainModel.CameraSettingNormalAdditionArmLength = (double)value;
		}

		// Token: 0x060457FF RID: 284671 RVA: 0x0122BE1E File Offset: 0x0122A01E
		public static void ApplyFightSpringArmLength(float value)
		{
			ModelBase<CameraModel>.Instance.MainModel.CameraSettingFightAdditionArmLength = (double)value;
		}

		// Token: 0x06045800 RID: 284672 RVA: 0x0122BE31 File Offset: 0x0122A031
		public static void ApplyResetFocusEnable(int value)
		{
			ModelBase<CameraModel>.Instance.MainModel.IsEnableResetFocus = (value == 1);
		}

		// Token: 0x06045801 RID: 284673 RVA: 0x0122BE46 File Offset: 0x0122A046
		public static void ApplyIsSidestepCameraEnable(int value)
		{
			ModelBase<CameraModel>.Instance.MainModel.IsEnableSidestepCamera = (value == 1);
		}

		// Token: 0x06045802 RID: 284674 RVA: 0x0122BE5B File Offset: 0x0122A05B
		public static void ApplyIsSoftLockCameraEnable(int value)
		{
			ModelBase<CameraModel>.Instance.MainModel.SetSettingSoftLockState(value == 1);
		}

		// Token: 0x06045803 RID: 284675 RVA: 0x0122BE70 File Offset: 0x0122A070
		public static bool ApplyJoystickShakeStrength(int value)
		{
			GameSettingsUtils.ApplyJoystickShakeInternal((EGlobalKuroForceFeedbackType)Singleton<GameSettingsManager>.Instance.GetCurrentValueSafely(EFunction.JoystickShakeType, 0, true), value);
			return true;
		}

		// Token: 0x06045804 RID: 284676 RVA: 0x0122BE88 File Offset: 0x0122A088
		public static bool ApplyJoystickShakeType(int value)
		{
			int currentValueSafely = Singleton<GameSettingsManager>.Instance.GetCurrentValueSafely(EFunction.JoystickShakeStrength, 0, true);
			GameSettingsUtils.ApplyJoystickShakeInternal((EGlobalKuroForceFeedbackType)value, currentValueSafely);
			return true;
		}

		// Token: 0x06045805 RID: 284677 RVA: 0x0122BEAD File Offset: 0x0122A0AD
		private static void ApplyJoystickShakeInternal(EGlobalKuroForceFeedbackType joystickShakeType, int joystickShakeStrength)
		{
			ABasePlayerController.SetKuroForceFeedbackConfig(joystickShakeType, joystickShakeStrength);
		}

		// Token: 0x06045806 RID: 284678 RVA: 0x0122BEB6 File Offset: 0x0122A0B6
		public static void ApplyWalkOrRunRate(float value)
		{
			RoleGaitStatic.SetWalkOrRunRateForRocker(value);
		}

		// Token: 0x06045807 RID: 284679 RVA: 0x0122BEBE File Offset: 0x0122A0BE
		public static void ApplyJoystickMode(int value)
		{
			ModelBase<BattleUiModel>.Instance.SetIsDynamicJoystick(value == 1);
		}

		// Token: 0x06045808 RID: 284680 RVA: 0x0122BECE File Offset: 0x0122A0CE
		public static void ApplyAutoSwitchSkillButtonMode(int value)
		{
			ModelBase<BattleUiModel>.Instance.SetIsAutoSwitchSkillButtonMode(value == 0);
		}

		// Token: 0x06045809 RID: 284681 RVA: 0x0122BEDE File Offset: 0x0122A0DE
		public static void ApplyAimAssistEnable(int value)
		{
			CameraModel instance = ModelBase<CameraModel>.Instance;
			if (instance == null)
			{
				return;
			}
			instance.MainModel.SetAimAssistEnable(value == 1);
		}

		// Token: 0x0604580A RID: 284682 RVA: 0x0122BEF8 File Offset: 0x0122A0F8
		public static void ApplyKeyboardLockEnemyMode(int value)
		{
			ControllerBase<FormationDataController>.Instance.SetKeyboardLockEnemyMode((ELockEnemyMode)value);
		}

		// Token: 0x0604580B RID: 284683 RVA: 0x0122BF08 File Offset: 0x0122A108
		public static void ApplyHorizontalViewRevert(int value)
		{
			IReadOnlyList<AxisRevert> axisRevertConfigListByRevertType = ConfigBase<MenuBaseConfig>.Instance.GetAxisRevertConfigListByRevertType(0);
			if (axisRevertConfigListByRevertType == null)
			{
				return;
			}
			GameSettingsUtils.ApplyAxisRevert(value == 1, axisRevertConfigListByRevertType);
		}

		// Token: 0x0604580C RID: 284684 RVA: 0x0122BF30 File Offset: 0x0122A130
		public static void ApplyVerticalViewRevert(int value)
		{
			IReadOnlyList<AxisRevert> axisRevertConfigListByRevertType = ConfigBase<MenuBaseConfig>.Instance.GetAxisRevertConfigListByRevertType(1);
			if (axisRevertConfigListByRevertType == null)
			{
				return;
			}
			GameSettingsUtils.ApplyAxisRevert(value == 1, axisRevertConfigListByRevertType);
		}

		// Token: 0x0604580D RID: 284685 RVA: 0x0122BF58 File Offset: 0x0122A158
		public static void RefreshViewRevertState(EInputControllerMainType mainType)
		{
			int value = 0;
			int value2 = 0;
			if (mainType == EInputControllerMainType.Gamepad)
			{
				value = Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.HorizontalViewRevert, true, true).GetValueOrDefault();
				value2 = Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.VerticalViewRevert, true, true).GetValueOrDefault();
			}
			GameSettingsUtils.ApplyHorizontalViewRevert(value);
			GameSettingsUtils.ApplyVerticalViewRevert(value2);
		}

		// Token: 0x0604580E RID: 284686 RVA: 0x0122BFB0 File Offset: 0x0122A1B0
		private static void ApplyAxisRevert(bool bRevert, IReadOnlyList<AxisRevert> axisRevertConfigList)
		{
			foreach (AxisRevert axisRevert in axisRevertConfigList)
			{
				string axisName = axisRevert.AxisName;
				InputAxisBinding axisBinding = Singleton<InputSettingsManager>.Instance.GetAxisBinding(axisName);
				if (axisBinding != null)
				{
					IEnumerable<DicStringInt> enumerable = axisRevert.RevertInfoIter();
					Dictionary<EInputBindingType, Dictionary<string, InputAxisKey>> allInputAxisKeyMap = axisBinding.GetAllInputAxisKeyMap();
					if (allInputAxisKeyMap != null)
					{
						foreach (KeyValuePair<EInputBindingType, Dictionary<string, InputAxisKey>> keyValuePair in allInputAxisKeyMap)
						{
							EInputBindingType key = keyValuePair.Key;
							Dictionary<string, InputAxisKey> value = keyValuePair.Value;
							Dictionary<string, float> dictionary = new Dictionary<string, float>();
							foreach (DicStringInt dicStringInt in enumerable)
							{
								string key2 = dicStringInt.Key;
								int value2 = dicStringInt.Value;
								InputAxisKey inputAxisKey;
								if (value.TryGetValue(key2, out inputAxisKey))
								{
									float value3 = 0f;
									float scale = inputAxisKey.Scale;
									if (value2 == 0)
									{
										if (bRevert)
										{
											value3 = ((scale > 0f) ? (-scale) : scale);
										}
										else
										{
											value3 = ((scale > 0f) ? scale : (-scale));
										}
									}
									if (value2 == 1)
									{
										if (bRevert)
										{
											value3 = ((scale > 0f) ? scale : (-scale));
										}
										else
										{
											value3 = ((scale > 0f) ? (-scale) : scale);
										}
									}
									dictionary[key2] = value3;
								}
							}
							if (dictionary.Count > 0)
							{
								axisBinding.SetKeys(dictionary, key);
							}
						}
					}
				}
			}
		}

		// Token: 0x0604580F RID: 284687 RVA: 0x0122C18C File Offset: 0x0122A38C
		public static void ApplyGamepadLockEnemyMode(int value)
		{
			ControllerBase<FormationDataController>.Instance.SetGamepadLockEnemyMode((ELockEnemyMode)value);
		}

		// Token: 0x06045810 RID: 284688 RVA: 0x0122C199 File Offset: 0x0122A399
		public static void ApplyEnemyHitDisplayMode(int value)
		{
			ModelBase<BulletModel>.Instance.OpenHitMaterial = (value == 1);
		}

		// Token: 0x06045811 RID: 284689 RVA: 0x0122C1AC File Offset: 0x0122A3AC
		public static void ApplyPushEnableState(int value, EGameSettingsApplyReason? reason = null)
		{
			if (value == 0)
			{
				ControllerBase<KuroPushController>.Instance.TurnOffPush();
				return;
			}
			bool checkPermissionState = reason.GetValueOrDefault() == EGameSettingsApplyReason.WhenUi;
			ControllerBase<KuroPushController>.Instance.TurnOnPush(checkPermissionState);
		}

		// Token: 0x06045812 RID: 284690 RVA: 0x0122C1DE File Offset: 0x0122A3DE
		public static void ApplyAutoAdjustImageQuality(int value)
		{
			Singleton<GameSettingsDeviceRender>.Instance.SetIsAutoAdjustImageQuality(value == 1);
			if (PerfSightController.IsEnable)
			{
				UPerfSightHelper.PostEvent(824, value.ToString());
			}
		}

		// Token: 0x06045813 RID: 284691 RVA: 0x0122C206 File Offset: 0x0122A406
		public static void ApplyShowDamage(int value)
		{
			Singleton<DamageUiManager>.Instance.SetDamageViewVisible(value == 1);
		}

		// Token: 0x06045814 RID: 284692 RVA: 0x0122C216 File Offset: 0x0122A416
		public static void ApplyDynamicBones(int value)
		{
			ControllerBase<CreatureController>.Instance.SetKawaiiEnable(value);
		}

		// Token: 0x06045815 RID: 284693 RVA: 0x0122C224 File Offset: 0x0122A424
		public static void ApplyDolbyAtmos(int value)
		{
			Singleton<AudioSystem>.Instance.SetRtpcValue("dolby_atmos", (float)value, null);
		}

		// Token: 0x06045816 RID: 284694 RVA: 0x0122C24B File Offset: 0x0122A44B
		public static bool ApplyUiPureMode(int value)
		{
			if (value == 1)
			{
				ControllerBase<BattleUiControl>.Instance.TryOpenPureMode();
				return false;
			}
			return ControllerBase<BattleUiControl>.Instance.TryClosePureMode();
		}

		// Token: 0x06045817 RID: 284695 RVA: 0x0122C268 File Offset: 0x0122A468
		public unsafe static bool ApplyRayTracing(int value)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler;
			if (value > 0)
			{
				UObject world = GlobalData.World;
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(21, 1);
				defaultInterpolatedStringHandler.AppendLiteral("sg.RayTracingQuality ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(value);
				UKismetSystemLibrary.ExecuteConsoleCommand(world, defaultInterpolatedStringHandler.ToStringAndClear(), null);
			}
			string path = UBlueprintPathsLibrary.ProjectSavedDir() + "SaveGames/RTX.json";
			if (UKuroStaticLibrary.FileExists(path))
			{
				UKuroStaticLibrary.DeleteFile(path, false, false, false);
			}
			UKuroRenderingRuntimeBPPluginBPLibrary.SetRayTracingEnable(value > 0);
			bool flag = !Singleton<GameSettingsDeviceRender>.Instance.IsNvidiaGPU() || Singleton<GameSettingsDeviceRender>.Instance.IsDlss3GpuDevice();
			bool flag2 = value > 0 && flag;
			UObject world2 = GlobalData.World;
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(21, 1);
			defaultInterpolatedStringHandler.AppendLiteral("r.MegaLights.Allowed ");
			defaultInterpolatedStringHandler.AppendFormatted<int>((flag2 > false) ? 1 : 0);
			UKismetSystemLibrary.ExecuteConsoleCommand(world2, defaultInterpolatedStringHandler.ToStringAndClear(), null);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.GameSettings;
			ELogAuthor author = ELogAuthor.WX;
			string message = "MegaLights 开关";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("rayTracing", value);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("allowMegaLights", flag2);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			if (PerfSightController.IsEnable)
			{
				UPerfSightHelper.PostEvent(821, value.ToString());
			}
			return true;
		}

		// Token: 0x06045818 RID: 284696 RVA: 0x0122C3A4 File Offset: 0x0122A5A4
		public static bool ApplyRayTracedReflection(int value)
		{
			if (value > 0)
			{
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.Lumen.Reflections.Allow 1", null);
				Singleton<Log>.Instance.Info(ELogModule.GameSettings, ELogAuthor.WX, "光追反射开启", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			else
			{
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.Lumen.Reflections.Allow 0", null);
				Singleton<Log>.Instance.Info(ELogModule.GameSettings, ELogAuthor.WX, "光追反射关闭", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			if (PerfSightController.IsEnable)
			{
				UPerfSightHelper.PostEvent(822, value.ToString());
			}
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.UpdateRayTraceReflection, value > 0);
			return true;
		}

		// Token: 0x06045819 RID: 284697 RVA: 0x0122C444 File Offset: 0x0122A644
		public static bool ApplyRayTracedGI(int value)
		{
			if (value > 0)
			{
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.Lumen.DiffuseIndirect.Allow 1", null);
				Singleton<Log>.Instance.Info(ELogModule.GameSettings, ELogAuthor.WX, "光追全局光照开启", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			else
			{
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.Lumen.DiffuseIndirect.Allow 0", null);
				Singleton<Log>.Instance.Info(ELogModule.GameSettings, ELogAuthor.WX, "光追全局光照关闭", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			if (PerfSightController.IsEnable)
			{
				UPerfSightHelper.PostEvent(823, value.ToString());
			}
			return true;
		}

		// Token: 0x0604581A RID: 284698 RVA: 0x0122C4D0 File Offset: 0x0122A6D0
		public static bool ApplyRayTracedShadow(int value)
		{
			if (value > 0)
			{
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.RayTracing.Shadows 1", null);
				Singleton<Log>.Instance.Info(ELogModule.GameSettings, ELogAuthor.WX, "光追阴影开启", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			else
			{
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.RayTracing.Shadows 0", null);
				Singleton<Log>.Instance.Info(ELogModule.GameSettings, ELogAuthor.WX, "光追阴影关闭", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			return true;
		}

		// Token: 0x0604581B RID: 284699 RVA: 0x0122C544 File Offset: 0x0122A744
		public static bool ApplySaturationClient(int value)
		{
			float value2 = 1f;
			if (value <= 50)
			{
				value2 = Singleton<MathUtils>.Instance.Lerp(0f, 1f, (float)(value * 2) / 100f);
			}
			if (value > 50)
			{
				value2 = Singleton<MathUtils>.Instance.Lerp(1f, 2f, (float)((value - 50) * 2) / 100f);
			}
			UObject world = GlobalData.World;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(20, 1);
			defaultInterpolatedStringHandler.AppendLiteral("r.Client.Saturation ");
			defaultInterpolatedStringHandler.AppendFormatted<float>(value2);
			UKismetSystemLibrary.ExecuteConsoleCommand(world, defaultInterpolatedStringHandler.ToStringAndClear(), null);
			return true;
		}

		// Token: 0x0604581C RID: 284700 RVA: 0x0122C5D4 File Offset: 0x0122A7D4
		public static bool ApplyContrastClient(int value)
		{
			float value2 = 1f;
			if (value <= 50)
			{
				value2 = Singleton<MathUtils>.Instance.Lerp(0.5f, 1f, (float)(value * 2) / 100f);
			}
			if (value > 50)
			{
				value2 = Singleton<MathUtils>.Instance.Lerp(1f, 2f, (float)((value - 50) * 2) / 100f);
			}
			UObject world = GlobalData.World;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(18, 1);
			defaultInterpolatedStringHandler.AppendLiteral("r.Client.Contrast ");
			defaultInterpolatedStringHandler.AppendFormatted<float>(value2);
			UKismetSystemLibrary.ExecuteConsoleCommand(world, defaultInterpolatedStringHandler.ToStringAndClear(), null);
			return true;
		}

		// Token: 0x0604581D RID: 284701 RVA: 0x0122C663 File Offset: 0x0122A863
		public static void ApplySkinDamageMode(int value)
		{
			CharacterSkinDamageComponent.EnableSkinDamage = (value == 1);
			Singleton<EventSystem>.Instance.Emit(EEventName.OnResetSkinDamageMode);
		}

		// Token: 0x0604581E RID: 284702 RVA: 0x0122C680 File Offset: 0x0122A880
		public static void ApplyAFMEOption(int value)
		{
			Singleton<GameSettingsDeviceRender>.Instance.EnableAFME(value);
			if (PerfSightController.IsEnable)
			{
				if (UKismetSystemLibrary.GetConsoleVariableIntValue("r.KuroFI.Enable") == 1)
				{
					UPerfSightHelper.PostEvent(829, (value != 0) ? "1" : "0");
					return;
				}
				UPerfSightHelper.PostEvent(828, (value != 0) ? "1" : "0");
			}
		}

		// Token: 0x0604581F RID: 284703 RVA: 0x0122C6E1 File Offset: 0x0122A8E1
		public static bool ApplyAutoRun(int value)
		{
			if (ModelBase<BattleUiModel>.Instance == null)
			{
				return false;
			}
			if (ModelBase<BattleUiModel>.Instance.FormationData == null)
			{
				return false;
			}
			ModelBase<BattleUiModel>.Instance.FormationData.AutoMovingSettingEnable = (value > 0);
			return true;
		}

		// Token: 0x06045820 RID: 284704 RVA: 0x0122C70E File Offset: 0x0122A90E
		public static bool ApplyAutoSprint(int value)
		{
			if (ModelBase<BattleUiModel>.Instance == null)
			{
				return false;
			}
			if (ModelBase<BattleUiModel>.Instance.FormationData == null)
			{
				return false;
			}
			ModelBase<BattleUiModel>.Instance.FormationData.AutoSprintSettingEnable = (value > 0);
			return true;
		}

		// Token: 0x06045821 RID: 284705 RVA: 0x0122C73B File Offset: 0x0122A93B
		public static bool ApplyVulkan(int value)
		{
			UKuroRenderingRuntimeBPPluginBPLibrary.SetVulkanPromotion(value > 0);
			return true;
		}

		// Token: 0x06045822 RID: 284706 RVA: 0x0122C748 File Offset: 0x0122A948
		public static bool ApplyWaterInteract(int value)
		{
			if (value == 0)
			{
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.MarchingCubes.EnablePrePass 0", null);
			}
			else
			{
				HashSet<string> hashSet = new HashSet<string>();
				hashSet.Add("Windows_AMD_Graphics");
				hashSet.Add("Windows_IntelARCB570");
				hashSet.Add("Windows_IntelARCA770");
				hashSet.Add("Windows_IntelARCMiddle");
				hashSet.Add("Windows_Intel");
				string deviceProfileProfileName = UKuroRenderingRuntimeBPPluginBPLibrary.GetDeviceProfileProfileName();
				if (!hashSet.Contains(deviceProfileProfileName))
				{
					UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.MarchingCubes.EnablePrePass 1", null);
				}
			}
			ModelBase<SceneBattleInteractModel>.Instance.Open = (value > 0);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.SetEnvironmentInteraction, value);
			return true;
		}

		// Token: 0x06045823 RID: 284707 RVA: 0x0122C7EC File Offset: 0x0122A9EC
		public static bool ApplyVegetationDither(int value)
		{
			FName parameterName = new FName("FoliageDitherState");
			UKismetMaterialLibrary.SetScalarParameterValue(GlobalData.World, Singleton<RenderDataManager>.Instance.GetGlobalShaderParameters(), parameterName, (value > 0) ? 1f : 0f);
			return true;
		}

		// Token: 0x06045824 RID: 284708 RVA: 0x0122C82C File Offset: 0x0122AA2C
		public static bool ApplyVegetationDensity(int value)
		{
			switch (value)
			{
			case 0:
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "foliage.DensityScale 0.6", null);
				break;
			case 1:
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "foliage.DensityScale 0.7", null);
				break;
			case 2:
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "foliage.DensityScale 0.8", null);
				break;
			case 3:
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "foliage.DensityScale 1", null);
				break;
			}
			return true;
		}

		// Token: 0x06045825 RID: 284709 RVA: 0x0122C898 File Offset: 0x0122AA98
		public static bool ApplyImageDisplayMode(int value)
		{
			switch (value)
			{
			case 0:
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.Kuro.KuroEnableScreenFilter 0", null);
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.Tonemapper.BrightnessAndTextureDisable 1", null);
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.BlueLightFilter.Disable 1", null);
				break;
			case 1:
				if (ControllerBase<FilterSettingController>.Instance.IsFilterSettingChange())
				{
					UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.Kuro.KuroEnableScreenFilter 1", null);
				}
				else
				{
					UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.Kuro.KuroEnableScreenFilter 0", null);
				}
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.Tonemapper.BrightnessAndTextureDisable 1", null);
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.BlueLightFilter.Disable 1", null);
				break;
			case 2:
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.Kuro.KuroEnableScreenFilter 0", null);
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.Tonemapper.BrightnessAndTextureDisable 0", null);
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.BlueLightFilter.Disable 0", null);
				break;
			}
			return true;
		}

		// Token: 0x06045826 RID: 284710 RVA: 0x0122C974 File Offset: 0x0122AB74
		public static bool ApplyEyeProtectionMode(int value)
		{
			UKuroGISystem.ApplyEyeProtectionEnvironment(GlobalData.World, (float)value);
			if (value == 2)
			{
				float currentValueSafelyFloat = Singleton<GameSettingsManager>.Instance.GetCurrentValueSafelyFloat(EFunction.EyeProtectionTemp, 0f);
				float currentValueSafelyFloat2 = Singleton<GameSettingsManager>.Instance.GetCurrentValueSafelyFloat(EFunction.EyeProtectionStrength, 0f);
				float currentValueSafelyFloat3 = Singleton<GameSettingsManager>.Instance.GetCurrentValueSafelyFloat(EFunction.EyeProtectionBrightness, 0f);
				float currentValueSafelyFloat4 = Singleton<GameSettingsManager>.Instance.GetCurrentValueSafelyFloat(EFunction.EyeProtectionTexture, 0f);
				GameSettingsUtils.ApplyEyeProtectionTemp(currentValueSafelyFloat, value);
				GameSettingsUtils.ApplyEyeProtectionStrength(currentValueSafelyFloat2, value);
				GameSettingsUtils.ApplyEyeProtectionBrightness(currentValueSafelyFloat3, value);
				GameSettingsUtils.ApplyEyeProtectionTexture(currentValueSafelyFloat4, value);
			}
			return true;
		}

		// Token: 0x06045827 RID: 284711 RVA: 0x0122CA04 File Offset: 0x0122AC04
		public static bool ApplyEyeProtectionTemp(float value, int mode)
		{
			UKuroGISystem.ApplyEyeProtectionTemperature(GlobalData.World, value, (float)mode);
			return true;
		}

		// Token: 0x06045828 RID: 284712 RVA: 0x0122CA14 File Offset: 0x0122AC14
		public static bool ApplyEyeProtectionStrength(float value, int mode)
		{
			UKuroGISystem.ApplyEyeProtectionStrength(GlobalData.World, value, (float)mode);
			return true;
		}

		// Token: 0x06045829 RID: 284713 RVA: 0x0122CA24 File Offset: 0x0122AC24
		public static bool ApplyEyeProtectionBrightness(float value, int mode)
		{
			UKuroGISystem.ApplyEyeProtectionBrightness(GlobalData.World, value, (float)mode);
			return true;
		}

		// Token: 0x0604582A RID: 284714 RVA: 0x0122CA34 File Offset: 0x0122AC34
		public static bool ApplyEyeProtectionTexture(float value, int mode)
		{
			UKuroGISystem.ApplyEyeProtectionTexture(GlobalData.World, value, (float)mode);
			return true;
		}

		// Token: 0x0604582B RID: 284715 RVA: 0x0122CA44 File Offset: 0x0122AC44
		public static bool ApplyAutoExposure(int value)
		{
			UObject world = GlobalData.World;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(32, 1);
			defaultInterpolatedStringHandler.AppendLiteral("r.Kuro.AutoExposurePlayerCustom ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(value);
			UKismetSystemLibrary.ExecuteConsoleCommand(world, defaultInterpolatedStringHandler.ToStringAndClear(), null);
			return true;
		}

		// Token: 0x0604582C RID: 284716 RVA: 0x0122CA82 File Offset: 0x0122AC82
		public static void ApplyAdjustiveGamePadTrigger(int value)
		{
			UTriggerEffectBPLibrary.SetTriggerEffectState(Global.CharacterController, value == 1);
		}

		// Token: 0x0604582D RID: 284717 RVA: 0x0122CA92 File Offset: 0x0122AC92
		public static float MapGamepadDeadZoneUiToEngine(int uiValue)
		{
			if (Singleton<Info>.Instance.IsIosPlatform())
			{
				return (float)(uiValue - 10) * 0.01f;
			}
			return (float)uiValue / 100f * 0.9f;
		}

		// Token: 0x0604582E RID: 284718 RVA: 0x0122CABA File Offset: 0x0122ACBA
		public static void ApplyGamepadLeftStickDeadZone(int uiValue)
		{
			GameSettingsUtils.ApplyGamepadDeadZoneToKeys(uiValue, new EKey[]
			{
				EKey.Gamepad_LeftX,
				EKey.Gamepad_LeftY
			});
		}

		// Token: 0x0604582F RID: 284719 RVA: 0x0122CAE0 File Offset: 0x0122ACE0
		public static void ApplyGamepadRightStickDeadZone(int uiValue)
		{
			GameSettingsUtils.ApplyGamepadDeadZoneToKeys(uiValue, new EKey[]
			{
				EKey.Gamepad_RightX,
				EKey.Gamepad_RightY
			});
		}

		// Token: 0x06045830 RID: 284720 RVA: 0x0122CB06 File Offset: 0x0122AD06
		public static void ApplyGamepadLeftTriggerDeadZone(int uiValue)
		{
			GameSettingsUtils.ApplyGamepadDeadZoneToKeys(uiValue, new EKey[]
			{
				EKey.Gamepad_LeftTriggerAxis
			});
		}

		// Token: 0x06045831 RID: 284721 RVA: 0x0122CB20 File Offset: 0x0122AD20
		public static void ApplyGamepadRightTriggerDeadZone(int uiValue)
		{
			GameSettingsUtils.ApplyGamepadDeadZoneToKeys(uiValue, new EKey[]
			{
				EKey.Gamepad_RightTriggerAxis
			});
		}

		// Token: 0x06045832 RID: 284722 RVA: 0x0122CB3C File Offset: 0x0122AD3C
		private static void ApplyGamepadDeadZoneToKeys(int uiValue, EKey[] keys)
		{
			float deadZone = GameSettingsUtils.MapGamepadDeadZoneUiToEngine(uiValue);
			int playerIndex = 0;
			foreach (EKey key in keys)
			{
				UKuroStaticLibrary.SetInputKeyDeadZone(Global.CharacterController, playerIndex, new FKey(new FName(key)), deadZone);
			}
		}

		// Token: 0x06045833 RID: 284723 RVA: 0x0122CB88 File Offset: 0x0122AD88
		public static void ApplyMotorAutoLongPressSpeedUp(int value)
		{
			ModelBase<BattleUiModel>.Instance.MotorcycleData.AutoNitrogenSettingEnable = (value == 1);
		}

		// Token: 0x06045834 RID: 284724 RVA: 0x0122CB9D File Offset: 0x0122AD9D
		public static void ApplyMotorAutoAcceleratorSettingEnable(int value)
		{
			ModelBase<BattleUiModel>.Instance.MotorcycleData.AutoAcceleratorSettingEnable = (value == 1);
		}

		// Token: 0x06045835 RID: 284725 RVA: 0x0122CBB2 File Offset: 0x0122ADB2
		public static void ApplyMotorDriftAcceleratorSettingEnable(int value)
		{
			ModelBase<BattleUiModel>.Instance.MotorcycleData.DriftAcceleratorSettingEnable = (value == 1);
		}

		// Token: 0x06045836 RID: 284726 RVA: 0x0122CBC7 File Offset: 0x0122ADC7
		public static void ApplyMotorHudVisible(int value)
		{
			ModelBase<BattleUiModel>.Instance.MotorcycleData.SetHudVisible(value == 0, "设置系统设置");
		}

		// Token: 0x06045837 RID: 284727 RVA: 0x0122CBE1 File Offset: 0x0122ADE1
		public static void ApplyMotorIsDynamicJoystick(int value)
		{
			ModelBase<BattleUiModel>.Instance.MotorcycleData.SetIsDynamicJoystick(value == 1);
		}

		// Token: 0x06045838 RID: 284728 RVA: 0x0122CBF8 File Offset: 0x0122ADF8
		public static void ApplyUiBrightness(float value)
		{
			int? dataCacheOrCurValue = ModelBase<MenuModel>.Instance.GetDataCacheOrCurValue(EFunction.PeakBrightness);
			UKuroGISystem.ApplyHDRMetaData(GlobalData.World, value, (float)dataCacheOrCurValue.GetValueOrDefault());
		}

		// Token: 0x06045839 RID: 284729 RVA: 0x0122CC28 File Offset: 0x0122AE28
		public static void ApplyPeakBrightness(float value)
		{
			int? dataCacheOrCurValue = ModelBase<MenuModel>.Instance.GetDataCacheOrCurValue(EFunction.UiBrightness);
			UKuroGISystem.ApplyHDRMetaData(GlobalData.World, (float)dataCacheOrCurValue.GetValueOrDefault(), value);
		}

		// Token: 0x0604583A RID: 284730 RVA: 0x0122CC58 File Offset: 0x0122AE58
		public static void ApplyAnisoLevel(int value)
		{
			switch (value)
			{
			case 0:
				UKuroRenderingRuntimeBPPluginBPLibrary.SetAnisoLevel(1);
				break;
			case 1:
				UKuroRenderingRuntimeBPPluginBPLibrary.SetAnisoLevel(2);
				break;
			case 2:
				UKuroRenderingRuntimeBPPluginBPLibrary.SetAnisoLevel(4);
				break;
			case 3:
				UKuroRenderingRuntimeBPPluginBPLibrary.SetAnisoLevel(8);
				break;
			case 4:
				UKuroRenderingRuntimeBPPluginBPLibrary.SetAnisoLevel(16);
				break;
			}
			if (PerfSightController.IsEnable)
			{
				UPerfSightHelper.PostEvent(837, value.ToString());
			}
		}

		// Token: 0x0604583B RID: 284731 RVA: 0x0122CCC0 File Offset: 0x0122AEC0
		public unsafe static bool ApplyLoadingRangeScaleLevel(int value)
		{
			int? dataCacheOrCurValue = ModelBase<MenuModel>.Instance.GetDataCacheOrCurValue(EFunction.IMAGEQUALITY);
			if (dataCacheOrCurValue == null)
			{
				return false;
			}
			DeviceRenderFeature? deviceRenderFeature = Singleton<GameSettingsDeviceRender>.Instance.GetDeviceRenderFeature((EGameQualitySettingLevel)dataCacheOrCurValue.Value);
			if (deviceRenderFeature == null)
			{
				return false;
			}
			int loadingRangeScale = deviceRenderFeature.Value.LoadingRangeScale;
			float num = (float)(loadingRangeScale - 100) / 2f;
			float num2 = Singleton<MathUtils>.Instance.Clamp(100f + num * (float)value, 100f, (float)loadingRangeScale) / 100f;
			UObject world = GlobalData.World;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(41, 1);
			defaultInterpolatedStringHandler.AppendLiteral("wp.Runtime.PlannedLoadingRangeScaleExtra ");
			defaultInterpolatedStringHandler.AppendFormatted<float>(num2);
			UKismetSystemLibrary.ExecuteConsoleCommand(world, defaultInterpolatedStringHandler.ToStringAndClear(), null);
			UObject world2 = GlobalData.World;
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(34, 1);
			defaultInterpolatedStringHandler.AppendLiteral("wp.Runtime.LoadingRangeScaleExtra ");
			defaultInterpolatedStringHandler.AppendFormatted<float>(num2);
			UKismetSystemLibrary.ExecuteConsoleCommand(world2, defaultInterpolatedStringHandler.ToStringAndClear(), null);
			if (GameSettingsUtils.GrassCullDistanceCache != null && GameSettingsUtils.GrassMobileCullDistanceCache != null && GameSettingsUtils.GrassLODDistanceScaleCache != null)
			{
				if (Singleton<Info>.Instance.IsPcOrGamepadPlatform())
				{
					float num3 = GameSettingsUtils.GrassCullDistanceCache.Value * num2;
					UKuroStaticLibrary.SetConsoleVariableWithCurrentPriority_Float("r.Kuro.Foliage.GrassCullDistanceMax", num3);
					float num4 = GameSettingsUtils.GrassLODDistanceScaleCache.Value + 0.3f * (float)value;
					UKuroStaticLibrary.SetConsoleVariableWithCurrentPriority_Float("foliage.LODDistanceScale", num4);
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.GameSettings;
					ELogAuthor author = ELogAuthor.LQX;
					string message = "ApplyLoadingRangeScaleLevel";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("grassCullDistance", num3);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("grassLODDistanceScale", num4);
					instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				}
				else
				{
					float num5 = GameSettingsUtils.GrassMobileCullDistanceCache.Value * num2;
					UKuroStaticLibrary.SetConsoleVariableWithCurrentPriority_Float("r.Kuro.Foliage.MobileGrassCullDistanceMax", num5);
					float num6 = GameSettingsUtils.GrassLODDistanceScaleCache.Value + 0.15f * (float)value;
					UKuroStaticLibrary.SetConsoleVariableWithCurrentPriority_Float("foliage.LODDistanceScale", num6);
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.GameSettings;
					ELogAuthor author2 = ELogAuthor.LQX;
					string message2 = "ApplyLoadingRangeScaleLevel";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("grassCullDistance", num5);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("grassLODDistanceScale", num6);
					instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				}
			}
			Singleton<EventSystem>.Instance.Emit<float>(EEventName.LoadingRangeScaleChanged, num2);
			if (PerfSightController.IsEnable)
			{
				UPerfSightHelper.PostEvent(838, value.ToString());
			}
			return true;
		}

		// Token: 0x04026D1D RID: 159005
		private static int? NvidiaSuperSamplingQualityCache;

		// Token: 0x04026D1E RID: 159006
		private static int? KuroLocalRenderSettingIndexCache;

		// Token: 0x04026D1F RID: 159007
		private static bool XessEnabled;

		// Token: 0x04026D20 RID: 159008
		private static bool Fsr3FgEnable;

		// Token: 0x04026D21 RID: 159009
		private static EFFXFIApplyMode Fsr3FgApplyMode;

		// Token: 0x04026D22 RID: 159010
		[Nullable(2)]
		private static Dictionary<int, int> Fsr3FgSwitchStates;

		// Token: 0x04026D23 RID: 159011
		private static bool Fsr3FgInTemporaryApplyState;

		// Token: 0x04026D24 RID: 159012
		private static float? GrassCullDistanceCache;

		// Token: 0x04026D25 RID: 159013
		private static float? GrassMobileCullDistanceCache;

		// Token: 0x04026D26 RID: 159014
		private static float? GrassLODDistanceScaleCache;
	}
}
