using System;
using System.Collections.Generic;
using System.Text;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhoneMessage
{
	// Token: 0x02005455 RID: 21589
	internal class PhoneViewFilterEntry : UiPanelBase
	{
		// Token: 0x0603701B RID: 225307 RVA: 0x00DF6394 File Offset: 0x00DF4594
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnBtnFilterClick)),
				new ValueTuple<int, Delegate>(3, new Action(this.OnBtnDeleteClick))
			};
		}

		// Token: 0x0603701C RID: 225308 RVA: 0x00DF643F File Offset: 0x00DF463F
		protected override void OnBeforeShow()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnPhoneMsgFilterChanged, new Action(this.OnFilterChanged));
			this.ResetFilter();
		}

		// Token: 0x0603701D RID: 225309 RVA: 0x00DF6463 File Offset: 0x00DF4663
		protected override void OnBeforeHide()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnPhoneMsgFilterChanged, new Action(this.OnFilterChanged));
		}

		// Token: 0x0603701E RID: 225310 RVA: 0x00DF6481 File Offset: 0x00DF4681
		private void OnFilterChanged()
		{
			this.RefreshFilterInfoTips();
		}

		// Token: 0x0603701F RID: 225311 RVA: 0x00DF6489 File Offset: 0x00DF4689
		private void OnBtnFilterClick()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PhoneViewFilterPanel, null, null);
		}

		// Token: 0x06037020 RID: 225312 RVA: 0x00DF649C File Offset: 0x00DF469C
		private void OnBtnDeleteClick()
		{
			base.GetItem(1).SetUIActive(false);
			this.ResetFilter();
		}

		// Token: 0x06037021 RID: 225313 RVA: 0x00DF64B4 File Offset: 0x00DF46B4
		public void RefreshFilterInfoTips()
		{
			UUIItem item = base.GetItem(1);
			UUIText text = base.GetText(2);
			if (ModelBase<PhoneMsgModel>.Instance.SelectedFilterIdSet.Count == 0)
			{
				text.SetText("", true);
				item.SetUIActive(false);
				return;
			}
			StringBuilder stringBuilder = new StringBuilder();
			foreach (int filterId in ModelBase<PhoneMsgModel>.Instance.SelectedFilterIdSet)
			{
				ChatPartnerFilter? chatPartnerFilterConfig = ConfigBase<PhoneMsgConfig>.Instance.GetChatPartnerFilterConfig(filterId);
				if (chatPartnerFilterConfig != null)
				{
					string value = ConfigMultiTextLang.GetLocalTextNew(chatPartnerFilterConfig.Value.Name, null) ?? "";
					stringBuilder.Append(value);
					stringBuilder.Append(',');
				}
			}
			stringBuilder.Remove(stringBuilder.Length - 1, 1);
			text.SetText(stringBuilder.ToString(), true);
			item.SetUIActive(true);
		}

		// Token: 0x06037022 RID: 225314 RVA: 0x00DF65B0 File Offset: 0x00DF47B0
		public void ResetFilter()
		{
			ModelBase<PhoneMsgModel>.Instance.ClearSelectedFilterIdSet();
		}
	}
}
