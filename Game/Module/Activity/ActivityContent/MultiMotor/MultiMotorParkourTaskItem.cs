using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MultiMotor
{
	// Token: 0x02006661 RID: 26209
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class MultiMotorParkourTaskItem : GridProxyAbstract<MultiMotorTaskData>
	{
		// Token: 0x06041731 RID: 268081 RVA: 0x010CC2AC File Offset: 0x010CA4AC
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

		// Token: 0x06041732 RID: 268082 RVA: 0x010CC3D6 File Offset: 0x010CA5D6
		protected override void OnStart()
		{
			this.RewardScrollView = new GenericScrollViewNew<CommonItemSmallItemGrid, TItem>(base.GetScrollViewWithScrollbar(2), new Func<CommonItemSmallItemGrid>(this.CreatePropItem), null, false, null);
		}

		// Token: 0x06041733 RID: 268083 RVA: 0x010CC3FC File Offset: 0x010CA5FC
		public override void Refresh(MultiMotorTaskData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			this.RewardScrollView.RefreshByData(data.RewardList.ToList<TItem>(), null, false);
			base.GetText(0).SetText(data.DescString, true);
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

		// Token: 0x06041734 RID: 268084 RVA: 0x010CC4A2 File Offset: 0x010CA6A2
		private CommonItemSmallItemGrid CreatePropItem()
		{
			return new CommonItemSmallItemGrid();
		}

		// Token: 0x06041735 RID: 268085 RVA: 0x010CC4A9 File Offset: 0x010CA6A9
		private void OnClickGetButton()
		{
			ControllerBase<MultiMotorController>.Instance.MotorOnlineRewardRequest(this.Data.LevelId);
		}

		// Token: 0x04024988 RID: 149896
		[Nullable(2)]
		private MultiMotorTaskData Data;

		// Token: 0x04024989 RID: 149897
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> RewardScrollView;

		// Token: 0x0200C685 RID: 50821
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403D203 RID: 250371
			public const int TxtName = 0;

			// Token: 0x0403D204 RID: 250372
			public const int ProgressText = 1;

			// Token: 0x0403D205 RID: 250373
			public const int RewardScroll = 2;

			// Token: 0x0403D206 RID: 250374
			public const int GetBtn = 3;

			// Token: 0x0403D207 RID: 250375
			public const int DoingText = 4;

			// Token: 0x0403D208 RID: 250376
			public const int PanelDone = 5;
		}
	}
}
