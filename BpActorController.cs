using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Scene.Interface;
using AkiClient.Game.Aki.Render.RuntimeBP.SceneCapture_3To2;
using AkiClient.Game.Aki.Render.RuntimeBP.SceneViedoPlay;
using CSharpScript.Core.Framework;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200346C RID: 13420
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[TickController(0)]
public class BpActorController : ControllerBase<BpActorController>
{
	// Token: 0x0601C3F9 RID: 115705 RVA: 0x0086D4FC File Offset: 0x0086B6FC
	public void SetDebugMediaDisabled(bool disabled)
	{
		this.DebugMediaDisabled = disabled;
		if (!this.DebugMediaDisabled)
		{
			return;
		}
		IBPI_SceneBp_C lastActiveMediaActor = this.LastActiveMediaActor;
		if (lastActiveMediaActor != null)
		{
			lastActiveMediaActor.Stop();
		}
		this.LastActiveMediaActor = null;
		IBPI_SceneBp_C lastActiveMediaActor_Extra = this.LastActiveMediaActor_Extra;
		if (lastActiveMediaActor_Extra != null)
		{
			lastActiveMediaActor_Extra.Stop();
		}
		this.LastActiveMediaActor_Extra = null;
	}

	// Token: 0x0601C3FA RID: 115706 RVA: 0x0086D54C File Offset: 0x0086B74C
	public void SetDebugSpecialMediaDisabled(bool disabled)
	{
		this.DebugSpecialMediaDisabled = disabled;
		if (!this.DebugSpecialMediaDisabled)
		{
			return;
		}
		foreach (BpActorController.ActiveResourceGroup activeResourceGroup in this.ActiveResourceGroups.Values)
		{
			foreach (MediaPlayForModel_Special_C mediaPlayForModel_Special_C in activeResourceGroup.Actors)
			{
				if (mediaPlayForModel_Special_C != null && mediaPlayForModel_Special_C.IsValid())
				{
					mediaPlayForModel_Special_C.Stop();
				}
			}
		}
		this.ActiveResourceGroups.Clear();
		this.PendingPlayMediaActors_Special.Clear();
		this.PendingCloseMediaActors_Special.Clear();
		this.PendingReleaseMediaActors_Special.Clear();
	}

