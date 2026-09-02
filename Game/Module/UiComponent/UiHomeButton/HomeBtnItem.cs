using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiComponent.UiHomeButton
{
	// Token: 0x02004D8A RID: 19850
	public class HomeBtnItem : UiPanelBase
	{
		// Token: 0x06033655 RID: 210517 RVA: 0x00CDAE80 File Offset: 0x00CD9080
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISpriteTransition));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnButtonClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06033656 RID: 210518 RVA: 0x00CDAF28 File Offset: 0x00CD9128
		protected override UniTask OnBeforeStartAsync()
		{
			HomeBtnItem.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<HomeBtnItem.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06033657 RID: 210519 RVA: 0x00CDAF6B File Offset: 0x00CD916B
		[NullableContext(1)]
		public void SetFunction(Action callback)
		{
			this.CallBack = callback;
		}

		// Token: 0x06033658 RID: 210520 RVA: 0x00CDAF74 File Offset: 0x00CD9174
		private void OnButtonClick()
		{
			Action callBack = this.CallBack;
			if (callBack == null)
			{
				return;
			}
			callBack();
		}

		// Token: 0x06033659 RID: 210521 RVA: 0x00CDAF86 File Offset: 0x00CD9186
		public void SetHomeBtnStyle(int id)
		{
			this.HomeBtnStyle = new int?(id);
		}

		// Token: 0x0603365A RID: 210522 RVA: 0x00CDAF94 File Offset: 0x00CD9194
		public void SetSnapSize(bool snap)
		{
			this.SnapSize = snap;
		}

		// Token: 0x0401DC8E RID: 121998
		[Nullable(2)]
		private Action CallBack;

		// Token: 0x0401DC8F RID: 121999
		private int? HomeBtnStyle;

		// Token: 0x0401DC90 RID: 122000
		private bool SnapSize;

		// Token: 0x0200AD69 RID: 44393
		private enum EComponent
		{
			// Token: 0x04035DDB RID: 220635
			Btn,
			// Token: 0x04035DDC RID: 220636
			Img
		}
	}
}
