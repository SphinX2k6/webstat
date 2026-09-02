using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FCB RID: 24523
	public class BattleSkillExtraEffectRhythmItem : BattleSkillExtraEffectItem
	{
		// Token: 0x0603DAA0 RID: 252576 RVA: 0x00FB5C38 File Offset: 0x00FB3E38
		[NullableContext(1)]
		public override void Init(UUIItem rootUiItem)
		{
			base.CreateByResourceIdAsync("UiItem_FightBtnRhythm", rootUiItem, false).Forget();
		}

		// Token: 0x0603DAA1 RID: 252577 RVA: 0x00FB5C4C File Offset: 0x00FB3E4C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUINiagara));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603DAA2 RID: 252578 RVA: 0x00FB5C94 File Offset: 0x00FB3E94
		protected override void OnStart()
		{
			this.EffectItem = new BattleUiNiagaraItem(base.GetUiNiagara(0));
			if (this.ExtraEffectDuration > 0f)
			{
				this.EffectItem.Duration = this.ExtraEffectDuration * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
			}
			base.OnStart();
		}

		// Token: 0x0603DAA3 RID: 252579 RVA: 0x00FB5CE3 File Offset: 0x00FB3EE3
		protected override void OnRefresh()
		{
			BattleUiNiagaraItem effectItem = this.EffectItem;
			if (effectItem == null)
			{
				return;
			}
			effectItem.Play();
		}

		// Token: 0x0603DAA4 RID: 252580 RVA: 0x00FB5CF5 File Offset: 0x00FB3EF5
		public override void Stop()
		{
			BattleUiNiagaraItem effectItem = this.EffectItem;
			if (effectItem == null)
			{
				return;
			}
			effectItem.Stop();
		}

		// Token: 0x040229C1 RID: 141761
		[Nullable(2)]
		private BattleUiNiagaraItem EffectItem;

		// Token: 0x0200C038 RID: 49208
		private enum EChildType
		{
			// Token: 0x0403B2C0 RID: 242368
			Effect
		}
	}
}
