using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Core.Common;

// Token: 0x02002334 RID: 9012
[NullableContext(1)]
[Nullable(0)]
public class OnlineHallData : IOnlinePlayerData, IPlayerData
{
	// Token: 0x17001546 RID: 5446
	// (get) Token: 0x060112E7 RID: 70375 RVA: 0x004B8720 File Offset: 0x004B6920
	public int CurUsingCardId
	{
		get
		{
			return this.CurUsingCardIdInternal;
		}
	}

	// Token: 0x17001547 RID: 5447
	// (get) Token: 0x060112E8 RID: 70376 RVA: 0x004B8728 File Offset: 0x004B6928
	public List<PersonalCardData> CardUnlockList
	{
		get
		{
			return this._cardUnlockList;
		}
	}

	// Token: 0x060112E9 RID: 70377 RVA: 0x004B8730 File Offset: 0x004B6930
	public OnlineHallData(PlayerDetails playerDetails)
	{
		this.PlayerDetailsInternal = playerDetails;
		foreach (int cardId in playerDetails.CardShowList)
		{
			this.CardUnlockList.Add(new PersonalCardData(cardId, true, true));
		}
		this.CurUsingCardIdInternal = playerDetails.CurCard;
	}

	// Token: 0x060112EA RID: 70378 RVA: 0x004B87B0 File Offset: 0x004B69B0
	public void SetApplyTime(double time)
	{
		if (time <= 0.0)
		{
			return;
		}
		this.RefuseTimestampInternal = time;
	}

	// Token: 0x17001548 RID: 5448
	// (get) Token: 0x060112EB RID: 70379 RVA: 0x004B87C6 File Offset: 0x004B69C6
	public double ApplyTimeLeftTime
	{
		get
		{
			return this.RefuseTimestampInternal - Singleton<TimeUtil>.Instance.GetServerTime();
		}
	}

	// Token: 0x17001549 RID: 5449
	// (get) Token: 0x060112EC RID: 70380 RVA: 0x004B87D9 File Offset: 0x004B69D9
	public int PlayerId
	{
		get
		{
			return this.PlayerDetailsInternal.PlayerId;
		}
	}

	// Token: 0x1700154A RID: 5450
	// (get) Token: 0x060112ED RID: 70381 RVA: 0x004B87E6 File Offset: 0x004B69E6
	public int HeadId
	{
		get
		{
			return this.PlayerDetailsInternal.HeadId;
		}
	}

	// Token: 0x1700154B RID: 5451
	// (get) Token: 0x060112EE RID: 70382 RVA: 0x004B87F3 File Offset: 0x004B69F3
	public int Level
	{
		get
		{
			return this.PlayerDetailsInternal.Level;
		}
	}

	// Token: 0x1700154C RID: 5452
	// (get) Token: 0x060112EF RID: 70383 RVA: 0x004B8800 File Offset: 0x004B6A00
	public int PlayerCount
	{
		get
		{
			return this.PlayerDetailsInternal.TeamMemberCount;
		}
	}

	// Token: 0x1700154D RID: 5453
	// (get) Token: 0x060112F0 RID: 70384 RVA: 0x004B880D File Offset: 0x004B6A0D
	public int WorldLevel
	{
		get
		{
			return this.PlayerDetailsInternal.CurWorldLevel;
		}
	}

	// Token: 0x1700154E RID: 5454
	// (get) Token: 0x060112F1 RID: 70385 RVA: 0x004B881A File Offset: 0x004B6A1A
	public string Name
	{
		get
		{
			return this.PlayerDetailsInternal.Name;
		}
	}

	// Token: 0x1700154F RID: 5455
	// (get) Token: 0x060112F2 RID: 70386 RVA: 0x004B8827 File Offset: 0x004B6A27
	public string PlayerName
	{
		get
		{
			return this.PlayerDetailsInternal.Name;
		}
	}

	// Token: 0x17001550 RID: 5456
	// (get) Token: 0x060112F3 RID: 70387 RVA: 0x004B8834 File Offset: 0x004B6A34
	public string Signature
	{
		get
		{
			return this.PlayerDetailsInternal.Signature;
		}
	}

