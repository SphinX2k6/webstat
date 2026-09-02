using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.DeckBuilder
{
	// Token: 0x020054F2 RID: 21746
	[NullableContext(2)]
	[Nullable(0)]
	public class TabData
	{
		// Token: 0x0401FCF3 RID: 130291
		public int TabIndex;

		// Token: 0x0401FCF4 RID: 130292
		[Nullable(1)]
		public string TabNameTextId = string.Empty;

		// Token: 0x0401FCF5 RID: 130293
		public UiPanelBase Panel;

		// Token: 0x0401FCF6 RID: 130294
		public IDeckBuilderCardInfoViewPanelSequencePlayer SequencePlayer;

		// Token: 0x0401FCF7 RID: 130295
		public Action OnShow;
	}
}
