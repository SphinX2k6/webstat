using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002723 RID: 10019
public class RacingBetsLegMatchTabItem : UiPanelBase
{
	// Token: 0x06013C29 RID: 80937 RVA: 0x0057FC81 File Offset: 0x0057DE81
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText))
		};
	}

	// Token: 0x06013C2A RID: 80938 RVA: 0x0057FCBC File Offset: 0x0057DEBC
	[NullableContext(2)]
	public void RefreshUi(RacingBetsLegMatchData legMatchData)
	{
		if (legMatchData == null)
		{
			this.SetActive(false);
			return;
		}
		UUIText text = base.GetText(0);
		if (text != null)
		{
			text.ShowTextNew(legMatchData.Name);
		}
		DateTime dateTime = DateTimeOffset.FromUnixTimeMilliseconds((long)legMatchData.MatchStartTime).DateTime;
		UUIText text2 = base.GetText(1);
		if (text2 == null)
		{
			return;
		}
		text2.SetText(Singleton<TimeUtil>.Instance.DateFormat3(dateTime), true);
	}

	// Token: 0x02008ACA RID: 35530
	private enum EComponent
	{
		// Token: 0x0402ECB1 RID: 191665
		MatchNameText,
		// Token: 0x0402ECB2 RID: 191666
		TimeIntervalText
	}
}
