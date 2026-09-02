using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x020026D4 RID: 9940
public class OpenRacingBetsGamePlayViewCommand : RacingBetsCommandBase
{
	// Token: 0x170018C8 RID: 6344
	// (get) Token: 0x060139E2 RID: 80354 RVA: 0x00578B76 File Offset: 0x00576D76
	public override ERacingBetsCommandType CommandType
	{
		get
		{
			return ERacingBetsCommandType.GamePlayView;
		}
	}

	// Token: 0x060139E3 RID: 80355 RVA: 0x00578B7C File Offset: 0x00576D7C
	public override UniTask OnExecute()
	{
		OpenRacingBetsGamePlayViewCommand.<OnExecute>d__2 <OnExecute>d__;
		<OnExecute>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnExecute>d__.<>1__state = -1;
		<OnExecute>d__.<>t__builder.Start<OpenRacingBetsGamePlayViewCommand.<OnExecute>d__2>(ref <OnExecute>d__);
		return <OnExecute>d__.<>t__builder.Task;
	}

	// Token: 0x060139E4 RID: 80356 RVA: 0x00578BB7 File Offset: 0x00576DB7
	[NullableContext(1)]
	public override string LogInfo()
	{
		return "OpenRacingBetsGamePlayViewCommand";
	}
}
