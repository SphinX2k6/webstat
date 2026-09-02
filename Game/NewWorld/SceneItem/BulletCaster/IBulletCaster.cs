using System;

namespace CSharpScript.Game.NewWorld.SceneItem.BulletCaster
{
	// Token: 0x0200489B RID: 18587
	public interface IBulletCaster
	{
		// Token: 0x060306F8 RID: 198392
		void Start();

		// Token: 0x060306F9 RID: 198393
		void Stop();

		// Token: 0x060306FA RID: 198394
		void SetTimeDilationRespectOwnerEntity();

		// Token: 0x060306FB RID: 198395
		void SetTimeDilation(float timeDilation);
	}
}
