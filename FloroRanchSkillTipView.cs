using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001C44 RID: 7236
public class FloroRanchSkillTipView : UiViewBase
{
	// Token: 0x0600D30B RID: 54027 RVA: 0x0038339C File Offset: 0x0038159C
	[NullableContext(1)]
	public FloroRanchSkillTipView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x0600D30C RID: 54028 RVA: 0x003833A8 File Offset: 0x003815A8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 11;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnCloseButtonClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(10, new Action(this.OnUseButtonClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D30D RID: 54029 RVA: 0x003835A0 File Offset: 0x003817A0
	protected override void OnStart()
	{
		TermExplanationRegistryParam param = new TermExplanationRegistryParam
		{
			UiText = base.GetText(5),
			ViewType = ETermExplanationViewType.Center,
			ReportType = ETermExplanationReportType.FloroRanch,
			Style = new ETermExplanationViewStyle?(ETermExplanationViewStyle.FloroRanch)
		};
		ControllerBase<TermExplanationController>.Instance.RegisterTextHyperlinkByParam(param);
	}

	// Token: 0x0600D30E RID: 54030 RVA: 0x003835E8 File Offset: 0x003817E8
	protected override void OnBeforeShow()
	{
		this.SkillEntity = (this.OpenParam as FloroRanchEntityBase);
		FloroRanchRoleSkillDataComponent floroRanchRoleSkillDataComponent = this.SkillEntity.CheckGetComponent<FloroRanchRoleSkillDataComponent>();
		FloroRanchSkillData skillData = floroRanchRoleSkillDataComponent.SkillData;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), skillData.Name, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), skillData.Desc, Array.Empty<object>());
		base.GetSprite(3).useChangeColor = skillData.IsActiveSkill;
		string textStringId = skillData.IsActiveSkill ? "FloroRanchActiveSkill" : "FloroRanchPassiveSkill";
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), textStringId, Array.Empty<object>());
		base.SetTextureShowUntilLoaded(skillData.Icon, base.GetTexture(1), null);
		base.GetItem(6).SetUIActive(true);
		base.GetItem(7).SetUIActive(floroRanchRoleSkillDataComponent.CanUseCount > 0);
		base.GetItem(9).SetUIActive(floroRanchRoleSkillDataComponent.CanUseCount <= 0);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), "Farm_SkillTimes", new <>z__ReadOnlySingleElementList<object>(floroRanchRoleSkillDataComponent.CanUseCount));
		base.GetButton(10).RootUIComp.Get().SetUIActive(floroRanchRoleSkillDataComponent.CanUseSkill());
	}

	// Token: 0x0600D30F RID: 54031 RVA: 0x00383724 File Offset: 0x00381924
	protected override void OnBeforeDestroy()
	{
		ControllerBase<TermExplanationController>.Instance.UnRegisterTextHyperlink(base.GetText(5));
	}

	// Token: 0x0600D310 RID: 54032 RVA: 0x00383738 File Offset: 0x00381938
	private void OnUseButtonClick()
	{
		if (!ModelBase<FloroRanchGamePlayModel>.Instance.CanFsmInsertSkillTask())
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("FloroRanchSkillCantUse", Array.Empty<object>());
			return;
		}
		int activityId = ModelBase<FloroRanchGamePlayModel>.Instance.ActivityId;
		int subInstanceId = ModelBase<FloroRanchGamePlayModel>.Instance.SubInstanceId;
		ControllerBase<FloroRanchController>.Instance.SendFloroRanchExecuteSkillPlayRequest(activityId, subInstanceId, new Action<bool>(this.OnUseSkillFinish));
	}

	// Token: 0x0600D311 RID: 54033 RVA: 0x00383794 File Offset: 0x00381994
	private void OnCloseButtonClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600D312 RID: 54034 RVA: 0x003837A0 File Offset: 0x003819A0
	private void OnUseSkillFinish(bool isSuccess)
	{
		if (!isSuccess)
		{
			return;
		}
		if (base.IsDestroyOrDestroying)
		{
			return;
		}
		FloroRanchGamePlayView floroRanchGamePlayView = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.FloroRanchGamePlayView) as FloroRanchGamePlayView;
		if (floroRanchGamePlayView != null)
		{
			floroRanchGamePlayView.PlayFloroAudio(EFloroRanchAudioType.Skill);
		}
		base.CloseMe(null);
	}

	// Token: 0x04006489 RID: 25737
	[Nullable(2)]
	private FloroRanchEntityBase SkillEntity;

	// Token: 0x02007F52 RID: 32594
	private class EComponent
	{
		// Token: 0x0402B564 RID: 177508
		public const int CloseButton = 0;

		// Token: 0x0402B565 RID: 177509
		public const int SkillIcon = 1;

		// Token: 0x0402B566 RID: 177510
		public const int SkillName = 2;

		// Token: 0x0402B567 RID: 177511
		public const int SkillTagSprite = 3;

		// Token: 0x0402B568 RID: 177512
		public const int SkillTagText = 4;

		// Token: 0x0402B569 RID: 177513
		public const int SkillDesc = 5;

		// Token: 0x0402B56A RID: 177514
		public const int RootItem = 6;

		// Token: 0x0402B56B RID: 177515
		public const int UseCountItem = 7;

		// Token: 0x0402B56C RID: 177516
		public const int UseTimeCount = 8;

		// Token: 0x0402B56D RID: 177517
		public const int DepletedItem = 9;

		// Token: 0x0402B56E RID: 177518
		public const int UseButton = 10;
	}
}
