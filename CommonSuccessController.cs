using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x02001A57 RID: 6743
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class CommonSuccessController : UiControllerBase<CommonSuccessController>
{
	// Token: 0x0600C0BB RID: 49339 RVA: 0x0032D824 File Offset: 0x0032BA24
	public static void OpenCommonSuccessView(CommonSuccessData data = null, Action finishCallback = null)
	{
		CommonSuccessData param = data ?? new CommonSuccessData();
		Singleton<UiManager>.Instance.OpenView(EUiViewName.CommonSuccessView, param, delegate(bool success, int viewId)
		{
			Action finishCallback2 = finishCallback;
			if (finishCallback2 == null)
			{
				return;
			}
			finishCallback2();
		});
	}
}
