using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002688 RID: 9864
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class QuestReviewTabItem : GridProxyAbstract<QuestReviewTabData>
{
	// Token: 0x06013750 RID: 79696 RVA: 0x0056BDA4 File Offset: 0x00569FA4
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
		*span[num2] = new ValueTuple<int, Type>(2, typeof(USpineSkeletonAnimationComponent));
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
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnTabClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06013751 RID: 79697 RVA: 0x0056BEB0 File Offset: 0x0056A0B0
	protected override void OnStart()
	{
		this.SeqPlayer = new LevelSequencePlayer(base.GetRootItem());
		this.SeqPlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSeqEnd), false);
		Singleton<EventSystem>.Instance.Add(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnOpenQuestReviewDetail, new Action<int>(this.RefreshRedDot));
	}

	// Token: 0x06013752 RID: 79698 RVA: 0x0056BF1E File Offset: 0x0056A11E
	protected override void OnBeforeDestroy()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnOpenQuestReviewDetail, new <>f__AnonymousDelegate2<int>(this.RefreshRedDot));
	}

	// Token: 0x06013753 RID: 79699 RVA: 0x0056BF58 File Offset: 0x0056A158
	public override void Refresh(QuestReviewTabData data, bool isSelected, int gridIndex)
	{
		this.Clear();
		this.Data = data;
		this.RefreshRedDot(0);
		if (this.Data.IsFirstTimeShow)
		{
			this.SeqPlayer.PlayLevelSequenceByName("Unlock", false, null, false);
			this.Data.IsFirstTimeShow = false;
			this.HasStartSeqPlayed = true;
		}
		else if (!this.HasStartSeqPlayed)
		{
			this.SeqPlayer.PlayLevelSequenceByName(data.IsSelected ? "Start" : "UnStart", false, null, false);
			this.HasStartSeqPlayed = true;
			base.GetExtendToggle(0).SetToggleState(data.IsSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		}
		else
		{
			base.GetExtendToggle(0).SetToggleState(data.IsSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), data.NameId, Array.Empty<object>());
		base.GetSprite(3).SetUIActive(gridIndex < 2);
	}

	// Token: 0x06013754 RID: 79700 RVA: 0x0056C058 File Offset: 0x0056A258
	public override void Clear()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		extendToggle.SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
		FToggleAnimationPlayInfo ftoggleAnimationPlayInfo = extendToggle.StateSwitchAnimations.Get(EToggleStateSwitch.CheckedToUnChecked);
		if (ftoggleAnimationPlayInfo == null)
		{
			return;
		}
		FSoftObjectPath levelSequence = ftoggleAnimationPlayInfo.Animation.LevelSequence;
		(extendToggle.GetOwner() as AUIBaseActor).SequenceJumpToEnd(levelSequence);
	}

	// Token: 0x06013755 RID: 79701 RVA: 0x0056C0AC File Offset: 0x0056A2AC
	private void OnTabClick(EToggleState toggleState)
	{
		ControllerBase<QuestReviewController>.Instance.TriggerViewRefresh(this.Data.Id);
	}

	// Token: 0x06013756 RID: 79702 RVA: 0x0056C0C3 File Offset: 0x0056A2C3
	private void OnSeqEnd(string name)
	{
		if (name == "Unlock")
		{
			QuestReviewTabData data = this.Data;
			if (data != null && data.IsSelected)
			{
				base.GetExtendToggle(0).SetToggleStateForce(EToggleState.ETT_Checked, false, true, false);
			}
		}
	}

	// Token: 0x06013757 RID: 79703 RVA: 0x0056C0F6 File Offset: 0x0056A2F6
	private void OnActivitySequenceEmitEvent(string param)
	{
		if (param == "idle")
		{
			USpineSkeletonAnimationComponent spine = base.GetSpine(2);
			if (spine == null)
			{
				return;
			}
			spine.SetAnimation(0, param, true);
		}
	}

	// Token: 0x06013758 RID: 79704 RVA: 0x0056C11C File Offset: 0x0056A31C
	private void RefreshRedDot(int i = 0)
	{
		QuestReviewModel instance = ModelBase<QuestReviewModel>.Instance;
		QuestReviewTabData data = this.Data;
		bool uiactive = instance.TabHasRedDot((data != null) ? data.Id : 0);
		base.GetItem(4).SetUIActive(uiactive);
	}

	// Token: 0x040097A6 RID: 38822
	[Nullable(2)]
	private QuestReviewTabData Data;

	// Token: 0x040097A7 RID: 38823
	[Nullable(2)]
	private LevelSequencePlayer SeqPlayer;

	// Token: 0x040097A8 RID: 38824
	private bool HasStartSeqPlayed;

	// Token: 0x02008A2B RID: 35371
	[NullableContext(0)]
	private class ETabComponentDefine
	{
		// Token: 0x0402E97C RID: 190844
		public const int ToggleSelf = 0;

		// Token: 0x0402E97D RID: 190845
		public const int TextDesc = 1;

		// Token: 0x0402E97E RID: 190846
		public const int Spine = 2;

		// Token: 0x0402E97F RID: 190847
		public const int SpriteLine = 3;

		// Token: 0x0402E980 RID: 190848
		public const int ItemRedDot = 4;
	}
}
