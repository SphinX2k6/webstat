using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RoadBook
{
	// Token: 0x02006490 RID: 25744
	[NullableContext(2)]
	[Nullable(0)]
	public class ActivitySubViewRoadBook : ActivitySubViewBase
	{
		// Token: 0x17009E5F RID: 40543
		// (get) Token: 0x06040925 RID: 264485 RVA: 0x0108D09E File Offset: 0x0108B29E
		protected new ActivityRoadBookData ActivityBaseData
		{
			get
			{
				return this.ActivityBaseData as ActivityRoadBookData;
			}
		}

		// Token: 0x06040926 RID: 264486 RVA: 0x0108D0AC File Offset: 0x0108B2AC
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

		// Token: 0x06040927 RID: 264487 RVA: 0x0108D11C File Offset: 0x0108B31C
		protected override UniTask OnBeforeStartAsync()
		{
			ActivitySubViewRoadBook.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<ActivitySubViewRoadBook.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040928 RID: 264488 RVA: 0x0108D15F File Offset: 0x0108B35F
		protected override void OnRefreshView()
		{
			this.RefreshExpComponent();
			this.RefreshButton();
		}

		// Token: 0x06040929 RID: 264489 RVA: 0x0108D16D File Offset: 0x0108B36D
		private void OnBtnClick(ActivityBaseData _)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RoadBookMainView, this.ActivityBaseData, null);
		}

		// Token: 0x0604092A RID: 264490 RVA: 0x0108D188 File Offset: 0x0108B388
		private void RefreshExpComponent()
		{
			this.ExpComponent.SetProgress(this.ActivityBaseData.GetCurrentExp(), this.ActivityBaseData.GetCurrentTargetExp(), this.ActivityBaseData.TravelLevel == this.ActivityBaseData.MaxTravelLevel);
			this.ExpComponent.SetLevel(this.ActivityBaseData.TravelLevel);
		}

		// Token: 0x0604092B RID: 264491 RVA: 0x0108D1E4 File Offset: 0x0108B3E4
		private void RefreshButton()
		{
			this.GeneralActivityInfo.SetFunctionRedDotVisible(this.ActivityBaseData.RedPointShowState);
		}

		// Token: 0x04024233 RID: 148019
		protected ActivitySubViewGeneralInfo GeneralActivityInfo;

		// Token: 0x04024234 RID: 148020
		protected RoadBookExpComponent ExpComponent;
	}
}
