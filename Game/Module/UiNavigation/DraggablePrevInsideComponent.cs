using System;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CF3 RID: 19699
	public class DraggablePrevInsideComponent : DraggableInsideComponent
	{
		// Token: 0x060333EC RID: 209900 RVA: 0x00CD49C2 File Offset: 0x00CD2BC2
		public DraggablePrevInsideComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060333ED RID: 209901 RVA: 0x00CD49CB File Offset: 0x00CD2BCB
		protected override void TriggerEvent()
		{
			ControllerBase<UiNavigationNewController>.Instance.DraggableInsideComponentNavigate(base.GetBindButtonTag(), false);
		}
	}
}
