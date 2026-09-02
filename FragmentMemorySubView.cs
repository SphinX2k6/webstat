using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001339 RID: 4921
[NullableContext(2)]
[Nullable(0)]
public class FragmentMemorySubView : ActivitySubViewBase
{
	// Token: 0x06008658 RID: 34392 RVA: 0x002366D8 File Offset: 0x002348D8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06008659 RID: 34393 RVA: 0x002367C8 File Offset: 0x002349C8
	protected override UniTask OnBeforeStartAsync()
	{
		FragmentMemorySubView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<FragmentMemorySubView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600865A RID: 34394 RVA: 0x0023680B File Offset: 0x00234A0B
	[NullableContext(1)]
	protected override void OnSequenceClose(string sequenceName)
	{
	}

	// Token: 0x0600865B RID: 34395 RVA: 0x00236810 File Offset: 0x00234A10
	private unsafe void OnFragmentMemoryButtonClick(int value)
	{
		Singleton<EventSystem>.Instance.Emit<bool>(EEventName.ChangeActivityViewNeedBlurState, false);
		ModelBase<ActivityModel>.Instance.SendActivityViewJumpClickLogData(this.ActivityBaseData);
		if (!this.ActivityBaseData.GetPreGuideQuestFinishState())
		{
			int unFinishPreGuideQuestId = this.ActivityBaseData.GetUnFinishPreGuideQuestId();
			Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, unFinishPreGuideQuestId, null);
			return;
		}
		PhotoMemoryActivity? data = ConfigBase<FragmentMemoryConfig>.Instance.GetPhotoMemoryActivityById(this.ActivityBaseData.Id);
		FragmentMemoryTopicData topicData = ModelBase<FragmentMemoryModel>.Instance.GetTopicDataById(data.Value.TopicId);
		if (topicData == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FragmentMemory;
			ELogAuthor author = ELogAuthor.YZY;
			string message = "FragmentMemorySubView.OnFragmentMemoryButtonClick";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("message", "topicData is null");
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("topicId", data.Value.TopicId);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.PlaySequencePurely("HideView01", false, false, null, null, false);
		}
		Singleton<UiLayer>.Instance.SetShowMaskLayer("FragmentMemoryMask", true);
		TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
		{
			ModelBase<FragmentMemoryModel>.Instance.SaveTopicOpened(data.Value.TopicId);
			ModelBase<FragmentMemoryModel>.Instance.MemoryFragmentMainViewTryPlayAnimation = "Start02";
			FragmentMemoryMainViewOpenData fragmentMemoryMainViewOpenData = new FragmentMemoryMainViewOpenData();
			fragmentMemoryMainViewOpenData.FragmentMemoryTopicData = topicData;
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MemoryFragmentMainView, fragmentMemoryMainViewOpenData, null);
			Singleton<UiLayer>.Instance.SetShowMaskLayer("FragmentMemoryMask", false);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.ActivityBaseData.Id);
		}, 600f, null, null, true, 1f);
	}

	// Token: 0x0600865C RID: 34396 RVA: 0x0023698C File Offset: 0x00234B8C
	private void OnCollectMemoryButtonClick(int value)
	{
		ModelBase<ActivityModel>.Instance.SendActivityViewJumpClickLogData(this.ActivityBaseData);
		PhotoMemoryActivity? data = ConfigBase<FragmentMemoryConfig>.Instance.GetPhotoMemoryActivityById(this.ActivityBaseData.Id);
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.PlaySequencePurely("HideView02", false, false, null, null, false);
		}
		Singleton<UiLayer>.Instance.SetShowMaskLayer("FragmentMemoryMask", true);
		TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MemoryDetailView, (data != null) ? new int?(data.GetValueOrDefault().TopicId) : null, null);
			Singleton<UiLayer>.Instance.SetShowMaskLayer("FragmentMemoryMask", false);
		}, 600f, null, null, true, 1f);
	}

	// Token: 0x0600865D RID: 34397 RVA: 0x00236A21 File Offset: 0x00234C21
	protected override void OnStart()
	{
	}

	// Token: 0x0600865E RID: 34398 RVA: 0x00236A23 File Offset: 0x00234C23
	protected override void OnBeforeShow()
	{
		this.TryPlayAnimation();
	}

	// Token: 0x0600865F RID: 34399 RVA: 0x00236A2B File Offset: 0x00234C2B
	protected override void OnBeforeHide()
	{
		ModelBase<FragmentMemoryModel>.Instance.ActivitySubViewTryPlayAnimation = "";
		this.RemoveRedDot();
	}

	// Token: 0x06008660 RID: 34400 RVA: 0x00236A44 File Offset: 0x00234C44
	protected override void OnRefreshView()
	{
		Activity? localConfig = this.ActivityBaseData.LocalConfig;
		if (localConfig == null)
		{
			return;
		}
		this.RefreshDesc();
		this.RefreshTitle();
		this.RefreshReward();
		this.RefreshFunctionalComponent();
		this.RefreshState();
		this.RefreshButton();
		this.RefreshCollectButton();
		this.TryPlayAnimation();
		this.BindRedDot();
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.ActivityBaseData.Id);
	}

	// Token: 0x06008661 RID: 34401 RVA: 0x00236AB8 File Offset: 0x00234CB8
	private void TryPlayAnimation()
	{
		if (!StringUtils.IsEmpty(ModelBase<FragmentMemoryModel>.Instance.ActivitySubViewTryPlayAnimation))
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.PlaySequencePurely(ModelBase<FragmentMemoryModel>.Instance.ActivitySubViewTryPlayAnimation, false, false, null, null, false);
			}
			ModelBase<FragmentMemoryModel>.Instance.ActivitySubViewTryPlayAnimation = "";
			return;
		}
		LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
		if (((levelSequencePlayer2 != null) ? levelSequencePlayer2.GetCurrentSequence() : null) == "Start01")
		{
			LevelSequencePlayer levelSequencePlayer3 = this.LevelSequencePlayer;
			if (levelSequencePlayer3 != null)
			{
				levelSequencePlayer3.StopSequenceByKey("Start01", false, false);
			}
			LevelSequencePlayer levelSequencePlayer4 = this.LevelSequencePlayer;
			if (levelSequencePlayer4 == null)
			{
				return;
			}
			levelSequencePlayer4.ReplaySequenceByKey("Start01");
			return;
		}
		else
		{
			LevelSequencePlayer levelSequencePlayer5 = this.LevelSequencePlayer;
			if (levelSequencePlayer5 == null)
			{
				return;
			}
			levelSequencePlayer5.PlaySequencePurely("Start01", false, false, null, null, false);
			return;
		}
	}

	// Token: 0x06008662 RID: 34402 RVA: 0x00236B7C File Offset: 0x00234D7C
	private void BindRedDot()
	{
		ButtonItem fragmentMemoryButtonItem = this.FragmentMemoryButtonItem;
		if (fragmentMemoryButtonItem == null)
		{
			return;
		}
		fragmentMemoryButtonItem.BindRedDot(ERedDotName.FragmentMemoryEntrance, 0);
	}

	// Token: 0x06008663 RID: 34403 RVA: 0x00236B94 File Offset: 0x00234D94
	private void RemoveRedDot()
	{
		ButtonItem fragmentMemoryButtonItem = this.FragmentMemoryButtonItem;
		if (fragmentMemoryButtonItem == null)
		{
			return;
		}
		fragmentMemoryButtonItem.UnBindRedDot();
	}

	// Token: 0x06008664 RID: 34404 RVA: 0x00236BA8 File Offset: 0x00234DA8
	private void RefreshState()
	{
		bool flag = this.ActivityBaseData.IsUnLock();
		this.FunctionalComponent.SetPanelConditionVisible(!flag);
		if (!flag)
		{
			this.FunctionalComponent.SetPerformanceConditionLock(this.ActivityBaseData.ConditionGroupId, this.ActivityBaseData.Id);
		}
	}

	// Token: 0x06008665 RID: 34405 RVA: 0x00236BF4 File Offset: 0x00234DF4
	private void RefreshButton()
	{
		bool active = this.ActivityBaseData.IsUnLock();
		this.FragmentMemoryButtonItem.SetActive(active);
	}

	// Token: 0x06008666 RID: 34406 RVA: 0x00236C1C File Offset: 0x00234E1C
	private void RefreshTitle()
	{
		this.TitleComponent.SetActivityBaseData(this.ActivityBaseData);
		this.TitleComponent.SetTitleByText(this.ActivityBaseData.GetTitle());
		ValueTuple<bool, string, long> timeVisibleAndRemainTime = this.GetTimeVisibleAndRemainTime();
		bool item = timeVisibleAndRemainTime.Item1;
		string item2 = timeVisibleAndRemainTime.Item2;
		this.TitleComponent.SetTimeTextVisible(item);
		if (item)
		{
			this.TitleComponent.SetTimeTextByText(item2);
		}
	}

	// Token: 0x06008667 RID: 34407 RVA: 0x00236C80 File Offset: 0x00234E80
	protected override void OnTimer(float gap)
	{
		this.RefreshTitle();
	}

	// Token: 0x06008668 RID: 34408 RVA: 0x00236C88 File Offset: 0x00234E88
	private void RefreshDesc()
	{
		Activity? localConfig = this.ActivityBaseData.LocalConfig;
		string descTheme = localConfig.Value.DescTheme;
		string desc = localConfig.Value.Desc;
		bool flag = !StringUtils.IsEmpty(descTheme);
		this.TitleComponent.SetSubTitleVisible(flag);
		if (flag)
		{
			this.TitleComponent.SetSubTitleByTextId(descTheme, Array.Empty<string>());
		}
		this.DescriptionComponent.SetContentByTextId(desc, Array.Empty<string>());
	}

	// Token: 0x06008669 RID: 34409 RVA: 0x00236D00 File Offset: 0x00234F00
	private void RefreshReward()
	{
		List<TItem> previewReward = this.ActivityBaseData.GetPreviewReward(null);
		this.RewardListComponent.SetTitleByTextId("FragmentMemoryCollectReward");
		this.RewardListComponent.RefreshItemLayout(previewReward, null);
	}

	// Token: 0x0600866A RID: 34410 RVA: 0x00236D40 File Offset: 0x00234F40
	private void RefreshFunctionalComponent()
	{
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew("FragmentMemoryEnterText", null);
		this.FunctionalComponent.FunctionButton.SetText(localTextNew);
	}

	// Token: 0x0600866B RID: 34411 RVA: 0x00236D6C File Offset: 0x00234F6C
	private void RefreshCollectButton()
	{
		bool preGuideQuestFinishState = this.ActivityBaseData.GetPreGuideQuestFinishState();
		bool flag = this.ActivityBaseData.IsUnLock();
		ButtonItem fragmentMemoryButtonItem = this.FragmentMemoryButtonItem;
		if (fragmentMemoryButtonItem == null)
		{
			return;
		}
		fragmentMemoryButtonItem.SetActive(flag && preGuideQuestFinishState);
	}

	// Token: 0x04003F83 RID: 16259
	private const int HIDEVIEW01DELAY = 600;

	// Token: 0x04003F84 RID: 16260
	private const int HIDEVIEWDELAY = 600;

	// Token: 0x04003F85 RID: 16261
	[Nullable(1)]
	private const string FRAGMENTMEMORYMASK = "FragmentMemoryMask";

	// Token: 0x04003F86 RID: 16262
	[Nullable(1)]
	private const string START01 = "Start01";

	// Token: 0x04003F87 RID: 16263
	private ActivityTitleTypeA TitleComponent;

	// Token: 0x04003F88 RID: 16264
	private ActivityDescriptionTypeA DescriptionComponent;

	// Token: 0x04003F89 RID: 16265
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private ActivityRewardList<CommonItemSmallItemGrid, TItem> RewardListComponent;

	// Token: 0x04003F8A RID: 16266
	private ActivityFunctionalTypeA FunctionalComponent;

	// Token: 0x04003F8B RID: 16267
	private ButtonItem FragmentMemoryButtonItem;

	// Token: 0x020076DE RID: 30430
	[NullableContext(0)]
	private class EComponent
	{
		// Token: 0x04028F14 RID: 167700
		public const int TitleItem = 0;

		// Token: 0x04028F15 RID: 167701
		public const int DescItem = 1;

		// Token: 0x04028F16 RID: 167702
		public const int RewardItem = 2;

		// Token: 0x04028F17 RID: 167703
		public const int FunctionalAreaItem = 3;

		// Token: 0x04028F18 RID: 167704
		public const int CollectMemoryButton = 4;

		// Token: 0x04028F19 RID: 167705
		public const int FragmentMemoryButton = 5;
	}
}
