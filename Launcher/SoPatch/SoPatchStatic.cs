using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.BaseConfig;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Launcher.SoPatch
{
	// Token: 0x02004535 RID: 17717
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class SoPatchStatic : Singleton<SoPatchStatic>, ITickable
	{
		// Token: 0x0602EA63 RID: 191075 RVA: 0x00B0D7FC File Offset: 0x00B0B9FC
		private UniTask RequestConfig(string appParallel, List<string> prefixList, string mixRoute, string platform)
		{
			SoPatchStatic.<RequestConfig>d__9 <RequestConfig>d__;
			<RequestConfig>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RequestConfig>d__.<>4__this = this;
			<RequestConfig>d__.appParallel = appParallel;
			<RequestConfig>d__.prefixList = prefixList;
			<RequestConfig>d__.mixRoute = mixRoute;
			<RequestConfig>d__.platform = platform;
			<RequestConfig>d__.<>1__state = -1;
			<RequestConfig>d__.<>t__builder.Start<SoPatchStatic.<RequestConfig>d__9>(ref <RequestConfig>d__);
			return <RequestConfig>d__.<>t__builder.Task;
		}

		// Token: 0x0602EA64 RID: 191076 RVA: 0x00B0D860 File Offset: 0x00B0BA60
		private unsafe void GetDeviceAndAppInfo()
		{
			if (this.OsVersion != null && this.OsVersion.Length > 0)
			{
				return;
			}
			if (UKuroStaticLibrary.IsModuleLoaded("KuroSDK") && Singleton<BaseConfigController>.Instance.GetPublicValue("UseSDK") == "1")
			{
				string deviceId = UKuroSDKManager.GetBasicInfo().DeviceId;
				string text = UKuroStaticLibrary.HashStringWithSHA1(deviceId);
				if (text == null || text.Length == 0)
				{
					LauncherLog instance = Singleton<LauncherLog>.Instance;
					string message = "灰度检查: deviceId的SHA1值不合法";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("DeviceId", deviceId ?? "");
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("SHA1", text ?? "");
					instance.Error(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				}
				else
				{
					this.DeviceValue = Convert.ToInt64(text.Substring(0, Math.Min(8, text.Length)), 16);
				}
			}
			this.Manufacturer = UKuroAndroidModelTools.GetManufacturer();
			this.Model = UKuroAndroidModelTools.GetModel();
			this.OsVersion = UKuroAndroidModelTools.GetAndroidVersion();
		}

		// Token: 0x0602EA65 RID: 191077 RVA: 0x00B0D974 File Offset: 0x00B0BB74
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		private UniTask<string> DownloadPatch(string mixRoute, string platform, int curVer)
		{
			SoPatchStatic.<DownloadPatch>d__11 <DownloadPatch>d__;
			<DownloadPatch>d__.<>t__builder = AsyncUniTaskMethodBuilder<string>.Create();
			<DownloadPatch>d__.<>4__this = this;
			<DownloadPatch>d__.mixRoute = mixRoute;
			<DownloadPatch>d__.platform = platform;
			<DownloadPatch>d__.curVer = curVer;
			<DownloadPatch>d__.<>1__state = -1;
			<DownloadPatch>d__.<>t__builder.Start<SoPatchStatic.<DownloadPatch>d__11>(ref <DownloadPatch>d__);
			return <DownloadPatch>d__.<>t__builder.Task;
		}

		// Token: 0x0602EA66 RID: 191078 RVA: 0x00B0D9D0 File Offset: 0x00B0BBD0
		[NullableContext(0)]
		private UniTask<int> CheckSoHash([Nullable(1)] string soHash)
		{
			SoPatchStatic.<CheckSoHash>d__12 <CheckSoHash>d__;
			<CheckSoHash>d__.<>t__builder = AsyncUniTaskMethodBuilder<int>.Create();
			<CheckSoHash>d__.<>4__this = this;
			<CheckSoHash>d__.soHash = soHash;
			<CheckSoHash>d__.<>1__state = -1;
			<CheckSoHash>d__.<>t__builder.Start<SoPatchStatic.<CheckSoHash>d__12>(ref <CheckSoHash>d__);
			return <CheckSoHash>d__.<>t__builder.Task;
		}

		// Token: 0x0602EA67 RID: 191079 RVA: 0x00B0DA1C File Offset: 0x00B0BC1C
		private UniTask FixInternal()
		{
			SoPatchStatic.<FixInternal>d__13 <FixInternal>d__;
			<FixInternal>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<FixInternal>d__.<>4__this = this;
			<FixInternal>d__.<>1__state = -1;
			<FixInternal>d__.<>t__builder.Start<SoPatchStatic.<FixInternal>d__13>(ref <FixInternal>d__);
			return <FixInternal>d__.<>t__builder.Task;
		}

		// Token: 0x0602EA68 RID: 191080 RVA: 0x00B0DA60 File Offset: 0x00B0BC60
		public UniTask Fix()
		{
			SoPatchStatic.<Fix>d__14 <Fix>d__;
			<Fix>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Fix>d__.<>4__this = this;
			<Fix>d__.<>1__state = -1;
			<Fix>d__.<>t__builder.Start<SoPatchStatic.<Fix>d__14>(ref <Fix>d__);
			return <Fix>d__.<>t__builder.Task;
		}

		// Token: 0x0602EA69 RID: 191081 RVA: 0x00B0DAA3 File Offset: 0x00B0BCA3
		public void Tick(float delta)
		{
			this.Current += (int)delta;
			if (this.Current >= SoPatchStatic.Interval)
			{
				this.Current -= SoPatchStatic.Interval;
				this.Fix().Forget();
			}
		}

		// Token: 0x0401A7DD RID: 108509
		[Nullable(2)]
		private UKuroVerify Verify;

		// Token: 0x0401A7DE RID: 108510
		[Nullable(2)]
		private SoPathConfig Config;

		// Token: 0x0401A7DF RID: 108511
		private string OsVersion = "";

		// Token: 0x0401A7E0 RID: 108512
		private string Manufacturer = "";

		// Token: 0x0401A7E1 RID: 108513
		private string Model = "";

		// Token: 0x0401A7E2 RID: 108514
		private long DeviceValue;

		// Token: 0x0401A7E3 RID: 108515
		private static readonly int Interval = 300000;

		// Token: 0x0401A7E4 RID: 108516
		private int Current = 300000;

		// Token: 0x0401A7E5 RID: 108517
		private bool IsProcessing;
	}
}
