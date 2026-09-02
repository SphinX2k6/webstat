using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Cysharp.Threading.Tasks;

// Token: 0x02001C0F RID: 7183
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchDayActionSettleTask : FloroRanchDailyTaskBase
{
	// Token: 0x0600D126 RID: 53542 RVA: 0x00378909 File Offset: 0x00376B09
	public FloroRanchDayActionSettleTask(FRUnitActions dayActionData)
	{
		this.DayActionData = dayActionData;
	}

	// Token: 0x0600D127 RID: 53543 RVA: 0x00378918 File Offset: 0x00376B18
	protected override void OnExecute()
	{
		FloroRanchEntityActionSystem.ExecuteActionList(new List<FloroRanchUnitActionMsg>(this.DayActionData.UnitActions)).ContinueWith(delegate()
		{
			base.AsyncComplete(null);
		});
	}

	// Token: 0x040063DD RID: 25565
	private readonly FRUnitActions DayActionData;
}
