using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x02001757 RID: 5975
public class NewSoundSuitDropDownTitle : TitleItemBase<int>
{
	// Token: 0x0600A7FC RID: 43004 RVA: 0x002CBC60 File Offset: 0x002C9E60
	[NullableContext(1)]
	public NewSoundSuitDropDownTitle(UUIItem uiItem) : base(uiItem)
	{
	}

	// Token: 0x0600A7FD RID: 43005 RVA: 0x002CBC6C File Offset: 0x002C9E6C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600A7FE RID: 43006 RVA: 0x002CBCD8 File Offset: 0x002C9ED8
	[NullableContext(1)]
	public override void ShowTemp(int data, DropDownItemBase<int> selectedItemObj)
	{
		if (this.VisionFetterSuitItem == null)
		{
			this.VisionFetterSuitItem = new VisionFetterSuitItem(base.GetItem(1));
			this.VisionFetterSuitItem.Init().ContinueWith(delegate()
			{
			});
		}
		string newText;
		if (data > 0)
		{
			newText = (ConfigMultiTextLang.GetLocalTextNew(ConfigBase<PhantomBattleConfig>.Instance.GetFetterGroupById(data).FetterGroupName, null) ?? "");
		}
		else
		{
			newText = (ConfigMultiTextLang.GetLocalTextNew("Text_FilterTextAllVisionFetter_Text", null) ?? "");
		}
		base.GetText(0).SetText(newText, true);
		PhantomFetterGroup? fetterGroupData = (data > 0) ? new PhantomFetterGroup?(ConfigBase<PhantomBattleConfig>.Instance.GetFetterGroupById(data)) : null;
		this.VisionFetterSuitItem.Update(fetterGroupData);
		this.VisionFetterSuitItem.SetActive(true);
	}

	// Token: 0x0600A7FF RID: 43007 RVA: 0x002CBDBC File Offset: 0x002C9FBC
	protected override void OnBeforeDestroy()
	{
		VisionFetterSuitItem visionFetterSuitItem = this.VisionFetterSuitItem;
		if (visionFetterSuitItem == null)
		{
			return;
		}
		visionFetterSuitItem.Destroy(null);
	}

	// Token: 0x04004F42 RID: 20290
	[Nullable(2)]
	private VisionFetterSuitItem VisionFetterSuitItem;

	// Token: 0x02007ABC RID: 31420
	private enum EComponent
	{
		// Token: 0x0402A0B2 RID: 172210
		TxtOption,
		// Token: 0x0402A0B3 RID: 172211
		SuitElementItem
	}
}
