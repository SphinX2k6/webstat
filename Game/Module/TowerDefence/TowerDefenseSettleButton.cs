using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004EE5 RID: 20197
	[NullableContext(1)]
	[Nullable(0)]
	public class TowerDefenseSettleButton : UiPanelBase
	{
		// Token: 0x060342A1 RID: 213665 RVA: 0x00D0B474 File Offset: 0x00D09674
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

		// Token: 0x060342A2 RID: 213666 RVA: 0x00D0B55C File Offset: 0x00D0975C
		public UniTask InitializeAsync(AActor rootActor, Action onClick)
		{
			TowerDefenseSettleButton.<InitializeAsync>d__2 <InitializeAsync>d__;
			<InitializeAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitializeAsync>d__.<>4__this = this;
			<InitializeAsync>d__.rootActor = rootActor;
			<InitializeAsync>d__.onClick = onClick;
			<InitializeAsync>d__.<>1__state = -1;
			<InitializeAsync>d__.<>t__builder.Start<TowerDefenseSettleButton.<InitializeAsync>d__2>(ref <InitializeAsync>d__);
			return <InitializeAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060342A3 RID: 213667 RVA: 0x00D0B5AF File Offset: 0x00D097AF
		public void SetBtnTextById(string textId, params string[] args)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), textId, args);
		}

		// Token: 0x060342A4 RID: 213668 RVA: 0x00D0B5C4 File Offset: 0x00D097C4
		public void SetFloatText(string textId, params string[] args)
		{
			base.GetText(2).SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), textId, args);
		}

		// Token: 0x060342A5 RID: 213669 RVA: 0x00D0B5E6 File Offset: 0x00D097E6
		private void OnClickedButton()
		{
			Action onClickEvent = this.OnClickEvent;
			if (onClickEvent == null)
			{
				return;
			}
			onClickEvent();
		}

		// Token: 0x0401E1D5 RID: 123349
		[Nullable(2)]
		private Action OnClickEvent;

		// Token: 0x0200AE9E RID: 44702
		[NullableContext(0)]
		private class ESettleButton
		{
			// Token: 0x0403636E RID: 222062
			public const int ButtonText = 0;

			// Token: 0x0403636F RID: 222063
			public const int DescriptionItem = 1;

			// Token: 0x04036370 RID: 222064
			public const int DescriptionText = 2;

			// Token: 0x04036371 RID: 222065
			public const int Button = 3;
		}
	}
}
