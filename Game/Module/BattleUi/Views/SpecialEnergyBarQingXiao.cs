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
	// Token: 0x020060DB RID: 24795
	public class SpecialEnergyBarQingXiao : SpecialEnergyBarBase
	{
		// Token: 0x0603E9F9 RID: 256505 RVA: 0x010070CC File Offset: 0x010052CC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 16;
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
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISliderComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E9FA RID: 256506 RVA: 0x0100730B File Offset: 0x0100550B
		protected override void OnInitData()
		{
			this.MorphPercentMachine.Init(this.GetMorphTargetAttributePercent());
		}

		// Token: 0x0603E9FB RID: 256507 RVA: 0x01007320 File Offset: 0x01005520
		protected float GetAttributePercent(EAttributeType attrId, EAttributeType maxAttrId)
		{
			float currentValue = this.AttributeComponent.GetCurrentValue(attrId);
			float currentValue2 = this.AttributeComponent.GetCurrentValue(maxAttrId);
			float result = 0f;
			if (currentValue2 > 0f)
			{
				result = currentValue / currentValue2;
			}
			return result;
		}

		// Token: 0x0603E9FC RID: 256508 RVA: 0x0100735A File Offset: 0x0100555A
		protected float GetQinTargetAttributePercent()
		{
			return this.GetAttributePercent(SpecialEnergyBarQingXiao.QIN_ATTR_ID, SpecialEnergyBarQingXiao.MAX_QIN_ATTR_ID);
		}

		// Token: 0x0603E9FD RID: 256509 RVA: 0x0100736C File Offset: 0x0100556C
		protected float GetJianTargetAttributePercent()
		{
			return this.GetAttributePercent(SpecialEnergyBarQingXiao.JIAN_ATTR_ID, SpecialEnergyBarQingXiao.MAX_JIAN_ATTR_ID);
		}

		// Token: 0x0603E9FE RID: 256510 RVA: 0x0100737E File Offset: 0x0100557E
		protected float GetMorphTargetAttributePercent()
		{
			return this.GetAttributePercent(SpecialEnergyBarQingXiao.MORPH_ATTR_ID, SpecialEnergyBarQingXiao.MAX_MORPH_ATTR_ID);
		}

		// Token: 0x0603E9FF RID: 256511 RVA: 0x01007390 File Offset: 0x01005590
		protected override void AddEvents()
		{
			base.AddEvents();
			base.ListenForAttributeChanged(SpecialEnergyBarQingXiao.QIN_ATTR_ID, new Action<EAttributeType, float, float>(this.OnQinOrMorphPercentChange));
			base.ListenForAttributeChanged(SpecialEnergyBarQingXiao.MAX_QIN_ATTR_ID, new Action<EAttributeType, float, float>(this.OnQinOrMorphPercentChange));
			base.ListenForAttributeChanged(SpecialEnergyBarQingXiao.JIAN_ATTR_ID, new Action<EAttributeType, float, float>(this.OnJianPercentChange));
			base.ListenForAttributeChanged(SpecialEnergyBarQingXiao.MAX_JIAN_ATTR_ID, new Action<EAttributeType, float, float>(this.OnJianPercentChange));
			base.ListenForTagAddOrRemoveChanged(SpecialEnergyBarQingXiao.MorphTagId, new BaseTagComponent.TTagSwitchedCallback(this.OnMorphTagChange));
		}

		// Token: 0x0603EA00 RID: 256512 RVA: 0x01007416 File Offset: 0x01005616
		private void OnQinOrMorphPercentChange(EAttributeType attributeId, float newValue, float oldValue)
		{
			if (this.CurState == SpecialEnergyBarQingXiao.EState.Normal)
			{
				this.OnQinPercentChange(attributeId, newValue, oldValue);
				return;
			}
			this.OnMorphPercentChange(attributeId, newValue, oldValue);
		}

		// Token: 0x0603EA01 RID: 256513 RVA: 0x01007434 File Offset: 0x01005634
		private void OnQinPercentChange(EAttributeType attributeId, float newValue, float oldValue)
		{
			float qinTargetAttributePercent = this.GetQinTargetAttributePercent();
			this.IsQinEnergyFull = (qinTargetAttributePercent >= 1f);
			this.RefreshNormalBarStyle(false);
		}

		// Token: 0x0603EA02 RID: 256514 RVA: 0x01007460 File Offset: 0x01005660
		private void OnJianPercentChange(EAttributeType attributeId, float newValue, float oldValue)
		{
			float jianTargetAttributePercent = this.GetJianTargetAttributePercent();
			this.IsJianEnergyFull = (jianTargetAttributePercent >= 1f);
			this.RefreshNormalBarStyle(false);
		}

		// Token: 0x0603EA03 RID: 256515 RVA: 0x0100748C File Offset: 0x0100568C
		private void OnMorphPercentChange(EAttributeType attributeId, float newValue, float oldValue)
		{
			float morphTargetAttributePercent = this.GetMorphTargetAttributePercent();
			this.SetMorphScaleVisible(morphTargetAttributePercent > 0f && morphTargetAttributePercent < 1f);
			this.SetMorphMaxNiaVisible(morphTargetAttributePercent >= 1f);
			SpecialEnergyBarKeyItem morphKeyItem = this.MorphKeyItem;
			if (morphKeyItem != null)
			{
				morphKeyItem.RefreshKeyEnable(morphTargetAttributePercent >= 1f, false);
			}
			this.MorphPercentMachine.SetTargetPercent(morphTargetAttributePercent);
			this.UpdateMorphBarPercent();
		}

		// Token: 0x0603EA04 RID: 256516 RVA: 0x010074FC File Offset: 0x010056FC
		private void SetMorphScaleVisible(bool visible)
		{
			bool? morphScaleVisible = this.MorphScaleVisible;
			if (morphScaleVisible.GetValueOrDefault() == visible & morphScaleVisible != null)
			{
				return;
			}
			this.MorphScaleVisible = new bool?(visible);
			if (visible)
			{
				base.StopTweenAnim(11);
				base.PlayTweenAnim(10);
				return;
			}
			base.StopTweenAnim(10);
			base.PlayTweenAnim(11);
		}

		// Token: 0x0603EA05 RID: 256517 RVA: 0x01007558 File Offset: 0x01005758
		private void SetMorphMaxNiaVisible(bool visible)
		{
			bool? morphMaxNiaVisible = this.MorphMaxNiaVisible;
			if (morphMaxNiaVisible.GetValueOrDefault() == visible & morphMaxNiaVisible != null)
			{
				return;
			}
			this.MorphMaxNiaVisible = new bool?(visible);
			if (visible)
			{
				base.PlayTweenAnim(12);
				return;
			}
			base.PlayTweenAnim(15);
		}

		// Token: 0x0603EA06 RID: 256518 RVA: 0x010075A3 File Offset: 0x010057A3
		private void OnMorphTagChange(int tagId, bool tagExist)
		{
			this.SetState(tagExist ? SpecialEnergyBarQingXiao.EState.Morph : SpecialEnergyBarQingXiao.EState.Normal);
		}

		// Token: 0x0603EA07 RID: 256519 RVA: 0x010075B4 File Offset: 0x010057B4
		private void RefreshNormalBarStyle(bool isStart = false)
		{
			if (isStart)
			{
				this.IsQinEnergyFull = (this.GetQinTargetAttributePercent() >= 1f);
				this.IsJianEnergyFull = (this.GetJianTargetAttributePercent() >= 1f);
			}
			bool flag = this.IsJianEnergyFull && this.IsQinEnergyFull;
			if (this.IsLastNormalEnergyFull == flag)
			{
				return;
			}
			if (flag)
			{
				base.PlayTweenAnim(7);
			}
			else
			{
				base.StopTweenAnim(7);
				base.GetItem(3).SetUIActive(false);
				base.GetItem(2).SetAlpha(1f);
				base.GetItem(2).SetUIActive(true);
			}
			SpecialEnergyBarQingXiaoSlot normalBarSlotItem = this.NormalBarSlotItem;
			if (normalBarSlotItem != null)
			{
				normalBarSlotItem.SetKeyEnable(flag);
			}
			this.IsLastNormalEnergyFull = flag;
		}

		// Token: 0x0603EA08 RID: 256520 RVA: 0x01007664 File Offset: 0x01005864
		protected override UniTask OnBeforeStartAsync()
		{
			SpecialEnergyBarQingXiao.<OnBeforeStartAsync>d__33 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SpecialEnergyBarQingXiao.<OnBeforeStartAsync>d__33>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603EA09 RID: 256521 RVA: 0x010076A8 File Offset: 0x010058A8
		protected UniTask InitBarItem()
		{
			SpecialEnergyBarQingXiao.<InitBarItem>d__34 <InitBarItem>d__;
			<InitBarItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitBarItem>d__.<>4__this = this;
			<InitBarItem>d__.<>1__state = -1;
			<InitBarItem>d__.<>t__builder.Start<SpecialEnergyBarQingXiao.<InitBarItem>d__34>(ref <InitBarItem>d__);
			return <InitBarItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603EA0A RID: 256522 RVA: 0x010076EC File Offset: 0x010058EC
		protected UniTask InitMorphKeyItem()
		{
			SpecialEnergyBarQingXiao.<InitMorphKeyItem>d__35 <InitMorphKeyItem>d__;
			<InitMorphKeyItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitMorphKeyItem>d__.<>4__this = this;
			<InitMorphKeyItem>d__.<>1__state = -1;
			<InitMorphKeyItem>d__.<>t__builder.Start<SpecialEnergyBarQingXiao.<InitMorphKeyItem>d__35>(ref <InitMorphKeyItem>d__);
			return <InitMorphKeyItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603EA0B RID: 256523 RVA: 0x01007730 File Offset: 0x01005930
		protected override void OnStart()
		{
			base.InitTweenAnim(7);
			base.InitTweenAnim(8);
			base.InitTweenAnim(9);
			base.InitTweenAnim(10);
			base.InitTweenAnim(11);
			base.InitTweenAnim(12);
			base.InitTweenAnim(15);
			this.RefreshState();
			this.UpdateMorphBarPercent();
			this.RefreshNormalBarStyle(true);
			SpecialEnergyBarKeyItem morphKeyItem = this.MorphKeyItem;
			if (morphKeyItem == null)
			{
				return;
			}
			morphKeyItem.RefreshKeyEnable(this.GetMorphTargetAttributePercent() >= 1f, true);
		}

		// Token: 0x0603EA0C RID: 256524 RVA: 0x010077A7 File Offset: 0x010059A7
		private void RefreshState()
		{
			BaseTagComponent tagComponent = this.TagComponent;
			if (tagComponent != null && tagComponent.HasTag(SpecialEnergyBarQingXiao.MorphTagId))
			{
				this.SetState(SpecialEnergyBarQingXiao.EState.Morph);
				return;
			}
			this.SetState(SpecialEnergyBarQingXiao.EState.Normal);
		}

		// Token: 0x0603EA0D RID: 256525 RVA: 0x010077D4 File Offset: 0x010059D4
		private void SetState(SpecialEnergyBarQingXiao.EState state)
		{
			if (this.CurState == state)
			{
				return;
			}
			if (state != SpecialEnergyBarQingXiao.EState.Normal)
			{
				if (state == SpecialEnergyBarQingXiao.EState.Morph)
				{
					if (this.CurState != SpecialEnergyBarQingXiao.EState.Max)
					{
						base.StopTweenAnim(9);
					}
					base.PlayTweenAnim(8);
					base.GetUiNiagara(13).SetUIActive(true);
					base.GetUiNiagara(14).SetUIActive(true);
					this.UpdateMorphBarPercent();
					SpecialEnergyBarKeyItem morphKeyItem = this.MorphKeyItem;
					if (morphKeyItem != null)
					{
						morphKeyItem.RefreshKeyEnable(this.GetMorphTargetAttributePercent() >= 1f, false);
					}
				}
			}
			else
			{
				if (this.CurState != SpecialEnergyBarQingXiao.EState.Max)
				{
					base.StopTweenAnim(8);
				}
				base.PlayTweenAnim(9);
				base.GetUiNiagara(13).SetUIActive(false);
				base.GetUiNiagara(14).SetUIActive(false);
				this.RefreshNormalBarStyle(false);
			}
			base.GetItem(6).SetUIActive(state == SpecialEnergyBarQingXiao.EState.Morph);
			this.CurState = state;
		}

		// Token: 0x0603EA0E RID: 256526 RVA: 0x010078A8 File Offset: 0x01005AA8
		private void UpdateMorphBarPercent()
		{
			float curPercent = this.MorphPercentMachine.GetCurPercent();
			base.GetSlider(5).SetValue(curPercent, true);
			base.GetUiNiagara(13).SetNiagaraVarFloat("Dissolve", 1f - curPercent);
			base.GetUiNiagara(14).SetNiagaraVarFloat("Dissolve", curPercent);
		}

		// Token: 0x0603EA0F RID: 256527 RVA: 0x010078FB File Offset: 0x01005AFB
		public override void Tick(float delta)
		{
			base.Tick(delta);
			SpecialEnergyBarQingXiaoSlot normalBarSlotItem = this.NormalBarSlotItem;
			if (normalBarSlotItem != null)
			{
				normalBarSlotItem.Tick(delta);
			}
			if (this.MorphPercentMachine.Update(delta))
			{
				this.UpdateMorphBarPercent();
			}
		}

		// Token: 0x040231EA RID: 143850
		[StaticVariableRuleIgnore]
		private static readonly int MorphTagId = GameplayTagDefine.EGameplayTagId["角色.R2T1QingxiaoMd10011.状态标识.剑仙状态"];

		// Token: 0x040231EB RID: 143851
		private static readonly EAttributeType QIN_ATTR_ID = EAttributeType.SpecialEnergy1;

		// Token: 0x040231EC RID: 143852
		private static readonly EAttributeType MAX_QIN_ATTR_ID = EAttributeType.SpecialEnergy1Max;

		// Token: 0x040231ED RID: 143853
		private static readonly EAttributeType JIAN_ATTR_ID = EAttributeType.SpecialEnergy2;

		// Token: 0x040231EE RID: 143854
		private static readonly EAttributeType MAX_JIAN_ATTR_ID = EAttributeType.SpecialEnergy2Max;

		// Token: 0x040231EF RID: 143855
		private static readonly EAttributeType MORPH_ATTR_ID = EAttributeType.SpecialEnergy1;

		// Token: 0x040231F0 RID: 143856
		private static readonly EAttributeType MAX_MORPH_ATTR_ID = EAttributeType.SpecialEnergy1Max;

		// Token: 0x040231F1 RID: 143857
		[Nullable(1)]
		private readonly SpecialEnergyBarPercentMachine MorphPercentMachine = new SpecialEnergyBarPercentMachine();

		// Token: 0x040231F2 RID: 143858
		[Nullable(2)]
		private SpecialEnergyBarQingXiaoSlot NormalBarSlotItem;

		// Token: 0x040231F3 RID: 143859
		[Nullable(2)]
		private SpecialEnergyBarKeyItem MorphKeyItem;

		// Token: 0x040231F4 RID: 143860
		private bool IsQinEnergyFull;

		// Token: 0x040231F5 RID: 143861
		private bool IsJianEnergyFull;

		// Token: 0x040231F6 RID: 143862
		private bool IsLastNormalEnergyFull;

		// Token: 0x040231F7 RID: 143863
		private SpecialEnergyBarQingXiao.EState CurState = SpecialEnergyBarQingXiao.EState.Max;

		// Token: 0x040231F8 RID: 143864
		private bool? MorphScaleVisible;

		// Token: 0x040231F9 RID: 143865
		private bool? MorphMaxNiaVisible;

		// Token: 0x0200C231 RID: 49713
		private enum EChildType
		{
			// Token: 0x0403BD96 RID: 245142
			PnlStateA,
			// Token: 0x0403BD97 RID: 245143
			SlotBarItem,
			// Token: 0x0403BD98 RID: 245144
			PnlNml,
			// Token: 0x0403BD99 RID: 245145
			PnlAct,
			// Token: 0x0403BD9A RID: 245146
			PnlStateB,
			// Token: 0x0403BD9B RID: 245147
			SldBar,
			// Token: 0x0403BD9C RID: 245148
			PnlHotKey,
			// Token: 0x0403BD9D RID: 245149
			AnimAMax,
			// Token: 0x0403BD9E RID: 245150
			AnimA2B,
			// Token: 0x0403BD9F RID: 245151
			AnimB2A,
			// Token: 0x0403BDA0 RID: 245152
			AnimDGlowIn,
			// Token: 0x0403BDA1 RID: 245153
			AnimDGlowOut,
			// Token: 0x0403BDA2 RID: 245154
			AnimBMax,
			// Token: 0x0403BDA3 RID: 245155
			NiaGre,
			// Token: 0x0403BDA4 RID: 245156
			NiaBlu,
			// Token: 0x0403BDA5 RID: 245157
			AnimBMax2B
		}

		// Token: 0x0200C232 RID: 49714
		private enum EState
		{
			// Token: 0x0403BDA7 RID: 245159
			Normal,
			// Token: 0x0403BDA8 RID: 245160
			Morph,
			// Token: 0x0403BDA9 RID: 245161
			Max
		}
	}
}
