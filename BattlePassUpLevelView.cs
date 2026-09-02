using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002390 RID: 9104
public class BattlePassUpLevelView : UiViewBase
{
	// Token: 0x06011728 RID: 71464 RVA: 0x004CF088 File Offset: 0x004CD288
	[NullableContext(1)]
	public BattlePassUpLevelView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06011729 RID: 71465 RVA: 0x004CF094 File Offset: 0x004CD294
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0601172A RID: 71466 RVA: 0x004CF100 File Offset: 0x004CD300
	protected override void OnStart()
	{
		int battlePassLevel = ModelBase<BattlePassModel>.Instance.BattlePassLevel;
		int increasedLevelToShow = ModelBase<BattlePassModel>.Instance.IncreasedLevelToShow;
		ModelBase<BattlePassModel>.Instance.IncreasedLevelToShow = 0;
		base.GetText(1).SetText(battlePassLevel.ToString(), true);
		base.GetText(0).SetText((battlePassLevel - increasedLevelToShow).ToString(), true);
		TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
		{
			Singleton<UiManager>.Instance.CloseView(this.ViewInfo.Name, null);
		}, 2000f, null, null, true, 1f);
	}

	// Token: 0x0601172B RID: 71467 RVA: 0x004CF17E File Offset: 0x004CD37E
	protected override void OnAfterHide()
	{
		if (((IBattlePassUpLevelViewData)this.OpenParam).FirstUnlockPass)
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.BattlePassFirstUnlockAnime);
		}
	}

	// Token: 0x020086AE RID: 34478
	private enum EBpUpgradeComponents
	{
		// Token: 0x0402D8D6 RID: 186582
		PreLevel,
		// Token: 0x0402D8D7 RID: 186583
		NowLevel
	}
}
