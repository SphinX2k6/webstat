using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002B26 RID: 11046
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class SurvivorsRewardTaskItem : GridProxyAbstract<ActivityTaskData>
{
	// Token: 0x060160D6 RID: 90326 RVA: 0x0061E8CC File Offset: 0x0061CACC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUISprite)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(4, new Action(this.OnGetBtnClickInternal)),
			new ValueTuple<int, Delegate>(8, new Action(this.OnJumpBtnClick))
		};
	}

	// Token: 0x060160D7 RID: 90327 RVA: 0x0061E9E5 File Offset: 0x0061CBE5
	protected override void OnStart()
	{
		this.RewardScroll = new GenericLayout<CommonItemSmallItemGrid, TItem>(base.GetHorizontalLayout(2), new Func<CommonItemSmallItemGrid>(this.CreateRewardItem), null, false, true);
	}

	// Token: 0x060160D8 RID: 90328 RVA: 0x0061EA08 File Offset: 0x0061CC08
	private CommonItemSmallItemGrid CreateRewardItem()
	{
		return new CommonItemSmallItemGrid();
	}

	// Token: 0x060160D9 RID: 90329 RVA: 0x0061EA10 File Offset: 0x0061CC10
	public override void Refresh(ActivityTaskData taskData, bool isSelected, int gridIndex)
	{
		this.TaskData = taskData;
		SurvivorsTask? survivorsTask = ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsTask(taskData.Id);
		if (survivorsTask == null)
		{
			return;
		}
		List<TItem> dropPackagePreviewItemList = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(survivorsTask.Value.DropId);
		this.RewardScroll.RefreshByData(dropPackagePreviewItemList, null, false);
		bool uiactive = taskData.Status == EActivityTaskState.FinishedAndClaimed;
		bool uiactive2 = taskData.Status == EActivityTaskState.FinishedAndUnclaimed;
		bool flag = taskData.Status == EActivityTaskState.Active;
		base.GetButton(4).RootUIComp.Get().SetUIActive(uiactive2);
		base.GetItem(7).SetUIActive(uiactive2);
		base.GetSprite(6).SetUIActive(uiactive);
		base.GetText(5).SetUIActive(flag && survivorsTask.Value.JumpId == 0);
		UUIButtonComponent button = base.GetButton(8);
		if (button != null)
		{
			button.RootUIComp.Get().SetUIActive(flag && survivorsTask.Value.JumpId > 0);
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), survivorsTask.Value.TaskName, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "SurvivorsNowProgress", new <>z__ReadOnlyArray<object>(new object[]
		{
			taskData.Current.ToString(),
			taskData.Target.ToString()
		}));
	}

	// Token: 0x060160DA RID: 90330 RVA: 0x0061EB81 File Offset: 0x0061CD81
	private void OnGetBtnClickInternal()
	{
		this.OnGetBtnClick();
	}

	// Token: 0x060160DB RID: 90331 RVA: 0x0061EB90 File Offset: 0x0061CD90
	private void OnJumpBtnClick()
	{
		if (this.TaskData == null)
		{
			return;
		}
		SurvivorsTask? survivorsTask = ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsTask(this.TaskData.Id);
		if (survivorsTask == null)
		{
			return;
		}
		SkipTaskManager.RunByConfigId(survivorsTask.Value.JumpId, null);
	}

	// Token: 0x060160DC RID: 90332 RVA: 0x0061EBDB File Offset: 0x0061CDDB
	public override object GetKey(ActivityTaskData data, int displayIndex)
	{
		return data.Id;
	}

	// Token: 0x0400A9AD RID: 43437
	[Nullable(2)]
	private ActivityTaskData TaskData;

	// Token: 0x0400A9AE RID: 43438
	public Action OnGetBtnClick = delegate()
	{
	};

	// Token: 0x0400A9AF RID: 43439
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<CommonItemSmallItemGrid, TItem> RewardScroll;
}
