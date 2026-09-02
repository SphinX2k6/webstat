using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi.Views;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SpringManor
{
	// Token: 0x0200632C RID: 25388
	[NullableContext(2)]
	[Nullable(0)]
	public class SpringManorQuestView : UiTickViewBase
	{
		// Token: 0x0603FC7D RID: 261245 RVA: 0x0105A579 File Offset: 0x01058779
		[NullableContext(1)]
		public SpringManorQuestView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603FC7E RID: 261246 RVA: 0x0105A584 File Offset: 0x01058784
		protected unsafe override void OnRegisterComponent()
		{
			int num = 20;
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
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUILayoutBase));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(19, typeof(UUILayoutBase));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603FC7F RID: 261247 RVA: 0x0105A84C File Offset: 0x01058A4C
		protected override UniTask OnBeforeStartAsync()
		{
			SpringManorQuestView.<OnBeforeStartAsync>d__13 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SpringManorQuestView.<OnBeforeStartAsync>d__13>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603FC80 RID: 261248 RVA: 0x0105A890 File Offset: 0x01058A90
		protected override void OnStart()
		{
			this.InitCaption();
			this.RewardPreviewScroll = new GenericScrollViewNew<CommonItemSmallItemGrid, TItem>(base.GetScrollViewWithScrollbar(10), () => new CommonItemSmallItemGrid(), null, false, null);
			FunctionalPanelConditionLock warningTipsItem = this.WarningTipsItem;
			if (warningTipsItem != null)
			{
				warningTipsItem.SetButtonVisible(false);
			}
			this.MainQuestLayout = new GenericLayout<SpringManorQuestItem, int>(base.GetLayoutBase(19), new Func<SpringManorQuestItem>(this.CreateMainQuestItem), null, false, true);
			this.SubQuestLayout = new GenericLayout<SpringManorQuestItem, int>(base.GetLayoutBase(4), new Func<SpringManorQuestItem>(this.CreateSubQuestItem), null, false, true);
			int? num = this.OpenParam as int?;
			if (num != null && num.Value != 0)
			{
				this.CurrentSelectQuestId = num.Value;
			}
		}

		// Token: 0x0603FC81 RID: 261249 RVA: 0x0105A960 File Offset: 0x01058B60
		protected override UniTask OnBeforeShowAsyncImplementImplement()
		{
			SpringManorQuestView.<OnBeforeShowAsyncImplementImplement>d__15 <OnBeforeShowAsyncImplementImplement>d__;
			<OnBeforeShowAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeShowAsyncImplementImplement>d__.<>4__this = this;
			<OnBeforeShowAsyncImplementImplement>d__.<>1__state = -1;
			<OnBeforeShowAsyncImplementImplement>d__.<>t__builder.Start<SpringManorQuestView.<OnBeforeShowAsyncImplementImplement>d__15>(ref <OnBeforeShowAsyncImplementImplement>d__);
			return <OnBeforeShowAsyncImplementImplement>d__.<>t__builder.Task;
		}

		// Token: 0x0603FC82 RID: 261250 RVA: 0x0105A9A4 File Offset: 0x01058BA4
		private UniTask RefreshQuestScroll(bool playScrollAnim = true)
		{
			SpringManorQuestView.<RefreshQuestScroll>d__16 <RefreshQuestScroll>d__;
			<RefreshQuestScroll>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshQuestScroll>d__.<>4__this = this;
			<RefreshQuestScroll>d__.playScrollAnim = playScrollAnim;
			<RefreshQuestScroll>d__.<>1__state = -1;
			<RefreshQuestScroll>d__.<>t__builder.Start<SpringManorQuestView.<RefreshQuestScroll>d__16>(ref <RefreshQuestScroll>d__);
			return <RefreshQuestScroll>d__.<>t__builder.Task;
		}

		// Token: 0x0603FC83 RID: 261251 RVA: 0x0105A9F0 File Offset: 0x01058BF0
		protected override void OnTick(float delta)
		{
			if (this.TickTimer > 0.0)
			{
				this.TickTimer -= (double)delta;
				return;
			}
			this.TickTimer = 1000.0;
			FunctionalPanelConditionLock warningTipsItem = this.WarningTipsItem;
			if (warningTipsItem != null && warningTipsItem.IsUiActiveInHierarchy())
			{
				this.RefreshWarningTipsText();
			}
		}

		// Token: 0x0603FC84 RID: 261252 RVA: 0x0105AA47 File Offset: 0x01058C47
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnLogicTreeTrackUpdate, new Action<BtType, long?>(this.OnLogicTreeTrackUpdate));
			Singleton<EventSystem>.Instance.Add(EEventName.OnQuestStateChange, new Action<int, QuestState, EQuestStatusUpdateReason>(this.OnQuestStateChange));
		}

		// Token: 0x0603FC85 RID: 261253 RVA: 0x0105AA81 File Offset: 0x01058C81
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnLogicTreeTrackUpdate, new Action<BtType, long?>(this.OnLogicTreeTrackUpdate));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnQuestStateChange, new Action<int, QuestState, EQuestStatusUpdateReason>(this.OnQuestStateChange));
		}

		// Token: 0x0603FC86 RID: 261254 RVA: 0x0105AABB File Offset: 0x01058CBB
		private void RefreshView()
		{
			this.RefreshQuestScroll(false);
		}

		// Token: 0x0603FC87 RID: 261255 RVA: 0x0105AAC8 File Offset: 0x01058CC8
		private void InitCaption()
		{
			PopupCaptionItem captionItem = this.CaptionItem;
			if (captionItem != null)
			{
				captionItem.SetCloseCallBack(new Action(this.OnClickClose));
			}
			PopupCaptionItem captionItem2 = this.CaptionItem;
			if (captionItem2 == null)
			{
				return;
			}
			captionItem2.SetHelpCallBack(delegate
			{
				ControllerBase<HelpController>.Instance.OpenHelpById(515);
			});
		}

		// Token: 0x0603FC88 RID: 261256 RVA: 0x0105AB24 File Offset: 0x01058D24
		private void RefreshEmpty()
		{
			bool flag = ModelBase<SpringManorModel>.Instance.HasAnyQuest();
			base.GetItem(1).SetUIActive(!flag);
			base.GetItem(2).SetUIActive(flag);
		}

		// Token: 0x0603FC89 RID: 261257 RVA: 0x0105AB59 File Offset: 0x01058D59
		[NullableContext(1)]
		private SpringManorQuestItem CreateMainQuestItem()
		{
			return new SpringManorQuestItem
			{
				ToggleClickCallback = new Action<int, int>(this.OnClickMainQuestToggle)
			};
		}

		// Token: 0x0603FC8A RID: 261258 RVA: 0x0105AB72 File Offset: 0x01058D72
		[NullableContext(1)]
		private SpringManorQuestItem CreateSubQuestItem()
		{
			return new SpringManorQuestItem
			{
				ToggleClickCallback = new Action<int, int>(this.OnClickSubQuestToggle)
			};
		}

		// Token: 0x0603FC8B RID: 261259 RVA: 0x0105AB8B File Offset: 0x01058D8B
		private void OnClickMainQuestToggle(int gridIndex, int questId)
		{
			GenericLayout<SpringManorQuestItem, int> mainQuestLayout = this.MainQuestLayout;
			if (mainQuestLayout != null)
			{
				mainQuestLayout.SelectGridProxy(gridIndex, false);
			}
			GenericLayout<SpringManorQuestItem, int> subQuestLayout = this.SubQuestLayout;
			if (subQuestLayout != null)
			{
				subQuestLayout.DeselectCurrentGridProxy();
			}
			this.UpdateQuestDetails(questId, true);
		}

		// Token: 0x0603FC8C RID: 261260 RVA: 0x0105ABB9 File Offset: 0x01058DB9
		private void OnClickSubQuestToggle(int gridIndex, int questId)
		{
			GenericLayout<SpringManorQuestItem, int> subQuestLayout = this.SubQuestLayout;
			if (subQuestLayout != null)
			{
				subQuestLayout.SelectGridProxy(gridIndex, false);
			}
			GenericLayout<SpringManorQuestItem, int> mainQuestLayout = this.MainQuestLayout;
			if (mainQuestLayout != null)
			{
				mainQuestLayout.DeselectCurrentGridProxy();
			}
			this.UpdateQuestDetails(questId, true);
		}

		// Token: 0x0603FC8D RID: 261261 RVA: 0x0105ABE8 File Offset: 0x01058DE8
		private void UpdateQuestDetails(int questId, bool playAnim = false)
		{
			this.CurrentSelectQuestId = questId;
			SpringManorModel instance = ModelBase<SpringManorModel>.Instance;
			if (instance != null)
			{
				instance.ActivityData.ReadSubQuestRedDot(questId);
			}
			if (playAnim)
			{
				UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
				if (uiViewSequence != null)
				{
					uiViewSequence.PlayOrReplaySequenceByName("Switch", false, null);
				}
			}
			QuestNewModel instance2 = ModelBase<QuestNewModel>.Instance;
			if (instance2.GetQuest(questId) == null)
			{
				this.RefreshLockState();
				return;
			}
			base.GetText(6).SetText(instance2.GetQuestName(questId), true);
			base.GetText(9).SetText(instance2.GetQuestDetails(questId), true);
			this.UpdateQuestSteps(questId);
			this.RefreshRewardPreview(questId);
			this.UpdateQuestState(questId);
			this.RefreshBottomByQuestState();
		}

		// Token: 0x0603FC8E RID: 261262 RVA: 0x0105AC90 File Offset: 0x01058E90
		private void RefreshLockState()
		{
			IQuest questConfig = ModelBase<QuestNewModel>.Instance.GetQuestConfig(this.CurrentSelectQuestId);
			base.GetText(6).ShowTextNew(questConfig.TidName);
			base.GetText(9).ShowTextNew(questConfig.TidDesc);
			UUIItem item = base.GetItem(16);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(10);
			if (scrollViewWithScrollbar != null)
			{
				scrollViewWithScrollbar.RootUIComp.Get().SetUIActive(questConfig.RewardId != null);
			}
			if (questConfig.RewardId != null)
			{
				List<TItem> dropPackagePreviewItemList = ConfigBase<RewardConfig>.Instance.GetDropPackagePreviewItemList(questConfig.RewardId.Value);
				GenericScrollViewNew<CommonItemSmallItemGrid, TItem> rewardPreviewScroll = this.RewardPreviewScroll;
				if (rewardPreviewScroll != null)
				{
					rewardPreviewScroll.RefreshByData(dropPackagePreviewItemList, null, false);
				}
			}
			UUIItem item2 = base.GetItem(17);
			if (item2 != null)
			{
				item2.SetUIActive(false);
			}
			FunctionalPanelConditionLock warningTipsItem = this.WarningTipsItem;
			if (warningTipsItem != null)
			{
				warningTipsItem.SetUiActive(true);
			}
			this.RefreshWarningTipsText();
		}

		// Token: 0x0603FC8F RID: 261263 RVA: 0x0105AD80 File Offset: 0x01058F80
		private void RefreshWarningTipsText()
		{
			SpringManorModel instance = ModelBase<SpringManorModel>.Instance;
			if (instance.IsMainQuest(this.CurrentSelectQuestId))
			{
				string mainQuestRemainTimeText = instance.GetMainQuestRemainTimeText(this.CurrentSelectQuestId, "Spring26_Quest_TimeLimit");
				FunctionalPanelConditionLock warningTipsItem = this.WarningTipsItem;
				if (warningTipsItem == null)
				{
					return;
				}
				warningTipsItem.SetTextByText(mainQuestRemainTimeText);
			}
		}

		// Token: 0x0603FC90 RID: 261264 RVA: 0x0105ADC4 File Offset: 0x01058FC4
		private void UpdateQuestState(int questId)
		{
			if (!ModelBase<SpringManorModel>.Instance.IsQuestUnlocked(questId))
			{
				this.CurrentSpringManorQuestState = ESpringManorQuestState.Lock;
				return;
			}
			if (ModelBase<SpringManorModel>.Instance.IsCurrentTrackQuest(questId))
			{
				this.CurrentSpringManorQuestState = ESpringManorQuestState.Track;
				return;
			}
			this.CurrentSpringManorQuestState = ESpringManorQuestState.UnTrack;
		}

		// Token: 0x0603FC91 RID: 261265 RVA: 0x0105ADFC File Offset: 0x01058FFC
		private void RefreshBottomByQuestState()
		{
			ButtonItem buttonRight = this.ButtonRight;
			if (buttonRight != null)
			{
				buttonRight.SetUiActive(true);
			}
			SpringManorModel instance = ModelBase<SpringManorModel>.Instance;
			bool? flag = (instance != null) ? new bool?(instance.IsMainQuest(this.CurrentSelectQuestId)) : null;
			ButtonItem buttonLeft = this.ButtonLeft;
			if (buttonLeft != null)
			{
				buttonLeft.SetUiActive(this.CurrentSpringManorQuestState == ESpringManorQuestState.Track && !flag.GetValueOrDefault());
			}
			UUIItem item = base.GetItem(17);
			if (item != null)
			{
				item.SetUIActive(this.CurrentSpringManorQuestState > ESpringManorQuestState.Lock);
			}
			FunctionalPanelConditionLock warningTipsItem = this.WarningTipsItem;
			if (warningTipsItem != null)
			{
				warningTipsItem.SetUiActive(this.CurrentSpringManorQuestState == ESpringManorQuestState.Lock);
			}
			if (this.CurrentSpringManorQuestState != ESpringManorQuestState.UnTrack)
			{
				if (this.CurrentSpringManorQuestState == ESpringManorQuestState.Track)
				{
					ButtonItem buttonRight2 = this.ButtonRight;
					if (buttonRight2 != null)
					{
						buttonRight2.SetLocalTextNew("Spring26_Quest_Skip", Array.Empty<object>());
					}
					ButtonItem buttonLeft2 = this.ButtonLeft;
					if (buttonLeft2 == null)
					{
						return;
					}
					buttonLeft2.SetLocalTextNew("Spring26_Quest_UnTrack", Array.Empty<object>());
				}
				return;
			}
			ButtonItem buttonRight3 = this.ButtonRight;
			if (buttonRight3 == null)
			{
				return;
			}
			buttonRight3.SetLocalTextNew("Spring26_Quest_Track", Array.Empty<object>());
		}

		// Token: 0x0603FC92 RID: 261266 RVA: 0x0105AF00 File Offset: 0x01059100
		private UniTask UpdateQuestSteps(int questId)
		{
			SpringManorQuestView.<UpdateQuestSteps>d__32 <UpdateQuestSteps>d__;
			<UpdateQuestSteps>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<UpdateQuestSteps>d__.<>4__this = this;
			<UpdateQuestSteps>d__.questId = questId;
			<UpdateQuestSteps>d__.<>1__state = -1;
			<UpdateQuestSteps>d__.<>t__builder.Start<SpringManorQuestView.<UpdateQuestSteps>d__32>(ref <UpdateQuestSteps>d__);
			return <UpdateQuestSteps>d__.<>t__builder.Task;
		}

		// Token: 0x0603FC93 RID: 261267 RVA: 0x0105AF4C File Offset: 0x0105914C
		private void RefreshRewardPreview(int questId)
		{
			List<TItem> list = ModelBase<QuestNewModel>.Instance.GetDisplayRewardCommonInfo(questId);
			if (list == null)
			{
				IQuest questConfig = ModelBase<QuestNewModel>.Instance.GetQuestConfig(questId);
				int? num = (questConfig != null) ? questConfig.RewardId : null;
				if (num == null)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.SpringManor;
					ELogAuthor author = ELogAuthor.LJ;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 1);
					defaultInterpolatedStringHandler.AppendLiteral("任务");
					defaultInterpolatedStringHandler.AppendFormatted<int>(questId);
					defaultInterpolatedStringHandler.AppendLiteral("配置无效");
					instance.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
					return;
				}
				RewardConfig instance2 = ConfigBase<RewardConfig>.Instance;
				list = ((instance2 != null) ? instance2.GetDropPackagePreviewItemList(num.Value) : null);
			}
			if (list == null)
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.SpringManor;
				ELogAuthor author2 = ELogAuthor.LJ;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(10, 1);
				defaultInterpolatedStringHandler.AppendLiteral("任务");
				defaultInterpolatedStringHandler.AppendFormatted<int>(questId);
				defaultInterpolatedStringHandler.AppendLiteral("没有任何奖励信息");
				instance3.Warn(module2, author2, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			GenericScrollViewNew<CommonItemSmallItemGrid, TItem> rewardPreviewScroll = this.RewardPreviewScroll;
			if (rewardPreviewScroll == null)
			{
				return;
			}
			rewardPreviewScroll.RefreshByData(list, null, false);
		}

		// Token: 0x0603FC94 RID: 261268 RVA: 0x0105B05C File Offset: 0x0105925C
		private void OnClickClose()
		{
			base.CloseMe(null);
		}

		// Token: 0x0603FC95 RID: 261269 RVA: 0x0105B065 File Offset: 0x01059265
		private void OnClickLeft(int __)
		{
			ControllerBase<SpringManorController>.Instance.RequestTrackQuest(this.CurrentSelectQuestId, false);
			this.RefreshQuestScroll(false);
		}

		// Token: 0x0603FC96 RID: 261270 RVA: 0x0105B080 File Offset: 0x01059280
		private void OnClickRight(int __)
		{
			if (this.CurrentSpringManorQuestState == ESpringManorQuestState.UnTrack)
			{
				ControllerBase<SpringManorController>.Instance.RequestTrackQuest(this.CurrentSelectQuestId, true);
			}
			Singleton<UiManager>.Instance.ResetToBattleView(null);
		}

		// Token: 0x0603FC97 RID: 261271 RVA: 0x0105B0A7 File Offset: 0x010592A7
		private void OnLogicTreeTrackUpdate(BtType btType, long? treeIncId)
		{
			this.RefreshView();
		}

		// Token: 0x0603FC98 RID: 261272 RVA: 0x0105B0AF File Offset: 0x010592AF
		private void OnQuestStateChange(int questId, QuestState state, EQuestStatusUpdateReason reason)
		{
			this.RefreshView();
		}

		// Token: 0x04023D07 RID: 146695
		private int CurrentSelectQuestId;

		// Token: 0x04023D08 RID: 146696
		private ESpringManorQuestState CurrentSpringManorQuestState;

		// Token: 0x04023D09 RID: 146697
		private PopupCaptionItem CaptionItem;

		// Token: 0x04023D0A RID: 146698
		private StepBaseItem QuestStepItem;

		// Token: 0x04023D0B RID: 146699
		private FunctionalPanelConditionLock WarningTipsItem;

		// Token: 0x04023D0C RID: 146700
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> RewardPreviewScroll;

		// Token: 0x04023D0D RID: 146701
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<SpringManorQuestItem, int> MainQuestLayout;

		// Token: 0x04023D0E RID: 146702
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<SpringManorQuestItem, int> SubQuestLayout;

		// Token: 0x04023D0F RID: 146703
		private ButtonItem ButtonLeft;

		// Token: 0x04023D10 RID: 146704
		private ButtonItem ButtonRight;

		// Token: 0x04023D11 RID: 146705
		private double TickTimer;
	}
}
