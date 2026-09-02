using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SpringManor
{
	// Token: 0x02006339 RID: 25401
	[NullableContext(1)]
	[Nullable(0)]
	public class SpringManorRoleSwitchView : UiViewBase
	{
		// Token: 0x0603FCCF RID: 261327 RVA: 0x0105C2AD File Offset: 0x0105A4AD
		public SpringManorRoleSwitchView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603FCD0 RID: 261328 RVA: 0x0105C2B8 File Offset: 0x0105A4B8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 16;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUILoopScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.BackClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603FCD1 RID: 261329 RVA: 0x0105C538 File Offset: 0x0105A738
		protected override UniTask OnBeforeStartAsync()
		{
			SpringManorRoleSwitchView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SpringManorRoleSwitchView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603FCD2 RID: 261330 RVA: 0x0105C57C File Offset: 0x0105A77C
		protected override void OnStart()
		{
			UUIItem item = base.GetItem(5);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUIText text = base.GetText(9);
			if (text != null)
			{
				text.SetUIActive(false);
			}
			UUIText text2 = base.GetText(18);
			if (text2 != null)
			{
				text2.ShowTextNew("Spring26_RoleSwitch_Loading");
			}
			ButtonItem confirmButton = this.ConfirmButton;
			if (confirmButton != null)
			{
				confirmButton.SetShowText("Spring26_ChangeRoleBtn_Text");
			}
			this.RoleScrollView = new LoopScrollView<SpringManorRoleGridItem, RoleDataBase>(base.GetLoopScrollViewComponent(1), base.GetItem(10).GetOwner() as AUIBaseActor, new Func<SpringManorRoleGridItem>(this.OnGridProxyCreate), false);
			UUIItem item2 = base.GetItem(8);
			this.FilterSortEntrance = new FilterSortEntrance<RoleDataBase>(item2, new TUpdateDataListFunction<RoleDataBase>(this.UpdateRoleList));
			this.FilterSortEntrance.UpdateData(EFilterSortGroupId.EditFormation, ModelBase<RoleModel>.Instance.GetRoleDataList(true), Array.Empty<object>());
			this.LoadingSequencePlayer = new UiSequencePlayer(base.GetItem(13));
		}

		// Token: 0x0603FCD3 RID: 261331 RVA: 0x0105C65E File Offset: 0x0105A85E
		protected override void OnBeforeShow()
		{
			this.RefreshView();
		}

		// Token: 0x0603FCD4 RID: 261332 RVA: 0x0105C668 File Offset: 0x0105A868
		private void RefreshView()
		{
			EditFormationData getCurrentFormationData = ModelBase<EditFormationModel>.Instance.GetCurrentFormationData;
			int? num = (getCurrentFormationData != null) ? new int?(getCurrentFormationData.GetCurrentRoleConfigId) : null;
			int selectedRoleId = this.SelectedRoleId;
			bool flag = num.GetValueOrDefault() == selectedRoleId & num != null;
			ButtonItem confirmButton = this.ConfirmButton;
			if (confirmButton == null)
			{
				return;
			}
			UUIButtonComponent btn = confirmButton.GetBtn();
			if (btn == null)
			{
				return;
			}
			btn.SetSelfInteractive(this.SelectedRoleId != 0 && !flag);
		}

		// Token: 0x0603FCD5 RID: 261333 RVA: 0x0105C6DC File Offset: 0x0105A8DC
		private void ConfirmClick(int __)
		{
			if (this.SelectedRoleId == 0)
			{
				return;
			}
			if (ModelBase<SpringManorModel>.Instance.IsRoleDead(this.SelectedRoleId))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("ErrorCode_300038_Text", Array.Empty<object>());
				return;
			}
			EditFormationModel instance = ModelBase<EditFormationModel>.Instance;
			EditFormationData editFormationData = (instance != null) ? instance.GetCurrentFormationData : null;
			if (editFormationData == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.SpringManor, ELogAuthor.LJ, "检查试用角色时无当前编队数据！", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			int[] getRoleIdList = editFormationData.GetRoleIdList;
			int value = editFormationData.GetCurrentRolePosition - 1;
			if (RoleUtils.HasMultiTrialRole(this.SelectedRoleId, getRoleIdList, new int?(value)))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("EditBattleTeamMultiTrialRole", Array.Empty<object>());
				return;
			}
			this.ShowLoading();
			ControllerBase<SpringManorController>.Instance.ChangeRoleRequest(this.SelectedRoleId).ContinueWith(new Action(this.TryCloseMe));
		}

		// Token: 0x0603FCD6 RID: 261334 RVA: 0x0105C7B0 File Offset: 0x0105A9B0
		private void ShowLoading()
		{
			if (this.DelayLoadingTimer == null)
			{
				Singleton<UiLayer>.Instance.SetShowMaskLayer("SpringManorRoleSwitchViewLoading", true);
				this.DelayLoadingTimer = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
				{
					UUIButtonComponent button = base.GetButton(4);
					if (button != null)
					{
						button.RootUIComp.Get().SetUIActive(false);
					}
					UUIItem item = base.GetItem(13);
					if (item != null)
					{
						item.SetUIActive(true);
					}
					UiSequencePlayer loadingSequencePlayer = this.LoadingSequencePlayer;
					if (loadingSequencePlayer == null)
					{
						return;
					}
					loadingSequencePlayer.PlaySequence("Progressing", false, null);
				}, 500f, null, null, true, 1f);
			}
			if (this.AutoCloseTimer == null)
			{
				this.AutoCloseTimer = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
				{
					this.TryCloseMe();
				}, 30000f, null, null, true, 1f);
			}
		}

		// Token: 0x0603FCD7 RID: 261335 RVA: 0x0105C82F File Offset: 0x0105AA2F
		private void BackClick()
		{
			this.TryCloseMe();
		}

		// Token: 0x0603FCD8 RID: 261336 RVA: 0x0105C838 File Offset: 0x0105AA38
		protected override void OnBeforeDestroy()
		{
			if (this.DelayLoadingTimer != null)
			{
				if (TimerSystem.GameplayTimeInstance.Has(this.DelayLoadingTimer))
				{
					TimerSystem.GameplayTimeInstance.Remove(this.DelayLoadingTimer);
				}
				this.DelayLoadingTimer = null;
			}
			if (this.AutoCloseTimer != null)
			{
				if (TimerSystem.GameplayTimeInstance.Has(this.AutoCloseTimer))
				{
					TimerSystem.GameplayTimeInstance.Remove(this.AutoCloseTimer);
				}
				this.AutoCloseTimer = null;
			}
			Singleton<UiLayer>.Instance.SetShowMaskLayer("SpringManorRoleSwitchViewLoading", false);
		}

		// Token: 0x0603FCD9 RID: 261337 RVA: 0x0105C8B9 File Offset: 0x0105AAB9
		private void TryCloseMe()
		{
			if (this.IsClosed)
			{
				return;
			}
			this.IsClosed = true;
			base.CloseMe(null);
		}

		// Token: 0x0603FCDA RID: 261338 RVA: 0x0105C8D4 File Offset: 0x0105AAD4
		private void UpdateRoleList(List<RoleDataBase> list, bool isShowText, EFilterSortType OperationType)
		{
			List<RoleDataBase> list2 = new List<RoleDataBase>();
			RoleModel instance = ModelBase<RoleModel>.Instance;
			RoleDataBase roleDataBase = (instance != null) ? instance.GetRoleDataById(this.SelectedRoleId, true) : null;
			if (roleDataBase != null)
			{
				list2.Add(roleDataBase);
			}
			list2.AddRange(list);
			if (roleDataBase != null)
			{
				for (int i = list2.Count - 1; i >= 1; i--)
				{
					if (list2[i] == roleDataBase)
					{
						list2.RemoveAt(i);
					}
				}
			}
			bool flag = list2.Count > 0;
			base.GetItem(11).SetUIActive(!flag);
			ButtonItem confirmButton = this.ConfirmButton;
			if (confirmButton != null)
			{
				confirmButton.SetUiActive(flag);
			}
			base.GetLoopScrollViewComponent(1).RootUIComp.Get().SetUIActive(flag);
			if (!flag)
			{
				return;
			}
			this.RoleScrollView.RefreshByData(list2, false, delegate
			{
				LoopScrollView<SpringManorRoleGridItem, RoleDataBase> roleScrollView = this.RoleScrollView;
				if (roleScrollView == null)
				{
					return;
				}
				SpringManorRoleGridItem springManorRoleGridItem = roleScrollView.UnsafeGetGridProxy(0, false);
				if (springManorRoleGridItem == null)
				{
					return;
				}
				springManorRoleGridItem.SetToggleState(true, true, false);
			}, false);
		}

		// Token: 0x0603FCDB RID: 261339 RVA: 0x0105C99E File Offset: 0x0105AB9E
		private SpringManorRoleGridItem OnGridProxyCreate()
		{
			SpringManorRoleGridItem springManorRoleGridItem = new SpringManorRoleGridItem();
			springManorRoleGridItem.BindOnExtendToggleStateChanged(new Action<MediumItemGridExtendCallback>(this.ToggleFunction));
			springManorRoleGridItem.BindOnCanExecuteChange(new Func<object, bool, EToggleState, bool>(this.CanExecuteChange));
			return springManorRoleGridItem;
		}

		// Token: 0x0603FCDC RID: 261340 RVA: 0x0105C9CC File Offset: 0x0105ABCC
		protected void ToggleFunction(MediumItemGridExtendCallback parameters)
		{
			RoleDataBase roleDataBase = parameters.Data as RoleDataBase;
			this.SelectedRoleId = roleDataBase.GetDataId();
			SpringManorRoleGridItem springManorRoleGridItem = parameters.MediumItemGrid as SpringManorRoleGridItem;
			LoopScrollView<SpringManorRoleGridItem, RoleDataBase> roleScrollView = this.RoleScrollView;
			if (roleScrollView != null)
			{
				roleScrollView.SelectGridProxy(springManorRoleGridItem.GridIndex, false);
			}
			this.RefreshView();
		}

		// Token: 0x0603FCDD RID: 261341 RVA: 0x0105CA1B File Offset: 0x0105AC1B
		protected bool CanExecuteChange(object data, bool isForceSelected, EToggleState state)
		{
			return state != EToggleState.ETT_Checked;
		}

		// Token: 0x04023D5B RID: 146779
		private int SelectedRoleId;

		// Token: 0x04023D5C RID: 146780
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		protected LoopScrollView<SpringManorRoleGridItem, RoleDataBase> RoleScrollView;

		// Token: 0x04023D5D RID: 146781
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected FilterSortEntrance<RoleDataBase> FilterSortEntrance;

		// Token: 0x04023D5E RID: 146782
		[Nullable(2)]
		protected TimerHandle DelayLoadingTimer;

		// Token: 0x04023D5F RID: 146783
		[Nullable(2)]
		protected TimerHandle AutoCloseTimer;

		// Token: 0x04023D60 RID: 146784
		[Nullable(2)]
		protected UiSequencePlayer LoadingSequencePlayer;

		// Token: 0x04023D61 RID: 146785
		[Nullable(2)]
		private ButtonItem ConfirmButton;

		// Token: 0x04023D62 RID: 146786
		private bool IsClosed;

		// Token: 0x04023D63 RID: 146787
		private const string ROLE_LOADING_MASK_TAG = "SpringManorRoleSwitchViewLoading";
	}
}
