using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Battle.Dialog;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.PhantomArena.Battle.View.Bvb
{
	// Token: 0x020055D8 RID: 21976
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaBattleDetailsViewProxy
	{
		// Token: 0x06038018 RID: 229400 RVA: 0x00E304C5 File Offset: 0x00E2E6C5
		public void RegisterView(PhantomArenaBattleDetailsView view)
		{
			this.View = view;
		}

		// Token: 0x06038019 RID: 229401 RVA: 0x00E304D0 File Offset: 0x00E2E6D0
		public void SetOwnAllSettlePoint(long entityId, int settlePoint)
		{
			this.OwnSettlePointMap[entityId] = settlePoint;
			int num = 0;
			foreach (int num2 in this.OwnSettlePointMap.Values)
			{
				num += num2;
			}
			this.View.SetOwnAllSettlePoint(num);
		}

		// Token: 0x0603801A RID: 229402 RVA: 0x00E30540 File Offset: 0x00E2E740
		public void SetOpponentSettlePoint(long entityId, int settlePoint)
		{
			this.OpponentSettlePointMap[entityId] = settlePoint;
			int num = 0;
			foreach (int num2 in this.OpponentSettlePointMap.Values)
			{
				num += num2;
			}
			this.View.SetOpponentSettlePoint(num);
		}

		// Token: 0x17008FF4 RID: 36852
		// (get) Token: 0x0603801B RID: 229403 RVA: 0x00E305B0 File Offset: 0x00E2E7B0
		public bool IsInGamepadNavigation
		{
			get
			{
				return this.IsInGamepadNavigationInternal;
			}
		}

		// Token: 0x0603801C RID: 229404 RVA: 0x00E305B8 File Offset: 0x00E2E7B8
		public void SetIsInGamepadNavigation(bool isInGamepadNavigation)
		{
			this.IsInGamepadNavigationInternal = isInGamepadNavigation;
			ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
		}

		// Token: 0x04020060 RID: 131168
		private PhantomArenaBattleDetailsView View;

		// Token: 0x04020061 RID: 131169
		private readonly Dictionary<long, int> OwnSettlePointMap = new Dictionary<long, int>();

		// Token: 0x04020062 RID: 131170
		private readonly Dictionary<long, int> OpponentSettlePointMap = new Dictionary<long, int>();

		// Token: 0x04020063 RID: 131171
		public PhantomArenaBattleDialog DialogManager = new PhantomArenaBattleDialog();

		// Token: 0x04020064 RID: 131172
		private bool IsInGamepadNavigationInternal;
	}
}
