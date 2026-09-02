using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Camera.FightCameraController.SpecialGameplay
{
	// Token: 0x020070C4 RID: 28868
	[NullableContext(1)]
	public interface ISpecialGameplayCamera
	{
		// Token: 0x06045FDC RID: 286684
		void OnInit(ACameraActor camera, CameraModelInstance cameraModel);

		// Token: 0x06045FDD RID: 286685
		void Update(float deltaTime);

		// Token: 0x06045FDE RID: 286686
		void OnDestroy();
	}
}
