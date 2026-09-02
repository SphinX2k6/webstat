using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CEF RID: 19695
	public class DraggableComponent : HotKeyComponent
	{
		// Token: 0x060333DD RID: 209885 RVA: 0x00CD4826 File Offset: 0x00CD2A26
		public DraggableComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060333DE RID: 209886 RVA: 0x00CD4841 File Offset: 0x00CD2A41
		protected override void OnPress(HotKeyMap config)
		{
			this.RemoveTickHandle();
			this.AddTickHandle();
		}

		// Token: 0x060333DF RID: 209887 RVA: 0x00CD484F File Offset: 0x00CD2A4F
		protected override void OnRelease(HotKeyMap config)
		{
			this.RemoveTickHandle();
		}

		// Token: 0x060333E0 RID: 209888 RVA: 0x00CD4857 File Offset: 0x00CD2A57
		private void AddTickHandle()
		{
			this.TickTime = 20f;
			this.TickHandle = Singleton<TickSystem>.Instance.Add(new Action<float>(this.OnTick), "NavigationDraggableComponent", ETickingGroup.TG_PrePhysics, true, 0, true).Id;
		}

		// Token: 0x060333E1 RID: 209889 RVA: 0x00CD488E File Offset: 0x00CD2A8E
		private void RemoveTickHandle()
		{
			if (this.TickHandle != -1)
			{
				Singleton<TickSystem>.Instance.Remove(this.TickHandle);
				this.TickHandle = -1;
			}
		}

		// Token: 0x060333E2 RID: 209890 RVA: 0x00CD48B4 File Offset: 0x00CD2AB4
		[NullableContext(1)]
		protected override void OnRefreshSelfHotKeyState(UiNavigationViewHandle viewHandle)
		{
			string bindButtonTag = base.GetBindButtonTag();
			if (StringUtils.IsEmpty(bindButtonTag))
			{
				return;
			}
			TsUiNavigationBehaviorListener activeListenerByTag = viewHandle.GetActiveListenerByTag(bindButtonTag);
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, activeListenerByTag != null && activeListenerByTag.IsListenerActive(), false);
		}

		// Token: 0x060333E3 RID: 209891 RVA: 0x00CD48ED File Offset: 0x00CD2AED
		private void OnTick(float deltaTime)
		{
			this.TickTime += deltaTime;
			if (this.TickTime > 20f)
			{
				this.TickTime -= 20f;
				this.TriggerEvent();
			}
		}

		// Token: 0x060333E4 RID: 209892 RVA: 0x00CD4922 File Offset: 0x00CD2B22
		protected virtual void TriggerEvent()
		{
		}

		// Token: 0x060333E5 RID: 209893 RVA: 0x00CD4924 File Offset: 0x00CD2B24
		protected override void OnUnRegisterMe()
		{
			this.RemoveTickHandle();
		}

		// Token: 0x0401DC30 RID: 121904
		private const float TRIGGER_TIME = 20f;

		// Token: 0x0401DC31 RID: 121905
		private int TickHandle = -1;

		// Token: 0x0401DC32 RID: 121906
		private float TickTime = 20f;
	}
}
