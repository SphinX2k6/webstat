using System;
using CSharpScript.Game.Ui;

// Token: 0x0200155E RID: 5470
public class ActivityRegressTaskSubViewBase : UiPanelBase
{
	// Token: 0x0600997A RID: 39290 RVA: 0x002829C7 File Offset: 0x00280BC7
	public void Update()
	{
		this.OnUpdate();
	}

	// Token: 0x0600997B RID: 39291 RVA: 0x002829CF File Offset: 0x00280BCF
	protected virtual void OnUpdate()
	{
	}
}
