using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.GenericPrompt.View;
using CSharpScript.Game.Ui;

// Token: 0x02001AEE RID: 6894
public class DangoAbyssNpcTips : GenericPromptFloatTipsBase
{
	// Token: 0x0600C67B RID: 50811 RVA: 0x003471D5 File Offset: 0x003453D5
	[NullableContext(1)]
	public DangoAbyssNpcTips(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600C67C RID: 50812 RVA: 0x003471E0 File Offset: 0x003453E0
	protected override void SetMainText([ParamCollection] [Nullable(new byte[]
	{
		1,
		2
	})] IReadOnlyList<object> param)
	{
		if (this.Data.MainTextObj != null)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.ExtraText, this.Data.MainTextObj.TextKey, Array.Empty<object>());
			base.ExtraText.SetUIActive(true);
			return;
		}
	}

	// Token: 0x0600C67D RID: 50813 RVA: 0x0034722C File Offset: 0x0034542C
	protected override void SetExtraText([ParamCollection] [Nullable(new byte[]
	{
		1,
		2
	})] IReadOnlyList<object> param)
	{
	}
}
