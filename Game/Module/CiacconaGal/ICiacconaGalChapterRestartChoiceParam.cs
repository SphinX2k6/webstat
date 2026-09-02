using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.CiacconaGal
{
	// Token: 0x02005ECD RID: 24269
	[NullableContext(1)]
	public interface ICiacconaGalChapterRestartChoiceParam
	{
		// Token: 0x170099E7 RID: 39399
		// (get) Token: 0x0603CFE3 RID: 249827
		// (set) Token: 0x0603CFE4 RID: 249828
		ECiacconaGalChapterRestartChoiceType Type { get; set; }

		// Token: 0x170099E8 RID: 39400
		// (get) Token: 0x0603CFE5 RID: 249829
		// (set) Token: 0x0603CFE6 RID: 249830
		string Desc { get; set; }

		// Token: 0x170099E9 RID: 39401
		// (get) Token: 0x0603CFE7 RID: 249831
		// (set) Token: 0x0603CFE8 RID: 249832
		CiacconaGalChapterData ChapterData { get; set; }
	}
}
