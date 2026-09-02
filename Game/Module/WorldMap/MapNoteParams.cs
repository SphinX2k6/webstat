using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.WorldMap
{
	// Token: 0x02004B2B RID: 19243
	[NullableContext(1)]
	[Nullable(0)]
	public class MapNoteParams : IMapNoteParams
	{
		// Token: 0x170085FB RID: 34299
		// (get) Token: 0x0603237E RID: 205694 RVA: 0x00C8FA74 File Offset: 0x00C8DC74
		// (set) Token: 0x0603237F RID: 205695 RVA: 0x00C8FA7C File Offset: 0x00C8DC7C
		public EMapNoteId MapNoteId { get; set; }

		// Token: 0x170085FC RID: 34300
		// (get) Token: 0x06032380 RID: 205696 RVA: 0x00C8FA85 File Offset: 0x00C8DC85
		// (set) Token: 0x06032381 RID: 205697 RVA: 0x00C8FA8D File Offset: 0x00C8DC8D
		public Action<int> ClickCallBack { get; set; }

		// Token: 0x170085FD RID: 34301
		// (get) Token: 0x06032382 RID: 205698 RVA: 0x00C8FA96 File Offset: 0x00C8DC96
		// (set) Token: 0x06032383 RID: 205699 RVA: 0x00C8FA9E File Offset: 0x00C8DC9E
		public MapNote MapNoteConfig { get; set; }

		// Token: 0x170085FE RID: 34302
		// (get) Token: 0x06032384 RID: 205700 RVA: 0x00C8FAA7 File Offset: 0x00C8DCA7
		// (set) Token: 0x06032385 RID: 205701 RVA: 0x00C8FAAF File Offset: 0x00C8DCAF
		public int? MapMarkId { get; set; }

		// Token: 0x170085FF RID: 34303
		// (get) Token: 0x06032386 RID: 205702 RVA: 0x00C8FAB8 File Offset: 0x00C8DCB8
		// (set) Token: 0x06032387 RID: 205703 RVA: 0x00C8FAC0 File Offset: 0x00C8DCC0
		[Nullable(2)]
		public string CustomDesc { [NullableContext(2)] get; [NullableContext(2)] set; }
	}
}
