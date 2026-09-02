using System;
using System.Runtime.CompilerServices;

// Token: 0x020021EC RID: 8684
[NullableContext(1)]
[Nullable(0)]
public class ButtonPreset : IButtonPreset
{
	// Token: 0x17001432 RID: 5170
	// (get) Token: 0x06010605 RID: 67077 RVA: 0x00479E8F File Offset: 0x0047808F
	// (set) Token: 0x06010606 RID: 67078 RVA: 0x00479E97 File Offset: 0x00478097
	public string Title { get; set; }

	// Token: 0x17001433 RID: 5171
	// (get) Token: 0x06010607 RID: 67079 RVA: 0x00479EA0 File Offset: 0x004780A0
	// (set) Token: 0x06010608 RID: 67080 RVA: 0x00479EA8 File Offset: 0x004780A8
	public Action ClickFunc { get; set; }
}
