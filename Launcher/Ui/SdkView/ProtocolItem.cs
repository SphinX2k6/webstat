using System;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Ui.HotFix;
using UnrealEngine;

namespace CSharpScript.Launcher.Ui.SdkView
{
	// Token: 0x020044FB RID: 17659
	[NullableContext(1)]
	[Nullable(0)]
	internal class ProtocolItem : LaunchComponentsAction
	{
		// Token: 0x17008041 RID: 32833
		// (get) Token: 0x0602E8BE RID: 190654 RVA: 0x00B07454 File Offset: 0x00B05654
		public SdkProtocolView Owner { get; }

		// Token: 0x0602E8BF RID: 190655 RVA: 0x00B0745C File Offset: 0x00B0565C
		public ProtocolItem(SdkProtocolView owner)
		{
			this.Owner = owner;
		}

		// Token: 0x0602E8C0 RID: 190656 RVA: 0x00B0746B File Offset: 0x00B0566B
		public void SetActor(AActor actor)
		{
			base.SetRootActorLaunchComponentsAction(actor);
		}

		// Token: 0x0602E8C1 RID: 190657 RVA: 0x00B07474 File Offset: 0x00B05674
		protected override void OnStart()
		{
			this.ClickButton = base.GetButton(0);
			UUIButtonComponent clickButton = this.ClickButton;
			if (clickButton != null)
			{
				clickButton.OnClickCallBack.Bind(new Action(this.OnClickButton));
			}
			this.DescText = base.GetText(1);
		}

		// Token: 0x0602E8C2 RID: 190658 RVA: 0x00B074B2 File Offset: 0x00B056B2
		private void OnClickButton()
		{
			SdkProtocolViewLayoutData data = this.Data;
			if (data == null)
			{
				return;
			}
			Action<SdkProtocolView> clickCallBack = data.ClickCallBack;
			if (clickCallBack == null)
			{
				return;
			}
			clickCallBack(this.Owner);
		}

		// Token: 0x0602E8C3 RID: 190659 RVA: 0x00B074D4 File Offset: 0x00B056D4
		public void Refresh(SdkProtocolViewLayoutData data)
		{
			this.Data = data;
			HotFixManager.SetLocalText(this.DescText, data.TextId, Array.Empty<string>());
		}

		// Token: 0x0401A719 RID: 108313
		[Nullable(2)]
		public SdkProtocolViewLayoutData Data;

		// Token: 0x0401A71A RID: 108314
		[Nullable(2)]
		private UUIButtonComponent ClickButton;

		// Token: 0x0401A71B RID: 108315
		[Nullable(2)]
		private UUIText DescText;

		// Token: 0x0200A711 RID: 42769
		[NullableContext(0)]
		private static class EProtocolItemComponents
		{
			// Token: 0x04033D99 RID: 212377
			public const int ClickButton = 0;

			// Token: 0x04033D9A RID: 212378
			public const int DescText = 1;
		}
	}
}
