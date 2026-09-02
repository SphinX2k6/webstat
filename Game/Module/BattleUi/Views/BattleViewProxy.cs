using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhoneMessage.View;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FDF RID: 24543
	[NullableContext(2)]
	[Nullable(0)]
	public class BattleViewProxy
	{
		// Token: 0x0603DC6E RID: 253038 RVA: 0x00FBD903 File Offset: 0x00FBBB03
		[NullableContext(1)]
		public void RegisterBattleView(BattleView battleView)
		{
			this.BattleView = battleView;
		}

		// Token: 0x0603DC6F RID: 253039 RVA: 0x00FBD90C File Offset: 0x00FBBB0C
		public UUIItem GetTopPanelPhoneMsgButtonItem()
		{
			return this.BattleView.GetTopPanelPhoneMsgButtonItem();
		}

		// Token: 0x0603DC70 RID: 253040 RVA: 0x00FBD919 File Offset: 0x00FBBB19
		public IPhoneMessageButtonImplement GetTopPanelPhoneMsgButton()
		{
			return this.BattleView.GetTopPanelPhoneMsgButton();
		}

		// Token: 0x04022A67 RID: 141927
		public BattleHeadStatePanel HeadStatePanel;

		// Token: 0x04022A68 RID: 141928
		public BattleView BattleView;
	}
}
