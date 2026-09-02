using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialContainer;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using UnrealEngine;

namespace CSharpScript.Game.Render
{
	// Token: 0x0200475E RID: 18270
	[NullableContext(2)]
	[Nullable(0)]
	public class CharMaterialControlDataCache
	{
		// Token: 0x0602F698 RID: 194200 RVA: 0x00B42754 File Offset: 0x00B40954
		[NullableContext(1)]
		public unsafe CharMaterialControlDataCache(string dataName, PD_CharacterControllerData_C data)
		{
			this.Data = data;
			this.DataName = dataName;
			string empty = string.Empty;
			<>y__InlineArray2<string> <>y__InlineArray = default(<>y__InlineArray2<string>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<string>, string>(ref <>y__InlineArray, 0) = "Render_CharMaterialControlUpdate_";
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<string>, string>(ref <>y__InlineArray, 1) = dataName;
			this.StatCharMaterialControlUpdate = Stat.CreateNoFlameGraph(string.Join(empty, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<string>, string>(<>y__InlineArray, 2)), "", "");
			string empty2 = string.Empty;
			<>y__InlineArray2<string> <>y__InlineArray2 = default(<>y__InlineArray2<string>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<string>, string>(ref <>y__InlineArray2, 0) = "Render_CharMaterialControlCacheData_";
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<string>, string>(ref <>y__InlineArray2, 1) = dataName;
			this.StatCharMaterialControlCacheData = Stat.CreateNoFlameGraph(string.Join(empty2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<string>, string>(<>y__InlineArray2, 2)), "", "");
			this.RefCount = 0;
			this.MaskOriginEffect = data.MaskOriginEffect;
			this.DataType = new ECharacterControllerType?(data.DataType);
			SMaterialControllerLoopTime loopTime = data.LoopTime;
			this.DataLoopEnd = loopTime.End;
			this.DataLoopStart = loopTime.Start;
			this.DataLoopTime = loopTime.Loop;
			this.WholeLoopTime = this.DataLoopStart + this.DataLoopTime + this.DataLoopEnd;
			this.IgnoreTimeDilation = data.IgnoreTimeDilation;
			this.SpecifiedBodyType = new ECharacterBodySpecifiedType?(data.SpecifiedBodyType);
			this.SpecifiedSlotType = new ECharacterSlotSpecifiedType?(data.SpecifiedSlotType);
			this.MaterialModifyType = new ECharacterControllerApplyType?(data.MaterialModifyType);
			TArray<string> otherCases = data.OtherCases;
			int num = otherCases.Num();
			if (num > 0)
			{
				this.OtherCases = new HashSet<string>();
				for (int i = 0; i < num; i++)
				{
					this.OtherCases.Add(otherCases.Get(i));
				}
			}
			TArray<string> weaponCases = data.WeaponCases;
			num = weaponCases.Num();
			if (num > 0)
			{
				this.WeaponCases = new HashSet<string>();
				for (int j = 0; j < num; j++)
				{
					this.WeaponCases.Add(weaponCases.Get(j));
				}
			}
			TArray<TEnumAsByte<ECharacterMeshPart>> specifiedParts = data.SpecifiedParts;
			num = specifiedParts.Num();
			if (num > 0)
			{
				this.SpecifiedParts = new ECharacterMeshPart[num];
				for (int k = 0; k < num; k++)
				{
					this.SpecifiedParts[k] = specifiedParts.Get(k);
				}
			}
			TArray<string> customPartNames = data.CustomPartNames;
			num = customPartNames.Num();
			if (num > 0)
			{
				this.CustomPartNames = new string[num];
				for (int l = 0; l < num; l++)
				{
					this.CustomPartNames[l] = customPartNames.Get(l);
				}
			}
			TArray<string> customExcludePartNames = data.CustomExcludePartNames;
			num = customExcludePartNames.Num();
			if (num > 0)
			{
				this.CustomExcludePartNames = new string[num];
				for (int m = 0; m < num; m++)
				{
					this.CustomExcludePartNames[m] = customExcludePartNames.Get(m);
				}
			}
			this.UseRim = data.UseRim;
			if (this.UseRim)
			{
				this.RimUseTex = ((data.RimUseTex > false) ? 1 : 0);
				this.RimChannel = new FLinearColor?(RenderUtil.GetSelectedChannel(data.RimChannel));
				this.RimRevertProperty = data.RimRevertProperty_DEPRECATED;
				SMaterialControllerFloatGroup rimRange = data.RimRange;
				this.RimRange = new CharMaterialControlFloatGroup(rimRange.End, rimRange.Loop, rimRange.Start);
				SMaterialControllerColorGroup rimColor = data.RimColor;
				this.RimColor = new CharMaterialControlColorGroup(rimColor.End, rimColor.Loop, rimColor.Start);
				SMaterialControllerFloatGroup rimIntensity = data.RimIntensity;
				this.RimIntensity = new CharMaterialControlFloatGroup(rimIntensity.End, rimIntensity.Loop, rimIntensity.Start);
			}
			this.UseDissolve = data.UseDissolve;
			if (this.UseDissolve)
			{
				if (data.DissolveChannel == ECharacterControllerChannelSwitch.RGB)
				{
					this.DissolveChannel = new FLinearColor?(new FLinearColor(1f, 0f, 0f, 0f));
				}
				else
				{
					this.DissolveChannel = new FLinearColor?(RenderUtil.GetSelectedChannel(data.DissolveChannel));
				}
				SMaterialControllerFloatGroup dissolveProgress = data.DissolveProgress;
				this.DissolveProgress = new CharMaterialControlFloatGroup(dissolveProgress.End, dissolveProgress.Loop, dissolveProgress.Start);
				SMaterialControllerFloatGroup dissolveSmooth = data.DissolveSmooth;
				this.DissolveSmooth = new CharMaterialControlFloatGroup(dissolveSmooth.End, dissolveSmooth.Loop, dissolveSmooth.Start);
				SMaterialControllerFloatGroup dissolveColorIntensity = data.DissolveColorIntensity;
				this.DissolveColorIntensity = new CharMaterialControlFloatGroup(dissolveColorIntensity.End, dissolveColorIntensity.Loop, dissolveColorIntensity.Start);
				SMaterialControllerColorGroup dissolveColor = data.DissolveColor;
				this.DissolveColor = new CharMaterialControlColorGroup(dissolveColor.End, dissolveColor.Loop, dissolveColor.Start);
				this.DissolveRevertProperty = data.DissolveRevertProperty_DEPRECATED;
			}
			this.UseOutline = data.UseOutline;
			if (this.UseOutline)
			{
				this.OutlineRevertProperty = data.OutlineRevertProperty_DEPRECATED;
				this.OutlineUseTex = (data.OutlineUseTex > false);
				this.UseOuterOutlineEffect = data.UseOuterOutlineEffect;
				SMaterialControllerFloatGroup outlineWidth = data.OutlineWidth;
				this.OutlineWidth = new CharMaterialControlFloatGroup(outlineWidth.End, outlineWidth.Loop, outlineWidth.Start);
				SMaterialControllerColorGroup outlineColor = data.OutlineColor;
				this.OutlineColor = new CharMaterialControlColorGroup(outlineColor.End, outlineColor.Loop, outlineColor.Start);
				SMaterialControllerFloatGroup outlineIntensity = data.OutlineIntensity;
				this.OutlineIntensity = new CharMaterialControlFloatGroup(outlineIntensity.End, outlineIntensity.Loop, outlineIntensity.Start);
			}
			if (GlobalData.IsEs3 && data.MobileUseDifferentMaterial && data.ReplaceMaterialMobile != null)
			{
				this.ReplaceMaterialInterface = data.ReplaceMaterialMobile;
			}
			else
			{
				this.ReplaceMaterialInterface = data.ReplaceMaterial;
			}
			if (this.ReplaceMaterialInterface != null)
			{
				this.UseParameterModify = data.UseParameterModify;
				this.RevertMaterial = data.RevertMaterial_DEPRECATED;
				TArray<SMaterialControllerColorParameter> colorParameters = data.ColorParameters;
				num = colorParameters.Num();
				if (num > 0)
				{
					this.ColorParameterNames = new FName[num];
					List<CharMaterialControlColorGroup> list = new List<CharMaterialControlColorGroup>();
					List<FName> list2 = new List<FName>();
					for (int n = 0; n < num; n++)
					{
						SMaterialControllerColorParameter smaterialControllerColorParameter = colorParameters.Get(n);
						if (!smaterialControllerColorParameter.ParameterName.Equals(FNameUtil.NONE))
						{
							list2.Add(smaterialControllerColorParameter.ParameterName);
							SMaterialControllerColorGroup parameterValue = smaterialControllerColorParameter.ParameterValue;
							list.Add(new CharMaterialControlColorGroup(parameterValue.End, parameterValue.Loop, parameterValue.Start));
						}
					}
					this.ColorParameterNames = list2.ToArray();
					this.ColorParameterValues = list.ToArray();
				}
				TArray<SMaterialControllerFloatParameter> floatParameters = data.FloatParameters;
				num = floatParameters.Num();
				if (num > 0)
				{
					this.FloatParameterNames = new FName[num];
					List<CharMaterialControlFloatGroup> list3 = new List<CharMaterialControlFloatGroup>();
					List<FName> list4 = new List<FName>();
					for (int num2 = 0; num2 < num; num2++)
					{
						SMaterialControllerFloatParameter smaterialControllerFloatParameter = floatParameters.Get(num2);
						if (!smaterialControllerFloatParameter.ParameterName.Equals(FNameUtil.NONE))
						{
							list4.Add(smaterialControllerFloatParameter.ParameterName);
							SMaterialControllerFloatGroup parameterValue2 = smaterialControllerFloatParameter.ParameterValue;
							list3.Add(new CharMaterialControlFloatGroup(parameterValue2.End, parameterValue2.Loop, parameterValue2.Start));
						}
					}
					this.FloatParameterNames = list4.ToArray();
					this.FloatParameterValues = list3.ToArray();
				}
			}
			this.UseColor = data.UseColor;
			if (this.UseColor)
			{
				SMaterialControllerColorGroup baseColor = data.BaseColor;
				this.BaseColor = new CharMaterialControlColorGroup(baseColor.End, baseColor.Loop, baseColor.Start);
				SMaterialControllerColorGroup emissionColor = data.EmissionColor;
				this.EmissionColor = new CharMaterialControlColorGroup(emissionColor.End, emissionColor.Loop, emissionColor.Start);
				SMaterialControllerFloatGroup emissionIntensity = data.EmissionIntensity;
				this.EmissionIntensity = new CharMaterialControlFloatGroup(emissionIntensity.End, emissionIntensity.Loop, emissionIntensity.Start);
				SMaterialControllerFloatGroup baseColorIntensity = data.BaseColorIntensity;
				this.BaseColorIntensity = new CharMaterialControlFloatGroup(baseColorIntensity.End, baseColorIntensity.Loop, baseColorIntensity.Start);
				this.BaseUseTex = (data.BaseUseTex > false);
				this.EmissionUseTex = (data.EmissionUseTex > false);
				this.ColorRevertProperty = data.ColorRevertProperty_DEPRECATED;
			}
			this.UseTextureSample = data.UseTextureSample;
			if (this.UseTextureSample)
			{
				this.MaskTexture = data.MaskTexture;
				this.UseScreenUv = 0f;
				switch (data.UVSelection)
				{
				case AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController.ECharacterControllerUVSwitch.UV1:
					this.UvSelection = new FLinearColor?(new FLinearColor(1f, 0f, 0f, 0f));
					break;
				case AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController.ECharacterControllerUVSwitch.UV2:
					this.UvSelection = new FLinearColor?(new FLinearColor(0f, 1f, 0f, 0f));
					break;
				case AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController.ECharacterControllerUVSwitch.UV3:
					this.UvSelection = new FLinearColor?(new FLinearColor(0f, 0f, 1f, 0f));
					break;
				case AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController.ECharacterControllerUVSwitch.UV4:
					this.UvSelection = new FLinearColor?(new FLinearColor(0f, 0f, 0f, 1f));
					break;
				case AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController.ECharacterControllerUVSwitch.ScreenUV:
					this.UseScreenUv = 1f;
					this.UvSelection = new FLinearColor?(new FLinearColor(0f, 0f, 0f, 0f));
					break;
				default:
					this.UvSelection = new FLinearColor?(new FLinearColor(0f, 0f, 0f, 0f));
					break;
				}
				SMaterialControllerColorGroup textureScaleAndOffset = data.TextureScaleAndOffset;
				this.TextureScaleAndOffset = new CharMaterialControlColorGroup(textureScaleAndOffset.End, textureScaleAndOffset.Loop, textureScaleAndOffset.Start);
				SMaterialControllerColorGroup textureSpeed = data.TextureSpeed;
				this.TextureSpeed = new CharMaterialControlColorGroup(textureSpeed.End, textureSpeed.Loop, textureSpeed.Start);
				SMaterialControllerColorGroup textureColorTint = data.TextureColorTint;
				this.TextureColorTint = new CharMaterialControlColorGroup(textureColorTint.End, textureColorTint.Loop, textureColorTint.Start);
				SMaterialControllerFloatGroup rotation = data.Rotation;
				this.Rotation = new CharMaterialControlFloatGroup(rotation.End, rotation.Loop, rotation.Start);
				SMaterialControllerFloatGroup textureMaskRange = data.TextureMaskRange;
				this.TextureMaskRange = new CharMaterialControlFloatGroup(textureMaskRange.End, textureMaskRange.Loop, textureMaskRange.Start);
				this.UseAlphaToMask = (data.UseAlphaToMask > false);
				this.TextureSampleRevertProperty = data.TextureSampleRevertProperty;
			}
			this.UseMotionOffset = data.UseMotionOffset;
			if (this.UseMotionOffset)
			{
				this.MotionAffectVertexRange = data.MotionAffectVertexRange;
				this.MotionOffsetLength = data.MotionOffsetLength;
				SMaterialControllerFloatGroup motionNoiseSpeed = data.MotionNoiseSpeed;
				this.MotionNoiseSpeed = new CharMaterialControlFloatGroup(motionNoiseSpeed.End, motionNoiseSpeed.Loop, motionNoiseSpeed.Start);
				this.MotionOffsetRevertProperty = data.MotionOffsetRevertProperty_DEPRECATED;
			}
			this.UseDitherEffect = data.UseDitherEffect;
			if (this.UseDitherEffect)
			{
				SMaterialControllerFloatGroup ditherValue = data.DitherValue;
				this.DitherValue = new CharMaterialControlFloatGroup(ditherValue.End, ditherValue.Loop, ditherValue.Start);
				this.DitherRevertProperty = data.DitherRevertProperty_DEPRECATED;
			}
			this.UseCustomMaterialEffect = data.UseCustomMaterialEffect;
			if (this.UseCustomMaterialEffect)
			{
				this.CustomRevertProperty = data.CustomRevertProperty_DEPRECATED;
				TArray<SMaterialControllerColorParameter> customColorParameters = data.CustomColorParameters;
				num = customColorParameters.Num();
				if (num > 0)
				{
					List<FName> list5 = new List<FName>();
					List<CharMaterialControlColorGroup> list6 = new List<CharMaterialControlColorGroup>();
					for (int num3 = 0; num3 < num; num3++)
					{
						SMaterialControllerColorParameter smaterialControllerColorParameter2 = customColorParameters.Get(num3);
						if (!smaterialControllerColorParameter2.ParameterName.Equals(FNameUtil.NONE))
						{
							list5.Add(smaterialControllerColorParameter2.ParameterName);
							SMaterialControllerColorGroup parameterValue3 = smaterialControllerColorParameter2.ParameterValue;
							list6.Add(new CharMaterialControlColorGroup(parameterValue3.End, parameterValue3.Loop, parameterValue3.Start));
						}
					}
					this.CustomColorParameterNames = list5.ToArray();
					this.CustomColorParameterValues = list6.ToArray();
				}
				TArray<SMaterialControllerFloatParameter> customFloatParameters = data.CustomFloatParameters;
				num = customFloatParameters.Num();
				if (num > 0)
				{
					List<FName> list7 = new List<FName>();
					List<CharMaterialControlFloatGroup> list8 = new List<CharMaterialControlFloatGroup>();
					for (int num4 = 0; num4 < num; num4++)
					{
						SMaterialControllerFloatParameter smaterialControllerFloatParameter2 = customFloatParameters.Get(num4);
						if (!smaterialControllerFloatParameter2.ParameterName.Equals(FNameUtil.NONE))
						{
							list7.Add(smaterialControllerFloatParameter2.ParameterName);
							SMaterialControllerFloatGroup parameterValue4 = smaterialControllerFloatParameter2.ParameterValue;
							list8.Add(new CharMaterialControlFloatGroup(parameterValue4.End, parameterValue4.Loop, parameterValue4.Start));
						}
					}
					this.CustomFloatParameterNames = list7.ToArray();
					this.CustomFloatParameterValues = list8.ToArray();
				}
				TArray<SMaterialControllerTextureParameter> customTextureParameters = data.CustomTextureParameters;
				num = customTextureParameters.Num();
				if (num > 0)
				{
					List<FName> list9 = new List<FName>();
					List<CharMaterialControlTextureGroup> list10 = new List<CharMaterialControlTextureGroup>();
					for (int num5 = 0; num5 < num; num5++)
					{
						SMaterialControllerTextureParameter smaterialControllerTextureParameter = customTextureParameters.Get(num5);
						if (!smaterialControllerTextureParameter.ParameterName.Equals(FNameUtil.NONE))
						{
							list9.Add(smaterialControllerTextureParameter.ParameterName);
							SMaterialControllerTextureGroup parameterValue5 = smaterialControllerTextureParameter.ParameterValue;
							list10.Add(new CharMaterialControlTextureGroup(parameterValue5.End, parameterValue5.Loop, parameterValue5.Start));
						}
					}
					this.CustomTextureParameterNames = list9.ToArray();
					this.CustomTextureParameterValues = list10.ToArray();
				}
			}
			this.HiddenAfterEffect = data.HiddenAfterEffect;
		}

		// Token: 0x0401B008 RID: 110600
		public PD_CharacterControllerData_C Data;

		// Token: 0x0401B009 RID: 110601
		public string DataName;

		// Token: 0x0401B00A RID: 110602
		public int RefCount;

		// Token: 0x0401B00B RID: 110603
		public Stat StatCharMaterialControlCacheData;

		// Token: 0x0401B00C RID: 110604
		public Stat StatCharMaterialControlUpdate;

		// Token: 0x0401B00D RID: 110605
		public float WholeLoopTime;

		// Token: 0x0401B00E RID: 110606
		public float DataLoopEnd;

		// Token: 0x0401B00F RID: 110607
		public float DataLoopStart;

		// Token: 0x0401B010 RID: 110608
		public float DataLoopTime;

		// Token: 0x0401B011 RID: 110609
		public bool IgnoreTimeDilation;

		// Token: 0x0401B012 RID: 110610
		public bool MaskOriginEffect;

		// Token: 0x0401B013 RID: 110611
		public ECharacterControllerType? DataType;

		// Token: 0x0401B014 RID: 110612
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public HashSet<string> OtherCases;

		// Token: 0x0401B015 RID: 110613
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public HashSet<string> WeaponCases;

		// Token: 0x0401B016 RID: 110614
		public ECharacterMeshPart[] SpecifiedParts;

		// Token: 0x0401B017 RID: 110615
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public string[] CustomPartNames;

		// Token: 0x0401B018 RID: 110616
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public string[] CustomExcludePartNames;

		// Token: 0x0401B019 RID: 110617
		public bool HiddenAfterEffect;

		// Token: 0x0401B01A RID: 110618
		public ECharacterBodySpecifiedType? SpecifiedBodyType;

		// Token: 0x0401B01B RID: 110619
		public ECharacterSlotSpecifiedType? SpecifiedSlotType;

		// Token: 0x0401B01C RID: 110620
		public ECharacterControllerApplyType? MaterialModifyType;

		// Token: 0x0401B01D RID: 110621
		public bool UseRim;

		// Token: 0x0401B01E RID: 110622
		public CharMaterialControlFloatGroup RimRange;

		// Token: 0x0401B01F RID: 110623
		public CharMaterialControlColorGroup RimColor;

		// Token: 0x0401B020 RID: 110624
		public CharMaterialControlFloatGroup RimIntensity;

		// Token: 0x0401B021 RID: 110625
		public int RimUseTex;

		// Token: 0x0401B022 RID: 110626
		public FLinearColor? RimChannel;

		// Token: 0x0401B023 RID: 110627
		public bool RimRevertProperty;

		// Token: 0x0401B024 RID: 110628
		public bool UseDissolve;

		// Token: 0x0401B025 RID: 110629
		public FLinearColor? DissolveChannel;

		// Token: 0x0401B026 RID: 110630
		public CharMaterialControlFloatGroup DissolveProgress;

		// Token: 0x0401B027 RID: 110631
		public CharMaterialControlFloatGroup DissolveSmooth;

		// Token: 0x0401B028 RID: 110632
		public CharMaterialControlFloatGroup DissolveColorIntensity;

		// Token: 0x0401B029 RID: 110633
		public CharMaterialControlColorGroup DissolveColor;

		// Token: 0x0401B02A RID: 110634
		public bool DissolveRevertProperty;

		// Token: 0x0401B02B RID: 110635
		public bool UseOutline;

		// Token: 0x0401B02C RID: 110636
		public bool OutlineRevertProperty;

		// Token: 0x0401B02D RID: 110637
		public float OutlineUseTex;

		// Token: 0x0401B02E RID: 110638
		public bool UseOuterOutlineEffect;

		// Token: 0x0401B02F RID: 110639
		public CharMaterialControlFloatGroup OutlineWidth;

		// Token: 0x0401B030 RID: 110640
		public CharMaterialControlColorGroup OutlineColor;

		// Token: 0x0401B031 RID: 110641
		public CharMaterialControlFloatGroup OutlineIntensity;

		// Token: 0x0401B032 RID: 110642
		public UMaterialInterface ReplaceMaterialInterface;

		// Token: 0x0401B033 RID: 110643
		public bool UseParameterModify;

		// Token: 0x0401B034 RID: 110644
		public FName[] ColorParameterNames;

		// Token: 0x0401B035 RID: 110645
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public CharMaterialControlColorGroup[] ColorParameterValues;

		// Token: 0x0401B036 RID: 110646
		public FName[] FloatParameterNames;

		// Token: 0x0401B037 RID: 110647
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public CharMaterialControlFloatGroup[] FloatParameterValues;

		// Token: 0x0401B038 RID: 110648
		public bool RevertMaterial;

		// Token: 0x0401B039 RID: 110649
		public CharMaterialControlColorGroup BaseColor;

		// Token: 0x0401B03A RID: 110650
		public CharMaterialControlColorGroup EmissionColor;

		// Token: 0x0401B03B RID: 110651
		public CharMaterialControlFloatGroup EmissionIntensity;

		// Token: 0x0401B03C RID: 110652
		public CharMaterialControlFloatGroup BaseColorIntensity;

		// Token: 0x0401B03D RID: 110653
		public float BaseUseTex;

		// Token: 0x0401B03E RID: 110654
		public float EmissionUseTex;

		// Token: 0x0401B03F RID: 110655
		public bool UseColor;

		// Token: 0x0401B040 RID: 110656
		public bool ColorRevertProperty;

		// Token: 0x0401B041 RID: 110657
		public bool UseTextureSample;

		// Token: 0x0401B042 RID: 110658
		public UTexture2D MaskTexture;

		// Token: 0x0401B043 RID: 110659
		public FLinearColor? UvSelection;

		// Token: 0x0401B044 RID: 110660
		public float UseScreenUv;

		// Token: 0x0401B045 RID: 110661
		public CharMaterialControlColorGroup TextureScaleAndOffset;

		// Token: 0x0401B046 RID: 110662
		public CharMaterialControlColorGroup TextureSpeed;

		// Token: 0x0401B047 RID: 110663
		public CharMaterialControlColorGroup TextureColorTint;

		// Token: 0x0401B048 RID: 110664
		public CharMaterialControlFloatGroup Rotation;

		// Token: 0x0401B049 RID: 110665
		public float UseAlphaToMask;

		// Token: 0x0401B04A RID: 110666
		public CharMaterialControlFloatGroup TextureMaskRange;

		// Token: 0x0401B04B RID: 110667
		public bool TextureSampleRevertProperty;

		// Token: 0x0401B04C RID: 110668
		public bool UseMotionOffset;

		// Token: 0x0401B04D RID: 110669
		public float MotionAffectVertexRange;

		// Token: 0x0401B04E RID: 110670
		public float MotionOffsetLength;

		// Token: 0x0401B04F RID: 110671
		public CharMaterialControlFloatGroup MotionNoiseSpeed;

		// Token: 0x0401B050 RID: 110672
		public bool MotionOffsetRevertProperty;

		// Token: 0x0401B051 RID: 110673
		public bool UseDitherEffect;

		// Token: 0x0401B052 RID: 110674
		public CharMaterialControlFloatGroup DitherValue;

		// Token: 0x0401B053 RID: 110675
		public bool DitherRevertProperty;

		// Token: 0x0401B054 RID: 110676
		public bool UseCustomMaterialEffect;

		// Token: 0x0401B055 RID: 110677
		public bool CustomRevertProperty;

		// Token: 0x0401B056 RID: 110678
		public FName[] CustomColorParameterNames;

		// Token: 0x0401B057 RID: 110679
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public CharMaterialControlColorGroup[] CustomColorParameterValues;

		// Token: 0x0401B058 RID: 110680
		public FName[] CustomFloatParameterNames;

		// Token: 0x0401B059 RID: 110681
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public CharMaterialControlFloatGroup[] CustomFloatParameterValues;

		// Token: 0x0401B05A RID: 110682
		public FName[] CustomTextureParameterNames;

		// Token: 0x0401B05B RID: 110683
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public CharMaterialControlTextureGroup[] CustomTextureParameterValues;
	}
}
