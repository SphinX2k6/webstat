using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.TDConfigMgr.Action;
using AkiClient.Game.Aki.Data.Sequence.Struct;
using AkiClient.Game.Aki.Sequence.Manager;
using CSharpScript.Game.LevelGamePlay.GravityFlip;
using CSharpScript.Game.LevelGamePlay.ItemInspect;
using CSharpScript.Game.Module.Plot;
using CSharpScript.Game.Module.Plot.Flow;
using CSharpScript.Game.Module.Plot.PlotView;
using CSharpScript.Game.Module.Plot.Sequence;
using CSharpScript.Game.NewWorld.SceneItem;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x0200297C RID: 10620
[UClass("/Game/Aki/TypeScript/Game/Module/Sequence/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Module/Sequence/PlotBlueprintFunctionLibrary.PlotBlueprintFunctionLibrary_C")]
public class PlotBlueprintFunctionLibrary : UBlueprintFunctionLibrary, IUnrealUObject, IUnrealObject
{
	// Token: 0x060151BC RID: 86460 RVA: 0x005D6FD4 File Offset: 0x005D51D4
	[UFunction(EFunctionFlags.FUNC_None)]
	public static bool IsInSequence()
	{
		if (ModelBase<PlotModel>.Instance.IsInPlot)
		{
			EPlotLevel? plotLevel = ModelBase<PlotModel>.Instance.PlotConfig.PlotLevel;
			EPlotLevel eplotLevel = EPlotLevel.LevelA;
			return (plotLevel.GetValueOrDefault() == eplotLevel & plotLevel != null) || ModelBase<PlotModel>.Instance.PlotConfig.PlotLevel.GetValueOrDefault() == EPlotLevel.LevelB;
		}
		return false;
	}

	// Token: 0x060151BD RID: 86461 RVA: 0x005D702E File Offset: 0x005D522E
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SkipCurrentSequence()
	{
	}

	// Token: 0x060151BE RID: 86462 RVA: 0x005D7030 File Offset: 0x005D5230
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void PauseSequence()
	{
	}

	// Token: 0x060151BF RID: 86463 RVA: 0x005D7032 File Offset: 0x005D5232
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void ResumeSequence()
	{
	}

	// Token: 0x060151C0 RID: 86464 RVA: 0x005D7034 File Offset: 0x005D5234
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void UseEnterMoveMode(AActor inCharacter)
	{
	}

