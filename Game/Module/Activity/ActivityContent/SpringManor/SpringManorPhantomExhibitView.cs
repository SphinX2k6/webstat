using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.NewWorld.SceneItem;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SpringManor
{
	// Token: 0x02006314 RID: 25364
	[NullableContext(1)]
	[Nullable(0)]
	public class SpringManorPhantomExhibitView : UiViewBase
	{
		// Token: 0x0603FBED RID: 261101 RVA: 0x0105782A File Offset: 0x01055A2A
		public SpringManorPhantomExhibitView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603FBEE RID: 261102 RVA: 0x01057868 File Offset: 0x01055A68
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUILoopScrollViewComponent)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(8, new Action(this.OnClickBtnRemove))
			};
		}

		// Token: 0x0603FBEF RID: 261103 RVA: 0x01057940 File Offset: 0x01055B40
		protected override UniTask OnBeforeStartAsync()
		{
			SpringManorPhantomExhibitView.<OnBeforeStartAsync>d__13 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SpringManorPhantomExhibitView.<OnBeforeStartAsync>d__13>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603FBF0 RID: 261104 RVA: 0x01057983 File Offset: 0x01055B83
		protected override void OnBeforeShow()
		{
			this.RefreshPhantomList();
		}

		// Token: 0x0603FBF1 RID: 261105 RVA: 0x0105798B File Offset: 0x01055B8B
		protected override void OnBeforeDestroy()
		{
			Singleton<UiCameraAnimationManager>.Instance.EnablePlayerActor();
			FilterSortEntrance<int> filterSortComponent = this.FilterSortComponent;
			if (filterSortComponent == null)
			{
				return;
			}
			filterSortComponent.ClearData(EFilterSortGroupId.MonsterHandBook);
		}

		// Token: 0x0603FBF2 RID: 261106 RVA: 0x010579AC File Offset: 0x01055BAC
		private void InitPhantomScrollView()
		{
			UUILoopScrollViewComponent loopScrollViewComponent = base.GetLoopScrollViewComponent(2);
			UUIItem item = base.GetItem(3);
			AUIBaseActor auibaseActor = ((item != null) ? item.GetOwner() : null) as AUIBaseActor;
			if (loopScrollViewComponent == null || auibaseActor == null)
			{
				return;
			}
			this.PhantomScrollView = new LoopScrollView<SpringManorPhantomExhibitGrid, SpringManorPhantomDisplayItem>(loopScrollViewComponent, auibaseActor, new Func<SpringManorPhantomExhibitGrid>(this.CreatePhantomGrid), false);
		}

		// Token: 0x0603FBF3 RID: 261107 RVA: 0x010579FB File Offset: 0x01055BFB
		private SpringManorPhantomExhibitGrid CreatePhantomGrid()
		{
			return new SpringManorPhantomExhibitGrid
			{
				OnToggleClick = new Action<int, int>(this.OnPhantomGridSelected)
			};
		}

		// Token: 0x0603FBF4 RID: 261108 RVA: 0x01057A14 File Offset: 0x01055C14
		private void InitFilterSortEntrance()
		{
			UUIItem item = base.GetItem(4);
			if (item == null)
			{
				return;
			}
			this.FilterSortComponent = new FilterSortEntrance<int>(item, new TUpdateDataListFunction<int>(this.OnFilterSortRefresh));
		}

		// Token: 0x0603FBF5 RID: 261109 RVA: 0x01057A48 File Offset: 0x01055C48
		private void RefreshPhantomList()
		{
			IEnumerable<ExhibitPhantom> phantomExtraConfigByBodySize = ConfigBase<SpringManorConfig>.Instance.GetPhantomExtraConfigByBodySize(this.PhantomBodySize);
			List<int> list = new List<int>();
			foreach (ExhibitPhantom exhibitPhantom in phantomExtraConfigByBodySize)
			{
				if (ModelBase<CalabashModel>.Instance.CheckCalabashMonsterUnlocked(exhibitPhantom.Id))
				{
					HandBookConfig instance = ConfigBase<HandBookConfig>.Instance;
					MonsterHandBook? monsterHandBook = (instance != null) ? instance.GetMonsterHandBookConfigByMonsterId(exhibitPhantom.Id) : null;
					if (monsterHandBook != null)
					{
						list.Add(monsterHandBook.Value.Id);
					}
				}
			}
			if (this.FilterSortComponent != null)
			{
				this.FilterSortComponent.UpdateData(EFilterSortGroupId.SpringManorPhantomExhibit, list, Array.Empty<object>());
				return;
			}
			this.UpdatePhantomGridDataSource(list);
		}

		// Token: 0x0603FBF6 RID: 261110 RVA: 0x01057B18 File Offset: 0x01055D18
		private void UpdatePhantomGridDataSource(List<int> handbookIdList)
		{
			bool flag = handbookIdList.Count > 0;
			UUIItem item = base.GetItem(1);
			if (item != null)
			{
				item.SetUIActive(!flag);
			}
			SpringManorPhantomDisplayItem springManorPhantomDisplayItem = null;
			List<SpringManorPhantomDisplayItem> list = new List<SpringManorPhantomDisplayItem>();
			foreach (int id in handbookIdList)
			{
				HandBookConfig instance = ConfigBase<HandBookConfig>.Instance;
				MonsterHandBook? monsterHandBook = (instance != null) ? instance.GetMonsterHandBookConfigById(id) : null;
				if (monsterHandBook != null)
				{
					IReadOnlyList<Aki.Config.PhantomItem> phantomItemByMonsterId = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomItemByMonsterId(monsterHandBook.Value.MonsterId);
					if (phantomItemByMonsterId != null && phantomItemByMonsterId.Count != 0)
					{
						Aki.Config.PhantomItem phantomItem = phantomItemByMonsterId[0];
						int? placedPhantomId = this.PlacedPhantomId;
						int itemId = phantomItem.ItemId;
						bool flag2 = placedPhantomId.GetValueOrDefault() == itemId & placedPhantomId != null;
						SpringManorPhantomDisplayItem springManorPhantomDisplayItem2 = new SpringManorPhantomDisplayItem
						{
							PhantomId = phantomItem.ItemId,
							IsSelected = flag2
						};
						if (flag2)
						{
							springManorPhantomDisplayItem = springManorPhantomDisplayItem2;
						}
						else
						{
							list.Add(springManorPhantomDisplayItem2);
						}
					}
				}
			}
			if (springManorPhantomDisplayItem != null)
			{
				this.PhantomGridDataSource = new List<SpringManorPhantomDisplayItem>
				{
					springManorPhantomDisplayItem
				};
				this.PhantomGridDataSource.AddRange(list);
			}
			else
			{
				this.PhantomGridDataSource = list;
			}
			this.PhantomScrollView.RefreshByData(this.PhantomGridDataSource, false, null, true);
			if (flag && this.PhantomGridDataSource.Count > 0)
			{
				int num = 0;
				this.PhantomScrollView.ScrollToGridIndex(num, false);
				this.PhantomScrollView.SelectGridProxy(num, false);
				SpringManorPhantomDisplayItem springManorPhantomDisplayItem3 = this.PhantomGridDataSource[num];
				this.CurrentSelectedPhantomId = ((springManorPhantomDisplayItem3 != null) ? new int?(springManorPhantomDisplayItem3.PhantomId) : null);
				this.PreviewPhantomSelection(this.CurrentSelectedPhantomId.Value);
			}
			else
			{
				this.PhantomScrollView.DeselectCurrentGridProxy(false);
				this.CurrentSelectedPhantomId = null;
			}
			this.RefreshOperationButtonState();
		}

		// Token: 0x0603FBF7 RID: 261111 RVA: 0x01057D0C File Offset: 0x01055F0C
		private void OnFilterSortRefresh(List<int> list, bool isOutSideChange, EFilterSortType operationType)
		{
			this.UpdatePhantomGridDataSource(list);
		}

		// Token: 0x0603FBF8 RID: 261112 RVA: 0x01057D22 File Offset: 0x01055F22
		private void OnPhantomGridSelected(int phantomId, int gridIndex)
		{
			this.CurrentSelectedPhantomId = new int?(phantomId);
			this.PreviewPhantomSelection(phantomId);
			this.RefreshOperationButtonState();
			LoopScrollView<SpringManorPhantomExhibitGrid, SpringManorPhantomDisplayItem> phantomScrollView = this.PhantomScrollView;
			if (phantomScrollView == null)
			{
				return;
			}
			phantomScrollView.SelectGridProxy(gridIndex, false);
		}

		// Token: 0x0603FBF9 RID: 261113 RVA: 0x01057D50 File Offset: 0x01055F50
		private void RefreshOperationButtonState()
		{
			bool flag = this.CurrentSelectedPhantomId != null;
			bool flag2;
			if (flag && this.PlacedPhantomId != null)
			{
				int? placedPhantomId = this.PlacedPhantomId;
				int? currentSelectedPhantomId = this.CurrentSelectedPhantomId;
				flag2 = (placedPhantomId.GetValueOrDefault() == currentSelectedPhantomId.GetValueOrDefault() & placedPhantomId != null == (currentSelectedPhantomId != null));
			}
			else
			{
				flag2 = false;
			}
			bool flag3 = flag2;
			ButtonItem placeButtonItem = this.PlaceButtonItem;
			if (placeButtonItem != null)
			{
				placeButtonItem.SetUiActive(flag && !flag3);
			}
			UUIButtonComponent button = base.GetButton(8);
			if (button != null)
			{
				UUIItem uuiitem = button.RootUIComp.Get();
				if (uuiitem != null)
				{
					uuiitem.SetUIActive(flag && flag3);
				}
			}
			bool flag4 = !flag3 && this.PlacedPhantomId != 0;
			if (this.PlaceButtonItem != null)
			{
				if (flag4)
				{
					this.PlaceButtonItem.SetShowText("Text_PhantomExhibitionReplace_Text");
					return;
				}
				this.PlaceButtonItem.SetShowText("Text_PhantomExhibitionEquip_Text");
			}
		}

		// Token: 0x0603FBFA RID: 261114 RVA: 0x01057E44 File Offset: 0x01056044
		private void UpdatePhantomSelectionState(int phantomId, bool isSelected)
		{
			int i = 0;
			while (i < this.PhantomGridDataSource.Count)
			{
				SpringManorPhantomDisplayItem springManorPhantomDisplayItem = this.PhantomGridDataSource[i];
				if (springManorPhantomDisplayItem != null && springManorPhantomDisplayItem.PhantomId == phantomId)
				{
					springManorPhantomDisplayItem.IsSelected = isSelected;
					LoopScrollView<SpringManorPhantomExhibitGrid, SpringManorPhantomDisplayItem> phantomScrollView = this.PhantomScrollView;
					if (phantomScrollView == null)
					{
						return;
					}
					phantomScrollView.RefreshGridProxy(i);
					return;
				}
				else
				{
					i++;
				}
			}
		}

		// Token: 0x0603FBFB RID: 261115 RVA: 0x01057EA1 File Offset: 0x010560A1
		private void PreviewPhantomSelection(int phantomId)
		{
			if (this.EntityId == null)
			{
				return;
			}
			this.PreviewPhantomId = new int?(phantomId);
			this.RefreshSceneItemExhibit(this.EntityId.Value, phantomId);
		}

		// Token: 0x0603FBFC RID: 261116 RVA: 0x01057ED0 File Offset: 0x010560D0
		private UniTask InitCaptionAsync()
		{
			SpringManorPhantomExhibitView.<InitCaptionAsync>d__27 <InitCaptionAsync>d__;
			<InitCaptionAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitCaptionAsync>d__.<>4__this = this;
			<InitCaptionAsync>d__.<>1__state = -1;
			<InitCaptionAsync>d__.<>t__builder.Start<SpringManorPhantomExhibitView.<InitCaptionAsync>d__27>(ref <InitCaptionAsync>d__);
			return <InitCaptionAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603FBFD RID: 261117 RVA: 0x01057F14 File Offset: 0x01056114
		private bool RefreshSceneItemExhibit(int entityId, int itemId)
		{
			SceneItemExhibitComponent exhibitComponent = this.GetExhibitComponent(entityId);
			if (exhibitComponent == null)
			{
				return false;
			}
			if (itemId == 0)
			{
				SceneItemExhibitComponent exhibitComponent2 = this.GetExhibitComponent(entityId);
				if (exhibitComponent2 != null)
				{
					exhibitComponent2.HideSkeletalMeshComponent();
				}
			}
			else
			{
				exhibitComponent.RefreshSkeletalMeshComponent(itemId, false);
			}
			return true;
		}

		// Token: 0x0603FBFE RID: 261118 RVA: 0x01057F50 File Offset: 0x01056150
		private List<EntityItemBundleInfo> BuildPhantomBundleInfos(int? phantomId = null)
		{
			int? num = phantomId;
			int? num2 = (num != null) ? num : this.PlacedPhantomId;
			if (this.EntityId == null || num2 == null)
			{
				return new List<EntityItemBundleInfo>();
			}
			EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById(this.EntityId.Value);
			if (entityById == null)
			{
				return new List<EntityItemBundleInfo>();
			}
			int value = num2.Value;
			EntityItemBundleInfo entityItemBundleInfo = EntityItemBundleInfo.Create();
			entityItemBundleInfo.EntityId = Singleton<MathUtils>.Instance.NumberToLong(entityById.CreatureDataId);
			entityItemBundleInfo.ItemId = value;
			return new List<EntityItemBundleInfo>
			{
				entityItemBundleInfo
			};
		}

		// Token: 0x0603FBFF RID: 261119 RVA: 0x01057FE8 File Offset: 0x010561E8
		private EPhantomExhibitSizeType? GetSize()
		{
			SceneItemExhibitComponent exhibitComponent = this.GetExhibitComponent(this.EntityId.Value);
			IPhantomExhibitConfig phantomExhibitConfig = ((exhibitComponent != null) ? exhibitComponent.GetExhibitConfig() : null) as IPhantomExhibitConfig;
			if (phantomExhibitConfig == null)
			{
				return null;
			}
			return new EPhantomExhibitSizeType?(phantomExhibitConfig.PhantomSize);
		}

		// Token: 0x0603FC00 RID: 261120 RVA: 0x01058030 File Offset: 0x01056230
		[NullableContext(2)]
		private SceneItemExhibitComponent GetExhibitComponent(int entityId)
		{
			EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById(entityId);
			if (entityById == null)
			{
				return null;
			}
			SceneItemExhibitComponent component = entityById.Entity.GetComponent<SceneItemExhibitComponent>();
			if (component == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SceneItem;
				ELogAuthor author = ELogAuthor.BB;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(46, 1);
				defaultInterpolatedStringHandler.AppendLiteral("刷新场景物品展示模型失败，PbDataId: ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(entityId);
				defaultInterpolatedStringHandler.AppendLiteral("，Entity没有ActorComponent");
				instance.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				return null;
			}
			return component;
		}

		// Token: 0x0603FC01 RID: 261121 RVA: 0x010580A8 File Offset: 0x010562A8
		private void SaveIfChange()
		{
			int valueOrDefault = this.PlacedPhantomId.GetValueOrDefault();
			if (valueOrDefault != this.OriginItemId)
			{
				List<EntityItemBundleInfo> bundleInfos = this.BuildPhantomBundleInfos(new int?(valueOrDefault));
				ControllerBase<SpringManorController>.Instance.RequestExhibitionSave(bundleInfos);
			}
		}

		// Token: 0x0603FC02 RID: 261122 RVA: 0x010580E4 File Offset: 0x010562E4
		private void OnClickCloseBtn()
		{
			int valueOrDefault = this.PreviewPhantomId.GetValueOrDefault();
			int valueOrDefault2 = this.PlacedPhantomId.GetValueOrDefault();
			if (valueOrDefault == valueOrDefault2)
			{
				this.SaveIfChange();
				base.CloseMe(null);
				return;
			}
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.SpringManorPhantomExhibitConfirm);
			confirmBoxDataNew.FunctionMap.Add(1, delegate
			{
				this.PreviewPhantomId = this.PlacedPhantomId;
				if (this.EntityId != null)
				{
					this.RefreshSceneItemExhibit(this.EntityId.Value, this.PlacedPhantomId.GetValueOrDefault());
				}
				this.SaveIfChange();
				base.CloseMe(null);
			});
			confirmBoxDataNew.FunctionMap.Add(2, delegate
			{
				this.PlacedPhantomId = this.PreviewPhantomId;
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("PhantomDisplayUpdated_Tips", Array.Empty<object>());
				this.SaveIfChange();
				base.CloseMe(null);
			});
			confirmBoxDataNew.IsEscViewTriggerCallBack = false;
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x0603FC03 RID: 261123 RVA: 0x01058168 File Offset: 0x01056368
		private void OnClickBtnPlace(int _)
		{
			if (this.CurrentSelectedPhantomId == null)
			{
				return;
			}
			int? placedPhantomId = this.PlacedPhantomId;
			int? currentSelectedPhantomId = this.CurrentSelectedPhantomId;
			if (placedPhantomId.GetValueOrDefault() == currentSelectedPhantomId.GetValueOrDefault() & placedPhantomId != null == (currentSelectedPhantomId != null))
			{
				return;
			}
			if (this.PlacedPhantomId != null)
			{
				this.UpdatePhantomSelectionState(this.PlacedPhantomId.Value, false);
			}
			this.PlacedPhantomId = this.CurrentSelectedPhantomId;
			this.UpdatePhantomSelectionState(this.CurrentSelectedPhantomId.Value, true);
			this.PreviewPhantomSelection(this.PlacedPhantomId.Value);
			this.RefreshOperationButtonState();
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("PhantomDisplayUpdated_Tips", Array.Empty<object>());
		}

		// Token: 0x0603FC04 RID: 261124 RVA: 0x01058220 File Offset: 0x01056420
		private void OnClickBtnRemove()
		{
			if (this.CurrentSelectedPhantomId == null)
			{
				return;
			}
			int? placedPhantomId = this.PlacedPhantomId;
			int? currentSelectedPhantomId = this.CurrentSelectedPhantomId;
			if (!(placedPhantomId.GetValueOrDefault() == currentSelectedPhantomId.GetValueOrDefault() & placedPhantomId != null == (currentSelectedPhantomId != null)))
			{
				return;
			}
			this.PlacedPhantomId = null;
			this.PreviewPhantomId = null;
			this.UpdatePhantomSelectionState(this.CurrentSelectedPhantomId.Value, false);
			SceneItemExhibitComponent exhibitComponent = this.GetExhibitComponent(this.EntityId.Value);
			if (exhibitComponent != null)
			{
				exhibitComponent.HideSkeletalMeshComponent();
			}
			this.RefreshOperationButtonState();
		}

		// Token: 0x04023C83 RID: 146563
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private LoopScrollView<SpringManorPhantomExhibitGrid, SpringManorPhantomDisplayItem> PhantomScrollView;

		// Token: 0x04023C84 RID: 146564
		private List<SpringManorPhantomDisplayItem> PhantomGridDataSource = new List<SpringManorPhantomDisplayItem>();

		// Token: 0x04023C85 RID: 146565
		[Nullable(2)]
		private FilterSortEntrance<int> FilterSortComponent;

		// Token: 0x04023C86 RID: 146566
		private int? CurrentSelectedPhantomId;

		// Token: 0x04023C87 RID: 146567
		private int? PreviewPhantomId;

		// Token: 0x04023C88 RID: 146568
		private int? PlacedPhantomId;

		// Token: 0x04023C89 RID: 146569
		private int PhantomBodySize = 1;

		// Token: 0x04023C8A RID: 146570
		private int? EntityId;

		// Token: 0x04023C8B RID: 146571
		private int OriginItemId;

		// Token: 0x04023C8C RID: 146572
		[Nullable(2)]
		private ButtonItem PlaceButtonItem;

		// Token: 0x04023C8D RID: 146573
		private readonly Dictionary<EPhantomExhibitSizeType, int> phantomExhibitBodySizeRecord = new Dictionary<EPhantomExhibitSizeType, int>
		{
			{
				EPhantomExhibitSizeType.Small,
				1
			},
			{
				EPhantomExhibitSizeType.Big,
				2
			},
			{
				EPhantomExhibitSizeType.Huge,
				3
			}
		};

		// Token: 0x0200C398 RID: 50072
		[NullableContext(0)]
		[RequiredMember]
		public class Params
		{
			// Token: 0x0604E87E RID: 321662 RVA: 0x015CADD2 File Offset: 0x015C8FD2
			[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
			[CompilerFeatureRequired("RequiredMembers")]
			public Params()
			{
			}

			// Token: 0x0403C429 RID: 246825
			[RequiredMember]
			public int TargetPhantomExhibitEntity;
		}
	}
}
