using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Battle.View;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CBB RID: 19643
	[NullableContext(1)]
	[Nullable(0)]
	public class NavigationPhantomArenaOpponentFunctionalToggle : NavigationButton
	{
		// Token: 0x0603327F RID: 209535 RVA: 0x00CCED5E File Offset: 0x00CCCF5E
		public NavigationPhantomArenaOpponentFunctionalToggle(ULGUIBehaviour selectable, string type, List<string> paramList) : base(selectable, type, paramList)
		{
		}

		// Token: 0x170087C5 RID: 34757
		// (get) Token: 0x06033280 RID: 209536 RVA: 0x00CCED6C File Offset: 0x00CCCF6C
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

		// Token: 0x06033281 RID: 209537 RVA: 0x00CCEDAE File Offset: 0x00CCCFAE
		protected override void OnButtonClick()
		{
		}

		// Token: 0x06033282 RID: 209538 RVA: 0x00CCEDB0 File Offset: 0x00CCCFB0
		protected override void OnNotifyFocusListener(bool isSameListener)
		{
			if (this.Proxy != null && !isSameListener)
			{
				this.Proxy.GamepadLogic.HideCardTips();
			}
		}

		// Token: 0x06033283 RID: 209539 RVA: 0x00CCEDCD File Offset: 0x00CCCFCD
		protected override bool OnCheckFindOpposite()
		{
			return this.Proxy == null || !this.Proxy.GamepadLogic.IsInCardSelectState;
		}

		// Token: 0x0401DB8B RID: 121739
		protected PhantomArenaBattleProxy ProxyInternal;
	}
}
