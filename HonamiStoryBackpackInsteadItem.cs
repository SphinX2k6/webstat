using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001F03 RID: 7939
public class HonamiStoryBackpackInsteadItem : UiPanelBase
{
	// Token: 0x0600ED00 RID: 60672 RVA: 0x00409AB4 File Offset: 0x00407CB4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickedCancel));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600ED01 RID: 60673 RVA: 0x00409B9C File Offset: 0x00407D9C
	protected override void OnStart()
	{
		UUIText text = base.GetText(3);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "HonamiStory_ChooseSlot", Array.Empty<object>());
	}

	// Token: 0x0600ED02 RID: 60674 RVA: 0x00409BC8 File Offset: 0x00407DC8
	public void SetVisible(bool isVisible)
	{
		base.SetUiActive(isVisible);
		if (isVisible)
		{
			HonamiStoryItemDataBase insteadItem = ModelBase<HonamiStoryModel>.Instance.GetBackpackLogic().GetInsteadItem();
			this.SetSpriteByPath(insteadItem.GetQualityConfig().Value.GridBg, base.GetSprite(1), false, null, null);
			base.SetTextureByPath(insteadItem.GetIconTexture(), base.GetTexture(2), null, null);
		}
	}

	// Token: 0x0600ED03 RID: 60675 RVA: 0x00409C3C File Offset: 0x00407E3C
	private void OnClickedCancel()
	{
		HonamiStoryBackpackLogicController backpackLogic = ModelBase<HonamiStoryModel>.Instance.GetBackpackLogic();
		if (backpackLogic == null)
		{
			return;
		}
		backpackLogic.SetLogicState(EHonamiStoryBackpackLogicState.Normal, null, null);
	}

	// Token: 0x0200825B RID: 33371
	private enum EReplace
	{
		// Token: 0x0402C373 RID: 181107
		BtnCancel,
		// Token: 0x0402C374 RID: 181108
		SpriteBg,
		// Token: 0x0402C375 RID: 181109
		Icon,
		// Token: 0x0402C376 RID: 181110
		TxtTips
	}
}
