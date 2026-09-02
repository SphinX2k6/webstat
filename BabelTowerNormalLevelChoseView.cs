using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001236 RID: 4662
[NullableContext(1)]
[Nullable(0)]
public class BabelTowerNormalLevelChoseView : UiViewBase
{
	// Token: 0x06007C23 RID: 31779 RVA: 0x00209E20 File Offset: 0x00208020
	public BabelTowerNormalLevelChoseView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06007C24 RID: 31780 RVA: 0x00209E34 File Offset: 0x00208034
	protected unsafe override void OnRegisterComponent()
	{
		int num = 10;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
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
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUILoopScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickQuestBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06007C25 RID: 31781 RVA: 0x00209FE4 File Offset: 0x002081E4
	protected override UniTask OnBeforeStartAsync()
	{
		BabelTowerNormalLevelChoseView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<BabelTowerNormalLevelChoseView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06007C26 RID: 31782 RVA: 0x0020A028 File Offset: 0x00208228
	protected override void OnBeforeShow()
	{
		int levelChoseHandle = ModelBase<BabelTowerModel>.Instance.LevelChoseHandle;
		if (levelChoseHandle != 0)
		{
			for (int i = 0; i < this.LevelList.Count; i++)
			{
				if (this.LevelList[i].LevelsId == levelChoseHandle)
				{
					LoopScrollView<BabelTowerNormalLevelChoseItem, BabelActivityLevelInfo> loopScrollView = this.LoopScrollView;
					if (loopScrollView != null)
					{
						loopScrollView.ScrollToGridIndex(i, true);
					}
					BabelTowerNormalLevelChoseItem item = this.LoopScrollView.UnsafeGetGridProxy(i, false);
					LoopScrollView<BabelTowerNormalLevelChoseItem, BabelActivityLevelInfo> loopScrollView2 = this.LoopScrollView;
					if (loopScrollView2 != null)
					{
						loopScrollView2.BindLateUpdate(delegate(float _)
						{
							if (item != null)
							{
								ControllerBase<UiNavigationNewController>.Instance.SetNavigationFocusForView(item.GetRootItem(), true, false, false);
								if (this.CurrentPlayLoopSeqItem != item)
								{
									BabelTowerNormalLevelChoseItem currentPlayLoopSeqItem = this.CurrentPlayLoopSeqItem;
									if (currentPlayLoopSeqItem != null)
									{
										currentPlayLoopSeqItem.StopLoopSequence();
									}
									item.PlayLoopSequence();
								}
								else if (this.CurrentPlayLoopSeqItem != null && !this.CurrentPlayLoopSeqItem.IsPlayingSequence())
								{
									this.CurrentPlayLoopSeqItem.PlayLoopSequence();
								}
								this.CurrentPlayLoopSeqItem = item;
							}
							LoopScrollView<BabelTowerNormalLevelChoseItem, BabelActivityLevelInfo> loopScrollView3 = this.LoopScrollView;
							if (loopScrollView3 == null)
							{
								return;
							}
							loopScrollView3.UnBindLateUpdate();
						});
					}
				}
			}
		}
	}

	// Token: 0x06007C27 RID: 31783 RVA: 0x0020A0C0 File Offset: 0x002082C0
	protected override void OnStart()
	{
		UUIItem item = base.GetItem(2);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		UUIItem item2 = base.GetItem(3);
		if (item2 != null)
		{
			item2.SetUIActive(false);
		}
		ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.BabelTowerQuestRedDot, base.GetItem(5), null, 0);
		this.RefreshView();
	}

	// Token: 0x06007C28 RID: 31784 RVA: 0x0020A111 File Offset: 0x00208311
	protected override void OnBeforeDestroy()
	{
		ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.BabelTowerQuestRedDot, base.GetItem(5), 0);
	}

	// Token: 0x06007C29 RID: 31785 RVA: 0x0020A12C File Offset: 0x0020832C
	private void RefreshView()
	{
		BabelTowerData babelTowerData = ControllerBase<BabelTowerController>.Instance.GetBabelTowerData();
		this.LevelList = new List<BabelActivityLevelInfo>();
		int num = 0;
		foreach (KeyValuePair<int, BabelActivityLevelInfo> keyValuePair in babelTowerData.NormalLevelDataMap)
		{
			this.LevelList.Add(keyValuePair.Value);
			if (keyValuePair.Value.IsFinished)
			{
				num++;
			}
		}
		LoopScrollView<BabelTowerNormalLevelChoseItem, BabelActivityLevelInfo> loopScrollView = this.LoopScrollView;
		if (loopScrollView != null)
		{
			loopScrollView.RefreshByData(this.LevelList, false, null, false);
		}
		base.GetText(1).SetText(num.ToString() + "/" + babelTowerData.NormalLevelDataMap.Count.ToString(), true);
		UUIInturnAnimController uuiinturnAnimController = base.GetLoopScrollViewComponent(8).Content.Get().GetComponentByClass(UUIInturnAnimController.StaticClass()) as UUIInturnAnimController;
		if (uuiinturnAnimController != null)
		{
			uuiinturnAnimController.Play("", -1, false);
		}
		this.RefreshQuestText();
	}

