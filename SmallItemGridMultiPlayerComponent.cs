using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

// Token: 0x02001A30 RID: 6704
public class SmallItemGridMultiPlayerComponent : SmallItemGridComponent
{
	// Token: 0x0600C01D RID: 49181 RVA: 0x0032C6EF File Offset: 0x0032A8EF
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_PlayerIcon";
	}

	// Token: 0x0600C01E RID: 49182 RVA: 0x0032C6F8 File Offset: 0x0032A8F8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600C01F RID: 49183 RVA: 0x0032C740 File Offset: 0x0032A940
	[NullableContext(2)]
	protected override void OnRefresh(object @params)
	{
		SmallItemMultiPlayer smallItemMultiPlayer = @params as SmallItemMultiPlayer;
		List<SmallItemMultiPlayerSlot> list = (smallItemMultiPlayer != null) ? smallItemMultiPlayer.Players : null;
		if (list == null || list.Count == 0)
		{
			this.SetActive(false);
			return;
		}
		this.EnsureIconCount(list.Count);
		for (int i = 0; i < this.IconSprites.Count; i++)
		{
			UUISprite uuisprite = this.IconSprites[i];
			if (i < list.Count)
			{
				SmallItemMultiPlayerSlot smallItemMultiPlayerSlot = list[i];
				string resourceId = smallItemMultiPlayerSlot.IsSelf ? SmallItemGridDefine.SelfResIdBySlot[smallItemMultiPlayerSlot.Seat] : SmallItemGridDefine.NormalResIdBySlot[smallItemMultiPlayerSlot.Seat];
				UiResourceConfig instance = ConfigBase<UiResourceConfig>.Instance;
				string path = ((instance != null) ? instance.GetResourcePath(resourceId) : null) ?? "";
				this.SetSpriteByPath(path, uuisprite, false, null, null);
				uuisprite.SetUIActive(true);
			}
			else
			{
				uuisprite.SetUIActive(false);
			}
		}
		this.SetActive(true);
	}

	// Token: 0x0600C020 RID: 49184 RVA: 0x0032C830 File Offset: 0x0032AA30
	private void EnsureIconCount(int count)
	{
		if (this.IconSprites.Count == 0)
		{
			this.IconSprites.Add(base.GetSprite(0));
		}
		UUISprite item = this.IconSprites[0];
		UUIItem rootItem = base.GetRootItem();
		while (this.IconSprites.Count < count)
		{
			UUISprite item2 = Singleton<LguiUtil>.Instance.CopyItem(item, rootItem) as UUISprite;
			this.IconSprites.Add(item2);
		}
	}

	// Token: 0x040059F9 RID: 23033
	[Nullable(1)]
	private readonly List<UUISprite> IconSprites = new List<UUISprite>();

	// Token: 0x02007CFF RID: 31999
	private static class EComponent
	{
		// Token: 0x0402AA1B RID: 174619
		public const int SpriteIcon = 0;
	}
}
