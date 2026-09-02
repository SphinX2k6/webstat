using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E5F RID: 20063
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseBuildingDevelopBranchSelectView : UiViewBase
	{
		// Token: 0x06033D8B RID: 212363 RVA: 0x00CF725F File Offset: 0x00CF545F
		public TrapDefenseBuildingDevelopBranchSelectView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06033D8C RID: 212364 RVA: 0x00CF727C File Offset: 0x00CF547C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnClickedConfirm));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06033D8D RID: 212365 RVA: 0x00CF73C8 File Offset: 0x00CF55C8
		protected override void OnStart()
		{
			ITrapDefenseSelectBranchData trapDefenseSelectBranchData = this.OpenParam as ITrapDefenseSelectBranchData;
			this.IsInDungeon = trapDefenseSelectBranchData.IsInDungeon;
			UUIItem item = base.GetItem(5);
			if (item != null)
			{
				item.SetUIActive(this.IsInDungeon);
			}
			UUIButtonComponent button = base.GetButton(6);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(!this.IsInDungeon);
			}
			this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
			this.CaptionItem.SetCloseCallBack(new Action(this.OnClickedClose));
			this.Layout = new GenericLayout<TrapDefenseBuildingDevelopBranchSelectItem, ITrapDefenseDevelopBranchSelectInfo>(base.GetVerticalLayout(3), new Func<TrapDefenseBuildingDevelopBranchSelectItem>(this.CreateItem), null, false, true);
			this.Data = trapDefenseSelectBranchData.Data;
			this.CurSelectedId = this.Data.Id;
			this.UpdateData();
		}

		// Token: 0x06033D8E RID: 212366 RVA: 0x00CF749A File Offset: 0x00CF569A
		protected override void OnBeforeDestroy()
		{
			this.CaptionItem = null;
			this.Data = null;
		}

		// Token: 0x06033D8F RID: 212367 RVA: 0x00CF74AC File Offset: 0x00CF56AC
		protected void UpdateData()
		{
			if (!this.Data.GetHasBranch())
			{
				base.CloseMe(null);
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), this.Data.GetName(), Array.Empty<object>());
			base.SetTextureByPath(this.Data.GetIconPath(), base.GetTexture(1), null, null);
			ITrapDefenseMachineIdInfo trapDefenseMachineIdInfo = ModelBase<TrapDefenseModel>.Instance.DecomposeMachineId(this.CurSelectedId);
			int branchCount = this.Data.GetBranchCount();
			for (int i = 1; i <= branchCount; i++)
			{
				ITrapDefenseMachineIdInfo info = new ITrapDefenseMachineIdInfo
				{
					MachineType = trapDefenseMachineIdInfo.MachineType,
					DataType = trapDefenseMachineIdInfo.DataType,
					Level = trapDefenseMachineIdInfo.Level,
					Branch = i
				};
				int num = ModelBase<TrapDefenseModel>.Instance.ComposeMachineId(info);
				TrapDefenseDevelopBranchSelectInfo item = new TrapDefenseDevelopBranchSelectInfo
				{
					Id = num,
					IsCurLevel = (this.Data.Id == num),
					IsSelected = (this.Data.Id == num)
				};
				this.DataList.Add(item);
			}
			this.Layout.RefreshByData(this.DataList, delegate
			{
				this.UpdateSelected();
				foreach (TrapDefenseBuildingDevelopBranchSelectItem trapDefenseBuildingDevelopBranchSelectItem in this.Layout.GetLayoutItemList())
				{
					trapDefenseBuildingDevelopBranchSelectItem.GetRootItem().SetRaycastTarget(!this.IsInDungeon);
				}
			}, true);
			this.CurSelectedId = ((trapDefenseMachineIdInfo.Branch > 0) ? this.Data.Id : -1);
			UUIButtonComponent button = base.GetButton(6);
			if (button == null)
			{
				return;
			}
			button.SetSelfInteractive(this.CurSelectedId != -1);
		}

		// Token: 0x06033D90 RID: 212368 RVA: 0x00CF7620 File Offset: 0x00CF5820
		protected void UpdateSelected()
		{
			foreach (ITrapDefenseDevelopBranchSelectInfo trapDefenseDevelopBranchSelectInfo in this.DataList)
			{
				trapDefenseDevelopBranchSelectInfo.IsSelected = (this.CurSelectedId == trapDefenseDevelopBranchSelectInfo.Id);
			}
			foreach (TrapDefenseBuildingDevelopBranchSelectItem trapDefenseBuildingDevelopBranchSelectItem in this.Layout.GetLayoutItemList())
			{
				trapDefenseBuildingDevelopBranchSelectItem.UpdateSelected();
			}
		}

		// Token: 0x06033D91 RID: 212369 RVA: 0x00CF76C4 File Offset: 0x00CF58C4
		private void OnClickedConfirm()
		{
			if (this.CurSelectedId == -1)
			{
				return;
			}
			ControllerBase<TrapDefenseController>.Instance.RequestTrapDefenseDevelopBranch(this.CurSelectedId).ContinueWith(delegate(bool task)
			{
				if (task)
				{
					base.CloseMe(null);
				}
			});
		}

		// Token: 0x06033D92 RID: 212370 RVA: 0x00CF76F2 File Offset: 0x00CF58F2
		private void OnClickedClose()
		{
			base.CloseMe(null);
		}

		// Token: 0x06033D93 RID: 212371 RVA: 0x00CF76FB File Offset: 0x00CF58FB
		private void OnSelectedItem(int id)
		{
			this.CurSelectedId = ((id == this.CurSelectedId) ? -1 : id);
			UUIButtonComponent button = base.GetButton(6);
			if (button != null)
			{
				button.SetSelfInteractive(this.CurSelectedId != -1);
			}
			this.UpdateSelected();
		}

		// Token: 0x06033D94 RID: 212372 RVA: 0x00CF7734 File Offset: 0x00CF5934
		private TrapDefenseBuildingDevelopBranchSelectItem CreateItem()
		{
			return new TrapDefenseBuildingDevelopBranchSelectItem
			{
				OnClickCb = new Action<int>(this.OnSelectedItem)
			};
		}

		// Token: 0x0401DFD2 RID: 122834
		protected TrapDefenseBuildingDevelopItemData Data;

		// Token: 0x0401DFD3 RID: 122835
		protected int CurSelectedId = -1;

		// Token: 0x0401DFD4 RID: 122836
		protected PopupCaptionItem CaptionItem;

		// Token: 0x0401DFD5 RID: 122837
		protected List<ITrapDefenseDevelopBranchSelectInfo> DataList = new List<ITrapDefenseDevelopBranchSelectInfo>();

		// Token: 0x0401DFD6 RID: 122838
		protected GenericLayout<TrapDefenseBuildingDevelopBranchSelectItem, ITrapDefenseDevelopBranchSelectInfo> Layout;

		// Token: 0x0401DFD7 RID: 122839
		protected bool IsInDungeon;

		// Token: 0x0200AE0B RID: 44555
		[NullableContext(0)]
		internal class EMainView
		{
			// Token: 0x040360D4 RID: 221396
			public const int Caption = 0;

			// Token: 0x040360D5 RID: 221397
			public const int Icon = 1;

			// Token: 0x040360D6 RID: 221398
			public const int Title = 2;

			// Token: 0x040360D7 RID: 221399
			public const int PanelSelectLayout = 3;

			// Token: 0x040360D8 RID: 221400
			public const int SelectItem = 4;

			// Token: 0x040360D9 RID: 221401
			public const int StartLayout = 5;

			// Token: 0x040360DA RID: 221402
			public const int BtnConfirm = 6;
		}
	}
}
