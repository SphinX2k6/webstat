using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x020026DD RID: 9949
[NullableContext(1)]
[Nullable(0)]
public class RacingBetsDangoTransmitCommand : RacingBetsCommandBase
{
	// Token: 0x170018D4 RID: 6356
	// (get) Token: 0x06013A1F RID: 80415 RVA: 0x0057913C File Offset: 0x0057733C
	public override ERacingBetsCommandType CommandType
	{
		get
		{
			return ERacingBetsCommandType.DangoTransmit;
		}
	}

	// Token: 0x06013A20 RID: 80416 RVA: 0x00579140 File Offset: 0x00577340
	public void Init(RacingBetsDangoActionTransmit transmitAction)
	{
		this.TransmitAction = transmitAction;
	}

	// Token: 0x06013A21 RID: 80417 RVA: 0x0057914C File Offset: 0x0057734C
	public override UniTask OnExecute()
	{
		RacingBetsDangoTransmitCommand.<OnExecute>d__4 <OnExecute>d__;
		<OnExecute>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnExecute>d__.<>4__this = this;
		<OnExecute>d__.<>1__state = -1;
		<OnExecute>d__.<>t__builder.Start<RacingBetsDangoTransmitCommand.<OnExecute>d__4>(ref <OnExecute>d__);
		return <OnExecute>d__.<>t__builder.Task;
	}

	// Token: 0x06013A22 RID: 80418 RVA: 0x0057918F File Offset: 0x0057738F
	public override string LogInfo()
	{
		return "RacingBetsDangoTransmitCommand";
	}

	// Token: 0x040098B6 RID: 39094
	private RacingBetsDangoActionTransmit TransmitAction;
}
