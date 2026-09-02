using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005152 RID: 20818
	[NullableContext(1)]
	[Nullable(0)]
	public class RoguelikePopularEntriesDescPanel : UiPanelBase
	{
		// Token: 0x06035969 RID: 219497 RVA: 0x00D7568C File Offset: 0x00D7388C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickReduce));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickAdd));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603596A RID: 219498 RVA: 0x00D757B8 File Offset: 0x00D739B8
		protected override void OnStart()
		{
			this.DescLayout = new GenericScrollViewNew<RoguelikePopularEntryDesc, int>(base.GetScrollViewWithScrollbar(0), new Func<RoguelikePopularEntryDesc>(this.CreateDescItem), null, false, null);
		}

		// Token: 0x0603596B RID: 219499 RVA: 0x00D757DC File Offset: 0x00D739DC
		public UniTask Init(RoguelikeEntranceViewModel vm)
		{
			RoguelikePopularEntriesDescPanel.<Init>d__5 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.vm = vm;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<RoguelikePopularEntriesDescPanel.<Init>d__5>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x0603596C RID: 219500 RVA: 0x00D75828 File Offset: 0x00D73A28
		public void Refresh(RoguelikeEntranceViewModel vm)
		{
			GenericScrollViewNew<RoguelikePopularEntryDesc, int> descLayout = this.DescLayout;
			List<RoguelikePopularEntryDesc> list = ((descLayout != null) ? descLayout.GetScrollItemList() : null) ?? new List<RoguelikePopularEntryDesc>();
			List<bool> list2 = new List<bool>();
			List<bool> list3 = new List<bool>();
			int num = -1;
			for (int i = 0; i < list.Count; i++)
			{
				RoguelikePopularEntryDesc roguelikePopularEntryDesc = list[i];
				list2.Add(roguelikePopularEntryDesc.ShowState);
				bool overviewIdActiveState = vm.GetOverviewIdActiveState(roguelikePopularEntryDesc.OverviewId);
				list3.Add(overviewIdActiveState);
				if (overviewIdActiveState)
				{
					num = i;
				}
			}
			bool delayEmit = false;
			for (int j = 0; j < list.Count; j++)
			{
				if (j != num && !list2[j] && list3[j])
				{
					delayEmit = true;
					break;
				}
			}
			for (int k = 0; k < list.Count; k++)
			{
				RoguelikePopularEntryDesc roguelikePopularEntryDesc2 = list[k];
				roguelikePopularEntryDesc2.Reset();
				roguelikePopularEntryDesc2.RefreshState(list3[k], delayEmit);
			}
			RogueHotEntryGroup config = vm.CurrentEntriesGroupData.GetConfig();
			base.GetText(2).SetText(((float)config.Rate / 100f).ToString() + "%", true);
			base.GetText(2).SetColor(FColor.FromHex(config.RateColor));
			base.GetButton(3).SetSelfInteractive(vm.IsReduceMultiplierAvailable);
			base.GetButton(4).SetSelfInteractive(vm.IsAddMultiplierAvailable);
		}

		// Token: 0x0603596D RID: 219501 RVA: 0x00D75988 File Offset: 0x00D73B88
		private RoguelikePopularEntryDesc CreateDescItem()
		{
			return new RoguelikePopularEntryDesc();
		}

		// Token: 0x0603596E RID: 219502 RVA: 0x00D7598F File Offset: 0x00D73B8F
		private void OnClickReduce()
		{
			Action<bool> onMultiplierChange = this.OnMultiplierChange;
			if (onMultiplierChange == null)
			{
				return;
			}
			onMultiplierChange(false);
		}

		// Token: 0x0603596F RID: 219503 RVA: 0x00D759A2 File Offset: 0x00D73BA2
		private void OnClickAdd()
		{
			Action<bool> onMultiplierChange = this.OnMultiplierChange;
			if (onMultiplierChange == null)
			{
				return;
			}
			onMultiplierChange(true);
		}

		// Token: 0x0401EC81 RID: 126081
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericScrollViewNew<RoguelikePopularEntryDesc, int> DescLayout;

		// Token: 0x0401EC82 RID: 126082
		[Nullable(2)]
		public Action<bool> OnMultiplierChange;

		// Token: 0x0200B0FC RID: 45308
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x04036E58 RID: 224856
			public const int ScrollViewEntryDesc = 0;

			// Token: 0x04036E59 RID: 224857
			public const int EntryDesc = 1;

			// Token: 0x04036E5A RID: 224858
			public const int TxtMultiplier = 2;

			// Token: 0x04036E5B RID: 224859
			public const int BtnReduce = 3;

			// Token: 0x04036E5C RID: 224860
			public const int BtnAdd = 4;
		}
	}
}
