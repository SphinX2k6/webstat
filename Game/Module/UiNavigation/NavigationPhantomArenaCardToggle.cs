using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Battle.View;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CB8 RID: 19640
	[NullableContext(1)]
	[Nullable(0)]
	public class NavigationPhantomArenaCardToggle : NavigationButton
	{
		// Token: 0x06033272 RID: 209522 RVA: 0x00CCEB7A File Offset: 0x00CCCD7A
		public NavigationPhantomArenaCardToggle(ULGUIBehaviour selectable, string type, List<string> paramList) : base(selectable, type, paramList)
		{
		}

		// Token: 0x170087C2 RID: 34754
		// (get) Token: 0x06033273 RID: 209523 RVA: 0x00CCEB88 File Offset: 0x00CCCD88
		protected PhantomArenaBattleProxy Proxy
		{
			get
			{
				if (this.ProxyInternal == null)
				{
					UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.PhantomArenaBattleView);
					this.ProxyInternal = (((viewByName != null) ? viewByName.OpenParam : null) as PhantomArenaBattleProxy);
				}
				return this.ProxyInternal;
			}
		}

		// Token: 0x06033274 RID: 209524 RVA: 0x00CCEBCA File Offset: 0x00CCCDCA
		protected override void OnNotifyFocusListener(bool isSameListener)
		{
			if (this.Proxy != null && !isSameListener)
			{
				this.Proxy.GamepadLogic.HideCardTips();
			}
		}

		// Token: 0x0401DB88 RID: 121736
		protected PhantomArenaBattleProxy ProxyInternal;
	}
}
