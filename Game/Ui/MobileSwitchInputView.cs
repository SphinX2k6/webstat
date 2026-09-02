using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A2C RID: 18988
	public class MobileSwitchInputView : UiViewBase
	{
		// Token: 0x060319F2 RID: 203250 RVA: 0x00C5CF82 File Offset: 0x00C5B182
		[NullableContext(1)]
		public MobileSwitchInputView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x060319F3 RID: 203251 RVA: 0x00C5CF8C File Offset: 0x00C5B18C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060319F4 RID: 203252 RVA: 0x00C5CFF8 File Offset: 0x00C5B1F8
		protected override void OnStart()
		{
			bool flag = (bool)this.OpenParam;
			UUIItem item = base.GetItem(0);
			if (item != null)
			{
				item.SetUIActive(!flag);
			}
			UUIItem item2 = base.GetItem(1);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(flag);
		}

		// Token: 0x060319F5 RID: 203253 RVA: 0x00C5D039 File Offset: 0x00C5B239
		protected override void OnAfterPlayStartSequence()
		{
			base.CloseMe(new Action<bool>(Singleton<MobileSwitchInputController>.Instance.ReOpenBattleView));
		}

		// Token: 0x0200AA92 RID: 43666
		private class EComponentDefine
		{
			// Token: 0x04034C4A RID: 216138
			public const int MobileTex = 0;

			// Token: 0x04034C4B RID: 216139
			public const int GamepadTex = 1;
		}
	}
}
