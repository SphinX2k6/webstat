using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x0200592D RID: 22829
	[NullableContext(1)]
	[Nullable(0)]
	public class ToggleItemData : IToggleItemData
	{
		// Token: 0x1700943C RID: 37948
		// (get) Token: 0x06039EE0 RID: 237280 RVA: 0x00EA9E7E File Offset: 0x00EA807E
		// (set) Token: 0x06039EE1 RID: 237281 RVA: 0x00EA9E86 File Offset: 0x00EA8086
		public int Id { get; set; }

		// Token: 0x1700943D RID: 37949
		// (get) Token: 0x06039EE2 RID: 237282 RVA: 0x00EA9E8F File Offset: 0x00EA808F
		// (set) Token: 0x06039EE3 RID: 237283 RVA: 0x00EA9E97 File Offset: 0x00EA8097
		public string Icon { get; set; }

		// Token: 0x1700943E RID: 37950
		// (get) Token: 0x06039EE4 RID: 237284 RVA: 0x00EA9EA0 File Offset: 0x00EA80A0
		// (set) Token: 0x06039EE5 RID: 237285 RVA: 0x00EA9EA8 File Offset: 0x00EA80A8
		public string TitleId { get; set; }

		// Token: 0x1700943F RID: 37951
		// (get) Token: 0x06039EE6 RID: 237286 RVA: 0x00EA9EB1 File Offset: 0x00EA80B1
		// (set) Token: 0x06039EE7 RID: 237287 RVA: 0x00EA9EB9 File Offset: 0x00EA80B9
		public string DescId { get; set; }

		// Token: 0x17009440 RID: 37952
		// (get) Token: 0x06039EE8 RID: 237288 RVA: 0x00EA9EC2 File Offset: 0x00EA80C2
		// (set) Token: 0x06039EE9 RID: 237289 RVA: 0x00EA9ECA File Offset: 0x00EA80CA
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public string[] DescParams { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x17009441 RID: 37953
		// (get) Token: 0x06039EEA RID: 237290 RVA: 0x00EA9ED3 File Offset: 0x00EA80D3
		// (set) Token: 0x06039EEB RID: 237291 RVA: 0x00EA9EDB File Offset: 0x00EA80DB
		[Nullable(2)]
		public string ProgressId { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x17009442 RID: 37954
		// (get) Token: 0x06039EEC RID: 237292 RVA: 0x00EA9EE4 File Offset: 0x00EA80E4
		// (set) Token: 0x06039EED RID: 237293 RVA: 0x00EA9EEC File Offset: 0x00EA80EC
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public string[] ProgressParams { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x17009443 RID: 37955
		// (get) Token: 0x06039EEE RID: 237294 RVA: 0x00EA9EF5 File Offset: 0x00EA80F5
		// (set) Token: 0x06039EEF RID: 237295 RVA: 0x00EA9EFD File Offset: 0x00EA80FD
		public bool IsDisabled { get; set; }
	}
}
