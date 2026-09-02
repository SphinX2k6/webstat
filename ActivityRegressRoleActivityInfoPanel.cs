using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200154B RID: 5451
public class ActivityRegressRoleActivityInfoPanel : UiPanelBase
{
	// Token: 0x060098FB RID: 39163 RVA: 0x00280F8C File Offset: 0x0027F18C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem))
		};
	}

	// Token: 0x060098FC RID: 39164 RVA: 0x00280FFC File Offset: 0x0027F1FC
	protected override UniTask OnBeforeStartAsync()
	{
		ActivityRegressRoleActivityInfoPanel.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivityRegressRoleActivityInfoPanel.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060098FD RID: 39165 RVA: 0x0028103F File Offset: 0x0027F23F
	protected override void OnStart()
	{
		this.ActivityBottom.FunctionButton.SetFunction(new Action(this.OnGotoRoleBtnClick));
		this.ActivityBottom.FunctionButton.SetLocalTextNew("RecallActivity_Go", Array.Empty<object>());
	}

	// Token: 0x060098FE RID: 39166 RVA: 0x00281077 File Offset: 0x0027F277
	public void RefreshData(RegressBase config)
	{
		this.Config = new RegressBase?(config);
	}

	// Token: 0x060098FF RID: 39167 RVA: 0x00281088 File Offset: 0x0027F288
	private void OnGotoRoleBtnClick()
	{
		int gachaId = this.Config.Value.GachaId;
		if (ModelBase<GachaModel>.Instance.GetGachaInfo(gachaId) == null)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("RecallActivity_Tips_01", Array.Empty<object>());
		}
		ActivityRegressHelper.ReportRecallLog1024(EReportLogEventType.NewRole, 0);
		ControllerBase<GachaController>.Instance.OpenGachaView(gachaId);
	}

	// Token: 0x040046B2 RID: 18098
	private RegressBase? Config;

	// Token: 0x040046B3 RID: 18099
	[Nullable(2)]
	private ActivityFunctionalTypeA ActivityBottom;

	// Token: 0x02007907 RID: 30983
	private class EComponents
	{
		// Token: 0x0402997D RID: 170365
		public const int ComActivityTitle = 0;

		// Token: 0x0402997E RID: 170366
		public const int ComActivityDesc = 1;

		// Token: 0x0402997F RID: 170367
		public const int ComActivityReward = 2;

		// Token: 0x04029980 RID: 170368
		public const int ComActivityBottom = 3;
	}
}
