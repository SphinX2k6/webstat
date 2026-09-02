using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.PhoneMessage;
using UnrealEngine;

// Token: 0x02002574 RID: 9588
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class PhoneMsgBgItem : SyncGridProxyAbstract<PhoneMsgBgItemData>
{
	// Token: 0x06012A69 RID: 76393 RVA: 0x00524968 File Offset: 0x00522B68
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUISprite)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle))
		};
	}

	// Token: 0x06012A6A RID: 76394 RVA: 0x00524A27 File Offset: 0x00522C27
	protected override void OnStart()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.PhoneMsgDialogAndBgUpdate, new Action(this.OnRedDotUpdate));
	}

	// Token: 0x06012A6B RID: 76395 RVA: 0x00524A45 File Offset: 0x00522C45
	protected override void OnBeforeDestroy()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.PhoneMsgDialogAndBgUpdate, new Action(this.OnRedDotUpdate));
	}

	// Token: 0x06012A6C RID: 76396 RVA: 0x00524A63 File Offset: 0x00522C63
	private void OnRedDotUpdate()
	{
		this.RefreshRedDot();
	}

	// Token: 0x06012A6D RID: 76397 RVA: 0x00524A6B File Offset: 0x00522C6B
	public void RefreshRedDot()
	{
		UUIItem item = base.GetItem(5);
		PhoneMsgBgItemData phoneMsgBgData = this.PhoneMsgBgData;
		item.SetUIActive(phoneMsgBgData != null && phoneMsgBgData.IsHasRedDot());
	}

	// Token: 0x06012A6E RID: 76398 RVA: 0x00524A8C File Offset: 0x00522C8C
	public override void Refresh(PhoneMsgBgItemData data)
	{
		if (data == null)
		{
			return;
		}
		this.PhoneMsgBgData = data;
		ChatBg? chatBgConfig = ConfigBase<PhoneMsgConfig>.Instance.GetChatBgConfig(data.BgId);
		if (chatBgConfig != null)
		{
			base.SetTextureByPath(chatBgConfig.Value.ChatBgPathSmall, base.GetTexture(2), null, null);
		}
		base.GetSprite(3).SetUIActive(data.IsUsing);
		base.GetItem(4).SetUIActive(!data.IsUnlocked);
		base.GetItem(5).SetUIActive(data.IsHasRedDot());
		this.SetToggleState(data.IsSelected, true);
	}

	// Token: 0x06012A6F RID: 76399 RVA: 0x00524B2C File Offset: 0x00522D2C
	private void OnClickToggle(EToggleState toggleState)
	{
		if (this.OnToggleCallBack != null && this.PhoneMsgBgData != null)
		{
			this.OnToggleCallBack(base.GridIndex, this.PhoneMsgBgData);
		}
		PhoneMsgBgItemData phoneMsgBgData = this.PhoneMsgBgData;
		if (phoneMsgBgData != null && phoneMsgBgData.IsHasRedDot())
		{
			ModelBase<PhoneMsgModel>.Instance.RemoveChatShowRedDotById(this.PhoneMsgBgData.BgId);
			base.GetItem(5).SetUIActive(false);
		}
	}

	// Token: 0x06012A70 RID: 76400 RVA: 0x00524B98 File Offset: 0x00522D98
	public void SetToggleState(bool state, bool isFirstRefresh = false)
	{
		if (this.PhoneMsgBgData == null)
		{
			return;
		}
		this.PhoneMsgBgData.IsSelected = state;
		EToggleState state2 = state ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		base.GetExtendToggle(0).SetToggleState(state2, false, isFirstRefresh, isFirstRefresh);
	}

	// Token: 0x06012A71 RID: 76401 RVA: 0x00524BD3 File Offset: 0x00522DD3
	public void OnSelected()
	{
		this.SetToggleState(true, false);
	}

	// Token: 0x06012A72 RID: 76402 RVA: 0x00524BDD File Offset: 0x00522DDD
	public void OnDeselected()
	{
		this.SetToggleState(false, false);
	}

	// Token: 0x06012A73 RID: 76403 RVA: 0x00524BE8 File Offset: 0x00522DE8
	public void RefreshSpeakerNameTextColor(int bgId)
	{
		bool flag = ModelBase<PhoneMsgModel>.Instance.IsDefaultChatBg(bgId);
		base.GetText(2).SetUIActive(flag);
		UUIText text = base.GetText(11);
		if (text == null)
		{
			return;
		}
		text.SetUIActive(!flag);
	}

	// Token: 0x06012A74 RID: 76404 RVA: 0x00524C24 File Offset: 0x00522E24
	public void HideRedDot()
	{
		base.GetItem(5).SetUIActive(false);
	}

	// Token: 0x040091BA RID: 37306
	[Nullable(2)]
	private PhoneMsgBgItemData PhoneMsgBgData;

	// Token: 0x040091BB RID: 37307
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<int, PhoneMsgBgItemData> OnToggleCallBack;
}
