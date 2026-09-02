using System;
using System.Collections.Generic;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002570 RID: 9584
public class SettingPanelChatItem : UiPanelBase
{
	// Token: 0x06012A58 RID: 76376 RVA: 0x00524428 File Offset: 0x00522628
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUITexture)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(9, typeof(UUITexture)),
			new ValueTuple<int, Type>(10, typeof(UUISprite)),
			new ValueTuple<int, Type>(11, typeof(UUIText))
		};
	}

	// Token: 0x06012A59 RID: 76377 RVA: 0x0052454C File Offset: 0x0052274C
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

	// Token: 0x06012A5A RID: 76378 RVA: 0x00524588 File Offset: 0x00522788
	public void OnNameChange()
	{
		string text = ModelBase<FunctionModel>.Instance.GetPlayerName() ?? "";
		if (!string.IsNullOrEmpty(text))
		{
			base.GetText(2).SetText(text, true);
			UUIText text2 = base.GetText(11);
			if (text2 != null)
			{
				text2.SetText(text, true);
			}
		}
	}
}
