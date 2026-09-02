using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Ui;

// Token: 0x02001C14 RID: 7188
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchGachaTask : FloroRanchDailyTaskBase
{
	// Token: 0x0600D131 RID: 53553 RVA: 0x003789CE File Offset: 0x00376BCE
	public FloroRanchGachaTask(FloroRanchGacha data)
	{
		this.GachaData = data;
	}

	// Token: 0x0600D132 RID: 53554 RVA: 0x003789E0 File Offset: 0x00376BE0
	protected override void OnExecute()
	{
		FloroRanchCardSelectViewParam floroRanchCardSelectViewParam = new FloroRanchCardSelectViewParam
		{
			GachaData = this.GachaData,
			CloseCallback = delegate()
			{
				base.Complete(null);
			}
		};
		ModelBase<FloroRanchGamePlayModel>.Instance.OpenAndRecordView(EUiViewName.FloroRanchCardSelectView, floroRanchCardSelectViewParam, null);
	}

	// Token: 0x040063E2 RID: 25570
	private readonly FloroRanchGacha GachaData;
}
