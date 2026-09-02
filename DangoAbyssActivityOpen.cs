using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.GenericPrompt.View;
using CSharpScript.Game.Ui;

// Token: 0x02001ACD RID: 6861
public class DangoAbyssActivityOpen : GenericPromptFloatTipsBase
{
	// Token: 0x0600C588 RID: 50568 RVA: 0x00342E10 File Offset: 0x00341010
	[NullableContext(1)]
	public DangoAbyssActivityOpen(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600C589 RID: 50569 RVA: 0x00342E19 File Offset: 0x00341019
	protected override void SetMainText([ParamCollection] [Nullable(new byte[]
	{
		1,
		2
	})] IReadOnlyList<object> param)
	{
	}

	// Token: 0x0600C58A RID: 50570 RVA: 0x00342E1B File Offset: 0x0034101B
	protected override void SetExtraText([ParamCollection] [Nullable(new byte[]
	{
		1,
		2
	})] IReadOnlyList<object> param)
	{
	}
}
