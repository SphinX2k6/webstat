using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.GenericPrompt.View
{
	// Token: 0x02005CAE RID: 23726
	public class ChallengeSuccessFloatTips : GenericPromptFloatTipsBase
	{
		// Token: 0x0603BE16 RID: 245270 RVA: 0x00F2CDFD File Offset: 0x00F2AFFD
		[NullableContext(1)]
		public ChallengeSuccessFloatTips(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603BE17 RID: 245271 RVA: 0x00F2CE06 File Offset: 0x00F2B006
		protected override void SetExtraText([ParamCollection] [Nullable(new byte[]
		{
			1,
			2
		})] IReadOnlyList<object> parameters)
		{
		}
	}
}
