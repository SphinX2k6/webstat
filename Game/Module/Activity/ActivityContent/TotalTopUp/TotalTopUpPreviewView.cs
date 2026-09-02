using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.TotalTopUp
{
	// Token: 0x02006289 RID: 25225
	[NullableContext(2)]
	[Nullable(0)]
	public class TotalTopUpPreviewView : UiViewBase
	{
		// Token: 0x0603F80F RID: 260111 RVA: 0x010481EF File Offset: 0x010463EF
		[NullableContext(1)]
		public TotalTopUpPreviewView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603F810 RID: 260112 RVA: 0x010481F8 File Offset: 0x010463F8
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem))
			};
		}

		// Token: 0x0603F811 RID: 260113 RVA: 0x01048234 File Offset: 0x01046434
		protected override UniTask OnBeforeStartAsync()
		{
			TotalTopUpPreviewView.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TotalTopUpPreviewView.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603F812 RID: 260114 RVA: 0x01048277 File Offset: 0x01046477
		private void OnClickedCloseButton()
		{
			base.CloseMe(null);
		}

		// Token: 0x04023A61 RID: 146017
		private PopupCaptionItem CaptionItem;

		// Token: 0x04023A62 RID: 146018
		private TotalTopUpPreviewSubView SubView;
	}
}
