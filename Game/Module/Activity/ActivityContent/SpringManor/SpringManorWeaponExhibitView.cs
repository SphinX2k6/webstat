using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.NewWorld.SceneItem;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SpringManor
{
	// Token: 0x02006319 RID: 25369
	[NullableContext(1)]
	[Nullable(0)]
	public class SpringManorWeaponExhibitView : UiViewBase
	{
		// Token: 0x0603FC15 RID: 261141 RVA: 0x01058464 File Offset: 0x01056664
		public SpringManorWeaponExhibitView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603FC16 RID: 261142 RVA: 0x010584B8 File Offset: 0x010566B8
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUILoopScrollViewComponent)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUIItem)),
				new ValueTuple<int, Type>(12, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(13, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(13, new Action(this.OnClickBtnRemove))
			};
		}

		// Token: 0x0603FC17 RID: 261143 RVA: 0x01058600 File Offset: 0x01056800
		protected override UniTask OnBeforeStartAsync()
		{
			SpringManorWeaponExhibitView.<OnBeforeStartAsync>d__13 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SpringManorWeaponExhibitView.<OnBeforeStartAsync>d__13>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603FC18 RID: 261144 RVA: 0x01058643 File Offset: 0x01056843
		protected override void OnBeforeShow()
		{
			this.RefreshWeaponList();
		}

		// Token: 0x0603FC19 RID: 261145 RVA: 0x0105864B File Offset: 0x0105684B
		protected override void OnBeforeDestroy()
		{
			Singleton<UiCameraAnimationManager>.Instance.EnablePlayerActor();
			FilterSortEntrance<int> filterSortComponent = this.FilterSortComponent;
			if (filterSortComponent != null)
			{
				filterSortComponent.ClearData(EFilterSortGroupId.SpringManorWeaponExhibit);
			}
			this.ResetAllExhibitActiveState();
		}

		// Token: 0x0603FC1A RID: 261146 RVA: 0x01058670 File Offset: 0x01056870
		private void SelectFirstWeaponSlot()
		{
			if (this.WeaponTogList.Count > 0)
			{
				int num = this.WeaponSlotAssignments.FindIndex((int itemId) => itemId == 0);
				if (num < 0 || num >= this.WeaponTogList.Count)
				{
					num = 0;
				}
				this.OnWeaponToggleSelected(num);
			}
			else
			{
				this.SelectedToggleIndex = -1;
			}
			this.RefreshOperationButtonState();
		}

		// Token: 0x0603FC1B RID: 261147 RVA: 0x010586E0 File Offset: 0x010568E0
		private UniTask CreateWeaponTogsAsync()
		{
			SpringManorWeaponExhibitView.<CreateWeaponTogsAsync>d__17 <CreateWeaponTogsAsync>d__;
			<CreateWeaponTogsAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateWeaponTogsAsync>d__.<>4__this = this;
			<CreateWeaponTogsAsync>d__.<>1__state = -1;
			<CreateWeaponTogsAsync>d__.<>t__builder.Start<SpringManorWeaponExhibitView.<CreateWeaponTogsAsync>d__17>(ref <CreateWeaponTogsAsync>d__);
			return <CreateWeaponTogsAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603FC1C RID: 261148 RVA: 0x01058724 File Offset: 0x01056924
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		private UniTask<SpringManorWeaponSlotToggle> CreateToggleAsync(int componentId)
		{
			SpringManorWeaponExhibitView.<CreateToggleAsync>d__18 <CreateToggleAsync>d__;
			<CreateToggleAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<SpringManorWeaponSlotToggle>.Create();
			<CreateToggleAsync>d__.<>4__this = this;
			<CreateToggleAsync>d__.componentId = componentId;
			<CreateToggleAsync>d__.<>1__state = -1;
			<CreateToggleAsync>d__.<>t__builder.Start<SpringManorWeaponExhibitView.<CreateToggleAsync>d__18>(ref <CreateToggleAsync>d__);
			return <CreateToggleAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603FC1D RID: 261149 RVA: 0x01058770 File Offset: 0x01056970
		private void InitWeaponScrollView()
		{
			UUILoopScrollViewComponent loopScrollViewComponent = base.GetLoopScrollViewComponent(6);
			UUIItem item = base.GetItem(7);
			AUIBaseActor auibaseActor = ((item != null) ? item.GetOwner() : null) as AUIBaseActor;
			if (loopScrollViewComponent == null || auibaseActor == null)
			{
				return;
			}
			this.WeaponScrollView = new LoopScrollView<SpringManorWeaponExhibitGrid, SpringManorWeaponExhibitItem>(loopScrollViewComponent, auibaseActor, new Func<SpringManorWeaponExhibitGrid>(this.CreateWeaponGrid), false);
		}

		// Token: 0x0603FC1E RID: 261150 RVA: 0x010587C0 File Offset: 0x010569C0
		private void InitFilterSortEntrance()
		{
			UUIItem item = base.GetItem(9);
			if (item == null)
			{
				return;
			}
			this.FilterSortComponent = new FilterSortEntrance<int>(item, new TUpdateDataListFunction<int>(this.OnFilterSortRefresh));
		}

		// Token: 0x0603FC1F RID: 261151 RVA: 0x010587F2 File Offset: 0x010569F2
		private SpringManorWeaponExhibitGrid CreateWeaponGrid()
		{
			SpringManorWeaponExhibitGrid springManorWeaponExhibitGrid = new SpringManorWeaponExhibitGrid();
			springManorWeaponExhibitGrid.BindOnWeaponSelected(new Action<int, int>(this.OnWeaponGridSelected));
			return springManorWeaponExhibitGrid;
		}

		// Token: 0x0603FC20 RID: 261152 RVA: 0x0105880C File Offset: 0x01056A0C
		private UniTask InitCaptionAsync()
		{
			SpringManorWeaponExhibitView.<InitCaptionAsync>d__22 <InitCaptionAsync>d__;
			<InitCaptionAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitCaptionAsync>d__.<>4__this = this;
			<InitCaptionAsync>d__.<>1__state = -1;
			<InitCaptionAsync>d__.<>t__builder.Start<SpringManorWeaponExhibitView.<InitCaptionAsync>d__22>(ref <InitCaptionAsync>d__);
			return <InitCaptionAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603FC21 RID: 261153 RVA: 0x01058850 File Offset: 0x01056A50
		private List<int> CreateWeaponItemViewDataList(List<WeaponItemData> sourceList)
		{
			List<int> list = new List<int>();
			this.WeaponItemLookup.Clear();
			HashSet<int> hashSet = new HashSet<int>();
			foreach (WeaponItemData weaponItemData in sourceList)
			{
				int configId = weaponItemData.GetConfigId();
				if (!hashSet.Contains(configId) && weaponItemData.GetQuality() >= 4)
				{
					hashSet.Add(configId);
					SpringManorWeaponExhibitItem value = new SpringManorWeaponExhibitItem
					{
						ConfigId = configId,
						IsSelected = false
					};
					this.WeaponItemLookup.Add(configId, value);
					list.Add(configId);
				}
			}
			return list;
		}

		// Token: 0x0603FC22 RID: 261154 RVA: 0x01058900 File Offset: 0x01056B00
		private void RefreshWeaponList()
		{
			List<WeaponItemData> weaponItemDataList = ModelBase<InventoryModel>.Instance.GetWeaponItemDataList();
			List<int> dataList = this.CreateWeaponItemViewDataList(weaponItemDataList);
			this.FilterSortComponent.UpdateData(EFilterSortGroupId.SpringManorWeaponExhibit, dataList, Array.Empty<object>());
		}

		// Token: 0x0603FC23 RID: 261155 RVA: 0x01058934 File Offset: 0x01056B34
		private List<SpringManorWeaponExhibitItem> SortPlacedWeaponFirst(List<SpringManorWeaponExhibitItem> dataList)
		{
			Dictionary<int, int> assignedOrder = new Dictionary<int, int>();
			for (int i = 0; i < this.WeaponSlotAssignments.Count; i++)
			{
				int num = this.WeaponSlotAssignments[i];
				if (num != 0)
				{
					assignedOrder.Add(num, i);
				}
			}
			if (assignedOrder.Count == 0)
			{
				return dataList;
			}
			List<SpringManorWeaponExhibitItem> list = new List<SpringManorWeaponExhibitItem>();
			List<SpringManorWeaponExhibitItem> list2 = new List<SpringManorWeaponExhibitItem>();
			foreach (SpringManorWeaponExhibitItem springManorWeaponExhibitItem in dataList)
			{
				if (assignedOrder.ContainsKey(springManorWeaponExhibitItem.ConfigId))
				{
					list.Add(springManorWeaponExhibitItem);
				}
				else
				{
					list2.Add(springManorWeaponExhibitItem);
				}
			}
			list.Sort(delegate(SpringManorWeaponExhibitItem a, SpringManorWeaponExhibitItem b)
			{
				int num2 = assignedOrder[a.ConfigId];
				int num3 = assignedOrder[b.ConfigId];
				return num2 - num3;
			});
			List<SpringManorWeaponExhibitItem> list3 = new List<SpringManorWeaponExhibitItem>(list);
			list3.AddRange(list2);
			return list3;
		}

		// Token: 0x0603FC24 RID: 261156 RVA: 0x01058A24 File Offset: 0x01056C24
		private void ApplyWeaponList(List<SpringManorWeaponExhibitItem> dataList)
		{
			this.WeaponViewDataList = this.SortPlacedWeaponFirst(dataList);
			bool flag = this.WeaponViewDataList.Count > 0;
			UUIItem item = base.GetItem(8);
			if (item != null)
			{
				item.SetUIActive(!flag);
			}
			this.RefreshWeaponGridDataSource();
		}

		// Token: 0x0603FC25 RID: 261157 RVA: 0x01058A6C File Offset: 0x01056C6C
		private void OnFilterSortRefresh(List<int> list, bool isOutSideChange, EFilterSortType operationType)
		{
			List<int> list2 = list ?? new List<int>();
			List<SpringManorWeaponExhibitItem> list3 = new List<SpringManorWeaponExhibitItem>();
			foreach (int key in list2)
			{
				list3.Add(this.WeaponItemLookup[key]);
			}
			this.ApplyWeaponList(list3);
		}

		// Token: 0x0603FC26 RID: 261158 RVA: 0x01058ADC File Offset: 0x01056CDC
		private void RefreshToggleSelectState(int selectIndex)
		{
			if (this.WeaponTogList.Count == 0)
			{
				this.SelectedToggleIndex = -1;
				return;
			}
			int num = selectIndex;
			if (num < 0 || num >= this.WeaponTogList.Count)
			{
				num = 0;
			}
			this.SelectedToggleIndex = num;
			for (int i = 0; i < this.WeaponTogList.Count; i++)
			{
				this.WeaponTogList[i].SetSelected(i == num);
			}
		}

		// Token: 0x0603FC27 RID: 261159 RVA: 0x01058B46 File Offset: 0x01056D46
		private void OnWeaponGridSelected(int configId, int gridIndex)
		{
			this.SelectedConfigId = new int?(configId);
			this.WeaponScrollView.DeselectCurrentGridProxy(false);
			this.WeaponScrollView.SelectGridProxy(gridIndex, false);
			this.OnClickBtnPut();
		}

		// Token: 0x0603FC28 RID: 261160 RVA: 0x01058B74 File Offset: 0x01056D74
		private void RefreshOperationButtonState()
		{
			bool flag = this.SelectedToggleIndex >= 0 && this.SelectedToggleIndex < this.WeaponTogList.Count;
			if (!flag)
			{
				return;
			}
			UUIButtonComponent button = base.GetButton(13);
			if (button == null)
			{
				return;
			}
			bool selfInteractive;
			if (flag)
			{
				int? selectedConfigId = this.SelectedConfigId;
				int num = this.WeaponSlotAssignments[this.SelectedToggleIndex];
				selfInteractive = (selectedConfigId.GetValueOrDefault() == num & selectedConfigId != null);
			}
			else
			{
				selfInteractive = false;
			}
			button.SetSelfInteractive(selfInteractive);
		}

		// Token: 0x0603FC29 RID: 261161 RVA: 0x01058BE8 File Offset: 0x01056DE8
		private void ScrollWeaponListToItemId(int itemId)
		{
			int num = this.WeaponViewDataList.FindIndex((SpringManorWeaponExhibitItem weaponData) => weaponData.ConfigId == itemId);
			if (num < 0)
			{
				return;
			}
			this.SelectedConfigId = new int?(this.WeaponViewDataList[num].ConfigId);
			this.WeaponScrollView.ScrollToGridIndex(num, false);
			this.WeaponScrollView.SelectGridProxy(num, false);
			this.OnWeaponGridSelected(this.SelectedConfigId.Value, num);
		}

		// Token: 0x0603FC2A RID: 261162 RVA: 0x01058C68 File Offset: 0x01056E68
		private void RefreshWeaponGridDataSource()
		{
			this.UpdateWeaponSelectState();
			this.WeaponScrollView.RefreshByData(this.WeaponViewDataList, false, null, true);
			bool flag = this.WeaponViewDataList.Count > 0;
			if (this.SelectedConfigId == null)
			{
				this.WeaponScrollView.DeselectCurrentGridProxy(false);
				return;
			}
			if (flag)
			{
				int num = this.WeaponSlotAssignments[this.SelectedToggleIndex];
				if (num != 0)
				{
					this.ScrollWeaponListToItemId(num);
					return;
				}
				this.ScrollWeaponListToItemId(this.SelectedConfigId.Value);
			}
		}

		// Token: 0x0603FC2B RID: 261163 RVA: 0x01058CEC File Offset: 0x01056EEC
		private void UpdateWeaponSelectState()
		{
			HashSet<int> hashSet = new HashSet<int>();
			foreach (int num in this.WeaponSlotAssignments)
			{
				if (num != 0)
				{
					hashSet.Add(num);
				}
			}
			foreach (SpringManorWeaponExhibitItem springManorWeaponExhibitItem in this.WeaponViewDataList)
			{
				bool isSelected = hashSet.Contains(springManorWeaponExhibitItem.ConfigId);
				springManorWeaponExhibitItem.IsSelected = isSelected;
			}
		}

		// Token: 0x0603FC2C RID: 261164 RVA: 0x01058DA0 File Offset: 0x01056FA0
		[NullableContext(2)]
		private SceneItemExhibitComponent GetExhibitComponent(int pbDataId)
		{
			EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(pbDataId);
			if (entityByPbDataId == null)
			{
				return null;
			}
			SceneItemExhibitComponent component = entityByPbDataId.Entity.GetComponent<SceneItemExhibitComponent>();
			if (component == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SceneItem;
				ELogAuthor author = ELogAuthor.BB;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(46, 1);
				defaultInterpolatedStringHandler.AppendLiteral("刷新场景物品展示模型失败，PbDataId: ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(pbDataId);
				defaultInterpolatedStringHandler.AppendLiteral("，Entity没有ActorComponent");
				instance.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				return null;
			}
			return component;
		}

		// Token: 0x0603FC2D RID: 261165 RVA: 0x01058E18 File Offset: 0x01057018
		private bool RefreshSceneItemExhibit(int pbDataId, int weaponGuid)
		{
			SceneItemExhibitComponent exhibitComponent = this.GetExhibitComponent(pbDataId);
			if (exhibitComponent == null)
			{
				return false;
			}
			if (weaponGuid == 0)
			{
				exhibitComponent.HideSkeletalMeshComponent();
			}
			else
			{
				exhibitComponent.RefreshSkeletalMeshComponent(weaponGuid, false);
			}
			return true;
		}

		// Token: 0x0603FC2E RID: 261166 RVA: 0x01058E48 File Offset: 0x01057048
		private void ResetExhibitToOrigin()
		{
			if (this.ExhibitPbDataIdList == null)
			{
				return;
			}
			for (int i = 0; i < this.ExhibitPbDataIdList.Count; i++)
			{
				int pbDataId = this.ExhibitPbDataIdList[i];
				int weaponGuid = this.OriginWeaponIdList[i];
				this.RefreshSceneItemExhibit(pbDataId, weaponGuid);
			}
		}

		// Token: 0x0603FC2F RID: 261167 RVA: 0x01058E98 File Offset: 0x01057098
		private void UpdateExhibitActiveState(int? previousIndex, int currentIndex)
		{
			if (this.ExhibitPbDataIdList == null)
			{
				return;
			}
			if (previousIndex != null)
			{
				int? num = previousIndex;
				int num2 = 0;
				if (num.GetValueOrDefault() >= num2 & num != null)
				{
					num = previousIndex;
					num2 = this.ExhibitPbDataIdList.Count;
					if (num.GetValueOrDefault() < num2 & num != null)
					{
						int pbDataId = this.ExhibitPbDataIdList[previousIndex.Value];
						SceneItemExhibitComponent exhibitComponent = this.GetExhibitComponent(pbDataId);
						if (exhibitComponent != null)
						{
							exhibitComponent.SetExhibitShowEffect(false);
						}
					}
				}
			}
			if (currentIndex >= 0 && currentIndex < this.ExhibitPbDataIdList.Count)
			{
				int pbDataId2 = this.ExhibitPbDataIdList[currentIndex];
				SceneItemExhibitComponent exhibitComponent2 = this.GetExhibitComponent(pbDataId2);
				if (exhibitComponent2 == null)
				{
					return;
				}
				exhibitComponent2.SetExhibitShowEffect(true);
			}
		}

		// Token: 0x0603FC30 RID: 261168 RVA: 0x01058F4C File Offset: 0x0105714C
		private void ResetAllExhibitActiveState()
		{
			if (this.ExhibitPbDataIdList == null)
			{
				return;
			}
			foreach (int pbDataId in this.ExhibitPbDataIdList)
			{
				SceneItemExhibitComponent exhibitComponent = this.GetExhibitComponent(pbDataId);
				if (exhibitComponent != null)
				{
					exhibitComponent.SetExhibitShowEffect(false);
				}
			}
		}

		// Token: 0x0603FC31 RID: 261169 RVA: 0x01058FB4 File Offset: 0x010571B4
		private bool IsWeaponAssignmentsModified()
		{
			if (this.ExhibitPbDataIdList == null)
			{
				return false;
			}
			for (int i = 0; i < this.ExhibitPbDataIdList.Count; i++)
			{
				int num = this.OriginWeaponIdList[i];
				if (this.WeaponSlotAssignments[i] != num)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0603FC32 RID: 261170 RVA: 0x01059000 File Offset: 0x01057200
		private void OnClickBtnPut()
		{
			if (this.SelectedToggleIndex < 0)
			{
				return;
			}
			if (this.SelectedConfigId == null)
			{
				return;
			}
			if (this.SelectedToggleIndex >= this.WeaponTogList.Count)
			{
				return;
			}
			int weaponItemId = this.SelectedConfigId.Value;
			int num = this.WeaponSlotAssignments.FindIndex((int itemId) => itemId == weaponItemId);
			if (num >= 0 && num != this.SelectedToggleIndex)
			{
				List<int> exhibitPbDataIdList = this.ExhibitPbDataIdList;
				int? num2 = (exhibitPbDataIdList != null) ? new int?(exhibitPbDataIdList[num]) : null;
				this.WeaponSlotAssignments[num] = 0;
				SpringManorWeaponSlotToggle springManorWeaponSlotToggle = this.WeaponTogList[num];
				if (springManorWeaponSlotToggle != null)
				{
					springManorWeaponSlotToggle.SetWeaponItemId(0);
				}
				if (num2 != null)
				{
					this.RefreshSceneItemExhibit(num2.Value, 0);
				}
			}
			this.WeaponSlotAssignments[this.SelectedToggleIndex] = weaponItemId;
			SpringManorWeaponSlotToggle springManorWeaponSlotToggle2 = this.WeaponTogList[this.SelectedToggleIndex];
			if (springManorWeaponSlotToggle2 != null)
			{
				springManorWeaponSlotToggle2.SetWeaponItemId(weaponItemId);
			}
			this.UpdateWeaponSelectState();
			this.WeaponScrollView.RefreshAllGridProxies();
			List<int> exhibitPbDataIdList2 = this.ExhibitPbDataIdList;
			int? num3 = (exhibitPbDataIdList2 != null) ? new int?(exhibitPbDataIdList2[this.SelectedToggleIndex]) : null;
			if (num3 != null)
			{
				this.RefreshSceneItemExhibit(num3.Value, this.SelectedConfigId.Value);
			}
			this.RefreshOperationButtonState();
		}

		// Token: 0x0603FC33 RID: 261171 RVA: 0x01059170 File Offset: 0x01057370
		private void OnClickBtnRemove()
		{
			if (this.SelectedToggleIndex < 0 || this.SelectedToggleIndex >= this.WeaponTogList.Count)
			{
				return;
			}
			if (this.WeaponSlotAssignments[this.SelectedToggleIndex] == 0)
			{
				return;
			}
			this.WeaponSlotAssignments[this.SelectedToggleIndex] = 0;
			SpringManorWeaponSlotToggle springManorWeaponSlotToggle = this.WeaponTogList[this.SelectedToggleIndex];
			if (springManorWeaponSlotToggle != null)
			{
				springManorWeaponSlotToggle.SetWeaponItemId(0);
			}
			List<int> exhibitPbDataIdList = this.ExhibitPbDataIdList;
			int? num = (exhibitPbDataIdList != null) ? new int?(exhibitPbDataIdList[this.SelectedToggleIndex]) : null;
			if (num != null)
			{
				this.RefreshSceneItemExhibit(num.Value, 0);
			}
			this.UpdateWeaponSelectState();
			this.WeaponScrollView.RefreshAllGridProxies();
			this.RefreshOperationButtonState();
		}

		// Token: 0x0603FC34 RID: 261172 RVA: 0x01059234 File Offset: 0x01057434
		private List<EntityItemBundleInfo> BuildWeaponBundleInfos()
		{
			List<EntityItemBundleInfo> list = new List<EntityItemBundleInfo>();
			if (this.ExhibitPbDataIdList == null)
			{
				return list;
			}
			for (int i = 0; i < this.ExhibitPbDataIdList.Count; i++)
			{
				int pbDataId = this.ExhibitPbDataIdList[i];
				EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(pbDataId);
				if (entityByPbDataId != null)
				{
					int num = this.WeaponSlotAssignments[i];
					if (num != this.OriginWeaponIdList[i])
					{
						EntityItemBundleInfo entityItemBundleInfo = EntityItemBundleInfo.Create();
						entityItemBundleInfo.EntityId = Singleton<MathUtils>.Instance.NumberToLong(entityByPbDataId.CreatureDataId);
						entityItemBundleInfo.ItemId = num;
						list.Add(entityItemBundleInfo);
					}
				}
			}
			return list;
		}

		// Token: 0x0603FC35 RID: 261173 RVA: 0x010592D4 File Offset: 0x010574D4
		private void OnClickCloseBtn()
		{
			if (!this.IsWeaponAssignmentsModified())
			{
				base.CloseMe(null);
				return;
			}
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.SpringManorWeaponExhibitConfirm);
			confirmBoxDataNew.FunctionMap.Add(1, delegate
			{
				this.ResetExhibitToOrigin();
				base.CloseMe(null);
			});
			confirmBoxDataNew.FunctionMap.Add(2, delegate
			{
				List<EntityItemBundleInfo> bundleInfos = this.BuildWeaponBundleInfos();
				ControllerBase<SpringManorController>.Instance.RequestExhibitionSave(bundleInfos);
				base.CloseMe(null);
			});
			confirmBoxDataNew.IsEscViewTriggerCallBack = false;
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x0603FC36 RID: 261174 RVA: 0x01059340 File Offset: 0x01057540
		private void SwitchWeaponSlot(int targetIndex)
		{
			this.RefreshToggleSelectState(targetIndex);
			int num = this.WeaponSlotAssignments[targetIndex];
			if (num != 0)
			{
				this.ScrollWeaponListToItemId(num);
			}
			else
			{
				LoopScrollView<SpringManorWeaponExhibitGrid, SpringManorWeaponExhibitItem> weaponScrollView = this.WeaponScrollView;
				if (weaponScrollView != null)
				{
					weaponScrollView.DeselectCurrentGridProxy(false);
				}
				this.SelectedConfigId = null;
			}
			this.RefreshOperationButtonState();
		}

		// Token: 0x0603FC37 RID: 261175 RVA: 0x01059394 File Offset: 0x01057594
		private void OnWeaponToggleSelected(int index)
		{
			int selectedToggleIndex = this.SelectedToggleIndex;
			if (selectedToggleIndex == index)
			{
				this.RefreshToggleSelectState(index);
				return;
			}
			this.SwitchWeaponSlot(index);
			this.UpdateExhibitActiveState(new int?(selectedToggleIndex), index);
		}

		// Token: 0x04023CA0 RID: 146592
		private const int MIN_DISPLAY_WEAPON_QUALITY = 4;

		// Token: 0x04023CA1 RID: 146593
		private List<SpringManorWeaponSlotToggle> WeaponTogList = new List<SpringManorWeaponSlotToggle>();

		// Token: 0x04023CA2 RID: 146594
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private LoopScrollView<SpringManorWeaponExhibitGrid, SpringManorWeaponExhibitItem> WeaponScrollView;

		// Token: 0x04023CA3 RID: 146595
		private List<SpringManorWeaponExhibitItem> WeaponViewDataList = new List<SpringManorWeaponExhibitItem>();

		// Token: 0x04023CA4 RID: 146596
		private readonly Dictionary<int, SpringManorWeaponExhibitItem> WeaponItemLookup = new Dictionary<int, SpringManorWeaponExhibitItem>();

		// Token: 0x04023CA5 RID: 146597
		[Nullable(2)]
		private FilterSortEntrance<int> FilterSortComponent;

		// Token: 0x04023CA6 RID: 146598
		private List<int> WeaponSlotAssignments = new List<int>();

		// Token: 0x04023CA7 RID: 146599
		private int SelectedToggleIndex = -1;

		// Token: 0x04023CA8 RID: 146600
		private int? SelectedConfigId;

		// Token: 0x04023CA9 RID: 146601
		[Nullable(2)]
		private List<int> ExhibitPbDataIdList;

		// Token: 0x04023CAA RID: 146602
		private List<int> OriginWeaponIdList = new List<int>();
	}
}
