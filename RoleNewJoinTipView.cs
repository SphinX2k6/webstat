using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x020028FB RID: 10491
public class RoleNewJoinTipView : UiViewBase
{
	// Token: 0x06014D64 RID: 85348 RVA: 0x005C5804 File Offset: 0x005C3A04
	[NullableContext(1)]
	public RoleNewJoinTipView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06014D65 RID: 85349 RVA: 0x005C580D File Offset: 0x005C3A0D
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>();
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>();
	}

	// Token: 0x06014D66 RID: 85350 RVA: 0x005C5828 File Offset: 0x005C3A28
	protected override void OnAfterPlayStartSequence()
	{
		int num = (int)(this.OpenParam ?? 0);
		Singleton<UiManager>.Instance.CloseAndOpenView(this.ViewInfo.Name, EUiViewName.RoleNewJoinView, num, null, true);
	}
}
