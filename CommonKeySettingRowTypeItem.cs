using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Menu;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200208E RID: 8334
public class CommonKeySettingRowTypeItem : UiPanelBase
{
	// Token: 0x0600FE4C RID: 65100 RVA: 0x0045C0A8 File Offset: 0x0045A2A8
	protected unsafe override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent))
		};
		int num = 1;
		List<ValueTuple<int, Delegate>> list = new List<ValueTuple<int, Delegate>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list, num);
		Span<ValueTuple<int, Delegate>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickHelpBtn));
		this.BtnBindInfo = list;
	}

	// Token: 0x0600FE4D RID: 65101 RVA: 0x0045C140 File Offset: 0x0045A340
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
		}
		else
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, keyTypeName, Array.Empty<object>());
			text.SetUIActive(true);
		}
		if (keySettingRowData.HelpBtnCallBack != null)
		{
			this.HelpBtnCallBack = keySettingRowData.HelpBtnCallBack;
			base.GetButton(2).RootUIComp.Get().SetUIActive(true);
			return;
		}
		base.GetButton(2).RootUIComp.Get().SetUIActive(false);
	}

	// Token: 0x0600FE4E RID: 65102 RVA: 0x0045C217 File Offset: 0x0045A417
	private void OnClickHelpBtn()
	{
		Action helpBtnCallBack = this.HelpBtnCallBack;
		if (helpBtnCallBack == null)
		{
			return;
		}
		helpBtnCallBack();
	}

	// Token: 0x040079DE RID: 31198
	[Nullable(2)]
	private Action HelpBtnCallBack;

	// Token: 0x0200841E RID: 33822
	private static class EChildType
	{
		// Token: 0x0402CC68 RID: 183400
		public const int TypeSprite = 0;

		// Token: 0x0402CC69 RID: 183401
		public const int TypeNameText = 1;

		// Token: 0x0402CC6A RID: 183402
		public const int HelpBtn = 2;
	}
}
