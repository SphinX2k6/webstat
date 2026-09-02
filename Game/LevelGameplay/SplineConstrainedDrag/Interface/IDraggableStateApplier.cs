using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.LevelGamePlay.SplineConstrainedDrag.Define;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.SplineConstrainedDrag.Interface
{
	// Token: 0x02006AE1 RID: 27361
	[NullableContext(1)]
	public interface IDraggableStateApplier
	{
		// Token: 0x06043A64 RID: 277092
		void Initialize(AActor actor);

		// Token: 0x06043A65 RID: 277093
		void ApplyState(AActor actor, EDraggableState state);

		// Token: 0x06043A66 RID: 277094
		void Dispose(AActor actor);
	}
}
