using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using CSharpScript.Core.Common;
using CSharpScript.Launcher.BaseConfig;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002106 RID: 8454
[NullableContext(1)]
[Nullable(0)]
public class LoginUdpDelay : IStaticVariableResetter
{
	// Token: 0x060102C4 RID: 66244 RVA: 0x00471C3A File Offset: 0x0046FE3A
	static LoginUdpDelay()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(LoginUdpDelay.CreateStaticDefaultValue), new Action(LoginUdpDelay.ResetStaticDefaultValue));
	}

	// Token: 0x060102C5 RID: 66245 RVA: 0x00471C59 File Offset: 0x0046FE59
	public static void CreateStaticDefaultValue()
	{
		LoginUdpDelay.ClientIp = "anonymous";
		LoginUdpDelay.TraceId = "";
		LoginUdpDelay.UdpProbe = new List<ValueTuple<string, IUdpProbe>>();
	}

	// Token: 0x060102C6 RID: 66246 RVA: 0x00471C79 File Offset: 0x0046FE79
	public static void ResetStaticDefaultValue()
	{
		LoginUdpDelay.ClientIp = "anonymous";
		LoginUdpDelay.TraceId = "";
		LoginUdpDelay.UdpRegionCfg = null;
		LoginUdpDelay.TimerId = null;
		LoginUdpDelay.UdpProbe = null;
	}

	// Token: 0x060102C7 RID: 66247 RVA: 0x00471CA1 File Offset: 0x0046FEA1
	private static bool IsIPv4(string address)
	{
		return new Regex("^(25[0-5]|2[0-4]\\d|1\\d{2}|[1-9]?\\d)(\\.(25[0-5]|2[0-4]\\d|1\\d{2}|[1-9]?\\d)){3}$").IsMatch(address);
	}

	// Token: 0x060102C8 RID: 66248 RVA: 0x00471CB4 File Offset: 0x0046FEB4
	private static bool IsIPv6(string address)
	{
		if (string.IsNullOrEmpty(address))
		{
			return false;
		}
		if (address.Contains("."))
		{
			return false;
		}
		string[] array = address.Split(new string[]
		{
			"::"
		}, StringSplitOptions.None);
		if (array.Length > 2)
		{
			return false;
		}
		string text = array[0];
		string text2 = (array.Length > 1) ? array[1] : null;
		string[] array2 = (!string.IsNullOrEmpty(text)) ? text.Split(':', StringSplitOptions.None) : new string[0];
		string[] array3 = (!string.IsNullOrEmpty(text2)) ? text2.Split(':', StringSplitOptions.None) : new string[0];
		if (!array2.All(new Func<string, bool>(LoginUdpDelay.<IsIPv6>g__IsValidBlock|13_0)) || !array3.All(new Func<string, bool>(LoginUdpDelay.<IsIPv6>g__IsValidBlock|13_0)))
		{
			return false;
		}
		int num = array2.Length + array3.Length;
		if (text2 != null)
		{
			return num < 8;
		}
		return num == 8;
	}

	// Token: 0x060102C9 RID: 66249 RVA: 0x00471D81 File Offset: 0x0046FF81
	private static bool IsDomain(string address)
	{
		return new Regex("^(?=.{1,253}$)(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?\\.)+[a-zA-Z]{2,63}$").IsMatch(address);
	}

	// Token: 0x060102CA RID: 66250 RVA: 0x00471D93 File Offset: 0x0046FF93
	private static LoginUdpDelay.AddressType GetAddressType(string address)
	{
		address = address.Trim();
		if (string.IsNullOrEmpty(address))
		{
			return LoginUdpDelay.AddressType.Unknown;
		}
		if (LoginUdpDelay.IsIPv4(address))
		{
			return LoginUdpDelay.AddressType.IPv4;
		}
		if (LoginUdpDelay.IsIPv6(address))
		{
			return LoginUdpDelay.AddressType.IPv6;
		}
		if (LoginUdpDelay.IsDomain(address))
		{
			return LoginUdpDelay.AddressType.Domain;
		}
		return LoginUdpDelay.AddressType.Unknown;
	}

	// Token: 0x060102CB RID: 66251 RVA: 0x00471DC8 File Offset: 0x0046FFC8
	[return: Nullable(new byte[]
	{
		0,
		1,
		1
	})]
	private static UniTask<TArray<string>> GetDomianIp(string address)
	{
		LoginUdpDelay.<GetDomianIp>d__16 <GetDomianIp>d__;
		<GetDomianIp>d__.<>t__builder = AsyncUniTaskMethodBuilder<TArray<string>>.Create();
		<GetDomianIp>d__.address = address;
		<GetDomianIp>d__.<>1__state = -1;
		<GetDomianIp>d__.<>t__builder.Start<LoginUdpDelay.<GetDomianIp>d__16>(ref <GetDomianIp>d__);
		return <GetDomianIp>d__.<>t__builder.Task;
	}

	// Token: 0x060102CC RID: 66252 RVA: 0x00471E0C File Offset: 0x0047000C
	[return: Nullable(new byte[]
	{
		0,
		1,
		0,
		1,
		1
	})]
	private static UniTask<List<ValueTuple<string, IUdpProbe>>> GetIP(List<IUdpProbe> address)
	{
		LoginUdpDelay.<GetIP>d__17 <GetIP>d__;
		<GetIP>d__.<>t__builder = AsyncUniTaskMethodBuilder<List<ValueTuple<string, IUdpProbe>>>.Create();
		<GetIP>d__.address = address;
		<GetIP>d__.<>1__state = -1;
		<GetIP>d__.<>t__builder.Start<LoginUdpDelay.<GetIP>d__17>(ref <GetIP>d__);
		return <GetIP>d__.<>t__builder.Task;
	}

	// Token: 0x060102CD RID: 66253 RVA: 0x00471E50 File Offset: 0x00470050
	public static UniTask Start()
	{
		LoginUdpDelay.<Start>d__18 <Start>d__;
		<Start>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Start>d__.<>1__state = -1;
		<Start>d__.<>t__builder.Start<LoginUdpDelay.<Start>d__18>(ref <Start>d__);
		return <Start>d__.<>t__builder.Task;
	}

	// Token: 0x060102CE RID: 66254 RVA: 0x00471E8C File Offset: 0x0047008C
	private static UniTask InitClientIp()
	{
		LoginUdpDelay.<InitClientIp>d__19 <InitClientIp>d__;
		<InitClientIp>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitClientIp>d__.<>1__state = -1;
		<InitClientIp>d__.<>t__builder.Start<LoginUdpDelay.<InitClientIp>d__19>(ref <InitClientIp>d__);
		return <InitClientIp>d__.<>t__builder.Task;
	}

	// Token: 0x060102CF RID: 66255 RVA: 0x00471EC8 File Offset: 0x004700C8
	private static UniTask InitProbeInfo()
	{
		LoginUdpDelay.<InitProbeInfo>d__20 <InitProbeInfo>d__;
		<InitProbeInfo>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitProbeInfo>d__.<>1__state = -1;
		<InitProbeInfo>d__.<>t__builder.Start<LoginUdpDelay.<InitProbeInfo>d__20>(ref <InitProbeInfo>d__);
		return <InitProbeInfo>d__.<>t__builder.Task;
	}

	// Token: 0x060102D0 RID: 66256 RVA: 0x00471F04 File Offset: 0x00470104
	private static void InitTraceId()
	{
		SdkLoginConfig sdkLoginConfig = ModelBase<LoginModel>.Instance.GetSdkLoginConfig();
		LoginUdpDelay.TraceId = (((sdkLoginConfig != null) ? sdkLoginConfig.Uid : null) ?? "") + "_" + UKismetGuidLibrary.NewGuid().ToString();
	}

	// Token: 0x060102D1 RID: 66257 RVA: 0x00471F52 File Offset: 0x00470152
	private static string GenUdpPayload(long ts)
	{
		return Json.Encode(new LoginUdpDelay.Payload
		{
			traceId = LoginUdpDelay.TraceId,
			clientIp = LoginUdpDelay.ClientIp,
			timestamp = ts
		}, null);
	}

	// Token: 0x060102D2 RID: 66258 RVA: 0x00471F7C File Offset: 0x0047017C
	private static void SetTimer()
	{
		if (LoginUdpDelay.UdpRegionCfg == null)
		{
			return;
		}
		if (!LoginUdpDelay.UdpRegionCfg.ProbeOpen)
		{
			return;
		}
		if (LoginUdpDelay.TimerId != null)
		{
			TimerSystem.RealTimeInstance.Remove(LoginUdpDelay.TimerId);
			LoginUdpDelay.TimerId = null;
		}
		TTimerAction ttimerAction = delegate(float _)
		{
			using (List<ValueTuple<string, IUdpProbe>>.Enumerator enumerator = LoginUdpDelay.UdpProbe.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					LoginUdpDelay.<>c__DisplayClass24_0 CS$<>8__locals1 = new LoginUdpDelay.<>c__DisplayClass24_0();
					CS$<>8__locals1.srvInfo = enumerator.Current;
					CS$<>8__locals1.sendTs = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
					string message = LoginUdpDelay.GenUdpPayload(CS$<>8__locals1.sendTs);
					UKuroUdp.SendUdpMessage(CS$<>8__locals1.srvInfo.Item2.ip, CS$<>8__locals1.srvInfo.Item2.port, message, 512, global::DelegateUtils.ToManualReleaseDelegate<FUdpDelegate>(new Action<bool, string>(CS$<>8__locals1.<SetTimer>g__udpCallback|1)));
				}
			}
		};
		ttimerAction(0f);
		LoginUdpDelay.TimerId = TimerSystem.RealTimeInstance.Forever(ttimerAction, (float)(LoginUdpDelay.UdpRegionCfg.ProbeInterval * 1000), 1f, null, null, false);
	}

	// Token: 0x060102D4 RID: 66260 RVA: 0x00472017 File Offset: 0x00470217
	[CompilerGenerated]
	internal static bool <IsIPv6>g__IsValidBlock|13_0(string s)
	{
		return s.Length > 0 && Regex.IsMatch(s, "^[0-9a-fA-F]{1,4}$");
	}

	// Token: 0x04007C3D RID: 31805
	private static string ClientIp;

	// Token: 0x04007C3E RID: 31806
	private static string TraceId;

	// Token: 0x04007C3F RID: 31807
	[Nullable(2)]
	private static IUdpRegion UdpRegionCfg;

	// Token: 0x04007C40 RID: 31808
	[Nullable(new byte[]
	{
		2,
		0,
		1,
		1
	})]
	private static List<ValueTuple<string, IUdpProbe>> UdpProbe;

	// Token: 0x04007C41 RID: 31809
	[Nullable(2)]
	private static TimerHandle TimerId;

	// Token: 0x04007C42 RID: 31810
	private const string CLIENT_IP_KEY = "clientIp";

	// Token: 0x04007C43 RID: 31811
	private const int TEST_PORT = 5500;

	// Token: 0x04007C44 RID: 31812
	private const string REPORT_KEY = "UDP_PROBE";

	// Token: 0x02008483 RID: 33923
	[NullableContext(0)]
	public enum AddressType
	{
		// Token: 0x0402CE59 RID: 183897
		IPv4,
		// Token: 0x0402CE5A RID: 183898
		IPv6,
		// Token: 0x0402CE5B RID: 183899
		Domain,
		// Token: 0x0402CE5C RID: 183900
		Unknown
	}

	// Token: 0x02008484 RID: 33924
	[Nullable(0)]
	[RequiredMember]
	public class Payload
	{
		// Token: 0x060489B1 RID: 297393 RVA: 0x0138387E File Offset: 0x01381A7E
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public Payload()
		{
		}

		// Token: 0x0402CE5D RID: 183901
		[RequiredMember]
		public string traceId;

		// Token: 0x0402CE5E RID: 183902
		[RequiredMember]
		public string clientIp;

		// Token: 0x0402CE5F RID: 183903
		[RequiredMember]
		public long timestamp;
	}
}
