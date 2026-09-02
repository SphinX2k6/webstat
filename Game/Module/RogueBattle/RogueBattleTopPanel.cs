using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Roguelike;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x02005236 RID: 21046
	[NullableContext(2)]
	[Nullable(0)]
	public class RogueBattleTopPanel : UiPanelBase
	{
		// Token: 0x06035E6C RID: 220780 RVA: 0x00D91698 File Offset: 0x00D8F898
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(2, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(5, typeof(UUIText)),
				new ValueTuple<int, Type>(6, typeof(UUIText))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(1, new Action(this.BackBtn)),
				new ValueTuple<int, Delegate>(2, new Action<EToggleState>(this.TabBtn)),
				new ValueTuple<int, Delegate>(4, new Action(this.TotalInfoBtn))
			};
		}

		// Token: 0x06035E6D RID: 220781 RVA: 0x00D9179D File Offset: 0x00D8F99D
		protected override void OnStart()
		{
			this.PopupCaptionItem = new PopupCaptionItem(base.GetItem(0));
			this.PopupCaptionItem.SetCloseBtnActive(false);
			this.PopupCaptionItem.SetHelpBtnActive(false);
		}

		// Token: 0x06035E6E RID: 220782 RVA: 0x00D917C9 File Offset: 0x00D8F9C9
		protected override void OnBeforeShow()
		{
			this.RefreshTabBtn();
		}

		// Token: 0x06035E6F RID: 220783 RVA: 0x00D917D4 File Offset: 0x00D8F9D4
		public void RefreshTabBtn()
		{
			EToggleState state = (ModelBase<RogueBattleModel>.Instance.DescMode == EDescModel.SIMPLE) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			UUIExtendToggle extendToggle = base.GetExtendToggle(2);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleState(state, false, false, false);
		}

		// Token: 0x06035E70 RID: 220784 RVA: 0x00D91808 File Offset: 0x00D8FA08
		protected override void OnBeforeDestroy()
		{
			this.CloseCallback = null;
		}

		// Token: 0x06035E71 RID: 220785 RVA: 0x00D91811 File Offset: 0x00D8FA11
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

		// Token: 0x06035E72 RID: 220786 RVA: 0x00D9183D File Offset: 0x00D8FA3D
		public void EmptySelectTipsText()
		{
			base.GetText(5).SetText(string.Empty, true);
		}

		// Token: 0x06035E73 RID: 220787 RVA: 0x00D91851 File Offset: 0x00D8FA51
		private void BackBtn()
		{
			Action closeCallback = this.CloseCallback;
			if (closeCallback == null)
			{
				return;
			}
			closeCallback();
		}

		// Token: 0x06035E74 RID: 220788 RVA: 0x00D91863 File Offset: 0x00D8FA63
		private void TabBtn(EToggleState state)
		{
			ModelBase<RogueBattleModel>.Instance.ChangeDescMode();
		}

		// Token: 0x06035E75 RID: 220789 RVA: 0x00D91870 File Offset: 0x00D8FA70
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

		// Token: 0x06035E76 RID: 220790 RVA: 0x00D918AC File Offset: 0x00D8FAAC
		public void SetCloseBtnActive(bool isActive)
		{
			PopupCaptionItem popupCaptionItem = this.PopupCaptionItem;
			if (popupCaptionItem != null)
			{
				popupCaptionItem.SetCloseBtnActive(isActive);
			}
			base.GetButton(1).RootUIComp.Get().SetUIActive(isActive);
		}

		// Token: 0x06035E77 RID: 220791 RVA: 0x00D918E5 File Offset: 0x00D8FAE5
		private void TotalInfoBtn()
		{
			Action clickDetailCallback = this.ClickDetailCallback;
			if (clickDetailCallback == null)
			{
				return;
			}
			clickDetailCallback();
		}

		// Token: 0x0401EFA6 RID: 126886
		private PopupCaptionItem PopupCaptionItem;

		// Token: 0x0401EFA7 RID: 126887
		public Action CloseCallback;

		// Token: 0x0401EFA8 RID: 126888
		public Action ClickDetailCallback;
	}
}
