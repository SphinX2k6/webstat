using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Plot;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D41 RID: 19777
	public class PlotInteractComponentBase : HotKeyComponent
	{
		// Token: 0x06033548 RID: 210248 RVA: 0x00CD7DD4 File Offset: 0x00CD5FD4
		public PlotInteractComponentBase(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x06033549 RID: 210249 RVA: 0x00CD7DDD File Offset: 0x00CD5FDD
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.PlotEnableControlView, new Action<bool>(this.PlotEnableControlView));
		}

		// Token: 0x0603354A RID: 210250 RVA: 0x00CD7DFB File Offset: 0x00CD5FFB
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.PlotEnableControlView, new Action<bool>(this.PlotEnableControlView));
		}

		// Token: 0x0603354B RID: 210251 RVA: 0x00CD7E1C File Offset: 0x00CD601C
		[NullableContext(1)]
		protected override void OnRefreshSelfHotKeyState(UiNavigationViewHandle viewHandle)
		{
			string bindButtonTag = base.GetBindButtonTag();
			if (StringUtils.IsEmpty(bindButtonTag))
			{
				return;
			}
			TsUiNavigationBehaviorListener activeListenerByTag = viewHandle.GetActiveListenerByTag(bindButtonTag);
			this.Listener = activeListenerByTag;
			TsUiNavigationBehaviorListener listener = this.Listener;
			bool flag = listener != null && listener.IsListenerActive();
			bool flag2 = ModelBase<PlotModel>.Instance.CanControlView && this.CheckAxisCanInput() && this.CheckCameraMode();
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, flag && flag2, false);
		}

		// Token: 0x0603354C RID: 210252 RVA: 0x00CD7E84 File Offset: 0x00CD6084
		private void PlotEnableControlView(bool isActive)
		{
			bool flag = isActive && this.CheckAxisCanInput() && this.CheckCameraMode();
			TsUiNavigationBehaviorListener listener = this.Listener;
			bool flag2 = listener != null && listener.IsListenerActive();
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, flag2 && flag, false);
		}

		// Token: 0x0603354D RID: 210253 RVA: 0x00CD7EC4 File Offset: 0x00CD60C4
		private bool CheckCameraMode()
		{
			ECustomCameraMode? cameraMode = ModelBase<CameraModel>.Instance.MainModel.CameraMode;
			ECustomCameraMode ecustomCameraMode = ECustomCameraMode.LockOn;
			return cameraMode.GetValueOrDefault() == ecustomCameraMode & cameraMode != null;
		}

		// Token: 0x0603354E RID: 210254 RVA: 0x00CD7EF5 File Offset: 0x00CD60F5
		protected virtual bool CheckAxisCanInput()
		{
			return true;
		}

		// Token: 0x0401DC5A RID: 121946
		protected const float ZOOM_RATE = 30f;

		// Token: 0x0401DC5B RID: 121947
		protected const float MOVE_RATE = 0.7f;

		// Token: 0x0401DC5C RID: 121948
		[Nullable(2)]
		private TsUiNavigationBehaviorListener Listener;
	}
}
