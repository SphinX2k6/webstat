using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Card
{
	// Token: 0x0200561D RID: 22045
	public interface IPhantomCardProxy : IPhantomCardProxyBase
	{
		// Token: 0x060382E8 RID: 230120
		void PointerClickCard(int id, EToggleState state);

		// Token: 0x060382E9 RID: 230121
		void PointerEnterCard(int id);

		// Token: 0x060382EA RID: 230122
		[NullableContext(1)]
		void PointerDownCard(int id, ULGUIPointerEventData eventData);
	}
}
