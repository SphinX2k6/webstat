using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using Google.Protobuf.Collections;
using UnrealEngine;

// Token: 0x020021E1 RID: 8673
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class LordGymController : ControllerBase<LordGymController>
{
	// Token: 0x060105A5 RID: 66981 RVA: 0x00477B99 File Offset: 0x00475D99
	protected override bool OnInit()
	{
		this.OnRegisterNetEvent();
		this.OnAddEvents();
		return true;
	}

	// Token: 0x060105A6 RID: 66982 RVA: 0x00477BA8 File Offset: 0x00475DA8
	protected override bool OnClear()
	{
		this.OnUnRegisterNetEvent();
		this.OnRemoveEvents();
		return true;
	}

	// Token: 0x060105A7 RID: 66983 RVA: 0x00477BB8 File Offset: 0x00475DB8
	protected void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<LordGymUnlockNotify>(ENotifyMessageId.LordGymUnlockNotify, new Action<LordGymUnlockNotify, Net.CallbackStatus>(this.OnLordGymUnlockNotify));
		Singleton<Net>.Instance.Register<LordGymLevelPlayResultNotify>(ENotifyMessageId.LordGymLevelPlayResultNotify, new Action<LordGymLevelPlayResultNotify, Net.CallbackStatus>(this.OnLordGymLevelPlayResultNotify));
		Singleton<Net>.Instance.Register<LordGymGroupInfoUpdateNotify>(ENotifyMessageId.LordGymGroupInfoUpdateNotify, new Action<LordGymGroupInfoUpdateNotify, Net.CallbackStatus>(this.OnLordGymGroupInfoUpdateNotify));
	}

	// Token: 0x060105A8 RID: 66984 RVA: 0x00477C19 File Offset: 0x00475E19
	protected void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.LordGymUnlockNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.LordGymLevelPlayResultNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.LordGymGroupInfoUpdateNotify);
	}

	// Token: 0x060105A9 RID: 66985 RVA: 0x00477C4B File Offset: 0x00475E4B
	protected void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.WorldDone));
		Singleton<EventSystem>.Instance.Add(EEventName.WorldDoneAndCloseLoading, new Action(this.OnWorldDoneAndCloseLoading));
	}

	// Token: 0x060105AA RID: 66986 RVA: 0x00477C85 File Offset: 0x00475E85
	protected void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.WorldDone));
		Singleton<EventSystem>.Instance.Remove(EEventName.WorldDoneAndCloseLoading, new Action(this.OnWorldDoneAndCloseLoading));
	}

	// Token: 0x060105AB RID: 66987 RVA: 0x00477CBF File Offset: 0x00475EBF
	private void WorldDone()
	{
		ModelBase<LordGymModel>.Instance.InitNewLordGymEntranceIdRecord();
		this.LordGymInfoRequest(0).Forget<bool>();
	}

	// Token: 0x060105AC RID: 66988 RVA: 0x00477CD7 File Offset: 0x00475ED7
	private void OnWorldDoneAndCloseLoading()
	{
		if (!this.IsInLordGymDungeon())
		{
			return;
		}
		this.EnterLordGymDungeon().Forget<bool>();
	}

	// Token: 0x060105AD RID: 66989 RVA: 0x00477CF0 File Offset: 0x00475EF0
	[NullableContext(0)]
	public UniTask<bool> LordGymInfoRequest(int timeoutMs = 0)
	{
		LordGymController.<LordGymInfoRequest>d__10 <LordGymInfoRequest>d__;
		<LordGymInfoRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<LordGymInfoRequest>d__.timeoutMs = timeoutMs;
		<LordGymInfoRequest>d__.<>1__state = -1;
		<LordGymInfoRequest>d__.<>t__builder.Start<LordGymController.<LordGymInfoRequest>d__10>(ref <LordGymInfoRequest>d__);
		return <LordGymInfoRequest>d__.<>t__builder.Task;
	}

	// Token: 0x060105AE RID: 66990 RVA: 0x00477D34 File Offset: 0x00475F34
	[NullableContext(0)]
	public UniTask<bool> LordGymBeginRequest(int lordId)
	{
		LordGymController.<LordGymBeginRequest>d__11 <LordGymBeginRequest>d__;
		<LordGymBeginRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<LordGymBeginRequest>d__.<>4__this = this;
		<LordGymBeginRequest>d__.lordId = lordId;
		<LordGymBeginRequest>d__.<>1__state = -1;
		<LordGymBeginRequest>d__.<>t__builder.Start<LordGymController.<LordGymBeginRequest>d__11>(ref <LordGymBeginRequest>d__);
		return <LordGymBeginRequest>d__.<>t__builder.Task;
	}

	// Token: 0x060105AF RID: 66991 RVA: 0x00477D7F File Offset: 0x00475F7F
	[NullableContext(2)]
	private void OnLordGymUnlockNotify(LordGymUnlockNotify data, Net.CallbackStatus _)
	{
		if (data == null)
		{
			return;
		}
		ModelBase<LordGymModel>.Instance.FirstUnLockLordGym = new List<int>(data.UnlockLoadGymIds);
	}

	// Token: 0x060105B0 RID: 66992 RVA: 0x00477D9A File Offset: 0x00475F9A
	[NullableContext(2)]
	private void OnLordGymGroupInfoUpdateNotify(LordGymGroupInfoUpdateNotify data, Net.CallbackStatus _)
	{
		if (data == null)
		{
			return;
		}
		LordGymModel instance = ModelBase<LordGymModel>.Instance;
		RepeatedField<LordGymGroupInfo> lordGymGroupInfos = data.LordGymGroupInfos;
		instance.UpdateLordGymGroupInfos((lordGymGroupInfos != null) ? lordGymGroupInfos.ToList<LordGymGroupInfo>() : null);
	}

	// Token: 0x060105B1 RID: 66993 RVA: 0x00477DBC File Offset: 0x00475FBC
	[NullableContext(0)]
	public UniTask<bool> OpenLordGymEntrance(int lordEntranceId, int entranceEntityId = 0)
	{
		LordGymController.<OpenLordGymEntrance>d__14 <OpenLordGymEntrance>d__;
		<OpenLordGymEntrance>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<OpenLordGymEntrance>d__.<>4__this = this;
		<OpenLordGymEntrance>d__.lordEntranceId = lordEntranceId;
		<OpenLordGymEntrance>d__.entranceEntityId = entranceEntityId;
		<OpenLordGymEntrance>d__.<>1__state = -1;
		<OpenLordGymEntrance>d__.<>t__builder.Start<LordGymController.<OpenLordGymEntrance>d__14>(ref <OpenLordGymEntrance>d__);
		return <OpenLordGymEntrance>d__.<>t__builder.Task;
	}

	// Token: 0x060105B2 RID: 66994 RVA: 0x00477E10 File Offset: 0x00476010
	[NullableContext(0)]
	public UniTask<bool> OpenLordGymLordEntranceSelectView(int lordEntranceSetId, int entranceEntityId = 0, bool isPlaySpecialSequence = false)
	{
		LordGymController.<OpenLordGymLordEntranceSelectView>d__15 <OpenLordGymLordEntranceSelectView>d__;
		<OpenLordGymLordEntranceSelectView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<OpenLordGymLordEntranceSelectView>d__.lordEntranceSetId = lordEntranceSetId;
		<OpenLordGymLordEntranceSelectView>d__.entranceEntityId = entranceEntityId;
		<OpenLordGymLordEntranceSelectView>d__.isPlaySpecialSequence = isPlaySpecialSequence;
		<OpenLordGymLordEntranceSelectView>d__.<>1__state = -1;
		<OpenLordGymLordEntranceSelectView>d__.<>t__builder.Start<LordGymController.<OpenLordGymLordEntranceSelectView>d__15>(ref <OpenLordGymLordEntranceSelectView>d__);
		return <OpenLordGymLordEntranceSelectView>d__.<>t__builder.Task;
	}

	// Token: 0x060105B3 RID: 66995 RVA: 0x00477E63 File Offset: 0x00476063
	public void OpenGymUnlockTipView(int lordGymId)
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.LordGymUnlockTipView, lordGymId, null);
		ModelBase<LordGymModel>.Instance.FirstUnLockLordGym = new List<int>();
	}

	// Token: 0x060105B4 RID: 66996 RVA: 0x00477E8C File Offset: 0x0047608C
	public UniTask ReadLordGym(int lordGymId)
	{
		LordGymController.<ReadLordGym>d__17 <ReadLordGym>d__;
		<ReadLordGym>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ReadLordGym>d__.lordGymId = lordGymId;
		<ReadLordGym>d__.<>1__state = -1;
		<ReadLordGym>d__.<>t__builder.Start<LordGymController.<ReadLordGym>d__17>(ref <ReadLordGym>d__);
		return <ReadLordGym>d__.<>t__builder.Task;
	}

	// Token: 0x060105B5 RID: 66997 RVA: 0x00477ECF File Offset: 0x004760CF
	public int GetLordGymGuideEntranceId(ELordGymVersion version)
	{
		switch (version)
		{
		case ELordGymVersion.First:
			return 3927;
		case ELordGymVersion.Second:
			return 3926;
		case ELordGymVersion.Third:
			return 3924;
		case ELordGymVersion.Third5:
			return 3925;
		default:
			return 0;
		}
	}

	// Token: 0x060105B6 RID: 66998 RVA: 0x00477F04 File Offset: 0x00476104
	[NullableContext(0)]
	public UniTask<bool> OpenLordGymViaGuide(ELordGymVersion version, int entranceId)
	{
		LordGymController.<OpenLordGymViaGuide>d__19 <OpenLordGymViaGuide>d__;
		<OpenLordGymViaGuide>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<OpenLordGymViaGuide>d__.<>4__this = this;
		<OpenLordGymViaGuide>d__.version = version;
		<OpenLordGymViaGuide>d__.entranceId = entranceId;
		<OpenLordGymViaGuide>d__.<>1__state = -1;
		<OpenLordGymViaGuide>d__.<>t__builder.Start<LordGymController.<OpenLordGymViaGuide>d__19>(ref <OpenLordGymViaGuide>d__);
		return <OpenLordGymViaGuide>d__.<>t__builder.Task;
	}

	// Token: 0x060105B7 RID: 66999 RVA: 0x00477F58 File Offset: 0x00476158
	[NullableContext(0)]
	public UniTask<bool> EnterLordGymDungeon()
	{
		LordGymController.<EnterLordGymDungeon>d__20 <EnterLordGymDungeon>d__;
		<EnterLordGymDungeon>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<EnterLordGymDungeon>d__.<>4__this = this;
		<EnterLordGymDungeon>d__.<>1__state = -1;
		<EnterLordGymDungeon>d__.<>t__builder.Start<LordGymController.<EnterLordGymDungeon>d__20>(ref <EnterLordGymDungeon>d__);
		return <EnterLordGymDungeon>d__.<>t__builder.Task;
	}

	// Token: 0x060105B8 RID: 67000 RVA: 0x00477F9C File Offset: 0x0047619C
	private List<IRewardExploreConfirmButton> BuildGuideReturnButtons(int? nextId, int returnEntranceId)
	{
		RewardExploreConfirmButtonData item = new RewardExploreConfirmButtonData
		{
			ButtonTextId = "Text_GymReturnToLordGym1.0_Text",
			DescriptionTextId = null,
			IsTimeDownCloseView = false,
			IsClickedCloseView = true,
			OnClickedCallback = delegate(int _)
			{
				ControllerBase<InstanceDungeonEntranceController>.Instance.EnterEntrance(returnEntranceId, 0, null).Forget<bool>();
			}
		};
		if (nextId != null && nextId.Value != 0 && ModelBase<LordGymModel>.Instance.GetLordGymIsUnLock(nextId.Value))
		{
			RewardExploreConfirmButtonData item2 = new RewardExploreConfirmButtonData
			{
				ButtonTextId = "Text_GymContinueChallenge_Text",
				DescriptionTextId = null,
				IsTimeDownCloseView = false,
				IsClickedCloseView = true,
				OnClickedCallback = delegate(int _)
				{
					ModelBase<LordGymModel>.Instance.EntryChallengeId = nextId.Value;
					ControllerBase<InstanceDungeonEntranceController>.Instance.RestartInstanceDungeon().Forget<bool>();
				}
			};
			return new List<IRewardExploreConfirmButton>
			{
				item,
				item2
			};
		}
		return new List<IRewardExploreConfirmButton>
		{
			item
		};
	}

	// Token: 0x060105B9 RID: 67001 RVA: 0x00478080 File Offset: 0x00476280
	[NullableContext(2)]
	private void OnLordGymLevelPlayResultNotify(LordGymLevelPlayResultNotify data, Net.CallbackStatus _)
	{
		if (data == null)
		{
			return;
		}
		LordGymModel instance = ModelBase<LordGymModel>.Instance;
		bool isDeadInChallenge = instance.IsDeadInChallenge;
		instance.IsDeadInChallenge = false;
		int loadGymId = data.LordGymPassRecord.LoadGymId;
		if (loadGymId != 0)
		{
			instance.LordGymRecord[loadGymId] = data.LordGymPassRecord;
		}
		bool isCurrentChallengeFromGuide = instance.IsCurrentChallengeFromGuide;
		instance.IsCurrentChallengeFromGuide = false;
		if (!data.IsSuccess)
		{
			this.HandlePlayResultFail(data, isCurrentChallengeFromGuide, isDeadInChallenge);
			return;
		}
		this.HandlePlayResultSuccess(data, loadGymId, isCurrentChallengeFromGuide);
	}

	// Token: 0x060105BA RID: 67002 RVA: 0x004780F0 File Offset: 0x004762F0
	private void HandlePlayResultFail(LordGymLevelPlayResultNotify data, bool isFromGuide, bool isDeadInChallenge)
	{
		int failLoadGymId = data.FailLoadGymId;
		LordGym? lordGymConfig = ConfigBase<LordGymConfig>.Instance.GetLordGymConfig(failLoadGymId);
		if (lordGymConfig == null)
		{
			return;
		}
		ELordGymVersion version = (ELordGymVersion)lordGymConfig.Value.Version;
		LordGymChallengeFailViewParam param = new LordGymChallengeFailViewParam
		{
			LordId = failLoadGymId,
			Version = version,
			IsFromGuide = isFromGuide
		};
		switch (version)
		{
		case ELordGymVersion.First:
			if (isFromGuide)
			{
				this.HandleFirstGuideFail(param, isDeadInChallenge);
			}
			return;
		case ELordGymVersion.Second:
			if (isFromGuide)
			{
				this.HandleSecondGuideFail(param, isDeadInChallenge);
			}
			return;
		case ELordGymVersion.Third:
			this.HandleThirdFail(param, isDeadInChallenge);
			return;
		case ELordGymVersion.Third5:
			this.HandleThird5Fail(param, isDeadInChallenge);
			return;
		default:
			return;
		}
	}

	// Token: 0x060105BB RID: 67003 RVA: 0x00478188 File Offset: 0x00476388
	private void HandleFirstGuideFail(LordGymChallengeFailViewParam param, bool isDeadInChallenge)
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.LordGymChallengeFailView, param, null);
	}

	// Token: 0x060105BC RID: 67004 RVA: 0x0047819B File Offset: 0x0047639B
	private void HandleSecondGuideFail(LordGymChallengeFailViewParam param, bool isDeadInChallenge)
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.LordGymChallengeFailView, param, null);
	}

	// Token: 0x060105BD RID: 67005 RVA: 0x004781AE File Offset: 0x004763AE
	private void HandleThirdFail(LordGymChallengeFailViewParam param, bool isDeadInChallenge)
	{
		this.OpenChallengeFailViewWithReviveDelay(param, isDeadInChallenge);
	}

	// Token: 0x060105BE RID: 67006 RVA: 0x004781B8 File Offset: 0x004763B8
	private void HandleThird5Fail(LordGymChallengeFailViewParam param, bool isDeadInChallenge)
	{
		this.OpenChallengeFailViewWithReviveDelay(param, isDeadInChallenge);
	}

	// Token: 0x060105BF RID: 67007 RVA: 0x004781C4 File Offset: 0x004763C4
	private void OpenChallengeFailViewWithReviveDelay(LordGymChallengeFailViewParam param, bool isDeadInChallenge)
	{
		Action open = delegate()
		{
			this.ChallengeFailViewDelayHandle = null;
			Singleton<UiManager>.Instance.OpenView(EUiViewName.LordGymChallengeFailView, param, null);
		};
		if (isDeadInChallenge)
		{
			this.ChallengeFailViewDelayHandle = TimerSystem.FlowTimeInstance.Delay(delegate(float _)
			{
				open();
			}, 3000f, null, null, true, 1f);
			return;
		}
		open();
	}

	// Token: 0x060105C0 RID: 67008 RVA: 0x00478230 File Offset: 0x00476430
	private void HandlePlayResultSuccess(LordGymLevelPlayResultNotify data, int gymId, bool isFromGuide)
	{
		LordGym? lordGymConfig = ConfigBase<LordGymConfig>.Instance.GetLordGymConfig(gymId);
		if (lordGymConfig == null)
		{
			return;
		}
		ELordGymVersion version = (ELordGymVersion)lordGymConfig.Value.Version;
		int? nextId = ModelBase<LordGymModel>.Instance.GetNextGymId(gymId);
		List<IRewardExploreConfirmButton> buttonInfoList = this.BuildSuccessButtonList(version, isFromGuide, nextId);
		List<RewardItemData> list = new List<RewardItemData>();
		foreach (Aki.Protocol.ItemData itemData in data.ItemDatas)
		{
			RewardItemData item = new RewardItemData(itemData.ItemId, itemData.Count, (itemData.ItemIncId != 0) ? new int?(itemData.ItemIncId) : null, EDropItemType.Normal);
			list.Add(item);
		}
		RewardExploreRecordData exploreRecordInfo = new RewardExploreRecordData
		{
			TitleTextId = "LordGym_TimeTitle",
			Record = Singleton<TimeUtil>.Instance.GetTimeString((double)data.PassTime),
			IsNewRecord = data.IsNewRecord
		};
		bool needShowUnlockTip = nextId != null && nextId.Value != 0 && !ModelBase<LordGymModel>.Instance.GetLordGymHasRead(nextId.Value) && ModelBase<LordGymModel>.Instance.GetLordGymIsUnLock(nextId.Value);
		ControllerBase<ItemRewardController>.Instance.OpenExploreRewardViewNew(new ExploreRewardViewData
		{
			ConfigId = 3011,
			IsSuccess = true,
			RewardItemDataList = list,
			ExploreRecordInfo = exploreRecordInfo,
			ButtonInfoList = buttonInfoList,
			OnCloseCallback = delegate
			{
				if (needShowUnlockTip)
				{
					Singleton<UiManager>.Instance.OpenView(EUiViewName.LordGymUnlockTipView, nextId.Value, null);
				}
			},
			IsBagFull = new bool?(data.IsPkgFull)
		});
	}

	// Token: 0x060105C1 RID: 67009 RVA: 0x004783F0 File Offset: 0x004765F0
	private List<IRewardExploreConfirmButton> BuildSuccessButtonList(ELordGymVersion version, bool isFromGuide, int? nextId)
	{
		switch (version)
		{
		case ELordGymVersion.First:
			if (!isFromGuide)
			{
				return this.BuildFirstWorldSuccessButtons();
			}
			return this.BuildFirstGuideSuccessButtons(nextId);
		case ELordGymVersion.Second:
			if (!isFromGuide)
			{
				return this.BuildSecondWorldSuccessButtons(nextId);
			}
			return this.BuildSecondGuideSuccessButtons(nextId);
		case ELordGymVersion.Third:
			return this.BuildThirdSuccessButtons(nextId);
		case ELordGymVersion.Third5:
			return this.BuildThird5SuccessButtons(nextId);
		default:
			return this.BuildFirstWorldSuccessButtons();
		}
	}

	// Token: 0x060105C2 RID: 67010 RVA: 0x00478452 File Offset: 0x00476652
	private List<IRewardExploreConfirmButton> BuildFirstGuideSuccessButtons(int? nextId)
	{
		return this.BuildGuideReturnButtons(nextId, 3927);
	}

	// Token: 0x060105C3 RID: 67011 RVA: 0x00478460 File Offset: 0x00476660
	private List<IRewardExploreConfirmButton> BuildFirstWorldSuccessButtons()
	{
		return new List<IRewardExploreConfirmButton>
		{
			new RewardExploreConfirmButtonData
			{
				ButtonTextId = "ConfirmBox_45_ButtonText_1",
				DescriptionTextId = null,
				IsTimeDownCloseView = false,
				IsClickedCloseView = true
			}
		};
	}

	// Token: 0x060105C4 RID: 67012 RVA: 0x00478492 File Offset: 0x00476692
	private List<IRewardExploreConfirmButton> BuildSecondGuideSuccessButtons(int? nextId)
	{
		return this.BuildGuideReturnButtons(nextId, 3926);
	}

	// Token: 0x060105C5 RID: 67013 RVA: 0x004784A0 File Offset: 0x004766A0
	private List<IRewardExploreConfirmButton> BuildSecondWorldSuccessButtons(int? nextId)
	{
		RewardExploreConfirmButtonData item = new RewardExploreConfirmButtonData
		{
			ButtonTextId = "Text_GymReturnToWorld_Text",
			DescriptionTextId = null,
			IsTimeDownCloseView = false,
			IsClickedCloseView = true
		};
		if (nextId != null && nextId.Value != 0 && ModelBase<LordGymModel>.Instance.GetLordGymIsUnLock(nextId.Value))
		{
			RewardExploreConfirmButtonData item2 = new RewardExploreConfirmButtonData
			{
				ButtonTextId = "Text_GymContinueChallenge_Text",
				DescriptionTextId = null,
				IsTimeDownCloseView = false,
				IsClickedCloseView = true,
				OnClickedCallback = delegate(int _)
				{
					this.LordGymBeginRequest(nextId.Value).Forget<bool>();
				}
			};
			return new List<IRewardExploreConfirmButton>
			{
				item,
				item2
			};
		}
		RewardExploreConfirmButtonData rewardExploreConfirmButtonData = new RewardExploreConfirmButtonData();
		rewardExploreConfirmButtonData.ButtonTextId = "Text_GymReturnToLordGym_Text";
		rewardExploreConfirmButtonData.DescriptionTextId = null;
		rewardExploreConfirmButtonData.IsTimeDownCloseView = false;
		rewardExploreConfirmButtonData.IsClickedCloseView = true;
		rewardExploreConfirmButtonData.OnClickedCallback = delegate(int _)
		{
			int entranceSetId = ModelBase<LordGymModel>.Instance.EntranceSetId;
			if (entranceSetId > 0)
			{
				LordGymLordEntranceSelectViewParam param = new LordGymLordEntranceSelectViewParam
				{
					EntranceSetId = entranceSetId,
					IsPlaySpecialSequence = new bool?(false)
				};
				Singleton<UiManager>.Instance.OpenView(EUiViewName.LordGymLordEntranceSelectView, param, null);
			}
		};
		RewardExploreConfirmButtonData item3 = rewardExploreConfirmButtonData;
		return new List<IRewardExploreConfirmButton>
		{
			item,
			item3
		};
	}

	// Token: 0x060105C6 RID: 67014 RVA: 0x004785C2 File Offset: 0x004767C2
	private List<IRewardExploreConfirmButton> BuildThirdSuccessButtons(int? nextId)
	{
		return this.BuildThirdLikeSuccessButtons(nextId, 3924, "ChanllengeBackToCockpit");
	}

	// Token: 0x060105C7 RID: 67015 RVA: 0x004785D5 File Offset: 0x004767D5
	private List<IRewardExploreConfirmButton> BuildThird5SuccessButtons(int? nextId)
	{
		return this.BuildThirdLikeSuccessButtons(nextId, 3925, "Text_GymReturnToLordGym3.5_Text");
	}

	// Token: 0x060105C8 RID: 67016 RVA: 0x004785E8 File Offset: 0x004767E8
	private List<IRewardExploreConfirmButton> BuildThirdLikeSuccessButtons(int? nextId, int entranceId, string returnTextId)
	{
		RewardExploreConfirmButtonData item = new RewardExploreConfirmButtonData
		{
			ButtonTextId = returnTextId,
			DescriptionTextId = null,
			IsTimeDownCloseView = false,
			IsClickedCloseView = true,
			OnClickedCallback = delegate(int _)
			{
				ControllerBase<InstanceDungeonEntranceController>.Instance.EnterEntrance(entranceId, 0, null).Forget<bool>();
			}
		};
		if (nextId != null && nextId.Value != 0 && ModelBase<LordGymModel>.Instance.GetLordGymIsUnLock(nextId.Value))
		{
			RewardExploreConfirmButtonData item2 = new RewardExploreConfirmButtonData
			{
				ButtonTextId = "Text_GymContinueChallenge_Text",
				DescriptionTextId = null,
				IsTimeDownCloseView = false,
				IsClickedCloseView = true,
				OnClickedCallback = delegate(int _)
				{
					ModelBase<LordGymModel>.Instance.EntryChallengeId = nextId.Value;
					ControllerBase<InstanceDungeonEntranceController>.Instance.RestartInstanceDungeon().Forget<bool>();
				}
			};
			return new List<IRewardExploreConfirmButton>
			{
				item,
				item2
			};
		}
		RewardExploreConfirmButtonData rewardExploreConfirmButtonData = new RewardExploreConfirmButtonData();
		rewardExploreConfirmButtonData.ButtonTextId = "Text_GymReturnToWorld_Text";
		rewardExploreConfirmButtonData.DescriptionTextId = null;
		rewardExploreConfirmButtonData.IsTimeDownCloseView = false;
		rewardExploreConfirmButtonData.IsClickedCloseView = true;
		rewardExploreConfirmButtonData.OnClickedCallback = delegate(int _)
		{
			ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeon().Forget<bool>();
		};
		RewardExploreConfirmButtonData item3 = rewardExploreConfirmButtonData;
		return new List<IRewardExploreConfirmButton>
		{
			item,
			item3
		};
	}

	// Token: 0x060105C9 RID: 67017 RVA: 0x00478718 File Offset: 0x00476918
	public bool IsInEntranceEntity()
	{
		int entranceEntityId = ModelBase<LordGymModel>.Instance.EntranceEntityId;
		if (entranceEntityId == 0)
		{
			return true;
		}
		EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById(entranceEntityId);
		if (entityById == null || !entityById.IsInit)
		{
			return true;
		}
		WorldEntity entity = entityById.Entity;
		bool? flag;
		if (entity == null)
		{
			flag = null;
		}
		else
		{
			PawnPerceptionComponent component = entity.GetComponent<PawnPerceptionComponent>();
			flag = ((component != null) ? new bool?(component.IsInInteractRange) : null);
		}
		bool? flag2 = flag;
		return flag2.GetValueOrDefault();
	}

	// Token: 0x060105CA RID: 67018 RVA: 0x0047878C File Offset: 0x0047698C
	public void CreateLordModelByEntranceId()
	{
		SkeletalObserverHandle lordSkeletalHandle = Singleton<UiSceneManager>.Instance.GetLordSkeletalHandle();
		if (lordSkeletalHandle == null)
		{
			return;
		}
		Singleton<UiModelUtil>.Instance.SetTransformByTag(lordSkeletalHandle.Model, "MonsterCase");
	}

	// Token: 0x060105CB RID: 67019 RVA: 0x004787C0 File Offset: 0x004769C0
	public UniTask LoadLordModelByEntranceId(int entranceId, bool autoPlayMaterialAnimation = true, bool playBossAudio = false)
	{
		LordGymController.<LoadLordModelByEntranceId>d__40 <LoadLordModelByEntranceId>d__;
		<LoadLordModelByEntranceId>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<LoadLordModelByEntranceId>d__.<>4__this = this;
		<LoadLordModelByEntranceId>d__.entranceId = entranceId;
		<LoadLordModelByEntranceId>d__.autoPlayMaterialAnimation = autoPlayMaterialAnimation;
		<LoadLordModelByEntranceId>d__.playBossAudio = playBossAudio;
		<LoadLordModelByEntranceId>d__.<>1__state = -1;
		<LoadLordModelByEntranceId>d__.<>t__builder.Start<LordGymController.<LoadLordModelByEntranceId>d__40>(ref <LoadLordModelByEntranceId>d__);
		return <LoadLordModelByEntranceId>d__.<>t__builder.Task;
	}

	// Token: 0x060105CC RID: 67020 RVA: 0x0047881C File Offset: 0x00476A1C
	[NullableContext(2)]
	public void PlayLordModelMaterialAnimationByEntranceId(int entranceId, UiModelBase model = null, UiModelLoadComponent loadComponent = null, bool playBossAudio = true, bool isStart = false)
	{
		if (Singleton<UiSceneManager>.Instance.GetLordSkeletalHandle() == null)
		{
			return;
		}
		if (playBossAudio)
		{
			Singleton<AudioSystem>.Instance.PostEvent("play_ui_daoguan_3_1_efx_boss");
		}
		LordGymEntrance? lordGymEntranceConfig = ConfigBase<LordGymConfig>.Instance.GetLordGymEntranceConfig(entranceId);
		if (lordGymEntranceConfig == null)
		{
			return;
		}
		string lordStartMaterialController = lordGymEntranceConfig.Value.LordStartMaterialController;
		string lordChangeMaterialController = lordGymEntranceConfig.Value.LordChangeMaterialController;
		string lordIdleMaterialController = lordGymEntranceConfig.Value.LordIdleMaterialController;
		string text = (isStart && !StringUtils.IsBlank(lordStartMaterialController)) ? lordStartMaterialController : lordChangeMaterialController;
		SkeletalObserverHandle lordSkeletalHandle = Singleton<UiSceneManager>.Instance.GetLordSkeletalHandle();
		UiModelBase uiModelBase = model ?? lordSkeletalHandle.Model;
		UiModelLoadComponent uiModelLoadComponent = loadComponent ?? uiModelBase.CheckGetComponent<UiModelLoadComponent>();
		UiModelRenderingMaterialComponent uiModelRenderingMaterialComponent = uiModelBase.CheckGetComponent<UiModelRenderingMaterialComponent>();
		if (!StringUtils.IsBlank(text))
		{
			UObject loadedResource = uiModelLoadComponent.GetLoadedResource(text);
			if (lordGymEntranceConfig.Value.IsGroup)
			{
				PD_CharacterControllerDataGroup_C pd_CharacterControllerDataGroup_C = loadedResource as PD_CharacterControllerDataGroup_C;
				if (pd_CharacterControllerDataGroup_C != null && uiModelRenderingMaterialComponent != null)
				{
					uiModelRenderingMaterialComponent.AddRenderingMaterialGroup(pd_CharacterControllerDataGroup_C);
				}
			}
			else
			{
				PD_CharacterControllerData_C pd_CharacterControllerData_C = loadedResource as PD_CharacterControllerData_C;
				if (pd_CharacterControllerData_C != null && uiModelRenderingMaterialComponent != null)
				{
					uiModelRenderingMaterialComponent.AddRenderingMaterialByData(pd_CharacterControllerData_C);
				}
			}
		}
		if (!StringUtils.IsBlank(lordIdleMaterialController))
		{
			UObject loadedResource2 = uiModelLoadComponent.GetLoadedResource(lordIdleMaterialController);
			if (lordGymEntranceConfig.Value.IsGroup)
			{
				PD_CharacterControllerDataGroup_C pd_CharacterControllerDataGroup_C2 = loadedResource2 as PD_CharacterControllerDataGroup_C;
				if (pd_CharacterControllerDataGroup_C2 != null && uiModelRenderingMaterialComponent != null)
				{
					uiModelRenderingMaterialComponent.AddRenderingMaterialGroup(pd_CharacterControllerDataGroup_C2);
					return;
				}
			}
			else
			{
				PD_CharacterControllerData_C pd_CharacterControllerData_C2 = loadedResource2 as PD_CharacterControllerData_C;
				if (pd_CharacterControllerData_C2 != null && uiModelRenderingMaterialComponent != null)
				{
					uiModelRenderingMaterialComponent.AddRenderingMaterialByData(pd_CharacterControllerData_C2);
				}
			}
		}
	}

	// Token: 0x060105CD RID: 67021 RVA: 0x00478990 File Offset: 0x00476B90
	public UniTask LoadLordModelByEntranceIdThird5(int entranceId, bool autoPlayMaterialAnimation = true, bool playBossAudio = false)
	{
		LordGymController.<LoadLordModelByEntranceIdThird5>d__42 <LoadLordModelByEntranceIdThird5>d__;
		<LoadLordModelByEntranceIdThird5>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<LoadLordModelByEntranceIdThird5>d__.<>4__this = this;
		<LoadLordModelByEntranceIdThird5>d__.entranceId = entranceId;
		<LoadLordModelByEntranceIdThird5>d__.autoPlayMaterialAnimation = autoPlayMaterialAnimation;
		<LoadLordModelByEntranceIdThird5>d__.playBossAudio = playBossAudio;
		<LoadLordModelByEntranceIdThird5>d__.<>1__state = -1;
		<LoadLordModelByEntranceIdThird5>d__.<>t__builder.Start<LordGymController.<LoadLordModelByEntranceIdThird5>d__42>(ref <LoadLordModelByEntranceIdThird5>d__);
		return <LoadLordModelByEntranceIdThird5>d__.<>t__builder.Task;
	}

	// Token: 0x060105CE RID: 67022 RVA: 0x004789EC File Offset: 0x00476BEC
	[NullableContext(2)]
	public void PlayLordModelMaterialAnimationByEntranceIdThird5(int entranceId, UiModelBase model = null, UiModelLoadComponent loadComponent = null, bool playBossAudio = true, bool isStart = false)
	{
		if (Singleton<UiSceneManager>.Instance.GetLordSkeletalHandle() == null)
		{
			return;
		}
		if (playBossAudio)
		{
			Singleton<AudioSystem>.Instance.PostEvent("play_ui_daoguan_3_5_efx_boss");
		}
		LordGymEntrance? lordGymEntranceConfig = ConfigBase<LordGymConfig>.Instance.GetLordGymEntranceConfig(entranceId);
		if (lordGymEntranceConfig == null)
		{
			return;
		}
		string lordStartMaterialController = lordGymEntranceConfig.Value.LordStartMaterialController;
		string lordChangeMaterialController = lordGymEntranceConfig.Value.LordChangeMaterialController;
		string lordIdleMaterialController = lordGymEntranceConfig.Value.LordIdleMaterialController;
		string text = (isStart && !StringUtils.IsBlank(lordStartMaterialController)) ? lordStartMaterialController : lordChangeMaterialController;
		SkeletalObserverHandle lordSkeletalHandle = Singleton<UiSceneManager>.Instance.GetLordSkeletalHandle();
		UiModelBase uiModelBase = model ?? lordSkeletalHandle.Model;
		UiModelLoadComponent uiModelLoadComponent = loadComponent ?? uiModelBase.CheckGetComponent<UiModelLoadComponent>();
		UiModelRenderingMaterialComponent uiModelRenderingMaterialComponent = uiModelBase.CheckGetComponent<UiModelRenderingMaterialComponent>();
		if (!StringUtils.IsBlank(text))
		{
			UObject loadedResource = uiModelLoadComponent.GetLoadedResource(text);
			if (lordGymEntranceConfig.Value.IsGroup)
			{
				PD_CharacterControllerDataGroup_C pd_CharacterControllerDataGroup_C = loadedResource as PD_CharacterControllerDataGroup_C;
				if (pd_CharacterControllerDataGroup_C != null && uiModelRenderingMaterialComponent != null)
				{
					uiModelRenderingMaterialComponent.AddRenderingMaterialGroup(pd_CharacterControllerDataGroup_C);
				}
			}
			else
			{
				PD_CharacterControllerData_C pd_CharacterControllerData_C = loadedResource as PD_CharacterControllerData_C;
				if (pd_CharacterControllerData_C != null && uiModelRenderingMaterialComponent != null)
				{
					uiModelRenderingMaterialComponent.AddRenderingMaterialByData(pd_CharacterControllerData_C);
				}
			}
		}
		if (!StringUtils.IsBlank(lordIdleMaterialController))
		{
			UObject loadedResource2 = uiModelLoadComponent.GetLoadedResource(lordIdleMaterialController);
			if (lordGymEntranceConfig.Value.IsGroup)
			{
				PD_CharacterControllerDataGroup_C pd_CharacterControllerDataGroup_C2 = loadedResource2 as PD_CharacterControllerDataGroup_C;
				if (pd_CharacterControllerDataGroup_C2 != null && uiModelRenderingMaterialComponent != null)
				{
					uiModelRenderingMaterialComponent.AddRenderingMaterialGroup(pd_CharacterControllerDataGroup_C2);
					return;
				}
			}
			else
			{
				PD_CharacterControllerData_C pd_CharacterControllerData_C2 = loadedResource2 as PD_CharacterControllerData_C;
				if (pd_CharacterControllerData_C2 != null && uiModelRenderingMaterialComponent != null)
				{
					uiModelRenderingMaterialComponent.AddRenderingMaterialByData(pd_CharacterControllerData_C2);
				}
			}
		}
	}

	// Token: 0x060105CF RID: 67023 RVA: 0x00478B60 File Offset: 0x00476D60
	public bool IsInLordGymDungeon()
	{
		InstanceDungeon? instanceDungeon = ModelBase<GameModeModel>.Instance.InstanceDungeon;
		return instanceDungeon != null && instanceDungeon.Value.InstSubType == 48;
	}

	// Token: 0x060105D0 RID: 67024 RVA: 0x00478B98 File Offset: 0x00476D98
	public bool IsInLordGymThird5Dungeon()
	{
		InstanceDungeon? instanceDungeon = ModelBase<GameModeModel>.Instance.InstanceDungeon;
		if (instanceDungeon == null || instanceDungeon.Value.InstSubType != 48)
		{
			return false;
		}
		IReadOnlyList<LordGymEntranceSet> configList = ConfigLordGymEntranceSetAll.GetConfigList(true);
		if (configList == null)
		{
			return false;
		}
		LordGymEntranceSet? lordGymEntranceSet = null;
		foreach (LordGymEntranceSet value in configList)
		{
			if (value.DungeonId == instanceDungeon.Value.Id)
			{
				lordGymEntranceSet = new LordGymEntranceSet?(value);
				break;
			}
		}
		return lordGymEntranceSet != null && lordGymEntranceSet.GetValueOrDefault().Id == 200104;
	}

	// Token: 0x060105D1 RID: 67025 RVA: 0x00478C60 File Offset: 0x00476E60
	public void ClearChallengeFailViewDelay()
	{
		if (this.ChallengeFailViewDelayHandle != null)
		{
			TimerSystem.FlowTimeInstance.Remove(this.ChallengeFailViewDelayHandle);
			this.ChallengeFailViewDelayHandle = null;
		}
	}

	// Token: 0x040080E4 RID: 32996
	private const float TIME_TO_REVIVE = 3000f;

	// Token: 0x040080E5 RID: 32997
	[Nullable(2)]
	private TimerHandle ChallengeFailViewDelayHandle;
}
