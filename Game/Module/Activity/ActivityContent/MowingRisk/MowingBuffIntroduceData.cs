using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MowingRisk
{
	// Token: 0x0200667D RID: 26237
	[NullableContext(1)]
	[Nullable(0)]
	public class MowingBuffIntroduceData : IMowingBuffIntroduceData
	{
		// Token: 0x17009FC2 RID: 40898
		// (get) Token: 0x06041893 RID: 268435 RVA: 0x010D0CC1 File Offset: 0x010CEEC1
		// (set) Token: 0x06041894 RID: 268436 RVA: 0x010D0CC9 File Offset: 0x010CEEC9
		public string BackgroundPath { get; set; }

		// Token: 0x17009FC3 RID: 40899
		// (get) Token: 0x06041895 RID: 268437 RVA: 0x010D0CD2 File Offset: 0x010CEED2
		// (set) Token: 0x06041896 RID: 268438 RVA: 0x010D0CDA File Offset: 0x010CEEDA
		public string LevelTextId { get; set; }

		// Token: 0x17009FC4 RID: 40900
		// (get) Token: 0x06041897 RID: 268439 RVA: 0x010D0CE3 File Offset: 0x010CEEE3
		// (set) Token: 0x06041898 RID: 268440 RVA: 0x010D0CEB File Offset: 0x010CEEEB
		public string[] LevelTextArgs { get; set; }

		// Token: 0x17009FC5 RID: 40901
		// (get) Token: 0x06041899 RID: 268441 RVA: 0x010D0CF4 File Offset: 0x010CEEF4
		// (set) Token: 0x0604189A RID: 268442 RVA: 0x010D0CFC File Offset: 0x010CEEFC
		public string NameTextId { get; set; }

		// Token: 0x17009FC6 RID: 40902
		// (get) Token: 0x0604189B RID: 268443 RVA: 0x010D0D05 File Offset: 0x010CEF05
		// (set) Token: 0x0604189C RID: 268444 RVA: 0x010D0D0D File Offset: 0x010CEF0D
		public string TipsTextId { get; set; }

		// Token: 0x17009FC7 RID: 40903
		// (get) Token: 0x0604189D RID: 268445 RVA: 0x010D0D16 File Offset: 0x010CEF16
		// (set) Token: 0x0604189E RID: 268446 RVA: 0x010D0D1E File Offset: 0x010CEF1E
		public string[] TipsArgs { get; set; }

		// Token: 0x17009FC8 RID: 40904
		// (get) Token: 0x0604189F RID: 268447 RVA: 0x010D0D27 File Offset: 0x010CEF27
		// (set) Token: 0x060418A0 RID: 268448 RVA: 0x010D0D2F File Offset: 0x010CEF2F
		public string IconPath { get; set; }

		// Token: 0x17009FC9 RID: 40905
		// (get) Token: 0x060418A1 RID: 268449 RVA: 0x010D0D38 File Offset: 0x010CEF38
		// (set) Token: 0x060418A2 RID: 268450 RVA: 0x010D0D40 File Offset: 0x010CEF40
		public string HexColor { get; set; }

		// Token: 0x17009FCA RID: 40906
		// (get) Token: 0x060418A3 RID: 268451 RVA: 0x010D0D49 File Offset: 0x010CEF49
		// (set) Token: 0x060418A4 RID: 268452 RVA: 0x010D0D51 File Offset: 0x010CEF51
		public bool IsUnlock { get; set; }
	}
}
