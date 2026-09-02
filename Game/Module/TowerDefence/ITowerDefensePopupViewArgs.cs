using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004EC0 RID: 20160
	[NullableContext(1)]
	public interface ITowerDefensePopupViewArgs
	{
		// Token: 0x170089A2 RID: 35234
		// (get) Token: 0x06034155 RID: 213333
		// (set) Token: 0x06034156 RID: 213334
		string TextTitle { get; set; }

		// Token: 0x170089A3 RID: 35235
		// (get) Token: 0x06034157 RID: 213335
		// (set) Token: 0x06034158 RID: 213336
		string TextTips { get; set; }

		// Token: 0x170089A4 RID: 35236
		// (get) Token: 0x06034159 RID: 213337
		// (set) Token: 0x0603415A RID: 213338
		[Nullable(new byte[]
		{
			2,
			1
		})]
		List<object> TextTipsArgs { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x170089A5 RID: 35237
		// (get) Token: 0x0603415B RID: 213339
		// (set) Token: 0x0603415C RID: 213340
		string TextContent { get; set; }

		// Token: 0x170089A6 RID: 35238
		// (get) Token: 0x0603415D RID: 213341
		// (set) Token: 0x0603415E RID: 213342
		[Nullable(2)]
		Action ConfirmBack { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x170089A7 RID: 35239
		// (get) Token: 0x0603415F RID: 213343
		// (set) Token: 0x06034160 RID: 213344
		[Nullable(2)]
		Action CancelBack { [NullableContext(2)] get; [NullableContext(2)] set; }
	}
}
