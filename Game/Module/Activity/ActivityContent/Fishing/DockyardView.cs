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
	// Token: 0x020067BD RID: 26557
	[NullableContext(1)]
	[Nullable(0)]
	public class DockyardView : UiTickViewBase, IDockyardViewInterface
	{
		// Token: 0x0604240F RID: 271375 RVA: 0x010FEFAF File Offset: 0x010FD1AF
		public DockyardView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06042410 RID: 271376 RVA: 0x010FEFC0 File Offset: 0x010FD1C0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
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
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06042411 RID: 271377 RVA: 0x010FF0CE File Offset: 0x010FD2CE
		private void InitViewModel()
		{
			this.Vm = (this.OpenParam as DockyardViewModel);
			this.Vm.RegisterView(this);
		}

		// Token: 0x06042412 RID: 271378 RVA: 0x010FF0F0 File Offset: 0x010FD2F0
		private UniTask InitFishingCurrencyItem()
		{
			DockyardView.<InitFishingCurrencyItem>d__15 <InitFishingCurrencyItem>d__;
			<InitFishingCurrencyItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitFishingCurrencyItem>d__.<>4__this = this;
			<InitFishingCurrencyItem>d__.<>1__state = -1;
			<InitFishingCurrencyItem>d__.<>t__builder.Start<DockyardView.<InitFishingCurrencyItem>d__15>(ref <InitFishingCurrencyItem>d__);
			return <InitFishingCurrencyItem>d__.<>t__builder.Task;
		}

		// Token: 0x06042413 RID: 271379 RVA: 0x010FF134 File Offset: 0x010FD334
		private UniTask InitCaption()
		{
			DockyardView.<InitCaption>d__16 <InitCaption>d__;
			<InitCaption>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitCaption>d__.<>4__this = this;
			<InitCaption>d__.<>1__state = -1;
			<InitCaption>d__.<>t__builder.Start<DockyardView.<InitCaption>d__16>(ref <InitCaption>d__);
			return <InitCaption>d__.<>t__builder.Task;
		}

		// Token: 0x06042414 RID: 271380 RVA: 0x010FF178 File Offset: 0x010FD378
		private UniTask InitBackpackPanel()
		{
			DockyardView.<InitBackpackPanel>d__17 <InitBackpackPanel>d__;
			<InitBackpackPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitBackpackPanel>d__.<>4__this = this;
			<InitBackpackPanel>d__.<>1__state = -1;
			<InitBackpackPanel>d__.<>t__builder.Start<DockyardView.<InitBackpackPanel>d__17>(ref <InitBackpackPanel>d__);
			return <InitBackpackPanel>d__.<>t__builder.Task;
		}

		// Token: 0x06042415 RID: 271381 RVA: 0x010FF1BC File Offset: 0x010FD3BC
		private UniTask InitStatePanel()
		{
			DockyardView.<InitStatePanel>d__18 <InitStatePanel>d__;
			<InitStatePanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitStatePanel>d__.<>4__this = this;
			<InitStatePanel>d__.<>1__state = -1;
			<InitStatePanel>d__.<>t__builder.Start<DockyardView.<InitStatePanel>d__18>(ref <InitStatePanel>d__);
			return <InitStatePanel>d__.<>t__builder.Task;
		}

		// Token: 0x06042416 RID: 271382 RVA: 0x010FF200 File Offset: 0x010FD400
		private UniTask InitTipsPanel()
		{
			DockyardView.<InitTipsPanel>d__19 <InitTipsPanel>d__;
			<InitTipsPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitTipsPanel>d__.<>4__this = this;
			<InitTipsPanel>d__.<>1__state = -1;
			<InitTipsPanel>d__.<>t__builder.Start<DockyardView.<InitTipsPanel>d__19>(ref <InitTipsPanel>d__);
			return <InitTipsPanel>d__.<>t__builder.Task;
		}

		// Token: 0x06042417 RID: 271383 RVA: 0x010FF244 File Offset: 0x010FD444
		private UniTask InitLoopScroll()
		{
			DockyardView.<InitLoopScroll>d__20 <InitLoopScroll>d__;
			<InitLoopScroll>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitLoopScroll>d__.<>4__this = this;
			<InitLoopScroll>d__.<>1__state = -1;
			<InitLoopScroll>d__.<>t__builder.Start<DockyardView.<InitLoopScroll>d__20>(ref <InitLoopScroll>d__);
			return <InitLoopScroll>d__.<>t__builder.Task;
		}

		// Token: 0x06042418 RID: 271384 RVA: 0x010FF288 File Offset: 0x010FD488
		private UniTask InitQuestPanel()
		{
			DockyardView.<InitQuestPanel>d__21 <InitQuestPanel>d__;
			<InitQuestPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitQuestPanel>d__.<>4__this = this;
			<InitQuestPanel>d__.<>1__state = -1;
			<InitQuestPanel>d__.<>t__builder.Start<DockyardView.<InitQuestPanel>d__21>(ref <InitQuestPanel>d__);
			return <InitQuestPanel>d__.<>t__builder.Task;
		}

		// Token: 0x06042419 RID: 271385 RVA: 0x010FF2CC File Offset: 0x010FD4CC
		protected override UniTask OnBeforeStartAsync()
		{
			DockyardView.<OnBeforeStartAsync>d__22 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<DockyardView.<OnBeforeStartAsync>d__22>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0604241A RID: 271386 RVA: 0x010FF310 File Offset: 0x010FD510
		protected override UniTask OnBeforeShowAsyncImplementImplement()
		{
			DockyardView.<OnBeforeShowAsyncImplementImplement>d__23 <OnBeforeShowAsyncImplementImplement>d__;
			<OnBeforeShowAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeShowAsyncImplementImplement>d__.<>4__this = this;
			<OnBeforeShowAsyncImplementImplement>d__.<>1__state = -1;
			<OnBeforeShowAsyncImplementImplement>d__.<>t__builder.Start<DockyardView.<OnBeforeShowAsyncImplementImplement>d__23>(ref <OnBeforeShowAsyncImplementImplement>d__);
			return <OnBeforeShowAsyncImplementImplement>d__.<>t__builder.Task;
		}

		// Token: 0x0604241B RID: 271387 RVA: 0x010FF353 File Offset: 0x010FD553
		protected override void OnBeforeShow()
		{
			this.QuestPanel.Refresh();
		}

		// Token: 0x0604241C RID: 271388 RVA: 0x010FF360 File Offset: 0x010FD560
		protected override void OnTick(float delta)
		{
			if (this.TipDirty)
			{
				if (this.LeftTipsType == DockyardView.ELeftTipsType.ItemTips)
				{
					DockyardItemBlockOriginalData itemBlockData = this.Vm.GetItemBlockData(this.CacheId);
					this.TipsPanel.Refresh(itemBlockData);
					this.TipsPanel.SetPanelVisible(true);
					this.QuestPanel.SetPanelVisible(false);
				}
				else if (this.LeftTipsType == DockyardView.ELeftTipsType.InfoTips)
				{
					this.TipsPanel.SetPanelVisible(false);
					this.QuestPanel.SetPanelVisible(true);
				}
				this.TipDirty = false;
				this.CacheId = 0;
			}
		}

		// Token: 0x0604241D RID: 271389 RVA: 0x010FF3E4 File Offset: 0x010FD5E4
		public void ShowTipsPanel(int id)
		{
			this.TipDirty = true;
			this.LeftTipsType = DockyardView.ELeftTipsType.ItemTips;
			this.CacheId = id;
		}

		// Token: 0x0604241E RID: 271390 RVA: 0x010FF3FB File Offset: 0x010FD5FB
		public void HideTipsPanel()
		{
			this.TipDirty = true;
			this.LeftTipsType = DockyardView.ELeftTipsType.InfoTips;
		}

		// Token: 0x0604241F RID: 271391 RVA: 0x010FF40B File Offset: 0x010FD60B
		public void SetTrawlState(bool state)
		{
			this.StatePanel.SetActive(!state);
			this.ListPanel.SetActive(state);
		}

		// Token: 0x06042420 RID: 271392 RVA: 0x010FF428 File Offset: 0x010FD628
		public UUIItem GetQuicklySellPanelParentItem()
		{
			return base.GetItem(5);
		}

		// Token: 0x06042421 RID: 271393 RVA: 0x010FF434 File Offset: 0x010FD634
		public void NotifyQuicklySellActive(bool isActive)
		{
			IDockyardLeftTipsInterface dockyardLeftTipsInterface2;
			if (this.LeftTipsType != DockyardView.ELeftTipsType.ItemTips)
			{
				IDockyardLeftTipsInterface dockyardLeftTipsInterface = this.QuestPanel;
				dockyardLeftTipsInterface2 = dockyardLeftTipsInterface;
			}
			else
			{
				IDockyardLeftTipsInterface dockyardLeftTipsInterface = this.TipsPanel;
				dockyardLeftTipsInterface2 = dockyardLeftTipsInterface;
			}
			IDockyardLeftTipsInterface dockyardLeftTipsInterface3 = dockyardLeftTipsInterface2;
			if (isActive)
			{
				dockyardLeftTipsInterface3.SetPanelVisible(false);
				this.QuestPanel.LockState = true;
				this.TipsPanel.LockState = true;
				return;
			}
			this.QuestPanel.LockState = false;
			this.TipsPanel.LockState = false;
			dockyardLeftTipsInterface3.SetPanelVisible(true);
		}

		// Token: 0x04024E58 RID: 151128
		private PopupCaptionItem CaptionItem;

		// Token: 0x04024E59 RID: 151129
		private DockyardBackpackPanel BackpackPanel;

		// Token: 0x04024E5A RID: 151130
		private DockyardStatePanel StatePanel;

		// Token: 0x04024E5B RID: 151131
		private DockyardTipsPanel TipsPanel;

		// Token: 0x04024E5C RID: 151132
		private DockyardItemListPanel ListPanel;

		// Token: 0x04024E5D RID: 151133
		[Nullable(2)]
		private DockyardQuestInfoPanel QuestPanel;

		// Token: 0x04024E5E RID: 151134
		private DockyardViewModel Vm;

		// Token: 0x04024E5F RID: 151135
		private DockyardView.ELeftTipsType LeftTipsType = DockyardView.ELeftTipsType.InfoTips;

		// Token: 0x04024E60 RID: 151136
		private bool TipDirty;

		// Token: 0x04024E61 RID: 151137
		private int CacheId;

		// Token: 0x0200C7F5 RID: 51189
		[NullableContext(0)]
		private enum ELeftTipsType
		{
			// Token: 0x0403D8B7 RID: 252087
			ItemTips,
			// Token: 0x0403D8B8 RID: 252088
			InfoTips
		}

		// Token: 0x0200C7F6 RID: 51190
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403D8B9 RID: 252089
			public const int CaptionItem = 0;

			// Token: 0x0403D8BA RID: 252090
			public const int BackpackItem = 1;

			// Token: 0x0403D8BB RID: 252091
			public const int TipsItem = 2;

			// Token: 0x0403D8BC RID: 252092
			public const int StateItem = 3;

			// Token: 0x0403D8BD RID: 252093
			public const int ListItem = 4;

			// Token: 0x0403D8BE RID: 252094
			public const int SellParentItem = 5;

			// Token: 0x0403D8BF RID: 252095
			public const int PanelRootItem = 6;
		}
	}
}
