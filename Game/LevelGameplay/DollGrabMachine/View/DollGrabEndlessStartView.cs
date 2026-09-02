using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.DollGrabMachine.View
{
	// Token: 0x02006EEC RID: 28396
	[NullableContext(1)]
	[Nullable(0)]
	public class DollGrabEndlessStartView : UiViewBase
	{
		// Token: 0x06044D49 RID: 281929 RVA: 0x011E9132 File Offset: 0x011E7332
		public DollGrabEndlessStartView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06044D4A RID: 281930 RVA: 0x011E913C File Offset: 0x011E733C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnMaskButtonClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06044D4B RID: 281931 RVA: 0x011E9245 File Offset: 0x011E7445
		protected override void OnStart()
		{
			this.GenericLayout = new GenericLayout<DollGrabEndlessStartItem, IGrabItemData>(base.GetHorizontalLayout(1), new Func<DollGrabEndlessStartItem>(this.CreateDollGrabEndlessStartItem), null, false, true);
			this.TxtDescri = base.GetText(3);
			this.PnlScroll = base.GetItem(4);
		}

		// Token: 0x06044D4C RID: 281932 RVA: 0x011E9284 File Offset: 0x011E7484
		protected override UniTask OnBeforeShowAsyncImplementImplement()
		{
			DollGrabEndlessStartView.<OnBeforeShowAsyncImplementImplement>d__6 <OnBeforeShowAsyncImplementImplement>d__;
			<OnBeforeShowAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeShowAsyncImplementImplement>d__.<>4__this = this;
			<OnBeforeShowAsyncImplementImplement>d__.<>1__state = -1;
			<OnBeforeShowAsyncImplementImplement>d__.<>t__builder.Start<DollGrabEndlessStartView.<OnBeforeShowAsyncImplementImplement>d__6>(ref <OnBeforeShowAsyncImplementImplement>d__);
			return <OnBeforeShowAsyncImplementImplement>d__.<>t__builder.Task;
		}

		// Token: 0x06044D4D RID: 281933 RVA: 0x011E92C7 File Offset: 0x011E74C7
		private DollGrabEndlessStartItem CreateDollGrabEndlessStartItem()
		{
			return new DollGrabEndlessStartItem();
		}

		// Token: 0x06044D4E RID: 281934 RVA: 0x011E92CE File Offset: 0x011E74CE
		private void OnMaskButtonClick()
		{
			ControllerBase<DollGrabMachineController>.Instance.OnClickStart();
			base.CloseMe(null);
		}

		// Token: 0x0402657B RID: 157051
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<DollGrabEndlessStartItem, IGrabItemData> GenericLayout;

		// Token: 0x0402657C RID: 157052
		[Nullable(2)]
		private UUIText TxtDescri;

		// Token: 0x0402657D RID: 157053
		[Nullable(2)]
		private UUIItem PnlScroll;
	}
}
