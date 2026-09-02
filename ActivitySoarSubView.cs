using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020015BB RID: 5563
[NullableContext(2)]
[Nullable(0)]
public class ActivitySoarSubView : ActivitySubViewBase
{
	// Token: 0x06009CC3 RID: 40131 RVA: 0x00290D7C File Offset: 0x0028EF7C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 8;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUINiagara));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06009CC4 RID: 40132 RVA: 0x00290EAB File Offset: 0x0028F0AB
	protected override void OnSetData()
	{
		this.ActivityData = (ActivitySoarData)this.ActivityBaseData;
	}

	// Token: 0x06009CC5 RID: 40133 RVA: 0x00290EC0 File Offset: 0x0028F0C0
	protected override UniTask OnBeforeStartAsync()
	{
		ActivitySoarSubView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivitySoarSubView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009CC6 RID: 40134 RVA: 0x00290F04 File Offset: 0x0028F104
	protected override void OnRefreshView()
	{
		bool flag = ModelBase<FunctionModel>.Instance.IsOpen(10026010);
		UUIItem item = base.GetItem(2);
		if (item != null)
		{
			item.SetUIActive(!flag);
		}
		UUISprite sprite = base.GetSprite(1);
		if (sprite != null)
		{
			sprite.SetUIActive(flag);
		}
		UUINiagara uiNiagara = base.GetUiNiagara(7);
		if (uiNiagara != null)
		{
			uiNiagara.SetUIActive(flag);
		}
		string textStringId = flag ? "JinZhouFly_FunctionUnLock" : "JinZhouFly_FunctionLock";
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), textStringId, Array.Empty<object>());
		string textStringId2 = flag ? "JinZhouFly_FunctionUnLockDes" : "JinZhouFly_FunctionLockDes";
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), textStringId2, Array.Empty<object>());
		ActivitySubViewGeneralInfo commonInfoPanel = this.CommonInfoPanel;
		if (commonInfoPanel != null)
		{
			commonInfoPanel.RefreshView();
		}
		bool redPointShowState = this.ActivityData.RedPointShowState;
		ActivitySubViewGeneralInfo commonInfoPanel2 = this.CommonInfoPanel;
		if (commonInfoPanel2 != null)
		{
			commonInfoPanel2.SetFunctionRedDotVisible(redPointShowState);
		}
		if (ModelBase<QuestNewModel>.Instance.CheckQuestFinished(this.ActivityData.GetQuestId()))
		{
			ActivitySubViewGeneralInfo commonInfoPanel3 = this.CommonInfoPanel;
			ActivityFunctionalTypeA activityFunctionalTypeA = (commonInfoPanel3 != null) ? commonInfoPanel3.GetFunctional() : null;
			activityFunctionalTypeA.FunctionButton.SetUiActive(false);
			activityFunctionalTypeA.SetPanelConditionVisible(false);
			activityFunctionalTypeA.SetActivatePanelConditionVisible(true);
			activityFunctionalTypeA.SetActivateTextByTextId("DangoMonopoly_title_21", Array.Empty<string>());
		}
	}

	// Token: 0x06009CC7 RID: 40135 RVA: 0x0029102C File Offset: 0x0028F22C
	protected override void OnTimer(float gap)
	{
		if (this.IsShowConfirmBox)
		{
			return;
		}
		if (!this.ActivityData.CheckIfInShowTime())
		{
			this.IsShowConfirmBox = true;
			ModelBase<ActivityModel>.Instance.RefreshShowingActivities();
		}
	}

	// Token: 0x06009CC8 RID: 40136 RVA: 0x00291055 File Offset: 0x0028F255
	private void OnConfirmBtnClick(ActivityBaseData _)
	{
		this.ActivityData.SaveFirstClick();
		Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, this.ActivityData.GetQuestId(), null);
	}

	// Token: 0x0400480A RID: 18442
	protected ActivitySoarData ActivityData;

	// Token: 0x0400480B RID: 18443
	protected ActivitySubViewGeneralInfo CommonInfoPanel;

	// Token: 0x0400480C RID: 18444
	private bool IsShowConfirmBox;

	// Token: 0x0200797F RID: 31103
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x04029BB3 RID: 170931
		public const int ItemCommonInfo = 0;

		// Token: 0x04029BB4 RID: 170932
		public const int SpriteUnlock = 1;

		// Token: 0x04029BB5 RID: 170933
		public const int ItemLock = 2;

		// Token: 0x04029BB6 RID: 170934
		public const int TextState = 3;

		// Token: 0x04029BB7 RID: 170935
		public const int ItemMale = 4;

		// Token: 0x04029BB8 RID: 170936
		public const int ItemFemale = 5;

		// Token: 0x04029BB9 RID: 170937
		public const int TextDesc = 6;

		// Token: 0x04029BBA RID: 170938
		public const int NiagaraUnlock = 7;
	}
}
