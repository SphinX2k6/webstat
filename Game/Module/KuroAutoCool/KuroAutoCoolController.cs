using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Extension;
using CSharpScript.Core.Framework;
using CSharpScript.Game.GameSettings;
using CSharpScript.Launcher.Platform;
using UnrealEngine;

namespace CSharpScript.Game.Module.KuroAutoCool
{
	// Token: 0x02005AF7 RID: 23287
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[TickController(0)]
	public class KuroAutoCoolController : ControllerBase<KuroAutoCoolController>
	{
		// Token: 0x0603AE4C RID: 241228 RVA: 0x00EEEF7C File Offset: 0x00EED17C
		public void SetMaxFrameRate(int fps)
		{
			UObject world = GlobalData.World;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 1);
			defaultInterpolatedStringHandler.AppendLiteral("t.MaxFPS ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(fps);
			UKismetSystemLibrary.ExecuteConsoleCommand(world, defaultInterpolatedStringHandler.ToStringAndClear(), null);
		}

		// Token: 0x0603AE4D RID: 241229 RVA: 0x00EEEFB9 File Offset: 0x00EED1B9
		public int GetMaxFrameRate()
		{
			return (int)UKismetSystemLibrary.GetConsoleVariableFloatValue("t.MaxFPS");
		}

		// Token: 0x0603AE4E RID: 241230 RVA: 0x00EEEFC6 File Offset: 0x00EED1C6
		public int? GetCurrentValue(int handle)
		{
			return Singleton<GameSettingsManager>.Instance.GetCurrentValue((EFunction)handle, true, true);
		}

		// Token: 0x0603AE4F RID: 241231 RVA: 0x00EEEFD8 File Offset: 0x00EED1D8
		public void ApplyNiagaraQuality(int value)
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

		// Token: 0x0603AE50 RID: 241232 RVA: 0x00EEF060 File Offset: 0x00EED260
		public void ApplyMobileResolution(int value)
		{
			float num = (float)Singleton<GameSettingsDeviceRender>.Instance.GetMobileResolutionByIndex(value);
			float consoleVariableFloatValue = UKismetSystemLibrary.GetConsoleVariableFloatValue("r.SecondaryScreenPercentage.GameViewport");
			if (Singleton<GameSettingsDeviceRender>.Instance.GetDefaultScreenResolution().Y < 750 && consoleVariableFloatValue < 70f)
			{
				num = Math.Min(num * 1.5f, 100f);
			}
			UObject world = GlobalData.World;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(19, 1);
			defaultInterpolatedStringHandler.AppendLiteral("r.ScreenPercentage ");
			defaultInterpolatedStringHandler.AppendFormatted<float>(num);
			UKismetSystemLibrary.ExecuteConsoleCommand(world, defaultInterpolatedStringHandler.ToStringAndClear(), null);
		}

