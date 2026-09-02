using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Common.InputView.View
{
	// Token: 0x02005E74 RID: 24180
	public class CommonSingleInputView : CommonInputViewBase
	{
		// Token: 0x0603CD1B RID: 249115 RVA: 0x00F7114C File Offset: 0x00F6F34C
		[NullableContext(1)]
		public CommonSingleInputView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603CD1C RID: 249116 RVA: 0x00F71155 File Offset: 0x00F6F355
		protected override int GetMaxLimit()
		{
			return 12;
		}

		// Token: 0x0603CD1D RID: 249117 RVA: 0x00F71159 File Offset: 0x00F6F359
		protected override bool IsAllowMultiLine()
		{
			return false;
		}
	}
}
