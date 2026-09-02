using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Core.Net
{
	// Token: 0x0200711D RID: 28957
	public class GatewayLatencyConfigVo
	{
		// Token: 0x0604625F RID: 287327 RVA: 0x0126C59C File Offset: 0x0126A79C
		[NullableContext(1)]
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(54, 3);
			defaultInterpolatedStringHandler.AppendLiteral("GatewayLatencyConfigVo(Enabled=");
			defaultInterpolatedStringHandler.AppendFormatted<bool>(this.enabled);
			defaultInterpolatedStringHandler.AppendLiteral(", Count=");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.count);
			defaultInterpolatedStringHandler.AppendLiteral(", TimeoutMs=");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.timeoutMs);
			defaultInterpolatedStringHandler.AppendLiteral("ms)");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x04027565 RID: 161125
		public bool enabled = true;

		// Token: 0x04027566 RID: 161126
		public int count;

		// Token: 0x04027567 RID: 161127
		public int timeoutMs;
	}
}
