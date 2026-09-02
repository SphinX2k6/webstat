using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Module.Activity.ActivityContent.Fishing;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006008 RID: 24584
	public class FishingButton : UiPanelBase
	{
		// Token: 0x0603DED4 RID: 253652 RVA: 0x00FCC0B4 File Offset: 0x00FCA2B4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			if (!Singleton<Info>.Instance.IsInTouch())
			{
				this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(2, typeof(UUIItem)));
			}
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickedButton));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603DED5 RID: 253653 RVA: 0x00FCC184 File Offset: 0x00FCA384
		protected override UniTask OnBeforeStartAsync()
		{
			FishingButton.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<FishingButton.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603DED6 RID: 253654 RVA: 0x00FCC1C7 File Offset: 0x00FCA3C7
		protected override void OnBeforeShow()
		{
			if (this.ActionName == "切换角色3")
			{
				ModelBase<FishingModel>.Instance.RefreshTechCanLevelUp();
			}
		}

		// Token: 0x0603DED7 RID: 253655 RVA: 0x00FCC1E5 File Offset: 0x00FCA3E5
		private void OnClickedButton()
		{
			ControllerBase<FishingController>.Instance.FishingInputHandler(this.ActionName);
		}

		// Token: 0x0603DED8 RID: 253656 RVA: 0x00FCC1F7 File Offset: 0x00FCA3F7
		protected override void OnBeforeDestroy()
		{
			if (this.ActionName == "切换角色3")
			{
				ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.FishingTech, base.GetItem(1), 0);
			}
		}

		// Token: 0x04022BC9 RID: 142281
		[Nullable(2)]
		private InputMultiKeyItem KeyItem;

		// Token: 0x04022BCA RID: 142282
		[Nullable(1)]
		private string ActionName = string.Empty;

		// Token: 0x0200C09F RID: 49311
		private enum EChildType
		{
			// Token: 0x0403B4E3 RID: 242915
			Button,
			// Token: 0x0403B4E4 RID: 242916
			RedDotItem,
			// Token: 0x0403B4E5 RID: 242917
			KeyItem
		}
	}
}
