using System;
using System.Collections.Generic;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001F17 RID: 7959
public class HonamiStorySkillDescToggle : UiPanelBase
{
	// Token: 0x0600EE11 RID: 60945 RVA: 0x004105E4 File Offset: 0x0040E7E4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickedToggle))
		};
	}

	// Token: 0x0600EE12 RID: 60946 RVA: 0x0041064B File Offset: 0x0040E84B
	protected override void OnStart()
	{
		this.RefreshState();
	}

	// Token: 0x0600EE13 RID: 60947 RVA: 0x00410654 File Offset: 0x0040E854
	public void RefreshState()
	{
		EToggleState state = ModelBase<HonamiStoryModel>.Instance.GetSkillDescMode() ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleState(state, false, false, false);
	}

	// Token: 0x0600EE14 RID: 60948 RVA: 0x00410688 File Offset: 0x0040E888
	private void OnClickedToggle(EToggleState toggleState)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		bool skillDescMode = extendToggle != null && extendToggle.GetToggleState() == EToggleState.ETT_Checked;
		ModelBase<HonamiStoryModel>.Instance.SetSkillDescMode(skillDescMode);
	}

	// Token: 0x02008285 RID: 33413
	private enum EToggle
	{
		// Token: 0x0402C457 RID: 181335
		Tog,
		// Token: 0x0402C458 RID: 181336
		Txt
	}
}
