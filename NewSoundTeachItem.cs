using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.AdventureGuide;
using CSharpScript.Game.Module.AdventureGuide.Views;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001759 RID: 5977
public class NewSoundTeachItem : UiPanelBase, INewSoundItem
{
	// Token: 0x0600A804 RID: 43012 RVA: 0x002CBF20 File Offset: 0x002CA120
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600A805 RID: 43013 RVA: 0x002CBF8C File Offset: 0x002CA18C
	[NullableContext(1)]
	public void Update(NewSoundDetectItemData sourceData)
	{
		SoundAreaDetectionRecord detectRecordData = sourceData.DetectRecordData;
		UUIText text = base.GetText(0);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, detectRecordData.Name, Array.Empty<object>());
		UUITexture texture = base.GetTexture(1);
		base.SetTextureShowUntilLoaded(detectRecordData.BigIcon, texture, null);
	}

	// Token: 0x02007ABF RID: 31423
	private enum EChildType
	{
		// Token: 0x0402A0BA RID: 172218
		NameText,
		// Token: 0x0402A0BB RID: 172219
		IconTexture
	}
}
