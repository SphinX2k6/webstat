using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Role
{
	// Token: 0x020065C5 RID: 26053
	public class PinballAttributeDetailView : UiViewBase
	{
		// Token: 0x06041193 RID: 266643 RVA: 0x010B3E42 File Offset: 0x010B2042
		[NullableContext(1)]
		public PinballAttributeDetailView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06041194 RID: 266644 RVA: 0x010B3E4C File Offset: 0x010B204C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06041195 RID: 266645 RVA: 0x010B3ED8 File Offset: 0x010B20D8
		protected override UniTask OnBeforeStartAsync()
		{
			PinballAttributeDetailView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PinballAttributeDetailView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041196 RID: 266646 RVA: 0x010B3F1B File Offset: 0x010B211B
		[NullableContext(1)]
		private PinballAttributeDetailItem CreateAttrItem()
		{
			return new PinballAttributeDetailItem();
		}

		// Token: 0x06041197 RID: 266647 RVA: 0x010B3F22 File Offset: 0x010B2122
		private void OnCloseButtonClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x04024782 RID: 149378
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected List<IPinballAttributeDetailItemData> AttributeDataList;

		// Token: 0x04024783 RID: 149379
		[Nullable(2)]
		protected PopupCaptionItem CaptionItem;

		// Token: 0x04024784 RID: 149380
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		protected GenericScrollViewNew<PinballAttributeDetailItem, IPinballAttributeDetailItemData> AttrScrollView;

		// Token: 0x0200C5C8 RID: 50632
		private enum EComponent
		{
			// Token: 0x0403CE06 RID: 249350
			CaptionItem,
			// Token: 0x0403CE07 RID: 249351
			AttrScrollView,
			// Token: 0x0403CE08 RID: 249352
			AttrTemplateItem
		}
	}
}
