using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Common.InputView.View
{
	// Token: 0x02005E7A RID: 24186
	[NullableContext(1)]
	[Nullable(0)]
	public class TextInputData : ITextInputData
	{
		// Token: 0x17009954 RID: 39252
		// (get) Token: 0x0603CD3D RID: 249149 RVA: 0x00F71287 File Offset: 0x00F6F487
		// (set) Token: 0x0603CD3E RID: 249150 RVA: 0x00F7128F File Offset: 0x00F6F48F
		public TConfirm ConfirmFunc { get; set; }

		// Token: 0x17009955 RID: 39253
		// (get) Token: 0x0603CD3F RID: 249151 RVA: 0x00F71298 File Offset: 0x00F6F498
		// (set) Token: 0x0603CD40 RID: 249152 RVA: 0x00F712A0 File Offset: 0x00F6F4A0
		public TResult ResultFunc { get; set; }

		// Token: 0x17009956 RID: 39254
		// (get) Token: 0x0603CD41 RID: 249153 RVA: 0x00F712A9 File Offset: 0x00F6F4A9
		// (set) Token: 0x0603CD42 RID: 249154 RVA: 0x00F712B1 File Offset: 0x00F6F4B1
		public string InputText { get; set; }

		// Token: 0x17009957 RID: 39255
		// (get) Token: 0x0603CD43 RID: 249155 RVA: 0x00F712BA File Offset: 0x00F6F4BA
		// (set) Token: 0x0603CD44 RID: 249156 RVA: 0x00F712C2 File Offset: 0x00F6F4C2
		[Nullable(2)]
		public string DefaultText { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x17009958 RID: 39256
		// (get) Token: 0x0603CD45 RID: 249157 RVA: 0x00F712CB File Offset: 0x00F6F4CB
		// (set) Token: 0x0603CD46 RID: 249158 RVA: 0x00F712D3 File Offset: 0x00F6F4D3
		public bool IsCheckNone { get; set; }
	}
}
