using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu.KeySettingsView
{
	// Token: 0x020057BB RID: 22459
	public class ChangeActionRowView : UiPanelBase
	{
		// Token: 0x0603917E RID: 233854 RVA: 0x00E784AC File Offset: 0x00E766AC
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnExtendToggleStateChanged))
			};
		}

		// Token: 0x0603917F RID: 233855 RVA: 0x00E78529 File Offset: 0x00E76729
		protected override void OnBeforeDestroy()
		{
			this.KeySettingRowData = null;
		}

		// Token: 0x06039180 RID: 233856 RVA: 0x00E78532 File Offset: 0x00E76732
		private void OnExtendToggleStateChanged(EToggleState state)
		{
			if (state != EToggleState.ETT_Checked)
			{
				return;
			}
			Action<ChangeActionRowView, bool> onSelectedCallback = this.OnSelectedCallback;
			if (onSelectedCallback == null)
			{
				return;
			}
			onSelectedCallback(this, this.IsRevert);
		}

		// Token: 0x06039181 RID: 233857 RVA: 0x00E78550 File Offset: 0x00E76750
		[NullableContext(1)]
		public void Refresh(KeySettingRowData keySettingRowData, EInputControllerType inputControllerType, bool bRevert)
		{
			this.KeySettingRowData = keySettingRowData;
			this.IsRevert = bRevert;
			List<string> list = this.KeySettingRowData.GetDisplayKeyName(inputControllerType) ?? new List<string>();
			string text = list[0];
			string text2 = list[1];
			string settingName = this.KeySettingRowData.GetSettingName();
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), settingName, Array.Empty<object>());
			string[] array2;
			if (!bRevert)
			{
				string[] array = new string[2];
				array[0] = text;
				array2 = array;
				array[1] = text2;
			}
			else
			{
				string[] array3 = new string[2];
				array3[0] = text2;
				array2 = array3;
				array3[1] = text;
			}
			string[] source = array2;
			string keyNameRichTextByKeyNameList = this.KeySettingRowData.GetKeyNameRichTextByKeyNameList(inputControllerType, source.ToList<string>(), "/");
			UUIText text3 = base.GetText(2);
			if (text3 == null)
			{
				return;
			}
			text3.SetText(keyNameRichTextByKeyNameList, true);
		}

		// Token: 0x06039182 RID: 233858 RVA: 0x00E78601 File Offset: 0x00E76801
		[NullableContext(1)]
		public void BindOnSelected(Action<ChangeActionRowView, bool> onSelected)
		{
			this.OnSelectedCallback = onSelected;
		}

		// Token: 0x06039183 RID: 233859 RVA: 0x00E7860A File Offset: 0x00E7680A
		public void SetSelected(bool bSelected)
		{
			if (bSelected)
			{
				UUIExtendToggle extendToggle = base.GetExtendToggle(0);
				if (extendToggle == null)
				{
					return;
				}
				extendToggle.SetToggleState(EToggleState.ETT_Checked, false, false, false);
				return;
			}
			else
			{
				UUIExtendToggle extendToggle2 = base.GetExtendToggle(0);
				if (extendToggle2 == null)
				{
					return;
				}
				extendToggle2.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
				return;
			}
		}

		// Token: 0x04020805 RID: 133125
		[Nullable(2)]
		private KeySettingRowData KeySettingRowData;

		// Token: 0x04020806 RID: 133126
		public bool IsRevert;

		// Token: 0x04020807 RID: 133127
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<ChangeActionRowView, bool> OnSelectedCallback;

		// Token: 0x0200B83C RID: 47164
		public class EChildType
		{
			// Token: 0x04038FC8 RID: 233416
			public const int ExtendToggle = 0;

			// Token: 0x04038FC9 RID: 233417
			public const int ActionNameText = 1;

			// Token: 0x04038FCA RID: 233418
			public const int ActionKeyText = 2;
		}
	}
}
