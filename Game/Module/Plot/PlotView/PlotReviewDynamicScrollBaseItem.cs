using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.PlotView
{
	// Token: 0x020053C3 RID: 21443
	public class PlotReviewDynamicScrollBaseItem : UiPanelBase, IDynamicScrollBaseItem<PlotReviewItemData>
	{
		// Token: 0x06036AE9 RID: 223977 RVA: 0x00DDB4B8 File Offset: 0x00DD96B8
		[NullableContext(1)]
		public UniTask Init(UUIItem actor)
		{
			PlotReviewDynamicScrollBaseItem.<Init>d__1 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.actor = actor;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<PlotReviewDynamicScrollBaseItem.<Init>d__1>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x06036AEA RID: 223978 RVA: 0x00DDB504 File Offset: 0x00DD9704
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06036AEB RID: 223979 RVA: 0x00DDB570 File Offset: 0x00DD9770
		[NullableContext(1)]
		public FVector2D GetItemSize(PlotReviewItemData data)
		{
			int? num = null;
			EPlotReviewItemType type = data.Type;
			if (type != EPlotReviewItemType.Talk)
			{
				if (type == EPlotReviewItemType.Option)
				{
					num = new int?(1);
				}
			}
			else
			{
				num = new int?(0);
			}
			UUIItem item = base.GetItem(num.GetValueOrDefault());
			return new FVector2D(item.GetWidth(), item.GetHeight());
		}

		// Token: 0x06036AEC RID: 223980 RVA: 0x00DDB5C6 File Offset: 0x00DD97C6
		public void ClearItem()
		{
		}

		// Token: 0x0200B337 RID: 45879
		private static class EComponent
		{
			// Token: 0x04037852 RID: 227410
			public const int TalkItem = 0;

			// Token: 0x04037853 RID: 227411
			public const int OptionItem = 1;
		}
	}
}
