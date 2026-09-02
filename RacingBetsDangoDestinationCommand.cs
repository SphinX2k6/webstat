using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x020026D9 RID: 9945
public class RacingBetsDangoDestinationCommand : RacingBetsCommandBase
{
	// Token: 0x170018D0 RID: 6352
	// (get) Token: 0x06013A0B RID: 80395 RVA: 0x00578FDE File Offset: 0x005771DE
	public override ERacingBetsCommandType CommandType
	{
		get
		{
			return ERacingBetsCommandType.DangoDestination;
		}
	}

	// Token: 0x06013A0C RID: 80396 RVA: 0x00578FE2 File Offset: 0x005771E2
	public void Init(int dangoId)
	{
		this.DangoId = dangoId;
	}

	// Token: 0x06013A0D RID: 80397 RVA: 0x00578FEC File Offset: 0x005771EC
	public override UniTask OnExecute()
	{
		RacingBetsDangoDestinationCommand.<OnExecute>d__4 <OnExecute>d__;
		<OnExecute>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnExecute>d__.<>4__this = this;
		<OnExecute>d__.<>1__state = -1;
		<OnExecute>d__.<>t__builder.Start<RacingBetsDangoDestinationCommand.<OnExecute>d__4>(ref <OnExecute>d__);
		return <OnExecute>d__.<>t__builder.Task;
	}

	// Token: 0x06013A0E RID: 80398 RVA: 0x0057902F File Offset: 0x0057722F
	[NullableContext(1)]
	public override string LogInfo()
	{
		return "RacingBetsDangoDestinationCommand";
	}

	// Token: 0x040098B1 RID: 39089
	private int DangoId;
}
