using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Sheriff.View
{
	// Token: 0x02004FD4 RID: 20436
	public class SheriffShowClueViewPop : UiViewBase
	{
		// Token: 0x06034B2A RID: 215850 RVA: 0x00D37453 File Offset: 0x00D35653
		[NullableContext(1)]
		public SheriffShowClueViewPop(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06034B2B RID: 215851 RVA: 0x00D3745C File Offset: 0x00D3565C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06034B2C RID: 215852 RVA: 0x00D37508 File Offset: 0x00D35708
		protected override UniTask OnBeforeStartAsync()
		{
			SheriffShowClueViewPop.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SheriffShowClueViewPop.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06034B2D RID: 215853 RVA: 0x00D3754B File Offset: 0x00D3574B
		private void OnClickedClose()
		{
			base.CloseMe(null);
		}

		// Token: 0x0401E604 RID: 124420
		[Nullable(1)]
		protected SheriffShowClueViewPanel DetailPanel;

		// Token: 0x0200AFA0 RID: 44960
		private static class EDefine
		{
			// Token: 0x0403680A RID: 223242
			public const int Caption = 0;

			// Token: 0x0403680B RID: 223243
			public const int Content = 1;

			// Token: 0x0403680C RID: 223244
			public const int BtnTips = 2;

			// Token: 0x0403680D RID: 223245
			public const int DialogItem = 3;
		}
	}
}
