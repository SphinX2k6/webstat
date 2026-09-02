using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.WheelTower;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020016DF RID: 5855
[NullableContext(2)]
[Nullable(0)]
public class WheelTowerRecordPopupView : UiViewBase
{
	// Token: 0x0600A285 RID: 41605 RVA: 0x002ADC93 File Offset: 0x002ABE93
	[NullableContext(1)]
	public WheelTowerRecordPopupView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600A286 RID: 41606 RVA: 0x002ADC9C File Offset: 0x002ABE9C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 8;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnClickCancel));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(7, new Action(this.OnClickConfirm));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600A287 RID: 41607 RVA: 0x002ADE2C File Offset: 0x002AC02C
	protected override UniTask OnBeforeStartAsync()
	{
		WheelTowerRecordPopupView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<WheelTowerRecordPopupView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600A288 RID: 41608 RVA: 0x002ADE70 File Offset: 0x002AC070
	protected override void OnStart()
	{
		IWheelTowerRecordPopupViewData wheelTowerRecordPopupViewData = this.OpenParam as IWheelTowerRecordPopupViewData;
		if (wheelTowerRecordPopupViewData == null)
		{
			return;
		}
		this.ConfirmCallback = wheelTowerRecordPopupViewData.OnClickConfirm;
		this.CancelCallback = wheelTowerRecordPopupViewData.OnClickCancel;
		string id = wheelTowerRecordPopupViewData.IsEndless ? "WheelBattleMode_Endless" : "WheelBattleMode_Normal";
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "WheelTowerRecordPopup_Title", new <>z__ReadOnlyArray<object>(new object[]
		{
			ConfigMultiTextLang.GetLocalTextNew(id, null),
			wheelTowerRecordPopupViewData.Round.ToString()
		}));
		this.RefreshScoreLayout(wheelTowerRecordPopupViewData);
		WheelTowerRecordPopupView.TeamItem oldTeamItem = this.OldTeamItem;
		if (oldTeamItem != null)
		{
			oldTeamItem.Refresh(wheelTowerRecordPopupViewData.BeforeData.TeamRoleIdList, wheelTowerRecordPopupViewData.BeforeData.BuffId);
		}
		WheelTowerRecordPopupView.TeamItem newTeamItem = this.NewTeamItem;
		if (newTeamItem != null)
		{
			newTeamItem.Refresh(wheelTowerRecordPopupViewData.AfterData.TeamRoleIdList, wheelTowerRecordPopupViewData.AfterData.BuffId);
		}
		ModelBase<WheelTowerModel>.Instance.BlockEndlessUnlockTips = false;
	}

	// Token: 0x0600A289 RID: 41609 RVA: 0x002ADF58 File Offset: 0x002AC158
	[NullableContext(1)]
	private void RefreshScoreLayout(IWheelTowerRecordPopupViewData data)
	{
		List<WheelTowerRecordPopupScoreItemData> data2 = new List<WheelTowerRecordPopupScoreItemData>
		{
			new WheelTowerRecordPopupScoreItemData
			{
				Title = "WheelTowerRecordPopupScore",
				ScoreOld = data.BeforeData.RoundScore,
				ScoreNew = data.AfterData.RoundScore,
				NeedScoreIcon = false
			},
			new WheelTowerRecordPopupScoreItemData
			{
				Title = "WheelTowerRecordPopupTotalScore",
				ScoreOld = data.BeforeData.TotalScore,
				ScoreNew = data.AfterData.TotalScore,
				NeedScoreIcon = true
			},
			new WheelTowerRecordPopupScoreItemData
			{
				Title = "WheelTowerRecordPopupScoreRecord",
				ScoreOld = data.BeforeData.ScoreRecord,
				ScoreNew = data.AfterData.ScoreRecord,
				NeedScoreIcon = true
			}
		};
		GenericLayout<WheelTowerRecordPopupView.ScoreItem, WheelTowerRecordPopupScoreItemData> scoreLayout = this.ScoreLayout;
		if (scoreLayout == null)
		{
			return;
		}
		scoreLayout.RefreshByData(data2, null, false);
	}

	// Token: 0x0600A28A RID: 41610 RVA: 0x002AE03B File Offset: 0x002AC23B
	private void OnClickCancel()
	{
		Action cancelCallback = this.CancelCallback;
		if (cancelCallback != null)
		{
			cancelCallback();
		}
		base.CloseMe(null);
	}

	// Token: 0x0600A28B RID: 41611 RVA: 0x002AE055 File Offset: 0x002AC255
	private void OnClickConfirm()
	{
		Action confirmCallback = this.ConfirmCallback;
		if (confirmCallback != null)
		{
			confirmCallback();
		}
		base.CloseMe(null);
	}

	// Token: 0x04004CDD RID: 19677
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<WheelTowerRecordPopupView.ScoreItem, WheelTowerRecordPopupScoreItemData> ScoreLayout;

	// Token: 0x04004CDE RID: 19678
	private WheelTowerRecordPopupView.TeamItem OldTeamItem;

	// Token: 0x04004CDF RID: 19679
	private WheelTowerRecordPopupView.TeamItem NewTeamItem;

	// Token: 0x04004CE0 RID: 19680
	private Action ConfirmCallback;

	// Token: 0x04004CE1 RID: 19681
	private Action CancelCallback;

	// Token: 0x02007A31 RID: 31281
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	private class ScoreItem : GridProxyAbstract<WheelTowerRecordPopupScoreItemData>
	{
		// Token: 0x060478AF RID: 293039 RVA: 0x01311E24 File Offset: 0x01310024
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060478B0 RID: 293040 RVA: 0x01311EF0 File Offset: 0x013100F0
		public override void Refresh(WheelTowerRecordPopupScoreItemData data, bool isSelected, int gridIndex)
		{
			UUIText text = base.GetText(0);
			if (text != null)
			{
				text.ShowTextNew(data.Title);
			}
			UUIText text2 = base.GetText(1);
			if (text2 != null)
			{
				text2.SetText(data.ScoreOld.ToString(), true);
			}
			UUIText text3 = base.GetText(2);
			if (text3 != null)
			{
				text3.SetText(data.ScoreNew.ToString(), true);
			}
			if (!data.NeedScoreIcon)
			{
				return;
			}
			WheelTowerScoreItem wheelTowerScoreItem = new WheelTowerScoreItem(this, base.GetItem(3));
			EScoreLevel totalScoreLevel = ModelBase<WheelTowerModel>.Instance.GetTotalScoreLevel(data.ScoreNew, null, null);
			wheelTowerScoreItem.Refresh(totalScoreLevel);
			UUIItem item = base.GetItem(4);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(totalScoreLevel > EScoreLevel.A);
		}
	}

	// Token: 0x02007A32 RID: 31282
	[NullableContext(0)]
	private class TeamItem : UiPanelBase
	{
		// Token: 0x060478B2 RID: 293042 RVA: 0x01311FB4 File Offset: 0x013101B4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060478B3 RID: 293043 RVA: 0x0131203E File Offset: 0x0131023E
		protected override void OnStart()
		{
			this.RoleLayout = new GenericLayout<WheelTowerRecordPopupView.RoleGridItem, int>(base.GetHorizontalLayout(0), () => new WheelTowerRecordPopupView.RoleGridItem(), null, false, true);
		}

		// Token: 0x060478B4 RID: 293044 RVA: 0x01312074 File Offset: 0x01310274
		[NullableContext(1)]
		public void Refresh(List<int> roleIdList, int buffId)
		{
			GenericLayout<WheelTowerRecordPopupView.RoleGridItem, int> roleLayout = this.RoleLayout;
			if (roleLayout != null)
			{
				roleLayout.RefreshByData(roleIdList, null, false);
			}
			NewTowerBuff? buffConfigById = ConfigBase<WheelTowerConfig>.Instance.GetBuffConfigById(buffId);
			if (buffConfigById != null)
			{
				base.SetTextureShowUntilLoaded(buffConfigById.Value.Icon, base.GetTexture(2), null);
			}
		}

		// Token: 0x04029E97 RID: 171671
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<WheelTowerRecordPopupView.RoleGridItem, int> RoleLayout;
	}

	// Token: 0x02007A33 RID: 31283
	[NullableContext(0)]
	private class RoleGridItem : LoopScrollSmallItemGrid<int>
	{
		// Token: 0x060478B6 RID: 293046 RVA: 0x013120CF File Offset: 0x013102CF
		protected override void OnStart()
		{
			base.BindOnCanExecuteChange((object _, bool _, EToggleState _) => false);
		}

		// Token: 0x060478B7 RID: 293047 RVA: 0x013120F8 File Offset: 0x013102F8
		protected override void OnRefresh(int roleId, bool isSelected, int gridIndex)
		{
			int num = ModelBase<WheelTowerModel>.Instance.TryGetRealRoleId(roleId);
			RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(num, true);
			if (roleDataById == null)
			{
				return;
			}
			CharacterSmallItemGrid parameters = new CharacterSmallItemGrid
			{
				Data = roleDataById,
				ItemConfigId = new int?(num),
				SkinId = new int?(roleDataById.GetRoleConfig().SkinId),
				BottomText = roleDataById.GetName(null),
				ElementId = new int?(roleDataById.GetRoleConfig().ElementId)
			};
			base.SetUseFixedAsync(true);
			base.Apply<CharacterSmallItemGrid>(parameters);
		}
	}
}
