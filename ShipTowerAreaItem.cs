using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020029A4 RID: 10660
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class ShipTowerAreaItem : GridProxyAbstract<ShipTowerAreaItemData>
{
	// Token: 0x06015409 RID: 87049 RVA: 0x005E3E08 File Offset: 0x005E2008
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUISprite)),
			new ValueTuple<int, Type>(5, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggleRoot))
		};
	}

	// Token: 0x0601540A RID: 87050 RVA: 0x005E3EC8 File Offset: 0x005E20C8
	protected override UniTask OnBeforeStartAsync()
	{
		ShipTowerAreaItem.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ShipTowerAreaItem.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601540B RID: 87051 RVA: 0x005E3F0B File Offset: 0x005E210B
	protected override void OnStart()
	{
		this.GetToggleRoot().bLockStateOnSelect = true;
	}

	// Token: 0x0601540C RID: 87052 RVA: 0x005E3F1C File Offset: 0x005E211C
	public override void Refresh(ShipTowerAreaItemData data, bool isSelected, int gridIndex)
	{
		this.ItemData = data;
		UUIText text = base.GetText(1);
		if (text != null)
		{
			text.ShowTextNew(data.Name);
		}
		UUIText text2 = base.GetText(2);
		if (text2 != null)
		{
			text2.SetText(data.Desc, true);
		}
		UUIText text3 = base.GetText(3);
		if (text3 != null)
		{
			text3.SetText(data.TimeContent ?? "", true);
		}
		UUISprite sprite = base.GetSprite(4);
		if (sprite != null)
		{
			sprite.SetUIActive(data.IsFinish.GetValueOrDefault());
		}
		UUIItem item = base.GetItem(5);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(data.IsRedPoint.GetValueOrDefault());
	}

	// Token: 0x0601540D RID: 87053 RVA: 0x005E3FBC File Offset: 0x005E21BC
	private void OnClickToggleRoot(EToggleState check)
	{
		if (check == EToggleState.ETT_Checked)
		{
			IScrollViewDelegate<IGridProxy<ShipTowerAreaItemData>, ShipTowerAreaItemData> scrollViewDelegate = base.ScrollViewDelegate;
			if (scrollViewDelegate == null)
			{
				return;
			}
			scrollViewDelegate.SelectGridProxy(base.GridIndex, base.DisplayIndex, false);
		}
	}

	// Token: 0x0601540E RID: 87054 RVA: 0x005E3FDF File Offset: 0x005E21DF
	public override void OnSelected(bool fireEvent)
	{
		this.GetToggleRoot().SetToggleState(EToggleState.ETT_Checked, false, false, false);
		Action<ShipTowerAreaItemData> clickCallBack = this.ClickCallBack;
		if (clickCallBack == null)
		{
			return;
		}
		clickCallBack(this.ItemData);
	}

	// Token: 0x0601540F RID: 87055 RVA: 0x005E4007 File Offset: 0x005E2207
	public override void OnDeselected(bool fireEvent)
	{
		this.GetToggleRoot().SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x06015410 RID: 87056 RVA: 0x005E4019 File Offset: 0x005E2219
	private UUIExtendToggle GetToggleRoot()
	{
		return base.GetExtendToggle(0);
	}

	// Token: 0x0400A3E7 RID: 41959
	private ShipTowerAreaItemData ItemData;

	// Token: 0x0400A3E8 RID: 41960
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<ShipTowerAreaItemData> ClickCallBack;

	// Token: 0x02008CEC RID: 36076
	[NullableContext(0)]
	private static class EChildType
	{
		// Token: 0x0402F683 RID: 194179
		public const int ToggleRoot = 0;

		// Token: 0x0402F684 RID: 194180
		public const int TextName = 1;

		// Token: 0x0402F685 RID: 194181
		public const int TextDesc = 2;

		// Token: 0x0402F686 RID: 194182
		public const int TextTimeContent = 3;

		// Token: 0x0402F687 RID: 194183
		public const int SpriteFinish = 4;

		// Token: 0x0402F688 RID: 194184
		public const int ItemRedPoint = 5;
	}
}
