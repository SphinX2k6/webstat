using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x020067D9 RID: 26585
	[NullableContext(1)]
	[Nullable(0)]
	public class DockyardWareHouseView : UiTickViewBase
	{
		// Token: 0x060424F4 RID: 271604 RVA: 0x01102354 File Offset: 0x01100554
		public DockyardWareHouseView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x060424F5 RID: 271605 RVA: 0x01102364 File Offset: 0x01100564
		protected unsafe override void OnRegisterComponent()
		{
			this.InitViewModel();
			int num = 6;
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
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060424F6 RID: 271606 RVA: 0x01102457 File Offset: 0x01100657
		private void InitViewModel()
		{
			this.Vm = (this.OpenParam as DockyardWareHouseViewModelBase);
			this.Vm.RegisterView(this);
		}

		// Token: 0x060424F7 RID: 271607 RVA: 0x01102478 File Offset: 0x01100678
		private UniTask InitFishingCurrencyItem()
		{
			DockyardWareHouseView.<InitFishingCurrencyItem>d__15 <InitFishingCurrencyItem>d__;
			<InitFishingCurrencyItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitFishingCurrencyItem>d__.<>4__this = this;
			<InitFishingCurrencyItem>d__.<>1__state = -1;
			<InitFishingCurrencyItem>d__.<>t__builder.Start<DockyardWareHouseView.<InitFishingCurrencyItem>d__15>(ref <InitFishingCurrencyItem>d__);
			return <InitFishingCurrencyItem>d__.<>t__builder.Task;
		}

		// Token: 0x060424F8 RID: 271608 RVA: 0x011024BC File Offset: 0x011006BC
		private UniTask InitCaption()
		{
			DockyardWareHouseView.<InitCaption>d__16 <InitCaption>d__;
			<InitCaption>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitCaption>d__.<>4__this = this;
			<InitCaption>d__.<>1__state = -1;
			<InitCaption>d__.<>t__builder.Start<DockyardWareHouseView.<InitCaption>d__16>(ref <InitCaption>d__);
			return <InitCaption>d__.<>t__builder.Task;
		}

		// Token: 0x060424F9 RID: 271609 RVA: 0x01102500 File Offset: 0x01100700
		private UniTask InitBackpackPanel()
		{
			DockyardWareHouseView.<InitBackpackPanel>d__17 <InitBackpackPanel>d__;
			<InitBackpackPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitBackpackPanel>d__.<>4__this = this;
			<InitBackpackPanel>d__.<>1__state = -1;
			<InitBackpackPanel>d__.<>t__builder.Start<DockyardWareHouseView.<InitBackpackPanel>d__17>(ref <InitBackpackPanel>d__);
			return <InitBackpackPanel>d__.<>t__builder.Task;
		}

		// Token: 0x060424FA RID: 271610 RVA: 0x01102544 File Offset: 0x01100744
		private UniTask InitLoopScroll()
		{
			DockyardWareHouseView.<InitLoopScroll>d__18 <InitLoopScroll>d__;
			<InitLoopScroll>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitLoopScroll>d__.<>4__this = this;
			<InitLoopScroll>d__.<>1__state = -1;
			<InitLoopScroll>d__.<>t__builder.Start<DockyardWareHouseView.<InitLoopScroll>d__18>(ref <InitLoopScroll>d__);
			return <InitLoopScroll>d__.<>t__builder.Task;
		}

		// Token: 0x060424FB RID: 271611 RVA: 0x01102588 File Offset: 0x01100788
		private UniTask InitTipsPanel()
		{
			DockyardWareHouseView.<InitTipsPanel>d__19 <InitTipsPanel>d__;
			<InitTipsPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitTipsPanel>d__.<>4__this = this;
			<InitTipsPanel>d__.<>1__state = -1;
			<InitTipsPanel>d__.<>t__builder.Start<DockyardWareHouseView.<InitTipsPanel>d__19>(ref <InitTipsPanel>d__);
			return <InitTipsPanel>d__.<>t__builder.Task;
		}

		// Token: 0x060424FC RID: 271612 RVA: 0x011025CB File Offset: 0x011007CB
		private IDockyardLeftTipsInterface GetLeftInfoPanel()
		{
			if (this.QteSkipPanel != null)
			{
				return this.QteSkipPanel;
			}
			return this.QuestPanel;
		}

		// Token: 0x060424FD RID: 271613 RVA: 0x011025E4 File Offset: 0x011007E4
		protected override UniTask OnBeforeStartAsync()
		{
			DockyardWareHouseView.<OnBeforeStartAsync>d__21 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<DockyardWareHouseView.<OnBeforeStartAsync>d__21>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060424FE RID: 271614 RVA: 0x01102627 File Offset: 0x01100827
		protected override void OnBeforeShow()
		{
			DockyardQuestInfoPanel questPanel = this.QuestPanel;
			if (questPanel == null)
			{
				return;
			}
			questPanel.Refresh();
		}

		// Token: 0x060424FF RID: 271615 RVA: 0x0110263C File Offset: 0x0110083C
		protected override void OnTick(float delta)
		{
			if (this.TipDirty)
			{
				if (this.LeftTipsType == 0)
				{
					DockyardItemBlockOriginalData itemBlockData = this.Vm.GetItemBlockData(this.CacheId);
					if (itemBlockData != null)
					{
						this.TipsPanel.Refresh(itemBlockData);
						this.TipsPanel.SetPanelVisible(true);
						this.GetLeftInfoPanel().SetPanelVisible(false);
					}
				}
				else if (this.LeftTipsType == 1)
				{
					this.TipsPanel.SetPanelVisible(false);
					this.GetLeftInfoPanel().SetPanelVisible(true);
				}
				this.TipDirty = false;
				this.CacheId = 0;
			}
		}

		// Token: 0x06042500 RID: 271616 RVA: 0x011026C3 File Offset: 0x011008C3
		public void ShowTipsPanel(int id)
		{
			this.TipDirty = true;
			this.LeftTipsType = 0;
			this.CacheId = id;
		}

		// Token: 0x06042501 RID: 271617 RVA: 0x011026DA File Offset: 0x011008DA
		public void HideTipsPanel()
		{
			this.TipDirty = true;
			this.LeftTipsType = 1;
		}

		// Token: 0x06042502 RID: 271618 RVA: 0x011026EA File Offset: 0x011008EA
		public UUIItem GetPanelParentItem()
		{
			return base.GetItem(4);
		}

		// Token: 0x06042503 RID: 271619 RVA: 0x011026F4 File Offset: 0x011008F4
		public void NotifyQuicklySellActive(bool isActive)
		{
			IDockyardLeftTipsInterface leftInfoPanel = this.GetLeftInfoPanel();
			IDockyardLeftTipsInterface dockyardLeftTipsInterface;
			if (this.LeftTipsType != 0)
			{
				dockyardLeftTipsInterface = leftInfoPanel;
			}
			else
			{
				IDockyardLeftTipsInterface tipsPanel = this.TipsPanel;
				dockyardLeftTipsInterface = tipsPanel;
			}
			IDockyardLeftTipsInterface dockyardLeftTipsInterface2 = dockyardLeftTipsInterface;
			if (isActive)
			{
				dockyardLeftTipsInterface2.SetPanelVisible(false);
				leftInfoPanel.LockState = true;
				this.TipsPanel.LockState = true;
				return;
			}
			leftInfoPanel.LockState = false;
			this.TipsPanel.LockState = false;
			dockyardLeftTipsInterface2.SetPanelVisible(true);
		}

		// Token: 0x06042504 RID: 271620 RVA: 0x01102754 File Offset: 0x01100954
		public UniTask CreateQteSkipPanel()
		{
			DockyardWareHouseView.<CreateQteSkipPanel>d__28 <CreateQteSkipPanel>d__;
			<CreateQteSkipPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateQteSkipPanel>d__.<>4__this = this;
			<CreateQteSkipPanel>d__.<>1__state = -1;
			<CreateQteSkipPanel>d__.<>t__builder.Start<DockyardWareHouseView.<CreateQteSkipPanel>d__28>(ref <CreateQteSkipPanel>d__);
			return <CreateQteSkipPanel>d__.<>t__builder.Task;
		}

		// Token: 0x06042505 RID: 271621 RVA: 0x01102798 File Offset: 0x01100998
		public UniTask CreateQuestPanel(bool withExitButton)
		{
			DockyardWareHouseView.<CreateQuestPanel>d__29 <CreateQuestPanel>d__;
			<CreateQuestPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateQuestPanel>d__.<>4__this = this;
			<CreateQuestPanel>d__.withExitButton = withExitButton;
			<CreateQuestPanel>d__.<>1__state = -1;
			<CreateQuestPanel>d__.<>t__builder.Start<DockyardWareHouseView.<CreateQuestPanel>d__29>(ref <CreateQuestPanel>d__);
			return <CreateQuestPanel>d__.<>t__builder.Task;
		}

		// Token: 0x06042506 RID: 271622 RVA: 0x011027E3 File Offset: 0x011009E3
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			return this.ListPanel.GetGuideUiItemAndUiItemForShowEx(configParams);
		}

		// Token: 0x06042507 RID: 271623 RVA: 0x011027F1 File Offset: 0x011009F1
		[CompilerGenerated]
		private void <CreateQteSkipPanel>g__continueFunc|28_0()
		{
			base.CloseMe(null);
		}

		// Token: 0x06042508 RID: 271624 RVA: 0x011027FA File Offset: 0x011009FA
		[CompilerGenerated]
		private void <CreateQteSkipPanel>g__exitFunc|28_1()
		{
			ControllerBase<FishingController>.Instance.ShowConfirmBoxAndRequestFishingExit(delegate(bool success)
			{
				if (success)
				{
					base.CloseMe(null);
				}
			});
		}

		// Token: 0x0604250A RID: 271626 RVA: 0x0110281E File Offset: 0x01100A1E
		[CompilerGenerated]
		private void <CreateQuestPanel>g__exitFunc|29_0()
		{
			ControllerBase<FishingController>.Instance.ShowConfirmBoxAndRequestFishingExit(delegate(bool success)
			{
				if (success)
				{
					base.CloseMe(null);
				}
			});
		}

		// Token: 0x04024E96 RID: 151190
		private PopupCaptionItem CaptionItem;

		// Token: 0x04024E97 RID: 151191
		private DockyardBackpackPanel BackpackPanel;

		// Token: 0x04024E98 RID: 151192
		private DockyardItemListPanel ListPanel;

		// Token: 0x04024E99 RID: 151193
		private DockyardTipsPanel TipsPanel;

		// Token: 0x04024E9A RID: 151194
		[Nullable(2)]
		private DockyardQteSkipPanel QteSkipPanel;

		// Token: 0x04024E9B RID: 151195
		[Nullable(2)]
		private DockyardQuestInfoPanel QuestPanel;

		// Token: 0x04024E9C RID: 151196
		private DockyardWareHouseViewModelBase Vm;

		// Token: 0x04024E9D RID: 151197
		private int LeftTipsType = 1;

		// Token: 0x04024E9E RID: 151198
		private bool TipDirty;

		// Token: 0x04024E9F RID: 151199
		private int CacheId;

		// Token: 0x0200C824 RID: 51236
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403D970 RID: 252272
			public const int CaptionItem = 0;

			// Token: 0x0403D971 RID: 252273
			public const int BackpackItem = 1;

			// Token: 0x0403D972 RID: 252274
			public const int ListItem = 2;

			// Token: 0x0403D973 RID: 252275
			public const int TipsItem = 3;

			// Token: 0x0403D974 RID: 252276
			public const int ParentItem = 4;

			// Token: 0x0403D975 RID: 252277
			public const int PanelRootItem = 5;
		}

		// Token: 0x0200C825 RID: 51237
		[NullableContext(0)]
		private class ELeftTipsType
		{
			// Token: 0x0403D976 RID: 252278
			public const int ItemTips = 0;

			// Token: 0x0403D977 RID: 252279
			public const int InfoTips = 1;
		}
	}
}
