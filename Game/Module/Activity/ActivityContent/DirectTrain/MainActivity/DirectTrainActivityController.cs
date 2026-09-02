using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DirectTrain.MainActivity
{
	// Token: 0x0200694E RID: 26958
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class DirectTrainActivityController : ActivityControllerBase<DirectTrainActivityController>
	{
		// Token: 0x06042E70 RID: 274032 RVA: 0x0112C2F2 File Offset: 0x0112A4F2
		protected override bool OnInit()
		{
			return true;
		}

		// Token: 0x06042E71 RID: 274033 RVA: 0x0112C2F5 File Offset: 0x0112A4F5
		protected override bool OnClear()
		{
			return true;
		}

		// Token: 0x06042E72 RID: 274034 RVA: 0x0112C2F8 File Offset: 0x0112A4F8
		protected override void OnOpenView(ActivityBaseData data)
		{
		}

		// Token: 0x06042E73 RID: 274035 RVA: 0x0112C2FA File Offset: 0x0112A4FA
		protected override ActivityBaseData OnCreateActivityData(ActivityData data)
		{
			return new DirectTrainActivityData();
		}

		// Token: 0x06042E74 RID: 274036 RVA: 0x0112C301 File Offset: 0x0112A501
		protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
		{
			return new DirectTrainMainSubView();
		}

		// Token: 0x06042E75 RID: 274037 RVA: 0x0112C308 File Offset: 0x0112A508
		protected override string OnGetActivityResource(ActivityBaseData data)
		{
			return "UiItem_PlotArriveGuide";
		}

		// Token: 0x06042E76 RID: 274038 RVA: 0x0112C30F File Offset: 0x0112A50F
		protected override bool OnGetIsOpeningActivityRelativeView()
		{
			return false;
		}
	}
}
