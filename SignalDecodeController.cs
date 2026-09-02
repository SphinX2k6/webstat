using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x02002A12 RID: 10770
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class SignalDecodeController : ControllerBase<SignalDecodeController>
{
	// Token: 0x060157ED RID: 88045 RVA: 0x005F583E File Offset: 0x005F3A3E
	public void Open(string id)
	{
		ModelBase<SignalDecodeModel>.Instance.GameplayStart(id);
		Singleton<UiManager>.Instance.OpenView(EUiViewName.SignalDecodeView, null, null);
	}
}
