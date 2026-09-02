using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardItem
{
	// Token: 0x0200552A RID: 21802
	public abstract class CardComponentBase<[Nullable(2)] TData> : UiPanelBase, ICardComponentBase
	{
		// Token: 0x060379D6 RID: 227798
		[NullableContext(1)]
		public abstract void Refresh(TData data);
	}
}
