using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x0200516F RID: 20847
	public class RoguelikePhantomNewUnlockView : UiViewBase
	{
		// Token: 0x06035A5C RID: 219740 RVA: 0x00D79979 File Offset: 0x00D77B79
		[NullableContext(1)]
		public RoguelikePhantomNewUnlockView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06035A5D RID: 219741 RVA: 0x00D79984 File Offset: 0x00D77B84
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.CloseBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06035A5E RID: 219742 RVA: 0x00D79AB0 File Offset: 0x00D77CB0
		protected override UniTask OnBeforeStartAsync()
		{
			RoguelikePhantomNewUnlockView.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoguelikePhantomNewUnlockView.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06035A5F RID: 219743 RVA: 0x00D79AF3 File Offset: 0x00D77CF3
		private void CloseBtn()
		{
			base.CloseMe(null);
		}

		// Token: 0x06035A60 RID: 219744 RVA: 0x00D79AFC File Offset: 0x00D77CFC
		[NullableContext(1)]
		private RoguelikePhantomSelectDragItem CreatePhantomSelectDragItem()
		{
			return new RoguelikePhantomSelectDragItem
			{
				CanToggleStateChange = new Func<bool, bool>(this.CanToggleStateChange)
			};
		}

		// Token: 0x06035A61 RID: 219745 RVA: 0x00D79B15 File Offset: 0x00D77D15
		private bool CanToggleStateChange(bool bState)
		{
			return false;
		}

		// Token: 0x0401ECD7 RID: 126167
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<RoguelikePhantomSelectDragItem, IPhantomSelectItemData> PhantomSelectItemLayout;

		// Token: 0x0200B11E RID: 45342
		private class EComponents
		{
			// Token: 0x04036F02 RID: 225026
			public const int BtnMask = 0;

			// Token: 0x04036F03 RID: 225027
			public const int TxtTitle = 1;

			// Token: 0x04036F04 RID: 225028
			public const int PanelTitle = 2;

			// Token: 0x04036F05 RID: 225029
			public const int TxtClose = 3;

			// Token: 0x04036F06 RID: 225030
			public const int ScrollView = 4;

			// Token: 0x04036F07 RID: 225031
			public const int Content = 5;
		}
	}
}
