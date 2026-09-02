using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x0200132E RID: 4910
public class FightPhotoLoadingView : UiViewBase
{
	// Token: 0x060085EB RID: 34283 RVA: 0x00234557 File Offset: 0x00232757
	[NullableContext(1)]
	public FightPhotoLoadingView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060085EC RID: 34284 RVA: 0x00234560 File Offset: 0x00232760
	protected override void OnAfterShow()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.FightPhotoMainView, this.OpenParam, delegate(bool _, int _)
		{
			base.CloseMe(null);
		});
	}
}
