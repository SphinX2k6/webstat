using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RealmBetween
{
	// Token: 0x02006559 RID: 25945
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class AreaTaskItem : SyncGridProxyAbstract<IAreaTaskItemData>
	{
		// Token: 0x06040D36 RID: 265526 RVA: 0x0109F987 File Offset: 0x0109DB87
		public AreaTaskItem(ActivityRealmBetweenData activityBaseData)
		{
			this.ActivityBaseData = activityBaseData;
		}

		// Token: 0x06040D37 RID: 265527 RVA: 0x0109F998 File Offset: 0x0109DB98
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(7, typeof(UUIItem))
			};
		}

		// Token: 0x06040D38 RID: 265528 RVA: 0x0109FA60 File Offset: 0x0109DC60
		protected override void OnStart()
		{
			this.RewardScrollView = new GenericScrollViewNew<ActivitySmallItemGrid, IItemGridData>(base.GetScrollViewWithScrollbar(2), new Func<ActivitySmallItemGrid>(this.InitRewardItem), null, false, null);
			this.InitGotoBtnProxy();
			this.InitRewardBtnProxy();
		}

		// Token: 0x06040D39 RID: 265529 RVA: 0x0109FA90 File Offset: 0x0109DC90
		public override void Refresh(IAreaTaskItemData data)
		{
			this.CurrentAreaId = data.AreaData.AreaId;
			if (data.UnlockJumpId != null)
			{
				this.RefreshAsLockGuide(data.UnlockJumpId.Value, data.UnlockHintText ?? "");
				return;
			}
			this.TaskData = data.TaskData;
			RealmBetweenTask value = ConfigBase<ActivityRealmBetweenConfig>.Instance.GetRealmBetweenTaskConfig(this.TaskData.Id).Value;
			bool flag = this.TaskData.Status == EActivityTaskState.FinishedAndClaimed;
			bool value2 = value.JumpId > 0 && this.TaskData.Status == EActivityTaskState.Active;
			bool flag2 = this.TaskData.Status == EActivityTaskState.FinishedAndUnclaimed;
			base.GetText(0).SetUIActive(true);
			base.GetText(1).SetUIActive(true);
			base.GetScrollViewWithScrollbar(2).RootUIComp.Get().SetUIActive(true);
			base.GetItem(7).SetUIActive(flag);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), value.Name, Array.Empty<object>());
			UUIText text = base.GetText(1);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(Math.Min(this.TaskData.Current, this.TaskData.Target));
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.TaskData.Target);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			this.RefreshRewardData(value.TaskReward);
			AreaTaskBtnProxy gotoBtnProxy = this.GotoBtnProxy;
			if (gotoBtnProxy != null)
			{
				gotoBtnProxy.SetClickFunction(new Action(this.OnGotoBtnClick));
			}
			AreaTaskBtnProxy gotoBtnProxy2 = this.GotoBtnProxy;
			if (gotoBtnProxy2 != null)
			{
				gotoBtnProxy2.SetTextById("RealmBetweenEnterName_Text", Array.Empty<object>());
			}
			base.SetButtonUiActive(6, value2);
			base.SetButtonUiActive(5, flag2);
			base.GetItem(4).SetUIActive(value.JumpId == 0 && !flag && !flag2);
		}

		// Token: 0x06040D3A RID: 265530 RVA: 0x0109FC74 File Offset: 0x0109DE74
		private void RefreshAsLockGuide(int jumpId, string hintText)
		{
			base.GetText(0).SetUIActive(true);
			base.GetText(1).SetUIActive(false);
			base.GetScrollViewWithScrollbar(2).RootUIComp.Get().SetUIActive(false);
			base.GetItem(4).SetUIActive(false);
			base.GetItem(7).SetUIActive(false);
			base.SetButtonUiActive(5, false);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), hintText, Array.Empty<object>());
			AreaTaskBtnProxy gotoBtnProxy = this.GotoBtnProxy;
			if (gotoBtnProxy != null)
			{
				gotoBtnProxy.SetClickFunction(delegate
				{
					if (jumpId > 0)
					{
						SkipTaskManager.RunByConfigId(jumpId, null);
					}
				});
			}
			AreaTaskBtnProxy gotoBtnProxy2 = this.GotoBtnProxy;
			if (gotoBtnProxy2 != null)
			{
				gotoBtnProxy2.SetTextById("RealmBetweenEnterName_Text", Array.Empty<object>());
			}
			base.SetButtonUiActive(6, jumpId > 0);
		}

		// Token: 0x06040D3B RID: 265531 RVA: 0x0109FD43 File Offset: 0x0109DF43
		[NullableContext(2)]
		public UUIItem GetFirstUiItem()
		{
			return this.RootItem;
		}

		// Token: 0x06040D3C RID: 265532 RVA: 0x0109FD4B File Offset: 0x0109DF4B
		private ActivitySmallItemGrid InitRewardItem()
		{
			return new ActivitySmallItemGrid();
		}

		// Token: 0x06040D3D RID: 265533 RVA: 0x0109FD54 File Offset: 0x0109DF54
		private void InitGotoBtnProxy()
		{
			AActor owner = base.GetButton(6).GetOwner();
			if (this.GotoBtnProxy == null)
			{
				this.GotoBtnProxy = new AreaTaskBtnProxy();
				this.GotoBtnProxy.CreateThenShowByActor(owner, null);
			}
			this.GotoBtnProxy.SetClickFunction(new Action(this.OnGotoBtnClick));
			this.GotoBtnProxy.SetTextById("RealmBetweenEnterName_Text", Array.Empty<object>());
		}

		// Token: 0x06040D3E RID: 265534 RVA: 0x0109FDBC File Offset: 0x0109DFBC
		private void InitRewardBtnProxy()
		{
			AActor owner = base.GetButton(5).GetOwner();
			if (this.RewardBtnProxy == null)
			{
				this.RewardBtnProxy = new AreaTaskBtnProxy();
				this.RewardBtnProxy.CreateThenShowByActor(owner, null);
			}
			this.RewardBtnProxy.SetClickFunction(new Action(this.OnRewardBtnClick));
			this.RewardBtnProxy.SetTextById("RealmBetweenGetReward_Text", Array.Empty<object>());
		}

		// Token: 0x06040D3F RID: 265535 RVA: 0x0109FE24 File Offset: 0x0109E024
		private void RefreshRewardData(int rewardId)
		{
			List<IItemGridData> list = new List<IItemGridData>();
			foreach (TItem item in ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(rewardId))
			{
				ItemGridData item2 = new ItemGridData
				{
					Item = item,
					HasClaimed = (this.TaskData.Status == EActivityTaskState.FinishedAndClaimed)
				};
				list.Add(item2);
			}
			this.RewardScrollView.RefreshByData(list, null, false);
		}

		// Token: 0x06040D40 RID: 265536 RVA: 0x0109FEB4 File Offset: 0x0109E0B4
		private void OnGotoBtnClick()
		{
			RealmBetweenTask value = ConfigBase<ActivityRealmBetweenConfig>.Instance.GetRealmBetweenTaskConfig(this.TaskData.Id).Value;
			if (value.JumpId != 0)
			{
				SkipTaskManager.RunByConfigId(value.JumpId, null);
			}
		}

		// Token: 0x06040D41 RID: 265537 RVA: 0x0109FEF8 File Offset: 0x0109E0F8
		private void OnRewardBtnClick()
		{
			if (this.CurrentAreaId <= 0)
			{
				return;
			}
			List<ActivityTaskData> areaTaskDataList = this.ActivityBaseData.GetAreaTaskDataList(this.CurrentAreaId);
			List<int> list = new List<int>();
			foreach (ActivityTaskData activityTaskData in areaTaskDataList)
			{
				if (activityTaskData.Status == EActivityTaskState.FinishedAndUnclaimed)
				{
					list.Add(activityTaskData.Id);
				}
			}
			if (list.Count > 0)
			{
				ControllerBase<ActivityRealmBetweenController>.Instance.RequestMultiRealmBetweenTaskReward(list.ToArray());
			}
		}

		// Token: 0x06040D42 RID: 265538 RVA: 0x0109FF8C File Offset: 0x0109E18C
		protected override void OnBeforeDestroy()
		{
			this.RewardScrollView = null;
		}

		// Token: 0x040245F4 RID: 148980
		private int CurrentAreaId;

		// Token: 0x040245F5 RID: 148981
		private ActivityTaskData TaskData;

		// Token: 0x040245F6 RID: 148982
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<ActivitySmallItemGrid, IItemGridData> RewardScrollView;

		// Token: 0x040245F7 RID: 148983
		protected ActivityRealmBetweenData ActivityBaseData;

		// Token: 0x040245F8 RID: 148984
		[Nullable(2)]
		private AreaTaskBtnProxy GotoBtnProxy;

		// Token: 0x040245F9 RID: 148985
		[Nullable(2)]
		private AreaTaskBtnProxy RewardBtnProxy;
	}
}
