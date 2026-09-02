using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.LevelGamePlay.DollGrabMachine.View
{
	// Token: 0x02006EF5 RID: 28405
	public class DollGrabMachineEndView : UiViewBase
	{
		// Token: 0x06044D79 RID: 281977 RVA: 0x011E9C8A File Offset: 0x011E7E8A
		[NullableContext(1)]
		public DollGrabMachineEndView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06044D7A RID: 281978 RVA: 0x011E9C93 File Offset: 0x011E7E93
		protected override void OnAfterPlayStartSequence()
		{
			base.CloseMe(null);
		}

		// Token: 0x06044D7B RID: 281979 RVA: 0x011E9C9C File Offset: 0x011E7E9C
		protected override void OnBeforeDestroy()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.DollGrabMachineSeltView, null, null);
		}
	}
}
