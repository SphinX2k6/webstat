using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.InstanceDungeon
{
	// Token: 0x02005BAC RID: 23468
	public class DifficultUnlockTipView : UiViewBase
	{
		// Token: 0x0603B5F3 RID: 243187 RVA: 0x00F0A04A File Offset: 0x00F0824A
		[NullableContext(1)]
		public DifficultUnlockTipView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603B5F4 RID: 243188 RVA: 0x00F0A054 File Offset: 0x00F08254
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

		// Token: 0x0603B5F5 RID: 243189 RVA: 0x00F0A09C File Offset: 0x00F0829C
		protected override void OnBeforeShow()
		{
			DifficultUnlockTipsData data = this.OpenParam as DifficultUnlockTipsData;
			this.Refresh(data);
		}

		// Token: 0x0603B5F6 RID: 243190 RVA: 0x00F0A0BC File Offset: 0x00F082BC
		[NullableContext(1)]
		private void Refresh(DifficultUnlockTipsData data)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), data.Text, data.Params);
		}

		// Token: 0x0603B5F7 RID: 243191 RVA: 0x00F0A0DB File Offset: 0x00F082DB
		protected override void OnAfterPlayStartSequence()
		{
			base.CloseMe(null);
		}

		// Token: 0x0200BBE3 RID: 48099
		private class EComponents
		{
			// Token: 0x04039F82 RID: 237442
			public const int UnLockText = 0;
		}
	}
}
