using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063F8 RID: 25592
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class RoverlikeOutsideTabViewBase : UiTabViewBase
	{
		// Token: 0x17009DCF RID: 40399
		// (get) Token: 0x060403FA RID: 263162 RVA: 0x01077B32 File Offset: 0x01075D32
		[Nullable(2)]
		protected RoverlikeActivityData ActivityData
		{
			[NullableContext(2)]
			get
			{
				RoverlikeActivityController instance = ControllerBase<RoverlikeActivityController>.Instance;
				if (instance == null)
				{
					return null;
				}
				return instance.GetCurrentActivityData();
			}
		}

		// Token: 0x17009DD0 RID: 40400
		// (get) Token: 0x060403FB RID: 263163
		[TupleElementNames(new string[]
		{
			"Slot",
			"Type"
		})]
		[Nullable(new byte[]
		{
			1,
			0,
			1
		})]
		protected abstract IReadOnlyList<ValueTuple<EOutsideSlot, Type>> Layout { [return: TupleElementNames(new string[]
		{
			"Slot",
			"Type"
		})] [return: Nullable(new byte[]
		{
			1,
			0,
			1
		})] get; }

		// Token: 0x060403FC RID: 263164 RVA: 0x01077B44 File Offset: 0x01075D44
		protected override void OnRegisterComponent()
		{
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>();
			this.SlotIndexMap.Clear();
			for (int i = 0; i < this.Layout.Count; i++)
			{
				list.Add(new ValueTuple<int, Type>(i, this.Layout[i].Item2));
				this.SlotIndexMap[this.Layout[i].Item1] = i;
			}
			this.ComponentRegisterInfos = (from entry in list
			select new ValueTuple<int, Type>(entry.Item1, entry.Item2)).ToList<ValueTuple<int, Type>>();
		}

		// Token: 0x060403FD RID: 263165 RVA: 0x01077BE4 File Offset: 0x01075DE4
		protected int SlotIndex(EOutsideSlot slot)
		{
			int result;
			if (!this.SlotIndexMap.TryGetValue(slot, out result))
			{
				return -1;
			}
			return result;
		}

		// Token: 0x060403FE RID: 263166 RVA: 0x01077C04 File Offset: 0x01075E04
		[NullableContext(2)]
		protected UUIItem GetSlotItem(EOutsideSlot slot)
		{
			return base.GetItem(this.SlotIndex(slot));
		}

		// Token: 0x060403FF RID: 263167 RVA: 0x01077C14 File Offset: 0x01075E14
		protected override UniTask OnBeforeStartAsync()
		{
			RoverlikeOutsideTabViewBase.<OnBeforeStartAsync>d__16 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoverlikeOutsideTabViewBase.<OnBeforeStartAsync>d__16>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040400 RID: 263168 RVA: 0x01077C57 File Offset: 0x01075E57
		protected override void OnStart()
		{
			this.SetupChromeVisibility();
			this.HideOtherDetailCards();
			if (this.ShouldShowToggle())
			{
				this.SetupToggle();
			}
			if (this.ShouldShowRoleList())
			{
				this.BuildRoleList();
			}
			this.RefreshList();
		}

		// Token: 0x06040401 RID: 263169 RVA: 0x01077C87 File Offset: 0x01075E87
		protected override void OnShowUiTabViewFromToggle()
		{
			if (this.MultiList == null)
			{
				return;
			}
			this.PlaySequence("Start");
			if (this.ShouldShowRoleList())
			{
				this.RefreshRoleListData();
			}
			this.RefreshList();
		}

		// Token: 0x06040402 RID: 263170 RVA: 0x01077CB4 File Offset: 0x01075EB4
		protected override void OnBeforeDestroy()
		{
			if (this.ShouldShowToggle())
			{
				UUIExtendToggle extendToggle = base.GetExtendToggle(this.SlotIndex(EOutsideSlot.ToggleTick));
				if (extendToggle != null)
				{
					extendToggle.OnStateChange.Remove(new Action<EToggleState>(this.OnToggleStateChanged));
				}
			}
			this.MultiList = null;
			this.MultiListAnimController = null;
			this.RoleList = null;
			this.ScrollDataList.Clear();
			this.RoleDataList = new List<RoverlikeOutsideRoleData>();
		}

		// Token: 0x06040403 RID: 263171 RVA: 0x01077D20 File Offset: 0x01075F20
		private void SetupChromeVisibility()
		{
			UUIItem slotItem = this.GetSlotItem(EOutsideSlot.PnlRole);
			if (slotItem != null)
			{
				slotItem.SetUIActive(this.ShouldShowRoleList());
			}
			UUIItem slotItem2 = this.GetSlotItem(EOutsideSlot.PnlToggle);
			if (slotItem2 != null)
			{
				slotItem2.SetUIActive(this.ShouldShowToggle());
			}
			UUIItem slotItem3 = this.GetSlotItem(EOutsideSlot.PnlProgress);
			if (slotItem3 != null)
			{
				slotItem3.SetUIActive(this.ShouldShowCollectProgress());
			}
			this.SetRoleEmptyActive(false);
			UUIItem slotItem4 = this.GetSlotItem(EOutsideSlot.PnlRoleLock);
			if (slotItem4 == null)
			{
				return;
			}
			slotItem4.SetUIActive(false);
		}

		// Token: 0x06040404 RID: 263172 RVA: 0x01077D90 File Offset: 0x01075F90
		private void SetRoleEmptyActive(bool active)
		{
			UUIItem slotItem = this.GetSlotItem(EOutsideSlot.PnlRoleEmpty);
			if (slotItem != null)
			{
				slotItem.SetUIActive(active);
			}
			UUIItem slotItem2 = this.GetSlotItem(EOutsideSlot.PnlRight);
			if (slotItem2 == null)
			{
				return;
			}
			slotItem2.SetUIActive(!active);
		}

		// Token: 0x06040405 RID: 263173 RVA: 0x01077DBC File Offset: 0x01075FBC
		private void BuildRoleList()
		{
			UUILoopScrollViewComponent loopScrollViewComponent = base.GetLoopScrollViewComponent(this.SlotIndex(EOutsideSlot.SvRole));
			UUIExtendToggle extendToggle = base.GetExtendToggle(this.SlotIndex(EOutsideSlot.TogRole));
			AUIBaseActor auibaseActor = ((extendToggle != null) ? extendToggle.GetOwner() : null) as AUIBaseActor;
			if (loopScrollViewComponent == null || auibaseActor == null)
			{
				return;
			}
			this.RoleList = new LoopScrollView<RoverlikeOutsideRoleItem, RoverlikeOutsideRoleData>(loopScrollViewComponent, auibaseActor, new Func<RoverlikeOutsideRoleItem>(this.CreateRoleProxy), false);
			this.RefreshRoleListData();
		}

		// Token: 0x06040406 RID: 263174 RVA: 0x01077E1D File Offset: 0x0107601D
		private RoverlikeOutsideRoleItem CreateRoleProxy()
		{
			return new RoverlikeOutsideRoleItem
			{
				OnClickCb = new Action<RoverlikeOutsideRoleData, int>(this.OnRoleClick),
				IsGridSelected = new Func<RoverlikeOutsideRoleData, int, bool>(this.IsRoleSelected),
				GetHasRedDot = new Func<RoverlikeOutsideRoleData, int, bool>(this.IsRoleRedDotVisible)
			};
		}

		// Token: 0x06040407 RID: 263175 RVA: 0x01077E5C File Offset: 0x0107605C
		private void RefreshRoleListData()
		{
			this.RoleDataList = this.BuildRoleDataList();
			if (this.RoleDataList.Count == 0)
			{
				return;
			}
			if (!this.RoleDataList.Any((RoverlikeOutsideRoleData data) => data.RoleId == this.SelectedRoleId))
			{
				this.SelectedRoleId = this.RoleDataList[0].RoleId;
			}
			LoopScrollView<RoverlikeOutsideRoleItem, RoverlikeOutsideRoleData> roleList = this.RoleList;
			if (roleList == null)
			{
				return;
			}
			roleList.RefreshByData(this.RoleDataList, false, null, false);
		}

		// Token: 0x06040408 RID: 263176 RVA: 0x01077ECC File Offset: 0x010760CC
		protected virtual List<RoverlikeOutsideRoleData> BuildRoleDataList()
		{
			return new List<RoverlikeOutsideRoleData>();
		}

		// Token: 0x06040409 RID: 263177 RVA: 0x01077ED4 File Offset: 0x010760D4
		private void OnRoleClick(RoverlikeOutsideRoleData data, int gridIndex)
		{
			this.OnRoleRedDotClear(data.RoleId);
			if (data.RoleId != this.SelectedRoleId)
			{
				this.SelectedRoleId = data.RoleId;
				LoopScrollView<RoverlikeOutsideRoleItem, RoverlikeOutsideRoleData> roleList = this.RoleList;
				if (roleList != null)
				{
					roleList.RefreshAllGridProxies();
				}
				this.OnRoleSelected();
				this.RefreshList();
				return;
			}
			LoopScrollView<RoverlikeOutsideRoleItem, RoverlikeOutsideRoleData> roleList2 = this.RoleList;
			if (roleList2 == null)
			{
				return;
			}
			roleList2.RefreshAllGridProxies();
		}

		// Token: 0x0604040A RID: 263178 RVA: 0x01077F35 File Offset: 0x01076135
		protected virtual void OnRoleSelected()
		{
		}

		// Token: 0x0604040B RID: 263179 RVA: 0x01077F37 File Offset: 0x01076137
		protected virtual bool IsRoleRedDotVisible(RoverlikeOutsideRoleData data, int gridIndex)
		{
			return data.HasRedDot;
		}

		// Token: 0x0604040C RID: 263180 RVA: 0x01077F3F File Offset: 0x0107613F
		protected virtual void OnRoleRedDotClear(int roleId)
		{
		}

		// Token: 0x0604040D RID: 263181 RVA: 0x01077F41 File Offset: 0x01076141
		protected void RefreshRoleGrids()
		{
			LoopScrollView<RoverlikeOutsideRoleItem, RoverlikeOutsideRoleData> roleList = this.RoleList;
			if (roleList == null)
			{
				return;
			}
			roleList.RefreshAllGridProxies();
		}

		// Token: 0x0604040E RID: 263182 RVA: 0x01077F53 File Offset: 0x01076153
		private bool IsRoleSelected(RoverlikeOutsideRoleData data, int gridIndex)
		{
			return data.RoleId == this.SelectedRoleId;
		}

		// Token: 0x0604040F RID: 263183 RVA: 0x01077F63 File Offset: 0x01076163
		protected bool IsSelectedRoleUnlocked()
		{
			RoverlikeOutsideRoleData roverlikeOutsideRoleData = this.RoleDataList.FirstOrDefault((RoverlikeOutsideRoleData item) => item.RoleId == this.SelectedRoleId);
			return roverlikeOutsideRoleData == null || roverlikeOutsideRoleData.Unlocked;
		}

		// Token: 0x06040410 RID: 263184 RVA: 0x01077F87 File Offset: 0x01076187
		protected int GetSelectedRoleId()
		{
			return this.SelectedRoleId;
		}

		// Token: 0x06040411 RID: 263185 RVA: 0x01077F90 File Offset: 0x01076190
		private void SetupToggle()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(this.SlotIndex(EOutsideSlot.ToggleTick));
			if (extendToggle == null)
			{
				return;
			}
			this.ShowAllChecked = false;
			extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			extendToggle.OnStateChange.Add(new Action<EToggleState>(this.OnToggleStateChanged));
		}

		// Token: 0x06040412 RID: 263186 RVA: 0x01077FD9 File Offset: 0x010761D9
		private void OnToggleStateChanged(EToggleState state)
		{
			this.ShowAllChecked = (state == EToggleState.ETT_Checked);
			this.RefreshList();
		}

		// Token: 0x06040413 RID: 263187 RVA: 0x01077FEB File Offset: 0x010761EB
		protected bool IsShowAllChecked()
		{
			return this.ShowAllChecked;
		}

		// Token: 0x06040414 RID: 263188 RVA: 0x01077FF4 File Offset: 0x010761F4
		private void RefreshCollectProgress()
		{
			if (!this.ShouldShowCollectProgress())
			{
				return;
			}
			RoverlikeActivityData activityData = this.ActivityData;
			ValueTuple<int, int> valueTuple = (activityData != null) ? activityData.GetItemUnlockProgress() : new ValueTuple<int, int>(0, 0);
			UUIText text = base.GetText(this.SlotIndex(EOutsideSlot.TxtProgress));
			if (text == null)
			{
				return;
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(valueTuple.Item1);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(valueTuple.Item2);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}

		// Token: 0x06040415 RID: 263189 RVA: 0x01078074 File Offset: 0x01076274
		protected void RefreshList()
		{
			this.ScrollDataList.Clear();
			this.SelectedGridIndex = -1;
			if (this.ShouldShowRoleList() && !this.IsSelectedRoleUnlocked())
			{
				this.ShowRoleLocked();
				return;
			}
			this.SetRoleEmptyActive(false);
			UUIItem slotItem = this.GetSlotItem(EOutsideSlot.PnlItem);
			if (slotItem != null)
			{
				slotItem.SetUIActive(true);
			}
			int num = this.BuildScrollDataList();
			MultiTemplateScrollViewRefreshContext multiTemplateScrollViewRefreshContext = new MultiTemplateScrollViewRefreshContext(this.ScrollDataList);
			multiTemplateScrollViewRefreshContext.ScrollToGridIndex = 0;
			this.MultiList.RefreshByData(multiTemplateScrollViewRefreshContext);
			this.PlayListInturnAnimation();
			this.RefreshCollectProgress();
			if (num >= 0)
			{
				this.SelectByGridIndex(num);
				return;
			}
			this.ShowEmptyDetail();
		}

		// Token: 0x06040416 RID: 263190 RVA: 0x01078108 File Offset: 0x01076308
		private void ShowRoleLocked()
		{
			RoverlikeOutsideRoleData roverlikeOutsideRoleData = this.RoleDataList.FirstOrDefault((RoverlikeOutsideRoleData item) => item.RoleId == this.SelectedRoleId);
			UUIItem slotItem = this.GetSlotItem(EOutsideSlot.PnlItem);
			if (slotItem != null)
			{
				slotItem.SetUIActive(false);
			}
			this.SetRoleEmptyActive(true);
			MultiTemplateScrollViewRefreshContext context = new MultiTemplateScrollViewRefreshContext(this.ScrollDataList);
			this.MultiList.RefreshByData(context);
			this.ShowEmptyDetail();
			string unlockDesc = (!string.IsNullOrEmpty((roverlikeOutsideRoleData != null) ? roverlikeOutsideRoleData.UnlockDesc : null)) ? roverlikeOutsideRoleData.UnlockDesc : "RoverRogue_SystemShow_RoleLocked";
			this.OnRefreshRoleLockedDesc(unlockDesc);
		}

		// Token: 0x06040417 RID: 263191 RVA: 0x0107818D File Offset: 0x0107638D
		protected virtual void OnRefreshRoleLockedDesc(string unlockDesc)
		{
		}

		// Token: 0x06040418 RID: 263192 RVA: 0x01078190 File Offset: 0x01076390
		protected void PushTitle(string titleKey)
		{
			RoverlikeOutsideTitleTemplateData roverlikeOutsideTitleTemplateData = new RoverlikeOutsideTitleTemplateData();
			roverlikeOutsideTitleTemplateData.Data = new RoverlikeOutsideTitleData
			{
				TitleKey = titleKey
			};
			this.ScrollDataList.Add(roverlikeOutsideTitleTemplateData);
		}

		// Token: 0x06040419 RID: 263193 RVA: 0x010781C4 File Offset: 0x010763C4
		protected void PushTitleIcon(string iconPath)
		{
			RoverlikeOutsideTitleTemplateData roverlikeOutsideTitleTemplateData = new RoverlikeOutsideTitleTemplateData();
			roverlikeOutsideTitleTemplateData.Data = new RoverlikeOutsideTitleData
			{
				IconPath = iconPath
			};
			this.ScrollDataList.Add(roverlikeOutsideTitleTemplateData);
		}

		// Token: 0x0604041A RID: 263194 RVA: 0x010781F8 File Offset: 0x010763F8
		protected void PushTitleIconWithText(string iconPath, string titleKey)
		{
			RoverlikeOutsideTitleTemplateData roverlikeOutsideTitleTemplateData = new RoverlikeOutsideTitleTemplateData();
			roverlikeOutsideTitleTemplateData.Data = new RoverlikeOutsideTitleData
			{
				IconPath = iconPath,
				TitleKey = titleKey
			};
			this.ScrollDataList.Add(roverlikeOutsideTitleTemplateData);
		}

		// Token: 0x0604041B RID: 263195 RVA: 0x01078230 File Offset: 0x01076430
		protected int PushGrid(RoverlikeGainEntry entry)
		{
			RoverlikeOutsideEntryGridItemTemplateData roverlikeOutsideEntryGridItemTemplateData = new RoverlikeOutsideEntryGridItemTemplateData();
			roverlikeOutsideEntryGridItemTemplateData.Data = entry;
			roverlikeOutsideEntryGridItemTemplateData.OnClickCb = new Action<RoverlikeGainEntry, int>(this.OnGridClick);
			roverlikeOutsideEntryGridItemTemplateData.IsSelected = new Func<RoverlikeGainEntry, int, bool>(this.IsGridSelected);
			roverlikeOutsideEntryGridItemTemplateData.GetLockState = new Func<RoverlikeGainEntry, int, bool>(this.IsGridLocked);
			this.ScrollDataList.Add(roverlikeOutsideEntryGridItemTemplateData);
			return this.ScrollDataList.Count - 1;
		}

		// Token: 0x0604041C RID: 263196 RVA: 0x0107829C File Offset: 0x0107649C
		private void SelectByGridIndex(int gridIndex)
		{
			int selectedGridIndex = this.SelectedGridIndex;
			this.SelectedGridIndex = gridIndex;
			if (selectedGridIndex >= 0 && selectedGridIndex != gridIndex)
			{
				this.MultiList.RefreshProxyDirectly(selectedGridIndex);
			}
			this.MultiList.RefreshProxyDirectly(gridIndex);
			RoverlikeGainEntry entry = this.ScrollDataList[gridIndex].Data as RoverlikeGainEntry;
			this.RefreshDetail(entry);
		}

		// Token: 0x0604041D RID: 263197 RVA: 0x010782F7 File Offset: 0x010764F7
		[NullableContext(2)]
		private void RefreshDetail(RoverlikeGainEntry entry)
		{
			if (entry == null || entry.ConfigId <= 0)
			{
				this.ShowEmptyDetail();
				return;
			}
			UUIItem detailItemComponent = this.GetDetailItemComponent();
			if (detailItemComponent != null)
			{
				detailItemComponent.SetUIActive(true);
			}
			this.RefreshDetailCard(entry);
		}

		// Token: 0x0604041E RID: 263198 RVA: 0x01078325 File Offset: 0x01076525
		private void ShowEmptyDetail()
		{
			UUIItem detailItemComponent = this.GetDetailItemComponent();
			if (detailItemComponent == null)
			{
				return;
			}
			detailItemComponent.SetUIActive(false);
		}

		// Token: 0x0604041F RID: 263199 RVA: 0x01078338 File Offset: 0x01076538
		private void HideOtherDetailCards()
		{
			UUIItem detailItemComponent = this.GetDetailItemComponent();
			foreach (EOutsideSlot slot in new EOutsideSlot[]
			{
				EOutsideSlot.ItemBlessDetail,
				EOutsideSlot.ItemPropDetail,
				EOutsideSlot.ItemReinforceDetail
			})
			{
				UUIItem slotItem = this.GetSlotItem(slot);
				if (slotItem != null && slotItem != detailItemComponent)
				{
					slotItem.SetUIActive(false);
				}
			}
		}

		// Token: 0x06040420 RID: 263200 RVA: 0x0107838A File Offset: 0x0107658A
		private void OnGridClick(RoverlikeGainEntry data, int gridIndex)
		{
			if (gridIndex == this.SelectedGridIndex)
			{
				return;
			}
			this.PlaySequence("Switch");
			this.SelectByGridIndex(gridIndex);
		}

		// Token: 0x06040421 RID: 263201 RVA: 0x010783A8 File Offset: 0x010765A8
		private bool IsGridSelected(RoverlikeGainEntry data, int gridIndex)
		{
			return gridIndex == this.SelectedGridIndex;
		}

		// Token: 0x06040422 RID: 263202 RVA: 0x010783B3 File Offset: 0x010765B3
		private bool IsGridLocked(RoverlikeGainEntry data, int gridIndex)
		{
			return this.IsEntryLocked(data);
		}

		// Token: 0x06040423 RID: 263203 RVA: 0x010783BC File Offset: 0x010765BC
		protected void PlaySequence(string sequenceName)
		{
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence == null)
			{
				return;
			}
			uiViewSequence.PlayOrReplaySequenceByName(sequenceName, false, null);
		}

		// Token: 0x06040424 RID: 263204 RVA: 0x010783E4 File Offset: 0x010765E4
		private void PlayListInturnAnimation()
		{
			UUIInturnAnimController multiListAnimController = this.MultiListAnimController;
			if (multiListAnimController == null)
			{
				return;
			}
			multiListAnimController.Play("", -1, true);
		}

		// Token: 0x06040425 RID: 263205
		protected abstract UniTask CreateDetailCardAsync();

		// Token: 0x06040426 RID: 263206
		protected abstract void RefreshDetailCard(RoverlikeGainEntry entry);

		// Token: 0x06040427 RID: 263207
		[NullableContext(2)]
		protected abstract UUIItem GetDetailItemComponent();

		// Token: 0x06040428 RID: 263208
		protected abstract int BuildScrollDataList();

		// Token: 0x06040429 RID: 263209
		protected abstract bool IsEntryLocked(RoverlikeGainEntry entry);

		// Token: 0x0604042A RID: 263210 RVA: 0x010783FD File Offset: 0x010765FD
		protected virtual bool ShouldShowRoleList()
		{
			return false;
		}

		// Token: 0x0604042B RID: 263211 RVA: 0x01078400 File Offset: 0x01076600
		protected virtual bool ShouldShowToggle()
		{
			return false;
		}

		// Token: 0x0604042C RID: 263212 RVA: 0x01078403 File Offset: 0x01076603
		protected virtual bool ShouldShowCollectProgress()
		{
			return false;
		}

		// Token: 0x04024071 RID: 147569
		[Nullable(2)]
		protected MultiTemplateScrollView MultiList;

		// Token: 0x04024072 RID: 147570
		[Nullable(2)]
		private UUIInturnAnimController MultiListAnimController;

		// Token: 0x04024073 RID: 147571
		protected readonly List<IMultiTemplateGridData> ScrollDataList = new List<IMultiTemplateGridData>();

		// Token: 0x04024074 RID: 147572
		protected int SelectedGridIndex = -1;

		// Token: 0x04024075 RID: 147573
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private LoopScrollView<RoverlikeOutsideRoleItem, RoverlikeOutsideRoleData> RoleList;

		// Token: 0x04024076 RID: 147574
		private List<RoverlikeOutsideRoleData> RoleDataList = new List<RoverlikeOutsideRoleData>();

		// Token: 0x04024077 RID: 147575
		private int SelectedRoleId;

		// Token: 0x04024078 RID: 147576
		private bool ShowAllChecked;

		// Token: 0x04024079 RID: 147577
		private readonly Dictionary<EOutsideSlot, int> SlotIndexMap = new Dictionary<EOutsideSlot, int>();
	}
}
