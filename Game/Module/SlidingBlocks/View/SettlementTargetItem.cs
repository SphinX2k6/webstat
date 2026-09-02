using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.SlidingBlocks.View
{
	// Token: 0x02004F13 RID: 20243
	public class SettlementTargetItem : UiPanelBase
	{
		// Token: 0x0603450D RID: 214285 RVA: 0x00D173F2 File Offset: 0x00D155F2
		[NullableContext(1)]
		public SettlementTargetItem(ITargetDescribeAndScore config)
		{
		}

		// Token: 0x0603450E RID: 214286 RVA: 0x00D17404 File Offset: 0x00D15604
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603450F RID: 214287 RVA: 0x00D17490 File Offset: 0x00D15690
		protected override void OnStart()
		{
			UUIText text = base.GetText(1);
			if (text != null)
			{
				text.ShowTextNew(this.Config.DescribeTextKey);
			}
			double score = ModelBase<SlidingBlocksModel>.Instance.GameData.Score;
			UUIItem item = base.GetItem(2);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(score >= (double)this.Config.Score);
		}

		// Token: 0x0401E2DA RID: 123610
		[Nullable(1)]
		public readonly ITargetDescribeAndScore Config = config;

		// Token: 0x0200AF48 RID: 44872
		private enum EViewComponent
		{
			// Token: 0x04036648 RID: 222792
			AchieveBg,
			// Token: 0x04036649 RID: 222793
			TargetText,
			// Token: 0x0403664A RID: 222794
			AchieveItem
		}
	}
}
