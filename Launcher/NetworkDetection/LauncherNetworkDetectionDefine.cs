using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.NetworkDetection
{
	// Token: 0x020045E0 RID: 17888
	[NullableContext(1)]
	[Nullable(0)]
	public static class LauncherNetworkDetectionDefine
	{
		// Token: 0x0401AA6B RID: 109163
		[StaticVariableRuleIgnore]
		public static readonly INetworkDetectionEntry[] networkDetectionEntries = new INetworkDetectionEntry[]
		{
			new INetworkDetectionEntry
			{
				NameLocalKey = "NetworkDetection_Proxy",
				Type = ENetworkDetectionType.Proxy
			},
			new INetworkDetectionEntry
			{
				NameLocalKey = "NetworkDetection_Domain",
				Type = ENetworkDetectionType.Domain
			},
			new INetworkDetectionEntry
			{
				NameLocalKey = "NetworkDetection_Ping",
				Type = ENetworkDetectionType.Ping
			},
			new INetworkDetectionEntry
			{
				NameLocalKey = "NetworkDetection_Http",
				Type = ENetworkDetectionType.Http
			},
			new INetworkDetectionEntry
			{
				NameLocalKey = "NetworkDetection_Udp",
				Type = ENetworkDetectionType.UdpPort
			},
			new INetworkDetectionEntry
			{
				NameLocalKey = "NetworkDetection_Route_Detection",
				Type = ENetworkDetectionType.TraceRoute
			}
		};

		// Token: 0x0401AA6C RID: 109164
		[StaticVariableRuleIgnore]
		public static Dictionary<ESendState, int> SendStateToCustomServiceLogMap = new Dictionary<ESendState, int>
		{
			{
				ESendState.ESS_None,
				6
			},
			{
				ESendState.ESS_Compressing,
				5
			},
			{
				ESendState.ESS_Sending,
				4
			},
			{
				ESendState.ESS_Interrupted,
				3
			},
			{
				ESendState.ESS_Fail,
				2
			},
			{
				ESendState.ESS_Done,
				1
			}
		};

		// Token: 0x0401AA6D RID: 109165
		public const int DOUBLE_CHECK_INTERVAL = 5;

		// Token: 0x0401AA6E RID: 109166
		public const float MS_TO_SECONDS = 0.001f;
	}
}