	// Token: 0x0601C3FB RID: 115707 RVA: 0x0086D624 File Offset: 0x0086B824
	public void SetDebugSpecialMediaSingleModeEnabled(bool enabled)
	{
		this.DebugSpecialMediaSingleModeEnabled = enabled;
		if (this.DebugSpecialMediaSingleModeEnabled)
		{
			foreach (BpActorController.ActiveResourceGroup activeResourceGroup in this.ActiveResourceGroups.Values)
			{
				foreach (MediaPlayForModel_Special_C mediaPlayForModel_Special_C in activeResourceGroup.Actors)
				{
					if (mediaPlayForModel_Special_C != null && mediaPlayForModel_Special_C.IsValid())
					{
						mediaPlayForModel_Special_C.Stop();
					}
				}
			}
			this.ActiveResourceGroups.Clear();
			this.PendingPlayMediaActors_Special.Clear();
			this.PendingCloseMediaActors_Special.Clear();
			this.PendingReleaseMediaActors_Special.Clear();
			this.DebugFixedMediaPlayer = null;
			this.DebugFixedMediaTexture = null;
			this.SpecialActorAssetLoadCompleted = false;
			this.LoadingSpecialActorAsset = false;
			this.TryLoadSpecialMediaActorAsset().Forget();
			Singleton<Log>.Instance.Info(ELogModule.World, ELogAuthor.CK, "[BpActorController] 已开启单资源调试模式, 正在从DA直接加载固定资源", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.DebugFixedMediaPlayer = null;
		this.DebugFixedMediaTexture = null;
		ControllerBase<WorldController>.Instance.ForceGarbageCollection(true);
		Singleton<Log>.Instance.Info(ELogModule.World, ELogAuthor.CK, "[BpActorController] 已关闭单资源调试模式", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x0601C3FC RID: 115708 RVA: 0x0086D778 File Offset: 0x0086B978
	private bool DebugImmediatePlayMedia_Special(MediaPlayForModel_Special_C actor, PDA_MediaPlayDataAsset_C dataAsset, int? pbDataId)
	{
		if (this.ActiveResourceGroups.Count > 0)
		{
			return false;
		}
		if (this.DebugFixedMediaPlayer == null || this.DebugFixedMediaTexture == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.World;
			ELogAuthor author = ELogAuthor.CK;
			string message = "[BpActorController] DebugImmediatePlayMedia_Special: 固定资源尚未就绪(DA直接加载中)";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Actor", actor);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		actor.AllocatePlayerAsset(this.DebugFixedMediaPlayer, this.DebugFixedMediaTexture);
		actor.Start();
		this.ActiveResourceGroups[dataAsset] = new BpActorController.ActiveResourceGroup(this.DebugFixedMediaPlayer, this.DebugFixedMediaTexture, new HashSet<MediaPlayForModel_Special_C>
		{
			actor
		});
		return true;
	}

	// Token: 0x0601C3FD RID: 115709 RVA: 0x0086D814 File Offset: 0x0086BA14
	private unsafe bool DebugImmediateStopMedia_Special(MediaPlayForModel_Special_C actor, PDA_MediaPlayDataAsset_C dataAsset, int? pbDataId, BpActorController.EPendingStopReason reason)
	{
		BpActorController.ActiveResourceGroup activeResourceGroup;
		if (!this.ActiveResourceGroups.TryGetValue(dataAsset, out activeResourceGroup) || !activeResourceGroup.Actors.Contains(actor))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.World;
			ELogAuthor author = ELogAuthor.CK;
			string message = "[BpActorController] DebugImmediateStopMedia_Special: Actor无需停止";
			<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray5<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("PbDataId", pbDataId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Actor", actor);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("DataAsset", dataAsset);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("Reason", (reason == BpActorController.EPendingStopReason.OutOfAOI) ? "OutOfAOI" : "ManualControl");
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("IsMainPlayer", actor.IsMainPlayer);
			instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 5));
			return true;
		}
		activeResourceGroup.Actors.Remove(actor);
		this.ActiveResourceGroups.Remove(dataAsset);
		actor.Stop();
		return true;
	}

	// Token: 0x0601C3FE RID: 115710 RVA: 0x0086D920 File Offset: 0x0086BB20
	protected override bool OnInit()
	{
		TArray<FGameBudgetBlueprintGroupConfig> tarray = new TArray<FGameBudgetBlueprintGroupConfig>();
		FGameBudgetBlueprintGroupConfig fgameBudgetBlueprintGroupConfig = new FGameBudgetBlueprintGroupConfig();
		fgameBudgetBlueprintGroupConfig.Group = EGameBudgetBlueprintGroup.Singleton;
		fgameBudgetBlueprintGroupConfig.GameBudgetGroupName = FNameUtil.GetDynamicFName("BlueprintTick.BlueprintSingleton").Value;
		FGameBudgetBlueprintGroupConfig fgameBudgetBlueprintGroupConfig2 = new FGameBudgetBlueprintGroupConfig();
		fgameBudgetBlueprintGroupConfig2.Group = EGameBudgetBlueprintGroup.SceneActor;
		fgameBudgetBlueprintGroupConfig2.GameBudgetGroupName = FNameUtil.GetDynamicFName("BlueprintTick.SceneBlueprintActor").Value;
		FGameBudgetBlueprintGroupConfig fgameBudgetBlueprintGroupConfig3 = new FGameBudgetBlueprintGroupConfig();
		fgameBudgetBlueprintGroupConfig3.Group = EGameBudgetBlueprintGroup.FarActor;
		fgameBudgetBlueprintGroupConfig3.GameBudgetGroupName = FNameUtil.GetDynamicFName("BlueprintTick.FarBlueprintActor").Value;
		FGameBudgetBlueprintGroupConfig fgameBudgetBlueprintGroupConfig4 = new FGameBudgetBlueprintGroupConfig();
		fgameBudgetBlueprintGroupConfig4.Group = EGameBudgetBlueprintGroup.SuperFarActor;
		fgameBudgetBlueprintGroupConfig4.GameBudgetGroupName = FNameUtil.GetDynamicFName("BlueprintTick.SuperFarBlueprintActor").Value;
		FGameBudgetBlueprintGroupConfig fgameBudgetBlueprintGroupConfig5 = new FGameBudgetBlueprintGroupConfig();
		fgameBudgetBlueprintGroupConfig5.Group = EGameBudgetBlueprintGroup.DynamicPhysicsInteractionActor;
		fgameBudgetBlueprintGroupConfig5.GameBudgetGroupName = FNameUtil.GetDynamicFName("BlueprintTick.DynamicPhysicsInteractionActor").Value;
		FGameBudgetBlueprintGroupConfig fgameBudgetBlueprintGroupConfig6 = new FGameBudgetBlueprintGroupConfig();
		fgameBudgetBlueprintGroupConfig6.Group = EGameBudgetBlueprintGroup.StaticPhysicInteractionActor;
		fgameBudgetBlueprintGroupConfig6.GameBudgetGroupName = FNameUtil.GetDynamicFName("BlueprintTick.StaticPhysicsInteractionActor").Value;
		FGameBudgetBlueprintGroupConfig fgameBudgetBlueprintGroupConfig7 = new FGameBudgetBlueprintGroupConfig();
		fgameBudgetBlueprintGroupConfig7.Group = EGameBudgetBlueprintGroup.HighPriorityPhysicInteractionActor;
		fgameBudgetBlueprintGroupConfig7.GameBudgetGroupName = FNameUtil.GetDynamicFName("BlueprintTick.HighPriorityPhysicsInteractionActor").Value;
		FGameBudgetBlueprintGroupConfig fgameBudgetBlueprintGroupConfig8 = new FGameBudgetBlueprintGroupConfig();
		fgameBudgetBlueprintGroupConfig8.Group = EGameBudgetBlueprintGroup.SpecialBlueprintActor;
		fgameBudgetBlueprintGroupConfig8.GameBudgetGroupName = FNameUtil.GetDynamicFName("BlueprintTick.SpecialBlueprintActor").Value;
		FGameBudgetBlueprintGroupConfig fgameBudgetBlueprintGroupConfig9 = new FGameBudgetBlueprintGroupConfig();
		fgameBudgetBlueprintGroupConfig9.Group = EGameBudgetBlueprintGroup.SparseGridPhysicsInteractionActor;
		fgameBudgetBlueprintGroupConfig9.GameBudgetGroupName = FNameUtil.GetDynamicFName("BlueprintTick.SparseGridPhysicsInteractionActor").Value;
		tarray.Add(fgameBudgetBlueprintGroupConfig);
		tarray.Add(fgameBudgetBlueprintGroupConfig2);
		tarray.Add(fgameBudgetBlueprintGroupConfig3);
		tarray.Add(fgameBudgetBlueprintGroupConfig4);
		tarray.Add(fgameBudgetBlueprintGroupConfig5);
		tarray.Add(fgameBudgetBlueprintGroupConfig6);
		tarray.Add(fgameBudgetBlueprintGroupConfig7);
		tarray.Add(fgameBudgetBlueprintGroupConfig8);
		tarray.Add(fgameBudgetBlueprintGroupConfig9);
		UKuroGameBudgetBlueprintDefine.Initialize(tarray);
		Singleton<EventSystem>.Instance.Add<int>(EEventName.SetEnvironmentInteraction, new Action<int>(this.OnSetEnvironmentInteraction));
		return true;
	}

	// Token: 0x0601C3FF RID: 115711 RVA: 0x0086DB06 File Offset: 0x0086BD06
	protected override bool OnClear()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.SetEnvironmentInteraction, new Action<int>(this.OnSetEnvironmentInteraction));
		UKuroGameBudgetBlueprintDefine.Clear();
		return true;
	}

	// Token: 0x0601C400 RID: 115712 RVA: 0x0086DB2C File Offset: 0x0086BD2C
	private void OnSetEnvironmentInteraction(int value)
	{
		UKuroGameBudgetSubSystem ukuroGameBudgetSubSystem = USubsystemBlueprintLibrary.GetWorldSubsystem(GlobalData.World, UKuroGameBudgetSubSystem.StaticClass()) as UKuroGameBudgetSubSystem;
		if (ukuroGameBudgetSubSystem != null)
		{
			ukuroGameBudgetSubSystem.SetEnvInteractChange(value > 0);
		}
	}

	// Token: 0x0601C401 RID: 115713 RVA: 0x0086DB60 File Offset: 0x0086BD60
	public void RegisterBpActor(FName groupTag, IBPI_SceneBp_C sceneBp)
	{
		if (sceneBp == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.World, ELogAuthor.ZWY, "BpActorController sceneBp 是空的", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (groupTag == this.MEDIA_ACTOR_GROUP)
		{
			AActor aactor = sceneBp as AActor;
			if (aactor == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.World, ELogAuthor.ZWY, "BpActorController MediaActor 只能放在Actor下实现接口", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			aactor.SetActorTickEnabled(false);
			this.MediaActors.Add(sceneBp);
			return;
		}
		else if (groupTag == this.MEDIA_ACTOR_GROUP_EXTRA)
		{
			AActor aactor2 = sceneBp as AActor;
			if (aactor2 == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.World, ELogAuthor.ZWY, "BpActorController MediaActor_Extra 只能放在Actor下实现接口", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			aactor2.SetActorTickEnabled(false);
			this.MediaActors_Extra.Add(sceneBp);
			return;
		}
		else if (groupTag == this.MEDIA_ACTOR_GROUP_SPECIAL)
		{
			MediaPlayForModel_Special_C mediaPlayForModel_Special_C = sceneBp as MediaPlayForModel_Special_C;
			if (mediaPlayForModel_Special_C == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.World, ELogAuthor.CK, "[BpActorController] RegisterBpActor 失败: Actor类型错误", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			mediaPlayForModel_Special_C.SetActorTickEnabled(false);
			this.RegisterMediaActors_Special.Add(mediaPlayForModel_Special_C);
			this.TryLoadSpecialMediaActorAsset().Forget();
			return;
		}
		else
		{
			if (!(groupTag == this.SCENE_CAPTURE_3TO2_GROUP))
			{
				Singleton<Log>.Instance.Error(ELogModule.World, ELogAuthor.ZWY, "SceneBp 注册失败,没有对应的处理类型", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			UObject item = sceneBp as UObject;
			BP_SceneCapture_3To2_C bp_SceneCapture_3To2_C = sceneBp as BP_SceneCapture_3To2_C;
			if (bp_SceneCapture_3To2_C == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.World;
				ELogAuthor author = ELogAuthor.HF;
				string message = "[BpActorController] SceneCapture_3To2 Actor类型错误";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("SceneBpActor", item);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.LoadSceneCapture3To2Rt(bp_SceneCapture_3To2_C).Forget();
			return;
		}
	}

	// Token: 0x0601C402 RID: 115714 RVA: 0x0086DCF0 File Offset: 0x0086BEF0
	private UniTask LoadSceneCapture3To2Rt(BP_SceneCapture_3To2_C actor)
	{
		BpActorController.<LoadSceneCapture3To2Rt>d__47 <LoadSceneCapture3To2Rt>d__;
		<LoadSceneCapture3To2Rt>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<LoadSceneCapture3To2Rt>d__.actor = actor;
		<LoadSceneCapture3To2Rt>d__.<>1__state = -1;
		<LoadSceneCapture3To2Rt>d__.<>t__builder.Start<BpActorController.<LoadSceneCapture3To2Rt>d__47>(ref <LoadSceneCapture3To2Rt>d__);
		return <LoadSceneCapture3To2Rt>d__.<>t__builder.Task;
	}

	// Token: 0x0601C403 RID: 115715 RVA: 0x0086DD34 File Offset: 0x0086BF34
	public unsafe void UnregisterBpActor(FName groupTag, IBPI_SceneBp_C sceneBp)
	{
		if (sceneBp == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.World, ELogAuthor.ZWY, "BpActorController sceneBp 是空的", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (groupTag == this.MEDIA_ACTOR_GROUP)
		{
			if (!(sceneBp is AActor))
			{
				return;
			}
			this.MediaActors.Remove(sceneBp);
			if (this.MediaActors.Count == 0)
			{
				AActor aactor = this.LastActiveMediaActor as AActor;
				if (aactor != null && aactor.IsValid())
				{
					this.LastActiveMediaActor.Stop();
					this.LastActiveMediaActor = null;
				}
			}
			return;
		}
		else if (groupTag == this.MEDIA_ACTOR_GROUP_EXTRA)
		{
			if (!(sceneBp is AActor))
			{
				return;
			}
			this.MediaActors_Extra.Remove(sceneBp);
			if (this.MediaActors_Extra.Count == 0)
			{
				AActor aactor2 = this.LastActiveMediaActor_Extra as AActor;
				if (aactor2 != null && aactor2.IsValid())
				{
					this.LastActiveMediaActor_Extra.Stop();
					this.LastActiveMediaActor_Extra = null;
				}
			}
			return;
		}
		else if (groupTag == this.MEDIA_ACTOR_GROUP_SPECIAL)
		{
			MediaPlayForModel_Special_C mediaPlayForModel_Special_C = sceneBp as MediaPlayForModel_Special_C;
			if (mediaPlayForModel_Special_C == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.World;
				ELogAuthor author = ELogAuthor.CK;
				string message = "[BpActorController] UnregisterBpActor失败: Actor类型错误";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("SceneBpActor", sceneBp);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("GroupTag", groupTag);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			this.RegisterMediaActors_Special.Remove(mediaPlayForModel_Special_C);
			ValueTuple<bool, bool> valueTuple = this.RemovePendingSpecialMediaActor(mediaPlayForModel_Special_C);
			PDA_MediaPlayDataAsset_C mediaPlayDataAsset = mediaPlayForModel_Special_C.MediaPlayDataAsset;
			BpActorController.ActiveResourceGroup activeResourceGroup2;
			BpActorController.ActiveResourceGroup activeResourceGroup = (mediaPlayDataAsset != null) ? (this.ActiveResourceGroups.TryGetValue(mediaPlayDataAsset, out activeResourceGroup2) ? activeResourceGroup2 : null) : null;
			if (activeResourceGroup != null && activeResourceGroup.Actors.Remove(mediaPlayForModel_Special_C))
			{
				if (activeResourceGroup.Actors.Count == 0 || mediaPlayForModel_Special_C.IsMainPlayer)
				{
					this.ActiveResourceGroups.Remove(mediaPlayDataAsset);
					this.PendingReleaseMediaActors_Special.Add(mediaPlayForModel_Special_C);
				}
			}
			else if (!valueTuple.Item1)
			{
				bool item = valueTuple.Item2;
			}
			if (this.RegisterMediaActors_Special.Count == 0)
			{
				foreach (BpActorController.ActiveResourceGroup activeResourceGroup3 in this.ActiveResourceGroups.Values)
				{
					foreach (MediaPlayForModel_Special_C mediaPlayForModel_Special_C2 in activeResourceGroup3.Actors)
					{
						if (mediaPlayForModel_Special_C2 != null && mediaPlayForModel_Special_C2.IsValid())
						{
							mediaPlayForModel_Special_C2.Stop();
						}
					}
				}
				this.ActiveResourceGroups.Clear();
				this.PendingPlayMediaActors_Special.Clear();
				this.PendingCloseMediaActors_Special.Clear();
				this.PendingReleaseMediaActors_Special.Clear();
				this.AvailableMediaPlayerPool.Clear();
				this.AvailableMediaTexturePool.Clear();
				this.SpecialActorAssetLoadCompleted = false;
				this.LoadingSpecialActorAsset = false;
			}
			return;
		}
		else
		{
			if (groupTag == this.SCENE_CAPTURE_3TO2_GROUP)
			{
				return;
			}
			Singleton<Log>.Instance.Error(ELogModule.World, ELogAuthor.ZWY, "SceneBp 反注册失败,没有对应的处理类型", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
	}

	// Token: 0x0601C404 RID: 115716 RVA: 0x0086E04C File Offset: 0x0086C24C
	[NullableContext(0)]
	[return: TupleElementNames(new string[]
	{
		"PendingPlayRemoved",
		"PendingCloseRemoved"
	})]
	private ValueTuple<bool, bool> RemovePendingSpecialMediaActor([Nullable(1)] MediaPlayForModel_Special_C actor)
	{
		int num = this.PendingPlayMediaActors_Special.IndexOf(actor);
		bool flag = num != -1;
		if (flag)
		{
			this.PendingPlayMediaActors_Special.RemoveAt(num);
		}
		int num2 = this.PendingCloseMediaActors_Special.IndexOf(actor);
		bool flag2 = num2 != -1;
		if (flag2)
		{
			this.PendingCloseMediaActors_Special.RemoveAt(num2);
		}
		return new ValueTuple<bool, bool>(flag, flag2);
	}

	// Token: 0x0601C405 RID: 115717 RVA: 0x0086E0A6 File Offset: 0x0086C2A6
	private bool CheckDayState()
	{
		return ControllerBase<TimeOfDayController>.Instance.CheckInMinuteSpan(360, 1080);
	}

	// Token: 0x0601C406 RID: 115718 RVA: 0x0086E0BC File Offset: 0x0086C2BC
	public void RegisterDayNightActor(IBPI_DayNightEvent_C dayNightBp)
	{
		if (!this.DayNightActors.Contains(dayNightBp))
		{
			this.DayNightActors.Add(dayNightBp);
			if (this.CheckDayState())
			{
				dayNightBp.OnEnterDay();
				return;
			}
			dayNightBp.OnEnterNight();
		}
	}

	// Token: 0x0601C407 RID: 115719 RVA: 0x0086E0EE File Offset: 0x0086C2EE
	public void UnregisterDayNightActor(IBPI_DayNightEvent_C dayNightBp)
	{
		if (this.DayNightActors.Contains(dayNightBp))
		{
			this.DayNightActors.Remove(dayNightBp);
		}
	}

	// Token: 0x0601C408 RID: 115720 RVA: 0x0086E10C File Offset: 0x0086C30C
	public unsafe bool PendingPlayMedia_Special(MediaPlayForModel_Special_C actor, int? pbDataId)
	{
		if (actor == null || !actor.IsValid())
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.World;
			ELogAuthor author = ELogAuthor.CK;
			string message = "[BpActorController] PendingPlayMedia_Special失败: Actor无效";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("PbDataId", pbDataId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Actor", actor);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return false;
		}
		if (!this.RegisterMediaActors_Special.Contains(actor))
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.World;
			ELogAuthor author2 = ELogAuthor.CK;
			string message2 = "[BpActorController] PendingPlayMedia_Special失败: Actor未注册";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("PbDataId", pbDataId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("Actor", actor);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("DataAsset", actor.MediaPlayDataAsset);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 3) = new ValueTuple<string, object>("IsMainPlayer", actor.IsMainPlayer);
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 4));
			return false;
		}
		PDA_MediaPlayDataAsset_C mediaPlayDataAsset = actor.MediaPlayDataAsset;
		if (mediaPlayDataAsset == null)
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.World;
			ELogAuthor author3 = ELogAuthor.CK;
			string message3 = "[BpActorController] PendingPlayMedia_Special失败: Actor没有MediaPlayDataAsset";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("PbDataId", pbDataId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("Actor", actor);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("IsMainPlayer", actor.IsMainPlayer);
			instance3.Error(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 3));
			return false;
		}
		BpActorController.ActiveResourceGroup activeResourceGroup;
		this.ActiveResourceGroups.TryGetValue(mediaPlayDataAsset, out activeResourceGroup);
		if (activeResourceGroup != null && activeResourceGroup.Actors.Contains(actor))
		{
			int num = this.PendingCloseMediaActors_Special.IndexOf(actor);
			if (num != -1)
			{
				this.PendingCloseMediaActors_Special.RemoveAt(num);
				return true;
			}
			Log instance4 = Singleton<Log>.Instance;
			ELogModule module4 = ELogModule.World;
			ELogAuthor author4 = ELogAuthor.CK;
			string message4 = "[BpActorController] PendingPlayMedia_Special忽略: Actor已在播放中";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray4 = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 0) = new ValueTuple<string, object>("PbDataId", pbDataId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 1) = new ValueTuple<string, object>("Actor", actor);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 2) = new ValueTuple<string, object>("DataAsset", mediaPlayDataAsset);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 3) = new ValueTuple<string, object>("IsMainPlayer", actor.IsMainPlayer);
			instance4.Warn(module4, author4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray4, 4));
			return true;
		}
		else
		{
			if (this.DebugSpecialMediaSingleModeEnabled)
			{
				return this.DebugImmediatePlayMedia_Special(actor, mediaPlayDataAsset, pbDataId);
			}
			if (!this.PendingPlayMediaActors_Special.Contains(actor))
			{
				this.PendingPlayMediaActors_Special.Add(actor);
			}
			return true;
		}
	}

	// Token: 0x0601C409 RID: 115721 RVA: 0x0086E3C0 File Offset: 0x0086C5C0
	public unsafe bool PendingStopMedia_Special(MediaPlayForModel_Special_C actor, int? pbDataId, BpActorController.EPendingStopReason reason = BpActorController.EPendingStopReason.ManualControl)
	{
		if (actor == null || !actor.IsValid())
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.World;
			ELogAuthor author = ELogAuthor.CK;
			string message = "[BpActorController] PendingStopMedia_Special失败: Actor无效";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("PbDataId", pbDataId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Actor", actor);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return false;
		}
		PDA_MediaPlayDataAsset_C mediaPlayDataAsset = actor.MediaPlayDataAsset;
		if (mediaPlayDataAsset == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.World;
			ELogAuthor author2 = ELogAuthor.CK;
			string message2 = "[BpActorController] PendingStopMedia_Special失败: Actor没有MediaPlayDataAsset";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("PbDataId", pbDataId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("Actor", actor);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("IsMainPlayer", actor.IsMainPlayer);
			instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
			return true;
		}
		if (this.DebugSpecialMediaSingleModeEnabled)
		{
			return this.DebugImmediateStopMedia_Special(actor, mediaPlayDataAsset, pbDataId, reason);
		}
		BpActorController.ActiveResourceGroup activeResourceGroup;
		if (this.ActiveResourceGroups.TryGetValue(mediaPlayDataAsset, out activeResourceGroup) && activeResourceGroup.Actors.Contains(actor))
		{
			if (!this.PendingCloseMediaActors_Special.Contains(actor))
			{
				this.PendingCloseMediaActors_Special.Add(actor);
			}
			return true;
		}
		int num = this.PendingPlayMediaActors_Special.IndexOf(actor);
		if (num != -1)
		{
			this.PendingPlayMediaActors_Special.RemoveAt(num);
			return true;
		}
		Log instance3 = Singleton<Log>.Instance;
		ELogModule module3 = ELogModule.World;
		ELogAuthor author3 = ELogAuthor.CK;
		string message3 = "[BpActorController] PendingStopMedia_Special失败: Actor无需停止";
		<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray4<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("PbDataId", pbDataId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("Actor", actor);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("DataAsset", mediaPlayDataAsset);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 3) = new ValueTuple<string, object>("IsMainPlayer", actor.IsMainPlayer);
		instance3.Warn(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 4));
		return true;
	}

	// Token: 0x0601C40A RID: 115722 RVA: 0x0086E5C4 File Offset: 0x0086C7C4
	private UniTask TryLoadSpecialMediaActorAsset()
	{
		BpActorController.<TryLoadSpecialMediaActorAsset>d__55 <TryLoadSpecialMediaActorAsset>d__;
		<TryLoadSpecialMediaActorAsset>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<TryLoadSpecialMediaActorAsset>d__.<>4__this = this;
		<TryLoadSpecialMediaActorAsset>d__.<>1__state = -1;
		<TryLoadSpecialMediaActorAsset>d__.<>t__builder.Start<BpActorController.<TryLoadSpecialMediaActorAsset>d__55>(ref <TryLoadSpecialMediaActorAsset>d__);
		return <TryLoadSpecialMediaActorAsset>d__.<>t__builder.Task;
	}

	// Token: 0x0601C40B RID: 115723 RVA: 0x0086E608 File Offset: 0x0086C808
	private void CheckDayNightChange()
	{
		if (this.DayNightActors.Count < 0)
		{
			return;
		}
		if (this.IsDayState == null)
		{
			this.IsDayState = new bool?(this.CheckDayState());
			return;
		}
		bool flag = this.CheckDayState();
		bool? isDayState = this.IsDayState;
		bool flag2 = flag;
		if (!(isDayState.GetValueOrDefault() == flag2 & isDayState != null))
		{
			this.IsDayState = new bool?(flag);
			if (flag)
			{
				using (HashSet<IBPI_DayNightEvent_C>.Enumerator enumerator = this.DayNightActors.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						IBPI_DayNightEvent_C ibpi_DayNightEvent_C = enumerator.Current;
						AActor aactor = ibpi_DayNightEvent_C as AActor;
						if (aactor != null && aactor.IsValid())
						{
							ibpi_DayNightEvent_C.OnEnterDay();
						}
						else
						{
							this.PendingRemoveDayNightActors.Add(ibpi_DayNightEvent_C);
						}
					}
					goto IL_11E;
				}
			}
			foreach (IBPI_DayNightEvent_C ibpi_DayNightEvent_C2 in this.DayNightActors)
			{
				AActor aactor2 = ibpi_DayNightEvent_C2 as AActor;
				if (aactor2 != null && aactor2.IsValid())
				{
					ibpi_DayNightEvent_C2.OnEnterNight();
				}
				else
				{
					this.PendingRemoveDayNightActors.Add(ibpi_DayNightEvent_C2);
				}
			}
			IL_11E:
			if (this.PendingRemoveDayNightActors.Count > 0)
			{
				foreach (IBPI_DayNightEvent_C item in this.PendingRemoveDayNightActors)
				{
					this.DayNightActors.Remove(item);
				}
				this.PendingRemoveDayNightActors.Clear();
			}
		}
	}

	// Token: 0x0601C40C RID: 115724 RVA: 0x0086E7B4 File Offset: 0x0086C9B4
	protected override void OnTick(float delta)
	{
		this.CheckMediaActor();
		this.CheckDayNightChange();
	}

	// Token: 0x0601C40D RID: 115725 RVA: 0x0086E7C4 File Offset: 0x0086C9C4
	private void CheckMediaActor()
	{
		if (this.MediaActors.Count > 0 || this.MediaActors_Extra.Count > 0)
		{
			if (this.DebugMediaDisabled)
			{
				return;
			}
			this.BpMediaActorTickInternal++;
			if (this.BpMediaActorTickInternal > 30)
			{
				this.BpMediaActorTickInternal = 0;
			}
			if (this.MediaActors.Count > 0)
			{
				if (this.BpMediaActorTickInternal == 10)
				{
					this.CheckMediaActorClose();
					return;
				}
				if (this.BpMediaActorTickInternal == 15)
				{
					this.CheckMediaActorPlay();
					return;
				}
			}
			if (this.MediaActors_Extra.Count > 0)
			{
				if (this.BpMediaActorTickInternal == 20)
				{
					this.CheckMediaActorClose_Extra();
					return;
				}
				if (this.BpMediaActorTickInternal == 25)
				{
					this.CheckMediaActorPlay_Extra();
				}
			}
		}
		if (this.RegisterMediaActors_Special.Count > 0)
		{
			if (this.DebugSpecialMediaDisabled)
			{
				return;
			}
			if (!this.SpecialActorAssetLoadCompleted)
			{
				return;
			}
			this.HandleMediaActor_Special_OutOfAOI();
			this.FrameCounter++;
			if (this.FrameCounter >= 5)
			{
				this.FrameCounter = 0;
				this.ProcessMediaActorOneAction();
			}
		}
	}

	// Token: 0x0601C40E RID: 115726 RVA: 0x0086E8C4 File Offset: 0x0086CAC4
	private unsafe void HandleMediaActor_Special_OutOfAOI()
	{
		Vector cameraLocation = ControllerBase<CameraController>.Instance.MainModel.CameraLocation;
		foreach (KeyValuePair<PDA_MediaPlayDataAsset_C, BpActorController.ActiveResourceGroup> keyValuePair in this.ActiveResourceGroups)
		{
			PDA_MediaPlayDataAsset_C pda_MediaPlayDataAsset_C;
			BpActorController.ActiveResourceGroup activeResourceGroup;
			keyValuePair.Deconstruct(out pda_MediaPlayDataAsset_C, out activeResourceGroup);
			PDA_MediaPlayDataAsset_C item = pda_MediaPlayDataAsset_C;
			foreach (MediaPlayForModel_Special_C mediaPlayForModel_Special_C in activeResourceGroup.Actors)
			{
				if (mediaPlayForModel_Special_C.IsValid())
				{
					Vector vector = Vector.Create();
					Vector vector2 = vector;
					FVectorDouble fvectorDouble = mediaPlayForModel_Special_C.D_K2_GetActorLocation();
					vector2.FromUeVector(fvectorDouble);
					double num = Vector.Dist(cameraLocation, vector);
					int aoiRange = this.GetAoiRange(mediaPlayForModel_Special_C);
					if (aoiRange > 0 && (double)aoiRange < num && !this.PendingCloseMediaActors_Special.Contains(mediaPlayForModel_Special_C))
					{
						this.PendingStopMedia_Special(mediaPlayForModel_Special_C, null, BpActorController.EPendingStopReason.OutOfAOI);
						Log instance = Singleton<Log>.Instance;
						ELogModule module = ELogModule.World;
						ELogAuthor author = ELogAuthor.CK;
						string message = "[BpActorController] CheckMediaActor_Special_OutOfAOI: Actor超出AOI范围, 停止播放";
						<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray5<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Actor", mediaPlayForModel_Special_C);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("DataAsset", item);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Distance", num);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("AoiRange", aoiRange);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("IsMainPlayer", mediaPlayForModel_Special_C.IsMainPlayer);
						instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 5));
					}
				}
			}
		}
	}

