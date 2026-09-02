using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.DollGrabMachine.View
{
	// Token: 0x02006EFB RID: 28411
	internal class DollGrabMachineHelpInfoCaptionPanel : UiPanelBase
	{
		// Token: 0x06044D8D RID: 281997 RVA: 0x011EA1B4 File Offset: 0x011E83B4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIHorizontalLayout));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnBackButtonClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06044D8E RID: 281998 RVA: 0x011EA320 File Offset: 0x011E8520
		protected override void OnBeforeCreate()
		{
			UUIButtonComponent button = base.GetButton(2);
			object obj;
			if (button == null)
			{
				obj = null;
			}
			else
			{
				AActor owner = button.GetOwner();
				obj = ((owner != null) ? owner.GetComponentByClass(UUIItem.StaticClass()) : null);
			}
			this.BtnHelpInfo = (obj as UUIItem);
			UUIItem btnHelpInfo = this.BtnHelpInfo;
			if (btnHelpInfo == null)
			{
				return;
			}
			btnHelpInfo.SetUIActive(false);
		}

		// Token: 0x06044D8F RID: 281999 RVA: 0x011EA372 File Offset: 0x011E8572
		private void OnBackButtonClick()
		{
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.DollGrabMachineHelpInfoView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.DollGrabMachineHelpInfoView, null);
			}
		}

		// Token: 0x040265B3 RID: 157107
		[Nullable(2)]
		private UUIItem BtnHelpInfo;
	}
}
