using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Extension;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049A8 RID: 18856
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class UiBlurLogic : Singleton<UiBlurLogic>
	{
		// Token: 0x060313C5 RID: 201669 RVA: 0x00C42798 File Offset: 0x00C40998
		[NullableContext(2)]
		private void SetGlobalBlurIndex(UUIItem uiItem)
		{
			if (uiItem == null)
			{
				return;
			}
			TsUiBlur tsUiBlur = uiItem.GetOwner().GetComponentByClass(TsUiBlur.StaticClass()) as TsUiBlur;
			UUIItem uuiitem = null;
			if (tsUiBlur != null)
			{
				uuiitem = ((tsUiBlur.OverrideItem == null) ? uiItem : ((UUIItem)tsUiBlur.OverrideItem.RootComponent));
				tsUiBlur.ApplyItem = uiItem;
			}
			if (uuiitem == null || !tsUiBlur.EnableUiBlur)
			{
				ULGUIBPLibrary.ResetGlobalBlurUIItem(uiItem.GetWorld());
				return;
			}
			ULGUIBPLibrary.SetGlobalBlurUIItem(uuiitem, uiItem.GetWorld());
		}

		// Token: 0x060313C6 RID: 201670 RVA: 0x00C42810 File Offset: 0x00C40A10
		private UUIItem GetRootItem(UiViewBase view)
		{
			IPopViewWithCustomUiBlurItem popViewWithCustomUiBlurItem = view as IPopViewWithCustomUiBlurItem;
			if (popViewWithCustomUiBlurItem != null)
			{
				return popViewWithCustomUiBlurItem.GetOverrideRootItem();
			}
			if (view.ChildPopView != null)
			{
				return view.ChildPopView.GetPopViewRootItem();
			}
			return view.GetBlurRootItem();
		}

		// Token: 0x060313C7 RID: 201671 RVA: 0x00C42848 File Offset: 0x00C40A48
		public void SetNormalUiRenderAfterBlur(UiViewBase view)
		{
			this.SetGlobalBlurIndex(this.GetRootItem(view));
		}

		// Token: 0x060313C8 RID: 201672 RVA: 0x00C42858 File Offset: 0x00C40A58
		public void ResumeTopUiRenderAfterBlur()
		{
			UiViewBase topView = Singleton<UiModel>.Instance.GetTopView(ELayerType.Pop);
			if (topView != null && topView.IsShowOrShowing)
			{
				this.SetNormalUiRenderAfterBlur(topView);
				return;
			}
			topView = Singleton<UiModel>.Instance.GetTopView(ELayerType.Plot);
			if (topView != null)
			{
				this.SetNormalUiRenderAfterBlur(topView);
				return;
			}
			topView = Singleton<UiModel>.Instance.GetTopView(ELayerType.Normal);
			if (topView != null)
			{
				this.SetNormalUiRenderAfterBlur(topView);
				return;
			}
			ULGUIBPLibrary.ResetGlobalBlurUIItem(GlobalData.GameInstance.GetWorld());
		}
	}
}
