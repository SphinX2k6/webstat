using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Core;
using AkiClient.Game.Aki.Core.Fight.Manager;
using AkiClient.Game.Aki.UI.Manager;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Launcher.Platform;
using UnrealEngine;
using UnrealEngine.Extension;

// Token: 0x02000E9D RID: 3741
[NullableContext(2)]
[Nullable(0)]
public class GlobalData : IStaticVariableResetter
{
	// Token: 0x06005C45 RID: 23621 RVA: 0x00173BAE File Offset: 0x00171DAE
	static GlobalData()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(GlobalData.CreateStaticDefaultValue), new Action(GlobalData.ResetStaticDefaultValue));
	}

	// Token: 0x06005C46 RID: 23622 RVA: 0x00173BCD File Offset: 0x00171DCD
	public static void CreateStaticDefaultValue()
	{
	}

	// Token: 0x06005C47 RID: 23623 RVA: 0x00173BCF File Offset: 0x00171DCF
	public static void ResetStaticDefaultValue()
	{
		GlobalData.UiSceneState = EKuroUI3DState.NotLoaded;
		GlobalData.IsEditor = false;
		GlobalData.GameInstanceInternal = null;
		GlobalData.BpEventManagerInternal = null;
		GlobalData.BpFightManagerInternal = null;
		GlobalData.NetworkState = null;
		GlobalData.IsRunWithEditorConfig = null;
		GlobalData.ClearSceneDone = null;
	}

	// Token: 0x06005C48 RID: 23624 RVA: 0x00173C0B File Offset: 0x00171E0B
	private GlobalData()
	{
	}

	// Token: 0x06005C49 RID: 23625 RVA: 0x00173C13 File Offset: 0x00171E13
	[NullableContext(1)]
	public static void Init(UGameInstance gameInstance)
	{
		GlobalData.GameInstanceInternal = (BP_MainGameInstance_C)gameInstance;
		GlobalData.IsEditor = UKuroStaticLibrary.IsEditor(gameInstance.GetWorld());
		GlobalData.BpEventManagerInternal = new BP_EventManager_C(gameInstance, null, EObjectFlags.RF_NoFlags);
		GlobalData.BpFightManagerInternal = new BP_FightManager_C(gameInstance, null, EObjectFlags.RF_NoFlags);
	}

	// Token: 0x06005C4A RID: 23626 RVA: 0x00173C4A File Offset: 0x00171E4A
	public static void SetUiState(EKuroUI3DState state)
	{
		if (GlobalData.UiSceneState != state)
		{
			GlobalData.UiSceneState = state;
			Singleton<EventSystem>.Instance.Emit<EKuroUI3DState>(EEventName.OnGlobalUiSceneStateChanged, state);
		}
	}

	// Token: 0x1700069A RID: 1690
	// (get) Token: 0x06005C4B RID: 23627 RVA: 0x00173C6B File Offset: 0x00171E6B
	public static bool IsUiSceneLoading
	{
		get
		{
			return GlobalData.UiSceneState == EKuroUI3DState.Loading;
		}
	}

	// Token: 0x1700069B RID: 1691
	// (get) Token: 0x06005C4C RID: 23628 RVA: 0x00173C75 File Offset: 0x00171E75
	public static bool IsUiSceneOpen
	{
		get
		{
			return GlobalData.UiSceneState == EKuroUI3DState.Loaded;
		}
	}

	// Token: 0x1700069C RID: 1692
	// (get) Token: 0x06005C4D RID: 23629 RVA: 0x00173C7F File Offset: 0x00171E7F
	public static bool IsPlayInEditor
	{
		get
		{
			return GlobalData.IsEditor;
		}
	}

	// Token: 0x1700069D RID: 1693
	// (get) Token: 0x06005C4E RID: 23630 RVA: 0x00173C86 File Offset: 0x00171E86
	public static BP_MainGameInstance_C GameInstance
	{
		get
		{
			return GlobalData.GameInstanceInternal;
		}
	}

	// Token: 0x1700069E RID: 1694
	// (get) Token: 0x06005C4F RID: 23631 RVA: 0x00173C8D File Offset: 0x00171E8D
	public static UWorld World
	{
		get
		{
			BP_MainGameInstance_C gameInstanceInternal = GlobalData.GameInstanceInternal;
			if (gameInstanceInternal == null)
			{
				return null;
			}
			return gameInstanceInternal.GetWorld();
		}
	}

	// Token: 0x1700069F RID: 1695
	// (get) Token: 0x06005C50 RID: 23632 RVA: 0x00173C9F File Offset: 0x00171E9F
	[Nullable(1)]
	public static BP_EventManager_C BpEventManager
	{
		[NullableContext(1)]
		get
		{
			return GlobalData.BpEventManagerInternal;
		}
	}

	// Token: 0x170006A0 RID: 1696
	// (get) Token: 0x06005C51 RID: 23633 RVA: 0x00173CA6 File Offset: 0x00171EA6
	[Nullable(1)]
	public static BP_FightManager_C BpFightManager
	{
		[NullableContext(1)]
		get
		{
			return GlobalData.BpFightManagerInternal;
		}
	}

	// Token: 0x170006A1 RID: 1697
	// (get) Token: 0x06005C52 RID: 23634 RVA: 0x00173CAD File Offset: 0x00171EAD
	public static bool IsEs3
	{
		get
		{
			return UKuroRenderingRuntimeBPPluginBPLibrary.GetWorldFeatureLevel(GlobalData.World) == KuroFeatureLevel.ES3_1;
		}
	}

	// Token: 0x170006A2 RID: 1698
	// (get) Token: 0x06005C53 RID: 23635 RVA: 0x00173CBC File Offset: 0x00171EBC
	public static bool IsSm5
	{
		get
		{
			return UKuroRenderingRuntimeBPPluginBPLibrary.GetWorldFeatureLevel(GlobalData.World) == KuroFeatureLevel.SM5;
		}
	}

	// Token: 0x06005C54 RID: 23636 RVA: 0x00173CCB File Offset: 0x00171ECB
	public static bool Networking()
	{
		if (GlobalData.NetworkState != null)
		{
			return GlobalData.NetworkState.Value;
		}
		GlobalData.NetworkState = new bool?(AActor.GetKuroNetMode() == EKuroNetMode.KNM_Net);
		return GlobalData.NetworkState.Value;
	}

	// Token: 0x06005C55 RID: 23637 RVA: 0x00173D08 File Offset: 0x00171F08
	public static bool IsRunWithEditorStartConfig()
	{
		if (GlobalData.IsRunWithEditorConfig != null)
		{
			return GlobalData.IsRunWithEditorConfig.Value;
		}
		if (!GlobalData.IsPlayInEditor && !Singleton<Info>.Instance.IsBuildShipping && Singleton<Platform>.Instance.IsWindowsPlatform())
		{
			string inPath = UBlueprintPathsLibrary.ProjectDir() + "../Config/Raw/Tables/k.可视化编辑/__Temp__/EditorStartConfig.json";
			string commandLine = UKismetSystemLibrary.GetCommandLine();
			GlobalData.IsRunWithEditorConfig = new bool?((commandLine.IndexOf("-StartWithEditorConfig") >= 0 || commandLine.IndexOf("-SessionName=\"Play in Standalone Game\"") >= 0) && UBlueprintPathsLibrary.FileExists(inPath));
		}
		else
		{
			GlobalData.IsRunWithEditorConfig = new bool?(false);
		}
		return GlobalData.IsRunWithEditorConfig.Value;
	}

	// Token: 0x170006A3 RID: 1699
	// (get) Token: 0x06005C56 RID: 23638 RVA: 0x00173DA7 File Offset: 0x00171FA7
	public static bool IsSceneClearing
	{
		get
		{
			return GlobalData.ClearSceneDone != null;
		}
	}

	// Token: 0x04002C25 RID: 11301
	private static bool IsEditor;

	// Token: 0x04002C26 RID: 11302
	private static EKuroUI3DState UiSceneState;

	// Token: 0x04002C27 RID: 11303
	private static BP_MainGameInstance_C GameInstanceInternal;

	// Token: 0x04002C28 RID: 11304
	private static BP_EventManager_C BpEventManagerInternal;

	// Token: 0x04002C29 RID: 11305
	private static BP_FightManager_C BpFightManagerInternal;

	// Token: 0x04002C2A RID: 11306
	private static bool? NetworkState;

	// Token: 0x04002C2B RID: 11307
	private static bool? IsRunWithEditorConfig;

	// Token: 0x04002C2C RID: 11308
	public static CustomPromise ClearSceneDone;
}
