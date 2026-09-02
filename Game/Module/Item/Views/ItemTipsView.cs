using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Item.Views
{
	// Token: 0x02005B80 RID: 23424
	[NullableContext(1)]
	[Nullable(0)]
	public class ItemTipsView : UiViewBase
	{
		// Token: 0x0603B367 RID: 242535 RVA: 0x00EFBC86 File Offset: 0x00EF9E86
		public ItemTipsView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603B368 RID: 242536 RVA: 0x00EFBC9C File Offset: 0x00EF9E9C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnClickCloseBtn)),
				new ValueTuple<int, Delegate>(2, new Action(this.OnClickCloseBtn))
			};
		}

		// Token: 0x0603B369 RID: 242537 RVA: 0x00EFBD34 File Offset: 0x00EF9F34
		protected override UniTask OnBeforeStartAsync()
		{
			ItemTipsView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<ItemTipsView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603B36A RID: 242538 RVA: 0x00EFBD78 File Offset: 0x00EF9F78
		private UniTask CreateItemTips(ItemTipsData data)
		{
			ItemTipsView.<CreateItemTips>d__9 <CreateItemTips>d__;
			<CreateItemTips>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateItemTips>d__.<>4__this = this;
			<CreateItemTips>d__.data = data;
			<CreateItemTips>d__.<>1__state = -1;
			<CreateItemTips>d__.<>t__builder.Start<ItemTipsView.<CreateItemTips>d__9>(ref <CreateItemTips>d__);
			return <CreateItemTips>d__.<>t__builder.Task;
		}

		// Token: 0x0603B36B RID: 242539 RVA: 0x00EFBDC4 File Offset: 0x00EF9FC4
		private UniTask CreatePowerTips(ItemTipsData data)
		{
			ItemTipsView.<CreatePowerTips>d__10 <CreatePowerTips>d__;
			<CreatePowerTips>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreatePowerTips>d__.<>4__this = this;
			<CreatePowerTips>d__.data = data;
			<CreatePowerTips>d__.<>1__state = -1;
			<CreatePowerTips>d__.<>t__builder.Start<ItemTipsView.<CreatePowerTips>d__10>(ref <CreatePowerTips>d__);
			return <CreatePowerTips>d__.<>t__builder.Task;
		}

		// Token: 0x0603B36C RID: 242540 RVA: 0x00EFBE10 File Offset: 0x00EFA010
		private UniTask CreateCardTips(ItemTipsData data)
		{
			ItemTipsView.<CreateCardTips>d__11 <CreateCardTips>d__;
			<CreateCardTips>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateCardTips>d__.<>4__this = this;
			<CreateCardTips>d__.data = data;
			<CreateCardTips>d__.<>1__state = -1;
			<CreateCardTips>d__.<>t__builder.Start<ItemTipsView.<CreateCardTips>d__11>(ref <CreateCardTips>d__);
			return <CreateCardTips>d__.<>t__builder.Task;
		}

		// Token: 0x0603B36D RID: 242541 RVA: 0x00EFBE5C File Offset: 0x00EFA05C
		private UniTask CreateHonamiStoryTips(ItemTipsData data)
		{
			ItemTipsView.<CreateHonamiStoryTips>d__12 <CreateHonamiStoryTips>d__;
			<CreateHonamiStoryTips>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateHonamiStoryTips>d__.<>4__this = this;
			<CreateHonamiStoryTips>d__.data = data;
			<CreateHonamiStoryTips>d__.<>1__state = -1;
			<CreateHonamiStoryTips>d__.<>t__builder.Start<ItemTipsView.<CreateHonamiStoryTips>d__12>(ref <CreateHonamiStoryTips>d__);
			return <CreateHonamiStoryTips>d__.<>t__builder.Task;
		}

		// Token: 0x0603B36E RID: 242542 RVA: 0x00EFBEA8 File Offset: 0x00EFA0A8
		private UniTask CreateTitleTips(int titleId)
		{
			ItemTipsView.<CreateTitleTips>d__13 <CreateTitleTips>d__;
			<CreateTitleTips>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateTitleTips>d__.<>4__this = this;
			<CreateTitleTips>d__.titleId = titleId;
			<CreateTitleTips>d__.<>1__state = -1;
			<CreateTitleTips>d__.<>t__builder.Start<ItemTipsView.<CreateTitleTips>d__13>(ref <CreateTitleTips>d__);
			return <CreateTitleTips>d__.<>t__builder.Task;
		}

		// Token: 0x0603B36F RID: 242543 RVA: 0x00EFBEF4 File Offset: 0x00EFA0F4
		private UniTask CreateFurnitureTips(ItemTipsData data)
		{
			ItemTipsView.<CreateFurnitureTips>d__14 <CreateFurnitureTips>d__;
			<CreateFurnitureTips>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateFurnitureTips>d__.<>4__this = this;
			<CreateFurnitureTips>d__.data = data;
			<CreateFurnitureTips>d__.<>1__state = -1;
			<CreateFurnitureTips>d__.<>t__builder.Start<ItemTipsView.<CreateFurnitureTips>d__14>(ref <CreateFurnitureTips>d__);
			return <CreateFurnitureTips>d__.<>t__builder.Task;
		}

		// Token: 0x0603B370 RID: 242544 RVA: 0x00EFBF40 File Offset: 0x00EFA140
		private UniTask CreatePinballItemTips(ItemTipsData data)
		{
			ItemTipsView.<CreatePinballItemTips>d__15 <CreatePinballItemTips>d__;
			<CreatePinballItemTips>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreatePinballItemTips>d__.<>4__this = this;
			<CreatePinballItemTips>d__.data = data;
			<CreatePinballItemTips>d__.<>1__state = -1;
			<CreatePinballItemTips>d__.<>t__builder.Start<ItemTipsView.<CreatePinballItemTips>d__15>(ref <CreatePinballItemTips>d__);
			return <CreatePinballItemTips>d__.<>t__builder.Task;
		}

		// Token: 0x0603B371 RID: 242545 RVA: 0x00EFBF8B File Offset: 0x00EFA18B
		protected override void OnBeforeShow()
		{
			IItemTipsUiProxy tipsProxy = this.TipsProxy;
			if (tipsProxy == null)
			{
				return;
			}
			tipsProxy.SetActive(true);
		}

		// Token: 0x0603B372 RID: 242546 RVA: 0x00EFBF9E File Offset: 0x00EFA19E
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<EUiTabViewName, int?>(EEventName.ChangeChildView, new Action<EUiTabViewName, int?>(this.OnChangeChildView));
		}

		// Token: 0x0603B373 RID: 242547 RVA: 0x00EFBFB9 File Offset: 0x00EFA1B9
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.ChangeChildView, new Action<EUiTabViewName, int?>(this.OnChangeChildView));
		}

		// Token: 0x0603B374 RID: 242548 RVA: 0x00EFBFD4 File Offset: 0x00EFA1D4
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Emit<int, int>(EEventName.CloseItemTips, this.ConfigId, this.IncId);
		}

		// Token: 0x0603B375 RID: 242549 RVA: 0x00EFBFF4 File Offset: 0x00EFA1F4
		protected override UniTask OnPlayingCloseSequenceAsync()
		{
			ItemTipsView.<OnPlayingCloseSequenceAsync>d__20 <OnPlayingCloseSequenceAsync>d__;
			<OnPlayingCloseSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnPlayingCloseSequenceAsync>d__.<>4__this = this;
			<OnPlayingCloseSequenceAsync>d__.<>1__state = -1;
			<OnPlayingCloseSequenceAsync>d__.<>t__builder.Start<ItemTipsView.<OnPlayingCloseSequenceAsync>d__20>(ref <OnPlayingCloseSequenceAsync>d__);
			return <OnPlayingCloseSequenceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603B376 RID: 242550 RVA: 0x00EFC037 File Offset: 0x00EFA237
		private void OnClickCloseBtn()
		{
			UiInteractLogReport.ReportSpaceKeyInteract(EUiInteractSpaceKeyType.ItemTips);
			this.DoCloseMe();
		}

		// Token: 0x0603B377 RID: 242551 RVA: 0x00EFC046 File Offset: 0x00EFA246
		private void OnChangeChildView(EUiTabViewName eUiTabViewName, int? o)
		{
			this.DoCloseMe();
		}

		// Token: 0x0603B378 RID: 242552 RVA: 0x00EFC04E File Offset: 0x00EFA24E
		protected void DoCloseMe()
		{
			base.CloseMe(null);
		}

		// Token: 0x0402161B RID: 136731
		protected int IncId;

		// Token: 0x0402161C RID: 136732
		protected int ConfigId;

		// Token: 0x0402161D RID: 136733
		[Nullable(2)]
		protected object ExtraParam;

		// Token: 0x0402161E RID: 136734
		protected ETipsUiType UiTipsType = ETipsUiType.ItemTipsComponent;

		// Token: 0x0402161F RID: 136735
		[Nullable(2)]
		protected IItemTipsUiProxy TipsProxy;

		// Token: 0x0200BB82 RID: 48002
		[NullableContext(0)]
		private class EItemTipsViewDefine
		{
			// Token: 0x04039D8F RID: 236943
			public const int MaskCloseBtn = 0;

			// Token: 0x04039D90 RID: 236944
			public const int Content = 1;

			// Token: 0x04039D91 RID: 236945
			public const int CloseBtn = 2;
		}
	}
}
