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
	// Token: 0x02005741 RID: 22337
	[NullableContext(1)]
	[Nullable(0)]
	public class LaHaiLuoCollectView : CollectItemViewBase
	{
		// Token: 0x06038DA4 RID: 232868 RVA: 0x00E66EC6 File Offset: 0x00E650C6
		public LaHaiLuoCollectView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06038DA5 RID: 232869 RVA: 0x00E66ED0 File Offset: 0x00E650D0
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
				new ValueTuple<int, Type>(16, typeof(UUIText)),
				new ValueTuple<int, Type>(17, typeof(UUISprite)),
				new ValueTuple<int, Type>(18, typeof(UUISprite)),
				new ValueTuple<int, Type>(19, typeof(UUIItem)),
				new ValueTuple<int, Type>(20, typeof(UUIItem))
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

		// Token: 0x06038DA6 RID: 232870 RVA: 0x00E67148 File Offset: 0x00E65348
		protected override void OnBegined()
		{
			UUIItem item = base.GetItem(5);
			this.RewardItemScrollView = new GenericLayout<CollectSmallItemGrid, IRewardItemData>((UUILayoutBase)item.GetOwner().GetComponentByClass(UUILayoutBase.StaticClass()), new Func<CollectSmallItemGrid>(this.OnCreateRewardItem), null, false, true);
			this.ProgressBarSprite = base.GetSprite(2);
			this.MingSuMod = ModelBase<MingSuModel>.Instance;
			UUIText text = base.GetText(16);
			string textStringId;
			if (LaHaiLuoCollectView.TitleMap.TryGetValue(this.PoolConfigId, out textStringId))
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, textStringId, Array.Empty<object>());
			}
			base.GetItem(19).SetUIActive(this.PoolConfigId == 6);
			base.GetItem(20).SetUIActive(this.PoolConfigId == 7);
			string path = "";
			string path2 = "";
			if (this.PoolConfigId == 6)
			{
				path = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("ShengXiaIcon");
				path2 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("ShengXiaIcon2");
			}
			else if (this.PoolConfigId == 7)
			{
				path = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("RiLingIcon");
				path2 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("RiLingIcon2");
			}
			this.SetSpriteByPath(path, base.GetSprite(17), false, null, null);
			this.SetSpriteByPath(path2, base.GetSprite(18), false, null, null);
			this.Refresh();
		}

		// Token: 0x06038DA7 RID: 232871 RVA: 0x00E672A3 File Offset: 0x00E654A3
		protected override void OnEnded()
		{
			this.RewardItemScrollView = null;
			this.ProgressBarSprite = null;
			this.MingSuMod = null;
			Singleton<EventSystem>.Instance.Emit(EEventName.OnExitNpcInteract);
		}

		// Token: 0x06038DA8 RID: 232872 RVA: 0x00E672CA File Offset: 0x00E654CA
		protected override void OnUpdateDragonPoolView()
		{
			this.JumpNextLevel();
		}

		// Token: 0x06038DA9 RID: 232873 RVA: 0x00E672D2 File Offset: 0x00E654D2
		protected override void OnSubmitItemLevelUp()
		{
			this.SetActive(false);
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.HangPlotViewHud, true);
		}

		// Token: 0x06038DAA RID: 232874 RVA: 0x00E672EC File Offset: 0x00E654EC
		protected override void OnSubmitItemLevelMax()
		{
			this.SetActive(false);
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.HangPlotViewHud, true);
		}

		// Token: 0x06038DAB RID: 232875 RVA: 0x00E67306 File Offset: 0x00E65506
		protected override void OnLevelUpSequenceFinished()
		{
			this.SetActive(true);
			this.IsInLevelUpDisplay = false;
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.HangPlotViewHud, false);
		}

		// Token: 0x06038DAC RID: 232876 RVA: 0x00E67327 File Offset: 0x00E65527
		protected override void OnLevelMaxSequenceFinished()
		{
			base.CloseMe(null);
		}

		// Token: 0x06038DAD RID: 232877 RVA: 0x00E67330 File Offset: 0x00E65530
		protected override void OnSubmitItemLevelUpSequencePlayFail()
		{
			Singleton<Log>.Instance.Info(ELogModule.NPC, ELogAuthor.BB, "[CollectionItemDisplay]当交付等级提升Sequence播放失败时，重新显示提交道具界面", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.IsInLevelUpDisplay = false;
			this.SetActive(true);
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.HangPlotViewHud, false);
		}

		// Token: 0x06038DAE RID: 232878 RVA: 0x00E6737B File Offset: 0x00E6557B
		protected override void OnCollectItemCountChanged(int count)
		{
			this.RefreshCountText();
		}

		// Token: 0x06038DAF RID: 232879 RVA: 0x00E67384 File Offset: 0x00E65584
		protected override void OnCloseRewardView()
		{
			Singleton<Log>.Instance.Info(ELogModule.NPC, ELogAuthor.BB, "[CollectionItemDisplay]当关闭了交付奖励结算界面时，重新显示提交道具界面", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.IsInLevelUpDisplay = false;
			this.SetActive(true);
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.HangPlotViewHud, false);
		}

		// Token: 0x06038DB0 RID: 232880 RVA: 0x00E673CF File Offset: 0x00E655CF
		private CollectSmallItemGrid OnCreateRewardItem()
		{
			CollectSmallItemGrid collectSmallItemGrid = new CollectSmallItemGrid();
			collectSmallItemGrid.BindOnExtendToggleRelease(new Action<MediumItemGridExtendCallback>(this.OnExtendToggleRelease));
			collectSmallItemGrid.BindOnCanExecuteChange((object _, bool __, EToggleState ___) => false);
			return collectSmallItemGrid;
		}

		// Token: 0x06038DB1 RID: 232881 RVA: 0x00E67410 File Offset: 0x00E65610
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

		// Token: 0x06038DB2 RID: 232882 RVA: 0x00E6745C File Offset: 0x00E6565C
		private void OnClickedLeftButton()
		{
			this.CurrentShowLevel--;
			this.Refresh();
		}

		// Token: 0x06038DB3 RID: 232883 RVA: 0x00E67472 File Offset: 0x00E65672
		private void OnClickedRightButton()
		{
			this.CurrentShowLevel++;
			this.Refresh();
		}

		// Token: 0x06038DB4 RID: 232884 RVA: 0x00E67488 File Offset: 0x00E65688
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
			int targetDragonPoolLevelById = this.MingSuMod.GetTargetDragonPoolLevelById(this.PoolConfigId);
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.NPC;
			ELogAuthor author2 = ELogAuthor.BB;
			string message2 = "[CollectionItemDisplay]当点击交付按钮时";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CurrentShowLevel", this.CurrentShowLevel);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("dragonPoolLevel", targetDragonPoolLevelById);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("PoolConfigId", this.PoolConfigId);
			instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			if (this.CurrentShowLevel != targetDragonPoolLevelById + 1)
			{
				this.JumpNextLevel();
				return;
			}
			if (this.MingSuMod.CheckUp(this.PoolConfigId))
			{
				this.MingSuMod.MingSuLastLevel = this.MingSuMod.GetTargetDragonPoolLevelById(this.PoolConfigId);
				if (this.MingSuMod.CanLevelUp(this.PoolConfigId))
				{
					Singleton<Log>.Instance.Info(ELogModule.NPC, ELogAuthor.BB, "[CollectionItemDisplay]提交声匣之后，等级提升会播放等级提升Sequence，IsInLevelUpDisplay设置为true", default(ReadOnlySpan<ValueTuple<string, object>>));
					this.IsInLevelUpDisplay = true;
				}
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.NPC;
				ELogAuthor author3 = ELogAuthor.BB;
				string message3 = "[CollectionItemDisplay]提交声匣之后，隐藏界面并发送给服务端";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("PoolConfigId", this.PoolConfigId);
				instance3.Info(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				MingSuController.SendHandInMingSuRequest(this.PoolConfigId);
				return;
			}
			Singleton<Log>.Instance.Info(ELogModule.NPC, ELogAuthor.BB, "[CollectionItemDisplay]当点击交付按钮时,当前经验无法升级，不会播放提交道具表现", default(ReadOnlySpan<ValueTuple<string, object>>));
			Singleton<EventSystem>.Instance.Emit(EEventName.OnSubmitItemFail);
		}

		// Token: 0x06038DB5 RID: 232885 RVA: 0x00E6765C File Offset: 0x00E6585C
		private void OnClickedItemButton()
		{
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(this.CollectItemConfigId, true, null);
		}

		// Token: 0x06038DB6 RID: 232886 RVA: 0x00E67670 File Offset: 0x00E65870
		private void OnClickedCloseButton()
		{
			base.CloseMe(null);
		}

		// Token: 0x06038DB7 RID: 232887 RVA: 0x00E6767C File Offset: 0x00E6587C
		private void JumpNextLevel()
		{
			int targetDragonPoolMaxLevelById = this.MingSuMod.GetTargetDragonPoolMaxLevelById(this.PoolConfigId);
			int targetDragonPoolLevelById = this.MingSuMod.GetTargetDragonPoolLevelById(this.PoolConfigId);
			this.CurrentShowLevel = Math.Min(targetDragonPoolMaxLevelById, targetDragonPoolLevelById + 1);
			this.Refresh();
		}

		// Token: 0x06038DB8 RID: 232888 RVA: 0x00E676C2 File Offset: 0x00E658C2
		private void Refresh()
		{
			this.RefreshShowLevel(this.CurrentShowLevel);
			this.RefreshLeftRightBtnState();
			this.RefreshProgressBar();
			this.RefreshReward();
			this.RefreshTipsText();
			this.RefreshConfirmButton();
			this.RefreshCountText();
			this.RefreshItemIcon();
		}

		// Token: 0x06038DB9 RID: 232889 RVA: 0x00E676FC File Offset: 0x00E658FC
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

		// Token: 0x06038DBA RID: 232890 RVA: 0x00E6778C File Offset: 0x00E6598C
		private void RefreshShowLevel(int level)
		{
			UUIText text = base.GetText(3);
			int num = Math.Min(this.MingSuMod.GetTargetDragonPoolMaxLevelById(this.PoolConfigId), level);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "PupuVillage_LevelText", new <>z__ReadOnlyArray<object>(new object[]
			{
				num - 1,
				num
			}));
			this.CurrentShowLevel = num;
			ModelBase<MingSuModel>.Instance.CurrentPreviewLevel = this.CurrentShowLevel;
		}

		// Token: 0x06038DBB RID: 232891 RVA: 0x00E67800 File Offset: 0x00E65A00
		private void RefreshLeftRightBtnState()
		{
			UUIItem uuiitem = base.GetButton(0).RootUIComp.Get();
			UUIItem uuiitem2 = base.GetButton(1).RootUIComp.Get();
			uuiitem.SetUIActive(this.CurrentShowLevel != 1);
			uuiitem2.SetUIActive(this.CurrentShowLevel != this.MingSuMod.GetTargetDragonPoolMaxLevelById(this.PoolConfigId));
		}

		// Token: 0x06038DBC RID: 232892 RVA: 0x00E6786C File Offset: 0x00E65A6C
		private void RefreshProgressBar()
		{
			int targetDragonPoolLevelById = this.MingSuMod.GetTargetDragonPoolLevelById(this.PoolConfigId);
			int targetDragonPoolMaxLevelById = this.MingSuMod.GetTargetDragonPoolMaxLevelById(this.PoolConfigId);
			UUIText text = base.GetText(4);
			int targetDragonPoolActiveById = this.MingSuMod.GetTargetDragonPoolActiveById(this.PoolConfigId);
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
				int targetDragonPoolLevelNeedCoreById = this.MingSuMod.GetTargetDragonPoolLevelNeedCoreById(this.PoolConfigId, num);
				int num2 = (targetDragonPoolActiveById == 2) ? targetDragonPoolLevelNeedCoreById : this.MingSuMod.GetTargetDragonPoolCoreCountById(this.PoolConfigId);
				float fillAmount = (float)num2 / (float)targetDragonPoolLevelNeedCoreById;
				this.ProgressBarSprite.SetFillAmount(fillAmount);
				text.SetText(num2.ToString() + "/" + targetDragonPoolLevelNeedCoreById.ToString(), true);
				return;
			}
			if (this.CurrentShowLevel <= targetDragonPoolLevelById)
			{
				this.CurrentShowState = MingSuDefine.EMingSuShowState.Done;
				int targetDragonPoolLevelNeedCoreById2 = this.MingSuMod.GetTargetDragonPoolLevelNeedCoreById(this.PoolConfigId, this.CurrentShowLevel - 1);
				text.SetText(targetDragonPoolLevelNeedCoreById2.ToString() + "/" + targetDragonPoolLevelNeedCoreById2.ToString(), true);
				this.ProgressBarSprite.SetFillAmount(1f);
				return;
			}
			if (this.CurrentShowLevel > targetDragonPoolLevelById + 1)
			{
				this.CurrentShowState = MingSuDefine.EMingSuShowState.NoStart;
				text.SetText("0/" + this.MingSuMod.GetTargetDragonPoolLevelNeedCoreById(this.PoolConfigId, this.CurrentShowLevel - 1).ToString(), true);
				this.ProgressBarSprite.SetFillAmount(0f);
			}
		}

		// Token: 0x06038DBD RID: 232893 RVA: 0x00E67A10 File Offset: 0x00E65C10
		private void RefreshReward()
		{
			List<IRewardItemData> targetDragonPoolLevelRewardById = this.MingSuMod.GetTargetDragonPoolLevelRewardById(this.PoolConfigId, this.CurrentShowLevel - 1);
			this.RewardItemScrollView.RefreshByData(targetDragonPoolLevelRewardById, null, false);
		}

		// Token: 0x06038DBE RID: 232894 RVA: 0x00E67A48 File Offset: 0x00E65C48
		private void RefreshTipsText()
		{
			UUIText text = base.GetText(6);
			if (this.MingSuMod.GetTargetDragonPoolActiveById(this.PoolConfigId) == 2)
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

		// Token: 0x06038DBF RID: 232895 RVA: 0x00E67AFC File Offset: 0x00E65CFC
		private void RefreshConfirmButton()
		{
			UUIText text = base.GetText(8);
			bool flag = this.MingSuMod.GetTargetDragonPoolActiveById(this.PoolConfigId) == 2;
			base.GetItem(9).SetUIActive(!flag);
			base.GetItem(13).SetUIActive(flag);
			if (!flag)
			{
				int targetDragonPoolLevelById = this.MingSuMod.GetTargetDragonPoolLevelById(this.PoolConfigId);
				if (this.CurrentShowLevel == targetDragonPoolLevelById + 1)
				{
					Singleton<LguiUtil>.Instance.SetLocalText(text, "MingSuTi_Text3", Array.Empty<object>());
					return;
				}
				Singleton<LguiUtil>.Instance.SetLocalText(text, "MingSuTi_Text4", Array.Empty<object>());
			}
		}

		// Token: 0x06038DC0 RID: 232896 RVA: 0x00E67B90 File Offset: 0x00E65D90
		private void RefreshCountText()
		{
			int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(this.CollectItemConfigId, 0);
			base.GetText(10).SetText(itemCountByConfigId.ToString(), true);
		}

		// Token: 0x0402060A RID: 132618
		private MingSuDefine.EMingSuShowState CurrentShowState;

		// Token: 0x0402060B RID: 132619
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<CollectSmallItemGrid, IRewardItemData> RewardItemScrollView;

		// Token: 0x0402060C RID: 132620
		[Nullable(2)]
		private UUISprite ProgressBarSprite;

		// Token: 0x0402060D RID: 132621
		private bool IsInLevelUpDisplay;

		// Token: 0x0402060E RID: 132622
		[Nullable(2)]
		private MingSuModel MingSuMod;

		// Token: 0x0402060F RID: 132623
		[StaticVariableRuleIgnore]
		private static readonly Dictionary<int, string> TitleMap = new Dictionary<int, string>
		{
			{
				6,
				"NpcSystemBackground_10132_Title"
			},
			{
				7,
				"NpcSystemBackground_10133_Title"
			}
		};

		// Token: 0x0200B7F3 RID: 47091
		[NullableContext(0)]
		private static class EChildType
		{
			// Token: 0x04038E59 RID: 233049
			public const int LeftButton = 0;

			// Token: 0x04038E5A RID: 233050
			public const int RightButton = 1;

			// Token: 0x04038E5B RID: 233051
			public const int ProgressBarSprite = 2;

			// Token: 0x04038E5C RID: 233052
			public const int LevelText = 3;

			// Token: 0x04038E5D RID: 233053
			public const int NeedCountText = 4;

			// Token: 0x04038E5E RID: 233054
			public const int ContentItem = 5;

			// Token: 0x04038E5F RID: 233055
			public const int TipsText = 6;

			// Token: 0x04038E60 RID: 233056
			public const int ConfirmButton = 7;

			// Token: 0x04038E61 RID: 233057
			public const int ConfirmButtonText = 8;

			// Token: 0x04038E62 RID: 233058
			public const int ConfirmButtonItem = 9;

			// Token: 0x04038E63 RID: 233059
			public const int ItemCountText = 10;

			// Token: 0x04038E64 RID: 233060
			public const int ItemButton = 11;

			// Token: 0x04038E65 RID: 233061
			public const int CloseButton = 12;

			// Token: 0x04038E66 RID: 233062
			public const int AllDoneItem = 13;

			// Token: 0x04038E67 RID: 233063
			public const int TextureCostItemIcon = 14;

			// Token: 0x04038E68 RID: 233064
			public const int TextureCostItemIcon2 = 15;

			// Token: 0x04038E69 RID: 233065
			public const int TxtTitle = 16;

			// Token: 0x04038E6A RID: 233066
			public const int SprTitle = 17;

			// Token: 0x04038E6B RID: 233067
			public const int SprXXIcon = 18;

			// Token: 0x04038E6C RID: 233068
			public const int ItemShengXiaBG = 19;

			// Token: 0x04038E6D RID: 233069
			public const int ItemRiLingBg = 20;
		}
	}
}
