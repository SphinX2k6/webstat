using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.MingSu.View
{
	// Token: 0x02005744 RID: 22340
	[NullableContext(1)]
	[Nullable(0)]
	public class MingSuView : CollectItemViewBase
	{
		// Token: 0x06038DDF RID: 232927 RVA: 0x00E68788 File Offset: 0x00E66988
		public MingSuView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06038DE0 RID: 232928 RVA: 0x00E68794 File Offset: 0x00E66994
		protected override void OnRegisterComponent()
		{
			Singleton<Log>.Instance.Info(ELogModule.MingSuTi, ELogAuthor.BB, "创建鸣素体界面!!!!", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.InitComponent();
		}

		// Token: 0x06038DE1 RID: 232929 RVA: 0x00E687C3 File Offset: 0x00E669C3
		protected override void OnBegined()
		{
			IUiPopFrameInterface childPopView = this.ChildPopView;
			if (childPopView != null)
			{
				childPopView.PopItem.OverrideBackBtnCallBack(delegate
				{
				});
			}
			this.InitView();
		}

		// Token: 0x06038DE2 RID: 232930 RVA: 0x00E68800 File Offset: 0x00E66A00
		protected override void OnAfterShow()
		{
			this.UiViewSequence.PlaySequencePurely("Show", false, false);
		}

		// Token: 0x06038DE3 RID: 232931 RVA: 0x00E68814 File Offset: 0x00E66A14
		protected override void OnEnded()
		{
			if (this.LoadSequenceHandleId != null)
			{
				Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.LoadSequenceHandleId.Value);
				this.LoadSequenceHandleId = null;
			}
			this.ExpBarSprite = null;
		}

		// Token: 0x06038DE4 RID: 232932 RVA: 0x00E6884C File Offset: 0x00E66A4C
		private void InitComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(2, typeof(UUISprite)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUIText)),
				new ValueTuple<int, Type>(5, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIText)),
				new ValueTuple<int, Type>(8, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(9, typeof(UUIText)),
				new ValueTuple<int, Type>(10, typeof(UUIItem)),
				new ValueTuple<int, Type>(11, typeof(UUIText)),
				new ValueTuple<int, Type>(12, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(13, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnLeftMove)),
				new ValueTuple<int, Delegate>(1, new Action(this.OnRightMove)),
				new ValueTuple<int, Delegate>(8, new Action(this.OnAddCore)),
				new ValueTuple<int, Delegate>(12, new Action(this.OnClickedItemButton)),
				new ValueTuple<int, Delegate>(13, new Action(this.OnClickedCloseButton))
			};
		}

		// Token: 0x06038DE5 RID: 232933 RVA: 0x00E68A22 File Offset: 0x00E66C22
		private void InitView()
		{
			this.ExpBarSprite = base.GetSprite(2);
			this.RefreshAll();
		}

		// Token: 0x06038DE6 RID: 232934 RVA: 0x00E68A38 File Offset: 0x00E66C38
		private void RefreshShowLevel(int level)
		{
			UUIText text = base.GetText(3);
			int targetDragonPoolMaxLevelById = ModelBase<MingSuModel>.Instance.GetTargetDragonPoolMaxLevelById(this.PoolConfigId);
			int num = level;
			if (num > targetDragonPoolMaxLevelById)
			{
				num = targetDragonPoolMaxLevelById;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "MingSuLevelText", new <>z__ReadOnlySingleElementList<object>(num));
			this.CurrentShowLevel = num;
			ModelBase<MingSuModel>.Instance.CurrentPreviewLevel = this.CurrentShowLevel;
		}

		// Token: 0x06038DE7 RID: 232935 RVA: 0x00E68A98 File Offset: 0x00E66C98
		private void RefreshLeftRightBtnState()
		{
			UUIItem uuiitem = base.GetButton(0).RootUIComp.Get();
			UUIItem uuiitem2 = base.GetButton(1).RootUIComp.Get();
			if (this.CurrentShowLevel == 1)
			{
				uuiitem.SetUIActive(false);
				uuiitem2.SetUIActive(true);
				return;
			}
			if (this.CurrentShowLevel == ModelBase<MingSuModel>.Instance.GetTargetDragonPoolMaxLevelById(this.PoolConfigId))
			{
				uuiitem2.SetUIActive(false);
				uuiitem.SetUIActive(true);
				return;
			}
			uuiitem2.SetUIActive(true);
			uuiitem.SetUIActive(true);
		}

		// Token: 0x06038DE8 RID: 232936 RVA: 0x00E68B1C File Offset: 0x00E66D1C
		private void RefreshCoreData()
		{
			MingSuModel instance = ModelBase<MingSuModel>.Instance;
			int targetDragonPoolLevelById = instance.GetTargetDragonPoolLevelById(this.PoolConfigId);
			int targetDragonPoolMaxLevelById = instance.GetTargetDragonPoolMaxLevelById(this.PoolConfigId);
			UUIText text = base.GetText(4);
			if (this.CurrentShowLevel == targetDragonPoolLevelById + 1 || (this.CurrentShowLevel == targetDragonPoolLevelById && this.CurrentShowLevel == targetDragonPoolMaxLevelById))
			{
				int num = targetDragonPoolLevelById;
				this.ShowState = MingSuDefine.EMingSuShowState.OnGoing;
				if (instance.GetTargetDragonPoolActiveById(this.PoolConfigId) == 2)
				{
					this.ShowState = MingSuDefine.EMingSuShowState.Done;
				}
				if (targetDragonPoolLevelById == targetDragonPoolMaxLevelById)
				{
					num--;
				}
				int targetDragonPoolLevelNeedCoreById = instance.GetTargetDragonPoolLevelNeedCoreById(this.PoolConfigId, num);
				int num2 = (instance.GetTargetDragonPoolActiveById(this.PoolConfigId) == 2) ? targetDragonPoolLevelNeedCoreById : instance.GetTargetDragonPoolCoreCountById(this.PoolConfigId);
				float fillAmount = (float)num2 / (float)targetDragonPoolLevelNeedCoreById;
				this.ExpBarSprite.SetFillAmount(fillAmount);
				text.SetText(num2.ToString() + "/" + targetDragonPoolLevelNeedCoreById.ToString(), true);
				return;
			}
			if (this.CurrentShowLevel <= targetDragonPoolLevelById)
			{
				this.ShowState = MingSuDefine.EMingSuShowState.Done;
				int targetDragonPoolLevelNeedCoreById2 = instance.GetTargetDragonPoolLevelNeedCoreById(this.PoolConfigId, this.CurrentShowLevel - 1);
				text.SetText(targetDragonPoolLevelNeedCoreById2.ToString() + "/" + targetDragonPoolLevelNeedCoreById2.ToString(), true);
				this.ExpBarSprite.SetFillAmount(1f);
				return;
			}
			if (this.CurrentShowLevel > targetDragonPoolLevelById + 1)
			{
				this.ShowState = MingSuDefine.EMingSuShowState.NoStart;
				text.SetText("0/" + instance.GetTargetDragonPoolLevelNeedCoreById(this.PoolConfigId, this.CurrentShowLevel - 1).ToString(), true);
				this.ExpBarSprite.SetFillAmount(0f);
			}
		}

		// Token: 0x06038DE9 RID: 232937 RVA: 0x00E68CAC File Offset: 0x00E66EAC
		private void RefreshReward()
		{
			List<IRewardItemData> targetDragonPoolLevelRewardById = ModelBase<MingSuModel>.Instance.GetTargetDragonPoolLevelRewardById(this.PoolConfigId, this.CurrentShowLevel - 1);
			UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(5);
			if (this.RewardItemScrollView == null)
			{
				this.RewardItemScrollView = new GenericLayout<CollectSmallItemGrid, IRewardItemData>((UUILayoutBase)scrollViewWithScrollbar.GetContent().GetComponentByClass(UUILayoutBase.StaticClass()), new Func<CollectSmallItemGrid>(this.OnCreateRewardItem), null, false, true);
			}
			this.RewardItemScrollView.RefreshByData(targetDragonPoolLevelRewardById, null, false);
		}

		// Token: 0x06038DEA RID: 232938 RVA: 0x00E68D24 File Offset: 0x00E66F24
		private CollectSmallItemGrid OnCreateRewardItem()
		{
			CollectSmallItemGrid collectSmallItemGrid = new CollectSmallItemGrid();
			collectSmallItemGrid.BindOnExtendToggleRelease(new Action<MediumItemGridExtendCallback>(this.OnExtendToggleRelease));
			collectSmallItemGrid.BindOnCanExecuteChange((object _, bool __, EToggleState ___) => false);
			return collectSmallItemGrid;
		}

		// Token: 0x06038DEB RID: 232939 RVA: 0x00E68D64 File Offset: 0x00E66F64
		private void OnExtendToggleRelease(MediumItemGridExtendCallback callbackParameter)
		{
			if (!callbackParameter.MediumItemGrid.IsHover)
			{
				return;
			}
			IRewardItemData rewardItemData = callbackParameter.Data as IRewardItemData;
			if (((rewardItemData != null) ? rewardItemData.ItemInfo : null) != null)
			{
				ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(rewardItemData.ItemInfo.Id, true, null);
			}
		}

		// Token: 0x06038DEC RID: 232940 RVA: 0x00E68DB0 File Offset: 0x00E66FB0
		private void RefreshCostItem()
		{
			UUIText text = base.GetText(7);
			if (ModelBase<MingSuModel>.Instance.GetTargetDragonPoolActiveById(this.PoolConfigId) == 2)
			{
				this.ShowState = MingSuDefine.EMingSuShowState.Finish;
			}
			if (this.ShowState == MingSuDefine.EMingSuShowState.OnGoing)
			{
				text.SetUIActive(false);
				return;
			}
			if (this.ShowState == MingSuDefine.EMingSuShowState.Done)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "MingSuDoneTips", Array.Empty<object>());
				text.SetUIActive(true);
				return;
			}
			if (this.ShowState == MingSuDefine.EMingSuShowState.NoStart)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "MingSuNotDoneTips", Array.Empty<object>());
				text.SetUIActive(true);
				return;
			}
			if (this.ShowState == MingSuDefine.EMingSuShowState.Finish)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "MingSuDoneTips", Array.Empty<object>());
				text.SetUIActive(true);
			}
		}

		// Token: 0x06038DED RID: 232941 RVA: 0x00E68E60 File Offset: 0x00E67060
		private void RefreshAddButton()
		{
			UUIText text = base.GetText(9);
			bool flag = ModelBase<MingSuModel>.Instance.GetTargetDragonPoolActiveById(this.PoolConfigId) == 2;
			base.GetItem(10).SetUIActive(!flag);
			if (!flag)
			{
				int targetDragonPoolLevelById = ModelBase<MingSuModel>.Instance.GetTargetDragonPoolLevelById(this.PoolConfigId);
				if (this.CurrentShowLevel == targetDragonPoolLevelById + 1)
				{
					Singleton<LguiUtil>.Instance.SetLocalText(text, "MingSuTi_Text3", Array.Empty<object>());
					return;
				}
				Singleton<LguiUtil>.Instance.SetLocalText(text, "MingSuTi_Text4", Array.Empty<object>());
			}
		}

		// Token: 0x06038DEE RID: 232942 RVA: 0x00E68EE8 File Offset: 0x00E670E8
		private void RefreshCountText()
		{
			int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(40040001, 0);
			base.GetText(11).SetText(itemCountByConfigId.ToString(), true);
		}

		// Token: 0x06038DEF RID: 232943 RVA: 0x00E68F1C File Offset: 0x00E6711C
		private void JumpLevel()
		{
			int targetDragonPoolMaxLevelById = ModelBase<MingSuModel>.Instance.GetTargetDragonPoolMaxLevelById(this.PoolConfigId);
			int targetDragonPoolLevelById = ModelBase<MingSuModel>.Instance.GetTargetDragonPoolLevelById(this.PoolConfigId);
			if (targetDragonPoolLevelById == targetDragonPoolMaxLevelById)
			{
				this.CurrentShowLevel = targetDragonPoolLevelById;
			}
			else
			{
				this.CurrentShowLevel = targetDragonPoolLevelById + 1;
			}
			this.RefreshAll();
		}

		// Token: 0x06038DF0 RID: 232944 RVA: 0x00E68F67 File Offset: 0x00E67167
		private void RefreshAll()
		{
			this.RefreshShowLevel(this.CurrentShowLevel);
			this.RefreshLeftRightBtnState();
			this.RefreshCoreData();
			this.RefreshReward();
			this.RefreshCostItem();
			this.RefreshAddButton();
			this.RefreshCountText();
		}

		// Token: 0x06038DF1 RID: 232945 RVA: 0x00E68F99 File Offset: 0x00E67199
		protected override void OnUpdateDragonPoolView()
		{
			this.JumpLevel();
		}

		// Token: 0x06038DF2 RID: 232946 RVA: 0x00E68FA1 File Offset: 0x00E671A1
		protected override void OnSubmitItemLevelUp()
		{
			this.SetActive(false);
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.HangPlotViewHud, true);
		}

		// Token: 0x06038DF3 RID: 232947 RVA: 0x00E68FBB File Offset: 0x00E671BB
		protected override void OnSubmitItemLevelMax()
		{
			this.SetActive(false);
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.HangPlotViewHud, true);
		}

		// Token: 0x06038DF4 RID: 232948 RVA: 0x00E68FD5 File Offset: 0x00E671D5
		protected override void OnSubmitItemLevelUpSequencePlayFail()
		{
			this.IsInLevelUpDisplay = false;
			this.SetActive(true);
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.HangPlotViewHud, false);
		}

		// Token: 0x06038DF5 RID: 232949 RVA: 0x00E68FF6 File Offset: 0x00E671F6
		protected override void OnCollectItemCountChanged(int count)
		{
			this.RefreshCountText();
		}

		// Token: 0x06038DF6 RID: 232950 RVA: 0x00E68FFE File Offset: 0x00E671FE
		protected override void OnLevelMaxSequenceFinished()
		{
			this.SetActive(true);
			this.IsInLevelUpDisplay = false;
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.HangPlotViewHud, false);
		}

		// Token: 0x06038DF7 RID: 232951 RVA: 0x00E6901F File Offset: 0x00E6721F
		protected override void OnLevelUpSequenceFinished()
		{
			this.SetActive(true);
			this.IsInLevelUpDisplay = false;
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.HangPlotViewHud, false);
		}

		// Token: 0x06038DF8 RID: 232952 RVA: 0x00E69040 File Offset: 0x00E67240
		private void OnLeftMove()
		{
			this.CurrentShowLevel--;
			this.RefreshAll();
			Singleton<Log>.Instance.Info(ELogModule.MingSuTi, ELogAuthor.BB, "当前等级: " + this.CurrentShowLevel.ToString() + " left " + ModelBase<MingSuModel>.Instance.GetTargetDragonPoolMaxLevelById(this.PoolConfigId).ToString(), default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x06038DF9 RID: 232953 RVA: 0x00E690AC File Offset: 0x00E672AC
		private void OnRightMove()
		{
			this.CurrentShowLevel++;
			this.RefreshAll();
			Singleton<Log>.Instance.Info(ELogModule.MingSuTi, ELogAuthor.BB, "当前等级: " + this.CurrentShowLevel.ToString() + " right " + ModelBase<MingSuModel>.Instance.GetTargetDragonPoolMaxLevelById(this.PoolConfigId).ToString(), default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x06038DFA RID: 232954 RVA: 0x00E69118 File Offset: 0x00E67318
		private void OnAddCore()
		{
			if (this.IsInLevelUpDisplay)
			{
				return;
			}
			MingSuModel instance = ModelBase<MingSuModel>.Instance;
			int targetDragonPoolLevelById = instance.GetTargetDragonPoolLevelById(this.PoolConfigId);
			if (this.CurrentShowLevel != targetDragonPoolLevelById + 1)
			{
				this.JumpLevel();
				return;
			}
			if (instance.CheckUp(this.PoolConfigId))
			{
				instance.MingSuLastLevel = instance.GetTargetDragonPoolLevelById(this.PoolConfigId);
				if (instance.CanLevelUp(this.PoolConfigId))
				{
					this.IsInLevelUpDisplay = true;
				}
				MingSuController.SendHandInMingSuRequest(this.PoolConfigId);
				Singleton<Log>.Instance.Info(ELogModule.MingSuTi, ELogAuthor.BB, "可以升级", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.OnSubmitItemFail);
			Singleton<Log>.Instance.Info(ELogModule.MingSuTi, ELogAuthor.BB, "不可升级!!!!", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x06038DFB RID: 232955 RVA: 0x00E691DF File Offset: 0x00E673DF
		private void OnClickedItemButton()
		{
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(40040001, true, null);
		}

		// Token: 0x06038DFC RID: 232956 RVA: 0x00E691F2 File Offset: 0x00E673F2
		private void OnClickedCloseButton()
		{
			base.CloseMe(null);
		}

		// Token: 0x04020626 RID: 132646
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<CollectSmallItemGrid, IRewardItemData> RewardItemScrollView;

		// Token: 0x04020627 RID: 132647
		private MingSuDefine.EMingSuShowState ShowState;

		// Token: 0x04020628 RID: 132648
		private int? LoadSequenceHandleId;

		// Token: 0x04020629 RID: 132649
		[Nullable(2)]
		private UUISprite ExpBarSprite;

		// Token: 0x0402062A RID: 132650
		private bool IsInLevelUpDisplay;

		// Token: 0x0200B7F6 RID: 47094
		[NullableContext(0)]
		private static class EChildType
		{
			// Token: 0x04038E72 RID: 233074
			public const int LeftButton = 0;

			// Token: 0x04038E73 RID: 233075
			public const int RightButton = 1;

			// Token: 0x04038E74 RID: 233076
			public const int ExpBarSprite = 2;

			// Token: 0x04038E75 RID: 233077
			public const int LevelText = 3;

			// Token: 0x04038E76 RID: 233078
			public const int ExpText = 4;

			// Token: 0x04038E77 RID: 233079
			public const int RewardItemScrollbar = 5;

			// Token: 0x04038E78 RID: 233080
			public const int ContentItem = 6;

			// Token: 0x04038E79 RID: 233081
			public const int TipsText = 7;

			// Token: 0x04038E7A RID: 233082
			public const int ConfirmButton = 8;

			// Token: 0x04038E7B RID: 233083
			public const int ConfirmText = 9;

			// Token: 0x04038E7C RID: 233084
			public const int ConfirmButtonItem = 10;

			// Token: 0x04038E7D RID: 233085
			public const int CountText = 11;

			// Token: 0x04038E7E RID: 233086
			public const int ItemButton = 12;

			// Token: 0x04038E7F RID: 233087
			public const int CloseButton = 13;
		}
	}
}
