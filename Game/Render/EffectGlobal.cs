using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Render
{
	// Token: 0x02004774 RID: 18292
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class EffectGlobal : Singleton<EffectGlobal>
	{
		// Token: 0x0401B1AA RID: 111018
		public bool EnableSpawnLog = true;

		// Token: 0x0401B1AB RID: 111019
		public bool GlobalGamePaused;

		// Token: 0x0401B1AC RID: 111020
		public Vector LastCameraLocation = Vector.Create(0.0, 0.0, 0.0);

		// Token: 0x0401B1AD RID: 111021
		public Vector CameraLocation = Vector.Create(0.0, 0.0, 0.0);

		// Token: 0x0401B1AE RID: 111022
		public bool HasPlayer0;

		// Token: 0x0401B1AF RID: 111023
		public double GameTimeInSeconds;

		// Token: 0x0401B1B0 RID: 111024
		public double GlobalTimeDilation = 1.0;

		// Token: 0x0401B1B1 RID: 111025
		public bool AllowEffectOutPool = true;

		// Token: 0x0401B1B2 RID: 111026
		public bool AllowEffectInPool = true;

		// Token: 0x0401B1B3 RID: 111027
		public bool SceneObjectWaterEffectShowDebugTrace;

		// Token: 0x0401B1B4 RID: 111028
		public bool SceneObjectAirWallEffectShowDebugTrace;

		// Token: 0x0401B1B5 RID: 111029
		public bool CgMode;
	}
}
