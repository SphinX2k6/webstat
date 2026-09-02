using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200238E RID: 9102
[NullableContext(2)]
[Nullable(0)]
public class BattlePassWeaponView : UiTabViewBase
{
	// Token: 0x06011717 RID: 71447 RVA: 0x004CEC10 File Offset: 0x004CCE10
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06011718 RID: 71448 RVA: 0x004CEC7C File Offset: 0x004CCE7C
	protected override UniTask OnBeforeStartAsync()
	{
		BattlePassWeaponView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<BattlePassWeaponView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06011719 RID: 71449 RVA: 0x004CECBF File Offset: 0x004CCEBF
	protected override void OnBeforeShow()
	{
		WeaponListComponent weaponListComponent = this.WeaponListComponent;
		if (weaponListComponent == null)
		{
			return;
		}
		weaponListComponent.SetCurSelect(0);
	}

	// Token: 0x0601171A RID: 71450 RVA: 0x004CECD2 File Offset: 0x004CCED2
	protected override void OnAfterHide()
	{
		WeaponListComponent weaponListComponent = this.WeaponListComponent;
		if (weaponListComponent == null)
		{
			return;
		}
		weaponListComponent.CancelSelect();
	}

	// Token: 0x0601171B RID: 71451 RVA: 0x004CECE4 File Offset: 0x004CCEE4
	private void OnWeaponChange()
	{
		WeaponTrialData weaponTrialData = (WeaponTrialData)this.WeaponListComponent.GetCurSelectedData();
		WeaponTrialData fullLevelWeaponData = weaponTrialData.GetFullLevelWeaponData();
		if (fullLevelWeaponData != null)
		{
			weaponTrialData = ((this.ToggleState == EToggleState.ETT_Checked) ? fullLevelWeaponData : weaponTrialData);
		}
		this.WeaponDetailComponent.UpdateComponent(weaponTrialData);
		ControllerBase<WeaponController>.Instance.OnSelectedWeaponChange(weaponTrialData, this.WeaponObserver, this.WeaponScabbardObserver, -1, true);
	}

	// Token: 0x0601171C RID: 71452 RVA: 0x004CED41 File Offset: 0x004CCF41
	public void OnClickFullLevelToggle(EToggleState state)
	{
		this.RefreshToggleState(state);
	}

	// Token: 0x0601171D RID: 71453 RVA: 0x004CED4C File Offset: 0x004CCF4C
	public void RefreshToggleState(EToggleState state)
	{
		if (state == this.ToggleState)
		{
			return;
		}
		this.ToggleState = state;
		if (!base.IsShowOrShowing)
		{
			return;
		}
		WeaponTrialData weaponTrialData = (WeaponTrialData)this.WeaponListComponent.GetCurSelectedData();
		WeaponTrialData fullLevelWeaponData = weaponTrialData.GetFullLevelWeaponData();
		if (state == EToggleState.ETT_Checked && fullLevelWeaponData != null)
		{
			weaponTrialData = fullLevelWeaponData;
		}
		this.WeaponDetailComponent.UpdateComponent(weaponTrialData);
		ControllerBase<WeaponController>.Instance.OnSelectedWeaponChange(weaponTrialData, this.WeaponObserver, this.WeaponScabbardObserver, -1, true);
	}

	// Token: 0x040088EE RID: 35054
	private WeaponDetailTipsComponent WeaponDetailComponent;

	// Token: 0x040088EF RID: 35055
	private WeaponListComponent WeaponListComponent;

	// Token: 0x040088F0 RID: 35056
	private SkeletalObserverHandle WeaponObserver;

	// Token: 0x040088F1 RID: 35057
	private SkeletalObserverHandle WeaponScabbardObserver;

	// Token: 0x040088F2 RID: 35058
	private EToggleState ToggleState = EToggleState.ETT_Checked;

	// Token: 0x020086AB RID: 34475
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402D8C8 RID: 186568
		WeaponDetailItem,
		// Token: 0x0402D8C9 RID: 186569
		WeaponScrollView
	}
}
