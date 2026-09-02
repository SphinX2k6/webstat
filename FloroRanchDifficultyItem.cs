using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001C58 RID: 7256
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class FloroRanchDifficultyItem : GridProxyAbstract<FloroRanchSubDungeonData>
{
	// Token: 0x0600D3BA RID: 54202 RVA: 0x00386C08 File Offset: 0x00384E08
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D3BB RID: 54203 RVA: 0x00386D14 File Offset: 0x00384F14
	public override void Refresh(FloroRanchSubDungeonData data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		EFloroRanchDifficulty difficulty = (EFloroRanchDifficulty)data.Difficulty;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), FloroRanchDefine.FloroRanchDifficultyTextId[difficulty], Array.Empty<object>());
		UUISprite sprite = base.GetSprite(3);
		if (sprite != null)
		{
			sprite.SetUIActive(!data.IsUnLock);
		}
		UUISprite sprite2 = base.GetSprite(2);
		if (sprite2 != null)
		{
			sprite2.SetUIActive(data.IsFinished);
		}
		UUIItem item = base.GetItem(4);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(data.HasRedDot);
	}

	// Token: 0x0600D3BC RID: 54204 RVA: 0x00386D9A File Offset: 0x00384F9A
	private void OnClickToggle(EToggleState toggleState)
	{
		if (this.OnToggleCallBack != null)
		{
			this.OnToggleCallBack(this.Data);
		}
	}

	// Token: 0x0600D3BD RID: 54205 RVA: 0x00386DB5 File Offset: 0x00384FB5
	public void SetToggleCallBack(Action<FloroRanchSubDungeonData> callBack)
	{
		this.OnToggleCallBack = callBack;
	}

	// Token: 0x0600D3BE RID: 54206 RVA: 0x00386DC0 File Offset: 0x00384FC0
	public void SetToggleState(bool state)
	{
		EToggleState state2 = state ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		base.GetExtendToggle(0).SetToggleState(state2, false, false, false);
	}

	// Token: 0x0600D3BF RID: 54207 RVA: 0x00386DE6 File Offset: 0x00384FE6
	public override object GetKey(FloroRanchSubDungeonData data, int displayIndex)
	{
		return data.Id;
	}

	// Token: 0x0600D3C0 RID: 54208 RVA: 0x00386DF3 File Offset: 0x00384FF3
	public override void OnSelected(bool fireEvent)
	{
		this.SetToggleState(true);
		UUIItem item = base.GetItem(4);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		if (this.Data.HasRedDot)
		{
			ControllerBase<FloroRanchController>.Instance.RequestSubDungeonRead(this.Data.Id);
		}
	}

	// Token: 0x0600D3C1 RID: 54209 RVA: 0x00386E31 File Offset: 0x00385031
	public override void OnDeselected(bool fireEvent)
	{
		this.SetToggleState(false);
	}

	// Token: 0x040064C4 RID: 25796
	private FloroRanchSubDungeonData Data;

	// Token: 0x040064C5 RID: 25797
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected Action<FloroRanchSubDungeonData> OnToggleCallBack;

	// Token: 0x02007F69 RID: 32617
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x0402B603 RID: 177667
		public const int ToggleRoot = 0;

		// Token: 0x0402B604 RID: 177668
		public const int TextTitle = 1;

		// Token: 0x0402B605 RID: 177669
		public const int SpriteFinished = 2;

		// Token: 0x0402B606 RID: 177670
		public const int SpriteLock = 3;

		// Token: 0x0402B607 RID: 177671
		public const int ItemRedDot = 4;
	}
}
