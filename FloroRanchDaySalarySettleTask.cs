using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Cysharp.Threading.Tasks;

// Token: 0x02001C11 RID: 7185
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchDaySalarySettleTask : FloroRanchDailyTaskBase
{
	// Token: 0x0600D12B RID: 53547 RVA: 0x00378960 File Offset: 0x00376B60
	public FloroRanchDaySalarySettleTask(FloroRanchWageSettleTask wageSettleData)
	{
		this.WageSettleData = wageSettleData;
	}

	// Token: 0x0600D12C RID: 53548 RVA: 0x0037896F File Offset: 0x00376B6F
	protected override void OnExecute()
	{
		FloroRanchEntityActionSystem.ExecuteWageSettleAction(this.WageSettleData).ContinueWith(delegate()
		{
			base.AsyncComplete(null);
		});
	}

	// Token: 0x040063DE RID: 25566
	private readonly FloroRanchWageSettleTask WageSettleData;
}
