using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060E0 RID: 24800
	public class SpecialEnergyBarSanHua : SpecialEnergyBarBase
	{
		// Token: 0x0603EA52 RID: 256594 RVA: 0x01008EAC File Offset: 0x010070AC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603EA53 RID: 256595 RVA: 0x01008F78 File Offset: 0x01007178
		protected override UniTask OnBeforeStartAsync()
		{
			SpecialEnergyBarSanHua.<OnBeforeStartAsync>d__13 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SpecialEnergyBarSanHua.<OnBeforeStartAsync>d__13>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603EA54 RID: 256596 RVA: 0x01008FBC File Offset: 0x010071BC
		[NullableContext(1)]
		protected UniTask InitPointItem(UUIItem pointItem)
		{
			SpecialEnergyBarSanHua.<InitPointItem>d__14 <InitPointItem>d__;
			<InitPointItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitPointItem>d__.<>4__this = this;
			<InitPointItem>d__.pointItem = pointItem;
			<InitPointItem>d__.<>1__state = -1;
			<InitPointItem>d__.<>t__builder.Start<SpecialEnergyBarSanHua.<InitPointItem>d__14>(ref <InitPointItem>d__);
			return <InitPointItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603EA55 RID: 256597 RVA: 0x01009008 File Offset: 0x01007208
		protected override void OnStart()
		{
			if (this.Config == null)
			{
				return;
			}
			if (!string.IsNullOrEmpty(this.Config.EffectColor))
			{
				FColor fcolor = FColor.FromHex(this.Config.EffectColor);
				FLinearColor flinearColor = new FLinearColor(ref fcolor);
				this.PointItem.SetFullEffectColor(flinearColor, false);
			}
			this.RefreshPercentRange();
			this.RefreshBarPercent(true);
			base.GetUiNiagara(3).SetUIActive(false);
			SpecialEnergyBarKeyItem keyItem = this.KeyItem;
			if (keyItem == null)
			{
				return;
			}
			keyItem.RefreshKeyEnable(true, true);
		}

		// Token: 0x0603EA56 RID: 256598 RVA: 0x01009084 File Offset: 0x01007284
		private void RefreshPercentRange()
		{
			int buffCountByBuffId = base.GetBuffCountByBuffId(1102012003L);
			float currentValue = this.AttributeComponent.GetCurrentValue((EAttributeType)this.Config.MaxAttributeId);
			this.CurLeftPercent = this.Config.ExtraFloatParams[buffCountByBuffId * 2] / currentValue;
			this.CurRightPercent = this.Config.ExtraFloatParams[buffCountByBuffId * 2 + 1] / currentValue;
		}

		// Token: 0x0603EA57 RID: 256599 RVA: 0x010090F0 File Offset: 0x010072F0
		protected void RefreshBarPercent(bool isStart = false)
		{
			float targetPercent = this.PercentMachine.GetTargetPercent();
			if (targetPercent > 0f)
			{
				this.LastPercent = targetPercent;
			}
			this.PointItem.UpdateLeftRightPercent(this.CurLeftPercent, this.CurRightPercent);
			base.GetItem(1).SetAnchorOffsetX(369f * (targetPercent - 0.5f));
			bool flag = targetPercent > this.CurLeftPercent && targetPercent <= this.CurRightPercent;
			if (isStart || flag != this.TipEffectEnable)
			{
				this.TipEffectEnable = flag;
				base.GetUiNiagara(2).SetUIActive(flag);
			}
		}

		// Token: 0x0603EA58 RID: 256600 RVA: 0x01009181 File Offset: 0x01007381
		protected override void OnBarPercentChanged()
		{
			this.RefreshBarPercent(false);
		}

		// Token: 0x0603EA59 RID: 256601 RVA: 0x0100918A File Offset: 0x0100738A
		public override void Tick(float delta)
		{
			base.Tick(delta);
			SpecialEnergyBarPointItem pointItem = this.PointItem;
			if (pointItem == null)
			{
				return;
			}
			pointItem.Tick(delta);
		}

		// Token: 0x0603EA5A RID: 256602 RVA: 0x010091A4 File Offset: 0x010073A4
		protected override void AddEvents()
		{
			base.AddEvents();
			base.ListenForTagCountChanged(SpecialEnergyBarSanHua.SuccessTagId, new BaseTagComponent.TTagChangedCallback(this.OnSuccessTagCountChange));
			base.ListenForTagCountChanged(SpecialEnergyBarSanHua.BuffTagId, new BaseTagComponent.TTagChangedCallback(this.OnBuffTagCountChange));
		}

		// Token: 0x0603EA5B RID: 256603 RVA: 0x010091DC File Offset: 0x010073DC
		private void OnSuccessTagCountChange(int count, int tagId, int exactTagId, int oldCount)
		{
			UUINiagara uiNiagara = base.GetUiNiagara(3);
			if (count > 0)
			{
				uiNiagara.SetAnchorOffsetX(369f * (this.LastPercent - 0.5f));
				uiNiagara.SetUIActive(true);
				return;
			}
			uiNiagara.SetUIActive(false);
		}

		// Token: 0x0603EA5C RID: 256604 RVA: 0x0100921C File Offset: 0x0100741C
		private void OnBuffTagCountChange(int count, int tagId, int exactTagId, int oldCount)
		{
			this.RefreshPercentRange();
			this.RefreshBarPercent(false);
		}

		// Token: 0x04023227 RID: 143911
		private const int POINT_NUM = 41;

		// Token: 0x04023228 RID: 143912
		private const float POINT_WIDTH = 9f;

		// Token: 0x04023229 RID: 143913
		private const float TOTAL_WIDTH = 369f;

		// Token: 0x0402322A RID: 143914
		[StaticVariableRuleIgnore]
		private static readonly int SuccessTagId = GameplayTagDefine.EGameplayTagId["角色.R2T1SanhuaMd10011.状态标识.蓄力判定成功暂停"];

		// Token: 0x0402322B RID: 143915
		[StaticVariableRuleIgnore]
		private static readonly int BuffTagId = GameplayTagDefine.EGameplayTagId["角色.R2T1SanhuaMd10011.状态标识.蓄力被动触发"];

		// Token: 0x0402322C RID: 143916
		private const int BUFF_ID = 1102012003;

		// Token: 0x0402322D RID: 143917
		[Nullable(2)]
		private SpecialEnergyBarPointItem PointItem;

		// Token: 0x0402322E RID: 143918
		private bool TipEffectEnable;

		// Token: 0x0402322F RID: 143919
		private float CurLeftPercent;

		// Token: 0x04023230 RID: 143920
		private float CurRightPercent = 1f;

		// Token: 0x04023231 RID: 143921
		private float LastPercent;

		// Token: 0x0200C23F RID: 49727
		private enum EChildType
		{
			// Token: 0x0403BDF9 RID: 245241
			PointItem,
			// Token: 0x0403BDFA RID: 245242
			SliderItem,
			// Token: 0x0403BDFB RID: 245243
			PointTipEffect,
			// Token: 0x0403BDFC RID: 245244
			PointSuccessEffect,
			// Token: 0x0403BDFD RID: 245245
			KeyContainerItem
		}
	}
}
