using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D4A RID: 19786
	public class RoleTurnComponent : RoleInteractComponentBase
	{
		// Token: 0x0603356B RID: 210283 RVA: 0x00CD81DD File Offset: 0x00CD63DD
		public RoleTurnComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x0603356C RID: 210284 RVA: 0x00CD81E6 File Offset: 0x00CD63E6
		[NullableContext(1)]
		protected override void OnInputAxis(string axisName, float value)
		{
			Singleton<EventSystem>.Instance.Emit<float>(EEventName.NavigationTriggerRoleTurn, value);
		}
	}
}
