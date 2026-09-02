using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.MapRogue;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A18 RID: 18968
	public class ViewHotKeyHandleRoleRootView : ViewHotKeyHandle
	{
		// Token: 0x06031906 RID: 203014 RVA: 0x00C5A451 File Offset: 0x00C58651
		[NullableContext(1)]
		public ViewHotKeyHandleRoleRootView(IOpenAndCloseViewHotKey parameters) : base(parameters)
		{
		}

		// Token: 0x06031907 RID: 203015 RVA: 0x00C5A45A File Offset: 0x00C5865A
		protected override bool SpecialConditionCheck()
		{
			return !ControllerBase<MapRogueController>.Instance.CheckInMapRogueInstance();
		}
	}
}
