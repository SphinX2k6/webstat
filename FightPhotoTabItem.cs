using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020025CC RID: 9676
[NullableContext(1)]
[Nullable(0)]
public class FightPhotoTabItem : GridProxyAbstract<EFightPhotoTab>
{
	// Token: 0x06012EA5 RID: 77477 RVA: 0x0053BD48 File Offset: 0x00539F48
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIExtendToggleSpriteTransition)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle))
		};
	}

	// Token: 0x06012EA6 RID: 77478 RVA: 0x0053BDC5 File Offset: 0x00539FC5
	protected override void OnStart()
	{
		base.GetExtendToggle(0).bLockStateOnSelect = true;
	}

	// Token: 0x06012EA7 RID: 77479 RVA: 0x0053BDD4 File Offset: 0x00539FD4
	public override UniTask RefreshAsync(EFightPhotoTab data, bool isSelected, int gridIndex)
	{
		FightPhotoTabItem.<RefreshAsync>d__7 <RefreshAsync>d__;
		<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshAsync>d__.<>4__this = this;
		<RefreshAsync>d__.data = data;
		<RefreshAsync>d__.<>1__state = -1;
		<RefreshAsync>d__.<>t__builder.Start<FightPhotoTabItem.<RefreshAsync>d__7>(ref <RefreshAsync>d__);
		return <RefreshAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012EA8 RID: 77480 RVA: 0x0053BE20 File Offset: 0x0053A020
	private bool IsRecommend(EFightPhotoTab tab)
	{
		ICameraConditionRecommend cameraConditionRecommend = ModelBase<FightPhotoModel>.Instance.GetCameraConditionRecommend();
		if (tab == EFightPhotoTab.Filter)
		{
			return cameraConditionRecommend.FilterIds.Count > 0;
		}
		return tab == EFightPhotoTab.Frame && cameraConditionRecommend.FrameIds.Count > 0;
	}

	// Token: 0x06012EA9 RID: 77481 RVA: 0x0053BE5F File Offset: 0x0053A05F
	public override void OnSelected(bool fireEvent)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleStateForce(EToggleState.ETT_Checked, false, false, false);
	}

	// Token: 0x06012EAA RID: 77482 RVA: 0x0053BE76 File Offset: 0x0053A076
	public override void OnDeselected(bool fireEvent)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x06012EAB RID: 77483 RVA: 0x0053BE8D File Offset: 0x0053A08D
	private void OnClickToggle(EToggleState state)
	{
		this.OnToggleClick(this.CurrentTab);
	}

	// Token: 0x06012EAC RID: 77484 RVA: 0x0053BEA0 File Offset: 0x0053A0A0
	public override object GetKey(EFightPhotoTab data, int displayIndex)
	{
		return data;
	}

	// Token: 0x06012EAE RID: 77486 RVA: 0x0053BEDC File Offset: 0x0053A0DC
	// Note: this type is marked as 'beforefieldinit'.
	static FightPhotoTabItem()
	{
		EToggleTransitionState[] array = new EToggleTransitionState[3];
		RuntimeHelpers.InitializeArray(array, fieldof(<PrivateImplementationDetails>.2848698AA4B3431E3DB06C343CA2CB0455F8AAF16C85CDD828C92DDF7DC134F8).FieldHandle);
		FightPhotoTabItem.CheckedStates = array;
		FightPhotoTabItem.UncheckedStates = new EToggleTransitionState[]
		{
			EToggleTransitionState.ETT_UnCheckedUnHover,
			EToggleTransitionState.ETT_UnCheckedHover,
			EToggleTransitionState.ETT_UnCheckedPressed
		};
	}

	// Token: 0x040093BD RID: 37821
	private EFightPhotoTab CurrentTab = EFightPhotoTab.Mission;

	// Token: 0x040093BE RID: 37822
	public Action<EFightPhotoTab> OnToggleClick = delegate(EFightPhotoTab tab)
	{
	};

	// Token: 0x040093BF RID: 37823
	[StaticVariableRuleIgnore]
	private static readonly EToggleTransitionState[] CheckedStates;

	// Token: 0x040093C0 RID: 37824
	[StaticVariableRuleIgnore]
	private static readonly EToggleTransitionState[] UncheckedStates;

	// Token: 0x02008937 RID: 35127
	[NullableContext(0)]
	private enum EComponents
	{
		// Token: 0x0402E4CF RID: 189647
		TogRoot,
		// Token: 0x0402E4D0 RID: 189648
		ToggleSpriteTransitionIcon,
		// Token: 0x0402E4D1 RID: 189649
		ItemRecommend
	}
}
