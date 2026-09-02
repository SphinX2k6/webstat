using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using CSharpScript.Game.Ui.PhoneMessage.View;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CC1 RID: 19649
	[NullableContext(1)]
	[Nullable(0)]
	public class NavigationChatTalkPartnerToggle : NavigationToggle
	{
		// Token: 0x0603329D RID: 209565 RVA: 0x00CCF27C File Offset: 0x00CCD47C
		public NavigationChatTalkPartnerToggle(ULGUIBehaviour selectable, string type, List<string> paramList) : base(selectable, type, paramList)
		{
		}

		// Token: 0x170087CA RID: 34762
		// (get) Token: 0x0603329E RID: 209566 RVA: 0x00CCF288 File Offset: 0x00CCD488
		protected PhoneSystemChatProxy Proxy
		{
			get
			{
				if (this.ProxyInternal == null)
				{
					PhoneMsgPanelViewBig phoneMsgPanelViewBig = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.PhoneMsgPanelViewBig) as PhoneMsgPanelViewBig;
					if (phoneMsgPanelViewBig != null)
					{
						this.ProxyInternal = phoneMsgPanelViewBig.GetProxy();
					}
				}
				return this.ProxyInternal;
			}
		}

		// Token: 0x0603329F RID: 209567 RVA: 0x00CCF2C7 File Offset: 0x00CCD4C7
		protected override bool OnCanFocusInScrollOrLayout()
		{
			bool isInteractive = this.IsInteractive;
			return false;
		}

		// Token: 0x060332A0 RID: 209568 RVA: 0x00CCF2D1 File Offset: 0x00CCD4D1
		protected override void OnNotifyFocusListener(bool isSameListener)
		{
			if (this.Proxy != null && !isSameListener)
			{
				this.Proxy.SetChatSelectPanelBlackMarkEnable(false);
			}
		}

		// Token: 0x0401DB90 RID: 121744
		protected PhoneSystemChatProxy ProxyInternal;
	}
}
