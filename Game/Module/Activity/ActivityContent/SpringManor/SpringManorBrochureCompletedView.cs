using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SpringManor
{
	// Token: 0x02006348 RID: 25416
	public class SpringManorBrochureCompletedView : UiViewBase
	{
		// Token: 0x0603FD3E RID: 261438 RVA: 0x0105F0CA File Offset: 0x0105D2CA
		[NullableContext(1)]
		public SpringManorBrochureCompletedView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603FD3F RID: 261439 RVA: 0x0105F0D4 File Offset: 0x0105D2D4
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUITexture)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(5, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(4, new Action(this.OnClickBtnConfirmL)),
				new ValueTuple<int, Delegate>(5, new Action(this.OnClickBtnConfirmR))
			};
		}

		// Token: 0x0603FD40 RID: 261440 RVA: 0x0105F1AB File Offset: 0x0105D3AB
		protected override void OnStart()
		{
			this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
			this.CaptionItem.SetCloseCallBack(delegate
			{
				base.CloseMe(null);
			});
		}

		// Token: 0x0603FD41 RID: 261441 RVA: 0x0105F1D8 File Offset: 0x0105D3D8
		protected override void OnBeforeShow()
		{
			SpringManorBrochureCompletedViewOpenParam springManorBrochureCompletedViewOpenParam = this.OpenParam as SpringManorBrochureCompletedViewOpenParam;
			this.ConfigId = springManorBrochureCompletedViewOpenParam.ConfigId;
			this.SetDetailInfo();
		}

		// Token: 0x0603FD42 RID: 261442 RVA: 0x0105F204 File Offset: 0x0105D404
		private void SetDetailInfo()
		{
			SpringManorConfig instance = ConfigBase<SpringManorConfig>.Instance;
			BookItem? bookItem = (instance != null) ? instance.GetSpringManorBookItemById(this.ConfigId) : null;
			if (bookItem == null)
			{
				return;
			}
			UUIText text = base.GetText(1);
			if (text != null)
			{
				text.ShowTextNew(bookItem.Value.DescriptionTitle);
			}
			UUIText text2 = base.GetText(3);
			if (text2 != null)
			{
				text2.ShowTextNew(bookItem.Value.DescriptionText);
			}
			this.NextConfigId = 0;
			SpringManorModel instance2 = ModelBase<SpringManorModel>.Instance;
			SpringManorData springManorData = (instance2 != null) ? instance2.ActivityData : null;
			if (springManorData != null)
			{
				this.NextConfigId = springManorData.GetNextLockBookItemId(this.ConfigId);
			}
			UUIButtonComponent button = base.GetButton(5);
			if (button != null)
			{
				UUIItem uuiitem = button.RootUIComp.Get();
				if (uuiitem != null)
				{
					uuiitem.SetUIActive(this.NextConfigId > 0);
				}
			}
			base.SetTextureByPath(bookItem.Value.ScreenIconDonePath, base.GetTexture(2), null, null);
			PopupCaptionItem captionItem = this.CaptionItem;
			if (captionItem == null)
			{
				return;
			}
			captionItem.SetTitle(bookItem.Value.DescriptionTitle);
		}

		// Token: 0x0603FD43 RID: 261443 RVA: 0x0105F320 File Offset: 0x0105D520
		private void OnClickBtnConfirmR()
		{
			if (this.NextConfigId <= 0)
			{
				return;
			}
			SpringManorConfig instance = ConfigBase<SpringManorConfig>.Instance;
			BookItem? bookItem = (instance != null) ? instance.GetSpringManorBookItemById(this.NextConfigId) : null;
			if (bookItem == null)
			{
				return;
			}
			if (bookItem.Value.TeleportEntityId > 0)
			{
				this.TeleportPlayerToEntity(this.NextConfigId).Forget();
			}
		}

		// Token: 0x0603FD44 RID: 261444 RVA: 0x0105F384 File Offset: 0x0105D584
		private UniTask TeleportPlayerToEntity(int configId)
		{
			SpringManorBrochureCompletedView.<TeleportPlayerToEntity>d__9 <TeleportPlayerToEntity>d__;
			<TeleportPlayerToEntity>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<TeleportPlayerToEntity>d__.configId = configId;
			<TeleportPlayerToEntity>d__.<>1__state = -1;
			<TeleportPlayerToEntity>d__.<>t__builder.Start<SpringManorBrochureCompletedView.<TeleportPlayerToEntity>d__9>(ref <TeleportPlayerToEntity>d__);
			return <TeleportPlayerToEntity>d__.<>t__builder.Task;
		}

		// Token: 0x0603FD45 RID: 261445 RVA: 0x0105F3C7 File Offset: 0x0105D5C7
		private void OnClickBtnConfirmL()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.SpringManorBrochureView, null, null);
			base.CloseMe(null);
		}

		// Token: 0x04023DDA RID: 146906
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x04023DDB RID: 146907
		private int ConfigId;

		// Token: 0x04023DDC RID: 146908
		private int NextConfigId;
	}
}
