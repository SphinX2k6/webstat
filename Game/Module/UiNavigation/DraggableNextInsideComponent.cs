using System;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CF4 RID: 19700
	public class DraggableNextInsideComponent : DraggableInsideComponent
	{
		// Token: 0x060333EE RID: 209902 RVA: 0x00CD49DE File Offset: 0x00CD2BDE
		public DraggableNextInsideComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060333EF RID: 209903 RVA: 0x00CD49E7 File Offset: 0x00CD2BE7
		protected override void TriggerEvent()
		{
			ControllerBase<UiNavigationNewController>.Instance.DraggableInsideComponentNavigate(base.GetBindButtonTag(), true);
		}
	}
}
