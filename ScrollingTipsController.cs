using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Ui;

// Token: 0x02002969 RID: 10601
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class ScrollingTipsController : UiControllerBase<ScrollingTipsController>
{
	// Token: 0x0601514B RID: 86347 RVA: 0x005D5594 File Offset: 0x005D3794
	public void ShowTipsById(string id, params object[] parameters)
	{
		TableTextArgNew mainTextObj = new TableTextArgNew(ConfigBase<TextConfig>.Instance.GetTextContentIdById(id), Array.Empty<object>());
		ControllerBase<GenericPromptController>.Instance.ShowPromptByItsType<object>(EPromptSubViewType.FloatLinePrompt, mainTextObj, null, parameters, null, null, null, null, null, false, null);
	}

	// Token: 0x0601514C RID: 86348 RVA: 0x005D55E0 File Offset: 0x005D37E0
	public void ShowTipsByText(string text)
	{
		ControllerBase<GenericPromptController>.Instance.ShowPromptByItsType<object>(EPromptSubViewType.FloatLinePrompt, null, null, new string[]
		{
			text
		}, null, null, null, null, null, false, null);
	}

	// Token: 0x0601514D RID: 86349 RVA: 0x005D561C File Offset: 0x005D381C
	public void ShowTipsByTextId(string textId, params object[] parameters)
	{
		TableTextArgNew mainTextObj = new TableTextArgNew(textId, Array.Empty<object>());
		ControllerBase<GenericPromptController>.Instance.ShowPromptByItsType<object>(EPromptSubViewType.FloatLinePrompt, mainTextObj, null, parameters, null, null, null, null, null, false, null);
	}
}
