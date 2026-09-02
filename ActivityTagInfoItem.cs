using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001EB5 RID: 7861
internal class ActivityTagInfoItem : UiPanelBase
{
	// Token: 0x0600E883 RID: 59523 RVA: 0x003EDFB4 File Offset: 0x003EC1B4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600E884 RID: 59524 RVA: 0x003EE040 File Offset: 0x003EC240
	public void SetView(ActivityTitleTags data)
	{
		base.GetSprite(0).SetUIActive(!string.IsNullOrEmpty(data.DescInTip));
		base.GetText(1).SetUIActive(!string.IsNullOrEmpty(data.DescInTip));
		base.GetText(2).SetUIActive(!string.IsNullOrEmpty(data.DescInTip));
		if (string.IsNullOrEmpty(data.DescInTip))
		{
			return;
		}
		this.SetSpriteByPath(data.TogIcon, base.GetSprite(0), false, null, null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), data.TagName, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), data.DescInTip, Array.Empty<object>());
	}

	// Token: 0x020081FB RID: 33275
	private enum EItemComponents
	{
		// Token: 0x0402C183 RID: 180611
		SprIcon,
		// Token: 0x0402C184 RID: 180612
		TxtTitle,
		// Token: 0x0402C185 RID: 180613
		TxtContent
	}
}
