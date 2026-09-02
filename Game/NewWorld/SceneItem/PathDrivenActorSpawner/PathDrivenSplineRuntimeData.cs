using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.SceneItem.Common.Component;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem.PathDrivenActorSpawner
{
	// Token: 0x02004838 RID: 18488
	[NullableContext(1)]
	[Nullable(0)]
	public class PathDrivenSplineRuntimeData : IPathDrivenSplineRuntimeData
	{
		// Token: 0x1700824B RID: 33355
		// (get) Token: 0x060301BA RID: 197050 RVA: 0x00BABB73 File Offset: 0x00BA9D73
		// (set) Token: 0x060301BB RID: 197051 RVA: 0x00BABB7B File Offset: 0x00BA9D7B
		public int SplineEntityId { get; set; }

		// Token: 0x1700824C RID: 33356
		// (get) Token: 0x060301BC RID: 197052 RVA: 0x00BABB84 File Offset: 0x00BA9D84
		// (set) Token: 0x060301BD RID: 197053 RVA: 0x00BABB8C File Offset: 0x00BA9D8C
		public USplineComponent SplineComponent { get; set; }

		// Token: 0x1700824D RID: 33357
		// (get) Token: 0x060301BE RID: 197054 RVA: 0x00BABB95 File Offset: 0x00BA9D95
		// (set) Token: 0x060301BF RID: 197055 RVA: 0x00BABB9D File Offset: 0x00BA9D9D
		public SceneItemMoveComponent.SceneItemSplineMoveAtConstantTimeParam MoveParamTemplate { get; set; }
	}
}
