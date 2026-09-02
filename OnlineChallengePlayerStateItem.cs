using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Personal;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002342 RID: 9026
public class OnlineChallengePlayerStateItem : GridProxyAbstract<int>
{
	// Token: 0x060113A5 RID: 70565 RVA: 0x004BB030 File Offset: 0x004B9230
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x060113A6 RID: 70566 RVA: 0x004BB0DC File Offset: 0x004B92DC
	public override void Refresh(int data, bool isSelected, int gridIndex)
	{
		this.PlayerId = data;
		OnlineTeamData currentTeamListById = ModelBase<OnlineModel>.Instance.GetCurrentTeamListById(this.PlayerId);
		if (currentTeamListById == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.MultiPlayerTeam;
			ELogAuthor author = ELogAuthor.LJQ;
			string message = "获取队友联机时，失败";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("PlayerId", this.PlayerId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		base.GetText(1).SetText(currentTeamListById.Name, true);
		PlayerHeadData playerHeadData = ModelBase<PersonalModel>.Instance.GetPlayerHeadData(currentTeamListById.HeadId, false);
		if (playerHeadData != null)
		{
			base.SetTextureByPath(playerHeadData.GetRoleHeadIconCircle(), base.GetTexture(0), null, null);
		}
		EContinuingChallenge? continuingChallengeConfirmState = ModelBase<OnlineModel>.Instance.GetContinuingChallengeConfirmState(this.PlayerId);
		this.SetTeamPlayerSprite(this.PlayerId, continuingChallengeConfirmState.Value);
	}

	// Token: 0x060113A7 RID: 70567 RVA: 0x004BB1A0 File Offset: 0x004B93A0
	public void SetTeamPlayerSprite(int playerId, EContinuingChallenge state)
	{
		if (this.PlayerId != playerId)
		{
			return;
		}
		switch (state)
		{
		case EContinuingChallenge.Accept:
		{
			UUIItem item = base.GetItem(2);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			UUIItem item2 = base.GetItem(3);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(false);
			return;
		}
		case EContinuingChallenge.Leave:
		{
			UUIItem item3 = base.GetItem(2);
			if (item3 != null)
			{
				item3.SetUIActive(false);
			}
			UUIItem item4 = base.GetItem(3);
			if (item4 == null)
			{
				return;
			}
			item4.SetUIActive(false);
			return;
		}
		case EContinuingChallenge.Pending:
		{
			UUIItem item5 = base.GetItem(2);
			if (item5 != null)
			{
				item5.SetUIActive(false);
			}
			UUIItem item6 = base.GetItem(3);
			if (item6 == null)
			{
				return;
			}
			item6.SetUIActive(true);
			return;
		}
		default:
			return;
		}
	}

	// Token: 0x0400876C RID: 34668
	private int PlayerId = -1;

	// Token: 0x02008650 RID: 34384
	private enum EOnlineChallengePlayerStateItem
	{
		// Token: 0x0402D6CB RID: 186059
		PlayHeadTexture,
		// Token: 0x0402D6CC RID: 186060
		PlayerNameText,
		// Token: 0x0402D6CD RID: 186061
		AcceptItem,
		// Token: 0x0402D6CE RID: 186062
		PendingItem
	}
}
