using System;
using System.Linq;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.Launcher.Define;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Launcher.Util
{
	// Token: 0x020044AF RID: 17583
	[NullableContext(1)]
	[Nullable(0)]
	[StaticVariableRuleIgnore]
	public class SplashRegionBlockLib
	{
		// Token: 0x0602E586 RID: 189830 RVA: 0x00AE26A3 File Offset: 0x00AE08A3
		public static void Initialize()
		{
			if (SplashRegionBlockLib.IsInited)
			{
				return;
			}
			SplashRegionBlockLib.IsInited = true;
			if (!SplashRegionBlockLib.IsFeatureEffective())
			{
				return;
			}
			SplashRegionBlockLib.LoadCache();
		}

		// Token: 0x0602E587 RID: 189831 RVA: 0x00AE26C0 File Offset: 0x00AE08C0
		public static UniTask PrepareAsync()
		{
			SplashRegionBlockLib.<PrepareAsync>d__7 <PrepareAsync>d__;
			<PrepareAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PrepareAsync>d__.<>1__state = -1;
			<PrepareAsync>d__.<>t__builder.Start<SplashRegionBlockLib.<PrepareAsync>d__7>(ref <PrepareAsync>d__);
			return <PrepareAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0602E588 RID: 189832 RVA: 0x00AE26FC File Offset: 0x00AE08FC
		public unsafe static bool ShouldBlockPhaseOne()
		{
			if (!SplashRegionBlockLib.IsInited || !SplashRegionBlockLib.IsFeatureEffective())
			{
				return false;
			}
			string cachedRegion = SplashRegionBlockLib.CachedRegion;
			if (cachedRegion == null)
			{
				bool fallbackBlockOnFailure = SplashRegionBlockConfig.FallbackBlockOnFailure;
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "[SplashRegionBlock]无 Region, 走兜底";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("fallback", fallbackBlockOnFailure);
				instance.Warn(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return fallbackBlockOnFailure;
			}
			bool flag = SplashRegionBlockConfig.BlockedRegions.Contains(cachedRegion);
			LauncherLog instance2 = Singleton<LauncherLog>.Instance;
			string message2 = "[SplashRegionBlock]";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("region", cachedRegion);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("blocked", flag);
			instance2.Info(message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return flag;
		}

		// Token: 0x0602E589 RID: 189833 RVA: 0x00AE27B6 File Offset: 0x00AE09B6
		private static bool IsFeatureEffective()
		{
			return SplashRegionBlockConfig.Enabled && (SplashRegionBlockLib.IsTestModeOn() || SplashRegionBlockLib.IsGlobalPackage());
		}

		// Token: 0x0602E58A RID: 189834 RVA: 0x00AE27D4 File Offset: 0x00AE09D4
		private static bool IsGlobalPackage()
		{
			return Singleton<BaseConfigController>.Instance.GetPublicValue("SdkArea") != "CN";
		}

		// Token: 0x0602E58B RID: 189835 RVA: 0x00AE27EF File Offset: 0x00AE09EF
		private static bool IsTestModeOn()
		{
			return SplashRegionBlockConfig.TestMode;
		}

		// Token: 0x0602E58C RID: 189836 RVA: 0x00AE27F8 File Offset: 0x00AE09F8
		private static void LoadCache()
		{
			string text = Singleton<LauncherStorageLib>.Instance.GetDeviceSaved<string>(ELauncherStorageDeviceKey.SplashRegionBlockRegion, "") ?? "";
			if (!SplashRegionBlockLib.IsValidCountryCode(text))
			{
				return;
			}
			int deviceSaved = Singleton<LauncherStorageLib>.Instance.GetDeviceSaved<int>(ELauncherStorageDeviceKey.SplashRegionBlockTimestampSecs, 0);
			if (deviceSaved <= 0)
			{
				return;
			}
			SplashRegionBlockLib.CachedRegion = text;
			SplashRegionBlockLib.CachedTimestampSecs = deviceSaved;
		}

		// Token: 0x0602E58D RID: 189837 RVA: 0x00AE2848 File Offset: 0x00AE0A48
		private static void SetCache(string region, int timestampSecs)
		{
			SplashRegionBlockLib.CachedRegion = region;
			SplashRegionBlockLib.CachedTimestampSecs = timestampSecs;
			Singleton<LauncherStorageLib>.Instance.SetDeviceSaved<string>(ELauncherStorageDeviceKey.SplashRegionBlockRegion, region);
			Singleton<LauncherStorageLib>.Instance.SetDeviceSaved<int>(ELauncherStorageDeviceKey.SplashRegionBlockTimestampSecs, timestampSecs);
		}

		// Token: 0x0602E58E RID: 189838 RVA: 0x00AE2874 File Offset: 0x00AE0A74
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		private static UniTask<string> QueryRegionByIpAsync()
		{
			SplashRegionBlockLib.<QueryRegionByIpAsync>d__14 <QueryRegionByIpAsync>d__;
			<QueryRegionByIpAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<string>.Create();
			<QueryRegionByIpAsync>d__.<>1__state = -1;
			<QueryRegionByIpAsync>d__.<>t__builder.Start<SplashRegionBlockLib.<QueryRegionByIpAsync>d__14>(ref <QueryRegionByIpAsync>d__);
			return <QueryRegionByIpAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0602E58F RID: 189839 RVA: 0x00AE28B0 File Offset: 0x00AE0AB0
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		private static UniTask<string> TryOneProviderAsync(SplashRegionGeoIpProvider provider)
		{
			SplashRegionBlockLib.<TryOneProviderAsync>d__15 <TryOneProviderAsync>d__;
			<TryOneProviderAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<string>.Create();
			<TryOneProviderAsync>d__.provider = provider;
			<TryOneProviderAsync>d__.<>1__state = -1;
			<TryOneProviderAsync>d__.<>t__builder.Start<SplashRegionBlockLib.<TryOneProviderAsync>d__15>(ref <TryOneProviderAsync>d__);
			return <TryOneProviderAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0602E590 RID: 189840 RVA: 0x00AE28F4 File Offset: 0x00AE0AF4
		private static bool IsValidCountryCode(string code)
		{
			if (code.Length != 2)
			{
				return false;
			}
			foreach (int num in code)
			{
				if (num < 65 || num > 90)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0401A578 RID: 107896
		private const int COUNTRY_CODE_LENGTH = 2;

		// Token: 0x0401A579 RID: 107897
		private const int CHAR_CODE_UPPER_A = 65;

		// Token: 0x0401A57A RID: 107898
		private const int CHAR_CODE_UPPER_Z = 90;

		// Token: 0x0401A57B RID: 107899
		private static bool IsInited;

		// Token: 0x0401A57C RID: 107900
		[Nullable(2)]
		private static string CachedRegion;

		// Token: 0x0401A57D RID: 107901
		private static int CachedTimestampSecs;
	}
}
