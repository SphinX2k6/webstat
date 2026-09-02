using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.GenericPrompt.View
{
	// Token: 0x02005CC7 RID: 23751
	public class WhiteCatWarningFloatTips : GenericPromptFloatTipsBase
	{
		// Token: 0x0603BE6D RID: 245357 RVA: 0x00F2E625 File Offset: 0x00F2C825
		[NullableContext(1)]
		public WhiteCatWarningFloatTips(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603BE6E RID: 245358 RVA: 0x00F2E62E File Offset: 0x00F2C82E
		protected override void SetExtraText([ParamCollection] [Nullable(new byte[]
		{
			1,
			2
		})] IReadOnlyList<object> param)
		{
		}
	}
}
