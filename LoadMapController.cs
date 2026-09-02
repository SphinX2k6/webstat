using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;
using UnrealEngine.Extension;

// Token: 0x02003473 RID: 13427
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class LoadMapController : ControllerBase<LoadMapController>
{
	// Token: 0x0601C4E9 RID: 115945 RVA: 0x008782AD File Offset: 0x008764AD
	protected override bool OnInit()
	{
		return true;
	}

	// Token: 0x0601C4EA RID: 115946 RVA: 0x008782B0 File Offset: 0x008764B0
	protected override bool OnClear()
	{
		return true;
	}

	// Token: 0x0601C4EB RID: 115947 RVA: 0x008782B3 File Offset: 0x008764B3
	protected override void OnTick(float delta)
	{
	}

	// Token: 0x0601C4EC RID: 115948 RVA: 0x008782B8 File Offset: 0x008764B8
	private UniTask OpenLoadingAsync()
	{
		LoadMapController.<OpenLoadingAsync>d__3 <OpenLoadingAsync>d__;
		<OpenLoadingAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OpenLoadingAsync>d__.<>1__state = -1;
		<OpenLoadingAsync>d__.<>t__builder.Start<LoadMapController.<OpenLoadingAsync>d__3>(ref <OpenLoadingAsync>d__);
		return <OpenLoadingAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601C4ED RID: 115949 RVA: 0x008782F4 File Offset: 0x008764F4
	private UniTask CheckQuestResource()
	{
		LoadMapController.<CheckQuestResource>d__4 <CheckQuestResource>d__;
		<CheckQuestResource>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CheckQuestResource>d__.<>1__state = -1;
		<CheckQuestResource>d__.<>t__builder.Start<LoadMapController.<CheckQuestResource>d__4>(ref <CheckQuestResource>d__);
		return <CheckQuestResource>d__.<>t__builder.Task;
	}

	// Token: 0x0601C4EE RID: 115950 RVA: 0x0087832F File Offset: 0x0087652F
	private void DisableWorldPartition()
	{
		ControllerBase<GameModeController>.Instance.InitStreamingSources();
		ModelBase<GameModeModel>.Instance.DisableStreamingSources();
	}

	// Token: 0x0601C4EF RID: 115951 RVA: 0x00878348 File Offset: 0x00876548
	private void SetAlwaysLoadActorsEnable(bool enableActor)
	{
		UWorld world = GlobalData.World.GetWorld();
		if (world != null && world.IsValid())
		{
			if (enableActor)
			{
				UKuroLevelPlayLibrary.FakeAddAlwaysLoadedActorsToWorld(world);
				return;
			}
			UKuroLevelPlayLibrary.FakeRemoveAlwaysLoadedActorsFromWorld(world);
		}
	}

	// Token: 0x0601C4F0 RID: 115952 RVA: 0x0087837C File Offset: 0x0087657C
	private void PreLoadLevels()
	{
		Singleton<EventSystem>.Instance.Emit(EEventName.BeforeLoadMap);
		Singleton<LoadModeManager>.Instance.SetLoadModeByReason(ELoadMode.Loading, ELoadModeReason.PreLoadLevelInstance);
		AActor.SetKuroNetMode(EKuroNetMode.KNM_Net);
		Singleton<UiManager>.Instance.LockOpen();
		Singleton<Net>.Instance.PauseAllNotifyCallback();
		ModelBase<GameModeModel>.Instance.AddLoadMapHandle("LoadMapController.WorldPartitionLoadLevelInstance");
	}

	// Token: 0x0601C4F1 RID: 115953 RVA: 0x008783D0 File Offset: 0x008765D0
	private void PostLoadLevels()
	{
		Singleton<Net>.Instance.ResumeAllNotifyCallback();
		Singleton<UiManager>.Instance.UnLockOpen();
		LevelSequencePlayer.SetBanned(false);
		Singleton<LguiEventSystemManager>.Instance.RefreshCurrentInputModule();
		ControllerBase<LoadingController>.Instance.SetProgress(30, null, 1, false, true);
	}

	// Token: 0x0601C4F2 RID: 115954 RVA: 0x00878408 File Offset: 0x00876608
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	public UniTask<ULevelStreamingDynamic> LoadLevelInstanceAsync(string mapPath, bool shouldBeLoaded, bool shouldBeVisible)
	{
		LoadMapController.<LoadLevelInstanceAsync>d__9 <LoadLevelInstanceAsync>d__;
		<LoadLevelInstanceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<ULevelStreamingDynamic>.Create();
		<LoadLevelInstanceAsync>d__.mapPath = mapPath;
		<LoadLevelInstanceAsync>d__.shouldBeVisible = shouldBeVisible;
		<LoadLevelInstanceAsync>d__.<>1__state = -1;
		<LoadLevelInstanceAsync>d__.<>t__builder.Start<LoadMapController.<LoadLevelInstanceAsync>d__9>(ref <LoadLevelInstanceAsync>d__);
		return <LoadLevelInstanceAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601C4F3 RID: 115955 RVA: 0x00878454 File Offset: 0x00876654
	private UniTask LoadLevelsAsync()
	{
		LoadMapController.<LoadLevelsAsync>d__10 <LoadLevelsAsync>d__;
		<LoadLevelsAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<LoadLevelsAsync>d__.<>4__this = this;
		<LoadLevelsAsync>d__.<>1__state = -1;
		<LoadLevelsAsync>d__.<>t__builder.Start<LoadMapController.<LoadLevelsAsync>d__10>(ref <LoadLevelsAsync>d__);
		return <LoadLevelsAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601C4F4 RID: 115956 RVA: 0x00878498 File Offset: 0x00876698
	private UniTask ApplyMaterialParameterCollectionAsync(SceneInformation sceneInformation)
	{
		LoadMapController.<ApplyMaterialParameterCollectionAsync>d__11 <ApplyMaterialParameterCollectionAsync>d__;
		<ApplyMaterialParameterCollectionAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ApplyMaterialParameterCollectionAsync>d__.sceneInformation = sceneInformation;
		<ApplyMaterialParameterCollectionAsync>d__.<>1__state = -1;
		<ApplyMaterialParameterCollectionAsync>d__.<>t__builder.Start<LoadMapController.<ApplyMaterialParameterCollectionAsync>d__11>(ref <ApplyMaterialParameterCollectionAsync>d__);
		return <ApplyMaterialParameterCollectionAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601C4F5 RID: 115957 RVA: 0x008784DC File Offset: 0x008766DC
	private UniTask CommonAndEntityPreloadAsync()
	{
		LoadMapController.<CommonAndEntityPreloadAsync>d__12 <CommonAndEntityPreloadAsync>d__;
		<CommonAndEntityPreloadAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CommonAndEntityPreloadAsync>d__.<>1__state = -1;
		<CommonAndEntityPreloadAsync>d__.<>t__builder.Start<LoadMapController.<CommonAndEntityPreloadAsync>d__12>(ref <CommonAndEntityPreloadAsync>d__);
		return <CommonAndEntityPreloadAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601C4F6 RID: 115958 RVA: 0x00878518 File Offset: 0x00876718
	private UniTask LoadBattleViewAsync()
	{
		LoadMapController.<LoadBattleViewAsync>d__13 <LoadBattleViewAsync>d__;
		<LoadBattleViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<LoadBattleViewAsync>d__.<>1__state = -1;
		<LoadBattleViewAsync>d__.<>t__builder.Start<LoadMapController.<LoadBattleViewAsync>d__13>(ref <LoadBattleViewAsync>d__);
		return <LoadBattleViewAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601C4F7 RID: 115959 RVA: 0x00878554 File Offset: 0x00876754
	private UniTask ControllerPreloadAsync()
	{
		LoadMapController.<ControllerPreloadAsync>d__14 <ControllerPreloadAsync>d__;
		<ControllerPreloadAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ControllerPreloadAsync>d__.<>4__this = this;
		<ControllerPreloadAsync>d__.<>1__state = -1;
		<ControllerPreloadAsync>d__.<>t__builder.Start<LoadMapController.<ControllerPreloadAsync>d__14>(ref <ControllerPreloadAsync>d__);
		return <ControllerPreloadAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601C4F8 RID: 115960 RVA: 0x00878598 File Offset: 0x00876798
	private UniTask AfterJoinSceneAsync()
	{
		LoadMapController.<AfterJoinSceneAsync>d__15 <AfterJoinSceneAsync>d__;
		<AfterJoinSceneAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<AfterJoinSceneAsync>d__.<>1__state = -1;
		<AfterJoinSceneAsync>d__.<>t__builder.Start<LoadMapController.<AfterJoinSceneAsync>d__15>(ref <AfterJoinSceneAsync>d__);
		return <AfterJoinSceneAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601C4F9 RID: 115961 RVA: 0x008785D4 File Offset: 0x008767D4
	private UniTask LoadSubLevelsAsync(SceneInformation sceneInformation)
	{
		LoadMapController.<LoadSubLevelsAsync>d__16 <LoadSubLevelsAsync>d__;
		<LoadSubLevelsAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<LoadSubLevelsAsync>d__.sceneInformation = sceneInformation;
		<LoadSubLevelsAsync>d__.<>1__state = -1;
		<LoadSubLevelsAsync>d__.<>t__builder.Start<LoadMapController.<LoadSubLevelsAsync>d__16>(ref <LoadSubLevelsAsync>d__);
		return <LoadSubLevelsAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601C4FA RID: 115962 RVA: 0x00878618 File Offset: 0x00876818
	private UniTask VoxelStreamingAsync()
	{
		LoadMapController.<VoxelStreamingAsync>d__17 <VoxelStreamingAsync>d__;
		<VoxelStreamingAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<VoxelStreamingAsync>d__.<>1__state = -1;
		<VoxelStreamingAsync>d__.<>t__builder.Start<LoadMapController.<VoxelStreamingAsync>d__17>(ref <VoxelStreamingAsync>d__);
		return <VoxelStreamingAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601C4FB RID: 115963 RVA: 0x00878654 File Offset: 0x00876854
	private UniTask StreamingAsync()
	{
		LoadMapController.<StreamingAsync>d__18 <StreamingAsync>d__;
		<StreamingAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<StreamingAsync>d__.<>1__state = -1;
		<StreamingAsync>d__.<>t__builder.Start<LoadMapController.<StreamingAsync>d__18>(ref <StreamingAsync>d__);
		return <StreamingAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601C4FC RID: 115964 RVA: 0x00878690 File Offset: 0x00876890
	private UniTask CreateEntityAsync()
	{
		LoadMapController.<CreateEntityAsync>d__19 <CreateEntityAsync>d__;
		<CreateEntityAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateEntityAsync>d__.<>1__state = -1;
		<CreateEntityAsync>d__.<>t__builder.Start<LoadMapController.<CreateEntityAsync>d__19>(ref <CreateEntityAsync>d__);
		return <CreateEntityAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601C4FD RID: 115965 RVA: 0x008786CC File Offset: 0x008768CC
	private UniTask RenderAssetStreamingAsync()
	{
		LoadMapController.<RenderAssetStreamingAsync>d__20 <RenderAssetStreamingAsync>d__;
		<RenderAssetStreamingAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RenderAssetStreamingAsync>d__.<>1__state = -1;
		<RenderAssetStreamingAsync>d__.<>t__builder.Start<LoadMapController.<RenderAssetStreamingAsync>d__20>(ref <RenderAssetStreamingAsync>d__);
		return <RenderAssetStreamingAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601C4FE RID: 115966 RVA: 0x00878708 File Offset: 0x00876908
	private UniTask WorldDoneAsync(bool isSeamlessTravel)
	{
		LoadMapController.<WorldDoneAsync>d__21 <WorldDoneAsync>d__;
		<WorldDoneAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<WorldDoneAsync>d__.isSeamlessTravel = isSeamlessTravel;
		<WorldDoneAsync>d__.<>1__state = -1;
		<WorldDoneAsync>d__.<>t__builder.Start<LoadMapController.<WorldDoneAsync>d__21>(ref <WorldDoneAsync>d__);
		return <WorldDoneAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601C4FF RID: 115967 RVA: 0x0087874C File Offset: 0x0087694C
	private UniTask LoadEndAsync(string sceneId)
	{
		LoadMapController.<LoadEndAsync>d__22 <LoadEndAsync>d__;
		<LoadEndAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<LoadEndAsync>d__.sceneId = sceneId;
		<LoadEndAsync>d__.<>1__state = -1;
		<LoadEndAsync>d__.<>t__builder.Start<LoadMapController.<LoadEndAsync>d__22>(ref <LoadEndAsync>d__);
		return <LoadEndAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601C500 RID: 115968 RVA: 0x00878790 File Offset: 0x00876990
	public UniTask Load(SceneInformation sceneInformation)
	{
		LoadMapController.<Load>d__23 <Load>d__;
		<Load>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Load>d__.<>4__this = this;
		<Load>d__.sceneInformation = sceneInformation;
		<Load>d__.<>1__state = -1;
		<Load>d__.<>t__builder.Start<LoadMapController.<Load>d__23>(ref <Load>d__);
		return <Load>d__.<>t__builder.Task;
	}
}
