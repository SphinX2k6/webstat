using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Core.Common;

// Token: 0x02002336 RID: 9014
[NullableContext(1)]
[Nullable(0)]
public class OnlineTeamData : IOnlinePlayerData, IPlayerData
{
	// Token: 0x17001561 RID: 5473
	// (get) Token: 0x06011306 RID: 70406 RVA: 0x004B899F File Offset: 0x004B6B9F
	public List<PersonalCardData> CardUnlockList
	{
		get
		{
			return this._cardUnlockList;
		}
	}

	// Token: 0x17001562 RID: 5474
	// (get) Token: 0x06011307 RID: 70407 RVA: 0x004B89A7 File Offset: 0x004B6BA7
	public int CurUsingCardId
	{
		get
		{
			return this.CurUsingCardIdInternal;
		}
	}

	// Token: 0x06011308 RID: 70408 RVA: 0x004B89B0 File Offset: 0x004B6BB0
	public OnlineTeamData(string name, int playerId, int level, int headId, string signature, int playerNumber, PlayerDetails playerDetails, ENetPingState ping, int playerTitleId, int playerTitleStarLevel, int sex, int worldLevel)
	{
		this.NameInternal = name;
		this.PlayerIdInternal = playerId;
		this.LevelInternal = level;
		this.HeadIdInternal = headId;
		this.SignatureInternal = signature;
		this.PlayerNumber = playerNumber;
		this.PlayerDetailsInternal = playerDetails;
		this.PingStateInternal = ENetPingState.Great;
		this.PlayerTitleIdInternal = playerTitleId;
		this.PlayerTitleStarLevelInternal = playerTitleStarLevel;
		this.SexInternal = sex;
		this.WorldLevelInternal = worldLevel;
		foreach (int cardId in playerDetails.CardShowList)
		{
			this.CardUnlockList.Add(new PersonalCardData(cardId, true, true));
		}
		this.CurUsingCardIdInternal = playerDetails.CurCard;
	}

	// Token: 0x17001563 RID: 5475
	// (get) Token: 0x06011309 RID: 70409 RVA: 0x004B8A8C File Offset: 0x004B6C8C
	public int PlayerId
	{
		get
		{
			return this.PlayerIdInternal;
		}
	}

	// Token: 0x17001564 RID: 5476
	// (get) Token: 0x0601130A RID: 70410 RVA: 0x004B8A94 File Offset: 0x004B6C94
	// (set) Token: 0x0601130B RID: 70411 RVA: 0x004B8A9C File Offset: 0x004B6C9C
	public int HeadId
	{
		get
		{
			return this.HeadIdInternal;
		}
		set
		{
			this.HeadIdInternal = value;
		}
	}

	// Token: 0x17001565 RID: 5477
	// (get) Token: 0x0601130C RID: 70412 RVA: 0x004B8AA5 File Offset: 0x004B6CA5
	// (set) Token: 0x0601130D RID: 70413 RVA: 0x004B8AAD File Offset: 0x004B6CAD
	public int Level
	{
		get
		{
			return this.LevelInternal;
		}
		set
		{
			this.LevelInternal = value;
		}
	}

	// Token: 0x17001566 RID: 5478
	// (get) Token: 0x0601130E RID: 70414 RVA: 0x004B8AB6 File Offset: 0x004B6CB6
	// (set) Token: 0x0601130F RID: 70415 RVA: 0x004B8ABE File Offset: 0x004B6CBE
	public string Name
	{
		get
		{
			return this.GetFormationName();
		}
		set
		{
			this.NameInternal = value;
		}
	}

	// Token: 0x17001567 RID: 5479
	// (get) Token: 0x06011310 RID: 70416 RVA: 0x004B8AC7 File Offset: 0x004B6CC7
	public int PlayerTitleId
	{
		get
		{
			return this.PlayerTitleIdInternal;
		}
	}

	// Token: 0x17001568 RID: 5480
	// (get) Token: 0x06011311 RID: 70417 RVA: 0x004B8ACF File Offset: 0x004B6CCF
	public int PlayerTitleStarLevel
	{
		get
		{
			return this.PlayerTitleStarLevelInternal;
		}
	}

	// Token: 0x17001569 RID: 5481
	// (get) Token: 0x06011312 RID: 70418 RVA: 0x004B8AD7 File Offset: 0x004B6CD7
	// (set) Token: 0x06011313 RID: 70419 RVA: 0x004B8ADF File Offset: 0x004B6CDF
	public int Sex
	{
		get
		{
			return this.SexInternal;
		}
		set
		{
			this.SexInternal = value;
		}
	}

	// Token: 0x1700156A RID: 5482
	// (get) Token: 0x06011314 RID: 70420 RVA: 0x004B8AE8 File Offset: 0x004B6CE8
	public int WorldLevel
	{
		get
		{
			return this.WorldLevelInternal;
		}
	}

	// Token: 0x06011315 RID: 70421 RVA: 0x004B8AF0 File Offset: 0x004B6CF0
	public void SetPlayerTitleInfo(string playerTitleString)
	{
		if (playerTitleString.Length != 0)
		{
			string[] array = playerTitleString.Split('_', StringSplitOptions.None);
			this.PlayerTitleIdInternal = int.Parse(array[0]);
			int playerTitleStarLevelInternal = (array.Length == 2) ? int.Parse(array[1]) : 0;
			this.PlayerTitleStarLevelInternal = playerTitleStarLevelInternal;
		}
	}

	// Token: 0x1700156B RID: 5483
	// (get) Token: 0x06011316 RID: 70422 RVA: 0x004B8B36 File Offset: 0x004B6D36
	public string PlayerName
	{
		get
		{
			return this.GetFormationName();
		}
	}

