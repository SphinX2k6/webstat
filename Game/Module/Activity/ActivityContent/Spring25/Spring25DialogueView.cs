using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Spring25
{
	// Token: 0x02006361 RID: 25441
	[NullableContext(1)]
	[Nullable(0)]
	public class Spring25DialogueView : UiViewBase
	{
		// Token: 0x0603FE04 RID: 261636 RVA: 0x010629BB File Offset: 0x01060BBB
		public Spring25DialogueView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603FE05 RID: 261637 RVA: 0x010629C4 File Offset: 0x01060BC4
		protected unsafe override void OnRegisterComponent()
		{
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

		// Token: 0x0603FE06 RID: 261638 RVA: 0x01062A70 File Offset: 0x01060C70
		protected override UniTask OnBeforeStartAsync()
		{
			Spring25DialogueView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<Spring25DialogueView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603FE07 RID: 261639 RVA: 0x01062AB3 File Offset: 0x01060CB3
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.HandleOnActivitySequenceEmitEvent));
		}

		// Token: 0x0603FE08 RID: 261640 RVA: 0x01062AD1 File Offset: 0x01060CD1
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.HandleOnActivitySequenceEmitEvent));
		}

		// Token: 0x0603FE09 RID: 261641 RVA: 0x01062AEF File Offset: 0x01060CEF
		private void HandleConfirmClick(int _)
		{
			ControllerBase<ActivitySpring25Controller>.Instance.HandleConfirmClickInDialogueView();
		}

		// Token: 0x0603FE0A RID: 261642 RVA: 0x01062AFC File Offset: 0x01060CFC
		private void HandleOnActivitySequenceEmitEvent(string passData)
		{
			Spring25DialogueViewData spring25DialogueViewData = this.OpenParam as Spring25DialogueViewData;
			int num;
			if (Spring25Define.Spring25DialogIndex.TryGetValue(passData, out num) && num < spring25DialogueViewData.ChatDataList.Count)
			{
				Spring25DialogueChatData spring25DialogueChatData = spring25DialogueViewData.ChatDataList[num];
				if (spring25DialogueChatData.Position == ESpring25DialogType.Left)
				{
					this.LeftItem.RefreshText(spring25DialogueChatData.ContentTextId);
					this.LeftItem.RefreshAnim(spring25DialogueChatData.SpineAnimName);
					return;
				}
				this.RightItem.RefreshText(spring25DialogueChatData.ContentTextId);
				this.RightItem.RefreshAnim(spring25DialogueChatData.SpineAnimName);
			}
		}

		// Token: 0x04023E6D RID: 147053
		private ButtonItem ConfirmItem;

		// Token: 0x04023E6E RID: 147054
		private RoleItem LeftItem;

		// Token: 0x04023E6F RID: 147055
		private RoleItem RightItem;

		// Token: 0x0200C3C2 RID: 50114
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x0403C4C4 RID: 246980
			public const int ConfirmItem = 0;

			// Token: 0x0403C4C5 RID: 246981
			public const int RoleLeftItem = 1;

			// Token: 0x0403C4C6 RID: 246982
			public const int RoleRightItem = 2;

			// Token: 0x0403C4C7 RID: 246983
			public const int ButtonMaskItem = 3;
		}
	}
}
