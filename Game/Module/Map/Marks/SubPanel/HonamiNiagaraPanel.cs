using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.SubPanel
{
	// Token: 0x02005834 RID: 22580
	public class HonamiNiagaraPanel : UiPanelBase
	{
		// Token: 0x06039670 RID: 235120 RVA: 0x00E92D2C File Offset: 0x00E90F2C
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

		// Token: 0x06039671 RID: 235121 RVA: 0x00E92D74 File Offset: 0x00E90F74
		[NullableContext(1)]
		public UniTask SetNiagaraAndShow(string resourceId, [Nullable(2)] string audioEvent = null)
		{
			HonamiNiagaraPanel.<SetNiagaraAndShow>d__2 <SetNiagaraAndShow>d__;
			<SetNiagaraAndShow>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SetNiagaraAndShow>d__.<>4__this = this;
			<SetNiagaraAndShow>d__.resourceId = resourceId;
			<SetNiagaraAndShow>d__.audioEvent = audioEvent;
			<SetNiagaraAndShow>d__.<>1__state = -1;
			<SetNiagaraAndShow>d__.<>t__builder.Start<HonamiNiagaraPanel.<SetNiagaraAndShow>d__2>(ref <SetNiagaraAndShow>d__);
			return <SetNiagaraAndShow>d__.<>t__builder.Task;
		}

		// Token: 0x0200B8A6 RID: 47270
		private enum EChildComponents
		{
			// Token: 0x0403916D RID: 233837
			Niagara
		}
	}
}
