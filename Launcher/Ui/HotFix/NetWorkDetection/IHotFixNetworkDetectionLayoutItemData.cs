using System;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.NetworkDetection;

namespace CSharpScript.Launcher.Ui.HotFix.NetWorkDetection
{
	// Token: 0x02004520 RID: 17696
	[NullableContext(2)]
	public interface IHotFixNetworkDetectionLayoutItemData : IHotFixLayoutData
	{
		// Token: 0x1700804B RID: 32843
		// (get) Token: 0x0602E9E0 RID: 190944
		// (set) Token: 0x0602E9E1 RID: 190945
		[Nullable(1)]
		INetworkDetectionEntry EntryData { [NullableContext(1)] get; [NullableContext(1)] set; }

		// Token: 0x1700804C RID: 32844
		// (get) Token: 0x0602E9E2 RID: 190946
		// (set) Token: 0x0602E9E3 RID: 190947
		INetworkDetectionResult Result { get; set; }

		// Token: 0x1700804D RID: 32845
		// (get) Token: 0x0602E9E4 RID: 190948
		// (set) Token: 0x0602E9E5 RID: 190949
		bool Proceed { get; set; }

		// Token: 0x1700804E RID: 32846
		// (get) Token: 0x0602E9E6 RID: 190950
		// (set) Token: 0x0602E9E7 RID: 190951
		string ErrorCodeText { get; set; }
	}
}
