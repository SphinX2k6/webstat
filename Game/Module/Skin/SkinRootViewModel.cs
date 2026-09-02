using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.UiCamera;
using CSharpScript.Game.Module.Skin.Skip;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Skin
{
	// Token: 0x02004F61 RID: 20321
	[NullableContext(1)]
	[Nullable(0)]
	public class SkinRootViewModel : ViewModelBase<ESkinRootViewData>
	{
		// Token: 0x0603466C RID: 214636 RVA: 0x00D1C6BC File Offset: 0x00D1A8BC
		public SkinRootViewModel()
		{
			this.DataMap.Add(ESkinRootViewData.CurSelectTabViewName, null);
			this.DataMap.Add(ESkinRootViewData.RootUiVisible, true);
			this.DataMap.Add(ESkinRootViewData.MoveGamepadKeyTipActive, true);
			this.DataMap.Add(ESkinRootViewData.GamePadKeyTipRefresh, true);
			this.DataMap.Add(ESkinRootViewData.ModelState, null);
			this.DataMap.Add(ESkinRootViewData.SelectTabViewName, null);
		}

		// Token: 0x17008A37 RID: 35383
		// (get) Token: 0x0603466D RID: 214637 RVA: 0x00D1C772 File Offset: 0x00D1A972
		public ISkinViewData ViewData
		{
			get
			{
				return this.ViewDataInternal;
			}
		}

		// Token: 0x17008A38 RID: 35384
		// (get) Token: 0x0603466E RID: 214638 RVA: 0x00D1C77A File Offset: 0x00D1A97A
		public int RoleId
		{
			get
			{
				return this.RoleIdInternal;
			}
		}

		// Token: 0x17008A39 RID: 35385
		// (get) Token: 0x0603466F RID: 214639 RVA: 0x00D1C782 File Offset: 0x00D1A982
		public int WeaponIncId
		{
			get
			{
				return this.WeaponIncIdInternal;
			}
		}

		// Token: 0x17008A3A RID: 35386
		// (get) Token: 0x06034670 RID: 214640 RVA: 0x00D1C78A File Offset: 0x00D1A98A
		public bool NeedLoadRole
		{
			get
			{
				return this.NeedLoadRoleInternal;
			}
		}

		// Token: 0x06034671 RID: 214641 RVA: 0x00D1C792 File Offset: 0x00D1A992
		public void SetCurSelectTabViewName(EUiTabViewName curSelectTabViewName, bool notNotify = false)
		{
			base.SetData(ESkinRootViewData.CurSelectTabViewName, curSelectTabViewName, notNotify);
		}

		// Token: 0x06034672 RID: 214642 RVA: 0x00D1C7A2 File Offset: 0x00D1A9A2
		public EUiTabViewName GetCurSelectTabViewName()
		{
			return (EUiTabViewName)base.GetData(ESkinRootViewData.CurSelectTabViewName);
		}

		// Token: 0x06034673 RID: 214643 RVA: 0x00D1C7B0 File Offset: 0x00D1A9B0
		public void SetRootUiVisible(bool visible, bool notNotify = false)
		{
			base.SetData(ESkinRootViewData.RootUiVisible, visible, notNotify);
		}

		// Token: 0x06034674 RID: 214644 RVA: 0x00D1C7C0 File Offset: 0x00D1A9C0
		public bool GetRootUiVisible()
		{
			return (bool)base.GetData(ESkinRootViewData.RootUiVisible);
		}

		// Token: 0x06034675 RID: 214645 RVA: 0x00D1C7CE File Offset: 0x00D1A9CE
		public void SetMoveGamepadKeyTipActive(bool isMoveGamepadKeyTipActive, bool notNotify = false)
		{
			base.SetData(ESkinRootViewData.MoveGamepadKeyTipActive, isMoveGamepadKeyTipActive, notNotify);
		}

		// Token: 0x06034676 RID: 214646 RVA: 0x00D1C7DE File Offset: 0x00D1A9DE
		public bool GetMoveGamepadKeyTipActive()
		{
			return (bool)base.GetData(ESkinRootViewData.MoveGamepadKeyTipActive);
		}

		// Token: 0x06034677 RID: 214647 RVA: 0x00D1C7EC File Offset: 0x00D1A9EC
		public void SetSelectTabViewName(EUiTabViewName curSelectTabViewName, bool notNotify = false)
		{
			base.SetData(ESkinRootViewData.SelectTabViewName, curSelectTabViewName, notNotify);
		}

		// Token: 0x06034678 RID: 214648 RVA: 0x00D1C7FC File Offset: 0x00D1A9FC
		public EUiTabViewName? GetSelectTabViewName()
		{
			return (EUiTabViewName?)base.GetData(ESkinRootViewData.SelectTabViewName);
		}

		// Token: 0x06034679 RID: 214649 RVA: 0x00D1C80C File Offset: 0x00D1AA0C
		public void SetModelState(EModelStateInSkinView modelState, bool notNotify = false)
		{
			EModelStateInSkinView? modelState2 = this.GetModelState();
			if (modelState2.GetValueOrDefault() == modelState & modelState2 != null)
			{
				return;
			}
			base.SetData(ESkinRootViewData.ModelState, modelState, notNotify);
		}

		// Token: 0x0603467A RID: 214650 RVA: 0x00D1C845 File Offset: 0x00D1AA45
		public EModelStateInSkinView? GetModelState()
		{
			return (EModelStateInSkinView?)base.GetData(ESkinRootViewData.ModelState);
		}

		// Token: 0x0603467B RID: 214651 RVA: 0x00D1C853 File Offset: 0x00D1AA53
		public void NotifyGamePadKeyTipRefresh()
		{
			base.SetData(ESkinRootViewData.GamePadKeyTipRefresh, true, false);
		}

		// Token: 0x0603467C RID: 214652 RVA: 0x00D1C864 File Offset: 0x00D1AA64
		public void Init(ISkinViewData viewData)
		{
			this.ViewDataInternal = viewData;
			this.RoleIdInternal = viewData.RoleId;
			this.WeaponIncIdInternal = viewData.WeaponId;
			this.NeedLoadRoleInternal = viewData.NeedLoadRole;
			this.SetCurSelectTabViewName(viewData.TabViewName, true);
			if (viewData.OrnamentSkinId != null || viewData.OrnamentId != null)
			{
				this.SetTabViewParam(new SkinTabViewParam
				{
					SkinId = viewData.OrnamentSkinId,
					OrnamentId = viewData.OrnamentId
				});
			}
		}

		// Token: 0x0603467D RID: 214653 RVA: 0x00D1C8EC File Offset: 0x00D1AAEC
		public void SetGetDragItemFunc(Func<UUIDraggableComponent> getDragItemFunc)
		{
			this.GetDragItemFunc = getDragItemFunc;
		}

		// Token: 0x0603467E RID: 214654 RVA: 0x00D1C8F5 File Offset: 0x00D1AAF5
		public UUIDraggableComponent GetDragItem()
		{
			Func<UUIDraggableComponent> getDragItemFunc = this.GetDragItemFunc;
			if (getDragItemFunc == null)
			{
				return null;
			}
			return getDragItemFunc();
		}

		// Token: 0x17008A3B RID: 35387
		// (get) Token: 0x0603467F RID: 214655 RVA: 0x00D1C908 File Offset: 0x00D1AB08
		public bool IsMainRole
		{
			get
			{
				return ModelBase<RoleModel>.Instance.IsMainRole(this.RoleIdInternal);
			}
		}

		// Token: 0x06034680 RID: 214656 RVA: 0x00D1C91A File Offset: 0x00D1AB1A
		public bool IsShowHelpBtn(EUiTabViewName viewName)
		{
			return this.HelpIdMapInternal.ContainsKey(viewName);
		}

		// Token: 0x06034681 RID: 214657 RVA: 0x00D1C928 File Offset: 0x00D1AB28
		public int? GetHelpId(EUiTabViewName viewName)
		{
			int value;
			if (this.HelpIdMapInternal.TryGetValue(viewName, out value))
			{
				return new int?(value);
			}
			return null;
		}

		// Token: 0x06034682 RID: 214658 RVA: 0x00D1C958 File Offset: 0x00D1AB58
		public List<ISkinSkipData> GetSkinSkipDataList(int skinId, IReadOnlyList<int> itemAccess)
		{
			List<ISkinSkipData> list = new List<ISkinSkipData>();
			foreach (int num in itemAccess)
			{
				AccessPath? configById = ConfigBase<GetWayConfig>.Instance.GetConfigById(num);
				if (configById != null)
				{
					SkinSkipData item = new SkinSkipData
					{
						Id = num,
						ConfigId = skinId,
						Type = (ESkinSkipType)configById.Value.Type,
						Text = configById.Value.Description,
						SortIndex = configById.Value.SortIndex
					};
					list.Add(item);
				}
			}
			list.Sort(delegate(ISkinSkipData aSkipData, ISkinSkipData bSkipData)
			{
				int sortIndex = aSkipData.SortIndex;
				int sortIndex2 = bSkipData.SortIndex;
				if (sortIndex == sortIndex2)
				{
					return bSkipData.Id - aSkipData.Id;
				}
				return sortIndex2 - sortIndex;
			});
			return list;
		}

		// Token: 0x06034683 RID: 214659 RVA: 0x00D1CA3C File Offset: 0x00D1AC3C
		public void SetCaptionItemActive(bool state)
		{
			if (state)
			{
				this.SetRootUiVisible(true, false);
				return;
			}
			this.SetRootUiVisible(false, false);
		}

		// Token: 0x06034684 RID: 214660 RVA: 0x00D1CA54 File Offset: 0x00D1AC54
		public ERedDotName? GetTabRedDotName(EUiTabViewName tabViewName)
		{
			if (tabViewName == EUiTabViewName.FlySkinTabView)
			{
				return new ERedDotName?(ERedDotName.FlySkinTab);
			}
			if (tabViewName == EUiTabViewName.CalabashSkinTabView)
			{
				return new ERedDotName?(ERedDotName.HuluSkinTab);
			}
			if (tabViewName == EUiTabViewName.RoleOrnamentTabView)
			{
				return new ERedDotName?(ERedDotName.RoleOrnamentTab);
			}
			return null;
		}

		// Token: 0x06034685 RID: 214661 RVA: 0x00D1CAAC File Offset: 0x00D1ACAC
		public int? GetTabRedDotUid(EUiTabViewName tabViewName)
		{
			if (tabViewName == EUiTabViewName.RoleOrnamentTabView)
			{
				return new int?(this.RoleIdInternal);
			}
			return null;
		}

		// Token: 0x06034686 RID: 214662 RVA: 0x00D1CADB File Offset: 0x00D1ACDB
		public void SetTabViewParam(SkinTabViewParam value)
		{
			this.TabViewParam = value;
		}

		// Token: 0x06034687 RID: 214663 RVA: 0x00D1CAE4 File Offset: 0x00D1ACE4
		[NullableContext(2)]
		public SkinTabViewParam GetTabViewParam()
		{
			SkinTabViewParam tabViewParam = this.TabViewParam;
			this.TabViewParam = null;
			return tabViewParam;
		}

		// Token: 0x06034688 RID: 214664 RVA: 0x00D1CAF4 File Offset: 0x00D1ACF4
		public void TryShowRoleSystemRoleActor()
		{
			if (this.TsUiSceneRoleActor == null)
			{
				return;
			}
			UiModelBase model = this.TsUiSceneRoleActor.Model;
			if (model == null)
			{
				return;
			}
			Singleton<UiModelUtil>.Instance.SetVisible(model, true);
		}

		// Token: 0x06034689 RID: 214665 RVA: 0x00D1CB28 File Offset: 0x00D1AD28
		public void StartCameraInput(IUiCameraInputComponentData data, bool? canCameraInput = null, bool forceActivate = false)
		{
			if (this.HasCameraInputComponentStartInternal)
			{
				this.CameraInputComponent.TryDeActivate();
				this.CameraInputComponent.UpdateData(data);
				if (canCameraInput != null)
				{
					this.CameraInputComponent.CanCameraInput = canCameraInput.Value;
				}
				this.CameraInputComponent.TryActivate();
				return;
			}
			this.HasCameraInputComponentStartInternal = true;
			this.CameraInputComponent.InitData(data);
			if (canCameraInput != null)
			{
				this.CameraInputComponent.CanCameraInput = canCameraInput.Value;
			}
			this.CameraInputComponent.Start();
			if (forceActivate)
			{
				this.CameraInputComponent.Activate();
				return;
			}
			this.CameraInputComponent.TryActivate();
		}

		// Token: 0x0603468A RID: 214666 RVA: 0x00D1CBD1 File Offset: 0x00D1ADD1
		public void EndCameraInput()
		{
			if (!this.HasCameraInputComponentStartInternal)
			{
				return;
			}
			this.HasCameraInputComponentStartInternal = false;
			this.CameraInputComponent.End();
		}

		// Token: 0x0603468B RID: 214667 RVA: 0x00D1CBEE File Offset: 0x00D1ADEE
		public void SetCameraInputCanInput(bool canCameraInput)
		{
			this.CameraInputComponent.CanCameraInput = canCameraInput;
		}

		// Token: 0x0401E32F RID: 123695
		private ISkinViewData ViewDataInternal;

		// Token: 0x0401E330 RID: 123696
		private int WeaponIncIdInternal;

		// Token: 0x0401E331 RID: 123697
		private int RoleIdInternal;

		// Token: 0x0401E332 RID: 123698
		private Func<UUIDraggableComponent> GetDragItemFunc;

		// Token: 0x0401E333 RID: 123699
		private bool NeedLoadRoleInternal;

		// Token: 0x0401E334 RID: 123700
		private readonly Dictionary<EUiTabViewName, int> HelpIdMapInternal = new Dictionary<EUiTabViewName, int>
		{
			{
				EUiTabViewName.RoleSkinTabView,
				146
			},
			{
				EUiTabViewName.CalabashSkinTabView,
				387
			},
			{
				EUiTabViewName.RoleOrnamentTabView,
				571
			}
		};

		// Token: 0x0401E335 RID: 123701
		public TsUiSceneRoleActor TsUiSceneRoleActor;

		// Token: 0x0401E336 RID: 123702
		public UiCameraInputComponent CameraInputComponent = new UiCameraInputComponent();

		// Token: 0x0401E337 RID: 123703
		[Nullable(2)]
		private SkinTabViewParam TabViewParam;

		// Token: 0x0401E338 RID: 123704
		private bool HasCameraInputComponentStartInternal;
	}
}
