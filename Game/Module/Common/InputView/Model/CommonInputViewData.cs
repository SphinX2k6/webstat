using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.Common.InputView.Model
{
	// Token: 0x02005E7E RID: 24190
	[NullableContext(1)]
	[Nullable(0)]
	public class CommonInputViewData : ICommonInputViewData
	{
		// Token: 0x17009962 RID: 39266
		// (get) Token: 0x0603CD76 RID: 249206 RVA: 0x00F718DB File Offset: 0x00F6FADB
		// (set) Token: 0x0603CD77 RID: 249207 RVA: 0x00F718E3 File Offset: 0x00F6FAE3
		public TableTextArgNew TitleTextArgs { get; set; }

		// Token: 0x17009963 RID: 39267
		// (get) Token: 0x0603CD78 RID: 249208 RVA: 0x00F718EC File Offset: 0x00F6FAEC
		// (set) Token: 0x0603CD79 RID: 249209 RVA: 0x00F718F4 File Offset: 0x00F6FAF4
		[Nullable(new byte[]
		{
			1,
			1,
			0
		})]
		public Func<string, UniTask<ErrorCode>> ConfirmFunc { [return: Nullable(new byte[]
		{
			1,
			1,
			0
		})] get; [param: Nullable(new byte[]
		{
			1,
			1,
			0
		})] set; }

		// Token: 0x17009964 RID: 39268
		// (get) Token: 0x0603CD7A RID: 249210 RVA: 0x00F718FD File Offset: 0x00F6FAFD
		// (set) Token: 0x0603CD7B RID: 249211 RVA: 0x00F71905 File Offset: 0x00F6FB05
		public string InputText { get; set; }

		// Token: 0x17009965 RID: 39269
		// (get) Token: 0x0603CD7C RID: 249212 RVA: 0x00F7190E File Offset: 0x00F6FB0E
		// (set) Token: 0x0603CD7D RID: 249213 RVA: 0x00F71916 File Offset: 0x00F6FB16
		public string DefaultText { get; set; }

		// Token: 0x17009966 RID: 39270
		// (get) Token: 0x0603CD7E RID: 249214 RVA: 0x00F7191F File Offset: 0x00F6FB1F
		// (set) Token: 0x0603CD7F RID: 249215 RVA: 0x00F71927 File Offset: 0x00F6FB27
		public bool IsCheckNone { get; set; }

		// Token: 0x17009967 RID: 39271
		// (get) Token: 0x0603CD80 RID: 249216 RVA: 0x00F71930 File Offset: 0x00F6FB30
		// (set) Token: 0x0603CD81 RID: 249217 RVA: 0x00F71938 File Offset: 0x00F6FB38
		public bool NeedFunctionButton { get; set; }

		// Token: 0x17009968 RID: 39272
		// (get) Token: 0x0603CD82 RID: 249218 RVA: 0x00F71941 File Offset: 0x00F6FB41
		// (set) Token: 0x0603CD83 RID: 249219 RVA: 0x00F71949 File Offset: 0x00F6FB49
		public string BottomTipsText { get; set; }

		// Token: 0x17009969 RID: 39273
		// (get) Token: 0x0603CD84 RID: 249220 RVA: 0x00F71952 File Offset: 0x00F6FB52
		// (set) Token: 0x0603CD85 RID: 249221 RVA: 0x00F7195A File Offset: 0x00F6FB5A
		[Nullable(2)]
		public string BottomTipsColor { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x1700996A RID: 39274
		// (get) Token: 0x0603CD86 RID: 249222 RVA: 0x00F71963 File Offset: 0x00F6FB63
		// (set) Token: 0x0603CD87 RID: 249223 RVA: 0x00F7196B File Offset: 0x00F6FB6B
		public bool? NeedCheckBlank { get; set; }
	}
}
