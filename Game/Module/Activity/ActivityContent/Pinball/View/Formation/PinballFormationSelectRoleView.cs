using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Formation
{
	// Token: 0x0200662E RID: 26158
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballFormationSelectRoleView : UiViewBase
	{
		// Token: 0x06041575 RID: 267637 RVA: 0x010C1F81 File Offset: 0x010C0181
		public PinballFormationSelectRoleView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06041576 RID: 267638 RVA: 0x010C1F8C File Offset: 0x010C018C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 14;
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
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIMultiTemplateLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 3;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(9, new Action(this.OnClickLeftBtn));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(10, new Action(this.OnClickRightBtn));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(11, new Action(this.OnClickCloseBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06041577 RID: 267639 RVA: 0x010C2210 File Offset: 0x010C0410
		protected override UniTask OnBeforeStartAsync()
		{
			PinballFormationSelectRoleView.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PinballFormationSelectRoleView.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041578 RID: 267640 RVA: 0x010C2253 File Offset: 0x010C0453
		private RoleTagItem CreateTagItem()
		{
			return new RoleTagItem();
		}

		// Token: 0x06041579 RID: 267641 RVA: 0x010C225A File Offset: 0x010C045A
		private RoleSkillItem CreateSkillItem()
		{
			return new RoleSkillItem();
		}

		// Token: 0x0604157A RID: 267642 RVA: 0x010C2264 File Offset: 0x010C0464
		private void InitFilterSortEntrance()
		{
			UUIItem item = base.GetItem(3);
			if (item == null)
			{
				return;
			}
			this.FilterSortComponent = new FilterSortEntrance<int>(item, delegate(List<int> list, bool isOutSideChange, EFilterSortType operationType)
			{
				this.OnFilterSortRefresh(list, isOutSideChange, operationType);
			});
		}

		// Token: 0x0604157B RID: 267643 RVA: 0x010C2295 File Offset: 0x010C0495
		protected override void OnBeforeDestroy()
		{
			ModelBase<PinballModel>.Instance.SelectRoleHandleList = new List<int>();
		}

		// Token: 0x0604157C RID: 267644 RVA: 0x010C22A8 File Offset: 0x010C04A8
		protected override void OnStart()
		{
			IPinballFormationSelectRoleViewData pinballFormationSelectRoleViewData = this.OpenParam as IPinballFormationSelectRoleViewData;
			this.OnConfirm = pinballFormationSelectRoleViewData.OnConfirm;
			this.RefreshRoleInfo(pinballFormationSelectRoleViewData.OpenRole.GetValueOrDefault());
			FilterSortEntrance<int> filterSortComponent = this.FilterSortComponent;
			if (filterSortComponent == null)
			{
				return;
			}
			filterSortComponent.UpdateData(EFilterSortGroupId.PinballFormation, pinballFormationSelectRoleViewData.RoleList, Array.Empty<object>());
		}

		// Token: 0x0604157D RID: 267645 RVA: 0x010C2300 File Offset: 0x010C0500
		protected override void OnBeforeShow()
		{
			base.GetButton(9).RootUIComp.Get().SetUIActive(ModelBase<PinballModel>.Instance.IsRoleFunctionOpen());
			this.RefreshRoleScrollView();
		}

		// Token: 0x0604157E RID: 267646 RVA: 0x010C2338 File Offset: 0x010C0538
		private void OnFilterSortRefresh(List<int> list, bool isOutSideChange, EFilterSortType operationType)
		{
			this.RefreshRoleList(new List<int>(list));
		}

		// Token: 0x0604157F RID: 267647 RVA: 0x010C2353 File Offset: 0x010C0553
		private PinballFormationSelectRoleItem OnGridProxyCreate()
		{
			PinballFormationSelectRoleItem pinballFormationSelectRoleItem = new PinballFormationSelectRoleItem();
			pinballFormationSelectRoleItem.BindOnStateChangeCallback(new Action<IPinballItemToggleCallback>(this.OnClickRoleItem));
			pinballFormationSelectRoleItem.BindOnCanExecuteChangeCallback(new Func<IPinballItemToggleCallback, bool>(this.CanExecuteChange));
			return pinballFormationSelectRoleItem;
		}

		// Token: 0x06041580 RID: 267648 RVA: 0x010C237E File Offset: 0x010C057E
		private void RefreshRoleList(List<int> roleIdList)
		{
			this.RoleList = roleIdList;
			this.RecommendRoleList = (this.OpenParam as IPinballFormationSelectRoleViewData).RecommendRoleList;
			this.RefreshRoleScrollView();
		}

		// Token: 0x06041581 RID: 267649 RVA: 0x010C23A4 File Offset: 0x010C05A4
		private void RefreshRoleScrollView()
		{
			List<IPinballItemDataRole> list = new List<IPinballItemDataRole>();
			foreach (int num in this.RoleList)
			{
				PinballRoleConfig? pinballRoleConfigById = ConfigBase<PinballConfig>.Instance.GetPinballRoleConfigById(num);
				PinballItemDataRole item = new PinballItemDataRole
				{
					Type = EPinballItemType.Role,
					Id = num,
					IsRecommend = new bool?(this.RecommendRoleList.Contains(num)),
					BdId = new int?(pinballRoleConfigById.Value.Bd),
					BottomPlainText = "Lv." + ModelBase<PinballModel>.Instance.GetRoleLevel(num).ToString(),
					ClassId = new int?(pinballRoleConfigById.Value.PinballClass(0))
				};
				list.Add(item);
			}
			LoopScrollView<PinballFormationSelectRoleItem, IPinballItemDataRole> roleScrollView = this.RoleScrollView;
			if (roleScrollView == null)
			{
				return;
			}
			roleScrollView.RefreshByDataAsync(list, false, true).Forget();
		}

		// Token: 0x06041582 RID: 267650 RVA: 0x010C24B0 File Offset: 0x010C06B0
		private void RefreshRoleInfo(int roleId)
		{
			this.CurrentShowRoleId = roleId;
			if (roleId == 0)
			{
				base.GetText(12).SetUIActive(false);
				base.GetSprite(4).SetUIActive(false);
				base.GetItem(13).SetUIActive(true);
				return;
			}
			base.GetItem(13).SetUIActive(false);
			PinballConfig instance = ConfigBase<PinballConfig>.Instance;
			PinballRoleConfig? pinballRoleConfig = (instance != null) ? instance.GetPinballRoleConfigById(roleId) : null;
			if (pinballRoleConfig == null)
			{
				return;
			}
			RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(pinballRoleConfig.Value.RoleId);
			if (roleConfig == null)
			{
				return;
			}
			base.GetText(12).SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(12), roleConfig.Value.Name, Array.Empty<object>());
			int selectRoleFormationNumber = ModelBase<PinballModel>.Instance.GetSelectRoleFormationNumber(roleId);
			if (selectRoleFormationNumber == 0)
			{
				base.GetSprite(4).SetUIActive(false);
			}
			else
			{
				string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_ComItemNum0" + selectRoleFormationNumber.ToString());
				this.SetSpriteByPath(resourcePath, base.GetSprite(4), true, null, delegate(bool _)
				{
					base.GetSprite(4).SetUIActive(true);
				});
			}
			List<IRoleTagItemData> list = new List<IRoleTagItemData>();
			list.Add(new RoleTagItemData
			{
				Type = ETagType.BD,
				ConfigId = pinballRoleConfig.Value.Bd
			});
			int pinballClassLength = pinballRoleConfig.Value.PinballClassLength;
			for (int i = 0; i < pinballClassLength; i++)
			{
				int configId = pinballRoleConfig.Value.PinballClass(i);
				list.Add(new RoleTagItemData
				{
					Type = ETagType.Class,
					ConfigId = configId
				});
			}
			GenericLayout<RoleTagItem, IRoleTagItemData> roleTagLayout = this.RoleTagLayout;
			if (roleTagLayout != null)
			{
				roleTagLayout.RefreshByData(list, null, false);
			}
			List<IRoleSkillItemData> list2 = new List<IRoleSkillItemData>();
			bool flag = true;
			int skillDisplayListLength = pinballRoleConfig.Value.SkillDisplayListLength;
			for (int j = 0; j < skillDisplayListLength; j++)
			{
				int configId2 = pinballRoleConfig.Value.SkillDisplayList(j);
				list2.Add(new RoleSkillItemData
				{
					IsLeader = (selectRoleFormationNumber == 1 && flag),
					ConfigId = configId2
				});
				flag = false;
			}
			base.GetScrollViewWithScrollbar(7).RootUIComp.Get().SetUIActive(true);
			GenericScrollViewNew<RoleSkillItem, IRoleSkillItemData> roleSkillScrollView = this.RoleSkillScrollView;
			if (roleSkillScrollView == null)
			{
				return;
			}
			roleSkillScrollView.RefreshByData(list2, null, false);
		}

		// Token: 0x06041583 RID: 267651 RVA: 0x010C2708 File Offset: 0x010C0908
		private void OnClickLeftBtn()
		{
			PinballRoleViewOpenParam param = new PinballRoleViewOpenParam
			{
				RoleId = ((this.CurrentShowRoleId > 0) ? new int?(this.CurrentShowRoleId) : null),
				FormationRoleIds = ModelBase<PinballModel>.Instance.SelectRoleHandleList.ToArray()
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PinballRoleView, param, null);
		}

		// Token: 0x06041584 RID: 267652 RVA: 0x010C2766 File Offset: 0x010C0966
		private void OnClickRightBtn()
		{
			Action<List<int>> onConfirm = this.OnConfirm;
			if (onConfirm != null)
			{
				onConfirm(ModelBase<PinballModel>.Instance.SelectRoleHandleList);
			}
			base.CloseMe(null);
		}

		// Token: 0x06041585 RID: 267653 RVA: 0x010C278A File Offset: 0x010C098A
		private void OnClickCloseBtn()
		{
			base.CloseMe(null);
		}

		// Token: 0x06041586 RID: 267654 RVA: 0x010C2794 File Offset: 0x010C0994
		private void OnClickRoleItem(IPinballItemToggleCallback @params)
		{
			int id = (@params.Data as IPinballItemDataRole).Id;
			if (@params.State == EToggleState.ETT_UnChecked)
			{
				ModelBase<PinballModel>.Instance.UnSelectRoleInHandleList(id);
				int gridIndex = this.RoleList.IndexOf(id);
				this.RoleScrollView.RefreshGridProxy(gridIndex);
			}
			else if (@params.State == EToggleState.ETT_Checked)
			{
				ModelBase<PinballModel>.Instance.SelectRoleInHandleList(id);
			}
			this.RefreshRoleInfo(id);
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence != null)
			{
				uiViewSequence.PlaySequence("Switch", false, null);
			}
			foreach (int item in ModelBase<PinballModel>.Instance.SelectRoleHandleList)
			{
				int gridIndex2 = this.RoleList.IndexOf(item);
				this.RoleScrollView.RefreshGridProxy(gridIndex2);
			}
			this.RefreshConfirmBtn();
		}

		// Token: 0x06041587 RID: 267655 RVA: 0x010C2884 File Offset: 0x010C0A84
		protected bool CanExecuteChange(IPinballItemToggleCallback @params)
		{
			if (@params.State != EToggleState.ETT_UnChecked)
			{
				return true;
			}
			if (ModelBase<PinballModel>.Instance.SelectRoleHandleList.Count >= 3)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("EditBattleTeamRoleFull", Array.Empty<object>());
				return false;
			}
			return true;
		}

		// Token: 0x06041588 RID: 267656 RVA: 0x010C28C0 File Offset: 0x010C0AC0
		private void RefreshConfirmBtn()
		{
			List<int> selectRoleHandleList = ModelBase<PinballModel>.Instance.SelectRoleHandleList;
			base.GetButton(10).SetSelfInteractive(selectRoleHandleList.Count > 0 && selectRoleHandleList.Count <= 3);
		}

		// Token: 0x06041589 RID: 267657 RVA: 0x010C2900 File Offset: 0x010C0B00
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams.Length < 2 || configParams[0] != "Role")
			{
				return null;
			}
			int num = int.Parse(configParams[1]);
			if (num < 0 || num >= this.RoleList.Count)
			{
				return null;
			}
			LoopScrollView<PinballFormationSelectRoleItem, IPinballItemDataRole> roleScrollView = this.RoleScrollView;
			if (roleScrollView != null)
			{
				roleScrollView.ScrollToGridIndex(num, false);
			}
			LoopScrollView<PinballFormationSelectRoleItem, IPinballItemDataRole> roleScrollView2 = this.RoleScrollView;
			PinballFormationSelectRoleItem pinballFormationSelectRoleItem = (roleScrollView2 != null) ? roleScrollView2.UnsafeGetGridProxy(num, false) : null;
			UUIItem uuiitem = (pinballFormationSelectRoleItem != null) ? pinballFormationSelectRoleItem.GetRoleItemToggleRootUiItem() : null;
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

		// Token: 0x040248CB RID: 149707
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x040248CC RID: 149708
		private List<int> RoleList;

		// Token: 0x040248CD RID: 149709
		private List<int> RecommendRoleList;

		// Token: 0x040248CE RID: 149710
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		protected LoopScrollView<PinballFormationSelectRoleItem, IPinballItemDataRole> RoleScrollView;

		// Token: 0x040248CF RID: 149711
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<List<int>> OnConfirm;

		// Token: 0x040248D0 RID: 149712
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<RoleTagItem, IRoleTagItemData> RoleTagLayout;

		// Token: 0x040248D1 RID: 149713
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<RoleSkillItem, IRoleSkillItemData> RoleSkillScrollView;

		// Token: 0x040248D2 RID: 149714
		[Nullable(2)]
		private FilterSortEntrance<int> FilterSortComponent;

		// Token: 0x040248D3 RID: 149715
		private int CurrentShowRoleId;

		// Token: 0x0200C652 RID: 50770
		[NullableContext(0)]
		private enum EComponent
		{
			// Token: 0x0403D0C2 RID: 250050
			CaptionItem,
			// Token: 0x0403D0C3 RID: 250051
			RoleLoopScrollView,
			// Token: 0x0403D0C4 RID: 250052
			RoleItem,
			// Token: 0x0403D0C5 RID: 250053
			SortFilterItem,
			// Token: 0x0403D0C6 RID: 250054
			NumberSprite,
			// Token: 0x0403D0C7 RID: 250055
			RoleTagLayout,
			// Token: 0x0403D0C8 RID: 250056
			RoleTagItem,
			// Token: 0x0403D0C9 RID: 250057
			RoleDesScrollView,
			// Token: 0x0403D0CA RID: 250058
			RoleDesItem,
			// Token: 0x0403D0CB RID: 250059
			LeftBtn,
			// Token: 0x0403D0CC RID: 250060
			RightBtn,
			// Token: 0x0403D0CD RID: 250061
			CloseBtn,
			// Token: 0x0403D0CE RID: 250062
			RoleNameText,
			// Token: 0x0403D0CF RID: 250063
			EmptyItem
		}
	}
}
