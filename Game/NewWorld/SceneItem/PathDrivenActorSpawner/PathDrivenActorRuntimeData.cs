using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem.PathDrivenActorSpawner
{
	// Token: 0x0200483B RID: 18491
	[NullableContext(1)]
	[Nullable(0)]
	public class PathDrivenActorRuntimeData : IPathDrivenActorRuntimeData
	{
		// Token: 0x17008256 RID: 33366
		// (get) Token: 0x060301D8 RID: 197080 RVA: 0x00BABBAE File Offset: 0x00BA9DAE
		// (set) Token: 0x060301D9 RID: 197081 RVA: 0x00BABBB6 File Offset: 0x00BA9DB6
		public Entity OwnerEntity { get; set; }

		// Token: 0x17008257 RID: 33367
		// (get) Token: 0x060301DA RID: 197082 RVA: 0x00BABBBF File Offset: 0x00BA9DBF
		// (set) Token: 0x060301DB RID: 197083 RVA: 0x00BABBC7 File Offset: 0x00BA9DC7
		public AActor Actor { get; set; }

		// Token: 0x17008258 RID: 33368
		// (get) Token: 0x060301DC RID: 197084 RVA: 0x00BABBD0 File Offset: 0x00BA9DD0
		// (set) Token: 0x060301DD RID: 197085 RVA: 0x00BABBD8 File Offset: 0x00BA9DD8
		public UKuroSceneItemMoveComponent MoveComponent { get; set; }

		// Token: 0x17008259 RID: 33369
		// (get) Token: 0x060301DE RID: 197086 RVA: 0x00BABBE1 File Offset: 0x00BA9DE1
		// (set) Token: 0x060301DF RID: 197087 RVA: 0x00BABBE9 File Offset: 0x00BA9DE9
		[Nullable(2)]
		public IPathDrivenActorBehavior Behavior { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x1700825A RID: 33370
		// (get) Token: 0x060301E0 RID: 197088 RVA: 0x00BABBF2 File Offset: 0x00BA9DF2
		// (set) Token: 0x060301E1 RID: 197089 RVA: 0x00BABBFA File Offset: 0x00BA9DFA
		public bool Finished { get; set; }

		// Token: 0x1700825B RID: 33371
		// (get) Token: 0x060301E2 RID: 197090 RVA: 0x00BABC03 File Offset: 0x00BA9E03
		// (set) Token: 0x060301E3 RID: 197091 RVA: 0x00BABC0B File Offset: 0x00BA9E0B
		public bool PendingRecycle { get; set; }

		// Token: 0x1700825C RID: 33372
		// (get) Token: 0x060301E4 RID: 197092 RVA: 0x00BABC14 File Offset: 0x00BA9E14
		// (set) Token: 0x060301E5 RID: 197093 RVA: 0x00BABC1C File Offset: 0x00BA9E1C
		public Action<EPathDrivenActorFinishReason> RequestFinish { get; set; }

		// Token: 0x1700825D RID: 33373
		// (get) Token: 0x060301E6 RID: 197094 RVA: 0x00BABC25 File Offset: 0x00BA9E25
		// (set) Token: 0x060301E7 RID: 197095 RVA: 0x00BABC2D File Offset: 0x00BA9E2D
		public Action OnMoveStoppedHandler { get; set; }
	}
}
