using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.GenericPrompt.GenericPromptSubViews;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.GenericPrompt
{
	// Token: 0x02005CA9 RID: 23721
	[NullableContext(1)]
	[Nullable(0)]
	public class GenericPromptView : UiTickViewBase
	{
		// Token: 0x0603BE00 RID: 245248 RVA: 0x00F2C9EC File Offset: 0x00F2ABEC
		private int Compare(IPromptParamHub prompt1, IPromptParamHub prompt2)
		{
			GenericPromptConfig instance = ConfigBase<GenericPromptConfig>.Instance;
			int priority = instance.GetPriority(prompt1);
			return instance.GetPriority(prompt2) - priority;
		}

		// Token: 0x0603BE01 RID: 245249 RVA: 0x00F2CA0E File Offset: 0x00F2AC0E
		public GenericPromptView(UiViewInfo info) : base(info)
		{
			this.WaitingTipsList = new PriorityQueue<IPromptParamHub>(new Comparison<IPromptParamHub>(this.Compare));
		}

		// Token: 0x0603BE02 RID: 245250 RVA: 0x00F2CA3C File Offset: 0x00F2AC3C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603BE03 RID: 245251 RVA: 0x00F2CAA8 File Offset: 0x00F2ACA8
		protected override UniTask OnBeforeStartAsync()
		{
			GenericPromptView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<GenericPromptView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603BE04 RID: 245252 RVA: 0x00F2CAEB File Offset: 0x00F2ACEB
		protected override void OnTick(float delta)
		{
			this.PromptView.Tick(delta);
		}

		// Token: 0x0603BE05 RID: 245253 RVA: 0x00F2CAF9 File Offset: 0x00F2ACF9
		protected override void OnBeforeDestroy()
		{
			this.PromptView.SetHideCallback(null);
			this.WaitingTipsList.Clear();
			this.CanCancelPromptMap.Clear();
		}

		// Token: 0x0603BE06 RID: 245254 RVA: 0x00F2CB20 File Offset: 0x00F2AD20
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<IPromptParamHub>(EEventName.InsertFloatTips, new Action<IPromptParamHub>(this.InsertFloatTips));
			Singleton<EventSystem>.Instance.Add<string>(EEventName.RemoveFloatTips, new Action<string>(this.RemoveFloatTips));
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.OnPreparePhotoScreenShot, new Action<bool>(this.OnPreparePhotoScreenShot));
		}

		// Token: 0x0603BE07 RID: 245255 RVA: 0x00F2CB84 File Offset: 0x00F2AD84
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove<IPromptParamHub>(EEventName.InsertFloatTips, new Action<IPromptParamHub>(this.InsertFloatTips));
			Singleton<EventSystem>.Instance.Remove<string>(EEventName.RemoveFloatTips, new Action<string>(this.RemoveFloatTips));
			Singleton<EventSystem>.Instance.Remove<bool>(EEventName.OnPreparePhotoScreenShot, new Action<bool>(this.OnPreparePhotoScreenShot));
		}

		// Token: 0x0603BE08 RID: 245256 RVA: 0x00F2CBE5 File Offset: 0x00F2ADE5
		private void InsertFloatTips(IPromptParamHub promptParamHub)
		{
			if (!string.IsNullOrEmpty(promptParamHub.PromptKey))
			{
				this.CanCancelPromptMap[promptParamHub.PromptKey] = promptParamHub;
			}
			this.WaitingTipsList.Push(promptParamHub);
			this.InvokeShow();
		}

		// Token: 0x0603BE09 RID: 245257 RVA: 0x00F2CC18 File Offset: 0x00F2AE18
		private void RemoveFloatTips(string promptKey)
		{
			IPromptParamHub item;
			if (this.CanCancelPromptMap.TryGetValue(promptKey, out item))
			{
				this.WaitingTipsList.Remove(item);
				this.CanCancelPromptMap.Remove(promptKey);
				return;
			}
			PromptForFloatLineView promptView = this.PromptView;
			string value;
			if (promptView == null)
			{
				value = null;
			}
			else
			{
				IPromptParamHub paramHub = promptView.ParamHub;
				value = ((paramHub != null) ? paramHub.PromptKey : null);
			}
			if (!string.IsNullOrEmpty(value) && this.PromptView.ParamHub.PromptKey == promptKey)
			{
				this.PromptView.HideView();
			}
		}

		// Token: 0x0603BE0A RID: 245258 RVA: 0x00F2CC98 File Offset: 0x00F2AE98
		private void SetVerticalOffset()
		{
			GenericPromptTypes? promptTypeInfo = ConfigBase<GenericPromptConfig>.Instance.GetPromptTypeInfo(9);
			if (promptTypeInfo.Value.OffsetY == 0f)
			{
				return;
			}
			UUIItem item = base.GetItem(0);
			item.SetAnchorOffsetY(item.GetAnchorOffsetY() + promptTypeInfo.Value.OffsetY);
		}

		// Token: 0x0603BE0B RID: 245259 RVA: 0x00F2CCEC File Offset: 0x00F2AEEC
		private void HidePromptViewCallback(PromptForFloatLineView promptView)
		{
			if (this.WaitingTipsList.Empty)
			{
				return;
			}
			Singleton<Log>.Instance.Info(ELogModule.GenericPrompt, ELogAuthor.XXJ, "获取下一个显示数据", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.InvokeShow();
		}

		// Token: 0x0603BE0C RID: 245260 RVA: 0x00F2CD29 File Offset: 0x00F2AF29
		private void ShowByType(IPromptParamHub promptParamHub)
		{
			this.PromptView.SetPromptHub(promptParamHub);
			this.PromptView.ShowView();
		}

		// Token: 0x0603BE0D RID: 245261 RVA: 0x00F2CD44 File Offset: 0x00F2AF44
		private void InvokeShow()
		{
			IPromptParamHub promptParamHub = this.WaitingTipsList.Pop();
			if (!string.IsNullOrEmpty(promptParamHub.PromptKey))
			{
				this.CanCancelPromptMap.Remove(promptParamHub.PromptKey);
			}
			this.ShowByType(promptParamHub);
		}

		// Token: 0x0603BE0E RID: 245262 RVA: 0x00F2CD84 File Offset: 0x00F2AF84
		private void OnPreparePhotoScreenShot(bool _)
		{
			PromptForFloatLineView promptView = this.PromptView;
			if (promptView != null)
			{
				UUIItem rootItem = promptView.GetRootItem();
				if (rootItem != null)
				{
					rootItem.SetUIActive(false);
				}
			}
			PromptForFloatLineView promptView2 = this.PromptView;
			if (promptView2 != null && promptView2.IsShowOrShowing)
			{
				PromptForFloatLineView promptView3 = this.PromptView;
				if (promptView3 == null)
				{
					return;
				}
				promptView3.SetActive(false);
			}
		}

		// Token: 0x04021AA4 RID: 137892
		public Dictionary<string, IPromptParamHub> CanCancelPromptMap = new Dictionary<string, IPromptParamHub>();

		// Token: 0x04021AA5 RID: 137893
		private readonly PriorityQueue<IPromptParamHub> WaitingTipsList;

		// Token: 0x04021AA6 RID: 137894
		[Nullable(2)]
		private PromptForFloatLineView PromptView;

		// Token: 0x0200BD3E RID: 48446
		[NullableContext(0)]
		private class ECompDefine
		{
			// Token: 0x0403A512 RID: 238866
			public const int FloatTipsParentItem = 0;

			// Token: 0x0403A513 RID: 238867
			public const int FloatTipsItem = 1;
		}
	}
}
