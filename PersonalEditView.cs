using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Personal;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200242B RID: 9259
[NullableContext(2)]
[Nullable(0)]
public class PersonalEditView : UiViewBase
{
	// Token: 0x06011E7C RID: 73340 RVA: 0x004ECC86 File Offset: 0x004EAE86
	[NullableContext(1)]
	public PersonalEditView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x17001692 RID: 5778
	// (get) Token: 0x06011E7D RID: 73341 RVA: 0x004ECC8F File Offset: 0x004EAE8F
	private new EPersonalEditDefine OpenParam
	{
		get
		{
			return (EPersonalEditDefine)this.OpenParam;
		}
	}

	// Token: 0x06011E7E RID: 73342 RVA: 0x004ECC9C File Offset: 0x004EAE9C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIInteractionGroup))
		};
	}

	// Token: 0x06011E7F RID: 73343 RVA: 0x004ECD38 File Offset: 0x004EAF38
	[NullableContext(1)]
	private PersonalEditTabItem CreatePersonalEditTabItem()
	{
		PersonalEditTabItem personalEditTabItem = new PersonalEditTabItem();
		personalEditTabItem.SetToggleCallBack(new Action<int, EPersonalEditDefine>(this.TabItemToggleClick));
		return personalEditTabItem;
	}

	// Token: 0x06011E80 RID: 73344 RVA: 0x004ECD54 File Offset: 0x004EAF54
	protected override UniTask OnBeforeStartAsync()
	{
		PersonalEditView.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<PersonalEditView.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06011E81 RID: 73345 RVA: 0x004ECD97 File Offset: 0x004EAF97
	protected override void OnStart()
	{
		IUiPopFrameInterface childPopView = this.ChildPopView;
		if (childPopView == null)
		{
			return;
		}
		childPopView.PopItem.OverrideBackBtnCallBack(new Action(this.OnClose));
	}

	// Token: 0x06011E82 RID: 73346 RVA: 0x004ECDBA File Offset: 0x004EAFBA
	public void TabItemToggleClick(int gridIndex, EPersonalEditDefine personalEditType)
	{
		this.TabLayout.SelectGridProxy(gridIndex, false);
		this.ShowContent(personalEditType).Forget();
	}

	// Token: 0x06011E83 RID: 73347 RVA: 0x004ECDD8 File Offset: 0x004EAFD8
	public UniTask ShowContent(EPersonalEditDefine personalEditType)
	{
		PersonalEditView.<ShowContent>d__15 <ShowContent>d__;
		<ShowContent>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ShowContent>d__.<>4__this = this;
		<ShowContent>d__.personalEditType = personalEditType;
		<ShowContent>d__.<>1__state = -1;
		<ShowContent>d__.<>t__builder.Start<PersonalEditView.<ShowContent>d__15>(ref <ShowContent>d__);
		return <ShowContent>d__.<>t__builder.Task;
	}

	// Token: 0x06011E84 RID: 73348 RVA: 0x004ECE24 File Offset: 0x004EB024
	public void UpdateCollectNum()
	{
		int num = 0;
		switch (this.EditType)
		{
		case EPersonalEditDefine.HeadPhoto:
			num = ModelBase<PersonalModel>.Instance.GetUnlockHeadNum();
			break;
		case EPersonalEditDefine.Card:
			num = this.PersonalInfoData.GetUnlockCardDataCount();
			break;
		case EPersonalEditDefine.PlayerTitle:
			num = ModelBase<PersonalModel>.Instance.GetUnlockTitleDataCount();
			break;
		}
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(2), "Collected", new <>z__ReadOnlySingleElementList<object>(num));
	}

	// Token: 0x06011E85 RID: 73349 RVA: 0x004ECE95 File Offset: 0x004EB095
	public void OnClickedConfirm()
	{
	}

	// Token: 0x06011E86 RID: 73350 RVA: 0x004ECE98 File Offset: 0x004EB098
	protected override void OnBeforeDestroy()
	{
		PersonalHeadPhotoComponent personalHeadPhotoComponent = this.PersonalHeadPhotoComponent;
		if (personalHeadPhotoComponent != null)
		{
			personalHeadPhotoComponent.Destroy(null);
		}
		this.PersonalHeadPhotoComponent = null;
		PersonalCardComponent personalCardComponent = this.PersonalCardComponent;
		if (personalCardComponent != null)
		{
			personalCardComponent.Destroy(null);
		}
		this.PersonalCardComponent = null;
		PersonalPlayerTitleComponent personalTitleComponent = this.PersonalTitleComponent;
		if (personalTitleComponent != null)
		{
			personalTitleComponent.Destroy(null);
		}
		this.PersonalTitleComponent = null;
	}

	// Token: 0x06011E87 RID: 73351 RVA: 0x004ECEF0 File Offset: 0x004EB0F0
	public void RefreshBtnConfirm(bool isInteractive, bool isBeUsed)
	{
		this.ConfirmBtn.SetEnableClick(isInteractive);
		base.GetInteractionGroup(5).SetInteractable(isInteractive);
		string textId;
		if (this.EditType == EPersonalEditDefine.PlayerTitle)
		{
			textId = (isBeUsed ? "Text_PhantomTakeOff_Text" : "ConfirmBox_173_ButtonText_1");
		}
		else
		{
			textId = (isBeUsed ? "Text_InUse_Text" : "ConfirmBox_173_ButtonText_1");
		}
		this.ConfirmBtn.SetLocalTextNew(textId, Array.Empty<object>());
	}

	// Token: 0x06011E88 RID: 73352 RVA: 0x004ECF58 File Offset: 0x004EB158
	private void OnClose()
	{
		if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.PersonalOptionView))
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.PersonalOptionView, null);
		}
		Singleton<UiManager>.Instance.CloseView(EUiViewName.PersonalEditView, null);
	}

	// Token: 0x04008C3A RID: 35898
	private EPersonalEditDefine EditType;

	// Token: 0x04008C3B RID: 35899
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<PersonalEditTabItem, EPersonalEditDefine> TabLayout;

	// Token: 0x04008C3C RID: 35900
	private PersonalCardComponent PersonalCardComponent;

	// Token: 0x04008C3D RID: 35901
	private PersonalHeadPhotoComponent PersonalHeadPhotoComponent;

	// Token: 0x04008C3E RID: 35902
	private PersonalPlayerTitleComponent PersonalTitleComponent;

	// Token: 0x04008C3F RID: 35903
	private PersonalInfoData PersonalInfoData;

	// Token: 0x04008C40 RID: 35904
	private ButtonItem ConfirmBtn;
}