	// Token: 0x060151C1 RID: 86465 RVA: 0x005D7038 File Offset: 0x005D5238
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void StartPlotTs(string inRes)
	{
		if (ModelBase<PlotModel>.Instance.IsInPlot && ModelBase<PlotModel>.Instance.PlotConfig.PlotLevel.GetValueOrDefault() != EPlotLevel.LevelD)
		{
			Singleton<global::Log>.Instance.Info(ELogModule.Plot, ELogAuthor.CFT, "当前正在播放其他剧情，不允许打断", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		ControllerBase<FlowController>.Instance.StartFlowByRes(inRes);
	}

	// Token: 0x060151C2 RID: 86466 RVA: 0x005D7090 File Offset: 0x005D5290
	[UFunction(EFunctionFlags.FUNC_None)]
	public static bool IsInPerformingPlot()
	{
		return ModelBase<PlotModel>.Instance != null && (ModelBase<PlotModel>.Instance.IsInInteraction || (ModelBase<PlotModel>.Instance.IsInPlot && ModelBase<PlotModel>.Instance.PlotConfig.PlotLevel.GetValueOrDefault() != EPlotLevel.LevelD));
	}

	// Token: 0x060151C3 RID: 86467 RVA: 0x005D70DC File Offset: 0x005D52DC
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void TriggerBlackSequence()
	{
		ControllerBase<PlotController>.Instance.TriggerBlackSequence();
	}

	// Token: 0x060151C4 RID: 86468 RVA: 0x005D70E8 File Offset: 0x005D52E8
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void ChangePlotWeather(int weatherId, bool isInherit, float tweenTime)
	{
		ControllerBase<PlotController>.Instance.ChangeWeather(weatherId, isInherit, tweenTime);
	}

	// Token: 0x060151C5 RID: 86469 RVA: 0x005D70F7 File Offset: 0x005D52F7
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void ChangePlotTimeOfDay(bool isInherit, int startSecond, int endSecond, int tweenFrame)
	{
		ControllerBase<PlotController>.Instance.ChangePlotTimeOfDay(isInherit, startSecond, endSecond, tweenFrame / 30);
	}

	// Token: 0x060151C6 RID: 86470 RVA: 0x005D710A File Offset: 0x005D530A
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void ExecuteSequenceEvents(string key)
	{
		ControllerBase<SequenceController>.Instance.RunSequenceFrameEvents(key);
	}

	// Token: 0x060151C7 RID: 86471 RVA: 0x005D7118 File Offset: 0x005D5318
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public unsafe static void ExecuteEntitySequenceEvents(string key, int entityId)
	{
		EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(entityId);
		if (entityByPbDataId == null || !entityByPbDataId.IsInit)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.LevelPlay;
			ELogAuthor author = ELogAuthor.FZX;
			string message = "场景引用Sequence帧事件找不到实体";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("key", key);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("id", entityId);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		WorldEntity entity = entityByPbDataId.Entity;
		if (entity == null)
		{
			return;
		}
		LevelSequenceFrameEventComponent component = entity.GetComponent<LevelSequenceFrameEventComponent>();
		if (component == null)
		{
			return;
		}
		component.ExecuteEvent(key);
	}

	// Token: 0x060151C8 RID: 86472 RVA: 0x005D71B6 File Offset: 0x005D53B6
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void TriggerCutChange()
	{
		ControllerBase<SequenceController>.Instance.TriggerCutChange();
	}

	// Token: 0x060151C9 RID: 86473 RVA: 0x005D71C2 File Offset: 0x005D53C2
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void OpenChapterUi(int chapterState, int chapterId)
	{
		Singleton<GeneralLogicTreeUtil>.Instance.OpenChapterViewV2(chapterState, chapterId, true, null);
	}

	// Token: 0x060151CA RID: 86474 RVA: 0x005D71D2 File Offset: 0x005D53D2
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void ShowLogo(float time)
	{
		ControllerBase<SequenceController>.Instance.ShowLogo(time);
	}

	// Token: 0x060151CB RID: 86475 RVA: 0x005D71E0 File Offset: 0x005D53E0
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void OpenUiView(string maleAssetName, string femaleAssetName, string maleSpineName, string femaleSpineName, bool needLoop = true, bool useFullscreenAdaptAnchor = false)
	{
		int sex = ModelBase<WorldLevelModel>.Instance.Sex;
		if (sex == 0)
		{
			ControllerBase<SequenceController>.Instance.OpenUiView(femaleAssetName, femaleSpineName, needLoop, useFullscreenAdaptAnchor);
			return;
		}
		if (sex != 1)
		{
			return;
		}
		ControllerBase<SequenceController>.Instance.OpenUiView(maleAssetName, maleSpineName, needLoop, useFullscreenAdaptAnchor);
	}

	// Token: 0x060151CC RID: 86476 RVA: 0x005D7224 File Offset: 0x005D5424
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void OpenUiViewInArray(string maleAssetName, string femaleAssetName, ref TArray<SpineThingsInfo> maleSpineArray, ref TArray<SpineThingsInfo> femaleSpineArray, bool useFullscreenAdaptAnchor = false)
	{
		int sex = ModelBase<WorldLevelModel>.Instance.Sex;
		if (sex == 0)
		{
			TArray<SpineThingsInfo> spineArray = femaleSpineArray;
			ControllerBase<SequenceController>.Instance.OpenUiViewForArray(femaleAssetName, spineArray, useFullscreenAdaptAnchor);
			return;
		}
		if (sex != 1)
		{
			return;
		}
		TArray<SpineThingsInfo> spineArray2 = maleSpineArray;
		ControllerBase<SequenceController>.Instance.OpenUiViewForArray(maleAssetName, spineArray2, useFullscreenAdaptAnchor);
	}

	// Token: 0x060151CD RID: 86477 RVA: 0x005D7267 File Offset: 0x005D5467
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void PlayUiLevelSequence(string seqName)
	{
		ControllerBase<SequenceController>.Instance.PlayUiLevelSequence(seqName);
	}

	// Token: 0x060151CE RID: 86478 RVA: 0x005D7274 File Offset: 0x005D5474
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void CloseUiView()
	{
		ControllerBase<SequenceController>.Instance.CloseUiView();
	}

	// Token: 0x060151CF RID: 86479 RVA: 0x005D7280 File Offset: 0x005D5480
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void PlaySpineAnim(string spineName, bool needLoop = true)
	{
		ControllerBase<SequenceController>.Instance.PlaySpineAnim(spineName, needLoop);
	}

	// Token: 0x060151D0 RID: 86480 RVA: 0x005D7290 File Offset: 0x005D5490
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void PlaySpineAnimForGender(string maleSpineName, string femaleSpineName, bool needLoop = true)
	{
		int sex = ModelBase<WorldLevelModel>.Instance.Sex;
		if (sex == 0)
		{
			ControllerBase<SequenceController>.Instance.PlaySpineAnim(femaleSpineName, needLoop);
			return;
		}
		if (sex != 1)
		{
			return;
		}
		ControllerBase<SequenceController>.Instance.PlaySpineAnim(maleSpineName, needLoop);
	}

	// Token: 0x060151D1 RID: 86481 RVA: 0x005D72CC File Offset: 0x005D54CC
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void PlaySpineAnimForGenderInArray(ref TArray<SpineThingsInfo> maleSpineArray, ref TArray<SpineThingsInfo> femaleSpineArray)
	{
		int sex = ModelBase<WorldLevelModel>.Instance.Sex;
		if (sex == 0)
		{
			TArray<SpineThingsInfo> spineArray = femaleSpineArray;
			ControllerBase<SequenceController>.Instance.PlaySpineAnimInArray(spineArray);
			return;
		}
		if (sex != 1)
		{
			return;
		}
		TArray<SpineThingsInfo> spineArray2 = maleSpineArray;
		ControllerBase<SequenceController>.Instance.PlaySpineAnimInArray(spineArray2);
	}

	// Token: 0x060151D2 RID: 86482 RVA: 0x005D7309 File Offset: 0x005D5509
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void CloseSpineAnim(string spineName)
	{
		ControllerBase<SequenceController>.Instance.CloseSpineAnim(spineName);
	}

	// Token: 0x060151D3 RID: 86483 RVA: 0x005D7318 File Offset: 0x005D5518
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void CloseSpineAnimInArray(ref TArray<string> spineArray)
	{
		TArray<string> spineArray2 = spineArray;
		ControllerBase<SequenceController>.Instance.CloseSpineAnimInArray(spineArray2);
	}

	// Token: 0x060151D4 RID: 86484 RVA: 0x005D7334 File Offset: 0x005D5534
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void AdditionSeqPlay(ULevelSequence levelSequence, FName componentName, FName boneName, float frame)
	{
		if (levelSequence == null)
		{
			Singleton<global::Log>.Instance.Info(ELogModule.Level, ELogAuthor.JYS, "AdditionSeqPlay 没找到LevelSequence", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		ControllerBase<SequenceController>.Instance.AdditionSeqPlay(levelSequence, componentName, boneName, (int)frame);
	}

	// Token: 0x060151D5 RID: 86485 RVA: 0x005D7370 File Offset: 0x005D5570
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void AdditionSeqEnd()
	{
		ControllerBase<SequenceController>.Instance.AdditionSeqEnd();
	}

	// Token: 0x060151D6 RID: 86486 RVA: 0x005D737C File Offset: 0x005D557C
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void OpenMultiTextCaption(string textId, float duration)
	{
		if (string.IsNullOrEmpty(textId))
		{
			Singleton<global::Log>.Instance.Warn(ELogModule.Plot, ELogAuthor.HYF, "OpenMultiTextCaption未配置textId，不打开字幕", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (duration <= 0f)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Plot;
			ELogAuthor author = ELogAuthor.HYF;
			string message = "OpenMultiTextCaption未配置有效duration，不打开字幕";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("duration", duration);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		PlotWordArtCaptionViewParams param = new PlotWordArtCaptionViewParams
		{
			TidSubtitleText = textId
		};
		Singleton<UiManager>.Instance.OpenViewByPlot(EUiViewName.PlotWordArtCaptionView, param, delegate(bool success, int viewId)
		{
			if (!success)
			{
				return;
			}
			TimerSystem.Instance.Delay(delegate(float _)
			{
				Singleton<UiManager>.Instance.CloseViewById(viewId, null);
			}, duration * 1000f, null, null, true, 1f);
		});
	}

	// Token: 0x060151D7 RID: 86487 RVA: 0x005D7423 File Offset: 0x005D5623
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void ShowNameInput()
	{
		CreateCharacterController.TriggerInputName();
	}

	// Token: 0x060151D8 RID: 86488 RVA: 0x005D742A File Offset: 0x005D562A
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void AddBurstEyeRenderingMaterial(bool isBoy)
	{
		CreateCharacterController.AddBurstEyeRenderingMaterial(isBoy);
	}

	// Token: 0x060151D9 RID: 86489 RVA: 0x005D7432 File Offset: 0x005D5632
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void RemoveBurstEyeRenderingMaterial(bool isBoy)
	{
		CreateCharacterController.RemoveBurstEyeRenderingMaterial(isBoy);
	}

	// Token: 0x060151DA RID: 86490 RVA: 0x005D743A File Offset: 0x005D563A
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void AddInteractTagToInteractingGravityMachine()
	{
		SceneItemGravityFlipComponent gravityFlipComp = ModelBase<GravityFlipModel>.Instance.GravityFlipComp;
		if (gravityFlipComp == null)
		{
			return;
		}
		gravityFlipComp.AddInteractTag();
	}

	// Token: 0x060151DB RID: 86491 RVA: 0x005D7450 File Offset: 0x005D5650
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void RemoveInteractTagFromInteractingGravityMachine()
	{
		SceneItemGravityFlipComponent gravityFlipComp = ModelBase<GravityFlipModel>.Instance.GravityFlipComp;
		if (gravityFlipComp == null)
		{
			return;
		}
		gravityFlipComp.RemoveInteractTag();
	}

	// Token: 0x060151DC RID: 86492 RVA: 0x005D7468 File Offset: 0x005D5668
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void TriggerTagToInteractingGravityMachine(FGameplayTag tag)
	{
		Entity gravityFlipEntity = ModelBase<GravityFlipModel>.Instance.GravityFlipEntity;
		BaseTagComponent baseTagComponent = (gravityFlipEntity != null) ? gravityFlipEntity.GetComponent<BaseTagComponent>() : null;
		int tagIdByName = GameplayTagUtils.GetTagIdByName(tag.TagName.ToString());
		if (baseTagComponent != null && baseTagComponent.HasTag(tagIdByName) && baseTagComponent != null)
		{
			baseTagComponent.RemoveTag(new int?(tagIdByName));
		}
		if (baseTagComponent != null)
		{
			baseTagComponent.AddTag(new int?(tagIdByName));
		}
	}

	// Token: 0x060151DD RID: 86493 RVA: 0x005D74D0 File Offset: 0x005D56D0
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void ShowBgIcon(bool bShow, UTexture2D texture, BP_KuroMasterSeqEvent_C obj)
	{
		ControllerBase<PlotController>.Instance.PlotViewManager.RunWithPlotSubtitleView("ShowBgIcon", delegate(PlotSubtitleView view)
		{
			view.SetIconBySequence(bShow, texture, obj);
			return UniTask.CompletedTask;
		}, null);
	}

	// Token: 0x060151DE RID: 86494 RVA: 0x005D751C File Offset: 0x005D571C
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void BindItemInspectActor(FMovieSceneObjectBindingID binding)
	{
		ALevelSequenceActor curLevelSeqActor = ModelBase<SequenceModel>.Instance.CurLevelSeqActor;
		if (curLevelSeqActor == null || !curLevelSeqActor.IsValid())
		{
			return;
		}
		AActor spawnedActorByGuid = curLevelSeqActor.SequencePlayer.GetSpawnedActorByGuid(binding.Guid, true);
		if (spawnedActorByGuid != null && spawnedActorByGuid.IsValid())
		{
			ControllerBase<ItemInspectController>.Instance.BindItemInspectActor(spawnedActorByGuid);
		}
	}

	// Token: 0x060151DF RID: 86495 RVA: 0x005D756F File Offset: 0x005D576F
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void EnablePlotInteract(bool bEnable, string skipLock = "")
	{
		ControllerBase<PlotController>.Instance.PlotViewManager.EnableInteractPlot(bEnable, new bool?(false), "Blueprint", (skipLock == "") ? null : skipLock);
	}

	// Token: 0x060151E0 RID: 86496 RVA: 0x005D759D File Offset: 0x005D579D
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void EnableCameraShake(bool bEnable, TSoftClassPtr<UMatineeCameraShake> cameraShakePtr)
	{
		ControllerBase<SequenceController>.Instance.EnableCameraShake(bEnable, cameraShakePtr);
	}

	// Token: 0x060151E1 RID: 86497 RVA: 0x005D75AC File Offset: 0x005D57AC
	[UFunction(EFunctionFlags.FUNC_None)]
	public static bool NeedFlowAdaption()
	{
		return Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.FlowAdaptation, true, true) != null;
	}

	// Token: 0x060151E2 RID: 86498 RVA: 0x005D75D2 File Offset: 0x005D57D2
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void OpenCaptionImage(string uiPrefabId, float duration, string uiStartAnimName, string uiEndAnimName)
	{
		ControllerBase<PlotCaptionImageController>.Instance.OpenAsync(uiPrefabId, duration, new IUiAnimConfig
		{
			UiStartAnimName = uiStartAnimName,
			UiEndAnimName = uiEndAnimName
		}).Forget();
	}

	// Token: 0x060151E3 RID: 86499 RVA: 0x005D75F8 File Offset: 0x005D57F8
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (PlotBlueprintFunctionLibrary._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Module/Sequence/PlotBlueprintFunctionLibrary.PlotBlueprintFunctionLibrary_C");
		}
		return PlotBlueprintFunctionLibrary._ClassPtr;
	}

	// Token: 0x060151E4 RID: 86500 RVA: 0x005D761C File Offset: 0x005D581C
	public PlotBlueprintFunctionLibrary() : this(BuiltinUtils.AllocNativeUObject(PlotBlueprintFunctionLibrary.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060151E5 RID: 86501 RVA: 0x005D7644 File Offset: 0x005D5844
	[NullableContext(1)]
	public PlotBlueprintFunctionLibrary(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PlotBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060151E6 RID: 86502 RVA: 0x005D7677 File Offset: 0x005D5877
	protected PlotBlueprintFunctionLibrary(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060151E7 RID: 86503 RVA: 0x005D7680 File Offset: 0x005D5880
	protected unsafe static void __CPPCALL_IsInSequence_Implementation(PlotBlueprintFunctionLibrary.__IsInSequence_FunctionParams* __Params)
	{
		__Params->__Result = PlotBlueprintFunctionLibrary.IsInSequence();
	}

	// Token: 0x060151E8 RID: 86504 RVA: 0x005D768D File Offset: 0x005D588D
	protected unsafe static void __CPPCALL_SkipCurrentSequence_Implementation(PlotBlueprintFunctionLibrary.__SkipCurrentSequence_FunctionParams* __Params)
	{
		PlotBlueprintFunctionLibrary.SkipCurrentSequence();
	}

	// Token: 0x060151E9 RID: 86505 RVA: 0x005D7694 File Offset: 0x005D5894
	protected unsafe static void __CPPCALL_PauseSequence_Implementation(PlotBlueprintFunctionLibrary.__PauseSequence_FunctionParams* __Params)
	{
		PlotBlueprintFunctionLibrary.PauseSequence();
	}

	// Token: 0x060151EA RID: 86506 RVA: 0x005D769B File Offset: 0x005D589B
	protected unsafe static void __CPPCALL_ResumeSequence_Implementation(PlotBlueprintFunctionLibrary.__ResumeSequence_FunctionParams* __Params)
	{
		PlotBlueprintFunctionLibrary.ResumeSequence();
	}

	// Token: 0x060151EB RID: 86507 RVA: 0x005D76A2 File Offset: 0x005D58A2
	protected unsafe static void __CPPCALL_UseEnterMoveMode_Implementation(PlotBlueprintFunctionLibrary.__UseEnterMoveMode_FunctionParams* __Params)
	{
		PlotBlueprintFunctionLibrary.UseEnterMoveMode(BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(__Params->inCharacter));
	}

	// Token: 0x060151EC RID: 86508 RVA: 0x005D76B4 File Offset: 0x005D58B4
	protected unsafe static void __CPPCALL_StartPlotTs_Implementation(PlotBlueprintFunctionLibrary.__StartPlotTs_FunctionParams* __Params)
	{
		PlotBlueprintFunctionLibrary.StartPlotTs(FString.ToString((void*)(&__Params->inRes)));
	}

	// Token: 0x060151ED RID: 86509 RVA: 0x005D76C7 File Offset: 0x005D58C7
	protected unsafe static void __CPPCALL_IsInPerformingPlot_Implementation(PlotBlueprintFunctionLibrary.__IsInPerformingPlot_FunctionParams* __Params)
	{
		__Params->__Result = PlotBlueprintFunctionLibrary.IsInPerformingPlot();
	}

	// Token: 0x060151EE RID: 86510 RVA: 0x005D76D4 File Offset: 0x005D58D4
	protected unsafe static void __CPPCALL_TriggerBlackSequence_Implementation(PlotBlueprintFunctionLibrary.__TriggerBlackSequence_FunctionParams* __Params)
	{
		PlotBlueprintFunctionLibrary.TriggerBlackSequence();
	}

	// Token: 0x060151EF RID: 86511 RVA: 0x005D76DB File Offset: 0x005D58DB
	protected unsafe static void __CPPCALL_ChangePlotWeather_Implementation(PlotBlueprintFunctionLibrary.__ChangePlotWeather_FunctionParams* __Params)
	{
		PlotBlueprintFunctionLibrary.ChangePlotWeather(__Params->weatherId, __Params->isInherit, __Params->tweenTime);
	}

	// Token: 0x060151F0 RID: 86512 RVA: 0x005D76F4 File Offset: 0x005D58F4
	protected unsafe static void __CPPCALL_ChangePlotTimeOfDay_Implementation(PlotBlueprintFunctionLibrary.__ChangePlotTimeOfDay_FunctionParams* __Params)
	{
		PlotBlueprintFunctionLibrary.ChangePlotTimeOfDay(__Params->isInherit, __Params->startSecond, __Params->endSecond, __Params->tweenFrame);
	}

	// Token: 0x060151F1 RID: 86513 RVA: 0x005D7713 File Offset: 0x005D5913
	protected unsafe static void __CPPCALL_ExecuteSequenceEvents_Implementation(PlotBlueprintFunctionLibrary.__ExecuteSequenceEvents_FunctionParams* __Params)
	{
		PlotBlueprintFunctionLibrary.ExecuteSequenceEvents(FString.ToString((void*)(&__Params->key)));
	}

	// Token: 0x060151F2 RID: 86514 RVA: 0x005D7726 File Offset: 0x005D5926
	protected unsafe static void __CPPCALL_ExecuteEntitySequenceEvents_Implementation(PlotBlueprintFunctionLibrary.__ExecuteEntitySequenceEvents_FunctionParams* __Params)
	{
		PlotBlueprintFunctionLibrary.ExecuteEntitySequenceEvents(FString.ToString((void*)(&__Params->key)), __Params->entityId);
	}

	// Token: 0x060151F3 RID: 86515 RVA: 0x005D773F File Offset: 0x005D593F
	protected unsafe static void __CPPCALL_TriggerCutChange_Implementation(PlotBlueprintFunctionLibrary.__TriggerCutChange_FunctionParams* __Params)
	{
		PlotBlueprintFunctionLibrary.TriggerCutChange();
	}

	// Token: 0x060151F4 RID: 86516 RVA: 0x005D7746 File Offset: 0x005D5946
	protected unsafe static void __CPPCALL_OpenChapterUi_Implementation(PlotBlueprintFunctionLibrary.__OpenChapterUi_FunctionParams* __Params)
	{
		PlotBlueprintFunctionLibrary.OpenChapterUi(__Params->chapterState, __Params->chapterId);
	}

	// Token: 0x060151F5 RID: 86517 RVA: 0x005D7759 File Offset: 0x005D5959
	protected unsafe static void __CPPCALL_ShowLogo_Implementation(PlotBlueprintFunctionLibrary.__ShowLogo_FunctionParams* __Params)
	{
		PlotBlueprintFunctionLibrary.ShowLogo(__Params->time);
	}

	// Token: 0x060151F6 RID: 86518 RVA: 0x005D7768 File Offset: 0x005D5968
	protected unsafe static void __CPPCALL_OpenUiView_Implementation(PlotBlueprintFunctionLibrary.__OpenUiView_FunctionParams* __Params)
	{
		string maleAssetName = FString.ToString((void*)(&__Params->maleAssetName));
		string femaleAssetName = FString.ToString((void*)(&__Params->femaleAssetName));
		string maleSpineName = FString.ToString((void*)(&__Params->maleSpineName));
		string femaleSpineName = FString.ToString((void*)(&__Params->femaleSpineName));
		PlotBlueprintFunctionLibrary.OpenUiView(maleAssetName, femaleAssetName, maleSpineName, femaleSpineName, __Params->needLoop, __Params->useFullscreenAdaptAnchor);
	}

	// Token: 0x060151F7 RID: 86519 RVA: 0x005D77BC File Offset: 0x005D59BC
	protected unsafe static void __CPPCALL_OpenUiViewInArray_Implementation(PlotBlueprintFunctionLibrary.__OpenUiViewInArray_FunctionParams* __Params)
	{
		string maleAssetName = FString.ToString((void*)(&__Params->maleAssetName));
		string femaleAssetName = FString.ToString((void*)(&__Params->femaleAssetName));
		TArray<SpineThingsInfo> tarray = new TArray<SpineThingsInfo>(&__Params->maleSpineArray, true, true);
		TArray<SpineThingsInfo> tarray2 = new TArray<SpineThingsInfo>(&__Params->femaleSpineArray, true, true);
		PlotBlueprintFunctionLibrary.OpenUiViewInArray(maleAssetName, femaleAssetName, ref tarray, ref tarray2, __Params->useFullscreenAdaptAnchor);
		if (tarray != null)
		{
			tarray.CopyTo(&__Params->maleSpineArray, default(UScriptStructStackOnlyPtr));
		}
		if (tarray2 != null)
		{
			tarray2.CopyTo(&__Params->femaleSpineArray, default(UScriptStructStackOnlyPtr));
		}
	}

	// Token: 0x060151F8 RID: 86520 RVA: 0x005D7842 File Offset: 0x005D5A42
	protected unsafe static void __CPPCALL_PlayUiLevelSequence_Implementation(PlotBlueprintFunctionLibrary.__PlayUiLevelSequence_FunctionParams* __Params)
	{
		PlotBlueprintFunctionLibrary.PlayUiLevelSequence(FString.ToString((void*)(&__Params->seqName)));
	}

	// Token: 0x060151F9 RID: 86521 RVA: 0x005D7855 File Offset: 0x005D5A55
	protected unsafe static void __CPPCALL_CloseUiView_Implementation(PlotBlueprintFunctionLibrary.__CloseUiView_FunctionParams* __Params)
	{
		PlotBlueprintFunctionLibrary.CloseUiView();
	}

	// Token: 0x060151FA RID: 86522 RVA: 0x005D785C File Offset: 0x005D5A5C
	protected unsafe static void __CPPCALL_PlaySpineAnim_Implementation(PlotBlueprintFunctionLibrary.__PlaySpineAnim_FunctionParams* __Params)
	{
		PlotBlueprintFunctionLibrary.PlaySpineAnim(FString.ToString((void*)(&__Params->spineName)), __Params->needLoop);
	}

	// Token: 0x060151FB RID: 86523 RVA: 0x005D7878 File Offset: 0x005D5A78
	protected unsafe static void __CPPCALL_PlaySpineAnimForGender_Implementation(PlotBlueprintFunctionLibrary.__PlaySpineAnimForGender_FunctionParams* __Params)
	{
		string maleSpineName = FString.ToString((void*)(&__Params->maleSpineName));
		string femaleSpineName = FString.ToString((void*)(&__Params->femaleSpineName));
		PlotBlueprintFunctionLibrary.PlaySpineAnimForGender(maleSpineName, femaleSpineName, __Params->needLoop);
	}

	// Token: 0x060151FC RID: 86524 RVA: 0x005D78AC File Offset: 0x005D5AAC
	protected unsafe static void __CPPCALL_PlaySpineAnimForGenderInArray_Implementation(PlotBlueprintFunctionLibrary.__PlaySpineAnimForGenderInArray_FunctionParams* __Params)
	{
		TArray<SpineThingsInfo> tarray = new TArray<SpineThingsInfo>(&__Params->maleSpineArray, true, true);
		TArray<SpineThingsInfo> tarray2 = new TArray<SpineThingsInfo>(&__Params->femaleSpineArray, true, true);
		PlotBlueprintFunctionLibrary.PlaySpineAnimForGenderInArray(ref tarray, ref tarray2);
		if (tarray != null)
		{
			tarray.CopyTo(&__Params->maleSpineArray, default(UScriptStructStackOnlyPtr));
		}
		if (tarray2 != null)
		{
			tarray2.CopyTo(&__Params->femaleSpineArray, default(UScriptStructStackOnlyPtr));
		}
	}

	// Token: 0x060151FD RID: 86525 RVA: 0x005D7912 File Offset: 0x005D5B12
	protected unsafe static void __CPPCALL_CloseSpineAnim_Implementation(PlotBlueprintFunctionLibrary.__CloseSpineAnim_FunctionParams* __Params)
	{
		PlotBlueprintFunctionLibrary.CloseSpineAnim(FString.ToString((void*)(&__Params->spineName)));
	}

	// Token: 0x060151FE RID: 86526 RVA: 0x005D7928 File Offset: 0x005D5B28
	protected unsafe static void __CPPCALL_CloseSpineAnimInArray_Implementation(PlotBlueprintFunctionLibrary.__CloseSpineAnimInArray_FunctionParams* __Params)
	{
		TArray<string> tarray = new TArray<string>(&__Params->spineArray, true, true);
		PlotBlueprintFunctionLibrary.CloseSpineAnimInArray(ref tarray);
		if (tarray != null)
		{
			tarray.CopyTo(&__Params->spineArray, default(UScriptStructStackOnlyPtr));
		}
	}

	// Token: 0x060151FF RID: 86527 RVA: 0x005D7964 File Offset: 0x005D5B64
	protected unsafe static void __CPPCALL_AdditionSeqPlay_Implementation(PlotBlueprintFunctionLibrary.__AdditionSeqPlay_FunctionParams* __Params)
	{
		PlotBlueprintFunctionLibrary.AdditionSeqPlay(BuiltinUtils.GetOrCreateUObjectByNativePointer<ULevelSequence>(__Params->levelSequence), __Params->componentName, __Params->boneName, __Params->frame);
	}

	// Token: 0x06015200 RID: 86528 RVA: 0x005D7988 File Offset: 0x005D5B88
	protected unsafe static void __CPPCALL_AdditionSeqEnd_Implementation(PlotBlueprintFunctionLibrary.__AdditionSeqEnd_FunctionParams* __Params)
	{
		PlotBlueprintFunctionLibrary.AdditionSeqEnd();
	}

	// Token: 0x06015201 RID: 86529 RVA: 0x005D798F File Offset: 0x005D5B8F
	protected unsafe static void __CPPCALL_OpenMultiTextCaption_Implementation(PlotBlueprintFunctionLibrary.__OpenMultiTextCaption_FunctionParams* __Params)
	{
		PlotBlueprintFunctionLibrary.OpenMultiTextCaption(FString.ToString((void*)(&__Params->textId)), __Params->duration);
	}

	// Token: 0x06015202 RID: 86530 RVA: 0x005D79A8 File Offset: 0x005D5BA8
	protected unsafe static void __CPPCALL_ShowNameInput_Implementation(PlotBlueprintFunctionLibrary.__ShowNameInput_FunctionParams* __Params)
	{
		PlotBlueprintFunctionLibrary.ShowNameInput();
	}

	// Token: 0x06015203 RID: 86531 RVA: 0x005D79AF File Offset: 0x005D5BAF
	protected unsafe static void __CPPCALL_AddBurstEyeRenderingMaterial_Implementation(PlotBlueprintFunctionLibrary.__AddBurstEyeRenderingMaterial_FunctionParams* __Params)
	{
		PlotBlueprintFunctionLibrary.AddBurstEyeRenderingMaterial(__Params->isBoy);
	}

	// Token: 0x06015204 RID: 86532 RVA: 0x005D79BC File Offset: 0x005D5BBC
	protected unsafe static void __CPPCALL_RemoveBurstEyeRenderingMaterial_Implementation(PlotBlueprintFunctionLibrary.__RemoveBurstEyeRenderingMaterial_FunctionParams* __Params)
	{
		PlotBlueprintFunctionLibrary.RemoveBurstEyeRenderingMaterial(__Params->isBoy);
	}

	// Token: 0x06015205 RID: 86533 RVA: 0x005D79C9 File Offset: 0x005D5BC9
	protected unsafe static void __CPPCALL_AddInteractTagToInteractingGravityMachine_Implementation(PlotBlueprintFunctionLibrary.__AddInteractTagToInteractingGravityMachine_FunctionParams* __Params)
	{
		PlotBlueprintFunctionLibrary.AddInteractTagToInteractingGravityMachine();
	}

	// Token: 0x06015206 RID: 86534 RVA: 0x005D79D0 File Offset: 0x005D5BD0
	protected unsafe static void __CPPCALL_RemoveInteractTagFromInteractingGravityMachine_Implementation(PlotBlueprintFunctionLibrary.__RemoveInteractTagFromInteractingGravityMachine_FunctionParams* __Params)
	{
		PlotBlueprintFunctionLibrary.RemoveInteractTagFromInteractingGravityMachine();
	}

	// Token: 0x06015207 RID: 86535 RVA: 0x005D79D7 File Offset: 0x005D5BD7
	protected unsafe static void __CPPCALL_TriggerTagToInteractingGravityMachine_Implementation(PlotBlueprintFunctionLibrary.__TriggerTagToInteractingGravityMachine_FunctionParams* __Params)
	{
		PlotBlueprintFunctionLibrary.TriggerTagToInteractingGravityMachine(__Params->tag);
	}

	// Token: 0x06015208 RID: 86536 RVA: 0x005D79E4 File Offset: 0x005D5BE4
	protected unsafe static void __CPPCALL_ShowBgIcon_Implementation(PlotBlueprintFunctionLibrary.__ShowBgIcon_FunctionParams* __Params)
	{
		UTexture2D orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UTexture2D>(__Params->texture);
		BP_KuroMasterSeqEvent_C orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<BP_KuroMasterSeqEvent_C>(__Params->obj);
		PlotBlueprintFunctionLibrary.ShowBgIcon(__Params->bShow, orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06015209 RID: 86537 RVA: 0x005D7A16 File Offset: 0x005D5C16
	protected unsafe static void __CPPCALL_BindItemInspectActor_Implementation(PlotBlueprintFunctionLibrary.__BindItemInspectActor_FunctionParams* __Params)
	{
		PlotBlueprintFunctionLibrary.BindItemInspectActor(new FMovieSceneObjectBindingID(&__Params->binding, true, true));
	}

	// Token: 0x0601520A RID: 86538 RVA: 0x005D7A2C File Offset: 0x005D5C2C
	protected unsafe static void __CPPCALL_EnablePlotInteract_Implementation(PlotBlueprintFunctionLibrary.__EnablePlotInteract_FunctionParams_Hotfix* __Params)
	{
		string skipLock = FString.ToString((void*)(&__Params->skipLock));
		PlotBlueprintFunctionLibrary.EnablePlotInteract(__Params->bEnable, skipLock);
	}

	// Token: 0x0601520B RID: 86539 RVA: 0x005D7A54 File Offset: 0x005D5C54
	protected unsafe static void __CPPCALL_EnableCameraShake_Implementation(PlotBlueprintFunctionLibrary.__EnableCameraShake_FunctionParams* __Params)
	{
		TSoftClassPtr<UMatineeCameraShake> cameraShakePtr = new TSoftClassPtr<UMatineeCameraShake>(&__Params->cameraShakePtr, true, true);
		PlotBlueprintFunctionLibrary.EnableCameraShake(__Params->bEnable, cameraShakePtr);
	}

	// Token: 0x0601520C RID: 86540 RVA: 0x005D7A7C File Offset: 0x005D5C7C
	protected unsafe static void __CPPCALL_NeedFlowAdaption_Implementation(PlotBlueprintFunctionLibrary.__NeedFlowAdaption_FunctionParams* __Params)
	{
		__Params->__Result = PlotBlueprintFunctionLibrary.NeedFlowAdaption();
	}

	// Token: 0x0601520D RID: 86541 RVA: 0x005D7A8C File Offset: 0x005D5C8C
	protected unsafe static void __CPPCALL_OpenCaptionImage_Implementation(PlotBlueprintFunctionLibrary.__OpenCaptionImage_FunctionParams* __Params)
	{
		string uiPrefabId = FString.ToString((void*)(&__Params->uiPrefabId));
		string uiStartAnimName = FString.ToString((void*)(&__Params->uiStartAnimName));
		string uiEndAnimName = FString.ToString((void*)(&__Params->uiEndAnimName));
		PlotBlueprintFunctionLibrary.OpenCaptionImage(uiPrefabId, __Params->duration, uiStartAnimName, uiEndAnimName);
	}

	// Token: 0x0400A280 RID: 41600
	private const int FRAME_PER_SECOND = 30;

	// Token: 0x0400A281 RID: 41601
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Module/Sequence/PlotBlueprintFunctionLibrary.PlotBlueprintFunctionLibrary_C";

	// Token: 0x0400A282 RID: 41602
	private static IntPtr _ClassPtr;

	// Token: 0x0400A283 RID: 41603
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x02008C93 RID: 35987
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __IsInSequence_FunctionParams
	{
		// Token: 0x0402F51E RID: 193822
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x0402F51F RID: 193823
		[FieldOffset(8)]
		public bool __Result;
	}

	// Token: 0x02008C94 RID: 35988
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __SkipCurrentSequence_FunctionParams
	{
		// Token: 0x0402F520 RID: 193824
		[FieldOffset(0)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02008C95 RID: 35989
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __PauseSequence_FunctionParams
	{
		// Token: 0x0402F521 RID: 193825
		[FieldOffset(0)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02008C96 RID: 35990
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __ResumeSequence_FunctionParams
	{
		// Token: 0x0402F522 RID: 193826
		[FieldOffset(0)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02008C97 RID: 35991
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __UseEnterMoveMode_FunctionParams
	{
		// Token: 0x0402F523 RID: 193827
		[FieldOffset(0)]
		public IntPtr inCharacter;

		// Token: 0x0402F524 RID: 193828
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02008C98 RID: 35992
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __StartPlotTs_FunctionParams
	{
		// Token: 0x0402F525 RID: 193829
		[FieldOffset(0)]
		public FString inRes;

		// Token: 0x0402F526 RID: 193830
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02008C99 RID: 35993
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __IsInPerformingPlot_FunctionParams
	{
		// Token: 0x0402F527 RID: 193831
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x0402F528 RID: 193832
		[FieldOffset(8)]
		public bool __Result;
	}

	// Token: 0x02008C9A RID: 35994
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __TriggerBlackSequence_FunctionParams
	{
		// Token: 0x0402F529 RID: 193833
		[FieldOffset(0)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02008C9B RID: 35995
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __ChangePlotWeather_FunctionParams
	{
		// Token: 0x0402F52A RID: 193834
		[FieldOffset(0)]
		public int weatherId;

		// Token: 0x0402F52B RID: 193835
		[FieldOffset(4)]
		public bool isInherit;

		// Token: 0x0402F52C RID: 193836
		[FieldOffset(8)]
		public float tweenTime;

		// Token: 0x0402F52D RID: 193837
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02008C9C RID: 35996
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __ChangePlotTimeOfDay_FunctionParams
	{
		// Token: 0x0402F52E RID: 193838
		[FieldOffset(0)]
		public bool isInherit;

		// Token: 0x0402F52F RID: 193839
		[FieldOffset(4)]
		public int startSecond;

		// Token: 0x0402F530 RID: 193840
		[FieldOffset(8)]
		public int endSecond;

		// Token: 0x0402F531 RID: 193841
		[FieldOffset(12)]
		public int tweenFrame;

		// Token: 0x0402F532 RID: 193842
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02008C9D RID: 35997
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __ExecuteSequenceEvents_FunctionParams
	{
		// Token: 0x0402F533 RID: 193843
		[FieldOffset(0)]
		public FString key;

		// Token: 0x0402F534 RID: 193844
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02008C9E RID: 35998
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __ExecuteEntitySequenceEvents_FunctionParams
	{
		// Token: 0x0402F535 RID: 193845
		[FieldOffset(0)]
		public FString key;

		// Token: 0x0402F536 RID: 193846
		[FieldOffset(16)]
		public int entityId;

		// Token: 0x0402F537 RID: 193847
		[FieldOffset(24)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02008C9F RID: 35999
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __TriggerCutChange_FunctionParams
	{
		// Token: 0x0402F538 RID: 193848
		[FieldOffset(0)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02008CA0 RID: 36000
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __OpenChapterUi_FunctionParams
	{
		// Token: 0x0402F539 RID: 193849
		[FieldOffset(0)]
		public int chapterState;

		// Token: 0x0402F53A RID: 193850
		[FieldOffset(4)]
		public int chapterId;

		// Token: 0x0402F53B RID: 193851
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02008CA1 RID: 36001
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __ShowLogo_FunctionParams
	{
		// Token: 0x0402F53C RID: 193852
		[FieldOffset(0)]
		public float time;

		// Token: 0x0402F53D RID: 193853
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02008CA2 RID: 36002
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 80)]
	protected ref struct __OpenUiView_FunctionParams
	{
		// Token: 0x0402F53E RID: 193854
		[FieldOffset(0)]
		public FString maleAssetName;

		// Token: 0x0402F53F RID: 193855
		[FieldOffset(16)]
		public FString femaleAssetName;

		// Token: 0x0402F540 RID: 193856
		[FieldOffset(32)]
		public FString maleSpineName;

		// Token: 0x0402F541 RID: 193857
		[FieldOffset(48)]
		public FString femaleSpineName;

		// Token: 0x0402F542 RID: 193858
		[FieldOffset(64)]
		public bool needLoop;

		// Token: 0x0402F543 RID: 193859
		[FieldOffset(65)]
		public bool useFullscreenAdaptAnchor;

		// Token: 0x0402F544 RID: 193860
		[FieldOffset(72)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02008CA3 RID: 36003
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 80)]
	protected ref struct __OpenUiViewInArray_FunctionParams
	{
		// Token: 0x0402F545 RID: 193861
		[FieldOffset(0)]
		public FString maleAssetName;

		// Token: 0x0402F546 RID: 193862
		[FieldOffset(16)]
		public FString femaleAssetName;

		// Token: 0x0402F547 RID: 193863
		[FieldOffset(32)]
		public byte maleSpineArray;

		// Token: 0x0402F548 RID: 193864
		[FieldOffset(48)]
		public byte femaleSpineArray;

		// Token: 0x0402F549 RID: 193865
		[FieldOffset(64)]
		public bool useFullscreenAdaptAnchor;

		// Token: 0x0402F54A RID: 193866
		[FieldOffset(72)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02008CA4 RID: 36004
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __PlayUiLevelSequence_FunctionParams
	{
		// Token: 0x0402F54B RID: 193867
		[FieldOffset(0)]
		public FString seqName;

		// Token: 0x0402F54C RID: 193868
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02008CA5 RID: 36005
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __CloseUiView_FunctionParams
	{
		// Token: 0x0402F54D RID: 193869
		[FieldOffset(0)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02008CA6 RID: 36006
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __PlaySpineAnim_FunctionParams
	{
		// Token: 0x0402F54E RID: 193870
		[FieldOffset(0)]
		public FString spineName;

		// Token: 0x0402F54F RID: 193871
		[FieldOffset(16)]
		public bool needLoop;

		// Token: 0x0402F550 RID: 193872
		[FieldOffset(24)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02008CA7 RID: 36007
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 48)]
	protected ref struct __PlaySpineAnimForGender_FunctionParams
	{
		// Token: 0x0402F551 RID: 193873
		[FieldOffset(0)]
		public FString maleSpineName;

		// Token: 0x0402F552 RID: 193874
		[FieldOffset(16)]
		public FString femaleSpineName;

		// Token: 0x0402F553 RID: 193875
		[FieldOffset(32)]
		public bool needLoop;

		// Token: 0x0402F554 RID: 193876
		[FieldOffset(40)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02008CA8 RID: 36008
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __PlaySpineAnimForGenderInArray_FunctionParams
	{
		// Token: 0x0402F555 RID: 193877
		[FieldOffset(0)]
		public byte maleSpineArray;

		// Token: 0x0402F556 RID: 193878
		[FieldOffset(16)]
		public byte femaleSpineArray;

		// Token: 0x0402F557 RID: 193879
		[FieldOffset(32)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02008CA9 RID: 36009
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __CloseSpineAnim_FunctionParams
	{
		// Token: 0x0402F558 RID: 193880
		[FieldOffset(0)]
		public FString spineName;

		// Token: 0x0402F559 RID: 193881
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02008CAA RID: 36010
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __CloseSpineAnimInArray_FunctionParams
	{
		// Token: 0x0402F55A RID: 193882
		[FieldOffset(0)]
		public byte spineArray;

		// Token: 0x0402F55B RID: 193883
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02008CAB RID: 36011
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 48)]
	protected ref struct __AdditionSeqPlay_FunctionParams
	{
		// Token: 0x0402F55C RID: 193884
		[FieldOffset(0)]
		public IntPtr levelSequence;

		// Token: 0x0402F55D RID: 193885
		[FieldOffset(8)]
		public FName componentName;

		// Token: 0x0402F55E RID: 193886
		[FieldOffset(20)]
		public FName boneName;

		// Token: 0x0402F55F RID: 193887
		[FieldOffset(32)]
		public float frame;

		// Token: 0x0402F560 RID: 193888
		[FieldOffset(40)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02008CAC RID: 36012
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __AdditionSeqEnd_FunctionParams
	{
		// Token: 0x0402F561 RID: 193889
		[FieldOffset(0)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02008CAD RID: 36013
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __OpenMultiTextCaption_FunctionParams
	{
		// Token: 0x0402F562 RID: 193890
		[FieldOffset(0)]
		public FString textId;

		// Token: 0x0402F563 RID: 193891
		[FieldOffset(16)]
		public float duration;

		// Token: 0x0402F564 RID: 193892
		[FieldOffset(24)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02008CAE RID: 36014
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __ShowNameInput_FunctionParams
	{
		// Token: 0x0402F565 RID: 193893
		[FieldOffset(0)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02008CAF RID: 36015
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __AddBurstEyeRenderingMaterial_FunctionParams
	{
		// Token: 0x0402F566 RID: 193894
		[FieldOffset(0)]
		public bool isBoy;

		// Token: 0x0402F567 RID: 193895
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02008CB0 RID: 36016
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __RemoveBurstEyeRenderingMaterial_FunctionParams
	{
		// Token: 0x0402F568 RID: 193896
		[FieldOffset(0)]
		public bool isBoy;

		// Token: 0x0402F569 RID: 193897
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02008CB1 RID: 36017
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __AddInteractTagToInteractingGravityMachine_FunctionParams
	{
		// Token: 0x0402F56A RID: 193898
		[FieldOffset(0)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02008CB2 RID: 36018
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __RemoveInteractTagFromInteractingGravityMachine_FunctionParams
	{
		// Token: 0x0402F56B RID: 193899
		[FieldOffset(0)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02008CB3 RID: 36019
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __TriggerTagToInteractingGravityMachine_FunctionParams
	{
		// Token: 0x0402F56C RID: 193900
		[FieldOffset(0)]
		public FGameplayTag tag;

		// Token: 0x0402F56D RID: 193901
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02008CB4 RID: 36020
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __ShowBgIcon_FunctionParams
	{
		// Token: 0x0402F56E RID: 193902
		[FieldOffset(0)]
		public bool bShow;

		// Token: 0x0402F56F RID: 193903
		[FieldOffset(8)]
		public IntPtr texture;

		// Token: 0x0402F570 RID: 193904
		[FieldOffset(16)]
		public IntPtr obj;

		// Token: 0x0402F571 RID: 193905
		[FieldOffset(24)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02008CB5 RID: 36021
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __BindItemInspectActor_FunctionParams
	{
		// Token: 0x0402F572 RID: 193906
		[FieldOffset(0)]
		public byte binding;

		// Token: 0x0402F573 RID: 193907
		[FieldOffset(24)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02008CB6 RID: 36022
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __EnablePlotInteract_FunctionParams_Hotfix
	{
		// Token: 0x0402F574 RID: 193908
		[FieldOffset(0)]
		public bool bEnable;

		// Token: 0x0402F575 RID: 193909
		[FieldOffset(8)]
		public FString skipLock;

		// Token: 0x0402F576 RID: 193910
		[FieldOffset(24)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02008CB7 RID: 36023
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 64)]
	protected ref struct __EnableCameraShake_FunctionParams
	{
		// Token: 0x0402F577 RID: 193911
		[FieldOffset(0)]
		public bool bEnable;

		// Token: 0x0402F578 RID: 193912
		[FieldOffset(8)]
		public byte cameraShakePtr;

		// Token: 0x0402F579 RID: 193913
		[FieldOffset(56)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02008CB8 RID: 36024
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __NeedFlowAdaption_FunctionParams
	{
		// Token: 0x0402F57A RID: 193914
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x0402F57B RID: 193915
		[FieldOffset(8)]
		public bool __Result;
	}

	// Token: 0x02008CB9 RID: 36025
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 64)]
	protected ref struct __OpenCaptionImage_FunctionParams
	{
		// Token: 0x0402F57C RID: 193916
		[FieldOffset(0)]
		public FString uiPrefabId;

		// Token: 0x0402F57D RID: 193917
		[FieldOffset(16)]
		public float duration;

		// Token: 0x0402F57E RID: 193918
		[FieldOffset(24)]
		public FString uiStartAnimName;

		// Token: 0x0402F57F RID: 193919
		[FieldOffset(40)]
		public FString uiEndAnimName;

		// Token: 0x0402F580 RID: 193920
		[FieldOffset(56)]
		public IntPtr __WorldContext;
	}
}
