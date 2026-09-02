using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.AdventureGuide;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020014ED RID: 5357
[NullableContext(1)]
[Nullable(0)]
internal class ActivityRegressAdventureAdventureItem : GridProxyAbstract<int>
{
	// Token: 0x060095E7 RID: 38375 RVA: 0x00271840 File Offset: 0x0026FA40
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(5, new Action(this.OnClickJumpToBtn)),
			new ValueTuple<int, Delegate>(8, new Action(this.OnClickLockBtn))
		};
	}

	// Token: 0x060095E8 RID: 38376 RVA: 0x0027195C File Offset: 0x0026FB5C
	protected override UniTask OnBeforeStartAsync()
	{
		ActivityRegressAdventureAdventureItem.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivityRegressAdventureAdventureItem.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060095E9 RID: 38377 RVA: 0x0027199F File Offset: 0x0026FB9F
	protected override void OnStart()
	{
		this.RewardLayout = new GenericLayout<NewSoundDetectRewardItem, INewSoundDetectRewardItemData>(base.GetHorizontalLayout(3), new Func<NewSoundDetectRewardItem>(this.InitRewardItem), null, false, true);
	}

	// Token: 0x060095EA RID: 38378 RVA: 0x002719C2 File Offset: 0x0026FBC2
	private NewSoundDetectRewardItem InitRewardItem()
	{
		return new NewSoundDetectRewardItem();
	}

	// Token: 0x060095EB RID: 38379 RVA: 0x002719CC File Offset: 0x0026FBCC
	public override void Refresh(int data, bool isSelected, int gridIndex)
	{
		GachaRoleDevelopIns? gachaRoleDevelopIns = ConfigBase<ActivityRegressConfig>.Instance.GetGachaRoleDevelopIns(data);
		if (gachaRoleDevelopIns == null)
		{
			return;
		}
		GachaRoleDevelopIns value = gachaRoleDevelopIns.Value;
		this.GetGachaRoleDevelopInsId = data;
		SoundAreaDetectionRecord recordById = ModelBase<AdventureGuideModel>.Instance.GetRecordById(value.AdventureGuide);
		this.DataDungeon = recordById.DungeonDetectionRecord;
		this.DataSilent = recordById.SilentAreaDetectionRecord;
		if (this.DataDungeon == null && this.DataSilent == null)
		{
			return;
		}
		EDungeonType? edungeonType = new EDungeonType?((EDungeonType)recordById.Secondary);
		if (edungeonType.GetValueOrDefault() == EDungeonType.NoSoundArea)
		{
			InstanceDungeon? instanceDungeon;
			string textStringId = ((ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(value.DungeonDetection) != null) ? instanceDungeon.GetValueOrDefault().MapName : null) ?? "";
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textStringId, Array.Empty<object>());
		}
		else
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), recordById.Name, Array.Empty<object>());
		}
		UUITexture texture = base.GetTexture(0);
		UUIText text = base.GetText(2);
		bool flag = (this.DataDungeon != null) ? ModelBase<AdventureGuideModel>.Instance.GetIsDetectionPreOpenByRecord(this.DataDungeon) : ModelBase<AdventureGuideModel>.Instance.GetIsDetectionPreOpenByRecord(this.DataSilent);
		bool flag2 = edungeonType != null && ModelBase<AdventureGuideModel>.Instance.CheckTargetDungeonTypeCanShow(edungeonType.Value);
		base.SetButtonUiActive(5, flag2);
		base.GetItem(7).SetUIActive(!flag2);
		if (this.DataSilent != null && (edungeonType.GetValueOrDefault() == EDungeonType.NightMare || edungeonType.GetValueOrDefault() == EDungeonType.VisionSettlement))
		{
			SilentAreaDetection conf = this.DataSilent.Conf;
			ValueTuple<long, int> valueTuple;
			if (!flag)
			{
				AdventureGuideModel instance = ModelBase<AdventureGuideModel>.Instance;
				int? instId = new int?(conf.MapId);
				int[] levelPlayListArray = conf.GetLevelPlayListArray();
				ValueTuple<int, int> nightMareTarget = instance.GetNightMareTarget(instId, new int?((levelPlayListArray != null && levelPlayListArray.Length != 0) ? conf.GetLevelPlayListArray()[0] : 0));
				valueTuple = new ValueTuple<long, int>((long)nightMareTarget.Item1, nightMareTarget.Item2);
			}
			else
			{
				valueTuple = ModelBase<AdventureGuideModel>.Instance.GetNightMarePreOpenTarget(value.DungeonDetection);
			}
			ValueTuple<long, int> valueTuple2 = valueTuple;
			if (valueTuple2.Item2 < 0)
			{
				if (text != null)
				{
					text.SetUIActive(false);
				}
			}
			else
			{
				if (text != null)
				{
					text.SetUIActive(true);
				}
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "NightMareLeftTimes", new <>z__ReadOnlyArray<object>(new object[]
				{
					valueTuple2.Item1,
					valueTuple2.Item2
				}));
			}
			base.SetTextureShowUntilLoaded(recordById.BigIcon, texture, null);
		}
		else
		{
			string text2 = ConfigMultiTextLang.GetLocalTextNew(recordById.InstanceSubTypeDescription, null) ?? "";
			if (StringUtils.IsEmpty(text2))
			{
				if (text != null)
				{
					text.SetUIActive(false);
				}
			}
			else
			{
				if (text != null)
				{
					text.SetUIActive(true);
				}
				if (text != null)
				{
					text.SetText(text2, true);
				}
			}
			base.SetTextureShowUntilLoaded(recordById.BigIcon, texture, null);
		}
		if (edungeonType.GetValueOrDefault() == EDungeonType.NoSoundArea)
		{
			SilentAreaDetectionRecord silentAreaDetectData = ModelBase<AdventureGuideModel>.Instance.GetSilentAreaDetectData(recordById.Id);
			bool flag3 = ModelBase<MapModel>.Instance.MapMarkIsCanTeleport(silentAreaDetectData.Conf.MarkId);
			base.GetItem(6).SetUIActive(!flag3);
			AdventureTag adventureTag = this.AdventureTag;
			if (adventureTag != null)
			{
				adventureTag.RefreshItem(true);
			}
		}
		else
		{
			base.GetItem(6).SetUIActive(flag);
			AdventureTag adventureTag2 = this.AdventureTag;
			if (adventureTag2 != null)
			{
				adventureTag2.RefreshItem(false);
			}
		}
		if (this.DataDungeon != null)
		{
			this.RefreshRewardLayout(this.DataDungeon);
			return;
		}
		this.RefreshRewardLayout(this.DataSilent);
	}

	// Token: 0x060095EC RID: 38380 RVA: 0x00271D38 File Offset: 0x0026FF38
	private void OnClickLockBtn()
	{
		int? num = null;
		if (this.DataDungeon != null)
		{
			num = new int?(this.DataDungeon.Conf.Secondary);
		}
		else if (this.DataSilent != null)
		{
			num = new int?(this.DataSilent.Conf.Secondary);
		}
		int num2;
		if (num == null)
		{
			num2 = 0;
		}
		else
		{
			AdventureGuideConfig instance = ConfigBase<AdventureGuideConfig>.Instance;
			SecondaryGuideData? secondaryGuideData;
			num2 = ((instance != null) ? ((instance.GetSecondaryGuideDataConf(num.Value) != null) ? new int?(secondaryGuideData.GetValueOrDefault().ConditionGroupId) : null) : null).GetValueOrDefault();
		}
		int num3 = num2;
		if ((this.DataDungeon == null && this.DataSilent == null) || num3 <= 0)
		{
			return;
		}
		List<IActivityConditionData> list = new List<IActivityConditionData>();
		foreach (int conditionId in ConfigBase<ConditionConfig>.Instance.GetGroupConditionIds(num3))
		{
			Condition? conditionConfig = ConfigBase<ConditionConfig>.Instance.GetConditionConfig(conditionId);
			int accessType = -1;
			if (conditionConfig != null && conditionConfig.Value.AccessId != 0)
			{
				AccessPath? configById = ConfigBase<GetWayConfig>.Instance.GetConfigById(conditionConfig.Value.AccessId);
				accessType = ((configById != null) ? configById.Value.SkipName : -1);
			}
			ActivityConditionData item = new ActivityConditionData
			{
				ConditionId = conditionId,
				ConditionTextId = conditionConfig.Value.Description,
				IsFinished = false,
				AccessId = conditionConfig.Value.AccessId,
				AccessType = accessType
			};
			list.Add(item);
		}
		ConditionGroupData param = new ConditionGroupData(num3, list, "", false);
		Singleton<UiManager>.Instance.OpenView(EUiViewName.CommonConditionView, param, null);
	}

	// Token: 0x060095ED RID: 38381 RVA: 0x00271F16 File Offset: 0x00270116
	private void RefreshRewardLayout(DungeonDetectionRecord record)
	{
		this.RefreshRewardLayoutInternal(record.Conf);
	}

	// Token: 0x060095EE RID: 38382 RVA: 0x00271F29 File Offset: 0x00270129
	private void RefreshRewardLayout(SilentAreaDetectionRecord record)
	{
		this.RefreshRewardLayoutInternal(record.Conf);
	}

	// Token: 0x060095EF RID: 38383 RVA: 0x00271F3C File Offset: 0x0027013C
	private void RefreshRewardLayoutInternal(object recordConf)
	{
		int curWorldLevel = ModelBase<WorldLevelModel>.Instance.CurWorldLevel;
		SoundAreaDetectionRecord record = (this.DataDungeon != null) ? new SoundAreaDetectionRecord(ESoundAreaDataType.Dungeon, this.DataDungeon, null) : new SoundAreaDetectionRecord(ESoundAreaDataType.SilentArea, null, this.DataSilent);
		bool haveFinish = ModelBase<AdventureGuideModel>.Instance.IsDetectionFinished(record);
		Dictionary<int, int> dictionary = null;
		if (recordConf is DungeonDetection && ((DungeonDetection)recordConf).Secondary == 22)
		{
			GachaRoleDevelopIns? gachaRoleDevelopIns = ConfigBase<ActivityRegressConfig>.Instance.GetGachaRoleDevelopIns(this.GetGachaRoleDevelopInsId);
			if (gachaRoleDevelopIns == null)
			{
				return;
			}
			int? instanceRewardId = ConfigBase<InstanceDungeonConfig>.Instance.GetInstanceRewardId(gachaRoleDevelopIns.Value.DungeonDetection);
			List<TItem> exchangeRewardPreviewRewardList = ConfigBase<ExchangeRewardConfig>.Instance.GetExchangeRewardPreviewRewardList(instanceRewardId.Value, null);
			List<INewSoundDetectRewardItemData> list = new List<INewSoundDetectRewardItemData>();
			for (int i = 0; i < exchangeRewardPreviewRewardList.Count; i++)
			{
				TItem itemData = exchangeRewardPreviewRewardList[i];
				NewSoundDetectRewardItemData item = new NewSoundDetectRewardItemData
				{
					ItemData = itemData,
					HaveFinish = haveFinish
				};
				list.Add(item);
			}
			this.RewardLayout.RefreshByData(list, null, false);
			return;
		}
		else
		{
			if (recordConf is SilentAreaDetection)
			{
				SilentAreaDetection silentAreaDetection = (SilentAreaDetection)recordConf;
				if (silentAreaDetection.Secondary == 63 || silentAreaDetection.Secondary == 64)
				{
					dictionary = ConfigBase<AdventureGuideConfig>.Instance.GetNightMareShowReward(silentAreaDetection.ShowRewardMapCalabash());
				}
				else
				{
					dictionary = ConfigBase<AdventureGuideConfig>.Instance.GetShowReward(silentAreaDetection.ShowRewardMap(), new int?(curWorldLevel));
				}
			}
			else if (recordConf is DungeonDetection)
			{
				DungeonDetection dungeonDetection = (DungeonDetection)recordConf;
				dictionary = ConfigBase<AdventureGuideConfig>.Instance.GetShowReward(dungeonDetection.ShowRewardMap(), new int?(curWorldLevel));
			}
			if (dictionary == null)
			{
				return;
			}
			List<INewSoundDetectRewardItemData> list2 = new List<INewSoundDetectRewardItemData>();
			foreach (int num in dictionary.Keys)
			{
				int count = dictionary[num];
				TItem itemData2 = new TItem(new InventoryDefine.GetItemData(num, 0), count);
				NewSoundDetectRewardItemData item2 = new NewSoundDetectRewardItemData
				{
					ItemData = itemData2,
					HaveFinish = haveFinish
				};
				list2.Add(item2);
			}
			this.RewardLayout.RefreshByData(list2, null, false);
			return;
		}
	}

	// Token: 0x060095F0 RID: 38384 RVA: 0x00272168 File Offset: 0x00270368
	private void OnClickJumpToBtn()
	{
		Action onClickJumpToCallBack = this.OnClickJumpToCallBack;
		if (onClickJumpToCallBack != null)
		{
			onClickJumpToCallBack();
		}
		if (ControllerBase<GameModeController>.Instance.IsInInstance())
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("DungeonDetection", Array.Empty<object>());
			return;
		}
		if (this.DataDungeon != null)
		{
			bool isDetectionPreOpenByRecord = ModelBase<AdventureGuideModel>.Instance.GetIsDetectionPreOpenByRecord(this.DataDungeon);
			bool isMulti = ModelBase<GameModeModel>.Instance.IsMulti;
			if (this.DataDungeon.Conf.Secondary == 22 && isDetectionPreOpenByRecord && isMulti)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("ErrorCode_2000015_Text", Array.Empty<object>());
				return;
			}
			ActivityRegressHelper.ReportRecallLog1024New(EReportLogEventNewType.Adventure, this.DataDungeon.Conf.Id, 0);
			if (!isDetectionPreOpenByRecord)
			{
				ModelBase<AdventureGuideModel>.Instance.HandleGachaRoleDevelopEntranceJump(this.GetGachaRoleDevelopInsId);
				return;
			}
			this.HandlePreOpenDetection();
			return;
		}
		else
		{
			bool isDetectionPreOpenByRecord2 = ModelBase<AdventureGuideModel>.Instance.GetIsDetectionPreOpenByRecord(this.DataSilent);
			bool isMulti2 = ModelBase<GameModeModel>.Instance.IsMulti;
			if (this.DataSilent.Conf.Secondary == 22 && isDetectionPreOpenByRecord2 && isMulti2)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("ErrorCode_2000015_Text", Array.Empty<object>());
				return;
			}
			ActivityRegressHelper.ReportRecallLog1024New(EReportLogEventNewType.Adventure, this.DataSilent.Conf.Id, 0);
			if (!isDetectionPreOpenByRecord2)
			{
				ModelBase<AdventureGuideModel>.Instance.HandleGachaRoleDevelopEntranceJump(this.GetGachaRoleDevelopInsId);
				return;
			}
			this.HandlePreOpenDetection();
			return;
		}
	}

	// Token: 0x060095F1 RID: 38385 RVA: 0x002722C0 File Offset: 0x002704C0
	private void HandlePreOpenDetection()
	{
		if (ModelBase<OnlineModel>.Instance.GetIsTeamModel())
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("CantUseInMultiplayerMode", Array.Empty<object>());
			return;
		}
		PreOpenDetection? preOpenDetection = null;
		if (this.DataDungeon != null)
		{
			DungeonDetection conf = this.DataDungeon.Conf;
			preOpenDetection = ModelBase<AdventureGuideModel>.Instance.GetPreOpenDetectionConf(conf.Id, ESoundAreaDataType.Dungeon, conf.PreOpenId);
		}
		else
		{
			SilentAreaDetection conf2 = this.DataSilent.Conf;
			preOpenDetection = ModelBase<AdventureGuideModel>.Instance.GetPreOpenDetectionConf(conf2.Id, ESoundAreaDataType.SilentArea, conf2.PreOpenId);
		}
		bool flag = false;
		if (preOpenDetection != null)
		{
			flag = preOpenDetection.Value.Spoiler;
		}
		if (flag)
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.PreOpenSpoilConfirmBox);
			confirmBoxDataNew.FunctionMap[2] = new Action(this.<HandlePreOpenDetection>g__ConfirmFunction|16_0);
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			return;
		}
		this.HandlePreOpenDetectionConfirmAction();
	}

	// Token: 0x060095F2 RID: 38386 RVA: 0x002723A4 File Offset: 0x002705A4
	private void HandlePreOpenDetectionConfirmAction()
	{
		if (this.DataDungeon != null)
		{
			DungeonDetection conf = this.DataDungeon.Conf;
			ControllerBase<AdventureGuideController>.Instance.HandlePreOpenDetection(conf.Id, ESoundAreaDataType.Dungeon, conf.PreOpenId);
			return;
		}
		SilentAreaDetection conf2 = this.DataSilent.Conf;
		ControllerBase<AdventureGuideController>.Instance.HandlePreOpenDetection(conf2.Id, ESoundAreaDataType.SilentArea, conf2.PreOpenId);
	}

	// Token: 0x060095F4 RID: 38388 RVA: 0x0027240C File Offset: 0x0027060C
	[CompilerGenerated]
	private void <HandlePreOpenDetection>g__ConfirmFunction|16_0()
	{
		this.HandlePreOpenDetectionConfirmAction();
	}

	// Token: 0x04004567 RID: 17767
	[Nullable(2)]
	private DungeonDetectionRecord DataDungeon;

	// Token: 0x04004568 RID: 17768
	[Nullable(2)]
	private SilentAreaDetectionRecord DataSilent;

	// Token: 0x04004569 RID: 17769
	private int GetGachaRoleDevelopInsId;

	// Token: 0x0400456A RID: 17770
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<NewSoundDetectRewardItem, INewSoundDetectRewardItemData> RewardLayout;

	// Token: 0x0400456B RID: 17771
	[Nullable(2)]
	private AdventureTag AdventureTag;

	// Token: 0x0400456C RID: 17772
	[Nullable(2)]
	public Action OnClickJumpToCallBack;
}
