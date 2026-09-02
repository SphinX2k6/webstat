using System;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Typing;
using UnrealEngine;

// Token: 0x02000BD5 RID: 3029
[NullableContext(1)]
[Nullable(0)]
public class LoadModeHandlerInGameLoading : ILoadModeHandler
{
	// Token: 0x060031C1 RID: 12737 RVA: 0x0001ECA0 File Offset: 0x0001CEA0
	public void EnterMode(UObject worldContext)
	{
		FKuroPerfSightHelper.BeginExtTag("InGameLoadingMode");
		if (Singleton<Info>.Instance.IsPlayInEditor)
		{
			UKismetSystemLibrary.ExecuteConsoleCommand(worldContext, "s.AsyncLoadingTimeLimit 40", null);
			UKismetSystemLibrary.ExecuteConsoleCommand(worldContext, "s.LevelStreamingActorsUpdateTimeLimit 40", null);
			UKismetSystemLibrary.ExecuteConsoleCommand(worldContext, "wp.Runtime.MaxLoadingStreamingCells 8", null);
		}
		else
		{
			UKismetSystemLibrary.ExecuteConsoleCommand(worldContext, "s.AsyncLoadingTimeLimit 10", null);
			UKismetSystemLibrary.ExecuteConsoleCommand(worldContext, "s.LevelStreamingActorsUpdateTimeLimit 10", null);
			UKismetSystemLibrary.ExecuteConsoleCommand(worldContext, "wp.Runtime.MaxLoadingStreamingCells 8", null);
		}
		UKismetSystemLibrary.ExecuteConsoleCommand(worldContext, "wp.Runtime.BlockOnSlowStreaming 1", null);
		Singleton<ResourceSystem>.Instance.SetCallbackTimeLimit(5);
		GameBudgetInterfaceController.UpdateMinUpdateFifoBudgetTime(3f);
	}

	// Token: 0x060031C2 RID: 12738 RVA: 0x0001ED2E File Offset: 0x0001CF2E
	public void ExitMode(UObject worldContext)
	{
		FKuroPerfSightHelper.EndExtTag("InGameLoadingMode");
	}

	// Token: 0x040004BA RID: 1210
	public Stat StatEnterMode = Stat.Create("LoadModeHandler_Enter_InGameLoading", "", "");
}
