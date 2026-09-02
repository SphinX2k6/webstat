using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002D44 RID: 11588
public class WeeklyRogueEnvironmentTips : UiViewBase
{
	// Token: 0x06017615 RID: 95765 RVA: 0x0067BCA3 File Offset: 0x00679EA3
	[NullableContext(1)]
	public WeeklyRogueEnvironmentTips(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x06017616 RID: 95766 RVA: 0x0067BCAC File Offset: 0x00679EAC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action(this.OnBtnBack))
		};
	}

	// Token: 0x06017617 RID: 95767 RVA: 0x0067BD14 File Offset: 0x00679F14
	protected override void OnBeforeShow()
	{
		RogueWeeklyCycle value = ModelBase<WeeklyRogueModel>.Instance.ActivityData.GetCycleConfig().Value;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), value.BuffDesc, value.BuffDescParam());
	}

	// Token: 0x06017618 RID: 95768 RVA: 0x0067BD58 File Offset: 0x00679F58
	private void OnBtnBack()
	{
		base.CloseMe(null);
	}

	// Token: 0x0200900C RID: 36876
	private enum EComponent
	{
		// Token: 0x0403054D RID: 197965
		TxtContent,
		// Token: 0x0403054E RID: 197966
		BtnBack
	}
}
