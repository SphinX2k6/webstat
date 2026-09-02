using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x02002A39 RID: 10809
public class SkinTabItem : CommonTabItem, ITabViewRegister
{
	// Token: 0x06015A14 RID: 88596 RVA: 0x00600598 File Offset: 0x005FE798
	public override void BindRedDot(ERedDotName redDotName, int? uId = 0)
	{
		int? num = uId;
		int num2 = 0;
		if (!(num.GetValueOrDefault() == num2 & num != null) && uId != null)
		{
			ControllerBase<RedDotController>.Instance.UnBindRedDotAndClearData(redDotName);
		}
		base.BindRedDot(redDotName, uId);
	}

	// Token: 0x06015A15 RID: 88597 RVA: 0x006005D9 File Offset: 0x005FE7D9
	[NullableContext(1)]
	public void RegisterViewModule(UiTabViewBase tabView)
	{
		tabView.AddUiTabViewBehavior<UiTabCamera>().SetTabData((EUiTabViewName)tabView.GetViewName());
		tabView.AddUiTabViewBehavior<UiTabSequence>().SetRootItem(tabView);
	}
}
