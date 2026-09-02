using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Menu.SubViews
{
	// Token: 0x020057A0 RID: 22432
	[NullableContext(1)]
	[Nullable(0)]
	public class SetItemData : ISetItemData
	{
		// Token: 0x1700919F RID: 37279
		// (get) Token: 0x060390A3 RID: 233635 RVA: 0x00E74786 File Offset: 0x00E72986
		// (set) Token: 0x060390A4 RID: 233636 RVA: 0x00E7478E File Offset: 0x00E7298E
		public int Index { get; set; }

		// Token: 0x170091A0 RID: 37280
		// (get) Token: 0x060390A5 RID: 233637 RVA: 0x00E74797 File Offset: 0x00E72997
		// (set) Token: 0x060390A6 RID: 233638 RVA: 0x00E7479F File Offset: 0x00E7299F
		public int Value { get; set; }

		// Token: 0x170091A1 RID: 37281
		// (get) Token: 0x060390A7 RID: 233639 RVA: 0x00E747A8 File Offset: 0x00E729A8
		// (set) Token: 0x060390A8 RID: 233640 RVA: 0x00E747B0 File Offset: 0x00E729B0
		public string Name { get; set; } = "";
	}
}
