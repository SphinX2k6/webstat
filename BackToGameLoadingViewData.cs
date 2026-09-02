using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.UI.Module.Loading.View;

// Token: 0x020020E3 RID: 8419
public class BackToGameLoadingViewData
{
	// Token: 0x0601015B RID: 65883 RVA: 0x0046A18D File Offset: 0x0046838D
	public void RebootFinished()
	{
		this.LoadingWidget.RebootFinished();
	}

	// Token: 0x0601015C RID: 65884 RVA: 0x0046A19A File Offset: 0x0046839A
	public void SetProgress(float progress)
	{
		this.LoadingWidget.UpdateOtherLoadingProgerss(progress);
	}

	// Token: 0x0601015D RID: 65885 RVA: 0x0046A1A8 File Offset: 0x004683A8
	public void Close()
	{
		WBP_UILoading_C loadingWidget = this.LoadingWidget;
		if (loadingWidget == null || !loadingWidget.IsValid())
		{
			return;
		}
		this.LoadingWidget.RemoveFromParent();
	}

	// Token: 0x04007B4F RID: 31567
	[Nullable(2)]
	public WBP_UILoading_C LoadingWidget;
}
