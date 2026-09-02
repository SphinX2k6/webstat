using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E42 RID: 20034
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseMonsterView : UiViewBase
	{
		// Token: 0x06033C7A RID: 212090 RVA: 0x00CF15B3 File Offset: 0x00CEF7B3
		public TrapDefenseMonsterView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06033C7B RID: 212091 RVA: 0x00CF15D4 File Offset: 0x00CEF7D4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 10;
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
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIDynScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06033C7C RID: 212092 RVA: 0x00CF1748 File Offset: 0x00CEF948
		protected override UniTask OnBeforeStartAsync()
		{
			TrapDefenseMonsterView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TrapDefenseMonsterView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06033C7D RID: 212093 RVA: 0x00CF178B File Offset: 0x00CEF98B
		protected override void OnStart()
		{
			this.InitTab();
		}

		// Token: 0x06033C7E RID: 212094 RVA: 0x00CF1794 File Offset: 0x00CEF994
		public void InitTab()
		{
			foreach (KeyValuePair<int, ShipTowerTeamTabItem> keyValuePair in this.TabComponent.GetTabItemMap())
			{
				int num;
				ShipTowerTeamTabItem shipTowerTeamTabItem;
				keyValuePair.Deconstruct(out num, out shipTowerTeamTabItem);
				int index = num;
				ShipTowerTeamTabItem shipTowerTeamTabItem2 = shipTowerTeamTabItem;
				shipTowerTeamTabItem2.UpdateName(this.TabDataList[index].TabNameKey);
				shipTowerTeamTabItem2.UpdateRedDotVisible(false);
			}
			this.TabComponent.SelectToggleByIndex(this.GetJumpTabIndex(), true, true);
		}

		// Token: 0x06033C7F RID: 212095 RVA: 0x00CF1824 File Offset: 0x00CEFA24
		public int GetJumpTabIndex()
		{
			ETrapDefenseMonsterTabType? jumpTabType = this.ViewModel.JumpTabType;
			if (jumpTabType != null)
			{
				ETrapDefenseMonsterTabType? jumpTabType3 = jumpTabType;
				ETrapDefenseMonsterTabType etrapDefenseMonsterTabType = ETrapDefenseMonsterTabType.MonsterType;
				if (!(jumpTabType3.GetValueOrDefault() == etrapDefenseMonsterTabType & jumpTabType3 != null))
				{
					return this.TabDataList.FindIndex(delegate(ITrapDefenseTab<ETrapDefenseMonsterTabType> tab)
					{
						ETrapDefenseMonsterTabType tabType = tab.TabType;
						ETrapDefenseMonsterTabType? jumpTabType2 = jumpTabType;
						return tabType == jumpTabType2.GetValueOrDefault() & jumpTabType2 != null;
					});
				}
			}
			return 0;
		}

		// Token: 0x06033C80 RID: 212096 RVA: 0x00CF188B File Offset: 0x00CEFA8B
		protected override void OnAddEventListener()
		{
		}

		// Token: 0x06033C81 RID: 212097 RVA: 0x00CF188D File Offset: 0x00CEFA8D
		protected override void OnRemoveEventListener()
		{
		}

		// Token: 0x06033C82 RID: 212098 RVA: 0x00CF188F File Offset: 0x00CEFA8F
		protected override void OnBeforeShow()
		{
		}

		// Token: 0x06033C83 RID: 212099 RVA: 0x00CF1891 File Offset: 0x00CEFA91
		protected override void OnBeforeDestroy()
		{
			this.ViewModel.OnViewClose();
		}

		// Token: 0x06033C84 RID: 212100 RVA: 0x00CF189E File Offset: 0x00CEFA9E
		protected override void OnAfterDestroy()
		{
		}

		// Token: 0x06033C85 RID: 212101 RVA: 0x00CF18A0 File Offset: 0x00CEFAA0
		public void OnBtnHelp()
		{
			int helpIdMonster = ConfigBase<TrapDefenseConfig>.Instance.GetHelpIdMonster();
			ControllerBase<HelpController>.Instance.OpenHelpById(helpIdMonster);
		}

		// Token: 0x06033C86 RID: 212102 RVA: 0x00CF18C3 File Offset: 0x00CEFAC3
		public void OnBtnClose()
		{
			base.CloseMe(null);
		}

		// Token: 0x06033C87 RID: 212103 RVA: 0x00CF18CC File Offset: 0x00CEFACC
		public ShipTowerTeamTabItem CreateTabItem([Nullable(2)] UUIItem item, int? index)
		{
			return new ShipTowerTeamTabItem();
		}

		// Token: 0x06033C88 RID: 212104 RVA: 0x00CF18D4 File Offset: 0x00CEFAD4
		public void OnClickTabItem(int index)
		{
			ETrapDefenseMonsterTabType tabType = this.TabDataList[index].TabType;
			if (tabType == ETrapDefenseMonsterTabType.MonsterType)
			{
				this.ShowMonsterType();
				return;
			}
			if (tabType != ETrapDefenseMonsterTabType.MonsterWave)
			{
				return;
			}
			this.ShowMonsterWaveDynamic();
		}

		// Token: 0x06033C89 RID: 212105 RVA: 0x00CF1908 File Offset: 0x00CEFB08
		public void SetTabItemContentShow(int childType)
		{
			foreach (int num in new List<int>
			{
				2,
				5
			})
			{
				UUIItem item = base.GetItem(num);
				if (item != null)
				{
					item.SetUIActive(childType == num);
				}
			}
		}

		// Token: 0x06033C8A RID: 212106 RVA: 0x00CF1978 File Offset: 0x00CEFB78
		public void ShowMonsterType()
		{
			this.SetTabItemContentShow(2);
			int lastSelectIndex = this.ScrollMonsterType.GetSelectedIndex();
			List<TrapDefenseMonsterTypeData> monsterTypeDataList = this.ViewModel.GetMonsterTypeDataList(true);
			this.ScrollMonsterType.RefreshByData(monsterTypeDataList, delegate
			{
				this.ScrollMonsterType.SelectGridProxy(Math.Max(lastSelectIndex, 0), false);
			}, true);
			bool flag = monsterTypeDataList.Count > 0;
			this.SetEmptyInfoVisible(!flag);
			this.PanelMonsterDesc.SetActive(flag);
		}

		// Token: 0x06033C8B RID: 212107 RVA: 0x00CF19F0 File Offset: 0x00CEFBF0
		public void ShowMonsterWaveDynamic()
		{
			this.ViewModel.GetMonsterTypeDataList(false);
			this.SetTabItemContentShow(5);
			List<TrapDefenseMonsterWaveData> monsterWaveDataList = this.ViewModel.GetMonsterWaveDataList();
			this.ScrollMonsterWaveDynamic.RefreshByData(monsterWaveDataList.ToArray(), true, false);
			this.ScrollToCheckDynamic(monsterWaveDataList);
			bool flag = monsterWaveDataList.Count > 0;
			this.SetEmptyInfoVisible(!flag);
			this.PanelMonsterDesc.SetActive(flag);
		}

		// Token: 0x06033C8C RID: 212108 RVA: 0x00CF1A58 File Offset: 0x00CEFC58
		public void ScrollToCheckDynamic(List<TrapDefenseMonsterWaveData> dataList)
		{
			if (this.FirstInitWave)
			{
				this.FirstInitWave = false;
				TrapDefenseMonsterWaveData curWave = dataList.Find((TrapDefenseMonsterWaveData wave) => wave.IsInTheCurrentWave());
				if (curWave != null)
				{
					int index = dataList.FindIndex((TrapDefenseMonsterWaveData wave) => wave == curWave);
					this.LateScrollToDynamic(index);
					this.SetWaveSelectMonsterData(curWave, curWave.GetMonsterDataList()[0]);
					return;
				}
			}
			if (this.ViewModel.IsSameLevel(null) && this.ViewModel.Model.BattleData.GetBatch() > dataList.Count)
			{
				int index2 = dataList.Count - 1;
				this.LateScrollToDynamic(index2);
				this.SetWaveSelectMonsterData(dataList[index2], dataList[index2].GetMonsterDataList()[0]);
			}
			if (this.ViewModel.WaveSelectMonsterData != null)
			{
				this.PanelMonsterDesc.UpdateData(this.ViewModel.WaveSelectMonsterData);
				return;
			}
			this.SetWaveSelectMonsterData(dataList[0], dataList[0].GetMonsterDataList()[0]);
		}

		// Token: 0x06033C8D RID: 212109 RVA: 0x00CF1B8C File Offset: 0x00CEFD8C
		public void LateScrollToDynamic(int index)
		{
			DynamicScrollView<TrapDefenseMonsterWaveItem, TrapDefenseMonsterWaveDynamicItem, TrapDefenseMonsterWaveData> scrollMonsterWaveDynamic = this.ScrollMonsterWaveDynamic;
			if (scrollMonsterWaveDynamic == null)
			{
				return;
			}
			scrollMonsterWaveDynamic.BindLateUpdate(delegate(float _)
			{
				DynamicScrollView<TrapDefenseMonsterWaveItem, TrapDefenseMonsterWaveDynamicItem, TrapDefenseMonsterWaveData> scrollMonsterWaveDynamic2 = this.ScrollMonsterWaveDynamic;
				if (scrollMonsterWaveDynamic2 != null)
				{
					scrollMonsterWaveDynamic2.ScrollToItemIndex(index, true, false);
				}
				DynamicScrollView<TrapDefenseMonsterWaveItem, TrapDefenseMonsterWaveDynamicItem, TrapDefenseMonsterWaveData> scrollMonsterWaveDynamic3 = this.ScrollMonsterWaveDynamic;
				if (scrollMonsterWaveDynamic3 == null)
				{
					return;
				}
				scrollMonsterWaveDynamic3.UnBindLateUpdate();
			});
		}

		// Token: 0x06033C8E RID: 212110 RVA: 0x00CF1BC9 File Offset: 0x00CEFDC9
		public void SetEmptyInfoVisible(bool visible)
		{
			UUIItem item = base.GetItem(8);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(visible);
		}

		// Token: 0x06033C8F RID: 212111 RVA: 0x00CF1BDD File Offset: 0x00CEFDDD
		public TrapDefenseMonsterTypeItem CreateItemMonsterType()
		{
			return new TrapDefenseMonsterTypeItem
			{
				OnSelectMonsterCallBack = new Action<TrapDefenseMonsterData>(this.OnSelectMonsterTypeMonster)
			};
		}

		// Token: 0x06033C90 RID: 212112 RVA: 0x00CF1BF6 File Offset: 0x00CEFDF6
		public TrapDefenseMonsterWaveItem CreateItemMonsterWave(TrapDefenseMonsterWaveData data, UUIItem uiItem, int index)
		{
			return new TrapDefenseMonsterWaveItem
			{
				OnSelectMonsterCallBack = new Action<TrapDefenseMonsterData, TrapDefenseMonsterWaveData>(this.OnSelectMonsterWaveMonster)
			};
		}

		// Token: 0x06033C91 RID: 212113 RVA: 0x00CF1C0F File Offset: 0x00CEFE0F
		public void OnSelectMonsterTypeMonster(TrapDefenseMonsterData data)
		{
			this.PanelMonsterDesc.UpdateData(data);
		}

		// Token: 0x06033C92 RID: 212114 RVA: 0x00CF1C1D File Offset: 0x00CEFE1D
		public void OnSelectMonsterWaveMonster(TrapDefenseMonsterData data, TrapDefenseMonsterWaveData waveData)
		{
			this.SetWaveSelectMonsterData(waveData, data);
			this.UpdateWaveSelectState();
		}

		// Token: 0x06033C93 RID: 212115 RVA: 0x00CF1C2D File Offset: 0x00CEFE2D
		public void SetWaveSelectMonsterData(TrapDefenseMonsterWaveData waveData, TrapDefenseMonsterData data)
		{
			this.ViewModel.SetWaveSelectMonsterData(waveData, data);
			this.PanelMonsterDesc.UpdateData(data);
		}

		// Token: 0x06033C94 RID: 212116 RVA: 0x00CF1C48 File Offset: 0x00CEFE48
		public void UpdateWaveSelectState()
		{
			TrapDefenseMonsterWaveItem[] scrollItemItems = this.ScrollMonsterWaveDynamic.GetScrollItemItems();
			for (int i = 0; i < scrollItemItems.Length; i++)
			{
				scrollItemItems[i].UpdateSelectState();
			}
		}

		// Token: 0x0401DF6F RID: 122735
		private bool FirstInitWave = true;

		// Token: 0x0401DF70 RID: 122736
		public PopupCaptionItem PopupCaption;

		// Token: 0x0401DF71 RID: 122737
		public TabComponent<ShipTowerTeamTabItem> TabComponent;

		// Token: 0x0401DF72 RID: 122738
		public List<ITrapDefenseTab<ETrapDefenseMonsterTabType>> TabDataList;

		// Token: 0x0401DF73 RID: 122739
		public GenericScrollViewNew<TrapDefenseMonsterTypeItem, TrapDefenseMonsterTypeData> ScrollMonsterType;

		// Token: 0x0401DF74 RID: 122740
		public DynamicScrollView<TrapDefenseMonsterWaveItem, TrapDefenseMonsterWaveDynamicItem, TrapDefenseMonsterWaveData> ScrollMonsterWaveDynamic;

		// Token: 0x0401DF75 RID: 122741
		public TrapDefenseMonsterDescPanel PanelMonsterDesc;

		// Token: 0x0401DF76 RID: 122742
		public TrapDefenseMonsterViewModel ViewModel = ModelBase<TrapDefenseModel>.Instance.ViewModelMonster;

		// Token: 0x0200ADCE RID: 44494
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x04035F89 RID: 221065
			public const int ItemCaption = 0;

			// Token: 0x04035F8A RID: 221066
			public const int ItemTabComponent = 1;

			// Token: 0x04035F8B RID: 221067
			public const int ItemRootMonsterType = 2;

			// Token: 0x04035F8C RID: 221068
			public const int ScrollMonsterType = 3;

			// Token: 0x04035F8D RID: 221069
			public const int ItemMonsterType = 4;

			// Token: 0x04035F8E RID: 221070
			public const int ItemRootMonsterWave = 5;

			// Token: 0x04035F8F RID: 221071
			public const int ScrollMonsterWave = 6;

			// Token: 0x04035F90 RID: 221072
			public const int ItemMonsterWave = 7;

			// Token: 0x04035F91 RID: 221073
			public const int ItemEmptyInfo = 8;

			// Token: 0x04035F92 RID: 221074
			public const int ItemMonsterDesc = 9;
		}
	}
}
