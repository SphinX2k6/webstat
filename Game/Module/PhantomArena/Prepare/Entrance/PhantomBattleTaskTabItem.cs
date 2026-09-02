using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.Entrance
{
	// Token: 0x020054CC RID: 21708
	public class PhantomBattleTaskTabItem : GridProxyAbstract<int>
	{
		// Token: 0x060374BE RID: 226494 RVA: 0x00E0755C File Offset: 0x00E0575C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClicked))
			};
		}

		// Token: 0x060374BF RID: 226495 RVA: 0x00E075DC File Offset: 0x00E057DC
		public override void Refresh(int data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			PhantomBattleTaskTab? taskTabConfigById = ConfigBase<PhantomArenaConfig>.Instance.GetTaskTabConfigById(data);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), taskTabConfigById.Value.Title, Array.Empty<object>());
			this.RefreshRedDot();
		}

		// Token: 0x060374C0 RID: 226496 RVA: 0x00E07628 File Offset: 0x00E05828
		public void RefreshRedDot()
		{
			bool uiactive = ModelBase<PhantomArenaModel>.Instance.CheckTaskRedDotByTab(this.Data, this.ActivityId);
			UUIItem item = base.GetItem(2);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(uiactive);
		}

		// Token: 0x060374C1 RID: 226497 RVA: 0x00E0765E File Offset: 0x00E0585E
		private void OnClicked(EToggleState toggleState)
		{
			if (this.OnClickedCb != null)
			{
				this.OnClickedCb(this.Data);
			}
		}

		// Token: 0x060374C2 RID: 226498 RVA: 0x00E0767C File Offset: 0x00E0587C
		public void SetToggleState(bool bSelect, bool bFire)
		{
			EToggleState state = bSelect ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			base.GetExtendToggle(0).SetToggleState(state, bFire, false, false);
		}

		// Token: 0x0401FC66 RID: 130150
		private int Data;

		// Token: 0x0401FC67 RID: 130151
		public int ActivityId;

		// Token: 0x0401FC68 RID: 130152
		[Nullable(2)]
		public Action<int> OnClickedCb;

		// Token: 0x0200B436 RID: 46134
		private class ETabComponents
		{
			// Token: 0x04037C5B RID: 228443
			public const int Toggle = 0;

			// Token: 0x04037C5C RID: 228444
			public const int Title = 1;

			// Token: 0x04037C5D RID: 228445
			public const int RedDot = 2;
		}
	}
}
