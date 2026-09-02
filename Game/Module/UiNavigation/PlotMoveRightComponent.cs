using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Input;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D43 RID: 19779
	public class PlotMoveRightComponent : PlotInteractComponentBase
	{
		// Token: 0x06033552 RID: 210258 RVA: 0x00CD7F2E File Offset: 0x00CD612E
		public PlotMoveRightComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x06033553 RID: 210259 RVA: 0x00CD7F37 File Offset: 0x00CD6137
		[NullableContext(1)]
		protected override void OnInputAxis(string axisName, float value)
		{
			Singleton<EventSystem>.Instance.Emit<float>(EEventName.NavigationTriggerPlotRight, value * 0.7f);
		}

		// Token: 0x06033554 RID: 210260 RVA: 0x00CD7F50 File Offset: 0x00CD6150
		protected override bool CheckAxisCanInput()
		{
			return !ModelBase<InputModel>.Instance.IsAxisBlock(EInputAxis.Turn);
		}
	}
}
