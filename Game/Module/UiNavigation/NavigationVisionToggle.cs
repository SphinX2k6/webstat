using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CD1 RID: 19665
	[NullableContext(1)]
	[Nullable(0)]
	public class NavigationVisionToggle : NavigationToggle
	{
		// Token: 0x060332CC RID: 209612 RVA: 0x00CCFB4E File Offset: 0x00CCDD4E
		public NavigationVisionToggle(ULGUIBehaviour selectable, string type, List<string> paramList) : base(selectable, type, paramList)
		{
		}

		// Token: 0x060332CD RID: 209613 RVA: 0x00CCFB5C File Offset: 0x00CCDD5C
		protected override bool OnHandlePointerSelect(ULGUIPointerEventData eventData)
		{
			UUIExtendToggle uuiextendToggle = this.Selectable as UUIExtendToggle;
			if (uuiextendToggle.ToggleState == EToggleState.ETT_UnChecked && eventData != null && eventData.inputType == ELGUIPointerInputType.Navigation && uuiextendToggle.bToggleOnSelect)
			{
				ControllerBase<UiNavigationNewController>.Instance.InteractClickByListener(this.Listener);
			}
			base.ScrollToSelectableComponent(uuiextendToggle);
			return base.IsAllowNavigationByGroup();
		}

		// Token: 0x060332CE RID: 209614 RVA: 0x00CCFBB3 File Offset: 0x00CCDDB3
		protected override bool OnIsIgnoreScrollOrLayoutCheck()
		{
			return true;
		}
	}
}
