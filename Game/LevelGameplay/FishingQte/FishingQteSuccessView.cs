using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Activity.ActivityContent.Fishing;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.FishingQte
{
	// Token: 0x02006E96 RID: 28310
	public class FishingQteSuccessView : UiViewBase
	{
		// Token: 0x06044A65 RID: 281189 RVA: 0x011D7D1C File Offset: 0x011D5F1C
		[NullableContext(1)]
		public FishingQteSuccessView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06044A66 RID: 281190 RVA: 0x011D7D28 File Offset: 0x011D5F28
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnButtonClicked));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnButtonClicked));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06044A67 RID: 281191 RVA: 0x011D7E33 File Offset: 0x011D6033
		protected override void OnStart()
		{
			this.GenericScrollView = new GenericScrollViewNew<DockyardItemListItem, DockyardItemBlockOriginalData>(base.GetScrollViewWithScrollbar(2), new Func<DockyardItemListItem>(this.InitGridItem), null, false, null);
		}

		// Token: 0x06044A68 RID: 281192 RVA: 0x011D7E58 File Offset: 0x011D6058
		protected override void OnBeforeShow()
		{
			List<DockyardItemBlockOriginalData> data = this.OpenParam as List<DockyardItemBlockOriginalData>;
			this.GenericScrollView.RefreshByData(data, null, true);
		}

		// Token: 0x06044A69 RID: 281193 RVA: 0x011D7E7F File Offset: 0x011D607F
		[NullableContext(1)]
		private DockyardItemListItem InitGridItem()
		{
			return new DockyardItemListItem
			{
				NeedInteract = false
			};
		}

		// Token: 0x06044A6A RID: 281194 RVA: 0x011D7E8D File Offset: 0x011D608D
		private void OnButtonClicked()
		{
			ControllerBase<FishingController>.Instance.OpenDockyardWareHouseView(false);
			base.CloseMe(null);
		}

		// Token: 0x0402637A RID: 156538
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<DockyardItemListItem, DockyardItemBlockOriginalData> GenericScrollView;

		// Token: 0x0200CB5B RID: 52059
		private class EComponents
		{
			// Token: 0x0403E690 RID: 255632
			public const int ButtonMask = 0;

			// Token: 0x0403E691 RID: 255633
			public const int ButtonBack = 1;

			// Token: 0x0403E692 RID: 255634
			public const int ScrollView = 2;

			// Token: 0x0403E693 RID: 255635
			public const int GridItem = 3;
		}
	}
}
