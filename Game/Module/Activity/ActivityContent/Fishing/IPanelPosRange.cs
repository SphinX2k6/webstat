using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x020067FB RID: 26619
	public interface IPanelPosRange
	{
		// Token: 0x1700A13F RID: 41279
		// (get) Token: 0x060425C6 RID: 271814
		// (set) Token: 0x060425C7 RID: 271815
		int RowStartIndex { get; set; }

		// Token: 0x1700A140 RID: 41280
		// (get) Token: 0x060425C8 RID: 271816
		// (set) Token: 0x060425C9 RID: 271817
		int RowEndIndex { get; set; }

		// Token: 0x1700A141 RID: 41281
		// (get) Token: 0x060425CA RID: 271818
		// (set) Token: 0x060425CB RID: 271819
		int ColStartIndex { get; set; }

		// Token: 0x1700A142 RID: 41282
		// (get) Token: 0x060425CC RID: 271820
		// (set) Token: 0x060425CD RID: 271821
		int ColEndIndex { get; set; }
	}
}
