using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001231 RID: 4657
public class BabelTowerMainView : UiViewBase
{
	// Token: 0x06007BF2 RID: 31730 RVA: 0x00208BF4 File Offset: 0x00206DF4
	[NullableContext(1)]
	public BabelTowerMainView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06007BF3 RID: 31731 RVA: 0x00208C00 File Offset: 0x00206E00
	protected unsafe override void OnRegisterComponent()
	{
		int num = 17;
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
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIArtText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIArtText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 3;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickQuestBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(13, new Action(this.OnClickNormalBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(14, new Action(this.OnClickHardBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06007BF4 RID: 31732 RVA: 0x00208EE8 File Offset: 0x002070E8
	protected override UniTask OnBeforeStartAsync()
	{
		BabelTowerMainView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<BabelTowerMainView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06007BF5 RID: 31733 RVA: 0x00208F2C File Offset: 0x0020712C
	protected override void OnStart()
	{
		UUIItem item = base.GetItem(1);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		UUIItem item2 = base.GetItem(2);
		if (item2 != null)
		{
			item2.SetUIActive(false);
		}
		ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.BabelTowerNewLevelDifficulty, base.GetItem(15), null, 1);
		ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.BabelTowerNewLevelDifficulty, base.GetItem(16), null, 0);
		ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.BabelTowerQuestRedDot, base.GetItem(4), null, 0);
		int newLevel = ControllerBase<BabelTowerController>.Instance.GetBabelTowerData().GetNewLevel();
		if (newLevel == 0)
		{
			return;
		}
		Dictionary<int, bool> player = LocalStorage.GetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.BabelTowerNewLevel, null);
		bool flag;
		if (player != null && player.TryGetValue(newLevel, out flag) && flag)
		{
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.BabelTowerNewLevelTipsView, newLevel, null);
	}

	// Token: 0x06007BF6 RID: 31734 RVA: 0x00208FF0 File Offset: 0x002071F0
	protected override void OnBeforeShow()
	{
		this.RefreshView();
	}

	// Token: 0x06007BF7 RID: 31735 RVA: 0x00208FF8 File Offset: 0x002071F8
	protected override void OnBeforeDestroy()
	{
		ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.BabelTowerNewLevelDifficulty, base.GetItem(15), 1);
		ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.BabelTowerNewLevelDifficulty, base.GetItem(16), 0);
		ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.BabelTowerQuestRedDot, base.GetItem(4), 0);
		ModelBase<BabelTowerModel>.Instance.CurrentSelectLevel = 0;
	}

	// Token: 0x06007BF8 RID: 31736 RVA: 0x00209058 File Offset: 0x00207258
	private void RefreshView()
	{
		BabelTowerData babelTowerData = ControllerBase<BabelTowerController>.Instance.GetBabelTowerData();
		if (babelTowerData == null)
		{
			return;
		}
		string nextLevelOpenTimeText = babelTowerData.GetNextLevelOpenTimeText();
		if (string.IsNullOrEmpty(nextLevelOpenTimeText))
		{
			double remainTime = (babelTowerData.EndOpenTime == 0L) ? 0.0 : ((double)babelTowerData.EndOpenTime - Singleton<TimeUtil>.Instance.GetServerTime());
			string countDownText = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat(remainTime).CountDownText;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), "BabelTowerCloseTime", new <>z__ReadOnlySingleElementList<object>(countDownText));
		}
		else
		{
			base.GetItem(8).SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), "BabelUiTimeNew", new <>z__ReadOnlySingleElementList<object>(nextLevelOpenTimeText));
		}
		string normalLevelPassText = babelTowerData.GetNormalLevelPassText();
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(10), "BabelTowerNormalLevelTips", new <>z__ReadOnlySingleElementList<object>(normalLevelPassText));
		string hardLevelStarText = babelTowerData.GetHardLevelStarText();
		base.GetArtText(12).SetText(hardLevelStarText);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(11), "Babeleasy_pass", Array.Empty<object>());
		this.RefreshQuestText();
	}

	// Token: 0x06007BF9 RID: 31737 RVA: 0x00209160 File Offset: 0x00207360
	private void RefreshQuestText()
	{
		ValueTuple<int, int> normalQuestCount = ControllerBase<BabelTowerController>.Instance.GetBabelTowerData().GetNormalQuestCount();
		int item = normalQuestCount.Item1;
		int item2 = normalQuestCount.Item2;
		int value = item;
		int value2 = item2;
		UUIText text = base.GetText(5);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
		defaultInterpolatedStringHandler.AppendLiteral("/");
		defaultInterpolatedStringHandler.AppendFormatted<int>(value2);
		text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		UUIText text2 = base.GetText(6);
		defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
		defaultInterpolatedStringHandler.AppendFormatted<int>(value);
		text2.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
	}

	// Token: 0x06007BFA RID: 31738 RVA: 0x002091E1 File Offset: 0x002073E1
	private void OnCloseBtnClick()
	{
		IBabelTowerMainViewData data = this.Data;
		if (data != null && data.IfLeaveInstanceDungeonWhenClose)
		{
			ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeon();
			return;
		}
		base.CloseMe(null);
	}

	// Token: 0x06007BFB RID: 31739 RVA: 0x0020920A File Offset: 0x0020740A
	private void OnClickQuestBtn()
	{
		if (!ControllerBase<BabelTowerController>.Instance.GetBabelTowerData().CheckIfInOpenTime())
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("BabelTowerIsNotOpen", Array.Empty<object>());
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.BabelTowerQuestView, null, null);
	}

	// Token: 0x06007BFC RID: 31740 RVA: 0x00209243 File Offset: 0x00207443
	private void OnClickNormalBtn()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.BabelTowerNormalLevelChoseView, null, null);
	}

	// Token: 0x06007BFD RID: 31741 RVA: 0x00209256 File Offset: 0x00207456
	private void OnClickHardBtn()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.BabelTowerHardLevelChoseView, null, null);
	}

	// Token: 0x04003B4C RID: 15180
	[Nullable(2)]
	private IBabelTowerMainViewData Data;

	// Token: 0x04003B4D RID: 15181
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x02007598 RID: 30104
	private class EComponentDefine
	{
		// Token: 0x04028923 RID: 166179
		public const int CaptionItem = 0;

		// Token: 0x04028924 RID: 166180
		public const int ShopBtn = 1;

		// Token: 0x04028925 RID: 166181
		public const int ShopBtnRedDotItem = 2;

		// Token: 0x04028926 RID: 166182
		public const int QuestBtn = 3;

		// Token: 0x04028927 RID: 166183
		public const int QuestRedDotItem = 4;

		// Token: 0x04028928 RID: 166184
		public const int QuestText1 = 5;

		// Token: 0x04028929 RID: 166185
		public const int QuestText2 = 6;

		// Token: 0x0402892A RID: 166186
		public const int NewLevelTimeText = 7;

		// Token: 0x0402892B RID: 166187
		public const int NewLevelTimeItem = 8;

		// Token: 0x0402892C RID: 166188
		public const int NormalProgressText = 9;

		// Token: 0x0402892D RID: 166189
		public const int NormalDesText = 10;

		// Token: 0x0402892E RID: 166190
		public const int NormalTipsText = 11;

		// Token: 0x0402892F RID: 166191
		public const int HardStarText = 12;

		// Token: 0x04028930 RID: 166192
		public const int NormalBtn = 13;

		// Token: 0x04028931 RID: 166193
		public const int HardBtn = 14;

		// Token: 0x04028932 RID: 166194
		public const int HardLevelRedDotItem = 15;

		// Token: 0x04028933 RID: 166195
		public const int NormalLevelRedDotItem = 16;
	}
}
