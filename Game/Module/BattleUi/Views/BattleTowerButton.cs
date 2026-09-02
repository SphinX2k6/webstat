using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FC1 RID: 24513
	public class BattleTowerButton : BattleEntranceButton
	{
		// Token: 0x0603DA3D RID: 252477 RVA: 0x00FB4608 File Offset: 0x00FB2808
		protected override void OnRegisterComponent()
		{
			base.OnRegisterComponent();
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(2, typeof(UUINiagara)));
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(3, typeof(UUINiagara)));
		}

		// Token: 0x0603DA3E RID: 252478 RVA: 0x00FB4646 File Offset: 0x00FB2846
		protected void AddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnTowerGuideClose, new Action(this.OnTowerGuideClose));
		}

		// Token: 0x0603DA3F RID: 252479 RVA: 0x00FB4664 File Offset: 0x00FB2864
		protected void RemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnTowerGuideClose, new Action(this.OnTowerGuideClose));
		}

		// Token: 0x0603DA40 RID: 252480 RVA: 0x00FB4682 File Offset: 0x00FB2882
		[NullableContext(2)]
		public override void Initialize(object param = null)
		{
			base.Initialize(param);
			this.AddEvents();
		}

		// Token: 0x0603DA41 RID: 252481 RVA: 0x00FB4691 File Offset: 0x00FB2891
		public override void Reset()
		{
			this.RemoveEvents();
			base.Reset();
		}

		// Token: 0x0603DA42 RID: 252482 RVA: 0x00FB46A0 File Offset: 0x00FB28A0
		private void OnTowerGuideClose()
		{
			UUINiagara uiNiagara = base.GetUiNiagara(2);
			if (uiNiagara != null)
			{
				uiNiagara.SetNiagaraUIActive(false, true);
			}
			UUINiagara uiNiagara2 = base.GetUiNiagara(3);
			if (uiNiagara2 != null)
			{
				uiNiagara2.SetNiagaraUIActive(false, true);
			}
			TimerSystem.Instance.Next(delegate(float _)
			{
				UUINiagara uiNiagara3 = base.GetUiNiagara(2);
				if (uiNiagara3 != null)
				{
					uiNiagara3.SetNiagaraUIActive(true, true);
				}
				UUINiagara uiNiagara4 = base.GetUiNiagara(3);
				if (uiNiagara4 == null)
				{
					return;
				}
				uiNiagara4.SetNiagaraUIActive(true, true);
			}, null, null);
		}

		// Token: 0x0200C02B RID: 49195
		private enum EChildType
		{
			// Token: 0x0403B28B RID: 242315
			Button,
			// Token: 0x0403B28C RID: 242316
			RedDotItem,
			// Token: 0x0403B28D RID: 242317
			NiagaraItem1,
			// Token: 0x0403B28E RID: 242318
			NiagaraItem2
		}
	}
}
