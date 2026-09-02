using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D47 RID: 19783
	[NullableContext(1)]
	[Nullable(0)]
	public class RewardTakeComponent : HotKeyComponent
	{
		// Token: 0x06033562 RID: 210274 RVA: 0x00CD8077 File Offset: 0x00CD6277
		public RewardTakeComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x06033563 RID: 210275 RVA: 0x00CD8080 File Offset: 0x00CD6280
		public void SetDataCallback(RewardTakeDataCallback callback)
		{
			this.LastNotTakenFunc = callback;
		}

		// Token: 0x06033564 RID: 210276 RVA: 0x00CD808C File Offset: 0x00CD628C
		protected override void OnPress(HotKeyMap config)
		{
			if (this.Listener != null)
			{
				UUIItem uiItem = this.Listener.GetBehaviorComponent().RootUIComp.Get();
				ControllerBase<UiNavigationNewController>.Instance.SimulateClickItem(uiItem, null);
			}
		}

		// Token: 0x06033565 RID: 210277 RVA: 0x00CD80D0 File Offset: 0x00CD62D0
		protected override void OnRefreshSelfHotKeyState(UiNavigationViewHandle viewHandle)
		{
			string bindButtonTag = base.GetBindButtonTag();
			if (string.IsNullOrEmpty(bindButtonTag))
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			int num = (this.LastNotTakenFunc != null) ? this.LastNotTakenFunc() : 0;
			if (num <= 0)
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			if (this.IndexReward <= 0)
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				List<TsUiNavigationBehaviorListener> activeListenerListByTag = viewHandle.GetActiveListenerListByTag(bindButtonTag);
				if (activeListenerListByTag.Count <= 0)
				{
					return;
				}
				for (int i = 0; i < activeListenerListByTag.Count; i++)
				{
					TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = activeListenerListByTag[i];
					AActor owner = tsUiNavigationBehaviorListener.GetOwner();
					if (base.IsLinkListener(owner))
					{
						this.IndexReward = i + 1;
						this.Listener = tsUiNavigationBehaviorListener;
						break;
					}
				}
			}
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, this.IndexReward == num, false);
		}

		// Token: 0x06033566 RID: 210278 RVA: 0x00CD8190 File Offset: 0x00CD6390
		protected override void OnClear()
		{
			base.OnClear();
			this.LastNotTakenFunc = null;
			this.IndexReward = 0;
			this.Listener = null;
		}

		// Token: 0x0401DC5E RID: 121950
		private int IndexReward;

		// Token: 0x0401DC5F RID: 121951
		[Nullable(2)]
		private TsUiNavigationBehaviorListener Listener;

		// Token: 0x0401DC60 RID: 121952
		[Nullable(2)]
		private RewardTakeDataCallback LastNotTakenFunc;
	}
}
