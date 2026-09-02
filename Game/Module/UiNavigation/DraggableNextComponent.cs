using System;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CF1 RID: 19697
	public class DraggableNextComponent : DraggableComponent
	{
		// Token: 0x060333E8 RID: 209896 RVA: 0x00CD4948 File Offset: 0x00CD2B48
		public DraggableNextComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060333E9 RID: 209897 RVA: 0x00CD4951 File Offset: 0x00CD2B51
		protected override void TriggerEvent()
		{
			ControllerBase<UiNavigationNewController>.Instance.DraggableComponentNavigate(base.GetBindButtonTag(), true);
		}
	}
}
