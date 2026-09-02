using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002578 RID: 9592
public class PhoneMsgTipViewA : UiPanelBase
{
	// Token: 0x06012A83 RID: 76419 RVA: 0x00524E0C File Offset: 0x0052300C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUISprite)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIText))
		};
	}

	// Token: 0x06012A84 RID: 76420 RVA: 0x00524EC0 File Offset: 0x005230C0
	protected override void OnStart()
	{
		ShortMessage? shortMessage = this.OpenParam as ShortMessage?;
		this.SeqPlayer = new LevelSequencePlayer(this.RootItem);
		if (shortMessage == null)
		{
			return;
		}
		this.OnRefreshByData(shortMessage.Value);
	}

	// Token: 0x06012A85 RID: 76421 RVA: 0x00524F08 File Offset: 0x00523108
	public void OnRefreshByData(ShortMessage msgData)
	{
		this.MsgData = new ShortMessage?(msgData);
		int whichChat = this.MsgData.Value.WhichChat;
		ChatPartner? chatPartnerConfigNew = ModelBase<PhoneMsgModel>.Instance.GetChatPartnerConfigNew(whichChat);
		if (this.MsgData == null || chatPartnerConfigNew == null)
		{
			return;
		}
		UUIText text = base.GetText(6);
		text.bGameRichText = true;
		text.richText = true;
		string icon = chatPartnerConfigNew.Value.Icon;
		base.SetTextureByPath(icon, base.GetTexture(1), null, null);
	}

	// Token: 0x06012A86 RID: 76422 RVA: 0x00524F96 File Offset: 0x00523196
	protected override void OnBeforeDestroy()
	{
		LevelSequencePlayer seqPlayer = this.SeqPlayer;
		if (seqPlayer != null)
		{
			seqPlayer.Clear();
		}
		this.SeqPlayer = null;
		this.RootActor.OnSequencePlayEvent.Unbind();
	}

	// Token: 0x06012A87 RID: 76423 RVA: 0x00524FC0 File Offset: 0x005231C0
	public int? GetMessageDataId()
	{
		if (this.MsgData == null)
		{
			return null;
		}
		return new int?(this.MsgData.Value.Id);
	}

	// Token: 0x040091C1 RID: 37313
	private ShortMessage? MsgData;

	// Token: 0x040091C2 RID: 37314
	[Nullable(2)]
	private LevelSequencePlayer SeqPlayer;

	// Token: 0x02008896 RID: 34966
	private enum EComponent
	{
		// Token: 0x0402E21A RID: 188954
		BtnClick,
		// Token: 0x0402E21B RID: 188955
		TexHeadIcon,
		// Token: 0x0402E21C RID: 188956
		PanelFold,
		// Token: 0x0402E21D RID: 188957
		PanelUnFold,
		// Token: 0x0402E21E RID: 188958
		ItemProgressBar,
		// Token: 0x0402E21F RID: 188959
		TxtRoleName,
		// Token: 0x0402E220 RID: 188960
		TxtMsgInfo
	}
}