	// Token: 0x0601C40F RID: 115727 RVA: 0x0086EAB8 File Offset: 0x0086CCB8
	private bool CheckMediaActor_Special_InAOI(MediaPlayForModel_Special_C actor)
	{
		if (!actor.IsValid())
		{
			return false;
		}
		Vector cameraLocation = ControllerBase<CameraController>.Instance.MainModel.CameraLocation;
		Vector vector = Vector.Create();
		Vector vector2 = vector;
		FVectorDouble fvectorDouble = actor.D_K2_GetActorLocation();
		vector2.FromUeVector(fvectorDouble);
		double num = Vector.Dist(cameraLocation, vector);
		int aoiRange = this.GetAoiRange(actor);
		return aoiRange == 0 || num <= (double)aoiRange;
	}

	// Token: 0x0601C410 RID: 115728 RVA: 0x0086EB10 File Offset: 0x0086CD10
	private bool HasPendingReleaseMediaResource()
	{
		this.TempInvalidReleaseActors.Clear();
		foreach (MediaPlayForModel_Special_C mediaPlayForModel_Special_C in this.PendingReleaseMediaActors_Special)
		{
			if (mediaPlayForModel_Special_C == null || !mediaPlayForModel_Special_C.IsValid())
			{
				this.TempInvalidReleaseActors.Add(mediaPlayForModel_Special_C);
			}
		}
		foreach (MediaPlayForModel_Special_C item in this.TempInvalidReleaseActors)
		{
			this.PendingReleaseMediaActors_Special.Remove(item);
		}
		return this.PendingReleaseMediaActors_Special.Count > 0;
	}

