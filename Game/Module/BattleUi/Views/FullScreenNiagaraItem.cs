using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006014 RID: 24596
	public class FullScreenNiagaraItem : BattleChildView
	{
		// Token: 0x0603DFA5 RID: 253861 RVA: 0x00FD0C14 File Offset: 0x00FCEE14
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

		// Token: 0x0603DFA6 RID: 253862 RVA: 0x00FD0C5C File Offset: 0x00FCEE5C
		public override void Reset()
		{
			UUINiagara fullScreenNiagara = this.FullScreenNiagara;
			if (fullScreenNiagara != null)
			{
				fullScreenNiagara.SetNiagaraSystem(null);
			}
			this.NiagaraPath = null;
			this.FullScreenNiagara = null;
			base.Reset();
		}

		// Token: 0x0603DFA7 RID: 253863 RVA: 0x00FD0C84 File Offset: 0x00FCEE84
		public UniTask<bool> LoadNiagara([Nullable(2)] string niagaraPath)
		{
			FullScreenNiagaraItem.<LoadNiagara>d__5 <LoadNiagara>d__;
			<LoadNiagara>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<LoadNiagara>d__.<>4__this = this;
			<LoadNiagara>d__.niagaraPath = niagaraPath;
			<LoadNiagara>d__.<>1__state = -1;
			<LoadNiagara>d__.<>t__builder.Start<FullScreenNiagaraItem.<LoadNiagara>d__5>(ref <LoadNiagara>d__);
			return <LoadNiagara>d__.<>t__builder.Task;
		}

		// Token: 0x0603DFA8 RID: 253864 RVA: 0x00FD0CCF File Offset: 0x00FCEECF
		[NullableContext(1)]
		public void SetNiagaraFloatValue(string key, float value)
		{
			UUINiagara fullScreenNiagara = this.FullScreenNiagara;
			if (fullScreenNiagara == null)
			{
				return;
			}
			fullScreenNiagara.SetNiagaraVarFloat(key, value);
		}

		// Token: 0x0603DFA9 RID: 253865 RVA: 0x00FD0CE4 File Offset: 0x00FCEEE4
		public void SetVisible(bool bVisible)
		{
			UUINiagara uiNiagara = base.GetUiNiagara(0);
			if (bVisible)
			{
				uiNiagara.ActivateSystem(true);
			}
			else
			{
				this.FullScreenNiagara.SetNiagaraSystem(null);
				this.FullScreenNiagara.DeactivateSystem();
			}
			this.SetActive(bVisible);
		}

		// Token: 0x04022C2A RID: 142378
		[Nullable(2)]
		private string NiagaraPath;

		// Token: 0x04022C2B RID: 142379
		[Nullable(2)]
		private UUINiagara FullScreenNiagara;

		// Token: 0x0200C0B7 RID: 49335
		private enum EChildType
		{
			// Token: 0x0403B559 RID: 243033
			PoisonScreenNiagara
		}
	}
}
