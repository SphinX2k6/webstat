using System;
using System.Runtime.CompilerServices;

// Token: 0x020032D1 RID: 13009
[NullableContext(1)]
[Nullable(0)]
public class RedDotEventData
{
	// Token: 0x17002537 RID: 9527
	// (get) Token: 0x0601B4A6 RID: 111782 RVA: 0x00832F57 File Offset: 0x00831157
	// (set) Token: 0x0601B4A7 RID: 111783 RVA: 0x00832F5F File Offset: 0x0083115F
	public TRedDotCheckEvent Event { get; set; }

	// Token: 0x17002538 RID: 9528
	// (get) Token: 0x0601B4A8 RID: 111784 RVA: 0x00832F68 File Offset: 0x00831168
	// (set) Token: 0x0601B4A9 RID: 111785 RVA: 0x00832F70 File Offset: 0x00831170
	public int Id { get; set; }

	// Token: 0x17002539 RID: 9529
	// (get) Token: 0x0601B4AA RID: 111786 RVA: 0x00832F79 File Offset: 0x00831179
	// (set) Token: 0x0601B4AB RID: 111787 RVA: 0x00832F81 File Offset: 0x00831181
	public string RedDotName { get; set; }

	// Token: 0x0601B4AC RID: 111788 RVA: 0x00832F8A File Offset: 0x0083118A
	public RedDotEventData(TRedDotCheckEvent @event, int id, string redDotName)
	{
		this.Event = @event;
		this.Id = id;
		this.RedDotName = redDotName;
	}

	// Token: 0x0601B4AD RID: 111789 RVA: 0x00832FA7 File Offset: 0x008311A7
	public void HandleEvent()
	{
		this.Event(this.Id);
	}
}
