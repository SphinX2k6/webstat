using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorFight
{
	// Token: 0x020066E2 RID: 26338
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class MotorFightTaskItem : GridProxyAbstract<MotorFightTaskData>
	{
		// Token: 0x06041C12 RID: 269330 RVA: 0x010DDACC File Offset: 0x010DBCCC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(4, this.OnRewardBtnClick);
			this.BtnBindInfo = list2;
		}

		// Token: 0x06041C13 RID: 269331 RVA: 0x010DDC11 File Offset: 0x010DBE11
		protected override void OnStart()
		{
			this.RewardScroll = new GenericScrollViewNew<CommonItemSmallItemGrid, TItem>(base.GetScrollViewWithScrollbar(2), new Func<CommonItemSmallItemGrid>(this.CreateRewardItem), null, false, null);
		}

		// Token: 0x06041C14 RID: 269332 RVA: 0x010DDC34 File Offset: 0x010DBE34
		public override void Refresh(MotorFightTaskData data, bool isSelected, int gridIndex)
		{
			this.RewardScroll.RefreshByData(data.RewardList, delegate
			{
				this.RewardScroll.ScrollToLeft(0);
			}, false);
			UUIItem item = base.GetItem(7);
			if (item != null)
			{
				item.SetUIActive(data.IsUnclaimed);
			}
			base.GetButton(4).RootUIComp.Get().SetUIActive(data.IsUnclaimed);
			base.GetSprite(5).SetUIActive(data.IsFinished);
			base.GetText(6).SetUIActive(data.IsDoing);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), data.TaskName, Array.Empty<object>());
			UUIText text = base.GetText(1);
			if (text != null)
			{
				text.SetUIActive(data.Target != 0);
			}
			UUIText text2 = base.GetText(1);
			if (text2 == null)
			{
				return;
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(data.Current);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(data.Target);
			text2.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}

		// Token: 0x06041C15 RID: 269333 RVA: 0x010DDD39 File Offset: 0x010DBF39
		private CommonItemSmallItemGrid CreateRewardItem()
		{
			return new CommonItemSmallItemGrid();
		}

		// Token: 0x04024AFB RID: 150267
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> RewardScroll;

		// Token: 0x04024AFC RID: 150268
		[Nullable(2)]
		public Action OnRewardBtnClick;

		// Token: 0x0200C718 RID: 50968
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403D4BF RID: 251071
			public const int TextName = 0;

			// Token: 0x0403D4C0 RID: 251072
			public const int TextProgress = 1;

			// Token: 0x0403D4C1 RID: 251073
			public const int ScrollReward = 2;

			// Token: 0x0403D4C2 RID: 251074
			public const int ItemReward = 3;

			// Token: 0x0403D4C3 RID: 251075
			public const int BtnReward = 4;

			// Token: 0x0403D4C4 RID: 251076
			public const int SpriteFinish = 5;

			// Token: 0x0403D4C5 RID: 251077
			public const int TextDoing = 6;

			// Token: 0x0403D4C6 RID: 251078
			public const int ItemRedDot = 7;
		}
	}
}
