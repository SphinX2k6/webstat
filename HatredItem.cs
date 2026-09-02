using System;

// Token: 0x02000CFF RID: 3327
public class HatredItem
{
	// Token: 0x17000317 RID: 791
	// (get) Token: 0x06004268 RID: 17000 RVA: 0x00075042 File Offset: 0x00073242
	public bool InDecreasing
	{
		get
		{
			return this.NextDecreaseTime > 0.0;
		}
	}

	// Token: 0x17000318 RID: 792
	// (get) Token: 0x06004269 RID: 17001 RVA: 0x00075055 File Offset: 0x00073255
	public float HatredValueActual
	{
		get
		{
			return this.HatredValue + this.TauntValue;
		}
	}

	// Token: 0x0600426A RID: 17002 RVA: 0x00075064 File Offset: 0x00073264
	public void AfterTriggerHatredDecrease()
	{
		if (Singleton<Time>.Instance.WorldTime > this.DecreaseEndTime)
		{
			this.NextDecreaseTime = 0.0;
			return;
		}
		this.NextDecreaseTime += 1000.0;
	}

	// Token: 0x040010C1 RID: 4289
	public float HatredValue;

	// Token: 0x040010C2 RID: 4290
	public float TauntValue;

	// Token: 0x040010C3 RID: 4291
	public double DisengageTime = -1.0;

	// Token: 0x040010C4 RID: 4292
	public double DecreaseCdEndTime;

	// Token: 0x040010C5 RID: 4293
	public double DecreaseEndTime;

	// Token: 0x040010C6 RID: 4294
	public double NextDecreaseTime;

	// Token: 0x040010C7 RID: 4295
	public double EarliestClearTime;

	// Token: 0x040010C8 RID: 4296
	public bool InMaxArea;
}
