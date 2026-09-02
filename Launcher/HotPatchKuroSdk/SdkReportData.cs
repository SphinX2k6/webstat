using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using CSharpScript.Launcher.BaseConfig;

namespace CSharpScript.Launcher.HotPatchKuroSdk
{
	// Token: 0x02004610 RID: 17936
	[NullableContext(1)]
	[Nullable(0)]
	public class SdkReportData
	{
		// Token: 0x0602EE65 RID: 192101 RVA: 0x00B1B94F File Offset: 0x00B19B4F
		public SdkReportData([Nullable(new byte[]
		{
			2,
			1,
			1
		})] Dictionary<string, string> eventData)
		{
			this.EventData = eventData;
			this.IfGlobalSdk = (Singleton<BaseConfigController>.Instance.GetPublicValue("SdkArea") != "CN");
		}

		// Token: 0x0602EE66 RID: 192102 RVA: 0x00B1B980 File Offset: 0x00B19B80
		public virtual string GetEventName()
		{
			Singleton<LauncherLog>.Instance.Debug("当前LogReport没有重写EventName,请重写EventName", default(ReadOnlySpan<ValueTuple<string, object>>));
			return "";
		}

		// Token: 0x0602EE67 RID: 192103 RVA: 0x00B1B9AC File Offset: 0x00B19BAC
		protected virtual string GetEventDataJson()
		{
			if (this.EventData == null)
			{
				return "{}";
			}
			int count = this.EventData.Count;
			if (count == 0)
			{
				return "{}";
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append('{');
			int num = 0;
			foreach (KeyValuePair<string, string> keyValuePair in this.EventData)
			{
				StringBuilder stringBuilder2 = stringBuilder;
				StringBuilder stringBuilder3 = stringBuilder2;
				StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(5, 2, stringBuilder2);
				appendInterpolatedStringHandler.AppendLiteral("\"");
				appendInterpolatedStringHandler.AppendFormatted(keyValuePair.Key);
				appendInterpolatedStringHandler.AppendLiteral("\":\"");
				appendInterpolatedStringHandler.AppendFormatted(keyValuePair.Value);
				appendInterpolatedStringHandler.AppendLiteral("\"");
				stringBuilder3.Append(ref appendInterpolatedStringHandler);
				if (count - 1 != num)
				{
					stringBuilder.Append(',');
				}
				num++;
			}
			stringBuilder.Append('}');
			return stringBuilder.ToString();
		}

		// Token: 0x0602EE68 RID: 192104 RVA: 0x00B1BAA8 File Offset: 0x00B19CA8
		public string GetReportString()
		{
			string text = JsonSerializer.Serialize<Dictionary<string, string>>(new Dictionary<string, string>
			{
				{
					"eventName",
					this.GetEventName()
				},
				{
					"eventParams",
					this.GetEventDataJson()
				}
			}, null);
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "上报埋点信息";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("finalJson", text);
			instance.Info(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return text;
		}

		// Token: 0x0401AAE4 RID: 109284
		public bool IfGlobalSdk;

		// Token: 0x0401AAE5 RID: 109285
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		protected Dictionary<string, string> EventData;
	}
}
