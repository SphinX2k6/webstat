using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Cysharp.Threading.Tasks;

// Token: 0x02001C12 RID: 7186
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchDayStartTask : FloroRanchDailyTaskBase
{
	// Token: 0x0600D12E RID: 53550 RVA: 0x00378997 File Offset: 0x00376B97
	public FloroRanchDayStartTask(FloroRanchDayStart dayStartData)
	{
		this.DayStartData = dayStartData;
	}

	// Token: 0x0600D12F RID: 53551 RVA: 0x003789A6 File Offset: 0x00376BA6
	protected override void OnExecute()
	{
		FloroRanchEntityActionSystem.DayStart(this.DayStartData).ContinueWith(delegate()
		{
			base.AsyncComplete(null);
		});
	}

	// Token: 0x040063DF RID: 25567
	private readonly FloroRanchDayStart DayStartData;
}
