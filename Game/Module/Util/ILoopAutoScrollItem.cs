using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.Util
{
	// Token: 0x02004C74 RID: 19572
	[NullableContext(1)]
	public interface ILoopAutoScrollItem<[Nullable(2)] in TData>
	{
		// Token: 0x0603300E RID: 208910 RVA: 0x00CC62E9 File Offset: 0x00CC44E9
		void Refresh(TData data)
		{
		}

		// Token: 0x0603300F RID: 208911 RVA: 0x00CC62EB File Offset: 0x00CC44EB
		UniTask RefreshAsync(TData data)
		{
			return UniTask.CompletedTask;
		}

		// Token: 0x06033010 RID: 208912
		UniTask CreateByActorAsync(AActor actor);

		// Token: 0x06033011 RID: 208913
		UUIItem GetRootItem();
	}
}
