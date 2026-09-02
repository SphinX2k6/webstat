using System;
using System.Collections.Generic;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare
{
	// Token: 0x020054AA RID: 21674
	public class PhantomArenaMainViewRoleSpineItem : UiPanelBase
	{
		// Token: 0x06037301 RID: 226049 RVA: 0x00E02AD5 File Offset: 0x00E00CD5
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(USpineSkeletonAnimationComponent)),
				new ValueTuple<int, Type>(1, typeof(USpineSkeletonAnimationComponent))
			};
		}

		// Token: 0x06037302 RID: 226050 RVA: 0x00E02B0E File Offset: 0x00E00D0E
		protected override void OnStart()
		{
			base.GetSpine(0).SetAnimation(0, "idle", true);
			base.GetSpine(1).SetAnimation(0, "idle", true);
		}

		// Token: 0x0200B415 RID: 46101
		private class EComponent
		{
			// Token: 0x04037BA2 RID: 228258
			public const int SpineSkeleton1 = 0;

			// Token: 0x04037BA3 RID: 228259
			public const int SpineSkeleton2 = 1;
		}
	}
}
