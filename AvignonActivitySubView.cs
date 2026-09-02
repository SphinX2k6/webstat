using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020011CB RID: 4555
public class AvignonActivitySubView : ActivitySubViewBase
{
	// Token: 0x0600782B RID: 30763 RVA: 0x001F6EFB File Offset: 0x001F50FB
	protected override void OnSetData()
	{
		this.ActivityData = (AvignonProtocolData)this.ActivityBaseData;
	}

	// Token: 0x0600782C RID: 30764 RVA: 0x001F6F10 File Offset: 0x001F5110
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600782D RID: 30765 RVA: 0x001F6F9C File Offset: 0x001F519C
	protected override UniTask OnBeforeStartAsync()
	{
		AvignonActivitySubView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<AvignonActivitySubView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600782E RID: 30766 RVA: 0x001F6FE0 File Offset: 0x001F51E0
	protected override void OnRefreshView()
	{
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshActivityTab, this.ActivityData.Id);
		this.CommonInfoPanel.SetFunctionRedDotVisible(ModelBase<AvignonModel>.Instance.CheckRedDot() || this.ActivityData.HasStageRewardRedDot());
		ActivitySubViewGeneralInfo commonInfoPanel = this.CommonInfoPanel;
		if (commonInfoPanel == null)
		{
			return;
		}
		commonInfoPanel.OnRefreshView();
	}

	// Token: 0x0600782F RID: 30767 RVA: 0x001F703D File Offset: 0x001F523D
	[NullableContext(2)]
	private void OnConfirmBtnClick(ActivityBaseData _)
	{
		ModelBase<AvignonModel>.Instance.ReadRedDot();
		Singleton<UiManager>.Instance.OpenView(EUiViewName.AvignonActivityMainView, this.ActivityData, null);
	}

	// Token: 0x04003A11 RID: 14865
	[Nullable(2)]
	protected AvignonProtocolData ActivityData;

	// Token: 0x04003A12 RID: 14866
	[Nullable(1)]
	protected ActivitySubViewGeneralInfo CommonInfoPanel;

	// Token: 0x02007521 RID: 29985
	private class EComponents
	{
		// Token: 0x040286EA RID: 165610
		public const int CommonActionInfo = 0;

		// Token: 0x040286EB RID: 165611
		public const int ItemFemale = 1;

		// Token: 0x040286EC RID: 165612
		public const int ItemMale = 2;
	}
}
