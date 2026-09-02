using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.DeckBuilder
{
	// Token: 0x020054E9 RID: 21737
	[NullableContext(1)]
	[Nullable(0)]
	public class DeckBuilderCardDeleteViewData : IDeckBuilderCardDeleteViewData
	{
		// Token: 0x17008EBA RID: 36538
		// (get) Token: 0x0603764B RID: 226891 RVA: 0x00E0E42D File Offset: 0x00E0C62D
		// (set) Token: 0x0603764C RID: 226892 RVA: 0x00E0E435 File Offset: 0x00E0C635
		public HashSet<ECardElement> EnabledElementSet { get; set; }

		// Token: 0x17008EBB RID: 36539
		// (get) Token: 0x0603764D RID: 226893 RVA: 0x00E0E43E File Offset: 0x00E0C63E
		// (set) Token: 0x0603764E RID: 226894 RVA: 0x00E0E446 File Offset: 0x00E0C646
		public Action<HashSet<ECardElement>> DeleteFunc { get; set; }
	}
}
