using System;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D32 RID: 19762
	public class NavigationGroupPrevComponent : NavigationGroupPrevComponentBase
	{
		// Token: 0x06033513 RID: 210195 RVA: 0x00CD7449 File Offset: 0x00CD5649
		public NavigationGroupPrevComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x06033514 RID: 210196 RVA: 0x00CD7452 File Offset: 0x00CD5652
		protected override ENavigationDirectionType GetDirection()
		{
			return ENavigationDirectionType.Left;
		}
	}
}
