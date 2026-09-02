using System;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CF0 RID: 19696
	public class DraggablePrevComponent : DraggableComponent
	{
		// Token: 0x060333E6 RID: 209894 RVA: 0x00CD492C File Offset: 0x00CD2B2C
		public DraggablePrevComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060333E7 RID: 209895 RVA: 0x00CD4935 File Offset: 0x00CD2B35
		protected override void TriggerEvent()
		{
			ControllerBase<UiNavigationNewController>.Instance.DraggableComponentNavigate(base.GetBindButtonTag(), false);
		}
	}
}
