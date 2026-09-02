using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Area;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RoadBook
{
	// Token: 0x020064B7 RID: 25783
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class AreaLayout : GridProxyAbstract<AreaLayoutItemData>, IDynamicScrollItem<AreaLayoutItemData>
	{
		// Token: 0x060409DD RID: 264669 RVA: 0x01090610 File Offset: 0x0108E810
		public AreaLayout(ActivityRoadBookData activityBaseData)
		{
			this.ActivityBaseData = activityBaseData;
		}

		// Token: 0x060409DE RID: 264670 RVA: 0x01090620 File Offset: 0x0108E820
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUITexture))
			};
		}

		// Token: 0x060409DF RID: 264671 RVA: 0x010906E8 File Offset: 0x0108E8E8
		public UniTask Init(UUIItem actor)
		{
			AreaLayout.<Init>d__8 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.actor = actor;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<AreaLayout.<Init>d__8>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x060409E0 RID: 264672 RVA: 0x01090733 File Offset: 0x0108E933
		public void Update(AreaLayoutItemData data, int index)
		{
			this.Refresh(data, false, index);
		}

		// Token: 0x060409E1 RID: 264673 RVA: 0x0109073E File Offset: 0x0108E93E
		public override void Refresh(AreaLayoutItemData data, bool isSelected, int gridIndex)
		{
			this.AreaData = data.AreaData;
			if (data.IsTitle)
			{
				this.RefreshTitle(data.AreaData);
				return;
			}
			this.RefreshTask(data.TaskData);
		}

		// Token: 0x060409E2 RID: 264674 RVA: 0x01090770 File Offset: 0x0108E970
		private void RefreshTitle(RoadBookAreaData areaData)
		{
			Area value = ConfigBase<AreaConfig>.Instance.GetAreaInfo(areaData.AreaId).Value;
			base.GetItem(4).SetUIActive(true);
			base.GetVerticalLayout(1).RootUIComp.Get().SetUIActive(false);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), value.Title, Array.Empty<object>());
			bool uiactive = true;
			foreach (int key in areaData.TravelTaskIdSet)
			{
				ActivityTaskData activityTaskData;
				if (this.ActivityBaseData.AreaTaskMap.TryGetValue(key, out activityTaskData) && activityTaskData.Status != EActivityTaskState.FinishedAndClaimed)
				{
					uiactive = false;
					break;
				}
			}
			UUIItem text = base.GetText(0);
			bool bUseChangeColor = !areaData.IsUnlock;
			FColor? fcolor = new FColor?(base.GetText(0).changeColor);
			text.SetChangeColor(bUseChangeColor, fcolor);
			UUIItem texture = base.GetTexture(7);
			bool bUseChangeColor2 = !areaData.IsUnlock;
			fcolor = new FColor?(base.GetTexture(7).changeColor);
			texture.SetChangeColor(bUseChangeColor2, fcolor);
			base.GetItem(3).SetUIActive(!areaData.IsUnlock);
			base.GetItem(6).SetUIActive(uiactive);
			if (!areaData.IsUnlock)
			{
				RoadBookLockAreaData roadBookLockAreaData = new RoadBookLockAreaData(areaData.AreaId);
				RoadBookArea value2 = ConfigBase<ActivityRoadBookConfig>.Instance.GetAreaConfig(areaData.AreaId).Value;
				roadBookLockAreaData.ConditionGroupId = value2.UnLockCondition;
				roadBookLockAreaData.JumpId = value2.UnlockAccessId;
				this.LockItem.Refresh(roadBookLockAreaData, false, 0);
			}
		}

		// Token: 0x060409E3 RID: 264675 RVA: 0x01090914 File Offset: 0x0108EB14
		private void RefreshTask(ActivityTaskData taskData)
		{
			base.GetItem(4).SetUIActive(false);
			base.GetVerticalLayout(1).RootUIComp.Get().SetUIActive(true);
			this.NormalItem.Refresh(taskData, false, 0);
		}

		// Token: 0x060409E4 RID: 264676 RVA: 0x01090958 File Offset: 0x0108EB58
		public void PlayUnlockAnim()
		{
			this.LevelSequencePlayer.PlayLevelSequenceByName("Unlock", true, null, false);
		}

		// Token: 0x060409E5 RID: 264677 RVA: 0x01090980 File Offset: 0x0108EB80
		[NullableContext(2)]
		public UUIItem GetFirstItem()
		{
			return this.TaskLayout.GetItemByIndex(0);
		}

		// Token: 0x060409E6 RID: 264678 RVA: 0x0109098E File Offset: 0x0108EB8E
		[return: Nullable(2)]
		public AUIBaseActor GetUsingItem(AreaLayoutItemData data)
		{
			if (data.IsTitle)
			{
				return base.GetItem(4).GetOwner() as AUIBaseActor;
			}
			return base.GetRootItem().GetOwner() as AUIBaseActor;
		}

		// Token: 0x060409E7 RID: 264679 RVA: 0x010909BA File Offset: 0x0108EBBA
		public void ClearItem()
		{
		}

		// Token: 0x060409E8 RID: 264680 RVA: 0x010909BC File Offset: 0x0108EBBC
		protected override void OnBeforeDestroy()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.Clear();
			}
			this.LevelSequencePlayer = null;
			this.LockItem = null;
			this.NormalItem = null;
			this.AreaData = null;
		}

		// Token: 0x040242F6 RID: 148214
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		protected GenericLayout<RoadBookTaskNormalItem, ActivityTaskData> TaskLayout;

		// Token: 0x040242F7 RID: 148215
		[Nullable(2)]
		protected LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x040242F8 RID: 148216
		[Nullable(2)]
		private RoadBookTaskLockItem LockItem;

		// Token: 0x040242F9 RID: 148217
		[Nullable(2)]
		private RoadBookTaskNormalItem NormalItem;

		// Token: 0x040242FA RID: 148218
		[Nullable(2)]
		private RoadBookAreaData AreaData;

		// Token: 0x040242FB RID: 148219
		protected ActivityRoadBookData ActivityBaseData;
	}
}
