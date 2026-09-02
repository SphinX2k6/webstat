using System;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;

// Token: 0x02001734 RID: 5940
public abstract class ActivityCaptionDecorationTagBase : UiPanelBase
{
	// Token: 0x0600A5A7 RID: 42407
	public abstract UniTask OnCaptionTagRefresh(int activityId);
}
