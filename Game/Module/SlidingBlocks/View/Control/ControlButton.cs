using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.BattleUi.Views;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.SlidingBlocks.View.Control
{
	// Token: 0x02004F1A RID: 20250
	public class ControlButton : UiPanelBase
	{
		// Token: 0x06034559 RID: 214361 RVA: 0x00D18E14 File Offset: 0x00D17014
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUINiagara));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603455A RID: 214362 RVA: 0x00D18E80 File Offset: 0x00D17080
		protected override UniTask OnBeforeStartAsync()
		{
			ControlButton.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<ControlButton.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603455B RID: 214363 RVA: 0x00D18EC3 File Offset: 0x00D170C3
		public void PlayClickEffect()
		{
			BattleUiNiagaraItem clickEffect = this.ClickEffect;
			if (clickEffect == null)
			{
				return;
			}
			clickEffect.Play();
		}

		// Token: 0x0401E2F4 RID: 123636
		[Nullable(2)]
		public UUIButtonComponent Button;

		// Token: 0x0401E2F5 RID: 123637
		[Nullable(2)]
		protected BattleUiNiagaraItem ClickEffect;

		// Token: 0x0200AF62 RID: 44898
		private enum EViewComponent
		{
			// Token: 0x040366DB RID: 222939
			SkillButton = 5,
			// Token: 0x040366DC RID: 222940
			ClickEffectNiagara = 10
		}
	}
}
