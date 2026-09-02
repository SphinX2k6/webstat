using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x0200122E RID: 4654
[Nullable(new byte[]
{
	0,
	1
})]
public class JumpToItem : GridProxyAbstract<IJumpToItemData>
{
	// Token: 0x06007BD4 RID: 31700 RVA: 0x0020790C File Offset: 0x00205B0C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06007BD5 RID: 31701 RVA: 0x00207A58 File Offset: 0x00205C58
	[NullableContext(1)]
	public override void Refresh(IJumpToItemData data, bool isSelected, int gridIndex)
	{
		this.LevelId = data.LevelId;
		BabelTowerLevel babelTowerLevelConfig = ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerLevelConfig(data.LevelId);
		this.IsUnlock = data.IsUnlock;
		base.GetItem(1).SetUIActive(data.Done);
		this.IsCurrentLevel = (data.LevelId == ModelBase<BabelTowerModel>.Instance.CurrentSelectLevel);
		if (this.IsCurrentLevel)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "BabelTowerCurrentLevel", Array.Empty<object>());
		}
		else
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), babelTowerLevelConfig.NameText, Array.Empty<object>());
		}
		base.GetItem(6).SetUIActive(!this.IsCurrentLevel);
		base.GetItem(5).SetUIActive(data.StarNumber > 0);
		base.GetText(4).SetText(data.StarNumber.ToString(), true);
	}

	// Token: 0x06007BD6 RID: 31702 RVA: 0x00207B3F File Offset: 0x00205D3F
	private void OnClickButton()
	{
		if (!this.IsUnlock)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("BabelTowerLevelUnlock", Array.Empty<object>());
			return;
		}
		if (this.IsCurrentLevel)
		{
			return;
		}
		Action<int> onClickButtonCallBack = this.OnClickButtonCallBack;
		if (onClickButtonCallBack == null)
		{
			return;
		}
		onClickButtonCallBack(this.LevelId);
	}

	// Token: 0x04003B40 RID: 15168
	private int LevelId;

	// Token: 0x04003B41 RID: 15169
	private bool IsUnlock;

	// Token: 0x04003B42 RID: 15170
	private bool IsCurrentLevel;

	// Token: 0x04003B43 RID: 15171
	[Nullable(2)]
	public Action<int> OnClickButtonCallBack;

	// Token: 0x02007594 RID: 30100
	private class EJumpToItem
	{
		// Token: 0x04028905 RID: 166149
		public const int BgItem = 0;

		// Token: 0x04028906 RID: 166150
		public const int DoneItem = 1;

		// Token: 0x04028907 RID: 166151
		public const int AreaText = 2;

		// Token: 0x04028908 RID: 166152
		public const int Button = 3;

		// Token: 0x04028909 RID: 166153
		public const int StarNumberText = 4;

		// Token: 0x0402890A RID: 166154
		public const int StarItem = 5;

		// Token: 0x0402890B RID: 166155
		public const int ArrowItem = 6;
	}
}
