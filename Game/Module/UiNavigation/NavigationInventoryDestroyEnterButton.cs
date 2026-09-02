using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CAC RID: 19628
	public class NavigationInventoryDestroyEnterButton : NavigationButton
	{
		// Token: 0x06033216 RID: 209430 RVA: 0x00CCDDB2 File Offset: 0x00CCBFB2
		[NullableContext(1)]
		public NavigationInventoryDestroyEnterButton(ULGUIBehaviour selectable, string type, List<string> paramList) : base(selectable, type, paramList)
		{
		}

		// Token: 0x06033217 RID: 209431 RVA: 0x00CCDDBD File Offset: 0x00CCBFBD
		protected override void OnButtonClick()
		{
			InventoryViewPanelHandle inventoryViewPanelHandle = this.PanelHandle as InventoryViewPanelHandle;
			if (inventoryViewPanelHandle == null)
			{
				return;
			}
			inventoryViewPanelHandle.SetItemGridDestroyMode(true);
		}
	}
}
