using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x020026D2 RID: 9938
[NullableContext(1)]
[Nullable(0)]
public class OpenRacingBetsDungeonResultViewCommand : RacingBetsCommandBase
{
	// Token: 0x170018C6 RID: 6342
	// (get) Token: 0x060139D8 RID: 80344 RVA: 0x00578AB7 File Offset: 0x00576CB7
	public override ERacingBetsCommandType CommandType
	{
		get
		{
			return ERacingBetsCommandType.DungeonResultView;
		}
	}

	// Token: 0x060139D9 RID: 80345 RVA: 0x00578ABB File Offset: 0x00576CBB
	public void Init(RacingBetsLegMatchData legMatchData)
	{
		this.LegMatchData = legMatchData;
	}

	// Token: 0x060139DA RID: 80346 RVA: 0x00578AC4 File Offset: 0x00576CC4
	public override UniTask OnExecute()
	{
		OpenRacingBetsDungeonResultViewCommand.<OnExecute>d__4 <OnExecute>d__;
		<OnExecute>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnExecute>d__.<>4__this = this;
		<OnExecute>d__.<>1__state = -1;
		<OnExecute>d__.<>t__builder.Start<OpenRacingBetsDungeonResultViewCommand.<OnExecute>d__4>(ref <OnExecute>d__);
		return <OnExecute>d__.<>t__builder.Task;
	}

	// Token: 0x060139DB RID: 80347 RVA: 0x00578B07 File Offset: 0x00576D07
	public override string LogInfo()
	{
		return "RacingBetsDungeonResultView";
	}

	// Token: 0x040098A7 RID: 39079
	private RacingBetsLegMatchData LegMatchData;
}
