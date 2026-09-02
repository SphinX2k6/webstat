using System;
using System.Runtime.CompilerServices;

// Token: 0x020014D6 RID: 5334
[NullableContext(1)]
[Nullable(0)]
internal class PinballBattleBossSkillTipsControllerParam : IPinballBattleBossSkillTipsParam, IPinballBattleTipsBaseParam
{
	// Token: 0x17000CB4 RID: 3252
	// (get) Token: 0x06009514 RID: 38164 RVA: 0x002706A0 File Offset: 0x0026E8A0
	// (set) Token: 0x06009515 RID: 38165 RVA: 0x002706A8 File Offset: 0x0026E8A8
	public string TextId { get; set; } = "";

	// Token: 0x17000CB5 RID: 3253
	// (get) Token: 0x06009516 RID: 38166 RVA: 0x002706B1 File Offset: 0x0026E8B1
	// (set) Token: 0x06009517 RID: 38167 RVA: 0x002706B9 File Offset: 0x0026E8B9
	[Nullable(2)]
	public Action CloseCallback { [NullableContext(2)] get; [NullableContext(2)] set; }

	// Token: 0x17000CB6 RID: 3254
	// (get) Token: 0x06009518 RID: 38168 RVA: 0x002706C2 File Offset: 0x0026E8C2
	// (set) Token: 0x06009519 RID: 38169 RVA: 0x002706CA File Offset: 0x0026E8CA
	public bool? AddMask { get; set; }

	// Token: 0x17000CB7 RID: 3255
	// (get) Token: 0x0600951A RID: 38170 RVA: 0x002706D3 File Offset: 0x0026E8D3
	// (set) Token: 0x0600951B RID: 38171 RVA: 0x002706DB File Offset: 0x0026E8DB
	public int? CloseTime { get; set; }

	// Token: 0x17000CB8 RID: 3256
	// (get) Token: 0x0600951C RID: 38172 RVA: 0x002706E4 File Offset: 0x0026E8E4
	// (set) Token: 0x0600951D RID: 38173 RVA: 0x002706EC File Offset: 0x0026E8EC
	public bool? MoveToBehind { get; set; }
}
