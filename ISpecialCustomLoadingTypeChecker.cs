using System;
using CSharpScript.Game.Ui;

// Token: 0x020020D3 RID: 8403
public interface ISpecialCustomLoadingTypeChecker
{
	// Token: 0x060100E7 RID: 65767
	bool CanHandle(int instanceId);

	// Token: 0x060100E8 RID: 65768
	EUiViewName? GetLoadingViewName(int instanceId);
}