	// Token: 0x0601C411 RID: 115729 RVA: 0x0086EBDC File Offset: 0x0086CDDC
	private unsafe void ProcessMediaActorOneAction()
	{
		if (this.PendingCloseMediaActors_Special.Count > 0)
		{
			MediaPlayForModel_Special_C mediaPlayForModel_Special_C = this.PendingCloseMediaActors_Special[0];
			this.PendingCloseMediaActors_Special.RemoveAt(0);
			if (mediaPlayForModel_Special_C != null && mediaPlayForModel_Special_C.IsValid())
			{
				PDA_MediaPlayDataAsset_C mediaPlayDataAsset = mediaPlayForModel_Special_C.MediaPlayDataAsset;
				BpActorController.ActiveResourceGroup activeResourceGroup;
				if (mediaPlayDataAsset != null && this.ActiveResourceGroups.TryGetValue(mediaPlayDataAsset, out activeResourceGroup) && activeResourceGroup != null)
				{
					activeResourceGroup.Actors.Remove(mediaPlayForModel_Special_C);
					if (activeResourceGroup.Actors.Count == 0)
					{
						this.ActiveResourceGroups.Remove(mediaPlayDataAsset);
						this.PendingReleaseMediaActors_Special.Add(mediaPlayForModel_Special_C);
						mediaPlayForModel_Special_C.Stop();
						return;
					}
					mediaPlayForModel_Special_C.Stop();
				}
			}
			return;
		}
		if (this.PendingPlayMediaActors_Special.Count > 0)
		{
			MediaPlayForModel_Special_C mediaPlayForModel_Special_C = this.PendingPlayMediaActors_Special[0];
			this.PendingPlayMediaActors_Special.RemoveAt(0);
			if (mediaPlayForModel_Special_C != null && mediaPlayForModel_Special_C.IsValid())
			{
				PDA_MediaPlayDataAsset_C mediaPlayDataAsset2 = mediaPlayForModel_Special_C.MediaPlayDataAsset;
				if (mediaPlayDataAsset2 != null)
				{
					if (!this.RegisterMediaActors_Special.Contains(mediaPlayForModel_Special_C))
					{
						Log instance = Singleton<Log>.Instance;
						ELogModule module = ELogModule.World;
						ELogAuthor author = ELogAuthor.CK;
						string message = "[BpActorController] ProcessMediaActorOneAction: Actor已反注册, 跳过待播放请求";
						<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Actor", mediaPlayForModel_Special_C);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("DataAsset", mediaPlayForModel_Special_C.MediaPlayDataAsset);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("IsMainPlayer", mediaPlayForModel_Special_C.IsMainPlayer);
						instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
						return;
					}
					if (!this.CheckMediaActor_Special_InAOI(mediaPlayForModel_Special_C))
					{
						this.PendingPlayMediaActors_Special.Add(mediaPlayForModel_Special_C);
						return;
					}
					BpActorController.ActiveResourceGroup activeResourceGroup2;
					if (this.ActiveResourceGroups.TryGetValue(mediaPlayDataAsset2, out activeResourceGroup2))
					{
						if (activeResourceGroup2.Actors.Contains(mediaPlayForModel_Special_C))
						{
							return;
						}
						mediaPlayForModel_Special_C.AllocatePlayerAsset(activeResourceGroup2.MediaPlayer, activeResourceGroup2.MediaTexture);
						mediaPlayForModel_Special_C.IsMainPlayer = false;
						mediaPlayForModel_Special_C.Start();
						activeResourceGroup2.Actors.Add(mediaPlayForModel_Special_C);
						return;
					}
					else
					{
						if (this.ActiveResourceGroups.Count >= 5)
						{
							Log instance2 = Singleton<Log>.Instance;
							ELogModule module2 = ELogModule.World;
							ELogAuthor author2 = ELogAuthor.CK;
							string message2 = "[BpActorController] ProcessMediaActorOneAction: 资源组已满, 无法分配新资源";
							<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray5<ValueTuple<string, object>>);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("当前资源组数量", this.ActiveResourceGroups.Count);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("最大资源组数量", 5);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("Actor", mediaPlayForModel_Special_C);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 3) = new ValueTuple<string, object>("DataAsset", mediaPlayDataAsset2);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 4) = new ValueTuple<string, object>("IsMainPlayer", mediaPlayForModel_Special_C.IsMainPlayer);
							instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 5));
							return;
						}
						if ((this.AvailableMediaPlayerPool.Count == 0 || this.AvailableMediaTexturePool.Count == 0) && this.HasPendingReleaseMediaResource())
						{
							this.PendingPlayMediaActors_Special.Add(mediaPlayForModel_Special_C);
							return;
						}
						if (this.AllocateToMediaPlayActor(mediaPlayForModel_Special_C))
						{
							UMediaPlayer shareMediaPlayer = mediaPlayForModel_Special_C.ShareMediaPlayer;
							UMediaTexture shareMediaTexture = mediaPlayForModel_Special_C.ShareMediaTexture;
							if (shareMediaPlayer != null && shareMediaTexture != null)
							{
								BpActorController.ActiveResourceGroup value = new BpActorController.ActiveResourceGroup(shareMediaPlayer, shareMediaTexture, new HashSet<MediaPlayForModel_Special_C>
								{
									mediaPlayForModel_Special_C
								});
								this.ActiveResourceGroups[mediaPlayDataAsset2] = value;
								mediaPlayForModel_Special_C.IsMainPlayer = true;
								mediaPlayForModel_Special_C.Start();
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x0601C412 RID: 115730 RVA: 0x0086EF0C File Offset: 0x0086D10C
	private unsafe bool AllocateToMediaPlayActor(MediaPlayForModel_Special_C actor)
	{
		if (this.AvailableMediaPlayerPool.Count == 0 || this.AvailableMediaTexturePool.Count == 0)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.World;
			ELogAuthor author = ELogAuthor.CK;
			string message = "[BpActorController] AllocateToMediaPlayActor失败: 没有可用的资源";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("AvailableMediaPlayerPool", this.AvailableMediaPlayerPool.Count);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("AvailableMediaTexturePool", this.AvailableMediaTexturePool.Count);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return false;
		}
		UMediaPlayer umediaPlayer = this.AvailableMediaPlayerPool[this.AvailableMediaPlayerPool.Count - 1];
		this.AvailableMediaPlayerPool.RemoveAt(this.AvailableMediaPlayerPool.Count - 1);
		UMediaTexture umediaTexture = this.AvailableMediaTexturePool[this.AvailableMediaTexturePool.Count - 1];
		this.AvailableMediaTexturePool.RemoveAt(this.AvailableMediaTexturePool.Count - 1);
		umediaTexture.SetMediaPlayer(umediaPlayer);
		actor.AllocatePlayerAsset(umediaPlayer, umediaTexture);
		return true;
	}

	// Token: 0x0601C413 RID: 115731 RVA: 0x0086F018 File Offset: 0x0086D218
	public unsafe void ReleaseFromMediaPlayActor(IBPI_SceneBp_C sceneBpActor)
	{
		MediaPlayForModel_Special_C mediaPlayForModel_Special_C = sceneBpActor as MediaPlayForModel_Special_C;
		if (mediaPlayForModel_Special_C == null || !mediaPlayForModel_Special_C.IsValid())
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.World;
			ELogAuthor author = ELogAuthor.CK;
			string message = "[BpActorController] ReleaseFromMediaPlayActor失败: sceneBpActor类型错误";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("SceneBpActor", sceneBpActor);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.PendingReleaseMediaActors_Special.Remove(mediaPlayForModel_Special_C);
		UMediaPlayer shareMediaPlayer = mediaPlayForModel_Special_C.ShareMediaPlayer;
		UMediaTexture shareMediaTexture = mediaPlayForModel_Special_C.ShareMediaTexture;
		PDA_MediaPlayDataAsset_C mediaPlayDataAsset = mediaPlayForModel_Special_C.MediaPlayDataAsset;
		if (shareMediaPlayer == null || shareMediaTexture == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.World;
			ELogAuthor author2 = ELogAuthor.CK;
			string message2 = "[BpActorController] ReleaseFromMediaPlayActor失败: player或texture为空";
			<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray5<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Actor", mediaPlayForModel_Special_C);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("DataAsset", mediaPlayDataAsset);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("ShareMediaPlayer", shareMediaPlayer);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("ShareMediaTexture", shareMediaTexture);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("IsMainPlayer", mediaPlayForModel_Special_C.IsMainPlayer);
			instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 5));
			return;
		}
		if (this.DebugSpecialMediaSingleModeEnabled)
		{
			return;
		}
		BpActorController.ActiveResourceGroup activeResourceGroup = (mediaPlayDataAsset != null) ? this.ActiveResourceGroups.GetValueOrDefault(mediaPlayDataAsset) : null;
		if (((activeResourceGroup != null) ? activeResourceGroup.MediaPlayer : null) == shareMediaPlayer && activeResourceGroup.MediaTexture == shareMediaTexture)
		{
			return;
		}
		this.AvailableMediaPlayerPool.Add(shareMediaPlayer);
		this.AvailableMediaTexturePool.Add(shareMediaTexture);
		shareMediaTexture.SetMediaPlayer(null);
	}

	// Token: 0x0601C414 RID: 115732 RVA: 0x0086F188 File Offset: 0x0086D388
	private int GetAoiRange(IBPI_SceneBp_C actor)
	{
		int result = 0;
		actor.GetAoiRange(ref result);
		return result;
	}

	// Token: 0x0601C415 RID: 115733 RVA: 0x0086F1A0 File Offset: 0x0086D3A0
	private bool GetShouldStopOnHide(IBPI_SceneBp_C actor)
	{
		bool result = false;
		actor.ShouldStopOnHide(ref result);
		return result;
	}

	// Token: 0x0601C416 RID: 115734 RVA: 0x0086F1B8 File Offset: 0x0086D3B8
	private void CheckMediaActorClose()
	{
		if (this.MediaActors.Count > 0)
		{
			AActor aactor = this.LastActiveMediaActor as AActor;
			if (aactor != null && aactor.IsValid())
			{
				IBPI_SceneBp_C ibpi_SceneBp_C = null;
				Vector cameraLocation = ControllerBase<CameraController>.Instance.MainModel.CameraLocation;
				double num = double.MaxValue;
				foreach (IBPI_SceneBp_C ibpi_SceneBp_C2 in this.MediaActors)
				{
					AActor aactor2 = ibpi_SceneBp_C2 as AActor;
					Vector vector = Vector.Create();
					Vector vector2 = vector;
					FVectorDouble fvectorDouble = aactor2.D_K2_GetActorLocation();
					vector2.FromUeVector(fvectorDouble);
					double num2 = Vector.Dist(cameraLocation, vector);
					if (num2 < num && !this.GetShouldStopOnHide(ibpi_SceneBp_C2))
					{
						num = num2;
						ibpi_SceneBp_C = ibpi_SceneBp_C2;
					}
				}
				AActor aactor3 = ibpi_SceneBp_C as AActor;
				if (aactor3 != null && aactor3.IsValid() && this.LastActiveMediaActor == ibpi_SceneBp_C)
				{
					int aoiRange = this.GetAoiRange(ibpi_SceneBp_C);
					if (aoiRange > 0 && (double)(aoiRange + 1000) < num)
					{
						this.LastActiveMediaActor.Stop();
						this.LastActiveMediaActor = null;
						return;
					}
				}
				else
				{
					this.LastActiveMediaActor.Stop();
					this.LastActiveMediaActor = null;
				}
			}
		}
	}

	// Token: 0x0601C417 RID: 115735 RVA: 0x0086F2F0 File Offset: 0x0086D4F0
	private void CheckMediaActorPlay()
	{
		if (this.MediaActors.Count > 0)
		{
			AActor aactor = this.LastActiveMediaActor as AActor;
			if (aactor == null || !aactor.IsValid())
			{
				IBPI_SceneBp_C ibpi_SceneBp_C = null;
				Vector cameraLocation = ControllerBase<CameraController>.Instance.MainModel.CameraLocation;
				double num = double.MaxValue;
				foreach (IBPI_SceneBp_C ibpi_SceneBp_C2 in this.MediaActors)
				{
					AActor aactor2 = ibpi_SceneBp_C2 as AActor;
					Vector vector = Vector.Create();
					Vector vector2 = vector;
					FVectorDouble fvectorDouble = aactor2.D_K2_GetActorLocation();
					vector2.FromUeVector(fvectorDouble);
					double num2 = Vector.DistSquared(cameraLocation, vector);
					if (num2 < num && !this.GetShouldStopOnHide(ibpi_SceneBp_C2))
					{
						num = num2;
						ibpi_SceneBp_C = ibpi_SceneBp_C2;
					}
				}
				AActor aactor3 = ibpi_SceneBp_C as AActor;
				if (aactor3 == null || !aactor3.IsValid())
				{
					return;
				}
				num = Math.Sqrt(num);
				int aoiRange = this.GetAoiRange(ibpi_SceneBp_C);
				if (aoiRange > 0 && (double)aoiRange > num)
				{
					ibpi_SceneBp_C.Start();
					this.LastActiveMediaActor = ibpi_SceneBp_C;
				}
			}
		}
	}

	// Token: 0x0601C418 RID: 115736 RVA: 0x0086F404 File Offset: 0x0086D604
	private void CheckMediaActorClose_Extra()
	{
		if (this.MediaActors_Extra.Count > 0)
		{
			AActor aactor = this.LastActiveMediaActor_Extra as AActor;
			if (aactor != null && aactor.IsValid())
			{
				IBPI_SceneBp_C ibpi_SceneBp_C = null;
				Vector cameraLocation = ControllerBase<CameraController>.Instance.MainModel.CameraLocation;
				double num = double.MaxValue;
				foreach (IBPI_SceneBp_C ibpi_SceneBp_C2 in this.MediaActors_Extra)
				{
					AActor aactor2 = ibpi_SceneBp_C2 as AActor;
					Vector vector = Vector.Create();
					Vector vector2 = vector;
					FVectorDouble fvectorDouble = aactor2.D_K2_GetActorLocation();
					vector2.FromUeVector(fvectorDouble);
					double num2 = Vector.Dist(cameraLocation, vector);
					if (num2 < num && !this.GetShouldStopOnHide(ibpi_SceneBp_C2))
					{
						num = num2;
						ibpi_SceneBp_C = ibpi_SceneBp_C2;
					}
				}
				AActor aactor3 = ibpi_SceneBp_C as AActor;
				if (aactor3 != null && aactor3.IsValid() && this.LastActiveMediaActor_Extra == ibpi_SceneBp_C)
				{
					int aoiRange = this.GetAoiRange(ibpi_SceneBp_C);
					if (aoiRange > 0 && (double)(aoiRange + 1000) < num)
					{
						this.LastActiveMediaActor_Extra.Stop();
						this.LastActiveMediaActor_Extra = null;
						return;
					}
				}
				else
				{
					this.LastActiveMediaActor_Extra.Stop();
					this.LastActiveMediaActor_Extra = null;
				}
			}
		}
	}

	// Token: 0x0601C419 RID: 115737 RVA: 0x0086F53C File Offset: 0x0086D73C
	private void CheckMediaActorPlay_Extra()
	{
		if (this.MediaActors_Extra.Count > 0)
		{
			AActor aactor = this.LastActiveMediaActor_Extra as AActor;
			if (aactor == null || !aactor.IsValid())
			{
				IBPI_SceneBp_C ibpi_SceneBp_C = null;
				Vector cameraLocation = ControllerBase<CameraController>.Instance.MainModel.CameraLocation;
				double num = double.MaxValue;
				foreach (IBPI_SceneBp_C ibpi_SceneBp_C2 in this.MediaActors_Extra)
				{
					AActor aactor2 = ibpi_SceneBp_C2 as AActor;
					Vector vector = Vector.Create();
					Vector vector2 = vector;
					FVectorDouble fvectorDouble = aactor2.D_K2_GetActorLocation();
					vector2.FromUeVector(fvectorDouble);
					double num2 = Vector.DistSquared(cameraLocation, vector);
					if (num2 < num && !this.GetShouldStopOnHide(ibpi_SceneBp_C2))
					{
						num = num2;
						ibpi_SceneBp_C = ibpi_SceneBp_C2;
					}
				}
				AActor aactor3 = ibpi_SceneBp_C as AActor;
				if (aactor3 == null || !aactor3.IsValid())
				{
					return;
				}
				num = Math.Sqrt(num);
				int aoiRange = this.GetAoiRange(ibpi_SceneBp_C);
				if (aoiRange > 0 && (double)aoiRange > num)
				{
					ibpi_SceneBp_C.Start();
					this.LastActiveMediaActor_Extra = ibpi_SceneBp_C;
				}
			}
		}
	}

	// Token: 0x0400E355 RID: 58197
	private const int AOI_OFFSET = 1000;

	// Token: 0x0400E356 RID: 58198
	private const int MEDIA_ACTOR_TICK_FEQ = 30;

	// Token: 0x0400E357 RID: 58199
	private readonly FName MEDIA_ACTOR_GROUP = new FName("MediaActor");

	// Token: 0x0400E358 RID: 58200
	private const int MEDIA_ACTOR_CHECKFRAME_CLOSE = 10;

	// Token: 0x0400E359 RID: 58201
	private const int MEDIA_ACTOR_CHECKFRAME_PLAY = 15;

	// Token: 0x0400E35A RID: 58202
	private readonly FName MEDIA_ACTOR_GROUP_EXTRA = new FName("MediaActor_Extra");

	// Token: 0x0400E35B RID: 58203
	private const int MEDIA_ACTOR_EXTRA_CHECKFRAME_CLOSE = 20;

	// Token: 0x0400E35C RID: 58204
	private const int MEDIA_ACTOR_EXTRA_CHECKFRAME_PLAY = 25;

	// Token: 0x0400E35D RID: 58205
	private readonly FName MEDIA_ACTOR_GROUP_SPECIAL = new FName("MediaActor_Special");

	// Token: 0x0400E35E RID: 58206
	private readonly FName SCENE_CAPTURE_3TO2_GROUP = new FName("SceneCapture_3To2");

	// Token: 0x0400E35F RID: 58207
	private const int MEDIA_ACTOR_SPECIAL_MAX_ACTIVE = 5;

	// Token: 0x0400E360 RID: 58208
	private const int MEDIA_ACTOR_SPECIAL_FRAMES_PER_ACTION = 5;

	// Token: 0x0400E361 RID: 58209
	private const string SpecialMediaActorAssetPoolDAPath = "/Game/Aki/Render/RuntimeBP/SceneViedoPlay/SpecialMediaPlayActorAsset.SpecialMediaPlayActorAsset";

	// Token: 0x0400E362 RID: 58210
	private const int DAY_MINITE_START = 360;

	// Token: 0x0400E363 RID: 58211
	private const int DAY_MINITE_END = 1080;

	// Token: 0x0400E364 RID: 58212
	public bool DebugMediaDisabled;

	// Token: 0x0400E365 RID: 58213
	public bool DebugSpecialMediaDisabled;

	// Token: 0x0400E366 RID: 58214
	public bool DebugSpecialMediaSingleModeEnabled;

	// Token: 0x0400E367 RID: 58215
	[Nullable(2)]
	private UMediaPlayer DebugFixedMediaPlayer;

	// Token: 0x0400E368 RID: 58216
	[Nullable(2)]
	private UMediaTexture DebugFixedMediaTexture;

	// Token: 0x0400E369 RID: 58217
	private int BpMediaActorTickInternal;

	// Token: 0x0400E36A RID: 58218
	private readonly HashSet<IBPI_SceneBp_C> MediaActors = new HashSet<IBPI_SceneBp_C>();

	// Token: 0x0400E36B RID: 58219
	[Nullable(2)]
	private IBPI_SceneBp_C LastActiveMediaActor;

	// Token: 0x0400E36C RID: 58220
	private readonly HashSet<IBPI_SceneBp_C> MediaActors_Extra = new HashSet<IBPI_SceneBp_C>();

	// Token: 0x0400E36D RID: 58221
	[Nullable(2)]
	private IBPI_SceneBp_C LastActiveMediaActor_Extra;

	// Token: 0x0400E36E RID: 58222
	private readonly HashSet<IBPI_DayNightEvent_C> DayNightActors = new HashSet<IBPI_DayNightEvent_C>();

	// Token: 0x0400E36F RID: 58223
	private bool LoadingSpecialActorAsset;

	// Token: 0x0400E370 RID: 58224
	private bool SpecialActorAssetLoadCompleted;

	// Token: 0x0400E371 RID: 58225
	private readonly List<UMediaPlayer> AvailableMediaPlayerPool = new List<UMediaPlayer>();

	// Token: 0x0400E372 RID: 58226
	private readonly List<UMediaTexture> AvailableMediaTexturePool = new List<UMediaTexture>();

	// Token: 0x0400E373 RID: 58227
	private readonly HashSet<MediaPlayForModel_Special_C> RegisterMediaActors_Special = new HashSet<MediaPlayForModel_Special_C>();

	// Token: 0x0400E374 RID: 58228
	private readonly Dictionary<PDA_MediaPlayDataAsset_C, BpActorController.ActiveResourceGroup> ActiveResourceGroups = new Dictionary<PDA_MediaPlayDataAsset_C, BpActorController.ActiveResourceGroup>();

	// Token: 0x0400E375 RID: 58229
	private readonly List<MediaPlayForModel_Special_C> PendingPlayMediaActors_Special = new List<MediaPlayForModel_Special_C>();

	// Token: 0x0400E376 RID: 58230
	private readonly List<MediaPlayForModel_Special_C> PendingCloseMediaActors_Special = new List<MediaPlayForModel_Special_C>();

	// Token: 0x0400E377 RID: 58231
	private readonly HashSet<MediaPlayForModel_Special_C> PendingReleaseMediaActors_Special = new HashSet<MediaPlayForModel_Special_C>();

	// Token: 0x0400E378 RID: 58232
	private int FrameCounter;

	// Token: 0x0400E379 RID: 58233
	private bool? IsDayState;

	// Token: 0x0400E37A RID: 58234
	private readonly HashSet<IBPI_DayNightEvent_C> PendingRemoveDayNightActors = new HashSet<IBPI_DayNightEvent_C>();

	// Token: 0x0400E37B RID: 58235
	private readonly List<MediaPlayForModel_Special_C> TempInvalidReleaseActors = new List<MediaPlayForModel_Special_C>();

	// Token: 0x020095F5 RID: 38389
	[NullableContext(0)]
	public enum EPendingStopReason
	{
		// Token: 0x04031824 RID: 202788
		OutOfAOI,
		// Token: 0x04031825 RID: 202789
		ManualControl
	}

	// Token: 0x020095F6 RID: 38390
	[Nullable(0)]
	internal class ActiveResourceGroup
	{
		// Token: 0x0604A3F5 RID: 304117 RVA: 0x0141CFA4 File Offset: 0x0141B1A4
		public ActiveResourceGroup(UMediaPlayer mediaPlayer, UMediaTexture mediaTexture, HashSet<MediaPlayForModel_Special_C> actors)
		{
			this.MediaPlayer = mediaPlayer;
			this.MediaTexture = mediaTexture;
			this.Actors = actors;
		}

		// Token: 0x04031826 RID: 202790
		public UMediaPlayer MediaPlayer;

		// Token: 0x04031827 RID: 202791
		public UMediaTexture MediaTexture;

		// Token: 0x04031828 RID: 202792
		public HashSet<MediaPlayForModel_Special_C> Actors;
	}
}
