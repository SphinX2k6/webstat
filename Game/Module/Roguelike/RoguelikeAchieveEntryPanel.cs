using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005129 RID: 20777
	[NullableContext(2)]
	[Nullable(0)]
	public class RoguelikeAchieveEntryPanel : UiPanelBase
	{
		// Token: 0x060357E6 RID: 219110 RVA: 0x00D6DEF8 File Offset: 0x00D6C0F8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060357E7 RID: 219111 RVA: 0x00D6DF61 File Offset: 0x00D6C161
		protected override void OnStart()
		{
			this.StartButton = new ButtonItem(base.GetItem(1));
			this.StartButton.SetFunction(new Action<int>(this.OnBtnStartInstanceClick));
		}

		// Token: 0x060357E8 RID: 219112 RVA: 0x00D6DF8C File Offset: 0x00D6C18C
		protected override void OnBeforeDestroy()
		{
			this.StartButton = null;
			this.Vm = null;
			this.CurrentArchiveInfoData = null;
		}

		// Token: 0x060357E9 RID: 219113 RVA: 0x00D6DFA3 File Offset: 0x00D6C1A3
		[NullableContext(1)]
		public void SetViewModel(RoguelikeAchieveViewModel vm)
		{
			this.Vm = vm;
		}

		// Token: 0x060357EA RID: 219114 RVA: 0x00D6DFAC File Offset: 0x00D6C1AC
		public void Refresh(RogueArchiveInfoData archiveInfoData, bool isTempRecord)
		{
			this.CurrentArchiveInfoData = archiveInfoData;
			RoguelikeAchieveViewModel vm = this.Vm;
			bool flag = vm != null && vm.IsUseArchiveMode && archiveInfoData != null && !isTempRecord;
			base.SetUiActive(flag);
			if (!flag)
			{
				return;
			}
			this.RefreshEntryName();
		}

		// Token: 0x060357EB RID: 219115 RVA: 0x00D6DFF0 File Offset: 0x00D6C1F0
		private void OnBtnStartInstanceClick(int _)
		{
			if (this.CurrentArchiveInfoData == null || this.Vm == null)
			{
				return;
			}
			ControllerBase<RoguelikeController>.Instance.RoguelikeBossChallengeStartRequest(this.Vm.InstId, this.CurrentArchiveInfoData.SlotId, null);
		}

		// Token: 0x060357EC RID: 219116 RVA: 0x00D6E024 File Offset: 0x00D6C224
		private void RefreshEntryName()
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "Rogue_Record_Name", new <>z__ReadOnlySingleElementList<object>(this.CurrentArchiveInfoData.ShowIndex.ToString().PadLeft(2, '0')));
		}

		// Token: 0x0401EBFD RID: 125949
		private ButtonItem StartButton;

		// Token: 0x0401EBFE RID: 125950
		private RoguelikeAchieveViewModel Vm;

		// Token: 0x0401EBFF RID: 125951
		private RogueArchiveInfoData CurrentArchiveInfoData;

		// Token: 0x0200B0C6 RID: 45254
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x04036D78 RID: 224632
			public const int EntryNameText = 0;

			// Token: 0x04036D79 RID: 224633
			public const int StartBattleButton = 1;
		}
	}
}
