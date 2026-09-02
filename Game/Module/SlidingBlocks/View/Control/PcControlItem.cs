using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.SlidingBlocks.View.Control
{
	// Token: 0x02004F1D RID: 20253
	public class PcControlItem : ControlItem
	{
		// Token: 0x06034572 RID: 214386 RVA: 0x00D19458 File Offset: 0x00D17658
		protected unsafe override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(2, typeof(UUIButtonComponent))
			};
			int num = 3;
			List<ValueTuple<int, Delegate>> list = new List<ValueTuple<int, Delegate>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list, num);
			Span<ValueTuple<int, Delegate>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Delegate>(0, new Action(this.OnClimbBtnClick));
			num2++;
			*span[num2] = new ValueTuple<int, Delegate>(1, new Action(this.OnRotateBtnClick));
			num2++;
			*span[num2] = new ValueTuple<int, Delegate>(2, new Action(this.OnFallDownBtnClick));
			this.BtnBindInfo = list;
		}

		// Token: 0x06034573 RID: 214387 RVA: 0x00D19538 File Offset: 0x00D17738
		protected override UniTask OnBeforeStartAsync()
		{
			PcControlItem.<OnBeforeStartAsync>d__2 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PcControlItem.<OnBeforeStartAsync>d__2>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06034574 RID: 214388 RVA: 0x00D1957B File Offset: 0x00D1777B
		protected override void OnClimbBtnClick()
		{
			base.OnClimbBtnClick();
		}

		// Token: 0x06034575 RID: 214389 RVA: 0x00D19583 File Offset: 0x00D17783
		protected override void OnRotateBtnClick()
		{
			base.OnRotateBtnClick();
		}

		// Token: 0x06034576 RID: 214390 RVA: 0x00D1958B File Offset: 0x00D1778B
		protected override void OnFallDownBtnClick()
		{
			base.OnFallDownBtnClick();
		}

		// Token: 0x0200AF6A RID: 44906
		private class EViewComponent
		{
			// Token: 0x040366FD RID: 222973
			public const int ClimbBtn = 0;

			// Token: 0x040366FE RID: 222974
			public const int RotateBtn = 1;

			// Token: 0x040366FF RID: 222975
			public const int FallDownBtn = 2;
		}
	}
}
