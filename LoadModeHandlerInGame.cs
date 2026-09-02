using System;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using UnrealEngine;

// Token: 0x02000BD4 RID: 3028
[NullableContext(1)]
[Nullable(0)]
public class LoadModeHandlerInGame : ILoadModeHandler
{
	// Token: 0x060031BE RID: 12734 RVA: 0x0001EBF8 File Offset: 0x0001CDF8
	public void EnterMode(UObject worldContext)
	{
		if (Singleton<Info>.Instance.IsPlayInEditor)
		{
			UKismetSystemLibrary.ExecuteConsoleCommand(worldContext, "s.AsyncLoadingTimeLimit 20", null);
			UKismetSystemLibrary.ExecuteConsoleCommand(worldContext, "s.LevelStreamingActorsUpdateTimeLimit 20", null);
			UKismetSystemLibrary.ExecuteConsoleCommand(worldContext, "wp.Runtime.MaxLoadingStreamingCells 4", null);
		}
		else
		{
			UKismetSystemLibrary.ExecuteConsoleCommand(worldContext, "s.AsyncLoadingTimeLimit 5", null);
			UKismetSystemLibrary.ExecuteConsoleCommand(worldContext, "s.LevelStreamingActorsUpdateTimeLimit 5", null);
			UKismetSystemLibrary.ExecuteConsoleCommand(worldContext, "wp.Runtime.MaxLoadingStreamingCells 4", null);
		}
		UKismetSystemLibrary.ExecuteConsoleCommand(worldContext, "wp.Runtime.BlockOnSlowStreaming 1", null);
		Singleton<ResourceSystem>.Instance.SetCallbackTimeLimit(5);
		GameBudgetInterfaceController.UpdateMinUpdateFifoBudgetTime(3f);
	}

	// Token: 0x060031BF RID: 12735 RVA: 0x0001EC7C File Offset: 0x0001CE7C
	public void ExitMode(UObject worldContext)
	{
	}

	// Token: 0x040004B9 RID: 1209
	public Stat StatEnterMode = Stat.Create("LoadModeHandler_Enter_InGame", "", "");
}
