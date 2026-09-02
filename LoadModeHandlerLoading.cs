using System;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Typing;
using UnrealEngine;

// Token: 0x02000BD6 RID: 3030
[NullableContext(1)]
[Nullable(0)]
public class LoadModeHandlerLoading : ILoadModeHandler
{
	// Token: 0x060031C4 RID: 12740 RVA: 0x0001ED5C File Offset: 0x0001CF5C
	public void EnterMode(UObject worldContext)
	{
		FKuroPerfSightHelper.BeginExtTag("InLoadingMode");
		if (Singleton<Info>.Instance.IsPlayInEditor)
		{
			UKismetSystemLibrary.ExecuteConsoleCommand(worldContext, "s.AsyncLoadingTimeLimit 5000", null);
			UKismetSystemLibrary.ExecuteConsoleCommand(worldContext, "s.LevelStreamingActorsUpdateTimeLimit 1000", null);
			UKismetSystemLibrary.ExecuteConsoleCommand(worldContext, "wp.Runtime.MaxLoadingStreamingCells 200", null);
		}
		else
		{
			UKismetSystemLibrary.ExecuteConsoleCommand(worldContext, "s.AsyncLoadingTimeLimit 50", null);
			UKismetSystemLibrary.ExecuteConsoleCommand(worldContext, "s.LevelStreamingActorsUpdateTimeLimit 1000", null);
			UKismetSystemLibrary.ExecuteConsoleCommand(worldContext, "wp.Runtime.MaxLoadingStreamingCells 40", null);
		}
		UKismetSystemLibrary.ExecuteConsoleCommand(worldContext, "wp.Runtime.BlockOnSlowStreaming 0", null);
		Singleton<ResourceSystem>.Instance.SetCallbackTimeLimit(0);
		GameBudgetInterfaceController.UpdateMinUpdateFifoBudgetTime(9999f);
	}

	// Token: 0x060031C5 RID: 12741 RVA: 0x0001EDEA File Offset: 0x0001CFEA
	public void ExitMode(UObject worldContext)
	{
		FKuroPerfSightHelper.EndExtTag("InLoadingMode");
	}

	// Token: 0x040004BB RID: 1211
	public Stat StatEnterMode = Stat.Create("LoadModeHandler_Enter_Loading", "", "");
}
