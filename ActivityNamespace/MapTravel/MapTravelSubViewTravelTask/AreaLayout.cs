using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Area;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace ActivityNamespace.MapTravel.MapTravelSubViewTravelTask
{
	// Token: 0x020043C9 RID: 17353
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	internal class AreaLayout : GridProxyAbstract<MapTravelAreaData>
	{
		// Token: 0x0602E20B RID: 188939 RVA: 0x00AD8882 File Offset: 0x00AD6A82
		public AreaLayout(ActivityMapTravelData ActivityBaseData)
		{
			this.ActivityBaseData = ActivityBaseData;
		}

		// Token: 0x0602E20C RID: 188940 RVA: 0x00AD8894 File Offset: 0x00AD6A94
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0602E20D RID: 188941 RVA: 0x00AD89C4 File Offset: 0x00AD6BC4
		protected override UniTask OnBeforeStartAsync()
		{
			AreaLayout.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<AreaLayout.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0602E20E RID: 188942 RVA: 0x00AD8A07 File Offset: 0x00AD6C07
		protected override void OnStart()
		{
			this.TaskLayout = new GenericLayout<TaskNormalItem, ActivityTaskData>(base.GetVerticalLayout(1), new Func<TaskNormalItem>(this.InitItem), null, false, true);
		}

		// Token: 0x0602E20F RID: 188943 RVA: 0x00AD8A2A File Offset: 0x00AD6C2A
		private TaskNormalItem InitItem()
		{
			TaskNormalItem taskNormalItem = new TaskNormalItem(this.ActivityBaseData);
			taskNormalItem.SetBtnClickCallback(delegate
			{
				GenericLayout<TaskNormalItem, ActivityTaskData> taskLayout = this.TaskLayout;
				List<int> list;
				if (taskLayout == null)
				{
					list = null;
				}
				else
				{
					list = taskLayout.GetDatas().ToList<ActivityTaskData>().FindAll((ActivityTaskData data) => data.Status == EActivityTaskState.FinishedAndUnclaimed).ConvertAll<int>((ActivityTaskData data) => data.Id);
				}
				List<int> list2 = list;
				if (list2 != null)
				{
					ControllerBase<ActivityMapTravelController>.Instance.RequestMultiMapTravelTaskReward(list2);
				}
			});
			return taskNormalItem;
		}

		// Token: 0x0602E210 RID: 188944 RVA: 0x00AD8A4C File Offset: 0x00AD6C4C
		public override void Refresh(MapTravelAreaData data, bool isSelected, int gridIndex)
		{
			this.IsLoading = true;
			this.IsUnlock = data.IsUnlock;
			Area? areaInfo = ConfigBase<AreaConfig>.Instance.GetAreaInfo(data.AreaId);
			TravelTaskArea? areaConfig = ConfigBase<ActivityMapTravelConfig>.Instance.GetAreaConfig(data.AreaId);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), areaInfo.Value.Title, Array.Empty<object>());
			bool uiactive = true;
			foreach (int key in data.TravelTaskIdSet)
			{
				if (this.ActivityBaseData.AreaTaskMap[key].Status != EActivityTaskState.FinishedAndClaimed)
				{
					uiactive = false;
					break;
				}
			}
			UUIItem text = base.GetText(0);
			bool bUseChangeColor = !data.IsUnlock;
			FColor? fcolor = new FColor?(base.GetText(0).changeColor);
			text.SetChangeColor(bUseChangeColor, fcolor);
			UUIItem texture = base.GetTexture(7);
			bool bUseChangeColor2 = !data.IsUnlock;
			fcolor = new FColor?(base.GetTexture(7).changeColor);
			texture.SetChangeColor(bUseChangeColor2, fcolor);
			base.GetItem(5).SetUIActive(!data.IsUnlock);
			base.GetItem(6).SetUIActive(uiactive);
			List<ActivityTaskData> data2 = new List<ActivityTaskData>();
			this.LockItem.SetActive(!data.IsUnlock);
			if (data.IsUnlock)
			{
				this.TryUnlockArea(data);
				data2 = this.ActivityBaseData.GetAreaTaskDataList(data.AreaId);
			}
			else
			{
				MapTravelLockAreaData mapTravelLockAreaData = new MapTravelLockAreaData(data.AreaId);
				mapTravelLockAreaData.ConditionGroupId = areaConfig.Value.UnLockCondition;
				mapTravelLockAreaData.JumpId = areaConfig.Value.UnlockAccessId;
				this.LockItem.Refresh(mapTravelLockAreaData);
			}
			this.TaskLayout.RefreshByData(data2, delegate
			{
				this.IsLoading = false;
				this.TaskLayout.BindLateUpdate(delegate(float _)
				{
					this.TaskLayout.UnBindLateUpdate();
					CustomPromise loadingPromise = this.LoadingPromise;
					if (loadingPromise == null)
					{
						return;
					}
					loadingPromise.SetResult();
				});
			}, false);
		}

		// Token: 0x0602E211 RID: 188945 RVA: 0x00AD8C2C File Offset: 0x00AD6E2C
		public UniTask WaitRefreshDone()
		{
			AreaLayout.<WaitRefreshDone>d__14 <WaitRefreshDone>d__;
			<WaitRefreshDone>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<WaitRefreshDone>d__.<>4__this = this;
			<WaitRefreshDone>d__.<>1__state = -1;
			<WaitRefreshDone>d__.<>t__builder.Start<AreaLayout.<WaitRefreshDone>d__14>(ref <WaitRefreshDone>d__);
			return <WaitRefreshDone>d__.<>t__builder.Task;
		}

		// Token: 0x0602E212 RID: 188946 RVA: 0x00AD8C70 File Offset: 0x00AD6E70
		private void TryUnlockArea(MapTravelAreaData data)
		{
			if (this.ActivityBaseData.GetAreaNewUnlockState(data.AreaId))
			{
				this.ActivityBaseData.SaveFirstCheckRedDotState(EMapTravelSaveFlag.AreaNewUnlock, data.AreaId);
				this.LevelSequencePlayer.PlayLevelSequenceByName("Unlock", true, null, false);
			}
		}

		// Token: 0x0602E213 RID: 188947 RVA: 0x00AD8CBE File Offset: 0x00AD6EBE
		[NullableContext(2)]
		public UUIItem GetFirstItem()
		{
			if (this.IsUnlock)
			{
				return this.TaskLayout.GetItemByIndex(0);
			}
			TaskLockItem lockItem = this.LockItem;
			if (lockItem == null)
			{
				return null;
			}
			return lockItem.GetRootItem();
		}

		// Token: 0x0401A17F RID: 106879
		private ActivityMapTravelData ActivityBaseData;

		// Token: 0x0401A180 RID: 106880
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		protected GenericLayout<TaskNormalItem, ActivityTaskData> TaskLayout;

		// Token: 0x0401A181 RID: 106881
		[Nullable(2)]
		private TaskLockItem LockItem;

		// Token: 0x0401A182 RID: 106882
		[Nullable(2)]
		private CustomPromise LoadingPromise;

		// Token: 0x0401A183 RID: 106883
		private bool IsLoading;

		// Token: 0x0401A184 RID: 106884
		private bool IsUnlock;

		// Token: 0x0401A185 RID: 106885
		[Nullable(2)]
		protected LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0200A63A RID: 42554
		[NullableContext(0)]
		private class ELayoutDefine
		{
			// Token: 0x0403366B RID: 210539
			public const int Title = 0;

			// Token: 0x0403366C RID: 210540
			public const int Layout = 1;

			// Token: 0x0403366D RID: 210541
			public const int TaskItem = 2;

			// Token: 0x0403366E RID: 210542
			public const int LockTaskItem = 3;

			// Token: 0x0403366F RID: 210543
			public const int PanelTitle = 4;

			// Token: 0x04033670 RID: 210544
			public const int LockItem = 5;

			// Token: 0x04033671 RID: 210545
			public const int FinishedItem = 6;

			// Token: 0x04033672 RID: 210546
			public const int TexIcon = 7;
		}
	}
}
