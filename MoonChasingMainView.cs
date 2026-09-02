using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001408 RID: 5128
[NullableContext(1)]
[Nullable(0)]
public class MoonChasingMainView : UiViewBase
{
	// Token: 0x06008E0D RID: 36365 RVA: 0x002553B3 File Offset: 0x002535B3
	public MoonChasingMainView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x06008E0E RID: 36366 RVA: 0x002553C8 File Offset: 0x002535C8
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
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem))
		};
	}

	// Token: 0x06008E0F RID: 36367 RVA: 0x002554A8 File Offset: 0x002536A8
	private UniTask InitPopularity()
	{
		MoonChasingMainView.<InitPopularity>d__11 <InitPopularity>d__;
		<InitPopularity>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitPopularity>d__.<>4__this = this;
		<InitPopularity>d__.<>1__state = -1;
		<InitPopularity>d__.<>t__builder.Start<MoonChasingMainView.<InitPopularity>d__11>(ref <InitPopularity>d__);
		return <InitPopularity>d__.<>t__builder.Task;
	}

	// Token: 0x06008E10 RID: 36368 RVA: 0x002554EC File Offset: 0x002536EC
	private UniTask InitCaption()
	{
		MoonChasingMainView.<InitCaption>d__12 <InitCaption>d__;
		<InitCaption>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitCaption>d__.<>4__this = this;
		<InitCaption>d__.<>1__state = -1;
		<InitCaption>d__.<>t__builder.Start<MoonChasingMainView.<InitCaption>d__12>(ref <InitCaption>d__);
		return <InitCaption>d__.<>t__builder.Task;
	}

	// Token: 0x06008E11 RID: 36369 RVA: 0x00255530 File Offset: 0x00253730
	private UniTask InitBuildingMainModule()
	{
		MoonChasingMainView.<InitBuildingMainModule>d__13 <InitBuildingMainModule>d__;
		<InitBuildingMainModule>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitBuildingMainModule>d__.<>4__this = this;
		<InitBuildingMainModule>d__.<>1__state = -1;
		<InitBuildingMainModule>d__.<>t__builder.Start<MoonChasingMainView.<InitBuildingMainModule>d__13>(ref <InitBuildingMainModule>d__);
		return <InitBuildingMainModule>d__.<>t__builder.Task;
	}

	// Token: 0x06008E12 RID: 36370 RVA: 0x00255574 File Offset: 0x00253774
	private void InitBtn()
	{
		this.BusinessBtn = new ButtonItem(base.GetItem(2));
		this.BusinessBtn.SetFunction(new Action<int>(this.Vc.SkipToBusinessByParam));
		this.BuildBtn = new ButtonItem(base.GetItem(3));
		this.BuildBtn.SetFunction(new Action<int>(this.Vc.SkipToBuildByParam));
		this.TaskBtn = new ButtonItem(base.GetItem(4));
		this.TaskBtn.SetFunction(delegate(int _)
		{
			this.Vc.SkipToTask(EMoonChasingTaskType.MainLine, false);
		});
		this.HandbookBtn = new ButtonItem(base.GetItem(0));
		this.HandbookBtn.SetFunction(new Action<int>(this.Vc.SkipToHandbook));
		this.RewardBtn = new ButtonItem(base.GetItem(1));
		this.RewardBtn.SetFunction(new Action<int>(this.Vc.SkipToReward));
	}

	// Token: 0x06008E13 RID: 36371 RVA: 0x00255664 File Offset: 0x00253864
	protected override UniTask OnBeforeStartAsync()
	{
		MoonChasingMainView.<OnBeforeStartAsync>d__15 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<MoonChasingMainView.<OnBeforeStartAsync>d__15>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06008E14 RID: 36372 RVA: 0x002556A7 File Offset: 0x002538A7
	protected override void OnBeforeShow()
	{
		this.Vc.Show();
		ControllerBase<ActivityMoonChasingController>.Instance.CheckIsActivityClose();
	}

	// Token: 0x06008E15 RID: 36373 RVA: 0x002556BE File Offset: 0x002538BE
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.PopularityChange, new Action(this.OnPopularityChange));
	}

	// Token: 0x06008E16 RID: 36374 RVA: 0x002556DC File Offset: 0x002538DC
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.PopularityChange, new Action(this.OnPopularityChange));
	}

	// Token: 0x06008E17 RID: 36375 RVA: 0x002556FC File Offset: 0x002538FC
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (configParams.Length < 1)
		{
			return null;
		}
		string a = configParams[0];
		if (a == "Cost")
		{
			UUIItem costContent = this.CaptionItem.GetCostContent();
			if (costContent == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				costContent,
				costContent
			};
		}
		else
		{
			if (a == "BuildMap")
			{
				return this.BuildingMainModule.GetGuideUiItemAndUiItemForShowEx(configParams);
			}
			return null;
		}
	}

	// Token: 0x06008E18 RID: 36376 RVA: 0x0025575D File Offset: 0x0025395D
	private void OnPopularityChange()
	{
		this.Popularity.RefreshPopularity();
	}

	// Token: 0x06008E19 RID: 36377 RVA: 0x0025576A File Offset: 0x0025396A
	public void RefreshBuildingModule()
	{
		this.BuildingMainModule.RefreshModule();
	}

	// Token: 0x06008E1A RID: 36378 RVA: 0x00255777 File Offset: 0x00253977
	public void BuildingBackToMainView()
	{
		UUIItem item = base.GetItem(7);
		if (item != null)
		{
			item.SetUIActive(true);
		}
		this.BuildingMainModule.HideBuildingModule();
	}

	// Token: 0x06008E1B RID: 36379 RVA: 0x00255797 File Offset: 0x00253997
	public void SkipToBuild()
	{
		UUIItem item = base.GetItem(7);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		this.BuildingMainModule.ShowBuilding();
	}

	// Token: 0x06008E1C RID: 36380 RVA: 0x002557B7 File Offset: 0x002539B7
	public void RefreshMainModule(int buildingId)
	{
		this.BuildingMainModule.RefreshBuilding(buildingId);
	}

	// Token: 0x06008E1D RID: 36381 RVA: 0x002557C8 File Offset: 0x002539C8
	public void RefreshRedDot()
	{
		this.BusinessBtn.BindRedDot(ERedDotName.MoonChasingDelegation, 0);
		this.BuildBtn.BindRedDot(ERedDotName.MoonChasingBuilding, 0);
		this.HandbookBtn.BindRedDot(ERedDotName.MoonChasingHandbook, 0);
		this.RewardBtn.BindRedDot(ERedDotName.MoonChasingRewardAndShop, 0);
		this.TaskBtn.BindRedDot(ERedDotName.MoonChasingAllQuest, 0);
	}

	// Token: 0x04004239 RID: 16953
	private PopularityModule Popularity;

	// Token: 0x0400423A RID: 16954
	private PopupCaptionItem CaptionItem;

	// Token: 0x0400423B RID: 16955
	private BuildingMainModule BuildingMainModule;

	// Token: 0x0400423C RID: 16956
	private ButtonItem BusinessBtn;

	// Token: 0x0400423D RID: 16957
	private ButtonItem BuildBtn;

	// Token: 0x0400423E RID: 16958
	private ButtonItem TaskBtn;

	// Token: 0x0400423F RID: 16959
	private ButtonItem HandbookBtn;

	// Token: 0x04004240 RID: 16960
	private ButtonItem RewardBtn;

	// Token: 0x04004241 RID: 16961
	private readonly MoonChasingViewController Vc = new MoonChasingViewController();

	// Token: 0x020077F8 RID: 30712
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x0402945F RID: 169055
		public const int HandbookBtn = 0;

		// Token: 0x04029460 RID: 169056
		public const int RewardBtn = 1;

		// Token: 0x04029461 RID: 169057
		public const int BusinessBtn = 2;

		// Token: 0x04029462 RID: 169058
		public const int BuildBtn = 3;

		// Token: 0x04029463 RID: 169059
		public const int TaskBtn = 4;

		// Token: 0x04029464 RID: 169060
		public const int CaptionItem = 5;

		// Token: 0x04029465 RID: 169061
		public const int PopularityItem = 6;

		// Token: 0x04029466 RID: 169062
		public const int ContentItem = 7;

		// Token: 0x04029467 RID: 169063
		public const int BuildMainItem = 8;
	}
}
