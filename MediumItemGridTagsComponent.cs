using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x020019E5 RID: 6629
[NullableContext(1)]
[Nullable(0)]
public class MediumItemGridTagsComponent : MediumItemGridComponent
{
	// Token: 0x0600BE06 RID: 48646 RVA: 0x0032553C File Offset: 0x0032373C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUILayoutBase));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600BE07 RID: 48647 RVA: 0x003255A5 File Offset: 0x003237A5
	protected override void OnStart()
	{
		UUISprite sprite = base.GetSprite(1);
		if (sprite == null)
		{
			return;
		}
		sprite.SetUIActive(false);
	}

	// Token: 0x0600BE08 RID: 48648 RVA: 0x003255B9 File Offset: 0x003237B9
	protected override string GetResourceId()
	{
		return "UiItem_EnemyItemState";
	}

	// Token: 0x0600BE09 RID: 48649 RVA: 0x003255C0 File Offset: 0x003237C0
	[NullableContext(2)]
	protected override void OnRefresh(object data)
	{
		string[] array = data as string[];
		if (array == null)
		{
			return;
		}
		bool flag = array != null && array.Length != 0;
		this.SetActive(flag);
		if (flag)
		{
			this.Tags = array;
			this.UpdateTagList();
		}
	}

	// Token: 0x0600BE0A RID: 48650 RVA: 0x003255FC File Offset: 0x003237FC
	private void UpdateTagList()
	{
		for (int i = this.Tags.Length; i < this.SpriteList.Count; i++)
		{
			this.SpriteList[i].SetUIActive(false);
		}
		for (int j = 0; j < this.Tags.Length; j++)
		{
			string path = this.Tags[j];
			UUISprite uiSprite = this.GetSpriteItem(j);
			uiSprite.SetUIActive(true);
			uiSprite.SetAlpha(0f);
			base.SetSpriteAsync(path, uiSprite, false).ContinueWith(delegate()
			{
				uiSprite.SetAlpha(1f);
			}).Forget();
		}
	}

	// Token: 0x0600BE0B RID: 48651 RVA: 0x003256A8 File Offset: 0x003238A8
	private UUISprite GetSpriteItem(int index)
	{
		if (index < this.SpriteList.Count)
		{
			return this.SpriteList[index];
		}
		UUISprite sprite = base.GetSprite(1);
		UUILayoutBase layoutBase = base.GetLayoutBase(0);
		TWeakObjectPtr<UUIItem>? tweakObjectPtr = (layoutBase != null) ? new TWeakObjectPtr<UUIItem>?(layoutBase.RootUIComp) : null;
		LguiUtil instance = Singleton<LguiUtil>.Instance;
		UUIItem item = sprite;
		TWeakObjectPtr<UUIItem>? tweakObjectPtr2 = tweakObjectPtr;
		UUISprite uuisprite = instance.CopyItem(item, (tweakObjectPtr2 != null) ? tweakObjectPtr2.GetValueOrDefault() : null) as UUISprite;
		this.SpriteList.Add(uuisprite);
		return uuisprite;
	}

	// Token: 0x04005970 RID: 22896
	private readonly List<UUISprite> SpriteList = new List<UUISprite>();

	// Token: 0x04005971 RID: 22897
	private string[] Tags = new string[0];

	// Token: 0x02007CD8 RID: 31960
	[NullableContext(0)]
	private class EChildType
	{
		// Token: 0x0402A995 RID: 174485
		public const int LayoutIcon = 0;

		// Token: 0x0402A996 RID: 174486
		public const int SpriteIconTemplate = 1;
	}
}
