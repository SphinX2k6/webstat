using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.BaseConfig;

namespace CSharpScript.Launcher.HotPatchKuroSdk
{
	// Token: 0x02004611 RID: 17937
	public class HotPatchReportData : IStaticVariableResetter
	{
		// Token: 0x0602EE69 RID: 192105 RVA: 0x00B1BB07 File Offset: 0x00B19D07
		static HotPatchReportData()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(HotPatchReportData.CreateStaticDefaultValue), new Action(HotPatchReportData.ResetStaticDefaultValue));
		}

		// Token: 0x0602EE6A RID: 192106 RVA: 0x00B1BB28 File Offset: 0x00B19D28
		[NullableContext(2)]
		public static SdkReportData CreateData(ESdkHotPatchReportEnum type, [Nullable(new byte[]
		{
			2,
			1,
			1
		})] Dictionary<string, string> dataMap)
		{
			if (Singleton<BaseConfigController>.Instance.GetPublicValue("SdkArea") == "CN")
			{
				return null;
			}
			if (HotPatchReportData.SdkReportTypeMap.Count == 0)
			{
				HotPatchReportData.SdkReportTypeMap[0] = (([Nullable(new byte[]
				{
					2,
					1,
					1
				})] Dictionary<string, string> dataMap) => new SdkLogoReportData(dataMap));
				HotPatchReportData.SdkReportTypeMap[1] = (([Nullable(new byte[]
				{
					2,
					1,
					1
				})] Dictionary<string, string> dataMap) => new SdkCheckVersionStart(dataMap));
				HotPatchReportData.SdkReportTypeMap[2] = (([Nullable(new byte[]
				{
					2,
					1,
					1
				})] Dictionary<string, string> dataMap) => new SdkCheckVersionEnd(dataMap));
				HotPatchReportData.SdkReportTypeMap[3] = (([Nullable(new byte[]
				{
					2,
					1,
					1
				})] Dictionary<string, string> dataMap) => new SdkCheckVersionFail(dataMap));
				HotPatchReportData.SdkReportTypeMap[4] = (([Nullable(new byte[]
				{
					2,
					1,
					1
				})] Dictionary<string, string> dataMap) => new SdkResourceDownloadStart(dataMap));
				HotPatchReportData.SdkReportTypeMap[5] = (([Nullable(new byte[]
				{
					2,
					1,
					1
				})] Dictionary<string, string> dataMap) => new SdkResourceDownloadEnd(dataMap));
				HotPatchReportData.SdkReportTypeMap[6] = (([Nullable(new byte[]
				{
					2,
					1,
					1
				})] Dictionary<string, string> dataMap) => new SdkResourceDownloadFail(dataMap));
			}
			Func<Dictionary<string, string>, SdkReportData> func;
			if (!HotPatchReportData.SdkReportTypeMap.TryGetValue((int)type, out func))
			{
				return null;
			}
			return func(dataMap2);
		}

		// Token: 0x0602EE6B RID: 192107 RVA: 0x00B1BC9F File Offset: 0x00B19E9F
		public static void CreateStaticDefaultValue()
		{
			HotPatchReportData.SdkReportTypeMap = new Dictionary<int, Func<Dictionary<string, string>, SdkReportData>>();
		}

		// Token: 0x0602EE6C RID: 192108 RVA: 0x00B1BCAB File Offset: 0x00B19EAB
		public static void ResetStaticDefaultValue()
		{
			HotPatchReportData.SdkReportTypeMap = null;
		}

		// Token: 0x0401AAE6 RID: 109286
		[Nullable(new byte[]
		{
			1,
			1,
			2,
			1,
			1,
			1
		})]
		private static Dictionary<int, Func<Dictionary<string, string>, SdkReportData>> SdkReportTypeMap;
	}
}
