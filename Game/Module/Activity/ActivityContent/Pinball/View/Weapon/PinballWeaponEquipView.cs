using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Item;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Weapon
{
	// Token: 0x020065AB RID: 26027
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballWeaponEquipView : UiViewBase
	{
		// Token: 0x0604104E RID: 266318 RVA: 0x010AE7C0 File Offset: 0x010AC9C0
		public PinballWeaponEquipView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0604104F RID: 266319 RVA: 0x010AE7FC File Offset: 0x010AC9FC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 11;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIMultiTemplateScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.OnClickContrastToggle));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnClickDecomposeButton));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06041050 RID: 266320 RVA: 0x010AE9F4 File Offset: 0x010ACBF4
		protected override UniTask OnBeforeStartAsync()
		{
			PinballWeaponEquipView.<OnBeforeStartAsync>d__19 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PinballWeaponEquipView.<OnBeforeStartAsync>d__19>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041051 RID: 266321 RVA: 0x010AEA37 File Offset: 0x010ACC37
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<int, bool>(EEventName.OnPinballWeaponLockChanged, new Action<int, bool>(this.OnPinballWeaponLockChanged));
		}

		// Token: 0x06041052 RID: 266322 RVA: 0x010AEA55 File Offset: 0x010ACC55
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove<int, bool>(EEventName.OnPinballWeaponLockChanged, new Action<int, bool>(this.OnPinballWeaponLockChanged));
		}

		// Token: 0x06041053 RID: 266323 RVA: 0x010AEA74 File Offset: 0x010ACC74
		protected override void OnBeforeShow()
		{
			int num = 0;
			if (this.SelectedGridData != null)
			{
				num = this.SelectedGridData.Data.WeaponData.IncId;
				this.SelectedGridData = null;
			}
			this.UpdateWeaponGridDataList();
			this.FilterSortEntrance.UpdateData(EFilterSortGroupId.PinballWeaponEquip, this.AllWeaponGridDataList, Array.Empty<object>());
			int num2 = -1;
			if (num > 0)
			{
				num2 = this.GetGridIndexByWeaponIncId(num);
			}
			if (num2 < 0)
			{
				num2 = 1;
			}
			this.SetSelectedGridData(num2);
			this.UpdateCurSelectedWeaponTipData();
			this.UpdateCurEquipWeaponTipData();
			this.RefreshGrids();
			this.RefreshCurSelectedWeaponTip();
			this.RefreshCurEquipWeaponTip();
			this.RefreshCurEquipWeaponTipShowState();
			this.RefreshWeaponCountText();
		}

		// Token: 0x06041054 RID: 266324 RVA: 0x010AEB0B File Offset: 0x010ACD0B
		protected override void OnAfterShow()
		{
			this.CheckToShowOverCapacityConfirm();
		}

		// Token: 0x06041055 RID: 266325 RVA: 0x010AEB14 File Offset: 0x010ACD14
		private void UpdateWeaponGridDataList()
		{
			if (this.Data == null)
			{
				return;
			}
			this.AllWeaponGridDataList.Clear();
			List<PinballWeaponData> weaponDataAll = this.Data.ActivityData.GetWeaponDataAll();
			PinballRoleConfig config = this.Data.RoleData.GetConfig();
			int id = config.Id;
			int personWeaponType = config.PersonWeaponType;
			int weaponType = config.WeaponType;
			PinballModel instance = ModelBase<PinballModel>.Instance;
			foreach (PinballWeaponData pinballWeaponData in weaponDataAll)
			{
				bool canEquip = instance.CheckWeaponCanEquip(pinballWeaponData, weaponType, personWeaponType);
				bool isCurRoleEquip = pinballWeaponData.RoleId == id;
				PinballWeaponMultiTemplateGridData item = new PinballWeaponMultiTemplateGridData(this.BuildWeaponGridData(pinballWeaponData, canEquip, isCurRoleEquip));
				this.AllWeaponGridDataList.Add(item);
			}
		}

		// Token: 0x06041056 RID: 266326 RVA: 0x010AEBEC File Offset: 0x010ACDEC
		protected void UpdateGridData(List<IMultiTemplateGridData> sortDataList)
		{
			if (this.Data == null)
			{
				return;
			}
			this.GridDataList.Clear();
			this.CanEquipWeaponGridDataList.Clear();
			this.CanNotEquipWeaponGridDataList.Clear();
			foreach (IMultiTemplateGridData multiTemplateGridData in sortDataList)
			{
				if ((multiTemplateGridData.Data as IPinballItemSyncWeaponGridViewData).CanEquip)
				{
					this.CanEquipWeaponGridDataList.Add(multiTemplateGridData);
				}
				else
				{
					this.CanNotEquipWeaponGridDataList.Add(multiTemplateGridData);
				}
			}
			int weaponType = this.Data.RoleData.GetConfig().WeaponType;
			PinballWeaponType? pinballWeaponTypeConfigById = ConfigBase<PinballConfig>.Instance.GetPinballWeaponTypeConfigById(weaponType);
			PinballWeaponEquipTitleGridData item = new PinballWeaponEquipTitleGridData(new PinballWeaponEquipTitleItemData
			{
				TypeIconPath = pinballWeaponTypeConfigById.Value.Icon,
				DescTextData = new TableTextArgNew("Pinball_Weapon_SelectInfo01", new <>z__ReadOnlySingleElementList<object>(ConfigMultiTextLang.GetLocalTextNew(pinballWeaponTypeConfigById.Value.Name, null))),
				CanEquip = true
			});
			this.GridDataList.Add(item);
			this.GridDataList.AddRange(this.CanEquipWeaponGridDataList);
			if (this.CanNotEquipWeaponGridDataList.Count == 0)
			{
				return;
			}
			PinballWeaponEquipTitleGridData item2 = new PinballWeaponEquipTitleGridData(new PinballWeaponEquipTitleItemData
			{
				TypeIconPath = "/Game/Aki/UI/UIResources/UiActivity/Atlas/Activity33/CatapultStory/OutSide/SP_IconTitle02.SP_IconTitle02",
				DescTextData = new TableTextArgNew("Pinball_Weapon_SelectInfo02", Array.Empty<object>()),
				CanEquip = false
			});
			this.GridDataList.Add(item2);
			this.GridDataList.AddRange(this.CanNotEquipWeaponGridDataList);
		}

		// Token: 0x06041057 RID: 266327 RVA: 0x010AED84 File Offset: 0x010ACF84
		protected void UpdateWeaponGridDataIsCurRoleEquip(PinballWeaponMultiTemplateGridData weaponGridData)
		{
			IPinballItemSyncWeaponGridViewData data = weaponGridData.Data;
			int roleId = data.WeaponData.RoleId;
			IPinballWeaponEquipViewData data2 = this.Data;
			int? num = (data2 != null) ? new int?(data2.RoleData.GetId()) : null;
			data.IsCurRoleEquip = (roleId == num.GetValueOrDefault() & num != null);
		}

		// Token: 0x06041058 RID: 266328 RVA: 0x010AEDE0 File Offset: 0x010ACFE0
		protected void SetSelectedGridData(int index)
		{
			if (index < 0 || index >= this.GridDataList.Count)
			{
				return;
			}
			PinballWeaponMultiTemplateGridData selectedGridData = this.SelectedGridData;
			if (selectedGridData != null)
			{
				selectedGridData.Data.IsSelected = false;
			}
			this.SelectedIndex = index;
			this.SelectedGridData = (this.GridDataList[index] as PinballWeaponMultiTemplateGridData);
			this.SelectedGridData.Data.IsSelected = true;
			this.UpdateCurSelectedWeaponTipData();
		}

		// Token: 0x06041059 RID: 266329 RVA: 0x010AEE4C File Offset: 0x010AD04C
		protected void UpdateCurSelectedWeaponTipData()
		{
			if (this.SelectedGridData == null)
			{
				return;
			}
			bool canEquip = this.SelectedGridData.Data.CanEquip;
			EPinballWeaponEquipState state = EPinballWeaponEquipState.CanNotEquip;
			if (canEquip)
			{
				state = ((this.SelectedGridData.Data.WeaponData.IncId == this.GetCurEquipWeaponIncId()) ? EPinballWeaponEquipState.IsEquipped : EPinballWeaponEquipState.CanEquip);
			}
			PinballWeaponEquipTipItemData curSelectedWeaponTipData = new PinballWeaponEquipTipItemData
			{
				WeaponData = this.SelectedGridData.Data.WeaponData,
				ShowButton = true,
				State = state,
				ConfirmDelegate = new Action(this.OnClickEquipButton)
			};
			this.CurSelectedWeaponTipData = curSelectedWeaponTipData;
		}

		// Token: 0x0604105A RID: 266330 RVA: 0x010AEEE0 File Offset: 0x010AD0E0
		protected void UpdateCurEquipWeaponTipData()
		{
			IPinballWeaponEquipViewData data = this.Data;
			PinballRoleDataBase pinballRoleDataBase = (data != null) ? data.RoleData : null;
			if (pinballRoleDataBase == null)
			{
				return;
			}
			PinballWeaponData weaponData = pinballRoleDataBase.GetWeaponData();
			if (weaponData == null)
			{
				return;
			}
			PinballWeaponEquipTipItemData curEquipWeaponTipData = new PinballWeaponEquipTipItemData
			{
				WeaponData = weaponData,
				ShowButton = false,
				State = EPinballWeaponEquipState.IsEquipped
			};
			this.CurEquipWeaponTipData = curEquipWeaponTipData;
		}

		// Token: 0x0604105B RID: 266331 RVA: 0x010AEF34 File Offset: 0x010AD134
		public void RefreshGrids()
		{
			MultiTemplateScrollViewRefreshContext multiTemplateScrollViewRefreshContext = new MultiTemplateScrollViewRefreshContext(this.GridDataList);
			multiTemplateScrollViewRefreshContext.PlayGridAnim = true;
			MultiTemplateScrollView weaponMultiTemplateScrollView = this.WeaponMultiTemplateScrollView;
			if (weaponMultiTemplateScrollView == null)
			{
				return;
			}
			weaponMultiTemplateScrollView.RefreshByData(multiTemplateScrollViewRefreshContext);
		}

		// Token: 0x0604105C RID: 266332 RVA: 0x010AEF65 File Offset: 0x010AD165
		public void RefreshCurSelectedWeaponTip()
		{
			if (this.CurSelectedWeaponTipData == null)
			{
				return;
			}
			PinballWeaponEquipTipItem curSelectedWeaponTipItem = this.CurSelectedWeaponTipItem;
			if (curSelectedWeaponTipItem == null)
			{
				return;
			}
			curSelectedWeaponTipItem.Refresh(this.CurSelectedWeaponTipData);
		}

		// Token: 0x0604105D RID: 266333 RVA: 0x010AEF86 File Offset: 0x010AD186
		public void RefreshCurEquipWeaponTip()
		{
			if (this.CurEquipWeaponTipData == null)
			{
				return;
			}
			PinballWeaponEquipTipItem curEquipWeaponTipItem = this.CurEquipWeaponTipItem;
			if (curEquipWeaponTipItem == null)
			{
				return;
			}
			curEquipWeaponTipItem.Refresh(this.CurEquipWeaponTipData);
		}

		// Token: 0x0604105E RID: 266334 RVA: 0x010AEFA7 File Offset: 0x010AD1A7
		public void RefreshCurEquipWeaponTipShowState()
		{
			if (this.CurEquipWeaponTipData == null)
			{
				return;
			}
			UUIItem item = base.GetItem(7);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(this.IsContrastEnabled);
		}

		// Token: 0x0604105F RID: 266335 RVA: 0x010AEFCC File Offset: 0x010AD1CC
		public void RefreshWeaponCountText()
		{
			int count = this.AllWeaponGridDataList.Count;
			UUIText text = base.GetText(3);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "Pinball_Weapon_SelectInfo03", new <>z__ReadOnlyArray<object>(new object[]
			{
				count,
				this.Capacity
			}));
		}

		// Token: 0x06041060 RID: 266336 RVA: 0x010AF020 File Offset: 0x010AD220
		public void SelectGrid(int index)
		{
			int selectedIndex = this.SelectedIndex;
			if (selectedIndex == index)
			{
				return;
			}
			this.SetSelectedGridData(index);
			if (selectedIndex != -1)
			{
				MultiTemplateScrollView weaponMultiTemplateScrollView = this.WeaponMultiTemplateScrollView;
				ISyncGridProxy syncGridProxy = (weaponMultiTemplateScrollView != null) ? weaponMultiTemplateScrollView.GetProxyByGridIndex(selectedIndex) : null;
				if (syncGridProxy != null)
				{
					((PinballItemSyncWeaponGridView)syncGridProxy).RefreshToggleState(false);
				}
			}
			MultiTemplateScrollView weaponMultiTemplateScrollView2 = this.WeaponMultiTemplateScrollView;
			PinballItemSyncWeaponGridView pinballItemSyncWeaponGridView = ((weaponMultiTemplateScrollView2 != null) ? weaponMultiTemplateScrollView2.GetProxyByGridIndex(index) : null) as PinballItemSyncWeaponGridView;
			if (pinballItemSyncWeaponGridView != null)
			{
				pinballItemSyncWeaponGridView.RefreshToggleState(false);
			}
			this.RefreshCurSelectedWeaponTip();
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence == null)
			{
				return;
			}
			uiViewSequence.PlayOrReplaySequenceByName("Switch", false, null);
		}

		// Token: 0x06041061 RID: 266337 RVA: 0x010AF0B0 File Offset: 0x010AD2B0
		public void EquipCurSelectedWeapon()
		{
			UiAsyncTask task = new UiAsyncTask("EquipCurSelectedWeapon", new Func<UniTask>(this.EquipCurSelectedWeaponAsync), null);
			base.RunAsyncTask(task).Forget();
		}

		// Token: 0x06041062 RID: 266338 RVA: 0x010AF0E4 File Offset: 0x010AD2E4
		public void OpenReplaceConfirmView()
		{
			IPinballWeaponEquipTipItemData curSelectedWeaponTipData = this.CurSelectedWeaponTipData;
			PinballWeaponData pinballWeaponData = (curSelectedWeaponTipData != null) ? curSelectedWeaponTipData.WeaponData : null;
			if (pinballWeaponData == null || pinballWeaponData.RoleId <= 0)
			{
				return;
			}
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.PinballWeaponReplaceConfirm);
			confirmBoxDataNew.IsEscViewTriggerCallBack = false;
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				this.EquipCurSelectedWeapon();
			};
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew(pinballWeaponData.Name, null);
			string localTextNew2 = ConfigMultiTextLang.GetLocalTextNew(ModelBase<PinballModel>.Instance.GetRoleNameByPinballRoleId(pinballWeaponData.RoleId), null);
			confirmBoxDataNew.TextArgs = new string[]
			{
				localTextNew,
				localTextNew2
			};
			ControllerBase<PinballController>.Instance.OpenPinballSmallConfirmBoxView(confirmBoxDataNew);
		}

		// Token: 0x06041063 RID: 266339 RVA: 0x010AF180 File Offset: 0x010AD380
		public UniTask EquipCurSelectedWeaponAsync()
		{
			PinballWeaponEquipView.<EquipCurSelectedWeaponAsync>d__38 <EquipCurSelectedWeaponAsync>d__;
			<EquipCurSelectedWeaponAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<EquipCurSelectedWeaponAsync>d__.<>4__this = this;
			<EquipCurSelectedWeaponAsync>d__.<>1__state = -1;
			<EquipCurSelectedWeaponAsync>d__.<>t__builder.Start<PinballWeaponEquipView.<EquipCurSelectedWeaponAsync>d__38>(ref <EquipCurSelectedWeaponAsync>d__);
			return <EquipCurSelectedWeaponAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041064 RID: 266340 RVA: 0x010AF1C4 File Offset: 0x010AD3C4
		private void RefreshGridsByQuality(int quality)
		{
			if (quality <= 0)
			{
				return;
			}
			for (int i = 0; i < this.GridDataList.Count; i++)
			{
				if (this.GridDataList[i].GetTemplateIndex() == 1 && (this.GridDataList[i] as PinballWeaponMultiTemplateGridData).Data.WeaponData.Quality == quality)
				{
					this.RefreshGridByIndex(i);
				}
			}
		}

		// Token: 0x06041065 RID: 266341 RVA: 0x010AF22C File Offset: 0x010AD42C
		private void RefreshGridByWeaponIncId(int weaponIncId)
		{
			if (weaponIncId <= 0)
			{
				return;
			}
			int gridIndexByWeaponIncId = this.GetGridIndexByWeaponIncId(weaponIncId);
			if (gridIndexByWeaponIncId < 0)
			{
				return;
			}
			this.RefreshGridByIndex(gridIndexByWeaponIncId);
		}

		// Token: 0x06041066 RID: 266342 RVA: 0x010AF252 File Offset: 0x010AD452
		private void RefreshGridByIndex(int gridIndex)
		{
			if (gridIndex < 0)
			{
				return;
			}
			MultiTemplateScrollView weaponMultiTemplateScrollView = this.WeaponMultiTemplateScrollView;
			if (weaponMultiTemplateScrollView == null)
			{
				return;
			}
			weaponMultiTemplateScrollView.RefreshProxyDirectly(gridIndex);
		}

		// Token: 0x06041067 RID: 266343 RVA: 0x010AF26C File Offset: 0x010AD46C
		private int GetCurEquipWeaponIncId()
		{
			IPinballWeaponEquipViewData data = this.Data;
			PinballRoleDataBase pinballRoleDataBase = (data != null) ? data.RoleData : null;
			if (pinballRoleDataBase == null)
			{
				return 0;
			}
			PinballWeaponData weaponData = pinballRoleDataBase.GetWeaponData();
			if (weaponData == null)
			{
				return 0;
			}
			return weaponData.IncId;
		}

		// Token: 0x06041068 RID: 266344 RVA: 0x010AF2A4 File Offset: 0x010AD4A4
		private PinballWeaponMultiTemplateGridData GetGridDataByWeaponIncId(int weaponIncId)
		{
			foreach (IMultiTemplateGridData multiTemplateGridData in this.GridDataList)
			{
				if (multiTemplateGridData.GetTemplateIndex() == 1)
				{
					PinballWeaponMultiTemplateGridData pinballWeaponMultiTemplateGridData = multiTemplateGridData as PinballWeaponMultiTemplateGridData;
					if (pinballWeaponMultiTemplateGridData.Data.WeaponData.IncId == weaponIncId)
					{
						return pinballWeaponMultiTemplateGridData;
					}
				}
			}
			return null;
		}

		// Token: 0x06041069 RID: 266345 RVA: 0x010AF31C File Offset: 0x010AD51C
		private int GetGridIndexByWeaponIncId(int weaponIncId)
		{
			for (int i = 0; i < this.GridDataList.Count; i++)
			{
				if (this.GridDataList[i].GetTemplateIndex() == 1 && (this.GridDataList[i] as PinballWeaponMultiTemplateGridData).Data.WeaponData.IncId == weaponIncId)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x0604106A RID: 266346 RVA: 0x010AF37C File Offset: 0x010AD57C
		private IPinballItemSyncWeaponGridViewData BuildWeaponGridData(PinballWeaponData weaponData, bool canEquip, bool isCurRoleEquip)
		{
			int qualityId = ConfigBase<PinballConfig>.Instance.GetPinballWeaponConfigById(weaponData.Id).Value.QualityId;
			return new PinballItemSyncWeaponGridViewData
			{
				WeaponData = weaponData,
				IsSelected = false,
				CanEquip = canEquip,
				IsCurRoleEquip = isCurRoleEquip,
				QualityId = qualityId,
				OnStateChangeDelegate = new Action<IPinballItemToggleCallback>(this.OnWeaponGridStateChange),
				RoleId = this.Data.RoleData.GetId()
			};
		}

		// Token: 0x0604106B RID: 266347 RVA: 0x010AF3FC File Offset: 0x010AD5FC
		private void CheckToShowOverCapacityConfirm()
		{
			if (this.AllWeaponGridDataList.Count >= this.Capacity)
			{
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.PinballWeaponOverCapacityConfirm);
				confirmBoxDataNew.IsEscViewTriggerCallBack = false;
				confirmBoxDataNew.FunctionMap[2] = delegate()
				{
					Singleton<UiManager>.Instance.OpenView(EUiViewName.PinballWeaponDecomposeView, null, null);
				};
				ControllerBase<PinballController>.Instance.OpenPinballSmallConfirmBoxView(confirmBoxDataNew);
			}
		}

		// Token: 0x0604106C RID: 266348 RVA: 0x010AF464 File Offset: 0x010AD664
		private void OnPinballWeaponLockChanged(int incId, bool bLock)
		{
			this.RefreshGridByWeaponIncId(incId);
		}

		// Token: 0x0604106D RID: 266349 RVA: 0x010AF470 File Offset: 0x010AD670
		private void OnSortResult(List<IMultiTemplateGridData> dataList, bool isOutSideChange, EFilterSortType operationType)
		{
			this.UpdateGridData(dataList);
			if (this.SelectedGridData != null)
			{
				this.SelectedIndex = -1;
				for (int i = 0; i < this.GridDataList.Count; i++)
				{
					if (this.GridDataList[i] == this.SelectedGridData)
					{
						this.SelectedIndex = i;
						break;
					}
				}
			}
			else
			{
				this.SelectedIndex = -1;
			}
			if (!isOutSideChange)
			{
				this.RefreshGrids();
			}
		}

		// Token: 0x0604106E RID: 266350 RVA: 0x010AF4D8 File Offset: 0x010AD6D8
		private void OnWeaponGridStateChange(IPinballItemToggleCallback callbackParameter)
		{
			if (callbackParameter.State == EToggleState.ETT_Checked)
			{
				PinballItemSyncWeaponGridView pinballItemSyncWeaponGridView = callbackParameter.View as PinballItemSyncWeaponGridView;
				this.SelectGrid(pinballItemSyncWeaponGridView.GridIndex);
			}
		}

		// Token: 0x0604106F RID: 266351 RVA: 0x010AF508 File Offset: 0x010AD708
		private void OnClickEquipButton()
		{
			IPinballWeaponEquipTipItemData curSelectedWeaponTipData = this.CurSelectedWeaponTipData;
			PinballWeaponData pinballWeaponData = (curSelectedWeaponTipData != null) ? curSelectedWeaponTipData.WeaponData : null;
			if (pinballWeaponData == null)
			{
				return;
			}
			int roleId = pinballWeaponData.RoleId;
			if (roleId > 0)
			{
				int num = roleId;
				IPinballWeaponEquipViewData data = this.Data;
				int? num2 = (data != null) ? new int?(data.RoleData.GetId()) : null;
				if (!(num == num2.GetValueOrDefault() & num2 != null))
				{
					this.OpenReplaceConfirmView();
					return;
				}
			}
			this.EquipCurSelectedWeapon();
		}

		// Token: 0x06041070 RID: 266352 RVA: 0x010AF57D File Offset: 0x010AD77D
		private void OnClickContrastToggle(EToggleState state)
		{
			this.IsContrastEnabled = (state == EToggleState.ETT_Checked);
			this.RefreshCurEquipWeaponTipShowState();
		}

		// Token: 0x06041071 RID: 266353 RVA: 0x010AF58F File Offset: 0x010AD78F
		private void OnClickDecomposeButton()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PinballWeaponDecomposeView, null, null);
		}

		// Token: 0x06041072 RID: 266354 RVA: 0x010AF5A2 File Offset: 0x010AD7A2
		private void OnClickClose()
		{
			base.CloseMe(null);
		}

		// Token: 0x06041073 RID: 266355 RVA: 0x010AF5AC File Offset: 0x010AD7AC
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams.Length == 0)
			{
				return null;
			}
			if (!(configParams[0] == "WeaponGrid"))
			{
				return null;
			}
			if (configParams.Length < 2)
			{
				return null;
			}
			int num = int.Parse(configParams[1]);
			if (num < 0 || num >= this.GridDataList.Count)
			{
				return null;
			}
			MultiTemplateScrollView weaponMultiTemplateScrollView = this.WeaponMultiTemplateScrollView;
			PinballItemSyncWeaponGridView pinballItemSyncWeaponGridView = ((weaponMultiTemplateScrollView != null) ? weaponMultiTemplateScrollView.GetProxyByGridIndex(num) : null) as PinballItemSyncWeaponGridView;
			UUIItem uuiitem = (pinballItemSyncWeaponGridView != null) ? pinballItemSyncWeaponGridView.GetWeaponItemToggleRootUiItem() : null;
			if (uuiitem == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				uuiitem,
				uuiitem
			};
		}

		// Token: 0x04024739 RID: 149305
		private int SelectedIndex = -1;

		// Token: 0x0402473A RID: 149306
		private PinballWeaponMultiTemplateGridData SelectedGridData;

		// Token: 0x0402473B RID: 149307
		private IPinballWeaponEquipViewData Data;

		// Token: 0x0402473C RID: 149308
		private bool IsContrastEnabled;

		// Token: 0x0402473D RID: 149309
		private int Capacity;

		// Token: 0x0402473E RID: 149310
		protected List<IMultiTemplateGridData> GridDataList = new List<IMultiTemplateGridData>();

		// Token: 0x0402473F RID: 149311
		protected List<IMultiTemplateGridData> CanEquipWeaponGridDataList = new List<IMultiTemplateGridData>();

		// Token: 0x04024740 RID: 149312
		protected List<IMultiTemplateGridData> CanNotEquipWeaponGridDataList = new List<IMultiTemplateGridData>();

		// Token: 0x04024741 RID: 149313
		protected List<IMultiTemplateGridData> AllWeaponGridDataList = new List<IMultiTemplateGridData>();

		// Token: 0x04024742 RID: 149314
		protected IPinballWeaponEquipTipItemData CurSelectedWeaponTipData;

		// Token: 0x04024743 RID: 149315
		protected IPinballWeaponEquipTipItemData CurEquipWeaponTipData;

		// Token: 0x04024744 RID: 149316
		protected PinballWeaponEquipTipItem CurEquipWeaponTipItem;

		// Token: 0x04024745 RID: 149317
		protected PinballWeaponEquipTipItem CurSelectedWeaponTipItem;

		// Token: 0x04024746 RID: 149318
		protected MultiTemplateScrollView WeaponMultiTemplateScrollView;

		// Token: 0x04024747 RID: 149319
		protected PopupCaptionItem CaptionItem;

		// Token: 0x04024748 RID: 149320
		protected FilterSortEntrance<IMultiTemplateGridData> FilterSortEntrance;

		// Token: 0x0200C5A0 RID: 50592
		[NullableContext(0)]
		private enum EComponent
		{
			// Token: 0x0403CD2E RID: 249134
			CaptionItem,
			// Token: 0x0403CD2F RID: 249135
			ContrastToggle,
			// Token: 0x0403CD30 RID: 249136
			WeaponMultiTemplateScrollView,
			// Token: 0x0403CD31 RID: 249137
			WeaponCountText,
			// Token: 0x0403CD32 RID: 249138
			SortFilterItem,
			// Token: 0x0403CD33 RID: 249139
			DecomposeButton,
			// Token: 0x0403CD34 RID: 249140
			PaddingItem,
			// Token: 0x0403CD35 RID: 249141
			CurEquipWeaponTipRootItem,
			// Token: 0x0403CD36 RID: 249142
			CurEquipWeaponTipItem,
			// Token: 0x0403CD37 RID: 249143
			CurSelectedWeaponTipRootItem,
			// Token: 0x0403CD38 RID: 249144
			CurSelectedWeaponTipItem
		}
	}
}
