using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002429 RID: 9257
public class PersonalEditTabItem : GridProxyAbstract<EPersonalEditDefine>
{
	// Token: 0x06011E71 RID: 73329 RVA: 0x004ECA7C File Offset: 0x004EAC7C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle))
		};
	}

	// Token: 0x06011E72 RID: 73330 RVA: 0x004ECAFC File Offset: 0x004EACFC
	public override void Refresh(EPersonalEditDefine personalEditType, bool isSelected, int gridIndex)
	{
		this.PersonalEditType = personalEditType;
		string textStringId = string.Empty;
		switch (personalEditType)
		{
		case EPersonalEditDefine.HeadPhoto:
			textStringId = "Personalize_HeadPhoto";
			break;
		case EPersonalEditDefine.Card:
			textStringId = "Personalize_Card";
			this.RedDotName = new ERedDotName?(ERedDotName.PersonalCard);
			break;
		case EPersonalEditDefine.PlayerTitle:
			textStringId = "Personalize_Title";
			this.RedDotName = new ERedDotName?(ERedDotName.PersonalTitle);
			break;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textStringId, Array.Empty<object>());
		this.BindRedDot();
	}

	// Token: 0x06011E73 RID: 73331 RVA: 0x004ECB7D File Offset: 0x004EAD7D
	private void OnClickToggle(EToggleState toggleState)
	{
		if (this.OnToggleCallBack != null)
		{
			this.OnToggleCallBack(base.GridIndex, this.PersonalEditType);
		}
	}

	// Token: 0x06011E74 RID: 73332 RVA: 0x004ECB9E File Offset: 0x004EAD9E
	[NullableContext(1)]
	public void SetToggleCallBack(Action<int, EPersonalEditDefine> callBack)
	{
		this.OnToggleCallBack = callBack;
	}

	// Token: 0x06011E75 RID: 73333 RVA: 0x004ECBA8 File Offset: 0x004EADA8
	public void BindRedDot()
	{
		if (this.RedDotName != null)
		{
			UUIItem item = base.GetItem(2);
			ControllerBase<RedDotController>.Instance.BindRedDot(this.RedDotName.Value, item, null, 0);
		}
	}

	// Token: 0x06011E76 RID: 73334 RVA: 0x004ECBE2 File Offset: 0x004EADE2
	protected override void OnBeforeDestroy()
	{
		this.UnBindRedDot();
	}

	// Token: 0x06011E77 RID: 73335 RVA: 0x004ECBEA File Offset: 0x004EADEA
	public void UnBindRedDot()
	{
		if (this.RedDotName != null)
		{
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(this.RedDotName.Value, base.GetItem(2), 0);
			this.RedDotName = null;
		}
	}

	// Token: 0x06011E78 RID: 73336 RVA: 0x004ECC24 File Offset: 0x004EAE24
	public void SetToggleState(bool state)
	{
		EToggleState state2 = state ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		base.GetExtendToggle(0).SetToggleState(state2, false, false, false);
	}

	// Token: 0x06011E79 RID: 73337 RVA: 0x004ECC4A File Offset: 0x004EAE4A
	public override void OnSelected(bool fireEvent)
	{
		if (this.PersonalEditType == EPersonalEditDefine.PlayerTitle)
		{
			LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.PlayerTitleUnlockRedDot, false);
			Singleton<EventSystem>.Instance.Emit(EEventName.OnPlayerTitleRefreshRedDot);
		}
		this.SetToggleState(true);
	}

	// Token: 0x06011E7A RID: 73338 RVA: 0x004ECC75 File Offset: 0x004EAE75
	public override void OnDeselected(bool fireEvent)
	{
		this.SetToggleState(false);
	}

	// Token: 0x04008C30 RID: 35888
	private ERedDotName? RedDotName;

	// Token: 0x04008C31 RID: 35889
	private EPersonalEditDefine PersonalEditType;

	// Token: 0x04008C32 RID: 35890
	[Nullable(2)]
	protected Action<int, EPersonalEditDefine> OnToggleCallBack;
}
