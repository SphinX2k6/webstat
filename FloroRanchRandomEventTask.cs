using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Ui;

// Token: 0x02001C16 RID: 7190
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchRandomEventTask : FloroRanchDailyTaskBase
{
	// Token: 0x0600D134 RID: 53556 RVA: 0x00378A36 File Offset: 0x00376C36
	public FloroRanchRandomEventTask(FloroRanchPlayEvent data)
	{
		this.EventData = data;
	}

	// Token: 0x0600D135 RID: 53557 RVA: 0x00378A48 File Offset: 0x00376C48
	protected override void OnExecute()
	{
		FloroRanchRandomEventViewParam floroRanchRandomEventViewParam = new FloroRanchRandomEventViewParam
		{
			EventData = this.EventData,
			CloseCallback = delegate()
			{
				base.Complete(null);
			}
		};
		ModelBase<FloroRanchGamePlayModel>.Instance.OpenAndRecordView(EUiViewName.FloroRanchRandomEventView, floroRanchRandomEventViewParam, null);
	}

	// Token: 0x040063E5 RID: 25573
	private readonly FloroRanchPlayEvent EventData;
}
