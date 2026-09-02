using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FFA RID: 24570
	[NullableContext(1)]
	[Nullable(0)]
	public class BuffItemSimpleContainer
	{
		// Token: 0x0603DE10 RID: 253456 RVA: 0x00FC770C File Offset: 0x00FC590C
		public void Init(UUIItem buffParentItem, int maxItemCount = 6, bool isSmallContainer = false)
		{
			this.BuffParentItem = buffParentItem;
			this.MaxItemCount = maxItemCount;
			this.IsSmallContainer = isSmallContainer;
		}

		// Token: 0x0603DE11 RID: 253457 RVA: 0x00FC7724 File Offset: 0x00FC5924
		public void Tick(float delta)
		{
			int frame = Singleton<Time>.Instance.Frame;
			if (frame < this.NextTickFrame)
			{
				return;
			}
			if (this.BuffItemInfoList.Count > 6)
			{
				this.NextTickFrame = frame + 2;
			}
			foreach (BuffItemInfo buffItemInfo in this.BuffItemInfoList)
			{
				BuffItemBase buffItem = buffItemInfo.BuffItem;
				if (buffItem == null)
				{
					break;
				}
				buffItem.Tick(delta);
			}
			for (int i = this.HidingBuffItemList.Count - 1; i >= 0; i--)
			{
				BuffItemBase buffItemBase = this.HidingBuffItemList[i];
				if (!buffItemBase.TickHiding(delta))
				{
					this.HidingBuffItemList.RemoveAt(i);
					buffItemBase.GetRootItem().SetHierarchyIndex(this.BuffItemInfoList.Count + this.HidingBuffItemList.Count);
					this.HiddenBuffItemPool.RecycleBuffItem(buffItemBase);
				}
			}
		}

		// Token: 0x0603DE12 RID: 253458 RVA: 0x00FC781C File Offset: 0x00FC5A1C
		public void RefreshBuff(List<long> buffIds)
		{
			this.ClearAll();
			foreach (long buffId in buffIds)
			{
				this.AddBuffByBuffId(buffId);
			}
		}

		// Token: 0x0603DE13 RID: 253459 RVA: 0x00FC7870 File Offset: 0x00FC5A70
		public void AddBuffByBuffId(long buffId)
		{
			BuffDefinition buffDefinition = ControllerBase<BuffController>.Instance.GetBuffDefinition(buffId, null);
			if (((buffDefinition != null) ? buffDefinition.GameplayCueIds : null) == null)
			{
				return;
			}
			long[] gameplayCueIds = buffDefinition.GameplayCueIds;
			for (int i = 0; i < gameplayCueIds.Length; i++)
			{
				GameplayCue? configById = GameplayCueController.GetConfigById(gameplayCueIds[i]);
				if (configById != null)
				{
					GameplayCue value = configById.Value;
					this.AddBuffByCue(value, buffId, false);
				}
			}
		}

		// Token: 0x0603DE14 RID: 253460 RVA: 0x00FC78D4 File Offset: 0x00FC5AD4
		public void AddBuffByCue(in GameplayCue buffCueConfig, long handleId, bool playAnim = false)
		{
			if (!this.CheckCanShow(buffCueConfig))
			{
				return;
			}
			GameplayCue gameplayCue = buffCueConfig;
			long id = gameplayCue.Id;
			BuffItemInfo buffItemInfo;
			if (this.StateBuffItemInfoMap.TryGetValue(id, out buffItemInfo))
			{
				buffItemInfo.BuffHandleSet.Add(handleId);
				return;
			}
			buffItemInfo = this.NewBuffItemInfo(buffCueConfig);
			buffItemInfo.BuffHandleSet.Add(handleId);
			this.StateBuffItemInfoMap[id] = buffItemInfo;
			this.AddBuffItemInfo(buffItemInfo, playAnim);
		}

		// Token: 0x0603DE15 RID: 253461 RVA: 0x00FC794C File Offset: 0x00FC5B4C
		private bool CheckCanShow(GameplayCue buffCueConfig)
		{
			return !this.IsSmallContainer || buffCueConfig.ParametersLength <= 4 || !(buffCueConfig.Parameters(4) == "1");
		}

		// Token: 0x0603DE16 RID: 253462 RVA: 0x00FC7978 File Offset: 0x00FC5B78
		public void RemoveBuffByBuffId(long buffId)
		{
			BuffDefinition buffDefinition = ControllerBase<BuffController>.Instance.GetBuffDefinition(buffId, null);
			if (((buffDefinition != null) ? buffDefinition.GameplayCueIds : null) == null)
			{
				return;
			}
			long[] gameplayCueIds = buffDefinition.GameplayCueIds;
			for (int i = 0; i < gameplayCueIds.Length; i++)
			{
				GameplayCue? configById = GameplayCueController.GetConfigById(gameplayCueIds[i]);
				if (configById != null)
				{
					this.RemoveBuffByCue(configById.Value, buffId, false);
				}
			}
		}

		// Token: 0x0603DE17 RID: 253463 RVA: 0x00FC79D8 File Offset: 0x00FC5BD8
		public void RemoveBuffByCue(GameplayCue buffCueConfig, long handleId, bool playAnim = false)
		{
			long id = buffCueConfig.Id;
			BuffItemInfo buffItemInfo;
			if (!this.StateBuffItemInfoMap.TryGetValue(id, out buffItemInfo))
			{
				return;
			}
			if (!buffItemInfo.BuffHandleSet.Contains(handleId))
			{
				return;
			}
			buffItemInfo.BuffHandleSet.Remove(handleId);
			if (buffItemInfo.BuffHandleSet.Count <= 0)
			{
				this.StateBuffItemInfoMap.Remove(id);
				this.RemoveBuffItemInfo(buffItemInfo, playAnim);
			}
		}

		// Token: 0x0603DE18 RID: 253464 RVA: 0x00FC7A40 File Offset: 0x00FC5C40
		private BuffItemInfo NewBuffItemInfo(GameplayCue buffCueConfig)
		{
			BuffItemInfo buffItemInfo = (this.BuffItemInfoPool.Count > 0) ? this.BuffItemInfoPool.Pop<BuffItemInfo>() : new BuffItemInfo();
			buffItemInfo.SortId = BuffItemInfo.GenSortId();
			buffItemInfo.Priority = buffCueConfig.Priority;
			buffItemInfo.BuffCueConfig = new GameplayCue?(buffCueConfig);
			return buffItemInfo;
		}

		// Token: 0x0603DE19 RID: 253465 RVA: 0x00FC7A91 File Offset: 0x00FC5C91
		private void RecycleBuffItemInfo(BuffItemInfo buffItemInfo)
		{
			buffItemInfo.Clear();
			this.BuffItemInfoPool.Add(buffItemInfo);
		}

		// Token: 0x0603DE1A RID: 253466 RVA: 0x00FC7AA8 File Offset: 0x00FC5CA8
		private void AddBuffItemInfo(BuffItemInfo buffItemInfo, bool playAnim = false)
		{
			int num = this.InsertBuffItemInfo(buffItemInfo);
			if (num < this.MaxItemCount)
			{
				if (this.BuffItemInfoList.Count > this.MaxItemCount)
				{
					this.DeactivateBuffItem(this.BuffItemInfoList[this.MaxItemCount], false);
				}
				buffItemInfo.BuffItem = this.NewBuffItem(buffItemInfo.BuffCueConfig);
				this.ActivateBuffItem(buffItemInfo, num, playAnim);
			}
		}

		// Token: 0x0603DE1B RID: 253467 RVA: 0x00FC7B0C File Offset: 0x00FC5D0C
		private int InsertBuffItemInfo(BuffItemInfo newInfo)
		{
			int count = this.BuffItemInfoList.Count;
			for (int i = 0; i < count; i++)
			{
				if (BuffItemInfo.Compare(this.BuffItemInfoList[i], newInfo) >= 0)
				{
					this.BuffItemInfoList.Insert(i, newInfo);
					return i;
				}
			}
			this.BuffItemInfoList.Add(newInfo);
			return count;
		}

		// Token: 0x0603DE1C RID: 253468 RVA: 0x00FC7B64 File Offset: 0x00FC5D64
		private void RemoveBuffItemInfo(BuffItemInfo buffItemInfo, bool playAnim = false)
		{
			int num = this.BuffItemInfoList.IndexOf(buffItemInfo);
			if (num < 0)
			{
				return;
			}
			this.BuffItemInfoList.RemoveAt(num);
			if (num < this.MaxItemCount)
			{
				this.DeactivateBuffItem(buffItemInfo, playAnim);
				if (this.BuffItemInfoList.Count >= this.MaxItemCount)
				{
					BuffItemInfo buffItemInfo2 = this.BuffItemInfoList[this.MaxItemCount - 1];
					if (buffItemInfo2.BuffItem != null)
					{
						Log instance = Singleton<Log>.Instance;
						ELogModule module = ELogModule.Battle;
						ELogAuthor author = ELogAuthor.CFT;
						string message = "有残留的buffItem引用";
						string item = "cueId";
						BuffItemInfo buffItemInfo3 = buffItemInfo2;
						ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item, (buffItemInfo3.BuffCueConfig != null) ? new long?(buffItemInfo3.BuffCueConfig.GetValueOrDefault().Id) : null);
						instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					}
					buffItemInfo2.BuffItem = this.NewBuffItem(buffItemInfo2.BuffCueConfig);
					this.ActivateBuffItem(buffItemInfo2, this.MaxItemCount - 1, false);
				}
			}
			this.RecycleBuffItemInfo(buffItemInfo);
		}

		// Token: 0x0603DE1D RID: 253469 RVA: 0x00FC7C56 File Offset: 0x00FC5E56
		private BuffItemBase NewBuffItem(GameplayCue? cueConfig)
		{
			return this.HiddenBuffItemPool.GetBuffItem(this.BuffParentItem, cueConfig);
		}

		// Token: 0x0603DE1E RID: 253470 RVA: 0x00FC7C6C File Offset: 0x00FC5E6C
		private void ActivateBuffItem(BuffItemInfo buffItemInfo, int index, bool playAnim = false)
		{
			BuffItemBase buffItem = buffItemInfo.BuffItem;
			buffItem.Activate(buffItemInfo.BuffCueConfig.Value, buffItemInfo.SingleBuff, playAnim, 0);
			if (index <= 0)
			{
				buffItem.GetRootItem().SetHierarchyIndex(0);
				return;
			}
			BuffItemBase buffItem2 = this.BuffItemInfoList[index - 1].BuffItem;
			if (buffItem2 != null)
			{
				buffItem.GetRootItem().SetHierarchyIndex(buffItem2.GetRootItem().GetHierarchyIndex() + 1);
				return;
			}
			Singleton<Log>.Instance.Error(ELogModule.Battle, ELogAuthor.CFT, "要插入的buff图标前面的buff没有buffItem", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x0603DE1F RID: 253471 RVA: 0x00FC7CF8 File Offset: 0x00FC5EF8
		public void DeactivateBuffItem(BuffItemInfo buffItemInfo, bool playAnim = false)
		{
			BuffItemBase buffItem = buffItemInfo.BuffItem;
			if (buffItem == null)
			{
				return;
			}
			buffItemInfo.BuffItem = null;
			if (playAnim)
			{
				buffItem.DeactivateWithCloseAnim();
				this.HidingBuffItemList.Add(buffItem);
				return;
			}
			buffItem.Deactivate();
			buffItem.GetRootItem().SetHierarchyIndex(this.BuffItemInfoList.Count + this.HidingBuffItemList.Count);
			this.HiddenBuffItemPool.RecycleBuffItem(buffItem);
		}

		// Token: 0x0603DE20 RID: 253472 RVA: 0x00FC7D64 File Offset: 0x00FC5F64
		public void ClearAll()
		{
			foreach (BuffItemInfo buffItemInfo in this.BuffItemInfoList)
			{
				BuffItemBase buffItem = buffItemInfo.BuffItem;
				if (buffItem != null)
				{
					buffItem.DestroyCompatible();
				}
			}
			this.BuffItemInfoList.Clear();
			this.StateBuffItemInfoMap.Clear();
			this.BuffItemInfoPool.Clear();
			foreach (BuffItemBase buffItemBase in this.HidingBuffItemList)
			{
				buffItemBase.Deactivate();
				buffItemBase.DestroyCompatible();
			}
			this.HidingBuffItemList.Clear();
			this.HiddenBuffItemPool.Clear();
			this.NextTickFrame = 0;
		}

		// Token: 0x04022B54 RID: 142164
		private const int MAX_ITEM_COUNT = 6;

		// Token: 0x04022B55 RID: 142165
		private const int TICK_INTERVAL_FRAME_AT_MORE = 2;

		// Token: 0x04022B56 RID: 142166
		private readonly List<BuffItemInfo> BuffItemInfoList = new List<BuffItemInfo>();

		// Token: 0x04022B57 RID: 142167
		private readonly Dictionary<long, BuffItemInfo> StateBuffItemInfoMap = new Dictionary<long, BuffItemInfo>();

		// Token: 0x04022B58 RID: 142168
		private readonly List<BuffItemInfo> BuffItemInfoPool = new List<BuffItemInfo>();

		// Token: 0x04022B59 RID: 142169
		private readonly List<BuffItemBase> HidingBuffItemList = new List<BuffItemBase>();

		// Token: 0x04022B5A RID: 142170
		private readonly BuffItemPool HiddenBuffItemPool = new BuffItemPool();

		// Token: 0x04022B5B RID: 142171
		[Nullable(2)]
		private UUIItem BuffParentItem;

		// Token: 0x04022B5C RID: 142172
		private int MaxItemCount;

		// Token: 0x04022B5D RID: 142173
		private bool IsSmallContainer;

		// Token: 0x04022B5E RID: 142174
		private int NextTickFrame;
	}
}
