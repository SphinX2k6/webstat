using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Camera
{
	// Token: 0x02007097 RID: 28823
	[NullableContext(1)]
	public interface ICameraNearClipAction<[Nullable(0)] out T> where T : CameraBaseNearClipConfig
	{
		// Token: 0x1700A5C0 RID: 42432
		// (get) Token: 0x06045DAD RID: 286125
		T NearClipConfig { get; }

		// Token: 0x06045DAE RID: 286126
		void Start();

		// Token: 0x06045DAF RID: 286127
		bool IsPause();

		// Token: 0x06045DB0 RID: 286128
		void Pause();

		// Token: 0x06045DB1 RID: 286129
		void Resume();

		// Token: 0x06045DB2 RID: 286130
		void End();
	}
}
