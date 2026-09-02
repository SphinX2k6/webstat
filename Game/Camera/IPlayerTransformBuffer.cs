using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Camera
{
	// Token: 0x020070A0 RID: 28832
	[NullableContext(1)]
	public interface IPlayerTransformBuffer
	{
		// Token: 0x06045E13 RID: 286227
		void Init(FightCameraLogicComponent camera);

		// Token: 0x06045E14 RID: 286228
		bool IsValid();

		// Token: 0x06045E15 RID: 286229
		bool IsNeedBufferPlayerLocation();

		// Token: 0x06045E16 RID: 286230
		void BufferPlayerLocation(float second, Vector outPlayerLocation);

		// Token: 0x06045E17 RID: 286231
		void StopBufferPlayerLocation();
	}
}
