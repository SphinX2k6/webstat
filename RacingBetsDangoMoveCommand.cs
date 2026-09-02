using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x020026DA RID: 9946
[NullableContext(1)]
[Nullable(0)]
public class RacingBetsDangoMoveCommand : RacingBetsCommandBase
{
	// Token: 0x170018D1 RID: 6353
	// (get) Token: 0x06013A10 RID: 80400 RVA: 0x0057903E File Offset: 0x0057723E
	public override ERacingBetsCommandType CommandType
	{
		get
		{
			return ERacingBetsCommandType.DangoMove;
		}
	}

	// Token: 0x06013A11 RID: 80401 RVA: 0x00579041 File Offset: 0x00577241
	public void Init(RacingBetsDangoActionMove moveAction)
	{
		this.MoveAction = moveAction;
	}

	// Token: 0x06013A12 RID: 80402 RVA: 0x0057904C File Offset: 0x0057724C
	public override UniTask OnExecute()
	{
		RacingBetsDangoMoveCommand.<OnExecute>d__5 <OnExecute>d__;
		<OnExecute>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnExecute>d__.<>4__this = this;
		<OnExecute>d__.<>1__state = -1;
		<OnExecute>d__.<>t__builder.Start<RacingBetsDangoMoveCommand.<OnExecute>d__5>(ref <OnExecute>d__);
		return <OnExecute>d__.<>t__builder.Task;
	}

	// Token: 0x06013A13 RID: 80403 RVA: 0x0057908F File Offset: 0x0057728F
	public override string LogInfo()
	{
		return "RacingBetsDangoMoveCommand";
	}

	// Token: 0x040098B2 RID: 39090
	private const int DANGO_MOVE_EFFECT_REFRESH_DELAY_MS = 500;

	// Token: 0x040098B3 RID: 39091
	private RacingBetsDangoActionMove MoveAction;
}
