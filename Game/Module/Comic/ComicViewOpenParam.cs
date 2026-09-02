using System;

namespace CSharpScript.Game.Module.Comic
{
	// Token: 0x02005E8B RID: 24203
	public class ComicViewOpenParam : IComicViewOpenParam
	{
		// Token: 0x17009973 RID: 39283
		// (get) Token: 0x0603CDC3 RID: 249283 RVA: 0x00F72688 File Offset: 0x00F70888
		// (set) Token: 0x0603CDC4 RID: 249284 RVA: 0x00F72690 File Offset: 0x00F70890
		public int ComicId { get; set; }

		// Token: 0x17009974 RID: 39284
		// (get) Token: 0x0603CDC5 RID: 249285 RVA: 0x00F72699 File Offset: 0x00F70899
		// (set) Token: 0x0603CDC6 RID: 249286 RVA: 0x00F726A1 File Offset: 0x00F708A1
		public bool? FadeBeforeHide { get; set; }
	}
}
