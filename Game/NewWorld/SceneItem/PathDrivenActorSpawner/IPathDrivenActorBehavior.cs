using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.SceneItem.PathDrivenActorSpawner
{
	// Token: 0x02004839 RID: 18489
	[NullableContext(1)]
	public interface IPathDrivenActorBehavior
	{
		// Token: 0x060301C1 RID: 197057
		bool Initialize(IPathDrivenActorRuntimeData runtimeData);

		// Token: 0x060301C2 RID: 197058
		void PrepareCollisionBeforeSpawn(IPathDrivenActorRuntimeData runtimeData);

		// Token: 0x060301C3 RID: 197059
		void RestoreCollisionAfterSpawn(IPathDrivenActorRuntimeData runtimeData);

		// Token: 0x060301C4 RID: 197060
		void ClearCollisionBeforeRecycle(IPathDrivenActorRuntimeData runtimeData);

		// Token: 0x060301C5 RID: 197061
		void Tick(IPathDrivenActorRuntimeData runtimeData, float deltaSeconds);

		// Token: 0x060301C6 RID: 197062
		void OnFinishing(IPathDrivenActorRuntimeData runtimeData, EPathDrivenActorFinishReason reason);

		// Token: 0x060301C7 RID: 197063
		void Cleanup(IPathDrivenActorRuntimeData runtimeData);
	}
}
