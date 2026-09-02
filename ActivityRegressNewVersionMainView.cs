using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020014F5 RID: 5365
[NullableContext(1)]
[Nullable(0)]
public class ActivityRegressNewVersionMainView : UiViewBase
{
	// Token: 0x0600961F RID: 38431 RVA: 0x002737DC File Offset: 0x002719DC
	public ActivityRegressNewVersionMainView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x06009620 RID: 38432 RVA: 0x002737FC File Offset: 0x002719FC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUITexture)),
			new ValueTuple<int, Type>(4, typeof(UUIItem))
		};
	}

	// Token: 0x06009621 RID: 38433 RVA: 0x00273884 File Offset: 0x00271A84
	protected override UniTask OnBeforeStartAsync()
	{
		ActivityRegressNewVersionMainView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivityRegressNewVersionMainView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009622 RID: 38434 RVA: 0x002738C7 File Offset: 0x00271AC7
	protected override void OnStart()
	{
		base.GetItem(4).SetUIActive(false);
	}

	// Token: 0x06009623 RID: 38435 RVA: 0x002738D8 File Offset: 0x00271AD8
	private UniTask CreateTabs()
	{
		ActivityRegressNewVersionMainView.<CreateTabs>d__11 <CreateTabs>d__;
		<CreateTabs>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateTabs>d__.<>4__this = this;
		<CreateTabs>d__.<>1__state = -1;
		<CreateTabs>d__.<>t__builder.Start<ActivityRegressNewVersionMainView.<CreateTabs>d__11>(ref <CreateTabs>d__);
		return <CreateTabs>d__.<>t__builder.Task;
	}

	// Token: 0x06009624 RID: 38436 RVA: 0x0027391C File Offset: 0x00271B1C
	private UniTask RefreshTabs()
	{
		ActivityRegressNewVersionMainView.<RefreshTabs>d__12 <RefreshTabs>d__;
		<RefreshTabs>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshTabs>d__.<>4__this = this;
		<RefreshTabs>d__.<>1__state = -1;
		<RefreshTabs>d__.<>t__builder.Start<ActivityRegressNewVersionMainView.<RefreshTabs>d__12>(ref <RefreshTabs>d__);
		return <RefreshTabs>d__.<>t__builder.Task;
	}

	// Token: 0x06009625 RID: 38437 RVA: 0x0027395F File Offset: 0x00271B5F
	private ActivityRegressTabItemPanel ProxyCreateTabItem([Nullable(2)] UUIItem uiItem, int? index)
	{
		return new ActivityRegressTabItemPanel();
	}

	// Token: 0x06009626 RID: 38438 RVA: 0x00273966 File Offset: 0x00271B66
	private void OnTabSelected(int index)
	{
		this.LastClickTime = Singleton<Time>.Instance.Now;
		this.ChangeSubUi(this.TabTypeList[index], 0);
	}

	// Token: 0x06009627 RID: 38439 RVA: 0x0027398C File Offset: 0x00271B8C
	private UniTask ChangeSubUi(EActivityNewVersionSubViewType subViewType, int subTabIndex = 0)
	{
		ActivityRegressNewVersionMainView.<ChangeSubUi>d__15 <ChangeSubUi>d__;
		<ChangeSubUi>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ChangeSubUi>d__.<>4__this = this;
		<ChangeSubUi>d__.subViewType = subViewType;
		<ChangeSubUi>d__.subTabIndex = subTabIndex;
		<ChangeSubUi>d__.<>1__state = -1;
		<ChangeSubUi>d__.<>t__builder.Start<ActivityRegressNewVersionMainView.<ChangeSubUi>d__15>(ref <ChangeSubUi>d__);
		return <ChangeSubUi>d__.<>t__builder.Task;
	}

	// Token: 0x06009628 RID: 38440 RVA: 0x002739E0 File Offset: 0x00271BE0
	private void UpdateTitle()
	{
		if (this.CurrentSubViewType == null)
		{
			return;
		}
		string textId = this.GetTypeTitle(this.CurrentSubViewType.Value) ?? "";
		string text = this.GetTypeTitleIconPath(this.CurrentSubViewType.Value) ?? "";
		string iconPath = (text != null && text != "") ? ConfigBase<UiResourceConfig>.Instance.GetResourcePath(text) : "";
		this.CaptionTabComponent.UpdateTitle(iconPath, new CommonTabTitleData(textId, Array.Empty<object>()));
	}

	// Token: 0x06009629 RID: 38441 RVA: 0x00273A6C File Offset: 0x00271C6C
	private UniTask OpenSubUi(EActivityNewVersionSubViewType viewType, int subTabIndex)
	{
		ActivityRegressNewVersionMainView.<OpenSubUi>d__17 <OpenSubUi>d__;
		<OpenSubUi>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OpenSubUi>d__.<>4__this = this;
		<OpenSubUi>d__.viewType = viewType;
		<OpenSubUi>d__.<>1__state = -1;
		<OpenSubUi>d__.<>t__builder.Start<ActivityRegressNewVersionMainView.<OpenSubUi>d__17>(ref <OpenSubUi>d__);
		return <OpenSubUi>d__.<>t__builder.Task;
	}

	// Token: 0x0600962A RID: 38442 RVA: 0x00273AB8 File Offset: 0x00271CB8
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	private UniTask<UiPanelBase> CreateSubUi(EActivityNewVersionSubViewType viewType)
	{
		ActivityRegressNewVersionMainView.<CreateSubUi>d__18 <CreateSubUi>d__;
		<CreateSubUi>d__.<>t__builder = AsyncUniTaskMethodBuilder<UiPanelBase>.Create();
		<CreateSubUi>d__.<>4__this = this;
		<CreateSubUi>d__.viewType = viewType;
		<CreateSubUi>d__.<>1__state = -1;
		<CreateSubUi>d__.<>t__builder.Start<ActivityRegressNewVersionMainView.<CreateSubUi>d__18>(ref <CreateSubUi>d__);
		return <CreateSubUi>d__.<>t__builder.Task;
	}

	// Token: 0x0600962B RID: 38443 RVA: 0x00273B04 File Offset: 0x00271D04
	private UniTask HideSubUi(EActivityNewVersionSubViewType viewType)
	{
		ActivityRegressNewVersionMainView.<HideSubUi>d__19 <HideSubUi>d__;
		<HideSubUi>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<HideSubUi>d__.<>4__this = this;
		<HideSubUi>d__.viewType = viewType;
		<HideSubUi>d__.<>1__state = -1;
		<HideSubUi>d__.<>t__builder.Start<ActivityRegressNewVersionMainView.<HideSubUi>d__19>(ref <HideSubUi>d__);
		return <HideSubUi>d__.<>t__builder.Task;
	}

	// Token: 0x0600962C RID: 38444 RVA: 0x00273B50 File Offset: 0x00271D50
	private CommonTabData GetCommonData(int index)
	{
		EActivityNewVersionSubViewType type = this.TabTypeList[index];
		string textId = this.GetTypeTitle(type) ?? "";
		string typeTitleIconPath = this.GetTypeTitleIconPath(type);
		return new CommonTabData((typeTitleIconPath != null && typeTitleIconPath != "") ? ConfigBase<UiResourceConfig>.Instance.GetResourcePath(typeTitleIconPath) : "", new CommonTabTitleData(textId, Array.Empty<object>()), null);
	}

	// Token: 0x0600962D RID: 38445 RVA: 0x00273BB6 File Offset: 0x00271DB6
	[NullableContext(2)]
	private string GetTypeTitle(EActivityNewVersionSubViewType type)
	{
		if (type == EActivityNewVersionSubViewType.RoleGachaPool)
		{
			return "Regress_NewVersion_Role_Title";
		}
		if (type != EActivityNewVersionSubViewType.MainLine)
		{
			return null;
		}
		return "Regress_NewVersion_MainLine_Title";
	}

	// Token: 0x0600962E RID: 38446 RVA: 0x00273BCE File Offset: 0x00271DCE
	[NullableContext(2)]
	private string GetTypeTitleIconPath(EActivityNewVersionSubViewType type)
	{
		if (type == EActivityNewVersionSubViewType.RoleGachaPool)
		{
			return "SP_IconComDrawcard";
		}
		if (type != EActivityNewVersionSubViewType.MainLine)
		{
			return null;
		}
		return "SP_FuncIconRenwu";
	}

	// Token: 0x0600962F RID: 38447 RVA: 0x00273BE8 File Offset: 0x00271DE8
	protected bool CanToggleChange(int index, bool? _)
	{
		if (Singleton<Info>.Instance.IsInGamepad())
		{
			return true;
		}
		int num = 600;
		return this.LastClickTime == 0.0 || Singleton<Time>.Instance.Now - this.LastClickTime >= (double)num;
	}

	// Token: 0x0400458D RID: 17805
	private const int TAB_CD = 600;

	// Token: 0x0400458E RID: 17806
	private readonly Dictionary<EActivityNewVersionSubViewType, UiPanelBase> SubViewMap = new Dictionary<EActivityNewVersionSubViewType, UiPanelBase>();

	// Token: 0x0400458F RID: 17807
	private EActivityNewVersionSubViewType? CurrentSubViewType;

	// Token: 0x04004590 RID: 17808
	private readonly List<EActivityNewVersionSubViewType> TabTypeList = new List<EActivityNewVersionSubViewType>();

	// Token: 0x04004591 RID: 17809
	[Nullable(2)]
	private ActivityRegressMainCaptionListPanel CaptionTabComponent;

	// Token: 0x04004592 RID: 17810
	private double LastClickTime;

	// Token: 0x020078AF RID: 30895
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x040297C9 RID: 169929
		public const int CaptionNameList = 0;

		// Token: 0x040297CA RID: 169930
		public const int Bg = 1;

		// Token: 0x040297CB RID: 169931
		public const int SubViewRoot = 2;

		// Token: 0x040297CC RID: 169932
		public const int Bg2 = 3;

		// Token: 0x040297CD RID: 169933
		public const int TitleItem = 4;
	}
}
