using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.Util
{
	// Token: 0x02004C70 RID: 19568
	[NullableContext(1)]
	public interface IDynamicScrollBaseItem<[Nullable(2)] TData>
	{
		// Token: 0x06032FA5 RID: 208805
		FVector2D GetItemSize(TData data);

		// Token: 0x06032FA6 RID: 208806
		UniTask Init(UUIItem actor);

		// Token: 0x06032FA7 RID: 208807
		void ClearItem();
	}
}
