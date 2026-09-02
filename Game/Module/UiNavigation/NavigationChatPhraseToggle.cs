using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using CSharpScript.Game.Ui.PhoneMessage.View;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CC0 RID: 19648
	[NullableContext(1)]
	[Nullable(0)]
	public class NavigationChatPhraseToggle : NavigationButton
	{
		// Token: 0x0603329A RID: 209562 RVA: 0x00CCF217 File Offset: 0x00CCD417
		public NavigationChatPhraseToggle(ULGUIBehaviour selectable, string type, List<string> paramList) : base(selectable, type, paramList)
		{
		}

		// Token: 0x170087C9 RID: 34761
		// (get) Token: 0x0603329B RID: 209563 RVA: 0x00CCF224 File Offset: 0x00CCD424
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

		// Token: 0x0603329C RID: 209564 RVA: 0x00CCF263 File Offset: 0x00CCD463
		protected override void OnNotifyFocusListener(bool isSameListener)
		{
			if (this.Proxy != null && !isSameListener)
			{
				this.Proxy.SetChatSelectPanelBlackMarkEnable(true);
			}
		}

		// Token: 0x0401DB8F RID: 121743
		protected PhoneSystemChatProxy ProxyInternal;
	}
}
