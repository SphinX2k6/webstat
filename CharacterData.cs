using System;

// Token: 0x020013CF RID: 5071
public class CharacterData
{
	// Token: 0x17000BD0 RID: 3024
	// (get) Token: 0x06008C24 RID: 35876 RVA: 0x0024DE93 File Offset: 0x0024C093
	public int Id { get; }

	// Token: 0x06008C25 RID: 35877 RVA: 0x0024DE9B File Offset: 0x0024C09B
	public CharacterData(int id)
	{
		this.Id = id;
		this.MaxValueInternal = ConfigBase<BusinessConfig>.Instance.GetRoleCharacterMax();
	}

	// Token: 0x06008C26 RID: 35878 RVA: 0x0024DEBA File Offset: 0x0024C0BA
	public void SetCurrentValue(int value)
	{
		this.ValueInterval = value - this.CurrentValueInternal;
		this.CurrentValueInternal = value;
	}

	// Token: 0x17000BD1 RID: 3025
	// (get) Token: 0x06008C27 RID: 35879 RVA: 0x0024DED1 File Offset: 0x0024C0D1
	public int CurrentValue
	{
		get
		{
			return this.CurrentValueInternal;
		}
	}

	// Token: 0x06008C28 RID: 35880 RVA: 0x0024DED9 File Offset: 0x0024C0D9
	public void SetMaxValue(int value)
	{
		this.MaxValueInternal = value;
	}

	// Token: 0x17000BD2 RID: 3026
	// (get) Token: 0x06008C29 RID: 35881 RVA: 0x0024DEE2 File Offset: 0x0024C0E2
	public int MaxValue
	{
		get
		{
			return this.MaxValueInternal;
		}
	}

	// Token: 0x06008C2A RID: 35882 RVA: 0x0024DEEA File Offset: 0x0024C0EA
	public void SetUseScoreName(bool value)
	{
		this.UseScoreNameInternal = value;
	}

	// Token: 0x17000BD3 RID: 3027
	// (get) Token: 0x06008C2B RID: 35883 RVA: 0x0024DEF3 File Offset: 0x0024C0F3
	public bool UseScoreName
	{
		get
		{
			return this.UseScoreNameInternal;
		}
	}

	// Token: 0x0400414D RID: 16717
	private int CurrentValueInternal;

	// Token: 0x0400414E RID: 16718
	private int MaxValueInternal;

	// Token: 0x0400414F RID: 16719
	public int ValueInterval;

	// Token: 0x04004150 RID: 16720
	private bool UseScoreNameInternal;
}
