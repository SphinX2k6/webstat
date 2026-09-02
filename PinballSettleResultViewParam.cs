using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020014D0 RID: 5328
[NullableContext(1)]
[Nullable(0)]
public class PinballSettleResultViewParam : IPinballSettleResultViewParam
{
	// Token: 0x17000C9B RID: 3227
	// (get) Token: 0x060094DC RID: 38108 RVA: 0x002704B1 File Offset: 0x0026E6B1
	// (set) Token: 0x060094DD RID: 38109 RVA: 0x002704B9 File Offset: 0x0026E6B9
	public int LevelId { get; set; }

	// Token: 0x17000C9C RID: 3228
	// (get) Token: 0x060094DE RID: 38110 RVA: 0x002704C2 File Offset: 0x0026E6C2
	// (set) Token: 0x060094DF RID: 38111 RVA: 0x002704CA File Offset: 0x0026E6CA
	public EPinballLevelShowType LevelType { get; set; }

	// Token: 0x17000C9D RID: 3229
	// (get) Token: 0x060094E0 RID: 38112 RVA: 0x002704D3 File Offset: 0x0026E6D3
	// (set) Token: 0x060094E1 RID: 38113 RVA: 0x002704DB File Offset: 0x0026E6DB
	public bool IsWin { get; set; }

	// Token: 0x17000C9E RID: 3230
	// (get) Token: 0x060094E2 RID: 38114 RVA: 0x002704E4 File Offset: 0x0026E6E4
	// (set) Token: 0x060094E3 RID: 38115 RVA: 0x002704EC File Offset: 0x0026E6EC
	public int MostValuablePlayerRoleId { get; set; }

	// Token: 0x17000C9F RID: 3231
	// (get) Token: 0x060094E4 RID: 38116 RVA: 0x002704F5 File Offset: 0x0026E6F5
	// (set) Token: 0x060094E5 RID: 38117 RVA: 0x002704FD File Offset: 0x0026E6FD
	public Dictionary<int, float> Roles { get; set; } = new Dictionary<int, float>();

	// Token: 0x17000CA0 RID: 3232
	// (get) Token: 0x060094E6 RID: 38118 RVA: 0x00270506 File Offset: 0x0026E706
	// (set) Token: 0x060094E7 RID: 38119 RVA: 0x0027050E File Offset: 0x0026E70E
	public bool[] StarInfo { get; set; } = Array.Empty<bool>();

	// Token: 0x17000CA1 RID: 3233
	// (get) Token: 0x060094E8 RID: 38120 RVA: 0x00270517 File Offset: 0x0026E717
	// (set) Token: 0x060094E9 RID: 38121 RVA: 0x0027051F File Offset: 0x0026E71F
	public int Score { get; set; }

	// Token: 0x17000CA2 RID: 3234
	// (get) Token: 0x060094EA RID: 38122 RVA: 0x00270528 File Offset: 0x0026E728
	// (set) Token: 0x060094EB RID: 38123 RVA: 0x00270530 File Offset: 0x0026E730
	public bool IsFirstPass { get; set; }
}
