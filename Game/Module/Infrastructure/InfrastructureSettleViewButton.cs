using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Infrastructure
{
	// Token: 0x02005C57 RID: 23639
	[NullableContext(1)]
	[Nullable(0)]
	public class InfrastructureSettleViewButton : UiPanelBase
	{
		// Token: 0x0603BB8C RID: 244620 RVA: 0x00F21094 File Offset: 0x00F1F294
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
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
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickedButton));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603BB8D RID: 244621 RVA: 0x00F211A0 File Offset: 0x00F1F3A0
		protected override UniTask OnBeforeStartAsync()
		{
			InfrastructureSettleViewButton.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<InfrastructureSettleViewButton.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603BB8E RID: 244622 RVA: 0x00F211E4 File Offset: 0x00F1F3E4
		protected override void OnStart()
		{
			base.GetButton(4).RootUIComp.Get().SetUIActive(true);
			this.LeftButton.SetLocalTextNew("JijianTask_CompleteButton", Array.Empty<object>());
		}

		// Token: 0x0603BB8F RID: 244623 RVA: 0x00F21220 File Offset: 0x00F1F420
		private void OnClickedLeftButton(int _)
		{
			Action onClickLeftEvent = this.OnClickLeftEvent;
			if (onClickLeftEvent == null)
			{
				return;
			}
			onClickLeftEvent();
		}

		// Token: 0x0603BB90 RID: 244624 RVA: 0x00F21232 File Offset: 0x00F1F432
		private void OnClickedButton()
		{
			Action onClickEvent = this.OnClickEvent;
			if (onClickEvent == null)
			{
				return;
			}
			onClickEvent();
		}

		// Token: 0x0603BB91 RID: 244625 RVA: 0x00F21244 File Offset: 0x00F1F444
		public void SetBtnText(string textId, params string[] args)
		{
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(0), textId, args);
		}

		// Token: 0x0603BB92 RID: 244626 RVA: 0x00F21259 File Offset: 0x00F1F459
		public void HideFloatText()
		{
			base.GetText(2).SetUIActive(false);
		}

		// Token: 0x0603BB93 RID: 244627 RVA: 0x00F21268 File Offset: 0x00F1F468
		public void SetOnClickEvent(Action onClickEvent)
		{
			this.OnClickEvent = onClickEvent;
		}

		// Token: 0x0603BB94 RID: 244628 RVA: 0x00F21271 File Offset: 0x00F1F471
		public void SetOnClickLeftEvent(Action onClickLeftEvent)
		{
			this.OnClickLeftEvent = onClickLeftEvent;
		}

		// Token: 0x0402192A RID: 137514
		private Action OnClickEvent;

		// Token: 0x0402192B RID: 137515
		private Action OnClickLeftEvent;

		// Token: 0x0402192C RID: 137516
		private ButtonItem LeftButton = new ButtonItem(null);

		// Token: 0x0200BCD3 RID: 48339
		[NullableContext(0)]
		private class ESimpleButtonChildType
		{
			// Token: 0x0403A2CA RID: 238282
			public const int ButtonText = 0;

			// Token: 0x0403A2CB RID: 238283
			public const int DescriptionItem = 1;

			// Token: 0x0403A2CC RID: 238284
			public const int DescriptionText = 2;

			// Token: 0x0403A2CD RID: 238285
			public const int Button = 3;

			// Token: 0x0403A2CE RID: 238286
			public const int LeftButton = 4;
		}
	}
}
