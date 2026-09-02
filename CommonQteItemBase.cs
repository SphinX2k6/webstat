using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x0200261E RID: 9758
[NullableContext(1)]
[Nullable(0)]
public abstract class CommonQteItemBase : UiPanelBase
{
	// Token: 0x060132D9 RID: 78553
	public abstract void SetQteContext(CommonQteContextBase context);

	// Token: 0x060132DA RID: 78554
	public abstract void PlayQteStart();

	// Token: 0x060132DB RID: 78555
	public abstract void OnInputTest();

	// Token: 0x060132DC RID: 78556 RVA: 0x00552F75 File Offset: 0x00551175
	public virtual void SetPreloadQte(int qteId)
	{
	}

	// Token: 0x060132DD RID: 78557
	public abstract void Reattach(CommonQteContextBase context);
}
