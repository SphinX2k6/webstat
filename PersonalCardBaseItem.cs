using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002420 RID: 9248
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class PersonalCardBaseItem : GridProxyAbstract<PersonalCardData>
{
	// Token: 0x06011E32 RID: 73266 RVA: 0x004EB964 File Offset: 0x004E9B64
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIExtendToggle))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(2, new Action<EToggleState>(this.OnClickToggle))
		};
	}

	// Token: 0x06011E33 RID: 73267 RVA: 0x004EB9E1 File Offset: 0x004E9BE1
	protected override void OnBeforeShow()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnPersonalCardRead, new Action<int>(this.OnPersonalCardRead));
	}

	// Token: 0x06011E34 RID: 73268 RVA: 0x004EB9FF File Offset: 0x004E9BFF
	protected override void OnBeforeHide()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPersonalCardRead, new Action<int>(this.OnPersonalCardRead));
	}

	// Token: 0x06011E35 RID: 73269 RVA: 0x004EBA20 File Offset: 0x004E9C20
	public override void Refresh(PersonalCardData data, bool isSelected, int gridIndex)
	{
		this.CardData = data;
		base.GridIndex = gridIndex;
		this.CardConfig = ConfigBase<InventoryConfig>.Instance.GetCardItemConfig(data.CardId);
		this.RefreshRedDot(data);
		this.SetToggleState(isSelected);
		base.SetTextureByPath(this.CardConfig.Value.CardPath, base.GetTexture(0), null, null);
	}

	// Token: 0x06011E36 RID: 73270 RVA: 0x004EBA89 File Offset: 0x004E9C89
	private void RefreshRedDot(PersonalCardData data)
	{
		base.GetItem(1).SetUIActive(data.IsUnLock && !data.IsRead && this.NeedShowRedDot);
	}

	// Token: 0x06011E37 RID: 73271 RVA: 0x004EBAB0 File Offset: 0x004E9CB0
	private void OnClickToggle(EToggleState toggleState)
	{
		if (this.OnToggleCallBack != null)
		{
			this.OnToggleCallBack(base.GridIndex, this.CardData);
		}
	}

	// Token: 0x06011E38 RID: 73272 RVA: 0x004EBAD1 File Offset: 0x004E9CD1
	public void SetNeedShowRedDot(bool state)
	{
		this.NeedShowRedDot = state;
	}

	// Token: 0x06011E39 RID: 73273 RVA: 0x004EBADA File Offset: 0x004E9CDA
	public void SetToggleCallBack(Action<int, PersonalCardData> callBack)
	{
		this.OnToggleCallBack = callBack;
	}

	// Token: 0x06011E3A RID: 73274 RVA: 0x004EBAE4 File Offset: 0x004E9CE4
	public void SetToggleState(bool state)
	{
		EToggleState state2 = state ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		base.GetExtendToggle(2).SetToggleState(state2, false, false, false);
	}

	// Token: 0x06011E3B RID: 73275 RVA: 0x004EBB0A File Offset: 0x004E9D0A
	public override void OnSelected(bool fireEvent)
	{
		this.SetToggleState(true);
	}

	// Token: 0x06011E3C RID: 73276 RVA: 0x004EBB13 File Offset: 0x004E9D13
	public override void OnDeselected(bool fireEvent)
	{
		this.SetToggleState(false);
	}

	// Token: 0x06011E3D RID: 73277 RVA: 0x004EBB1C File Offset: 0x004E9D1C
	public BackgroundCard GetConfig()
	{
		return this.CardConfig.Value;
	}

	// Token: 0x06011E3E RID: 73278 RVA: 0x004EBB29 File Offset: 0x004E9D29
	private void OnPersonalCardRead(int cardId)
	{
		if (cardId != this.CardData.CardId)
		{
			return;
		}
		this.RefreshRedDot(this.CardData);
	}

	// Token: 0x04008C0B RID: 35851
	[Nullable(2)]
	protected PersonalCardData CardData;

	// Token: 0x04008C0C RID: 35852
	protected BackgroundCard? CardConfig;

	// Token: 0x04008C0D RID: 35853
	protected bool NeedShowRedDot = true;

	// Token: 0x04008C0E RID: 35854
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected Action<int, PersonalCardData> OnToggleCallBack;
}
