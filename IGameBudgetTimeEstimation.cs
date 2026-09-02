using System;

// Token: 0x02000BBB RID: 3003
public interface IGameBudgetTimeEstimation
{
	// Token: 0x060030E0 RID: 12512
	void Initialize();

	// Token: 0x060030E1 RID: 12513
	void SetMaximumFrameRate(int fps);

	// Token: 0x060030E2 RID: 12514
	void UpdateBudgetTime(float delta);
}
