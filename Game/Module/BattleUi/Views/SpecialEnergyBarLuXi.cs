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
	// Token: 0x020060D5 RID: 24789
	[NullableContext(2)]
	[Nullable(0)]
	public class SpecialEnergyBarLuXi : SpecialEnergyBarBase
	{
		// Token: 0x0603E9AF RID: 256431 RVA: 0x0100518C File Offset: 0x0100338C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 17;
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
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E9B0 RID: 256432 RVA: 0x010053ED File Offset: 0x010035ED
		protected override void OnInitData()
		{
			this.RedConfig = ModelBase<BattleUiModel>.Instance.SpecialEnergyBarData.GetSpecialEnergyBarInfo(151101);
		}

		// Token: 0x0603E9B1 RID: 256433 RVA: 0x0100540C File Offset: 0x0100360C
		protected override void AddEvents()
		{
			base.AddEvents();
			base.ListenForTagAddOrRemoveChanged(SpecialEnergyBarLuXi.NormalActivateTag, new BaseTagComponent.TTagSwitchedCallback(this.OnNormalActivateTagChange));
			base.ListenForTagAddOrRemoveChanged(SpecialEnergyBarLuXi.NormalActivateTag2, new BaseTagComponent.TTagSwitchedCallback(this.OnNormalActivateTagChange2));
			base.ListenForTagAddOrRemoveChanged(SpecialEnergyBarLuXi.RedOverclockTag, new BaseTagComponent.TTagSwitchedCallback(this.OnRedOverclockTagChange));
			base.ListenForTagAddOrRemoveChanged(SpecialEnergyBarLuXi.RedWeakTag, new BaseTagComponent.TTagSwitchedCallback(this.OnRedWeakTagChange));
			base.ListenForAttributeChanged(EAttributeType.SpecialEnergy2, new Action<EAttributeType, float, float>(this.WeakAttributeChanged));
			base.ListenForAttributeChanged(EAttributeType.SpecialEnergy2Max, new Action<EAttributeType, float, float>(this.WeakAttributeChanged));
		}

		// Token: 0x0603E9B2 RID: 256434 RVA: 0x010054A3 File Offset: 0x010036A3
		protected override void RemoveEvents()
		{
			base.RemoveEvents();
			base.RemoveListenAttributeChanged(EAttributeType.SpecialEnergy2, new Action<EAttributeType, float, float>(this.WeakAttributeChanged));
			base.RemoveListenAttributeChanged(EAttributeType.SpecialEnergy2Max, new Action<EAttributeType, float, float>(this.WeakAttributeChanged));
		}

		// Token: 0x0603E9B3 RID: 256435 RVA: 0x010054D3 File Offset: 0x010036D3
		private void OnNormalActivateTagChange(int tagId, bool tagExist)
		{
			this.IsNormalActivate = tagExist;
			this.StateDirty = true;
		}

		// Token: 0x0603E9B4 RID: 256436 RVA: 0x010054E3 File Offset: 0x010036E3
		private void OnNormalActivateTagChange2(int tagId, bool tagExist)
		{
			this.IsNormalActivate2 = tagExist;
			this.StateDirty = true;
		}

		// Token: 0x0603E9B5 RID: 256437 RVA: 0x010054F3 File Offset: 0x010036F3
		private void OnRedOverclockTagChange(int tagId, bool tagExist)
		{
			this.IsRedOverclock = tagExist;
			this.StateDirty = true;
		}

		// Token: 0x0603E9B6 RID: 256438 RVA: 0x01005503 File Offset: 0x01003703
		private void OnRedWeakTagChange(int tagId, bool tagExist)
		{
			this.IsRedWeak = tagExist;
			this.StateDirty = true;
		}

		// Token: 0x0603E9B7 RID: 256439 RVA: 0x01005513 File Offset: 0x01003713
		private void WeakAttributeChanged(EAttributeType attributeId, float curValue, float maxValue)
		{
			this.OnWeakAttributeChanged();
		}

		// Token: 0x0603E9B8 RID: 256440 RVA: 0x0100551C File Offset: 0x0100371C
		protected void OnWeakAttributeChanged()
		{
			if (this.AttributeComponent == null)
			{
				return;
			}
			float currentValue = this.AttributeComponent.GetCurrentValue(EAttributeType.SpecialEnergy2);
			float currentValue2 = this.AttributeComponent.GetCurrentValue(EAttributeType.SpecialEnergy2Max);
			float targetPercent = 0f;
			if (currentValue2 > 0f)
			{
				targetPercent = currentValue / currentValue2;
			}
			this.WeakPercentMachine.SetTargetPercent(targetPercent);
			this.OnWeakPercentChanged();
		}

		// Token: 0x0603E9B9 RID: 256441 RVA: 0x01005574 File Offset: 0x01003774
		protected void OnWeakPercentChanged()
		{
			float curPercent = this.WeakPercentMachine.GetCurPercent();
			UUISprite sprite = base.GetSprite(7);
			if (sprite == null)
			{
				return;
			}
			sprite.SetFillAmount(curPercent);
		}

		// Token: 0x0603E9BA RID: 256442 RVA: 0x010055A0 File Offset: 0x010037A0
		protected override UniTask OnBeforeStartAsync()
		{
			SpecialEnergyBarLuXi.<OnBeforeStartAsync>d__40 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SpecialEnergyBarLuXi.<OnBeforeStartAsync>d__40>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603E9BB RID: 256443 RVA: 0x010055E4 File Offset: 0x010037E4
		protected UniTask InitBarItem()
		{
			SpecialEnergyBarLuXi.<InitBarItem>d__41 <InitBarItem>d__;
			<InitBarItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitBarItem>d__.<>4__this = this;
			<InitBarItem>d__.<>1__state = -1;
			<InitBarItem>d__.<>t__builder.Start<SpecialEnergyBarLuXi.<InitBarItem>d__41>(ref <InitBarItem>d__);
			return <InitBarItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603E9BC RID: 256444 RVA: 0x01005628 File Offset: 0x01003828
		protected override void OnStart()
		{
			this.WeakPercentMachine.Duration = this.RedConfig.ExtraFloatParams[0] * 1000f;
			this.LineFlowDensityCurveAsset = Singleton<ResourceSystem>.Instance.Load<UCurveFloat>(ConfigBase<UiResourceConfig>.Instance.GetResourcePath("Curve_LIneFlow01_Luxi"), "js_undefined");
			this.LineFlowIntensityCurveAsset = Singleton<ResourceSystem>.Instance.Load<UCurveFloat>(ConfigBase<UiResourceConfig>.Instance.GetResourcePath("Curve_LIneFlow02_Luxi"), "js_undefined");
			base.InitTweenAnim(13);
			base.InitTweenAnim(14);
			base.InitTweenAnim(15);
			base.InitTweenAnim(16);
			this.LastBarPercent = this.PercentMachine.GetCurPercent();
			this.RefreshLineFlowMaterial(0f);
			BaseTagComponent tagComponent = this.TagComponent;
			this.IsNormalActivate = (tagComponent != null && tagComponent.HasTag(SpecialEnergyBarLuXi.NormalActivateTag));
			BaseTagComponent tagComponent2 = this.TagComponent;
			this.IsNormalActivate2 = (tagComponent2 != null && tagComponent2.HasTag(SpecialEnergyBarLuXi.NormalActivateTag2));
			BaseTagComponent tagComponent3 = this.TagComponent;
			this.IsRedWeak = (tagComponent3 != null && tagComponent3.HasTag(SpecialEnergyBarLuXi.RedWeakTag));
			BaseTagComponent tagComponent4 = this.TagComponent;
			this.IsRedOverclock = (tagComponent4 != null && tagComponent4.HasTag(SpecialEnergyBarLuXi.RedOverclockTag));
			this.RefreshState(true);
			this.OnWeakAttributeChanged();
		}

		// Token: 0x0603E9BD RID: 256445 RVA: 0x0100575C File Offset: 0x0100395C
		protected override void OnBarPercentChanged()
		{
			base.OnBarPercentChanged();
			float curPercent = this.PercentMachine.GetCurPercent();
			bool flag = curPercent > this.LastBarPercent;
			bool flag2 = curPercent >= 1f;
			if (this.IsFullPercent != flag2)
			{
				this.IsFullPercent = flag2;
				this.RefreshLineFlowVisible();
				this.RefreshNormalLightItem();
				this.RefreshNiaMax();
				if (this.CurState == SpecialEnergyBarLuXi.EState.Normal)
				{
					base.PlayTweenAnim(14);
				}
			}
			if (this.CurState == SpecialEnergyBarLuXi.EState.NormalActivate && flag && !this.IsFullPercent)
			{
				this.TryPlayLineFlowGrowAnim();
			}
			this.LastBarPercent = curPercent;
		}

		// Token: 0x0603E9BE RID: 256446 RVA: 0x010057E8 File Offset: 0x010039E8
		private void RefreshState(bool isStart = false)
		{
			if (this.IsRedWeak)
			{
				this.SetState(SpecialEnergyBarLuXi.EState.RedWeak, isStart);
				return;
			}
			if (this.IsRedOverclock)
			{
				this.SetState(SpecialEnergyBarLuXi.EState.RedOverclock, isStart);
				return;
			}
			if (this.IsNormalActivate || this.IsNormalActivate2)
			{
				this.SetState(SpecialEnergyBarLuXi.EState.NormalActivate, isStart);
				return;
			}
			this.SetState(SpecialEnergyBarLuXi.EState.Normal, isStart);
		}

		// Token: 0x0603E9BF RID: 256447 RVA: 0x01005838 File Offset: 0x01003A38
		private void SetState(SpecialEnergyBarLuXi.EState state, bool isStart = false)
		{
			if (state == this.CurState && !isStart)
			{
				return;
			}
			SpecialEnergyBarLuXi.EState curState = this.CurState;
			this.CurState = state;
			switch (this.CurState)
			{
			case SpecialEnergyBarLuXi.EState.Normal:
			{
				UUIItem item = base.GetItem(0);
				if (item != null)
				{
					item.SetUIActive(true);
				}
				UUIItem item2 = base.GetItem(5);
				if (item2 != null)
				{
					item2.SetUIActive(false);
				}
				UUIItem item3 = base.GetItem(3);
				if (item3 != null)
				{
					item3.SetUIActive(false);
				}
				this.RefreshLineFlowVisible();
				this.RefreshNormalLightItem();
				if (!isStart && curState != SpecialEnergyBarLuXi.EState.Normal && curState != SpecialEnergyBarLuXi.EState.NormalActivate)
				{
					base.PlayTweenAnim(16);
					return;
				}
				break;
			}
			case SpecialEnergyBarLuXi.EState.NormalActivate:
			{
				UUIItem item4 = base.GetItem(0);
				if (item4 != null)
				{
					item4.SetUIActive(true);
				}
				UUIItem item5 = base.GetItem(5);
				if (item5 != null)
				{
					item5.SetUIActive(false);
				}
				UUIItem item6 = base.GetItem(3);
				if (item6 != null)
				{
					item6.SetUIActive(true);
				}
				this.RefreshLineFlowVisible();
				this.RefreshNormalLightItem();
				if (!isStart)
				{
					if (curState != SpecialEnergyBarLuXi.EState.Normal && curState != SpecialEnergyBarLuXi.EState.NormalActivate)
					{
						base.PlayTweenAnim(16);
					}
					base.PlayTweenAnim(14);
					this.TryPlayLineFlowGrowAnim();
					return;
				}
				break;
			}
			case SpecialEnergyBarLuXi.EState.RedOverclock:
			{
				UUIItem item7 = base.GetItem(0);
				if (item7 != null)
				{
					item7.SetUIActive(false);
				}
				UUIItem item8 = base.GetItem(5);
				if (item8 != null)
				{
					item8.SetUIActive(true);
				}
				UUIItem item9 = base.GetItem(11);
				if (item9 != null)
				{
					item9.SetUIActive(true);
				}
				UUINiagara uiNiagara = base.GetUiNiagara(12);
				if (uiNiagara != null)
				{
					uiNiagara.SetUIActive(false);
				}
				this.RefreshNiaMax();
				if (!isStart && curState != SpecialEnergyBarLuXi.EState.RedOverclock && curState != SpecialEnergyBarLuXi.EState.RedWeak)
				{
					base.PlayTweenAnim(15);
					return;
				}
				break;
			}
			case SpecialEnergyBarLuXi.EState.RedWeak:
			{
				UUIItem item10 = base.GetItem(0);
				if (item10 != null)
				{
					item10.SetUIActive(false);
				}
				UUIItem item11 = base.GetItem(5);
				if (item11 != null)
				{
					item11.SetUIActive(true);
				}
				UUIItem item12 = base.GetItem(11);
				if (item12 != null)
				{
					item12.SetUIActive(false);
				}
				UUINiagara uiNiagara2 = base.GetUiNiagara(12);
				if (uiNiagara2 != null)
				{
					uiNiagara2.SetUIActive(true);
				}
				UUINiagara uiNiagara3 = base.GetUiNiagara(9);
				if (uiNiagara3 != null)
				{
					uiNiagara3.SetUIActive(false);
				}
				if (!isStart && curState != SpecialEnergyBarLuXi.EState.RedOverclock && curState != SpecialEnergyBarLuXi.EState.RedWeak)
				{
					base.PlayTweenAnim(15);
				}
				break;
			}
			default:
				return;
			}
		}

		// Token: 0x0603E9C0 RID: 256448 RVA: 0x01005A2C File Offset: 0x01003C2C
		private void RefreshNormalLightItem()
		{
			bool flag = false;
			if (this.CurState == SpecialEnergyBarLuXi.EState.Normal)
			{
				flag = this.IsFullPercent;
			}
			else if (this.CurState == SpecialEnergyBarLuXi.EState.NormalActivate)
			{
				flag = true;
			}
			UUIItem item = base.GetItem(2);
			if (item != null)
			{
				item.SetUIActive(flag);
			}
			SpecialEnergyBarLuXiSlot barItemNormal = this.BarItemNormal;
			if (barItemNormal == null)
			{
				return;
			}
			barItemNormal.SetColorState((flag > false) ? 1 : 0);
		}

		// Token: 0x0603E9C1 RID: 256449 RVA: 0x01005A80 File Offset: 0x01003C80
		private void RefreshLineFlowVisible()
		{
			bool uiactive = this.CurState == SpecialEnergyBarLuXi.EState.NormalActivate && !this.IsFullPercent;
			UUITexture texture = base.GetTexture(8);
			if (texture == null)
			{
				return;
			}
			texture.SetUIActive(uiactive);
		}

		// Token: 0x0603E9C2 RID: 256450 RVA: 0x01005AB5 File Offset: 0x01003CB5
		private void RefreshNiaMax()
		{
			UUINiagara uiNiagara = base.GetUiNiagara(9);
			if (uiNiagara == null)
			{
				return;
			}
			uiNiagara.SetUIActive(this.CurState == SpecialEnergyBarLuXi.EState.RedOverclock && this.IsFullPercent);
		}

		// Token: 0x0603E9C3 RID: 256451 RVA: 0x01005ADB File Offset: 0x01003CDB
		private void TryPlayLineFlowGrowAnim()
		{
			if (this.LineFlowAnimTriggerCd < 2000f)
			{
				return;
			}
			this.LineFlowAnimTriggerCd = 0f;
			this.LineFlowAnimElapsed = 0f;
			this.RefreshLineFlowMaterial(0f);
			base.PlayTweenAnim(13);
		}

		// Token: 0x0603E9C4 RID: 256452 RVA: 0x01005B14 File Offset: 0x01003D14
		private void RefreshLineFlowMaterial(float elapsedTime)
		{
			UUITexture texture = base.GetTexture(8);
			if (texture == null)
			{
				return;
			}
			float inTime = elapsedTime / 1000f;
			UCurveFloat lineFlowDensityCurveAsset = this.LineFlowDensityCurveAsset;
			float value = (lineFlowDensityCurveAsset != null) ? lineFlowDensityCurveAsset.GetFloatValue(inTime) : 0f;
			UCurveFloat lineFlowIntensityCurveAsset = this.LineFlowIntensityCurveAsset;
			float value2 = (lineFlowIntensityCurveAsset != null) ? lineFlowIntensityCurveAsset.GetFloatValue(inTime) : 0f;
			texture.SetCustomMaterialScalarParameter(this.NameDensityU, value);
			texture.SetCustomMaterialScalarParameter(this.NameIntensityU, value2);
		}

		// Token: 0x0603E9C5 RID: 256453 RVA: 0x01005B80 File Offset: 0x01003D80
		public override void Tick(float delta)
		{
			base.Tick(delta);
			SpecialEnergyBarLuXiSlot barItemRed = this.BarItemRed;
			if (barItemRed != null)
			{
				barItemRed.Tick(delta);
			}
			SpecialEnergyBarLuXiSlot barItemNormal = this.BarItemNormal;
			if (barItemNormal != null)
			{
				barItemNormal.Tick(delta);
			}
			if (this.StateDirty)
			{
				this.RefreshState(false);
				this.StateDirty = false;
			}
			if (this.WeakPercentMachine.Update(delta))
			{
				this.OnWeakPercentChanged();
			}
			if (this.LineFlowAnimTriggerCd < 2000f)
			{
				this.LineFlowAnimTriggerCd = Math.Min(this.LineFlowAnimTriggerCd + delta, 2000f);
			}
			if (this.LineFlowAnimElapsed < 2000f)
			{
				this.LineFlowAnimElapsed = Math.Min(this.LineFlowAnimElapsed + delta, 2000f);
				this.RefreshLineFlowMaterial(this.LineFlowAnimElapsed);
			}
		}

		// Token: 0x040231AA RID: 143786
		private const int RedConfigId = 151101;

		// Token: 0x040231AB RID: 143787
		[Nullable(1)]
		private const string LineFlowDensityCurve = "Curve_LIneFlow01_Luxi";

		// Token: 0x040231AC RID: 143788
		[Nullable(1)]
		private const string LineFlowIntensityCurve = "Curve_LIneFlow02_Luxi";

		// Token: 0x040231AD RID: 143789
		private const float LineFlowAnimDuration = 2000f;

		// Token: 0x040231AE RID: 143790
		private const float LineFlowAnimTriggerInterval = 2000f;

		// Token: 0x040231AF RID: 143791
		private static readonly int NormalActivateTag = GameplayTagDefine.EGameplayTagId["角色.R2T1LucyMd10011.黑客效果.跟踪同步"];

		// Token: 0x040231B0 RID: 143792
		private static readonly int NormalActivateTag2 = GameplayTagDefine.EGameplayTagId["角色.R2T1LucyMd10011.状态标识.黑客E可用"];

		// Token: 0x040231B1 RID: 143793
		private static readonly int RedOverclockTag = GameplayTagDefine.EGameplayTagId["角色.R2T1LucyMd10011.状态标识.强化重击印记"];

		// Token: 0x040231B2 RID: 143794
		private static readonly int RedWeakTag = GameplayTagDefine.EGameplayTagId["角色.R2T1LucyMd10011.状态标识.烧血警告"];

		// Token: 0x040231B3 RID: 143795
		private SpecialEnergyBarInfo RedConfig;

		// Token: 0x040231B4 RID: 143796
		private SpecialEnergyBarLuXiSlot BarItemRed;

		// Token: 0x040231B5 RID: 143797
		private SpecialEnergyBarLuXiSlot BarItemNormal;

		// Token: 0x040231B6 RID: 143798
		private bool IsNormalActivate;

		// Token: 0x040231B7 RID: 143799
		private bool IsNormalActivate2;

		// Token: 0x040231B8 RID: 143800
		private bool IsRedOverclock;

		// Token: 0x040231B9 RID: 143801
		private bool IsRedWeak;

		// Token: 0x040231BA RID: 143802
		private bool StateDirty;

		// Token: 0x040231BB RID: 143803
		private SpecialEnergyBarLuXi.EState CurState;

		// Token: 0x040231BC RID: 143804
		private bool IsFullPercent;

		// Token: 0x040231BD RID: 143805
		[Nullable(1)]
		private readonly SpecialEnergyBarPercentMachinePro WeakPercentMachine = new SpecialEnergyBarPercentMachinePro();

		// Token: 0x040231BE RID: 143806
		private readonly FName NameDensityU = FNameUtil.GetDynamicFName("密度U").Value;

		// Token: 0x040231BF RID: 143807
		private readonly FName NameIntensityU = FNameUtil.GetDynamicFName("强度U").Value;

		// Token: 0x040231C0 RID: 143808
		private UCurveFloat LineFlowDensityCurveAsset;

		// Token: 0x040231C1 RID: 143809
		private UCurveFloat LineFlowIntensityCurveAsset;

		// Token: 0x040231C2 RID: 143810
		private float LineFlowAnimElapsed = 2000f;

		// Token: 0x040231C3 RID: 143811
		private float LineFlowAnimTriggerCd = 2000f;

		// Token: 0x040231C4 RID: 143812
		private float LastBarPercent;

		// Token: 0x0200C221 RID: 49697
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403BD27 RID: 245031
			NormalItem,
			// Token: 0x0403BD28 RID: 245032
			NormalFullLightItem,
			// Token: 0x0403BD29 RID: 245033
			NormalLightItem,
			// Token: 0x0403BD2A RID: 245034
			NormalActivateItem,
			// Token: 0x0403BD2B RID: 245035
			SlotBarItemNormal,
			// Token: 0x0403BD2C RID: 245036
			RedItem,
			// Token: 0x0403BD2D RID: 245037
			SlotBarItemRed,
			// Token: 0x0403BD2E RID: 245038
			RedExtraBarSprite,
			// Token: 0x0403BD2F RID: 245039
			TexLineFlow,
			// Token: 0x0403BD30 RID: 245040
			NiaMax,
			// Token: 0x0403BD31 RID: 245041
			NiaGlitchS,
			// Token: 0x0403BD32 RID: 245042
			NiaLightItem,
			// Token: 0x0403BD33 RID: 245043
			NiaGlitchBig,
			// Token: 0x0403BD34 RID: 245044
			AnimActivate,
			// Token: 0x0403BD35 RID: 245045
			AnimNormalFull,
			// Token: 0x0403BD36 RID: 245046
			AnimRed,
			// Token: 0x0403BD37 RID: 245047
			AnimBackNormal
		}

		// Token: 0x0200C222 RID: 49698
		[NullableContext(0)]
		private enum EState
		{
			// Token: 0x0403BD39 RID: 245049
			Normal,
			// Token: 0x0403BD3A RID: 245050
			NormalActivate,
			// Token: 0x0403BD3B RID: 245051
			RedOverclock,
			// Token: 0x0403BD3C RID: 245052
			RedWeak
		}
	}
}
