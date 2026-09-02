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
	// Token: 0x020067C1 RID: 26561
	[NullableContext(1)]
	[Nullable(0)]
	public class DockyardSellTabView : UiTabViewBase, IDockyardViewInterface
	{
		// Token: 0x0604243C RID: 271420 RVA: 0x010FF914 File Offset: 0x010FDB14
		protected unsafe override void OnRegisterComponent()
		{
			this.InitViewModel();
			int num = 4;
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
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0604243D RID: 271421 RVA: 0x010FF9C5 File Offset: 0x010FDBC5
		private void InitViewModel()
		{
			this.Vm = (this.ExtraParams as DockyardShopTabViewModel);
			this.Vm.RegisterView(this);
		}

		// Token: 0x0604243E RID: 271422 RVA: 0x010FF9E4 File Offset: 0x010FDBE4
		private UniTask InitBackpackPanel()
		{
			DockyardSellTabView.<InitBackpackPanel>d__7 <InitBackpackPanel>d__;
			<InitBackpackPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitBackpackPanel>d__.<>4__this = this;
			<InitBackpackPanel>d__.<>1__state = -1;
			<InitBackpackPanel>d__.<>t__builder.Start<DockyardSellTabView.<InitBackpackPanel>d__7>(ref <InitBackpackPanel>d__);
			return <InitBackpackPanel>d__.<>t__builder.Task;
		}

		// Token: 0x0604243F RID: 271423 RVA: 0x010FFA28 File Offset: 0x010FDC28
		private UniTask InitLoopScroll()
		{
			DockyardSellTabView.<InitLoopScroll>d__8 <InitLoopScroll>d__;
			<InitLoopScroll>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitLoopScroll>d__.<>4__this = this;
			<InitLoopScroll>d__.<>1__state = -1;
			<InitLoopScroll>d__.<>t__builder.Start<DockyardSellTabView.<InitLoopScroll>d__8>(ref <InitLoopScroll>d__);
			return <InitLoopScroll>d__.<>t__builder.Task;
		}

		// Token: 0x06042440 RID: 271424 RVA: 0x010FFA6C File Offset: 0x010FDC6C
		private UniTask InitTipsPanel()
		{
			DockyardSellTabView.<InitTipsPanel>d__9 <InitTipsPanel>d__;
			<InitTipsPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitTipsPanel>d__.<>4__this = this;
			<InitTipsPanel>d__.<>1__state = -1;
			<InitTipsPanel>d__.<>t__builder.Start<DockyardSellTabView.<InitTipsPanel>d__9>(ref <InitTipsPanel>d__);
			return <InitTipsPanel>d__.<>t__builder.Task;
		}

		// Token: 0x06042441 RID: 271425 RVA: 0x010FFAB0 File Offset: 0x010FDCB0
		protected override UniTask OnBeforeStartAsync()
		{
			DockyardSellTabView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<DockyardSellTabView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06042442 RID: 271426 RVA: 0x010FFAF4 File Offset: 0x010FDCF4
		protected override UniTask OnBeforeShowAsyncImplement()
		{
			DockyardSellTabView.<OnBeforeShowAsyncImplement>d__11 <OnBeforeShowAsyncImplement>d__;
			<OnBeforeShowAsyncImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeShowAsyncImplement>d__.<>4__this = this;
			<OnBeforeShowAsyncImplement>d__.<>1__state = -1;
			<OnBeforeShowAsyncImplement>d__.<>t__builder.Start<DockyardSellTabView.<OnBeforeShowAsyncImplement>d__11>(ref <OnBeforeShowAsyncImplement>d__);
			return <OnBeforeShowAsyncImplement>d__.<>t__builder.Task;
		}

		// Token: 0x06042443 RID: 271427 RVA: 0x010FFB38 File Offset: 0x010FDD38
		public void ShowTipsPanel(int id)
		{
			DockyardItemBlockOriginalData itemBlockData = this.Vm.GetItemBlockData(id);
			this.TipsPanel.ShowTipsPanel(itemBlockData);
		}

		// Token: 0x06042444 RID: 271428 RVA: 0x010FFB5E File Offset: 0x010FDD5E
		public void HideTipsPanel()
		{
			this.TipsPanel.HideTipsPanel();
		}

		// Token: 0x06042445 RID: 271429 RVA: 0x010FFB6B File Offset: 0x010FDD6B
		[NullableContext(2)]
		public void CloseMe(Action<bool> callback = null)
		{
			this.Vm.NotifyMainViewClose();
		}

		// Token: 0x06042446 RID: 271430 RVA: 0x010FFB78 File Offset: 0x010FDD78
		public void NotifyQuicklySellActive(bool isActive)
		{
		}

		// Token: 0x06042447 RID: 271431 RVA: 0x010FFB7A File Offset: 0x010FDD7A
		[NullableContext(2)]
		public UUIItem GetQuicklySellPanelParentItem()
		{
			return null;
		}

		// Token: 0x06042448 RID: 271432 RVA: 0x010FFB7D File Offset: 0x010FDD7D
		public void SetTrawlState(bool state)
		{
			this.ListPanel.SetActive(state);
			this.Vm.NotifyMainViewUiBlur(state);
		}

		// Token: 0x04024E69 RID: 151145
		private DockyardBackpackPanel BackpackPanel;

		// Token: 0x04024E6A RID: 151146
		private DockyardItemListPanel ListPanel;

		// Token: 0x04024E6B RID: 151147
		private DockyardSellTipsPanel TipsPanel;

		// Token: 0x04024E6C RID: 151148
		private DockyardShopTabViewModel Vm;

		// Token: 0x0200C803 RID: 51203
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403D8ED RID: 252141
			public const int BackpackItem = 0;

			// Token: 0x0403D8EE RID: 252142
			public const int ListItem = 1;

			// Token: 0x0403D8EF RID: 252143
			public const int TipsItem = 2;

			// Token: 0x0403D8F0 RID: 252144
			public const int SellParentItem = 3;
		}
	}
}
