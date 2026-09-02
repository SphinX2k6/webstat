using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.WheelTower.View.Season
{
	// Token: 0x02006230 RID: 25136
	public class WheelTowerMedalRuleView : UiViewBase
	{
		// Token: 0x0603F673 RID: 259699 RVA: 0x0103FCA8 File Offset: 0x0103DEA8
		[NullableContext(1)]
		public WheelTowerMedalRuleView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603F674 RID: 259700 RVA: 0x0103FCB4 File Offset: 0x0103DEB4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUILoopScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603F675 RID: 259701 RVA: 0x0103FD60 File Offset: 0x0103DF60
		protected override UniTask OnBeforeStartAsync()
		{
			WheelTowerMedalRuleView.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<WheelTowerMedalRuleView.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603F676 RID: 259702 RVA: 0x0103FDA3 File Offset: 0x0103DFA3
		private void OnCloseBtnClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x04023910 RID: 145680
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x04023911 RID: 145681
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private LoopScrollView<WheelTowerMedalRuleItem, WheelTowerMedalRuleItemData> TargetLoopScroll;
	}
}
