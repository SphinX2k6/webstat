using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Camera.CameraSubModeController
{
	// Token: 0x020070CC RID: 28876
	[NullableContext(1)]
	[Nullable(0)]
	public class CameraSubModeController
	{
		// Token: 0x06046014 RID: 286740 RVA: 0x0125F250 File Offset: 0x0125D450
		public void Start(CameraModelInstance cameraModelInstance)
		{
			this.OnStart(cameraModelInstance);
		}

		// Token: 0x06046015 RID: 286741 RVA: 0x0125F259 File Offset: 0x0125D459
		public void Tick(float deltaTime)
		{
			this.OnTick(deltaTime);
		}

		// Token: 0x06046016 RID: 286742 RVA: 0x0125F262 File Offset: 0x0125D462
		public void AfterTick(float deltaTime)
		{
			this.OnAfterTick(deltaTime);
		}

		// Token: 0x06046017 RID: 286743 RVA: 0x0125F26B File Offset: 0x0125D46B
		public void End()
		{
			this.OnEnd();
		}

		// Token: 0x06046018 RID: 286744 RVA: 0x0125F273 File Offset: 0x0125D473
		protected virtual void OnStart(CameraModelInstance cameraModelInstance)
		{
		}

		// Token: 0x06046019 RID: 286745 RVA: 0x0125F275 File Offset: 0x0125D475
		protected virtual void OnTick(float deltaTime)
		{
		}

		// Token: 0x0604601A RID: 286746 RVA: 0x0125F277 File Offset: 0x0125D477
		protected virtual void OnAfterTick(float deltaTime)
		{
		}

		// Token: 0x0604601B RID: 286747 RVA: 0x0125F279 File Offset: 0x0125D479
		protected virtual void OnEnd()
		{
		}
	}
}
