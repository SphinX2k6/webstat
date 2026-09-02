using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002BF8 RID: 11256
public class TowerGuideView : UiViewBase
{
	// Token: 0x06016760 RID: 92000 RVA: 0x0063D602 File Offset: 0x0063B802
	[NullableContext(1)]
	public TowerGuideView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06016761 RID: 92001 RVA: 0x0063D60C File Offset: 0x0063B80C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 15;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickedCloseButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06016762 RID: 92002 RVA: 0x0063D866 File Offset: 0x0063BA66
	private void OnClickedCloseButton()
	{
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.StopCurrentSequence(false, true);
		}
		base.CloseMe(null);
	}

	// Token: 0x06016763 RID: 92003 RVA: 0x0063D884 File Offset: 0x0063BA84
	protected override void OnStart()
	{
		base.GetItem(14).SetUIActive(false);
		this.LevelSequencePlayer = new LevelSequencePlayer(base.GetRootItem());
		UUIItem item = base.GetItem(4);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		new TowerGuidePanel().CreateThenShowByActorAsync(base.GetItem(3).GetOwner(), null, false);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "TowerGuideTitle", Array.Empty<object>());
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.StopCurrentSequence(false, true);
		}
		LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
		if (levelSequencePlayer2 != null)
		{
			levelSequencePlayer2.PlayLevelSequenceByName("StartAtOnce", false, null, false);
		}
		base.GetButton(13).RootUIComp.Get().SetUIActive(false);
	}

	// Token: 0x06016764 RID: 92004 RVA: 0x0063D946 File Offset: 0x0063BB46
	protected override void OnAfterDestroy()
	{
		Singleton<EventSystem>.Instance.Emit(EEventName.OnTowerGuideClose);
	}

	// Token: 0x0400ADE0 RID: 44512
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x02008EEF RID: 36591
	private enum EChildType
	{
		// Token: 0x0403003A RID: 196666
		SpriteIcon,
		// Token: 0x0403003B RID: 196667
		TxtTitle,
		// Token: 0x0403003C RID: 196668
		BtnBack,
		// Token: 0x0403003D RID: 196669
		ItemMid,
		// Token: 0x0403003E RID: 196670
		ItemBottom,
		// Token: 0x0403003F RID: 196671
		LayoutPages,
		// Token: 0x04030040 RID: 196672
		UiItemPagesDot,
		// Token: 0x04030041 RID: 196673
		BtnArrowL,
		// Token: 0x04030042 RID: 196674
		BtnArrowR,
		// Token: 0x04030043 RID: 196675
		ItemTutorialsTips,
		// Token: 0x04030044 RID: 196676
		UiItemLayerBg,
		// Token: 0x04030045 RID: 196677
		UiItemLayerUi,
		// Token: 0x04030046 RID: 196678
		PageParent,
		// Token: 0x04030047 RID: 196679
		BtnBg,
		// Token: 0x04030048 RID: 196680
		DescItem
	}
}
