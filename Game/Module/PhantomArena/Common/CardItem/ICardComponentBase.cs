using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardItem
{
	// Token: 0x02005529 RID: 21801
	[NullableContext(1)]
	public interface ICardComponentBase
	{
		// Token: 0x060379D4 RID: 227796
		UniTask CreateByActorAsync(AActor actor, [Nullable(2)] object parameters = null, bool usePool = false);

		// Token: 0x060379D5 RID: 227797
		UniTask CreateByResourceIdAsync(string resourceId, [Nullable(2)] UUIItem parentItem = null, bool usePool = false);
	}
}
