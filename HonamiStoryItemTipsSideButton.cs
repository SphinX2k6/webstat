using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001F14 RID: 7956
public class HonamiStoryItemTipsSideButton : UiPanelBase
{
	// Token: 0x0600EDD0 RID: 60880 RVA: 0x0040EA94 File Offset: 0x0040CC94
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnClicked))
		};
	}

	// Token: 0x0600EDD1 RID: 60881 RVA: 0x0040EB14 File Offset: 0x0040CD14
	[NullableContext(1)]
	public void SetSpriteByResourceId(string resourceId)
	{
		UiResourceConfig instance = ConfigBase<UiResourceConfig>.Instance;
		string path = ((instance != null) ? instance.GetResourcePath(resourceId) : null) ?? string.Empty;
		this.SetSpriteByPath(path, base.GetSprite(1), false, null, null);
	}

	// Token: 0x0600EDD2 RID: 60882 RVA: 0x0040EB56 File Offset: 0x0040CD56
	[NullableContext(1)]
	public void SetLocalTextNew(string key)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), key, Array.Empty<object>());
	}

	// Token: 0x0600EDD3 RID: 60883 RVA: 0x0040EB6F File Offset: 0x0040CD6F
	private void OnClicked()
	{
		Action onClickedCb = this.OnClickedCb;
		if (onClickedCb == null)
		{
			return;
		}
		onClickedCb();
	}

	// Token: 0x0400723E RID: 29246
	[Nullable(2)]
	public Action OnClickedCb;

	// Token: 0x02008279 RID: 33401
	private enum EBtn
	{
		// Token: 0x0402C412 RID: 181266
		Btn,
		// Token: 0x0402C413 RID: 181267
		Sprite,
		// Token: 0x0402C414 RID: 181268
		Txt
	}
}
