using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardItem.Component
{
	// Token: 0x02005543 RID: 21827
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class CardAllInDeckComponent : CardComponentBase<ICardAllInDeckComponentData>
	{
		// Token: 0x06037A56 RID: 227926 RVA: 0x00E1E0EE File Offset: 0x00E1C2EE
		public override void Refresh(ICardAllInDeckComponentData data)
		{
			this.SetActive(data.IsAllInDeck && data.ShowComponent);
		}
	}
}