	// Token: 0x06007C2A RID: 31786 RVA: 0x0020A244 File Offset: 0x00208444
	private void RefreshQuestText()
	{
		ValueTuple<int, int> normalQuestCount = ControllerBase<BabelTowerController>.Instance.GetBabelTowerData().GetNormalQuestCount();
		int item = normalQuestCount.Item1;
		int item2 = normalQuestCount.Item2;
		int value = item;
		int value2 = item2;
		UUIText text = base.GetText(6);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
		defaultInterpolatedStringHandler.AppendLiteral("/");
		defaultInterpolatedStringHandler.AppendFormatted<int>(value2);
		text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		UUIText text2 = base.GetText(7);
		defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
		defaultInterpolatedStringHandler.AppendFormatted<int>(value);
		text2.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
	}

	// Token: 0x06007C2B RID: 31787 RVA: 0x0020A2C8 File Offset: 0x002084C8
	private void OnCloseBtnClick()
	{
		IBabelTowerNormalLevelChoseViewData data = this.Data;
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

	// Token: 0x06007C2C RID: 31788 RVA: 0x0020A324 File Offset: 0x00208524
	private void OnClickQuestBtn()
	{
		if (!ControllerBase<BabelTowerController>.Instance.GetBabelTowerData().CheckIfInOpenTime())
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("BabelTowerIsNotOpen", Array.Empty<object>());
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.BabelTowerQuestView, null, null);
	}

	// Token: 0x06007C2D RID: 31789 RVA: 0x0020A35D File Offset: 0x0020855D
	private void OnClickLoopItem(int levelId)
	{
		ControllerBase<BabelTowerController>.Instance.SaveNewLevelClickData(levelId, EBabelTowerDifficulty.Normal);
		Singleton<UiManager>.Instance.OpenView(EUiViewName.BabelTowerDeTermSelectViewNew, levelId, null);
	}

	// Token: 0x06007C2E RID: 31790 RVA: 0x0020A381 File Offset: 0x00208581
	protected override void OnBeforeHide()
	{
		ModelBase<BabelTowerModel>.Instance.LevelChoseHandle = 0;
	}

	// Token: 0x06007C2F RID: 31791 RVA: 0x0020A38E File Offset: 0x0020858E
	private BabelTowerNormalLevelChoseItem InitItem()
	{
		return new BabelTowerNormalLevelChoseItem
		{
			OnClickButtonCallBack = new Action<int>(this.OnClickLoopItem)
		};
	}

	// Token: 0x06007C30 RID: 31792 RVA: 0x0020A3A8 File Offset: 0x002085A8
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
		LoopScrollView<BabelTowerNormalLevelChoseItem, BabelActivityLevelInfo> loopScrollView = this.LoopScrollView;
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

	// Token: 0x04003B60 RID: 15200
	[Nullable(2)]
	private IBabelTowerNormalLevelChoseViewData Data;

	// Token: 0x04003B61 RID: 15201
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x04003B62 RID: 15202
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<BabelTowerNormalLevelChoseItem, BabelActivityLevelInfo> LoopScrollView;

	// Token: 0x04003B63 RID: 15203
	private List<BabelActivityLevelInfo> LevelList = new List<BabelActivityLevelInfo>();

	// Token: 0x04003B64 RID: 15204
	[Nullable(2)]
	private BabelTowerNormalLevelChoseItem CurrentPlayLoopSeqItem;

	// Token: 0x0200759C RID: 30108
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x04028944 RID: 166212
		public const int CaptionItem = 0;

		// Token: 0x04028945 RID: 166213
		public const int TargetText = 1;

		// Token: 0x04028946 RID: 166214
		public const int ShopItem = 2;

		// Token: 0x04028947 RID: 166215
		public const int ShopBtnRedDotItem = 3;

		// Token: 0x04028948 RID: 166216
		public const int QuestBtn = 4;

		// Token: 0x04028949 RID: 166217
		public const int QuestBtnRedDotItem = 5;

		// Token: 0x0402894A RID: 166218
		public const int QuestBtnText1 = 6;

		// Token: 0x0402894B RID: 166219
		public const int QuestBtnText2 = 7;

		// Token: 0x0402894C RID: 166220
		public const int LoopScrollView = 8;

		// Token: 0x0402894D RID: 166221
		public const int LoopScrollItem = 9;
	}
}