	// Token: 0x17001551 RID: 5457
	// (get) Token: 0x060112F4 RID: 70388 RVA: 0x004B8841 File Offset: 0x004B6A41
	public int PlayerCard
	{
		get
		{
			return this.PlayerDetailsInternal.CurCard;
		}
	}

	// Token: 0x17001552 RID: 5458
	// (get) Token: 0x060112F5 RID: 70389 RVA: 0x004B884E File Offset: 0x004B6A4E
	public int PlayerTitleId
	{
		get
		{
			return this.PlayerDetailsInternal.PlayerTitleId;
		}
	}

	// Token: 0x17001553 RID: 5459
	// (get) Token: 0x060112F6 RID: 70390 RVA: 0x004B885B File Offset: 0x004B6A5B
	public int PlayerTitleStarLevel
	{
		get
		{
			return this.PlayerDetailsInternal.PlayerTitleExtraParam;
		}
	}

	// Token: 0x17001554 RID: 5460
	// (get) Token: 0x060112F7 RID: 70391 RVA: 0x004B8868 File Offset: 0x004B6A68
	public int Sex
	{
		get
		{
			return this.PlayerDetailsInternal.Sex;
		}
	}

	// Token: 0x17001555 RID: 5461
	// (get) Token: 0x060112F8 RID: 70392 RVA: 0x004B8875 File Offset: 0x004B6A75
	public PlayerDetails PlayerDetails
	{
		get
		{
			return this.PlayerDetailsInternal;
		}
	}

	// Token: 0x17001556 RID: 5462
	// (get) Token: 0x060112F9 RID: 70393 RVA: 0x004B887D File Offset: 0x004B6A7D
	public int PlayerOriginWorldLevel
	{
		get
		{
			return this.PlayerDetailsInternal.OriginWorldLevel;
		}
	}

	// Token: 0x17001557 RID: 5463
	// (get) Token: 0x060112FA RID: 70394 RVA: 0x004B888A File Offset: 0x004B6A8A
	public bool Deactivation
	{
		get
		{
			return this.PlayerDetailsInternal.Deactivation;
		}
	}

	// Token: 0x17001558 RID: 5464
	// (get) Token: 0x060112FB RID: 70395 RVA: 0x004B8897 File Offset: 0x004B6A97
	public long PlayerLastOfflineTime
	{
		get
		{
			return this.PlayerDetailsInternal.LastOfflineTime;
		}
	}

	// Token: 0x17001559 RID: 5465
	// (get) Token: 0x060112FC RID: 70396 RVA: 0x004B88A4 File Offset: 0x004B6AA4
	public string ThirdPartyUserId
	{
		get
		{
			if (Singleton<Info>.Instance.IsPs5Platform())
			{
				return this.PlayerDetailsInternal.PsnAccountId;
			}
			return this.PlayerDetailsInternal.XboxUserId;
		}
	}

	// Token: 0x1700155A RID: 5466
	// (get) Token: 0x060112FD RID: 70397 RVA: 0x004B88C9 File Offset: 0x004B6AC9
	public string ThirdAvoidId
	{
		get
		{
			if (Singleton<Info>.Instance.IsPs5Platform())
			{
				return this.PlayerDetailsInternal.PsnAccountId;
			}
			return this.PlayerDetailsInternal.XboxAccountId;
		}
	}

	// Token: 0x060112FE RID: 70398 RVA: 0x004B88EE File Offset: 0x004B6AEE
	public bool GetIfCanShowInHallList([Nullable(new byte[]
	{
		2,
		1
	})] Dictionary<string, bool> blockMap = null)
	{
		return (!ControllerBase<KuroSdkController>.Instance.PlayOnly() || !(this.ThirdAvoidId == "")) && (blockMap == null || !blockMap.ContainsKey(this.ThirdAvoidId));
	}

	// Token: 0x0400870F RID: 34575
	private readonly PlayerDetails PlayerDetailsInternal;

	// Token: 0x04008710 RID: 34576
	private List<PersonalCardData> _cardUnlockList = new List<PersonalCardData>();

	// Token: 0x04008711 RID: 34577
	private int CurUsingCardIdInternal;

	// Token: 0x04008712 RID: 34578
	private double RefuseTimestampInternal;
}
