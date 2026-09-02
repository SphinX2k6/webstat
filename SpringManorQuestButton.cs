using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Activity.ActivityContent.SpringManor;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001D7C RID: 7548
public class SpringManorQuestButton : UiPanelBase
{
	// Token: 0x0600DE18 RID: 56856 RVA: 0x003BBBBC File Offset: 0x003B9DBC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnClickButton))
		};
	}

	// Token: 0x0600DE19 RID: 56857 RVA: 0x003BBC23 File Offset: 0x003B9E23
	private void OnClickButton()
	{
		Action clickCallback = this.ClickCallback;
		if (clickCallback == null)
		{
			return;
		}
		clickCallback();
	}

	// Token: 0x0600DE1A RID: 56858 RVA: 0x003BBC38 File Offset: 0x003B9E38
	public void RefreshRedDot()
	{
		SpringManorModel instance = ModelBase<SpringManorModel>.Instance;
		bool uiactive = instance != null && instance.ActivityData.HasAnySubQuestRedDot();
		UUIItem item = base.GetItem(1);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(uiactive);
	}

	// Token: 0x04006AA6 RID: 27302
	[Nullable(2)]
	public Action ClickCallback;

	// Token: 0x020080FC RID: 33020
	private static class ESpringManorQuestButton
	{
		// Token: 0x0402BDB9 RID: 179641
		public const int Button = 0;

		// Token: 0x0402BDBA RID: 179642
		public const int RedDot = 1;
	}
}
