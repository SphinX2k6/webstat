using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E5C RID: 20060
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseBdSumBdDescPanel : UiPanelBase
	{
		// Token: 0x06033D6C RID: 212332 RVA: 0x00CF69F4 File Offset: 0x00CF4BF4
		public UniTask Init(UUIItem item)
		{
			TrapDefenseBdSumBdDescPanel.<Init>d__3 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.item = item;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<TrapDefenseBdSumBdDescPanel.<Init>d__3>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x06033D6D RID: 212333 RVA: 0x00CF6A3F File Offset: 0x00CF4C3F
		protected override void OnBeforeCreate()
		{
		}

		// Token: 0x06033D6E RID: 212334 RVA: 0x00CF6A44 File Offset: 0x00CF4C44
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUILayoutBase));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06033D6F RID: 212335 RVA: 0x00CF6B52 File Offset: 0x00CF4D52
		[Conditional("WITH_EDITOR")]
		private void EditorShowActorLabel()
		{
		}

		// Token: 0x06033D70 RID: 212336 RVA: 0x00CF6B54 File Offset: 0x00CF4D54
		protected override UniTask OnBeforeStartAsync()
		{
			TrapDefenseBdSumBdDescPanel.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TrapDefenseBdSumBdDescPanel.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06033D71 RID: 212337 RVA: 0x00CF6B97 File Offset: 0x00CF4D97
		protected override void OnStart()
		{
		}

		// Token: 0x06033D72 RID: 212338 RVA: 0x00CF6B99 File Offset: 0x00CF4D99
		protected override void OnBeforeShow()
		{
		}

		// Token: 0x06033D73 RID: 212339 RVA: 0x00CF6B9B File Offset: 0x00CF4D9B
		protected override void OnBeforeDestroy()
		{
		}

		// Token: 0x06033D74 RID: 212340 RVA: 0x00CF6BA0 File Offset: 0x00CF4DA0
		public void UpdateData(TrapDefenseBdData data)
		{
			this.BdData = data;
			bool flag = !data.IsUnlockInTheUi();
			UUIItem item = base.GetItem(1);
			if (item != null)
			{
				item.SetUIActive(flag);
			}
			UUIItem item2 = base.GetItem(0);
			if (item2 != null)
			{
				item2.SetUIActive(!flag);
			}
			if (!flag)
			{
				UUIText text = base.GetText(2);
				if (text != null)
				{
					text.ShowTextNew(data.Config.Name);
				}
				UUIText text2 = base.GetText(3);
				if (text2 != null)
				{
					text2.ShowTextNew(data.Config.Desc);
				}
				this.UpdateGoldQualityBuffShow();
			}
		}

		// Token: 0x06033D75 RID: 212341 RVA: 0x00CF6C2C File Offset: 0x00CF4E2C
		public void UpdateGoldQualityBuffShow()
		{
			List<TrapDefenseBdBuffData> goldQualityBuffDataList = this.BdData.GetGoldQualityBuffDataList();
			bool flag = goldQualityBuffDataList.Count > 0;
			UUIItem item = base.GetItem(4);
			if (item != null)
			{
				item.SetUIActive(flag);
			}
			if (flag)
			{
				this.LayoutBdBuff.RefreshByData(goldQualityBuffDataList, null, false);
			}
		}

		// Token: 0x06033D76 RID: 212342 RVA: 0x00CF6C73 File Offset: 0x00CF4E73
		private TrapDefenseBdBuffItem CreateItemBdBuff()
		{
			return new TrapDefenseBdBuffItem
			{
				OnClickBuffItemCallback = new Action<TrapDefenseBdBuffData>(this.OnClickBdBuffItem),
				CanExecuteChangeCallback = new Func<TrapDefenseBdBuffData, bool>(this.BdBuffCanExecuteChange)
			};
		}

		// Token: 0x06033D77 RID: 212343 RVA: 0x00CF6CA0 File Offset: 0x00CF4EA0
		private void OnClickBdBuffItem(TrapDefenseBdBuffData data)
		{
			TrapDefenseBdData belongBdData = data.GetBelongBdData();
			int quality = data.Config.Quality;
			bool bdQualityShowNew = this.GetBdQualityShowNew(belongBdData, (ETrapDefenseBdBuffQuality)quality);
			ModelBase<TrapDefenseModel>.Instance.OpenViewBdQuality(belongBdData.Id, new ETrapDefenseBdBuffQuality?((ETrapDefenseBdBuffQuality)quality), new bool?(bdQualityShowNew), new int?(data.Id));
		}

		// Token: 0x06033D78 RID: 212344 RVA: 0x00CF6CF0 File Offset: 0x00CF4EF0
		public bool GetBdQualityShowNew(TrapDefenseBdData bdData, ETrapDefenseBdBuffQuality quality)
		{
			return ModelBase<TrapDefenseModel>.Instance.ViewModelBdSum.IsInstance && bdData.GetCurActiveQualityPool() == quality;
		}

		// Token: 0x06033D79 RID: 212345 RVA: 0x00CF6D0E File Offset: 0x00CF4F0E
		private bool BdBuffCanExecuteChange(TrapDefenseBdBuffData _)
		{
			return false;
		}

		// Token: 0x0401DFCB RID: 122827
		[Nullable(2)]
		public TrapDefenseBdData BdData;

		// Token: 0x0401DFCC RID: 122828
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public GenericLayout<TrapDefenseBdBuffItem, TrapDefenseBdBuffData> LayoutBdBuff;

		// Token: 0x0200AE03 RID: 44547
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x040360AA RID: 221354
			public const int ItemBdInfoRoot = 0;

			// Token: 0x040360AB RID: 221355
			public const int ItemLockRoot = 1;

			// Token: 0x040360AC RID: 221356
			public const int TextTitle = 2;

			// Token: 0x040360AD RID: 221357
			public const int TextDesc = 3;

			// Token: 0x040360AE RID: 221358
			public const int ItemBdBuffRoot = 4;

			// Token: 0x040360AF RID: 221359
			public const int LayoutBdBuff = 5;

			// Token: 0x040360B0 RID: 221360
			public const int ItemBdBuff = 6;
		}
	}
}
