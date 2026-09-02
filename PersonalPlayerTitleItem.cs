using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Personal;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002433 RID: 9267
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class PersonalPlayerTitleItem : GridProxyAbstract<PersonalPlayerTitleData>
{
	// Token: 0x06011EC9 RID: 73417 RVA: 0x004EE6EC File Offset: 0x004EC8EC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.OnClickToggle))
		};
	}

	// Token: 0x06011ECA RID: 73418 RVA: 0x004EE7C4 File Offset: 0x004EC9C4
	protected override UniTask OnBeforeStartAsync()
	{
		PersonalPlayerTitleItem.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<PersonalPlayerTitleItem.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06011ECB RID: 73419 RVA: 0x004EE808 File Offset: 0x004ECA08
	public override void Refresh(PersonalPlayerTitleData data, bool isSelected, int gridIndex)
	{
		if (data == null)
		{
			return;
		}
		this.PersonalPlayerTitleData = data;
		base.GridIndex = gridIndex;
		this.RefreshRedDot(data);
		this.SetToggleState(isSelected);
		this.RefreshState(data);
		if (this.PlayerTitleItem != null)
		{
			int sex = ModelBase<PersonalModel>.Instance.GetSex();
			this.PlayerTitleItem.Refresh(new int?(data.PlayerTitleId), data.StarLevel, new int?(sex));
		}
	}

	// Token: 0x06011ECC RID: 73420 RVA: 0x004EE871 File Offset: 0x004ECA71
	private void RefreshRedDot(PersonalPlayerTitleData data)
	{
		base.GetItem(0).SetUIActive(data.GetIsShowRedDot());
	}

	// Token: 0x06011ECD RID: 73421 RVA: 0x004EE885 File Offset: 0x004ECA85
	private void OnClickToggle(EToggleState toggleState)
	{
		if (this.OnToggleCallBack != null)
		{
			this.OnToggleCallBack(base.GridIndex, this.PersonalPlayerTitleData);
		}
	}

	// Token: 0x06011ECE RID: 73422 RVA: 0x004EE8A6 File Offset: 0x004ECAA6
	public void SetToggleCallBack(Action<int, PersonalPlayerTitleData> callBack)
	{
		this.OnToggleCallBack = callBack;
	}

	// Token: 0x06011ECF RID: 73423 RVA: 0x004EE8B0 File Offset: 0x004ECAB0
	public void SetToggleState(bool state)
	{
		EToggleState state2 = state ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		base.GetExtendToggle(1).SetToggleState(state2, false, false, false);
	}

	// Token: 0x06011ED0 RID: 73424 RVA: 0x004EE8D8 File Offset: 0x004ECAD8
	public override void OnSelected(bool fireEvent)
	{
		this.SetToggleState(true);
		if (this.PersonalPlayerTitleData.GetIsShowRedDot())
		{
			Dictionary<int, bool> dictionary = LocalStorage.GetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.PlayerTitleRecord, null) ?? new Dictionary<int, bool>();
			dictionary[this.PersonalPlayerTitleData.PlayerTitleId] = false;
			LocalStorage.SetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.PlayerTitleRecord, dictionary);
			base.GetItem(0).SetUIActive(false);
			Singleton<EventSystem>.Instance.Emit(EEventName.OnPlayerTitleRefreshRedDot);
		}
	}

	// Token: 0x06011ED1 RID: 73425 RVA: 0x004EE943 File Offset: 0x004ECB43
	public override void OnDeselected(bool fireEvent)
	{
		this.SetToggleState(false);
	}

	// Token: 0x06011ED2 RID: 73426 RVA: 0x004EE94C File Offset: 0x004ECB4C
	public void RefreshState(PersonalPlayerTitleData personalTitle)
	{
		UUIItem item = base.GetItem(3);
		UUIItem item2 = base.GetItem(2);
		if (item != null)
		{
			item.SetUIActive(!personalTitle.IsEffective());
		}
		PersonalInfoData personalInfoData = ModelBase<PersonalModel>.Instance.GetPersonalInfoData();
		if (item2 != null)
		{
			UUIItem uuiitem = item2;
			int playerTitleId = personalTitle.PlayerTitleId;
			int? num = (personalInfoData != null) ? personalInfoData.CurPlayerTitleId : null;
			uuiitem.SetUIActive(playerTitleId == num.GetValueOrDefault() & num != null);
		}
		bool flag = personalTitle.IsTimeLimitTitle();
		UUIItem item3 = base.GetItem(5);
		UUIText text = base.GetText(6);
		if (item3 != null)
		{
			bool uiactive = flag && !personalTitle.IsExpired();
			item3.SetUIActive(uiactive);
		}
		if (flag && !personalTitle.IsExpired() && text != null)
		{
			int remainingDays = personalTitle.GetRemainingDays();
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "LimitTimeTitleShowTime", new <>z__ReadOnlySingleElementList<object>(remainingDays));
		}
	}

	// Token: 0x04008C71 RID: 35953
	[Nullable(2)]
	private PersonalPlayerTitleData PersonalPlayerTitleData;

	// Token: 0x04008C72 RID: 35954
	[Nullable(2)]
	private PlayerTitleItem PlayerTitleItem;

	// Token: 0x04008C73 RID: 35955
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<int, PersonalPlayerTitleData> OnToggleCallBack;
}
