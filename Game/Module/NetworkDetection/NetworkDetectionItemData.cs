using System;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.NetworkDetection;

namespace CSharpScript.Game.Module.NetworkDetection
{
	// Token: 0x020056C3 RID: 22211
	[NullableContext(2)]
	[Nullable(0)]
	public class NetworkDetectionItemData : INetworkDetectionItemData
	{
		// Token: 0x170090C0 RID: 37056
		// (get) Token: 0x06038886 RID: 231558 RVA: 0x00E52628 File Offset: 0x00E50828
		// (set) Token: 0x06038887 RID: 231559 RVA: 0x00E52630 File Offset: 0x00E50830
		[Nullable(1)]
		public INetworkDetectionEntry EntryData { [NullableContext(1)] get; [NullableContext(1)] set; }

		// Token: 0x170090C1 RID: 37057
		// (get) Token: 0x06038888 RID: 231560 RVA: 0x00E52639 File Offset: 0x00E50839
		// (set) Token: 0x06038889 RID: 231561 RVA: 0x00E52641 File Offset: 0x00E50841
		public INetworkDetectionResult Result { get; set; }

		// Token: 0x170090C2 RID: 37058
		// (get) Token: 0x0603888A RID: 231562 RVA: 0x00E5264A File Offset: 0x00E5084A
		// (set) Token: 0x0603888B RID: 231563 RVA: 0x00E52652 File Offset: 0x00E50852
		public bool Proceed { get; set; }

		// Token: 0x170090C3 RID: 37059
		// (get) Token: 0x0603888C RID: 231564 RVA: 0x00E5265B File Offset: 0x00E5085B
		// (set) Token: 0x0603888D RID: 231565 RVA: 0x00E52663 File Offset: 0x00E50863
		public string ErrorCodeText { get; set; }
	}
}
