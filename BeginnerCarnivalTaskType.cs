using System;
using System.Collections.Generic;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001258 RID: 4696
public class BeginnerCarnivalTaskType : UiPanelBase
{
	// Token: 0x06007D34 RID: 32052 RVA: 0x0020FEC0 File Offset: 0x0020E0C0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnClickBtn))
		};
	}

	// Token: 0x06007D35 RID: 32053 RVA: 0x0020FF54 File Offset: 0x0020E154
	public void RefreshItem(int typeId)
	{
		this.TypeId = typeId;
		ValueTuple<int, int> progress = ControllerBase<BeginnerCarnivalController>.Instance.GetBeginnerCarnivalData().GetProgress(this.TypeId);
		bool flag = progress.Item1 == progress.Item2;
		base.GetText(1).SetUIActive(!flag);
		base.GetItem(2).SetUIActive(flag);
		if (!flag)
		{
			base.GetText(1).SetText("<color=#f5cf47>" + progress.Item1.ToString() + "</color>/" + progress.Item2.ToString(), true);
		}
		ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.BeginnerCarnivalTaskTabRedDot, base.GetItem(3), null, this.TypeId);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshBeginnerCarnivalTask, this.TypeId);
	}

	// Token: 0x06007D36 RID: 32054 RVA: 0x00210014 File Offset: 0x0020E214
	private void OnClickBtn()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.BeginnerCarnivalTaskView, this.TypeId, null);
	}

	// Token: 0x06007D37 RID: 32055 RVA: 0x00210031 File Offset: 0x0020E231
	protected override void OnBeforeDestroy()
	{
		ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.BeginnerCarnivalTaskTabRedDot, base.GetItem(3), this.TypeId);
	}

	// Token: 0x04003BF2 RID: 15346
	private int TypeId;
}
