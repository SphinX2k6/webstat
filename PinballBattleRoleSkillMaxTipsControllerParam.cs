using System;
using System.Runtime.CompilerServices;

// Token: 0x020014D7 RID: 5335
[NullableContext(2)]
[Nullable(0)]
internal class PinballBattleRoleSkillMaxTipsControllerParam : IPinballBattleRoleSkillMaxTipsParam, IPinballBattleTipsBaseParam
{
	// Token: 0x17000CB9 RID: 3257
	// (get) Token: 0x0600951F RID: 38175 RVA: 0x00270708 File Offset: 0x0026E908
	// (set) Token: 0x06009520 RID: 38176 RVA: 0x00270710 File Offset: 0x0026E910
	public int RoleId { get; set; }

	// Token: 0x17000CBA RID: 3258
	// (get) Token: 0x06009521 RID: 38177 RVA: 0x00270719 File Offset: 0x0026E919
	// (set) Token: 0x06009522 RID: 38178 RVA: 0x00270721 File Offset: 0x0026E921
	public Action CloseCallback { get; set; }

	// Token: 0x17000CBB RID: 3259
	// (get) Token: 0x06009523 RID: 38179 RVA: 0x0027072A File Offset: 0x0026E92A
	// (set) Token: 0x06009524 RID: 38180 RVA: 0x00270732 File Offset: 0x0026E932
	public bool? AddMask { get; set; }

	// Token: 0x17000CBC RID: 3260
	// (get) Token: 0x06009525 RID: 38181 RVA: 0x0027073B File Offset: 0x0026E93B
	// (set) Token: 0x06009526 RID: 38182 RVA: 0x00270743 File Offset: 0x0026E943
	public int? CloseTime { get; set; }

	// Token: 0x17000CBD RID: 3261
	// (get) Token: 0x06009527 RID: 38183 RVA: 0x0027074C File Offset: 0x0026E94C
	// (set) Token: 0x06009528 RID: 38184 RVA: 0x00270754 File Offset: 0x0026E954
	public bool? MoveToBehind { get; set; }
}
