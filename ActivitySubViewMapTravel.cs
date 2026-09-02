using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200138B RID: 5003
[NullableContext(2)]
[Nullable(0)]
public class ActivitySubViewMapTravel : ActivitySubViewBase
{
	// Token: 0x17000BBC RID: 3004
	// (get) Token: 0x06008988 RID: 35208 RVA: 0x00242FD5 File Offset: 0x002411D5
	// (set) Token: 0x06008989 RID: 35209 RVA: 0x00242FDD File Offset: 0x002411DD
	protected ActivityMapTravelData ActivityData { get; set; }

	// Token: 0x17000BBD RID: 3005
	// (get) Token: 0x0600898A RID: 35210 RVA: 0x00242FE6 File Offset: 0x002411E6
	// (set) Token: 0x0600898B RID: 35211 RVA: 0x00242FEE File Offset: 0x002411EE
	protected ActivitySubViewGeneralInfo GeneralActivityInfo { get; set; }

	// Token: 0x17000BBE RID: 3006
	// (get) Token: 0x0600898C RID: 35212 RVA: 0x00242FF7 File Offset: 0x002411F7
	// (set) Token: 0x0600898D RID: 35213 RVA: 0x00242FFF File Offset: 0x002411FF
	private MapTravelExpComponent ExpComponent { get; set; }

	// Token: 0x0600898E RID: 35214 RVA: 0x00243008 File Offset: 0x00241208
	protected override void OnSetData()
	{
		this.ActivityData = (ActivityMapTravelData)this.ActivityBaseData;
	}

	// Token: 0x0600898F RID: 35215 RVA: 0x0024301C File Offset: 0x0024121C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06008990 RID: 35216 RVA: 0x002430C8 File Offset: 0x002412C8
	protected override UniTask OnBeforeStartAsync()
	{
		ActivitySubViewMapTravel.<OnBeforeStartAsync>d__15 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivitySubViewMapTravel.<OnBeforeStartAsync>d__15>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06008991 RID: 35217 RVA: 0x0024310B File Offset: 0x0024130B
	protected override void OnRefreshView()
	{
		this.RefreshExpComponent();
		this.RefreshButton();
	}

	// Token: 0x06008992 RID: 35218 RVA: 0x00243119 File Offset: 0x00241319
	private void OnBtnClick(ActivityBaseData _)
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.MapTravelMainView, this.ActivityData, null);
	}

	// Token: 0x06008993 RID: 35219 RVA: 0x00243134 File Offset: 0x00241334
	private void RefreshExpComponent()
	{
		this.ExpComponent.SetProgress(this.ActivityData.GetCurrentExp(), this.ActivityData.GetCurrentTargetExp(), this.ActivityData.TravelLevel == this.ActivityData.MaxTravelLevel);
		this.ExpComponent.SetLevel(this.ActivityData.TravelLevel);
	}

	// Token: 0x06008994 RID: 35220 RVA: 0x00243190 File Offset: 0x00241390
	private void RefreshButton()
	{
		this.GeneralActivityInfo.SetFunctionRedDotVisible(this.ActivityData.RedPointShowState);
	}

	// Token: 0x02007728 RID: 30504
	[NullableContext(0)]
	private class EViewDefine
	{
		// Token: 0x0402907F RID: 168063
		public const int CommonActivityInfo = 0;

		// Token: 0x04029080 RID: 168064
		public const int ProgressItem = 1;

		// Token: 0x04029081 RID: 168065
		public const int PanelMale = 2;

		// Token: 0x04029082 RID: 168066
		public const int PanelFemale = 3;
	}
}
