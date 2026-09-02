using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

// Token: 0x020019E3 RID: 6627
public class MediumItemGridStarLevelComponent : MediumItemGridComponent
{
	// Token: 0x0600BDFA RID: 48634 RVA: 0x00325298 File Offset: 0x00323498
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600BDFB RID: 48635 RVA: 0x00325301 File Offset: 0x00323501
	protected override void OnActivate()
	{
		this.VerticalItem = base.GetItem(0);
		UUISprite sprite = base.GetSprite(1);
		if (sprite == null)
		{
			return;
		}
		sprite.SetUIActive(false);
	}

	// Token: 0x0600BDFC RID: 48636 RVA: 0x00325322 File Offset: 0x00323522
	protected override void OnDeactivate()
	{
		this.StarSpriteActorList.Clear();
		this.VerticalItem = null;
	}

	// Token: 0x0600BDFD RID: 48637 RVA: 0x00325336 File Offset: 0x00323536
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_ItemTagStar";
	}

	// Token: 0x0600BDFE RID: 48638 RVA: 0x00325340 File Offset: 0x00323540
	[NullableContext(2)]
	protected override void OnRefresh(object data)
	{
		if (!(data is int))
		{
			return;
		}
		int num = (int)data;
		if (this.StarLevel == num)
		{
			this.SetActive(true);
			return;
		}
		this.StarLevel = num;
		UUISprite sprite = base.GetSprite(1);
		AUIBaseActor actor = ((sprite != null) ? sprite.GetOwner() : null) as AUIBaseActor;
		this.HiddenAllStar();
		for (int i = 0; i < num; i++)
		{
			AUIBaseActor auibaseActor = null;
			if (i < this.StarSpriteActorList.Count)
			{
				auibaseActor = this.StarSpriteActorList[i];
			}
			if (auibaseActor == null || !auibaseActor.IsValid())
			{
				auibaseActor = (Singleton<LguiUtil>.Instance.DuplicateActor(actor, this.VerticalItem) as AUIBaseActor);
				if (i < this.StarSpriteActorList.Count)
				{
					this.StarSpriteActorList[i] = auibaseActor;
				}
				else
				{
					this.StarSpriteActorList.Add(auibaseActor);
				}
			}
			if (auibaseActor != null)
			{
				UUIItem uiitem = auibaseActor.GetUIItem();
				if (uiitem != null)
				{
					uiitem.SetUIActive(true);
				}
			}
		}
		this.SetActive(true);
	}

	// Token: 0x0600BDFF RID: 48639 RVA: 0x0032542C File Offset: 0x0032362C
	private void HiddenAllStar()
	{
		foreach (AUIBaseActor auibaseActor in this.StarSpriteActorList)
		{
			if (auibaseActor != null)
			{
				UUIItem uiitem = auibaseActor.GetUIItem();
				if (uiitem != null)
				{
					uiitem.SetUIActive(false);
				}
			}
		}
	}

	// Token: 0x0400596D RID: 22893
	[Nullable(2)]
	private UUIItem VerticalItem;

	// Token: 0x0400596E RID: 22894
	[Nullable(1)]
	private readonly List<AUIBaseActor> StarSpriteActorList = new List<AUIBaseActor>();

	// Token: 0x0400596F RID: 22895
	private int StarLevel;

	// Token: 0x02007CD6 RID: 31958
	private class EChildType
	{
		// Token: 0x0402A992 RID: 174482
		public const int VerticalItem = 0;

		// Token: 0x0402A993 RID: 174483
		public const int StarSprite = 1;
	}
}
