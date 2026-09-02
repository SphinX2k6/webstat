using System;
using System.Runtime.CompilerServices;

// Token: 0x02002D47 RID: 11591
[NullableContext(2)]
[Nullable(0)]
public class ExtraRoomTipsData : IExtraRoomTipsData
{
	// Token: 0x17001EC8 RID: 7880
	// (get) Token: 0x06017626 RID: 95782 RVA: 0x0067BF9D File Offset: 0x0067A19D
	// (set) Token: 0x06017627 RID: 95783 RVA: 0x0067BFA5 File Offset: 0x0067A1A5
	public int CurScore { get; set; }

	// Token: 0x17001EC9 RID: 7881
	// (get) Token: 0x06017628 RID: 95784 RVA: 0x0067BFAE File Offset: 0x0067A1AE
	// (set) Token: 0x06017629 RID: 95785 RVA: 0x0067BFB6 File Offset: 0x0067A1B6
	public int MaxScore { get; set; }

	// Token: 0x17001ECA RID: 7882
	// (get) Token: 0x0601762A RID: 95786 RVA: 0x0067BFBF File Offset: 0x0067A1BF
	// (set) Token: 0x0601762B RID: 95787 RVA: 0x0067BFC7 File Offset: 0x0067A1C7
	public Action CancelFunc { get; set; }

	// Token: 0x17001ECB RID: 7883
	// (get) Token: 0x0601762C RID: 95788 RVA: 0x0067BFD0 File Offset: 0x0067A1D0
	// (set) Token: 0x0601762D RID: 95789 RVA: 0x0067BFD8 File Offset: 0x0067A1D8
	public Action ConfirmFunc { get; set; }
}
