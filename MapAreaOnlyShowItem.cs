using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001B8B RID: 7051
[NullableContext(1)]
[Nullable(0)]
public class MapAreaOnlyShowItem : UiPanelBase
{
	// Token: 0x0600CCEE RID: 52462 RVA: 0x00368C0C File Offset: 0x00366E0C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600CCEF RID: 52463 RVA: 0x00368CF9 File Offset: 0x00366EF9
	protected override void OnBeforeCreate()
	{
		this.Sequence = new LevelSequencePlayer(this.RootItem);
		LevelSequencePlayer sequence = this.Sequence;
		if (sequence == null)
		{
			return;
		}
		sequence.BindSequenceCloseEvent(new TSequenceEndEvent(this.SequenceCloseEvent), false);
	}

	// Token: 0x0600CCF0 RID: 52464 RVA: 0x00368D2C File Offset: 0x00366F2C
	public void Refresh(IMapAreaOnlyShowItemData data, int? index = null)
	{
		this.Index = index.GetValueOrDefault();
		this.Data = data;
		this.StopSequenceToFirst();
		if (data.OpenCount > 0 || data.NewOpenCount > 0)
		{
			base.SetTextureByPath(data.IconPath, base.GetTexture(0), null, null);
		}
		for (int i = 0; i < 4; i++)
		{
			bool flag = i < data.OpenCount;
			UUISprite sprite = base.GetSprite(1 + i);
			if (sprite != null)
			{
				sprite.SetUIActive(!flag);
			}
			if (!flag && i < data.OpenCount + data.NewOpenCount)
			{
				LevelSequencePlayer sequence = this.Sequence;
				if (sequence != null)
				{
					sequence.PlayLevelSequenceByName(MapAreaOnlyShowItem.lockKeys[i], false, null, false);
				}
			}
		}
		bool uiactive = data.OpenCount + data.NewOpenCount < 4;
		UUISprite sprite2 = base.GetSprite(5);
		if (sprite2 == null)
		{
			return;
		}
		sprite2.SetUIActive(uiactive);
	}

	// Token: 0x0600CCF1 RID: 52465 RVA: 0x00368E0F File Offset: 0x0036700F
	protected override void OnBeforeDestroy()
	{
		LevelSequencePlayer sequence = this.Sequence;
		if (sequence != null)
		{
			sequence.Clear();
		}
		this.Sequence = null;
	}

	// Token: 0x0600CCF2 RID: 52466 RVA: 0x00368E2C File Offset: 0x0036702C
	private void SequenceCloseEvent(string sequenceName)
	{
		if (!(sequenceName != "Unlock04".ToString()))
		{
			IMapAreaOnlyShowItemData data = this.Data;
			if (data == null || data.NewOpenCount != 0)
			{
				if (!base.IsUiActiveInHierarchy())
				{
					return;
				}
				LevelSequencePlayer sequence = this.Sequence;
				if (sequence != null && sequence.IsPlayingSequence("Unlock04"))
				{
					return;
				}
				LevelSequencePlayer sequence2 = this.Sequence;
				if (sequence2 == null)
				{
					return;
				}
				sequence2.PlayLevelSequenceByName("Complete", false, null, false);
				return;
			}
		}
	}

	// Token: 0x0600CCF3 RID: 52467 RVA: 0x00368EA8 File Offset: 0x003670A8
	public void StopSequenceToFirst()
	{
		LevelSequencePlayer sequence = this.Sequence;
		if (sequence != null)
		{
			sequence.StopPlayingSequence(false, true);
		}
		LevelSequencePlayer sequence2 = this.Sequence;
		if (sequence2 == null)
		{
			return;
		}
		sequence2.PlayLevelSequenceByName("FirstStart", false, null, false);
	}

	// Token: 0x040061EE RID: 25070
	[StaticVariableRuleIgnore]
	private static readonly string[] lockKeys = new string[]
	{
		"Unlock01",
		"Unlock02",
		"Unlock03",
		"Unlock04"
	};

	// Token: 0x040061EF RID: 25071
	[Nullable(2)]
	private LevelSequencePlayer Sequence;

	// Token: 0x040061F0 RID: 25072
	private int Index;

	// Token: 0x040061F1 RID: 25073
	[Nullable(2)]
	private IMapAreaOnlyShowItemData Data;

	// Token: 0x02007E6F RID: 32367
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402B112 RID: 176402
		TextureAreaIcon,
		// Token: 0x0402B113 RID: 176403
		SpriteMask1,
		// Token: 0x0402B114 RID: 176404
		SpriteMask2,
		// Token: 0x0402B115 RID: 176405
		SpriteMask3,
		// Token: 0x0402B116 RID: 176406
		SpriteMask4,
		// Token: 0x0402B117 RID: 176407
		SpriteMaskLine
	}
}
