using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x020010E8 RID: 4328
[NullableContext(1)]
[Nullable(0)]
public class GuessJokerCardData
{
	// Token: 0x060070B6 RID: 28854 RVA: 0x001D6EA0 File Offset: 0x001D50A0
	public GuessJokerCardData(int id)
	{
		this.IdInternal = id;
		JokerDeck value = ConfigBase<GuessJokerConfig>.Instance.GetJokerDeck(id).Value;
		this.TypeInternal = (EGuessJokerCardType)value.CardType;
		this.ValueInternal = value.CardNumber;
		this.TexturePathInternal = value.TexturePath;
	}

	// Token: 0x060070B7 RID: 28855 RVA: 0x001D6F00 File Offset: 0x001D5100
	public void ChangeBlankValue(int cardId)
	{
		if (this.Type != EGuessJokerCardType.Blank || cardId == this.Id || cardId == 0)
		{
			return;
		}
		JokerDeck value = ConfigBase<GuessJokerConfig>.Instance.GetJokerDeck(cardId).Value;
		this.ValueInternal = value.CardNumber;
		this.TexturePathInternal = value.TexturePath;
		this.HasChangedInternal = true;
		this.IsChangedInternal = true;
		this.ChangeConfig = new JokerDeck?(value);
	}

	// Token: 0x060070B8 RID: 28856 RVA: 0x001D6F6C File Offset: 0x001D516C
	public bool IsChangedToJoker()
	{
		if (this.Type != EGuessJokerCardType.Blank)
		{
			return false;
		}
		JokerDeck? changeConfig = this.ChangeConfig;
		return changeConfig != null && changeConfig.Value.CardType == 1;
	}

	// Token: 0x060070B9 RID: 28857 RVA: 0x001D6FA8 File Offset: 0x001D51A8
	public void SetBelongPlayerType(EGuessJokerPlayerType? belongPlayerType)
	{
		this.BelongType = belongPlayerType;
	}

	// Token: 0x060070BA RID: 28858 RVA: 0x001D6FB1 File Offset: 0x001D51B1
	public EGuessJokerPlayerType? GetBelongPlayerType()
	{
		return this.BelongType;
	}

	// Token: 0x060070BB RID: 28859 RVA: 0x001D6FB9 File Offset: 0x001D51B9
	public bool IsBlank()
	{
		return this.Type == EGuessJokerCardType.Blank;
	}

	// Token: 0x060070BC RID: 28860 RVA: 0x001D6FC4 File Offset: 0x001D51C4
	public bool IsJoker()
	{
		return this.Type == EGuessJokerCardType.Joker;
	}

	// Token: 0x060070BD RID: 28861 RVA: 0x001D6FCF File Offset: 0x001D51CF
	public bool HasChanged()
	{
		return this.HasChangedInternal;
	}

	// Token: 0x060070BE RID: 28862 RVA: 0x001D6FD7 File Offset: 0x001D51D7
	public bool GetChange()
	{
		bool isChangedInternal = this.IsChangedInternal;
		this.IsChangedInternal = false;
		return isChangedInternal;
	}

	// Token: 0x17000916 RID: 2326
	// (get) Token: 0x060070BF RID: 28863 RVA: 0x001D6FE6 File Offset: 0x001D51E6
	public int Id
	{
		get
		{
			return this.IdInternal;
		}
	}

	// Token: 0x17000917 RID: 2327
	// (get) Token: 0x060070C0 RID: 28864 RVA: 0x001D6FEE File Offset: 0x001D51EE
	public EGuessJokerCardType Type
	{
		get
		{
			return this.TypeInternal;
		}
	}

	// Token: 0x17000918 RID: 2328
	// (get) Token: 0x060070C1 RID: 28865 RVA: 0x001D6FF6 File Offset: 0x001D51F6
	public int Value
	{
		get
		{
			return this.ValueInternal;
		}
	}

	// Token: 0x17000919 RID: 2329
	// (get) Token: 0x060070C2 RID: 28866 RVA: 0x001D6FFE File Offset: 0x001D51FE
	public string TexturePath
	{
		get
		{
			return this.TexturePathInternal;
		}
	}

	// Token: 0x04003635 RID: 13877
	private readonly int IdInternal;

	// Token: 0x04003636 RID: 13878
	private int ValueInternal;

	// Token: 0x04003637 RID: 13879
	private string TexturePathInternal = "";

	// Token: 0x04003638 RID: 13880
	private readonly EGuessJokerCardType TypeInternal;

	// Token: 0x04003639 RID: 13881
	private bool HasChangedInternal;

	// Token: 0x0400363A RID: 13882
	private bool IsChangedInternal;

	// Token: 0x0400363B RID: 13883
	private JokerDeck? ChangeConfig;

	// Token: 0x0400363C RID: 13884
	private EGuessJokerPlayerType? BelongType;
}
