using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.Role.Common.Data.Enum;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002CF5 RID: 11509
[NullableContext(2)]
[Nullable(0)]
public class WeaponPreviewView : UiViewBase
{
	// Token: 0x06017396 RID: 95126 RVA: 0x0067008C File Offset: 0x0066E28C
	[NullableContext(1)]
	public WeaponPreviewView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06017397 RID: 95127 RVA: 0x0067009C File Offset: 0x0066E29C
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
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIScrollViewWithScrollbarComponent));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06017398 RID: 95128 RVA: 0x00670128 File Offset: 0x0066E328
	protected override UniTask OnBeforeStartAsync()
	{
		WeaponPreviewView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<WeaponPreviewView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06017399 RID: 95129 RVA: 0x0067016C File Offset: 0x0066E36C
	protected override void OnBeforeShow()
	{
		ModelBase<WeaponModel>.Instance.SetCurSelectViewName(EWeaponViewName.WeaponLevelUpView);
		IWeaponPreviewViewParam weaponPreviewViewParam = this.OpenParam as IWeaponPreviewViewParam;
		WeaponListComponent weaponListComponent = this.WeaponListComponent;
		if (weaponListComponent == null)
		{
			return;
		}
		weaponListComponent.SetCurSelect(weaponPreviewViewParam.SelectedIndex);
	}

	// Token: 0x0601739A RID: 95130 RVA: 0x006701A6 File Offset: 0x0066E3A6
	protected override void OnAfterHide()
	{
		WeaponListComponent weaponListComponent = this.WeaponListComponent;
		if (weaponListComponent != null)
		{
			weaponListComponent.CancelSelect();
		}
		ModelBase<WeaponModel>.Instance.SetCurSelectViewName(EWeaponViewName.None);
	}

	// Token: 0x0601739B RID: 95131 RVA: 0x006701C4 File Offset: 0x0066E3C4
	private void OnCloseBtnClick()
	{
		Singleton<UiManager>.Instance.CloseView(EUiViewName.WeaponPreviewView, null);
	}

	// Token: 0x0601739C RID: 95132 RVA: 0x006701D8 File Offset: 0x0066E3D8
	private void OnWeaponChange()
	{
		WeaponTrialData weaponTrialData = this.WeaponListComponent.GetCurSelectedData() as WeaponTrialData;
		WeaponTrialData fullLevelWeaponData = weaponTrialData.GetFullLevelWeaponData();
		if (fullLevelWeaponData == null)
		{
			this.CaptionItem.SetToggleVisible(false);
		}
		else
		{
			this.CaptionItem.SetToggleVisible(true);
			weaponTrialData = ((this.CaptionItem.GetToggleState() == EToggleState.ETT_Checked) ? fullLevelWeaponData : weaponTrialData);
		}
		this.WeaponDetailComponent.UpdateComponent(weaponTrialData);
		ControllerBase<WeaponController>.Instance.OnSelectedWeaponChange(weaponTrialData, this.WeaponObserver, this.WeaponScabbardObserver, -1, this.NeedMeshStreaming);
	}

	// Token: 0x0601739D RID: 95133 RVA: 0x0067025C File Offset: 0x0066E45C
	protected override void OnBeforeCreate()
	{
		IWeaponPreviewViewParam weaponPreviewViewParam = this.OpenParam as IWeaponPreviewViewParam;
		WeaponSkeletalObserverHandles weaponSkeletalObserverHandles = (weaponPreviewViewParam != null) ? weaponPreviewViewParam.WeaponObservers : null;
		if (weaponSkeletalObserverHandles != null)
		{
			this.WeaponObserver = weaponSkeletalObserverHandles.WeaponObserver;
			this.WeaponScabbardObserver = weaponSkeletalObserverHandles.WeaponScabbardObserver;
			return;
		}
		this.WeaponObserver = Singleton<UiSceneManager>.Instance.InitWeaponObserver(this.NeedMeshStreaming);
		this.WeaponScabbardObserver = Singleton<UiSceneManager>.Instance.InitWeaponScabbardObserver();
	}

	// Token: 0x0601739E RID: 95134 RVA: 0x006702C4 File Offset: 0x0066E4C4
	protected override void OnBeforeDestroy()
	{
		IWeaponPreviewViewParam weaponPreviewViewParam = this.OpenParam as IWeaponPreviewViewParam;
		if (((weaponPreviewViewParam != null) ? weaponPreviewViewParam.WeaponObservers : null) != null)
		{
			return;
		}
		Singleton<UiSceneManager>.Instance.DestroyWeaponObserver(this.WeaponObserver);
		this.WeaponObserver = null;
		Singleton<UiSceneManager>.Instance.DestroyWeaponScabbardObserver(this.WeaponScabbardObserver);
		this.WeaponScabbardObserver = null;
	}

	// Token: 0x0601739F RID: 95135 RVA: 0x0067031C File Offset: 0x0066E51C
	private void OnClickFullLevelToggle(EToggleState state)
	{
		WeaponTrialData weaponTrialData = this.WeaponListComponent.GetCurSelectedData() as WeaponTrialData;
		WeaponTrialData fullLevelWeaponData = weaponTrialData.GetFullLevelWeaponData();
		if (state == EToggleState.ETT_Checked && fullLevelWeaponData != null)
		{
			weaponTrialData = fullLevelWeaponData;
		}
		this.WeaponDetailComponent.UpdateComponent(weaponTrialData);
		ControllerBase<WeaponController>.Instance.OnSelectedWeaponChange(weaponTrialData, this.WeaponObserver, this.WeaponScabbardObserver, -1, this.NeedMeshStreaming);
	}

	// Token: 0x0400B291 RID: 45713
	private WeaponDetailTipsComponent WeaponDetailComponent;

	// Token: 0x0400B292 RID: 45714
	private WeaponListComponent WeaponListComponent;

	// Token: 0x0400B293 RID: 45715
	private PopupCaptionItem CaptionItem;

	// Token: 0x0400B294 RID: 45716
	private readonly bool NeedMeshStreaming = true;

	// Token: 0x0400B295 RID: 45717
	private SkeletalObserverHandle WeaponObserver;

	// Token: 0x0400B296 RID: 45718
	private SkeletalObserverHandle WeaponScabbardObserver;

	// Token: 0x02008FC1 RID: 36801
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x04030403 RID: 197635
		WeaponDetailItem,
		// Token: 0x04030404 RID: 197636
		CaptionItem,
		// Token: 0x04030405 RID: 197637
		WeaponScrollView
	}
}
