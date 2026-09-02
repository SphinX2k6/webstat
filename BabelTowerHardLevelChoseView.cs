using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200121B RID: 4635
[NullableContext(1)]
[Nullable(0)]
public class BabelTowerHardLevelChoseView : UiViewBase
{
	// Token: 0x06007B13 RID: 31507 RVA: 0x00202DE4 File Offset: 0x00200FE4
	public BabelTowerHardLevelChoseView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06007B14 RID: 31508 RVA: 0x00202DF8 File Offset: 0x00200FF8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 12;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUILoopScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIArtText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickRankBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickQuestBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06007B15 RID: 31509 RVA: 0x0020300F File Offset: 0x0020120F
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.BabelTowerRefreshLevelInfo, new Action(this.BabelTowerRefreshLevelInfo));
	}

	// Token: 0x06007B16 RID: 31510 RVA: 0x0020302D File Offset: 0x0020122D
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.BabelTowerRefreshLevelInfo, new Action(this.BabelTowerRefreshLevelInfo));
	}

	// Token: 0x06007B17 RID: 31511 RVA: 0x0020304C File Offset: 0x0020124C
	protected override UniTask OnBeforeStartAsync()
	{
		BabelTowerHardLevelChoseView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<BabelTowerHardLevelChoseView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06007B18 RID: 31512 RVA: 0x0020308F File Offset: 0x0020128F
	protected override void OnStart()
	{
		ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.BabelTowerQuestRedDot, base.GetItem(5), null, 0);
		UUIItem item = base.GetItem(3);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		this.RefreshView();
	}

	// Token: 0x06007B19 RID: 31513 RVA: 0x002030C2 File Offset: 0x002012C2
	protected override void OnBeforeDestroy()
	{
		ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.BabelTowerQuestRedDot, base.GetItem(5), 0);
	}

	// Token: 0x06007B1A RID: 31514 RVA: 0x002030DC File Offset: 0x002012DC
	protected override void OnBeforeShow()
	{
		int levelChoseHandle = ModelBase<BabelTowerModel>.Instance.LevelChoseHandle;
		if (levelChoseHandle != 0)
		{
			for (int i = 0; i < this.LevelList.Count; i++)
			{
				if (this.LevelList[i].LevelsId == levelChoseHandle)
				{
					LoopScrollView<BabelTowerHardLevelChoseItem, BabelActivityLevelInfo> loopScrollView = this.LoopScrollView;
					if (loopScrollView != null)
					{
						loopScrollView.ScrollToGridIndex(i, true);
					}
					BabelTowerHardLevelChoseItem item = this.LoopScrollView.UnsafeGetGridProxy(i, false);
					LoopScrollView<BabelTowerHardLevelChoseItem, BabelActivityLevelInfo> loopScrollView2 = this.LoopScrollView;
					if (loopScrollView2 != null)
					{
						loopScrollView2.BindLateUpdate(delegate(float _)
						{
							if (item != null)
							{
								ControllerBase<UiNavigationNewController>.Instance.SetNavigationFocusForView(item.GetRootItem(), true, false, false);
								if (this.CurrentPlayLoopSeqItem != item)
								{
									BabelTowerHardLevelChoseItem currentPlayLoopSeqItem = this.CurrentPlayLoopSeqItem;
									if (currentPlayLoopSeqItem != null)
									{
										currentPlayLoopSeqItem.StopLoopSequence();
									}
									item.PlayLoopSequence();
								}
								else if (this.CurrentPlayLoopSeqItem != null && !this.CurrentPlayLoopSeqItem.IsPlayingSequence())
								{
									item.PlayLoopSequence();
								}
								this.CurrentPlayLoopSeqItem = item;
							}
							LoopScrollView<BabelTowerHardLevelChoseItem, BabelActivityLevelInfo> loopScrollView3 = this.LoopScrollView;
							if (loopScrollView3 == null)
							{
								return;
							}
							loopScrollView3.UnBindLateUpdate();
						});
					}
				}
			}
			return;
		}
		this.RefreshView();
	}

	// Token: 0x06007B1B RID: 31515 RVA: 0x00203178 File Offset: 0x00201378
	private void RefreshView()
	{
		BabelTowerData babelTowerData = ControllerBase<BabelTowerController>.Instance.GetBabelTowerData();
		this.LevelList = new List<BabelActivityLevelInfo>();
		foreach (KeyValuePair<int, BabelActivityLevelInfo> keyValuePair in babelTowerData.HardLevelDataMap)
		{
			this.LevelList.Add(keyValuePair.Value);
		}
		LoopScrollView<BabelTowerHardLevelChoseItem, BabelActivityLevelInfo> loopScrollView = this.LoopScrollView;
		if (loopScrollView != null)
		{
			loopScrollView.RefreshByData(this.LevelList, false, null, false);
		}
		base.GetArtText(1).SetText(babelTowerData.GetHardLevelStarText());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(10), "BabelTower_paiming", Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(11), "BabelTowerTaskType_3", Array.Empty<object>());
		ValueTuple<int, int> normalQuestCount = babelTowerData.GetNormalQuestCount();
		int item = normalQuestCount.Item1;
		int item2 = normalQuestCount.Item2;
		UUIText text = base.GetText(6);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
		defaultInterpolatedStringHandler.AppendLiteral("/");
		defaultInterpolatedStringHandler.AppendFormatted<int>(item2);
		text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		UUIText text2 = base.GetText(7);
		defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
		defaultInterpolatedStringHandler.AppendFormatted<int>(item);
		text2.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		UUIInturnAnimController uuiinturnAnimController = base.GetLoopScrollViewComponent(8).Content.Get().GetComponentByClass(UUIInturnAnimController.StaticClass()) as UUIInturnAnimController;
		if (uuiinturnAnimController == null)
		{
			return;
		}
		uuiinturnAnimController.Play("", -1, false);
	}

	// Token: 0x06007B1C RID: 31516 RVA: 0x002032F4 File Offset: 0x002014F4
	private void OnCloseBtnClick()
	{
		IBabelTowerHardLevelChoseViewData data = this.Data;
		if (data != null && data.IfReturnToBabelTowerMainView)
		{
			BabelTowerMainViewData param = new BabelTowerMainViewData
			{
				IfLeaveInstanceDungeonWhenClose = this.Data.IfLeaveInstanceDungeonWhenMainViewClose
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.BabelTowerMainView, param, delegate(bool _, int _)
			{
				base.CloseMe(null);
			});
			return;
		}
		base.CloseMe(null);
	}

	// Token: 0x06007B1D RID: 31517 RVA: 0x00203350 File Offset: 0x00201550
	private void OnClickRankBtn()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.BabelTowerRankView, null, null);
	}

	// Token: 0x06007B1E RID: 31518 RVA: 0x00203363 File Offset: 0x00201563
	private void OnClickQuestBtn()
	{
		if (!ControllerBase<BabelTowerController>.Instance.GetBabelTowerData().CheckIfInOpenTime())
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("BabelTowerIsNotOpen", Array.Empty<object>());
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.BabelTowerQuestView, null, null);
	}

	// Token: 0x06007B1F RID: 31519 RVA: 0x0020339C File Offset: 0x0020159C
	private void OnClickLoopItem(int levelId)
	{
		ControllerBase<BabelTowerController>.Instance.SaveNewLevelClickData(levelId, EBabelTowerDifficulty.Hard);
		Singleton<UiManager>.Instance.OpenView(EUiViewName.BabelTowerDeTermSelectViewNew, levelId, null);
	}

	// Token: 0x06007B20 RID: 31520 RVA: 0x002033C0 File Offset: 0x002015C0
	private BabelTowerHardLevelChoseItem InitItem()
	{
		return new BabelTowerHardLevelChoseItem
		{
			OnClickButtonCallBack = new Action<int>(this.OnClickLoopItem)
		};
	}

	// Token: 0x06007B21 RID: 31521 RVA: 0x002033D9 File Offset: 0x002015D9
	private void BabelTowerRefreshLevelInfo()
	{
		this.RefreshView();
	}

	// Token: 0x06007B22 RID: 31522 RVA: 0x002033E1 File Offset: 0x002015E1
	protected override void OnBeforeHide()
	{
		ModelBase<BabelTowerModel>.Instance.LevelChoseHandle = 0;
	}

	// Token: 0x06007B23 RID: 31523 RVA: 0x002033F0 File Offset: 0x002015F0
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (configParams == null || configParams.Length == 0)
		{
			return null;
		}
		if (!(configParams[0] == "FirstEntry"))
		{
			return null;
		}
		LoopScrollView<BabelTowerHardLevelChoseItem, BabelActivityLevelInfo> loopScrollView = this.LoopScrollView;
		UUIItem uuiitem = (loopScrollView != null) ? loopScrollView.GetGridByDisplayIndex(0) : null;
		if (uuiitem == null)
		{
			return null;
		}
		return new UUIItem[]
		{
			uuiitem,
			uuiitem
		};
	}

	// Token: 0x04003B02 RID: 15106
	[Nullable(2)]
	private IBabelTowerHardLevelChoseViewData Data;

	// Token: 0x04003B03 RID: 15107
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x04003B04 RID: 15108
	private List<BabelActivityLevelInfo> LevelList = new List<BabelActivityLevelInfo>();

	// Token: 0x04003B05 RID: 15109
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<BabelTowerHardLevelChoseItem, BabelActivityLevelInfo> LoopScrollView;

	// Token: 0x04003B06 RID: 15110
	[Nullable(2)]
	private BabelTowerHardLevelChoseItem CurrentPlayLoopSeqItem;

	// Token: 0x02007574 RID: 30068
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x0402886A RID: 165994
		public const int CaptionItem = 0;

		// Token: 0x0402886B RID: 165995
		public const int TargetText = 1;

		// Token: 0x0402886C RID: 165996
		public const int RankBtn = 2;

		// Token: 0x0402886D RID: 165997
		public const int RankBtnRedDotItem = 3;

		// Token: 0x0402886E RID: 165998
		public const int QuestBtn = 4;

		// Token: 0x0402886F RID: 165999
		public const int QuestBtnRedDotItem = 5;

		// Token: 0x04028870 RID: 166000
		public const int QuestText1 = 6;

		// Token: 0x04028871 RID: 166001
		public const int QuestText2 = 7;

		// Token: 0x04028872 RID: 166002
		public const int LoopScrollView = 8;

		// Token: 0x04028873 RID: 166003
		public const int LoopScrollItem = 9;

		// Token: 0x04028874 RID: 166004
		public const int OneText = 10;

		// Token: 0x04028875 RID: 166005
		public const int TowText = 11;
	}
}
