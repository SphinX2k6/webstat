using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using CSharpScript.Core.Net;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Login
{
	// Token: 0x020059FD RID: 23037
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class LoginGatewayController : UiControllerBase<LoginGatewayController>
	{
		// Token: 0x0603A5C6 RID: 239046 RVA: 0x00ECC47C File Offset: 0x00ECA67C
		public bool SupportIpv6Address()
		{
			TArray<string> tarray = new TArray<string>();
			UKuroStaticLibrary.GetLocalHostAddresses(ref tarray, false);
			if (tarray == null)
			{
				return false;
			}
			using (IEnumerator<string> enumerator = tarray.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.Contains(':'))
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0603A5C7 RID: 239047 RVA: 0x00ECC4E0 File Offset: 0x00ECA6E0
		[return: Nullable(0)]
		public UniTask<bool> ConnectGateWay(string token, List<NetHostInfo> hostInfos, [Nullable(2)] GatewayLatencyConfigVo gatewayLatencyConfig)
		{
			LoginGatewayController.<ConnectGateWay>d__3 <ConnectGateWay>d__;
			<ConnectGateWay>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ConnectGateWay>d__.<>4__this = this;
			<ConnectGateWay>d__.token = token;
			<ConnectGateWay>d__.hostInfos = hostInfos;
			<ConnectGateWay>d__.gatewayLatencyConfig = gatewayLatencyConfig;
			<ConnectGateWay>d__.<>1__state = -1;
			<ConnectGateWay>d__.<>t__builder.Start<LoginGatewayController.<ConnectGateWay>d__3>(ref <ConnectGateWay>d__);
			return <ConnectGateWay>d__.<>t__builder.Task;
		}

		// Token: 0x0603A5C8 RID: 239048 RVA: 0x00ECC53C File Offset: 0x00ECA73C
		[return: Nullable(0)]
		public static UniTask<bool> ConnectGatewayWithoutDetection(string token, List<NetHostInfo> hostInfos)
		{
			LoginGatewayController.<ConnectGatewayWithoutDetection>d__4 <ConnectGatewayWithoutDetection>d__;
			<ConnectGatewayWithoutDetection>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ConnectGatewayWithoutDetection>d__.token = token;
			<ConnectGatewayWithoutDetection>d__.hostInfos = hostInfos;
			<ConnectGatewayWithoutDetection>d__.<>1__state = -1;
			<ConnectGatewayWithoutDetection>d__.<>t__builder.Start<LoginGatewayController.<ConnectGatewayWithoutDetection>d__4>(ref <ConnectGatewayWithoutDetection>d__);
			return <ConnectGatewayWithoutDetection>d__.<>t__builder.Task;
		}

		// Token: 0x0603A5C9 RID: 239049 RVA: 0x00ECC588 File Offset: 0x00ECA788
		[return: Nullable(0)]
		public static UniTask<bool> ConnectGateWayWithDetection(string token, List<NetHostInfo> hostInfos, GatewayLatencyConfigVo gatewayLatencyConfig)
		{
			LoginGatewayController.<ConnectGateWayWithDetection>d__5 <ConnectGateWayWithDetection>d__;
			<ConnectGateWayWithDetection>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ConnectGateWayWithDetection>d__.token = token;
			<ConnectGateWayWithDetection>d__.hostInfos = hostInfos;
			<ConnectGateWayWithDetection>d__.gatewayLatencyConfig = gatewayLatencyConfig;
			<ConnectGateWayWithDetection>d__.<>1__state = -1;
			<ConnectGateWayWithDetection>d__.<>t__builder.Start<LoginGatewayController.<ConnectGateWayWithDetection>d__5>(ref <ConnectGateWayWithDetection>d__);
			return <ConnectGateWayWithDetection>d__.<>t__builder.Task;
		}

		// Token: 0x0603A5CA RID: 239050 RVA: 0x00ECC5DC File Offset: 0x00ECA7DC
		[return: TupleElementNames(new string[]
		{
			"Host",
			"HasHttp"
		})]
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		private static ValueTuple<string, bool> RemoveHttpPrefix(string host)
		{
			if (host.StartsWith("http://"))
			{
				return new ValueTuple<string, bool>(host.Substring("http://".Length), true);
			}
			if (host.StartsWith("https://"))
			{
				return new ValueTuple<string, bool>(host.Substring("https://".Length), true);
			}
			return new ValueTuple<string, bool>(host, false);
		}

		// Token: 0x0603A5CB RID: 239051 RVA: 0x00ECC638 File Offset: 0x00ECA838
		private static bool IsIPv4(string host)
		{
			return Regex.IsMatch(host, "^(\\d{1,3}\\.){3}\\d{1,3}$");
		}

		// Token: 0x0603A5CC RID: 239052 RVA: 0x00ECC645 File Offset: 0x00ECA845
		private static bool IsIPv6(string host)
		{
			return host.Contains(':') && !host.Contains("://");
		}

		// Token: 0x0603A5CD RID: 239053 RVA: 0x00ECC664 File Offset: 0x00ECA864
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		private static UniTask<string> ResolveHostToIp(string host)
		{
			LoginGatewayController.<ResolveHostToIp>d__9 <ResolveHostToIp>d__;
			<ResolveHostToIp>d__.<>t__builder = AsyncUniTaskMethodBuilder<string>.Create();
			<ResolveHostToIp>d__.host = host;
			<ResolveHostToIp>d__.<>1__state = -1;
			<ResolveHostToIp>d__.<>t__builder.Start<LoginGatewayController.<ResolveHostToIp>d__9>(ref <ResolveHostToIp>d__);
			return <ResolveHostToIp>d__.<>t__builder.Task;
		}

		// Token: 0x0603A5CE RID: 239054 RVA: 0x00ECC6A8 File Offset: 0x00ECA8A8
		[return: Nullable(0)]
		private static UniTask<bool> ConnectGateWayInternal(string token, string host, int port, bool showConfirmBox, bool pickByDetection, [Nullable(new byte[]
		{
			2,
			1
		})] List<LoginGateWayDetection> detections = null)
		{
			LoginGatewayController.<ConnectGateWayInternal>d__10 <ConnectGateWayInternal>d__;
			<ConnectGateWayInternal>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ConnectGateWayInternal>d__.token = token;
			<ConnectGateWayInternal>d__.host = host;
			<ConnectGateWayInternal>d__.port = port;
			<ConnectGateWayInternal>d__.showConfirmBox = showConfirmBox;
			<ConnectGateWayInternal>d__.pickByDetection = pickByDetection;
			<ConnectGateWayInternal>d__.detections = detections;
			<ConnectGateWayInternal>d__.<>1__state = -1;
			<ConnectGateWayInternal>d__.<>t__builder.Start<LoginGatewayController.<ConnectGateWayInternal>d__10>(ref <ConnectGateWayInternal>d__);
			return <ConnectGateWayInternal>d__.<>t__builder.Task;
		}

		// Token: 0x040210BC RID: 135356
		private const string HTTP_PREFIX_STRING = "http://";

		// Token: 0x040210BD RID: 135357
		private const string HTTPS_PREFIX_STRING = "https://";
	}
}
