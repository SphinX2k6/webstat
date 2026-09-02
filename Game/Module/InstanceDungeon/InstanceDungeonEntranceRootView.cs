using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Core.Extension;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.InstanceDungeon.Define;
using CSharpScript.Game.Module.InstanceDungeon.ExchangeReward;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using CSharpScript.Module.InstanceDungeon;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.InstanceDungeon
{
	// Token: 0x02005BBB RID: 23483
	[NullableContext(1)]
	[Nullable(0)]
	public class InstanceDungeonEntranceRootView : UiTickViewBase
	{
		// Token: 0x0603B6DE RID: 243422 RVA: 0x00F0FB8F File Offset: 0x00F0DD8F
		public InstanceDungeonEntranceRootView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x17009776 RID: 38774
		// (get) Token: 0x0603B6DF RID: 243423 RVA: 0x00F0FBC4 File Offset: 0x00F0DDC4
		// (set) Token: 0x0603B6E0 RID: 243424 RVA: 0x00F0FBCC File Offset: 0x00F0DDCC
		private int InstanceId
		{
			get
			{
				return this.InstanceIdInternal;
			}
			set
			{
				if (this.InstanceIdInternal == 0)
				{
					this.InstanceBgDirtyInternal = true;
				}
				else
				{
					InstanceDungeonConfig instance = ConfigBase<InstanceDungeonConfig>.Instance;
					InstanceDungeon? config = instance.GetConfig(this.InstanceIdInternal);
					InstanceDungeon? config2 = instance.GetConfig(value);
					if (config != null && config2 != null)
					{
						this.InstanceBgDirtyInternal = (config.Value.BannerPath != config2.Value.BannerPath);
					}
				}
				this.InstanceIdInternal = value;
			}
		}

		// Token: 0x17009777 RID: 38775
		// (get) Token: 0x0603B6E1 RID: 243425 RVA: 0x00F0FC45 File Offset: 0x00F0DE45
		private bool InstanceBgDirty
		{
			get
			{
				return this.InstanceBgDirtyInternal;
			}
		}

		// Token: 0x0603B6E2 RID: 243426 RVA: 0x00F0FC50 File Offset: 0x00F0DE50
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIDynScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603B6E3 RID: 243427 RVA: 0x00F0FD60 File Offset: 0x00F0DF60
		protected override UniTask OnBeforeStartAsync()
		{
			InstanceDungeonEntranceRootView.<OnBeforeStartAsync>d__25 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<InstanceDungeonEntranceRootView.<OnBeforeStartAsync>d__25>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603B6E4 RID: 243428 RVA: 0x00F0FDA3 File Offset: 0x00F0DFA3
		protected override void OnStart()
		{
			this.UpdateInstancesView();
			this.UpdateInstanceSubView();
		}

		// Token: 0x0603B6E5 RID: 243429 RVA: 0x00F0FDB1 File Offset: 0x00F0DFB1
		protected override void OnBeforeShow()
		{
			this.UpdateEntranceDetail();
		}

		// Token: 0x0603B6E6 RID: 243430 RVA: 0x00F0FDB9 File Offset: 0x00F0DFB9
		protected override void OnAfterShow()
		{
			if (this.InstanceIdList.Count <= 0)
			{
				base.GetItem(2).SetUIActive(false);
			}
		}

		// Token: 0x0603B6E7 RID: 243431 RVA: 0x00F0FDD6 File Offset: 0x00F0DFD6
		protected override void OnBeforeDestroy()
		{
			this.DisposeView();
			this.DisposeData();
		}

		// Token: 0x0603B6E8 RID: 243432 RVA: 0x00F0FDE4 File Offset: 0x00F0DFE4
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnClickEnterInstanceSingle, new Action(this.HandleOnClickEnterInstanceSingle));
			Singleton<EventSystem>.Instance.Add(EEventName.OnNeedRefreshByProtocol, new Action(this.HandleOnNeedRefreshByProtocol));
		}

		// Token: 0x0603B6E9 RID: 243433 RVA: 0x00F0FE1E File Offset: 0x00F0E01E
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnClickEnterInstanceSingle, new Action(this.HandleOnClickEnterInstanceSingle));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnNeedRefreshByProtocol, new Action(this.HandleOnNeedRefreshByProtocol));
		}

		// Token: 0x0603B6EA RID: 243434 RVA: 0x00F0FE58 File Offset: 0x00F0E058
		protected override void OnTick(float delta)
		{
			this.CountDownMs -= (int)delta;
			if (this.CountDownMs > 0)
			{
				return;
			}
			this.HandleOnUpdateInstancesView();
			this.CountDownMs = 2000;
		}

		// Token: 0x0603B6EB RID: 243435 RVA: 0x00F0FE84 File Offset: 0x00F0E084
		private void InitData()
		{
			this.EntranceId = ModelBase<InstanceDungeonEntranceModel>.Instance.EntranceId;
			foreach (KeyValuePair<int, int> keyValuePair in ModelBase<InstanceDungeonEntranceModel>.Instance.GetSortedByTitleEntranceInstanceIdList(this.EntranceId))
			{
				int num;
				int num2;
				keyValuePair.Deconstruct(out num, out num2);
				int item = num;
				int key = num2;
				List<int> list;
				if (!this.InstanceByTitleMap.TryGetValue(key, out list))
				{
					list = new List<int>();
					this.InstanceByTitleMap[key] = list;
				}
				list.Add(item);
			}
			foreach (KeyValuePair<int, List<int>> keyValuePair2 in this.InstanceByTitleMap)
			{
				foreach (int item2 in keyValuePair2.Value)
				{
					this.InstanceIdList.Add(item2);
				}
			}
		}

		// Token: 0x0603B6EC RID: 243436 RVA: 0x00F0FFB0 File Offset: 0x00F0E1B0
		private void DisposeData()
		{
			this.InstanceIdList.Clear();
			this.InstanceByTitleMap.Clear();
			this.TitleInstanceGridNumberMap.Clear();
			ModelBase<InstanceDungeonEntranceModel>.Instance.SelectInstanceId = 0;
		}

		// Token: 0x0603B6ED RID: 243437 RVA: 0x00F0FFDE File Offset: 0x00F0E1DE
		private void DisposeView()
		{
			DynamicScrollView<InstanceDetectItem, InstanceDetectDynamicItem, InstanceDetectionDynamicData> instanceLoopScroll = this.InstanceLoopScroll;
			if (instanceLoopScroll != null)
			{
				instanceLoopScroll.ClearChildren();
			}
			this.InstanceLoopScroll = null;
		}

		// Token: 0x0603B6EE RID: 243438 RVA: 0x00F0FFF8 File Offset: 0x00F0E1F8
		private void CreateCaption()
		{
			CommonTabComponentData<CommonTabItem> data = new CommonTabComponentData<CommonTabItem>(new Func<UUIItem, int?, CommonTabItem>(this.TabItemProxyCreate), new Action<int>(this.ToggleCallBack), new Func<int, CommonTabData>(this.GetCommonData));
			UUIItem item = base.GetItem(6);
			this.CaptionItem = new TabComponentWithCaptionItem<CommonTabItem>(item, data, new Action(this.OnClickBackBtn), false);
			this.CaptionItem.SetTabRootActive(false);
			InstanceDungeonEntrance? config = ConfigBase<InstanceDungeonEntranceConfig>.Instance.GetConfig(this.EntranceId);
			this.CaptionItem.SetTitleByTextIdAndArgNew(config.Value.Name, Array.Empty<string>());
			this.CaptionItem.SetTitleIcon(config.Value.TitleSprite);
			this.CaptionItem.SetHelpButtonCallBack(delegate
			{
				ControllerBase<HelpController>.Instance.OpenHelpById(config.Value.HelpButtonId);
			});
		}

		// Token: 0x0603B6EF RID: 243439 RVA: 0x00F100D4 File Offset: 0x00F0E2D4
		private UniTask CreateInstanceLoopScrollAsync()
		{
			InstanceDungeonEntranceRootView.<CreateInstanceLoopScrollAsync>d__37 <CreateInstanceLoopScrollAsync>d__;
			<CreateInstanceLoopScrollAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateInstanceLoopScrollAsync>d__.<>4__this = this;
			<CreateInstanceLoopScrollAsync>d__.<>1__state = -1;
			<CreateInstanceLoopScrollAsync>d__.<>t__builder.Start<InstanceDungeonEntranceRootView.<CreateInstanceLoopScrollAsync>d__37>(ref <CreateInstanceLoopScrollAsync>d__);
			return <CreateInstanceLoopScrollAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603B6F0 RID: 243440 RVA: 0x00F10118 File Offset: 0x00F0E318
		private UniTask CreateInstanceSubViewAsync()
		{
			InstanceDungeonEntranceRootView.<CreateInstanceSubViewAsync>d__38 <CreateInstanceSubViewAsync>d__;
			<CreateInstanceSubViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateInstanceSubViewAsync>d__.<>4__this = this;
			<CreateInstanceSubViewAsync>d__.<>1__state = -1;
			<CreateInstanceSubViewAsync>d__.<>t__builder.Start<InstanceDungeonEntranceRootView.<CreateInstanceSubViewAsync>d__38>(ref <CreateInstanceSubViewAsync>d__);
			return <CreateInstanceSubViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603B6F1 RID: 243441 RVA: 0x00F1015C File Offset: 0x00F0E35C
		private void UpdateEntranceDetail()
		{
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(this.InstanceId);
			if (config != null && this.InstanceBgDirty)
			{
				base.SetTextureByPath(config.Value.BannerPath, base.GetTexture(3), null, null);
				UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
				if (uiViewSequence != null)
				{
					uiViewSequence.StopSequenceByKey("Switch", false, false);
				}
				UiBehaviorLevelSequence uiViewSequence2 = this.UiViewSequence;
				if (uiViewSequence2 == null)
				{
					return;
				}
				uiViewSequence2.PlaySequence("Switch", false, null);
			}
		}

		// Token: 0x0603B6F2 RID: 243442 RVA: 0x00F101E8 File Offset: 0x00F0E3E8
		private void UpdateInstancesView()
		{
			InstanceDetectionDynamicData[] instanceListBySelectSeriesId = this.GetInstanceListBySelectSeriesId();
			DynamicScrollView<InstanceDetectItem, InstanceDetectDynamicItem, InstanceDetectionDynamicData> instanceLoopScroll = this.InstanceLoopScroll;
			if (instanceLoopScroll != null)
			{
				instanceLoopScroll.RefreshByData(instanceListBySelectSeriesId, false, false);
			}
			DynamicScrollView<InstanceDetectItem, InstanceDetectDynamicItem, InstanceDetectionDynamicData> instanceLoopScroll2 = this.InstanceLoopScroll;
			if (instanceLoopScroll2 == null)
			{
				return;
			}
			instanceLoopScroll2.BindLateUpdate(delegate(float _)
			{
				DynamicScrollView<InstanceDetectItem, InstanceDetectDynamicItem, InstanceDetectionDynamicData> instanceLoopScroll3 = this.InstanceLoopScroll;
				int? num = (instanceLoopScroll3 != null) ? new int?(instanceLoopScroll3.GetScrollItemCount()) : null;
				if (num == null)
				{
					return;
				}
				int num2 = this.ScrollIndex + 1;
				int? num3 = num;
				if (num2 < num3.GetValueOrDefault() & num3 != null)
				{
					DynamicScrollView<InstanceDetectItem, InstanceDetectDynamicItem, InstanceDetectionDynamicData> instanceLoopScroll4 = this.InstanceLoopScroll;
					if (instanceLoopScroll4 == null)
					{
						return;
					}
					instanceLoopScroll4.UnBindLateUpdate();
					return;
				}
				else
				{
					DynamicScrollView<InstanceDetectItem, InstanceDetectDynamicItem, InstanceDetectionDynamicData> instanceLoopScroll5 = this.InstanceLoopScroll;
					if (instanceLoopScroll5 != null)
					{
						instanceLoopScroll5.ScrollToItemIndex(this.ScrollIndex, true, false);
					}
					DynamicScrollView<InstanceDetectItem, InstanceDetectDynamicItem, InstanceDetectionDynamicData> instanceLoopScroll6 = this.InstanceLoopScroll;
					if (instanceLoopScroll6 == null)
					{
						return;
					}
					instanceLoopScroll6.UnBindLateUpdate();
					return;
				}
			});
		}

		// Token: 0x0603B6F3 RID: 243443 RVA: 0x00F1022C File Offset: 0x00F0E42C
		private void UpdateInstanceSubView()
		{
			IInstanceDungeonEntranceAbility subView = this.SubView;
			if (subView == null)
			{
				return;
			}
			subView.RefreshExternalAsync();
		}

		// Token: 0x0603B6F4 RID: 243444 RVA: 0x00F10240 File Offset: 0x00F0E440
		private InstanceDetectionDynamicData[] GetInstanceListBySelectSeriesId()
		{
			this.ScrollIndex = 0;
			List<InstanceDetectionDynamicData> list = new List<InstanceDetectionDynamicData>();
			int num = -1;
			this.RefreshInstanceIdByTitleMap();
			bool flag = this.TitleInstanceGridNumberMap.Count == 1;
			bool flag2 = false;
			foreach (KeyValuePair<int, List<int>> keyValuePair in this.InstanceByTitleMap)
			{
				int num2;
				List<int> list2;
				keyValuePair.Deconstruct(out num2, out list2);
				int num3 = num2;
				List<int> list3 = list2;
				bool flag3 = num3 == this.SeriesId;
				bool flag4 = this.TitleInstanceGridNumberMap.GetValueOrNull(num3).GetValueOrDefault() == 1;
				foreach (int num4 in list3)
				{
					if ((num != num3 && !flag) || (num != num3 && flag && flag4))
					{
						InstanceDetectionDynamicData instanceDetectionDynamicData = new InstanceDetectionDynamicData();
						instanceDetectionDynamicData.InstanceSeriesTitle = num3;
						instanceDetectionDynamicData.InstanceGirdId = num4;
						instanceDetectionDynamicData.IsSelect = flag3;
						instanceDetectionDynamicData.IsOnlyOneGrid = flag4;
						num = num3;
						list.Add(instanceDetectionDynamicData);
						if (!flag2)
						{
							this.ScrollIndex++;
						}
						if (flag && flag4)
						{
							break;
						}
					}
					if (flag3 && !flag4)
					{
						InstanceDetectionDynamicData instanceDetectionDynamicData2 = new InstanceDetectionDynamicData();
						instanceDetectionDynamicData2.InstanceGirdId = num4;
						instanceDetectionDynamicData2.IsSelect = (num4 == this.InstanceId);
						instanceDetectionDynamicData2.IsShow = flag3;
						list.Add(instanceDetectionDynamicData2);
						if (instanceDetectionDynamicData2.IsSelect)
						{
							flag2 = true;
						}
						if (!flag2)
						{
							this.ScrollIndex++;
						}
					}
				}
			}
			return list.ToArray();
		}

		// Token: 0x0603B6F5 RID: 243445 RVA: 0x00F1040C File Offset: 0x00F0E60C
		private void RefreshInstanceIdByTitleMap()
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			this.TitleInstanceGridNumberMap.Clear();
			bool flag = this.InstanceId != 0;
			foreach (KeyValuePair<int, List<int>> keyValuePair in this.InstanceByTitleMap)
			{
				int num4;
				List<int> list;
				keyValuePair.Deconstruct(out num4, out list);
				int num5 = num4;
				List<int> list2 = list;
				if (num2 == 0)
				{
					num2 = num5;
				}
				this.TitleInstanceGridNumberMap[num5] = list2.Count;
				if (!flag)
				{
					foreach (int num6 in list2)
					{
						if (this.SeriesId == 0 || num5 == this.SeriesId)
						{
							if (num == 0)
							{
								num = num6;
							}
							bool flag2 = ModelBase<InstanceDungeonEntranceModel>.Instance.CheckInstanceUnlock(num6);
							if (flag2 && num6 > this.InstanceId)
							{
								bool flag3 = ModelBase<ExchangeRewardModel>.Instance.IsFinishInstance(num6);
								int recommendLevel = ConfigBase<InstanceDungeonConfig>.Instance.GetRecommendLevel(num6, ModelBase<WorldLevelModel>.Instance.CurWorldLevel);
								if (flag2 && !flag3 && recommendLevel > num3)
								{
									this.InstanceId = num6;
									this.SeriesId = num5;
									num3 = recommendLevel;
								}
							}
						}
					}
				}
			}
			if (this.InstanceId == 0)
			{
				this.InstanceId = num;
			}
			if (this.SeriesId == 0)
			{
				this.SeriesId = num2;
			}
			ModelBase<InstanceDungeonEntranceModel>.Instance.SelectInstanceId = this.InstanceId;
		}

		// Token: 0x0603B6F6 RID: 243446 RVA: 0x00F10598 File Offset: 0x00F0E798
		private bool GetIsAllowedClickBegin()
		{
			return this.NextCanClickButtonTime <= Singleton<TimeUtil>.Instance.GetServerTimeStamp();
		}

		// Token: 0x0603B6F7 RID: 243447 RVA: 0x00F105B0 File Offset: 0x00F0E7B0
		private InstanceDetectItem CreateInstanceGrid(InstanceDetectionDynamicData data, UUIItem uiItem, int index)
		{
			InstanceDetectItem instanceDetectItem = new InstanceDetectItem();
			instanceDetectItem.BindClickInstanceCallback(new Action<int, UUIExtendToggle, InstanceDetectionDynamicData>(this.RefreshInstanceById));
			instanceDetectItem.BindClickSeriesCallback(new Action<int, UUIExtendToggle, bool>(this.RefreshSeriesById));
			instanceDetectItem.BindCanExecuteChange(new Func<int, bool>(this.CanExecuteChange));
			instanceDetectItem.BindSubtitleTextIdGetter(new TInstanceSubtitleTextIdGetter(ControllerBase<InstanceDungeonEntranceController>.Instance.GetInstanceSubtitleTextIdByInstanceId));
			instanceDetectItem.BindSubtitleArgsGetter(new TInstanceSubtitleArgsGetter(ControllerBase<InstanceDungeonEntranceController>.Instance.GetInstanceSubtitleArgsByInstanceId));
			return instanceDetectItem;
		}

		// Token: 0x0603B6F8 RID: 243448 RVA: 0x00F10624 File Offset: 0x00F0E824
		private void RefreshInstanceById(int id, UUIExtendToggle toggle, [Nullable(2)] InstanceDetectionDynamicData data = null)
		{
			this.InstanceId = id;
			if (data != null)
			{
				if (this.CurrentInstanceDynamicData != null)
				{
					this.CurrentInstanceDynamicData.IsSelect = false;
				}
				this.CurrentInstanceDynamicData = data;
				this.CurrentInstanceDynamicData.IsSelect = true;
			}
			ModelBase<InstanceDungeonEntranceModel>.Instance.SelectInstanceId = this.InstanceId;
			if (this.CurrentInstanceToggle != null && this.CurrentInstanceToggle != toggle)
			{
				this.CurrentInstanceToggle.SetToggleState(EToggleState.ETT_UnChecked, true, false, false);
			}
			this.CurrentInstanceToggle = toggle;
			this.UpdateEntranceDetail();
			this.UpdateInstanceSubView();
			this.UiViewSequence.PlaySequence("Xz", false, null);
		}

		// Token: 0x0603B6F9 RID: 243449 RVA: 0x00F106C0 File Offset: 0x00F0E8C0
		private void RefreshSeriesById(int id, UUIExtendToggle toggle, bool isShow)
		{
			if (this.CurrentSeriesToggle != null && this.CurrentSeriesToggle != toggle)
			{
				this.CurrentSeriesToggle.SetToggleState(EToggleState.ETT_UnChecked, true, false, false);
			}
			this.CurrentSeriesToggle = toggle;
			this.SeriesId = (isShow ? id : -1);
			this.InstanceId = (isShow ? this.InstanceByTitleMap[id][0] : this.InstanceId);
			InstanceDetectionDynamicData[] instanceListBySelectSeriesId = this.GetInstanceListBySelectSeriesId();
			DynamicScrollView<InstanceDetectItem, InstanceDetectDynamicItem, InstanceDetectionDynamicData> instanceLoopScroll = this.InstanceLoopScroll;
			if (instanceLoopScroll != null)
			{
				instanceLoopScroll.RefreshByData(instanceListBySelectSeriesId, false, false);
			}
			DynamicScrollView<InstanceDetectItem, InstanceDetectDynamicItem, InstanceDetectionDynamicData> instanceLoopScroll2 = this.InstanceLoopScroll;
			if (instanceLoopScroll2 == null)
			{
				return;
			}
			instanceLoopScroll2.BindLateUpdate(new Action<float>(this.ScrollToItem));
		}

		// Token: 0x0603B6FA RID: 243450 RVA: 0x00F1075C File Offset: 0x00F0E95C
		private bool CanExecuteChange(int id)
		{
			return this.InstanceId != id;
		}

		// Token: 0x0603B6FB RID: 243451 RVA: 0x00F1076C File Offset: 0x00F0E96C
		private void ScrollToItem(float delta)
		{
			int valueOrDefault = this.TitleInstanceGridNumberMap.GetValueOrDefault(this.SeriesId, 0);
			float scrollProgress = (float)(this.ScrollIndex - 1) / (float)(this.InstanceByTitleMap.Count + valueOrDefault);
			base.GetUIDynScrollViewComponent(0).SetScrollProgress(scrollProgress);
			DynamicScrollView<InstanceDetectItem, InstanceDetectDynamicItem, InstanceDetectionDynamicData> instanceLoopScroll = this.InstanceLoopScroll;
			if (instanceLoopScroll == null)
			{
				return;
			}
			instanceLoopScroll.UnBindLateUpdate();
		}

		// Token: 0x0603B6FC RID: 243452 RVA: 0x00F107C2 File Offset: 0x00F0E9C2
		private CommonTabItem TabItemProxyCreate([Nullable(2)] UUIItem uiItem, int? index)
		{
			return new CommonTabItem();
		}

		// Token: 0x0603B6FD RID: 243453 RVA: 0x00F107C9 File Offset: 0x00F0E9C9
		private void ToggleCallBack(int index)
		{
		}

		// Token: 0x0603B6FE RID: 243454 RVA: 0x00F107CB File Offset: 0x00F0E9CB
		[NullableContext(2)]
		private CommonTabData GetCommonData(int index)
		{
			return null;
		}

		// Token: 0x0603B6FF RID: 243455 RVA: 0x00F107CE File Offset: 0x00F0E9CE
		private void OnClickBackBtn()
		{
			base.CloseMe(null);
		}

		// Token: 0x0603B700 RID: 243456 RVA: 0x00F107D8 File Offset: 0x00F0E9D8
		private void HandleOnClickEnterInstanceSingle()
		{
			if (!this.GetIsAllowedClickBegin())
			{
				return;
			}
			this.NextCanClickButtonTime = Singleton<TimeUtil>.Instance.GetServerTimeStamp() + 500.0;
			int instanceId = this.InstanceId;
			if (instanceId == 0)
			{
				Singleton<Log>.Instance.Error(ELogModule.InstanceDungeon, ELogAuthor.TL, "副本入口界面点击挑战错误，当前未选择副本", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (!ModelBase<InstanceDungeonEntranceModel>.Instance.CheckInstanceCanChallenge(instanceId))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("InstanceDungeonLackChallengeTimes", Array.Empty<object>());
				return;
			}
			if (ControllerBase<RoleController>.Instance.IsInRoleTrial())
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("TrialRoleDungeonsLimit", Array.Empty<object>());
				return;
			}
			ModelBase<EditBattleTeamModel>.Instance.InstanceMultiEnter = false;
			bool powerEnough = ModelBase<PowerModel>.Instance.IsPowerEnough(ModelBase<InstanceDungeonEntranceModel>.Instance.GetInstancePowerCost(this.InstanceId));
			if (ModelBase<InstanceDungeonEntranceModel>.Instance.CheckInstanceLevelTooLow(this.InstanceId))
			{
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.InstanceLevelTooLowToGetPhantom);
				confirmBoxDataNew.FunctionMap[2] = delegate()
				{
					if (!powerEnough)
					{
						this.OpenPowerConfirm();
						return;
					}
					ModelBase<InstanceDungeonEntranceModel>.Instance.InstanceId = instanceId;
					ControllerBase<InstanceDungeonEntranceController>.Instance.ContinueEntranceFlow();
				};
				confirmBoxDataNew.FunctionMap[1] = new Action(this.PlayPopupLevelSequenceReverse);
				int[] unlockCondition = ConfigBase<InstanceDungeonConfig>.Instance.GetUnlockCondition(instanceId);
				confirmBoxDataNew.SetTextArgs(new string[]
				{
					unlockCondition[1].ToString()
				});
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
				return;
			}
			if (!powerEnough)
			{
				this.OpenPowerConfirm();
				return;
			}
			ModelBase<InstanceDungeonEntranceModel>.Instance.InstanceId = instanceId;
			ControllerBase<InstanceDungeonEntranceController>.Instance.ContinueEntranceFlow();
		}

		// Token: 0x0603B701 RID: 243457 RVA: 0x00F10968 File Offset: 0x00F0EB68
		private void HandleOnNeedRefreshByProtocol()
		{
			this.UpdateInstancesView();
			this.UpdateInstanceSubView();
		}

		// Token: 0x0603B702 RID: 243458 RVA: 0x00F10978 File Offset: 0x00F0EB78
		private void HandleOnUpdateInstancesView()
		{
			if (this.InstanceLoopScroll != null)
			{
				for (int i = 0; i < this.InstanceLoopScroll.GetScrollItemCount(); i++)
				{
					DynamicScrollView<InstanceDetectItem, InstanceDetectDynamicItem, InstanceDetectionDynamicData> instanceLoopScroll = this.InstanceLoopScroll;
					InstanceDetectItem instanceDetectItem = (instanceLoopScroll != null) ? instanceLoopScroll.GetScrollItemFromIndex(i) : null;
					if (instanceDetectItem != null)
					{
						instanceDetectItem.UpdateSelf();
					}
				}
			}
			IInstanceDungeonEntranceAbility subView = this.SubView;
			if (subView == null)
			{
				return;
			}
			subView.RefreshOnTick();
		}

		// Token: 0x0603B703 RID: 243459 RVA: 0x00F109D4 File Offset: 0x00F0EBD4
		private void OpenPowerConfirm()
		{
			int instanceId = this.InstanceId;
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.PowerNotEnoughForDungeon);
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				this.PlayPopupLevelSequenceReverse();
				ModelBase<InstanceDungeonEntranceModel>.Instance.InstanceId = instanceId;
				ControllerBase<InstanceDungeonEntranceController>.Instance.ContinueEntranceFlow();
			};
			confirmBoxDataNew.FunctionMap[1] = new Action(this.PlayPopupLevelSequenceReverse);
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x0603B704 RID: 243460 RVA: 0x00F10A3E File Offset: 0x00F0EC3E
		private void PlayPopupLevelSequenceReverse()
		{
			this.UiViewSequence.StopSequenceByKey("Popup", false, false);
			this.UiViewSequence.PlaySequencePurely("Popup", false, true);
		}

		// Token: 0x040217D5 RID: 137173
		private int EntranceId;

		// Token: 0x040217D6 RID: 137174
		private int InstanceIdInternal;

		// Token: 0x040217D7 RID: 137175
		private bool InstanceBgDirtyInternal;

		// Token: 0x040217D8 RID: 137176
		private int SeriesId;

		// Token: 0x040217D9 RID: 137177
		private int ScrollIndex;

		// Token: 0x040217DA RID: 137178
		private double NextCanClickButtonTime;

		// Token: 0x040217DB RID: 137179
		private readonly List<int> InstanceIdList = new List<int>();

		// Token: 0x040217DC RID: 137180
		private readonly Dictionary<int, List<int>> InstanceByTitleMap = new Dictionary<int, List<int>>();

		// Token: 0x040217DD RID: 137181
		private readonly Dictionary<int, int> TitleInstanceGridNumberMap = new Dictionary<int, int>();

		// Token: 0x040217DE RID: 137182
		[Nullable(2)]
		private UUIExtendToggle CurrentSeriesToggle;

		// Token: 0x040217DF RID: 137183
		[Nullable(2)]
		private UUIExtendToggle CurrentInstanceToggle;

		// Token: 0x040217E0 RID: 137184
		[Nullable(2)]
		private InstanceDetectionDynamicData CurrentInstanceDynamicData;

		// Token: 0x040217E1 RID: 137185
		private int CountDownMs = 2000;

		// Token: 0x040217E2 RID: 137186
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		private DynamicScrollView<InstanceDetectItem, InstanceDetectDynamicItem, InstanceDetectionDynamicData> InstanceLoopScroll;

		// Token: 0x040217E3 RID: 137187
		[Nullable(2)]
		private IInstanceDungeonEntranceAbility SubView;

		// Token: 0x040217E4 RID: 137188
		private TabComponentWithCaptionItem<CommonTabItem> CaptionItem;

		// Token: 0x040217E5 RID: 137189
		private const int CLICK_INSTANCE_BEGIN_BUTTON_CD = 500;

		// Token: 0x0200BC0A RID: 48138
		[NullableContext(0)]
		private enum EChildCom
		{
			// Token: 0x0403A011 RID: 237585
			ScrollInstanceSeries,
			// Token: 0x0403A012 RID: 237586
			InstanceDetectItem,
			// Token: 0x0403A013 RID: 237587
			UiItemInstanceSeries,
			// Token: 0x0403A014 RID: 237588
			TextureInstanceBG,
			// Token: 0x0403A015 RID: 237589
			MatchParentItem,
			// Token: 0x0403A016 RID: 237590
			ContentParentItem,
			// Token: 0x0403A017 RID: 237591
			CaptionItem
		}
	}
}
