using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CA6 RID: 19622
	public class NavigationFunctionPageLeftButton : NavigationButton
	{
		// Token: 0x0603320E RID: 209422 RVA: 0x00CCDCC8 File Offset: 0x00CCBEC8
		[NullableContext(1)]
		public NavigationFunctionPageLeftButton(ULGUIBehaviour selectable, string type, List<string> paramList) : base(selectable, type, paramList)
		{
		}

		// Token: 0x0603320F RID: 209423 RVA: 0x00CCDCD4 File Offset: 0x00CCBED4
		protected override void OnButtonClick()
		{
			SpecialPanelHandleBase panelHandle = this.PanelHandle;
			if (((panelHandle != null) ? new ESpecialPanelHandleDefine?(panelHandle.GetType()) : null) == ESpecialPanelHandleDefine.FunctionView)
			{
				FunctionViewPanelHandle functionViewPanelHandle = this.PanelHandle as FunctionViewPanelHandle;
				if (functionViewPanelHandle == null)
				{
					return;
				}
				functionViewPanelHandle.FindPrevFocusListener();
			}
		}
	}
}
