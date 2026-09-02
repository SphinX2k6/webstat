using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001075 RID: 4213
[NullableContext(2)]
[Nullable(0)]
public class FurnitureAreaCameraSelectionItem : UiPanelBase
{
	// Token: 0x06006DA4 RID: 28068 RVA: 0x001C822C File Offset: 0x001C642C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(2, new Action(this.OnClickPreBtn)),
			new ValueTuple<int, Delegate>(4, new Action(this.OnClickNextBtn))
		};
	}

	// Token: 0x06006DA5 RID: 28069 RVA: 0x001C8303 File Offset: 0x001C6503
	[NullableContext(1)]
	public void Refresh(string name)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), name, Array.Empty<object>());
	}

	// Token: 0x06006DA6 RID: 28070 RVA: 0x001C831C File Offset: 0x001C651C
	private void OnClickPreBtn()
	{
		Action preBtnClickDelegate = this.PreBtnClickDelegate;
		if (preBtnClickDelegate == null)
		{
			return;
		}
		preBtnClickDelegate();
	}

	// Token: 0x06006DA7 RID: 28071 RVA: 0x001C832E File Offset: 0x001C652E
	private void OnClickNextBtn()
	{
		Action nextBtnClickDelegate = this.NextBtnClickDelegate;
		if (nextBtnClickDelegate == null)
		{
			return;
		}
		nextBtnClickDelegate();
	}

	// Token: 0x040033FD RID: 13309
	public Action PreBtnClickDelegate;

	// Token: 0x040033FE RID: 13310
	public Action NextBtnClickDelegate;
}
