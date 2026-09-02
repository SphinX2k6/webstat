using System;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.NetworkDetection;

namespace CSharpScript.Launcher.Ui.HotFix.NetWorkDetection
{
	// Token: 0x02004521 RID: 17697
	[NullableContext(2)]
	[Nullable(0)]
	public class HotFixNetworkDetectionLayoutItemData : IHotFixNetworkDetectionLayoutItemData, IHotFixLayoutData
	{
		// Token: 0x1700804F RID: 32847
		// (get) Token: 0x0602E9E8 RID: 190952 RVA: 0x00B0B304 File Offset: 0x00B09504
		// (set) Token: 0x0602E9E9 RID: 190953 RVA: 0x00B0B30C File Offset: 0x00B0950C
		public int? Index { get; set; }

		// Token: 0x17008050 RID: 32848
		// (get) Token: 0x0602E9EA RID: 190954 RVA: 0x00B0B315 File Offset: 0x00B09515
		// (set) Token: 0x0602E9EB RID: 190955 RVA: 0x00B0B31D File Offset: 0x00B0951D
		[Nullable(1)]
		public INetworkDetectionEntry EntryData { [NullableContext(1)] get; [NullableContext(1)] set; }

		// Token: 0x17008051 RID: 32849
		// (get) Token: 0x0602E9EC RID: 190956 RVA: 0x00B0B326 File Offset: 0x00B09526
		// (set) Token: 0x0602E9ED RID: 190957 RVA: 0x00B0B32E File Offset: 0x00B0952E
		public INetworkDetectionResult Result { get; set; }

		// Token: 0x17008052 RID: 32850
		// (get) Token: 0x0602E9EE RID: 190958 RVA: 0x00B0B337 File Offset: 0x00B09537
		// (set) Token: 0x0602E9EF RID: 190959 RVA: 0x00B0B33F File Offset: 0x00B0953F
		public bool Proceed { get; set; }

		// Token: 0x17008053 RID: 32851
		// (get) Token: 0x0602E9F0 RID: 190960 RVA: 0x00B0B348 File Offset: 0x00B09548
		// (set) Token: 0x0602E9F1 RID: 190961 RVA: 0x00B0B350 File Offset: 0x00B09550
		public string ErrorCodeText { get; set; }
	}
}
