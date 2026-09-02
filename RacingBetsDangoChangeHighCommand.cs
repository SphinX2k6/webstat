using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x020026D8 RID: 9944
[NullableContext(1)]
[Nullable(0)]
public class RacingBetsDangoChangeHighCommand : RacingBetsCommandBase
{
	// Token: 0x170018CF RID: 6351
	// (get) Token: 0x06013A06 RID: 80390 RVA: 0x00578F7E File Offset: 0x0057717E
	public override ERacingBetsCommandType CommandType
	{
		get
		{
			return ERacingBetsCommandType.DangoChangeHigh;
		}
	}

	// Token: 0x06013A07 RID: 80391 RVA: 0x00578F81 File Offset: 0x00577181
	public void Init(RacingBetsDangoActionChangeHigh changeHighAction)
	{
		this.ChangeHighAction = changeHighAction;
	}

	// Token: 0x06013A08 RID: 80392 RVA: 0x00578F8C File Offset: 0x0057718C
	public override UniTask OnExecute()
	{
		RacingBetsDangoChangeHighCommand.<OnExecute>d__4 <OnExecute>d__;
		<OnExecute>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnExecute>d__.<>4__this = this;
		<OnExecute>d__.<>1__state = -1;
		<OnExecute>d__.<>t__builder.Start<RacingBetsDangoChangeHighCommand.<OnExecute>d__4>(ref <OnExecute>d__);
		return <OnExecute>d__.<>t__builder.Task;
	}

	// Token: 0x06013A09 RID: 80393 RVA: 0x00578FCF File Offset: 0x005771CF
	public override string LogInfo()
	{
		return "RacingBetsDangoChangeHighCommand";
	}

	// Token: 0x040098B0 RID: 39088
	private RacingBetsDangoActionChangeHigh ChangeHighAction;
}
