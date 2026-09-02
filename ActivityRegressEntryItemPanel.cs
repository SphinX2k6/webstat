using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001542 RID: 5442
public class ActivityRegressEntryItemPanel : UiPanelBase
{
	// Token: 0x060098AD RID: 39085 RVA: 0x0027FE48 File Offset: 0x0027E048
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(3, typeof(UUITexture))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(2, new Action(this.OnEntryBtnClick))
		};
	}

	// Token: 0x060098AE RID: 39086 RVA: 0x0027FEDC File Offset: 0x0027E0DC
	private void OnEntryBtnClick()
	{
		if (!ModelBase<ActivityRegressModel>.Instance.CheckIfEntryOpen(this.Config.Value).Item1)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("RecallActivity_Role_Lock", Array.Empty<object>());
			return;
		}
		switch (this.EntryType.Value)
		{
		case EActivityRegressEntranceType.NewMainLine:
			ActivityRegressHelper.ReportRecallLog1023(EReportLogEventType.NewMainLine);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.ActivityRegressMainView, EActivityMainSubViewType.MainLine, null);
			return;
		case EActivityRegressEntranceType.NewArea:
			ActivityRegressHelper.ReportRecallLog1023(EReportLogEventType.NewArea);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.ActivityRegressMainView, EActivityMainSubViewType.Area, null);
			return;
		case EActivityRegressEntranceType.NewRole1:
			ActivityRegressHelper.ReportRecallLog1023(EReportLogEventType.NewRole);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.ActivityRegressMainView, EActivityMainSubViewType.Role1, null);
			return;
		case EActivityRegressEntranceType.NewRole2:
			ActivityRegressHelper.ReportRecallLog1023(EReportLogEventType.NewRole);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.ActivityRegressMainView, EActivityMainSubViewType.Role2, null);
			return;
		default:
			return;
		}
	}

	// Token: 0x060098AF RID: 39087 RVA: 0x0027FFB4 File Offset: 0x0027E1B4
	public void RefreshData(EActivityRegressEntranceType entryType, RegressEntry? config)
	{
		this.EntryType = new EActivityRegressEntranceType?(entryType);
		this.Config = config;
		bool flag = config != null;
		base.SetUiActive(flag);
		if (flag)
		{
			this.RefreshView();
		}
	}

	// Token: 0x060098B0 RID: 39088 RVA: 0x0027FFEC File Offset: 0x0027E1EC
	private void RefreshView()
	{
		if (this.Config == null)
		{
			Singleton<Log>.Instance.Warn(ELogModule.ActivityRegress, ELogAuthor.LRX, "ActivityRegressEntryItemPanel.RefreshView->回流活动入口配置为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			base.SetUiActive(false);
			return;
		}
		base.SetUiActive(true);
		UUIText text = base.GetText(0);
		string title = this.Config.Value.Title;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, title ?? "", Array.Empty<object>());
		base.GetText(1).SetText("", true);
		string currentBgResourcePathByGender = this.GetCurrentBgResourcePathByGender(this.Config.Value);
		UUITexture texture = base.GetTexture(3);
		bool item = ModelBase<ActivityRegressModel>.Instance.CheckIfEntryOpen(this.Config.Value).Item1;
		texture.SetUIActive(item);
		base.SetTextureByPath(currentBgResourcePathByGender, texture, null, null);
	}

	// Token: 0x060098B1 RID: 39089 RVA: 0x002800D0 File Offset: 0x0027E2D0
	[NullableContext(1)]
	private string GetCurrentBgResourcePathByGender(RegressEntry config)
	{
		EPlayerGender playerGender = ModelBase<PlayerInfoModel>.Instance.GetPlayerGender();
		if (playerGender == EPlayerGender.Male)
		{
			return config.IconPath ?? "";
		}
		if (playerGender == EPlayerGender.Female)
		{
			return config.IconPathF ?? "";
		}
		return "";
	}

	// Token: 0x0400469F RID: 18079
	private EActivityRegressEntranceType? EntryType;

	// Token: 0x040046A0 RID: 18080
	private RegressEntry? Config;

	// Token: 0x020078FC RID: 30972
	private class EComponents
	{
		// Token: 0x04029952 RID: 170322
		public const int TxtNum = 0;

		// Token: 0x04029953 RID: 170323
		public const int TxtContent = 1;

		// Token: 0x04029954 RID: 170324
		public const int BtnItem = 2;

		// Token: 0x04029955 RID: 170325
		public const int TxtIcon = 3;
	}
}
