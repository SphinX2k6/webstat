using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BossPiling.View.Item;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.WorldMap;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.BossPiling.View
{
	// Token: 0x02005EF7 RID: 24311
	[NullableContext(1)]
	[Nullable(0)]
	public class BossPilingMainView : UiTickViewBase
	{
		// Token: 0x0603D135 RID: 250165 RVA: 0x00F82877 File Offset: 0x00F80A77
		public BossPilingMainView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603D136 RID: 250166 RVA: 0x00F82888 File Offset: 0x00F80A88
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnClickedConfirm));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603D137 RID: 250167 RVA: 0x00F829F4 File Offset: 0x00F80BF4
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<IReadOnlySet<int>>(EEventName.OnActivityClose, new Action<IReadOnlySet<int>>(this.OnActivityClose));
		}

		// Token: 0x0603D138 RID: 250168 RVA: 0x00F82A12 File Offset: 0x00F80C12
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove<IReadOnlySet<int>>(EEventName.OnActivityClose, new Action<IReadOnlySet<int>>(this.OnActivityClose));
		}

		// Token: 0x0603D139 RID: 250169 RVA: 0x00F82A30 File Offset: 0x00F80C30
		protected override void OnStart()
		{
			this.LevelSequence = new LevelSequencePlayer(base.GetRootItem());
			this.ActivityData = ModelBase<BossPilingModel>.Instance.GetActivityData();
			this.ActivityData.RefreshUnlockState();
			this.CaptionItem = new PopupCaptionItem(base.GetItem(1));
			this.CaptionItem.SetCloseCallBack(new Action(this.OnClickedClose));
			this.CaptionItem.SetHelpCallBack(delegate
			{
				ControllerBase<HelpController>.Instance.OpenHelpById(551);
			});
			bool flag = ModelBase<BossPilingModel>.Instance.CheckIsBossPiling();
			this.CaptionItem.SetHomeBtnShowState(!flag);
			this.RewardBtn = new ButtonItem(base.GetItem(5));
			this.RewardBtn.SetFunction(delegate(int _)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.BossPilingTaskView, null, null);
			});
			this.Layout = new GenericLayout<BossPilingBossTabItem, BossPilingLevelInfo>(base.GetVerticalLayout(3), new Func<BossPilingBossTabItem>(this.CreateBossItem), base.GetItem(4).GetOwner() as AUIBaseActor, false, true);
			this.CurSelected = this.ActivityData.GetFirstSelectLevel();
		}

		// Token: 0x0603D13A RID: 250170 RVA: 0x00F82B54 File Offset: 0x00F80D54
		protected override void OnBeforeShow()
		{
			this.RefreshRewardBtn();
			List<BossPilingLevelInfo> allLevelInfo = this.ActivityData.GetAllLevelInfo();
			this.Layout.RefreshByData(allLevelInfo, null, true);
			this.RefreshPanel();
		}

		// Token: 0x0603D13B RID: 250171 RVA: 0x00F82B87 File Offset: 0x00F80D87
		protected override void OnBeforeHide()
		{
			this.ActivityData.ClearLevelRedDot();
			this.RewardBtn.UnBindRedDot();
		}

		// Token: 0x0603D13C RID: 250172 RVA: 0x00F82BA0 File Offset: 0x00F80DA0
		protected override void OnTick(float delta)
		{
			if (!this.NeedTick)
			{
				return;
			}
			List<BossPilingBossTabItem> layoutItemList = this.Layout.GetLayoutItemList();
			bool flag = false;
			foreach (BossPilingBossTabItem bossPilingBossTabItem in layoutItemList)
			{
				bool flag2 = bossPilingBossTabItem.OnTick();
				flag = (flag || flag2);
			}
			if (!flag && layoutItemList.Count > 0)
			{
				this.NeedTick = false;
			}
		}

		// Token: 0x0603D13D RID: 250173 RVA: 0x00F82C1C File Offset: 0x00F80E1C
		protected void RefreshRewardBtn()
		{
			this.RewardBtn.BindRedDot(ERedDotName.BossPilingReward, 0);
			List<int> taskNumState = this.ActivityData.GetTaskNumState();
			ButtonItem rewardBtn = this.RewardBtn;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(taskNumState[0]);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(taskNumState[1]);
			rewardBtn.SetText(defaultInterpolatedStringHandler.ToStringAndClear());
		}

		// Token: 0x0603D13E RID: 250174 RVA: 0x00F82C8C File Offset: 0x00F80E8C
		protected void RefreshPanel()
		{
			BossPilingLevels? levelInfo = ConfigBase<BossPilingConfig>.Instance.GetLevelInfo(this.CurSelected);
			if (levelInfo == null)
			{
				return;
			}
			this.LevelSequence.PlayOrReplaySequenceByName("Switch", false, null);
			BossPilingLevelInfo levelInfo2 = this.ActivityData.GetLevelInfo(this.CurSelected);
			FColor changeColor = base.GetText(7).changeColor;
			base.SetTextureByPath(levelInfo.Value.Bg, base.GetTexture(0), null, null);
			if (levelInfo2.BossHp == 0)
			{
				UUIText text = base.GetText(7);
				if (text != null)
				{
					bool bUseChangeColor = true;
					FColor? fcolor = new FColor?(changeColor);
					text.SetChangeColor(bUseChangeColor, fcolor);
				}
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), "BossPilingActivity_Main05", Array.Empty<object>());
				return;
			}
			UUIText text2 = base.GetText(7);
			if (text2 != null)
			{
				bool bUseChangeColor2 = false;
				FColor? fcolor = new FColor?(changeColor);
				text2.SetChangeColor(bUseChangeColor2, fcolor);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), "BossPilingActivity_Main04", new <>z__ReadOnlySingleElementList<object>(levelInfo2.BossHp));
		}

		// Token: 0x0603D13F RID: 250175 RVA: 0x00F82D99 File Offset: 0x00F80F99
		private BossPilingBossTabItem CreateBossItem()
		{
			return new BossPilingBossTabItem
			{
				IsSelectOnCb = new Func<int, bool>(this.GetToggleStateSelected),
				OnToggleStateChangeFunction = new Action<int>(this.OnToggleStateChange)
			};
		}

		// Token: 0x0603D140 RID: 250176 RVA: 0x00F82DC4 File Offset: 0x00F80FC4
		private bool GetToggleStateSelected(int level)
		{
			return this.CurSelected == level;
		}

		// Token: 0x0603D141 RID: 250177 RVA: 0x00F82DCF File Offset: 0x00F80FCF
		private void OnToggleStateChange(int id)
		{
			this.CurSelected = id;
			this.Layout.RefreshWithoutDataSync();
			this.RefreshPanel();
		}

		// Token: 0x0603D142 RID: 250178 RVA: 0x00F82DE9 File Offset: 0x00F80FE9
		private void OnClickedConfirm()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.BossPilingLevelView, this.CurSelected, null);
		}

		// Token: 0x0603D143 RID: 250179 RVA: 0x00F82E06 File Offset: 0x00F81006
		private void OnActivityClose(IReadOnlySet<int> closeActivities)
		{
			ModelBase<BossPilingModel>.Instance.CloseActivityView(closeActivities);
		}

		// Token: 0x0603D144 RID: 250180 RVA: 0x00F82E13 File Offset: 0x00F81013
		private void OnClickedClose()
		{
			if (ModelBase<WorldMapModel>.Instance.IsPlayerInBigWorldInstanceDungeon())
			{
				base.CloseMe(null);
				return;
			}
			ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeonRequest(LeaveInstWay.Default);
		}

		// Token: 0x04022421 RID: 140321
		private const int BOSS_PILING_HELP_ID = 551;

		// Token: 0x04022422 RID: 140322
		private BossPilingActivityData ActivityData;

		// Token: 0x04022423 RID: 140323
		private PopupCaptionItem CaptionItem;

		// Token: 0x04022424 RID: 140324
		private ButtonItem RewardBtn;

		// Token: 0x04022425 RID: 140325
		private GenericLayout<BossPilingBossTabItem, BossPilingLevelInfo> Layout;

		// Token: 0x04022426 RID: 140326
		private int CurSelected;

		// Token: 0x04022427 RID: 140327
		private bool NeedTick = true;

		// Token: 0x04022428 RID: 140328
		private LevelSequencePlayer LevelSequence;

		// Token: 0x0200BEEE RID: 48878
		[NullableContext(0)]
		private enum EDefine
		{
			// Token: 0x0403AC32 RID: 240690
			TexBossMain,
			// Token: 0x0403AC33 RID: 240691
			CaptionItem,
			// Token: 0x0403AC34 RID: 240692
			SvBossSelect,
			// Token: 0x0403AC35 RID: 240693
			Content,
			// Token: 0x0403AC36 RID: 240694
			BossItem,
			// Token: 0x0403AC37 RID: 240695
			PanelReward,
			// Token: 0x0403AC38 RID: 240696
			BtnConfirm,
			// Token: 0x0403AC39 RID: 240697
			TxtDefeatNum
		}
	}
}
