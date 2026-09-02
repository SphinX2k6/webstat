using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Camera
{
	// Token: 0x020070A2 RID: 28834
	[NullableContext(1)]
	[Nullable(0)]
	public class CameraTransformBuffer
	{
		// Token: 0x06045E26 RID: 286246 RVA: 0x0124D9E8 File Offset: 0x0124BBE8
		public void Init(FightCameraLogicComponent camera)
		{
			this.Camera = camera;
			MotorCycleTransformBuffer motorCycleTransformBuffer = new MotorCycleTransformBuffer();
			motorCycleTransformBuffer.Init(camera);
			this.CameraTransformBufferMap[ECameraTransformBufferType.MotorCycle] = motorCycleTransformBuffer;
			Singleton<Log>.Instance.Info(ELogModule.Camera, ELogAuthor.LJM, "[CameraTransformBuffer] Init", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x06045E27 RID: 286247 RVA: 0x0124DA34 File Offset: 0x0124BC34
		public void BufferPlayerLocation(float second, Vector outPlayerLocation)
		{
			if (this.Camera == null)
			{
				return;
			}
			foreach (IPlayerTransformBuffer playerTransformBuffer in this.CameraTransformBufferMap.Values)
			{
				if (playerTransformBuffer.IsValid())
				{
					playerTransformBuffer.BufferPlayerLocation(second, outPlayerLocation);
					break;
				}
			}
		}

		// Token: 0x06045E28 RID: 286248 RVA: 0x0124DAA0 File Offset: 0x0124BCA0
		public void StopBufferPlayerLocation()
		{
			foreach (IPlayerTransformBuffer playerTransformBuffer in this.CameraTransformBufferMap.Values)
			{
				playerTransformBuffer.StopBufferPlayerLocation();
			}
		}

		// Token: 0x06045E29 RID: 286249 RVA: 0x0124DAF8 File Offset: 0x0124BCF8
		public void Clear()
		{
			Singleton<Log>.Instance.Info(ELogModule.Camera, ELogAuthor.LJM, "[CameraTransformBuffer] Clear", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.Camera = null;
		}

		// Token: 0x04027247 RID: 160327
		[Nullable(2)]
		private FightCameraLogicComponent Camera;

		// Token: 0x04027248 RID: 160328
		private readonly Dictionary<ECameraTransformBufferType, IPlayerTransformBuffer> CameraTransformBufferMap = new Dictionary<ECameraTransformBufferType, IPlayerTransformBuffer>();
	}
}
