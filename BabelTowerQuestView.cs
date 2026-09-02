using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001239 RID: 4665
[NullableContext(1)]
[Nullable(0)]
public class BabelTowerQuestView : UiViewBase
{
	// Token: 0x06007C40 RID: 31808 RVA: 0x0020A944 File Offset: 0x00208B44
	public BabelTowerQuestView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06007C41 RID: 31809 RVA: 0x0020A970 File Offset: 0x00208B70
	protected unsafe override void OnRegisterComponent()
	{
		int num = 9;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06007C42 RID: 31810 RVA: 0x0020AAC1 File Offset: 0x00208CC1
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.BabelTowerRefreshQuestState, new Action(this.BabelTowerRefreshQuestState));
	}

	// Token: 0x06007C43 RID: 31811 RVA: 0x0020AADF File Offset: 0x00208CDF
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.BabelTowerRefreshQuestState, new Action(this.BabelTowerRefreshQuestState));
	}

	// Token: 0x06007C44 RID: 31812 RVA: 0x0020AB00 File Offset: 0x00208D00
	protected override UniTask OnBeforeStartAsync()
	{
		BabelTowerQuestView.<OnBeforeStartAsync>d__13 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<BabelTowerQuestView.<OnBeforeStartAsync>d__13>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06007C45 RID: 31813 RVA: 0x0020AB44 File Offset: 0x00208D44
	protected override void OnStart()
	{
		base.GetItem(5).SetUIActive(false);
		foreach (KeyValuePair<int, ActivityTask> keyValuePair in ControllerBase<BabelTowerController>.Instance.GetBabelTowerData().NormalQuest)
		{
			int key = keyValuePair.Key;
			BabelTowerTask babelTowerNormalQuest = ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerNormalQuest(key);
			if (ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerLevelConfig(babelTowerNormalQuest.LevelId).IsDifficult)
			{
				this.NormalDifficultyList.Add(key);
			}
			else
			{
				this.NormalSimpleList.Add(key);
			}
		}
		this.SortItemList();
		this.QuestTypeList.Add(EBabelTowerTabItem.NormalQuest);
		this.QuestTypeList.Add(EBabelTowerTabItem.HardQuest);
		GenericScrollViewNew<BabelTowerQuestTabItem, int> tabScrollerView = this.TabScrollerView;
		if (tabScrollerView == null)
		{
			return;
		}
		tabScrollerView.RefreshByData(this.QuestTypeList.ConvertAll<int>((EBabelTowerTabItem x) => (int)x), delegate
		{
			int count = this.TabScrollerView.GetScrollItemList().Count;
			BabelTowerData babelTowerData = ControllerBase<BabelTowerController>.Instance.GetBabelTowerData();
			bool flag = false;
			for (int i = 0; i < count; i++)
			{
				if (babelTowerData.GetQuestTabRedDot((int)this.QuestTypeList[i]))
				{
					GenericScrollViewNew<BabelTowerQuestTabItem, int> tabScrollerView2 = this.TabScrollerView;
					if (tabScrollerView2 != null)
					{
						BabelTowerQuestTabItem scrollItemByIndex = tabScrollerView2.GetScrollItemByIndex(i);
						if (scrollItemByIndex != null)
						{
							scrollItemByIndex.SelectToggle();
						}
					}
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				GenericScrollViewNew<BabelTowerQuestTabItem, int> tabScrollerView3 = this.TabScrollerView;
				if (tabScrollerView3 == null)
				{
					return;
				}
				BabelTowerQuestTabItem scrollItemByIndex2 = tabScrollerView3.GetScrollItemByIndex(0);
				if (scrollItemByIndex2 == null)
				{
					return;
				}
				scrollItemByIndex2.SelectToggle();
			}
		}, false);
	}

	// Token: 0x06007C46 RID: 31814 RVA: 0x0020AC58 File Offset: 0x00208E58
	protected override void OnBeforeShow()
	{
		this.RefreshView();
		Singleton<EventSystem>.Instance.Emit(EEventName.BabelTowerRefreshQuestState);
	}

	// Token: 0x06007C47 RID: 31815 RVA: 0x0020AC70 File Offset: 0x00208E70
	private void RefreshView()
	{
		EBabelTowerTabItem currentSelect = this.CurrentSelect;
		UUIInturnAnimController animController;
		if (currentSelect == EBabelTowerTabItem.NormalQuest)
		{
			base.GetScrollViewWithScrollbar(1).RootUIComp.Get().SetUIActive(true);
			UUIInturnAnimController animController = base.GetScrollViewWithScrollbar(1).Content.Get().GetComponentByClass(UUIInturnAnimController.StaticClass()) as UUIInturnAnimController;
			Action <>9__1;
			this.NormalLoopScrollerView.RefreshByData(this.NormalSimpleList, delegate
			{
				GenericScrollViewNew<BabelTowerNormalQuestItem, int> normalLoopScrollerView = this.NormalLoopScrollerView;
				UUIItem itemByIndex = this.NormalLoopScrollerView.GetItemByIndex(0);
				Action callBack;
				if ((callBack = <>9__1) == null)
				{
					callBack = (<>9__1 = delegate()
					{
						UUIInturnAnimController animController = animController;
						if (animController == null)
						{
							return;
						}
						animController.Play("", -1, false);
					});
				}
				normalLoopScrollerView.LateScrollTo(itemByIndex, callBack, false);
			}, false);
			return;
		}
		if (currentSelect != EBabelTowerTabItem.HardQuest)
		{
			return;
		}
		base.GetScrollViewWithScrollbar(1).RootUIComp.Get().SetUIActive(true);
		animController = (base.GetScrollViewWithScrollbar(1).Content.Get().GetComponentByClass(UUIInturnAnimController.StaticClass()) as UUIInturnAnimController);
		Action <>9__3;
		this.NormalLoopScrollerView.RefreshByData(this.NormalDifficultyList, delegate
		{
			GenericScrollViewNew<BabelTowerNormalQuestItem, int> normalLoopScrollerView = this.NormalLoopScrollerView;
			UUIItem itemByIndex = this.NormalLoopScrollerView.GetItemByIndex(0);
			Action callBack;
			if ((callBack = <>9__3) == null)
			{
				callBack = (<>9__3 = delegate()
				{
					UUIInturnAnimController animController = animController;
					if (animController == null)
					{
						return;
					}
					animController.Play("", -1, false);
				});
			}
			normalLoopScrollerView.LateScrollTo(itemByIndex, callBack, false);
		}, false);
	}

	// Token: 0x06007C48 RID: 31816 RVA: 0x0020AD77 File Offset: 0x00208F77
	private BabelTowerQuestTabItem InitTabItem()
	{
		return new BabelTowerQuestTabItem
		{
			OnClickToggleCallBack = new Action<UUIExtendToggle, int>(this.OnClickTabItem)
		};
	}

	// Token: 0x06007C49 RID: 31817 RVA: 0x0020AD90 File Offset: 0x00208F90
	private BabelTowerNormalQuestItem InitNormalQuestItem()
	{
		return new BabelTowerNormalQuestItem();
	}

	// Token: 0x06007C4A RID: 31818 RVA: 0x0020AD97 File Offset: 0x00208F97
	private void OnClickTabItem(UUIExtendToggle toggle, int index)
	{
		UUIExtendToggle currentSelectToggle = this.CurrentSelectToggle;
		if (currentSelectToggle != null)
		{
			currentSelectToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}
		this.CurrentSelectToggle = toggle;
		this.CurrentSelect = (EBabelTowerTabItem)index;
		this.RefreshView();
	}

	// Token: 0x06007C4B RID: 31819 RVA: 0x0020ADC4 File Offset: 0x00208FC4
	private void SortItemList()
	{
		BabelTowerData data = ControllerBase<BabelTowerController>.Instance.GetBabelTowerData();
		this.NormalSimpleList.Sort(delegate(int a, int b)
		{
			ActivityTask activityTask;
			data.NormalQuest.TryGetValue(a, out activityTask);
			int num = (activityTask != null && activityTask.Status == ActivityTaskState.ActivityTaskFinish) ? 0 : ((activityTask != null && activityTask.Status == ActivityTaskState.ActivityTaskRunning) ? 1 : 2);
			ActivityTask activityTask2;
			data.NormalQuest.TryGetValue(b, out activityTask2);
			int num2 = (activityTask2 != null && activityTask2.Status == ActivityTaskState.ActivityTaskFinish) ? 0 : ((activityTask2 != null && activityTask2.Status == ActivityTaskState.ActivityTaskRunning) ? 1 : 2);
			return num - num2;
		});
		this.NormalDifficultyList.Sort(delegate(int a, int b)
		{
			ActivityTask activityTask;
			data.NormalQuest.TryGetValue(a, out activityTask);
			int num = (activityTask != null && activityTask.Status == ActivityTaskState.ActivityTaskFinish) ? 0 : ((activityTask != null && activityTask.Status == ActivityTaskState.ActivityTaskRunning) ? 1 : 2);
			ActivityTask activityTask2;
			data.NormalQuest.TryGetValue(b, out activityTask2);
			int num2 = (activityTask2 != null && activityTask2.Status == ActivityTaskState.ActivityTaskFinish) ? 0 : ((activityTask2 != null && activityTask2.Status == ActivityTaskState.ActivityTaskRunning) ? 1 : 2);
			return num - num2;
		});
	}

	// Token: 0x06007C4C RID: 31820 RVA: 0x0020AE15 File Offset: 0x00209015
	private void BabelTowerRefreshQuestState()
	{
		this.SortItemList();
		this.RefreshView();
	}

	// Token: 0x04003B68 RID: 15208
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x04003B69 RID: 15209
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollViewNew<BabelTowerQuestTabItem, int> TabScrollerView;

	// Token: 0x04003B6A RID: 15210
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollViewNew<BabelTowerNormalQuestItem, int> NormalLoopScrollerView;

	// Token: 0x04003B6B RID: 15211
	private EBabelTowerTabItem CurrentSelect;

	// Token: 0x04003B6C RID: 15212
	private readonly List<int> NormalSimpleList = new List<int>();

	// Token: 0x04003B6D RID: 15213
	private readonly List<int> NormalDifficultyList = new List<int>();

	// Token: 0x04003B6E RID: 15214
	private readonly List<EBabelTowerTabItem> QuestTypeList = new List<EBabelTowerTabItem>();

	// Token: 0x04003B6F RID: 15215
	[Nullable(2)]
	private UUIExtendToggle CurrentSelectToggle;

	// Token: 0x020075A1 RID: 30113
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x0402895E RID: 166238
		public const int CaptionItem = 0;

		// Token: 0x0402895F RID: 166239
		public const int NormalQuestLoopScrollerView = 1;

		// Token: 0x04028960 RID: 166240
		public const int NormalQuestLoopScrollerItem = 2;

		// Token: 0x04028961 RID: 166241
		public const int TabScrollerView = 3;

		// Token: 0x04028962 RID: 166242
		public const int TabItem = 4;

		// Token: 0x04028963 RID: 166243
		public const int DailyQuestItem = 5;

		// Token: 0x04028964 RID: 166244
		public const int RefreshTimeText = 6;

		// Token: 0x04028965 RID: 166245
		public const int DailyQuestLoopScrollerView = 7;

		// Token: 0x04028966 RID: 166246
		public const int DailyQuestLoopScrollerItem = 8;
	}
}
