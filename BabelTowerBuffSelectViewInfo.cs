using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020011ED RID: 4589
[NullableContext(1)]
[Nullable(0)]
public class BabelTowerBuffSelectViewInfo : IBabelTowerBuffSelectViewInfo
{
	// Token: 0x17000A49 RID: 2633
	// (get) Token: 0x06007969 RID: 31081 RVA: 0x001FCE1E File Offset: 0x001FB01E
	// (set) Token: 0x0600796A RID: 31082 RVA: 0x001FCE26 File Offset: 0x001FB026
	public int LevelId { get; set; }

	// Token: 0x17000A4A RID: 2634
	// (get) Token: 0x0600796B RID: 31083 RVA: 0x001FCE2F File Offset: 0x001FB02F
	// (set) Token: 0x0600796C RID: 31084 RVA: 0x001FCE37 File Offset: 0x001FB037
	public int MaxSelectBuffCount { get; set; }

	// Token: 0x17000A4B RID: 2635
	// (get) Token: 0x0600796D RID: 31085 RVA: 0x001FCE40 File Offset: 0x001FB040
	// (set) Token: 0x0600796E RID: 31086 RVA: 0x001FCE48 File Offset: 0x001FB048
	public List<int> CurrentSelectBuffList { get; set; }

	// Token: 0x17000A4C RID: 2636
	// (get) Token: 0x0600796F RID: 31087 RVA: 0x001FCE51 File Offset: 0x001FB051
	// (set) Token: 0x06007970 RID: 31088 RVA: 0x001FCE59 File Offset: 0x001FB059
	public int ShowBuffId { get; set; }

	// Token: 0x17000A4D RID: 2637
	// (get) Token: 0x06007971 RID: 31089 RVA: 0x001FCE62 File Offset: 0x001FB062
	// (set) Token: 0x06007972 RID: 31090 RVA: 0x001FCE6A File Offset: 0x001FB06A
	public List<IBabelTowerBuffInfo> AllBuffList { get; set; }

	// Token: 0x17000A4E RID: 2638
	// (get) Token: 0x06007973 RID: 31091 RVA: 0x001FCE73 File Offset: 0x001FB073
	// (set) Token: 0x06007974 RID: 31092 RVA: 0x001FCE7B File Offset: 0x001FB07B
	public Action<List<int>> OnConfirmCallBack { get; set; }
}
