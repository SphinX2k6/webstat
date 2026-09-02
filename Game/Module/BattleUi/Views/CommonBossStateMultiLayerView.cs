using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using Aki.TDConfigMgr.Component;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FF0 RID: 24560
	[NullableContext(1)]
	[Nullable(0)]
	public class CommonBossStateMultiLayerView : CommonBossStateView
	{
		// Token: 0x0603DD34 RID: 253236 RVA: 0x00FC1EFE File Offset: 0x00FC00FE
		protected override string GetResourceId()
		{
			return "UiItem_BossStateMultiLayer_Prefab";
		}

		// Token: 0x0603DD35 RID: 253237 RVA: 0x00FC1F08 File Offset: 0x00FC0108
		protected override void OnRegisterComponent()
		{
			base.OnRegisterComponent();
			this.ComponentRegisterInfos.AddRange(new <>z__ReadOnlyArray<ValueTuple<int, Type>>(new ValueTuple<int, Type>[]
			{
				new ValueTuple<int, Type>(40, typeof(UUISprite)),
				new ValueTuple<int, Type>(41, typeof(UUIItem)),
				new ValueTuple<int, Type>(42, typeof(UUIText)),
				new ValueTuple<int, Type>(43, typeof(UUIItem)),
				new ValueTuple<int, Type>(44, typeof(UUIItem))
			}));
		}

		// Token: 0x0603DD36 RID: 253238 RVA: 0x00FC1FAC File Offset: 0x00FC01AC
		protected override void OnStart()
		{
			base.OnStart();
			this.BgBar = base.GetSprite(40);
			this.TextNum = base.GetText(42);
			this.SingleFadeDuration = ConfigCommonParamById.GetFloatConfig("BossHpBarMultiLayer_SingleFadeDuration").Value;
			this.MinDurationPerSegment = ConfigCommonParamById.GetFloatConfig("BossHpBarMultiLayer_MinDurationPerSegment").Value;
			this.MaxFadeDuration = ConfigCommonParamById.GetFloatConfig("BossHpBarMultiLayer_MaxFadeDuration").Value;
		}

		// Token: 0x0603DD37 RID: 253239 RVA: 0x00FC2024 File Offset: 0x00FC0224
		private IReadOnlyList<string> GetHpBarColorConfig()
		{
			Entity entity = base.GetEntity();
			CreatureDataComponent creatureDataComponent = (entity != null) ? entity.GetComponent<CreatureDataComponent>() : null;
			MonsterComponent monsterComponent = (creatureDataComponent != null) ? creatureDataComponent.GetMonsterComponent() : null;
			if (monsterComponent == null)
			{
				return ConfigCommonParamById.GetStringArrayConfig("BossHpBarMultiLayer_Colors");
			}
			if (monsterComponent.LifeMaxCustomizationId == null || monsterComponent.LifeMaxCustomizationId.Value == 0)
			{
				return ConfigCommonParamById.GetStringArrayConfig("BossHpBarMultiLayer_Colors");
			}
			LifeMaxCustomization? config = ConfigLifeMaxCustomizationById.GetConfig(monsterComponent.LifeMaxCustomizationId.Value, true);
			if (config == null || config.Value.CustomColorSetLength <= 0)
			{
				return ConfigCommonParamById.GetStringArrayConfig("BossHpBarMultiLayer_Colors");
			}
			string[] array = new string[config.Value.CustomColorSetLength];
			for (int i = 0; i < config.Value.CustomColorSetLength; i++)
			{
				array[i] = config.Value.CustomColorSet(i);
			}
			return array;
		}

		// Token: 0x0603DD38 RID: 253240 RVA: 0x00FC2114 File Offset: 0x00FC0314
		private void InitBarColor()
		{
			IReadOnlyList<string> hpBarColorConfig = this.GetHpBarColorConfig();
			string stringConfig = ConfigCommonParamById.GetStringConfig("BossHpBarMultiLayer_WhiteBar");
			this.NumColor = hpBarColorConfig.Count;
			this.IsColorMode = (hpBarColorConfig.Count > 0 && !hpBarColorConfig[0].StartsWith("/Game/"));
			FColor fcolor = FColor.FromHex("ffffffff");
			for (int i = 0; i < hpBarColorConfig.Count; i++)
			{
				if (this.IsColorMode)
				{
					this.BarColors.Add(FColor.FromHex(hpBarColorConfig[i]));
				}
				else
				{
					this.BgBar.SetColor(fcolor);
					base.SetHpBarColor(fcolor);
					int localI = i;
					this.BarSprites.Add(null);
					this.LoadHandles.Add(-1);
					this.LoadHandles[localI] = Singleton<ResourceSystem>.Instance.LoadAsync<ULGUISpriteData_BaseObject>(hpBarColorConfig[localI], delegate([Nullable(2)] ULGUISpriteData_BaseObject sprite, string _)
					{
						this.LoadHandles[localI] = -1;
						if (sprite == null || !sprite.IsValid())
						{
							return;
						}
						if (this.IsInvalid)
						{
							return;
						}
						this.BarSprites[localI] = sprite;
						if (this.LoadHandles.Count == 0 && this.CurrentSegmentNum != 0)
						{
							this.BarSprites.Reverse();
							this.ResetCurrentSegment();
						}
					}, 100, "js_undefined");
				}
			}
			if (this.IsColorMode)
			{
				this.BarColors.Reverse();
				this.LoadWhiteBarHd = Singleton<ResourceSystem>.Instance.LoadAsync<ULGUISpriteData_BaseObject>(stringConfig, delegate([Nullable(2)] ULGUISpriteData_BaseObject sprite, string _)
				{
					this.LoadWhiteBarHd = 0;
					if (sprite == null || !sprite.IsValid())
					{
						return;
					}
					if (this.IsInvalid)
					{
						return;
					}
					this.BgBar.SetSprite(sprite, true);
					this.BgBar.SetHorizontalStretch(new FVector2D(0f, 0f));
					base.SetHpBarSprite(sprite);
					this.ResetCurrentSegment();
				}, 100, "js_undefined");
			}
		}

		// Token: 0x0603DD39 RID: 253241 RVA: 0x00FC225E File Offset: 0x00FC045E
		protected override void OnActivate()
		{
			base.OnActivate();
			this.InitBarColor();
			this.InitState();
		}

		// Token: 0x0603DD3A RID: 253242 RVA: 0x00FC2272 File Offset: 0x00FC0472
		protected override void OnDeactivate()
		{
			this.IsDeactivate = true;
			HeadStateWeaknessItem weaknessItem = this.WeaknessItem;
			if (weaknessItem != null)
			{
				weaknessItem.DisableRecycleItem();
			}
			base.OnDeactivate();
		}

		// Token: 0x0603DD3B RID: 253243 RVA: 0x00FC2292 File Offset: 0x00FC0492
		protected override void OnAfterHide()
		{
			if (this.IsDeactivate)
			{
				base.Destroy(null);
			}
		}

		// Token: 0x0603DD3C RID: 253244 RVA: 0x00FC22A4 File Offset: 0x00FC04A4
		protected override void OnBeforeDestroy()
		{
			this.IsInvalid = true;
			foreach (int num in this.LoadHandles)
			{
				if (num != -1)
				{
					Singleton<ResourceSystem>.Instance.CancelAsyncLoad(num);
				}
			}
			this.LoadHandles.Clear();
			if (this.LoadWhiteBarHd > 0)
			{
				Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.LoadWhiteBarHd);
			}
			base.OnBeforeDestroy();
		}

		// Token: 0x0603DD3D RID: 253245 RVA: 0x00FC2330 File Offset: 0x00FC0530
		protected override bool DestroyOverride()
		{
			return false;
		}

		// Token: 0x0603DD3E RID: 253246 RVA: 0x00FC2333 File Offset: 0x00FC0533
		protected override void InitAllTweenAnim()
		{
			base.InitAllTweenAnim();
			base.InitTweenAnim(43);
			base.InitTweenAnim(44);
		}

		// Token: 0x0603DD3F RID: 253247 RVA: 0x00FC234C File Offset: 0x00FC054C
		private unsafe void InitState()
		{
			Entity entity = base.GetEntity();
			CreatureDataComponent creatureDataComponent = (entity != null) ? entity.GetComponent<CreatureDataComponent>() : null;
			MonsterComponent monsterComponent = (creatureDataComponent != null) ? creatureDataComponent.GetMonsterComponent() : null;
			if (monsterComponent == null)
			{
				return;
			}
			if (monsterComponent.LifeMaxCustomizationId == null || monsterComponent.LifeMaxCustomizationId.Value == 0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Battle;
				ELogAuthor author = ELogAuthor.HWR;
				string message = "Boss多管血条:缺少配表id";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("pbDataId", (creatureDataComponent != null) ? new int?(creatureDataComponent.GetPbDataId()) : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("serverId", (creatureDataComponent != null) ? new long?(creatureDataComponent.GetCreatureDataId()) : null);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			LifeMaxCustomization? config = ConfigLifeMaxCustomizationById.GetConfig(monsterComponent.LifeMaxCustomizationId.Value, true);
			if (config == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Battle;
				ELogAuthor author2 = ELogAuthor.HYJ;
				string message2 = "Boss多管血条:id没有对应配置";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("pbDataId", (creatureDataComponent != null) ? new int?(creatureDataComponent.GetPbDataId()) : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("serverId", (creatureDataComponent != null) ? new long?(creatureDataComponent.GetCreatureDataId()) : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("LifeMaxCustomizationId", monsterComponent.LifeMaxCustomizationId);
				instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
				return;
			}
			if (config.Value.LifeCustomType == 0)
			{
				this.HpPerSegment = (double)config.Value.SingleTubeLife;
				this.HpLimit = (double)(config.Value.SingleTubeLife * config.Value.LifeCount);
			}
			else
			{
				if (config.Value.LifeCustomType != 1)
				{
					Log instance3 = Singleton<Log>.Instance;
					ELogModule module3 = ELogModule.Battle;
					ELogAuthor author3 = ELogAuthor.HWR;
					string message3 = "Boss多管血条:非法的血量定制类型";
					<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray4<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("pbDataId", (creatureDataComponent != null) ? new int?(creatureDataComponent.GetPbDataId()) : null);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("serverId", (creatureDataComponent != null) ? new long?(creatureDataComponent.GetCreatureDataId()) : null);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("LifeMaxCustomizationId", monsterComponent.LifeMaxCustomizationId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 3) = new ValueTuple<string, object>("LifeCustomType", config.Value.LifeCustomType);
					instance3.Error(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 4));
					return;
				}
				int num = ModelBase<WorldLevelModel>.Instance.CurWorldLevel - 1;
				if (config.Value.LifeCountAttrLength <= num || config.Value.SingleTubeLifeArrLength <= num)
				{
					Log instance4 = Singleton<Log>.Instance;
					ELogModule module4 = ELogModule.Battle;
					ELogAuthor author4 = ELogAuthor.HYJ;
					string message4 = "Boss多管血条:血量定制类型 1, 血量信息数组长度不合法";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray4 = default(<>y__InlineArray3<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 0) = new ValueTuple<string, object>("pbDataId", (creatureDataComponent != null) ? new int?(creatureDataComponent.GetPbDataId()) : null);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 1) = new ValueTuple<string, object>("serverId", (creatureDataComponent != null) ? new long?(creatureDataComponent.GetCreatureDataId()) : null);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 2) = new ValueTuple<string, object>("LifeMaxCustomizationId", monsterComponent.LifeMaxCustomizationId);
					instance4.Error(module4, author4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray4, 3));
					return;
				}
				this.HpPerSegment = (double)config.Value.SingleTubeLifeArr(num);
				this.HpLimit = (double)(config.Value.SingleTubeLifeArr(num) * config.Value.LifeCountAttr(num));
			}
			Log instance5 = Singleton<Log>.Instance;
			ELogModule module5 = ELogModule.Battle;
			ELogAuthor author5 = ELogAuthor.HWR;
			string message5 = "Boss多管血条";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray5 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 0) = new ValueTuple<string, object>("LifeMaxCustomizationId", monsterComponent.LifeMaxCustomizationId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 1) = new ValueTuple<string, object>("每管hp", this.HpPerSegment);
			instance5.Info(module5, author5, message5, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray5, 2));
			double hpAttributeValue = this.GetHpAttributeValue(EAttributeType.Life);
			double hpAttributeValue2 = this.GetHpAttributeValue(EAttributeType.LifeMax);
			if (hpAttributeValue2 < this.HpPerSegment)
			{
				Log instance6 = Singleton<Log>.Instance;
				ELogModule module6 = ELogModule.Battle;
				ELogAuthor author6 = ELogAuthor.HWR;
				string message6 = "Boss多管血条:分段值大于了最大血值:";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray6 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray6, 0) = new ValueTuple<string, object>("", this.HpPerSegment);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray6, 1) = new ValueTuple<string, object>("", hpAttributeValue2);
				instance6.Warn(module6, author6, message6, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray6, 2));
				this.HpPerSegment = hpAttributeValue2;
			}
			this.CurrentSegmentNum = (int)Math.Ceiling(hpAttributeValue / this.HpPerSegment);
			this.TargetSegmentNum = this.CurrentSegmentNum;
			this.ResetCurrentSegment();
			base.RefreshHpAndShield(false);
		}

		// Token: 0x0603DD40 RID: 253248 RVA: 0x00FC289E File Offset: 0x00FC0A9E
		protected override void OnBossHeathChanged(EAttributeType attributeId, float newValue, float oldValue)
		{
			this.CheckSegment((int)Math.Ceiling((double)newValue / this.HpPerSegment));
			base.RefreshHpAndShield(true);
		}

		// Token: 0x0603DD41 RID: 253249 RVA: 0x00FC28BC File Offset: 0x00FC0ABC
		private double GetHpAttributeValue(EAttributeType attributeId)
		{
			float currentAttributeValueById = base.GetCurrentAttributeValueById(attributeId);
			if (this.HpLimit > 0.0 && (double)currentAttributeValueById > this.HpLimit)
			{
				return this.HpLimit;
			}
			return (double)currentAttributeValueById;
		}

		// Token: 0x0603DD42 RID: 253250 RVA: 0x00FC28F5 File Offset: 0x00FC0AF5
		private float GetHpPercent()
		{
			return (float)(this.GetHpAttributeValue(EAttributeType.Life) % (this.HpPerSegment + 0.0010000000474974513) / this.HpPerSegment);
		}

		// Token: 0x0603DD43 RID: 253251 RVA: 0x00FC2918 File Offset: 0x00FC0B18
		[NullableContext(0)]
		[return: TupleElementNames(new string[]
		{
			"hpPercent",
			"shieldPercent"
		})]
		protected override ValueTuple<float, float> GetHpAndShieldPercent()
		{
			if (!this.IsValid())
			{
				return new ValueTuple<float, float>(0f, 0f);
			}
			float hpPercent = this.GetHpPercent();
			float item = 1f;
			float bossShield = base.GetBossShield();
			double hpAttributeValue = this.GetHpAttributeValue(EAttributeType.LifeMax);
			if ((double)bossShield <= hpAttributeValue)
			{
				item = (float)((double)bossShield / hpAttributeValue);
			}
			return new ValueTuple<float, float>(hpPercent, item);
		}

		// Token: 0x0603DD44 RID: 253252 RVA: 0x00FC296C File Offset: 0x00FC0B6C
		protected override void PlayBarAnimation(float hpPercent)
		{
			if (this.SegmentState == CommonBossStateMultiLayerView.ESegmentState.Multi)
			{
				int num = (this.TargetSegmentNum < this.CurrentSegmentNum) ? -1 : 1;
				base.PlayBarAnimation(num != -1);
				return;
			}
			base.PlayBarAnimation(hpPercent);
		}

		// Token: 0x0603DD45 RID: 253253 RVA: 0x00FC29AC File Offset: 0x00FC0BAC
		protected override void SetBarBufferPercent(float pctBuffer, float pctReal)
		{
			if (this.SegmentState == CommonBossStateMultiLayerView.ESegmentState.Multi)
			{
				float num = ((this.TargetSegmentNum < this.CurrentSegmentNum) ? -1 : 1) != -1;
				base.SetBarBufferPercent(Math.Max(pctBuffer, num), num);
				return;
			}
			base.SetBarBufferPercent(pctBuffer, pctReal);
		}

		// Token: 0x0603DD46 RID: 253254 RVA: 0x00FC29F3 File Offset: 0x00FC0BF3
		protected override void SetHpBarPercent(float percent)
		{
			if (this.SegmentState == CommonBossStateMultiLayerView.ESegmentState.Multi)
			{
				return;
			}
			if (percent > this.CurrentBarPercent || this.TargetSegmentNum < this.CurrentSegmentNum)
			{
				this.NextSegment();
			}
			base.SetHpBarPercent(percent);
		}

		// Token: 0x0603DD47 RID: 253255 RVA: 0x00FC2A24 File Offset: 0x00FC0C24
		private void CheckSegment(int newTarget)
		{
			if (newTarget == this.TargetSegmentNum)
			{
				return;
			}
			this.TargetSegmentNum = newTarget;
			int num = Math.Abs(this.CurrentSegmentNum - this.TargetSegmentNum);
			if (this.SegmentState == CommonBossStateMultiLayerView.ESegmentState.Multi)
			{
				float num2 = Math.Max(this.MultiRemainingTime, 0f);
				int num3 = Math.Max((int)Math.Floor((double)((float)num / (num2 / this.MinDurationPerSegment))), 1);
				if (this.SegmentDelta < num3)
				{
					this.SegmentDelta = num3;
				}
			}
			else if (num > 1)
			{
				this.SegmentState = CommonBossStateMultiLayerView.ESegmentState.Multi;
				this.MultiRemainingTime = this.MaxFadeDuration;
				float num4;
				if ((float)num * this.SingleFadeDuration > this.MaxFadeDuration)
				{
					this.SegmentDelta = Math.Max((int)Math.Floor((double)((float)num / (this.MaxFadeDuration / this.MinDurationPerSegment))), 1);
					num4 = this.MinDurationPerSegment;
				}
				else
				{
					num4 = this.SingleFadeDuration;
					this.SegmentDelta = 1;
				}
				int num5 = (this.TargetSegmentNum < this.CurrentSegmentNum) ? -1 : 1;
				float currentBarPercent = this.CurrentBarPercent;
				this.PercentSegment.SetTargetPercent(num5 != -1);
				this.PercentSegment.SetCurrentPercent(currentBarPercent);
				this.PercentSegment.SetDuration(num4 * ((num5 == -1) ? currentBarPercent : (1f - currentBarPercent)));
				this.PercentSegment.UpdateSpeed(true);
			}
			CommonBossStateMultiLayerView.ESegmentState segmentState = this.SegmentState;
		}

		// Token: 0x0603DD48 RID: 253256 RVA: 0x00FC2B7B File Offset: 0x00FC0D7B
		private void ResetCurrentSegment()
		{
			this.UpdateBarColor(this.CurrentSegmentNum);
		}

		// Token: 0x0603DD49 RID: 253257 RVA: 0x00FC2B8C File Offset: 0x00FC0D8C
		private void UpdateBarColor(int num)
		{
			int num2 = (this.TargetSegmentNum < this.CurrentSegmentNum) ? -1 : 1;
			if (!this.ColorInit)
			{
				this.ColorInit = true;
				this.ColorIndex = this.NumColor - 2;
			}
			else if (this.LastDir == num2 && this.CurrentSegmentNum != num)
			{
				this.ColorIndex += num2;
				if (this.ColorIndex < 0)
				{
					this.ColorIndex = this.NumColor - 1;
				}
			}
			this.LastDir = num2;
			int num3 = this.ColorIndex % this.NumColor;
			int num4 = (num3 + num2 < 0) ? (this.NumColor - 1) : ((num3 + num2) % this.NumColor);
			if (this.IsColorMode)
			{
				this.BgBar.SetColor(this.BarColors[(num2 == -1) ? num4 : num3]);
				base.SetHpBarColor(this.BarColors[(num2 == -1) ? num3 : num4]);
			}
			else
			{
				ULGUISpriteData_BaseObject ulguispriteData_BaseObject = this.BarSprites[num4];
				if (ulguispriteData_BaseObject != null && ulguispriteData_BaseObject.IsValid())
				{
					this.BgBar.SetSprite(this.BarSprites[num4], true);
					this.BgBar.SetHorizontalStretch(new FVector2D(0f, 0f));
				}
				base.SetHpBarSprite(this.BarSprites[num3]);
			}
			this.BgBar.SetUIActive(num > 1);
			this.BgBar.SetFillAmount(1f);
			if (this.SegmentState == CommonBossStateMultiLayerView.ESegmentState.Multi)
			{
				base.SetHpBarPercent(num2 == -1);
			}
			else
			{
				base.SetHpBarPercent(this.CurrentBarPercent);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(this.TextNum, "BossPilingActivity_BossHpVesselNum", new <>z__ReadOnlySingleElementList<object>(num));
		}

		// Token: 0x0603DD4A RID: 253258 RVA: 0x00FC2D34 File Offset: 0x00FC0F34
		private void UpdateNumFx(int num, int dir)
		{
			if (this.NextNumFx != num && Singleton<Time>.Instance.Now - this.NextNumTime > 300.0)
			{
				this.NextNumFx = num;
				this.NextNumTime = Singleton<Time>.Instance.Now;
				base.PlayTweenAnim((dir == -1) ? 43 : 44);
			}
		}

		// Token: 0x0603DD4B RID: 253259 RVA: 0x00FC2D90 File Offset: 0x00FC0F90
		private void NextSegment()
		{
			int num = 1;
			if (this.SegmentState == CommonBossStateMultiLayerView.ESegmentState.Multi)
			{
				num = this.SegmentDelta;
			}
			int num2 = (this.TargetSegmentNum < this.CurrentSegmentNum) ? -1 : 1;
			int num3 = this.CurrentSegmentNum + num * num2;
			if (num2 == -1)
			{
				if (num3 < this.TargetSegmentNum)
				{
					num3 = this.TargetSegmentNum;
				}
			}
			else if (num3 > this.TargetSegmentNum)
			{
				num3 = this.TargetSegmentNum;
			}
			if (num3 != this.CurrentSegmentNum)
			{
				this.UpdateBarColor(num3);
				this.UpdateNumFx(num3, num2);
				this.CurrentSegmentNum = num3;
			}
		}

		// Token: 0x0603DD4C RID: 253260 RVA: 0x00FC2E14 File Offset: 0x00FC1014
		private void TickSegmentBar(float delta)
		{
			if (this.PercentSegment.Update(delta))
			{
				this.MultiRemainingTime -= delta;
				float curPercent = this.PercentSegment.GetCurPercent();
				base.SetHpBarPercent(curPercent);
				int num = (this.TargetSegmentNum < this.CurrentSegmentNum) ? -1 : 1;
				if ((num == -1 && curPercent <= 0f) || (num == 1 && curPercent >= 1f))
				{
					this.NextSegment();
					if (this.CurrentSegmentNum != this.TargetSegmentNum)
					{
						this.PercentSegment.SetTargetPercent(num != -1);
						this.PercentSegment.SetCurrentPercent(num == -1);
						this.PercentSegment.SetDuration(this.MinDurationPerSegment);
						this.PercentSegment.UpdateSpeed(true);
						return;
					}
					float hpPercent = this.GetHpPercent();
					this.PercentSegment.SetTargetPercent(hpPercent);
					this.PercentSegment.SetCurrentPercent(num == -1);
					this.PercentSegment.SetDuration(this.MinDurationPerSegment * ((num == -1) ? (1f - hpPercent) : hpPercent));
					this.PercentSegment.UpdateSpeed(true);
					return;
				}
			}
			else if (this.SegmentState == CommonBossStateMultiLayerView.ESegmentState.Multi)
			{
				this.SegmentState = CommonBossStateMultiLayerView.ESegmentState.Single;
				base.RefreshHpAndShield(false);
			}
		}

		// Token: 0x0603DD4D RID: 253261 RVA: 0x00FC2F40 File Offset: 0x00FC1140
		public override void Tick(float delta)
		{
			base.Tick(delta);
			this.TickSegmentBar(delta);
		}

		// Token: 0x04022AC0 RID: 142016
		private CommonBossStateMultiLayerView.ESegmentState SegmentState;

		// Token: 0x04022AC1 RID: 142017
		private double HpPerSegment = 1.0;

		// Token: 0x04022AC2 RID: 142018
		private float MaxFadeDuration = 500f;

		// Token: 0x04022AC3 RID: 142019
		private float MinDurationPerSegment = 100f;

		// Token: 0x04022AC4 RID: 142020
		private float SingleFadeDuration = 100f;

		// Token: 0x04022AC5 RID: 142021
		private double HpLimit;

		// Token: 0x04022AC6 RID: 142022
		private bool IsColorMode = true;

		// Token: 0x04022AC7 RID: 142023
		private int NumColor;

		// Token: 0x04022AC8 RID: 142024
		private readonly List<FColor> BarColors = new List<FColor>();

		// Token: 0x04022AC9 RID: 142025
		[Nullable(new byte[]
		{
			1,
			2
		})]
		private readonly List<ULGUISpriteData_BaseObject> BarSprites = new List<ULGUISpriteData_BaseObject>();

		// Token: 0x04022ACA RID: 142026
		private readonly List<int> LoadHandles = new List<int>();

		// Token: 0x04022ACB RID: 142027
		private int LoadWhiteBarHd;

		// Token: 0x04022ACC RID: 142028
		private int CurrentSegmentNum;

		// Token: 0x04022ACD RID: 142029
		private int TargetSegmentNum;

		// Token: 0x04022ACE RID: 142030
		private readonly ProgressPercentMachine PercentSegment = new ProgressPercentMachine();

		// Token: 0x04022ACF RID: 142031
		private int SegmentDelta = 1;

		// Token: 0x04022AD0 RID: 142032
		private int ColorIndex = -1;

		// Token: 0x04022AD1 RID: 142033
		private bool ColorInit;

		// Token: 0x04022AD2 RID: 142034
		[Nullable(2)]
		private UUISprite BgBar;

		// Token: 0x04022AD3 RID: 142035
		[Nullable(2)]
		private UUIText TextNum;

		// Token: 0x04022AD4 RID: 142036
		private bool IsDeactivate;

		// Token: 0x04022AD5 RID: 142037
		private bool IsInvalid;

		// Token: 0x04022AD6 RID: 142038
		private float MultiRemainingTime;

		// Token: 0x04022AD7 RID: 142039
		private int LastDir;

		// Token: 0x04022AD8 RID: 142040
		private int NextNumFx;

		// Token: 0x04022AD9 RID: 142041
		private double NextNumTime;

		// Token: 0x0200C079 RID: 49273
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403B3C0 RID: 242624
			BarHp = 40,
			// Token: 0x0403B3C1 RID: 242625
			PnlMultiNum,
			// Token: 0x0403B3C2 RID: 242626
			TextNum,
			// Token: 0x0403B3C3 RID: 242627
			AniNumDown,
			// Token: 0x0403B3C4 RID: 242628
			AniNumUp
		}

		// Token: 0x0200C07A RID: 49274
		[NullableContext(0)]
		private enum ESegmentState
		{
			// Token: 0x0403B3C6 RID: 242630
			Single,
			// Token: 0x0403B3C7 RID: 242631
			Multi
		}
	}
}
