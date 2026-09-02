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
	// Token: 0x02005739 RID: 22329
	[NullableContext(1)]
	[Nullable(0)]
	public class CollectItemView : CollectItemViewBase
	{
		// Token: 0x06038D3F RID: 232767 RVA: 0x00E64FA8 File Offset: 0x00E631A8
		public CollectItemView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06038D40 RID: 232768 RVA: 0x00E64FB4 File Offset: 0x00E631B4
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(2, typeof(UUISprite)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUIText)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIText)),
				new ValueTuple<int, Type>(7, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(8, typeof(UUIText)),
				new ValueTuple<int, Type>(9, typeof(UUIItem)),
				new ValueTuple<int, Type>(10, typeof(UUIText)),
				new ValueTuple<int, Type>(11, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(12, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnClickedLeftButton)),
				new ValueTuple<int, Delegate>(1, new Action(this.OnClickedRightButton)),
				new ValueTuple<int, Delegate>(7, new Action(this.OnClickedConfirmButton)),
				new ValueTuple<int, Delegate>(11, new Action(this.OnClickedItemButton)),
				new ValueTuple<int, Delegate>(12, new Action(this.OnClickedCloseButton))
			};
		}

		// Token: 0x06038D41 RID: 232769 RVA: 0x00E65174 File Offset: 0x00E63374
		protected override void OnBegined()
		{
			UUIItem item = base.GetItem(5);
			this.RewardItemScrollView = new GenericLayout<CollectSmallItemGrid, IRewardItemData>((UUILayoutBase)item.GetOwner().GetComponentByClass(UUILayoutBase.StaticClass()), new Func<CollectSmallItemGrid>(this.OnCreateRewardItem), null, false, true);
			this.ProgressBarSprite = base.GetSprite(2);
			this.Refresh();
		}

		// Token: 0x06038D42 RID: 232770 RVA: 0x00E651D0 File Offset: 0x00E633D0
		protected override void OnEnded()
		{
			this.RewardItemScrollView = null;
			this.ProgressBarSprite = null;
		}

		// Token: 0x06038D43 RID: 232771 RVA: 0x00E651E0 File Offset: 0x00E633E0
		protected override void OnUpdateDragonPoolView()
		{
			this.JumpNextLevel();
		}

		// Token: 0x06038D44 RID: 232772 RVA: 0x00E651E8 File Offset: 0x00E633E8
		protected override void OnSubmitItemLevelUp()
		{
			this.SetActive(false);
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.HangPlotViewHud, true);
		}

		// Token: 0x06038D45 RID: 232773 RVA: 0x00E65202 File Offset: 0x00E63402
		protected override void OnSubmitItemLevelMax()
		{
			this.SetActive(false);
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.HangPlotViewHud, true);
		}

		// Token: 0x06038D46 RID: 232774 RVA: 0x00E6521C File Offset: 0x00E6341C
		protected override void OnLevelUpSequenceFinished()
		{
			this.SetActive(true);
			this.IsInLevelUpDisplay = false;
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.HangPlotViewHud, false);
		}

		// Token: 0x06038D47 RID: 232775 RVA: 0x00E6523D File Offset: 0x00E6343D
		protected override void OnLevelMaxSequenceFinished()
		{
			base.CloseMe(null);
		}

		// Token: 0x06038D48 RID: 232776 RVA: 0x00E65248 File Offset: 0x00E63448
		protected override void OnSubmitItemLevelUpSequencePlayFail()
		{
			Singleton<Log>.Instance.Info(ELogModule.NPC, ELogAuthor.BB, "[CollectionItemDisplay]当交付等级提升Sequence播放失败时，重新显示提交道具界面", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.IsInLevelUpDisplay = false;
			this.SetActive(true);
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.HangPlotViewHud, false);
		}

		// Token: 0x06038D49 RID: 232777 RVA: 0x00E65293 File Offset: 0x00E63493
		protected override void OnCollectItemCountChanged(int count)
		{
			this.RefreshCountText();
		}

		// Token: 0x06038D4A RID: 232778 RVA: 0x00E6529C File Offset: 0x00E6349C
		protected override void OnCloseRewardView()
		{
			Singleton<Log>.Instance.Info(ELogModule.NPC, ELogAuthor.BB, "[CollectionItemDisplay]当关闭了交付奖励结算界面时，重新显示提交道具界面", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.IsInLevelUpDisplay = false;
			this.SetActive(true);
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.HangPlotViewHud, false);
		}

		// Token: 0x06038D4B RID: 232779 RVA: 0x00E652E7 File Offset: 0x00E634E7
		private CollectSmallItemGrid OnCreateRewardItem()
		{
			CollectSmallItemGrid collectSmallItemGrid = new CollectSmallItemGrid();
			collectSmallItemGrid.BindOnExtendToggleRelease(new Action<MediumItemGridExtendCallback>(this.OnExtendToggleRelease));
			collectSmallItemGrid.BindOnCanExecuteChange((object _, bool __, EToggleState ___) => false);
			return collectSmallItemGrid;
		}

		// Token: 0x06038D4C RID: 232780 RVA: 0x00E65328 File Offset: 0x00E63528
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

		// Token: 0x06038D4D RID: 232781 RVA: 0x00E65374 File Offset: 0x00E63574
		private void OnClickedLeftButton()
		{
			this.CurrentShowLevel--;
			this.Refresh();
		}

		// Token: 0x06038D4E RID: 232782 RVA: 0x00E6538A File Offset: 0x00E6358A
		private void OnClickedRightButton()
		{
			this.CurrentShowLevel++;
			this.Refresh();
		}

		// Token: 0x06038D4F RID: 232783 RVA: 0x00E653A0 File Offset: 0x00E635A0
		private unsafe void OnClickedConfirmButton()
		{
			if (this.IsInLevelUpDisplay)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.NPC;
				ELogAuthor author = ELogAuthor.BB;
				string message = "[CollectionItemDisplay]当点击交付按钮时，在播放等级提升动画，不做任何响应";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("PoolConfigId", this.PoolConfigId);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			MingSuModel instance2 = ModelBase<MingSuModel>.Instance;
			int targetDragonPoolLevelById = instance2.GetTargetDragonPoolLevelById(this.PoolConfigId);
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.NPC;
			ELogAuthor author2 = ELogAuthor.BB;
			string message2 = "[CollectionItemDisplay]当点击交付按钮时";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CurrentShowLevel", this.CurrentShowLevel);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("dragonPoolLevel", targetDragonPoolLevelById);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("PoolConfigId", this.PoolConfigId);
			instance3.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			if (this.CurrentShowLevel != targetDragonPoolLevelById + 1)
			{
				this.JumpNextLevel();
				return;
			}
			if (instance2.CheckUp(this.PoolConfigId))
			{
				instance2.MingSuLastLevel = instance2.GetTargetDragonPoolLevelById(this.PoolConfigId);
				if (instance2.CanLevelUp(this.PoolConfigId))
				{
					Singleton<Log>.Instance.Info(ELogModule.NPC, ELogAuthor.BB, "[CollectionItemDisplay]提交声匣之后，等级提升会播放等级提升Sequence，IsInLevelUpDisplay设置为true", default(ReadOnlySpan<ValueTuple<string, object>>));
					this.IsInLevelUpDisplay = true;
				}
				Log instance4 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.NPC;
				ELogAuthor author3 = ELogAuthor.BB;
				string message3 = "[CollectionItemDisplay]提交声匣之后，隐藏界面并发送给服务端";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("PoolConfigId", this.PoolConfigId);
				instance4.Info(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				MingSuController.SendHandInMingSuRequest(this.PoolConfigId);
				return;
			}
			Singleton<Log>.Instance.Info(ELogModule.NPC, ELogAuthor.BB, "[CollectionItemDisplay]当点击交付按钮时,当前经验无法升级，不会播放提交道具表现", default(ReadOnlySpan<ValueTuple<string, object>>));
			Singleton<EventSystem>.Instance.Emit(EEventName.OnSubmitItemFail);
		}

		// Token: 0x06038D50 RID: 232784 RVA: 0x00E65561 File Offset: 0x00E63761
		private void OnClickedItemButton()
		{
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(this.CollectItemConfigId, true, null);
		}

		// Token: 0x06038D51 RID: 232785 RVA: 0x00E65575 File Offset: 0x00E63775
		private void OnClickedCloseButton()
		{
			base.CloseMe(null);
		}

		// Token: 0x06038D52 RID: 232786 RVA: 0x00E65580 File Offset: 0x00E63780
		private void JumpNextLevel()
		{
			int targetDragonPoolMaxLevelById = ModelBase<MingSuModel>.Instance.GetTargetDragonPoolMaxLevelById(this.PoolConfigId);
			int targetDragonPoolLevelById = ModelBase<MingSuModel>.Instance.GetTargetDragonPoolLevelById(this.PoolConfigId);
			this.CurrentShowLevel = Math.Min(targetDragonPoolMaxLevelById, targetDragonPoolLevelById + 1);
			this.Refresh();
		}

		// Token: 0x06038D53 RID: 232787 RVA: 0x00E655C4 File Offset: 0x00E637C4
		private void Refresh()
		{
			this.RefreshShowLevel(this.CurrentShowLevel);
			this.RefreshLeftRightBtnState();
			this.RefreshProgressBar();
			this.RefreshReward();
			this.RefreshCostItem();
			this.RefreshConfirmButton();
			this.RefreshCountText();
		}

		// Token: 0x06038D54 RID: 232788 RVA: 0x00E655F8 File Offset: 0x00E637F8
		private void RefreshShowLevel(int level)
		{
			UUIText text = base.GetText(3);
			int num = Math.Min(ModelBase<MingSuModel>.Instance.GetTargetDragonPoolMaxLevelById(this.PoolConfigId), level);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "MingSuLevelText", new <>z__ReadOnlySingleElementList<object>(num));
			this.CurrentShowLevel = num;
			ModelBase<MingSuModel>.Instance.CurrentPreviewLevel = this.CurrentShowLevel;
		}

		// Token: 0x06038D55 RID: 232789 RVA: 0x00E65658 File Offset: 0x00E63858
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

		// Token: 0x06038D56 RID: 232790 RVA: 0x00E656DC File Offset: 0x00E638DC
		private void RefreshProgressBar()
		{
			MingSuModel instance = ModelBase<MingSuModel>.Instance;
			int targetDragonPoolLevelById = instance.GetTargetDragonPoolLevelById(this.PoolConfigId);
			int targetDragonPoolMaxLevelById = instance.GetTargetDragonPoolMaxLevelById(this.PoolConfigId);
			UUIText text = base.GetText(4);
			int targetDragonPoolActiveById = instance.GetTargetDragonPoolActiveById(this.PoolConfigId);
			if (this.CurrentShowLevel == targetDragonPoolLevelById + 1 || (this.CurrentShowLevel == targetDragonPoolLevelById && this.CurrentShowLevel == targetDragonPoolMaxLevelById))
			{
				int num = targetDragonPoolLevelById;
				this.CurrentShowState = MingSuDefine.EMingSuShowState.OnGoing;
				if (targetDragonPoolActiveById == 2)
				{
					this.CurrentShowState = MingSuDefine.EMingSuShowState.Done;
				}
				if (targetDragonPoolLevelById == targetDragonPoolMaxLevelById)
				{
					num--;
				}
				int targetDragonPoolLevelNeedCoreById = instance.GetTargetDragonPoolLevelNeedCoreById(this.PoolConfigId, num);
				int num2;
				if (targetDragonPoolActiveById == 2)
				{
					num2 = targetDragonPoolLevelNeedCoreById;
				}
				else
				{
					num2 = instance.GetTargetDragonPoolCoreCountById(this.PoolConfigId);
				}
				float fillAmount = (float)num2 / (float)targetDragonPoolLevelNeedCoreById;
				this.ProgressBarSprite.SetFillAmount(fillAmount);
				text.SetText(num2.ToString() + "/" + targetDragonPoolLevelNeedCoreById.ToString(), true);
				return;
			}
			if (this.CurrentShowLevel <= targetDragonPoolLevelById)
			{
				this.CurrentShowState = MingSuDefine.EMingSuShowState.Done;
				int targetDragonPoolLevelNeedCoreById2 = instance.GetTargetDragonPoolLevelNeedCoreById(this.PoolConfigId, this.CurrentShowLevel - 1);
				text.SetText(targetDragonPoolLevelNeedCoreById2.ToString() + "/" + targetDragonPoolLevelNeedCoreById2.ToString(), true);
				this.ProgressBarSprite.SetFillAmount(1f);
				return;
			}
			if (this.CurrentShowLevel > targetDragonPoolLevelById + 1)
			{
				this.CurrentShowState = MingSuDefine.EMingSuShowState.NoStart;
				text.SetText("0/" + instance.GetTargetDragonPoolLevelNeedCoreById(this.PoolConfigId, this.CurrentShowLevel - 1).ToString(), true);
				this.ProgressBarSprite.SetFillAmount(0f);
			}
		}

		// Token: 0x06038D57 RID: 232791 RVA: 0x00E6586C File Offset: 0x00E63A6C
		private void RefreshReward()
		{
			List<IRewardItemData> targetDragonPoolLevelRewardById = ModelBase<MingSuModel>.Instance.GetTargetDragonPoolLevelRewardById(this.PoolConfigId, this.CurrentShowLevel - 1);
			this.RewardItemScrollView.RefreshByData((targetDragonPoolLevelRewardById != null) ? new List<IRewardItemData>(targetDragonPoolLevelRewardById) : new List<IRewardItemData>(), null, false);
		}

		// Token: 0x06038D58 RID: 232792 RVA: 0x00E658B0 File Offset: 0x00E63AB0
		private void RefreshCostItem()
		{
			UUIText text = base.GetText(6);
			if (ModelBase<MingSuModel>.Instance.GetTargetDragonPoolActiveById(this.PoolConfigId) == 2)
			{
				this.CurrentShowState = MingSuDefine.EMingSuShowState.Finish;
			}
			if (this.CurrentShowState == MingSuDefine.EMingSuShowState.OnGoing)
			{
				text.SetUIActive(false);
				return;
			}
			if (this.CurrentShowState == MingSuDefine.EMingSuShowState.Done)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "MingSuDoneTips", Array.Empty<object>());
				text.SetUIActive(true);
				return;
			}
			if (this.CurrentShowState == MingSuDefine.EMingSuShowState.NoStart)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "MingSuNotDoneTips", Array.Empty<object>());
				text.SetUIActive(true);
				return;
			}
			if (this.CurrentShowState == MingSuDefine.EMingSuShowState.Finish)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "MingSuDoneTips", Array.Empty<object>());
				text.SetUIActive(true);
			}
		}

		// Token: 0x06038D59 RID: 232793 RVA: 0x00E65960 File Offset: 0x00E63B60
		private void RefreshConfirmButton()
		{
			UUIText text = base.GetText(8);
			bool flag = ModelBase<MingSuModel>.Instance.GetTargetDragonPoolActiveById(this.PoolConfigId) == 2;
			base.GetItem(9).SetUIActive(!flag);
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

		// Token: 0x06038D5A RID: 232794 RVA: 0x00E659E4 File Offset: 0x00E63BE4
		private void RefreshCountText()
		{
			int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(this.CollectItemConfigId, 0);
			base.GetText(10).SetText(itemCountByConfigId.ToString(), true);
		}

		// Token: 0x040205EF RID: 132591
		private MingSuDefine.EMingSuShowState CurrentShowState;

		// Token: 0x040205F0 RID: 132592
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<CollectSmallItemGrid, IRewardItemData> RewardItemScrollView;

		// Token: 0x040205F1 RID: 132593
		[Nullable(2)]
		private UUISprite ProgressBarSprite;

		// Token: 0x040205F2 RID: 132594
		private bool IsInLevelUpDisplay;

		// Token: 0x0200B7E6 RID: 47078
		[NullableContext(0)]
		private static class EChildType
		{
			// Token: 0x04038E02 RID: 232962
			public const int LeftButton = 0;

			// Token: 0x04038E03 RID: 232963
			public const int RightButton = 1;

			// Token: 0x04038E04 RID: 232964
			public const int ProgressBarSprite = 2;

			// Token: 0x04038E05 RID: 232965
			public const int LevelText = 3;

			// Token: 0x04038E06 RID: 232966
			public const int NeedCountText = 4;

			// Token: 0x04038E07 RID: 232967
			public const int ContentItem = 5;

			// Token: 0x04038E08 RID: 232968
			public const int TipsText = 6;

			// Token: 0x04038E09 RID: 232969
			public const int ConfirmButton = 7;

			// Token: 0x04038E0A RID: 232970
			public const int ConfirmButtonText = 8;

			// Token: 0x04038E0B RID: 232971
			public const int ConfirmButtonItem = 9;

			// Token: 0x04038E0C RID: 232972
			public const int ItemCountText = 10;

			// Token: 0x04038E0D RID: 232973
			public const int ItemButton = 11;

			// Token: 0x04038E0E RID: 232974
			public const int CloseButton = 12;
		}
	}
}
