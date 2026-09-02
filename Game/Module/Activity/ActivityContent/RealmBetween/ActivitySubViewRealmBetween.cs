using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RealmBetween
{
	// Token: 0x02006533 RID: 25907
	[NullableContext(2)]
	[Nullable(0)]
	public class ActivitySubViewRealmBetween : ActivitySubViewBase
	{
		// Token: 0x17009E9D RID: 40605
		// (get) Token: 0x06040C7C RID: 265340 RVA: 0x0109C51F File Offset: 0x0109A71F
		protected new ActivityRealmBetweenData ActivityBaseData
		{
			get
			{
				return this.ActivityBaseData as ActivityRealmBetweenData;
			}
		}

		// Token: 0x06040C7D RID: 265341 RVA: 0x0109C52C File Offset: 0x0109A72C
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

		// Token: 0x06040C7E RID: 265342 RVA: 0x0109C59C File Offset: 0x0109A79C
		protected override UniTask OnBeforeStartAsync()
		{
			ActivitySubViewRealmBetween.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<ActivitySubViewRealmBetween.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040C7F RID: 265343 RVA: 0x0109C5DF File Offset: 0x0109A7DF
		protected override void OnRefreshView()
		{
			this.RefreshExpComponent();
			this.RefreshButton();
		}

		// Token: 0x06040C80 RID: 265344 RVA: 0x0109C5ED File Offset: 0x0109A7ED
		private void OnBtnClick(ActivityBaseData _)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RealmBetweenMainView, this.ActivityBaseData, null);
		}

		// Token: 0x06040C81 RID: 265345 RVA: 0x0109C608 File Offset: 0x0109A808
		private void RefreshExpComponent()
		{
			this.ExpComponent.SetProgress(this.ActivityBaseData.GetCurrentExp(), this.ActivityBaseData.GetCurrentTargetExp(), this.ActivityBaseData.TravelLevel == this.ActivityBaseData.MaxTravelLevel);
			this.ExpComponent.SetLevel(this.ActivityBaseData.TravelLevel);
		}

		// Token: 0x06040C82 RID: 265346 RVA: 0x0109C664 File Offset: 0x0109A864
		private void RefreshButton()
		{
			this.GeneralActivityInfo.SetFunctionRedDotVisible(this.ActivityBaseData.RedPointShowState);
		}

		// Token: 0x0402453C RID: 148796
		protected ActivitySubViewGeneralInfo GeneralActivityInfo;

		// Token: 0x0402453D RID: 148797
		protected RealmBetweenExpComponent ExpComponent;
	}
}
