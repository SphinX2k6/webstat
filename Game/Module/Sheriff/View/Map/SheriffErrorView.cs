using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Sheriff.View.Map
{
	// Token: 0x02004FDC RID: 20444
	public class SheriffErrorView : UiViewBase
	{
		// Token: 0x06034B63 RID: 215907 RVA: 0x00D3840C File Offset: 0x00D3660C
		[NullableContext(1)]
		public SheriffErrorView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06034B64 RID: 215908 RVA: 0x00D38418 File Offset: 0x00D36618
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickBtnClose));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06034B65 RID: 215909 RVA: 0x00D3849D File Offset: 0x00D3669D
		private void OnClickBtnClose()
		{
			this.HandleClose().Forget();
		}

		// Token: 0x06034B66 RID: 215910 RVA: 0x00D384AC File Offset: 0x00D366AC
		private UniTask HandleClose()
		{
			SheriffErrorView.<HandleClose>d__4 <HandleClose>d__;
			<HandleClose>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<HandleClose>d__.<>1__state = -1;
			<HandleClose>d__.<>t__builder.Start<SheriffErrorView.<HandleClose>d__4>(ref <HandleClose>d__);
			return <HandleClose>d__.<>t__builder.Task;
		}

		// Token: 0x0200AFAD RID: 44973
		private static class EComponent
		{
			// Token: 0x0403683D RID: 223293
			public const int BtnClose = 0;
		}
	}
}
