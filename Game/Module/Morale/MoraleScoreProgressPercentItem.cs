using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Morale
{
	// Token: 0x0200571C RID: 22300
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class MoraleScoreProgressPercentItem : GridProxyAbstract<MoraleProgressRewardData>
	{
		// Token: 0x06038C1C RID: 232476 RVA: 0x00E5F138 File Offset: 0x00E5D338
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUISprite)),
				new ValueTuple<int, Type>(2, typeof(UUISprite))
			};
		}

		// Token: 0x06038C1D RID: 232477 RVA: 0x00E5F194 File Offset: 0x00E5D394
		public override void Refresh(MoraleProgressRewardData data, bool isSelected, int gridIndex)
		{
			this.ItemData = data;
			UUISprite sprite = base.GetSprite(1);
			float stageProgressPercent = ModelBase<MoraleModel>.Instance.GetStageProgressPercent(data);
			UUISprite sprite2 = base.GetSprite(2);
			if (sprite2 != null)
			{
				sprite2.SetUIActive(false);
			}
			if (sprite == null)
			{
				return;
			}
			sprite.SetFillAmount(stageProgressPercent);
		}

		// Token: 0x06038C1E RID: 232478 RVA: 0x00E5F1DC File Offset: 0x00E5D3DC
		public void UpdatePercentHandle()
		{
			UUISprite sprite = base.GetSprite(1);
			UUISprite sprite2 = base.GetSprite(2);
			float num = (sprite != null) ? sprite.GetWidth() : 0f;
			float stageProgressPercent = ModelBase<MoraleModel>.Instance.GetStageProgressPercent(this.ItemData);
			bool flag = this.ItemData.IsInCurrentStage && stageProgressPercent > 0f;
			if (sprite2 != null)
			{
				sprite2.SetUIActive(flag);
			}
			if (flag && sprite2 != null)
			{
				sprite2.SetAnchorOffsetX(num * stageProgressPercent);
			}
		}

		// Token: 0x04020557 RID: 132439
		private MoraleProgressRewardData ItemData;

		// Token: 0x0200B7C4 RID: 47044
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x04038D80 RID: 232832
			public const int ItemSelf = 0;

			// Token: 0x04038D81 RID: 232833
			public const int SpritePercent = 1;

			// Token: 0x04038D82 RID: 232834
			public const int SpriteHandle = 2;
		}
	}
}
