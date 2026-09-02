using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Battle
{
	// Token: 0x02005F28 RID: 24360
	[NullableContext(1)]
	[Nullable(0)]
	public class FlagChallengeSettleButton : UiPanelBase
	{
		// Token: 0x0603D2CE RID: 250574 RVA: 0x00F8BED8 File Offset: 0x00F8A0D8
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

		// Token: 0x0603D2CF RID: 250575 RVA: 0x00F8BFC0 File Offset: 0x00F8A1C0
		protected override void OnBeforeShow()
		{
			base.GetText(0).SetText(string.Empty, true);
			base.GetText(2).SetText(string.Empty, true);
		}

		// Token: 0x0603D2D0 RID: 250576 RVA: 0x00F8BFE8 File Offset: 0x00F8A1E8
		public UniTask InitializeAsync(AActor rootActor, Action onClickCall)
		{
			FlagChallengeSettleButton.<InitializeAsync>d__4 <InitializeAsync>d__;
			<InitializeAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitializeAsync>d__.<>4__this = this;
			<InitializeAsync>d__.rootActor = rootActor;
			<InitializeAsync>d__.onClickCall = onClickCall;
			<InitializeAsync>d__.<>1__state = -1;
			<InitializeAsync>d__.<>t__builder.Start<FlagChallengeSettleButton.<InitializeAsync>d__4>(ref <InitializeAsync>d__);
			return <InitializeAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603D2D1 RID: 250577 RVA: 0x00F8C03B File Offset: 0x00F8A23B
		private void OnClickedButton()
		{
			Action onClickEvent = this.OnClickEvent;
			if (onClickEvent == null)
			{
				return;
			}
			onClickEvent();
		}

		// Token: 0x0603D2D2 RID: 250578 RVA: 0x00F8C04D File Offset: 0x00F8A24D
		public void SetFloatText(string textId, params object[] args)
		{
			base.GetText(2).SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(2), textId, args);
		}

		// Token: 0x0603D2D3 RID: 250579 RVA: 0x00F8C06F File Offset: 0x00F8A26F
		public void SetBtnTextNew(string textId, params object[] args)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), textId, args);
		}

		// Token: 0x040224E0 RID: 140512
		[Nullable(2)]
		private Action OnClickEvent;

		// Token: 0x0200BF37 RID: 48951
		[NullableContext(0)]
		private enum ESettleButtonType
		{
			// Token: 0x0403ADB9 RID: 241081
			ButtonText,
			// Token: 0x0403ADBA RID: 241082
			DescriptionItem,
			// Token: 0x0403ADBB RID: 241083
			DescriptionText,
			// Token: 0x0403ADBC RID: 241084
			Button
		}
	}
}
