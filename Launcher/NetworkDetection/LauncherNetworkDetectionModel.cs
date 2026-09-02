using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Define;
using CSharpScript.Launcher.Platform;

namespace CSharpScript.Launcher.NetworkDetection
{
	// Token: 0x020045E4 RID: 17892
	[NullableContext(1)]
	[Nullable(0)]
	public class LauncherNetworkDetectionModel
	{
		// Token: 0x0602ED81 RID: 191873 RVA: 0x00B17EA4 File Offset: 0x00B160A4
		public static string GetGenericErrorCodeTips(ENetworkDetectionType detectionType, int errorCode, INetworkDetectionResult result)
		{
			string value = "ERROR CODE:";
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler;
			switch (detectionType)
			{
			case ENetworkDetectionType.Proxy:
				return Singleton<LauncherConfigLib>.Instance.GetHotPatchText("NetworkDetection_Proxy_Wrong") + (result as INetworkDetectionProxyResult).Address;
			case ENetworkDetectionType.Domain:
				value = Singleton<LauncherConfigLib>.Instance.GetHotPatchText("NetworkDetection_Domain_Wrong");
				break;
			case ENetworkDetectionType.Ping:
			{
				INetworkDetectionPingResult networkDetectionPingResult = result as INetworkDetectionPingResult;
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(21, 5);
				defaultInterpolatedStringHandler.AppendFormatted(Singleton<LauncherConfigLib>.Instance.GetHotPatchText("NetworkDetection_Ping_Wrong"));
				defaultInterpolatedStringHandler.AppendLiteral(" Min:");
				defaultInterpolatedStringHandler.AppendFormatted<float>(networkDetectionPingResult.Result.Min);
				defaultInterpolatedStringHandler.AppendLiteral(",Max:");
				defaultInterpolatedStringHandler.AppendFormatted<float>(networkDetectionPingResult.Result.Max);
				defaultInterpolatedStringHandler.AppendLiteral(",Min:");
				defaultInterpolatedStringHandler.AppendFormatted<float>(networkDetectionPingResult.Result.Avg);
				defaultInterpolatedStringHandler.AppendLiteral(",Loss:");
				defaultInterpolatedStringHandler.AppendFormatted<float>(networkDetectionPingResult.Result.Loss);
				value = defaultInterpolatedStringHandler.ToStringAndClear();
				break;
			}
			case ENetworkDetectionType.Http:
				value = Singleton<LauncherConfigLib>.Instance.GetHotPatchText("NetworkDetection_Http_Wrong");
				break;
			case ENetworkDetectionType.UdpPort:
				value = Singleton<LauncherConfigLib>.Instance.GetHotPatchText("NetworkDetection_Udp_Wrong");
				break;
			}
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 2);
			defaultInterpolatedStringHandler.AppendFormatted(value);
			defaultInterpolatedStringHandler.AppendFormatted<int>(errorCode);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x0602ED82 RID: 191874 RVA: 0x00B17FF8 File Offset: 0x00B161F8
		public static string GenerateTraceCode()
		{
			List<int> list = new List<int>();
			for (int i = 0; i < 12; i++)
			{
				int item = Random.Shared.Next(0, 10);
				list.Add(item);
			}
			return string.Join<int>("", list);
		}

		// Token: 0x0602ED83 RID: 191875 RVA: 0x00B18038 File Offset: 0x00B16238
		public static List<INetworkDetectionEntry> GetDetectionDataList()
		{
			if (Singleton<Platform>.Instance.IsWindowsPlatform())
			{
				List<INetworkDetectionEntry> list = new List<INetworkDetectionEntry>();
				foreach (INetworkDetectionEntry item in LauncherNetworkDetectionDefine.networkDetectionEntries)
				{
					list.Add(item);
				}
				return list;
			}
			List<INetworkDetectionEntry> list2 = new List<INetworkDetectionEntry>();
			foreach (INetworkDetectionEntry networkDetectionEntry in LauncherNetworkDetectionDefine.networkDetectionEntries)
			{
				if (networkDetectionEntry.Type != ENetworkDetectionType.TraceRoute)
				{
					list2.Add(networkDetectionEntry);
				}
			}
			return list2;
		}
	}
}
