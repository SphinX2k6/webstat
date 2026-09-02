using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView.Components
{
	// Token: 0x020058A9 RID: 22697
	public class MarkOutOfBoundComponent : MarkPanelBase
	{
		// Token: 0x06039AB4 RID: 236212 RVA: 0x00E9F740 File Offset: 0x00E9D940
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

		// Token: 0x06039AB5 RID: 236213 RVA: 0x00E9F788 File Offset: 0x00E9D988
		protected override void OnBeforeShow()
		{
			this.UpdateRotation();
		}

		// Token: 0x06039AB6 RID: 236214 RVA: 0x00E9F790 File Offset: 0x00E9D990
		[NullableContext(1)]
		public void SetOutOfBoundDirection(Vector2D offset)
		{
			double num = Math.Atan2(offset.Y, offset.X) * 57.29577951308232 - 90.0;
			this.TempRotator.Yaw = (float)num;
			if (base.IsShowOrShowing)
			{
				this.UpdateRotation();
			}
		}

		// Token: 0x06039AB7 RID: 236215 RVA: 0x00E9F7DE File Offset: 0x00E9D9DE
		private void UpdateRotation()
		{
			base.GetItem(0).SetUIRelativeRotation(this.TempRotator);
		}

		// Token: 0x04020AF7 RID: 133879
		private const double RAD_2_DEG = 57.29577951308232;

		// Token: 0x04020AF8 RID: 133880
		private const double DEG_PI_4 = 90.0;

		// Token: 0x04020AF9 RID: 133881
		private FRotator TempRotator = new FRotator();

		// Token: 0x0200B8DA RID: 47322
		public static class EChildComponents
		{
			// Token: 0x04039233 RID: 234035
			public const int DirectionItem = 0;
		}
	}
}
