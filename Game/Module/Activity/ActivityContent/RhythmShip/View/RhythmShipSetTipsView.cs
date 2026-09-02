using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip.View
{
	// Token: 0x02006512 RID: 25874
	public class RhythmShipSetTipsView : UiViewBase
	{
		// Token: 0x06040BA8 RID: 265128 RVA: 0x010992B9 File Offset: 0x010974B9
		[NullableContext(1)]
		public RhythmShipSetTipsView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06040BA9 RID: 265129 RVA: 0x010992C2 File Offset: 0x010974C2
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent))
			};
		}

		// Token: 0x06040BAA RID: 265130 RVA: 0x010992FC File Offset: 0x010974FC
		protected override UniTask OnBeforeStartAsync()
		{
			RhythmShipSetTipsView.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RhythmShipSetTipsView.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040BAB RID: 265131 RVA: 0x01099340 File Offset: 0x01097540
		protected override void OnStart()
		{
			List<int> rhythmShipActionAll = ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipActionAll();
			GenericScrollViewNew<KeyItem, int> scrollView = this.ScrollView;
			if (scrollView == null)
			{
				return;
			}
			scrollView.RefreshByData(rhythmShipActionAll, null, false);
		}

		// Token: 0x040244A8 RID: 148648
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x040244A9 RID: 148649
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericScrollViewNew<KeyItem, int> ScrollView;
	}
}
