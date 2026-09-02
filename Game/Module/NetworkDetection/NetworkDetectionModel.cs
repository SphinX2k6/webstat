using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.BaseConfig;

namespace CSharpScript.Game.Module.NetworkDetection
{
	// Token: 0x020056C5 RID: 22213
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class NetworkDetectionModel : ModelBase<NetworkDetectionModel>
	{
		// Token: 0x06038897 RID: 231575 RVA: 0x00E5290C File Offset: 0x00E50B0C
		public bool NeedInterruptDetectionDoubleCheckTips()
		{
			return (double)DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() * 0.0010000000474974513 - this.LastDoubleCheckTime >= 5.0;
		}

		// Token: 0x06038898 RID: 231576 RVA: 0x00E52948 File Offset: 0x00E50B48
		public void ConfirmInterruptDetection()
		{
			double lastDoubleCheckTime = (double)DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() * 0.0010000000474974513;
			this.LastDoubleCheckTime = lastDoubleCheckTime;
		}

		// Token: 0x06038899 RID: 231577 RVA: 0x00E52975 File Offset: 0x00E50B75
		public void ResetInterruptDetectionCheckTime()
		{
			this.LastDoubleCheckTime = 0.0;
		}

		// Token: 0x0603889A RID: 231578 RVA: 0x00E52988 File Offset: 0x00E50B88
		[NullableContext(1)]
		public string GetFinalErrorCodeString(IReadOnlyList<INetworkDetectionItemData> datas)
		{
			List<string> list = new List<string>();
			foreach (INetworkDetectionItemData networkDetectionItemData in datas)
			{
				if (!string.IsNullOrEmpty(networkDetectionItemData.ErrorCodeText))
				{
					list.Add(networkDetectionItemData.ErrorCodeText);
				}
			}
			return string.Join("\n", list);
		}

		// Token: 0x04020446 RID: 132166
		public ILoginServersData CurrentSelectServerData;

		// Token: 0x04020447 RID: 132167
		public ILoginServersData CurrentUiSelectSeverData;

		// Token: 0x04020448 RID: 132168
		private double LastDoubleCheckTime;
	}
}
