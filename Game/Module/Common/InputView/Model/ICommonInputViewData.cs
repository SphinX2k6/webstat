using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.Common.InputView.Model
{
	// Token: 0x02005E7D RID: 24189
	[NullableContext(1)]
	public interface ICommonInputViewData
	{
		// Token: 0x17009959 RID: 39257
		// (get) Token: 0x0603CD64 RID: 249188
		// (set) Token: 0x0603CD65 RID: 249189
		TableTextArgNew TitleTextArgs { get; set; }

		// Token: 0x1700995A RID: 39258
		// (get) Token: 0x0603CD66 RID: 249190
		// (set) Token: 0x0603CD67 RID: 249191
		[Nullable(new byte[]
		{
			1,
			1,
			0
		})]
		Func<string, UniTask<ErrorCode>> ConfirmFunc { [return: Nullable(new byte[]
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

		// Token: 0x1700995B RID: 39259
		// (get) Token: 0x0603CD68 RID: 249192
		// (set) Token: 0x0603CD69 RID: 249193
		string InputText { get; set; }

		// Token: 0x1700995C RID: 39260
		// (get) Token: 0x0603CD6A RID: 249194
		// (set) Token: 0x0603CD6B RID: 249195
		string DefaultText { get; set; }

		// Token: 0x1700995D RID: 39261
		// (get) Token: 0x0603CD6C RID: 249196
		// (set) Token: 0x0603CD6D RID: 249197
		bool IsCheckNone { get; set; }

		// Token: 0x1700995E RID: 39262
		// (get) Token: 0x0603CD6E RID: 249198
		// (set) Token: 0x0603CD6F RID: 249199
		bool NeedFunctionButton { get; set; }

		// Token: 0x1700995F RID: 39263
		// (get) Token: 0x0603CD70 RID: 249200
		// (set) Token: 0x0603CD71 RID: 249201
		string BottomTipsText { get; set; }

		// Token: 0x17009960 RID: 39264
		// (get) Token: 0x0603CD72 RID: 249202
		// (set) Token: 0x0603CD73 RID: 249203
		[Nullable(2)]
		string BottomTipsColor { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x17009961 RID: 39265
		// (get) Token: 0x0603CD74 RID: 249204
		// (set) Token: 0x0603CD75 RID: 249205
		bool? NeedCheckBlank { get; set; }
	}
}
