using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060C8 RID: 24776
	internal class SpecialEnergyBarKeLaiTa : SpecialEnergyBarBase
	{
		// Token: 0x0603E92B RID: 256299 RVA: 0x010020D4 File Offset: 0x010002D4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E92C RID: 256300 RVA: 0x010021C4 File Offset: 0x010003C4
		protected override UniTask OnBeforeStartAsync()
		{
			SpecialEnergyBarKeLaiTa.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SpecialEnergyBarKeLaiTa.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603E92D RID: 256301 RVA: 0x01002208 File Offset: 0x01000408
		protected UniTask InitBarItem()
		{
			SpecialEnergyBarKeLaiTa.<InitBarItem>d__9 <InitBarItem>d__;
			<InitBarItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitBarItem>d__.<>4__this = this;
			<InitBarItem>d__.<>1__state = -1;
			<InitBarItem>d__.<>t__builder.Start<SpecialEnergyBarKeLaiTa.<InitBarItem>d__9>(ref <InitBarItem>d__);
			return <InitBarItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603E92E RID: 256302 RVA: 0x0100224B File Offset: 0x0100044B
		protected override void OnStart()
		{
			base.OnStart();
			base.InitTweenAnim(5);
			this.BarItem.SetCustomEffectBasePercent(0.46341464f);
			this.RefreshBuff();
			this.SetRedState(this.Buff == null, true);
		}

		// Token: 0x0603E92F RID: 256303 RVA: 0x01002280 File Offset: 0x01000480
		protected void RefreshBuff()
		{
			SpecialEnergyBarInfo config = this.Config;
			bool flag;
			if (config == null)
			{
				flag = false;
			}
			else
			{
				long buffId = config.BuffId;
				flag = true;
			}
			if (flag)
			{
				CharacterBuffComponent buffComponent = this.BuffComponent;
				this.Buff = ((buffComponent != null) ? buffComponent.GetBuffById(this.Config.BuffId) : null);
				IActiveBuff buff = this.Buff;
				this.BuffHandle = ((buff != null) ? buff.Handle : 0);
				return;
			}
			this.Buff = null;
			this.BuffHandle = 0;
		}

		// Token: 0x0603E930 RID: 256304 RVA: 0x010022F0 File Offset: 0x010004F0
		public override void Tick(float delta)
		{
			base.Tick(delta);
			SpecialEnergyBarSlot barItem = this.BarItem;
			if (barItem != null)
			{
				barItem.Tick(delta);
			}
			if (this.Buff != null)
			{
				CharacterBuffComponent buffComponent = this.BuffComponent;
				if (((buffComponent != null) ? buffComponent.GetBuffByHandle(this.BuffHandle) : null) != null)
				{
					goto IL_41;
				}
			}
			this.RefreshBuff();
			IL_41:
			if (this.Buff != null && this.Buff.Duration > 0f)
			{
				this.SetRedState(false, false);
				float buffBarPercent = 1f - this.Buff.GetRemainDuration() / this.Buff.Duration;
				this.SetBuffBarPercent(buffBarPercent);
				return;
			}
			this.SetRedState(true, false);
		}

		// Token: 0x0603E931 RID: 256305 RVA: 0x0100238E File Offset: 0x0100058E
		private void SetBuffBarPercent(float percent)
		{
			if (this.LastBuffBarPercent == percent)
			{
				return;
			}
			this.LastBuffBarPercent = percent;
			base.GetUiNiagara(3).SetNiagaraVarFloat("Dissolve", percent);
			base.GetUiNiagara(4).SetNiagaraVarFloat("Dissolve", percent);
		}

		// Token: 0x0603E932 RID: 256306 RVA: 0x010023C8 File Offset: 0x010005C8
		private void SetRedState(bool isRed, bool bForce = false)
		{
			if (this.IsRedState == isRed && !bForce)
			{
				return;
			}
			this.IsRedState = isRed;
			UUIItem item = base.GetItem(1);
			if (item != null)
			{
				item.SetUIActive(!isRed);
			}
			UUIItem item2 = base.GetItem(2);
			if (item2 != null)
			{
				item2.SetUIActive(isRed);
			}
			if (!isRed && !bForce)
			{
				base.PlayTweenAnim(5);
			}
		}

		// Token: 0x04023157 RID: 143703
		private const float EFFECT_BASE_PERCENT = 0.46341464f;

		// Token: 0x04023158 RID: 143704
		[Nullable(2)]
		private SpecialEnergyBarSlot BarItem;

		// Token: 0x04023159 RID: 143705
		[Nullable(2)]
		private IActiveBuff Buff;

		// Token: 0x0402315A RID: 143706
		private int BuffHandle;

		// Token: 0x0402315B RID: 143707
		private bool IsRedState;

		// Token: 0x0402315C RID: 143708
		private float LastBuffBarPercent = -1f;

		// Token: 0x0200C201 RID: 49665
		private enum EChildType
		{
			// Token: 0x0403BC59 RID: 244825
			SlotBarItem,
			// Token: 0x0403BC5A RID: 244826
			BlueItem,
			// Token: 0x0403BC5B RID: 244827
			RedItem,
			// Token: 0x0403BC5C RID: 244828
			BlueBarL,
			// Token: 0x0403BC5D RID: 244829
			BlueBarR,
			// Token: 0x0403BC5E RID: 244830
			AniBurst
		}
	}
}
