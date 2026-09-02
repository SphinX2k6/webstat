using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001C46 RID: 7238
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchSkillView : UiViewBase
{
	// Token: 0x0600D313 RID: 54035 RVA: 0x003837E0 File Offset: 0x003819E0
	public FloroRanchSkillView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x0600D314 RID: 54036 RVA: 0x003837EC File Offset: 0x003819EC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(USpineSkeletonAnimationComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnConfirmBtnClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(7, new Action(this.OnCloseBtnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D315 RID: 54037 RVA: 0x0038393C File Offset: 0x00381B3C
	protected override UniTask OnBeforeStartAsync()
	{
		FloroRanchSkillView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<FloroRanchSkillView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D316 RID: 54038 RVA: 0x00383980 File Offset: 0x00381B80
	private void ResolveOpenParam()
	{
		object openParam = this.OpenParam;
		if (openParam is bool)
		{
			bool canSelect = (bool)openParam;
			this.CanSelect = canSelect;
			this.ActivityDataType = EFloroRanchActivityDataType.Normal;
			return;
		}
		openParam = this.OpenParam;
		if (openParam is FloroRanchSkillViewParam)
		{
			FloroRanchSkillViewParam floroRanchSkillViewParam = (FloroRanchSkillViewParam)openParam;
			this.CanSelect = floroRanchSkillViewParam.CanSelect;
			this.ActivityDataType = floroRanchSkillViewParam.ActivityDataType;
			return;
		}
		this.CanSelect = false;
		this.ActivityDataType = EFloroRanchActivityDataType.Normal;
	}

	// Token: 0x0600D317 RID: 54039 RVA: 0x003839EF File Offset: 0x00381BEF
	private bool OnCanExecuteChange(int skillId)
	{
		return this.SelectedSkillId != skillId;
	}

	// Token: 0x0600D318 RID: 54040 RVA: 0x003839FD File Offset: 0x00381BFD
	private void OnToggleCallback(int skillId)
	{
		this.SelectedSkillId = skillId;
		this.SkillLayout.SelectGridProxyByKey(skillId, false);
	}

	// Token: 0x0600D319 RID: 54041 RVA: 0x00383A18 File Offset: 0x00381C18
	private FloroRanchSkillCardItem CreateSkillCard()
	{
		return new FloroRanchSkillCardItem
		{
			OnCanExecuteChangeFunc = new Func<int, bool>(this.OnCanExecuteChange),
			OnToggleCallBack = new Action<int>(this.OnToggleCallback),
			CanSelect = this.CanSelect,
			ActivityDataType = this.ActivityDataType
		};
	}

	// Token: 0x0600D31A RID: 54042 RVA: 0x00383A68 File Offset: 0x00381C68
	private void OnConfirmBtnClick()
	{
		LocalStorage.SetPlayer<int>(ModelBase<FloroRanchModel>.Instance.GetSkillStorageKeyByActivityType(this.ActivityDataType), this.SelectedSkillId);
		ModelBase<FloroRanchModel>.Instance.GetActivityData(this.ActivityDataType, true).SaveSkillRedDot();
		Singleton<EventSystem>.Instance.Emit<EFloroRanchActivityDataType, int>(EEventName.FloroRanchSkillChange, this.ActivityDataType, this.SelectedSkillId);
		base.CloseMe(null);
	}

	// Token: 0x0600D31B RID: 54043 RVA: 0x00383ACA File Offset: 0x00381CCA
	private void OnCloseBtnClick()
	{
		ModelBase<FloroRanchModel>.Instance.GetActivityData(this.ActivityDataType, true).SaveSkillRedDot();
		Singleton<EventSystem>.Instance.Emit<EFloroRanchActivityDataType>(EEventName.FloroRanchSkillRedDotRefresh, this.ActivityDataType);
		base.CloseMe(null);
	}

	// Token: 0x0600D31C RID: 54044 RVA: 0x00383B00 File Offset: 0x00381D00
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (configParams.Length == 0)
		{
			return null;
		}
		if (!(configParams[0] == "SkillCard"))
		{
			return null;
		}
		if (configParams.Length < 2)
		{
			return null;
		}
		int index = int.Parse(configParams[1]);
		GenericLayout<FloroRanchSkillCardItem, FloroRanchSkillData> skillLayout = this.SkillLayout;
		UUIItem uuiitem = (skillLayout != null) ? skillLayout.GetItemByIndex(index) : null;
		if (uuiitem == null)
		{
			return null;
		}
		return new UUIItem[]
		{
			uuiitem,
			uuiitem
		};
	}

	// Token: 0x0400648C RID: 25740
	private int SelectedSkillId;

	// Token: 0x0400648D RID: 25741
	private EFloroRanchActivityDataType ActivityDataType;

	// Token: 0x0400648E RID: 25742
	private bool CanSelect;

	// Token: 0x0400648F RID: 25743
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<FloroRanchSkillCardItem, FloroRanchSkillData> SkillLayout;

	// Token: 0x02007F53 RID: 32595
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x0402B56F RID: 177519
		public const int SpineRole = 2;

		// Token: 0x0402B570 RID: 177520
		public const int LayoutSkillCard = 4;

		// Token: 0x0402B571 RID: 177521
		public const int ItemSkillCard = 5;

		// Token: 0x0402B572 RID: 177522
		public const int ButtonConfirm = 6;

		// Token: 0x0402B573 RID: 177523
		public const int ButtonClose = 7;

		// Token: 0x0402B574 RID: 177524
		public const int ItemTip = 8;
	}
}
