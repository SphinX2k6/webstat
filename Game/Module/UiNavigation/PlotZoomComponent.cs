using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Input;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D44 RID: 19780
	public class PlotZoomComponent : PlotInteractComponentBase
	{
		// Token: 0x06033555 RID: 210261 RVA: 0x00CD7F64 File Offset: 0x00CD6164
		public PlotZoomComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x06033556 RID: 210262 RVA: 0x00CD7F6D File Offset: 0x00CD616D
		[NullableContext(1)]
		protected override void OnInputAxis(string axisName, float value)
		{
			Singleton<EventSystem>.Instance.Emit<float>(EEventName.NavigationTriggerPlotZoom, value * 30f);
		}

		// Token: 0x06033557 RID: 210263 RVA: 0x00CD7F86 File Offset: 0x00CD6186
		protected override bool CheckAxisCanInput()
		{
			return !ModelBase<InputModel>.Instance.IsAxisBlock(EInputAxis.Zoom);
		}
	}
}
