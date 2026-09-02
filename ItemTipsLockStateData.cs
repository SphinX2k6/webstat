using System;
using System.Runtime.CompilerServices;

// Token: 0x020019A1 RID: 6561
[NullableContext(2)]
[Nullable(0)]
public class ItemTipsLockStateData : IItemTipsLockStateData
{
	// Token: 0x17000F5F RID: 3935
	// (get) Token: 0x0600BC66 RID: 48230 RVA: 0x0031FFC7 File Offset: 0x0031E1C7
	// (set) Token: 0x0600BC67 RID: 48231 RVA: 0x0031FFCF File Offset: 0x0031E1CF
	public bool? IsShowLockIcon { get; set; }

	// Token: 0x17000F60 RID: 3936
	// (get) Token: 0x0600BC68 RID: 48232 RVA: 0x0031FFD8 File Offset: 0x0031E1D8
	// (set) Token: 0x0600BC69 RID: 48233 RVA: 0x0031FFE0 File Offset: 0x0031E1E0
	public bool? IsShowHelpButton { get; set; }

	// Token: 0x17000F61 RID: 3937
	// (get) Token: 0x0600BC6A RID: 48234 RVA: 0x0031FFE9 File Offset: 0x0031E1E9
	// (set) Token: 0x0600BC6B RID: 48235 RVA: 0x0031FFF1 File Offset: 0x0031E1F1
	public string TipsTextKey { get; set; }

	// Token: 0x17000F62 RID: 3938
	// (get) Token: 0x0600BC6C RID: 48236 RVA: 0x0031FFFA File Offset: 0x0031E1FA
	// (set) Token: 0x0600BC6D RID: 48237 RVA: 0x00320002 File Offset: 0x0031E202
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public string[] TipsTextParams { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }

	// Token: 0x17000F63 RID: 3939
	// (get) Token: 0x0600BC6E RID: 48238 RVA: 0x0032000B File Offset: 0x0031E20B
	// (set) Token: 0x0600BC6F RID: 48239 RVA: 0x00320013 File Offset: 0x0031E213
	public Action HelpBtnCallback { get; set; }
}
