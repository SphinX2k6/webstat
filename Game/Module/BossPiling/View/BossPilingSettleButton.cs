using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BossPiling.View
{
	// Token: 0x02005EFB RID: 24315
	[NullableContext(1)]
	[Nullable(0)]
	public class BossPilingSettleButton : UiPanelBase
	{
		// Token: 0x0603D15F RID: 250207 RVA: 0x00F83BEC File Offset: 0x00F81DEC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickedButton));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603D160 RID: 250208 RVA: 0x00F83CD4 File Offset: 0x00F81ED4
		protected override void OnBeforeShow()
		{
			base.GetText(0).SetText("", true);
			base.GetText(2).SetText("", true);
		}

		// Token: 0x0603D161 RID: 250209 RVA: 0x00F83CFC File Offset: 0x00F81EFC
		public UniTask InitializeAsync(AActor rootActor, Action onClickCall)
		{
			BossPilingSettleButton.<InitializeAsync>d__4 <InitializeAsync>d__;
			<InitializeAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitializeAsync>d__.<>4__this = this;
			<InitializeAsync>d__.rootActor = rootActor;
			<InitializeAsync>d__.onClickCall = onClickCall;
			<InitializeAsync>d__.<>1__state = -1;
			<InitializeAsync>d__.<>t__builder.Start<BossPilingSettleButton.<InitializeAsync>d__4>(ref <InitializeAsync>d__);
			return <InitializeAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603D162 RID: 250210 RVA: 0x00F83D4F File Offset: 0x00F81F4F
		private void OnClickedButton()
		{
			Action onClickEvent = this.OnClickEvent;
			if (onClickEvent == null)
			{
				return;
			}
			onClickEvent();
		}

		// Token: 0x0603D163 RID: 250211 RVA: 0x00F83D61 File Offset: 0x00F81F61
		public void SetFloatText(string textId, params string[] args)
		{
			base.GetText(2).SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), textId, args);
		}

		// Token: 0x0603D164 RID: 250212 RVA: 0x00F83D83 File Offset: 0x00F81F83
		public void SetBtnTextNew(string textId, params string[] args)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), textId, args);
		}

		// Token: 0x0402243A RID: 140346
		[Nullable(2)]
		private Action OnClickEvent;

		// Token: 0x0200BEFB RID: 48891
		[NullableContext(0)]
		private enum EBossPilingButton
		{
			// Token: 0x0403AC75 RID: 240757
			ButtonText,
			// Token: 0x0403AC76 RID: 240758
			DescriptionItem,
			// Token: 0x0403AC77 RID: 240759
			DescriptionText,
			// Token: 0x0403AC78 RID: 240760
			Button
		}
	}
}
