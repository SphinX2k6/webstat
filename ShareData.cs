using System;
using System.Runtime.CompilerServices;

// Token: 0x02000EC3 RID: 3779
[NullableContext(1)]
[Nullable(0)]
public class ShareData : IShareData
{
	// Token: 0x170006AF RID: 1711
	// (get) Token: 0x06005D79 RID: 23929 RVA: 0x00177980 File Offset: 0x00175B80
	// (set) Token: 0x06005D7A RID: 23930 RVA: 0x00177988 File Offset: 0x00175B88
	public string platform { get; set; } = "";

	// Token: 0x170006B0 RID: 1712
	// (get) Token: 0x06005D7B RID: 23931 RVA: 0x00177991 File Offset: 0x00175B91
	// (set) Token: 0x06005D7C RID: 23932 RVA: 0x00177999 File Offset: 0x00175B99
	public string title { get; set; } = "";

	// Token: 0x170006B1 RID: 1713
	// (get) Token: 0x06005D7D RID: 23933 RVA: 0x001779A2 File Offset: 0x00175BA2
	// (set) Token: 0x06005D7E RID: 23934 RVA: 0x001779AA File Offset: 0x00175BAA
	public string text { get; set; } = "";

	// Token: 0x170006B2 RID: 1714
	// (get) Token: 0x06005D7F RID: 23935 RVA: 0x001779B3 File Offset: 0x00175BB3
	// (set) Token: 0x06005D80 RID: 23936 RVA: 0x001779BB File Offset: 0x00175BBB
	public string topicId { get; set; } = "";

	// Token: 0x170006B3 RID: 1715
	// (get) Token: 0x06005D81 RID: 23937 RVA: 0x001779C4 File Offset: 0x00175BC4
	// (set) Token: 0x06005D82 RID: 23938 RVA: 0x001779CC File Offset: 0x00175BCC
	public string topicName { get; set; } = "";
}
