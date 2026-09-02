using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Card
{
	// Token: 0x0200561E RID: 22046
	[NullableContext(1)]
	public interface IPhantomCardDragProxy : IPhantomCardProxyBase
	{
		// Token: 0x060382EB RID: 230123
		void PointerBeginDrag(int id, ULGUIPointerEventData eventData);

		// Token: 0x060382EC RID: 230124
		void PointerDragCard(int id, ULGUIPointerEventData eventData);

		// Token: 0x060382ED RID: 230125
		void PointerEndDrag(int id, ULGUIPointerEventData eventData);
	}
}
