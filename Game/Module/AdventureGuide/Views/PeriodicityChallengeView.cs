using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.AdventureGuide.Views
{
	// Token: 0x020061BE RID: 25022
	[NullableContext(1)]
	[Nullable(0)]
	public class PeriodicityChallengeView : UiTabViewBase
	{
		// Token: 0x0603F274 RID: 258676 RVA: 0x010350B0 File Offset: 0x010332B0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUILoopScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603F275 RID: 258677 RVA: 0x0103519D File Offset: 0x0103339D
		private PeriodicityChallengeTypeItem InitTypeItem()
		{
			PeriodicityChallengeTypeItem periodicityChallengeTypeItem = new PeriodicityChallengeTypeItem();
			periodicityChallengeTypeItem.BindOnToggleFunc(new Action<int, UUIExtendToggle>(this.OnClickTypeItem));
			periodicityChallengeTypeItem.BindCanToggleExecuteChange(new Func<int, bool>(this.CanClickTypeItem));
			return periodicityChallengeTypeItem;
		}

		// Token: 0x0603F276 RID: 258678 RVA: 0x010351C8 File Offset: 0x010333C8
		private PeriodicityChallengeItem InitPlayItem()
		{
			return new PeriodicityChallengeItem();
		}

		// Token: 0x0603F277 RID: 258679 RVA: 0x010351D0 File Offset: 0x010333D0
		private void OnClickTypeItem(int currentType, UUIExtendToggle toggle)
		{
			this.CurrentType = (EDungeonType)currentType;
			UUIExtendToggle currentSelectedToggle = this.CurrentSelectedToggle;
			if (currentSelectedToggle != null)
			{
				currentSelectedToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			}
			this.CurrentSelectedToggle = toggle;
			int num = this.TypeList.IndexOf(currentType);
			if (num >= 0)
			{
				this.TypeScroll.SelectGridProxy(num, false);
			}
			SecondaryGuideData? secondaryGuideDataConf = ConfigBase<AdventureGuideConfig>.Instance.GetSecondaryGuideDataConf(currentType);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.AdventureHelpBtn, secondaryGuideDataConf.Value.HelpGroupId);
			this.RefreshPlayScrollView();
			LevelSequencePlayer switchLevelSequencePlayer = this.SwitchLevelSequencePlayer;
			if (((switchLevelSequencePlayer != null) ? switchLevelSequencePlayer.GetCurrentSequence() : null) == null)
			{
				LevelSequencePlayer switchLevelSequencePlayer2 = this.SwitchLevelSequencePlayer;
				if (switchLevelSequencePlayer2 == null)
				{
					return;
				}
				switchLevelSequencePlayer2.PlayLevelSequenceByName("Switch", false, null, false);
				return;
			}
			else
			{
				LevelSequencePlayer switchLevelSequencePlayer3 = this.SwitchLevelSequencePlayer;
				if (switchLevelSequencePlayer3 == null)
				{
					return;
				}
				switchLevelSequencePlayer3.ReplaySequenceByKey("Switch");
				return;
			}
		}

		// Token: 0x0603F278 RID: 258680 RVA: 0x0103529C File Offset: 0x0103349C
		private void RefreshPlayScrollView()
		{
			List<SoundAreaDetectionRecord> item = ModelBase<AdventureGuideModel>.Instance.GetCanShowDungeonRecordsByType(this.CurrentType, null, true).Item2;
			GenericScrollViewNew<PeriodicityChallengeItem, IPeriodicityChallengeItem> playScroll = this.PlayScroll;
			if (playScroll == null)
			{
				return;
			}
			playScroll.RefreshByData(this.GetPeriodicityChallengeItemDataList(item.ToList<SoundAreaDetectionRecord>()), null, false);
		}

		// Token: 0x0603F279 RID: 258681 RVA: 0x010352E8 File Offset: 0x010334E8
		private void RefreshTypeScrollView()
		{
			int index = this.TypeList.IndexOf((int)this.CurrentType);
			this.TypeScroll.RefreshByData(this.BuildTypeItemDataList(), false, delegate
			{
				PeriodicityChallengeTypeItem periodicityChallengeTypeItem = this.TypeScroll.UnsafeGetGridProxy(index, false);
				if (periodicityChallengeTypeItem == null)
				{
					return;
				}
				periodicityChallengeTypeItem.OnlySetSelectToggle(EToggleState.ETT_Checked);
			}, false);
		}

		// Token: 0x0603F27A RID: 258682 RVA: 0x01035338 File Offset: 0x01033538
		private List<EDungeonType> BuildTypeItemDataList()
		{
			int count = this.TypeList.Count;
			List<EDungeonType> list = new List<EDungeonType>();
			for (int i = 0; i < count; i++)
			{
				int cycleId = ModelBase<WeeklyRogueModel>.Instance.CycleId;
				if (this.TypeList[i] != 29 || cycleId != 0)
				{
					list.Add((EDungeonType)this.TypeList[i]);
				}
			}
			return list;
		}

		// Token: 0x0603F27B RID: 258683 RVA: 0x01035394 File Offset: 0x01033594
		private List<IPeriodicityChallengeItem> GetPeriodicityChallengeItemDataList(List<SoundAreaDetectionRecord> list)
		{
			List<IPeriodicityChallengeItem> list2 = new List<IPeriodicityChallengeItem>();
			Dictionary<int, List<SoundAreaDetectionRecord>> dictionary = new Dictionary<int, List<SoundAreaDetectionRecord>>();
			foreach (SoundAreaDetectionRecord soundAreaDetectionRecord in list)
			{
				List<SoundAreaDetectionRecord> list3;
				if (!dictionary.TryGetValue(soundAreaDetectionRecord.DetectionTitlePanel, out list3))
				{
					list3 = new List<SoundAreaDetectionRecord>();
					dictionary[soundAreaDetectionRecord.DetectionTitlePanel] = list3;
				}
				list3.Add(soundAreaDetectionRecord);
			}
			foreach (KeyValuePair<int, List<SoundAreaDetectionRecord>> keyValuePair in dictionary)
			{
				List<SoundAreaDetectionRecord> value = keyValuePair.Value;
				if (ModelBase<AdventureGuideModel>.Instance.IsTowerType((EPeriodicityChallengeType)value[0].PeriodicityChallengeType))
				{
					value.Sort(delegate(SoundAreaDetectionRecord a, SoundAreaDetectionRecord b)
					{
						int num = (a.GetTargetTowerIsUnlock() > false) ? 1 : 0;
						int num2 = (b.GetTargetTowerIsUnlock() > false) ? 1 : 0;
						if (num != num2)
						{
							return num2 - num;
						}
						int targetTowerDifficulty = a.GetTargetTowerDifficulty();
						int targetTowerDifficulty2 = b.GetTargetTowerDifficulty();
						if (num != 0)
						{
							return targetTowerDifficulty2 - targetTowerDifficulty;
						}
						return targetTowerDifficulty - targetTowerDifficulty2;
					});
				}
				for (int i = 0; i < value.Count; i++)
				{
					IPeriodicityChallengeItem periodicityChallengeItem = new IPeriodicityChallengeItem
					{
						Data = value[i],
						Title = (value[i].DetectionTitlePanel > 0 && i < 1)
					};
					if (this.CurrentType == EDungeonType.WeeklyRogue)
					{
						WeeklyRogueData activityDataNew = ModelBase<WeeklyRogueModel>.Instance.ActivityDataNew;
						int freeCount = activityDataNew.FreeCount;
						int freeCountMax = activityDataNew.FreeCountMax;
						PeriodicityChallengeTopTipsData periodicityChallengeTopTipsData = new PeriodicityChallengeTopTipsData();
						periodicityChallengeTopTipsData.TitleTips = "Text_WeeklyRogue_FreeTime_Title";
						periodicityChallengeTopTipsData.Args = Array.Empty<string>();
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
						defaultInterpolatedStringHandler.AppendFormatted<int>(freeCount);
						defaultInterpolatedStringHandler.AppendLiteral("/");
						defaultInterpolatedStringHandler.AppendFormatted<int>(freeCountMax);
						periodicityChallengeTopTipsData.TxtNum = defaultInterpolatedStringHandler.ToStringAndClear();
						PeriodicityChallengeTopTipsData topTips = periodicityChallengeTopTipsData;
						periodicityChallengeItem.TopTips = topTips;
					}
					list2.Add(periodicityChallengeItem);
				}
			}
			return list2;
		}

		// Token: 0x0603F27C RID: 258684 RVA: 0x0103558C File Offset: 0x0103378C
		private bool CanClickTypeItem(int currentType)
		{
			return this.CurrentType != (EDungeonType)currentType;
		}

		// Token: 0x0603F27D RID: 258685 RVA: 0x0103559C File Offset: 0x0103379C
		protected override UniTask OnBeforeStartAsync()
		{
			PeriodicityChallengeView.<OnBeforeStartAsync>d__17 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PeriodicityChallengeView.<OnBeforeStartAsync>d__17>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603F27E RID: 258686 RVA: 0x010355D8 File Offset: 0x010337D8
		protected override void OnStart()
		{
			this.PlayScroll = new GenericScrollViewNew<PeriodicityChallengeItem, IPeriodicityChallengeItem>(base.GetScrollViewWithScrollbar(3), new Func<PeriodicityChallengeItem>(this.InitPlayItem), null, false, null);
			this.TypeScroll = new LoopScrollView<PeriodicityChallengeTypeItem, EDungeonType>(base.GetLoopScrollViewComponent(0), base.GetItem(2).GetOwner() as AUIBaseActor, new Func<PeriodicityChallengeTypeItem>(this.InitTypeItem), false);
			List<int> allCanShowDungeonTypeList = ModelBase<AdventureGuideModel>.Instance.GetAllCanShowDungeonTypeList(new EUiTabViewName?(EUiTabViewName.PeriodicityChallengeView), true);
			this.TypeList = allCanShowDungeonTypeList.ToList<int>();
			this.StartLevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.SwitchLevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.TryAddTimer();
		}

		// Token: 0x0603F27F RID: 258687 RVA: 0x01035684 File Offset: 0x01033884
		protected override void OnBeforeShow()
		{
			this.CurrentData = (this.ExtraParams as AdventureGuideViewOpenData);
			AdventureGuideViewOpenData currentData = this.CurrentData;
			int? num = (((currentData != null) ? currentData.OpenTabViewName : null) == EUiTabViewName.PeriodicityChallengeView) ? ((currentData != null) ? currentData.OpenParam : null) : new int?((int)this.CurrentType);
			int dungeonIndex = 0;
			if (num != null)
			{
				int? num2 = num;
				int num3 = 0;
				if (!(num2.GetValueOrDefault() == num3 & num2 != null))
				{
					int num4 = this.TypeList.IndexOf(num.Value);
					if (num4 >= 0)
					{
						dungeonIndex = num4;
					}
				}
			}
			List<EDungeonType> data = this.BuildTypeItemDataList();
			this.TypeScroll.RefreshByData(data, false, delegate
			{
				this.TypeScroll.SelectGridProxy(dungeonIndex, false);
				this.TypeScroll.ScrollToGridIndex(dungeonIndex, true);
				PeriodicityChallengeTypeItem periodicityChallengeTypeItem = this.TypeScroll.UnsafeGetGridProxy(dungeonIndex, false);
				if (periodicityChallengeTypeItem == null)
				{
					return;
				}
				periodicityChallengeTypeItem.SetSelectToggle(EToggleState.ETT_Checked);
			}, false);
			LevelSequencePlayer startLevelSequencePlayer = this.StartLevelSequencePlayer;
			if (startLevelSequencePlayer == null)
			{
				return;
			}
			startLevelSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
		}

		// Token: 0x0603F280 RID: 258688 RVA: 0x010357A1 File Offset: 0x010339A1
		protected override void OnBeforeDestroy()
		{
			LevelSequencePlayer startLevelSequencePlayer = this.StartLevelSequencePlayer;
			if (startLevelSequencePlayer != null)
			{
				startLevelSequencePlayer.Clear();
			}
			this.StartLevelSequencePlayer = null;
			LevelSequencePlayer switchLevelSequencePlayer = this.SwitchLevelSequencePlayer;
			if (switchLevelSequencePlayer != null)
			{
				switchLevelSequencePlayer.Clear();
			}
			this.SwitchLevelSequencePlayer = null;
			this.TryRemoveTimer();
		}

		// Token: 0x0603F281 RID: 258689 RVA: 0x010357DA File Offset: 0x010339DA
		private bool TryAddTimer()
		{
			if (this.RefreshTimer != null)
			{
				return false;
			}
			this.AddTimer();
			return true;
		}

		// Token: 0x0603F282 RID: 258690 RVA: 0x010357ED File Offset: 0x010339ED
		private bool TryRemoveTimer()
		{
			if (this.RefreshTimer == null)
			{
				return false;
			}
			this.RemoveTimer();
			return true;
		}

		// Token: 0x0603F283 RID: 258691 RVA: 0x01035800 File Offset: 0x01033A00
		private void AddTimer()
		{
			this.RefreshTimer = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.OnTimerRefresh), (float)Singleton<TimeUtil>.Instance.InverseMillisecond, 1f, null, null, true);
		}

		// Token: 0x0603F284 RID: 258692 RVA: 0x01035831 File Offset: 0x01033A31
		private void RemoveTimer()
		{
			TimerSystem.GameplayTimeInstance.Remove(this.RefreshTimer);
			this.RefreshTimer = null;
		}

		// Token: 0x0603F285 RID: 258693 RVA: 0x0103584B File Offset: 0x01033A4B
		private void OnTimerRefresh(float delta)
		{
			this.RefreshTypeScrollView();
			this.RefreshPlayScrollView();
		}

		// Token: 0x04023780 RID: 145280
		[Nullable(2)]
		private AdventureGuideViewOpenData CurrentData;

		// Token: 0x04023781 RID: 145281
		private EDungeonType CurrentType = EDungeonType.Mat;

		// Token: 0x04023782 RID: 145282
		[Nullable(2)]
		private UUIExtendToggle CurrentSelectedToggle;

		// Token: 0x04023783 RID: 145283
		private List<int> TypeList = new List<int>();

		// Token: 0x04023784 RID: 145284
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private LoopScrollView<PeriodicityChallengeTypeItem, EDungeonType> TypeScroll;

		// Token: 0x04023785 RID: 145285
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<PeriodicityChallengeItem, IPeriodicityChallengeItem> PlayScroll;

		// Token: 0x04023786 RID: 145286
		[Nullable(2)]
		private LevelSequencePlayer StartLevelSequencePlayer;

		// Token: 0x04023787 RID: 145287
		[Nullable(2)]
		private LevelSequencePlayer SwitchLevelSequencePlayer;

		// Token: 0x04023788 RID: 145288
		[Nullable(2)]
		private TimerHandle RefreshTimer;
	}
}
