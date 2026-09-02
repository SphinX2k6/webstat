using System;
using System.Runtime.CompilerServices;

// Token: 0x02001845 RID: 6213
[NullableContext(1)]
[Nullable(0)]
public class ChatPlayerData
{
	// Token: 0x0600B1AE RID: 45486 RVA: 0x002F63F1 File Offset: 0x002F45F1
	public ChatPlayerData(int playerId)
	{
		this.PlayerId = playerId;
	}

	// Token: 0x0600B1AF RID: 45487 RVA: 0x002F640B File Offset: 0x002F460B
	public void SetPlayerId(int playerId)
	{
		this.PlayerId = playerId;
	}

	// Token: 0x0600B1B0 RID: 45488 RVA: 0x002F6414 File Offset: 0x002F4614
	public int GetPlayerId()
	{
		return this.PlayerId;
	}

	// Token: 0x0600B1B1 RID: 45489 RVA: 0x002F641C File Offset: 0x002F461C
	public void SetPlayerIcon(int? playerIcon = null)
	{
		this.PlayerIcon = playerIcon.GetValueOrDefault();
	}

	// Token: 0x0600B1B2 RID: 45490 RVA: 0x002F642B File Offset: 0x002F462B
	public int GetPlayerIcon()
	{
		return this.PlayerIcon;
	}

	// Token: 0x0600B1B3 RID: 45491 RVA: 0x002F6433 File Offset: 0x002F4633
	[NullableContext(2)]
	public void SetPlayerName(string playerName = null)
	{
		this.PlayerName = (playerName ?? "");
	}

	// Token: 0x0600B1B4 RID: 45492 RVA: 0x002F6445 File Offset: 0x002F4645
	public string GetPlayerName()
	{
		return this.PlayerName;
	}

	// Token: 0x0600B1B5 RID: 45493 RVA: 0x002F6450 File Offset: 0x002F4650
	public void SetPlayerTitle(string playerTitleString)
	{
		if (playerTitleString.Length == 0)
		{
			return;
		}
		string[] array = playerTitleString.Split('_', StringSplitOptions.None);
		this.PlayerTitleId = int.Parse(array[0]);
		int? playerTitleStarLevel = (array.Length == 2) ? new int?(int.Parse(array[1])) : null;
		this.PlayerTitleStarLevel = playerTitleStarLevel;
	}

	// Token: 0x0600B1B6 RID: 45494 RVA: 0x002F64A4 File Offset: 0x002F46A4
	public void SetPlayerTitleId(int? playerTitleId = null)
	{
		this.PlayerTitleId = playerTitleId.GetValueOrDefault();
	}

	// Token: 0x0600B1B7 RID: 45495 RVA: 0x002F64B3 File Offset: 0x002F46B3
	public void SetPlayerTitleExParam(int? playerTitleExParam = null)
	{
		this.PlayerTitleStarLevel = playerTitleExParam;
	}

	// Token: 0x0600B1B8 RID: 45496 RVA: 0x002F64BC File Offset: 0x002F46BC
	public int GetPlayerTitleId()
	{
		return this.PlayerTitleId;
	}

	// Token: 0x0600B1B9 RID: 45497 RVA: 0x002F64C4 File Offset: 0x002F46C4
	public int? GetPlayerTitleStarLevel()
	{
		return this.PlayerTitleStarLevel;
	}

	// Token: 0x0600B1BA RID: 45498 RVA: 0x002F64CC File Offset: 0x002F46CC
	public void SetSex(int sex)
	{
		this.PlayerSex = sex;
	}

	// Token: 0x0600B1BB RID: 45499 RVA: 0x002F64D5 File Offset: 0x002F46D5
	public int GetSex()
	{
		return this.PlayerSex;
	}

	// Token: 0x0400542D RID: 21549
	private int PlayerId;

	// Token: 0x0400542E RID: 21550
	private int PlayerIcon;

	// Token: 0x0400542F RID: 21551
	private string PlayerName = "";

	// Token: 0x04005430 RID: 21552
	private int PlayerTitleId;

	// Token: 0x04005431 RID: 21553
	private int? PlayerTitleStarLevel;

	// Token: 0x04005432 RID: 21554
	private int PlayerSex;
}