		// Token: 0x0603AE51 RID: 241233 RVA: 0x00EEF0E8 File Offset: 0x00EED2E8
		public unsafe void ReduceImageQualityAndFrameRate(int currentFps)
		{
			int? currentValue = this.GetCurrentValue(67);
			int? currentValue2 = this.GetCurrentValue(55);
			int? currentValue3 = this.GetCurrentValue(64);
			int? currentValue4 = this.GetCurrentValue(56);
			int? currentValue5 = this.GetCurrentValue(54);
			int? currentValue6 = this.GetCurrentValue(79);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Render;
			ELogAuthor author = ELogAuthor.YJL;
			string message = "自动渲染调节触发前";
			<>y__InlineArray7<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray7<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CurrentFps", currentFps);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Resolution", currentValue);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Niagara", currentValue2);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("ImageDetail", currentValue4);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("VolumeLight", currentValue3);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("Shadow", currentValue5);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 6) = new ValueTuple<string, object>("NpcDensity", currentValue6);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 7));
			if (currentFps > 55)
			{
				this.IsAutoCoolState = true;
				this.SetMaxFrameRate(55);
				currentFps = 55;
				if (currentValue2 != null)
				{
					int? num = currentValue2;
					int num2 = 1;
					if (num.GetValueOrDefault() > num2 & num != null)
					{
						this.ApplyNiagaraQuality(1);
						currentValue2 = new int?(1);
					}
				}
				if (currentValue != null)
				{
					int? num = currentValue;
					int num2 = 1;
					if (num.GetValueOrDefault() > num2 & num != null)
					{
						this.ApplyMobileResolution(1);
						currentValue = new int?(1);
					}
				}
			}
			else if (currentFps > 50 && currentFps <= 55)
			{
				this.IsAutoCoolState = true;
				this.SetMaxFrameRate(50);
				currentFps = 50;
				if (currentValue3 != null)
				{
					int? num = currentValue3;
					int num2 = 0;
					if (num.GetValueOrDefault() > num2 & num != null)
					{
						GameSettingsUtils.ApplyVolumeLight(0);
						currentValue3 = new int?(0);
					}
				}
				if (currentValue4 != null)
				{
					int? num = currentValue4;
					int num2 = 1;
					if (num.GetValueOrDefault() > num2 & num != null)
					{
						GameSettingsUtils.ApplyImageDetail(1);
						currentValue4 = new int?(1);
					}
				}
			}
			else if (currentFps > 45 && currentFps <= 50)
			{
				this.IsAutoCoolState = true;
				this.SetMaxFrameRate(45);
				currentFps = 45;
				if (currentValue6 != null)
				{
					int? num = currentValue6;
					int num2 = 1;
					if (num.GetValueOrDefault() > num2 & num != null)
					{
						GameSettingsUtils.ApplyNpcDensity(1);
						currentValue6 = new int?(1);
					}
				}
			}
			else if (currentFps > 40 && currentFps <= 45)
			{
				this.IsAutoCoolState = true;
				this.SetMaxFrameRate(40);
				currentFps = 40;
				if (currentValue5 != null)
				{
					int? num = currentValue5;
					int num2 = 1;
					if (num.GetValueOrDefault() > num2 & num != null)
					{
						GameSettingsUtils.ApplyShadowQuality(1);
						currentValue5 = new int?(1);
					}
				}
			}
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Render;
			ELogAuthor author2 = ELogAuthor.YJL;
			string message2 = "自动渲染调节触发后";
			<>y__InlineArray7<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray7<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("CurrentFps", currentFps);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("Resolution", currentValue);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("Niagara", currentValue2);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 3) = new ValueTuple<string, object>("ImageDetail", currentValue4);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 4) = new ValueTuple<string, object>("VolumeLight", currentValue3);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 5) = new ValueTuple<string, object>("Shadow", currentValue5);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 6) = new ValueTuple<string, object>("NpcDensity", currentValue6);
			instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 7));
		}

		// Token: 0x0603AE52 RID: 241234 RVA: 0x00EEF4D4 File Offset: 0x00EED6D4
		public unsafe void RestoreImageQualityAndFrameRate(int currentFps)
		{
			int? currentValue = this.GetCurrentValue(67);
			int? currentValue2 = this.GetCurrentValue(55);
			int? currentValue3 = this.GetCurrentValue(64);
			int? currentValue4 = this.GetCurrentValue(56);
			int? currentValue5 = this.GetCurrentValue(54);
			int? currentValue6 = this.GetCurrentValue(79);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Render;
			ELogAuthor author = ELogAuthor.YJL;
			string message = "自动渲染调节恢复前";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("CurrentFps", currentFps);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			if (Singleton<Platform>.Instance.IsMobilePlatform())
			{
				this.IsAutoCoolState = false;
			}
			int num = currentFps;
			if (currentFps >= 55)
			{
				this.IsAutoCoolState = false;
				MenuModel instance2 = ModelBase<MenuModel>.Instance;
				int valueOrDefault = ((instance2 != null) ? instance2.GetDataCacheOrCurValue(EFunction.HIGHESTFPS) : null).GetValueOrDefault();
				num = Singleton<GameSettingsDeviceRender>.Instance.GetFrameByList(valueOrDefault);
				if (currentValue2 != null)
				{
					int? num2 = currentValue2;
					int num3 = 1;
					if (num2.GetValueOrDefault() > num3 & num2 != null)
					{
						this.ApplyNiagaraQuality(currentValue2.Value);
					}
				}
				if (currentValue != null)
				{
					int? num2 = currentValue;
					int num3 = 1;
					if (num2.GetValueOrDefault() > num3 & num2 != null)
					{
						this.ApplyMobileResolution(currentValue.Value);
					}
				}
			}
			else if (currentFps >= 50 && currentFps < 55)
			{
				num = 55;
				if (currentValue3 != null)
				{
					int? num2 = currentValue3;
					int num3 = 0;
					if (num2.GetValueOrDefault() > num3 & num2 != null)
					{
						GameSettingsUtils.ApplyVolumeLight(currentValue3.Value);
					}
				}
				if (currentValue4 != null)
				{
					int? num2 = currentValue4;
					int num3 = 1;
					if (num2.GetValueOrDefault() > num3 & num2 != null)
					{
						GameSettingsUtils.ApplyImageDetail(currentValue4.Value);
					}
				}
			}
			else if (currentFps >= 45 && currentFps < 50)
			{
				num = 50;
				if (currentValue6 != null)
				{
					int? num2 = currentValue6;
					int num3 = 1;
					if (num2.GetValueOrDefault() > num3 & num2 != null)
					{
						GameSettingsUtils.ApplyNpcDensity(currentValue6.Value);
					}
				}
			}
			else if (currentFps >= 40 && currentFps < 45)
			{
				num = 45;
				if (currentValue5 != null)
				{
					int? num2 = currentValue5;
					int num3 = 1;
					if (num2.GetValueOrDefault() > num3 & num2 != null)
					{
						GameSettingsUtils.ApplyShadowQuality(currentValue5.Value);
					}
				}
			}
			this.SetMaxFrameRate(num);
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Render;
			ELogAuthor author2 = ELogAuthor.YJL;
			string message2 = "自动渲染调节恢复后";
			<>y__InlineArray7<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray7<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("MaxFps", num);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Resolution", currentValue);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Niagara", currentValue2);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("ImageDetail", currentValue4);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("VolumeLight", currentValue3);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("NpcDensity", currentValue6);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 6) = new ValueTuple<string, object>("Shadow", currentValue5);
			instance3.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 7));
		}

		// Token: 0x0603AE53 RID: 241235 RVA: 0x00EEF804 File Offset: 0x00EEDA04
		private unsafe void OnGetTemperatureDataFromMAGT(bool bResult, float currentTemperature, float tempBudget)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Render;
			ELogAuthor author = ELogAuthor.YJL;
			string message = "KuroAutoCoolController.temperature";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("bResult", bResult);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("currentTemperature", currentTemperature);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("tempBudget", tempBudget);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			int maxFps = UKuroRenderingRuntimeBPPluginBPLibrary.GetMaxFps();
			if (!bResult || tempBudget <= 5f)
			{
				this.ReduceImageQualityAndFrameRate(maxFps);
				return;
			}
			if (this.IsAutoCoolState)
			{
				this.RestoreImageQualityAndFrameRate(maxFps);
			}
		}

		// Token: 0x0603AE54 RID: 241236 RVA: 0x00EEF8B4 File Offset: 0x00EEDAB4
		private void OnGetTemperatureDataFromOthers()
		{
			int cpuTemperature = UKuroRenderingRuntimeBPPluginBPLibrary.GetCpuTemperature();
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Render;
			ELogAuthor author = ELogAuthor.YJL;
			string message = "当前CPU温度";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("CpuTemperature", cpuTemperature);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.CheckCount = 0;
			int maxFps = UKuroRenderingRuntimeBPPluginBPLibrary.GetMaxFps();
			if (this.IsAutoCoolState && cpuTemperature < 65)
			{
				this.RestoreImageQualityAndFrameRate(maxFps);
				return;
			}
			if (cpuTemperature >= 65)
			{
				this.ReduceImageQualityAndFrameRate(maxFps);
			}
		}

		// Token: 0x0603AE55 RID: 241237 RVA: 0x00EEF924 File Offset: 0x00EEDB24
		private unsafe void OnAutoAdjustImageQualityPcPlatform(float delta)
		{
			if (delta <= 0f)
			{
				return;
			}
			float num = 1000f / delta;
			this.fpsHistory.Add(num);
			this.frameTimes.Add(delta);
			if (this.frameTimes.Count > 3)
			{
				this.frameTimes.RemoveAt(0);
			}
			if (this.frameTimes.Count == 3)
			{
				float num2 = (this.frameTimes[0] + this.frameTimes[1] + this.frameTimes[2]) / 3f;
				bool flag = delta > num2 * 2f && delta > 84f;
				this.jankCountHistory.Add((flag > false) ? 1 : 0);
				if (flag)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Render;
					ELogAuthor author = ELogAuthor.LQX;
					string message = "检测到Jank帧";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CurrentFrameTime", delta);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("AvgLast3FrameTime", num2);
					instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				}
			}
			long num3 = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
			if (num3 - this.lastJankCheckTime >= 5000L)
			{
				int num4 = 0;
				foreach (int num5 in this.jankCountHistory)
				{
					num4 += num5;
				}
				float num6 = (this.fpsHistory.Count > 0) ? (this.fpsHistory.Sum() / (float)this.fpsHistory.Count) : 0f;
				this.lastJankCheckTime = num3;
				this.jankCountHistory.Clear();
				this.fpsHistory.Clear();
				if (num4 >= 2)
				{
					this.consecutiveJankWindows++;
					this.consecutiveNoJankWindows = 0;
				}
				else if (num4 >= 1)
				{
					this.consecutiveNoJankWindows = 0;
				}
				else
				{
					this.consecutiveNoJankWindows++;
					this.consecutiveJankWindows = 0;
				}
				float val = 50f;
				EGameQualitySettingLevel? recommendQualityLv = Singleton<GameSettingsDeviceRender>.Instance.GetRecommendQualityLv();
				if (recommendQualityLv != null)
				{
					DeviceRenderFeature? deviceRenderFeature = Singleton<GameSettingsDeviceRender>.Instance.GetDeviceRenderFeature(recommendQualityLv.Value);
					if (deviceRenderFeature != null)
					{
						int? valueOrNull = Singleton<GameSettingsDeviceRender>.Instance.GetOtherChangedValue(deviceRenderFeature.Value).GetValueOrNull(EFunction.HIGHESTFPS);
						if (valueOrNull != null)
						{
							val = (float)Singleton<GameSettingsDeviceRender>.Instance.GetFrameByList(valueOrNull.Value);
						}
					}
				}
				float num7 = Math.Min(val, (float)this.GetMaxFrameRate()) * 0.9f;
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Render;
				ELogAuthor author2 = ELogAuthor.LQX;
				string message2 = "5秒窗口统计";
				<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray4<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("JankCount", num4);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("CurrentFrameTime", delta);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("FpsThreshold", num7);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 3) = new ValueTuple<string, object>("AvgFPS", num6);
				instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 4));
				if (!this.IsAutoCoolState && (this.consecutiveJankWindows >= 2 || num6 < num7))
				{
					Singleton<Log>.Instance.Info(ELogModule.Render, ELogAuthor.LQX, "触发降画质", default(ReadOnlySpan<ValueTuple<string, object>>));
					this.ReduceImageQualityAndFrameRate((int)num);
				}
				else if (this.IsAutoCoolState && (num4 >= 1 || num6 < num7))
				{
					Singleton<Log>.Instance.Info(ELogModule.Render, ELogAuthor.LQX, "维持降画质状态", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				else if (this.IsAutoCoolState && this.consecutiveNoJankWindows >= 3 && num6 >= num7)
				{
					Singleton<Log>.Instance.Info(ELogModule.Render, ELogAuthor.LQX, "恢复升画质", default(ReadOnlySpan<ValueTuple<string, object>>));
					this.RestoreImageQualityAndFrameRate((int)num);
				}
				this.CheckCount = 0;
			}
		}

		// Token: 0x0603AE56 RID: 241238 RVA: 0x00EEFD0C File Offset: 0x00EEDF0C
		protected override bool OnInit()
		{
			this.TemperatureDelegate = global::DelegateUtils.ToManualReleaseDelegate<FGetCurrentTemperatureDataDelegate>(new Action<bool, float, float>(this.OnGetTemperatureDataFromMAGT));
			this.IsAutoCoolState = false;
			return true;
		}

		// Token: 0x0603AE57 RID: 241239 RVA: 0x00EEFD2D File Offset: 0x00EEDF2D
		protected override bool OnClear()
		{
			global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<bool, float, float>(this.OnGetTemperatureDataFromMAGT));
			this.TemperatureDelegate = null;
			return true;
		}

		// Token: 0x0603AE58 RID: 241240 RVA: 0x00EEFD48 File Offset: 0x00EEDF48
		protected override void OnTick(float delta)
		{
			if (UKuroRenderingRuntimeBPPluginBPLibrary.GetCVarFloat("r.Kuro.AutoCoolEnable") > 0f && UKuroRenderingRuntimeBPPluginBPLibrary.GetCVarFloat("r.Kuro.AutoCoolUIEnable") > 0f)
			{
				this.CheckCount += (int)delta;
				if (this.CheckCount < 10000)
				{
					return;
				}
				if (Singleton<Platform>.Instance.IsMobilePlatform())
				{
					if (ControllerBase<KuroPerformanceController>.Instance.IsEnable)
					{
						UKuroPerformanceBPLibrary.GetCurrentTemperatureData(this.TemperatureDelegate);
					}
					else
					{
						this.OnGetTemperatureDataFromOthers();
					}
				}
				else if (Singleton<Platform>.Instance.IsPcPlatform())
				{
					this.OnAutoAdjustImageQualityPcPlatform(delta);
				}
				this.CheckCount = 0;
			}
		}

		// Token: 0x04021420 RID: 136224
		private const int CHECK_TIME = 10000;

		// Token: 0x04021421 RID: 136225
		private const bool DebugLogEnabled = true;

		// Token: 0x04021422 RID: 136226
		private const int CpuTemperatureThreshold = 65;

		// Token: 0x04021423 RID: 136227
		private const int FpsThreshold = 50;

		// Token: 0x04021424 RID: 136228
		private int CheckCount;

		// Token: 0x04021425 RID: 136229
		private bool IsAutoCoolState;

		// Token: 0x04021426 RID: 136230
		private const int ResolutionThreshold = 1;

		// Token: 0x04021427 RID: 136231
		private const int NiagaraThreshold = 1;

		// Token: 0x04021428 RID: 136232
		private const int ImageDetailThreshold = 1;

		// Token: 0x04021429 RID: 136233
		private const int VolumeLightThreshold = 0;

		// Token: 0x0402142A RID: 136234
		private const int NpcDensityThreshold = 1;

		// Token: 0x0402142B RID: 136235
		private const int ShadowThreshold = 1;

		// Token: 0x0402142C RID: 136236
		[Nullable(2)]
		public FGetCurrentTemperatureDataDelegate TemperatureDelegate;

		// Token: 0x0402142D RID: 136237
		private List<float> frameTimes = new List<float>();

		// Token: 0x0402142E RID: 136238
		private List<int> jankCountHistory = new List<int>();

		// Token: 0x0402142F RID: 136239
		private List<float> fpsHistory = new List<float>();

		// Token: 0x04021430 RID: 136240
		private long lastJankCheckTime;

		// Token: 0x04021431 RID: 136241
		private int consecutiveJankWindows;

		// Token: 0x04021432 RID: 136242
		private int consecutiveNoJankWindows;

		// Token: 0x04021433 RID: 136243
		private const int jankCheckInterval = 5000;
	}
}
