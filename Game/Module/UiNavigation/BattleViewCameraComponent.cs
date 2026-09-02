using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CE5 RID: 19685
	[NullableContext(1)]
	[Nullable(0)]
	public class BattleViewCameraComponent : HotKeyComponent
	{
		// Token: 0x060333B3 RID: 209843 RVA: 0x00CD417A File Offset: 0x00CD237A
		public BattleViewCameraComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
			ControllerBase<InputDistributeController>.Instance.BindAction("组合主键", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputCombineButton));
		}

		// Token: 0x060333B4 RID: 209844 RVA: 0x00CD419E File Offset: 0x00CD239E
		protected override void OnClear()
		{
			ControllerBase<InputDistributeController>.Instance.UnBindAction("组合主键", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputCombineButton));
		}

		// Token: 0x060333B5 RID: 209845 RVA: 0x00CD41BB File Offset: 0x00CD23BB
		private void OnInputCombineButton(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification _)
		{
			this.IsMainKeyPress = (actionType == InputDistributeDefine.EActionType.Press);
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, this.IsMainKeyPress, false);
		}

		// Token: 0x060333B6 RID: 209846 RVA: 0x00CD41D5 File Offset: 0x00CD23D5
		protected override void OnRefreshSelfHotKeyState(UiNavigationViewHandle viewHandle)
		{
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, this.IsMainKeyPress, false);
		}

		// Token: 0x060333B7 RID: 209847 RVA: 0x00CD41E5 File Offset: 0x00CD23E5
		protected override bool OnIsOccupancyFightInput()
		{
			return false;
		}

		// Token: 0x0401DC2D RID: 121901
		private bool IsMainKeyPress;
	}
}
