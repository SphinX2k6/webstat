using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200108D RID: 4237
public class FurnitureGetWayButtonItem : UiPanelBase
{
	// Token: 0x06006E83 RID: 28291 RVA: 0x001CC6D0 File Offset: 0x001CA8D0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(2, new Action(this.OnClickJumpButton))
		};
	}

	// Token: 0x06006E84 RID: 28292 RVA: 0x001CC750 File Offset: 0x001CA950
	[NullableContext(1)]
	public void Refresh(IFurnitureGetWayButtonItemData data)
	{
		this.Data = data;
		if (this.Data.NameTextId != null)
		{
			if (this.Data.NameTextParams != null)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), this.Data.NameTextId, this.Data.NameTextParams);
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), this.Data.NameTextId, Array.Empty<object>());
		}
	}

	// Token: 0x06006E85 RID: 28293 RVA: 0x001CC7C7 File Offset: 0x001CA9C7
	private void OnClickJumpButton()
	{
		IFurnitureGetWayButtonItemData data = this.Data;
		if (data == null)
		{
			return;
		}
		Action jumpFunction = data.JumpFunction;
		if (jumpFunction == null)
		{
			return;
		}
		jumpFunction();
	}

	// Token: 0x040034AE RID: 13486
	[Nullable(2)]
	private IFurnitureGetWayButtonItemData Data;
}
