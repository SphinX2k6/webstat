using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using AkiClient.Game.Aki.Render.RuntimeBP.GI;
using CSharpScript.Game.Common;
using CSharpScript.Game.Effect;
using CSharpScript.Game.Render;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020021E8 RID: 8680
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class LordGymModel : ModelBase<LordGymModel>
{
	// Token: 0x060105D9 RID: 67033 RVA: 0x00478CC4 File Offset: 0x00476EC4
	protected override bool OnInit()
	{
		this.LordId2EntranceIdMap = new Dictionary<int, int>();
		foreach (LordGymEntrance lordGymEntrance in ConfigBase<LordGymConfig>.Instance.GetLordGymEntranceAllConfig())
		{
			foreach (int key in lordGymEntrance.LordGymList())
			{
				this.LordId2EntranceIdMap.Add(key, lordGymEntrance.Id);
			}
		}
		return true;
	}

	// Token: 0x060105DA RID: 67034 RVA: 0x00478D4C File Offset: 0x00476F4C
	public bool GetLordGymIsUnLock(int lordId)
	{
		return this.UnLockLordGym.Contains(lordId);
	}

	// Token: 0x060105DB RID: 67035 RVA: 0x00478D5C File Offset: 0x00476F5C
	public bool IsLordGymUnlockedByGroup(int lordId)
	{
		LordGym? lordGymConfig = ConfigBase<LordGymConfig>.Instance.GetLordGymConfig(lordId);
		int num;
		return lordGymConfig != null && this.LordGymGroupPassDiff.TryGetValue(lordGymConfig.Value.FilterType, out num) && lordGymConfig.Value.Difficulty <= num + 1;
	}

	// Token: 0x060105DC RID: 67036 RVA: 0x00478DB8 File Offset: 0x00476FB8
	public void UpdateLordGymGroupInfos([Nullable(new byte[]
	{
		2,
		1
	})] List<LordGymGroupInfo> infos)
	{
		this.LordGymGroupPassDiff.Clear();
		if (infos == null)
		{
			return;
		}
		foreach (LordGymGroupInfo lordGymGroupInfo in infos)
		{
			this.LordGymGroupPassDiff[lordGymGroupInfo.GroupId] = lordGymGroupInfo.PassDiff;
		}
	}

	// Token: 0x060105DD RID: 67037 RVA: 0x00478E28 File Offset: 0x00477028
	public bool GetLordGymHasRead(int lordId)
	{
		return this.ReadLoadGymIds.Contains(lordId);
	}

	// Token: 0x060105DE RID: 67038 RVA: 0x00478E36 File Offset: 0x00477036
	public void ReadLordGym(int lordId)
	{
		this.ReadLoadGymIds.Add(lordId);
	}

	// Token: 0x060105DF RID: 67039 RVA: 0x00478E44 File Offset: 0x00477044
	[NullableContext(2)]
	public int[] GetLordGymEntranceList(int lordEntranceId)
	{
		return ConfigBase<LordGymConfig>.Instance.GetLordGymEntranceLordList(lordEntranceId);
	}

	// Token: 0x060105E0 RID: 67040 RVA: 0x00478E54 File Offset: 0x00477054
	public bool GetLastGymFinish(int lordId)
	{
		LordGym value = ConfigBase<LordGymConfig>.Instance.GetLordGymConfig(lordId).Value;
		if (value.Difficulty <= 1)
		{
			return true;
		}
		if (this.IsLordGymUnlockedByGroup(lordId))
		{
			return true;
		}
		foreach (LordGym lordGym in ConfigBase<LordGymConfig>.Instance.GetLordGymAllConfigByDifficulty(value.Difficulty - 1))
		{
			if (lordGym.PlayId == value.PlayId)
			{
				return this.LordGymRecord.ContainsKey(lordGym.Id);
			}
		}
		return false;
	}

	// Token: 0x060105E1 RID: 67041 RVA: 0x00478EFC File Offset: 0x004770FC
	public int? GetNextGymId(int lordId)
	{
		LordGym value = ConfigBase<LordGymConfig>.Instance.GetLordGymConfig(lordId).Value;
		IReadOnlyList<LordGym> lordGymAllConfigByDifficulty = ConfigBase<LordGymConfig>.Instance.GetLordGymAllConfigByDifficulty(value.Difficulty + 1);
		if (lordGymAllConfigByDifficulty == null)
		{
			return null;
		}
		foreach (LordGym lordGym in lordGymAllConfigByDifficulty)
		{
			if (lordGym.PlayId == value.PlayId)
			{
				return new int?(lordGym.Id);
			}
		}
		return null;
	}

	// Token: 0x060105E2 RID: 67042 RVA: 0x00478FA4 File Offset: 0x004771A4
	public bool GetLordGymIsFinish(int lordId)
	{
		if (lordId == 0)
		{
			return false;
		}
		if (this.LordGymRecord.ContainsKey(lordId))
		{
			return true;
		}
		LordGym? lordGymConfig = ConfigBase<LordGymConfig>.Instance.GetLordGymConfig(lordId);
		if (lordGymConfig == null)
		{
			return false;
		}
		foreach (int lordId2 in this.LordGymRecord.Keys)
		{
			LordGym? lordGymConfig2 = ConfigBase<LordGymConfig>.Instance.GetLordGymConfig(lordId2);
			if (lordGymConfig2 != null && lordGymConfig2.Value.PlayId == lordGymConfig.Value.PlayId && lordGymConfig2.Value.Difficulty >= lordGymConfig.Value.Difficulty)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060105E3 RID: 67043 RVA: 0x00479084 File Offset: 0x00477284
	public int? GetMarkIdByLordGymId(int gymId)
	{
		int lordEntranceId;
		if (!this.LordId2EntranceIdMap.TryGetValue(gymId, out lordEntranceId))
		{
			return null;
		}
		LordGymEntrance? lordGymEntranceConfig = ConfigBase<LordGymConfig>.Instance.GetLordGymEntranceConfig(lordEntranceId);
		if (lordGymEntranceConfig == null)
		{
			return null;
		}
		return new int?(lordGymEntranceConfig.GetValueOrDefault().MarkId);
	}

	// Token: 0x060105E4 RID: 67044 RVA: 0x004790E0 File Offset: 0x004772E0
	public int GetEntranceIdByLordId(int lordId)
	{
		int result;
		if (this.LordId2EntranceIdMap != null && this.LordId2EntranceIdMap.TryGetValue(lordId, out result))
		{
			return result;
		}
		return 0;
	}

	// Token: 0x060105E5 RID: 67045 RVA: 0x00479108 File Offset: 0x00477308
	[NullableContext(2)]
	public string GetLordGymEntranceFinish(int gymEntranceId)
	{
		int? gymCanFightMaxLevelWithoutLockCondition = this.GetGymCanFightMaxLevelWithoutLockCondition(gymEntranceId);
		string str = this.GetHasFinishLord(gymEntranceId).ToString();
		string str2 = "/";
		int? num = gymCanFightMaxLevelWithoutLockCondition;
		return str + str2 + num.ToString();
	}

	// Token: 0x060105E6 RID: 67046 RVA: 0x00479148 File Offset: 0x00477348
	public int GetHasFinishLord(int gymEntranceId)
	{
		LordGymEntrance? lordGymEntranceConfig = ConfigBase<LordGymConfig>.Instance.GetLordGymEntranceConfig(gymEntranceId);
		if (lordGymEntranceConfig == null)
		{
			return 0;
		}
		int[] array = lordGymEntranceConfig.Value.LordGymList();
		int num = 0;
		foreach (int lordId in array)
		{
			if (this.GetLordGymIsFinish(lordId))
			{
				num++;
			}
		}
		return num;
	}

	// Token: 0x060105E7 RID: 67047 RVA: 0x004791A8 File Offset: 0x004773A8
	public int? GetMaxDifficultyLordGymEntrance(int gymEntranceId)
	{
		LordGymEntrance? lordGymEntranceConfig = ConfigBase<LordGymConfig>.Instance.GetLordGymEntranceConfig(gymEntranceId);
		if (lordGymEntranceConfig == null)
		{
			return null;
		}
		int num = 0;
		foreach (int lordId in lordGymEntranceConfig.Value.LordGymList())
		{
			LordGym? lordGymConfig = ConfigBase<LordGymConfig>.Instance.GetLordGymConfig(lordId);
			if (this.GetLordGymIsUnLock(lordId) && lordGymConfig.Value.Difficulty > num)
			{
				num = lordGymConfig.Value.Difficulty;
			}
		}
		return new int?(num);
	}

	// Token: 0x060105E8 RID: 67048 RVA: 0x00479244 File Offset: 0x00477444
	public int? GetMaxDifficultyLordGymEntranceCanFight(int gymEntranceId)
	{
		LordGymEntrance? lordGymEntranceConfig = ConfigBase<LordGymConfig>.Instance.GetLordGymEntranceConfig(gymEntranceId);
		if (lordGymEntranceConfig == null)
		{
			return null;
		}
		int num = 1;
		foreach (int num2 in lordGymEntranceConfig.Value.LordGymList())
		{
			LordGym? lordGymConfig = ConfigBase<LordGymConfig>.Instance.GetLordGymConfig(num2);
			if (lordGymConfig.Value.Difficulty > 1 && this.GetLordGymIsUnLock(num2) && this.GetLordGymIsFinish(num2 - 1) && lordGymConfig.Value.Difficulty > num)
			{
				num = lordGymConfig.Value.Difficulty;
			}
		}
		return new int?(num);
	}

	// Token: 0x060105E9 RID: 67049 RVA: 0x00479300 File Offset: 0x00477500
	public int GetCanFightLordGym(bool isNewLordGym = false)
	{
		foreach (int num in this.UnLockLordGym)
		{
			LordGym value = ConfigBase<LordGymConfig>.Instance.GetLordGymConfig(num).Value;
			bool lordGymIsUnLock = this.GetLordGymIsUnLock(num);
			bool flag = value.Difficulty == 1 || this.GetLordGymIsFinish(num - 1);
			bool lordGymIsFinish = this.GetLordGymIsFinish(num);
			if (lordGymIsUnLock && flag && !lordGymIsFinish)
			{
				return num;
			}
		}
		return 0;
	}

	// Token: 0x060105EA RID: 67050 RVA: 0x0047939C File Offset: 0x0047759C
	public bool GetGymEntranceAllFinish(int gymEntranceId)
	{
		LordGymEntrance? lordGymEntranceConfig = ConfigBase<LordGymConfig>.Instance.GetLordGymEntranceConfig(gymEntranceId);
		if (lordGymEntranceConfig == null)
		{
			return false;
		}
		foreach (int lordId in lordGymEntranceConfig.Value.LordGymList())
		{
			if (!this.GetLordGymIsFinish(lordId))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x060105EB RID: 67051 RVA: 0x004793F0 File Offset: 0x004775F0
	public int? GetGymCanFightMaxLevelWithoutLockCondition(int gymEntranceId)
	{
		LordGymEntrance? lordGymEntranceConfig = ConfigBase<LordGymConfig>.Instance.GetLordGymEntranceConfig(gymEntranceId);
		if (lordGymEntranceConfig == null)
		{
			return null;
		}
		int num = 1;
		foreach (int lordId in lordGymEntranceConfig.Value.LordGymList())
		{
			LordGym? lordGymConfig = ConfigBase<LordGymConfig>.Instance.GetLordGymConfig(lordId);
			if (lordGymConfig.Value.Difficulty > 1 && this.GetLordGymIsUnLock(lordId) && lordGymConfig.Value.Difficulty > num)
			{
				num = lordGymConfig.Value.Difficulty;
			}
		}
		return new int?(num);
	}

	// Token: 0x060105EC RID: 67052 RVA: 0x004794A0 File Offset: 0x004776A0
	public int? GetGymCanFightMaxLevel(int gymEntranceId)
	{
		LordGymEntrance? lordGymEntranceConfig = ConfigBase<LordGymConfig>.Instance.GetLordGymEntranceConfig(gymEntranceId);
		if (lordGymEntranceConfig == null)
		{
			return null;
		}
		int num = 1;
		foreach (int lordId in lordGymEntranceConfig.Value.LordGymList())
		{
			LordGym? lordGymConfig = ConfigBase<LordGymConfig>.Instance.GetLordGymConfig(lordId);
			if (lordGymConfig.Value.Difficulty > 1 && lordGymConfig.Value.Difficulty > num)
			{
				num = lordGymConfig.Value.Difficulty;
			}
		}
		return new int?(num);
	}

	// Token: 0x060105ED RID: 67053 RVA: 0x00479544 File Offset: 0x00477744
	[NullableContext(0)]
	public ValueTuple<int, int> GetLordGymCurrencyRewardAndTotalCount(int gymEntranceSetId)
	{
		int[] array = ConfigLordGymEntranceSetById.GetConfig(gymEntranceSetId, true).Value.LordEntranceList();
		int num = 0;
		int num2 = 0;
		LordGymConfig instance = ConfigBase<LordGymConfig>.Instance;
		ExchangeRewardConfig instance2 = ConfigBase<ExchangeRewardConfig>.Instance;
		foreach (int lordEntranceId in array)
		{
			foreach (int lordId in instance.GetLordGymEntranceConfig(lordEntranceId).Value.LordGymList())
			{
				int rewardId = instance.GetLordGymConfig(lordId).Value.RewardId;
				List<TItem> exchangeRewardPreviewRewardList = instance2.GetExchangeRewardPreviewRewardList(rewardId, null);
				bool lordGymIsFinish = this.GetLordGymIsFinish(lordId);
				foreach (TItem titem in exchangeRewardPreviewRewardList)
				{
					if (titem.ItemData.ItemId == 34 || titem.ItemData.ItemId == 63 || titem.ItemData.ItemId == 11 || titem.ItemData.ItemId == 82)
					{
						if (lordGymIsFinish)
						{
							num += titem.Count;
						}
						num2 += titem.Count;
					}
				}
			}
		}
		return new ValueTuple<int, int>(num, num2);
	}

	// Token: 0x060105EE RID: 67054 RVA: 0x004796AC File Offset: 0x004778AC
	public bool IsChallenging()
	{
		return this.CurrentChallengeLordGymId > 0;
	}

	// Token: 0x060105EF RID: 67055 RVA: 0x004796B7 File Offset: 0x004778B7
	public void InitNewLordGymEntranceIdRecord()
	{
		this.NewLordGymEntranceIdRecord = (LocalStorage.GetPlayer<List<int>>(ELocalStoragePlayerKey.NewLordGymEntranceIdRecord, null) ?? new List<int>());
	}

	// Token: 0x060105F0 RID: 67056 RVA: 0x004796D0 File Offset: 0x004778D0
	public void RecordNewLordGymEntrance(int entranceId)
	{
		if (this.NewLordGymEntranceIdRecord == null || this.IsNewLordGymEntranceRecord(entranceId))
		{
			return;
		}
		this.NewLordGymEntranceIdRecord.Add(entranceId);
		LocalStorage.SetPlayer<List<int>>(ELocalStoragePlayerKey.NewLordGymEntranceIdRecord, this.NewLordGymEntranceIdRecord);
	}

	// Token: 0x060105F1 RID: 67057 RVA: 0x004796FE File Offset: 0x004778FE
	public bool IsNewLordGymEntranceRecord(int entranceId)
	{
		List<int> newLordGymEntranceIdRecord = this.NewLordGymEntranceIdRecord;
		return newLordGymEntranceIdRecord != null && newLordGymEntranceIdRecord.Contains(entranceId);
	}

	// Token: 0x060105F2 RID: 67058 RVA: 0x00479714 File Offset: 0x00477914
	public void PhraseEntranceInfo(List<Aki.Protocol.LordGymEntranceInfo> info)
	{
		if (info == null)
		{
			return;
		}
		this.LordGymEntranceInfo.Clear();
		foreach (Aki.Protocol.LordGymEntranceInfo info2 in info)
		{
			global::LordGymEntranceInfo lordGymEntranceInfo = new global::LordGymEntranceInfo();
			lordGymEntranceInfo.Phrase(info2);
			this.LordGymEntranceInfo.Add(lordGymEntranceInfo);
		}
	}

	// Token: 0x060105F3 RID: 67059 RVA: 0x00479784 File Offset: 0x00477984
	public List<int> GetLordGymEntranceWithNewTag()
	{
		this.LordGymEntrancesWithNewTag.Clear();
		foreach (global::LordGymEntranceInfo lordGymEntranceInfo in this.LordGymEntranceInfo)
		{
			double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
			if (serverTime >= lordGymEntranceInfo.EffectBeginTime && serverTime <= lordGymEntranceInfo.EffectEndTime)
			{
				this.LordGymEntrancesWithNewTag.Add(lordGymEntranceInfo.Id);
			}
		}
		return this.LordGymEntrancesWithNewTag;
	}

	// Token: 0x060105F4 RID: 67060 RVA: 0x00479810 File Offset: 0x00477A10
	[NullableContext(2)]
	public ALevelSequenceActor GetLordGymThirdBossSequenceActor()
	{
		return this.LordGymThirdBossSequenceActor;
	}

	// Token: 0x060105F5 RID: 67061 RVA: 0x00479818 File Offset: 0x00477A18
	public void DestroyLordGymThirdBossSequenceActor()
	{
		if (this.LordGymThirdBossSequenceActor != null && this.LordGymThirdBossSequenceActor.IsValid())
		{
			ULevelSequencePlayer sequencePlayer = this.LordGymThirdBossSequenceActor.SequencePlayer;
			if (sequencePlayer != null)
			{
				sequencePlayer.Stop();
			}
			this.LordGymThirdBossSequenceActor.K2_DestroyActor();
			this.LordGymThirdBossSequenceActor = null;
		}
	}

	// Token: 0x060105F6 RID: 67062 RVA: 0x00479858 File Offset: 0x00477A58
	protected void PlaybackPosition(bool isStart)
	{
		if (this.LordGymThirdBossSequenceActor == null || !this.LordGymThirdBossSequenceActor.IsValid())
		{
			return;
		}
		UKuroSceneInteractionActorSystem ukuroSceneInteractionActorSystem = UKuroRenderingRuntimeBPPluginBPLibrary.GetSubsystem(GlobalData.World, UKuroSceneInteractionActorSystem.StaticClass()) as UKuroSceneInteractionActorSystem;
		AActor actorWithTag = UKuroCollectActorComponent.GetActorWithTag(FNameUtil.GetDynamicFName("MonsterCase").Value, ECollectActorType.UI);
		if (actorWithTag != null && actorWithTag.IsValid() && ukuroSceneInteractionActorSystem != null)
		{
			ukuroSceneInteractionActorSystem.SetSequenceWithTargetLevelActor(this.LordGymThirdBossSequenceActor, this.LordGymThirdBossSequenceActor.GetSequence(), actorWithTag);
		}
		UKuroSequenceRuntimeFunctionLibrary.SetSequenceInUiScene(this.LordGymThirdBossSequenceActor.GetSequence(), true);
		this.LordGymThirdBossSequenceActor.bOverrideInstanceData = true;
		UDefaultLevelSequenceInstanceData udefaultLevelSequenceInstanceData = this.LordGymThirdBossSequenceActor.DefaultInstanceData as UDefaultLevelSequenceInstanceData;
		FTransform transformOrigin = UKismetMathLibrary.Conv_TransformDoubleToTransform(ControllerBase<RenderModuleController>.Instance.GetKuroCurrentUiSceneTransform().Value);
		udefaultLevelSequenceInstanceData.TransformOrigin = transformOrigin;
		FFrameTime fframeTime;
		if (!isStart)
		{
			ALevelSequenceActor lordGymThirdBossSequenceActor = this.LordGymThirdBossSequenceActor;
			if (lordGymThirdBossSequenceActor == null)
			{
				fframeTime = null;
			}
			else
			{
				ULevelSequencePlayer sequencePlayer = lordGymThirdBossSequenceActor.SequencePlayer;
				fframeTime = ((sequencePlayer != null) ? sequencePlayer.GetEndTime().Time : null);
			}
		}
		else
		{
			ALevelSequenceActor lordGymThirdBossSequenceActor2 = this.LordGymThirdBossSequenceActor;
			if (lordGymThirdBossSequenceActor2 == null)
			{
				fframeTime = null;
			}
			else
			{
				ULevelSequencePlayer sequencePlayer2 = lordGymThirdBossSequenceActor2.SequencePlayer;
				fframeTime = ((sequencePlayer2 != null) ? sequencePlayer2.GetStartTime().Time : null);
			}
		}
		FFrameTime fframeTime2 = fframeTime;
		if (fframeTime2 != null)
		{
			FMovieSceneSequencePlaybackParams playbackPosition = new FMovieSceneSequencePlaybackParams(fframeTime2, 0f, "", EMovieScenePositionType.Frame, EUpdatePositionMethod.Play);
			ALevelSequenceActor lordGymThirdBossSequenceActor3 = this.LordGymThirdBossSequenceActor;
			if (lordGymThirdBossSequenceActor3 == null)
			{
				return;
			}
			ULevelSequencePlayer sequencePlayer3 = lordGymThirdBossSequenceActor3.SequencePlayer;
			if (sequencePlayer3 == null)
			{
				return;
			}
			sequencePlayer3.SetPlaybackPosition(playbackPosition);
		}
	}

	// Token: 0x060105F7 RID: 67063 RVA: 0x004799A8 File Offset: 0x00477BA8
	private UniTask CreateLordGymThirdBossSequence(bool isStart)
	{
		LordGymModel.<CreateLordGymThirdBossSequence>d__54 <CreateLordGymThirdBossSequence>d__;
		<CreateLordGymThirdBossSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateLordGymThirdBossSequence>d__.<>4__this = this;
		<CreateLordGymThirdBossSequence>d__.isStart = isStart;
		<CreateLordGymThirdBossSequence>d__.<>1__state = -1;
		<CreateLordGymThirdBossSequence>d__.<>t__builder.Start<LordGymModel.<CreateLordGymThirdBossSequence>d__54>(ref <CreateLordGymThirdBossSequence>d__);
		return <CreateLordGymThirdBossSequence>d__.<>t__builder.Task;
	}

	// Token: 0x060105F8 RID: 67064 RVA: 0x004799F4 File Offset: 0x00477BF4
	public UniTask EnterLordGymThirdBossScene(bool isStart)
	{
		LordGymModel.<EnterLordGymThirdBossScene>d__55 <EnterLordGymThirdBossScene>d__;
		<EnterLordGymThirdBossScene>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<EnterLordGymThirdBossScene>d__.<>4__this = this;
		<EnterLordGymThirdBossScene>d__.isStart = isStart;
		<EnterLordGymThirdBossScene>d__.<>1__state = -1;
		<EnterLordGymThirdBossScene>d__.<>t__builder.Start<LordGymModel.<EnterLordGymThirdBossScene>d__55>(ref <EnterLordGymThirdBossScene>d__);
		return <EnterLordGymThirdBossScene>d__.<>t__builder.Task;
	}

	// Token: 0x060105F9 RID: 67065 RVA: 0x00479A40 File Offset: 0x00477C40
	public void ExitLordGymThirdBossScene()
	{
		UKuroGISystem kuroGISystem = UKuroGISystem.GetKuroGISystem(GlobalData.World);
		if (kuroGISystem == null)
		{
			return;
		}
		BP_GlobalGI_C bp_GlobalGI_C = kuroGISystem.GetKuroGlobalGIActor() as BP_GlobalGI_C;
		bp_GlobalGI_C.UINeedLerpData = false;
		if (bp_GlobalGI_C.GlobalUiScenePostProcess != null)
		{
			bp_GlobalGI_C.GlobalUiScenePostProcess.bEnabled = true;
		}
		if (bp_GlobalGI_C.GlobalPostProcessVolume != null)
		{
			bp_GlobalGI_C.GlobalPostProcessVolume.bIsUISceneRendering = false;
		}
	}

	// Token: 0x060105FA RID: 67066 RVA: 0x00479A98 File Offset: 0x00477C98
	public void PreloadThird5SceneEffect(int entranceId)
	{
		LordGymEntrance? config = ConfigLordGymEntranceById.GetConfig(entranceId, true);
		if (config == null || string.IsNullOrEmpty(config.Value.LordUISceneEffect))
		{
			return;
		}
		EffectSystem instance = Singleton<EffectSystem>.Instance;
		UObject world = GlobalData.World;
		FTransformDouble? ftransformDouble = new FTransformDouble?(this.Third5SceneEffectTransform);
		instance.SpawnEffect(world, ftransformDouble, config.Value.LordUISceneEffect, "LordGymSceneEffect", null, EEffectType.UiScene3D, null, null, null, true, false);
	}

	// Token: 0x060105FB RID: 67067 RVA: 0x00479B08 File Offset: 0x00477D08
	public void PlayThird5SceneEffect(int entranceId)
	{
		if (Singleton<EffectSystem>.Instance.IsValid(this.Third5SceneEffectHandle))
		{
			Singleton<EffectSystem>.Instance.StopEffectById(this.Third5SceneEffectHandle, "[LordGymModel.PlayThird5SceneEffect]", true, null);
			this.Third5SceneEffectHandle = 0;
		}
		LordGymEntrance? config = ConfigLordGymEntranceById.GetConfig(entranceId, true);
		if (config == null || string.IsNullOrEmpty(config.Value.LordUISceneEffect))
		{
			return;
		}
		EffectSystem instance = Singleton<EffectSystem>.Instance;
		UObject world = GlobalData.World;
		FTransformDouble? ftransformDouble = new FTransformDouble?(this.Third5SceneEffectTransform);
		this.Third5SceneEffectHandle = instance.SpawnEffect(world, ftransformDouble, config.Value.LordUISceneEffect, "LordGymSceneEffect", null, EEffectType.UiScene3D, null, null, null, false, false);
		Singleton<AudioSystem>.Instance.PostEvent("play_ui_daoguan_3_5_efx_scene");
	}

	// Token: 0x060105FC RID: 67068 RVA: 0x00479BC4 File Offset: 0x00477DC4
	public void EnterLordGymThird5BossScene()
	{
		UKuroGISystem kuroGISystem = UKuroGISystem.GetKuroGISystem(GlobalData.World);
		if (kuroGISystem == null)
		{
			return;
		}
		BP_GlobalGI_C bp_GlobalGI_C = kuroGISystem.GetKuroGlobalGIActor() as BP_GlobalGI_C;
		bp_GlobalGI_C.UINeedLerpData = true;
		if (bp_GlobalGI_C.GlobalUiScenePostProcess != null)
		{
			bp_GlobalGI_C.GlobalUiScenePostProcess.bEnabled = false;
		}
		if (bp_GlobalGI_C.GlobalPostProcessVolume != null)
		{
			bp_GlobalGI_C.GlobalPostProcessVolume.bIsUISceneRendering = true;
		}
	}

	// Token: 0x060105FD RID: 67069 RVA: 0x00479C1C File Offset: 0x00477E1C
	public void ExitLordGymThird5BossScene()
	{
		UKuroGISystem kuroGISystem = UKuroGISystem.GetKuroGISystem(GlobalData.World);
		if (kuroGISystem == null)
		{
			return;
		}
		BP_GlobalGI_C bp_GlobalGI_C = kuroGISystem.GetKuroGlobalGIActor() as BP_GlobalGI_C;
		bp_GlobalGI_C.UINeedLerpData = false;
		if (bp_GlobalGI_C.GlobalUiScenePostProcess != null)
		{
			bp_GlobalGI_C.GlobalUiScenePostProcess.bEnabled = true;
		}
		if (bp_GlobalGI_C.GlobalPostProcessVolume != null)
		{
			bp_GlobalGI_C.GlobalPostProcessVolume.bIsUISceneRendering = false;
		}
		if (Singleton<EffectSystem>.Instance.IsValid(this.Third5SceneEffectHandle))
		{
			Singleton<EffectSystem>.Instance.StopEffectById(this.Third5SceneEffectHandle, "[LordGymModel.ExitLordGymThird5BossScene]", true, null);
			this.Third5SceneEffectHandle = 0;
		}
	}

	// Token: 0x060105FE RID: 67070 RVA: 0x00479CAC File Offset: 0x00477EAC
	public void EnterLordGymFirstBossScene()
	{
		UKuroGISystem kuroGISystem = UKuroGISystem.GetKuroGISystem(GlobalData.World);
		if (kuroGISystem == null)
		{
			return;
		}
		BP_GlobalGI_C bp_GlobalGI_C = kuroGISystem.GetKuroGlobalGIActor() as BP_GlobalGI_C;
		bp_GlobalGI_C.UINeedLerpData = true;
		if (bp_GlobalGI_C.GlobalUiScenePostProcess != null)
		{
			bp_GlobalGI_C.GlobalUiScenePostProcess.bEnabled = false;
		}
		if (bp_GlobalGI_C.GlobalPostProcessVolume != null)
		{
			bp_GlobalGI_C.GlobalPostProcessVolume.bIsUISceneRendering = true;
		}
	}

	// Token: 0x060105FF RID: 67071 RVA: 0x00479D04 File Offset: 0x00477F04
	public void ExitLordGymFirstBossScene()
	{
		UKuroGISystem kuroGISystem = UKuroGISystem.GetKuroGISystem(GlobalData.World);
		if (kuroGISystem == null)
		{
			return;
		}
		BP_GlobalGI_C bp_GlobalGI_C = kuroGISystem.GetKuroGlobalGIActor() as BP_GlobalGI_C;
		bp_GlobalGI_C.UINeedLerpData = false;
		if (bp_GlobalGI_C.GlobalUiScenePostProcess != null)
		{
			bp_GlobalGI_C.GlobalUiScenePostProcess.bEnabled = true;
		}
		if (bp_GlobalGI_C.GlobalPostProcessVolume != null)
		{
			bp_GlobalGI_C.GlobalPostProcessVolume.bIsUISceneRendering = false;
		}
	}

	// Token: 0x06010600 RID: 67072 RVA: 0x00479D5C File Offset: 0x00477F5C
	public LordGymModel()
	{
		FRotator frotator = new FRotator(0f, 0f, 0f);
		FVectorDouble fvectorDouble = new FVectorDouble(0.0, 0.0, 0.0);
		FVectorDouble fvectorDouble2 = new FVectorDouble(1.0, 1.0, 1.0);
		FVector fvector = fvectorDouble2;
		this.Third5SceneEffectTransform = new FTransformDouble(ref frotator, ref fvectorDouble, ref fvector);
		base..ctor();
	}

	// Token: 0x0400810B RID: 33035
	[Nullable(2)]
	protected Dictionary<int, int> LordId2EntranceIdMap;

	// Token: 0x0400810C RID: 33036
	public List<int> UnLockLordGym = new List<int>();

	// Token: 0x0400810D RID: 33037
	public List<int> ReadLoadGymIds = new List<int>();

	// Token: 0x0400810E RID: 33038
	public List<int> FirstUnLockLordGym = new List<int>();

	// Token: 0x0400810F RID: 33039
	public int EntranceEntityId;

	// Token: 0x04008110 RID: 33040
	public int EntranceSetId;

	// Token: 0x04008111 RID: 33041
	public int EntryChallengeId;

	// Token: 0x04008112 RID: 33042
	public int LastChallengeLordEntranceId;

	// Token: 0x04008113 RID: 33043
	public int CurrentChallengeLordGymId;

	// Token: 0x04008114 RID: 33044
	public bool IsDeadInChallenge;

	// Token: 0x04008115 RID: 33045
	public int LastChallengeLordId;

	// Token: 0x04008116 RID: 33046
	public bool SkipBossSelectInFlow;

	// Token: 0x04008117 RID: 33047
	public bool LastChallengeEntryFromGuide;

	// Token: 0x04008118 RID: 33048
	public bool IsCurrentChallengeFromGuide;

	// Token: 0x04008119 RID: 33049
	public Dictionary<int, LordGymPassRecord> LordGymRecord = new Dictionary<int, LordGymPassRecord>();

	// Token: 0x0400811A RID: 33050
	public Dictionary<int, int> LordGymGroupPassDiff = new Dictionary<int, int>();

	// Token: 0x0400811B RID: 33051
	public List<global::LordGymEntranceInfo> LordGymEntranceInfo = new List<global::LordGymEntranceInfo>();

	// Token: 0x0400811C RID: 33052
	public List<int> LordGymEntrancesWithNewTag = new List<int>();

	// Token: 0x0400811D RID: 33053
	[Nullable(2)]
	public List<int> NewLordGymEntranceIdRecord;

	// Token: 0x0400811E RID: 33054
	public FTransform CacheTransform;

	// Token: 0x0400811F RID: 33055
	public FVector CacheLocation;

	// Token: 0x04008120 RID: 33056
	public FRotator CacheRotator;

	// Token: 0x04008121 RID: 33057
	public FVector CacheScale;

	// Token: 0x04008122 RID: 33058
	[Nullable(2)]
	private ALevelSequenceActor LordGymThirdBossSequenceActor;

	// Token: 0x04008123 RID: 33059
	private int Third5SceneEffectHandle;

	// Token: 0x04008124 RID: 33060
	private readonly FTransformDouble Third5SceneEffectTransform;
}
