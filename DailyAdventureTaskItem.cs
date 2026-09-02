using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020012CE RID: 4814
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class DailyAdventureTaskItem : GridProxyAbstract<DailyAdventureTaskData>
{
	// Token: 0x06008147 RID: 33095 RVA: 0x00222C24 File Offset: 0x00220E24
	protected unsafe override void OnRegisterComponent()
	{
		int num = 8;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.ButtonJump));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.ButtonReward));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06008148 RID: 33096 RVA: 0x00222DB4 File Offset: 0x00220FB4
	protected override UniTask OnBeforeStartAsync()
	{
		DailyAdventureTaskItem.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<DailyAdventureTaskItem.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06008149 RID: 33097 RVA: 0x00222DF8 File Offset: 0x00220FF8
	private UniTask CreateRewardItem(AActor item)
	{
		DailyAdventureTaskItem.<CreateRewardItem>d__9 <CreateRewardItem>d__;
		<CreateRewardItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateRewardItem>d__.<>4__this = this;
		<CreateRewardItem>d__.item = item;
		<CreateRewardItem>d__.<>1__state = -1;
		<CreateRewardItem>d__.<>t__builder.Start<DailyAdventureTaskItem.<CreateRewardItem>d__9>(ref <CreateRewardItem>d__);
		return <CreateRewardItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600814A RID: 33098 RVA: 0x00222E44 File Offset: 0x00221044
	private void HandleRewardItemClick(MediumItemGridExtendCallback parameter)
	{
		if (this.Data == null)
		{
			return;
		}
		if (this.Data.TaskState != ERewardState.FinishedAndUnClaimed)
		{
			IItemGridData itemGridData = parameter.Data as IItemGridData;
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(itemGridData.Item.ItemData.ItemId, true, null);
			return;
		}
		ControllerBase<ActivityDailyAdventureController>.Instance.RequestTaskReward(this.Data.TaskId);
	}

	// Token: 0x0600814B RID: 33099 RVA: 0x00222EA8 File Offset: 0x002210A8
	public override void Refresh(DailyAdventureTaskData data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		DailyAdventureTask? dailyAdventureTaskConfig = ConfigBase<ActivityDailyAdventureConfig>.Instance.GetDailyAdventureTaskConfig(data.TaskId);
		if (dailyAdventureTaskConfig == null)
		{
			return;
		}
		List<string> list = dailyAdventureTaskConfig.Value.TaskFunc().ToList<string>();
		if (list.Count >= 1)
		{
			this.TaskJumpType = (EDailyAdventureTaskJumpType)int.Parse(list[0]);
		}
		if (list.Count >= 2)
		{
			this.TaskJumpParams = list.GetRange(1, list.Count - 1);
			if (this.TaskJumpType == EDailyAdventureTaskJumpType.Map)
			{
				this.TaskJumpParams.Add(ControllerBase<ActivityDailyAdventureController>.Instance.GetDefaultMapMarkId().ToString());
			}
		}
		List<TItem> list2 = new List<TItem>();
		foreach (KeyValuePair<int, int> keyValuePair in dailyAdventureTaskConfig.Value.TaskReward())
		{
			int key = keyValuePair.Key;
			int value = keyValuePair.Value;
			TItem item = new TItem
			{
				ItemData = new InventoryDefine.GetItemData(key, 0),
				Count = value
			};
			list2.Add(item);
		}
		if (list2.Count != 1)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Activity;
			ELogAuthor author = ELogAuthor.YYZ;
			string message = "[日常探险活动] 任务奖励配置不正确";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("TaskId", this.Data.TaskId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		ItemGridData data2 = new ItemGridData
		{
			Item = list2[0],
			HasClaimed = (this.Data.TaskState == ERewardState.FinishedAndClaimed)
		};
		this.RewardItemGrid.Refresh(data2, this.Data.TaskState == ERewardState.FinishedAndUnClaimed, this.Data.TaskState == ERewardState.Progress);
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew(dailyAdventureTaskConfig.Value.TaskTitle, null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "Text_ActivityTaskProgress_Text", new <>z__ReadOnlyArray<object>(new object[]
		{
			localTextNew,
			this.Data.CurrentProgress.ToString(),
			this.Data.TargetProgress.ToString()
		}));
		bool flag = !StringUtils.IsEmpty(dailyAdventureTaskConfig.Value.TaskDescription);
		base.GetItem(4).SetUIActive(flag);
		if (flag)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), dailyAdventureTaskConfig.Value.TaskDescription, Array.Empty<object>());
		}
		this.RefreshState(data.TaskState);
	}

	// Token: 0x0600814C RID: 33100 RVA: 0x00223130 File Offset: 0x00221330
	private void RefreshState(ERewardState state)
	{
		switch (state)
		{
		case ERewardState.FinishedAndUnClaimed:
			base.GetButton(5).RootUIComp.Get().SetUIActive(false);
			base.GetItem(7).SetUIActive(false);
			this.SetTextChangeColor(true);
			this.SetIconChangeColor(true);
			base.GetSprite(6).SetAlpha(1f);
			return;
		case ERewardState.Progress:
		{
			bool flag = this.TaskJumpType != EDailyAdventureTaskJumpType.Normal;
			base.GetButton(5).RootUIComp.Get().SetUIActive(flag);
			base.GetItem(7).SetUIActive(!flag);
			this.SetTextChangeColor(false);
			this.SetIconChangeColor(false);
			base.GetSprite(6).SetAlpha(1f);
			return;
		}
		case ERewardState.FinishedAndClaimed:
			base.GetButton(5).RootUIComp.Get().SetUIActive(false);
			base.GetItem(7).SetUIActive(false);
			this.SetTextChangeColor(false);
			this.SetIconChangeColor(false);
			base.GetSprite(6).SetAlpha(0.5f);
			return;
		default:
			return;
		}
	}

	// Token: 0x0600814D RID: 33101 RVA: 0x00223234 File Offset: 0x00221434
	private void SetTextChangeColor(bool useChangeColor)
	{
		UUIItem text = base.GetText(3);
		FColor? fcolor = new FColor?(base.GetText(3).changeColor);
		text.SetChangeColor(useChangeColor, fcolor);
	}

	// Token: 0x0600814E RID: 33102 RVA: 0x00223264 File Offset: 0x00221464
	private void SetIconChangeColor(bool useChangeColor)
	{
		UUIItem sprite = base.GetSprite(2);
		FColor? fcolor = new FColor?(base.GetSprite(2).changeColor);
		sprite.SetChangeColor(useChangeColor, fcolor);
	}

	// Token: 0x0600814F RID: 33103 RVA: 0x00223292 File Offset: 0x00221492
	private void ButtonJump()
	{
		if (this.Data == null || this.Data.TaskState != ERewardState.Progress)
		{
			return;
		}
		ControllerBase<DailyAdventureTaskController>.Instance.TrackTaskByType(this.TaskJumpType, this.TaskJumpParams.ToArray());
	}

	// Token: 0x06008150 RID: 33104 RVA: 0x002232C6 File Offset: 0x002214C6
	private void ButtonReward()
	{
		if (this.Data == null || this.Data.TaskState != ERewardState.FinishedAndUnClaimed)
		{
			return;
		}
		ControllerBase<ActivityDailyAdventureController>.Instance.RequestTaskReward(this.Data.TaskId);
	}

	// Token: 0x04003DB9 RID: 15801
	[Nullable(2)]
	private DailyAdventureTaskData Data;

	// Token: 0x04003DBA RID: 15802
	[Nullable(2)]
	private DailyAdventureSmallGridItem RewardItemGrid;

	// Token: 0x04003DBB RID: 15803
	protected EDailyAdventureTaskJumpType TaskJumpType = EDailyAdventureTaskJumpType.Normal;

	// Token: 0x04003DBC RID: 15804
	protected List<string> TaskJumpParams = new List<string>();

	// Token: 0x04003DBD RID: 15805
	private const float NORMAL_BG_ALPHA = 1f;

	// Token: 0x04003DBE RID: 15806
	private const float CLAMIED_BG_ALPHA = 0.5f;

	// Token: 0x02007640 RID: 30272
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x04028C21 RID: 166945
		public const int ButtonReward = 0;

		// Token: 0x04028C22 RID: 166946
		public const int Item = 1;

		// Token: 0x04028C23 RID: 166947
		public const int SpriteIcon = 2;

		// Token: 0x04028C24 RID: 166948
		public const int TxtName = 3;

		// Token: 0x04028C25 RID: 166949
		public const int TxtInfo = 4;

		// Token: 0x04028C26 RID: 166950
		public const int ButtonJump = 5;

		// Token: 0x04028C27 RID: 166951
		public const int SpriteBg = 6;

		// Token: 0x04028C28 RID: 166952
		public const int TxtOngoing = 7;
	}
}
