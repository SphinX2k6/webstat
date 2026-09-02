using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Area;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001A9C RID: 6812
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class DailyActivityTaskItem : GridProxyAbstract<DailyActiveTaskData>
{
	// Token: 0x0600C328 RID: 49960 RVA: 0x00336BB4 File Offset: 0x00334DB4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIText)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(4, new Action(this.OnClickItem)),
			new ValueTuple<int, Delegate>(5, new Action(this.OnClickJumpToBtn)),
			new ValueTuple<int, Delegate>(6, new Action(this.OnClickTakeRewardBtn))
		};
	}

	// Token: 0x0600C329 RID: 49961 RVA: 0x00336D2A File Offset: 0x00334F2A
	protected override void OnStart()
	{
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
	}

	// Token: 0x0600C32A RID: 49962 RVA: 0x00336D3D File Offset: 0x00334F3D
	protected override void OnBeforeDestroy()
	{
	}

	// Token: 0x0600C32B RID: 49963 RVA: 0x00336D3F File Offset: 0x00334F3F
	private void OnClickTakeRewardBtn()
	{
		if (this.TaskId == 0)
		{
			return;
		}
		Action clickReceiveCb = this.ClickReceiveCb;
		if (clickReceiveCb == null)
		{
			return;
		}
		clickReceiveCb();
	}

	// Token: 0x0600C32C RID: 49964 RVA: 0x00336D5A File Offset: 0x00334F5A
	private void OnClickJumpToBtn()
	{
		if (this.TaskId == 0)
		{
			return;
		}
		if (!this.IsFunctionUnlock)
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("FunctionDisable", Array.Empty<object>());
			return;
		}
		SkipTaskManager.RunByConfigId(this.JumpId, null);
	}

	// Token: 0x0600C32D RID: 49965 RVA: 0x00336D8E File Offset: 0x00334F8E
	private void OnClickItem()
	{
		if (this.TaskId == 0 || this.RewardItemId == 0)
		{
			return;
		}
		ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(this.RewardItemId, true, null);
	}

	// Token: 0x0600C32E RID: 49966 RVA: 0x00336DB4 File Offset: 0x00334FB4
	public override void Refresh(DailyActiveTaskData data, bool isSelected, int gridIndex)
	{
		this.TaskId = data.TaskId.Value;
		this.IsFunctionUnlock = data.IsFunctionUnlock;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "DailyTask_ProgressText", new <>z__ReadOnlyArray<object>(new object[]
		{
			data.CurrentProgress.ToString(),
			data.TargetProgress.ToString()
		}));
		LivenessTask value = ConfigBase<DailyActivityConfig>.Instance.GetActivityTaskConfigById(this.TaskId).Value;
		string taskName = value.TaskName;
		int updateType = value.UpdateType;
		List<string> list = new List<string>();
		if (updateType == 2)
		{
			int areaId = ModelBase<DailyActivityModel>.Instance.AreaId;
			if (areaId > 0)
			{
				Area? areaInfo = ConfigBase<AreaConfig>.Instance.GetAreaInfo(areaId);
				if (areaInfo != null)
				{
					string localTextNew = ConfigMultiTextLang.GetLocalTextNew(areaInfo.Value.Title, null);
					if (localTextNew != null)
					{
						list.Add(localTextNew);
					}
				}
			}
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), taskName, list.ToArray());
		this.JumpId = value.AccessId;
		TItem titem = data.RewardItemList[0];
		this.RewardItemId = titem.ItemData.ItemId;
		base.GetText(8).SetText("+" + titem.Count.ToString(), true);
		switch (data.TaskState)
		{
		case EDailyActiveState.FinishedAndNotTaken:
			base.GetText(2).SetUIActive(false);
			base.GetButton(5).RootUIComp.Get().SetUIActive(false);
			base.GetButton(6).RootUIComp.Get().SetUIActive(true);
			base.GetItem(3).SetUIActive(false);
			base.GetItem(7).SetUIActive(false);
			break;
		case EDailyActiveState.Unfinished:
		{
			bool flag = this.JumpId != 0;
			base.GetText(2).SetUIActive(!flag);
			base.GetButton(5).RootUIComp.Get().SetUIActive(flag);
			base.GetButton(6).RootUIComp.Get().SetUIActive(false);
			base.GetItem(3).SetUIActive(false);
			base.GetItem(7).SetUIActive(false);
			break;
		}
		case EDailyActiveState.FinishedAndTaken:
			base.GetText(2).SetUIActive(false);
			base.GetButton(5).RootUIComp.Get().SetUIActive(false);
			base.GetButton(6).RootUIComp.Get().SetUIActive(false);
			base.GetItem(3).SetUIActive(true);
			base.GetItem(7).SetUIActive(true);
			break;
		}
		bool flag2 = data.TaskState == EDailyActiveState.FinishedAndTaken;
		base.GetItem(9).SetUIActive(!flag2);
		base.GetItem(10).SetUIActive(flag2);
		base.GetItem(11).SetAlpha(flag2 ? 0.5f : 1f);
	}

	// Token: 0x0600C32F RID: 49967 RVA: 0x003370A4 File Offset: 0x003352A4
	public void SetClickReceiveCb(Action cb)
	{
		this.ClickReceiveCb = cb;
	}

	// Token: 0x0600C330 RID: 49968 RVA: 0x003370B0 File Offset: 0x003352B0
	public UniTask PlayRewardAnimAsync()
	{
		DailyActivityTaskItem.<PlayRewardAnimAsync>d__15 <PlayRewardAnimAsync>d__;
		<PlayRewardAnimAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayRewardAnimAsync>d__.<>4__this = this;
		<PlayRewardAnimAsync>d__.<>1__state = -1;
		<PlayRewardAnimAsync>d__.<>t__builder.Start<DailyActivityTaskItem.<PlayRewardAnimAsync>d__15>(ref <PlayRewardAnimAsync>d__);
		return <PlayRewardAnimAsync>d__.<>t__builder.Task;
	}

	// Token: 0x04005D7E RID: 23934
	private int TaskId;

	// Token: 0x04005D7F RID: 23935
	private bool IsFunctionUnlock;

	// Token: 0x04005D80 RID: 23936
	private int RewardItemId;

	// Token: 0x04005D81 RID: 23937
	private int JumpId;

	// Token: 0x04005D82 RID: 23938
	[Nullable(2)]
	private Action ClickReceiveCb;

	// Token: 0x04005D83 RID: 23939
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x02007D5F RID: 32095
	[NullableContext(0)]
	private enum EActiveTaskComponent
	{
		// Token: 0x0402AB84 RID: 174980
		TxtDescription,
		// Token: 0x0402AB85 RID: 174981
		TxtProcess,
		// Token: 0x0402AB86 RID: 174982
		TxtStatus,
		// Token: 0x0402AB87 RID: 174983
		PanelFinished,
		// Token: 0x0402AB88 RID: 174984
		RewardItem,
		// Token: 0x0402AB89 RID: 174985
		JumpButton,
		// Token: 0x0402AB8A RID: 174986
		RewardButton,
		// Token: 0x0402AB8B RID: 174987
		PanelMask,
		// Token: 0x0402AB8C RID: 174988
		TxtValue,
		// Token: 0x0402AB8D RID: 174989
		TextureActiveBg,
		// Token: 0x0402AB8E RID: 174990
		TextureDoneBg,
		// Token: 0x0402AB8F RID: 174991
		ContentItem
	}
}
