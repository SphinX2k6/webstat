using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001E11 RID: 7697
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class GreatSwordChallengeModel : ModelBase<GreatSwordChallengeModel>
{
	// Token: 0x0600E33F RID: 58175 RVA: 0x003D30CC File Offset: 0x003D12CC
	public void InitChallenge(ITrialChallenge challenge)
	{
		this.Challenge = challenge;
	}

	// Token: 0x0600E340 RID: 58176 RVA: 0x003D30D5 File Offset: 0x003D12D5
	public List<TrialSubChallenge> GetSubChallenges()
	{
		ITrialChallenge challenge = this.Challenge;
		return (((challenge != null) ? challenge.SubChallenges : null) as List<TrialSubChallenge>) ?? new List<TrialSubChallenge>();
	}

	// Token: 0x0600E341 RID: 58177 RVA: 0x003D30F8 File Offset: 0x003D12F8
	public void SetSubChallengeState(int index, bool unlocked, bool completed)
	{
		if (this.Challenge != null && this.Challenge.SubChallenges[index] != null)
		{
			this.Challenge.SubChallenges[index].Unlocked = unlocked;
			this.Challenge.SubChallenges[index].Completed = completed;
		}
	}

	// Token: 0x0600E342 RID: 58178 RVA: 0x003D314E File Offset: 0x003D134E
	public void SetActionIncId(int incId)
	{
		this.ActionIncId = incId;
	}

	// Token: 0x0600E343 RID: 58179 RVA: 0x003D3157 File Offset: 0x003D1357
	public void SetIsStartChallenge(bool isStart)
	{
		this.IsStartChallenge = isStart;
	}

	// Token: 0x0600E344 RID: 58180 RVA: 0x003D3160 File Offset: 0x003D1360
	public int GetActionIncId()
	{
		return this.ActionIncId;
	}

	// Token: 0x0600E345 RID: 58181 RVA: 0x003D3168 File Offset: 0x003D1368
	public bool GetIsStartChallenge()
	{
		return this.IsStartChallenge;
	}

	// Token: 0x0600E346 RID: 58182 RVA: 0x003D3170 File Offset: 0x003D1370
	[NullableContext(2)]
	public ITrialChallenge GetChallenge()
	{
		return this.Challenge;
	}

	// Token: 0x0600E347 RID: 58183 RVA: 0x003D3178 File Offset: 0x003D1378
	public int GetSelectedIndex()
	{
		return this.SelectedIndex;
	}

	// Token: 0x0600E348 RID: 58184 RVA: 0x003D3180 File Offset: 0x003D1380
	public void SetSelectedIndex(int index)
	{
		this.SelectedIndex = index;
	}

	// Token: 0x0600E349 RID: 58185 RVA: 0x003D3189 File Offset: 0x003D1389
	public void ClearData()
	{
		this.Challenge = null;
		this.SelectedIndex = 0;
		this.ActionIncId = 0;
		this.IsStartChallenge = false;
	}

	// Token: 0x04006D3C RID: 27964
	[Nullable(2)]
	private ITrialChallenge Challenge;

	// Token: 0x04006D3D RID: 27965
	private int SelectedIndex;

	// Token: 0x04006D3E RID: 27966
	private int ActionIncId;

	// Token: 0x04006D3F RID: 27967
	private bool IsStartChallenge;
}
