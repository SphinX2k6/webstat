using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020012A7 RID: 4775
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class TaskItem : GridProxyAbstract<TaskData>
{
	// Token: 0x06007FF7 RID: 32759 RVA: 0x0021CCD8 File Offset: 0x0021AED8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnClickJump)),
			new ValueTuple<int, Delegate>(1, new Action(this.OnClickGetButton))
		};
	}

	// Token: 0x06007FF8 RID: 32760 RVA: 0x0021CDC5 File Offset: 0x0021AFC5
	protected override void OnStart()
	{
		this.RewardScrollView = new GenericScrollViewNew<CommonItemSmallItemGrid, TItem>(base.GetScrollViewWithScrollbar(5), new Func<CommonItemSmallItemGrid>(this.CreatePropItem), null, false, null);
	}

	// Token: 0x06007FF9 RID: 32761 RVA: 0x0021CDE8 File Offset: 0x0021AFE8
	private CommonItemSmallItemGrid CreatePropItem()
	{
		return new CommonItemSmallItemGrid();
	}

	// Token: 0x06007FFA RID: 32762 RVA: 0x0021CDEF File Offset: 0x0021AFEF
	private void OnClickJump()
	{
		SkipTaskManager.RunByConfigId(this.TaskData.JumpId, null);
	}

	// Token: 0x06007FFB RID: 32763 RVA: 0x0021CE02 File Offset: 0x0021B002
	private void OnClickGetButton()
	{
		TaskReceive receiveDelegate = this.TaskData.ReceiveDelegate;
		if (receiveDelegate == null)
		{
			return;
		}
		receiveDelegate(this.TaskData.TaskId);
	}

	// Token: 0x06007FFC RID: 32764 RVA: 0x0021CE24 File Offset: 0x0021B024
	public override void Refresh(TaskData data, bool isSelected, int gridIndex)
	{
		this.TaskData = data;
		this.RewardScrollView.RefreshByData(data.RewardList, null, false);
		base.GetButton(1).RootUIComp.Get().SetUIActive(data.IsFinished && !data.IsTaken);
		base.GetItem(2).SetUIActive(data.IsTaken);
		base.GetText(6).SetUIActive(!data.IsTaken && !data.IsFinished && data.JumpId == 0);
		if (!StringUtils.IsEmpty(data.DoingTextId))
		{
			base.GetText(6).ShowTextNew("Moonfiesta_TargetDone");
		}
		else
		{
			base.GetText(6).ShowTextNew("Moonfiesta_TargetOn");
		}
		base.GetButton(0).RootUIComp.Get().SetUIActive(!data.IsFinished && !data.IsTaken && data.JumpId > 0);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), data.TitleTextId, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "LongShanStage_Progress", new <>z__ReadOnlyArray<object>(new object[]
		{
			data.Current,
			data.Target
		}));
	}

	// Token: 0x04003D25 RID: 15653
	private TaskData TaskData;

	// Token: 0x04003D26 RID: 15654
	private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> RewardScrollView;

	// Token: 0x0200761E RID: 30238
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x04028B7F RID: 166783
		public const int JumpBtn = 0;

		// Token: 0x04028B80 RID: 166784
		public const int GetBtn = 1;

		// Token: 0x04028B81 RID: 166785
		public const int FinishItem = 2;

		// Token: 0x04028B82 RID: 166786
		public const int TxtName = 3;

		// Token: 0x04028B83 RID: 166787
		public const int ProgressText = 4;

		// Token: 0x04028B84 RID: 166788
		public const int RewardScroll = 5;

		// Token: 0x04028B85 RID: 166789
		public const int DoingText = 6;
	}
}
