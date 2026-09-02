using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.MingSu.View
{
	// Token: 0x02005745 RID: 22341
	[NullableContext(1)]
	[Nullable(0)]
	public class PupuVillageCollectView : CollectItemViewBase
	{
		// Token: 0x06038DFD RID: 232957 RVA: 0x00E691FB File Offset: 0x00E673FB
		public PupuVillageCollectView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06038DFE RID: 232958 RVA: 0x00E69204 File Offset: 0x00E67404
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
				new ValueTuple<int, Type>(12, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(13, typeof(UUIItem)),
				new ValueTuple<int, Type>(14, typeof(UUITexture)),
				new ValueTuple<int, Type>(15, typeof(UUITexture)),
				new ValueTuple<int, Type>(16, typeof(UUIText))
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

		// Token: 0x06038DFF RID: 232959 RVA: 0x00E69420 File Offset: 0x00E67620
		protected override void OnBegined()
		{
			UUIItem item = base.GetItem(5);
			this.RewardItemScrollView = new GenericLayout<CollectSmallItemGrid, IRewardItemData>((UUILayoutBase)item.GetOwner().GetComponentByClass(UUILayoutBase.StaticClass()), new Func<CollectSmallItemGrid>(this.OnCreateRewardItem), null, false, true);
			this.ProgressBarSprite = base.GetSprite(2);
			if (this.PoolConfigId == 5)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(16), "NpcSystemBackground_1010_Title", Array.Empty<object>());
			}
			this.Refresh();
		}

		// Token: 0x06038E00 RID: 232960 RVA: 0x00E694A1 File Offset: 0x00E676A1
		protected override void OnEnded()
		{
			this.RewardItemScrollView = null;
			this.ProgressBarSprite = null;
			Singleton<EventSystem>.Instance.Emit(EEventName.OnExitNpcInteract);
		}

		// Token: 0x06038E01 RID: 232961 RVA: 0x00E694C1 File Offset: 0x00E676C1
		protected override void OnUpdateDragonPoolView()
		{
			this.JumpNextLevel();
		}

		// Token: 0x06038E02 RID: 232962 RVA: 0x00E694C9 File Offset: 0x00E676C9
		protected override void OnSubmitItemLevelUp()
		{
			this.SetActive(false);
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.HangPlotViewHud, true);
		}

		// Token: 0x06038E03 RID: 232963 RVA: 0x00E694E3 File Offset: 0x00E676E3
		protected override void OnSubmitItemLevelMax()
		{
			this.SetActive(false);
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.HangPlotViewHud, true);
		}

		// Token: 0x06038E04 RID: 232964 RVA: 0x00E694FD File Offset: 0x00E676FD
		protected override void OnLevelUpSequenceFinished()
		{
			this.SetActive(true);
			this.IsInLevelUpDisplay = false;
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.HangPlotViewHud, false);
		}

		// Token: 0x06038E05 RID: 232965 RVA: 0x00E6951E File Offset: 0x00E6771E
		protected override void OnLevelMaxSequenceFinished()
		{
			base.CloseMe(null);
		}

		// Token: 0x06038E06 RID: 232966 RVA: 0x00E69528 File Offset: 0x00E67728
		protected override void OnSubmitItemLevelUpSequencePlayFail()
		{
			Singleton<Log>.Instance.Info(ELogModule.NPC, ELogAuthor.BB, "[CollectionItemDisplay]当交付等级提升Sequence播放失败时，重新显示提交道具界面", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.IsInLevelUpDisplay = false;
			this.SetActive(true);
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.HangPlotViewHud, false);
		}

		// Token: 0x06038E07 RID: 232967 RVA: 0x00E69573 File Offset: 0x00E67773
		protected override void OnCollectItemCountChanged(int count)
		{
			this.RefreshCountText();
		}

		// Token: 0x06038E08 RID: 232968 RVA: 0x00E6957C File Offset: 0x00E6777C
		protected override void OnCloseRewardView()
		{
			Singleton<Log>.Instance.Info(ELogModule.NPC, ELogAuthor.BB, "[CollectionItemDisplay]当关闭了交付奖励结算界面时，重新显示提交道具界面", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.IsInLevelUpDisplay = false;
			this.SetActive(true);
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.HangPlotViewHud, false);
		}

		// Token: 0x06038E09 RID: 232969 RVA: 0x00E695C7 File Offset: 0x00E677C7
		private CollectSmallItemGrid OnCreateRewardItem()
		{
			CollectSmallItemGrid collectSmallItemGrid = new CollectSmallItemGrid();
			collectSmallItemGrid.BindOnExtendToggleRelease(new Action<MediumItemGridExtendCallback>(this.OnExtendToggleRelease));
			collectSmallItemGrid.BindOnCanExecuteChange((object _, bool __, EToggleState ___) => false);
			return collectSmallItemGrid;
		}

		// Token: 0x06038E0A RID: 232970 RVA: 0x00E69608 File Offset: 0x00E67808
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

		// Token: 0x06038E0B RID: 232971 RVA: 0x00E69654 File Offset: 0x00E67854
		private void OnClickedLeftButton()
		{
			this.CurrentShowLevel--;
			this.Refresh();
		}

		// Token: 0x06038E0C RID: 232972 RVA: 0x00E6966A File Offset: 0x00E6786A
		private void OnClickedRightButton()
		{
			this.CurrentShowLevel++;
			this.Refresh();
		}

		// Token: 0x06038E0D RID: 232973 RVA: 0x00E69680 File Offset: 0x00E67880
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

		// Token: 0x06038E0E RID: 232974 RVA: 0x00E69841 File Offset: 0x00E67A41
		private void OnClickedItemButton()
		{
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(this.CollectItemConfigId, true, null);
		}

		// Token: 0x06038E0F RID: 232975 RVA: 0x00E69855 File Offset: 0x00E67A55
		private void OnClickedCloseButton()
		{
			base.CloseMe(null);
		}

		// Token: 0x06038E10 RID: 232976 RVA: 0x00E69860 File Offset: 0x00E67A60
		private void JumpNextLevel()
		{
			int targetDragonPoolMaxLevelById = ModelBase<MingSuModel>.Instance.GetTargetDragonPoolMaxLevelById(this.PoolConfigId);
			int targetDragonPoolLevelById = ModelBase<MingSuModel>.Instance.GetTargetDragonPoolLevelById(this.PoolConfigId);
			this.CurrentShowLevel = Math.Min(targetDragonPoolMaxLevelById, targetDragonPoolLevelById + 1);
			this.Refresh();
		}

		// Token: 0x06038E11 RID: 232977 RVA: 0x00E698A4 File Offset: 0x00E67AA4
		private void Refresh()
		{
			this.RefreshShowLevel(this.CurrentShowLevel);
			this.RefreshLeftRightBtnState();
			this.RefreshProgressBar();
			this.RefreshReward();
			this.RefreshCostItem();
			this.RefreshConfirmButton();
			this.RefreshCountText();
			this.RefreshItemIcon();
		}

		// Token: 0x06038E12 RID: 232978 RVA: 0x00E698DC File Offset: 0x00E67ADC
		private void RefreshItemIcon()
		{
			UUITexture texture = base.GetTexture(14);
			UUITexture texture2 = base.GetTexture(15);
			DragonPool? dragonPoolConfigById = ConfigBase<CollectItemConfig>.Instance.GetDragonPoolConfigById(this.PoolConfigId);
			if (dragonPoolConfigById != null)
			{
				ItemInfo? config = ConfigBase<ItemConfig>.Instance.GetConfig(dragonPoolConfigById.Value.CoreId);
				if (config != null)
				{
					base.SetTextureShowUntilLoaded(config.Value.IconSmall, texture, null);
					base.SetTextureShowUntilLoaded(config.Value.IconSmall, texture2, null);
				}
			}
		}

		// Token: 0x06038E13 RID: 232979 RVA: 0x00E6996C File Offset: 0x00E67B6C
		private void RefreshShowLevel(int level)
		{
			UUIText text = base.GetText(3);
			int num = Math.Min(ModelBase<MingSuModel>.Instance.GetTargetDragonPoolMaxLevelById(this.PoolConfigId), level);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "PupuVillage_LevelText", new <>z__ReadOnlyArray<object>(new object[]
			{
				num - 1,
				num
			}));
			this.CurrentShowLevel = num;
			ModelBase<MingSuModel>.Instance.CurrentPreviewLevel = this.CurrentShowLevel;
		}

		// Token: 0x06038E14 RID: 232980 RVA: 0x00E699E0 File Offset: 0x00E67BE0
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

		// Token: 0x06038E15 RID: 232981 RVA: 0x00E69A64 File Offset: 0x00E67C64
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
				int num2 = (targetDragonPoolActiveById == 2) ? targetDragonPoolLevelNeedCoreById : instance.GetTargetDragonPoolCoreCountById(this.PoolConfigId);
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

		// Token: 0x06038E16 RID: 232982 RVA: 0x00E69BEC File Offset: 0x00E67DEC
		private void RefreshReward()
		{
			List<IRewardItemData> targetDragonPoolLevelRewardById = ModelBase<MingSuModel>.Instance.GetTargetDragonPoolLevelRewardById(this.PoolConfigId, this.CurrentShowLevel - 1);
			this.RewardItemScrollView.RefreshByData(targetDragonPoolLevelRewardById, null, false);
		}

		// Token: 0x06038E17 RID: 232983 RVA: 0x00E69C20 File Offset: 0x00E67E20
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
				text.SetUIActive(false);
			}
		}

		// Token: 0x06038E18 RID: 232984 RVA: 0x00E69CD0 File Offset: 0x00E67ED0
		private void RefreshConfirmButton()
		{
			UUIText text = base.GetText(8);
			bool flag = ModelBase<MingSuModel>.Instance.GetTargetDragonPoolActiveById(this.PoolConfigId) == 2;
			base.GetItem(9).SetUIActive(!flag);
			base.GetItem(13).SetUIActive(flag);
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

		// Token: 0x06038E19 RID: 232985 RVA: 0x00E69D64 File Offset: 0x00E67F64
		private void RefreshCountText()
		{
			int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(this.CollectItemConfigId, 0);
			base.GetText(10).SetText(itemCountByConfigId.ToString(), true);
		}

		// Token: 0x0402062B RID: 132651
		private MingSuDefine.EMingSuShowState CurrentShowState;

		// Token: 0x0402062C RID: 132652
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<CollectSmallItemGrid, IRewardItemData> RewardItemScrollView;

		// Token: 0x0402062D RID: 132653
		[Nullable(2)]
		private UUISprite ProgressBarSprite;

		// Token: 0x0402062E RID: 132654
		private bool IsInLevelUpDisplay;

		// Token: 0x0200B7F8 RID: 47096
		[NullableContext(0)]
		private static class EChildType
		{
			// Token: 0x04038E83 RID: 233091
			public const int LeftButton = 0;

			// Token: 0x04038E84 RID: 233092
			public const int RightButton = 1;

			// Token: 0x04038E85 RID: 233093
			public const int ProgressBarSprite = 2;

			// Token: 0x04038E86 RID: 233094
			public const int LevelText = 3;

			// Token: 0x04038E87 RID: 233095
			public const int NeedCountText = 4;

			// Token: 0x04038E88 RID: 233096
			public const int ContentItem = 5;

			// Token: 0x04038E89 RID: 233097
			public const int TipsText = 6;

			// Token: 0x04038E8A RID: 233098
			public const int ConfirmButton = 7;

			// Token: 0x04038E8B RID: 233099
			public const int ConfirmButtonText = 8;

			// Token: 0x04038E8C RID: 233100
			public const int ConfirmButtonItem = 9;

			// Token: 0x04038E8D RID: 233101
			public const int ItemCountText = 10;

			// Token: 0x04038E8E RID: 233102
			public const int ItemButton = 11;

			// Token: 0x04038E8F RID: 233103
			public const int CloseButton = 12;

			// Token: 0x04038E90 RID: 233104
			public const int AllDoneItem = 13;

			// Token: 0x04038E91 RID: 233105
			public const int TextureCostItemIcon = 14;

			// Token: 0x04038E92 RID: 233106
			public const int TextureCostItemIcon2 = 15;

			// Token: 0x04038E93 RID: 233107
			public const int TxtTitle = 16;
		}
	}
}
