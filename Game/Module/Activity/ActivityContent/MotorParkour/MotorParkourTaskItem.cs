using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorParkour
{
	// Token: 0x020066BB RID: 26299
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class MotorParkourTaskItem : GridProxyAbstract<MotorParkourTaskData>
	{
		// Token: 0x06041AAB RID: 268971 RVA: 0x010D6A08 File Offset: 0x010D4C08
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickGetButton));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06041AAC RID: 268972 RVA: 0x010D6B32 File Offset: 0x010D4D32
		protected override void OnStart()
		{
			this.RewardScrollView = new GenericScrollViewNew<CommonItemSmallItemGrid, TItem>(base.GetScrollViewWithScrollbar(2), new Func<CommonItemSmallItemGrid>(this.CreatePropItem), null, false, null);
		}

		// Token: 0x06041AAD RID: 268973 RVA: 0x010D6B58 File Offset: 0x010D4D58
		public override void Refresh(MotorParkourTaskData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			this.RewardScrollView.RefreshByData(data.RewardList.ToList<TItem>(), null, false);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), data.Desc, Array.Empty<object>());
			UUIText text = base.GetText(1);
			if (text != null)
			{
				text.SetUIActive(false);
			}
			UUIItem item = base.GetItem(5);
			if (item != null)
			{
				item.SetUIActive(data.IsReceived);
			}
			UUIButtonComponent button = base.GetButton(3);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(data.IsFinished);
			}
			UUIText text2 = base.GetText(4);
			if (text2 == null)
			{
				return;
			}
			text2.SetUIActive(data.IsRunning);
		}

		// Token: 0x06041AAE RID: 268974 RVA: 0x010D6C07 File Offset: 0x010D4E07
		private CommonItemSmallItemGrid CreatePropItem()
		{
			return new CommonItemSmallItemGrid();
		}

		// Token: 0x06041AAF RID: 268975 RVA: 0x010D6C0E File Offset: 0x010D4E0E
		private void OnClickGetButton()
		{
			ControllerBase<MotorParkourController>.Instance.RequestTaskReward(this.Data.LevelId);
		}

		// Token: 0x04024A7A RID: 150138
		[Nullable(2)]
		private MotorParkourTaskData Data;

		// Token: 0x04024A7B RID: 150139
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> RewardScrollView;

		// Token: 0x0200C6E2 RID: 50914
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403D3B9 RID: 250809
			public const int TxtName = 0;

			// Token: 0x0403D3BA RID: 250810
			public const int ProgressText = 1;

			// Token: 0x0403D3BB RID: 250811
			public const int RewardScroll = 2;

			// Token: 0x0403D3BC RID: 250812
			public const int GetBtn = 3;

			// Token: 0x0403D3BD RID: 250813
			public const int DoingText = 4;

			// Token: 0x0403D3BE RID: 250814
			public const int PanelDone = 5;
		}
	}
}
