using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001B98 RID: 7064
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class MapExplorePlayProgressItem : GridProxyAbstract<IExplorePlayProgressItemData>
{
	// Token: 0x0600CD8C RID: 52620 RVA: 0x0036C0D8 File Offset: 0x0036A2D8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
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

	// Token: 0x0600CD8D RID: 52621 RVA: 0x0036C1C5 File Offset: 0x0036A3C5
	protected override void OnBeforeCreate()
	{
		this.Sequence = new LevelSequencePlayer(this.RootItem);
	}

	// Token: 0x0600CD8E RID: 52622 RVA: 0x0036C1D8 File Offset: 0x0036A3D8
	[NullableContext(1)]
	public override void Refresh(IExplorePlayProgressItemData data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		this.UpdatePlayPointType();
		if (data.LastPlayPointState != null)
		{
			this.UpdatePlayPointState(data.LastPlayPointState.Value);
			return;
		}
		this.UpdatePlayPointState(data.PlayPointState);
	}

	// Token: 0x0600CD8F RID: 52623 RVA: 0x0036C224 File Offset: 0x0036A424
	public void UpdatePlayPointType()
	{
		if (this.Data.IgnoreHiddenType.GetValueOrDefault())
		{
			base.GetSprite(4).SetUIActive(false);
			return;
		}
		if (this.Data.PlayPointType == EPlayPointType.Hidden)
		{
			base.GetSprite(4).SetUIActive(true);
			return;
		}
		base.GetSprite(4).SetUIActive(false);
	}

	// Token: 0x0600CD90 RID: 52624 RVA: 0x0036C280 File Offset: 0x0036A480
	private void UpdatePlayPointState(EPlayPointState playPointState)
	{
		base.GetSprite(1).SetUIActive(false);
		base.GetSprite(2).SetUIActive(false);
		base.GetSprite(3).SetUIActive(false);
		switch (playPointState)
		{
		case EPlayPointState.Locked:
			base.GetSprite(1).SetUIActive(true);
			base.GetSprite(5).SetFillAmount(0f);
			return;
		case EPlayPointState.ToBeCompleted:
			base.GetSprite(2).SetUIActive(true);
			base.GetSprite(5).SetFillAmount(0f);
			return;
		case EPlayPointState.Completed:
			base.GetSprite(3).SetUIActive(true);
			base.GetSprite(5).SetFillAmount(1f);
			return;
		default:
			return;
		}
	}

	// Token: 0x0600CD91 RID: 52625 RVA: 0x0036C324 File Offset: 0x0036A524
	public void CheckPlayStateChanged()
	{
		if (this.Data.LastPlayPointState == null)
		{
			return;
		}
		LevelSequencePlayer sequence = this.Sequence;
		if (sequence != null)
		{
			sequence.PlayLevelSequenceByName("Complete", false, null, false);
		}
		this.UpdatePlayPointState(this.Data.PlayPointState);
		this.Data.LastPlayPointState = null;
	}

	// Token: 0x0600CD92 RID: 52626 RVA: 0x0036C38D File Offset: 0x0036A58D
	protected override void OnBeforeDestroy()
	{
		LevelSequencePlayer sequence = this.Sequence;
		if (sequence != null)
		{
			sequence.Clear();
		}
		this.Sequence = null;
	}

	// Token: 0x04006229 RID: 25129
	private LevelSequencePlayer Sequence;

	// Token: 0x0400622A RID: 25130
	private IExplorePlayProgressItemData Data;

	// Token: 0x02007E82 RID: 32386
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402B192 RID: 176530
		IconRoot,
		// Token: 0x0402B193 RID: 176531
		LockedIcon,
		// Token: 0x0402B194 RID: 176532
		ToBeCompletedIcon,
		// Token: 0x0402B195 RID: 176533
		CompletedIcon,
		// Token: 0x0402B196 RID: 176534
		HiddenPoint,
		// Token: 0x0402B197 RID: 176535
		ProgressBar
	}
}
