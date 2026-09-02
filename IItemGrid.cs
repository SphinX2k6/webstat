using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Inventory;
using UnrealEngine;

// Token: 0x02001969 RID: 6505
[NullableContext(1)]
public interface IItemGrid
{
	// Token: 0x17000F25 RID: 3877
	// (get) Token: 0x0600BADC RID: 47836
	bool IsItemGrid { get; }

	// Token: 0x0600BADD RID: 47837
	void RefreshQualitySprite();

	// Token: 0x0600BADE RID: 47838
	void RefreshTextureIcon();

	// Token: 0x0600BADF RID: 47839
	void RefreshTextDown(bool showState, string text);

	// Token: 0x0600BAE0 RID: 47840
	void SetToggleClickEvent(Action<int, ItemConfig> call);

	// Token: 0x0600BAE1 RID: 47841
	void SetToggleClickStateEvent(Action<EToggleState> call);

	// Token: 0x0600BAE2 RID: 47842
	[NullableContext(2)]
	UUIExtendToggle GetClickToggle();

	// Token: 0x0600BAE3 RID: 47843
	[NullableContext(2)]
	UUIText GetDownText();

	// Token: 0x0600BAE4 RID: 47844
	void BindRedPointWithKeyAndId(ERedDotName name, int uid);

	// Token: 0x0600BAE5 RID: 47845
	void RefreshCdPanel(bool showState, float cdFillAmount, string cdText);

	// Token: 0x0600BAE6 RID: 47846
	void RefreshDarkSprite(bool showState);

	// Token: 0x0600BAE7 RID: 47847
	void RefreshLockSprite(bool showState);
}
