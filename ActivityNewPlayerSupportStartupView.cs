using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001475 RID: 5237
public class ActivityNewPlayerSupportStartupView : UiViewBase
{
	// Token: 0x0600927C RID: 37500 RVA: 0x0026A1E6 File Offset: 0x002683E6
	[NullableContext(1)]
	public ActivityNewPlayerSupportStartupView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600927D RID: 37501 RVA: 0x0026A1F0 File Offset: 0x002683F0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnCloseBtnClick))
		};
	}

	// Token: 0x0600927E RID: 37502 RVA: 0x0026A241 File Offset: 0x00268441
	protected override void OnBeforeShow()
	{
		ActivityNewPlayerSupportData activityData = ControllerBase<ActivityNewPlayerSupportController>.Instance.ActivityData;
		ControllerBase<SplashScreenController>.Instance.FinishCurTask(ESplashScreenSourceModuleType.NewPlayerSupport);
		activityData.RecordActivityFirstShow();
		activityData.AlreadyStartView = true;
	}

	// Token: 0x0600927F RID: 37503 RVA: 0x0026A264 File Offset: 0x00268464
	private void OnCloseBtnClick()
	{
		this.GotoActivityViewAndCloseSelf();
	}

	// Token: 0x06009280 RID: 37504 RVA: 0x0026A26C File Offset: 0x0026846C
	private void GotoActivityViewAndCloseSelf()
	{
		base.CloseMe(null);
		int id = ControllerBase<ActivityNewPlayerSupportController>.Instance.ActivityData.Id;
		if (id != 0)
		{
			ControllerBase<ActivityController>.Instance.OpenActivityById(id, EActivityViewOpenType.Other, null, null);
		}
	}

	// Token: 0x02007875 RID: 30837
	private static class EComponentType
	{
		// Token: 0x040296D7 RID: 169687
		public const int CloseBtn = 0;
	}
}
