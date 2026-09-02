using System;

namespace CSharpScript.Game.Module.Comic
{
	// Token: 0x02005E89 RID: 24201
	public interface IComicViewOpenParam
	{
		// Token: 0x1700996E RID: 39278
		// (get) Token: 0x0603CDB8 RID: 249272
		// (set) Token: 0x0603CDB9 RID: 249273
		int ComicId { get; set; }

		// Token: 0x1700996F RID: 39279
		// (get) Token: 0x0603CDBA RID: 249274
		// (set) Token: 0x0603CDBB RID: 249275
		bool? FadeBeforeHide { get; set; }
	}
}
