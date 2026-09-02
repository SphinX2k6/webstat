using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Aki.Config;
using Aki.Protocol;
using AkiClient.Game.Aki.Render.RuntimeBP.Interaction;
using CSharpScript.Game.Module.Dango.DangoLogic;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;
using UnrealEngine.Extension;

// Token: 0x020026DE RID: 9950
[NullableContext(1)]
[Nullable(0)]
public class RacingBetsDiceCommand : RacingBetsCommandBase
{
	// Token: 0x170018D5 RID: 6357
	// (get) Token: 0x06013A24 RID: 80420 RVA: 0x0057919E File Offset: 0x0057739E
	public override ERacingBetsCommandType CommandType
	{
		get
		{
			return ERacingBetsCommandType.Dice;
		}
	}

	// Token: 0x06013A25 RID: 80421 RVA: 0x005791A4 File Offset: 0x005773A4
	public void Init(int round, List<DangoIdToDiceNum> dangoDiceList)
	{
		this.Round = round;
		this.DangoDiceList = dangoDiceList;
		this.DiceOutlineBp = (UKuroCollectActorComponent.GetActorWithTag(FNameUtil.GetDynamicFName("DiceBp").Value, ECollectActorType.UI) as BP_DiceOL_C);
		this.DiceCamera = (UKuroCollectActorComponent.GetActorWithTag(FNameUtil.GetDynamicFName("DiceCamera").Value, ECollectActorType.UI) as ACineCameraActor);
	}

	// Token: 0x06013A26 RID: 80422 RVA: 0x00579208 File Offset: 0x00577408
	public override UniTask OnExecute()
	{
		RacingBetsDiceCommand.<OnExecute>d__12 <OnExecute>d__;
		<OnExecute>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnExecute>d__.<>4__this = this;
		<OnExecute>d__.<>1__state = -1;
		<OnExecute>d__.<>t__builder.Start<RacingBetsDiceCommand.<OnExecute>d__12>(ref <OnExecute>d__);
		return <OnExecute>d__.<>t__builder.Task;
	}

