using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CA5 RID: 19621
	public class NavigationFunctionPageButton : NavigationButton
	{
		// Token: 0x0603320B RID: 209419 RVA: 0x00CCDC15 File Offset: 0x00CCBE15
		[NullableContext(1)]
		public NavigationFunctionPageButton(ULGUIBehaviour selectable, string type, List<string> paramList) : base(selectable, type, paramList)
		{
		}

		// Token: 0x0603320C RID: 209420 RVA: 0x00CCDC20 File Offset: 0x00CCBE20
		protected override void OnStart()
		{
			SpecialPanelHandleBase panelHandle = this.PanelHandle;
			if (((panelHandle != null) ? new ESpecialPanelHandleDefine?(panelHandle.GetType()) : null) == ESpecialPanelHandleDefine.FunctionView)
			{
				FunctionViewPanelHandle functionViewPanelHandle = this.PanelHandle as FunctionViewPanelHandle;
				if (functionViewPanelHandle == null)
				{
					return;
				}
				functionViewPanelHandle.AddNavigationListener(this.Listener);
			}
		}

		// Token: 0x0603320D RID: 209421 RVA: 0x00CCDC8C File Offset: 0x00CCBE8C
		protected override bool OnCheckFindOpposite()
		{
			ULGUIBehaviour selectable = this.Selectable;
			UUIItem uuiitem = (selectable != null) ? selectable.GetRootComponent() : null;
			ULGUICanvas ulguicanvas = (uuiitem != null) ? uuiitem.GetRenderCanvas() : null;
			return ulguicanvas != null && ulguicanvas.IsUIVisible(uuiitem);
		}
	}
}
