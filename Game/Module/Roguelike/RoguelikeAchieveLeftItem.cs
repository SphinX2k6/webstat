using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x0200512A RID: 20778
	[NullableContext(1)]
	[Nullable(0)]
	public class RoguelikeAchieveLeftItem : UiPanelBase
	{
		// Token: 0x060357EE RID: 219118 RVA: 0x00D6E070 File Offset: 0x00D6C270
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060357EF RID: 219119 RVA: 0x00D6E11C File Offset: 0x00D6C31C
		protected override UniTask OnBeforeStartAsync()
		{
			RoguelikeAchieveLeftItem.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoguelikeAchieveLeftItem.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060357F0 RID: 219120 RVA: 0x00D6E15F File Offset: 0x00D6C35F
		protected override void OnStart()
		{
			this.RefreshByViewModel();
		}

		// Token: 0x060357F1 RID: 219121 RVA: 0x00D6E167 File Offset: 0x00D6C367
		protected override void OnBeforeDestroy()
		{
			this.TogTempRecordPanel = null;
			this.RecordItemScroll = null;
			this.Vm = null;
			this.OnSelectedRoguelikeInfoChanged = null;
		}

		// Token: 0x060357F2 RID: 219122 RVA: 0x00D6E185 File Offset: 0x00D6C385
		public void SetViewModel(RoguelikeAchieveViewModel vm)
		{
			this.Vm = vm;
		}

		// Token: 0x060357F3 RID: 219123 RVA: 0x00D6E18E File Offset: 0x00D6C38E
		public void BindOnSelectedRoguelikeInfoChanged(Action callback)
		{
			this.OnSelectedRoguelikeInfoChanged = callback;
		}

		// Token: 0x060357F4 RID: 219124 RVA: 0x00D6E198 File Offset: 0x00D6C398
		public void RefreshByViewModel()
		{
			this.RefreshStateIcon();
			this.RefreshRoleRecordList();
			RoguelikeAchieveViewModel vm = this.Vm;
			if (vm == null || !vm.ShouldShowTempRecord)
			{
				this.Vm.IsTempRecordSelected = false;
				RoguelikeAchieveTogTempRecordItem togTempRecordPanel = this.TogTempRecordPanel;
				if (togTempRecordPanel == null)
				{
					return;
				}
				togTempRecordPanel.Refresh(null, false);
				return;
			}
			else
			{
				RoguelikeAchieveTogTempRecordItem togTempRecordPanel2 = this.TogTempRecordPanel;
				if (togTempRecordPanel2 == null)
				{
					return;
				}
				togTempRecordPanel2.Refresh(this.Vm.TempRecordInfo, this.Vm.IsTempRecordSaved);
				return;
			}
		}

		// Token: 0x060357F5 RID: 219125 RVA: 0x00D6E20D File Offset: 0x00D6C40D
		private RoguelikeAchieveTogRoleRecordItem CreateRoleRecordItem()
		{
			RoguelikeAchieveTogRoleRecordItem roguelikeAchieveTogRoleRecordItem = new RoguelikeAchieveTogRoleRecordItem();
			roguelikeAchieveTogRoleRecordItem.BindOnToggleStateChanged(new Action<RoguelikeAchieveSlotData, int, EToggleState>(this.OnRoleRecordToggleStateChanged));
			return roguelikeAchieveTogRoleRecordItem;
		}

		// Token: 0x060357F6 RID: 219126 RVA: 0x00D6E228 File Offset: 0x00D6C428
		private void RefreshRoleRecordList()
		{
			List<RoguelikeAchieveSlotData> roleRecordDataList = this.GetRoleRecordDataList();
			if (this.Vm.SelectedRecordGridIndex >= roleRecordDataList.Count)
			{
				this.Vm.SelectedRecordGridIndex = -1;
			}
			if (!this.Vm.IsTempRecordSelected && this.Vm.SelectedRecordGridIndex < 0)
			{
				this.Vm.SelectedRecordGridIndex = this.GetDefaultSelectedRecordGridIndex(roleRecordDataList);
			}
			GenericScrollViewNew<RoguelikeAchieveTogRoleRecordItem, RoguelikeAchieveSlotData> recordItemScroll = this.RecordItemScroll;
			if (recordItemScroll == null)
			{
				return;
			}
			recordItemScroll.RefreshByData(roleRecordDataList, new Action(this.RefreshSelectedRecord), true);
		}

		// Token: 0x060357F7 RID: 219127 RVA: 0x00D6E2A8 File Offset: 0x00D6C4A8
		private void RefreshSelectedRecord()
		{
			if (this.Vm.IsTempRecordSelected || this.Vm.SelectedRecordGridIndex < 0)
			{
				GenericScrollViewNew<RoguelikeAchieveTogRoleRecordItem, RoguelikeAchieveSlotData> recordItemScroll = this.RecordItemScroll;
				if (recordItemScroll != null)
				{
					GenericLayout<RoguelikeAchieveTogRoleRecordItem, RoguelikeAchieveSlotData> genericLayout = recordItemScroll.GetGenericLayout();
					if (genericLayout != null)
					{
						genericLayout.DeselectCurrentGridProxy();
					}
				}
				if (this.Vm.SelectedRecordGridIndex < 0)
				{
					Action onSelectedRoguelikeInfoChanged = this.OnSelectedRoguelikeInfoChanged;
					if (onSelectedRoguelikeInfoChanged == null)
					{
						return;
					}
					onSelectedRoguelikeInfoChanged();
				}
				return;
			}
			GenericScrollViewNew<RoguelikeAchieveTogRoleRecordItem, RoguelikeAchieveSlotData> recordItemScroll2 = this.RecordItemScroll;
			if (recordItemScroll2 == null)
			{
				return;
			}
			recordItemScroll2.SelectGridProxy(this.Vm.SelectedRecordGridIndex, true);
		}

		// Token: 0x060357F8 RID: 219128 RVA: 0x00D6E328 File Offset: 0x00D6C528
		private void OnTempRecordToggleStateChanged(EToggleState state)
		{
			if (state != EToggleState.ETT_Checked)
			{
				if (this.Vm.SelectedRecordGridIndex < 0)
				{
					RoguelikeAchieveTogTempRecordItem togTempRecordPanel = this.TogTempRecordPanel;
					if (togTempRecordPanel == null)
					{
						return;
					}
					togTempRecordPanel.SetToggleState(true, false);
				}
				return;
			}
			this.Vm.IsTempRecordSelected = true;
			this.Vm.SelectedRecordGridIndex = -1;
			GenericScrollViewNew<RoguelikeAchieveTogRoleRecordItem, RoguelikeAchieveSlotData> recordItemScroll = this.RecordItemScroll;
			if (recordItemScroll != null)
			{
				GenericLayout<RoguelikeAchieveTogRoleRecordItem, RoguelikeAchieveSlotData> genericLayout = recordItemScroll.GetGenericLayout();
				if (genericLayout != null)
				{
					genericLayout.DeselectCurrentGridProxy();
				}
			}
			Action onSelectedRoguelikeInfoChanged = this.OnSelectedRoguelikeInfoChanged;
			if (onSelectedRoguelikeInfoChanged == null)
			{
				return;
			}
			onSelectedRoguelikeInfoChanged();
		}

		// Token: 0x060357F9 RID: 219129 RVA: 0x00D6E3A0 File Offset: 0x00D6C5A0
		private void OnRoleRecordToggleStateChanged(RoguelikeAchieveSlotData slotData, int gridIndex, EToggleState state)
		{
			if (state != EToggleState.ETT_Checked)
			{
				if (!this.Vm.IsTempRecordSelected)
				{
					GenericScrollViewNew<RoguelikeAchieveTogRoleRecordItem, RoguelikeAchieveSlotData> recordItemScroll = this.RecordItemScroll;
					if (recordItemScroll == null)
					{
						return;
					}
					recordItemScroll.SelectGridProxy(gridIndex, false);
				}
				return;
			}
			if (slotData.SlotIndex < 0)
			{
				return;
			}
			this.Vm.IsTempRecordSelected = false;
			RoguelikeAchieveTogTempRecordItem togTempRecordPanel = this.TogTempRecordPanel;
			if (togTempRecordPanel != null)
			{
				togTempRecordPanel.SetToggleState(false, false);
			}
			this.Vm.SelectedRecordGridIndex = gridIndex;
			GenericScrollViewNew<RoguelikeAchieveTogRoleRecordItem, RoguelikeAchieveSlotData> recordItemScroll2 = this.RecordItemScroll;
			if (recordItemScroll2 != null)
			{
				recordItemScroll2.SelectGridProxy(gridIndex, false);
			}
			Action onSelectedRoguelikeInfoChanged = this.OnSelectedRoguelikeInfoChanged;
			if (onSelectedRoguelikeInfoChanged == null)
			{
				return;
			}
			onSelectedRoguelikeInfoChanged();
		}

		// Token: 0x060357FA RID: 219130 RVA: 0x00D6E42C File Offset: 0x00D6C62C
		private void RefreshStateIcon()
		{
			RoguelikeAchieveViewModel vm = this.Vm;
			if (vm != null)
			{
				string path = (vm.IsUseArchiveMode || vm.IsTempRecordSaved) ? RoguelikeAchieveDefine.RoguelikeAchieveSavedStateIconPath : RoguelikeAchieveDefine.RoguelikeAchieveUnSavedStateIconPath;
				UUISprite sprite = base.GetSprite(1);
				sprite.SetUIActive(true);
				this.SetSpriteByPath(path, sprite, false, null, null);
				return;
			}
			UUISprite sprite2 = base.GetSprite(1);
			if (sprite2 == null)
			{
				return;
			}
			sprite2.SetUIActive(false);
		}

		// Token: 0x060357FB RID: 219131 RVA: 0x00D6E498 File Offset: 0x00D6C698
		private List<RoguelikeAchieveSlotData> GetRoleRecordDataList()
		{
			RoguelikeAchieveViewModel vm = this.Vm;
			if (vm == null)
			{
				return new List<RoguelikeAchieveSlotData>();
			}
			if (vm.IsUseArchiveMode)
			{
				return vm.ArchiveSlotList.FindAll((RoguelikeAchieveSlotData slotData) => slotData.ArchiveInfoData != null);
			}
			return new List<RoguelikeAchieveSlotData>(vm.ArchiveSlotList);
		}

		// Token: 0x060357FC RID: 219132 RVA: 0x00D6E4F4 File Offset: 0x00D6C6F4
		private int GetDefaultSelectedRecordGridIndex(List<RoguelikeAchieveSlotData> dataList)
		{
			if (dataList.Count <= 0)
			{
				return -1;
			}
			RoguelikeAchieveViewModel vm = this.Vm;
			if (vm != null && vm.IsUseArchiveMode)
			{
				return 0;
			}
			int num = dataList.FindIndex((RoguelikeAchieveSlotData slotData) => !slotData.ArchiveInfoData.HasData);
			if (num < 0)
			{
				return 0;
			}
			return num;
		}

		// Token: 0x0401EC00 RID: 125952
		[Nullable(2)]
		private RoguelikeAchieveTogTempRecordItem TogTempRecordPanel;

		// Token: 0x0401EC01 RID: 125953
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<RoguelikeAchieveTogRoleRecordItem, RoguelikeAchieveSlotData> RecordItemScroll;

		// Token: 0x0401EC02 RID: 125954
		[Nullable(2)]
		private RoguelikeAchieveViewModel Vm;

		// Token: 0x0401EC03 RID: 125955
		[Nullable(2)]
		private Action OnSelectedRoguelikeInfoChanged;

		// Token: 0x0200B0C7 RID: 45255
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x04036D7A RID: 224634
			public const int TempRecordItem = 0;

			// Token: 0x04036D7B RID: 224635
			public const int SprStateIcon = 1;

			// Token: 0x04036D7C RID: 224636
			public const int RecordItemScroll = 2;

			// Token: 0x04036D7D RID: 224637
			public const int RoleRecordItem = 3;
		}
	}
}
