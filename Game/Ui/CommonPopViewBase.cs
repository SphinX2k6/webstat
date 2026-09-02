using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049C3 RID: 18883
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class CommonPopViewBase : UiPanelBase
	{
		// Token: 0x0603163F RID: 202303 RVA: 0x00C4A750 File Offset: 0x00C48950
		public void AttachItem(UUIItem item, UUIItem viewRoot)
		{
			UUIItem attachParent = this.GetAttachParent();
			if (attachParent == null)
			{
				return;
			}
			UIAnchorHorizontalAlign anchorHAlign = item.GetAnchorHAlign();
			UIAnchorVerticalAlign anchorVAlign = item.GetAnchorVAlign();
			float stretchBottom = item.GetStretchBottom();
			float stretchLeft = item.GetStretchLeft();
			float stretchRight = item.GetStretchRight();
			float stretchTop = item.GetStretchTop();
			item.SetUIParent(attachParent, false);
			item.SetAnchorAlign(anchorHAlign, anchorVAlign);
			item.SetStretchBottom(stretchBottom);
			item.SetStretchLeft(stretchLeft);
			item.SetStretchRight(stretchRight);
			item.SetStretchTop(stretchTop);
			if (viewRoot != item)
			{
				viewRoot.SetAnchorAlign(anchorHAlign, anchorVAlign);
				viewRoot.SetStretchBottom(stretchBottom);
				viewRoot.SetStretchLeft(stretchLeft);
				viewRoot.SetStretchRight(stretchRight);
				viewRoot.SetStretchTop(stretchTop);
			}
		}

		// Token: 0x06031640 RID: 202304 RVA: 0x00C4A7EF File Offset: 0x00C489EF
		protected void OnClickMaskButton()
		{
			if (!this.MaskCallable)
			{
				return;
			}
			this.TryHideSelf();
		}

		// Token: 0x06031641 RID: 202305 RVA: 0x00C4A800 File Offset: 0x00C48A00
		protected void OnClickCloseBtn()
		{
			this.TryHideSelf();
		}

		// Token: 0x06031642 RID: 202306 RVA: 0x00C4A808 File Offset: 0x00C48A08
		[NullableContext(2)]
		public virtual UUIItem GetAttachParent()
		{
			Singleton<Log>.Instance.Error(ELogModule.UiCommon, ELogAuthor.YZY, "子类没有重写获取父物体方法", default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}

		// Token: 0x06031643 RID: 202307 RVA: 0x00C4A832 File Offset: 0x00C48A32
		public virtual void OnSetCloseBtnInteractive(bool state)
		{
		}

		// Token: 0x06031644 RID: 202308 RVA: 0x00C4A834 File Offset: 0x00C48A34
		public virtual void OnSetHelpButtonActive(bool state)
		{
		}

		// Token: 0x06031645 RID: 202309 RVA: 0x00C4A836 File Offset: 0x00C48A36
		public virtual void OnSetTitleByTextIdAndArg(string textId, params object[] args)
		{
		}

		// Token: 0x06031646 RID: 202310 RVA: 0x00C4A838 File Offset: 0x00C48A38
		public virtual void OnSetBackBtnShowState(bool state)
		{
		}

		// Token: 0x06031647 RID: 202311 RVA: 0x00C4A83A File Offset: 0x00C48A3A
		public virtual void OnRefreshCost(CommonCurrencyItem[] commonCurrencyItemList)
		{
		}

		// Token: 0x06031648 RID: 202312 RVA: 0x00C4A83C File Offset: 0x00C48A3C
		[NullableContext(2)]
		public virtual UUIItem GetCostParent()
		{
			return null;
		}

		// Token: 0x06031649 RID: 202313 RVA: 0x00C4A83F File Offset: 0x00C48A3F
		public void SetViewInfo(UiViewInfo info)
		{
			this.ViewInfo = info;
		}

		// Token: 0x0603164A RID: 202314 RVA: 0x00C4A848 File Offset: 0x00C48A48
		public void SetPopupViewBase()
		{
			if (this is ICommonPopView)
			{
				this.SelfItem = (this as ICommonPopView);
			}
		}

		// Token: 0x0603164B RID: 202315 RVA: 0x00C4A85E File Offset: 0x00C48A5E
		protected void TryHideSelf()
		{
			this.OnClickHideFunction();
		}

		// Token: 0x0603164C RID: 202316 RVA: 0x00C4A866 File Offset: 0x00C48A66
		public void OverrideBackBtnCallBack(Action call)
		{
			this.OnClickBtnBtnCall = call;
			this.OverrideCloseBtnFuncState = true;
		}

		// Token: 0x0603164D RID: 202317 RVA: 0x00C4A876 File Offset: 0x00C48A76
		private void OnClickHideFunction()
		{
			if (!this.OverrideCloseBtnFuncState)
			{
				if (this.ViewInfo != null)
				{
					Singleton<UiManager>.Instance.CloseView(this.ViewInfo.Name, null);
				}
				return;
			}
			Action onClickBtnBtnCall = this.OnClickBtnBtnCall;
			if (onClickBtnBtnCall == null)
			{
				return;
			}
			onClickBtnBtnCall();
		}

		// Token: 0x0603164E RID: 202318 RVA: 0x00C4A8AF File Offset: 0x00C48AAF
		public void SetCloseBtnInteractive(bool state)
		{
			ICommonPopView selfItem = this.SelfItem;
			if (selfItem == null)
			{
				return;
			}
			selfItem.OnSetCloseBtnInteractive(state);
		}

		// Token: 0x0603164F RID: 202319 RVA: 0x00C4A8C2 File Offset: 0x00C48AC2
		public void SetHelpButtonActive(bool state)
		{
			ICommonPopView selfItem = this.SelfItem;
			if (selfItem == null)
			{
				return;
			}
			selfItem.OnSetHelpButtonActive(state);
		}

		// Token: 0x06031650 RID: 202320 RVA: 0x00C4A8D5 File Offset: 0x00C48AD5
		public void SetTitleByTextIdAndArg(string textId, params object[] args)
		{
			ICommonPopView selfItem = this.SelfItem;
			if (selfItem == null)
			{
				return;
			}
			selfItem.OnSetTitleByTextIdAndArg(textId, args);
		}

		// Token: 0x06031651 RID: 202321 RVA: 0x00C4A8E9 File Offset: 0x00C48AE9
		public void SetBackBtnShowState(bool state)
		{
			ICommonPopView selfItem = this.SelfItem;
			if (selfItem == null)
			{
				return;
			}
			selfItem.OnSetBackBtnShowState(state);
		}

		// Token: 0x06031652 RID: 202322 RVA: 0x00C4A8FC File Offset: 0x00C48AFC
		public void RefreshCost(CommonCurrencyItem[] commonCurrencyItemList)
		{
			ICommonPopView selfItem = this.SelfItem;
			if (selfItem == null)
			{
				return;
			}
			selfItem.OnRefreshCost(commonCurrencyItemList);
		}

		// Token: 0x06031653 RID: 202323 RVA: 0x00C4A90F File Offset: 0x00C48B0F
		public void SetMaskResponsibleState(bool state)
		{
			this.MaskCallable = state;
		}

		// Token: 0x06031654 RID: 202324 RVA: 0x00C4A918 File Offset: 0x00C48B18
		public UniTask SetCurrencyItemList(int[] itemIdList)
		{
			CommonPopViewBase.<SetCurrencyItemList>d__28 <SetCurrencyItemList>d__;
			<SetCurrencyItemList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SetCurrencyItemList>d__.<>4__this = this;
			<SetCurrencyItemList>d__.itemIdList = itemIdList;
			<SetCurrencyItemList>d__.<>1__state = -1;
			<SetCurrencyItemList>d__.<>t__builder.Start<CommonPopViewBase.<SetCurrencyItemList>d__28>(ref <SetCurrencyItemList>d__);
			return <SetCurrencyItemList>d__.<>t__builder.Task;
		}

		// Token: 0x06031655 RID: 202325 RVA: 0x00C4A963 File Offset: 0x00C48B63
		[NullableContext(2)]
		public CommonCurrencyItemListComponent GetCurrencyComponent()
		{
			return this.CurrencyItemListComponent;
		}

		// Token: 0x06031656 RID: 202326 RVA: 0x00C4A96B File Offset: 0x00C48B6B
		public virtual void SetTitleVisible(bool bVisible)
		{
		}

		// Token: 0x06031657 RID: 202327 RVA: 0x00C4A96D File Offset: 0x00C48B6D
		public virtual void SetTitleText(string titleTextId)
		{
		}

		// Token: 0x06031658 RID: 202328 RVA: 0x00C4A96F File Offset: 0x00C48B6F
		public virtual void SetTexBgVisible(bool bVisible)
		{
		}

		// Token: 0x0401C5ED RID: 116205
		[Nullable(2)]
		private CommonCurrencyItemListComponent CurrencyItemListComponent;

		// Token: 0x0401C5EE RID: 116206
		private bool MaskCallable = true;

		// Token: 0x0401C5EF RID: 116207
		[Nullable(2)]
		private ICommonPopView SelfItem;

		// Token: 0x0401C5F0 RID: 116208
		[Nullable(2)]
		protected UUIItem ContentItem;

		// Token: 0x0401C5F1 RID: 116209
		[Nullable(2)]
		protected UiViewInfo ViewInfo;

		// Token: 0x0401C5F2 RID: 116210
		[Nullable(2)]
		protected Action OnClickBtnBtnCall;

		// Token: 0x0401C5F3 RID: 116211
		private bool OverrideCloseBtnFuncState;
	}
}
