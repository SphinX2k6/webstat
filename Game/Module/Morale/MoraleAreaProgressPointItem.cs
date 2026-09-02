using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Morale
{
	// Token: 0x02005704 RID: 22276
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class MoraleAreaProgressPointItem : GridProxyAbstract<MoraleAreaProgressData>
	{
		// Token: 0x06038B0B RID: 232203 RVA: 0x00E5AF70 File Offset: 0x00E59170
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06038B0C RID: 232204 RVA: 0x00E5AFB8 File Offset: 0x00E591B8
		public override void Refresh(MoraleAreaProgressData data, bool isSelected, int gridIndex)
		{
			this.ItemData = data;
			this.SetUiProgressByScore(data.StartScore);
		}

		// Token: 0x06038B0D RID: 232205 RVA: 0x00E5AFCD File Offset: 0x00E591CD
		private void SetPointShow(bool show)
		{
			UUIItem item = base.GetItem(0);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(show);
		}

		// Token: 0x06038B0E RID: 232206 RVA: 0x00E5AFE4 File Offset: 0x00E591E4
		public void SetUiProgressByScore(int score)
		{
			bool pointShow = score >= this.ItemData.TargetScore;
			this.SetPointShow(pointShow);
		}

		// Token: 0x04020516 RID: 132374
		public MoraleAreaProgressData ItemData;

		// Token: 0x04020517 RID: 132375
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<MoraleAreaProgressData> ClickCallBack;

		// Token: 0x0200B786 RID: 46982
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x04038C36 RID: 232502
			ItemPoint
		}
	}
}
