using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002096 RID: 8342
[NullableContext(2)]
[Nullable(0)]
public class KingShipCardItem : UiPanelBase
{
	// Token: 0x0600FE8F RID: 65167 RVA: 0x0045D0CC File Offset: 0x0045B2CC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUITexture)),
			new ValueTuple<int, Type>(5, typeof(UUITexture)),
			new ValueTuple<int, Type>(18, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUISprite)),
			new ValueTuple<int, Type>(12, typeof(UUIText)),
			new ValueTuple<int, Type>(13, typeof(UUITexture)),
			new ValueTuple<int, Type>(14, typeof(UUITexture)),
			new ValueTuple<int, Type>(15, typeof(UUITexture)),
			new ValueTuple<int, Type>(16, typeof(UUITexture)),
			new ValueTuple<int, Type>(20, typeof(UUITexture)),
			new ValueTuple<int, Type>(17, typeof(UUITexture)),
			new ValueTuple<int, Type>(21, typeof(UUITexture)),
			new ValueTuple<int, Type>(19, typeof(UUIItem)),
			new ValueTuple<int, Type>(22, typeof(UUIItem))
		};
	}

	// Token: 0x0600FE90 RID: 65168 RVA: 0x0045D2D8 File Offset: 0x0045B4D8
	protected override UniTask OnBeforeStartAsync()
	{
		KingShipCardItem.<OnBeforeStartAsync>d__52 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<KingShipCardItem.<OnBeforeStartAsync>d__52>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600FE91 RID: 65169 RVA: 0x0045D31B File Offset: 0x0045B51B
	protected override void OnBeforeDestroy()
	{
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.Clear();
		}
		this.LevelSequencePlayer = null;
	}

	// Token: 0x0600FE92 RID: 65170 RVA: 0x0045D338 File Offset: 0x0045B538
	protected override void OnStart()
	{
		this.RotationItem = base.GetItem(19);
		this.LocationItem = base.GetItem(18);
		UUIItem rotationItem = this.RotationItem;
		if (rotationItem != null)
		{
			FRotator frotator = this.CacheRotator.ToUeRotator();
			rotationItem.SetUIRelativeRotation(frotator);
		}
		this.RightItem = base.GetItem(8);
		this.LeftItem = base.GetItem(7);
		this.RightTexture = base.GetTexture(5);
		this.LeftTexture = base.GetTexture(4);
		this.LayerTextureA = base.GetTexture(16);
		this.LayerTextureB = base.GetTexture(15);
		this.LayerTextureC = base.GetTexture(14);
		this.LayerTextureD = base.GetTexture(13);
		this.LayerTextureE = base.GetTexture(20);
		this.LayerTextureF = base.GetTexture(17);
		this.LayerTextureG = base.GetTexture(21);
		base.GetItem(9).SetUIActive(false);
		this.CacheBarVector.Y = (double)this.RightTexture.RelativeLocation.Y;
		this.ViewPortPercentage = ConfigCommonParamById.GetFloatConfig("KingShipViewPortPercentage").GetValueOrDefault();
		this.SensitivityPitch = ConfigCommonParamById.GetFloatConfig("KingShipSensitivityPitch").GetValueOrDefault();
		this.GamepadInputRate = ConfigCommonParamById.GetFloatConfig("KingShipGamepadInputRate").GetValueOrDefault();
		this.MobileRotateInputRate = ConfigCommonParamById.GetFloatConfig("KingShipMobileRotateInputRate").GetValueOrDefault();
		this.LocationWhenPitch = ConfigCommonParamById.GetFloatConfig("KingShipXLocationWhenPitch").GetValueOrDefault();
		this.KingShipCardContentTextRotateRate = ConfigCommonParamById.GetFloatConfig("KingShipCardContentTextRotateRate").GetValueOrDefault();
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		this.LevelSequencePlayer.BindSequenceCloseEvent(delegate(string name)
		{
			if (name == "DropL" || name == "DropR")
			{
				Action<bool> onCallBackDropSequence = this.OnCallBackDropSequence;
				if (onCallBackDropSequence != null)
				{
					onCallBackDropSequence(name == "DropR");
				}
				this.CardSequencePlayering++;
				if (!this.IsShowBuffCard)
				{
					base.GetItem(9).SetUIActive(false);
					base.GetItem(22).SetUIActive(false);
					LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
					if (levelSequencePlayer != null)
					{
						levelSequencePlayer.PlayLevelSequenceByName("Flip", false, null, false);
					}
				}
				else
				{
					LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
					if (levelSequencePlayer2 != null)
					{
						levelSequencePlayer2.PlayLevelSequenceByName("FlipB", false, null, false);
					}
				}
				this.ClearCardItemRotation();
			}
			if (name == "ResetL" || name == "ResetR")
			{
				this.ClearCardItemRotation();
			}
			this.CardSequencePlayering--;
		}, false);
	}

	// Token: 0x0600FE93 RID: 65171 RVA: 0x0045D4FC File Offset: 0x0045B6FC
	[NullableContext(1)]
	public void RefreshCardItemByShowTalk(int whoId, string backGroundPath)
	{
		this.IsShowBuffCard = false;
		if (!string.IsNullOrEmpty(backGroundPath))
		{
			this.SetCardBackGroud(backGroundPath);
		}
		Speaker? speaker = (whoId != 0) ? ConfigSpeakerById.GetConfig(whoId, true) : null;
		if (speaker == null)
		{
			return;
		}
		string newText = Singleton<PublicUtil>.Instance.GetConfigTextByTable(ETableText.SpeakerName, new int?(speaker.Value.Id)) ?? "";
		UUIText text = base.GetText(2);
		if (text != null)
		{
			text.SetText(newText, true);
		}
		if (speaker.Value.Title == 0)
		{
			UUIText text2 = base.GetText(3);
			if (text2 != null)
			{
				text2.SetUIActive(false);
			}
		}
		UUIText text3 = base.GetText(3);
		if (text3 != null)
		{
			text3.SetUIActive(true);
		}
		string newText2 = Singleton<PublicUtil>.Instance.GetConfigTextByTable(ETableText.SpeakerTitle, new int?(speaker.Value.Id)) ?? "";
		UUIText text4 = base.GetText(3);
		if (text4 != null)
		{
			text4.SetText(newText2, true);
		}
		base.GetText(0).SetUIActive(true);
		base.GetText(1).SetUIActive(true);
	}

	// Token: 0x0600FE94 RID: 65172 RVA: 0x0045D610 File Offset: 0x0045B810
	public void RefreshCardItemByCallCard(int cardId)
	{
		this.IsShowBuffCard = false;
		base.GetItem(9).SetUIActive(true);
		base.GetText(0).SetUIActive(false);
		base.GetText(1).SetUIActive(false);
		UUIText text = base.GetText(3);
		if (text != null)
		{
			text.SetUIActive(false);
		}
		base.GetItem(22).SetUIActive(false);
		ReignsCard reignsCallCard = ConfigBase<KingShipConfig>.Instance.GetReignsCallCard(cardId);
		if (!string.IsNullOrEmpty(reignsCallCard.CardBackground))
		{
			this.SetCardBackGroud(reignsCallCard.CardBackground);
		}
		base.GetText(12).SetUIActive(false);
		string configTextByKey = Singleton<PublicUtil>.Instance.GetConfigTextByKey("ReignsCard_" + cardId.ToString() + "_CardTitle");
		base.GetText(2).SetText(configTextByKey, true);
		base.GetSprite(11).SetUIActive(false);
	}

	// Token: 0x0600FE95 RID: 65173 RVA: 0x0045D6E0 File Offset: 0x0045B8E0
	public void RefreshCardItemByBuffCard(int cardId)
	{
		this.IsShowBuffCard = true;
		base.GetItem(9).SetUIActive(true);
		base.GetText(0).SetUIActive(false);
		base.GetText(1).SetUIActive(false);
		UUIText text = base.GetText(3);
		if (text != null)
		{
			text.SetUIActive(false);
		}
		base.GetText(12).SetUIActive(true);
		base.GetItem(22).SetUIActive(true);
		ReignsCard reignsCallCard = ConfigBase<KingShipConfig>.Instance.GetReignsCallCard(cardId);
		if (!string.IsNullOrEmpty(reignsCallCard.CardBackground))
		{
			this.SetCardBackGroud(reignsCallCard.CardBackground);
		}
		string configTextByKey = Singleton<PublicUtil>.Instance.GetConfigTextByKey("ReignsCard_" + cardId.ToString() + "_CardDesc");
		base.GetText(12).SetText(configTextByKey, true);
		string configTextByKey2 = Singleton<PublicUtil>.Instance.GetConfigTextByKey("ReignsCard_" + cardId.ToString() + "_CardTitle");
		base.GetText(2).SetText(configTextByKey2, true);
		base.GetSprite(11).SetUIActive(!StringUtils.IsEmpty(reignsCallCard.CardIcon));
		if (!string.IsNullOrEmpty(reignsCallCard.CardIcon))
		{
			this.SetSpriteByPath(reignsCallCard.CardIcon, base.GetSprite(11), false, null, null);
		}
	}

	// Token: 0x0600FE96 RID: 65174 RVA: 0x0045D81C File Offset: 0x0045BA1C
	[NullableContext(1)]
	private void SetCardBackGroud(string backGroundPath)
	{
		UUITexture layerTextureA = this.LayerTextureA;
		if (layerTextureA != null)
		{
			layerTextureA.SetUIActive(false);
		}
		UUITexture layerTextureB = this.LayerTextureB;
		if (layerTextureB != null)
		{
			layerTextureB.SetUIActive(false);
		}
		UUITexture layerTextureC = this.LayerTextureC;
		if (layerTextureC != null)
		{
			layerTextureC.SetUIActive(false);
		}
		UUITexture layerTextureD = this.LayerTextureD;
		if (layerTextureD != null)
		{
			layerTextureD.SetUIActive(false);
		}
		UUITexture layerTextureE = this.LayerTextureE;
		if (layerTextureE != null)
		{
			layerTextureE.SetUIActive(false);
		}
		UUITexture layerTextureF = this.LayerTextureF;
		if (layerTextureF != null)
		{
			layerTextureF.SetUIActive(false);
		}
		this.SetCardBackGroudAsync(backGroundPath).ContinueWith(delegate()
		{
			UUITexture layerTextureA2 = this.LayerTextureA;
			if (layerTextureA2 != null)
			{
				layerTextureA2.SetUIActive(true);
			}
			UUITexture layerTextureB2 = this.LayerTextureB;
			if (layerTextureB2 != null)
			{
				layerTextureB2.SetUIActive(true);
			}
			UUITexture layerTextureC2 = this.LayerTextureC;
			if (layerTextureC2 != null)
			{
				layerTextureC2.SetUIActive(true);
			}
			UUITexture layerTextureD2 = this.LayerTextureD;
			if (layerTextureD2 != null)
			{
				layerTextureD2.SetUIActive(true);
			}
			UUITexture layerTextureE2 = this.LayerTextureE;
			if (layerTextureE2 != null)
			{
				layerTextureE2.SetUIActive(true);
			}
			UUITexture layerTextureF2 = this.LayerTextureF;
			if (layerTextureF2 == null)
			{
				return;
			}
			layerTextureF2.SetUIActive(true);
		}).Forget();
	}

	// Token: 0x0600FE97 RID: 65175 RVA: 0x0045D8B4 File Offset: 0x0045BAB4
	[NullableContext(1)]
	private UniTask SetCardBackGroudAsync(string backGroundPath)
	{
		KingShipCardItem.<SetCardBackGroudAsync>d__59 <SetCardBackGroudAsync>d__;
		<SetCardBackGroudAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<SetCardBackGroudAsync>d__.<>4__this = this;
		<SetCardBackGroudAsync>d__.backGroundPath = backGroundPath;
		<SetCardBackGroudAsync>d__.<>1__state = -1;
		<SetCardBackGroudAsync>d__.<>t__builder.Start<KingShipCardItem.<SetCardBackGroudAsync>d__59>(ref <SetCardBackGroudAsync>d__);
		return <SetCardBackGroudAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600FE98 RID: 65176 RVA: 0x0045D8FF File Offset: 0x0045BAFF
	public void SetCardItemInputPitch(float pitch)
	{
		this.PitchInput = pitch;
	}

	// Token: 0x0600FE99 RID: 65177 RVA: 0x0045D908 File Offset: 0x0045BB08
	public void SetCardItemPitchByPercentage(float percentage)
	{
		float num = Singleton<MathUtils>.Instance.Clamp(percentage, -this.ViewPortPercentage, this.ViewPortPercentage);
		this.TargetPitch = -(num / this.ViewPortPercentage) * this.MaxCardPitch;
	}

	// Token: 0x0600FE9A RID: 65178 RVA: 0x0045D944 File Offset: 0x0045BB44
	public void ClearCardItemRotation()
	{
		this.CacheRotator.Pitch = 0f;
		this.CacheRotator.Yaw = 0f;
		this.CacheRotator.Roll = 0f;
		this.PitchInput = 0f;
		this.TargetPitch = 0f;
		this.RightEnd = false;
		this.LeftEnd = false;
		Action onClearPostionMax = this.OnClearPostionMax;
		if (onClearPostionMax != null)
		{
			onClearPostionMax();
		}
		this.UpdateRotator();
		this.UpdateBarSprite();
	}

	// Token: 0x0600FE9B RID: 65179 RVA: 0x0045D9C2 File Offset: 0x0045BBC2
	public void ClearTargetRotation()
	{
		this.TargetPitch = 0f;
	}

	// Token: 0x0600FE9C RID: 65180 RVA: 0x0045D9D0 File Offset: 0x0045BBD0
	public void Update(float deltaTime)
	{
		if (this.CardSequencePlayering > 0 || !base.IsShowOrShowing)
		{
			return;
		}
		if (Singleton<MathUtils>.Instance.IsNearlyZero((double)this.TargetPitch, null))
		{
			this.UpdateInput(deltaTime);
		}
		else
		{
			this.UpdateTarget(deltaTime);
		}
		this.UpdatePitch();
		this.UpdateRotator();
		this.UpdateBarSprite();
	}

	// Token: 0x0600FE9D RID: 65181 RVA: 0x0045DA30 File Offset: 0x0045BC30
	private void UpdateInput(float deltaTime)
	{
		float num = this.PitchInput;
		this.PitchInput = 0f;
		if (Singleton<Info>.Instance.IsInGamepad())
		{
			num *= this.GamepadInputRate;
		}
		else if (Singleton<Info>.Instance.IsInTouch())
		{
			num *= this.MobileRotateInputRate;
		}
		num = num * this.SensitivityPitch * deltaTime;
		if (!Singleton<MathUtils>.Instance.IsNearlyZero((double)num, null))
		{
			this.CacheRotator.Pitch -= num;
		}
	}

	// Token: 0x0600FE9E RID: 65182 RVA: 0x0045DAB0 File Offset: 0x0045BCB0
	private void UpdateTarget(float deltaTime)
	{
		if (Singleton<MathUtils>.Instance.IsNearlyEqual((double)this.TargetPitch, (double)this.CacheRotator.Pitch, null))
		{
			return;
		}
		float num = Math.Abs(this.CacheRotator.Pitch - this.TargetPitch);
		float num2 = Math.Abs(this.CacheRotator.Pitch);
		float num3 = (float)Math.Sign(this.CacheRotator.Pitch);
		float num4 = Math.Abs(this.TargetPitch);
		float num5 = (float)Math.Sign(this.TargetPitch);
		UCurveFloat reignsCardMouseMoveCurve = this.ReignsCardMouseMoveCurve;
		float num6 = (reignsCardMouseMoveCurve != null) ? reignsCardMouseMoveCurve.GetFloatValue(num2 / num4) : 0f;
		if (num5 >= 0f)
		{
			if (num2 < num4)
			{
				if (num <= num6)
				{
					this.CacheRotator.Pitch = this.TargetPitch;
				}
				else
				{
					this.CacheRotator.Pitch += num6;
				}
			}
			else if (num <= num6)
			{
				this.CacheRotator.Pitch = this.TargetPitch;
			}
			else
			{
				this.CacheRotator.Pitch -= (float)((num3 >= 0f) ? 1 : -1) * num6;
			}
		}
		else if (num2 < num4)
		{
			if (num <= num6)
			{
				this.CacheRotator.Pitch = this.TargetPitch;
			}
			else
			{
				this.CacheRotator.Pitch -= num6;
			}
		}
		else if (num <= num6)
		{
			this.CacheRotator.Pitch = this.TargetPitch;
		}
		else
		{
			this.CacheRotator.Pitch += (float)((num3 >= 0f) ? -1 : 1) * num6;
		}
		this.TargetPitch = 0f;
	}

	// Token: 0x0600FE9F RID: 65183 RVA: 0x0045DC4C File Offset: 0x0045BE4C
	private void UpdatePitch()
	{
		float num = this.CacheRotator.Pitch;
		num %= 360f;
		num = ((num > 180f) ? (num - 360f) : num);
		num = Singleton<MathUtils>.Instance.Clamp(num, -this.MaxCardPitch, this.MaxCardPitch);
		this.CacheRotator.Pitch = num;
	}

	// Token: 0x0600FEA0 RID: 65184 RVA: 0x0045DCA8 File Offset: 0x0045BEA8
	private void UpdateRotator()
	{
		float inTime = this.CacheRotator.Pitch / this.MaxCardPitch;
		UCurveVector reignsCardRotatorCurve = this.ReignsCardRotatorCurve;
		FVector? fvector = (reignsCardRotatorCurve != null) ? new FVector?(reignsCardRotatorCurve.GetVectorValue(inTime)) : null;
		this.CacheRotator.Roll = ((fvector != null) ? fvector.GetValueOrDefault().X : 0f);
		this.CacheRotator.Yaw = ((fvector != null) ? fvector.GetValueOrDefault().Z : 0f);
		global::Vector cacheCardVector = this.CacheCardVector;
		UCurveFloat reignsCardOffsetCurve = this.ReignsCardOffsetCurve;
		cacheCardVector.X = (double)(((reignsCardOffsetCurve != null) ? reignsCardOffsetCurve.GetFloatValue(inTime) : 0f) * this.LocationWhenPitch);
		UUIItem locationItem = this.LocationItem;
		if (locationItem != null)
		{
			locationItem.SetUIRelativeLocation(this.CacheCardVector.ToUeVectorOld());
		}
		UUIItem rotationItem = this.RotationItem;
		if (rotationItem != null)
		{
			FRotator frotator = this.CacheRotator.ToUeRotator();
			rotationItem.SetUIRelativeRotation(frotator);
		}
		this.CacheContentRotator.Pitch = this.CacheRotator.Pitch * this.KingShipCardContentTextRotateRate;
		UUIItem contentItem = this.ContentItem;
		if (contentItem != null)
		{
			FRotator frotator = this.CacheContentRotator.ToUeRotator();
			contentItem.SetUIRelativeRotation(frotator);
		}
		UUITexture layerTextureA = this.LayerTextureA;
		if (layerTextureA != null)
		{
			layerTextureA.SetCustomMaterialScalarParameter(this.CardMaterialParamOffsetX, this.CacheRotator.Pitch * -0.001f);
		}
		UUITexture layerTextureA2 = this.LayerTextureA;
		if (layerTextureA2 != null)
		{
			layerTextureA2.SetCustomMaterialScalarParameter(this.CardMaterialParamOffsetY, this.CacheRotator.Roll * -0.001f);
		}
		UUITexture layerTextureB = this.LayerTextureB;
		if (layerTextureB != null)
		{
			layerTextureB.SetCustomMaterialScalarParameter(this.CardMaterialParamOffsetX, this.CacheRotator.Pitch * 0.0025f);
		}
		UUITexture layerTextureB2 = this.LayerTextureB;
		if (layerTextureB2 != null)
		{
			layerTextureB2.SetCustomMaterialScalarParameter(this.CardMaterialParamOffsetY, this.CacheRotator.Roll * 0.0025f);
		}
		UUITexture layerTextureC = this.LayerTextureC;
		if (layerTextureC != null)
		{
			layerTextureC.SetCustomMaterialScalarParameter(this.CardMaterialParamOffsetX, this.CacheRotator.Pitch * 0.0075f);
		}
		UUITexture layerTextureC2 = this.LayerTextureC;
		if (layerTextureC2 != null)
		{
			layerTextureC2.SetCustomMaterialScalarParameter(this.CardMaterialParamOffsetY, this.CacheRotator.Roll * 0.0075f);
		}
		UUITexture layerTextureD = this.LayerTextureD;
		if (layerTextureD != null)
		{
			layerTextureD.SetCustomMaterialScalarParameter(this.CardMaterialParamOffsetX, this.CacheRotator.Pitch * 0.01f);
		}
		UUITexture layerTextureD2 = this.LayerTextureD;
		if (layerTextureD2 != null)
		{
			layerTextureD2.SetCustomMaterialScalarParameter(this.CardMaterialParamOffsetY, this.CacheRotator.Roll * 0.01f);
		}
		UUITexture layerTextureG = this.LayerTextureG;
		if (layerTextureG != null)
		{
			layerTextureG.SetCustomMaterialScalarParameter(this.CardMaterialParamOffsetX, this.CacheRotator.Pitch * -0.01f);
		}
		UUITexture layerTextureG2 = this.LayerTextureG;
		if (layerTextureG2 == null)
		{
			return;
		}
		layerTextureG2.SetCustomMaterialScalarParameter(this.CardMaterialParamOffsetY, this.CacheRotator.Roll * -0.01f);
	}

	// Token: 0x0600FEA1 RID: 65185 RVA: 0x0045DF68 File Offset: 0x0045C168
	private void UpdateBarSprite()
	{
		float pitch = this.CacheRotator.Pitch;
		if (Math.Abs(pitch) < 1f)
		{
			UUIItem rightItem = this.RightItem;
			if (rightItem != null)
			{
				rightItem.SetUIActive(false);
			}
			UUIItem leftItem = this.LeftItem;
			if (leftItem == null)
			{
				return;
			}
			leftItem.SetUIActive(false);
			return;
		}
		else if (pitch > 0f)
		{
			UUIItem rightItem2 = this.RightItem;
			if (rightItem2 != null)
			{
				rightItem2.SetUIActive(false);
			}
			UUIItem leftItem2 = this.LeftItem;
			if (leftItem2 != null)
			{
				leftItem2.SetUIActive(true);
			}
			float inTime = pitch / this.MaxCardPitch;
			global::Vector cacheBarVector = this.CacheBarVector;
			UCurveFloat reignsBarOffsetCurve = this.ReignsBarOffsetCurve;
			cacheBarVector.X = (double)((reignsBarOffsetCurve != null) ? reignsBarOffsetCurve.GetFloatValue(inTime) : 0f);
			UUITexture leftTexture = this.LeftTexture;
			if (leftTexture != null)
			{
				leftTexture.SetUIRelativeLocation(this.CacheBarVector.ToUeVectorOld());
			}
			UUIItem leftItem3 = this.LeftItem;
			if (leftItem3 != null)
			{
				UCurveFloat reignsBarRootAlphaCurve = this.ReignsBarRootAlphaCurve;
				leftItem3.SetAlpha((reignsBarRootAlphaCurve != null) ? reignsBarRootAlphaCurve.GetFloatValue(inTime) : 0f);
			}
			global::Vector cacheBarRootVector = this.CacheBarRootVector;
			UCurveFloat reignsBarRootOffsetCurve = this.ReignsBarRootOffsetCurve;
			cacheBarRootVector.X = (double)((reignsBarRootOffsetCurve != null) ? reignsBarRootOffsetCurve.GetFloatValue(inTime) : 0f);
			UUIItem leftItem4 = this.LeftItem;
			if (leftItem4 != null)
			{
				leftItem4.SetUIRelativeLocation(this.CacheBarRootVector.ToUeVectorOld());
			}
			if (pitch >= this.MaxCardPitch)
			{
				if (!this.LeftEnd)
				{
					Action<bool> onPostionMaxCallBack = this.OnPostionMaxCallBack;
					if (onPostionMaxCallBack != null)
					{
						onPostionMaxCallBack(false);
					}
					Singleton<AudioSystem>.Instance.PostEvent("play_ui_com_slider_tick");
				}
				this.LeftEnd = true;
				this.RightEnd = false;
				return;
			}
			this.RightEnd = false;
			this.LeftEnd = false;
			Action onClearPostionMax = this.OnClearPostionMax;
			if (onClearPostionMax == null)
			{
				return;
			}
			onClearPostionMax();
			return;
		}
		else
		{
			UUIItem rightItem3 = this.RightItem;
			if (rightItem3 != null)
			{
				rightItem3.SetUIActive(true);
			}
			UUIItem leftItem5 = this.LeftItem;
			if (leftItem5 != null)
			{
				leftItem5.SetUIActive(false);
			}
			float inTime2 = pitch / this.MaxCardPitch;
			global::Vector cacheBarVector2 = this.CacheBarVector;
			UCurveFloat reignsBarOffsetCurve2 = this.ReignsBarOffsetCurve;
			cacheBarVector2.X = (double)((reignsBarOffsetCurve2 != null) ? reignsBarOffsetCurve2.GetFloatValue(inTime2) : 0f);
			UUITexture rightTexture = this.RightTexture;
			if (rightTexture != null)
			{
				rightTexture.SetUIRelativeLocation(this.CacheBarVector.ToUeVectorOld());
			}
			UUIItem rightItem4 = this.RightItem;
			if (rightItem4 != null)
			{
				UCurveFloat reignsBarRootAlphaCurve2 = this.ReignsBarRootAlphaCurve;
				rightItem4.SetAlpha((reignsBarRootAlphaCurve2 != null) ? reignsBarRootAlphaCurve2.GetFloatValue(inTime2) : 0f);
			}
			global::Vector cacheBarRootVector2 = this.CacheBarRootVector;
			UCurveFloat reignsBarRootOffsetCurve2 = this.ReignsBarRootOffsetCurve;
			cacheBarRootVector2.X = (double)((reignsBarRootOffsetCurve2 != null) ? reignsBarRootOffsetCurve2.GetFloatValue(inTime2) : 0f);
			UUIItem rightItem5 = this.RightItem;
			if (rightItem5 != null)
			{
				rightItem5.SetUIRelativeLocation(this.CacheBarRootVector.ToUeVectorOld());
			}
			if (pitch <= -this.MaxCardPitch)
			{
				if (!this.RightEnd)
				{
					Action<bool> onPostionMaxCallBack2 = this.OnPostionMaxCallBack;
					if (onPostionMaxCallBack2 != null)
					{
						onPostionMaxCallBack2(true);
					}
					Singleton<AudioSystem>.Instance.PostEvent("play_ui_com_slider_tick");
				}
				this.RightEnd = true;
				this.LeftEnd = false;
				return;
			}
			this.RightEnd = false;
			this.LeftEnd = false;
			Action onClearPostionMax2 = this.OnClearPostionMax;
			if (onClearPostionMax2 == null)
			{
				return;
			}
			onClearPostionMax2();
			return;
		}
	}

	// Token: 0x0600FEA2 RID: 65186 RVA: 0x0045E228 File Offset: 0x0045C428
	[NullableContext(1)]
	public void SetLeftAndRight(string leftText, string rightText)
	{
		string flowConfigLocalText = Singleton<PublicUtil>.Instance.GetFlowConfigLocalText(leftText);
		base.GetText(0).SetText(flowConfigLocalText ?? "", true);
		string flowConfigLocalText2 = Singleton<PublicUtil>.Instance.GetFlowConfigLocalText(rightText);
		base.GetText(1).SetText(flowConfigLocalText2 ?? "", true);
	}

	// Token: 0x0600FEA3 RID: 65187 RVA: 0x0045E27C File Offset: 0x0045C47C
	[NullableContext(1)]
	public void PlaySequenceByName(string name)
	{
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.StopCurrentSequence(true, true);
		}
		LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
		if (levelSequencePlayer2 != null)
		{
			levelSequencePlayer2.PlayLevelSequenceByName(name, false, null, false);
		}
		this.CardSequencePlayering++;
		this.LeftEnd = false;
		this.RightEnd = false;
	}

	// Token: 0x0600FEA4 RID: 65188 RVA: 0x0045E2D8 File Offset: 0x0045C4D8
	public void PlayReSetSequence()
	{
		UUIItem rightItem = this.RightItem;
		if (rightItem == null || !rightItem.IsUIActiveSelf())
		{
			UUIItem leftItem = this.LeftItem;
			if (leftItem != null && leftItem.IsUIActiveSelf())
			{
				this.CardSequencePlayering++;
				LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
				if (levelSequencePlayer != null)
				{
					levelSequencePlayer.StopCurrentSequence(true, true);
				}
				LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
				if (levelSequencePlayer2 == null)
				{
					return;
				}
				levelSequencePlayer2.PlayLevelSequenceByName("ResetL", false, null, false);
			}
			return;
		}
		this.CardSequencePlayering++;
		LevelSequencePlayer levelSequencePlayer3 = this.LevelSequencePlayer;
		if (levelSequencePlayer3 != null)
		{
			levelSequencePlayer3.StopCurrentSequence(true, true);
		}
		LevelSequencePlayer levelSequencePlayer4 = this.LevelSequencePlayer;
		if (levelSequencePlayer4 == null)
		{
			return;
		}
		levelSequencePlayer4.PlayLevelSequenceByName("ResetR", false, null, false);
	}

	// Token: 0x040079FE RID: 31230
	private const float MATERIAL_LAYA = -0.001f;

	// Token: 0x040079FF RID: 31231
	private const float MATERIAL_LAYB = 0.0025f;

	// Token: 0x04007A00 RID: 31232
	private const float MATERIAL_LAYC = 0.0075f;

	// Token: 0x04007A01 RID: 31233
	private const float MATERIAL_LAYD = 0.01f;

	// Token: 0x04007A02 RID: 31234
	private const float MATERIAL_LAYG = -0.01f;

	// Token: 0x04007A03 RID: 31235
	[Nullable(1)]
	private const string CLICK_AUDIO_EVENT = "play_ui_com_slider_tick";

	// Token: 0x04007A04 RID: 31236
	[Nullable(1)]
	private readonly Rotator CacheRotator = Rotator.Create();

	// Token: 0x04007A05 RID: 31237
	[Nullable(1)]
	private readonly Rotator CacheContentRotator = Rotator.Create();

	// Token: 0x04007A06 RID: 31238
	[Nullable(1)]
	private readonly global::Vector CacheCardVector = global::Vector.Create();

	// Token: 0x04007A07 RID: 31239
	[Nullable(1)]
	private readonly global::Vector CacheBarVector = global::Vector.Create();

	// Token: 0x04007A08 RID: 31240
	[Nullable(1)]
	private readonly global::Vector CacheBarRootVector = global::Vector.Create();

	// Token: 0x04007A09 RID: 31241
	private float GamepadInputRate = 1f;

	// Token: 0x04007A0A RID: 31242
	private float MobileRotateInputRate = 1f;

	// Token: 0x04007A0B RID: 31243
	private float SensitivityPitch;

	// Token: 0x04007A0C RID: 31244
	private float ViewPortPercentage;

	// Token: 0x04007A0D RID: 31245
	private float MaxCardPitch;

	// Token: 0x04007A0E RID: 31246
	private float LocationWhenPitch;

	// Token: 0x04007A0F RID: 31247
	private float KingShipCardContentTextRotateRate;

	// Token: 0x04007A10 RID: 31248
	private UUIItem RotationItem;

	// Token: 0x04007A11 RID: 31249
	private UUIItem LocationItem;

	// Token: 0x04007A12 RID: 31250
	private UUIItem RightItem;

	// Token: 0x04007A13 RID: 31251
	private UUIItem LeftItem;

	// Token: 0x04007A14 RID: 31252
	private UUITexture RightTexture;

	// Token: 0x04007A15 RID: 31253
	private UUITexture LeftTexture;

	// Token: 0x04007A16 RID: 31254
	private UCurveFloat ReignsCardMouseMoveCurve;

	// Token: 0x04007A17 RID: 31255
	private UCurveVector ReignsCardRotatorCurve;

	// Token: 0x04007A18 RID: 31256
	private UCurveFloat ReignsCardOffsetCurve;

	// Token: 0x04007A19 RID: 31257
	private UCurveFloat ReignsBarRootOffsetCurve;

	// Token: 0x04007A1A RID: 31258
	private UCurveFloat ReignsBarRootAlphaCurve;

	// Token: 0x04007A1B RID: 31259
	private UCurveFloat ReignsBarOffsetCurve;

	// Token: 0x04007A1C RID: 31260
	private UUITexture LayerTextureA;

	// Token: 0x04007A1D RID: 31261
	private UUITexture LayerTextureB;

	// Token: 0x04007A1E RID: 31262
	private UUITexture LayerTextureC;

	// Token: 0x04007A1F RID: 31263
	private UUITexture LayerTextureD;

	// Token: 0x04007A20 RID: 31264
	private UUITexture LayerTextureE;

	// Token: 0x04007A21 RID: 31265
	private UUITexture LayerTextureF;

	// Token: 0x04007A22 RID: 31266
	private UUITexture LayerTextureG;

	// Token: 0x04007A23 RID: 31267
	private float PitchInput;

	// Token: 0x04007A24 RID: 31268
	private float TargetPitch;

	// Token: 0x04007A25 RID: 31269
	public bool RightEnd;

	// Token: 0x04007A26 RID: 31270
	public bool LeftEnd;

	// Token: 0x04007A27 RID: 31271
	public Action<bool> OnPostionMaxCallBack;

	// Token: 0x04007A28 RID: 31272
	public Action OnClearPostionMax;

	// Token: 0x04007A29 RID: 31273
	public UUIItem ContentItem;

	// Token: 0x04007A2A RID: 31274
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x04007A2B RID: 31275
	private int CardSequencePlayering;

	// Token: 0x04007A2C RID: 31276
	private readonly FName CardMaterialParamOffsetX = new FName("OffsetX");

	// Token: 0x04007A2D RID: 31277
	private readonly FName CardMaterialParamOffsetY = new FName("OffsetY");

	// Token: 0x04007A2E RID: 31278
	public Action<bool> OnCallBackDropSequence;

	// Token: 0x04007A2F RID: 31279
	private bool IsShowBuffCard;

	// Token: 0x02008423 RID: 33827
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x0402CC83 RID: 183427
		public const int LeftText = 0;

		// Token: 0x0402CC84 RID: 183428
		public const int RightText = 1;

		// Token: 0x0402CC85 RID: 183429
		public const int CardNameText = 2;

		// Token: 0x0402CC86 RID: 183430
		public const int CardDesText = 3;

		// Token: 0x0402CC87 RID: 183431
		public const int LeftBarTexture = 4;

		// Token: 0x0402CC88 RID: 183432
		public const int RightBarTexture = 5;

		// Token: 0x0402CC89 RID: 183433
		public const int OldItem = 6;

		// Token: 0x0402CC8A RID: 183434
		public const int LeftItem = 7;

		// Token: 0x0402CC8B RID: 183435
		public const int RightItem = 8;

		// Token: 0x0402CC8C RID: 183436
		public const int CallCardItem = 9;

		// Token: 0x0402CC8D RID: 183437
		public const int CallCardItemIconItem = 10;

		// Token: 0x0402CC8E RID: 183438
		public const int CallCardItemIconSprite = 11;

		// Token: 0x0402CC8F RID: 183439
		public const int CallCardItemText = 12;

		// Token: 0x0402CC90 RID: 183440
		public const int LayerDTexture = 13;

		// Token: 0x0402CC91 RID: 183441
		public const int LayerCTexture = 14;

		// Token: 0x0402CC92 RID: 183442
		public const int LayerBTexture = 15;

		// Token: 0x0402CC93 RID: 183443
		public const int LayerATexture = 16;

		// Token: 0x0402CC94 RID: 183444
		public const int LayerFTexture = 17;

		// Token: 0x0402CC95 RID: 183445
		public const int LocationItem = 18;

		// Token: 0x0402CC96 RID: 183446
		public const int RotatorItem = 19;

		// Token: 0x0402CC97 RID: 183447
		public const int LayerETexture = 20;

		// Token: 0x0402CC98 RID: 183448
		public const int LayerGTexture = 21;

		// Token: 0x0402CC99 RID: 183449
		public const int GreenItem = 22;
	}
}
