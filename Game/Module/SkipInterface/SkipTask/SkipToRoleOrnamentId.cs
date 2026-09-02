using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.SkipInterface.SkipTask
{
	// Token: 0x02004F55 RID: 20309
	public class SkipToRoleOrnamentId : SkipTask
	{
		// Token: 0x0603460E RID: 214542 RVA: 0x00D1BEDC File Offset: 0x00D1A0DC
		protected override void OnRun([Nullable(new byte[]
		{
			1,
			2
		})] params object[] data)
		{
			if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.ItemTipsView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.ItemTipsView, null);
			}
			int ornamentId = Convert.ToInt32(data[0]);
			ControllerBase<RoleController>.Instance.OpenOrnamentPreviewView(ornamentId, null);
			base.Finish();
		}
	}
}
