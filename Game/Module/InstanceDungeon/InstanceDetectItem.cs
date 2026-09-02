using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.AdventureGuide;
using CSharpScript.Game.Module.InstanceDungeon.Define;
using CSharpScript.Game.Module.InstanceDungeon.InstanceDungeonViewModel;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.InstanceDungeon
{
	// Token: 0x02005BAF RID: 23471
	[NullableContext(2)]
	[Nullable(0)]
	public class InstanceDetectItem : UiPanelBase, IDynamicScrollItem<InstanceDetectionDynamicData>
	{
		// Token: 0x0603B5FD RID: 243197 RVA: 0x00F0A1F0 File Offset: 0x00F083F0
		[NullableContext(1)]
		public UniTask Init(UUIItem actor)
		{
			InstanceDetectItem.<Init>d__14 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.actor = actor;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<InstanceDetectItem.<Init>d__14>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x0603B5FE RID: 243198 RVA: 0x00F0A23C File Offset: 0x00F0843C
		protected unsafe override void OnRegisterComponent()
		{
			this.ParentModel = (this.OpenParam as InstanceDungeonViewModelBase);
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603B5FF RID: 243199 RVA: 0x00F0A31C File Offset: 0x00F0851C
		private UniTask InitChildItem()
		{
			InstanceDetectItem.<InitChildItem>d__16 <InitChildItem>d__;
			<InitChildItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitChildItem>d__.<>4__this = this;
			<InitChildItem>d__.<>1__state = -1;
			<InitChildItem>d__.<>t__builder.Start<InstanceDetectItem.<InitChildItem>d__16>(ref <InitChildItem>d__);
			return <InitChildItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603B600 RID: 243200 RVA: 0x00F0A360 File Offset: 0x00F08560
		[NullableContext(1)]
		public AUIBaseActor GetUsingItem(InstanceDetectionDynamicData data)
		{
			if (data.ExtraType == EInstanceDetectionExtraType.TextOnly)
			{
				return base.GetText(4).GetOwner() as AUIBaseActor;
			}
			bool flag = !ControllerBase<InstanceDungeonEntranceController>.Instance.GetInstanceItemLockStateGetter(data.InstanceGirdId);
			if (data.InstanceSeriesTitle != 0)
			{
				return (flag ? base.GetItem(0) : base.GetItem(2)).GetOwner() as AUIBaseActor;
			}
			return (flag ? base.GetItem(1) : base.GetItem(3)).GetOwner() as AUIBaseActor;
		}

		// Token: 0x0603B601 RID: 243201 RVA: 0x00F0A3E0 File Offset: 0x00F085E0
		[NullableContext(1)]
		public void Update(InstanceDetectionDynamicData data, int index)
		{
			this.Data = data;
			if (this.UpdateExtraType(data))
			{
				return;
			}
			this.BindAllInstanceDetectGetter(data.InstanceGirdId);
			bool instanceItemLockStateGetter = ControllerBase<InstanceDungeonEntranceController>.Instance.GetInstanceItemLockStateGetter(data.InstanceGirdId);
			InstanceSeriesItem instanceSeriesItem = this.InstanceSeriesItem;
			InstanceItem instanceItem = this.InstanceItem;
			this.InstanceSeriesItem.SetUiActive(!instanceItemLockStateGetter);
			this.InstanceItem.SetUiActive(!instanceItemLockStateGetter);
			this.LockInstanceSeriesItem.SetUiActive(instanceItemLockStateGetter);
			this.LockInstanceItem.SetUiActive(instanceItemLockStateGetter);
			if (instanceItemLockStateGetter)
			{
				instanceItem = this.LockInstanceItem;
				instanceSeriesItem = this.LockInstanceSeriesItem;
			}
			if (data.InstanceSeriesTitle == 0)
			{
				instanceSeriesItem.SetUiActive(false);
				instanceItem.SetUiActive(true);
				instanceItem.BindClickCallback(this.OnInstanceCallback);
				instanceItem.BindCanExecuteChange(this.InstanceCanExecuteChange);
				instanceItem.Update(data.InstanceGirdId, data.IsSelect, data.IsShow);
				return;
			}
			instanceItem.SetUiActive(false);
			instanceSeriesItem.SetUiActive(true);
			instanceSeriesItem.CurrentData = data;
			instanceSeriesItem.BindCanShowRedDot(this.CanShowRedDot);
			if (instanceSeriesItem != null)
			{
				this.UpdateInstanceSeriesItemGetter(instanceSeriesItem, data.InstanceGirdId);
			}
			if (this.InstanceIconRightPathGetter != null)
			{
				instanceSeriesItem.IconRightPath = this.InstanceIconRightPathGetter(data.InstanceGirdId);
			}
			if (!data.IsOnlyOneGrid)
			{
				instanceSeriesItem.BindClickCallback(this.OnSeriesCallback);
				instanceSeriesItem.Update(data.InstanceSeriesTitle, data.IsSelect, false);
				return;
			}
			instanceSeriesItem.BindClickCallbackOnlyOneGrid(this.OnInstanceCallback);
			instanceSeriesItem.Update(data.InstanceGirdId, data.IsSelect, true);
		}

		// Token: 0x0603B602 RID: 243202 RVA: 0x00F0A554 File Offset: 0x00F08754
		[NullableContext(1)]
		private bool UpdateExtraType(InstanceDetectionDynamicData data)
		{
			if (data.ExtraType == EInstanceDetectionExtraType.None)
			{
				return false;
			}
			if (data.ExtraType == EInstanceDetectionExtraType.TextOnly)
			{
				this.InstanceSeriesItem.SetUiActive(false);
				this.InstanceItem.SetUiActive(false);
				this.LockInstanceSeriesItem.SetUiActive(false);
				this.LockInstanceItem.SetUiActive(false);
				UUIText text = base.GetText(4);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, data.ExtraText, Array.Empty<object>());
				text.SetUIActive(true);
			}
			return true;
		}

		// Token: 0x0603B603 RID: 243203 RVA: 0x00F0A5CC File Offset: 0x00F087CC
		public void UpdateSelf()
		{
			InstanceDetectionDynamicData data = this.Data;
			bool instanceItemLockStateGetter = ControllerBase<InstanceDungeonEntranceController>.Instance.GetInstanceItemLockStateGetter(data.InstanceGirdId);
			InstanceSeriesItem instanceSeriesItem = this.InstanceSeriesItem;
			if (instanceSeriesItem != null)
			{
				instanceSeriesItem.SetUiActive(!instanceItemLockStateGetter);
			}
			InstanceSeriesItem lockInstanceSeriesItem = this.LockInstanceSeriesItem;
			if (lockInstanceSeriesItem != null)
			{
				lockInstanceSeriesItem.SetUiActive(instanceItemLockStateGetter);
			}
			InstanceSeriesItem instanceSeriesItem2 = this.InstanceSeriesItem;
			if (instanceItemLockStateGetter)
			{
				instanceSeriesItem2 = this.LockInstanceSeriesItem;
			}
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(data.InstanceGirdId);
			Singleton<LguiUtil>.Instance.SetLocalTextNew((instanceSeriesItem2 != null) ? instanceSeriesItem2.GetTitleText() : null, config.Value.MapName, Array.Empty<object>());
			if (instanceSeriesItem2 != null)
			{
				this.UpdateInstanceSeriesItemGetter(instanceSeriesItem2, data.InstanceGirdId);
			}
			instanceSeriesItem2.RefreshSubtitleByIdAndArgs();
		}

		// Token: 0x0603B604 RID: 243204 RVA: 0x00F0A67C File Offset: 0x00F0887C
		private void BindAllInstanceDetectGetter(int instanceId)
		{
			InstanceDetectItemGetterData instanceDetectItemGetterData = null;
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId);
			if (config != null)
			{
				EDungeonSubType instSubType = (EDungeonSubType)config.Value.InstSubType;
				InstanceDungeonMapDefine.InstanceDetectItemGetterDataMap.TryGetValue(instSubType, out instanceDetectItemGetterData);
			}
			this.BindSubtitleTextIdGetter((instanceDetectItemGetterData != null) ? instanceDetectItemGetterData.SubtitleTextIdGetter : null);
			this.BindSubtitleArgsGetter((instanceDetectItemGetterData != null) ? instanceDetectItemGetterData.SubtitleArgsGetter : null);
			this.BindInstanceCheckFinishedGetter((instanceDetectItemGetterData != null) ? instanceDetectItemGetterData.CheckFinishedGetter : null);
		}

		// Token: 0x0603B605 RID: 243205 RVA: 0x00F0A6F4 File Offset: 0x00F088F4
		[NullableContext(1)]
		private void UpdateInstanceSeriesItemGetter(InstanceSeriesItem instanceSeriesItem, int instanceId)
		{
			TInstanceSubtitleTextIdGetter instanceSubtitleTextIdGetter = this.InstanceSubtitleTextIdGetter;
			instanceSeriesItem.SubtitleTextId = ((instanceSubtitleTextIdGetter != null) ? instanceSubtitleTextIdGetter(instanceId) : null);
			TInstanceSubtitleArgsGetter instanceSubtitleArgsGetter = this.InstanceSubtitleArgsGetter;
			instanceSeriesItem.SubtitleTextArgs = ((instanceSubtitleArgsGetter != null) ? instanceSubtitleArgsGetter(instanceId) : null);
			instanceSeriesItem.RefreshSubtitleByIdAndArgs();
			instanceSeriesItem.HasOverrideFinishState = (this.InstanceCheckFinishedGetter != null);
			if (this.InstanceCheckFinishedGetter != null)
			{
				instanceSeriesItem.OverrideFinishState = this.InstanceCheckFinishedGetter(instanceId);
			}
		}

		// Token: 0x0603B606 RID: 243206 RVA: 0x00F0A764 File Offset: 0x00F08964
		[NullableContext(1)]
		public void UpdateSelfByText(string text)
		{
			InstanceDetectionDynamicData data = this.Data;
			bool instanceItemLockStateGetter = ControllerBase<InstanceDungeonEntranceController>.Instance.GetInstanceItemLockStateGetter(data.InstanceGirdId);
			InstanceSeriesItem instanceSeriesItem = this.InstanceSeriesItem;
			if (instanceSeriesItem != null)
			{
				instanceSeriesItem.SetUiActive(!instanceItemLockStateGetter);
			}
			InstanceSeriesItem lockInstanceSeriesItem = this.LockInstanceSeriesItem;
			if (lockInstanceSeriesItem != null)
			{
				lockInstanceSeriesItem.SetUiActive(instanceItemLockStateGetter);
			}
			if (instanceItemLockStateGetter)
			{
				InstanceSeriesItem lockInstanceSeriesItem2 = this.LockInstanceSeriesItem;
				if (lockInstanceSeriesItem2 == null)
				{
					return;
				}
				lockInstanceSeriesItem2.UpdateSubtitleByText(text);
			}
		}

		// Token: 0x0603B607 RID: 243207 RVA: 0x00F0A7C4 File Offset: 0x00F089C4
		[NullableContext(1)]
		public UUIText GetActiveNameText()
		{
			if (this.InstanceSeriesItem.IsUiActiveInHierarchy())
			{
				return this.InstanceSeriesItem.GetTitleText();
			}
			if (this.InstanceItem.IsUiActiveInHierarchy())
			{
				return this.InstanceItem.GetTitleText();
			}
			if (this.LockInstanceSeriesItem.IsUiActiveInHierarchy())
			{
				return this.LockInstanceSeriesItem.GetTitleText();
			}
			return this.LockInstanceItem.GetTitleText();
		}

		// Token: 0x0603B608 RID: 243208 RVA: 0x00F0A827 File Offset: 0x00F08A27
		[NullableContext(1)]
		public void BindClickSeriesCallback(Action<int, UUIExtendToggle, bool> onClickCallback)
		{
			this.OnSeriesCallback = onClickCallback;
		}

		// Token: 0x0603B609 RID: 243209 RVA: 0x00F0A830 File Offset: 0x00F08A30
		public void BindClickInstanceCallback([Nullable(new byte[]
		{
			1,
			1,
			2
		})] Action<int, UUIExtendToggle, InstanceDetectionDynamicData> onClickCallback)
		{
			this.OnInstanceCallback = onClickCallback;
		}

		// Token: 0x0603B60A RID: 243210 RVA: 0x00F0A839 File Offset: 0x00F08A39
		[NullableContext(1)]
		public void BindCanExecuteChange(Func<int, bool> canExecuteChange)
		{
			this.InstanceCanExecuteChange = canExecuteChange;
		}

		// Token: 0x0603B60B RID: 243211 RVA: 0x00F0A842 File Offset: 0x00F08A42
		public void BindSubtitleTextIdGetter(TInstanceSubtitleTextIdGetter getter)
		{
			this.InstanceSubtitleTextIdGetter = getter;
		}

		// Token: 0x0603B60C RID: 243212 RVA: 0x00F0A84B File Offset: 0x00F08A4B
		public void BindSubtitleArgsGetter(TInstanceSubtitleArgsGetter getter)
		{
			this.InstanceSubtitleArgsGetter = getter;
		}

		// Token: 0x0603B60D RID: 243213 RVA: 0x00F0A854 File Offset: 0x00F08A54
		public void BindInstanceCheckFinishedGetter(TInstanceCheckFinishedGetter getter)
		{
			this.InstanceCheckFinishedGetter = getter;
		}

		// Token: 0x0603B60E RID: 243214 RVA: 0x00F0A85D File Offset: 0x00F08A5D
		[NullableContext(1)]
		public void BindCanShowRedDot(Func<int, bool> getter)
		{
			this.CanShowRedDot = getter;
		}

		// Token: 0x0603B60F RID: 243215 RVA: 0x00F0A866 File Offset: 0x00F08A66
		public void BindIconRightPathGetter(Func<int, string> getter)
		{
			this.InstanceIconRightPathGetter = getter;
		}

		// Token: 0x0603B610 RID: 243216 RVA: 0x00F0A86F File Offset: 0x00F08A6F
		public void ClearItem()
		{
			base.Destroy(null);
		}

		// Token: 0x0603B611 RID: 243217 RVA: 0x00F0A878 File Offset: 0x00F08A78
		public UUIExtendToggle GetExtendToggleForGuide()
		{
			if (!this.InstanceItem.GetActive())
			{
				Singleton<Log>.Instance.Warn(ELogModule.Guide, ELogAuthor.TL, "聚焦引导索引到了副本标题, 检查extraParam字段是否配置错误", default(ReadOnlySpan<ValueTuple<string, object>>));
				return null;
			}
			return this.InstanceItem.ExtendToggle;
		}

		// Token: 0x17009773 RID: 38771
		// (get) Token: 0x0603B612 RID: 243218 RVA: 0x00F0A8BB File Offset: 0x00F08ABB
		public int InstanceId
		{
			get
			{
				return this.Data.InstanceGirdId;
			}
		}

		// Token: 0x04021765 RID: 137061
		protected InstanceDetectionDynamicData Data;

		// Token: 0x04021766 RID: 137062
		private InstanceSeriesItem InstanceSeriesItem;

		// Token: 0x04021767 RID: 137063
		private InstanceItem InstanceItem;

		// Token: 0x04021768 RID: 137064
		private InstanceSeriesItem LockInstanceSeriesItem;

		// Token: 0x04021769 RID: 137065
		private InstanceItem LockInstanceItem;

		// Token: 0x0402176A RID: 137066
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<int, UUIExtendToggle, bool> OnSeriesCallback;

		// Token: 0x0402176B RID: 137067
		[Nullable(new byte[]
		{
			2,
			1,
			2
		})]
		private Action<int, UUIExtendToggle, InstanceDetectionDynamicData> OnInstanceCallback;

		// Token: 0x0402176C RID: 137068
		private Func<int, bool> InstanceCanExecuteChange;

		// Token: 0x0402176D RID: 137069
		private TInstanceSubtitleTextIdGetter InstanceSubtitleTextIdGetter;

		// Token: 0x0402176E RID: 137070
		private TInstanceSubtitleArgsGetter InstanceSubtitleArgsGetter;

		// Token: 0x0402176F RID: 137071
		private TInstanceCheckFinishedGetter InstanceCheckFinishedGetter;

		// Token: 0x04021770 RID: 137072
		private Func<int, string> InstanceIconRightPathGetter;

		// Token: 0x04021771 RID: 137073
		private Func<int, bool> CanShowRedDot;

		// Token: 0x04021772 RID: 137074
		private InstanceDungeonViewModelBase ParentModel;
	}
}
