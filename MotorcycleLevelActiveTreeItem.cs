using System;
using System.Collections.Generic;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200228D RID: 8845
public class MotorcycleLevelActiveTreeItem : UiPanelBase
{
	// Token: 0x06010B90 RID: 68496 RVA: 0x00494638 File Offset: 0x00492838
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(2, new Action(this.OnBtnShowDetailClick))
		};
	}

	// Token: 0x06010B91 RID: 68497 RVA: 0x004946B8 File Offset: 0x004928B8
	public void Refresh()
	{
		int curTreeType = ModelBase<MotorcycleDevelopModel>.Instance.GetCurTreeType();
		MotorTechTree? motorTechTreeConfig = ConfigBase<MotorConfig>.Instance.GetMotorTechTreeConfig(curTreeType);
		base.SetTextureByPath(motorTechTreeConfig.Value.Icon, base.GetTexture(0), null, null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), motorTechTreeConfig.Value.Name, Array.Empty<object>());
	}

	// Token: 0x06010B92 RID: 68498 RVA: 0x00494728 File Offset: 0x00492928
	private void OnBtnShowDetailClick()
	{
		int curTreeType = ModelBase<MotorcycleDevelopModel>.Instance.GetCurTreeType();
		Singleton<UiManager>.Instance.OpenView(EUiViewName.MotorcycleTechTreeDetailView, curTreeType, null);
	}

	// Token: 0x02008558 RID: 34136
	private class EMotorLevelActiveTreeItemComponent
	{
		// Token: 0x0402D1FA RID: 184826
		public const int TexIcon = 0;

		// Token: 0x0402D1FB RID: 184827
		public const int TxtName = 1;

		// Token: 0x0402D1FC RID: 184828
		public const int BtnShowDetail = 2;
	}
}
