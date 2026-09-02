using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using CSharpScript.Game.Ui.PhoneMessage.View;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CC2 RID: 19650
	[NullableContext(1)]
	[Nullable(0)]
	public class NavigationChatTalkToggle : NavigationToggle
	{
		// Token: 0x060332A1 RID: 209569 RVA: 0x00CCF2EA File Offset: 0x00CCD4EA
		public NavigationChatTalkToggle(ULGUIBehaviour selectable, string type, List<string> paramList) : base(selectable, type, paramList)
		{
		}

		// Token: 0x170087CB RID: 34763
		// (get) Token: 0x060332A2 RID: 209570 RVA: 0x00CCF2F8 File Offset: 0x00CCD4F8
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

		// Token: 0x060332A3 RID: 209571 RVA: 0x00CCF337 File Offset: 0x00CCD537
		protected override void OnNotifyFocusListener(bool isSameListener)
		{
			if (this.Proxy != null && !isSameListener)
			{
				this.Proxy.SetChatSelectPanelBlackMarkEnable(false);
			}
		}

		// Token: 0x0401DB91 RID: 121745
		protected PhoneSystemChatProxy ProxyInternal;
	}
}
