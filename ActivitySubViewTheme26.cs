using System;
using CSharpScript.Game.Ui;

// Token: 0x02001365 RID: 4965
public class ActivitySubViewTheme26 : ActivitySubViewSevenHills
{
	// Token: 0x0600882E RID: 34862 RVA: 0x0023EE6F File Offset: 0x0023D06F
	protected override void OnConfirmBtnClick()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.Theme26MainView, this.ActivityData, null);
	}
}
