using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorFight
{
	// Token: 0x020066F0 RID: 26352
	[NullableContext(1)]
	[Nullable(0)]
	public class MotorFightPauseView : UiViewBase
	{
		// Token: 0x06041C74 RID: 269428 RVA: 0x010DFAFE File Offset: 0x010DDCFE
		public MotorFightPauseView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06041C75 RID: 269429 RVA: 0x010DFB14 File Offset: 0x010DDD14
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 5;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnLeaveBtnClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnSettleAndLeaveBtnClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnReChallengeBtnClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnContinueBtnClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(10, new Action(this.OnDetailBtnClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06041C76 RID: 269430 RVA: 0x010DFD30 File Offset: 0x010DDF30
		protected override UniTask OnBeforeStartAsync()
		{
			MotorFightPauseView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MotorFightPauseView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041C77 RID: 269431 RVA: 0x010DFD74 File Offset: 0x010DDF74
		private int SortItemList(MotorcycleArrowCollectionItemData a, MotorcycleArrowCollectionItemData b)
		{
			if (a.Config.Type != b.Config.Type)
			{
				Dictionary<int, int> dictionary = this.ItemNumMap[a.Config.Type];
				Dictionary<int, int> dictionary2 = this.ItemNumMap[b.Config.Type];
				if (dictionary.Count != dictionary2.Count)
				{
					return dictionary2.Count - dictionary.Count;
				}
				for (int i = 5; i >= 3; i--)
				{
					int num;
					if (!dictionary.TryGetValue(i, out num))
					{
						num = 0;
					}
					int num2;
					if (!dictionary2.TryGetValue(i, out num2))
					{
						num2 = 0;
					}
					if (num != num2)
					{
						return num2 - num;
					}
				}
				return a.Config.Type - b.Config.Type;
			}
			else
			{
				if (a.Config.Quality != b.Config.Quality)
				{
					return b.Config.Quality - a.Config.Quality;
				}
				return a.Id - b.Id;
			}
		}

		// Token: 0x06041C78 RID: 269432 RVA: 0x010DFE6C File Offset: 0x010DE06C
		private void OnItemClick(MotorcycleArrowCollectionItemData data)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MotorcycleArrowCollectionTipsView, data, null);
		}

		// Token: 0x06041C79 RID: 269433 RVA: 0x010DFE7F File Offset: 0x010DE07F
		private CollectionGridItemPanel CreateItem()
		{
			return new CollectionGridItemPanel
			{
				OnClickCallBack = new Action<MotorcycleArrowCollectionItemData>(this.OnItemClick),
				NeedSelectedState = false
			};
		}

		// Token: 0x06041C7A RID: 269434 RVA: 0x010DFE9F File Offset: 0x010DE09F
		private MotorFightSummaryAttrItem CreateAttrItem()
		{
			return new MotorFightSummaryAttrItem();
		}

		// Token: 0x06041C7B RID: 269435 RVA: 0x010DFEA6 File Offset: 0x010DE0A6
		private void OnLeaveBtnClick()
		{
			ControllerBase<MotorFightController>.Instance.LeaveInstanceDungeon();
		}

		// Token: 0x06041C7C RID: 269436 RVA: 0x010DFEB2 File Offset: 0x010DE0B2
		private void OnSettleAndLeaveBtnClick()
		{
			ControllerBase<MotorFightController>.Instance.RequestSettlement(true, null);
			base.CloseMe(null);
		}

		// Token: 0x06041C7D RID: 269437 RVA: 0x010DFEC7 File Offset: 0x010DE0C7
		private void OnReChallengeBtnClick()
		{
			ControllerBase<MotorFightController>.Instance.RequestSettlement(false, delegate
			{
				ControllerBase<MotorFightController>.Instance.ReChallengeMotorFightDungeon();
			});
		}

		// Token: 0x06041C7E RID: 269438 RVA: 0x010DFEF3 File Offset: 0x010DE0F3
		private void OnContinueBtnClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x06041C7F RID: 269439 RVA: 0x010DFEFC File Offset: 0x010DE0FC
		private void OnDetailBtnClick()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MotorFightAttrDetailView, null, null);
		}

		// Token: 0x06041C80 RID: 269440 RVA: 0x010DFF0F File Offset: 0x010DE10F
		private void OnCloseBtnClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x04024B26 RID: 150310
		public Dictionary<int, Dictionary<int, int>> ItemNumMap = new Dictionary<int, Dictionary<int, int>>();

		// Token: 0x04024B27 RID: 150311
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x04024B28 RID: 150312
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<CollectionGridItemPanel, MotorcycleArrowCollectionItemData> ItemScrollLayout;

		// Token: 0x04024B29 RID: 150313
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<MotorFightSummaryAttrItem, EMotorFightAttrShowType> AttrLayout;

		// Token: 0x0200C734 RID: 50996
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x0403D53F RID: 251199
			public const int ItemCaption = 0;

			// Token: 0x0403D540 RID: 251200
			public const int BtnLeave = 1;

			// Token: 0x0403D541 RID: 251201
			public const int BtnSettleAndLeave = 2;

			// Token: 0x0403D542 RID: 251202
			public const int BtnReChallenge = 3;

			// Token: 0x0403D543 RID: 251203
			public const int BtnContinue = 4;

			// Token: 0x0403D544 RID: 251204
			public const int ItemEmptyPanel = 5;

			// Token: 0x0403D545 RID: 251205
			public const int ScrollLayoutItem = 6;

			// Token: 0x0403D546 RID: 251206
			public const int ItemBase = 7;

			// Token: 0x0403D547 RID: 251207
			public const int LayoutAttribute = 8;

			// Token: 0x0403D548 RID: 251208
			public const int ItemAttribute = 9;

			// Token: 0x0403D549 RID: 251209
			public const int BtnDetail = 10;
		}
	}
}
