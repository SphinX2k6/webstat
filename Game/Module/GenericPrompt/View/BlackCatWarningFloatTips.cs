using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.GenericPrompt.View
{
	// Token: 0x02005CAB RID: 23723
	public class BlackCatWarningFloatTips : GenericPromptFloatTipsBase
	{
		// Token: 0x0603BE10 RID: 245264 RVA: 0x00F2CDDC File Offset: 0x00F2AFDC
		[NullableContext(1)]
		public BlackCatWarningFloatTips(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603BE11 RID: 245265 RVA: 0x00F2CDE5 File Offset: 0x00F2AFE5
		protected override void SetExtraText([ParamCollection] [Nullable(new byte[]
		{
			1,
			2
		})] IReadOnlyList<object> parameters)
		{
		}
	}
}
