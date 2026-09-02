using System;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.NetworkDetection;

namespace CSharpScript.Game.Module.NetworkDetection
{
	// Token: 0x020056C2 RID: 22210
	[NullableContext(2)]
	public interface INetworkDetectionItemData
	{
		// Token: 0x170090BC RID: 37052
		// (get) Token: 0x0603887E RID: 231550
		// (set) Token: 0x0603887F RID: 231551
		[Nullable(1)]
		INetworkDetectionEntry EntryData { [NullableContext(1)] get; [NullableContext(1)] set; }

		// Token: 0x170090BD RID: 37053
		// (get) Token: 0x06038880 RID: 231552
		// (set) Token: 0x06038881 RID: 231553
		INetworkDetectionResult Result { get; set; }

		// Token: 0x170090BE RID: 37054
		// (get) Token: 0x06038882 RID: 231554
		// (set) Token: 0x06038883 RID: 231555
		bool Proceed { get; set; }

		// Token: 0x170090BF RID: 37055
		// (get) Token: 0x06038884 RID: 231556
		// (set) Token: 0x06038885 RID: 231557
		string ErrorCodeText { get; set; }
	}
}
