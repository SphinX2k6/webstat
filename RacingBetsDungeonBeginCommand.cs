using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x020026DF RID: 9951
public class RacingBetsDungeonBeginCommand : RacingBetsCommandBase
{
	// Token: 0x170018D6 RID: 6358
	// (get) Token: 0x06013A30 RID: 80432 RVA: 0x0057973A File Offset: 0x0057793A
	public override ERacingBetsCommandType CommandType
	{
		get
		{
			return ERacingBetsCommandType.DungeonBegin;
		}
	}

	// Token: 0x06013A31 RID: 80433 RVA: 0x00579740 File Offset: 0x00577940
	public override UniTask OnExecute()
	{
		RacingBetsDungeonBeginCommand.<OnExecute>d__2 <OnExecute>d__;
		<OnExecute>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnExecute>d__.<>1__state = -1;
		<OnExecute>d__.<>t__builder.Start<RacingBetsDungeonBeginCommand.<OnExecute>d__2>(ref <OnExecute>d__);
		return <OnExecute>d__.<>t__builder.Task;
	}

	// Token: 0x06013A32 RID: 80434 RVA: 0x0057977B File Offset: 0x0057797B
	[NullableContext(1)]
	public override string LogInfo()
	{
		return "RacingBetsDungeonBeginCommand";
	}
}
