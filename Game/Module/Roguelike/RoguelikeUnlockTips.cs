using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x020051BA RID: 20922
	public class RoguelikeUnlockTips : UiViewBase
	{
		// Token: 0x06035CAB RID: 220331 RVA: 0x00D879BF File Offset: 0x00D85BBF
		[NullableContext(1)]
		public RoguelikeUnlockTips(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06035CAC RID: 220332 RVA: 0x00D879C8 File Offset: 0x00D85BC8
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

		// Token: 0x06035CAD RID: 220333 RVA: 0x00D87A10 File Offset: 0x00D85C10
		protected override void OnBeforeShow()
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "LordGymUnLock", new <>z__ReadOnlySingleElementList<object>(this.OpenParam as string));
		}

		// Token: 0x06035CAE RID: 220334 RVA: 0x00D87A38 File Offset: 0x00D85C38
		protected override void OnAfterPlayStartSequence()
		{
			base.CloseMe(null);
		}

		// Token: 0x0200B19E RID: 45470
		private class EComponents
		{
			// Token: 0x0403714F RID: 225615
			public const int UnLockText = 0;
		}
	}
}
