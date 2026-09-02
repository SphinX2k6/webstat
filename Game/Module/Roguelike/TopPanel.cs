using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x020051C0 RID: 20928
	[NullableContext(2)]
	[Nullable(0)]
	public class TopPanel : UiPanelBase
	{
		// Token: 0x17008C92 RID: 35986
		// (get) Token: 0x06035CE3 RID: 220387 RVA: 0x00D892EF File Offset: 0x00D874EF
		// (set) Token: 0x06035CE4 RID: 220388 RVA: 0x00D892F7 File Offset: 0x00D874F7
		public Action CloseCallback { get; set; }

		// Token: 0x06035CE5 RID: 220389 RVA: 0x00D89300 File Offset: 0x00D87500
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 3;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.BackBtn));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(2, this.TabBtn);
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(4, this.TotalInfoBtn);
			this.BtnBindInfo = list2;
		}

		// Token: 0x06035CE6 RID: 220390 RVA: 0x00D89485 File Offset: 0x00D87685
		protected override void OnStart()
		{
			this.PopupCaptionItem = new PopupCaptionItem(base.GetItem(0));
			this.PopupCaptionItem.SetCloseBtnActive(false);
			this.PopupCaptionItem.SetHelpBtnActive(false);
		}

		// Token: 0x06035CE7 RID: 220391 RVA: 0x00D894B1 File Offset: 0x00D876B1
		protected override void OnBeforeShow()
		{
			this.RefreshTabBtn();
		}

		// Token: 0x06035CE8 RID: 220392 RVA: 0x00D894BC File Offset: 0x00D876BC
		public void RefreshTabBtn()
		{
			EToggleState state = (ModelBase<RoguelikeModel>.Instance.GetDescModel() == EDescModel.SIMPLE) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			UUIExtendToggle extendToggle = base.GetExtendToggle(2);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleState(state, true, false, false);
		}

		// Token: 0x06035CE9 RID: 220393 RVA: 0x00D894F0 File Offset: 0x00D876F0
		protected override void OnBeforeDestroy()
		{
			this.CloseCallback = null;
		}

		// Token: 0x06035CEA RID: 220394 RVA: 0x00D894F9 File Offset: 0x00D876F9
		[NullableContext(1)]
		public void RefreshTitle(string titleText)
		{
			this.PopupCaptionItem.SetTitleByTextIdAndArgNew(titleText, Array.Empty<object>());
		}

		// Token: 0x06035CEB RID: 220395 RVA: 0x00D8950C File Offset: 0x00D8770C
		[NullableContext(1)]
		public UniTask RefreshCurrency(List<int> currencyList)
		{
			TopPanel.<RefreshCurrency>d__12 <RefreshCurrency>d__;
			<RefreshCurrency>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshCurrency>d__.<>4__this = this;
			<RefreshCurrency>d__.currencyList = currencyList;
			<RefreshCurrency>d__.<>1__state = -1;
			<RefreshCurrency>d__.<>t__builder.Start<TopPanel.<RefreshCurrency>d__12>(ref <RefreshCurrency>d__);
			return <RefreshCurrency>d__.<>t__builder.Task;
		}

		// Token: 0x06035CEC RID: 220396 RVA: 0x00D89557 File Offset: 0x00D87757
		[NullableContext(1)]
		public void RefreshSelectTipsText(string selectTipsText, bool isUseTypeB = false, params object[] args)
		{
			if (isUseTypeB)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), selectTipsText, args);
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), selectTipsText, args);
		}

		// Token: 0x06035CED RID: 220397 RVA: 0x00D89583 File Offset: 0x00D87783
		public void EmptySelectTipsText()
		{
			base.GetText(5).SetText("", true);
		}

		// Token: 0x06035CEE RID: 220398 RVA: 0x00D89597 File Offset: 0x00D87797
		private void BackBtn()
		{
			Action closeCallback = this.CloseCallback;
			if (closeCallback == null)
			{
				return;
			}
			closeCallback();
		}

		// Token: 0x06035CEF RID: 220399 RVA: 0x00D895AC File Offset: 0x00D877AC
		public UUIItem GetCostItemByIndex(int index)
		{
			PopupCaptionItem popupCaptionItem = this.PopupCaptionItem;
			List<CommonCurrencyItem> list = (popupCaptionItem != null) ? popupCaptionItem.GetCurrencyItemList() : null;
			if (list != null && list.Count > index)
			{
				return list[index].GetRootItem();
			}
			return null;
		}

		// Token: 0x0401EDD2 RID: 126418
		private PopupCaptionItem PopupCaptionItem;

		// Token: 0x0401EDD4 RID: 126420
		[Nullable(1)]
		private readonly Action<EToggleState> TabBtn = delegate(EToggleState state)
		{
			ModelBase<RoguelikeModel>.Instance.UpdateDescModel(state == EToggleState.ETT_Checked);
		};

		// Token: 0x0401EDD5 RID: 126421
		[Nullable(1)]
		private readonly Action TotalInfoBtn = delegate()
		{
			ControllerBase<RoguelikeController>.Instance.OpenRogueInfoView(null, true, true, ERogueInfoViewPage.Overview);
		};

		// Token: 0x0200B1A6 RID: 45478
		[NullableContext(0)]
		private class ETopPanelCom
		{
			// Token: 0x04037187 RID: 225671
			public const int PopupCaptionItem = 0;

			// Token: 0x04037188 RID: 225672
			public const int BackBtn = 1;

			// Token: 0x04037189 RID: 225673
			public const int TabToggle = 2;

			// Token: 0x0403718A RID: 225674
			public const int DescText = 3;

			// Token: 0x0403718B RID: 225675
			public const int TotalInfoBtn = 4;

			// Token: 0x0403718C RID: 225676
			public const int SelectTipsText = 5;

			// Token: 0x0403718D RID: 225677
			public const int SelectTipsText2 = 6;
		}
	}
}
