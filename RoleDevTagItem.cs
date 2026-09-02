using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002804 RID: 10244
public class RoleDevTagItem : UiPanelBase
{
	// Token: 0x06014392 RID: 82834 RVA: 0x005A1D48 File Offset: 0x0059FF48
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06014393 RID: 82835 RVA: 0x005A1DB4 File Offset: 0x0059FFB4
	public void SetData(ERoleTypeTag typeTag)
	{
		string textStringId;
		switch (typeTag)
		{
		case ERoleTypeTag.Forecast:
			textStringId = "RoleProject_Prospect";
			break;
		case ERoleTypeTag.Rerun:
			textStringId = "RoleProject_Review";
			break;
		case ERoleTypeTag.Summon:
			textStringId = "RoleProject_Popular";
			break;
		default:
			base.SetUiActive(false);
			return;
		}
		base.SetUiActive(true);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textStringId, Array.Empty<object>());
	}

	// Token: 0x02008B96 RID: 35734
	private enum EComponent
	{
		// Token: 0x0402F0B3 RID: 192691
		TexBg,
		// Token: 0x0402F0B4 RID: 192692
		TxtTagState
	}
}
