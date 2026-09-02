using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CA3 RID: 19619
	public class NavigationCommonRefreshNavigationButton : NavigationButton
	{
		// Token: 0x06033206 RID: 209414 RVA: 0x00CCDB2D File Offset: 0x00CCBD2D
		[NullableContext(1)]
		public NavigationCommonRefreshNavigationButton(ULGUIBehaviour selectable, string type, List<string> paramList) : base(selectable, type, paramList)
		{
		}

		// Token: 0x06033207 RID: 209415 RVA: 0x00CCDB38 File Offset: 0x00CCBD38
		protected override void OnButtonClick()
		{
			ControllerBase<UiNavigationNewController>.Instance.MarkViewHandleRefreshNavigationDirtyByListener(this.Listener);
		}
	}
}
