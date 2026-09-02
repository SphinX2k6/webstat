using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.AdventureGuide;
using UnrealEngine;

// Token: 0x0200174E RID: 5966
[Nullable(new byte[]
{
	0,
	1
})]
public class NewSoundDetectPreOpenTitleItem : SyncGridProxyAbstract<NewSoundDetectTabItemData>
{
	// Token: 0x0600A7D5 RID: 42965 RVA: 0x002CAD9C File Offset: 0x002C8F9C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		this.ComponentRegisterInfos = list;
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleStateChange))
		};
	}

	// Token: 0x0600A7D6 RID: 42966 RVA: 0x002CAE08 File Offset: 0x002C9008
	[NullableContext(1)]
	public override void Refresh(NewSoundDetectTabItemData data)
	{
		this.Area = data.Area;
		this.IsVisible = data.IsVisible;
		EToggleState state = data.IsVisible ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleState(state, false, false, false);
	}

	// Token: 0x0600A7D7 RID: 42967 RVA: 0x002CAE50 File Offset: 0x002C9050
	private void OnToggleStateChange(EToggleState state)
	{
		if (this.OnClickCallBack != null)
		{
			this.OnClickCallBack(this.Area, !this.IsVisible);
		}
	}

	// Token: 0x04004F3B RID: 20283
	private int Area;

	// Token: 0x04004F3C RID: 20284
	private bool IsVisible;

	// Token: 0x04004F3D RID: 20285
	[Nullable(2)]
	public Action<int, bool> OnClickCallBack;

	// Token: 0x02007AB4 RID: 31412
	private enum ENewSoundDetectPreOpenTitleItem
	{
		// Token: 0x0402A08E RID: 172174
		Toggle
	}
}
