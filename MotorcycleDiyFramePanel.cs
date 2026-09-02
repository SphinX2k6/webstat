using System;
using System.Collections.Generic;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002300 RID: 8960
public class MotorcycleDiyFramePanel : UiPanelBase
{
	// Token: 0x06010FD7 RID: 69591 RVA: 0x004A8DF0 File Offset: 0x004A6FF0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUITexture)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnBtnEnterClick))
		};
	}

	// Token: 0x06010FD8 RID: 69592 RVA: 0x004A8EAF File Offset: 0x004A70AF
	protected override void OnStart()
	{
		this.SetEditable(true);
	}

	// Token: 0x06010FD9 RID: 69593 RVA: 0x004A8EB8 File Offset: 0x004A70B8
	public void Refresh(int frameId)
	{
		MotorFrame? motorFrameConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorFrameConfig(frameId);
		if (motorFrameConfig == null)
		{
			return;
		}
		base.SetTextureByPath(motorFrameConfig.Value.ModelIconPath, base.GetTexture(2), null, null);
		base.GetItem(4).SetUIActive(ModelBase<MotorcycleDiyModel>.Instance.RedDotHasNewFrameVisible());
	}

	// Token: 0x06010FDA RID: 69594 RVA: 0x004A8F17 File Offset: 0x004A7117
	public void SetEditable(bool isEditable)
	{
		base.GetItem(5).SetUIActive(!isEditable);
		base.GetTexture(2).SetUIActive(isEditable);
		base.GetTexture(3).SetUIActive(isEditable);
	}

	// Token: 0x06010FDB RID: 69595 RVA: 0x004A8F44 File Offset: 0x004A7144
	private void OnBtnEnterClick()
	{
		ModelBase<MotorcycleDiyModel>.Instance.ResetSelectedItemInfo();
		OpenMotorcycleDiyRootViewData param = new OpenMotorcycleDiyRootViewData
		{
			OpenTabView = new EUiTabViewName?(EUiTabViewName.MotorcycleDiyFrameTabView),
			PartTabIndex = new int?(1),
			IsNeedResetMotor = new bool?(true)
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.MotorcycleDiyRootView, param, null);
	}

	// Token: 0x020085F3 RID: 34291
	private class EMotorFrameComponent
	{
		// Token: 0x0402D4EA RID: 185578
		public const int BtnEnter = 0;

		// Token: 0x0402D4EB RID: 185579
		public const int TxtTitle = 1;

		// Token: 0x0402D4EC RID: 185580
		public const int TexIconBig = 2;

		// Token: 0x0402D4ED RID: 185581
		public const int TexIconSmall = 3;

		// Token: 0x0402D4EE RID: 185582
		public const int NewItem = 4;

		// Token: 0x0402D4EF RID: 185583
		public const int LockItem = 5;
	}
}
