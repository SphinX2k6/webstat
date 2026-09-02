using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E51 RID: 20049
	public class TrapDefenseTalentLockItem : UiPanelBase
	{
		// Token: 0x06033D01 RID: 212225 RVA: 0x00CF4504 File Offset: 0x00CF2704
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06033D02 RID: 212226 RVA: 0x00CF456D File Offset: 0x00CF276D
		protected override void OnStart()
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), ETrapDefenseTextKey.TalentNodeNeedUnlockPre.ToString(), Array.Empty<object>());
		}

		// Token: 0x0200ADEE RID: 44526
		private class EComponentDefine
		{
			// Token: 0x0403602C RID: 221228
			public const int SpriteLock = 0;

			// Token: 0x0403602D RID: 221229
			public const int TextLock = 1;
		}
	}
}
