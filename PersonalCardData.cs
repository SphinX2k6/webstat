using System;

// Token: 0x0200240B RID: 9227
public class PersonalCardData
{
	// Token: 0x06011DCE RID: 73166 RVA: 0x004E9E76 File Offset: 0x004E8076
	public PersonalCardData(int cardId, bool isRead, bool isUnLock)
	{
		this.CardId = cardId;
		this.IsRead = isRead;
		this.IsUnLock = isUnLock;
	}

	// Token: 0x06011DCF RID: 73167 RVA: 0x004E9E93 File Offset: 0x004E8093
	public void RefreshData(bool isRead, bool isUnLock)
	{
		this.IsRead = isRead;
		this.IsUnLock = isUnLock;
	}

	// Token: 0x04008B96 RID: 35734
	public int CardId;

	// Token: 0x04008B97 RID: 35735
	public bool IsRead;

	// Token: 0x04008B98 RID: 35736
	public bool IsUnLock;
}
