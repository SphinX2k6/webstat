using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001234 RID: 4660
public class BabelTowerNewLevelTipsView : UiViewBase
{
	// Token: 0x06007C15 RID: 31765 RVA: 0x00209868 File Offset: 0x00207A68
	[NullableContext(1)]
	public BabelTowerNewLevelTipsView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06007C16 RID: 31766 RVA: 0x00209874 File Offset: 0x00207A74
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

	// Token: 0x06007C17 RID: 31767 RVA: 0x002098BC File Offset: 0x00207ABC
	protected override void OnStart()
	{
		int levelId = (int)this.OpenParam;
		ControllerBase<BabelTowerController>.Instance.SaveNewLevelData(levelId);
		UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
		if (uiViewSequence != null)
		{
			uiViewSequence.AddSequenceFinishEvent("Start", delegate(string _)
			{
				UiBehaviorLevelSequence uiViewSequence3 = this.UiViewSequence;
				if (uiViewSequence3 == null)
				{
					return;
				}
				uiViewSequence3.PlaySequence("Close", false, null);
			}, false);
		}
		UiBehaviorLevelSequence uiViewSequence2 = this.UiViewSequence;
		if (uiViewSequence2 == null)
		{
			return;
		}
		uiViewSequence2.AddSequenceFinishEvent("Close", delegate(string _)
		{
			base.CloseMe(null);
		}, false);
	}

	// Token: 0x0200759A RID: 30106
	private class EComponentDefine
	{
		// Token: 0x04028938 RID: 166200
		public const int TitleText = 0;
	}
}
