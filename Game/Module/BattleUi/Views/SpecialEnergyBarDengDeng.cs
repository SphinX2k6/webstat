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
	// Token: 0x020060B6 RID: 24758
	[NullableContext(1)]
	[Nullable(0)]
	public class SpecialEnergyBarDengDeng : SpecialEnergyBarBase
	{
		// Token: 0x0603E83E RID: 256062 RVA: 0x00FFBCB0 File Offset: 0x00FF9EB0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
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
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUINiagara));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E83F RID: 256063 RVA: 0x00FFBDBE File Offset: 0x00FF9FBE
		protected override void OnInitData()
		{
			base.OnInitData();
			this.IsRedState = this.TagComponent.HasTag(SpecialEnergyBarDengDeng.TagRed);
			this.SecondPercentMachine.Init(this.GetSecondTargetAttributePercent());
		}

		// Token: 0x0603E840 RID: 256064 RVA: 0x00FFBDF0 File Offset: 0x00FF9FF0
		protected override UniTask OnBeforeStartAsync()
		{
			SpecialEnergyBarDengDeng.<OnBeforeStartAsync>d__14 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SpecialEnergyBarDengDeng.<OnBeforeStartAsync>d__14>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603E841 RID: 256065 RVA: 0x00FFBE34 File Offset: 0x00FFA034
		private UniTask InitPointLeftItem(UUIItem pointItem)
		{
			SpecialEnergyBarDengDeng.<InitPointLeftItem>d__15 <InitPointLeftItem>d__;
			<InitPointLeftItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitPointLeftItem>d__.<>4__this = this;
			<InitPointLeftItem>d__.pointItem = pointItem;
			<InitPointLeftItem>d__.<>1__state = -1;
			<InitPointLeftItem>d__.<>t__builder.Start<SpecialEnergyBarDengDeng.<InitPointLeftItem>d__15>(ref <InitPointLeftItem>d__);
			return <InitPointLeftItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603E842 RID: 256066 RVA: 0x00FFBE80 File Offset: 0x00FFA080
		private UniTask InitPointRightItem(UUIItem pointItem)
		{
			SpecialEnergyBarDengDeng.<InitPointRightItem>d__16 <InitPointRightItem>d__;
			<InitPointRightItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitPointRightItem>d__.<>4__this = this;
			<InitPointRightItem>d__.pointItem = pointItem;
			<InitPointRightItem>d__.<>1__state = -1;
			<InitPointRightItem>d__.<>t__builder.Start<SpecialEnergyBarDengDeng.<InitPointRightItem>d__16>(ref <InitPointRightItem>d__);
			return <InitPointRightItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603E843 RID: 256067 RVA: 0x00FFBECC File Offset: 0x00FFA0CC
		protected override void AddEvents()
		{
			base.AddEvents();
			base.ListenForAttributeChanged(this.SecondAttributeId, new Action<EAttributeType, float, float>(this.SecondAttributeChanged));
			base.ListenForAttributeChanged(this.SecondMaxAttributeId, new Action<EAttributeType, float, float>(this.SecondMaxAttributeChanged));
			base.ListenForTagAddOrRemoveChanged(SpecialEnergyBarDengDeng.TagRed, new BaseTagComponent.TTagSwitchedCallback(this.OnTagRedChange));
		}

		// Token: 0x0603E844 RID: 256068 RVA: 0x00FFBF26 File Offset: 0x00FFA126
		protected override void RemoveEvents()
		{
			base.RemoveEvents();
			base.RemoveListenAttributeChanged(this.SecondAttributeId, new Action<EAttributeType, float, float>(this.SecondAttributeChanged));
			base.RemoveListenAttributeChanged(this.SecondMaxAttributeId, new Action<EAttributeType, float, float>(this.SecondMaxAttributeChanged));
		}

		// Token: 0x0603E845 RID: 256069 RVA: 0x00FFBF60 File Offset: 0x00FFA160
		protected override void OnStart()
		{
			if (this.Config == null)
			{
				return;
			}
			this.SlotLeftItem.SetEffectBasePercent(0.4878049f);
			this.SlotRightItem.SetEffectBasePercent(0.4878049f);
			this.InitColor(this.SlotLeftItem, this.Config.PointColorList[0], this.Config.PointColorList[1], this.Config.EffectColor);
			this.InitColor(this.SlotRightItem, this.Config.PointColorList[2], this.Config.PointColorList[3], this.Config.OtherEffectColorList[0]);
			this.SlotLeftItem.ReplaceFullEffect(this.NiagaraList[0]);
			this.SlotRightItem.ReplaceFullEffect(this.NiagaraList[1]);
			this.UpdateRedState(true);
			this.RefreshBarPercent(true);
			this.RefreshSecondBarPercent(true);
			this.RefreshKeyEnable(true);
		}

		// Token: 0x0603E846 RID: 256070 RVA: 0x00FFC048 File Offset: 0x00FFA248
		private void InitColor(SpecialEnergyBarSlotItem slotItem, string pointBgColorStr, string pointColorStr, string effectColorStr)
		{
			FColor fcolor = FColor.FromHex(pointBgColorStr);
			FColor fcolor2 = FColor.FromHex(pointColorStr);
			FColor fcolor3 = FColor.FromHex(effectColorStr);
			FLinearColor flinearColor = new FLinearColor(ref fcolor3);
			slotItem.SetPointBgColor(fcolor);
			slotItem.SetBarColor(fcolor2);
			slotItem.SetPointColor(fcolor2);
			slotItem.SetBgAndUseEffectColor(flinearColor);
		}

		// Token: 0x0603E847 RID: 256071 RVA: 0x00FFC093 File Offset: 0x00FFA293
		private void UpdateRedState(bool isStart = false)
		{
			UUIItem item = base.GetItem(3);
			if (item != null)
			{
				item.SetUIActive(!this.IsRedState);
			}
			UUIItem item2 = base.GetItem(4);
			if (item2 != null)
			{
				item2.SetUIActive(this.IsRedState);
			}
			if (!isStart)
			{
				this.RefreshKeyEnable(false);
			}
		}

		// Token: 0x0603E848 RID: 256072 RVA: 0x00FFC0D4 File Offset: 0x00FFA2D4
		private void RefreshBarPercent(bool isStart = false)
		{
			float curPercent = this.PercentMachine.GetCurPercent();
			this.SlotLeftItem.UpdatePercent(curPercent, curPercent >= this.Config.DisableKeyOnPercent, false);
			UUIItem item = base.GetItem(3);
			if (item != null)
			{
				item.SetAnchorOffsetX(-curPercent * 190f);
			}
			if (!this.IsRedState && !isStart)
			{
				this.RefreshKeyEnable(false);
			}
			bool flag = curPercent > 0f;
			if (isStart || flag != this.IsLeftGraduateEffectVisible)
			{
				this.IsLeftGraduateEffectVisible = flag;
				UUINiagara uiNiagara = base.GetUiNiagara(5);
				if (uiNiagara == null)
				{
					return;
				}
				uiNiagara.SetUIActive(flag);
			}
		}

		// Token: 0x0603E849 RID: 256073 RVA: 0x00FFC168 File Offset: 0x00FFA368
		private void RefreshSecondBarPercent(bool isStart = false)
		{
			float curPercent = this.SecondPercentMachine.GetCurPercent();
			this.SlotRightItem.UpdatePercent(curPercent, curPercent >= this.Config.DisableKeyOnPercent, false);
			UUIItem item = base.GetItem(4);
			if (item != null)
			{
				item.SetAnchorOffsetX(curPercent * 190f);
			}
			if (this.IsRedState && !isStart)
			{
				this.RefreshKeyEnable(isStart);
			}
			bool flag = curPercent > 0f;
			if (isStart || flag != this.IsRightGraduateEffectVisible)
			{
				this.IsRightGraduateEffectVisible = flag;
				UUINiagara uiNiagara = base.GetUiNiagara(6);
				if (uiNiagara == null)
				{
					return;
				}
				uiNiagara.SetUIActive(flag);
			}
		}

		// Token: 0x0603E84A RID: 256074 RVA: 0x00FFC1F8 File Offset: 0x00FFA3F8
		private void RefreshKeyEnable(bool isStart = false)
		{
			SpecialEnergyBarKeyItem keyItem = this.KeyItem;
			if (keyItem == null)
			{
				return;
			}
			keyItem.RefreshKeyEnable(this.GetKeyEnable(), isStart);
		}

		// Token: 0x0603E84B RID: 256075 RVA: 0x00FFC211 File Offset: 0x00FFA411
		protected override bool GetKeyEnable()
		{
			return (this.IsRedState ? this.SecondPercentMachine.GetCurPercent() : this.PercentMachine.GetCurPercent()) >= this.Config.DisableKeyOnPercent;
		}

		// Token: 0x0603E84C RID: 256076 RVA: 0x00FFC243 File Offset: 0x00FFA443
		protected override void OnBarPercentChanged()
		{
			this.RefreshBarPercent(false);
		}

		// Token: 0x0603E84D RID: 256077 RVA: 0x00FFC24C File Offset: 0x00FFA44C
		private void OnSecondBarPercentChanged()
		{
			this.RefreshSecondBarPercent(false);
		}

		// Token: 0x0603E84E RID: 256078 RVA: 0x00FFC255 File Offset: 0x00FFA455
		public override void Tick(float delta)
		{
			base.Tick(delta);
			if (this.SecondPercentMachine.Update(delta))
			{
				this.OnSecondBarPercentChanged();
			}
			SpecialEnergyBarSlotItem slotLeftItem = this.SlotLeftItem;
			if (slotLeftItem != null)
			{
				slotLeftItem.Tick(delta);
			}
			SpecialEnergyBarSlotItem slotRightItem = this.SlotRightItem;
			if (slotRightItem == null)
			{
				return;
			}
			slotRightItem.Tick(delta);
		}

		// Token: 0x0603E84F RID: 256079 RVA: 0x00FFC295 File Offset: 0x00FFA495
		private void SecondAttributeChanged(EAttributeType attributeId, float newValue, float oldValue)
		{
			this.SecondPercentMachine.SetTargetPercent(this.GetSecondTargetAttributePercent());
			this.OnSecondBarPercentChanged();
		}

		// Token: 0x0603E850 RID: 256080 RVA: 0x00FFC2AE File Offset: 0x00FFA4AE
		private void SecondMaxAttributeChanged(EAttributeType attributeId, float newValue, float oldValue)
		{
			this.SecondPercentMachine.SetTargetPercent(this.GetSecondTargetAttributePercent());
			this.OnSecondBarPercentChanged();
		}

		// Token: 0x0603E851 RID: 256081 RVA: 0x00FFC2C8 File Offset: 0x00FFA4C8
		private float GetSecondTargetAttributePercent()
		{
			float currentValue = this.AttributeComponent.GetCurrentValue(this.SecondAttributeId);
			float currentValue2 = this.AttributeComponent.GetCurrentValue(this.SecondMaxAttributeId);
			float result = 0f;
			if (currentValue2 > 0f)
			{
				result = currentValue / currentValue2;
			}
			return result;
		}

		// Token: 0x0603E852 RID: 256082 RVA: 0x00FFC30C File Offset: 0x00FFA50C
		private void OnTagRedChange(int tagId, bool tagExist)
		{
			if (tagExist == this.IsRedState)
			{
				return;
			}
			this.IsRedState = tagExist;
			this.UpdateRedState(false);
		}

		// Token: 0x040230AF RID: 143535
		private const float WIDTH = 190f;

		// Token: 0x040230B0 RID: 143536
		private const float EFFECT_BASE_PERCENT = 0.4878049f;

		// Token: 0x040230B1 RID: 143537
		[StaticVariableRuleIgnore]
		private static readonly int TagRed = GameplayTagDefine.EGameplayTagId["角色.R2T1DengDengMd10011.状态标识.红剑"];

		// Token: 0x040230B2 RID: 143538
		[Nullable(2)]
		private SpecialEnergyBarSlotItem SlotLeftItem;

		// Token: 0x040230B3 RID: 143539
		[Nullable(2)]
		private SpecialEnergyBarSlotItem SlotRightItem;

		// Token: 0x040230B4 RID: 143540
		private readonly SpecialEnergyBarPercentMachine SecondPercentMachine = new SpecialEnergyBarPercentMachine();

		// Token: 0x040230B5 RID: 143541
		private readonly EAttributeType SecondAttributeId = EAttributeType.SpecialEnergy2;

		// Token: 0x040230B6 RID: 143542
		private readonly EAttributeType SecondMaxAttributeId = EAttributeType.SpecialEnergy2Max;

		// Token: 0x040230B7 RID: 143543
		private bool IsRedState;

		// Token: 0x040230B8 RID: 143544
		private bool IsLeftGraduateEffectVisible;

		// Token: 0x040230B9 RID: 143545
		private bool IsRightGraduateEffectVisible;

		// Token: 0x0200C1DD RID: 49629
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403BB46 RID: 244550
			SlotLeftItem,
			// Token: 0x0403BB47 RID: 244551
			SlotRightItem,
			// Token: 0x0403BB48 RID: 244552
			KeyContainerItem,
			// Token: 0x0403BB49 RID: 244553
			LeftGraduateItem,
			// Token: 0x0403BB4A RID: 244554
			RightGraduateItem,
			// Token: 0x0403BB4B RID: 244555
			LeftGraduateEffect,
			// Token: 0x0403BB4C RID: 244556
			RightGraduateEffect
		}
	}
}
