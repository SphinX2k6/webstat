using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D1E RID: 19742
	public class MapZoomComponent : MapInteractComponentBase
	{
		// Token: 0x060334D0 RID: 210128 RVA: 0x00CD6CA4 File Offset: 0x00CD4EA4
		public MapZoomComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060334D1 RID: 210129 RVA: 0x00CD6CAD File Offset: 0x00CD4EAD
		[NullableContext(1)]
		protected override void OnInputAxis(string axisName, float value)
		{
			Singleton<EventSystem>.Instance.Emit<string, float>(EEventName.NavigationTriggerMapZoom, axisName, value);
		}
	}
}
