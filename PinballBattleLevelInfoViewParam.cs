using System;
using System.Runtime.CompilerServices;

// Token: 0x020014E1 RID: 5345
[NullableContext(1)]
[Nullable(0)]
public class PinballBattleLevelInfoViewParam : IPinballBattleLevelInfoViewParam
{
	// Token: 0x17000CE6 RID: 3302
	// (get) Token: 0x06009583 RID: 38275 RVA: 0x00270A55 File Offset: 0x0026EC55
	// (set) Token: 0x06009584 RID: 38276 RVA: 0x00270A5D File Offset: 0x0026EC5D
	public int LevelId { get; set; }

	// Token: 0x17000CE7 RID: 3303
	// (get) Token: 0x06009585 RID: 38277 RVA: 0x00270A66 File Offset: 0x0026EC66
	// (set) Token: 0x06009586 RID: 38278 RVA: 0x00270A6E File Offset: 0x0026EC6E
	public EPinballLevelShowType LevelType { get; set; }

	// Token: 0x17000CE8 RID: 3304
	// (get) Token: 0x06009587 RID: 38279 RVA: 0x00270A77 File Offset: 0x0026EC77
	// (set) Token: 0x06009588 RID: 38280 RVA: 0x00270A7F File Offset: 0x0026EC7F
	public int Score { get; set; }

	// Token: 0x17000CE9 RID: 3305
	// (get) Token: 0x06009589 RID: 38281 RVA: 0x00270A88 File Offset: 0x0026EC88
	// (set) Token: 0x0600958A RID: 38282 RVA: 0x00270A90 File Offset: 0x0026EC90
	public int[] StarInfo { get; set; }
}
