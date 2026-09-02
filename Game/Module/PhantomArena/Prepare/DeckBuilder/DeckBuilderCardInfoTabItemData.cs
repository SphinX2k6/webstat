using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.DeckBuilder
{
	// Token: 0x020054EF RID: 21743
	public class DeckBuilderCardInfoTabItemData
	{
		// Token: 0x0401FCEF RID: 130287
		public int TabIndex;

		// Token: 0x0401FCF0 RID: 130288
		[Nullable(1)]
		public string TabNameTextId = string.Empty;

		// Token: 0x0401FCF1 RID: 130289
		[Nullable(2)]
		public Action<int> OnSelect;
	}
}
