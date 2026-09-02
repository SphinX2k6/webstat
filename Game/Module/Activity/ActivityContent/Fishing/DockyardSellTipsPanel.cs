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
	// Token: 0x020067CE RID: 26574
	[NullableContext(1)]
	[Nullable(0)]
	public class DockyardSellTipsPanel : UiPanelBase
	{
		// Token: 0x060424B1 RID: 271537 RVA: 0x011012F4 File Offset: 0x010FF4F4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnSellClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060424B2 RID: 271538 RVA: 0x0110139C File Offset: 0x010FF59C
		private UniTask InitTipsPanel()
		{
			DockyardSellTipsPanel.<InitTipsPanel>d__6 <InitTipsPanel>d__;
			<InitTipsPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitTipsPanel>d__.<>4__this = this;
			<InitTipsPanel>d__.<>1__state = -1;
			<InitTipsPanel>d__.<>t__builder.Start<DockyardSellTipsPanel.<InitTipsPanel>d__6>(ref <InitTipsPanel>d__);
			return <InitTipsPanel>d__.<>t__builder.Task;
		}

		// Token: 0x060424B3 RID: 271539 RVA: 0x011013E0 File Offset: 0x010FF5E0
		protected override UniTask OnBeforeStartAsync()
		{
			DockyardSellTipsPanel.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<DockyardSellTipsPanel.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060424B4 RID: 271540 RVA: 0x01101423 File Offset: 0x010FF623
		private void OnSellClick()
		{
			Action<int, int> sellClick = this.SellClick;
			if (sellClick == null)
			{
				return;
			}
			sellClick(this.Data.IncId, this.Data.ItemId);
		}

		// Token: 0x060424B5 RID: 271541 RVA: 0x0110144C File Offset: 0x010FF64C
		private void RefreshSellBtnActive()
		{
			base.GetButton(1).RootUIComp.Get().SetUIActive(this.Data.Price > 0);
		}

		// Token: 0x060424B6 RID: 271542 RVA: 0x01101480 File Offset: 0x010FF680
		protected override UniTask OnShowAsyncImplementImplement()
		{
			DockyardSellTipsPanel.<OnShowAsyncImplementImplement>d__10 <OnShowAsyncImplementImplement>d__;
			<OnShowAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnShowAsyncImplementImplement>d__.<>4__this = this;
			<OnShowAsyncImplementImplement>d__.<>1__state = -1;
			<OnShowAsyncImplementImplement>d__.<>t__builder.Start<DockyardSellTipsPanel.<OnShowAsyncImplementImplement>d__10>(ref <OnShowAsyncImplementImplement>d__);
			return <OnShowAsyncImplementImplement>d__.<>t__builder.Task;
		}

		// Token: 0x060424B7 RID: 271543 RVA: 0x011014C4 File Offset: 0x010FF6C4
		protected override UniTask OnHideAsyncImplementImplement()
		{
			DockyardSellTipsPanel.<OnHideAsyncImplementImplement>d__11 <OnHideAsyncImplementImplement>d__;
			<OnHideAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnHideAsyncImplementImplement>d__.<>4__this = this;
			<OnHideAsyncImplementImplement>d__.<>1__state = -1;
			<OnHideAsyncImplementImplement>d__.<>t__builder.Start<DockyardSellTipsPanel.<OnHideAsyncImplementImplement>d__11>(ref <OnHideAsyncImplementImplement>d__);
			return <OnHideAsyncImplementImplement>d__.<>t__builder.Task;
		}

		// Token: 0x060424B8 RID: 271544 RVA: 0x01101507 File Offset: 0x010FF707
		protected override void OnBeforeDestroy()
		{
			this.SequencePlayer.Clear();
		}

		// Token: 0x060424B9 RID: 271545 RVA: 0x01101514 File Offset: 0x010FF714
		protected void Refresh()
		{
			this.TipsPanel.Refresh(this.Data);
			this.TipsPanel.SetPanelVisible(true, false);
			this.RefreshSellBtnActive();
		}

		// Token: 0x060424BA RID: 271546 RVA: 0x0110153A File Offset: 0x010FF73A
		public void ShowTipsPanel(DockyardItemBlockOriginalData data)
		{
			this.Data = data;
			this.Refresh();
			this.SetActive(true);
		}

		// Token: 0x060424BB RID: 271547 RVA: 0x01101550 File Offset: 0x010FF750
		public void HideTipsPanel()
		{
			if (base.IsShowOrShowing)
			{
				this.SetActive(false);
			}
		}

		// Token: 0x060424BC RID: 271548 RVA: 0x01101561 File Offset: 0x010FF761
		public void SetSellClick(Action<int, int> sellClick)
		{
			this.SellClick = sellClick;
		}

		// Token: 0x04024E89 RID: 151177
		protected DockyardTipsPanel TipsPanel;

		// Token: 0x04024E8A RID: 151178
		protected UiSequencePlayer SequencePlayer;

		// Token: 0x04024E8B RID: 151179
		protected DockyardItemBlockOriginalData Data;

		// Token: 0x04024E8C RID: 151180
		protected Action<int, int> SellClick;

		// Token: 0x0200C815 RID: 51221
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403D934 RID: 252212
			public const int TipsItem = 0;

			// Token: 0x0403D935 RID: 252213
			public const int SellBtn = 1;
		}
	}
}
