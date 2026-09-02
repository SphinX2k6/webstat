using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorFight
{
	// Token: 0x020066EC RID: 26348
	public class MotorFightItemTips : UiViewBase
	{
		// Token: 0x06041C54 RID: 269396 RVA: 0x010DEEC4 File Offset: 0x010DD0C4
		[NullableContext(1)]
		public MotorFightItemTips(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06041C55 RID: 269397 RVA: 0x010DEED0 File Offset: 0x010DD0D0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickBtnClose));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06041C56 RID: 269398 RVA: 0x010DEF78 File Offset: 0x010DD178
		protected override UniTask OnBeforeStartAsync()
		{
			MotorFightItemTips.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MotorFightItemTips.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041C57 RID: 269399 RVA: 0x010DEFBB File Offset: 0x010DD1BB
		private void OnClickBtnClose()
		{
			base.CloseMe(null);
		}

		// Token: 0x04024B16 RID: 150294
		[Nullable(2)]
		protected MotorFightItemDetailPanel CollectionItem;

		// Token: 0x04024B17 RID: 150295
		[Nullable(2)]
		protected MotorFightItemData Data;

		// Token: 0x0200C72C RID: 50988
		private class EComponentDefine
		{
			// Token: 0x0403D50B RID: 251147
			public const int ButtonClose = 0;

			// Token: 0x0403D50C RID: 251148
			public const int ItemTopCollection = 1;
		}
	}
}
