using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x02001AD0 RID: 6864
public class DangoAbyssAttributeTitleItem : UiPanelBase
{
	// Token: 0x0600C591 RID: 50577 RVA: 0x00342F47 File Offset: 0x00341147
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUISprite))
		};
	}

	// Token: 0x0600C592 RID: 50578 RVA: 0x00342F80 File Offset: 0x00341180
	[NullableContext(1)]
	public void Initialize(UUIItem uiItem)
	{
		base.CreateByActorAsync(uiItem.GetOwner(), null, false).Forget();
	}

	// Token: 0x0600C593 RID: 50579 RVA: 0x00342F98 File Offset: 0x00341198
	[NullableContext(1)]
	public void Refresh(DangoAbyssDefine.EquipViewAttributeData data)
	{
		UUIText text = base.GetText(0);
		UUISprite sprite = base.GetSprite(1);
		string textStringId = data.IsValid ? "Text_AttributeValid_Text" : "Text_AttributeNotValid_Text";
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, textStringId, Array.Empty<object>());
		UUIItem uuiitem = text;
		bool bUseChangeColor = !data.IsValid;
		FColor? fcolor = new FColor?(text.changeColor);
		uuiitem.SetChangeColor(bUseChangeColor, fcolor);
		UUIItem uuiitem2 = sprite;
		bool bUseChangeColor2 = !data.IsValid;
		fcolor = new FColor?(sprite.changeColor);
		uuiitem2.SetChangeColor(bUseChangeColor2, fcolor);
		base.SetUiActive(true);
	}

	// Token: 0x02007DA2 RID: 32162
	private enum ETitleItemComponent
	{
		// Token: 0x0402ACA4 RID: 175268
		TextTitle,
		// Token: 0x0402ACA5 RID: 175269
		SpriteTitle
	}
}
