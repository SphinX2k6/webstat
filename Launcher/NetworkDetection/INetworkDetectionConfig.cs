using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.NetworkDetection
{
	// Token: 0x020045D8 RID: 17880
	[NullableContext(2)]
	[Nullable(0)]
	public class INetworkDetectionConfig
	{
		// Token: 0x1700807C RID: 32892
		// (get) Token: 0x0602ED71 RID: 191857 RVA: 0x00B17D21 File Offset: 0x00B15F21
		// (set) Token: 0x0602ED72 RID: 191858 RVA: 0x00B17D29 File Offset: 0x00B15F29
		public string ip { get; set; }

		// Token: 0x1700807D RID: 32893
		// (get) Token: 0x0602ED73 RID: 191859 RVA: 0x00B17D32 File Offset: 0x00B15F32
		// (set) Token: 0x0602ED74 RID: 191860 RVA: 0x00B17D3A File Offset: 0x00B15F3A
		public string PingUrl { get; set; }

		// Token: 0x1700807E RID: 32894
		// (get) Token: 0x0602ED75 RID: 191861 RVA: 0x00B17D43 File Offset: 0x00B15F43
		// (set) Token: 0x0602ED76 RID: 191862 RVA: 0x00B17D4B File Offset: 0x00B15F4B
		public int[] UdpPort { get; set; }

		// Token: 0x1700807F RID: 32895
		// (get) Token: 0x0602ED77 RID: 191863 RVA: 0x00B17D54 File Offset: 0x00B15F54
		// (set) Token: 0x0602ED78 RID: 191864 RVA: 0x00B17D5C File Offset: 0x00B15F5C
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public string[] LoginUrl { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }
	}
}
