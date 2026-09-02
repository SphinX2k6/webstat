using System;
using System.Runtime.CompilerServices;

// Token: 0x02002678 RID: 9848
[NullableContext(1)]
[Nullable(0)]
public class QuestReviewNodeParam : IQuestReviewNodeParam
{
	// Token: 0x1700183C RID: 6204
	// (get) Token: 0x060136B9 RID: 79545 RVA: 0x00569D56 File Offset: 0x00567F56
	// (set) Token: 0x060136BA RID: 79546 RVA: 0x00569D5E File Offset: 0x00567F5E
	[Nullable(2)]
	public QuestReviewNodeData Data { [NullableContext(2)] get; [NullableContext(2)] set; }

	// Token: 0x1700183D RID: 6205
	// (get) Token: 0x060136BB RID: 79547 RVA: 0x00569D67 File Offset: 0x00567F67
	// (set) Token: 0x060136BC RID: 79548 RVA: 0x00569D6F File Offset: 0x00567F6F
	public bool IsLastSlotEmpty { get; set; }

	// Token: 0x1700183E RID: 6206
	// (get) Token: 0x060136BD RID: 79549 RVA: 0x00569D78 File Offset: 0x00567F78
	// (set) Token: 0x060136BE RID: 79550 RVA: 0x00569D80 File Offset: 0x00567F80
	public bool IsDestroy { get; set; }

	// Token: 0x1700183F RID: 6207
	// (get) Token: 0x060136BF RID: 79551 RVA: 0x00569D89 File Offset: 0x00567F89
	// (set) Token: 0x060136C0 RID: 79552 RVA: 0x00569D91 File Offset: 0x00567F91
	public bool IsLastSlot { get; set; }

	// Token: 0x17001840 RID: 6208
	// (get) Token: 0x060136C1 RID: 79553 RVA: 0x00569D9A File Offset: 0x00567F9A
	// (set) Token: 0x060136C2 RID: 79554 RVA: 0x00569DA2 File Offset: 0x00567FA2
	public string LineColorHex { get; set; }

	// Token: 0x17001841 RID: 6209
	// (get) Token: 0x060136C3 RID: 79555 RVA: 0x00569DAB File Offset: 0x00567FAB
	// (set) Token: 0x060136C4 RID: 79556 RVA: 0x00569DB3 File Offset: 0x00567FB3
	public string StarIcon { get; set; }

	// Token: 0x17001842 RID: 6210
	// (get) Token: 0x060136C5 RID: 79557 RVA: 0x00569DBC File Offset: 0x00567FBC
	// (set) Token: 0x060136C6 RID: 79558 RVA: 0x00569DC4 File Offset: 0x00567FC4
	public string RoundIcon { get; set; }

	// Token: 0x17001843 RID: 6211
	// (get) Token: 0x060136C7 RID: 79559 RVA: 0x00569DCD File Offset: 0x00567FCD
	// (set) Token: 0x060136C8 RID: 79560 RVA: 0x00569DD5 File Offset: 0x00567FD5
	public int LineId { get; set; }

	// Token: 0x17001844 RID: 6212
	// (get) Token: 0x060136C9 RID: 79561 RVA: 0x00569DDE File Offset: 0x00567FDE
	// (set) Token: 0x060136CA RID: 79562 RVA: 0x00569DE6 File Offset: 0x00567FE6
	public bool ShouldHide { get; set; }

	// Token: 0x17001845 RID: 6213
	// (get) Token: 0x060136CB RID: 79563 RVA: 0x00569DEF File Offset: 0x00567FEF
	// (set) Token: 0x060136CC RID: 79564 RVA: 0x00569DF7 File Offset: 0x00567FF7
	public int SlotIndex { get; set; }

	// Token: 0x060136CD RID: 79565 RVA: 0x00569E00 File Offset: 0x00568000
	public QuestReviewNodeParam()
	{
		this.LineColorHex = string.Empty;
		this.StarIcon = string.Empty;
		this.RoundIcon = string.Empty;
	}
}
