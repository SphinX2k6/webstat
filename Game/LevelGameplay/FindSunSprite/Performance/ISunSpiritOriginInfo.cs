using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.FindSunSprite.Performance
{
	// Token: 0x02006EB3 RID: 28339
	[NullableContext(1)]
	public interface ISunSpiritOriginInfo
	{
		// Token: 0x1700A3D2 RID: 41938
		// (get) Token: 0x06044B43 RID: 281411
		// (set) Token: 0x06044B44 RID: 281412
		EntityHandle EntityHandle { get; set; }

		// Token: 0x1700A3D3 RID: 41939
		// (get) Token: 0x06044B45 RID: 281413
		// (set) Token: 0x06044B46 RID: 281414
		Transform Transform { get; set; }

		// Token: 0x1700A3D4 RID: 41940
		// (get) Token: 0x06044B47 RID: 281415
		// (set) Token: 0x06044B48 RID: 281416
		int DisableMoveHandle { get; set; }

		// Token: 0x1700A3D5 RID: 41941
		// (get) Token: 0x06044B49 RID: 281417
		// (set) Token: 0x06044B4A RID: 281418
		int DisableMoveTickHandle { get; set; }
	}
}
