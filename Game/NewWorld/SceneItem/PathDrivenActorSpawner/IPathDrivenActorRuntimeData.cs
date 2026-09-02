using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem.PathDrivenActorSpawner
{
	// Token: 0x0200483A RID: 18490
	[NullableContext(1)]
	public interface IPathDrivenActorRuntimeData
	{
		// Token: 0x1700824E RID: 33358
		// (get) Token: 0x060301C8 RID: 197064
		// (set) Token: 0x060301C9 RID: 197065
		Entity OwnerEntity { get; set; }

		// Token: 0x1700824F RID: 33359
		// (get) Token: 0x060301CA RID: 197066
		// (set) Token: 0x060301CB RID: 197067
		AActor Actor { get; set; }

		// Token: 0x17008250 RID: 33360
		// (get) Token: 0x060301CC RID: 197068
		// (set) Token: 0x060301CD RID: 197069
		UKuroSceneItemMoveComponent MoveComponent { get; set; }

		// Token: 0x17008251 RID: 33361
		// (get) Token: 0x060301CE RID: 197070
		// (set) Token: 0x060301CF RID: 197071
		[Nullable(2)]
		IPathDrivenActorBehavior Behavior { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x17008252 RID: 33362
		// (get) Token: 0x060301D0 RID: 197072
		// (set) Token: 0x060301D1 RID: 197073
		bool Finished { get; set; }

		// Token: 0x17008253 RID: 33363
		// (get) Token: 0x060301D2 RID: 197074
		// (set) Token: 0x060301D3 RID: 197075
		bool PendingRecycle { get; set; }

		// Token: 0x17008254 RID: 33364
		// (get) Token: 0x060301D4 RID: 197076
		// (set) Token: 0x060301D5 RID: 197077
		Action<EPathDrivenActorFinishReason> RequestFinish { get; set; }

		// Token: 0x17008255 RID: 33365
		// (get) Token: 0x060301D6 RID: 197078
		// (set) Token: 0x060301D7 RID: 197079
		Action OnMoveStoppedHandler { get; set; }
	}
}