	// Token: 0x06013A27 RID: 80423 RVA: 0x0057924C File Offset: 0x0057744C
	private void InitDiceParameter(List<DangoIdToDiceNum> dangoDiceList)
	{
		this.ProcessName = FNameUtil.GetDynamicFName("Ani_Process").Value;
		UKismetMaterialLibrary.SetScalarParameterValue(GlobalData.GameInstance.GetWorld(), this.DiceMaterialParameterCollection, this.ProcessName, 0f);
		UKismetMaterialLibrary.SetScalarParameterValue(GlobalData.GameInstance.GetWorld(), this.DiceMaterialParameterCollection, FNameUtil.GetDynamicFName("DiceNub").Value, (float)dangoDiceList.Count);
		int num = Random.Shared.Next(RacingBetsDefine.RacingBetsDiceIndexList.Length);
		UKismetMaterialLibrary.SetScalarParameterValue(GlobalData.GameInstance.GetWorld(), this.DiceMaterialParameterCollection, FNameUtil.GetDynamicFName("Ani_Num").Value, (float)RacingBetsDefine.RacingBetsDiceIndexList[num]);
		for (int i = 0; i < dangoDiceList.Count; i++)
		{
			UObject world = GlobalData.GameInstance.GetWorld();
			UMaterialParameterCollection diceMaterialParameterCollection = this.DiceMaterialParameterCollection;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(11, 1);
			defaultInterpolatedStringHandler.AppendLiteral("DicePoints_");
			defaultInterpolatedStringHandler.AppendFormatted<int>(i + 1);
			UKismetMaterialLibrary.SetScalarParameterValue(world, diceMaterialParameterCollection, FNameUtil.GetDynamicFName(defaultInterpolatedStringHandler.ToStringAndClear()).Value, (float)dangoDiceList[i].Num);
			DangoConfig instance = ConfigBase<DangoConfig>.Instance;
			Dice? dice = (instance != null) ? instance.GetDiceById(dangoDiceList[i].DiceId) : null;
			if (dice != null)
			{
				FLinearColor? flinearColor = this.ParseLineColorString(dice.Value.DiceColor);
				if (flinearColor != null)
				{
					UObject world2 = GlobalData.GameInstance.GetWorld();
					UMaterialParameterCollection diceMaterialParameterCollection2 = this.DiceMaterialParameterCollection;
					defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(10, 1);
					defaultInterpolatedStringHandler.AppendLiteral("DiceColor_");
					defaultInterpolatedStringHandler.AppendFormatted<int>(i + 1);
					FName value = FNameUtil.GetDynamicFName(defaultInterpolatedStringHandler.ToStringAndClear()).Value;
					FLinearColor value2 = flinearColor.Value;
					UKismetMaterialLibrary.SetVectorParameterValue(world2, diceMaterialParameterCollection2, value, value2);
				}
				FLinearColor? flinearColor2 = this.ParseLineColorString(dice.Value.DiceNumColor);
				if (flinearColor2 != null)
				{
					UObject world3 = GlobalData.GameInstance.GetWorld();
					UMaterialParameterCollection diceMaterialParameterCollection3 = this.DiceMaterialParameterCollection;
					defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 1);
					defaultInterpolatedStringHandler.AppendLiteral("NumColor_");
					defaultInterpolatedStringHandler.AppendFormatted<int>(i + 1);
					FName value3 = FNameUtil.GetDynamicFName(defaultInterpolatedStringHandler.ToStringAndClear()).Value;
					FLinearColor value2 = flinearColor2.Value;
					UKismetMaterialLibrary.SetVectorParameterValue(world3, diceMaterialParameterCollection3, value3, value2);
				}
				FLinearColor? flinearColor3 = this.ParseLineColorString(dice.Value.DiceHighLightColor);
				if (flinearColor3 != null)
				{
					UObject world4 = GlobalData.GameInstance.GetWorld();
					UMaterialParameterCollection diceMaterialParameterCollection4 = this.DiceMaterialParameterCollection;
					defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(16, 1);
					defaultInterpolatedStringHandler.AppendLiteral("HeighLightColor_");
					defaultInterpolatedStringHandler.AppendFormatted<int>(i + 1);
					FName value4 = FNameUtil.GetDynamicFName(defaultInterpolatedStringHandler.ToStringAndClear()).Value;
					FLinearColor value2 = flinearColor3.Value;
					UKismetMaterialLibrary.SetVectorParameterValue(world4, diceMaterialParameterCollection4, value4, value2);
				}
			}
		}
	}

	// Token: 0x06013A28 RID: 80424 RVA: 0x00579500 File Offset: 0x00577700
	private UniTask PlayDiceOrderAnim()
	{
		RacingBetsDiceCommand.<PlayDiceOrderAnim>d__14 <PlayDiceOrderAnim>d__;
		<PlayDiceOrderAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayDiceOrderAnim>d__.<>4__this = this;
		<PlayDiceOrderAnim>d__.<>1__state = -1;
		<PlayDiceOrderAnim>d__.<>t__builder.Start<RacingBetsDiceCommand.<PlayDiceOrderAnim>d__14>(ref <PlayDiceOrderAnim>d__);
		return <PlayDiceOrderAnim>d__.<>t__builder.Task;
	}

	// Token: 0x06013A29 RID: 80425 RVA: 0x00579544 File Offset: 0x00577744
	private UniTask PlayFreeCameraBlend()
	{
		RacingBetsDiceCommand.<PlayFreeCameraBlend>d__15 <PlayFreeCameraBlend>d__;
		<PlayFreeCameraBlend>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayFreeCameraBlend>d__.<>4__this = this;
		<PlayFreeCameraBlend>d__.<>1__state = -1;
		<PlayFreeCameraBlend>d__.<>t__builder.Start<RacingBetsDiceCommand.<PlayFreeCameraBlend>d__15>(ref <PlayFreeCameraBlend>d__);
		return <PlayFreeCameraBlend>d__.<>t__builder.Task;
	}

	// Token: 0x06013A2A RID: 80426 RVA: 0x00579588 File Offset: 0x00577788
	private UniTask PlayDiceAnim()
	{
		RacingBetsDiceCommand.<PlayDiceAnim>d__16 <PlayDiceAnim>d__;
		<PlayDiceAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayDiceAnim>d__.<>4__this = this;
		<PlayDiceAnim>d__.<>1__state = -1;
		<PlayDiceAnim>d__.<>t__builder.Start<RacingBetsDiceCommand.<PlayDiceAnim>d__16>(ref <PlayDiceAnim>d__);
		return <PlayDiceAnim>d__.<>t__builder.Task;
	}

	// Token: 0x06013A2B RID: 80427 RVA: 0x005795CB File Offset: 0x005777CB
	public override string LogInfo()
	{
		return "RacingBetsDiceCommand";
	}

	// Token: 0x06013A2C RID: 80428 RVA: 0x005795D4 File Offset: 0x005777D4
	private FLinearColor? ParseLineColorString(string colorString)
	{
		Match match = this.DiceColorRegex.Match(colorString);
		if (!match.Success)
		{
			return null;
		}
		float r = float.Parse(match.Groups[1].Value);
		float g = float.Parse(match.Groups[2].Value);
		float b = float.Parse(match.Groups[3].Value);
		float a = float.Parse(match.Groups[4].Value);
		return new FLinearColor?(new FLinearColor(r, g, b, a));
	}

	// Token: 0x06013A2D RID: 80429 RVA: 0x00579670 File Offset: 0x00577870
	private float GetDynamicFov(UCineCameraComponent cameraComponent)
	{
		float sensorAspectRatio = cameraComponent.Filmback.SensorAspectRatio;
		float fieldOfView = cameraComponent.FieldOfView;
		Vector2D viewportSize = Singleton<UiLayer>.Instance.GetViewportSize();
		if (viewportSize.X / viewportSize.Y > (double)sensorAspectRatio)
		{
			return fieldOfView;
		}
		return this.GetDynamicVerticalFieldOfView(fieldOfView, sensorAspectRatio);
	}

	// Token: 0x06013A2E RID: 80430 RVA: 0x005796B8 File Offset: 0x005778B8
	private float GetDynamicVerticalFieldOfView(float fov, float aspectRatio)
	{
		Vector2D viewportSize = Singleton<UiLayer>.Instance.GetViewportSize();
		float num = MathCommon.DegreeToRadian(fov);
		double num2 = viewportSize.X / viewportSize.Y;
		return MathCommon.RadianToDegree((float)(Math.Atan((double)aspectRatio / num2 * Math.Tan((double)(num / 2f))) * 2.0));
	}

	// Token: 0x040098B7 RID: 39095
	private int Round;

	// Token: 0x040098B8 RID: 39096
	private List<DangoIdToDiceNum> DangoDiceList;

	// Token: 0x040098B9 RID: 39097
	[Nullable(2)]
	private UMaterialParameterCollection DiceMaterialParameterCollection;

	// Token: 0x040098BA RID: 39098
	[Nullable(2)]
	private BP_DiceOL_C DiceOutlineBp;

	// Token: 0x040098BB RID: 39099
	[Nullable(2)]
	private ACineCameraActor DiceCamera;

	// Token: 0x040098BC RID: 39100
	private FName ProcessName;

	// Token: 0x040098BD RID: 39101
	protected readonly global::Vector Location = global::Vector.Create();

	// Token: 0x040098BE RID: 39102
	protected readonly global::Rotator Rotator = global::Rotator.Create();

	// Token: 0x040098BF RID: 39103
	private readonly Regex DiceColorRegex = new Regex("R=([\\d.]+),G=([\\d.]+),B=([\\d.]+),A=([\\d.]+)");
}
