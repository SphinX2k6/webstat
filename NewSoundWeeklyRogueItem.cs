using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.AdventureGuide.Views;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001761 RID: 5985
public class NewSoundWeeklyRogueItem : UiPanelBase, INewSoundItem
{
	// Token: 0x0600A834 RID: 43060 RVA: 0x002CCCD8 File Offset: 0x002CAED8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600A835 RID: 43061 RVA: 0x002CCD84 File Offset: 0x002CAF84
	[NullableContext(1)]
	public void Update(NewSoundDetectItemData data)
	{
		RogueWeeklyCycle? cycleConfig = ModelBase<WeeklyRogueModel>.Instance.ActivityData.GetCycleConfig();
		int score = ModelBase<WeeklyRogueModel>.Instance.ActivityData.Score;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "PrefabTextItem_1382682910_Text", new <>z__ReadOnlyArray<object>(new object[]
		{
			score,
			cycleConfig.Value.MaxScore
		}));
	}

	// Token: 0x02007AC5 RID: 31429
	private enum EComponentsDefine
	{
		// Token: 0x0402A0D9 RID: 172249
		TxtName,
		// Token: 0x0402A0DA RID: 172250
		TextureIcon,
		// Token: 0x0402A0DB RID: 172251
		TxtTips,
		// Token: 0x0402A0DC RID: 172252
		SpriteIcon
	}
}
