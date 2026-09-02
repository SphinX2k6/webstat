using System;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Framework;
using UnrealEngine;

namespace CSharpScript.Game.World.Controller
{
	// Token: 0x020046E4 RID: 18148
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[TickController(0)]
	public class MultiInteractionActorController : ControllerBase<MultiInteractionActorController>
	{
		// Token: 0x0602F342 RID: 193346 RVA: 0x00B2FE08 File Offset: 0x00B2E008
		protected override void OnTick(float delta)
		{
			if (this.WaitDestroyActors.Size <= 0)
			{
				return;
			}
			for (int i = 0; i < 3; i++)
			{
				if (this.WaitDestroyActors.Size <= 0)
				{
					return;
				}
				this.WaitDestroyActors.Pop().DestroySelf();
			}
		}

		// Token: 0x0602F343 RID: 193347 RVA: 0x00B2FE4F File Offset: 0x00B2E04F
		protected override bool OnClear()
		{
			this.ProcessRemainingActor();
			return true;
		}

		// Token: 0x0602F344 RID: 193348 RVA: 0x00B2FE58 File Offset: 0x00B2E058
		protected override bool OnLeaveLevel()
		{
			this.ProcessRemainingActor();
			return true;
		}

		// Token: 0x0602F345 RID: 193349 RVA: 0x00B2FE64 File Offset: 0x00B2E064
		private void ProcessRemainingActor()
		{
			while (this.WaitDestroyActors.Size > 0)
			{
				SceneInteractionActor sceneInteractionActor = this.WaitDestroyActors.Pop();
				if (sceneInteractionActor != null && sceneInteractionActor.IsValid())
				{
					sceneInteractionActor.DestroySelf();
				}
			}
		}

		// Token: 0x0602F346 RID: 193350 RVA: 0x00B2FE9E File Offset: 0x00B2E09E
		public void AddWaitDestroyActor(SceneInteractionActor actor)
		{
			this.WaitDestroyActors.Push(actor);
			ControllerBase<AttachToActorController>.Instance.DetachActor(actor, false, "MultiInteractionActorController.AddWaitDestroyActor", EDetachmentRule.KeepWorld, EDetachmentRule.KeepWorld, EDetachmentRule.KeepWorld);
		}

		// Token: 0x0401AE59 RID: 110169
		private const int MAX_DESTROY_TIME = 3;

		// Token: 0x0401AE5A RID: 110170
		private readonly Queue<SceneInteractionActor> WaitDestroyActors = new Queue<SceneInteractionActor>(4);
	}
}
