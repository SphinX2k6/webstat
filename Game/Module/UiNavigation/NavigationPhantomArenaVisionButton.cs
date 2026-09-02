using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Battle.View.Bvb;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CBE RID: 19646
	public class NavigationPhantomArenaVisionButton : NavigationButton, INavigationInteractPrevGroup
	{
		// Token: 0x06033294 RID: 209556 RVA: 0x00CCF0C9 File Offset: 0x00CCD2C9
		[NullableContext(1)]
		public NavigationPhantomArenaVisionButton(ULGUIBehaviour selectable, string type, List<string> paramList) : base(selectable, type, paramList)
		{
		}

		// Token: 0x06033295 RID: 209557 RVA: 0x00CCF0D4 File Offset: 0x00CCD2D4
		protected override void OnInit()
		{
			base.OnInit();
			UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.PhantomArenaBattleDetailsView);
			this.Proxy = (((viewByName != null) ? viewByName.OpenParam : null) as PhantomArenaBattleDetailsViewProxy);
		}

		// Token: 0x06033296 RID: 209558 RVA: 0x00CCF10E File Offset: 0x00CCD30E
		public void InteractClickPrevGroup()
		{
			if (this.Proxy != null)
			{
				this.Proxy.SetIsInGamepadNavigation(false);
			}
		}

		// Token: 0x0401DB8E RID: 121742
		[Nullable(1)]
		protected PhantomArenaBattleDetailsViewProxy Proxy;
	}
}
