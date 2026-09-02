using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Ui.HotFix;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Launcher.Ui.SdkView
{
	// Token: 0x020044FA RID: 17658
	[NullableContext(2)]
	[Nullable(0)]
	public class SdkProtocolView : LaunchComponentsAction
	{
		// Token: 0x0602E8B2 RID: 190642 RVA: 0x00B07100 File Offset: 0x00B05300
		[NullableContext(1)]
		public void SetViewData(SdkProtocolViewData data)
		{
			this.ViewData = data;
		}

		// Token: 0x0602E8B3 RID: 190643 RVA: 0x00B0710C File Offset: 0x00B0530C
		[NullableContext(1)]
		public UniTask Init(UObject worldContext, [Nullable(2)] USceneComponent root)
		{
			SdkProtocolView.<Init>d__14 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.worldContext = worldContext;
			<Init>d__.root = root;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<SdkProtocolView.<Init>d__14>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x0602E8B4 RID: 190644 RVA: 0x00B0715F File Offset: 0x00B0535F
		[NullableContext(1)]
		private void OnViewLoadCallback(AActor actor)
		{
			base.SetRootActorLaunchComponentsAction(actor);
		}

		// Token: 0x0602E8B5 RID: 190645 RVA: 0x00B07168 File Offset: 0x00B05368
		protected override void OnStart()
		{
			this.DescText = base.GetText(3);
			this.TitleText = base.GetText(5);
			this.EnterButton = base.GetButton(0);
			this.CancelButton = base.GetButton(1);
			UUIButtonComponent enterButton = this.EnterButton;
			if (enterButton != null)
			{
				enterButton.OnClickCallBack.Bind(new Action(this.OnClickEnterButton));
			}
			UUIButtonComponent cancelButton = this.CancelButton;
			if (cancelButton != null)
			{
				cancelButton.OnClickCallBack.Bind(new Action(this.OnClickCancelButton));
			}
			this.ButtonL1 = base.GetButton(2);
			this.ButtonR1 = base.GetButton(6);
			this.ButtonTriangle = base.GetButton(7);
			this.ButtonL2 = base.GetButton(8);
			this.ButtonR2 = base.GetButton(9);
			this.LayoutButtonList.Add(this.ButtonL1);
			this.LayoutButtonList.Add(this.ButtonR1);
			this.LayoutButtonList.Add(this.ButtonTriangle);
			this.LayoutButtonList.Add(this.ButtonL2);
			this.LayoutButtonList.Add(this.ButtonR2);
			for (int i = 0; i < this.LayoutButtonList.Count; i++)
			{
				this.LayoutButtonList[i].RootUIComp.Get().SetUIActive(false);
			}
			HotFixManager.SetLocalText(base.GetText(10), "SdkProtocolRefuse", Array.Empty<string>());
			HotFixManager.SetLocalText(base.GetText(11), "SdkProtocolConfirm", Array.Empty<string>());
			this.RefreshView();
		}

		// Token: 0x0602E8B6 RID: 190646 RVA: 0x00B072ED File Offset: 0x00B054ED
		public void RefreshView()
		{
			this.RefreshDesc();
			this.RefreshTitle();
			this.RefreshLayout();
		}

		// Token: 0x0602E8B7 RID: 190647 RVA: 0x00B07301 File Offset: 0x00B05501
		private void OnClickEnterButton()
		{
			SdkProtocolViewData viewData = this.ViewData;
			if (viewData == null)
			{
				return;
			}
			Action enterCallback = viewData.EnterCallback;
			if (enterCallback == null)
			{
				return;
			}
			enterCallback();
		}

		// Token: 0x0602E8B8 RID: 190648 RVA: 0x00B0731D File Offset: 0x00B0551D
		private void OnClickCancelButton()
		{
			SdkProtocolViewData viewData = this.ViewData;
			if (viewData == null)
			{
				return;
			}
			Action cancelCallback = viewData.CancelCallback;
			if (cancelCallback == null)
			{
				return;
			}
			cancelCallback();
		}

		// Token: 0x0602E8B9 RID: 190649 RVA: 0x00B0733C File Offset: 0x00B0553C
		private void RefreshLayout()
		{
			SdkProtocolViewData viewData = this.ViewData;
			if (((viewData != null) ? viewData.LayoutData : null) != null)
			{
				int count = this.ViewData.LayoutData.Count;
				for (int i = 0; i < count; i++)
				{
					ProtocolItem protocolItem = new ProtocolItem(this);
					protocolItem.SetActor(this.LayoutButtonList[i].RootUIComp.Get().GetOwner());
					protocolItem.SetActive(true);
					protocolItem.Refresh(this.ViewData.LayoutData[i]);
					this.CurrentCopyProtocolArray.Add(protocolItem);
				}
			}
		}

		// Token: 0x0602E8BA RID: 190650 RVA: 0x00B073CF File Offset: 0x00B055CF
		private void RefreshTitle()
		{
			if (this.ViewData != null && this.TitleText != null)
			{
				HotFixManager.SetLocalText(this.TitleText, this.ViewData.TitleId, Array.Empty<string>());
			}
		}

		// Token: 0x0602E8BB RID: 190651 RVA: 0x00B073FC File Offset: 0x00B055FC
		private void RefreshDesc()
		{
			if (this.ViewData != null && this.DescText != null)
			{
				HotFixManager.SetLocalText(this.DescText, this.ViewData.DescTextId, Array.Empty<string>());
			}
		}

		// Token: 0x0602E8BC RID: 190652 RVA: 0x00B07429 File Offset: 0x00B05629
		protected override void OnBeforeDestroy()
		{
			this.CurrentCopyProtocolArray.Clear();
		}

		// Token: 0x0401A70C RID: 108300
		private SdkProtocolViewData ViewData;

		// Token: 0x0401A70D RID: 108301
		private UUIText DescText;

		// Token: 0x0401A70E RID: 108302
		private UUIText TitleText;

		// Token: 0x0401A70F RID: 108303
		private UUIButtonComponent EnterButton;

		// Token: 0x0401A710 RID: 108304
		private UUIButtonComponent CancelButton;

		// Token: 0x0401A711 RID: 108305
		private UUIButtonComponent ButtonL1;

		// Token: 0x0401A712 RID: 108306
		private UUIButtonComponent ButtonR1;

		// Token: 0x0401A713 RID: 108307
		private UUIButtonComponent ButtonTriangle;

		// Token: 0x0401A714 RID: 108308
		private UUIButtonComponent ButtonL2;

		// Token: 0x0401A715 RID: 108309
		private UUIButtonComponent ButtonR2;

		// Token: 0x0401A716 RID: 108310
		[Nullable(1)]
		private readonly List<UUIButtonComponent> LayoutButtonList = new List<UUIButtonComponent>();

		// Token: 0x0401A717 RID: 108311
		[Nullable(1)]
		private readonly List<ProtocolItem> CurrentCopyProtocolArray = new List<ProtocolItem>();

		// Token: 0x0200A70F RID: 42767
		[NullableContext(0)]
		private static class EComponents
		{
			// Token: 0x04033D87 RID: 212359
			public const int EnterButton = 0;

			// Token: 0x04033D88 RID: 212360
			public const int CancelButton = 1;

			// Token: 0x04033D89 RID: 212361
			public const int ButtonL1 = 2;

			// Token: 0x04033D8A RID: 212362
			public const int DescText = 3;

			// Token: 0x04033D8B RID: 212363
			public const int VerticalLayout = 4;

			// Token: 0x04033D8C RID: 212364
			public const int TitleText = 5;

			// Token: 0x04033D8D RID: 212365
			public const int ButtonR1 = 6;

			// Token: 0x04033D8E RID: 212366
			public const int ButtonTriangle = 7;

			// Token: 0x04033D8F RID: 212367
			public const int ButtonL2 = 8;

			// Token: 0x04033D90 RID: 212368
			public const int ButtonR2 = 9;

			// Token: 0x04033D91 RID: 212369
			public const int LeftButtonText = 10;

			// Token: 0x04033D92 RID: 212370
			public const int RightButtonText = 11;
		}
	}
}
