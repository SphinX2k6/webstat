using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200120D RID: 4621
public class DeTermDailyQuestItem : UiPanelBase
{
	// Token: 0x06007A4B RID: 31307 RVA: 0x001FDB48 File Offset: 0x001FBD48
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06007A4C RID: 31308 RVA: 0x001FDBB1 File Offset: 0x001FBDB1
	protected override void OnStart()
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "ScratchCard_TaskType_01", Array.Empty<object>());
	}

	// Token: 0x02007555 RID: 30037
	private class EDeTermDailyQuestItem
	{
		// Token: 0x040287CA RID: 165834
		public const int BgSprite = 0;

		// Token: 0x040287CB RID: 165835
		public const int Text = 1;
	}
}
