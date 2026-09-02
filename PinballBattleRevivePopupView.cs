using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.KuroSimpleCombat.PB;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001D77 RID: 7543
[NullableContext(1)]
[Nullable(0)]
public class PinballBattleRevivePopupView : UiViewBase
{
	// Token: 0x0600DDD7 RID: 56791 RVA: 0x003BA485 File Offset: 0x003B8685
	public PinballBattleRevivePopupView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600DDD8 RID: 56792 RVA: 0x003BA490 File Offset: 0x003B8690
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnBtnLeftClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnBtnRightClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600DDD9 RID: 56793 RVA: 0x003BA5BC File Offset: 0x003B87BC
	protected override void OnStart()
	{
		this.Param = (this.OpenParam as IPinballBattleRevivePopupViewParam);
		this.RoleHeadLayout = new GenericLayout<PinballBattleReviveRoleHeadItem, int>(base.GetHorizontalLayout(0), new Func<PinballBattleReviveRoleHeadItem>(this.CreateRoleHeadItem), (AUIBaseActor)base.GetItem(1).GetOwner(), false, true);
		PinballBattleSubModel pinballBattleSubModel = ControllerBase<KuroSimpleCombatController>.Instance.CurSubModel as PinballBattleSubModel;
		List<int> list = new List<int>();
		if (pinballBattleSubModel.FormationData != null)
		{
			foreach (PinballFormationRolePb pinballFormationRolePb in pinballBattleSubModel.FormationData)
			{
				list.Add(pinballFormationRolePb.RoleId);
			}
		}
		GenericLayout<PinballBattleReviveRoleHeadItem, int> roleHeadLayout = this.RoleHeadLayout;
		if (roleHeadLayout != null)
		{
			roleHeadLayout.RefreshByData(list, null, false);
		}
		int value = pinballBattleSubModel.MaxReviveTime - pinballBattleSubModel.UsedReviveTime;
		UUIText text = base.GetText(2);
		if (text == null)
		{
			return;
		}
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
		defaultInterpolatedStringHandler.AppendFormatted<int>(value);
		defaultInterpolatedStringHandler.AppendLiteral("/");
		defaultInterpolatedStringHandler.AppendFormatted<int>(pinballBattleSubModel.MaxReviveTime);
		text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
	}

	// Token: 0x0600DDDA RID: 56794 RVA: 0x003BA6DC File Offset: 0x003B88DC
	protected override void OnBeforeShow()
	{
		IUiPopFrameInterface childPopView = this.ChildPopView;
		if (childPopView != null)
		{
			childPopView.SetBackBtnShowState(false);
		}
		IUiPopFrameInterface childPopView2 = this.ChildPopView;
		if (childPopView2 == null)
		{
			return;
		}
		childPopView2.PopItem.SetMaskResponsibleState(false);
	}

	// Token: 0x0600DDDB RID: 56795 RVA: 0x003BA706 File Offset: 0x003B8906
	private PinballBattleReviveRoleHeadItem CreateRoleHeadItem()
	{
		return new PinballBattleReviveRoleHeadItem();
	}

	// Token: 0x0600DDDC RID: 56796 RVA: 0x003BA70D File Offset: 0x003B890D
	private void OnBtnLeftClick()
	{
		IPinballBattleRevivePopupViewParam param = this.Param;
		if (param != null)
		{
			Action cancelCallback = param.CancelCallback;
			if (cancelCallback != null)
			{
				cancelCallback();
			}
		}
		base.CloseMe(null);
	}

	// Token: 0x0600DDDD RID: 56797 RVA: 0x003BA732 File Offset: 0x003B8932
	private void OnBtnRightClick()
	{
		IPinballBattleRevivePopupViewParam param = this.Param;
		if (param != null)
		{
			Action confirmCallback = param.ConfirmCallback;
			if (confirmCallback != null)
			{
				confirmCallback();
			}
		}
		base.CloseMe(null);
	}

	// Token: 0x04006A90 RID: 27280
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<PinballBattleReviveRoleHeadItem, int> RoleHeadLayout;

	// Token: 0x04006A91 RID: 27281
	[Nullable(2)]
	private IPinballBattleRevivePopupViewParam Param;
}
