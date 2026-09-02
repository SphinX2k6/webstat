using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.Entrance
{
	// Token: 0x020054D4 RID: 21716
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class GymStarItem : GridProxyAbstract<GymChallengeData>
	{
		// Token: 0x06037510 RID: 226576 RVA: 0x00E088E2 File Offset: 0x00E06AE2
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUISprite)),
				new ValueTuple<int, Type>(1, typeof(UUISprite))
			};
		}

		// Token: 0x06037511 RID: 226577 RVA: 0x00E0891B File Offset: 0x00E06B1B
		[NullableContext(1)]
		public override void Refresh(GymChallengeData data, bool isSelected, int gridIndex)
		{
			base.GetSprite(0).SetUIActive(true);
			base.GetSprite(1).SetUIActive(data.State == EChallengeState.Finish);
		}

		// Token: 0x06037512 RID: 226578 RVA: 0x00E0893F File Offset: 0x00E06B3F
		public override void OnSelected(bool fireEvent)
		{
		}

		// Token: 0x06037513 RID: 226579 RVA: 0x00E08941 File Offset: 0x00E06B41
		public override void OnDeselected(bool fireEvent)
		{
		}

		// Token: 0x0200B440 RID: 46144
		private class EComponent
		{
			// Token: 0x04037C8E RID: 228494
			public const int SpriteBg = 0;

			// Token: 0x04037C8F RID: 228495
			public const int SpriteIcon = 1;
		}
	}
}
