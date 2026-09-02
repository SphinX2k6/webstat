using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.SceneItem.Common.Component;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem.PathDrivenActorSpawner
{
	// Token: 0x02004837 RID: 18487
	[NullableContext(1)]
	public interface IPathDrivenSplineRuntimeData
	{
		// Token: 0x17008248 RID: 33352
		// (get) Token: 0x060301B4 RID: 197044
		// (set) Token: 0x060301B5 RID: 197045
		int SplineEntityId { get; set; }

		// Token: 0x17008249 RID: 33353
		// (get) Token: 0x060301B6 RID: 197046
		// (set) Token: 0x060301B7 RID: 197047
		USplineComponent SplineComponent { get; set; }

		// Token: 0x1700824A RID: 33354
		// (get) Token: 0x060301B8 RID: 197048
		// (set) Token: 0x060301B9 RID: 197049
		SceneItemMoveComponent.SceneItemSplineMoveAtConstantTimeParam MoveParamTemplate { get; set; }
	}
}
