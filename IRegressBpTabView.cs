using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x0200152D RID: 5421
[NullableContext(1)]
public interface IRegressBpTabView
{
	// Token: 0x060097E5 RID: 38885
	void RefreshView(bool playAnim = false);

	// Token: 0x060097E6 RID: 38886
	void RefreshBtnClaimVisible(UUIItem uiItem);

	// Token: 0x060097E7 RID: 38887
	void OnClickBtnClaimAll();
}
