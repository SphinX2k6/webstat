using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.Sequence
{
	// Token: 0x02005388 RID: 21384
	[NullableContext(2)]
	[Nullable(0)]
	public class SequenceRenderSettings : IStaticVariableResetter
	{
		// Token: 0x060368A6 RID: 223398 RVA: 0x00DC91D9 File Offset: 0x00DC73D9
		static SequenceRenderSettings()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(SequenceRenderSettings.CreateStaticDefaultValue), new Action(SequenceRenderSettings.ResetStaticDefaultValue));
		}

		// Token: 0x060368A7 RID: 223399 RVA: 0x00DC91F8 File Offset: 0x00DC73F8
		public static void CreateStaticDefaultValue()
		{
			SequenceRenderSettings.TextureStreamingPC = new Dictionary<EGameQualitySettingLevel, bool>();
			SequenceRenderSettings.TextureStreamingAndroid = new Dictionary<EGameQualitySettingLevel, bool>();
			SequenceRenderSettings.TextureStreamingIOS = new Dictionary<EGameQualitySettingLevel, bool>();
			SequenceRenderSettings.TextureStreamingPS5 = new Dictionary<EGameQualitySettingLevel, bool>();
		}

		// Token: 0x060368A8 RID: 223400 RVA: 0x00DC9222 File Offset: 0x00DC7422
		public static void ResetStaticDefaultValue()
		{
			SequenceRenderSettings.TextureStreamingPC = null;
			SequenceRenderSettings.TextureStreamingAndroid = null;
			SequenceRenderSettings.TextureStreamingIOS = null;
			SequenceRenderSettings.TextureStreamingPS5 = null;
		}

		// Token: 0x060368A9 RID: 223401 RVA: 0x00DC923C File Offset: 0x00DC743C
		public static void SetupSequenceSetting()
		{
			SequenceRenderSettings.TextureStreamingAndroid[EGameQualitySettingLevel.VeryLow] = true;
			SequenceRenderSettings.TextureStreamingAndroid[EGameQualitySettingLevel.Low] = true;
			SequenceRenderSettings.TextureStreamingAndroid[EGameQualitySettingLevel.Middle] = true;
			SequenceRenderSettings.TextureStreamingAndroid[EGameQualitySettingLevel.High] = true;
			SequenceRenderSettings.TextureStreamingAndroid[EGameQualitySettingLevel.VeryHigh] = true;
			SequenceRenderSettings.TextureStreamingAndroid[EGameQualitySettingLevel.Highest] = true;
			SequenceRenderSettings.TextureStreamingPC[EGameQualitySettingLevel.VeryLow] = false;
			SequenceRenderSettings.TextureStreamingPC[EGameQualitySettingLevel.Low] = true;
			SequenceRenderSettings.TextureStreamingPC[EGameQualitySettingLevel.Middle] = true;
			SequenceRenderSettings.TextureStreamingPC[EGameQualitySettingLevel.High] = true;
			SequenceRenderSettings.TextureStreamingPC[EGameQualitySettingLevel.VeryHigh] = true;
			SequenceRenderSettings.TextureStreamingPC[EGameQualitySettingLevel.Highest] = true;
			SequenceRenderSettings.TextureStreamingIOS[EGameQualitySettingLevel.VeryLow] = false;
			SequenceRenderSettings.TextureStreamingIOS[EGameQualitySettingLevel.Low] = true;
			SequenceRenderSettings.TextureStreamingIOS[EGameQualitySettingLevel.Middle] = true;
			SequenceRenderSettings.TextureStreamingIOS[EGameQualitySettingLevel.High] = true;
			SequenceRenderSettings.TextureStreamingIOS[EGameQualitySettingLevel.VeryHigh] = true;
			SequenceRenderSettings.TextureStreamingIOS[EGameQualitySettingLevel.Highest] = true;
			SequenceRenderSettings.TextureStreamingPS5[EGameQualitySettingLevel.VeryLow] = true;
			SequenceRenderSettings.TextureStreamingPS5[EGameQualitySettingLevel.Low] = true;
			SequenceRenderSettings.TextureStreamingPS5[EGameQualitySettingLevel.Middle] = true;
			SequenceRenderSettings.TextureStreamingPS5[EGameQualitySettingLevel.High] = true;
			SequenceRenderSettings.TextureStreamingPS5[EGameQualitySettingLevel.VeryHigh] = true;
			SequenceRenderSettings.TextureStreamingPS5[EGameQualitySettingLevel.Highest] = true;
		}

		// Token: 0x060368AA RID: 223402 RVA: 0x00DC936C File Offset: 0x00DC756C
		public static bool GetTexureStreamingEnable(EGameQualitySettingLevel level)
		{
			if (Singleton<Info>.Instance.IsPcPlatform())
			{
				bool flag;
				return !SequenceRenderSettings.TextureStreamingPC.TryGetValue(level, out flag) || flag;
			}
			if (Singleton<Info>.Instance.IsAndroidPlatform())
			{
				bool flag2;
				if (SequenceRenderSettings.TextureStreamingAndroid.TryGetValue(level, out flag2))
				{
					return !UKuroStaticLibrary.IsLowMemoryDevice() && flag2;
				}
				return !UKuroStaticLibrary.IsLowMemoryDevice();
			}
			else
			{
				if (!Singleton<Info>.Instance.IsIosPlatform())
				{
					bool flag3;
					return !Singleton<Info>.Instance.IsGamepadPlatform() || !SequenceRenderSettings.TextureStreamingPS5.TryGetValue(level, out flag3) || flag3;
				}
				bool flag4;
				if (SequenceRenderSettings.TextureStreamingIOS.TryGetValue(level, out flag4))
				{
					return !UKuroStaticLibrary.IsLowMemoryDevice() && flag4;
				}
				return !UKuroStaticLibrary.IsLowMemoryDevice();
			}
		}

		// Token: 0x0401F677 RID: 128631
		private static Dictionary<EGameQualitySettingLevel, bool> TextureStreamingPC;

		// Token: 0x0401F678 RID: 128632
		private static Dictionary<EGameQualitySettingLevel, bool> TextureStreamingAndroid;

		// Token: 0x0401F679 RID: 128633
		private static Dictionary<EGameQualitySettingLevel, bool> TextureStreamingIOS;

		// Token: 0x0401F67A RID: 128634
		private static Dictionary<EGameQualitySettingLevel, bool> TextureStreamingPS5;
	}
}
