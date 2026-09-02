using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu.KeySettingsView
{
	// Token: 0x020057CA RID: 22474
	public class KeySettingRowTypeItem : UiPanelBase
	{
		// Token: 0x060391FC RID: 233980 RVA: 0x00E7A35A File Offset: 0x00E7855A
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUISprite)),
				new ValueTuple<int, Type>(1, typeof(UUIText))
			};
		}

		// Token: 0x060391FD RID: 233981 RVA: 0x00E7A394 File Offset: 0x00E78594
		[NullableContext(1)]
		public void Refresh(KeySettingRowData keySettingRowData)
		{
			if (keySettingRowData.GetRowType() != EKeySettingRowType.KeyType)
			{
				return;
			}
			string keyTypeIconSpritePath = keySettingRowData.KeyTypeIconSpritePath;
			UUISprite sprite = base.GetSprite(0);
			UUIText text = base.GetText(1);
			if (StringUtils.IsEmpty(keyTypeIconSpritePath))
			{
				sprite.SetUIActive(false);
			}
			else
			{
				this.SetSpriteByPath(keySettingRowData.KeyTypeIconSpritePath, sprite, false, null, null);
				sprite.SetUIActive(true);
			}
			string keyTypeName = keySettingRowData.KeyTypeName;
			if (StringUtils.IsEmpty(keyTypeName))
			{
				text.SetUIActive(false);
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, keyTypeName, Array.Empty<object>());
			text.SetUIActive(true);
		}

		// Token: 0x0200B84E RID: 47182
		public class EChildType
		{
			// Token: 0x04039014 RID: 233492
			public const int TypeSprite = 0;

			// Token: 0x04039015 RID: 233493
			public const int TypeNameText = 1;
		}
	}
}
