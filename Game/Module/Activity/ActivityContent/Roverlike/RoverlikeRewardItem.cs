using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x02006402 RID: 25602
	public class RoverlikeRewardItem : UiPanelBase
	{
		// Token: 0x06040473 RID: 263283 RVA: 0x01079530 File Offset: 0x01077730
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06040474 RID: 263284 RVA: 0x010795BC File Offset: 0x010777BC
		[NullableContext(1)]
		public void Refresh(IRoverlikeSettleRewardItemData data)
		{
			base.SetTextureByPath(data.IconPath, base.GetTexture(0), null, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), data.NameTextId, Array.Empty<object>());
			base.GetText(2).SetText(data.Num.ToString(), true);
		}

		// Token: 0x0200C469 RID: 50281
		private class EComponents
		{
			// Token: 0x0403C751 RID: 247633
			public const int TexIcon = 0;

			// Token: 0x0403C752 RID: 247634
			public const int TxtTitle = 1;

			// Token: 0x0403C753 RID: 247635
			public const int TxtNum = 2;
		}
	}
}
