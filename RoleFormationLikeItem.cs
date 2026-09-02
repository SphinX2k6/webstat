using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001B4B RID: 6987
public class RoleFormationLikeItem : UiPanelBase
{
	// Token: 0x0600CA0D RID: 51725 RVA: 0x0035B438 File Offset: 0x00359638
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600CA0E RID: 51726 RVA: 0x0035B4FF File Offset: 0x003596FF
	private void OnClick()
	{
	}

	// Token: 0x0600CA0F RID: 51727 RVA: 0x0035B504 File Offset: 0x00359704
	public void Refresh(int playerId)
	{
		MatchTeamInfo matchTeamInfo = ModelBase<InstanceDungeonModel>.Instance.GetMatchTeamInfo();
		int num = 0;
		if (matchTeamInfo != null)
		{
			foreach (MatchPlayerInfo matchPlayerInfo in matchTeamInfo.PlayerInfos)
			{
				if (matchPlayerInfo.PlayerId == playerId)
				{
					num = matchPlayerInfo.AbyssLikeCount;
					break;
				}
			}
		}
		base.GetText(1).SetText(num.ToString(), true);
	}

	// Token: 0x02007E2E RID: 32302
	private enum EComponent
	{
		// Token: 0x0402AFA2 RID: 176034
		LikeButton,
		// Token: 0x0402AFA3 RID: 176035
		LikeNumText,
		// Token: 0x0402AFA4 RID: 176036
		LikeIcon
	}
}
