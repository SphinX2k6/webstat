using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Views
{
	// Token: 0x020068FA RID: 26874
	public class DropCatchGameplayDropItemFxView : DropCatchGameplayPoolPanelBase
	{
		// Token: 0x06042C5D RID: 273501 RVA: 0x01122D60 File Offset: 0x01120F60
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUINiagara)),
				new ValueTuple<int, Type>(1, typeof(UUINiagara)),
				new ValueTuple<int, Type>(2, typeof(UUINiagara)),
				new ValueTuple<int, Type>(3, typeof(UUINiagara))
			};
		}

		// Token: 0x06042C5E RID: 273502 RVA: 0x01122DD0 File Offset: 0x01120FD0
		protected override void OnBeforeShow()
		{
			this.ClearTimer();
			UUINiagara uiNiagara = base.GetUiNiagara(0);
			if (uiNiagara != null)
			{
				uiNiagara.SetUIActive(false);
			}
			UUINiagara uiNiagara2 = base.GetUiNiagara(1);
			if (uiNiagara2 != null)
			{
				uiNiagara2.SetUIActive(false);
			}
			UUINiagara uiNiagara3 = base.GetUiNiagara(2);
			if (uiNiagara3 != null)
			{
				uiNiagara3.SetUIActive(false);
			}
			UUINiagara uiNiagara4 = base.GetUiNiagara(3);
			if (uiNiagara4 != null)
			{
				uiNiagara4.SetUIActive(false);
			}
			IDropCatchGameplayDropItemFxViewParams dropCatchGameplayDropItemFxViewParams = this.OpenParam as IDropCatchGameplayDropItemFxViewParams;
			this.InitPos(dropCatchGameplayDropItemFxViewParams.Pos);
			switch (dropCatchGameplayDropItemFxViewParams.Type)
			{
			case EDropCatchDropItemNiagaraType.Nor:
			{
				UUINiagara uiNiagara5 = base.GetUiNiagara(0);
				if (uiNiagara5 != null)
				{
					uiNiagara5.SetUIActive(true);
				}
				break;
			}
			case EDropCatchDropItemNiagaraType.Mid:
			{
				UUINiagara uiNiagara6 = base.GetUiNiagara(1);
				if (uiNiagara6 != null)
				{
					uiNiagara6.SetUIActive(true);
				}
				break;
			}
			case EDropCatchDropItemNiagaraType.High:
			{
				UUINiagara uiNiagara7 = base.GetUiNiagara(2);
				if (uiNiagara7 != null)
				{
					uiNiagara7.SetUIActive(true);
				}
				break;
			}
			case EDropCatchDropItemNiagaraType.Bad:
			{
				UUINiagara uiNiagara8 = base.GetUiNiagara(3);
				if (uiNiagara8 != null)
				{
					uiNiagara8.SetUIActive(true);
				}
				break;
			}
			}
			this.TimerHandle = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				Action<DropCatchGameplayPoolPanelBase> onRecycle = this.OnRecycle;
				if (onRecycle == null)
				{
					return;
				}
				onRecycle(this);
			}, (float)this.RECYCLE_TIME, null, null, true, 1f);
		}

		// Token: 0x06042C5F RID: 273503 RVA: 0x01122EE3 File Offset: 0x011210E3
		[NullableContext(1)]
		protected void InitPos(Vector2D pos)
		{
			base.GetRootItem().SetAnchorOffset(pos.ToUeVector2D(false));
		}

		// Token: 0x06042C60 RID: 273504 RVA: 0x01122EF7 File Offset: 0x011210F7
		private void ClearTimer()
		{
			if (TimerSystem.GameplayTimeInstance.Has(this.TimerHandle))
			{
				TimerSystem.GameplayTimeInstance.Remove(this.TimerHandle);
			}
			this.TimerHandle = null;
		}

		// Token: 0x06042C61 RID: 273505 RVA: 0x01122F23 File Offset: 0x01121123
		protected override void OnBeforeDestroy()
		{
			this.ClearTimer();
		}

		// Token: 0x04025336 RID: 152374
		private readonly int RECYCLE_TIME = 2000;

		// Token: 0x04025337 RID: 152375
		[Nullable(2)]
		private TimerHandle TimerHandle;
	}
}
