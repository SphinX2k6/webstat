using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.InstanceDungeon.InstanceDungeonSubComponent
{
	// Token: 0x02005BE7 RID: 23527
	public class InstanceDungeonLockItem : UiPanelBase
	{
		// Token: 0x0603B8F7 RID: 243959 RVA: 0x00F19548 File Offset: 0x00F17748
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

		// Token: 0x0603B8F8 RID: 243960 RVA: 0x00F19590 File Offset: 0x00F17790
		[NullableContext(1)]
		public void RefreshItem(TableTextArgNew args)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), args.TextKey, args.Params);
		}

		// Token: 0x0603B8F9 RID: 243961 RVA: 0x00F195AF File Offset: 0x00F177AF
		[NullableContext(1)]
		public void SetLockText(string lockText)
		{
			base.GetText(0).SetText(lockText, true);
		}

		// Token: 0x0200BC60 RID: 48224
		private enum EChildType
		{
			// Token: 0x0403A169 RID: 237929
			TextLock
		}
	}
}
