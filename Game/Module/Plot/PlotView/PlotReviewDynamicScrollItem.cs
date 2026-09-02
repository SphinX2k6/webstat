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
	// Token: 0x020053C4 RID: 21444
	[NullableContext(1)]
	[Nullable(0)]
	public class PlotReviewDynamicScrollItem : UiPanelBase, IDynamicScrollItem<PlotReviewItemData>
	{
		// Token: 0x06036AEE RID: 223982 RVA: 0x00DDB5D0 File Offset: 0x00DD97D0
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

		// Token: 0x06036AEF RID: 223983 RVA: 0x00DDB63C File Offset: 0x00DD983C
		public UniTask Init(UUIItem actor)
		{
			PlotReviewDynamicScrollItem.<Init>d__6 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.actor = actor;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<PlotReviewDynamicScrollItem.<Init>d__6>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x06036AF0 RID: 223984 RVA: 0x00DDB688 File Offset: 0x00DD9888
		private UniTask InitChildItem()
		{
			PlotReviewDynamicScrollItem.<InitChildItem>d__7 <InitChildItem>d__;
			<InitChildItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitChildItem>d__.<>4__this = this;
			<InitChildItem>d__.<>1__state = -1;
			<InitChildItem>d__.<>t__builder.Start<PlotReviewDynamicScrollItem.<InitChildItem>d__7>(ref <InitChildItem>d__);
			return <InitChildItem>d__.<>t__builder.Task;
		}

		// Token: 0x06036AF1 RID: 223985 RVA: 0x00DDB6CC File Offset: 0x00DD98CC
		public AUIBaseActor GetUsingItem(PlotReviewItemData data)
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
			return base.GetItem(num.GetValueOrDefault()).GetOwner() as AUIBaseActor;
		}

		// Token: 0x06036AF2 RID: 223986 RVA: 0x00DDB71A File Offset: 0x00DD991A
		public void Update(PlotReviewItemData data, int index)
		{
			this.Data = data;
			this.Index = index;
			this.Refresh();
		}

		// Token: 0x06036AF3 RID: 223987 RVA: 0x00DDB730 File Offset: 0x00DD9930
		public void Refresh()
		{
			bool uiactive = false;
			bool uiactive2 = false;
			EPlotReviewItemType type = this.Data.Type;
			if (type != EPlotReviewItemType.Talk)
			{
				if (type == EPlotReviewItemType.Option)
				{
					uiactive2 = true;
					this.RefreshOptionItem();
				}
			}
			else
			{
				uiactive = true;
				this.RefreshTalkItem();
			}
			base.GetItem(0).SetUIActive(uiactive);
			base.GetItem(1).SetUIActive(uiactive2);
		}

		// Token: 0x06036AF4 RID: 223988 RVA: 0x00DDB784 File Offset: 0x00DD9984
		public void RefreshTalkItem()
		{
			PlotReviewTalkItemData data = (PlotReviewTalkItemData)this.Data.Data;
			this.TalkItem.Update(data, this.Index);
		}

		// Token: 0x06036AF5 RID: 223989 RVA: 0x00DDB7B4 File Offset: 0x00DD99B4
		public void RefreshOptionItem()
		{
			PlotReviewOptionItemData data = (PlotReviewOptionItemData)this.Data.Data;
			this.OptionItem.Update(data, this.Index);
		}

		// Token: 0x06036AF6 RID: 223990 RVA: 0x00DDB7E4 File Offset: 0x00DD99E4
		public void SetTalkItemToggleClickCallBack(Action<int> onToggleClick)
		{
			this.TalkItem.OnToggleClick = onToggleClick;
		}

		// Token: 0x06036AF7 RID: 223991 RVA: 0x00DDB7F2 File Offset: 0x00DD99F2
		public void SetTalkItemCanToggleChangeCallBack(Func<int, bool> canToggleChange)
		{
			this.TalkItem.CanToggleChange = canToggleChange;
		}

		// Token: 0x06036AF8 RID: 223992 RVA: 0x00DDB800 File Offset: 0x00DD9A00
		public void SetTalkItemToggleState(EToggleState state)
		{
			this.TalkItem.SetToggleState(state);
		}

		// Token: 0x06036AF9 RID: 223993 RVA: 0x00DDB80E File Offset: 0x00DD9A0E
		public void ClearItem()
		{
			base.Destroy(null);
		}

		// Token: 0x0401F7FB RID: 129019
		protected int Index = -1;

		// Token: 0x0401F7FC RID: 129020
		[Nullable(2)]
		private PlotReviewItemData Data;

		// Token: 0x0401F7FD RID: 129021
		private readonly PlotReviewTalkItem TalkItem = new PlotReviewTalkItem();

		// Token: 0x0401F7FE RID: 129022
		private readonly PlotReviewOptionItem OptionItem = new PlotReviewOptionItem();

		// Token: 0x0200B339 RID: 45881
		[NullableContext(0)]
		private static class EPlotReviewDynamicScrollItemComponent
		{
			// Token: 0x04037859 RID: 227417
			public const int TalkItem = 0;

			// Token: 0x0403785A RID: 227418
			public const int OptionItem = 1;
		}
	}
}
