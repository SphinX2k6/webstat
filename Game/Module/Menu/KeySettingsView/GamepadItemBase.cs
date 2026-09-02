using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu.KeySettingsView
{
	// Token: 0x020057C2 RID: 22466
	[NullableContext(1)]
	[Nullable(0)]
	public class GamepadItemBase : UiPanelBase
	{
		// Token: 0x060391AC RID: 233900 RVA: 0x00E7900C File Offset: 0x00E7720C
		protected void AddKeySprite(string keyName, UUISprite keySprite)
		{
			this.KeySpriteMap.Add(keyName, keySprite);
		}

		// Token: 0x060391AD RID: 233901 RVA: 0x00E7901C File Offset: 0x00E7721C
		public void SetKeysEnable(string[] keyNameList)
		{
			foreach (KeyValuePair<string, UUISprite> keyValuePair in this.VisibleKeySpriteMap)
			{
				string key = keyValuePair.Key;
				UUISprite value = keyValuePair.Value;
				if (Array.IndexOf<string>(keyNameList, key) < 0)
				{
					value.SetUIActive(false);
				}
			}
			foreach (string keyName in keyNameList)
			{
				this.SetKeySpriteVisible(keyName, true);
			}
		}

		// Token: 0x060391AE RID: 233902 RVA: 0x00E790B0 File Offset: 0x00E772B0
		public void SetAllKeyDisable()
		{
			foreach (UUISprite uuisprite in this.VisibleKeySpriteMap.Values)
			{
				uuisprite.SetUIActive(false);
			}
		}

		// Token: 0x060391AF RID: 233903 RVA: 0x00E79108 File Offset: 0x00E77308
		public void SetKeySpriteVisible(string keyName, bool bVisible)
		{
			UUISprite uuisprite;
			if (!this.KeySpriteMap.TryGetValue(keyName, out uuisprite))
			{
				return;
			}
			uuisprite.SetUIActive(bVisible);
			if (bVisible)
			{
				this.VisibleKeySpriteMap[keyName] = uuisprite;
				return;
			}
			this.VisibleKeySpriteMap.Remove(keyName);
		}

		// Token: 0x060391B0 RID: 233904 RVA: 0x00E7914B File Offset: 0x00E7734B
		protected override void OnBeforeDestroy()
		{
			this.KeySpriteMap.Clear();
			this.VisibleKeySpriteMap.Clear();
		}

		// Token: 0x04020822 RID: 133154
		private readonly Dictionary<string, UUISprite> KeySpriteMap = new Dictionary<string, UUISprite>();

		// Token: 0x04020823 RID: 133155
		private readonly Dictionary<string, UUISprite> VisibleKeySpriteMap = new Dictionary<string, UUISprite>();
	}
}
