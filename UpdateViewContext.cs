using System;

// Token: 0x02002A5C RID: 10844
public class UpdateViewContext
{
	// Token: 0x17001C1D RID: 7197
	// (get) Token: 0x06015BA0 RID: 88992 RVA: 0x00607A64 File Offset: 0x00605C64
	// (set) Token: 0x06015BA1 RID: 88993 RVA: 0x00607A6C File Offset: 0x00605C6C
	public EFlySkinTab Tab { get; set; }

	// Token: 0x17001C1E RID: 7198
	// (get) Token: 0x06015BA2 RID: 88994 RVA: 0x00607A75 File Offset: 0x00605C75
	// (set) Token: 0x06015BA3 RID: 88995 RVA: 0x00607A7D File Offset: 0x00605C7D
	public int SelectedSkinId { get; set; }

	// Token: 0x17001C1F RID: 7199
	// (get) Token: 0x06015BA4 RID: 88996 RVA: 0x00607A86 File Offset: 0x00605C86
	// (set) Token: 0x06015BA5 RID: 88997 RVA: 0x00607A8E File Offset: 0x00605C8E
	public bool UiShowState { get; set; }

	// Token: 0x17001C20 RID: 7200
	// (get) Token: 0x06015BA6 RID: 88998 RVA: 0x00607A97 File Offset: 0x00605C97
	// (set) Token: 0x06015BA7 RID: 88999 RVA: 0x00607A9F File Offset: 0x00605C9F
	public bool IsApplyToAll { get; set; }
}
