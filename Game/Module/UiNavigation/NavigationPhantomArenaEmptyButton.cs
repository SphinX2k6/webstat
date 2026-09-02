using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Battle.View.Bvb;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CB9 RID: 19641
	[NullableContext(1)]
	[Nullable(0)]
	public class NavigationPhantomArenaEmptyButton : NavigationButton
	{
		// Token: 0x06033275 RID: 209525 RVA: 0x00CCEBE7 File Offset: 0x00CCCDE7
		public NavigationPhantomArenaEmptyButton(ULGUIBehaviour selectable, string type, List<string> paramList) : base(selectable, type, paramList)
		{
		}

		// Token: 0x06033276 RID: 209526 RVA: 0x00CCEBF4 File Offset: 0x00CCCDF4
		protected override void OnInit()
		{
			base.OnInit();
			UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.PhantomArenaBattleDetailsView);
			this.Proxy = (((viewByName != null) ? viewByName.OpenParam : null) as PhantomArenaBattleDetailsViewProxy);
		}

		// Token: 0x06033277 RID: 209527 RVA: 0x00CCEC2E File Offset: 0x00CCCE2E
		public void NotifyFocusListener()
		{
			if (this.Proxy != null)
			{
				this.Proxy.SetIsInGamepadNavigation(false);
			}
		}

		// Token: 0x0401DB89 RID: 121737
		protected PhantomArenaBattleDetailsViewProxy Proxy;
	}
}
