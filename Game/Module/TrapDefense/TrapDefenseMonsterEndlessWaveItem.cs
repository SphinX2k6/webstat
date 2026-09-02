using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E3F RID: 20031
	public class TrapDefenseMonsterEndlessWaveItem : UiPanelBase
	{
		// Token: 0x06033C5E RID: 212062 RVA: 0x00CF1168 File Offset: 0x00CEF368
		[NullableContext(1)]
		public UniTask Init(UUIItem item)
		{
			TrapDefenseMonsterEndlessWaveItem.<Init>d__1 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.item = item;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<TrapDefenseMonsterEndlessWaveItem.<Init>d__1>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x06033C5F RID: 212063 RVA: 0x00CF11B4 File Offset: 0x00CEF3B4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06033C60 RID: 212064 RVA: 0x00CF11FC File Offset: 0x00CEF3FC
		[NullableContext(1)]
		public void UpdateDescKey(string descKey)
		{
			UUIText text = base.GetText(0);
			if (text == null)
			{
				return;
			}
			text.ShowTextNew(descKey);
		}

		// Token: 0x0200ADC9 RID: 44489
		private class EChildType
		{
			// Token: 0x04035F76 RID: 221046
			public const int TextContent = 0;
		}
	}
}
