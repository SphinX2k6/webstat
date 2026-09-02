using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001582 RID: 5506
[NullableContext(2)]
[Nullable(0)]
public class RoleIntroductionView : UiViewBase
{
	// Token: 0x06009AAB RID: 39595 RVA: 0x00288397 File Offset: 0x00286597
	[NullableContext(1)]
	public RoleIntroductionView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06009AAC RID: 39596 RVA: 0x002883A0 File Offset: 0x002865A0
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
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnBtnCloseClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06009AAD RID: 39597 RVA: 0x00288574 File Offset: 0x00286774
	protected override UniTask OnBeforeStartAsync()
	{
		RoleIntroductionView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RoleIntroductionView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009AAE RID: 39598 RVA: 0x002885B8 File Offset: 0x002867B8
	public UniTask RefreshAsync()
	{
		RoleIntroductionView.<RefreshAsync>d__11 <RefreshAsync>d__;
		<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshAsync>d__.<>4__this = this;
		<RefreshAsync>d__.<>1__state = -1;
		<RefreshAsync>d__.<>t__builder.Start<RoleIntroductionView.<RefreshAsync>d__11>(ref <RefreshAsync>d__);
		return <RefreshAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009AAF RID: 39599 RVA: 0x002885FC File Offset: 0x002867FC
	private void RefreshBtn()
	{
		string textId = (this.CurShowMode == 0) ? "RoleTrialButton2" : "RoleTrialButton1";
		this.TrialBtnItem.SetActive(this.CurShowMode == 1);
		this.SwitchBtnItem.SetLocalTextNew(textId, Array.Empty<object>());
		this.RoleSkillInputPanel.SetFeatureActive(this.CurShowMode == 0);
		this.RoleSkillInputPanel.SetEmptyActive(this.CurShowMode == 0);
		this.RoleSkillInputPanel.SetTrickActive(this.CurShowMode == 1);
	}

	// Token: 0x06009AB0 RID: 39600 RVA: 0x00288680 File Offset: 0x00286880
	private void RefreshTips()
	{
		string text = "";
		if (!RoleSkinTrialController.CheckIfInRoleSkinTrialInstance())
		{
			int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
			foreach (ActivityRoleTrialData activityRoleTrialData in ControllerBase<ActivityRoleTrialController>.Instance.GetCurrentActivityDataList())
			{
				RoleTrialInfo? configByRoleAndInstance = activityRoleTrialData.GetConfigByRoleAndInstance(this.RoleId, instanceId);
				if (configByRoleAndInstance != null)
				{
					text = (configByRoleAndInstance.Value.InstanceText ?? "");
					break;
				}
			}
		}
		if (!StringUtils.IsEmpty(text))
		{
			base.GetText(6).ShowTextNew(text);
			base.GetItem(7).SetUIActive(true);
			return;
		}
		base.GetItem(7).SetUIActive(false);
	}

	// Token: 0x06009AB1 RID: 39601 RVA: 0x0028874C File Offset: 0x0028694C
	protected override void OnBeforeHide()
	{
		Singleton<EventSystem>.Instance.Emit(EEventName.RoleIntroductionViewHide);
	}

	// Token: 0x06009AB2 RID: 39602 RVA: 0x0028875E File Offset: 0x0028695E
	protected override void OnBeforeDestroy()
	{
		this.PushCloseViewDone();
	}

	// Token: 0x06009AB3 RID: 39603 RVA: 0x00288766 File Offset: 0x00286966
	private void PushCloseViewDone()
	{
		if (RoleSkinTrialController.CheckIfInRoleSkinTrialInstance())
		{
			RoleSkinTrialController.RequestRoleSkinTrialUiEndPush();
			return;
		}
		ControllerBase<ActivityRoleTrialController>.Instance.PushRoleIntroductionViewDone();
	}

	// Token: 0x06009AB4 RID: 39604 RVA: 0x0028877F File Offset: 0x0028697F
	private void OnBtnCloseClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x06009AB5 RID: 39605 RVA: 0x00288788 File Offset: 0x00286988
	private void OnSwitchClick()
	{
		if (this.CurShowMode == 0)
		{
			this.CurShowMode = 1;
		}
		else
		{
			this.CurShowMode = 0;
		}
		this.RefreshBtn();
	}

	// Token: 0x06009AB6 RID: 39606 RVA: 0x002887A8 File Offset: 0x002869A8
	private void OnTrialClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x04004742 RID: 18242
	private int RoleId;

	// Token: 0x04004743 RID: 18243
	private RoleSkillInputPanel RoleSkillInputPanel;

	// Token: 0x04004744 RID: 18244
	private SimpleGenericLayout StarLayout;

	// Token: 0x04004745 RID: 18245
	private ButtonItem SwitchBtnItem;

	// Token: 0x04004746 RID: 18246
	private ButtonItem TrialBtnItem;

	// Token: 0x04004747 RID: 18247
	private int CurShowMode;

	// Token: 0x02007943 RID: 31043
	[NullableContext(0)]
	private static class EIntroductionShowMode
	{
		// Token: 0x04029A88 RID: 170632
		public const int Feature = 0;

		// Token: 0x04029A89 RID: 170633
		public const int Trick = 1;
	}

	// Token: 0x02007944 RID: 31044
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x04029A8A RID: 170634
		public const int BtnBack = 0;

		// Token: 0x04029A8B RID: 170635
		public const int TexRole = 1;

		// Token: 0x04029A8C RID: 170636
		public const int StarLayout = 2;

		// Token: 0x04029A8D RID: 170637
		public const int RoleName = 3;

		// Token: 0x04029A8E RID: 170638
		public const int ElementIcon = 4;

		// Token: 0x04029A8F RID: 170639
		public const int ElementText = 5;

		// Token: 0x04029A90 RID: 170640
		public const int TextTips = 6;

		// Token: 0x04029A91 RID: 170641
		public const int PanelTips = 7;

		// Token: 0x04029A92 RID: 170642
		public const int RoleSkillInputPanel = 8;

		// Token: 0x04029A93 RID: 170643
		public const int BtnSwitchPage = 9;

		// Token: 0x04029A94 RID: 170644
		public const int BtnTrial = 10;
	}
}
