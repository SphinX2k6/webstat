using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera.MovieCamera;
using AkiClient.Game.Aki.Data.Camera;
using CSharpScript.Game.LevelGamePlay.StaticScene;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Camera.CameraSubModeController
{
	// Token: 0x020070CB RID: 28875
	[NullableContext(1)]
	[Nullable(0)]
	public class CameraMovieModeController : CameraSubModeController, IStaticVariableResetter
	{
		// Token: 0x06045FED RID: 286701 RVA: 0x0125E418 File Offset: 0x0125C618
		static CameraMovieModeController()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(CameraMovieModeController.CreateStaticDefaultValue), new Action(CameraMovieModeController.ResetStaticDefaultValue));
		}

		// Token: 0x06045FEE RID: 286702 RVA: 0x0125E46E File Offset: 0x0125C66E
		protected override void OnStart(CameraModelInstance cameraModelInstance)
		{
			this.CameraModelInstance = cameraModelInstance;
			this.Inited = true;
		}

		// Token: 0x06045FEF RID: 286703 RVA: 0x0125E480 File Offset: 0x0125C680
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		private UniTask<BP_MovieCameraConfig_C> InitConfig(string daPath)
		{
			CameraMovieModeController.<InitConfig>d__42 <InitConfig>d__;
			<InitConfig>d__.<>t__builder = AsyncUniTaskMethodBuilder<BP_MovieCameraConfig_C>.Create();
			<InitConfig>d__.<>4__this = this;
			<InitConfig>d__.daPath = daPath;
			<InitConfig>d__.<>1__state = -1;
			<InitConfig>d__.<>t__builder.Start<CameraMovieModeController.<InitConfig>d__42>(ref <InitConfig>d__);
			return <InitConfig>d__.<>t__builder.Task;
		}

		// Token: 0x06045FF0 RID: 286704 RVA: 0x0125E4CC File Offset: 0x0125C6CC
		public UniTask PlaySpecialMovieCamera(string movieCameraConfigRowName, [Nullable(2)] Action<bool> callback = null)
		{
			CameraMovieModeController.<PlaySpecialMovieCamera>d__43 <PlaySpecialMovieCamera>d__;
			<PlaySpecialMovieCamera>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlaySpecialMovieCamera>d__.<>4__this = this;
			<PlaySpecialMovieCamera>d__.movieCameraConfigRowName = movieCameraConfigRowName;
			<PlaySpecialMovieCamera>d__.callback = callback;
			<PlaySpecialMovieCamera>d__.<>1__state = -1;
			<PlaySpecialMovieCamera>d__.<>t__builder.Start<CameraMovieModeController.<PlaySpecialMovieCamera>d__43>(ref <PlaySpecialMovieCamera>d__);
			return <PlaySpecialMovieCamera>d__.<>t__builder.Task;
		}

		// Token: 0x06045FF1 RID: 286705 RVA: 0x0125E51F File Offset: 0x0125C71F
		private void LoadSpecialMovieCameraConfig()
		{
			if (this.SpecialMovieCameraConfigDataTable != null || this.SpecialMovieCameraConfigLoading)
			{
				return;
			}
			this.SpecialMovieCameraConfigLoading = true;
			Singleton<ResourceSystem>.Instance.LoadAsync<UDataTable>("/Game/Aki/Data/Camera/DT_SpecialMovieCameraConfigList.DT_SpecialMovieCameraConfigList", delegate([Nullable(2)] UDataTable dataTable, string _)
			{
				this.SpecialMovieCameraConfigLoading = false;
				if (dataTable != null)
				{
					this.SpecialMovieCameraConfigDataTable = dataTable;
					if (this.SpecialMovieCameraConfigKey != "")
					{
						this.PlaySpecialMovieCamera(this.SpecialMovieCameraConfigKey, this.SpecialPlayCallback).Forget();
					}
					return;
				}
				Singleton<Log>.Instance.Error(ELogModule.Camera, ELogAuthor.LJM, "[电影镜头][特殊]异步加载DT表失败", default(ReadOnlySpan<ValueTuple<string, object>>));
				Action<bool> specialPlayCallback = this.SpecialPlayCallback;
				if (specialPlayCallback == null)
				{
					return;
				}
				specialPlayCallback(false);
			}, 100, "js_undefined");
		}

		// Token: 0x06045FF2 RID: 286706 RVA: 0x0125E55C File Offset: 0x0125C75C
		public UniTask PlayMovieCamera(string movieCameraConfigRowName, int initialPlayCameraIndex = -1, [Nullable(2)] Action<bool> callback = null)
		{
			CameraMovieModeController.<PlayMovieCamera>d__45 <PlayMovieCamera>d__;
			<PlayMovieCamera>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayMovieCamera>d__.<>4__this = this;
			<PlayMovieCamera>d__.movieCameraConfigRowName = movieCameraConfigRowName;
			<PlayMovieCamera>d__.initialPlayCameraIndex = initialPlayCameraIndex;
			<PlayMovieCamera>d__.callback = callback;
			<PlayMovieCamera>d__.<>1__state = -1;
			<PlayMovieCamera>d__.<>t__builder.Start<CameraMovieModeController.<PlayMovieCamera>d__45>(ref <PlayMovieCamera>d__);
			return <PlayMovieCamera>d__.<>t__builder.Task;
		}

		// Token: 0x06045FF3 RID: 286707 RVA: 0x0125E5B7 File Offset: 0x0125C7B7
		private void LoadMovieCameraConfig()
		{
			if (this.MovieCameraConfigDataTable != null || this.MovieCameraConfigLoading)
			{
				return;
			}
			this.MovieCameraConfigLoading = true;
			Singleton<ResourceSystem>.Instance.LoadAsync<UDataTable>("/Game/Aki/Data/Camera/DT_MovieCameraConfigList.DT_MovieCameraConfigList", delegate([Nullable(2)] UDataTable dataTable, string _)
			{
				if (dataTable != null)
				{
					this.MovieCameraConfigDataTable = dataTable;
					if (this.MovieCameraConfigKey != "")
					{
						this.PlayMovieCamera(this.MovieCameraConfigKey, this.InitialPlayCameraIndex, this.PlayCallback).Forget();
					}
					return;
				}
				Singleton<Log>.Instance.Error(ELogModule.Camera, ELogAuthor.LJM, "[电影镜头]异步加载DT表失败", default(ReadOnlySpan<ValueTuple<string, object>>));
				Action<bool> playCallback = this.PlayCallback;
				if (playCallback == null)
				{
					return;
				}
				playCallback(false);
			}, 100, "js_undefined");
		}

		// Token: 0x06045FF4 RID: 286708 RVA: 0x0125E5F4 File Offset: 0x0125C7F4
		[NullableContext(2)]
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		private UniTask<ULevelSequence> LoadLevelSequence(string path)
		{
			CameraMovieModeController.<LoadLevelSequence>d__47 <LoadLevelSequence>d__;
			<LoadLevelSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder<ULevelSequence>.Create();
			<LoadLevelSequence>d__.path = path;
			<LoadLevelSequence>d__.<>1__state = -1;
			<LoadLevelSequence>d__.<>t__builder.Start<CameraMovieModeController.<LoadLevelSequence>d__47>(ref <LoadLevelSequence>d__);
			return <LoadLevelSequence>d__.<>t__builder.Task;
		}

		// Token: 0x06045FF5 RID: 286709 RVA: 0x0125E638 File Offset: 0x0125C838
		private void PlaySequenceCamera(SMovieCameraConfigItem_SequenceSetting sequenceSetting)
		{
			this.StopMovieCameraInternal();
			if (Global.BaseCharacter == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Camera;
				ELogAuthor author = ELogAuthor.LJM;
				string message = "[电影镜头]Sequence镜头播放失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Global.BaseCharacter", Global.BaseCharacter != null);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			Vector tempVector = this.TempVector;
			FVectorDouble fvectorDouble = sequenceSetting.BindTargetSetting.AttachLocationOffset;
			tempVector.FromUeVector(fvectorDouble);
			Rotator tempRotator = this.TempRotator;
			FRotator frotator = sequenceSetting.BindTargetSetting.AttachRotatorOffset;
			tempRotator.FromUeRotator(frotator);
			Vector tempVector2 = this.TempVector1;
			fvectorDouble = sequenceSetting.BindTargetSetting.SpecificLocationOffset;
			tempVector2.FromUeVector(fvectorDouble);
			Rotator tempRotator2 = this.TempRotator1;
			frotator = sequenceSetting.BindTargetSetting.SpecificRotatorOffset;
			tempRotator2.FromUeRotator(frotator);
			Vector tempVector3 = this.TempVector2;
			fvectorDouble = sequenceSetting.BindTargetSetting.WorldLocation;
			tempVector3.FromUeVector(fvectorDouble);
			Rotator tempRotator3 = this.TempRotator2;
			frotator = sequenceSetting.BindTargetSetting.WorldRotation;
			tempRotator3.FromUeRotator(frotator);
			ULevelSequence valueOrDefault = this.CacheLevelSequenceMap.GetValueOrDefault(this.GetCurrentPlayCameraConfigItem());
			if (valueOrDefault == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Camera, ELogAuthor.LJM, "[电影镜头]Sequence镜头播放失败,不应出现此情况", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.StopMovieCameraInternal();
				return;
			}
			this.SimpleLevelSequenceActor = new SimpleLevelSequenceActor(valueOrDefault);
			this.SimpleLevelSequenceActor.PlaySequence(new DefaultLevelSequencePlayParam(sequenceSetting.BlendInTime, sequenceSetting.BlendOutTime, this.Config.SmoothFactor, this.Config.SmoothDelta, new BindTargetSetting(sequenceSetting.BindTargetSetting.BindTargetType, sequenceSetting.BindTargetSetting.AttachSocketName, this.TempVector, this.TempRotator, this.TempVector1, this.TempRotator1, this.TempVector2, this.TempRotator2), new FollowTargetSetting(sequenceSetting.FollowTargetSetting.IsFollowTarget, sequenceSetting.FollowTargetSetting.FollowType == EMovieCameraSequenceSettingFollowTargetType.俯仰跟随, sequenceSetting.FollowTargetSetting.PitchFollowSpeed, sequenceSetting.FollowTargetSetting.FollowType == EMovieCameraSequenceSettingFollowTargetType.偏航跟随, sequenceSetting.FollowTargetSetting.FollowSpeed, sequenceSetting.FollowTargetSetting.FollowType == EMovieCameraSequenceSettingFollowTargetType.俯仰_偏航跟随, sequenceSetting.FollowTargetSetting.AngleFollowSpeed), Global.BaseCharacter));
			this.SimpleLevelSequenceActor.AddOnFinishedCallback(new Action(this.OnSequenceCameraFinished));
			this.SimpleLevelSequenceActor.AddOnStopCallback(new Action<bool>(this.OnSequenceCameraStopped));
		}

		// Token: 0x06045FF6 RID: 286710 RVA: 0x0125E880 File Offset: 0x0125CA80
		private unsafe void PlayFightCamera(SMovieCameraConfigItem_FightSubCameraSetting fightSetting)
		{
			this.StopMovieCameraInternal();
			int playerId = ModelBase<CreatureModel>.Instance.GetPlayerId();
			if (!ControllerBase<FormationDataController>.Instance.IsPlayerExist(playerId))
			{
				Singleton<Log>.Instance.Error(ELogModule.Camera, ELogAuthor.LJM, "[电影镜头]Fight镜头播放失败, 因为没有玩家队伍", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (Global.BaseCharacter == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Camera;
				ELogAuthor author = ELogAuthor.LJM;
				string message = "[电影镜头]Fight镜头播放失败";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("sequenceSetting", fightSetting.ToString());
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Global.BaseCharacter", Global.BaseCharacter != null);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			ControllerBase<FormationDataController>.Instance.AddPlayerTag(playerId, new int?(fightSetting.FightSubCameraTag.TagId()));
			this.FightCameraTagId = fightSetting.FightSubCameraTag.TagId();
			this.FightCameraTimerHandle = TimerSystem.FlowTimeInstance.Delay(new TTimerAction(this.OnFightCameraFinished), fightSetting.TimeLength * 1000f, null, null, true, 1f);
		}

		// Token: 0x06045FF7 RID: 286711 RVA: 0x0125E990 File Offset: 0x0125CB90
		public void PauseMovieCamera()
		{
			TimerHandle fightCameraTimerHandle = this.FightCameraTimerHandle;
			if (fightCameraTimerHandle != null && fightCameraTimerHandle.Valid())
			{
				TimerSystem.FlowTimeInstance.Pause(this.FightCameraTimerHandle, null);
			}
			if (this.SimpleLevelSequenceActor != null)
			{
				this.SimpleLevelSequenceActor.Pause();
			}
		}

		// Token: 0x06045FF8 RID: 286712 RVA: 0x0125E9CB File Offset: 0x0125CBCB
		public void ResumeMovieCamera()
		{
			TimerHandle fightCameraTimerHandle = this.FightCameraTimerHandle;
			if (fightCameraTimerHandle != null && fightCameraTimerHandle.Valid())
			{
				TimerSystem.FlowTimeInstance.Resume(this.FightCameraTimerHandle);
			}
			if (this.SimpleLevelSequenceActor != null)
			{
				this.SimpleLevelSequenceActor.Resume();
			}
		}

		// Token: 0x06045FF9 RID: 286713 RVA: 0x0125EA08 File Offset: 0x0125CC08
		private bool PlayNextMovieCamera()
		{
			if (this.MovieCameraConfig == null)
			{
				this.StopMovieCamera(null, "[电影镜头]没有常规电影镜头数据,停止电影镜头");
				return false;
			}
			if (!this.CheckValid())
			{
				return false;
			}
			this.CurrentPlayState = EMovieCameraPlayState.Play;
			EMovieCameraSwitchType emovieCameraSwitchType = this.MovieCameraConfig.MovieCameraSwitchType;
			if (emovieCameraSwitchType == EMovieCameraSwitchType.随机切换)
			{
				return this.RandomPlayMovieCamera();
			}
			if (emovieCameraSwitchType - EMovieCameraSwitchType.顺序切换 > 1)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Camera;
				ELogAuthor author = ELogAuthor.LJM;
				string message = "[电影镜头]未支持的播放模式";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", (int)this.MovieCameraConfig.MovieCameraSwitchType);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			return this.SequencePlayMovieCamera();
		}

		// Token: 0x06045FFA RID: 286714 RVA: 0x0125EAA8 File Offset: 0x0125CCA8
		private bool RandomPlayMovieCamera()
		{
			if (this.MovieCameraCacheList.Count <= 0)
			{
				return false;
			}
			int num = (int)Math.Round((double)Singleton<MathUtils>.Instance.GetRandomFloatNumber(0f, (float)(this.MovieCameraCacheList.Count - 1)));
			int valueOrDefault = this.MovieCameraCacheIndexMap.GetValueOrDefault(num, -1);
			int cacheIndex;
			if (this.MovieCameraIndexCacheMap.TryGetValue(this.DebugPlayIndex, out cacheIndex))
			{
				this.PlayMovieCameraByCacheIndex(this.DebugPlayIndex, cacheIndex);
			}
			else
			{
				this.PlayMovieCameraByCacheIndex(valueOrDefault, num);
			}
			return true;
		}

		// Token: 0x06045FFB RID: 286715 RVA: 0x0125EB28 File Offset: 0x0125CD28
		private bool SequencePlayMovieCamera()
		{
			if (this.MovieCameraCacheList.Count <= 0)
			{
				return false;
			}
			int num = (this.CurrentPlayCameraCacheIndex == -1) ? 0 : ((this.CurrentPlayCameraCacheIndex + 1) % this.MovieCameraCacheList.Count);
			int valueOrDefault = this.MovieCameraCacheIndexMap.GetValueOrDefault(num, -1);
			int cacheIndex;
			if (this.MovieCameraIndexCacheMap.TryGetValue(this.DebugPlayIndex, out cacheIndex))
			{
				this.PlayMovieCameraByCacheIndex(this.DebugPlayIndex, cacheIndex);
			}
			else
			{
				this.PlayMovieCameraByCacheIndex(valueOrDefault, num);
			}
			return true;
		}

		// Token: 0x06045FFC RID: 286716 RVA: 0x0125EBA4 File Offset: 0x0125CDA4
		private bool PlayMovieCameraByConfigIndex(int index)
		{
			int cacheIndex;
			if (!this.MovieCameraIndexCacheMap.TryGetValue(index, out cacheIndex))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Camera;
				ELogAuthor author = ELogAuthor.LJM;
				string message = "[电影镜头]使用DT表的索引播放电影镜头失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("index", index);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			return this.PlayMovieCameraByCacheIndex(index, cacheIndex);
		}

		// Token: 0x06045FFD RID: 286717 RVA: 0x0125EBF8 File Offset: 0x0125CDF8
		private unsafe bool PlayMovieCameraByCacheIndex(int index, int cacheIndex)
		{
			this.StopMovieCameraInternal();
			if (cacheIndex < 0 || cacheIndex >= this.MovieCameraCacheList.Count)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Camera;
				ELogAuthor author = ELogAuthor.LJM;
				string message = "[电影镜头]使用缓存的索引播放电影镜头失败";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("index", index);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("cacheIndex", cacheIndex);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("cacheLength", this.MovieCameraCacheList.Count);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				return false;
			}
			this.CurrentPlayCameraIndex = index;
			this.CurrentPlayCameraCacheIndex = cacheIndex;
			this.CurrentPlayCameraConfigItem = this.MovieCameraConfigItemList[this.MovieCameraCacheList[cacheIndex]];
			EMovieCameraItemType emovieCameraItemType = this.CurrentPlayCameraConfigItem.Type;
			if (emovieCameraItemType != EMovieCameraItemType.战斗子镜头)
			{
				if (emovieCameraItemType == EMovieCameraItemType.Sequence镜头)
				{
					this.PlaySequenceCamera(this.CurrentPlayCameraConfigItem.SequenceSetting);
				}
			}
			else
			{
				this.PlayFightCamera(this.CurrentPlayCameraConfigItem.FightSubCameraSetting);
			}
			return true;
		}

		// Token: 0x06045FFE RID: 286718 RVA: 0x0125ED10 File Offset: 0x0125CF10
		private bool PlayMovieCameraByConfigItem(SMovieCameraConfigItem movieCameraConfigItem)
		{
			this.StopMovieCameraInternal();
			this.CurrentPlaySpecialCameraConfigItem = movieCameraConfigItem;
			EMovieCameraItemType emovieCameraItemType = this.CurrentPlaySpecialCameraConfigItem.Type;
			if (emovieCameraItemType != EMovieCameraItemType.战斗子镜头)
			{
				if (emovieCameraItemType == EMovieCameraItemType.Sequence镜头)
				{
					this.PlaySequenceCamera(this.CurrentPlaySpecialCameraConfigItem.SequenceSetting);
				}
			}
			else
			{
				this.PlayFightCamera(this.CurrentPlaySpecialCameraConfigItem.FightSubCameraSetting);
			}
			return true;
		}

		// Token: 0x06045FFF RID: 286719 RVA: 0x0125ED68 File Offset: 0x0125CF68
		public void StopMovieCamera([Nullable(2)] Action<bool> callback = null, string reason = "")
		{
			this.RemoveMovieCameraTag();
			this.CurrentPlayState = EMovieCameraPlayState.Stop;
			this.StopMovieCameraInternal();
			this.SpecialMovieCameraConfigLoading = false;
			this.SpecialMovieCameraConfigDataTable = null;
			this.SpecialMovieCameraConfigKey = "";
			this.SpecialCameraConfigItem = null;
			this.CurrentPlaySpecialCameraConfigItem = null;
			this.SpecialPlayCallback = null;
			this.CurrentPlaySpecialCameraConfigItem = null;
			this.MovieCameraConfigLoading = false;
			this.MovieCameraConfigDataTable = null;
			this.MovieCameraConfigKey = "";
			this.InitialPlayCameraIndex = -1;
			this.PlayCallback = null;
			this.MovieCameraConfig = null;
			this.MovieCameraConfigItemList.Clear();
			this.MovieCameraCacheList.Clear();
			this.MovieCameraIndexCacheMap.Clear();
			this.MovieCameraCacheIndexMap.Clear();
			this.CurrentPlayCameraIndex = -1;
			this.CurrentPlayCameraCacheIndex = -1;
			this.CurrentPlayCameraConfigItem = null;
			this.CacheLevelSequenceMap.Clear();
			this.FightCameraTagId = -1;
			this.FightCameraTimerHandle = null;
			this.SimpleLevelSequenceActor = null;
			if (callback != null)
			{
				callback(true);
			}
		}

		// Token: 0x06046000 RID: 286720 RVA: 0x0125EE56 File Offset: 0x0125D056
		private void StopMovieCameraInternal()
		{
			this.StopSequenceCameraInternal();
			this.StopFightCameraInternal();
		}

		// Token: 0x06046001 RID: 286721 RVA: 0x0125EE64 File Offset: 0x0125D064
		private void StopSequenceCameraInternal()
		{
			if (!this.CheckValid())
			{
				return;
			}
			if (this.SimpleLevelSequenceActor == null)
			{
				return;
			}
			this.SimpleLevelSequenceActor.StopSequence();
			this.SimpleLevelSequenceActor = null;
		}

		// Token: 0x06046002 RID: 286722 RVA: 0x0125EE8C File Offset: 0x0125D08C
		private void StopFightCameraInternal()
		{
			if (!this.CheckValid())
			{
				return;
			}
			if (this.FightCameraTagId == -1)
			{
				return;
			}
			int playerId = ModelBase<CreatureModel>.Instance.GetPlayerId();
			if (!ControllerBase<FormationDataController>.Instance.IsPlayerExist(playerId))
			{
				return;
			}
			TimerHandle fightCameraTimerHandle = this.FightCameraTimerHandle;
			if (fightCameraTimerHandle != null && fightCameraTimerHandle.Valid())
			{
				TimerSystem.FlowTimeInstance.Remove(this.FightCameraTimerHandle);
				this.FightCameraTimerHandle = null;
			}
			ControllerBase<FormationDataController>.Instance.RemovePlayerTag(playerId, new int?(this.FightCameraTagId));
			this.CameraModelInstance.FightCamera.LogicComponent.ForceTickOutSide();
			this.FightCameraTagId = -1;
		}

		// Token: 0x06046003 RID: 286723 RVA: 0x0125EF23 File Offset: 0x0125D123
		public int GetCurrentPlayState()
		{
			return (int)this.CurrentPlayState;
		}

		// Token: 0x06046004 RID: 286724 RVA: 0x0125EF2B File Offset: 0x0125D12B
		public int GetCurrentPlayCameraIndex()
		{
			return this.CurrentPlayCameraIndex;
		}

		// Token: 0x06046005 RID: 286725 RVA: 0x0125EF33 File Offset: 0x0125D133
		public int GetCurrentPlayCameraCacheIndex()
		{
			return this.CurrentPlayCameraCacheIndex;
		}

		// Token: 0x06046006 RID: 286726 RVA: 0x0125EF3B File Offset: 0x0125D13B
		[NullableContext(2)]
		public SMovieCameraConfigItem GetCurrentPlayCameraConfigItem()
		{
			if (this.CurrentPlayState == EMovieCameraPlayState.PlaySpecial)
			{
				return this.CurrentPlaySpecialCameraConfigItem;
			}
			return this.CurrentPlayCameraConfigItem;
		}

		// Token: 0x06046007 RID: 286727 RVA: 0x0125EF53 File Offset: 0x0125D153
		public bool IsPlayingSpecialMovieCamera(string specialMovieCameraConfigKey)
		{
			return this.CurrentPlayState == EMovieCameraPlayState.PlaySpecial && this.SpecialMovieCameraConfigKey == specialMovieCameraConfigKey;
		}

		// Token: 0x06046008 RID: 286728 RVA: 0x0125EF6C File Offset: 0x0125D16C
		private bool CheckValid()
		{
			return this.Inited;
		}

		// Token: 0x06046009 RID: 286729 RVA: 0x0125EF74 File Offset: 0x0125D174
		private void AddMovieCameraTag()
		{
			int playerId = ModelBase<CreatureModel>.Instance.GetPlayerId();
			if (!ControllerBase<FormationDataController>.Instance.IsPlayerExist(playerId))
			{
				return;
			}
			foreach (int num in CameraMovieModeController.MovieModeTagList)
			{
				if (!ControllerBase<FormationDataController>.Instance.HasPlayerTag(playerId, num, true))
				{
					ControllerBase<FormationDataController>.Instance.AddPlayerTag(playerId, new int?(num));
				}
			}
		}

		// Token: 0x0604600A RID: 286730 RVA: 0x0125EFD4 File Offset: 0x0125D1D4
		private void RemoveMovieCameraTag()
		{
			int playerId = ModelBase<CreatureModel>.Instance.GetPlayerId();
			if (!ControllerBase<FormationDataController>.Instance.IsPlayerExist(playerId))
			{
				return;
			}
			foreach (int num in CameraMovieModeController.MovieModeTagList)
			{
				if (ControllerBase<FormationDataController>.Instance.HasPlayerTag(playerId, num, true))
				{
					ControllerBase<FormationDataController>.Instance.RemovePlayerTag(playerId, new int?(num));
				}
			}
		}

		// Token: 0x0604600B RID: 286731 RVA: 0x0125F032 File Offset: 0x0125D232
		private void OnSequenceCameraStopped(bool isSequenceStopWithFinish)
		{
			if (!isSequenceStopWithFinish)
			{
				return;
			}
			this.StopSequenceCameraInternal();
			if (this.CurrentPlayState == EMovieCameraPlayState.Stop)
			{
				return;
			}
			this.PlayNextMovieCamera();
		}

		// Token: 0x0604600C RID: 286732 RVA: 0x0125F04F File Offset: 0x0125D24F
		private void OnSequenceCameraFinished()
		{
			this.StopSequenceCameraInternal();
			if (this.CurrentPlayState == EMovieCameraPlayState.Stop)
			{
				return;
			}
			this.PlayNextMovieCamera();
		}

		// Token: 0x0604600D RID: 286733 RVA: 0x0125F068 File Offset: 0x0125D268
		private void OnFightCameraFinished(float delta)
		{
			this.StopFightCameraInternal();
			if (this.CurrentPlayState == EMovieCameraPlayState.Stop)
			{
				return;
			}
			this.PlayNextMovieCamera();
		}

		// Token: 0x0604600E RID: 286734 RVA: 0x0125F081 File Offset: 0x0125D281
		protected override void OnEnd()
		{
			this.StopMovieCamera(null, "系统销毁,停止电影镜头");
			this.Inited = false;
		}

		// Token: 0x0604600F RID: 286735 RVA: 0x0125F096 File Offset: 0x0125D296
		public static void CreateStaticDefaultValue()
		{
		}

		// Token: 0x06046010 RID: 286736 RVA: 0x0125F098 File Offset: 0x0125D298
		public static void ResetStaticDefaultValue()
		{
		}

		// Token: 0x04027409 RID: 160777
		private const string MOVIE_CAMERA_CONFIG_PATH = "/Game/Aki/Data/Camera/DT_MovieCameraConfigList.DT_MovieCameraConfigList";

		// Token: 0x0402740A RID: 160778
		private const string SPECIAL_MOVIE_CAMERA_CONFIG_PATH = "/Game/Aki/Data/Camera/DT_SpecialMovieCameraConfigList.DT_SpecialMovieCameraConfigList";

		// Token: 0x0402740B RID: 160779
		private const string MOVIE_CONFIG_DA_PATH = "/Game/Aki/Data/Camera/DA_MovieCameraConfig.DA_MovieCameraConfig";

		// Token: 0x0402740C RID: 160780
		private const int INVALID_GAMEPLAY_TAG_ID = -1;

		// Token: 0x0402740D RID: 160781
		private static readonly FName CameraTag = new FName("SequenceCamera");

		// Token: 0x0402740E RID: 160782
		[StaticVariableRuleIgnore]
		private static readonly int[] MovieModeTagList = new int[]
		{
			GameplayTagDefine.EGameplayTagId["角色.Common.载具驾驶.摩托.开启电影模式"]
		};

		// Token: 0x0402740F RID: 160783
		private bool Inited;

		// Token: 0x04027410 RID: 160784
		[Nullable(2)]
		private CameraModelInstance CameraModelInstance;

		// Token: 0x04027411 RID: 160785
		[Nullable(2)]
		private MovieCameraConfig Config;

		// Token: 0x04027412 RID: 160786
		private bool SpecialMovieCameraConfigLoading;

		// Token: 0x04027413 RID: 160787
		[Nullable(2)]
		private UDataTable SpecialMovieCameraConfigDataTable;

		// Token: 0x04027414 RID: 160788
		private string SpecialMovieCameraConfigKey = "";

		// Token: 0x04027415 RID: 160789
		[Nullable(2)]
		private SMovieCameraConfigItem SpecialCameraConfigItem;

		// Token: 0x04027416 RID: 160790
		[Nullable(2)]
		private Action<bool> SpecialPlayCallback;

		// Token: 0x04027417 RID: 160791
		[Nullable(2)]
		private SMovieCameraConfigItem CurrentPlaySpecialCameraConfigItem;

		// Token: 0x04027418 RID: 160792
		private bool MovieCameraConfigLoading;

		// Token: 0x04027419 RID: 160793
		[Nullable(2)]
		private UDataTable MovieCameraConfigDataTable;

		// Token: 0x0402741A RID: 160794
		private string MovieCameraConfigKey = "";

		// Token: 0x0402741B RID: 160795
		private int InitialPlayCameraIndex = -1;

		// Token: 0x0402741C RID: 160796
		[Nullable(2)]
		private Action<bool> PlayCallback;

		// Token: 0x0402741D RID: 160797
		[Nullable(2)]
		private SMovieCameraConfig MovieCameraConfig;

		// Token: 0x0402741E RID: 160798
		private readonly List<SMovieCameraConfigItem> MovieCameraConfigItemList = new List<SMovieCameraConfigItem>();

		// Token: 0x0402741F RID: 160799
		private readonly List<int> MovieCameraCacheList = new List<int>();

		// Token: 0x04027420 RID: 160800
		private readonly Dictionary<int, int> MovieCameraIndexCacheMap = new Dictionary<int, int>();

		// Token: 0x04027421 RID: 160801
		private readonly Dictionary<int, int> MovieCameraCacheIndexMap = new Dictionary<int, int>();

		// Token: 0x04027422 RID: 160802
		private int CurrentPlayCameraIndex = -1;

		// Token: 0x04027423 RID: 160803
		private int CurrentPlayCameraCacheIndex = -1;

		// Token: 0x04027424 RID: 160804
		[Nullable(2)]
		private SMovieCameraConfigItem CurrentPlayCameraConfigItem;

		// Token: 0x04027425 RID: 160805
		private EMovieCameraPlayState CurrentPlayState;

		// Token: 0x04027426 RID: 160806
		private readonly Dictionary<SMovieCameraConfigItem, ULevelSequence> CacheLevelSequenceMap = new Dictionary<SMovieCameraConfigItem, ULevelSequence>();

		// Token: 0x04027427 RID: 160807
		private int FightCameraTagId = -1;

		// Token: 0x04027428 RID: 160808
		[Nullable(2)]
		private TimerHandle FightCameraTimerHandle;

		// Token: 0x04027429 RID: 160809
		[Nullable(2)]
		private SimpleLevelSequenceActor SimpleLevelSequenceActor;

		// Token: 0x0402742A RID: 160810
		private readonly Vector TempVector = Vector.Create();

		// Token: 0x0402742B RID: 160811
		private readonly Vector TempVector1 = Vector.Create();

		// Token: 0x0402742C RID: 160812
		private readonly Vector TempVector2 = Vector.Create();

		// Token: 0x0402742D RID: 160813
		private readonly Rotator TempRotator = Rotator.Create();

		// Token: 0x0402742E RID: 160814
		private readonly Rotator TempRotator1 = Rotator.Create();

		// Token: 0x0402742F RID: 160815
		private readonly Rotator TempRotator2 = Rotator.Create();

		// Token: 0x04027430 RID: 160816
		private readonly int DebugPlayIndex = -1;
	}
}
