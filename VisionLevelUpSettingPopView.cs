using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002525 RID: 9509
public class VisionLevelUpSettingPopView : UiViewBase
{
	// Token: 0x060127CD RID: 75725 RVA: 0x00517125 File Offset: 0x00515325
	[NullableContext(1)]
	public VisionLevelUpSettingPopView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060127CE RID: 75726 RVA: 0x00517130 File Offset: 0x00515330
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(2, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(3, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(7, typeof(UUIExtendToggle))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnAllInModeToggleClick)),
			new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.OnStepInModeToggleClick)),
			new ValueTuple<int, Delegate>(2, new Action<EToggleState>(this.OnOnlyLevelUpMaterialToggleClick)),
			new ValueTuple<int, Delegate>(3, new Action<EToggleState>(this.OnBothLevelUpMaterialAndVisionToggleClick)),
			new ValueTuple<int, Delegate>(4, new Action(this.OnCancelButtonClick)),
			new ValueTuple<int, Delegate>(5, new Action(this.OnConfirmButtonClick)),
			new ValueTuple<int, Delegate>(6, new Action<EToggleState>(this.OnDisableIdentifyToggleClick)),
			new ValueTuple<int, Delegate>(7, new Action<EToggleState>(this.OnEnableIdentifyToggleClick))
		};
	}

	// Token: 0x060127CF RID: 75727 RVA: 0x005172C3 File Offset: 0x005154C3
	private void OnDisableIdentifyToggleClick(EToggleState toggleState)
	{
		this.SetIdentify(EVisionLevelUpIdentify.DisableIdentify);
	}

	// Token: 0x060127D0 RID: 75728 RVA: 0x005172CC File Offset: 0x005154CC
	private void OnEnableIdentifyToggleClick(EToggleState toggleState)
	{
		this.SetIdentify(EVisionLevelUpIdentify.EnableIdentify);
	}

	// Token: 0x060127D1 RID: 75729 RVA: 0x005172D5 File Offset: 0x005154D5
	private void OnAllInModeToggleClick(EToggleState toggleState)
	{
		this.SetPutInMode(EVisionLevelUpMaterialPutInMode.AllIn);
	}

	// Token: 0x060127D2 RID: 75730 RVA: 0x005172DE File Offset: 0x005154DE
	private void OnStepInModeToggleClick(EToggleState toggleState)
	{
		this.SetPutInMode(EVisionLevelUpMaterialPutInMode.StepIn);
	}

	// Token: 0x060127D3 RID: 75731 RVA: 0x005172E7 File Offset: 0x005154E7
	private void OnOnlyLevelUpMaterialToggleClick(EToggleState toggleState)
	{
		this.SetUseType(EVisionLevelUpMaterialUseType.OnlyLevelUpMaterial);
	}

	// Token: 0x060127D4 RID: 75732 RVA: 0x005172F0 File Offset: 0x005154F0
	private void OnBothLevelUpMaterialAndVisionToggleClick(EToggleState toggleState)
	{
		this.SetUseType(EVisionLevelUpMaterialUseType.BothLevelUpMaterialAndVision);
	}

	// Token: 0x060127D5 RID: 75733 RVA: 0x005172F9 File Offset: 0x005154F9
	private void OnCancelButtonClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x060127D6 RID: 75734 RVA: 0x00517302 File Offset: 0x00515502
	private void OnConfirmButtonClick()
	{
		this.SaveSetting();
		base.CloseMe(null);
	}

	// Token: 0x060127D7 RID: 75735 RVA: 0x00517314 File Offset: 0x00515514
	protected override void OnStart()
	{
		PhantomBattleModel instance = ModelBase<PhantomBattleModel>.Instance;
		this.PutInMode = instance.GetVisionLevelUpMaterialPutInMode();
		this.UseType = instance.GetVisionLevelUpMaterialUseType();
		this.Identify = instance.GetVisionLevelUpIdentify();
		this.Refresh();
	}

	// Token: 0x060127D8 RID: 75736 RVA: 0x00517351 File Offset: 0x00515551
	public void Refresh()
	{
		this.RefreshPutInModeToggle();
		this.RefreshUseTypeToggle();
		this.RefreshIdentifyToggle();
	}

	// Token: 0x060127D9 RID: 75737 RVA: 0x00517368 File Offset: 0x00515568
	public void RefreshUseTypeToggle()
	{
		EToggleState? etoggleState = null;
		EToggleState? etoggleState2 = null;
		if (this.UseType == EVisionLevelUpMaterialUseType.OnlyLevelUpMaterial)
		{
			etoggleState = new EToggleState?(EToggleState.ETT_Checked);
			etoggleState2 = new EToggleState?(EToggleState.ETT_UnChecked);
		}
		else
		{
			etoggleState = new EToggleState?(EToggleState.ETT_UnChecked);
			etoggleState2 = new EToggleState?(EToggleState.ETT_Checked);
		}
		UUIExtendToggle extendToggle = base.GetExtendToggle(2);
		if (extendToggle != null)
		{
			extendToggle.SetToggleState(etoggleState.Value, false, false, false);
		}
		UUIExtendToggle extendToggle2 = base.GetExtendToggle(3);
		if (extendToggle2 == null)
		{
			return;
		}
		extendToggle2.SetToggleState(etoggleState2.Value, false, false, false);
	}

	// Token: 0x060127DA RID: 75738 RVA: 0x005173E8 File Offset: 0x005155E8
	public void RefreshPutInModeToggle()
	{
		EToggleState? etoggleState = null;
		EToggleState? etoggleState2 = null;
		if (this.PutInMode == EVisionLevelUpMaterialPutInMode.AllIn)
		{
			etoggleState = new EToggleState?(EToggleState.ETT_Checked);
			etoggleState2 = new EToggleState?(EToggleState.ETT_UnChecked);
		}
		else
		{
			etoggleState = new EToggleState?(EToggleState.ETT_UnChecked);
			etoggleState2 = new EToggleState?(EToggleState.ETT_Checked);
		}
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle != null)
		{
			extendToggle.SetToggleState(etoggleState.Value, false, false, false);
		}
		UUIExtendToggle extendToggle2 = base.GetExtendToggle(1);
		if (extendToggle2 == null)
		{
			return;
		}
		extendToggle2.SetToggleState(etoggleState2.Value, false, false, false);
	}

	// Token: 0x060127DB RID: 75739 RVA: 0x00517468 File Offset: 0x00515668
	public void RefreshIdentifyToggle()
	{
		EToggleState? etoggleState = null;
		EToggleState? etoggleState2 = null;
		if (this.Identify == EVisionLevelUpIdentify.DisableIdentify)
		{
			etoggleState = new EToggleState?(EToggleState.ETT_Checked);
			etoggleState2 = new EToggleState?(EToggleState.ETT_UnChecked);
		}
		else
		{
			etoggleState = new EToggleState?(EToggleState.ETT_UnChecked);
			etoggleState2 = new EToggleState?(EToggleState.ETT_Checked);
		}
		UUIExtendToggle extendToggle = base.GetExtendToggle(6);
		if (extendToggle != null)
		{
			extendToggle.SetToggleState(etoggleState.Value, false, false, false);
		}
		UUIExtendToggle extendToggle2 = base.GetExtendToggle(7);
		if (extendToggle2 == null)
		{
			return;
		}
		extendToggle2.SetToggleState(etoggleState2.Value, false, false, false);
	}

	// Token: 0x060127DC RID: 75740 RVA: 0x005174E8 File Offset: 0x005156E8
	protected void SetPutInMode(EVisionLevelUpMaterialPutInMode mode)
	{
		this.PutInMode = mode;
		this.RefreshPutInModeToggle();
	}

	// Token: 0x060127DD RID: 75741 RVA: 0x005174F7 File Offset: 0x005156F7
	protected void SetUseType(EVisionLevelUpMaterialUseType useType)
	{
		this.UseType = useType;
		this.RefreshUseTypeToggle();
	}

	// Token: 0x060127DE RID: 75742 RVA: 0x00517506 File Offset: 0x00515706
	protected void SetIdentify(EVisionLevelUpIdentify identify)
	{
		this.Identify = identify;
		this.RefreshIdentifyToggle();
	}

	// Token: 0x060127DF RID: 75743 RVA: 0x00517515 File Offset: 0x00515715
	protected void SaveSetting()
	{
		PhantomBattleModel instance = ModelBase<PhantomBattleModel>.Instance;
		instance.SetVisionLevelUpMaterialPutInMode(this.PutInMode);
		instance.SetVisionLevelUpMaterialUseType(this.UseType);
		instance.SetVisionLevelUpIdentify(this.Identify);
	}

	// Token: 0x04009034 RID: 36916
	private EVisionLevelUpMaterialPutInMode PutInMode;

	// Token: 0x04009035 RID: 36917
	private EVisionLevelUpMaterialUseType UseType;

	// Token: 0x04009036 RID: 36918
	private EVisionLevelUpIdentify Identify;

	// Token: 0x02008847 RID: 34887
	private enum EComponent
	{
		// Token: 0x0402E075 RID: 188533
		AllInModeToggle,
		// Token: 0x0402E076 RID: 188534
		StepInModeToggle,
		// Token: 0x0402E077 RID: 188535
		OnlyLevelUpMaterialToggle,
		// Token: 0x0402E078 RID: 188536
		BothLevelUpMaterialAndVisionToggle,
		// Token: 0x0402E079 RID: 188537
		CancelButton,
		// Token: 0x0402E07A RID: 188538
		ConfirmButton,
		// Token: 0x0402E07B RID: 188539
		DisableIdentifyToggle,
		// Token: 0x0402E07C RID: 188540
		EnableIdentifyToggle
	}
}
