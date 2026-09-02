using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Plot;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.VillageInfr
{
	// Token: 0x02004C25 RID: 19493
	[NullableContext(1)]
	[Nullable(0)]
	public class VillageInfrWorldBuildView : UiViewBase, IUiCameraBehavior
	{
		// Token: 0x06032D41 RID: 208193 RVA: 0x00CBC874 File Offset: 0x00CBAA74
		public VillageInfrWorldBuildView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06032D42 RID: 208194 RVA: 0x00CBC8A0 File Offset: 0x00CBAAA0
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(2, new Action(this.OnClickBtnFunction))
			};
		}

		// Token: 0x06032D43 RID: 208195 RVA: 0x00CBC91D File Offset: 0x00CBAB1D
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnAntiqueShopUpgradeSequenceFinished, new Action(this.OnSequenceFinished));
		}

		// Token: 0x06032D44 RID: 208196 RVA: 0x00CBC93B File Offset: 0x00CBAB3B
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnAntiqueShopUpgradeSequenceFinished, new Action(this.OnSequenceFinished));
		}

		// Token: 0x06032D45 RID: 208197 RVA: 0x00CBC95C File Offset: 0x00CBAB5C
		protected override UniTask OnBeforeStartAsync()
		{
			VillageInfrWorldBuildView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<VillageInfrWorldBuildView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06032D46 RID: 208198 RVA: 0x00CBC9A0 File Offset: 0x00CBABA0
		private void SetOpenParam()
		{
			IVillageInfrDeliveryParam villageInfrDeliveryParam = this.OpenParam as IVillageInfrDeliveryParam;
			this.SelectType = villageInfrDeliveryParam.SelectType;
			this.SelectId = villageInfrDeliveryParam.SelectId;
			this.UiCameraName = villageInfrDeliveryParam.UiCameraName;
			if (this.SelectType == EVillageInfrSelectType.Village)
			{
				this.SelectId = ModelBase<VillageInfrModel>.Instance.GetVillageLevel();
			}
		}

		// Token: 0x06032D47 RID: 208199 RVA: 0x00CBC9F8 File Offset: 0x00CBABF8
		private UniTask CreateCaption()
		{
			VillageInfrWorldBuildView.<CreateCaption>d__11 <CreateCaption>d__;
			<CreateCaption>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateCaption>d__.<>4__this = this;
			<CreateCaption>d__.<>1__state = -1;
			<CreateCaption>d__.<>t__builder.Start<VillageInfrWorldBuildView.<CreateCaption>d__11>(ref <CreateCaption>d__);
			return <CreateCaption>d__.<>t__builder.Task;
		}

		// Token: 0x06032D48 RID: 208200 RVA: 0x00CBCA3C File Offset: 0x00CBAC3C
		private UniTask CreateBuildPanel()
		{
			VillageInfrWorldBuildView.<CreateBuildPanel>d__12 <CreateBuildPanel>d__;
			<CreateBuildPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateBuildPanel>d__.<>4__this = this;
			<CreateBuildPanel>d__.<>1__state = -1;
			<CreateBuildPanel>d__.<>t__builder.Start<VillageInfrWorldBuildView.<CreateBuildPanel>d__12>(ref <CreateBuildPanel>d__);
			return <CreateBuildPanel>d__.<>t__builder.Task;
		}

		// Token: 0x06032D49 RID: 208201 RVA: 0x00CBCA80 File Offset: 0x00CBAC80
		protected override void OnStart()
		{
			this.RefreshBuildInfo();
			if (this.SelectType == EVillageInfrSelectType.Village)
			{
				Singleton<EventSystem>.Instance.Emit<string>(EEventName.OnGuideTriggerEvent, "VillageInfrWorldBuildVillage");
				return;
			}
			if (this.SelectType == EVillageInfrSelectType.Tree)
			{
				Singleton<EventSystem>.Instance.Emit<string>(EEventName.OnGuideTriggerEvent, "VillageInfrWorldBuildTree");
			}
		}

		// Token: 0x06032D4A RID: 208202 RVA: 0x00CBCAD0 File Offset: 0x00CBACD0
		protected override void OnBeforeShow()
		{
			if (this.SelectType == EVillageInfrSelectType.Village)
			{
				Singleton<UiCameraAnimationManager>.Instance.DisablePlayerActor();
			}
		}

		// Token: 0x06032D4B RID: 208203 RVA: 0x00CBCAE5 File Offset: 0x00CBACE5
		protected override void OnAfterDestroy()
		{
			if (this.SelectType == EVillageInfrSelectType.Village)
			{
				Singleton<UiCameraAnimationManager>.Instance.EnablePlayerActor();
			}
		}

		// Token: 0x06032D4C RID: 208204 RVA: 0x00CBCAFA File Offset: 0x00CBACFA
		public void PushCameraHandle(EUiViewName viewName, int viewId, bool isBlend)
		{
			if (this.UiCameraName.Length > 0)
			{
				ControllerBase<UiCameraAnimationController>.Instance.PushCameraHandle((EUiViewName)this.UiCameraName, new int?(viewId), isBlend);
			}
		}

		// Token: 0x06032D4D RID: 208205 RVA: 0x00CBCB26 File Offset: 0x00CBAD26
		[NullableContext(2)]
		public void PopCameraHandle(EUiViewName viewName, UiViewInfo stackTopInfo, int closeViewId, bool popOrDelete)
		{
			if (this.UiCameraName.Length > 0)
			{
				ControllerBase<UiCameraAnimationController>.Instance.PopCameraHandle((EUiViewName)this.UiCameraName, stackTopInfo, closeViewId, popOrDelete);
			}
		}

		// Token: 0x06032D4E RID: 208206 RVA: 0x00CBCB4F File Offset: 0x00CBAD4F
		protected override void OnBeforeDestroy()
		{
			this.SelectId = 1;
		}

		// Token: 0x06032D4F RID: 208207 RVA: 0x00CBCB58 File Offset: 0x00CBAD58
		private void RefreshBuildInfo()
		{
			this.BuildPanel.SetBottomBtnClickCb(delegate
			{
				this.OnClickBuild().Forget();
			});
		}

		// Token: 0x06032D50 RID: 208208 RVA: 0x00CBCB74 File Offset: 0x00CBAD74
		private UniTask OnClickBuild()
		{
			VillageInfrWorldBuildView.<OnClickBuild>d__20 <OnClickBuild>d__;
			<OnClickBuild>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnClickBuild>d__.<>4__this = this;
			<OnClickBuild>d__.<>1__state = -1;
			<OnClickBuild>d__.<>t__builder.Start<VillageInfrWorldBuildView.<OnClickBuild>d__20>(ref <OnClickBuild>d__);
			return <OnClickBuild>d__.<>t__builder.Task;
		}

		// Token: 0x06032D51 RID: 208209 RVA: 0x00CBCBB7 File Offset: 0x00CBADB7
		private void OnClickBtnFunction()
		{
			ControllerBase<VillageInfrController>.Instance.OpenVillageInfrMainView(null).Forget<int?>();
		}

		// Token: 0x06032D52 RID: 208210 RVA: 0x00CBCBC9 File Offset: 0x00CBADC9
		private void OnSequenceFinished()
		{
			ControllerBase<PlotController>.Instance.PlotViewManager.HangPlotViewHud(false);
		}

		// Token: 0x0401D972 RID: 121202
		private int SelectId;

		// Token: 0x0401D973 RID: 121203
		private EVillageInfrSelectType SelectType;

		// Token: 0x0401D974 RID: 121204
		private readonly PopupCaptionItem Caption = new PopupCaptionItem(null);

		// Token: 0x0401D975 RID: 121205
		private readonly VillageInfrBuildPanel BuildPanel = new VillageInfrBuildPanel();

		// Token: 0x0401D976 RID: 121206
		private string UiCameraName = "";
	}
}
