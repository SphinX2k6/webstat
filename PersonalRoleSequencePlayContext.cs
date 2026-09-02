using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Scene.NewGacha.BP;
using UnrealEngine;

// Token: 0x02002415 RID: 9237
[NullableContext(1)]
[Nullable(0)]
public class PersonalRoleSequencePlayContext : IPersonalRoleSequencePlayContext
{
	// Token: 0x1700168E RID: 5774
	// (get) Token: 0x06011DE9 RID: 73193 RVA: 0x004EA1EC File Offset: 0x004E83EC
	// (set) Token: 0x06011DEA RID: 73194 RVA: 0x004EA1F4 File Offset: 0x004E83F4
	public int RoleConfigId { get; set; }

	// Token: 0x1700168F RID: 5775
	// (get) Token: 0x06011DEB RID: 73195 RVA: 0x004EA1FD File Offset: 0x004E83FD
	// (set) Token: 0x06011DEC RID: 73196 RVA: 0x004EA205 File Offset: 0x004E8405
	public ALevelSequenceActor SequenceActor { get; set; }

	// Token: 0x17001690 RID: 5776
	// (get) Token: 0x06011DED RID: 73197 RVA: 0x004EA20E File Offset: 0x004E840E
	// (set) Token: 0x06011DEE RID: 73198 RVA: 0x004EA216 File Offset: 0x004E8416
	public AActor SceneSequenceCamera { get; set; }

	// Token: 0x17001691 RID: 5777
	// (get) Token: 0x06011DEF RID: 73199 RVA: 0x004EA21F File Offset: 0x004E841F
	// (set) Token: 0x06011DF0 RID: 73200 RVA: 0x004EA227 File Offset: 0x004E8427
	public BP_UpdateInteract_C UpdateInteractBp { get; set; }
}
