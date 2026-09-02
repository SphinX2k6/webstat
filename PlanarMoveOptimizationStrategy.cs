using System;
using System.Runtime.CompilerServices;

// Token: 0x0200323D RID: 12861
public class PlanarMoveOptimizationStrategy : BaseOptimizationStrategy
{
	// Token: 0x0601AC53 RID: 109651 RVA: 0x007FA868 File Offset: 0x007F8A68
	[NullableContext(1)]
	protected override void OnEntityInOutRangeLocal(bool isEnter, EntityHandle handle)
	{
		if (handle == null || !handle.Valid)
		{
			return;
		}
		CharacterMoveComponent component = handle.Entity.GetComponent<CharacterMoveComponent>();
		if (component == null || !component.Valid)
		{
			return;
		}
		component.SetKuroPlanarPhysWalking(isEnter);
		component.SetKuroAsyncRootMotion(isEnter);
	}
}
