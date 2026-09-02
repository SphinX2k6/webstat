using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020025ED RID: 9709
public class PilotThrowAimItem : UiPanelBase
{
	// Token: 0x06013063 RID: 77923 RVA: 0x00545CE0 File Offset: 0x00543EE0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIText))
		};
	}

	// Token: 0x06013064 RID: 77924 RVA: 0x00545D3A File Offset: 0x00543F3A
	protected override void OnStart()
	{
		UUIItem item = base.GetItem(0);
		if (item != null)
		{
			item.SetUIActive(true);
		}
		UUIItem item2 = base.GetItem(1);
		if (item2 == null)
		{
			return;
		}
		item2.SetUIActive(false);
	}

	// Token: 0x06013065 RID: 77925 RVA: 0x00545D64 File Offset: 0x00543F64
	[NullableContext(2)]
	public void OnFocusTarget(string targetPointText)
	{
		if (string.IsNullOrEmpty(targetPointText))
		{
			UUIItem item = base.GetItem(0);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			UUIItem item2 = base.GetItem(1);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(false);
			return;
		}
		else
		{
			UUIItem item3 = base.GetItem(0);
			if (item3 != null)
			{
				item3.SetUIActive(false);
			}
			UUIItem item4 = base.GetItem(1);
			if (item4 != null)
			{
				item4.SetUIActive(true);
			}
			UUIText text = base.GetText(2);
			if (text == null)
			{
				return;
			}
			text.SetText(targetPointText, true);
			return;
		}
	}

	// Token: 0x0200897F RID: 35199
	private class EViewComponent
	{
		// Token: 0x0402E64A RID: 190026
		public const int NormalItem = 0;

		// Token: 0x0402E64B RID: 190027
		public const int AimItem = 1;

		// Token: 0x0402E64C RID: 190028
		public const int TargetNameText = 2;
	}
}
