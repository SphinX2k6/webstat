using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Morale
{
	// Token: 0x02005703 RID: 22275
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class MoraleAreaProgressItem : GridProxyAbstract<MoraleAreaProgressData>
	{
		// Token: 0x06038B05 RID: 232197 RVA: 0x00E5AEA8 File Offset: 0x00E590A8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06038B06 RID: 232198 RVA: 0x00E5AEF0 File Offset: 0x00E590F0
		public override void Refresh(MoraleAreaProgressData data, bool isSelected, int gridIndex)
		{
			this.ItemData = data;
			this.SetUiProgressByScore(data.StartScore);
		}

		// Token: 0x06038B07 RID: 232199 RVA: 0x00E5AF05 File Offset: 0x00E59105
		private float GetProgress(int score)
		{
			if (score >= this.ItemData.TargetScore)
			{
				return 1f;
			}
			return (float)(score - this.ItemData.LastTargetScore) / (float)(this.ItemData.TargetScore - this.ItemData.LastTargetScore);
		}

		// Token: 0x06038B08 RID: 232200 RVA: 0x00E5AF42 File Offset: 0x00E59142
		private void SetUiProgress(float percent)
		{
			UUISprite sprite = base.GetSprite(0);
			if (sprite == null)
			{
				return;
			}
			sprite.SetFillAmount(percent);
		}

		// Token: 0x06038B09 RID: 232201 RVA: 0x00E5AF56 File Offset: 0x00E59156
		public void SetUiProgressByScore(int score)
		{
			this.SetUiProgress(this.GetProgress(score));
		}

		// Token: 0x04020515 RID: 132373
		public MoraleAreaProgressData ItemData;

		// Token: 0x0200B785 RID: 46981
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x04038C34 RID: 232500
			SpriteProgress
		}
	}
}
