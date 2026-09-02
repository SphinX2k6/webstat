using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Role
{
	// Token: 0x020065DB RID: 26075
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballRoleSelectView : UiViewBase
	{
		// Token: 0x0604123A RID: 266810 RVA: 0x010B5BB0 File Offset: 0x010B3DB0
		public PinballRoleSelectView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0604123B RID: 266811 RVA: 0x010B5BD0 File Offset: 0x010B3DD0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 10;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUILoopScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(8, new Action(this.OnBackButtonClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0604123C RID: 266812 RVA: 0x010B5D80 File Offset: 0x010B3F80
		protected override UniTask OnBeforeStartAsync()
		{
			PinballRoleSelectView.<OnBeforeStartAsync>d__14 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PinballRoleSelectView.<OnBeforeStartAsync>d__14>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0604123D RID: 266813 RVA: 0x010B5DC3 File Offset: 0x010B3FC3
		protected override void OnBeforeShow()
		{
			this.RoleScrollView.ResetGridController();
		}

		// Token: 0x0604123E RID: 266814 RVA: 0x010B5DD0 File Offset: 0x010B3FD0
		protected void BuildAllRoleDataList()
		{
			if (this.OpenData == null)
			{
				return;
			}
			this.AllGridDataList.Clear();
			PinballModel instance = ModelBase<PinballModel>.Instance;
			foreach (PinballRoleDataBase pinballRoleDataBase in this.OpenData.RoleDataList)
			{
				PinballRoleConfig config = pinballRoleDataBase.GetConfig();
				TableTextArgNew bottomText = pinballRoleDataBase.IsLocked() ? new TableTextArgNew(instance.GetRoleNameByPinballRoleConfig(config), Array.Empty<object>()) : new TableTextArgNew("Pinball_Character_List_01", new object[]
				{
					pinballRoleDataBase.GetLevel()
				});
				PinballItemDataRole itemData = new PinballItemDataRole
				{
					Type = EPinballItemType.Role,
					Id = pinballRoleDataBase.GetId(),
					BdId = new int?(config.Bd),
					IsLocked = new bool?(pinballRoleDataBase.IsLocked()),
					IsUnavailable = new bool?(pinballRoleDataBase.IsLocked()),
					BottomText = bottomText
				};
				List<int> list = new List<int>();
				int pinballClassLength = config.PinballClassLength;
				for (int i = 0; i < pinballClassLength; i++)
				{
					list.Add(config.PinballClass(i));
				}
				int[] formationRoleIds = this.OpenData.FormationRoleIds;
				int formationIndex = (formationRoleIds != null) ? formationRoleIds.IndexOf(pinballRoleDataBase.GetId()) : -1;
				PinballRoleSelectGridItemData item = new PinballRoleSelectGridItemData
				{
					RoleData = pinballRoleDataBase,
					ItemData = itemData,
					ClassIdList = list,
					IsSelected = false,
					FormationIndex = formationIndex
				};
				this.AllGridDataList.Add(item);
			}
		}

		// Token: 0x0604123F RID: 266815 RVA: 0x010B5F74 File Offset: 0x010B4174
		public bool SetSelectedRoleDataByRoleId(int roleId)
		{
			int num = this.CurShowGridDataList.FindIndex((IPinballRoleSelectGridItemData role) => role.RoleData.GetId() == roleId);
			return num >= 0 && this.SetSelectedRoleDataByIndex(num);
		}

		// Token: 0x06041240 RID: 266816 RVA: 0x010B5FB4 File Offset: 0x010B41B4
		public bool SetSelectedRoleDataByIndex(int index)
		{
			if (index < 0 || index >= this.CurShowGridDataList.Count)
			{
				return false;
			}
			if (this.CurShowGridDataList[index].IsSelected)
			{
				return false;
			}
			if (this.SelectedRoleData != null)
			{
				this.SelectedRoleData.IsSelected = false;
			}
			this.SelectedIndex = index;
			this.SelectedRoleData = this.CurShowGridDataList[index];
			this.SelectedRoleId = this.SelectedRoleData.RoleData.GetId();
			this.CurShowGridDataList[index].IsSelected = true;
			return true;
		}

		// Token: 0x06041241 RID: 266817 RVA: 0x010B6040 File Offset: 0x010B4240
		public void SelectRoleByIndex(int index)
		{
			int selectedIndex = this.SelectedIndex;
			if (!this.SetSelectedRoleDataByIndex(index))
			{
				return;
			}
			if (selectedIndex >= 0 && selectedIndex < this.CurShowGridDataList.Count)
			{
				PinballRoleSelectGridItem pinballRoleSelectGridItem = this.RoleScrollView.UnsafeGetGridProxy(selectedIndex, false);
				if (pinballRoleSelectGridItem != null)
				{
					pinballRoleSelectGridItem.RefreshSelectedState(false);
				}
			}
			this.RefreshRole();
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence == null)
			{
				return;
			}
			uiViewSequence.PlayOrReplaySequenceByName("Switch", false, null);
		}

		// Token: 0x06041242 RID: 266818 RVA: 0x010B60B0 File Offset: 0x010B42B0
		public void SelectRoleByRoleId(int roleId)
		{
			int num = this.CurShowGridDataList.FindIndex((IPinballRoleSelectGridItemData role) => role.RoleData.GetId() == roleId);
			if (num < 0)
			{
				return;
			}
			this.SelectRoleByIndex(num);
		}

		// Token: 0x06041243 RID: 266819 RVA: 0x010B60F0 File Offset: 0x010B42F0
		public void RefreshRole()
		{
			PinballRoleSelectView.<>c__DisplayClass21_0 CS$<>8__locals1 = new PinballRoleSelectView.<>c__DisplayClass21_0();
			CS$<>8__locals1.<>4__this = this;
			if (this.SelectedIndex < 0 || this.SelectedIndex >= this.CurShowGridDataList.Count)
			{
				return;
			}
			CS$<>8__locals1.roleItemData = this.CurShowGridDataList[this.SelectedIndex];
			UiAsyncTask task = new UiAsyncTask("RefreshRole", delegate()
			{
				PinballRoleSelectView.<>c__DisplayClass21_0.<<RefreshRole>b__0>d <<RefreshRole>b__0>d;
				<<RefreshRole>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<RefreshRole>b__0>d.<>4__this = CS$<>8__locals1;
				<<RefreshRole>b__0>d.<>1__state = -1;
				<<RefreshRole>b__0>d.<>t__builder.Start<PinballRoleSelectView.<>c__DisplayClass21_0.<<RefreshRole>b__0>d>(ref <<RefreshRole>b__0>d);
				return <<RefreshRole>b__0>d.<>t__builder.Task;
			}, null);
			base.RunAsyncTask(task).Forget();
		}

		// Token: 0x06041244 RID: 266820 RVA: 0x010B6164 File Offset: 0x010B4364
		public UniTask RefreshRoleAsync()
		{
			PinballRoleSelectView.<RefreshRoleAsync>d__22 <RefreshRoleAsync>d__;
			<RefreshRoleAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshRoleAsync>d__.<>4__this = this;
			<RefreshRoleAsync>d__.<>1__state = -1;
			<RefreshRoleAsync>d__.<>t__builder.Start<PinballRoleSelectView.<RefreshRoleAsync>d__22>(ref <RefreshRoleAsync>d__);
			return <RefreshRoleAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041245 RID: 266821 RVA: 0x010B61A8 File Offset: 0x010B43A8
		public UniTask RefreshRoleByRoleDataAsync(IPinballRoleSelectGridItemData gridData)
		{
			PinballRoleSelectView.<RefreshRoleByRoleDataAsync>d__23 <RefreshRoleByRoleDataAsync>d__;
			<RefreshRoleByRoleDataAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshRoleByRoleDataAsync>d__.<>4__this = this;
			<RefreshRoleByRoleDataAsync>d__.gridData = gridData;
			<RefreshRoleByRoleDataAsync>d__.<>1__state = -1;
			<RefreshRoleByRoleDataAsync>d__.<>t__builder.Start<PinballRoleSelectView.<RefreshRoleByRoleDataAsync>d__23>(ref <RefreshRoleByRoleDataAsync>d__);
			return <RefreshRoleByRoleDataAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041246 RID: 266822 RVA: 0x010B61F3 File Offset: 0x010B43F3
		private void UpdateRoleList(List<IPinballRoleSelectGridItemData> list, bool isOutSideChange, EFilterSortType operationType)
		{
			this.CurShowGridDataList = list;
			this.SelectedIndex = this.CurShowGridDataList.FindIndex((IPinballRoleSelectGridItemData role) => role.RoleData.GetId() == this.SelectedRoleId);
			if (!isOutSideChange)
			{
				this.RoleScrollView.RefreshByData(this.CurShowGridDataList, false, null, true);
			}
		}

		// Token: 0x06041247 RID: 266823 RVA: 0x010B6230 File Offset: 0x010B4430
		private PinballRoleSelectGridItem CreateRoleSelectGridItem()
		{
			PinballRoleSelectGridItem pinballRoleSelectGridItem = new PinballRoleSelectGridItem();
			pinballRoleSelectGridItem.BindOnStateChangeCallback(new Action<IPinballItemToggleCallback>(this.OnGridStateChange));
			return pinballRoleSelectGridItem;
		}

		// Token: 0x06041248 RID: 266824 RVA: 0x010B624C File Offset: 0x010B444C
		private void OnGridStateChange(IPinballItemToggleCallback callbackParameter)
		{
			if (callbackParameter.State == EToggleState.ETT_Checked)
			{
				PinballRoleSelectGridItem pinballRoleSelectGridItem = callbackParameter.View as PinballRoleSelectGridItem;
				this.SelectRoleByIndex(pinballRoleSelectGridItem.GridIndex);
			}
		}

		// Token: 0x06041249 RID: 266825 RVA: 0x010B627A File Offset: 0x010B447A
		private void OnBackButtonClick()
		{
			IPinballRoleSelectViewOpenData openData = this.OpenData;
			if (openData != null)
			{
				openData.OnSelectConfirm(this.SelectedRoleId);
			}
			base.CloseMe(null);
		}

		// Token: 0x040247B1 RID: 149425
		[Nullable(2)]
		protected IPinballRoleSelectViewOpenData OpenData;

		// Token: 0x040247B2 RID: 149426
		protected List<IPinballRoleSelectGridItemData> AllGridDataList = new List<IPinballRoleSelectGridItemData>();

		// Token: 0x040247B3 RID: 149427
		protected List<IPinballRoleSelectGridItemData> CurShowGridDataList = new List<IPinballRoleSelectGridItemData>();

		// Token: 0x040247B4 RID: 149428
		protected int SelectedIndex;

		// Token: 0x040247B5 RID: 149429
		protected int SelectedRoleId;

		// Token: 0x040247B6 RID: 149430
		[Nullable(2)]
		protected IPinballRoleSelectGridItemData SelectedRoleData;

		// Token: 0x040247B7 RID: 149431
		[Nullable(2)]
		protected PopupCaptionItem CaptionItem;

		// Token: 0x040247B8 RID: 149432
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		protected LoopScrollView<PinballRoleSelectGridItem, IPinballRoleSelectGridItemData> RoleScrollView;

		// Token: 0x040247B9 RID: 149433
		[Nullable(2)]
		protected PinballRoleSpineItem RoleSpineItem;

		// Token: 0x040247BA RID: 149434
		[Nullable(2)]
		protected PinballRoleBdItem BdItem;

		// Token: 0x040247BB RID: 149435
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected FilterSortEntrance<IPinballRoleSelectGridItemData> FilterSortEntrance;

		// Token: 0x0200C5DA RID: 50650
		[NullableContext(0)]
		private enum EComponent
		{
			// Token: 0x0403CE64 RID: 249444
			CaptionItem,
			// Token: 0x0403CE65 RID: 249445
			RoleLoopScrollView,
			// Token: 0x0403CE66 RID: 249446
			RoleTemplateItem,
			// Token: 0x0403CE67 RID: 249447
			RoleSpineItem,
			// Token: 0x0403CE68 RID: 249448
			NameText,
			// Token: 0x0403CE69 RID: 249449
			BdItem,
			// Token: 0x0403CE6A RID: 249450
			LevelText,
			// Token: 0x0403CE6B RID: 249451
			BdBgTexture,
			// Token: 0x0403CE6C RID: 249452
			BackButton,
			// Token: 0x0403CE6D RID: 249453
			FilterSortItem
		}
	}
}
