using System;
using System.Runtime.CompilerServices;

// Token: 0x02001982 RID: 6530
[NullableContext(1)]
[Nullable(0)]
public class GetWayItemData : IGetWayItemData
{
	// Token: 0x17000F3A RID: 3898
	// (get) Token: 0x0600BBB7 RID: 48055 RVA: 0x0031D9F3 File Offset: 0x0031BBF3
	// (set) Token: 0x0600BBB8 RID: 48056 RVA: 0x0031D9FB File Offset: 0x0031BBFB
	public int Id { get; set; }

	// Token: 0x17000F3B RID: 3899
	// (get) Token: 0x0600BBB9 RID: 48057 RVA: 0x0031DA04 File Offset: 0x0031BC04
	// (set) Token: 0x0600BBBA RID: 48058 RVA: 0x0031DA0C File Offset: 0x0031BC0C
	public EGetWayItemType Type { get; set; }

	// Token: 0x17000F3C RID: 3900
	// (get) Token: 0x0600BBBB RID: 48059 RVA: 0x0031DA15 File Offset: 0x0031BC15
	// (set) Token: 0x0600BBBC RID: 48060 RVA: 0x0031DA1D File Offset: 0x0031BC1D
	public string Text { get; set; }

	// Token: 0x17000F3D RID: 3901
	// (get) Token: 0x0600BBBD RID: 48061 RVA: 0x0031DA26 File Offset: 0x0031BC26
	// (set) Token: 0x0600BBBE RID: 48062 RVA: 0x0031DA2E File Offset: 0x0031BC2E
	public int SortIndex { get; set; }

	// Token: 0x17000F3E RID: 3902
	// (get) Token: 0x0600BBBF RID: 48063 RVA: 0x0031DA37 File Offset: 0x0031BC37
	// (set) Token: 0x0600BBC0 RID: 48064 RVA: 0x0031DA3F File Offset: 0x0031BC3F
	public Action Function { get; set; }

	// Token: 0x0600BBC1 RID: 48065 RVA: 0x0031DA48 File Offset: 0x0031BC48
	public GetWayItemData(int id, EGetWayItemType type, string text, int sortIndex, Action function)
	{
		this.Id = id;
		this.Type = type;
		this.Text = text;
		this.SortIndex = sortIndex;
		this.Function = function;
	}
}
