using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x02005933 RID: 22835
	public class GridEventChoiceFinish : UiPanelBase
	{
		// Token: 0x06039F09 RID: 237321 RVA: 0x00EAA4E4 File Offset: 0x00EA86E4
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUISprite)),
				new ValueTuple<int, Type>(2, typeof(UUIExtendToggleSpriteTransition)),
				new ValueTuple<int, Type>(3, typeof(UUIItem))
			};
		}

		// Token: 0x06039F0A RID: 237322 RVA: 0x00EAA554 File Offset: 0x00EA8754
		[NullableContext(1)]
		public void Refresh(IToggleItemData data)
		{
			UUIText text = base.GetText(0);
			if (!StringUtils.IsEmpty(data.Icon))
			{
				UUISprite spriteIcon = base.GetSprite(1);
				this.SetSpriteByPath(data.Icon, spriteIcon, false, null, delegate(bool _)
				{
					this.GetUiExtendToggleSpriteTransition(2).SetAllStateSprite(spriteIcon.GetSprite());
				});
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, data.TitleId, Array.Empty<object>());
		}
	}
}
