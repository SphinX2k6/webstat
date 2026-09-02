using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.Manager;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using CSharpScript.Core.Common;
using UnrealEngine;

namespace CSharpScript.Game.Render
{
	// Token: 0x02004794 RID: 18324
	[NullableContext(1)]
	[Nullable(0)]
	public class RenderUtil : IStaticVariableResetter
	{
		// Token: 0x0602F8C9 RID: 194761 RVA: 0x00B54806 File Offset: 0x00B52A06
		static RenderUtil()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(RenderUtil.CreateStaticDefaultValue), new Action(RenderUtil.ResetStaticDefaultValue));
		}

		// Token: 0x0602F8CA RID: 194762 RVA: 0x00B54825 File Offset: 0x00B52A25
		public static void CreateStaticDefaultValue()
		{
			RenderUtil.PsoSyncModeDepth = 0;
		}

		// Token: 0x0602F8CB RID: 194763 RVA: 0x00B5482D File Offset: 0x00B52A2D
		public static void ResetStaticDefaultValue()
		{
			RenderUtil.PsoSyncModeDepth = 0;
		}

		// Token: 0x0602F8CC RID: 194764 RVA: 0x00B54838 File Offset: 0x00B52A38
		public static CharRenderBase[] GetRenderComps(ECharacterRenderingType renderType, bool useMaterialContainerV2, bool monsterUseBodyEffect)
		{
			List<CharRenderBase> list = new List<CharRenderBase>();
			if (useMaterialContainerV2)
			{
				list.Add(new CharMaterialControllerV2());
				list.Add(new CharMaterialContainerV2());
			}
			else
			{
				list.Add(new CharMaterialController());
				list.Add(new CharMaterialContainer());
			}
			switch (renderType)
			{
			case ECharacterRenderingType.LocalPlayer:
				list.Add(new CharDitherEffect());
				list.Add(new CharSceneInteraction());
				list.Add(new CharPropertyModifier());
				list.Add(new CharBodyEffect());
				list.Add(new CharDecalShadow());
				list.Add(new CharGrassInteraction());
				list.Add(new CharEnviInteractionEffect());
				break;
			case ECharacterRenderingType.RemotePlayer:
				list.Add(new CharDitherEffect());
				list.Add(new CharSceneInteraction());
				list.Add(new CharPropertyModifier());
				list.Add(new CharBodyEffect());
				list.Add(new CharDecalShadow());
				list.Add(new CharGrassInteraction());
				list.Add(new CharEnviInteractionEffect());
				break;
			case ECharacterRenderingType.Monster:
				list.Add(new CharDitherEffect());
				list.Add(new CharSceneInteraction());
				list.Add(new CharPropertyModifier());
				list.Add(new CharDecalShadow());
				list.Add(new CharGrassInteraction());
				if (monsterUseBodyEffect)
				{
					list.Add(new CharBodyEffect());
				}
				break;
			case ECharacterRenderingType.Npc:
				list.Add(new CharDitherEffect());
				list.Add(new CharDecalShadow());
				list.Add(new CharGrassInteraction());
				break;
			case ECharacterRenderingType.Pet:
				list.Add(new CharDitherEffect());
				list.Add(new CharSceneInteraction());
				list.Add(new CharDecalShadow());
				break;
			case ECharacterRenderingType.UI:
				list.Add(new CharDitherEffect());
				break;
			case ECharacterRenderingType.Default:
				list.Add(new CharDitherEffect());
				break;
			case ECharacterRenderingType.Effect:
				list.Add(new CharDitherEffect());
				break;
			}
			return list.ToArray();
		}

		// Token: 0x0602F8CD RID: 194765 RVA: 0x00B54A0A File Offset: 0x00B52C0A
		public static float GetFloat(FKuroCurveFloat curveFloat, float factor)
		{
			return UKuroCurveLibrary.GetValue_Float(curveFloat, factor);
		}

		// Token: 0x0602F8CE RID: 194766 RVA: 0x00B54A14 File Offset: 0x00B52C14
		public static FLinearColor GetColor(FKuroCurveLinearColor curveColor, float factor)
		{
			return UKuroCurveLibrary.GetValue_LinearColor(curveColor, factor);
		}

		// Token: 0x0602F8CF RID: 194767 RVA: 0x00B54A20 File Offset: 0x00B52C20
		public static float GetFloatFromGroup(CharMaterialControlFloatGroup floatInfo, InterpolateFactor factor)
		{
			switch (factor.Type)
			{
			case EInterpolateRangeType.Start:
				if (floatInfo.StartConstant != null)
				{
					return floatInfo.StartConstant.Value;
				}
				return RenderUtil.GetFloat(floatInfo.Start, factor.Factor);
			case EInterpolateRangeType.Loop:
				if (floatInfo.LoopConstant != null)
				{
					return floatInfo.LoopConstant.Value;
				}
				return RenderUtil.GetFloat(floatInfo.Loop, factor.Factor);
			case EInterpolateRangeType.End:
				if (floatInfo.EndConstant != null)
				{
					return floatInfo.EndConstant.Value;
				}
				return RenderUtil.GetFloat(floatInfo.End, factor.Factor);
			default:
				return floatInfo.Loop.Constant;
			}
		}

		// Token: 0x0602F8D0 RID: 194768 RVA: 0x00B54AD8 File Offset: 0x00B52CD8
		public static FLinearColor GetColorFromGroup(CharMaterialControlColorGroup colorInfo, InterpolateFactor factor)
		{
			switch (factor.Type)
			{
			case EInterpolateRangeType.Start:
				if (colorInfo.StartConstant != null)
				{
					return colorInfo.StartConstant.Value;
				}
				return RenderUtil.GetColor(colorInfo.Start, factor.Factor);
			case EInterpolateRangeType.Loop:
				if (colorInfo.LoopConstant != null)
				{
					return colorInfo.LoopConstant.Value;
				}
				return RenderUtil.GetColor(colorInfo.Loop, factor.Factor);
			case EInterpolateRangeType.End:
				if (colorInfo.EndConstant != null)
				{
					return colorInfo.EndConstant.Value;
				}
				return RenderUtil.GetColor(colorInfo.End, factor.Factor);
			default:
				return colorInfo.Loop.Constant;
			}
		}

		// Token: 0x0602F8D1 RID: 194769 RVA: 0x00B54B90 File Offset: 0x00B52D90
		[return: Nullable(2)]
		public static UTexture2D GetTextureFromGroup(CharMaterialControlTextureGroup textureInfo, InterpolateFactor factor)
		{
			switch (factor.Type)
			{
			case EInterpolateRangeType.Start:
				return textureInfo.Start;
			case EInterpolateRangeType.Loop:
				return textureInfo.Loop;
			case EInterpolateRangeType.End:
				return textureInfo.End;
			default:
				return null;
			}
		}

		// Token: 0x0602F8D2 RID: 194770 RVA: 0x00B54BCE File Offset: 0x00B52DCE
		public static double Lerp(double a, double b, double alpha)
		{
			return a + alpha * (b - a);
		}

		// Token: 0x0602F8D3 RID: 194771 RVA: 0x00B54BD7 File Offset: 0x00B52DD7
		public static double Max(double a, double b)
		{
			if (a <= b)
			{
				return b;
			}
			return a;
		}

		// Token: 0x0602F8D4 RID: 194772 RVA: 0x00B54BE0 File Offset: 0x00B52DE0
		public static double Min(double a, double b)
		{
			if (a >= b)
			{
				return b;
			}
			return a;
		}

		// Token: 0x0602F8D5 RID: 194773 RVA: 0x00B54BEC File Offset: 0x00B52DEC
		public static double Clamp(double value, double min, double max)
		{
			double num = value;
			if (num <= min)
			{
				num = min;
			}
			if (num >= max)
			{
				num = max;
			}
			return num;
		}

		// Token: 0x0602F8D6 RID: 194774 RVA: 0x00B54C08 File Offset: 0x00B52E08
		public static void LerpVector(FVectorDouble from, FVectorDouble to, double alpha, double[] ret)
		{
			double alpha2 = RenderUtil.Clamp(alpha, 0.0, 1.0);
			ret[0] = RenderUtil.Lerp(from.X, to.X, alpha2);
			ret[1] = RenderUtil.Lerp(from.Y, to.Y, alpha2);
			ret[2] = RenderUtil.Lerp(from.Z, to.Z, alpha2);
		}

		// Token: 0x0602F8D7 RID: 194775 RVA: 0x00B54C6D File Offset: 0x00B52E6D
		public static bool StringIsNullOrEmpty(string value)
		{
			return string.IsNullOrEmpty(value);
		}

		// Token: 0x0602F8D8 RID: 194776 RVA: 0x00B54C78 File Offset: 0x00B52E78
		public static FLinearColor GetSelectedChannel(ECharacterControllerChannelSwitch channel)
		{
			switch (channel)
			{
			case ECharacterControllerChannelSwitch.RGB:
				return new FLinearColor(-1f, 0f, 0f, 0f);
			case ECharacterControllerChannelSwitch.R:
				return new FLinearColor(1f, 0f, 0f, 0f);
			case ECharacterControllerChannelSwitch.G:
				return new FLinearColor(0f, 1f, 0f, 0f);
			case ECharacterControllerChannelSwitch.B:
				return new FLinearColor(0f, 0f, 1f, 0f);
			case ECharacterControllerChannelSwitch.A:
				return new FLinearColor(0f, 0f, 0f, 1f);
			default:
				return new FLinearColor(0f, 0f, 0f, 0f);
			}
		}

		// Token: 0x0602F8D9 RID: 194777 RVA: 0x00B54D3F File Offset: 0x00B52F3F
		public static void OpenToonSceneShadow()
		{
			if (GlobalData.World == null)
			{
				return;
			}
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.Shadow.ToonSceneShadowIntensity 1", null);
		}

		// Token: 0x0602F8DA RID: 194778 RVA: 0x00B54D59 File Offset: 0x00B52F59
		public static void CloseToonSceneShadow()
		{
			if (GlobalData.World == null)
			{
				return;
			}
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.Shadow.ToonSceneShadowIntensity 0", null);
		}

		// Token: 0x0602F8DB RID: 194779 RVA: 0x00B54D73 File Offset: 0x00B52F73
		public static void OpenMobileSpotLightShadow()
		{
			if (GlobalData.World == null)
			{
				return;
			}
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.Mobile.EnableKuroSpotlightsShadow 1", null);
		}

		// Token: 0x0602F8DC RID: 194780 RVA: 0x00B54D8D File Offset: 0x00B52F8D
		public static void CloseMobileSpotLightShadow()
		{
			if (GlobalData.World == null)
			{
				return;
			}
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.Mobile.EnableKuroSpotlightsShadow 0", null);
		}

		// Token: 0x0602F8DD RID: 194781 RVA: 0x00B54DA7 File Offset: 0x00B52FA7
		public static void CloseVelocityScreenSizeCull()
		{
			if (GlobalData.World == null)
			{
				return;
			}
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.VelocityScreenSizeCull 0", null);
		}

		// Token: 0x0602F8DE RID: 194782 RVA: 0x00B54DC1 File Offset: 0x00B52FC1
		public static void EnableVelocityScreenSizeCull()
		{
			if (GlobalData.World == null)
			{
				return;
			}
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.VelocityScreenSizeCull 0.01", null);
		}

		// Token: 0x0602F8DF RID: 194783 RVA: 0x00B54DDC File Offset: 0x00B52FDC
		public static void BeginPSOSyncMode()
		{
			if (GlobalData.World == null)
			{
				return;
			}
			RenderUtil.PsoSyncModeDepth++;
			if (RenderUtil.PsoSyncModeDepth > 1)
			{
				return;
			}
			Singleton<Log>.Instance.Info(ELogModule.RenderUtil, ELogAuthor.ZBK, "Begin pso sync mode", default(ReadOnlySpan<ValueTuple<string, object>>));
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.PSO.CompilationMode 1", null);
			if (Singleton<Info>.Instance.PlatformType == ESourcePlatformType.Android)
			{
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.OpenGL.ProgramBinarySyncCreate 1", null);
				return;
			}
			if (Singleton<Info>.Instance.PlatformType == ESourcePlatformType.Windows)
			{
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.DX11AsyncCompileShader 0", null);
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.DX12PSOStreaming 0", null);
			}
		}

		// Token: 0x0602F8E0 RID: 194784 RVA: 0x00B54E80 File Offset: 0x00B53080
		public static void EndPSOSyncMode()
		{
			if (RenderUtil.PsoSyncModeDepth <= 0)
			{
				return;
			}
			RenderUtil.PsoSyncModeDepth--;
			if (RenderUtil.PsoSyncModeDepth > 0 || GlobalData.World == null)
			{
				return;
			}
			Singleton<Log>.Instance.Info(ELogModule.RenderUtil, ELogAuthor.ZBK, "End pso sync mode", default(ReadOnlySpan<ValueTuple<string, object>>));
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.PSO.CompilationMode 3", null);
			if (Singleton<Info>.Instance.PlatformType == ESourcePlatformType.Android)
			{
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.OpenGL.ProgramBinarySyncCreate 0", null);
				return;
			}
			if (Singleton<Info>.Instance.PlatformType == ESourcePlatformType.Windows)
			{
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.DX11AsyncCompileShader 1", null);
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.DX12PSOStreaming 1", null);
			}
		}

		// Token: 0x0602F8E1 RID: 194785 RVA: 0x00B54F29 File Offset: 0x00B53129
		public static void SetNeedRenderKuroToonDepth()
		{
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.kuro.NeedRenderKuroToonDepth 1", null);
		}

		// Token: 0x0602F8E2 RID: 194786 RVA: 0x00B54F3B File Offset: 0x00B5313B
		public static void UnsetNeedRenderKuroToonDepth()
		{
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.kuro.NeedRenderKuroToonDepth 0", null);
		}

		// Token: 0x0401B322 RID: 111394
		private static int PsoSyncModeDepth;
	}
}
