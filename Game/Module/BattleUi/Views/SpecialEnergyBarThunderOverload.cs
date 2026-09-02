using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060E5 RID: 24805
	public class SpecialEnergyBarThunderOverload : SpecialEnergyBarMorphCountDown
	{
		// Token: 0x0603EA97 RID: 256663 RVA: 0x0100A18C File Offset: 0x0100838C
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
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603EA98 RID: 256664 RVA: 0x0100A27C File Offset: 0x0100847C
		protected override UniTask OnBeforeStartAsync()
		{
			SpecialEnergyBarThunderOverload.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SpecialEnergyBarThunderOverload.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603EA99 RID: 256665 RVA: 0x0100A2BF File Offset: 0x010084BF
		protected override void OnStart()
		{
			base.OnStart();
			this.RefreshKeyEnable(true);
		}

		// Token: 0x0603EA9A RID: 256666 RVA: 0x0100A2CE File Offset: 0x010084CE
		protected override ValueTuple<float, float> GetEffectBasePercents(float effectBasePercent)
		{
			return new ValueTuple<float, float>(1f, effectBasePercent);
		}

		// Token: 0x0603EA9B RID: 256667 RVA: 0x0100A2DB File Offset: 0x010084DB
		protected override ValueTuple<int, int> GetEffectPointNums(int pointNum)
		{
			return new ValueTuple<int, int>(17, 17);
		}

		// Token: 0x0603EA9C RID: 256668 RVA: 0x0100A2E6 File Offset: 0x010084E6
		protected override int GetUseEffectPointOffsetNum(int pointNum)
		{
			return Math.Max(0, pointNum - 17);
		}

		// Token: 0x0603EA9D RID: 256669 RVA: 0x0100A2F2 File Offset: 0x010084F2
		protected override void OnBarPercentChanged()
		{
			base.OnBarPercentChanged();
			this.RefreshKeyEnable(false);
		}

		// Token: 0x0603EA9E RID: 256670 RVA: 0x0100A301 File Offset: 0x01008501
		protected override void OnKeyEnableChanged()
		{
			this.RefreshKeyEnable(false);
		}

		// Token: 0x0603EA9F RID: 256671 RVA: 0x0100A30A File Offset: 0x0100850A
		private void RefreshKeyEnable(bool isStart = false)
		{
			SpecialEnergyBarKeyItem keyItem = this.KeyItem;
			if (keyItem == null)
			{
				return;
			}
			keyItem.RefreshKeyEnable(this.GetKeyEnable(), isStart);
		}

		// Token: 0x0402324B RID: 143947
		private const int FULL_EFFECT_POINT_NUM = 17;

		// Token: 0x0200C251 RID: 49745
		private enum EChildType
		{
			// Token: 0x0403BE58 RID: 245336
			PointLeftItem,
			// Token: 0x0403BE59 RID: 245337
			PointRightItem,
			// Token: 0x0403BE5A RID: 245338
			IconTexture,
			// Token: 0x0403BE5B RID: 245339
			StartEffect,
			// Token: 0x0403BE5C RID: 245340
			AnimItem,
			// Token: 0x0403BE5D RID: 245341
			KeyContainerItem
		}
	}
}
