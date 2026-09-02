using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200258F RID: 9615
[NullableContext(2)]
[Nullable(0)]
public class TogChatPartner : UiPanelBase
{
	// Token: 0x06012BA0 RID: 76704 RVA: 0x0052A708 File Offset: 0x00528908
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUISprite)),
			new ValueTuple<int, Type>(7, typeof(UUISprite)),
			new ValueTuple<int, Type>(8, typeof(UUIText)),
			new ValueTuple<int, Type>(9, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickTogSelf))
		};
	}

	// Token: 0x06012BA1 RID: 76705 RVA: 0x0052A820 File Offset: 0x00528A20
	public void SetChangeAlpha(bool isEnable)
	{
		base.GetItem(9).SetAlpha(isEnable ? 0.5f : 1f);
	}

	// Token: 0x06012BA2 RID: 76706 RVA: 0x0052A83E File Offset: 0x00528A3E
	protected override void OnStart()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnPhoneMsgChatTabClick, new Action<int, int>(this.HandleSubItemSelected));
	}

	// Token: 0x06012BA3 RID: 76707 RVA: 0x0052A85C File Offset: 0x00528A5C
	protected override void OnBeforeDestroy()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPhoneMsgChatTabClick, new Action<int, int>(this.HandleSubItemSelected));
		ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.PhoneMsgChatPartnerRedDot, base.GetItem(3), this.ChatPartnerId);
		ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.PhoneMsgChatPartnerRedDotGiftIcon, base.GetItem(5), this.ChatPartnerId);
	}

	// Token: 0x06012BA4 RID: 76708 RVA: 0x0052A8B7 File Offset: 0x00528AB7
	public UUIExtendToggle GetTogglePartner()
	{
		return base.GetExtendToggle(0);
	}

	// Token: 0x06012BA5 RID: 76709 RVA: 0x0052A8C0 File Offset: 0x00528AC0
	public void RefreshView(int chatPartnerId, bool isSelected, int gridIndex)
	{
		ChatPartner? chatPartnerConfigNew = ModelBase<PhoneMsgModel>.Instance.GetChatPartnerConfigNew(chatPartnerId);
		if (chatPartnerConfigNew == null)
		{
			return;
		}
		ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.PhoneMsgChatPartnerRedDot, base.GetItem(3), this.ChatPartnerId);
		ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.PhoneMsgChatPartnerRedDotGiftIcon, base.GetItem(5), this.ChatPartnerId);
		this.ChatPartnerId = chatPartnerId;
		string iconMid = chatPartnerConfigNew.Value.IconMid;
		if (!string.IsNullOrEmpty(iconMid))
		{
			base.SetTextureByPath(iconMid, base.GetTexture(1), null, null);
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), chatPartnerConfigNew.Value.Name, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), chatPartnerConfigNew.Value.Name, Array.Empty<object>());
		ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.PhoneMsgChatPartnerRedDot, base.GetItem(3), null, this.ChatPartnerId);
		ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.PhoneMsgChatPartnerRedDotGiftIcon, base.GetItem(5), null, this.ChatPartnerId);
	}

	// Token: 0x06012BA6 RID: 76710 RVA: 0x0052A9CA File Offset: 0x00528BCA
	[NullableContext(1)]
	public void SetClickCallBack(Action func)
	{
		this.OnClickTogCallBack = func;
	}

	// Token: 0x06012BA7 RID: 76711 RVA: 0x0052A9D3 File Offset: 0x00528BD3
	private void OnClickTogSelf(EToggleState toggleState)
	{
		if (this.OnClickTogCallBack != null)
		{
			this.OnClickTogCallBack();
		}
	}

	// Token: 0x06012BA8 RID: 76712 RVA: 0x0052A9E8 File Offset: 0x00528BE8
	public void SetSelected(bool isSelected)
	{
		base.GetText(2).SetUIActive(!isSelected);
		base.GetText(8).SetUIActive(isSelected);
	}

	// Token: 0x06012BA9 RID: 76713 RVA: 0x0052AA07 File Offset: 0x00528C07
	public void HandleSubItemSelected(int messageId, int chatPartnerId)
	{
		if (chatPartnerId == this.ChatPartnerId)
		{
			this.SetSelectBgShow(true);
			return;
		}
		this.SetSelectBgShow(false);
	}

	// Token: 0x06012BAA RID: 76714 RVA: 0x0052AA21 File Offset: 0x00528C21
	public void SetSelectBgShow(bool isShow)
	{
		base.GetSprite(7).SetUIActive(isShow);
	}

	// Token: 0x04009252 RID: 37458
	private Action OnClickTogCallBack;

	// Token: 0x04009253 RID: 37459
	private int ChatPartnerId;

	// Token: 0x04009254 RID: 37460
	public UUIExtendToggle Toggle;

	// Token: 0x020088D7 RID: 35031
	[NullableContext(0)]
	private enum EChatPartnerComponent
	{
		// Token: 0x0402E332 RID: 189234
		TogSelf,
		// Token: 0x0402E333 RID: 189235
		TexHeadIcon,
		// Token: 0x0402E334 RID: 189236
		TxtNameNotSelect,
		// Token: 0x0402E335 RID: 189237
		ItemRedDot,
		// Token: 0x0402E336 RID: 189238
		TxtCount,
		// Token: 0x0402E337 RID: 189239
		ItemGiftIcon,
		// Token: 0x0402E338 RID: 189240
		SpriteBgNotSelect,
		// Token: 0x0402E339 RID: 189241
		SpriteBgSelect,
		// Token: 0x0402E33A RID: 189242
		TxtNameSelect,
		// Token: 0x0402E33B RID: 189243
		PanelSetAlpha
	}
}
