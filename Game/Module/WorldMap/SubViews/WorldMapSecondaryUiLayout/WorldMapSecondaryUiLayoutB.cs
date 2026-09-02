using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.WorldMap.SubViews.Common;
using CSharpScript.Game.Module.WorldMap.ViewComponent;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.WorldMap.SubViews.WorldMapSecondaryUiLayout
{
	// Token: 0x02004B62 RID: 19298
	[NullableContext(2)]
	[Nullable(0)]
	public class WorldMapSecondaryUiLayoutB : WorldMapSecondaryUi
	{
		// Token: 0x060326D0 RID: 206544 RVA: 0x00C9DB44 File Offset: 0x00C9BD44
		protected unsafe override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = WorldMapDefine.SecondaryUiPanelComponentsRegisterInfoB;
			int num = 1;
			List<ValueTuple<int, Delegate>> list = new List<ValueTuple<int, Delegate>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list, num);
			Span<ValueTuple<int, Delegate>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Delegate>(10, new Action(this.OnDelBtnClick));
			this.BtnBindInfo = list;
		}

		// Token: 0x060326D1 RID: 206545 RVA: 0x00C9DB9C File Offset: 0x00C9BD9C
		protected override UniTask OnBeforeStartAsync()
		{
			WorldMapSecondaryUiLayoutB.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<WorldMapSecondaryUiLayoutB.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060326D2 RID: 206546 RVA: 0x00C9DBE0 File Offset: 0x00C9BDE0
		private void InitButtons()
		{
			this.LeftConfirmBtn = new ButtonItem(base.GetItem(7));
			this.LeftConfirmBtn.SetFunction(new Action<int>(this.OnLeftConfirmBtnClick));
			this.RightConfirmBtn = new ButtonItem(base.GetItem(8));
			this.RightConfirmBtn.SetFunction(new Action<int>(this.OnRightConfirmBtnClick));
			this.MiddleCenterBtn = new ButtonItem(base.GetButton(12).RootUIComp);
			this.MiddleCenterBtn.SetFunction(new Action<int>(this.OnMiddleCenterBtnClick));
		}

		// Token: 0x060326D3 RID: 206547 RVA: 0x00C9DC76 File Offset: 0x00C9BE76
		private void InitLayoutContext()
		{
			this.LayoutContext = new WorldMapSecondaryUiContext();
			this.LayoutContext.TrackButtonItem = this.LeftConfirmBtn;
			this.LayoutContext.MapTipsActivateTipPanel = this.MapTipsActivateTipPanel;
		}

		// Token: 0x060326D4 RID: 206548 RVA: 0x00C9DCA8 File Offset: 0x00C9BEA8
		[NullableContext(1)]
		private UniTask InitAutoPilotContext(WorldMapSecondaryUiContext layoutContext)
		{
			WorldMapSecondaryUiLayoutB.<InitAutoPilotContext>d__10 <InitAutoPilotContext>d__;
			<InitAutoPilotContext>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitAutoPilotContext>d__.<>4__this = this;
			<InitAutoPilotContext>d__.layoutContext = layoutContext;
			<InitAutoPilotContext>d__.<>1__state = -1;
			<InitAutoPilotContext>d__.<>t__builder.Start<WorldMapSecondaryUiLayoutB.<InitAutoPilotContext>d__10>(ref <InitAutoPilotContext>d__);
			return <InitAutoPilotContext>d__.<>t__builder.Task;
		}

		// Token: 0x060326D5 RID: 206549 RVA: 0x00C9DCF3 File Offset: 0x00C9BEF3
		protected override void OnStart()
		{
			this.RootItem.SetRaycastTarget(false);
			this.SetDelBtnActive(false);
		}

		// Token: 0x060326D6 RID: 206550 RVA: 0x00C9DD08 File Offset: 0x00C9BF08
		protected override void OnBeforeDestroy()
		{
			this.LeftConfirmBtn.Destroy(null);
			this.RightConfirmBtn.Destroy(null);
			this.MiddleCenterBtn.Destroy(null);
		}

		// Token: 0x060326D7 RID: 206551 RVA: 0x00C9DD30 File Offset: 0x00C9BF30
		protected override void SetupWorldMapSecondaryUiLayout()
		{
			MapTipsActivateTipPanel mapTipsActivateTipPanel = this.MapTipsActivateTipPanel;
			if (mapTipsActivateTipPanel != null)
			{
				mapTipsActivateTipPanel.SetUiActive(false);
			}
			WorldMapSecondaryUiAutoPilotContext autoPilotContext = this.AutoPilotContext;
			if (autoPilotContext != null)
			{
				autoPilotContext.SetMap(this.Map);
			}
			WorldMapSecondaryUiAutoPilotContext autoPilotContext2 = this.AutoPilotContext;
			if (autoPilotContext2 != null)
			{
				autoPilotContext2.SetDownStateBtnRootActive(true);
			}
			WorldMapSecondaryUiAutoPilotContext autoPilotContext3 = this.AutoPilotContext;
			if (autoPilotContext3 != null)
			{
				autoPilotContext3.SetAutoPilotNavBtnActive(false);
			}
			WorldMapSecondaryUiAutoPilotContext autoPilotContext4 = this.AutoPilotContext;
			if (autoPilotContext4 == null)
			{
				return;
			}
			autoPilotContext4.RefreshAutoPilotTrackBtnGroup(false);
		}

		// Token: 0x060326D8 RID: 206552 RVA: 0x00C9DD9B File Offset: 0x00C9BF9B
		protected virtual void OnLeftConfirmBtnClick(int index)
		{
		}

		// Token: 0x060326D9 RID: 206553 RVA: 0x00C9DD9D File Offset: 0x00C9BF9D
		protected virtual void OnRightConfirmBtnClick(int index)
		{
		}

		// Token: 0x060326DA RID: 206554 RVA: 0x00C9DD9F File Offset: 0x00C9BF9F
		protected virtual void OnMiddleCenterBtnClick(int index)
		{
		}

		// Token: 0x060326DB RID: 206555 RVA: 0x00C9DDA1 File Offset: 0x00C9BFA1
		protected virtual void OnDelBtnClick()
		{
		}

		// Token: 0x060326DC RID: 206556 RVA: 0x00C9DDA4 File Offset: 0x00C9BFA4
		protected void SetDelBtnActive(bool active)
		{
			base.GetButton(10).RootUIComp.Get().SetUIActive(active);
		}

		// Token: 0x060326DD RID: 206557 RVA: 0x00C9DDCC File Offset: 0x00C9BFCC
		protected void SetDelBtnSelfInteractive(bool interactive)
		{
			base.GetButton(10).SetSelfInteractive(interactive);
		}

		// Token: 0x060326DE RID: 206558 RVA: 0x00C9DDDC File Offset: 0x00C9BFDC
		protected override void OnAfterShowWorldMapSecondaryUi()
		{
			WorldMapSecondaryUiAutoPilotContext autoPilotContext = this.AutoPilotContext;
			if (autoPilotContext == null)
			{
				return;
			}
			autoPilotContext.UpdateAutoPilotState();
		}

		// Token: 0x060326DF RID: 206559 RVA: 0x00C9DDEE File Offset: 0x00C9BFEE
		private void RefreshPanel(MarkItem selectedMarkItem = null)
		{
			this.OnRefreshPanel(selectedMarkItem);
		}

		// Token: 0x060326E0 RID: 206560 RVA: 0x00C9DDF7 File Offset: 0x00C9BFF7
		protected virtual void OnRefreshPanel(MarkItem selectedMarkItem = null)
		{
		}

		// Token: 0x0401D6D3 RID: 120531
		protected ButtonItem LeftConfirmBtn;

		// Token: 0x0401D6D4 RID: 120532
		protected ButtonItem RightConfirmBtn;

		// Token: 0x0401D6D5 RID: 120533
		protected ButtonItem MiddleCenterBtn;

		// Token: 0x0401D6D6 RID: 120534
		protected WorldMapSecondaryUiContext LayoutContext;

		// Token: 0x0401D6D7 RID: 120535
		protected WorldMapSecondaryUiAutoPilotContext AutoPilotContext;

		// Token: 0x0401D6D8 RID: 120536
		protected MapTipsActivateTipPanel MapTipsActivateTipPanel;
	}
}
