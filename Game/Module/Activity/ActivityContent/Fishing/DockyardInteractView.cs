using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x020067B1 RID: 26545
	[NullableContext(1)]
	[Nullable(0)]
	public class DockyardInteractView : UiViewBase
	{
		// Token: 0x06042331 RID: 271153 RVA: 0x010FB73F File Offset: 0x010F993F
		public DockyardInteractView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06042332 RID: 271154 RVA: 0x010FB748 File Offset: 0x010F9948
		protected unsafe override void OnRegisterComponent()
		{
			this.InitViewModel();
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06042333 RID: 271155 RVA: 0x010FB7F9 File Offset: 0x010F99F9
		private void InitViewModel()
		{
			this.Vm = (this.OpenParam as DockyardInteractViewModel);
			this.Vm.RegisterView(this);
		}

		// Token: 0x06042334 RID: 271156 RVA: 0x010FB818 File Offset: 0x010F9A18
		private UniTask InitFishingCurrencyItem()
		{
			DockyardInteractView.<InitFishingCurrencyItem>d__9 <InitFishingCurrencyItem>d__;
			<InitFishingCurrencyItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitFishingCurrencyItem>d__.<>4__this = this;
			<InitFishingCurrencyItem>d__.<>1__state = -1;
			<InitFishingCurrencyItem>d__.<>t__builder.Start<DockyardInteractView.<InitFishingCurrencyItem>d__9>(ref <InitFishingCurrencyItem>d__);
			return <InitFishingCurrencyItem>d__.<>t__builder.Task;
		}

		// Token: 0x06042335 RID: 271157 RVA: 0x010FB85C File Offset: 0x010F9A5C
		private UniTask InitCaption()
		{
			DockyardInteractView.<InitCaption>d__10 <InitCaption>d__;
			<InitCaption>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitCaption>d__.<>4__this = this;
			<InitCaption>d__.<>1__state = -1;
			<InitCaption>d__.<>t__builder.Start<DockyardInteractView.<InitCaption>d__10>(ref <InitCaption>d__);
			return <InitCaption>d__.<>t__builder.Task;
		}

		// Token: 0x06042336 RID: 271158 RVA: 0x010FB8A0 File Offset: 0x010F9AA0
		private UniTask InitInteractPanel()
		{
			DockyardInteractView.<InitInteractPanel>d__11 <InitInteractPanel>d__;
			<InitInteractPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitInteractPanel>d__.<>4__this = this;
			<InitInteractPanel>d__.<>1__state = -1;
			<InitInteractPanel>d__.<>t__builder.Start<DockyardInteractView.<InitInteractPanel>d__11>(ref <InitInteractPanel>d__);
			return <InitInteractPanel>d__.<>t__builder.Task;
		}

		// Token: 0x06042337 RID: 271159 RVA: 0x010FB8E4 File Offset: 0x010F9AE4
		private UniTask InitBackpackPanel()
		{
			DockyardInteractView.<InitBackpackPanel>d__12 <InitBackpackPanel>d__;
			<InitBackpackPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitBackpackPanel>d__.<>4__this = this;
			<InitBackpackPanel>d__.<>1__state = -1;
			<InitBackpackPanel>d__.<>t__builder.Start<DockyardInteractView.<InitBackpackPanel>d__12>(ref <InitBackpackPanel>d__);
			return <InitBackpackPanel>d__.<>t__builder.Task;
		}

		// Token: 0x06042338 RID: 271160 RVA: 0x010FB928 File Offset: 0x010F9B28
		private UniTask InitTipsPanel()
		{
			DockyardInteractView.<InitTipsPanel>d__13 <InitTipsPanel>d__;
			<InitTipsPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitTipsPanel>d__.<>4__this = this;
			<InitTipsPanel>d__.<>1__state = -1;
			<InitTipsPanel>d__.<>t__builder.Start<DockyardInteractView.<InitTipsPanel>d__13>(ref <InitTipsPanel>d__);
			return <InitTipsPanel>d__.<>t__builder.Task;
		}

		// Token: 0x06042339 RID: 271161 RVA: 0x010FB96C File Offset: 0x010F9B6C
		protected override UniTask OnBeforeStartAsync()
		{
			DockyardInteractView.<OnBeforeStartAsync>d__14 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<DockyardInteractView.<OnBeforeStartAsync>d__14>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0604233A RID: 271162 RVA: 0x010FB9AF File Offset: 0x010F9BAF
		protected override void OnBeforeDestroy()
		{
			ControllerBase<GeneralLogicTreeController>.Instance.OpenSystemBoardResultRequest((this.Vm.IsComplete > false) ? 1 : 0, this.Vm.ActionIncId);
		}

		// Token: 0x0604233B RID: 271163 RVA: 0x010FB9D4 File Offset: 0x010F9BD4
		public void ShowTipsPanel(int id)
		{
			DockyardItemBlockOriginalData itemBlockDataByIncId = this.Vm.GetItemBlockDataByIncId(id);
			this.TipsPanel.Refresh(itemBlockDataByIncId);
			this.TipsPanel.SetPanelVisible(true);
		}

		// Token: 0x0604233C RID: 271164 RVA: 0x010FBA06 File Offset: 0x010F9C06
		public void HideTipsPanel()
		{
			this.TipsPanel.SetPanelVisible(false);
		}

		// Token: 0x0604233D RID: 271165 RVA: 0x010FBA14 File Offset: 0x010F9C14
		public void OpenInteractFinishTipsView()
		{
			DockyardInteractFinishTipsViewModel dockyardInteractFinishTipsViewModel = new DockyardInteractFinishTipsViewModel();
			dockyardInteractFinishTipsViewModel.CloseCallback = delegate()
			{
				base.CloseMe(null);
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.DockyardInteractFinishTipsView, dockyardInteractFinishTipsViewModel, null);
		}

		// Token: 0x04024E06 RID: 151046
		private DockyardInteractPanel InteractPanel;

		// Token: 0x04024E07 RID: 151047
		private PopupCaptionItem CaptionItem;

		// Token: 0x04024E08 RID: 151048
		private DockyardBackpackPanel BackpackPanel;

		// Token: 0x04024E09 RID: 151049
		private DockyardTipsPanel TipsPanel;

		// Token: 0x04024E0A RID: 151050
		private DockyardInteractViewModel Vm;

		// Token: 0x0200C7D7 RID: 51159
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403D838 RID: 251960
			public const int CaptionItem = 0;

			// Token: 0x0403D839 RID: 251961
			public const int InteractItem = 1;

			// Token: 0x0403D83A RID: 251962
			public const int BackpackItem = 2;

			// Token: 0x0403D83B RID: 251963
			public const int TipsItem = 3;
		}
	}
}
