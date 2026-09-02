using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.RegularExpressions;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.Launcher.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Launcher.NetworkDetection
{
	// Token: 0x020045D3 RID: 17875
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class LauncherNetworkDetectionController : Singleton<LauncherNetworkDetectionController>
	{
		// Token: 0x0602ED57 RID: 191831 RVA: 0x00B174B4 File Offset: 0x00B156B4
		public unsafe bool SetDetectionConfig(ILoginServersData data)
		{
			if (this.LoginServersData != data)
			{
				string detectionConfig = UKuroNetworkDetection.GetDetectionConfig(data.name);
				try
				{
					INetworkDetectionConfig networkDetectionConfig = LauncherJson.Parse<INetworkDetectionConfig>(detectionConfig, new JsonSerializerOptions
					{
						PropertyNameCaseInsensitive = true
					});
					if (networkDetectionConfig != null && this.CheckDetectionConfigEntryValidate(data, networkDetectionConfig, true))
					{
						this.LoginServersData = data;
						this.NetworkDetectionConfig = networkDetectionConfig;
						return true;
					}
					return false;
				}
				catch (Exception ex)
				{
					LauncherLog instance = Singleton<LauncherLog>.Instance;
					string message = "网络检测->SetDetectionConfig执行异常";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("loginServersData", data);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("error", ex.Message);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("detectionConfigJson", detectionConfig);
					instance.Error(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
					return false;
				}
				return true;
			}
			return true;
		}

		// Token: 0x0602ED58 RID: 191832 RVA: 0x00B17598 File Offset: 0x00B15798
		private unsafe bool CheckDetectionConfigEntryValidate(ILoginServersData data, INetworkDetectionConfig detectionConfig, bool log = false)
		{
			string pingUrl = detectionConfig.PingUrl;
			int[] udpPort = detectionConfig.UdpPort;
			if (string.IsNullOrEmpty(pingUrl) || udpPort == null || udpPort.Length == 0)
			{
				if (log)
				{
					LauncherLog instance = Singleton<LauncherLog>.Instance;
					string message = "网络检测->SetDetectionConfig执行异常,检测条目配置缺失";
					<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("loginServersData", data);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("detectionConfig", detectionConfig);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("pingUrl", pingUrl);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("udpPortArray", udpPort);
					instance.Error(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
				}
				return false;
			}
			return true;
		}

		// Token: 0x0602ED59 RID: 191833 RVA: 0x00B1764C File Offset: 0x00B1584C
		private bool CheckDetectionConfig()
		{
			if (this.NetworkDetectionConfig == null)
			{
				Singleton<LauncherLog>.Instance.Debug("[网络检测]->没有拉取网络检测配置", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			return true;
		}

		// Token: 0x0602ED5A RID: 191834 RVA: 0x00B1767C File Offset: 0x00B1587C
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public UniTask<INetworkDetectionResult> StartDetection(INetworkDetectionEntry entry)
		{
			LauncherNetworkDetectionController.<StartDetection>d__11 <StartDetection>d__;
			<StartDetection>d__.<>t__builder = AsyncUniTaskMethodBuilder<INetworkDetectionResult>.Create();
			<StartDetection>d__.<>4__this = this;
			<StartDetection>d__.entry = entry;
			<StartDetection>d__.<>1__state = -1;
			<StartDetection>d__.<>t__builder.Start<LauncherNetworkDetectionController.<StartDetection>d__11>(ref <StartDetection>d__);
			return <StartDetection>d__.<>t__builder.Task;
		}

		// Token: 0x0602ED5B RID: 191835 RVA: 0x00B176C8 File Offset: 0x00B158C8
		public INetworkDetectionResult StartProxyDetect()
		{
			string currentProxyAddress = UKuroNetworkDetection.GetCurrentProxyAddress();
			bool flag = string.IsNullOrEmpty(currentProxyAddress);
			return new INetworkDetectionProxyResult
			{
				Success = flag,
				Address = currentProxyAddress,
				Code = new int?(flag ? 0 : -1)
			};
		}

		// Token: 0x0602ED5C RID: 191836 RVA: 0x00B17708 File Offset: 0x00B15908
		public bool SkipDomainDetect()
		{
			string ip = this.NetworkDetectionConfig.ip;
			return ip == null || !ip.StartsWith("http");
		}

		// Token: 0x0602ED5D RID: 191837 RVA: 0x00B17734 File Offset: 0x00B15934
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public UniTask<INetworkDetectionResult> StartDomainDetect()
		{
			LauncherNetworkDetectionController.<StartDomainDetect>d__14 <StartDomainDetect>d__;
			<StartDomainDetect>d__.<>t__builder = AsyncUniTaskMethodBuilder<INetworkDetectionResult>.Create();
			<StartDomainDetect>d__.<>4__this = this;
			<StartDomainDetect>d__.<>1__state = -1;
			<StartDomainDetect>d__.<>t__builder.Start<LauncherNetworkDetectionController.<StartDomainDetect>d__14>(ref <StartDomainDetect>d__);
			return <StartDomainDetect>d__.<>t__builder.Task;
		}

		// Token: 0x0602ED5E RID: 191838 RVA: 0x00B17777 File Offset: 0x00B15977
		public void ForceStopDomainDetect()
		{
			UKuroNetworkDetection.ResolveDomainFinish();
			if (this.OnResolveDomainName != null)
			{
				global::DelegateUtils.ReleaseManualReleaseDelegate(this.OnResolveDomainName);
				this.OnResolveDomainName = null;
			}
		}

		// Token: 0x0602ED5F RID: 191839 RVA: 0x00B17798 File Offset: 0x00B15998
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public UniTask<INetworkDetectionPingResult> StartPingDetect()
		{
			LauncherNetworkDetectionController.<StartPingDetect>d__16 <StartPingDetect>d__;
			<StartPingDetect>d__.<>t__builder = AsyncUniTaskMethodBuilder<INetworkDetectionPingResult>.Create();
			<StartPingDetect>d__.<>4__this = this;
			<StartPingDetect>d__.<>1__state = -1;
			<StartPingDetect>d__.<>t__builder.Start<LauncherNetworkDetectionController.<StartPingDetect>d__16>(ref <StartPingDetect>d__);
			return <StartPingDetect>d__.<>t__builder.Task;
		}

		// Token: 0x0602ED60 RID: 191840 RVA: 0x00B177DC File Offset: 0x00B159DC
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public UniTask<INetworkDetectionHttpResult> StartHttpsDetect()
		{
			LauncherNetworkDetectionController.<StartHttpsDetect>d__17 <StartHttpsDetect>d__;
			<StartHttpsDetect>d__.<>t__builder = AsyncUniTaskMethodBuilder<INetworkDetectionHttpResult>.Create();
			<StartHttpsDetect>d__.<>4__this = this;
			<StartHttpsDetect>d__.<>1__state = -1;
			<StartHttpsDetect>d__.<>t__builder.Start<LauncherNetworkDetectionController.<StartHttpsDetect>d__17>(ref <StartHttpsDetect>d__);
			return <StartHttpsDetect>d__.<>t__builder.Task;
		}

		// Token: 0x0602ED61 RID: 191841 RVA: 0x00B1781F File Offset: 0x00B15A1F
		public bool GetGateWayUdpCheckState()
		{
			return this.GateWayUdpCheckState;
		}

		// Token: 0x0602ED62 RID: 191842 RVA: 0x00B17828 File Offset: 0x00B15A28
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public UniTask<INetworkDetectionResult> StartUdpDetect()
		{
			LauncherNetworkDetectionController.<StartUdpDetect>d__19 <StartUdpDetect>d__;
			<StartUdpDetect>d__.<>t__builder = AsyncUniTaskMethodBuilder<INetworkDetectionResult>.Create();
			<StartUdpDetect>d__.<>4__this = this;
			<StartUdpDetect>d__.<>1__state = -1;
			<StartUdpDetect>d__.<>t__builder.Start<LauncherNetworkDetectionController.<StartUdpDetect>d__19>(ref <StartUdpDetect>d__);
			return <StartUdpDetect>d__.<>t__builder.Task;
		}

		// Token: 0x0602ED63 RID: 191843 RVA: 0x00B1786C File Offset: 0x00B15A6C
		public unsafe void SetGateWayCheckInfo([Nullable(2)] ILoginNetworkDetectionConfig data, string uid)
		{
			if (data != null)
			{
				if (data.Hosts.TrueForAll((string host) => !string.IsNullOrEmpty(host)))
				{
					this.LoginNetworkDetectionConfig = data;
				}
			}
			this.GateWayUdpCheckUid = uid;
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "[网络检测]->设置网关检测信息";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("data", data);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("uid", uid);
			instance.Debug(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}

		// Token: 0x0602ED64 RID: 191844 RVA: 0x00B17908 File Offset: 0x00B15B08
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		private UniTask<INetworkDetectionResult> StartGateWayUdpReachable()
		{
			LauncherNetworkDetectionController.<StartGateWayUdpReachable>d__21 <StartGateWayUdpReachable>d__;
			<StartGateWayUdpReachable>d__.<>t__builder = AsyncUniTaskMethodBuilder<INetworkDetectionResult>.Create();
			<StartGateWayUdpReachable>d__.<>4__this = this;
			<StartGateWayUdpReachable>d__.<>1__state = -1;
			<StartGateWayUdpReachable>d__.<>t__builder.Start<LauncherNetworkDetectionController.<StartGateWayUdpReachable>d__21>(ref <StartGateWayUdpReachable>d__);
			return <StartGateWayUdpReachable>d__.<>t__builder.Task;
		}

		// Token: 0x0602ED65 RID: 191845 RVA: 0x00B1794C File Offset: 0x00B15B4C
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		private UniTask<INetworkDetectionResult> StartUdpCheckPingUrlList()
		{
			LauncherNetworkDetectionController.<StartUdpCheckPingUrlList>d__22 <StartUdpCheckPingUrlList>d__;
			<StartUdpCheckPingUrlList>d__.<>t__builder = AsyncUniTaskMethodBuilder<INetworkDetectionResult>.Create();
			<StartUdpCheckPingUrlList>d__.<>4__this = this;
			<StartUdpCheckPingUrlList>d__.<>1__state = -1;
			<StartUdpCheckPingUrlList>d__.<>t__builder.Start<LauncherNetworkDetectionController.<StartUdpCheckPingUrlList>d__22>(ref <StartUdpCheckPingUrlList>d__);
			return <StartUdpCheckPingUrlList>d__.<>t__builder.Task;
		}

		// Token: 0x0602ED66 RID: 191846 RVA: 0x00B17990 File Offset: 0x00B15B90
		private unsafe void CheckGateWayDdpReachable(List<string> urlList, int index, int[] udpPortArray, string payload, Action<bool, int> callBack)
		{
			LauncherNetworkDetectionController.<>c__DisplayClass23_0 CS$<>8__locals1 = new LauncherNetworkDetectionController.<>c__DisplayClass23_0();
			CS$<>8__locals1.index = index;
			CS$<>8__locals1.urlList = urlList;
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.udpPortArray = udpPortArray;
			CS$<>8__locals1.payload = payload;
			CS$<>8__locals1.callBack = callBack;
			string text = CS$<>8__locals1.urlList[CS$<>8__locals1.index];
			if (text != null)
			{
				FTestUdpResultDelegate resultDelegate = global::DelegateUtils.ToManualReleaseDelegate<FTestUdpResultDelegate>(new Action<int, int>(CS$<>8__locals1.<CheckGateWayDdpReachable>g__CheckCallback|0));
				TArray<int> tarray = new TArray<int>();
				foreach (int value in CS$<>8__locals1.udpPortArray)
				{
					tarray.Add(value);
				}
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "[网络检测]->网关Udp端口检测";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("url", text);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("payload", CS$<>8__locals1.payload);
				instance.Info(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				UKuroNetworkDetection.GatewayUdpReachable(text, tarray, CS$<>8__locals1.payload, resultDelegate);
			}
		}

		// Token: 0x0602ED67 RID: 191847 RVA: 0x00B17A90 File Offset: 0x00B15C90
		private unsafe void CheckDetectUdp(List<string> urlList, int index, int[] udpPortArray, Action<bool, int> callBack)
		{
			LauncherNetworkDetectionController.<>c__DisplayClass24_0 CS$<>8__locals1 = new LauncherNetworkDetectionController.<>c__DisplayClass24_0();
			CS$<>8__locals1.index = index;
			CS$<>8__locals1.urlList = urlList;
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.udpPortArray = udpPortArray;
			CS$<>8__locals1.callBack = callBack;
			CS$<>8__locals1.url = CS$<>8__locals1.urlList[CS$<>8__locals1.index];
			if (CS$<>8__locals1.url != null)
			{
				FTestUdpResultDelegate resultDelegate = global::DelegateUtils.ToManualReleaseDelegate<FTestUdpResultDelegate>(new Action<int, int>(CS$<>8__locals1.<CheckDetectUdp>g__CheckCallback|0));
				TArray<int> tarray = new TArray<int>();
				foreach (int value in CS$<>8__locals1.udpPortArray)
				{
					tarray.Add(value);
				}
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "[网络检测]->UdpPort检测";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("url", CS$<>8__locals1.url);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("portUeArray", tarray);
				instance.Debug(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				UKuroNetworkDetection.TestUdpReachable(CS$<>8__locals1.url, tarray, resultDelegate);
			}
		}

		// Token: 0x0602ED68 RID: 191848 RVA: 0x00B17B90 File Offset: 0x00B15D90
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public UniTask<INetworkDetectionResult> StartTraceRouteDetect()
		{
			LauncherNetworkDetectionController.<StartTraceRouteDetect>d__25 <StartTraceRouteDetect>d__;
			<StartTraceRouteDetect>d__.<>t__builder = AsyncUniTaskMethodBuilder<INetworkDetectionResult>.Create();
			<StartTraceRouteDetect>d__.<>4__this = this;
			<StartTraceRouteDetect>d__.<>1__state = -1;
			<StartTraceRouteDetect>d__.<>t__builder.Start<LauncherNetworkDetectionController.<StartTraceRouteDetect>d__25>(ref <StartTraceRouteDetect>d__);
			return <StartTraceRouteDetect>d__.<>t__builder.Task;
		}

		// Token: 0x0602ED69 RID: 191849 RVA: 0x00B17BD4 File Offset: 0x00B15DD4
		private void CheckLoginUrlReachable(List<string> loginUrlList, int index, Action<bool> callBack)
		{
			LauncherNetworkDetectionController.<>c__DisplayClass26_0 CS$<>8__locals1 = new LauncherNetworkDetectionController.<>c__DisplayClass26_0();
			CS$<>8__locals1.index = index;
			CS$<>8__locals1.loginUrlList = loginUrlList;
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.callBack = callBack;
			CS$<>8__locals1.url = CS$<>8__locals1.loginUrlList[CS$<>8__locals1.index];
			if (CS$<>8__locals1.url != null)
			{
				string target = this.ExtractDomain(CS$<>8__locals1.url);
				FTracerouteDelegate callback = global::DelegateUtils.ToManualReleaseDelegate<FTracerouteDelegate>(new Action<bool>(CS$<>8__locals1.<CheckLoginUrlReachable>g__CheckCallback|0));
				new UKuroTraceroute().Traceroute(target, callback);
			}
		}

		// Token: 0x0602ED6A RID: 191850 RVA: 0x00B17C50 File Offset: 0x00B15E50
		private string ExtractDomain(string input)
		{
			if (string.IsNullOrEmpty(input))
			{
				return "";
			}
			string text = input.Trim();
			text = Regex.Replace(text, "^[a-zA-Z][a-zA-Z0-9+.-]*:\\/\\/", "");
			text = Regex.Split(text, "[/?#]")[0];
			if (string.IsNullOrEmpty(text))
			{
				return "";
			}
			text = Regex.Replace(text, ":\\d+$", "");
			return Regex.Replace(text, "^www\\.", "", RegexOptions.IgnoreCase);
		}

		// Token: 0x0602ED6B RID: 191851 RVA: 0x00B17CC3 File Offset: 0x00B15EC3
		public bool IsGlobalPlayer()
		{
			return Singleton<BaseConfigController>.Instance.GetPublicValue("SdkArea") != "CN";
		}

		// Token: 0x0602ED6C RID: 191852 RVA: 0x00B17CDE File Offset: 0x00B15EDE
		public void ReportDetectionLog(LauncherNetworkDetectionBaseLog logData)
		{
			Singleton<HotPatchLogReport>.Instance.ReportNetworkDetection(logData);
		}

		// Token: 0x0401AA3F RID: 109119
		private const int TIME_OUT = 2;

		// Token: 0x0401AA40 RID: 109120
		[Nullable(2)]
		private INetworkDetectionConfig NetworkDetectionConfig;

		// Token: 0x0401AA41 RID: 109121
		[Nullable(2)]
		private ILoginServersData LoginServersData;

		// Token: 0x0401AA42 RID: 109122
		[Nullable(2)]
		private Action<int> OnResolveDomainName;

		// Token: 0x0401AA43 RID: 109123
		[Nullable(2)]
		public INetworkDetectionPingResult PingResultCacheForLog;

		// Token: 0x0401AA44 RID: 109124
		[Nullable(2)]
		public ILoginNetworkDetectionConfig LoginNetworkDetectionConfig;

		// Token: 0x0401AA45 RID: 109125
		[Nullable(2)]
		private string GateWayUdpCheckUid;

		// Token: 0x0401AA46 RID: 109126
		private bool GateWayUdpCheckState;
	}
}
