using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002498 RID: 9368
[Nullable(new byte[]
{
	0,
	1
})]
public class VisionFetterDescItem : GridProxyAbstract<VisionFetterDescData>
{
	// Token: 0x060122DE RID: 74462 RVA: 0x00500720 File Offset: 0x004FE920
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x060122DF RID: 74463 RVA: 0x0050078C File Offset: 0x004FE98C
	[NullableContext(1)]
	public override void Refresh(VisionFetterDescData data, bool isSelected, int gridIndex)
	{
		int value = data.Value;
		this.RefreshContent(value);
		this.RefreshName(value, data.Key);
	}

	// Token: 0x060122E0 RID: 74464 RVA: 0x005007B4 File Offset: 0x004FE9B4
	private void RefreshName(int fetterId, int needNum)
	{
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew(ConfigBase<PhantomBattleConfig>.Instance.GetPhantomFetterById(fetterId).Name, null);
		UUIText text = base.GetText(0);
		if (text != null)
		{
			text.SetText(localTextNew ?? "", true);
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "VisionFetterDetailViewName", new <>z__ReadOnlyArray<object>(new object[]
		{
			localTextNew,
			needNum.ToString()
		}));
	}

	// Token: 0x060122E1 RID: 74465 RVA: 0x00500828 File Offset: 0x004FEA28
	private void RefreshContent(int fetterId)
	{
		PhantomFetter phantomFetterById = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomFetterById(fetterId);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), phantomFetterById.EffectDescription, phantomFetterById.EffectDescriptionParam());
	}

	// Token: 0x020087BA RID: 34746
	private class EVisionFetterDescItem
	{
		// Token: 0x0402DDFB RID: 187899
		public const int TitleText = 0;

		// Token: 0x0402DDFC RID: 187900
		public const int ContentTextOne = 1;
	}
}
