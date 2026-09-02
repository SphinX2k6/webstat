using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200248A RID: 9354
public class PhantomBattleFettersObtainView : UiViewBase
{
	// Token: 0x06012271 RID: 74353 RVA: 0x004FDF8C File Offset: 0x004FC18C
	[NullableContext(1)]
	public PhantomBattleFettersObtainView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06012272 RID: 74354 RVA: 0x004FDF98 File Offset: 0x004FC198
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action(this.OnClose))
		};
	}

	// Token: 0x06012273 RID: 74355 RVA: 0x004FE000 File Offset: 0x004FC200
	[NullableContext(1)]
	private ILayoutItem<PhantomFettersObtainItem> InitFettersItem(object data, UUIItem item, int index)
	{
		PhantomFettersObtainItem phantomFettersObtainItem = new PhantomFettersObtainItem(item);
		phantomFettersObtainItem.Init();
		phantomFettersObtainItem.Update((IFettersObtainData)data);
		phantomFettersObtainItem.BindOnItemButtonClickedCallback(new Action<int>(this.OnOpenTrackView));
		return new LayoutItem<PhantomFettersObtainItem>
		{
			Key = index,
			Value = phantomFettersObtainItem
		};
	}

	// Token: 0x06012274 RID: 74356 RVA: 0x004FE050 File Offset: 0x004FC250
	protected override void OnStart()
	{
		PhantomFetter fatterData = (PhantomFetter)this.OpenParam;
		this.FettersObtainScroll = new GenericScrollView<PhantomFettersObtainItem>(base.GetScrollViewWithScrollbar(0), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<PhantomFettersObtainItem>(this.InitFettersItem), null);
		this.ShowFettersObtainView(fatterData);
	}

	// Token: 0x06012275 RID: 74357 RVA: 0x004FE08F File Offset: 0x004FC28F
	public void ShowFettersObtainView(PhantomFetter fatterData)
	{
		this.SetActive(true);
		this.FetterData = new PhantomFetter?(fatterData);
	}

	// Token: 0x06012276 RID: 74358 RVA: 0x004FE0A4 File Offset: 0x004FC2A4
	protected override void OnBeforeDestroy()
	{
		this.FettersObtainScroll.ClearChildren();
	}

	// Token: 0x06012277 RID: 74359 RVA: 0x004FE0B4 File Offset: 0x004FC2B4
	private void OnOpenTrackView(int id)
	{
		CalabashDevelopReward? calabashDevelopReward;
		ControllerBase<AdventureGuideController>.Instance.JumpToTargetView(EUiTabViewName.MonsterDetectView, (ConfigBase<CalabashConfig>.Instance.GetCalabashDevelopRewardByMonsterId(id) != null) ? new int?(calabashDevelopReward.GetValueOrDefault().MonsterProbeId) : null, null);
	}

	// Token: 0x06012278 RID: 74360 RVA: 0x004FE108 File Offset: 0x004FC308
	private void OnClose()
	{
		ModelBase<PhantomBattleModel>.Instance.CurrentSelectedFetter = new PhantomFetter?(this.FetterData.Value);
		base.CloseMe(null);
		Singleton<EventSystem>.Instance.Emit(EEventName.VisionFilterMonster);
		int? battleTeamFirstRoleId = ModelBase<RoleModel>.Instance.GetBattleTeamFirstRoleId();
		if (battleTeamFirstRoleId == null)
		{
			return;
		}
		if (!Singleton<UiManager>.Instance.IsViewShow(EUiViewName.VisionEquipmentView))
		{
			if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.PhantomBattleFettersView))
			{
				PhantomUtil.CloseAndOpenVisionEquipmentView(EUiViewName.PhantomBattleFettersView, battleTeamFirstRoleId.Value, -1);
				return;
			}
			PhantomUtil.OpenVisionEquipmentView(battleTeamFirstRoleId.Value, -1, null);
		}
	}

	// Token: 0x04008D9E RID: 36254
	private PhantomFetter? FetterData;

	// Token: 0x04008D9F RID: 36255
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollView<PhantomFettersObtainItem> FettersObtainScroll;

	// Token: 0x020087A8 RID: 34728
	private enum EFettersObtainDefine
	{
		// Token: 0x0402DDBB RID: 187835
		ObtainScroll,
		// Token: 0x0402DDBC RID: 187836
		ConfirmButton
	}
}
