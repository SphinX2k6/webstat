using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace CSharpScript.Core.Net
{
	// Token: 0x02007121 RID: 28961
	public static class NetHostInfoExtensions
	{
		// Token: 0x0604626C RID: 287340 RVA: 0x0126C7D0 File Offset: 0x0126A9D0
		[NullableContext(1)]
		public static string FormatNetHostInfo([Nullable(new byte[]
		{
			2,
			1
		})] this List<NetHostInfo> hostInfos)
		{
			if (hostInfos == null || hostInfos.Count == 0)
			{
				return string.Empty;
			}
			if (hostInfos.Count == 1)
			{
				NetHostInfo netHostInfo = hostInfos[0];
				return netHostInfo.host + ":" + netHostInfo.port;
			}
			StringBuilder stringBuilder = new StringBuilder(hostInfos.Count * 20);
			for (int i = 0; i < hostInfos.Count; i++)
			{
				if (i > 0)
				{
					stringBuilder.Append(", ");
				}
				stringBuilder.Append(hostInfos[i].host).Append(':').Append(hostInfos[i].port);
			}
			return stringBuilder.ToString();
		}
	}
}
