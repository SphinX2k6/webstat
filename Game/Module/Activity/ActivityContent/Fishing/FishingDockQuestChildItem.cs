using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x0200680F RID: 26639
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class FishingDockQuestChildItem : GridProxyAbstract<IFishingDockQuestChildItemData>
	{
		// Token: 0x06042661 RID: 271969 RVA: 0x01104FB8 File Offset: 0x011031B8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06042662 RID: 271970 RVA: 0x01105042 File Offset: 0x01103242
		protected override void OnStart()
		{
			base.GetText(1).SetUIActive(true);
		}

		// Token: 0x06042663 RID: 271971 RVA: 0x01105054 File Offset: 0x01103254
		[NullableContext(1)]
		public override void Refresh(IFishingDockQuestChildItemData data, bool isSelected, int gridIndex)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), data.DesText, new <>z__ReadOnlySingleElementList<object>(data.MaxCount));
			base.GetText(1).SetText(string.Concat(new string[]
			{
				"(",
				Math.Min(data.CurrentCount, data.MaxCount).ToString(),
				"/",
				data.MaxCount.ToString(),
				")"
			}), true);
			base.GetItem(2).SetUIActive(data.CurrentCount >= data.MaxCount);
			base.GetText(1).useChangeColor = (data.CurrentCount >= data.MaxCount);
			base.GetText(0).useChangeColor = (data.CurrentCount >= data.MaxCount);
		}

		// Token: 0x0200C840 RID: 51264
		private class EComponentDefine
		{
			// Token: 0x0403D9E7 RID: 252391
			public const int TargetText = 0;

			// Token: 0x0403D9E8 RID: 252392
			public const int TargetCountText = 1;

			// Token: 0x0403D9E9 RID: 252393
			public const int FinishItem = 2;
		}
	}
}
