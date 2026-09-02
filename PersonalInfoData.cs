using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02002411 RID: 9233
[NullableContext(1)]
[Nullable(0)]
public class PersonalInfoData
{
	// Token: 0x06011DDC RID: 73180 RVA: 0x004EA088 File Offset: 0x004E8288
	public int GetUnlockCardDataCount()
	{
		int num = 0;
		using (List<PersonalCardData>.Enumerator enumerator = this.CardDataList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.IsUnLock)
				{
					num++;
				}
			}
		}
		return num;
	}

	// Token: 0x06011DDD RID: 73181 RVA: 0x004EA0E4 File Offset: 0x004E82E4
	public PersonalCardData[] GetCardList(bool needShowLockCard)
	{
		List<PersonalCardData> list = (from cardData in this.CardDataList.ToList<PersonalCardData>()
		where needShowLockCard || cardData.IsUnLock
		select cardData).ToList<PersonalCardData>();
		list.Sort(delegate(PersonalCardData cardDataA, PersonalCardData cardDataB)
		{
			if (cardDataA.IsUnLock != cardDataB.IsUnLock)
			{
				return Convert.ToInt32(cardDataB.IsUnLock) - Convert.ToInt32(cardDataA.IsUnLock);
			}
			BackgroundCard? config = ConfigBackgroundCardById.GetConfig(cardDataA.CardId, true);
			BackgroundCard? config2 = ConfigBackgroundCardById.GetConfig(cardDataB.CardId, true);
			if (config.Value.SortIndex != config2.Value.SortIndex)
			{
				return config2.Value.SortIndex - config.Value.SortIndex;
			}
			return cardDataB.CardId - cardDataA.CardId;
		});
		return list.ToArray();
	}

	// Token: 0x17001689 RID: 5769
	// (get) Token: 0x06011DDE RID: 73182 RVA: 0x004EA149 File Offset: 0x004E8349
	// (set) Token: 0x06011DDF RID: 73183 RVA: 0x004EA151 File Offset: 0x004E8351
	public int Birthday
	{
		get
		{
			return this.BirthdayInternal;
		}
		set
		{
			ModelBase<BirthdayModel>.Instance.ResetYear = (int)Math.Floor((double)value / 10000.0);
			this.BirthdayInternal = value % 10000;
			if (value < 10000)
			{
				this.BirthdayInternal = 0;
			}
		}
	}

	// Token: 0x04008BBB RID: 35771
	public List<RoleShowEntry> RoleShowList = new List<RoleShowEntry>();

	// Token: 0x04008BBC RID: 35772
	public List<int> CardShowList = new List<int>();

	// Token: 0x04008BBD RID: 35773
	public int? CurCardId;

	// Token: 0x04008BBE RID: 35774
	private int BirthdayInternal;

	// Token: 0x04008BBF RID: 35775
	public bool IsBirthdayDisplay;

	// Token: 0x04008BC0 RID: 35776
	public List<PersonalCardData> CardDataList = new List<PersonalCardData>();

	// Token: 0x04008BC1 RID: 35777
	public string Signature = "";

	// Token: 0x04008BC2 RID: 35778
	public int? HeadPhotoId;

	// Token: 0x04008BC3 RID: 35779
	public bool IsOtherData;

	// Token: 0x04008BC4 RID: 35780
	public int Level;

	// Token: 0x04008BC5 RID: 35781
	public int WorldLevel;

	// Token: 0x04008BC6 RID: 35782
	public string Name = "";

	// Token: 0x04008BC7 RID: 35783
	public List<PersonalPlayerTitleData> PlayerTitleDataList = new List<PersonalPlayerTitleData>();

	// Token: 0x04008BC8 RID: 35784
	public int? CurPlayerTitleId;

	// Token: 0x04008BC9 RID: 35785
	public int? CurPlayerTitleLevel;

	// Token: 0x04008BCA RID: 35786
	public int Sex;

	// Token: 0x04008BCB RID: 35787
	public int PlayerId;

	// Token: 0x04008BCC RID: 35788
	public int LastModifyNameTime;

	// Token: 0x04008BCD RID: 35789
	public string ModifyName = "";

	// Token: 0x04008BCE RID: 35790
	[Nullable(2)]
	public string ThirdUserId;

	// Token: 0x04008BCF RID: 35791
	[Nullable(2)]
	public string ThirdOnlineId;
}
