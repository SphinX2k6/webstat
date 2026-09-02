using System;
using System.Collections.Generic;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001541 RID: 5441
public class ActivityRecallCaptionPanel : UiPanelBase
{
	// Token: 0x060098A9 RID: 39081 RVA: 0x0027FD4C File Offset: 0x0027DF4C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(4, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(3, new Action(this.OnBackBtnClick))
		};
	}

	// Token: 0x060098AA RID: 39082 RVA: 0x0027FDF5 File Offset: 0x0027DFF5
	private void OnBackBtnClick()
	{
		Singleton<UiManager>.Instance.CloseView(EUiViewName.ActivityRegressMainView, null);
	}

	// Token: 0x060098AB RID: 39083 RVA: 0x0027FE08 File Offset: 0x0027E008
	public void RefreshData(RegressBase config)
	{
		UUIText text = base.GetText(1);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, config.Title ?? "", Array.Empty<object>());
	}

	// Token: 0x020078FB RID: 30971
	private class EActivityRecallCaptionPanelComponents
	{
		// Token: 0x0402994D RID: 170317
		public const int TitleIcon = 0;

		// Token: 0x0402994E RID: 170318
		public const int TitleTxt = 1;

		// Token: 0x0402994F RID: 170319
		public const int HelpInfoBtn = 2;

		// Token: 0x04029950 RID: 170320
		public const int BackBtn = 3;

		// Token: 0x04029951 RID: 170321
		public const int CostPanel = 4;
	}
}
