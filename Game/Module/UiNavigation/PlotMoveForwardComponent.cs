using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Input;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D42 RID: 19778
	public class PlotMoveForwardComponent : PlotInteractComponentBase
	{
		// Token: 0x0603354F RID: 210255 RVA: 0x00CD7EF8 File Offset: 0x00CD60F8
		public PlotMoveForwardComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x06033550 RID: 210256 RVA: 0x00CD7F01 File Offset: 0x00CD6101
		[NullableContext(1)]
		protected override void OnInputAxis(string axisName, float value)
		{
			Singleton<EventSystem>.Instance.Emit<float>(EEventName.NavigationTriggerPlotForward, value * 0.7f);
		}

		// Token: 0x06033551 RID: 210257 RVA: 0x00CD7F1A File Offset: 0x00CD611A
		protected override bool CheckAxisCanInput()
		{
			return !ModelBase<InputModel>.Instance.IsAxisBlock(EInputAxis.LookUp);
		}
	}
}
