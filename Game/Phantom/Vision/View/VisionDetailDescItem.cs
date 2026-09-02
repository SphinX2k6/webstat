using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Phantom.Vision.View
{
	// Token: 0x02004A6D RID: 19053
	[NullableContext(1)]
	[Nullable(0)]
	public class VisionDetailDescItem : UiPanelBase
	{
		// Token: 0x06031BE4 RID: 203748 RVA: 0x00C748C4 File Offset: 0x00C72AC4
		public void Clear()
		{
		}

		// Token: 0x06031BE5 RID: 203749 RVA: 0x00C748C6 File Offset: 0x00C72AC6
		public VisionDetailDescItem(UUIItem actor)
		{
			this.SourceItem = actor;
		}

		// Token: 0x06031BE6 RID: 203750 RVA: 0x00C748D8 File Offset: 0x00C72AD8
		public UniTask Init()
		{
			VisionDetailDescItem.<Init>d__6 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<VisionDetailDescItem.<Init>d__6>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x06031BE7 RID: 203751 RVA: 0x00C7491C File Offset: 0x00C72B1C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickJumpButton));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06031BE8 RID: 203752 RVA: 0x00C74AAA File Offset: 0x00C72CAA
		protected override void OnStart()
		{
			this.Layout = new GenericLayout<VisionDetailDescContentItem, VisionDetailDesc>(base.GetVerticalLayout(7), new Func<VisionDetailDescContentItem>(this.InitItem), null, false, true);
			base.GetItem(3).SetUIActive(false);
		}

		// Token: 0x06031BE9 RID: 203753 RVA: 0x00C74ADA File Offset: 0x00C72CDA
		private VisionDetailDescContentItem InitItem()
		{
			return new VisionDetailDescContentItem();
		}

		// Token: 0x06031BEA RID: 203754 RVA: 0x00C74AE1 File Offset: 0x00C72CE1
		private void OnClickJumpButton()
		{
			if (this.Data != null && this.Data.JumpCallBack != null)
			{
				this.Data.JumpCallBack();
			}
		}

		// Token: 0x06031BEB RID: 203755 RVA: 0x00C74B08 File Offset: 0x00C72D08
		public void Update(List<VisionDetailDesc> dataList)
		{
			VisionDetailDesc visionDetailDesc = null;
			List<VisionDetailDesc> list = new List<VisionDetailDesc>();
			foreach (VisionDetailDesc visionDetailDesc2 in dataList)
			{
				if (visionDetailDesc2.SkillConfig != null || (visionDetailDesc2.TitleItemShowState && visionDetailDesc2.TitleType == 0))
				{
					visionDetailDesc = visionDetailDesc2;
					if (visionDetailDesc2.SkillConfig != null)
					{
						list.Add(visionDetailDesc);
					}
				}
				if (visionDetailDesc2.FetterId > 0 || (visionDetailDesc2.TitleItemShowState && visionDetailDesc2.TitleType == 1) || visionDetailDesc2.GetNeedWarn())
				{
					if (visionDetailDesc2.TitleItemShowState)
					{
						visionDetailDesc = visionDetailDesc2;
					}
					if (visionDetailDesc2.FetterId > 0 || visionDetailDesc2.GetNeedWarn())
					{
						list.Add(visionDetailDesc2);
					}
				}
			}
			this.Data = visionDetailDesc;
			if (visionDetailDesc != null)
			{
				this.RefreshTitle(visionDetailDesc);
				this.RefreshJumpButton(visionDetailDesc);
				this.RefreshEmpty(visionDetailDesc);
				this.RefreshTitleItem(visionDetailDesc);
				this.RefreshEmptyContentItem(visionDetailDesc);
				this.RefreshDesc(list);
			}
		}

		// Token: 0x06031BEC RID: 203756 RVA: 0x00C74C08 File Offset: 0x00C72E08
		private void RefreshDesc(List<VisionDetailDesc> data)
		{
			GenericLayout<VisionDetailDescContentItem, VisionDetailDesc> layout = this.Layout;
			if (layout == null)
			{
				return;
			}
			layout.RefreshByData(data, null, false);
		}

		// Token: 0x06031BED RID: 203757 RVA: 0x00C74C1D File Offset: 0x00C72E1D
		private void RefreshTitle(VisionDetailDesc data)
		{
			base.GetText(0).SetText(data.Title, true);
		}

		// Token: 0x06031BEE RID: 203758 RVA: 0x00C74C34 File Offset: 0x00C72E34
		private void RefreshJumpButton(VisionDetailDesc data)
		{
			base.GetButton(1).RootUIComp.Get().SetUIActive(data.JumpCallBack != null && !data.CompareState);
		}

		// Token: 0x06031BEF RID: 203759 RVA: 0x00C74C6E File Offset: 0x00C72E6E
		private void RefreshEmpty(VisionDetailDesc data)
		{
			base.GetItem(2).SetUIActive(data.EmptyState);
			if (data.EmptyState)
			{
				base.GetItem(8).SetUIActive(data.TitleType == 0);
			}
		}

		// Token: 0x06031BF0 RID: 203760 RVA: 0x00C74C9F File Offset: 0x00C72E9F
		private void RefreshEmptyContentItem(VisionDetailDesc data)
		{
			base.GetText(5).SetText(data.EmptyText, true);
		}

		// Token: 0x06031BF1 RID: 203761 RVA: 0x00C74CB4 File Offset: 0x00C72EB4
		private void RefreshTitleItem(VisionDetailDesc data)
		{
			base.GetItem(4).SetUIActive(data.TitleItemShowState);
		}

		// Token: 0x0401D1FF RID: 119295
		[Nullable(2)]
		private readonly UUIItem SourceItem;

		// Token: 0x0401D200 RID: 119296
		[Nullable(2)]
		protected VisionDetailDesc CurrentData;

		// Token: 0x0401D201 RID: 119297
		[Nullable(2)]
		private VisionDetailDesc Data;

		// Token: 0x0401D202 RID: 119298
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<VisionDetailDescContentItem, VisionDetailDesc> Layout;
	}
}
