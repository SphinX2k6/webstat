using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x020026E1 RID: 9953
public class RacingBetsNextRoundRequestCommand : RacingBetsCommandBase
{
	// Token: 0x170018D8 RID: 6360
	// (get) Token: 0x06013A3E RID: 80446 RVA: 0x00579E6A File Offset: 0x0057806A
	public override ERacingBetsCommandType CommandType
	{
		get
		{
			return ERacingBetsCommandType.NextRoundRequest;
		}
	}

	// Token: 0x06013A3F RID: 80447 RVA: 0x00579E6E File Offset: 0x0057806E
	public void Init(int activityId, int legMatchId, int roundId)
	{
		this.ActivityId = activityId;
		this.LegMatchId = legMatchId;
		this.RoundId = roundId;
	}

	// Token: 0x06013A40 RID: 80448 RVA: 0x00579E88 File Offset: 0x00578088
	public override UniTask OnExecute()
	{
		RacingBetsNextRoundRequestCommand.<OnExecute>d__9 <OnExecute>d__;
		<OnExecute>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnExecute>d__.<>4__this = this;
		<OnExecute>d__.<>1__state = -1;
		<OnExecute>d__.<>t__builder.Start<RacingBetsNextRoundRequestCommand.<OnExecute>d__9>(ref <OnExecute>d__);
		return <OnExecute>d__.<>t__builder.Task;
	}

	// Token: 0x06013A41 RID: 80449 RVA: 0x00579ECB File Offset: 0x005780CB
	[NullableContext(1)]
	public override string LogInfo()
	{
		return "RacingBetsNextRoundRequestCommand";
	}

	// Token: 0x040098C3 RID: 39107
	[Nullable(2)]
	private CustomPromise Promise;

	// Token: 0x040098C4 RID: 39108
	private int ActivityId;

	// Token: 0x040098C5 RID: 39109
	private int LegMatchId;

	// Token: 0x040098C6 RID: 39110
	private int RoundId;

	// Token: 0x040098C7 RID: 39111
	private const int REQUEST_INTERVAL_TIME = 1000;

	// Token: 0x040098C8 RID: 39112
	private const int REQUEST_MAX_COUNT = 5;
}
