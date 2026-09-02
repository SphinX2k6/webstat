using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.Download
{
	// Token: 0x0200461B RID: 17947
	public class UrlPrefixInfo
	{
		// Token: 0x0401AAF1 RID: 109297
		[Nullable(1)]
		public string Address = "";

		// Token: 0x0401AAF2 RID: 109298
		public int Price;

		// Token: 0x0401AAF3 RID: 109299
		public int OriginOrder;

		// Token: 0x0401AAF4 RID: 109300
		public int EvalPoint;

		// Token: 0x0401AAF5 RID: 109301
		public bool IsEvaluated;

		// Token: 0x0401AAF6 RID: 109302
		public float RemainDownloadTime;

		// Token: 0x0401AAF7 RID: 109303
		public long DownloadedSize;

		// Token: 0x0401AAF8 RID: 109304
		public int Speed;
	}
}
