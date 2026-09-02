using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.GenericPrompt.View;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.PermanentRogue
{
	// Token: 0x0200568C RID: 22156
	public class RogueResOpenTips : GenericPromptFloatTipsBase
	{
		// Token: 0x06038715 RID: 231189 RVA: 0x00E4BFCB File Offset: 0x00E4A1CB
		[NullableContext(1)]
		public RogueResOpenTips(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06038716 RID: 231190 RVA: 0x00E4BFD4 File Offset: 0x00E4A1D4
		protected override void SetMainText([ParamCollection] [Nullable(new byte[]
		{
			1,
			2
		})] IReadOnlyList<object> param)
		{
		}

		// Token: 0x06038717 RID: 231191 RVA: 0x00E4BFD6 File Offset: 0x00E4A1D6
		protected override void SetExtraText([ParamCollection] [Nullable(new byte[]
		{
			1,
			2
		})] IReadOnlyList<object> param)
		{
		}
	}
}
