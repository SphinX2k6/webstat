using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Scene.NewGacha.BP;
using UnrealEngine;

// Token: 0x02002414 RID: 9236
[NullableContext(1)]
public interface IPersonalRoleSequencePlayContext
{
	// Token: 0x1700168A RID: 5770
	// (get) Token: 0x06011DE1 RID: 73185
	// (set) Token: 0x06011DE2 RID: 73186
	int RoleConfigId { get; set; }

	// Token: 0x1700168B RID: 5771
	// (get) Token: 0x06011DE3 RID: 73187
	// (set) Token: 0x06011DE4 RID: 73188
	ALevelSequenceActor SequenceActor { get; set; }

	// Token: 0x1700168C RID: 5772
	// (get) Token: 0x06011DE5 RID: 73189
	// (set) Token: 0x06011DE6 RID: 73190
	AActor SceneSequenceCamera { get; set; }

	// Token: 0x1700168D RID: 5773
	// (get) Token: 0x06011DE7 RID: 73191
	// (set) Token: 0x06011DE8 RID: 73192
	BP_UpdateInteract_C UpdateInteractBp { get; set; }
}
