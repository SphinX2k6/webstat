using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.KeySetting
{
	// Token: 0x02005AF8 RID: 23288
	[NullableContext(2)]
	public interface IKeySettingItem
	{
		// Token: 0x0603AE5A RID: 241242
		[NullableContext(1)]
		UUIText GetTitleUiText();

		// Token: 0x0603AE5B RID: 241243
		[NullableContext(1)]
		UUIExtendToggle GetKeySetToggle();

		// Token: 0x0603AE5C RID: 241244
		[NullableContext(1)]
		UUIText GetKeyNameUiText();

		// Token: 0x0603AE5D RID: 241245
		[NullableContext(1)]
		UUIItem GetCursorItem();

		// Token: 0x0603AE5E RID: 241246 RVA: 0x00EEFE08 File Offset: 0x00EEE008
		UUIItem GetDetailUiItem()
		{
			return null;
		}

		// Token: 0x0603AE5F RID: 241247 RVA: 0x00EEFE0B File Offset: 0x00EEE00B
		UUIText GetDetailUiText()
		{
			return null;
		}

		// Token: 0x0603AE60 RID: 241248 RVA: 0x00EEFE0E File Offset: 0x00EEE00E
		UUISprite GetDetailSprite()
		{
			return null;
		}

		// Token: 0x0603AE61 RID: 241249 RVA: 0x00EEFE11 File Offset: 0x00EEE011
		UUISprite GetLockSprite()
		{
			return null;
		}

		// Token: 0x0603AE62 RID: 241250 RVA: 0x00EEFE14 File Offset: 0x00EEE014
		UUISprite GetSelectSprite()
		{
			return null;
		}

		// Token: 0x0603AE63 RID: 241251 RVA: 0x00EEFE17 File Offset: 0x00EEE017
		UUIButtonComponent GetCancelButton()
		{
			return null;
		}
	}
}
