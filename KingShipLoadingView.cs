using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x0200209B RID: 8347
public class KingShipLoadingView : UiViewBase
{
	// Token: 0x0600FEBC RID: 65212 RVA: 0x0045E74C File Offset: 0x0045C94C
	[NullableContext(1)]
	public KingShipLoadingView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600FEBD RID: 65213 RVA: 0x0045E758 File Offset: 0x0045C958
	protected override void OnStart()
	{
		UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
		if (uiViewSequence != null)
		{
			uiViewSequence.AddSequenceFinishEvent("Start", delegate(string _)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.KingShipMainView, this.OpenParam, null);
				UiBehaviorLevelSequence uiViewSequence3 = this.UiViewSequence;
				if (uiViewSequence3 == null)
				{
					return;
				}
				uiViewSequence3.PlaySequence("Close01", false, null);
			}, false);
		}
		UiBehaviorLevelSequence uiViewSequence2 = this.UiViewSequence;
		if (uiViewSequence2 == null)
		{
			return;
		}
		uiViewSequence2.AddSequenceFinishEvent("Close01", delegate(string _)
		{
			base.CloseMe(null);
		}, false);
	}
}
