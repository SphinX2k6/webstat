using System;
using System.Runtime.CompilerServices;

// Token: 0x02001998 RID: 6552
[NullableContext(1)]
[Nullable(0)]
public class ButtonInfo : IButtonInfo
{
	// Token: 0x17000F55 RID: 3925
	// (get) Token: 0x0600BC1C RID: 48156 RVA: 0x0031F113 File Offset: 0x0031D313
	// (set) Token: 0x0600BC1D RID: 48157 RVA: 0x0031F11B File Offset: 0x0031D31B
	public Action<int> Function { get; set; }

	// Token: 0x17000F56 RID: 3926
	// (get) Token: 0x0600BC1E RID: 48158 RVA: 0x0031F124 File Offset: 0x0031D324
	// (set) Token: 0x0600BC1F RID: 48159 RVA: 0x0031F12C File Offset: 0x0031D32C
	public string Text { get; set; }

	// Token: 0x17000F57 RID: 3927
	// (get) Token: 0x0600BC20 RID: 48160 RVA: 0x0031F135 File Offset: 0x0031D335
	// (set) Token: 0x0600BC21 RID: 48161 RVA: 0x0031F13D File Offset: 0x0031D33D
	public int Index { get; set; }

	// Token: 0x17000F58 RID: 3928
	// (get) Token: 0x0600BC22 RID: 48162 RVA: 0x0031F146 File Offset: 0x0031D346
	// (set) Token: 0x0600BC23 RID: 48163 RVA: 0x0031F14E File Offset: 0x0031D34E
	public ERedDotName? RedDotName { get; set; }

	// Token: 0x17000F59 RID: 3929
	// (get) Token: 0x0600BC24 RID: 48164 RVA: 0x0031F157 File Offset: 0x0031D357
	// (set) Token: 0x0600BC25 RID: 48165 RVA: 0x0031F15F File Offset: 0x0031D35F
	public int? RedDotId { get; set; }
}
