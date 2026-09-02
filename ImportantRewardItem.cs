using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using UnrealEngine;

// Token: 0x020015B0 RID: 5552
public class ImportantRewardItem : SignRewardItemBase
{
	// Token: 0x06009C6A RID: 40042 RVA: 0x0028F520 File Offset: 0x0028D720
	protected unsafe override void OnRegisterComponent()
	{
		int num = 10;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(5, new Action<EToggleState>(base.OnClickToggle));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06009C6B RID: 40043 RVA: 0x0028F6D0 File Offset: 0x0028D8D0
	public void SetDayText(int day)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "DayNum", new <>z__ReadOnlySingleElementList<object>(day));
	}

	// Token: 0x06009C6C RID: 40044 RVA: 0x0028F6F3 File Offset: 0x0028D8F3
	[NullableContext(1)]
	public void SetStateText(string textId)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), textId, Array.Empty<object>());
	}

	// Token: 0x06009C6D RID: 40045 RVA: 0x0028F70C File Offset: 0x0028D90C
	public override void RefreshByData(OneItemConfig data, SignState state, int index)
	{
		this.Index = index;
		this.SetDayText(index + 1);
		this.SetStateText(base.GetRewardStateTextId(state));
		bool flag = state == SignState.IsReceive;
		bool flag2 = state == SignState.Unlock;
		this.CanGetReward = flag2;
		UUIText text = base.GetText(4);
		if (text != null)
		{
			UUIItem uuiitem = text;
			bool bUseChangeColor = state == SignState.Lock;
			FColor? fcolor = new FColor?(text.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
		}
		base.GetItem(6).SetUIActive(flag);
		base.GetItem(9).SetUIActive(!flag2 && !flag);
		base.GetSprite(7).SetUIActive(flag2);
		base.GetSprite(1).SetUIActive(flag2);
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(flag2 ? "SP_NewSignInBigItemBg_Reward" : "SP_NewSignInBigItemBg_Normal");
		this.SetSpriteByPath(resourcePath, base.GetSprite(0), false, null, null);
		base.GetItem(8).SetUIActive(flag2);
		if (!StringUtils.IsEmpty(this.BigIconPath))
		{
			base.SetTextureByPath(this.BigIconPath, base.GetTexture(2), null, null);
		}
	}

	// Token: 0x040047FA RID: 18426
	[Nullable(1)]
	public string BigIconPath = "";

	// Token: 0x02007973 RID: 31091
	private class EImportantRewardItemComponents
	{
		// Token: 0x04029B72 RID: 170866
		public const int SprBg = 0;

		// Token: 0x04029B73 RID: 170867
		public const int SprBgDesc = 1;

		// Token: 0x04029B74 RID: 170868
		public const int TexPix = 2;

		// Token: 0x04029B75 RID: 170869
		public const int TxtDay = 3;

		// Token: 0x04029B76 RID: 170870
		public const int TxtReward = 4;

		// Token: 0x04029B77 RID: 170871
		public const int Toggle = 5;

		// Token: 0x04029B78 RID: 170872
		public const int PnlReward = 6;

		// Token: 0x04029B79 RID: 170873
		public const int SprFrame = 7;

		// Token: 0x04029B7A RID: 170874
		public const int RewardEffect = 8;

		// Token: 0x04029B7B RID: 170875
		public const int LockItem = 9;
	}
}
