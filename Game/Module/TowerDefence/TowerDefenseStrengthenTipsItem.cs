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
	// Token: 0x02004EDB RID: 20187
	public class TowerDefenseStrengthenTipsItem : UiPanelBase
	{
		// Token: 0x06034244 RID: 213572 RVA: 0x00D0982C File Offset: 0x00D07A2C
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

		// Token: 0x06034245 RID: 213573 RVA: 0x00D09874 File Offset: 0x00D07A74
		protected override void OnStart()
		{
			this.SequencePlayer = new UiSequencePlayer(this.RootItem);
		}

		// Token: 0x06034246 RID: 213574 RVA: 0x00D09887 File Offset: 0x00D07A87
		[NullableContext(1)]
		public void SetTextByKey(string textKey)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), textKey, Array.Empty<object>());
		}

		// Token: 0x06034247 RID: 213575 RVA: 0x00D098A0 File Offset: 0x00D07AA0
		public UniTask PlayStartSequenceAsync()
		{
			TowerDefenseStrengthenTipsItem.<PlayStartSequenceAsync>d__5 <PlayStartSequenceAsync>d__;
			<PlayStartSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayStartSequenceAsync>d__.<>4__this = this;
			<PlayStartSequenceAsync>d__.<>1__state = -1;
			<PlayStartSequenceAsync>d__.<>t__builder.Start<TowerDefenseStrengthenTipsItem.<PlayStartSequenceAsync>d__5>(ref <PlayStartSequenceAsync>d__);
			return <PlayStartSequenceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06034248 RID: 213576 RVA: 0x00D098E4 File Offset: 0x00D07AE4
		public UniTask PlayCloseSequenceAsync()
		{
			TowerDefenseStrengthenTipsItem.<PlayCloseSequenceAsync>d__6 <PlayCloseSequenceAsync>d__;
			<PlayCloseSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayCloseSequenceAsync>d__.<>4__this = this;
			<PlayCloseSequenceAsync>d__.<>1__state = -1;
			<PlayCloseSequenceAsync>d__.<>t__builder.Start<TowerDefenseStrengthenTipsItem.<PlayCloseSequenceAsync>d__6>(ref <PlayCloseSequenceAsync>d__);
			return <PlayCloseSequenceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0401E1BB RID: 123323
		[Nullable(2)]
		private UiSequencePlayer SequencePlayer;

		// Token: 0x0200AE8B RID: 44683
		private class EItemComponent
		{
			// Token: 0x0403631B RID: 221979
			public const int TipsText = 0;
		}
	}
}
