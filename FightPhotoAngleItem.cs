using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.AutoAttach;
using UnrealEngine;

// Token: 0x020025BF RID: 9663
public class FightPhotoAngleItem : AutoAttachItem<int?>
{
	// Token: 0x06012E35 RID: 77365 RVA: 0x00539A70 File Offset: 0x00537C70
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
	}

	// Token: 0x06012E36 RID: 77366 RVA: 0x00539ACC File Offset: 0x00537CCC
	protected override void OnRefreshItem(int? angle)
	{
		if (angle == null)
		{
			UUIItem item = base.GetItem(0);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			UUIItem item2 = base.GetItem(1);
			if (item2 != null)
			{
				item2.SetUIActive(false);
			}
			UUIItem item3 = base.GetItem(2);
			if (item3 == null)
			{
				return;
			}
			item3.SetUIActive(false);
			return;
		}
		else
		{
			int? num = angle % 10;
			int num2 = 0;
			bool flag = num.GetValueOrDefault() == num2 & num != null;
			num = angle;
			num2 = 0;
			bool uiactive = num.GetValueOrDefault() == num2 & num != null;
			UUIItem item4 = base.GetItem(0);
			if (item4 != null)
			{
				item4.SetUIActive(!flag);
			}
			UUIItem item5 = base.GetItem(1);
			if (item5 != null)
			{
				item5.SetUIActive(flag);
			}
			UUIItem item6 = base.GetItem(2);
			if (item6 == null)
			{
				return;
			}
			item6.SetUIActive(uiactive);
			return;
		}
	}

	// Token: 0x06012E37 RID: 77367 RVA: 0x00539BAC File Offset: 0x00537DAC
	public override void OnSelect()
	{
		if (this.AllData != null && this.CurrentShowItemIndex >= 0 && this.CurrentShowItemIndex < this.AllData.Length)
		{
			int? num = this.AllData[this.CurrentShowItemIndex];
			if (num != null)
			{
				Action<int> onSelectCallback = this.OnSelectCallback;
				if (onSelectCallback == null)
				{
					return;
				}
				onSelectCallback(num.Value);
			}
		}
	}

	// Token: 0x06012E38 RID: 77368 RVA: 0x00539C0C File Offset: 0x00537E0C
	protected override void OnUnSelect()
	{
	}

	// Token: 0x06012E39 RID: 77369 RVA: 0x00539C0E File Offset: 0x00537E0E
	protected override void OnMoveItem()
	{
	}

	// Token: 0x06012E3A RID: 77370 RVA: 0x00539C10 File Offset: 0x00537E10
	public FightPhotoAngleItem() : base(null)
	{
	}

	// Token: 0x040093A1 RID: 37793
	[Nullable(2)]
	public Action<int> OnSelectCallback;

	// Token: 0x0200891D RID: 35101
	private enum EComponents
	{
		// Token: 0x0402E44C RID: 189516
		SpriteMarkShort,
		// Token: 0x0402E44D RID: 189517
		SpriteMarkLong,
		// Token: 0x0402E44E RID: 189518
		ItemMarkOriginPoint
	}
}
