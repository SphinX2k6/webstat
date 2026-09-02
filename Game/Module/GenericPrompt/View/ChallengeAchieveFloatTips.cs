using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.GenericPrompt.View
{
	// Token: 0x02005CAC RID: 23724
	public class ChallengeAchieveFloatTips : GenericPromptFloatTipsBase
	{
		// Token: 0x0603BE12 RID: 245266 RVA: 0x00F2CDE7 File Offset: 0x00F2AFE7
		[NullableContext(1)]
		public ChallengeAchieveFloatTips(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603BE13 RID: 245267 RVA: 0x00F2CDF0 File Offset: 0x00F2AFF0
		protected override void SetExtraText([ParamCollection] [Nullable(new byte[]
		{
			1,
			2
		})] IReadOnlyList<object> param)
		{
		}
	}
}
