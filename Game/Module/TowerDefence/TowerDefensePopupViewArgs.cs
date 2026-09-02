using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004EC1 RID: 20161
	[NullableContext(1)]
	[Nullable(0)]
	public class TowerDefensePopupViewArgs : ITowerDefensePopupViewArgs
	{
		// Token: 0x170089A8 RID: 35240
		// (get) Token: 0x06034161 RID: 213345 RVA: 0x00D04A8E File Offset: 0x00D02C8E
		// (set) Token: 0x06034162 RID: 213346 RVA: 0x00D04A96 File Offset: 0x00D02C96
		public string TextTitle { get; set; }

		// Token: 0x170089A9 RID: 35241
		// (get) Token: 0x06034163 RID: 213347 RVA: 0x00D04A9F File Offset: 0x00D02C9F
		// (set) Token: 0x06034164 RID: 213348 RVA: 0x00D04AA7 File Offset: 0x00D02CA7
		public string TextTips { get; set; }

		// Token: 0x170089AA RID: 35242
		// (get) Token: 0x06034165 RID: 213349 RVA: 0x00D04AB0 File Offset: 0x00D02CB0
		// (set) Token: 0x06034166 RID: 213350 RVA: 0x00D04AB8 File Offset: 0x00D02CB8
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<object> TextTipsArgs { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x170089AB RID: 35243
		// (get) Token: 0x06034167 RID: 213351 RVA: 0x00D04AC1 File Offset: 0x00D02CC1
		// (set) Token: 0x06034168 RID: 213352 RVA: 0x00D04AC9 File Offset: 0x00D02CC9
		public string TextContent { get; set; }

		// Token: 0x170089AC RID: 35244
		// (get) Token: 0x06034169 RID: 213353 RVA: 0x00D04AD2 File Offset: 0x00D02CD2
		// (set) Token: 0x0603416A RID: 213354 RVA: 0x00D04ADA File Offset: 0x00D02CDA
		[Nullable(2)]
		public Action ConfirmBack { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x170089AD RID: 35245
		// (get) Token: 0x0603416B RID: 213355 RVA: 0x00D04AE3 File Offset: 0x00D02CE3
		// (set) Token: 0x0603416C RID: 213356 RVA: 0x00D04AEB File Offset: 0x00D02CEB
		[Nullable(2)]
		public Action CancelBack { [NullableContext(2)] get; [NullableContext(2)] set; }
	}
}