	// Token: 0x06011317 RID: 70423 RVA: 0x004B8B3E File Offset: 0x004B6D3E
	public string GetRawName()
	{
		return this.NameInternal;
	}

	// Token: 0x06011318 RID: 70424 RVA: 0x004B8B46 File Offset: 0x004B6D46
	public string GetOnlineName()
	{
		if (!Singleton<Info>.Instance.IsPs5Platform())
		{
			return this.PlayerDetails.XboxOnlineId;
		}
		return this.PlayerDetails.PsnOnlineId;
	}

	// Token: 0x06011319 RID: 70425 RVA: 0x004B8B6C File Offset: 0x004B6D6C
	public string GetFormationName()
	{
		if (ControllerBase<KuroSdkController>.Instance.NeedShowThirdPartyId())
		{
			string text = Singleton<Info>.Instance.IsPs5Platform() ? this.PlayerDetails.PsnOnlineId : this.PlayerDetails.XboxOnlineId;
			if (!string.IsNullOrEmpty(text))
			{
				return text;
			}
		}
		return this.NameInternal;
	}

	// Token: 0x1700156C RID: 5484
	// (get) Token: 0x0601131A RID: 70426 RVA: 0x004B8BBA File Offset: 0x004B6DBA
	// (set) Token: 0x0601131B RID: 70427 RVA: 0x004B8BC2 File Offset: 0x004B6DC2
	public string Signature
	{
		get
		{
			return this.SignatureInternal;
		}
		set
		{
			this.SignatureInternal = value;
		}
	}

	// Token: 0x1700156D RID: 5485
	// (get) Token: 0x0601131C RID: 70428 RVA: 0x004B8BCB File Offset: 0x004B6DCB
	// (set) Token: 0x0601131D RID: 70429 RVA: 0x004B8BD3 File Offset: 0x004B6DD3
	public int PlayerNumber
	{
		get
		{
			return this.PlayerNumberInternal;
		}
		set
		{
			this.PlayerNumberInternal = value;
		}
	}

	// Token: 0x1700156E RID: 5486
	// (get) Token: 0x0601131E RID: 70430 RVA: 0x004B8BDC File Offset: 0x004B6DDC
	public bool IsSelf
	{
		get
		{
			int playerId = this.PlayerId;
			int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
			return playerId == id.GetValueOrDefault() & id != null;
		}
	}

	// Token: 0x1700156F RID: 5487
	// (get) Token: 0x0601131F RID: 70431 RVA: 0x004B8C0B File Offset: 0x004B6E0B
	// (set) Token: 0x06011320 RID: 70432 RVA: 0x004B8C13 File Offset: 0x004B6E13
	public ENetPingState PingState
	{
		get
		{
			return this.PingStateInternal;
		}
		set
		{
			this.PingStateInternal = value;
		}
	}

	// Token: 0x17001570 RID: 5488
	// (get) Token: 0x06011321 RID: 70433 RVA: 0x004B8C1C File Offset: 0x004B6E1C
	// (set) Token: 0x06011322 RID: 70434 RVA: 0x004B8C24 File Offset: 0x004B6E24
	public PlayerDetails PlayerDetails
	{
		get
		{
			return this.PlayerDetailsInternal;
		}
		set
		{
			this.PlayerDetailsInternal = value;
		}
	}

	// Token: 0x17001571 RID: 5489
	// (get) Token: 0x06011323 RID: 70435 RVA: 0x004B8C2D File Offset: 0x004B6E2D
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

	// Token: 0x17001572 RID: 5490
	// (get) Token: 0x06011324 RID: 70436 RVA: 0x004B8C52 File Offset: 0x004B6E52
	public string ThirdPartyOnlineId
	{
		get
		{
			if (Singleton<Info>.Instance.IsPs5Platform())
			{
				return this.PlayerDetailsInternal.PsnOnlineId;
			}
			return this.PlayerDetailsInternal.XboxOnlineId;
		}
	}

	// Token: 0x17001573 RID: 5491
	// (get) Token: 0x06011325 RID: 70437 RVA: 0x004B8C77 File Offset: 0x004B6E77
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

	// Token: 0x06011326 RID: 70438 RVA: 0x004B8C9C File Offset: 0x004B6E9C
	public bool GetIfCanShowInHallList([Nullable(new byte[]
	{
		2,
		1
	})] Dictionary<string, bool> blockMap = null)
	{
		return blockMap == null || !blockMap.ContainsKey(this.ThirdAvoidId);
	}

	// Token: 0x04008719 RID: 34585
	private readonly int PlayerIdInternal;

	// Token: 0x0400871A RID: 34586
	private string NameInternal;

	// Token: 0x0400871B RID: 34587
	private int HeadIdInternal;

	// Token: 0x0400871C RID: 34588
	private int LevelInternal;

	// Token: 0x0400871D RID: 34589
	private string SignatureInternal;

	// Token: 0x0400871E RID: 34590
	private int PlayerTitleIdInternal;

	// Token: 0x0400871F RID: 34591
	private int PlayerTitleStarLevelInternal;

	// Token: 0x04008720 RID: 34592
	private int SexInternal;

	// Token: 0x04008721 RID: 34593
	private PlayerDetails PlayerDetailsInternal;

	// Token: 0x04008722 RID: 34594
	private List<PersonalCardData> _cardUnlockList = new List<PersonalCardData>();

	// Token: 0x04008723 RID: 34595
	private int PlayerNumberInternal;

	// Token: 0x04008724 RID: 34596
	private ENetPingState PingStateInternal;

	// Token: 0x04008725 RID: 34597
	private readonly int WorldLevelInternal = 1;

	// Token: 0x04008726 RID: 34598
	private int CurUsingCardIdInternal;
}
