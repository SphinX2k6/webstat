using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.GenericPrompt.View
{
	// Token: 0x02005CAD RID: 23725
	public class ChallengeFailedFloatTips : GenericPromptFloatTipsBase
	{
		// Token: 0x0603BE14 RID: 245268 RVA: 0x00F2CDF2 File Offset: 0x00F2AFF2
		[NullableContext(1)]
		public ChallengeFailedFloatTips(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603BE15 RID: 245269 RVA: 0x00F2CDFB File Offset: 0x00F2AFFB
		protected override void SetExtraText([ParamCollection] [Nullable(new byte[]
		{
			1,
			2
		})] IReadOnlyList<object> param)
		{
		}
	}
}
