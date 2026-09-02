using System;
using Aki.Config;

// Token: 0x02001041 RID: 4161
public class FurnitureScrollItemData : IFurnitureScrollItemData
{
	// Token: 0x1700086C RID: 2156
	// (get) Token: 0x06006C73 RID: 27763 RVA: 0x001C5BDE File Offset: 0x001C3DDE
	// (set) Token: 0x06006C74 RID: 27764 RVA: 0x001C5BE6 File Offset: 0x001C3DE6
	public Furniture FurnitureConfig { get; set; }

	// Token: 0x1700086D RID: 2157
	// (get) Token: 0x06006C75 RID: 27765 RVA: 0x001C5BEF File Offset: 0x001C3DEF
	// (set) Token: 0x06006C76 RID: 27766 RVA: 0x001C5BF7 File Offset: 0x001C3DF7
	public bool RedDotShowState { get; set; }

	// Token: 0x1700086E RID: 2158
	// (get) Token: 0x06006C77 RID: 27767 RVA: 0x001C5C00 File Offset: 0x001C3E00
	// (set) Token: 0x06006C78 RID: 27768 RVA: 0x001C5C08 File Offset: 0x001C3E08
	public bool IsSelected { get; set; }

	// Token: 0x1700086F RID: 2159
	// (get) Token: 0x06006C79 RID: 27769 RVA: 0x001C5C11 File Offset: 0x001C3E11
	// (set) Token: 0x06006C7A RID: 27770 RVA: 0x001C5C19 File Offset: 0x001C3E19
	public int LeftCount { get; set; }

	// Token: 0x17000870 RID: 2160
	// (get) Token: 0x06006C7B RID: 27771 RVA: 0x001C5C22 File Offset: 0x001C3E22
	// (set) Token: 0x06006C7C RID: 27772 RVA: 0x001C5C2A File Offset: 0x001C3E2A
	public bool IsLock { get; set; }

	// Token: 0x17000871 RID: 2161
	// (get) Token: 0x06006C7D RID: 27773 RVA: 0x001C5C33 File Offset: 0x001C3E33
	// (set) Token: 0x06006C7E RID: 27774 RVA: 0x001C5C3B File Offset: 0x001C3E3B
	public bool IsCheck { get; set; }
}
