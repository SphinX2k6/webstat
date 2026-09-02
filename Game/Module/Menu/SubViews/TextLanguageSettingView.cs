using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu.SubViews
{
	// Token: 0x02005791 RID: 22417
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class TextLanguageSettingView : LanguageSettingViewBase<TextLanguageToggle>
	{
		// Token: 0x06039052 RID: 233554 RVA: 0x00E72F98 File Offset: 0x00E71198
		public TextLanguageSettingView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06039053 RID: 233555 RVA: 0x00E72FA1 File Offset: 0x00E711A1
		[return: Nullable(2)]
		protected override TextLanguageToggle CreateToggle(UUIItem uiItem, int index, bool isToggled)
		{
			TextLanguageToggle textLanguageToggle = new TextLanguageToggle();
			textLanguageToggle.Initialize(uiItem, index, isToggled);
			return textLanguageToggle;
		}

		// Token: 0x06039054 RID: 233556 RVA: 0x00E72FB4 File Offset: 0x00E711B4
		protected override void OnRefreshView(TextLanguageToggle newToggle)
		{
			string mainText = this.MenuDataIns.OptionsNameList[newToggle.GetIndex()];
			newToggle.SetMainText(mainText);
		}

		// Token: 0x06039055 RID: 233557 RVA: 0x00E72FDF File Offset: 0x00E711DF
		protected override void OnSelected(TextLanguageToggle newToggle, EToggleState newToggleState)
		{
			newToggle.SetSpriteActive(true);
		}
	}
}
