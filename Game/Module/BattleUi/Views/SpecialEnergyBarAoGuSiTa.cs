using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060AC RID: 24748
	[NullableContext(2)]
	[Nullable(0)]
	public class SpecialEnergyBarAoGuSiTa : SpecialEnergyBarBase
	{
		// Token: 0x0603E7BF RID: 255935 RVA: 0x00FF8B00 File Offset: 0x00FF6D00
		protected unsafe override void OnRegisterComponent()
		{
			int num = 18;
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
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUISliderComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
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
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUINiagara));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E7C0 RID: 255936 RVA: 0x00FF8D84 File Offset: 0x00FF6F84
		protected override void OnInitData()
		{
			this.ConfigList.Add(this.Config);
			this.ConfigList.Add(ModelBase<BattleUiModel>.Instance.SpecialEnergyBarData.GetSpecialEnergyBarInfo(130601));
			this.ConfigList.Add(ModelBase<BattleUiModel>.Instance.SpecialEnergyBarData.GetSpecialEnergyBarInfo(130602));
			this.UltraConfig = ModelBase<BattleUiModel>.Instance.SpecialEnergyBarData.GetSpecialEnergyBarInfo(130603);
			this.AttributeId = (EAttributeType)this.UltraConfig.AttributeId;
			this.MaxAttributeId = (EAttributeType)this.UltraConfig.MaxAttributeId;
			this.WarnTime = this.UltraConfig.ExtraFloatParams[0] * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
		}

		// Token: 0x0603E7C1 RID: 255937 RVA: 0x00FF8E40 File Offset: 0x00FF7040
		protected override UniTask OnBeforeStartAsync()
		{
			SpecialEnergyBarAoGuSiTa.<OnBeforeStartAsync>d__22 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SpecialEnergyBarAoGuSiTa.<OnBeforeStartAsync>d__22>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603E7C2 RID: 255938 RVA: 0x00FF8E84 File Offset: 0x00FF7084
		protected UniTask InitBarItem()
		{
			SpecialEnergyBarAoGuSiTa.<InitBarItem>d__23 <InitBarItem>d__;
			<InitBarItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitBarItem>d__.<>4__this = this;
			<InitBarItem>d__.<>1__state = -1;
			<InitBarItem>d__.<>t__builder.Start<SpecialEnergyBarAoGuSiTa.<InitBarItem>d__23>(ref <InitBarItem>d__);
			return <InitBarItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603E7C3 RID: 255939 RVA: 0x00FF8EC8 File Offset: 0x00FF70C8
		[NullableContext(1)]
		protected override UniTask InitKeyItem(UUIItem keyItemContainer)
		{
			SpecialEnergyBarAoGuSiTa.<InitKeyItem>d__24 <InitKeyItem>d__;
			<InitKeyItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitKeyItem>d__.<>4__this = this;
			<InitKeyItem>d__.keyItemContainer = keyItemContainer;
			<InitKeyItem>d__.<>1__state = -1;
			<InitKeyItem>d__.<>t__builder.Start<SpecialEnergyBarAoGuSiTa.<InitKeyItem>d__24>(ref <InitKeyItem>d__);
			return <InitKeyItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603E7C4 RID: 255940 RVA: 0x00FF8F14 File Offset: 0x00FF7114
		private UniTask LoadCurve()
		{
			SpecialEnergyBarAoGuSiTa.<LoadCurve>d__25 <LoadCurve>d__;
			<LoadCurve>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadCurve>d__.<>4__this = this;
			<LoadCurve>d__.<>1__state = -1;
			<LoadCurve>d__.<>t__builder.Start<SpecialEnergyBarAoGuSiTa.<LoadCurve>d__25>(ref <LoadCurve>d__);
			return <LoadCurve>d__.<>t__builder.Task;
		}

		// Token: 0x0603E7C5 RID: 255941 RVA: 0x00FF8F58 File Offset: 0x00FF7158
		protected override void OnStart()
		{
			base.InitTweenAnim(14);
			base.InitTweenAnim(15);
			base.InitTweenAnim(16);
			this.UltraRiseEffect = new BattleUiNiagaraItem(base.GetUiNiagara(17));
			this.UltraRiseEffect.Duration = 500f;
			UUIItem item = base.GetItem(10);
			if (item != null)
			{
				item.SetAlpha(1f);
			}
			BaseTagComponent tagComponent = this.TagComponent;
			bool isUltra = tagComponent != null && tagComponent.HasTag(SpecialEnergyBarAoGuSiTa.UltraTag);
			this.RefreshUltraState(isUltra, true);
			this.OnAttributeChangedB(true);
			BaseTagComponent tagComponent2 = this.TagComponent;
			int count = (tagComponent2 != null) ? tagComponent2.GetTagCount(SpecialEnergyBarAoGuSiTa.EnergyTag) : 0;
			this.OnEnergyTagChangedC(count, true);
			this.RefreshBarPercent(true);
			this.RefreshKeyItem();
			BattleUiRoleData roleData = this.RoleData;
			Entity entity;
			if (roleData == null)
			{
				entity = null;
			}
			else
			{
				EntityHandle entityHandle = roleData.EntityHandle;
				entity = ((entityHandle != null) ? entityHandle.Entity : null);
			}
			this.Entity = entity;
		}

		// Token: 0x0603E7C6 RID: 255942 RVA: 0x00FF9030 File Offset: 0x00FF7230
		protected override void OnBeforeDestroy()
		{
			if (this.UltraRiseEffect != null)
			{
				this.UltraRiseEffect.Stop();
				this.UltraRiseEffect = null;
			}
			base.OnBeforeDestroy();
		}

		// Token: 0x0603E7C7 RID: 255943 RVA: 0x00FF9052 File Offset: 0x00FF7252
		protected override void ClearAllTweenAnim()
		{
			base.StopTweenAnim(16);
			base.ClearAllTweenAnim();
		}

		// Token: 0x0603E7C8 RID: 255944 RVA: 0x00FF9064 File Offset: 0x00FF7264
		protected override void AddEvents()
		{
			base.AddEvents();
			base.ListenForTagAddOrRemoveChanged(SpecialEnergyBarAoGuSiTa.UltraTag, new BaseTagComponent.TTagSwitchedCallback(this.OnUltraTagChange));
			base.ListenForTagCountChanged(SpecialEnergyBarAoGuSiTa.EnergyTag, new BaseTagComponent.TTagChangedCallback(this.OnEnergyTagChange));
			base.ListenForAttributeChanged((EAttributeType)this.ConfigList[1].AttributeId, new Action<EAttributeType, float, float>(this.AttributeChangedB));
			base.ListenForAttributeChanged((EAttributeType)this.ConfigList[1].MaxAttributeId, new Action<EAttributeType, float, float>(this.MaxAttributeChangedB));
			if (this.Entity != null)
			{
				Singleton<EventSystem>.Instance.AddWithTarget<bool, float>(this.Entity, EEventName.OnAbsoluteTimeStop, new Action<bool, float>(this.OnAbsoluteTimeStop));
			}
		}

		// Token: 0x0603E7C9 RID: 255945 RVA: 0x00FF9118 File Offset: 0x00FF7318
		protected override void RemoveEvents()
		{
			base.RemoveEvents();
			base.RemoveListenAttributeChanged((EAttributeType)this.ConfigList[1].AttributeId, new Action<EAttributeType, float, float>(this.AttributeChangedB));
			base.RemoveListenAttributeChanged((EAttributeType)this.ConfigList[1].MaxAttributeId, new Action<EAttributeType, float, float>(this.MaxAttributeChangedB));
			if (this.Entity != null)
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget(this.Entity, EEventName.OnAbsoluteTimeStop, new Action<bool, float>(this.OnAbsoluteTimeStop));
			}
		}

		// Token: 0x0603E7CA RID: 255946 RVA: 0x00FF919B File Offset: 0x00FF739B
		private void OnUltraTagChange(int tagId, bool tagExist)
		{
			this.RefreshUltraState(tagExist, false);
		}

		// Token: 0x0603E7CB RID: 255947 RVA: 0x00FF91A5 File Offset: 0x00FF73A5
		private void OnEnergyTagChange(int count, int tagId, int exactTagId, int oldCount)
		{
			this.OnEnergyTagChangedC(count, false);
		}

		// Token: 0x0603E7CC RID: 255948 RVA: 0x00FF91AF File Offset: 0x00FF73AF
		private void AttributeChangedB(EAttributeType attributeId, float newValue, float oldValue)
		{
			this.OnAttributeChangedB(false);
		}

		// Token: 0x0603E7CD RID: 255949 RVA: 0x00FF91B8 File Offset: 0x00FF73B8
		private void MaxAttributeChangedB(EAttributeType attributeId, float newValue, float oldValue)
		{
			this.OnAttributeChangedB(false);
		}

		// Token: 0x0603E7CE RID: 255950 RVA: 0x00FF91C4 File Offset: 0x00FF73C4
		protected void OnAttributeChangedB(bool isStart = false)
		{
			float currentValue = this.AttributeComponent.GetCurrentValue((EAttributeType)this.ConfigList[1].AttributeId);
			float currentValue2 = this.AttributeComponent.GetCurrentValue((EAttributeType)this.ConfigList[1].MaxAttributeId);
			float fillAmount = 0f;
			if (currentValue2 > 0f)
			{
				fillAmount = currentValue / currentValue2;
			}
			UUITexture texture = base.GetTexture(3);
			if (texture != null)
			{
				texture.SetFillAmount(fillAmount);
			}
			bool flag = currentValue >= currentValue2;
			if (this.IsEnergyFullB == flag && !isStart)
			{
				return;
			}
			this.IsEnergyFullB = flag;
			if (texture != null)
			{
				texture.SetUIActive(!flag);
			}
			UUIItem item = base.GetItem(9);
			if (item != null)
			{
				item.SetUIActive(flag);
			}
			if (flag)
			{
				base.StopTweenAnim(15);
				base.PlayTweenAnim(14);
			}
			else
			{
				base.StopTweenAnim(14);
				base.PlayTweenAnim(15);
			}
			if (!isStart)
			{
				this.RefreshKeyItem();
			}
		}

		// Token: 0x0603E7CF RID: 255951 RVA: 0x00FF92A0 File Offset: 0x00FF74A0
		protected void OnEnergyTagChangedC(int count, bool isStart = false)
		{
			this.RefreshCountEnergyC(Math.Min(count, 2), isStart);
		}

		// Token: 0x0603E7D0 RID: 255952 RVA: 0x00FF92B0 File Offset: 0x00FF74B0
		private void RefreshCountEnergyC(int count, bool isStart = false)
		{
			if (this.CountEnergyC == count && !isStart)
			{
				return;
			}
			this.CountEnergyC = count;
			UUIItem item = base.GetItem(1);
			if (item != null)
			{
				item.SetUIActive(count > 0);
			}
			UUIItem item2 = base.GetItem(2);
			if (item2 != null)
			{
				item2.SetUIActive(count > 1);
			}
			if (!isStart)
			{
				this.RefreshKeyItem();
			}
		}

		// Token: 0x0603E7D1 RID: 255953 RVA: 0x00FF9306 File Offset: 0x00FF7506
		protected override void OnAttributeChanged()
		{
			base.OnAttributeChanged();
			if (this.PercentMachine.GetTargetPercent() > 0f)
			{
				BattleUiNiagaraItem ultraRiseEffect = this.UltraRiseEffect;
				if (ultraRiseEffect == null)
				{
					return;
				}
				ultraRiseEffect.Play();
			}
		}

		// Token: 0x0603E7D2 RID: 255954 RVA: 0x00FF9330 File Offset: 0x00FF7530
		protected override void OnBarPercentChanged()
		{
			this.RefreshBarPercent(false);
		}

		// Token: 0x0603E7D3 RID: 255955 RVA: 0x00FF933C File Offset: 0x00FF753C
		private void RefreshBarPercent(bool isStart = false)
		{
			float curPercent = this.PercentMachine.GetCurPercent();
			base.GetTexture(5).SetFillAmount(curPercent);
			base.GetSlider(8).SetValue(curPercent, true);
			float num = -207f + 428f * curPercent;
			UCurveFloat ultraCurve = this.UltraCurve;
			float anchorOffsetY = (ultraCurve != null) ? ultraCurve.GetFloatValue(num) : curPercent;
			UUINiagara uiNiagara = base.GetUiNiagara(12);
			uiNiagara.SetAnchorOffsetX(num);
			uiNiagara.SetAnchorOffsetY(anchorOffsetY);
			this.RefreshUltraEnergyFull(curPercent >= 1f, isStart);
			bool keyEnable = this.GetKeyEnable();
			SpecialEnergyBarKeyItem keyItem = this.KeyItem;
			if (keyItem == null)
			{
				return;
			}
			keyItem.RefreshKeyEnable(keyEnable, isStart);
		}

		// Token: 0x0603E7D4 RID: 255956 RVA: 0x00FF93D4 File Offset: 0x00FF75D4
		private void RefreshUltraEnergyFull(bool isFull, bool isStart = false)
		{
			if (this.IsUltraEnergyFull == isFull && !isStart)
			{
				return;
			}
			this.IsUltraEnergyFull = isFull;
			base.GetTexture(5).SetUIActive(!isFull);
			base.GetItem(7).SetUIActive(!isFull);
			base.GetUiNiagara(12).SetUIActive(!isFull);
			base.GetItem(11).SetUIActive(isFull);
		}

		// Token: 0x0603E7D5 RID: 255957 RVA: 0x00FF9434 File Offset: 0x00FF7634
		private void RefreshKeyItem()
		{
			if (this.CountEnergyC > 1)
			{
				SpecialEnergyBarAoGuSiTaSlot barItem = this.BarItem;
				if (barItem == null)
				{
					return;
				}
				barItem.SetKeyItemType(2);
				return;
			}
			else if (this.IsEnergyFullB)
			{
				SpecialEnergyBarAoGuSiTaSlot barItem2 = this.BarItem;
				if (barItem2 == null)
				{
					return;
				}
				barItem2.SetKeyItemType(1);
				return;
			}
			else
			{
				SpecialEnergyBarAoGuSiTaSlot barItem3 = this.BarItem;
				if (barItem3 == null)
				{
					return;
				}
				barItem3.SetKeyItemType(0);
				return;
			}
		}

		// Token: 0x0603E7D6 RID: 255958 RVA: 0x00FF9487 File Offset: 0x00FF7687
		private void RefreshUltraState(bool isUltra, bool isStart = false)
		{
			if (this.IsUltra == isUltra && !isStart)
			{
				return;
			}
			this.IsUltra = isUltra;
			UUIItem item = base.GetItem(0);
			if (item != null)
			{
				item.SetUIActive(!isUltra);
			}
			UUIItem item2 = base.GetItem(10);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(isUltra);
		}

		// Token: 0x0603E7D7 RID: 255959 RVA: 0x00FF94C6 File Offset: 0x00FF76C6
		private void PlayWarnAnim(bool bPlay)
		{
			if (this.IsPlayWarnAnim == bPlay)
			{
				return;
			}
			this.IsPlayWarnAnim = bPlay;
			if (bPlay)
			{
				base.PlayTweenAnim(16);
				return;
			}
			base.StopTweenAnim(16);
			UUIItem item = base.GetItem(10);
			if (item == null)
			{
				return;
			}
			item.SetAlpha(1f);
		}

		// Token: 0x0603E7D8 RID: 255960 RVA: 0x00FF9504 File Offset: 0x00FF7704
		public override void Tick(float delta)
		{
			base.Tick(delta);
			SpecialEnergyBarAoGuSiTaSlot barItem = this.BarItem;
			if (barItem != null)
			{
				barItem.Tick(delta);
			}
			if (!this.IsUltra)
			{
				this.PlayWarnAnim(false);
				return;
			}
			if (!TimerSystem.Instance.Has(this.TimerHandle))
			{
				this.PlayWarnAnim(false);
				return;
			}
			float nextRemainTime = TimerSystem.Instance.GetNextRemainTime(this.TimerHandle);
			if (nextRemainTime <= 0f)
			{
				this.PlayWarnAnim(false);
				return;
			}
			this.PlayWarnAnim(nextRemainTime < this.WarnTime);
		}

		// Token: 0x0603E7D9 RID: 255961 RVA: 0x00FF9584 File Offset: 0x00FF7784
		private void OnAbsoluteTimeStop(bool open, float duration)
		{
			if (open)
			{
				this.TimerHandle = TimerSystem.Instance.Delay(delegate(float _)
				{
					this.TimerHandle = null;
				}, duration * (float)Singleton<TimeUtil>.Instance.InverseMillisecond, null, null, true, 1f);
				return;
			}
			if (TimerSystem.Instance.Has(this.TimerHandle))
			{
				TimerSystem.Instance.Remove(this.TimerHandle);
				this.TimerHandle = null;
			}
		}

		// Token: 0x04023061 RID: 143457
		private const float EFFECT_BASE_PERCENT = 0.4390244f;

		// Token: 0x04023062 RID: 143458
		[StaticVariableRuleIgnore]
		private static readonly int UltraTag = GameplayTagDefine.EGameplayTagId["角色.R2T1AogusitaMd10011.战斗逻辑.大循环充能X"];

		// Token: 0x04023063 RID: 143459
		[StaticVariableRuleIgnore]
		private static readonly int EnergyTag = GameplayTagDefine.EGameplayTagId["角色.R2T1AogusitaMd10011.战斗逻辑.锁开可解放"];

		// Token: 0x04023064 RID: 143460
		[Nullable(1)]
		private const string CURVE_PATH = "/Game/Aki/UI/UIResources/UiFight/Curve/Ani_UiItem_BarAogusita/Curve_UiItem_BarAogusita_Y.Curve_UiItem_BarAogusita_Y";

		// Token: 0x04023065 RID: 143461
		private const float X_MIN = -207f;

		// Token: 0x04023066 RID: 143462
		private const float X_MAX = 221f;

		// Token: 0x04023067 RID: 143463
		[Nullable(1)]
		private readonly List<SpecialEnergyBarInfo> ConfigList = new List<SpecialEnergyBarInfo>();

		// Token: 0x04023068 RID: 143464
		private SpecialEnergyBarAoGuSiTaSlot BarItem;

		// Token: 0x04023069 RID: 143465
		private SpecialEnergyBarInfo UltraConfig;

		// Token: 0x0402306A RID: 143466
		private UCurveFloat UltraCurve;

		// Token: 0x0402306B RID: 143467
		private bool IsUltra;

		// Token: 0x0402306C RID: 143468
		private bool IsUltraEnergyFull;

		// Token: 0x0402306D RID: 143469
		private bool IsEnergyFullB;

		// Token: 0x0402306E RID: 143470
		private int CountEnergyC;

		// Token: 0x0402306F RID: 143471
		private TimerHandle TimerHandle;

		// Token: 0x04023070 RID: 143472
		private bool IsPlayWarnAnim;

		// Token: 0x04023071 RID: 143473
		private float WarnTime;

		// Token: 0x04023072 RID: 143474
		private BattleUiNiagaraItem UltraRiseEffect;

		// Token: 0x04023073 RID: 143475
		private Entity Entity;

		// Token: 0x0200C1C6 RID: 49606
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403BA9F RID: 244383
			NormalItem,
			// Token: 0x0403BAA0 RID: 244384
			BottomLightLeftItem,
			// Token: 0x0403BAA1 RID: 244385
			BottomLightRightItem,
			// Token: 0x0403BAA2 RID: 244386
			CircleBarTexture,
			// Token: 0x0403BAA3 RID: 244387
			SlotBarItem,
			// Token: 0x0403BAA4 RID: 244388
			UltraBarTexture,
			// Token: 0x0403BAA5 RID: 244389
			UltraLightItem,
			// Token: 0x0403BAA6 RID: 244390
			UltraSliderItem,
			// Token: 0x0403BAA7 RID: 244391
			UltraSlider,
			// Token: 0x0403BAA8 RID: 244392
			CirclePointItem,
			// Token: 0x0403BAA9 RID: 244393
			UltraItem,
			// Token: 0x0403BAAA RID: 244394
			UltraMaxItem,
			// Token: 0x0403BAAB RID: 244395
			UltraGlowNiagara,
			// Token: 0x0403BAAC RID: 244396
			KeyItem,
			// Token: 0x0403BAAD RID: 244397
			AniIn,
			// Token: 0x0403BAAE RID: 244398
			AniOut,
			// Token: 0x0403BAAF RID: 244399
			AniWarning,
			// Token: 0x0403BAB0 RID: 244400
			UltraRiseNiagara
		}
	}
}
