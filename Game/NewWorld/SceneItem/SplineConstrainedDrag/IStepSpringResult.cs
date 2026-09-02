using System;

namespace CSharpScript.Game.NewWorld.SceneItem.SplineConstrainedDrag
{
	// Token: 0x02004822 RID: 18466
	public interface IStepSpringResult
	{
		// Token: 0x17008231 RID: 33329
		// (get) Token: 0x060300E2 RID: 196834
		// (set) Token: 0x060300E3 RID: 196835
		float NewPosition { get; set; }

		// Token: 0x17008232 RID: 33330
		// (get) Token: 0x060300E4 RID: 196836
		// (set) Token: 0x060300E5 RID: 196837
		float NewVelocity { get; set; }

		// Token: 0x17008233 RID: 33331
		// (get) Token: 0x060300E6 RID: 196838
		// (set) Token: 0x060300E7 RID: 196839
		bool Converged { get; set; }
	}
}
