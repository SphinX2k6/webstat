using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Battle.View;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Card.Logic
{
	// Token: 0x02005627 RID: 22055
	public class PhantomArenaLogicFactory
	{
		// Token: 0x06038359 RID: 230233 RVA: 0x00E3B798 File Offset: 0x00E39998
		[NullableContext(1)]
		public static PhantomArenaCardLogic CreateLogic(PhantomArenaCard card, EPhantomArenaCardType type, PhantomArenaBattleProxy viewProxy)
		{
			if (type == EPhantomArenaCardType.Normal)
			{
				return new PhantomArenaNormalLogic(card, viewProxy);
			}
			if (type == EPhantomArenaCardType.Field)
			{
				return new PhantomArenaFieldLogic(card, viewProxy);
			}
			if (type == EPhantomArenaCardType.Tool)
			{
				return new PhantomArenaToolLogic(card, viewProxy);
			}
			return new PhantomArenaNormalLogic(card, viewProxy);
		}
	}
}
