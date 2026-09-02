using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200154A RID: 5450
public class ActivityRegressQuestionnaireView : UiViewBase
{
	// Token: 0x060098F0 RID: 39152 RVA: 0x00280C88 File Offset: 0x0027EE88
	[NullableContext(1)]
	public ActivityRegressQuestionnaireView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x060098F1 RID: 39153 RVA: 0x00280C94 File Offset: 0x0027EE94
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(2, new Action(this.OnBtn1Click)),
			new ValueTuple<int, Delegate>(5, new Action(this.OnBtn2Click))
		};
	}

	// Token: 0x060098F2 RID: 39154 RVA: 0x00280D98 File Offset: 0x0027EF98
	protected override void OnStart()
	{
		this.Layout1 = new GenericLayout<ActivityRegressQuestionnaireLayoutItem, ActivityRegressQuestionnaireItemData>(base.GetHorizontalLayout(0), new Func<ActivityRegressQuestionnaireLayoutItem>(this.CreateLayoutItem), null, false, true);
		this.Layout2 = new GenericLayout<ActivityRegressQuestionnaireLayoutItem, ActivityRegressQuestionnaireItemData>(base.GetHorizontalLayout(3), new Func<ActivityRegressQuestionnaireLayoutItem>(this.CreateLayoutItem), null, false, true);
	}

	// Token: 0x060098F3 RID: 39155 RVA: 0x00280DE7 File Offset: 0x0027EFE7
	protected override void OnBeforeShow()
	{
		ModelBase<ActivityRegressModel>.Instance.ActivityData.SetQuestionnaireRedDotChecked();
		this.UpdateVisiuals();
	}

	// Token: 0x060098F4 RID: 39156 RVA: 0x00280DFE File Offset: 0x0027EFFE
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RecallActivityInfoUpdate, new Action(this.UpdateVisiuals));
	}

	// Token: 0x060098F5 RID: 39157 RVA: 0x00280E1C File Offset: 0x0027F01C
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RecallActivityInfoUpdate, new Action(this.UpdateVisiuals));
	}

	// Token: 0x060098F6 RID: 39158 RVA: 0x00280E3A File Offset: 0x0027F03A
	protected override void OnBeforeDestroy()
	{
		this.Layout1.ClearChildren();
		this.Layout2.ClearChildren();
	}

	// Token: 0x060098F7 RID: 39159 RVA: 0x00280E52 File Offset: 0x0027F052
	[NullableContext(1)]
	private ActivityRegressQuestionnaireLayoutItem CreateLayoutItem()
	{
		return new ActivityRegressQuestionnaireLayoutItem();
	}

	// Token: 0x060098F8 RID: 39160 RVA: 0x00280E5C File Offset: 0x0027F05C
	private void UpdateVisiuals()
	{
		List<ActivityRegressQuestionnaireItemData> regressQuestionnaireRewardDataList = ModelBase<ActivityRegressModel>.Instance.GetRegressQuestionnaireRewardDataList(ERegressQuestionnaireType.Type1);
		this.Layout1.RefreshByData(regressQuestionnaireRewardDataList, null, false);
		List<ActivityRegressQuestionnaireItemData> regressQuestionnaireRewardDataList2 = ModelBase<ActivityRegressModel>.Instance.GetRegressQuestionnaireRewardDataList(ERegressQuestionnaireType.Type2);
		this.Layout2.RefreshByData(regressQuestionnaireRewardDataList2, null, false);
		base.GetItem(6).SetUIActive(ModelBase<ActivityRegressModel>.Instance.ActivityData.IsQuestionnaireUnlock(ERegressQuestionnaireType.Type2));
	}

	// Token: 0x060098F9 RID: 39161 RVA: 0x00280EBC File Offset: 0x0027F0BC
	private void OnBtn1Click()
	{
		ControllerBase<ActivityRegressController>.Instance.OpenQuestionnaire(ERegressQuestionnaireType.Type1);
		RegressInvestigation? regressQuestionnaireConfig = ConfigBase<ActivityRegressConfig>.Instance.GetRegressQuestionnaireConfig(ERegressQuestionnaireType.Type1);
		if (regressQuestionnaireConfig == null)
		{
			return;
		}
		RegressInvestigation value = regressQuestionnaireConfig.Value;
		if (ModelBase<ActivityRegressModel>.Instance.ActivityData.GetQuestionnaireRewardState(value.Id) == ERegressRewardState.UnReach)
		{
			ControllerBase<ActivityRegressController>.Instance.RequestQuestionOpen(ERegressQuestionnaireType.Type1);
			ActivityRegressHelper.ReportRegressLog1061(value.QuestionnaireId);
		}
	}

	// Token: 0x060098FA RID: 39162 RVA: 0x00280F24 File Offset: 0x0027F124
	private void OnBtn2Click()
	{
		ControllerBase<ActivityRegressController>.Instance.OpenQuestionnaire(ERegressQuestionnaireType.Type2);
		RegressInvestigation? regressQuestionnaireConfig = ConfigBase<ActivityRegressConfig>.Instance.GetRegressQuestionnaireConfig(ERegressQuestionnaireType.Type2);
		if (regressQuestionnaireConfig == null)
		{
			return;
		}
		RegressInvestigation value = regressQuestionnaireConfig.Value;
		if (ModelBase<ActivityRegressModel>.Instance.ActivityData.GetQuestionnaireRewardState(value.Id) == ERegressRewardState.UnReach)
		{
			ControllerBase<ActivityRegressController>.Instance.RequestQuestionOpen(ERegressQuestionnaireType.Type2);
			ActivityRegressHelper.ReportRegressLog1061(value.QuestionnaireId);
		}
	}

	// Token: 0x040046B0 RID: 18096
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<ActivityRegressQuestionnaireLayoutItem, ActivityRegressQuestionnaireItemData> Layout1;

	// Token: 0x040046B1 RID: 18097
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<ActivityRegressQuestionnaireLayoutItem, ActivityRegressQuestionnaireItemData> Layout2;

	// Token: 0x02007906 RID: 30982
	private class EComponents
	{
		// Token: 0x04029975 RID: 170357
		public const int PnlHor1 = 0;

		// Token: 0x04029976 RID: 170358
		public const int PnlItem1 = 1;

		// Token: 0x04029977 RID: 170359
		public const int PnlBtn1 = 2;

		// Token: 0x04029978 RID: 170360
		public const int PnlHor2 = 3;

		// Token: 0x04029979 RID: 170361
		public const int PnlItem2 = 4;

		// Token: 0x0402997A RID: 170362
		public const int PnlBtn2 = 5;

		// Token: 0x0402997B RID: 170363
		public const int RootItem2 = 6;

		// Token: 0x0402997C RID: 170364
		public const int RootItem1 = 7;
	}
}
