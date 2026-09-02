using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.CiacconaGal
{
	// Token: 0x02005ECE RID: 24270
	[NullableContext(1)]
	[Nullable(0)]
	public class CiacconaGalChapterRestartChoiceParam : ICiacconaGalChapterRestartChoiceParam
	{
		// Token: 0x170099EA RID: 39402
		// (get) Token: 0x0603CFE9 RID: 249833 RVA: 0x00F7DCAB File Offset: 0x00F7BEAB
		// (set) Token: 0x0603CFEA RID: 249834 RVA: 0x00F7DCB3 File Offset: 0x00F7BEB3
		public ECiacconaGalChapterRestartChoiceType Type { get; set; }

		// Token: 0x170099EB RID: 39403
		// (get) Token: 0x0603CFEB RID: 249835 RVA: 0x00F7DCBC File Offset: 0x00F7BEBC
		// (set) Token: 0x0603CFEC RID: 249836 RVA: 0x00F7DCC4 File Offset: 0x00F7BEC4
		public string Desc { get; set; }

		// Token: 0x170099EC RID: 39404
		// (get) Token: 0x0603CFED RID: 249837 RVA: 0x00F7DCCD File Offset: 0x00F7BECD
		// (set) Token: 0x0603CFEE RID: 249838 RVA: 0x00F7DCD5 File Offset: 0x00F7BED5
		public CiacconaGalChapterData ChapterData { get; set; }
	}
}
