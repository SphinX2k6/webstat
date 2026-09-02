using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem.Manipulate
{
	// Token: 0x02004853 RID: 18515
	public class SceneItemManipulableChantState : SceneItemManipulableBaseState
	{
		// Token: 0x060302A8 RID: 197288 RVA: 0x00BAF4D0 File Offset: 0x00BAD6D0
		[NullableContext(1)]
		public SceneItemManipulableChantState(SceneItemManipulatableComponent sceneItem, [Nullable(new byte[]
		{
			0,
			1
		})] TSubclassOf<UCameraShakeBase> cameraShake, FGameplayTag subCameraTag) : base(sceneItem)
		{
			this.CameraShake = new TSubclassOf<UCameraShakeBase>?(cameraShake);
			this.SubCameraTag = new FGameplayTag?(subCameraTag);
		}

		// Token: 0x060302A9 RID: 197289 RVA: 0x00BAF4F1 File Offset: 0x00BAD6F1
		protected override void OnEnter()
		{
			base.StartCameraShake(this.CameraShake);
			Singleton<EventSystem>.Instance.Emit<FGameplayTag>(EEventName.AddSubCameraTag, this.SubCameraTag.Value);
			this.SceneItem.NeedRemoveControllerId = true;
		}

		// Token: 0x060302AA RID: 197290 RVA: 0x00BAF526 File Offset: 0x00BAD726
		protected override void OnExit()
		{
			base.StopCameraShake();
			Singleton<EventSystem>.Instance.Emit<FGameplayTag>(EEventName.RemoveSubCameraTag, this.SubCameraTag.Value);
		}

		// Token: 0x0401BA6C RID: 113260
		[Nullable(new byte[]
		{
			0,
			1
		})]
		private readonly TSubclassOf<UCameraShakeBase>? CameraShake;

		// Token: 0x0401BA6D RID: 113261
		private readonly FGameplayTag? SubCameraTag;
	}
}
