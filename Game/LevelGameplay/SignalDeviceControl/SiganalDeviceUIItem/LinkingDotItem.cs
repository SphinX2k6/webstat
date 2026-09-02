using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.SignalDeviceControl.SiganalDeviceUIItem
{
	// Token: 0x02006AFE RID: 27390
	[NullableContext(2)]
	[Nullable(0)]
	public class LinkingDotItem : UiPanelBase
	{
		// Token: 0x06043B37 RID: 277303 RVA: 0x01176130 File Offset: 0x01174330
		protected unsafe override void OnRegisterComponent()
		{
			List<ValueTuple<int, Type>> componentRegisterInfos;
			if (ModelBase<SignalDeviceModel>.Instance.ViewType != EViewType.ChasingMoon)
			{
				int num = 8;
				List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
				CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
				componentRegisterInfos = list;
				Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
				int num2 = 0;
				*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(6, typeof(UUISprite));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			}
			else
			{
				int num2 = 14;
				List<ValueTuple<int, Type>> list2 = new List<ValueTuple<int, Type>>(num2);
				CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list2, num2);
				componentRegisterInfos = list2;
				Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list2);
				int num = 0;
				*span[num] = new ValueTuple<int, Type>(0, typeof(UUISprite));
				num++;
				*span[num] = new ValueTuple<int, Type>(1, typeof(UUISprite));
				num++;
				*span[num] = new ValueTuple<int, Type>(2, typeof(UUISprite));
				num++;
				*span[num] = new ValueTuple<int, Type>(3, typeof(UUISprite));
				num++;
				*span[num] = new ValueTuple<int, Type>(6, typeof(UUISprite));
				num++;
				*span[num] = new ValueTuple<int, Type>(5, typeof(UUISprite));
				num++;
				*span[num] = new ValueTuple<int, Type>(4, typeof(UUIItem));
				num++;
				*span[num] = new ValueTuple<int, Type>(7, typeof(UUIItem));
				num++;
				*span[num] = new ValueTuple<int, Type>(8, typeof(UUISprite));
				num++;
				*span[num] = new ValueTuple<int, Type>(9, typeof(UUISprite));
				num++;
				*span[num] = new ValueTuple<int, Type>(10, typeof(UUISprite));
				num++;
				*span[num] = new ValueTuple<int, Type>(11, typeof(UUISprite));
				num++;
				*span[num] = new ValueTuple<int, Type>(12, typeof(UUIItem));
				num++;
				*span[num] = new ValueTuple<int, Type>(13, typeof(UUIExtendToggle));
			}
			this.ComponentRegisterInfos = componentRegisterInfos;
		}

		// Token: 0x06043B38 RID: 277304 RVA: 0x01176460 File Offset: 0x01174660
		protected override void OnStart()
		{
			this.SprDot = base.GetSprite(0);
			this.SprDotLight = base.GetSprite(1);
			this.SprCorner = base.GetSprite(2);
			this.SprCornerLight = base.GetSprite(3);
			this.SprRay = base.GetSprite(6);
			this.SprUpper = base.GetSprite(5);
			this.PnlRota = base.GetItem(4);
			this.FxBoost = base.GetItem(7);
			UUISprite sprDot = this.SprDot;
			if (sprDot != null)
			{
				sprDot.SetUIActive(false);
			}
			UUISprite sprDotLight = this.SprDotLight;
			if (sprDotLight != null)
			{
				sprDotLight.SetUIActive(false);
			}
			UUISprite sprCorner = this.SprCorner;
			if (sprCorner != null)
			{
				sprCorner.SetUIActive(false);
			}
			UUISprite sprCornerLight = this.SprCornerLight;
			if (sprCornerLight != null)
			{
				sprCornerLight.SetUIActive(false);
			}
			UUISprite sprRay = this.SprRay;
			if (sprRay != null)
			{
				sprRay.SetUIActive(false);
			}
			UUISprite sprUpper = this.SprUpper;
			if (sprUpper != null)
			{
				sprUpper.SetUIActive(false);
			}
			UUIItem fxBoost = this.FxBoost;
			if (fxBoost != null)
			{
				fxBoost.SetUIActive(false);
			}
			if (ModelBase<SignalDeviceModel>.Instance.ViewType == EViewType.ChasingMoon)
			{
				this.SprAnimLine = base.GetSprite(9);
				this.SprAnimLineWhite = base.GetSprite(8);
				this.SprAnimDot = base.GetSprite(10);
				this.SprAnimLine.SetUIActive(false);
				this.SprAnimLineWhite.SetUIActive(false);
				this.SprAnimDot.SetUIActive(false);
				this.LevelSequencePlayer = new LevelSequencePlayer(base.GetRootItem());
			}
			Singleton<EventSystem>.Instance.Add<bool, int, bool, int, bool>(EEventName.OnSignalDeviceLinking, new Action<bool, int, bool, int, bool>(this.OnSignalDeviceLinking));
		}

		// Token: 0x06043B39 RID: 277305 RVA: 0x011765DA File Offset: 0x011747DA
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSignalDeviceLinking, new Action<bool, int, bool, int, bool>(this.OnSignalDeviceLinking));
		}

		// Token: 0x06043B3A RID: 277306 RVA: 0x011765F8 File Offset: 0x011747F8
		public void InitIcon(EPieceColorType color)
		{
			bool flag = ModelBase<SignalDeviceModel>.Instance.ViewType == EViewType.ChasingMoon;
			string text;
			LinkingDotItem.ColorDotIconMap.TryGetValue(color, out text);
			string text2 = text + "Light";
			string text3;
			LinkingDotItem.ColorCornerIconMap.TryGetValue(color, out text3);
			string text4;
			LinkingDotItem.ColorRayIconMap.TryGetValue(color, out text4);
			if (flag)
			{
				text += "CM";
				text2 += "CM";
				text3 += "CM";
				text4 += "CM";
			}
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(text);
			this.SetSpriteByPath(resourcePath, this.SprDot, false, null, null);
			string resourcePath2 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(text2);
			this.SetSpriteByPath(resourcePath2, this.SprDotLight, false, null, null);
			string resourcePath3 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(text3);
			this.SetSpriteByPath(resourcePath3, this.SprCornerLight, false, null, null);
			string resourcePath4 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(text4);
			this.SetSpriteByPath(resourcePath4, this.SprRay, false, null, null);
			string hexStr;
			LinkingDotItem.ColorMap.TryGetValue(color, out hexStr);
			this.SprUpper.SetColor(FColor.FromHex(hexStr));
			string hexStr2;
			LinkingDotItem.FxColorMap.TryGetValue(color, out hexStr2);
			this.FxBoost.SetColor(FColor.FromHex(hexStr2));
			if (flag)
			{
				string resourceId;
				LinkingDotItem.ColorAnimLineMap.TryGetValue(color, out resourceId);
				string resourcePath5 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
				this.SetSpriteByPath(resourcePath5, this.SprAnimLine, false, null, null);
				string resourceId2;
				LinkingDotItem.ColorAnimDotMap.TryGetValue(color, out resourceId2);
				string resourcePath6 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId2);
				this.SetSpriteByPath(resourcePath6, this.SprAnimDot, false, null, null);
				string hexStr3;
				LinkingDotItem.CmColorMap.TryGetValue(color, out hexStr3);
				this.SprAnimLineWhite.SetColor(FColor.FromHex(hexStr3));
				string hexStr4;
				LinkingDotItem.CmAnimColorMap.TryGetValue(color, out hexStr4);
				UUISprite sprite = base.GetSprite(11);
				if (sprite != null)
				{
					sprite.SetColor(FColor.FromHex(hexStr4));
				}
				UUISprite sprite2 = base.GetSprite(11);
				if (sprite2 != null)
				{
					sprite2.SetUIActive(false);
				}
				UUIItem item = base.GetItem(12);
				if (item != null)
				{
					item.SetColor(FColor.FromHex(hexStr4));
				}
			}
			this.SetLight(false);
			this.ResetIcon();
		}

		// Token: 0x06043B3B RID: 277307 RVA: 0x0117684C File Offset: 0x01174A4C
		public UniTask ResetIcon()
		{
			LinkingDotItem.<ResetIcon>d__26 <ResetIcon>d__;
			<ResetIcon>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ResetIcon>d__.<>4__this = this;
			<ResetIcon>d__.<>1__state = -1;
			<ResetIcon>d__.<>t__builder.Start<LinkingDotItem.<ResetIcon>d__26>(ref <ResetIcon>d__);
			return <ResetIcon>d__.<>t__builder.Task;
		}

		// Token: 0x06043B3C RID: 277308 RVA: 0x01176890 File Offset: 0x01174A90
		public UniTask OnPressed(bool isDown)
		{
			LinkingDotItem.<OnPressed>d__27 <OnPressed>d__;
			<OnPressed>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnPressed>d__.<>4__this = this;
			<OnPressed>d__.isDown = isDown;
			<OnPressed>d__.<>1__state = -1;
			<OnPressed>d__.<>t__builder.Start<LinkingDotItem.<OnPressed>d__27>(ref <OnPressed>d__);
			return <OnPressed>d__.<>t__builder.Task;
		}

		// Token: 0x06043B3D RID: 277309 RVA: 0x011768DC File Offset: 0x01174ADC
		public UniTask OnLinked()
		{
			LinkingDotItem.<OnLinked>d__28 <OnLinked>d__;
			<OnLinked>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnLinked>d__.<>4__this = this;
			<OnLinked>d__.<>1__state = -1;
			<OnLinked>d__.<>t__builder.Start<LinkingDotItem.<OnLinked>d__28>(ref <OnLinked>d__);
			return <OnLinked>d__.<>t__builder.Task;
		}

		// Token: 0x06043B3E RID: 277310 RVA: 0x01176920 File Offset: 0x01174B20
		public void SetLight(bool isLight)
		{
			this.SprDot.SetUIActive(!isLight);
			this.SprDotLight.SetUIActive(isLight);
			this.SprCorner.SetUIActive(!isLight);
			this.SprCornerLight.SetUIActive(isLight);
			if (!isLight)
			{
				this.SetFxBoost(false);
			}
		}

		// Token: 0x06043B3F RID: 277311 RVA: 0x0117696D File Offset: 0x01174B6D
		public void SetFxBoost(bool isLight)
		{
			if (ModelBase<SignalDeviceModel>.Instance.ViewType == EViewType.ChasingMoon)
			{
				return;
			}
			this.FxBoost.SetUIActive(isLight);
		}

		// Token: 0x06043B40 RID: 277312 RVA: 0x0117698C File Offset: 0x01174B8C
		public void RotateLine(bool isActive, ENeighborType neighborType = ENeighborType.None)
		{
			this.SprRay.SetUIActive(isActive);
			this.SprUpper.SetUIActive(isActive);
			int num;
			ModelBase<SignalDeviceModel>.Instance.RotateMap.TryGetValue(neighborType, out num);
			Rotator cacheRotator = ModelBase<SignalDeviceModel>.Instance.CacheRotator;
			cacheRotator.Yaw = (float)(num + 90);
			UUIItem pnlRota = this.PnlRota;
			FRotator frotator = cacheRotator.ToUeRotator();
			pnlRota.SetUIRelativeRotation(frotator);
		}

		// Token: 0x06043B41 RID: 277313 RVA: 0x011769EE File Offset: 0x01174BEE
		private void OnSignalDeviceLinking(bool isAdd, int from, bool isFromDot, int to, bool isToDot)
		{
		}

		// Token: 0x04025D40 RID: 154944
		private UUISprite SprDot;

		// Token: 0x04025D41 RID: 154945
		private UUISprite SprDotLight;

		// Token: 0x04025D42 RID: 154946
		private UUISprite SprCorner;

		// Token: 0x04025D43 RID: 154947
		private UUISprite SprCornerLight;

		// Token: 0x04025D44 RID: 154948
		private UUISprite SprRay;

		// Token: 0x04025D45 RID: 154949
		private UUISprite SprUpper;

		// Token: 0x04025D46 RID: 154950
		private UUIItem PnlRota;

		// Token: 0x04025D47 RID: 154951
		private UUIItem FxBoost;

		// Token: 0x04025D48 RID: 154952
		private UUISprite SprAnimLine;

		// Token: 0x04025D49 RID: 154953
		private UUISprite SprAnimLineWhite;

		// Token: 0x04025D4A RID: 154954
		private UUISprite SprAnimDot;

		// Token: 0x04025D4B RID: 154955
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x04025D4C RID: 154956
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		private static readonly Dictionary<EPieceColorType, string> ColorDotIconMap = new Dictionary<EPieceColorType, string>
		{
			{
				EPieceColorType.Blue,
				"SP_DotBlue"
			},
			{
				EPieceColorType.Green,
				"SP_DotGreen"
			},
			{
				EPieceColorType.Red,
				"SP_DotRed"
			},
			{
				EPieceColorType.Yellow,
				"SP_DotYellow"
			}
		};

		// Token: 0x04025D4D RID: 154957
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		private static readonly Dictionary<EPieceColorType, string> ColorCornerIconMap = new Dictionary<EPieceColorType, string>
		{
			{
				EPieceColorType.Blue,
				"SP_CornerBlue"
			},
			{
				EPieceColorType.Green,
				"SP_CornerGreen"
			},
			{
				EPieceColorType.Red,
				"SP_CornerRed"
			},
			{
				EPieceColorType.Yellow,
				"SP_CornerYellow"
			}
		};

		// Token: 0x04025D4E RID: 154958
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		protected static readonly Dictionary<EPieceColorType, string> ColorRayIconMap = new Dictionary<EPieceColorType, string>
		{
			{
				EPieceColorType.Blue,
				"SP_LineBlue"
			},
			{
				EPieceColorType.Green,
				"SP_LineGreen"
			},
			{
				EPieceColorType.Red,
				"SP_LineRed"
			},
			{
				EPieceColorType.Yellow,
				"SP_LineYellow"
			}
		};

		// Token: 0x04025D4F RID: 154959
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		private static readonly Dictionary<EPieceColorType, string> ColorAnimLineMap = new Dictionary<EPieceColorType, string>
		{
			{
				EPieceColorType.Blue,
				"SP_AnimLineBlue"
			},
			{
				EPieceColorType.Green,
				"SP_AnimLineGreen"
			},
			{
				EPieceColorType.Red,
				"SP_AnimLineRed"
			},
			{
				EPieceColorType.Yellow,
				"SP_AnimLineYellow"
			}
		};

		// Token: 0x04025D50 RID: 154960
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		private static readonly Dictionary<EPieceColorType, string> ColorAnimDotMap = new Dictionary<EPieceColorType, string>
		{
			{
				EPieceColorType.Blue,
				"SP_AnimDotBlue"
			},
			{
				EPieceColorType.Green,
				"SP_AnimDotGreen"
			},
			{
				EPieceColorType.Red,
				"SP_AnimDotRed"
			},
			{
				EPieceColorType.Yellow,
				"SP_AnimDotYellow"
			}
		};

		// Token: 0x04025D51 RID: 154961
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		protected static readonly Dictionary<EPieceColorType, string> ColorMap = new Dictionary<EPieceColorType, string>
		{
			{
				EPieceColorType.Blue,
				"3B82B9FF"
			},
			{
				EPieceColorType.Green,
				"64945FFF"
			},
			{
				EPieceColorType.Red,
				"B93B3CFF"
			},
			{
				EPieceColorType.Yellow,
				"B9823BFF"
			}
		};

		// Token: 0x04025D52 RID: 154962
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		protected static readonly Dictionary<EPieceColorType, string> CmColorMap = new Dictionary<EPieceColorType, string>
		{
			{
				EPieceColorType.Blue,
				"5CA1FF88"
			},
			{
				EPieceColorType.Green,
				"96FF5C88"
			},
			{
				EPieceColorType.Red,
				"FFA15C88"
			},
			{
				EPieceColorType.Yellow,
				"FFB85C88"
			}
		};

		// Token: 0x04025D53 RID: 154963
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		protected static readonly Dictionary<EPieceColorType, string> CmAnimColorMap = new Dictionary<EPieceColorType, string>
		{
			{
				EPieceColorType.Blue,
				"00FBE7FF"
			},
			{
				EPieceColorType.Green,
				"DFFF55FF"
			},
			{
				EPieceColorType.Red,
				"FFA73FFF"
			},
			{
				EPieceColorType.Yellow,
				"FAE56CFF"
			}
		};

		// Token: 0x04025D54 RID: 154964
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		protected static readonly Dictionary<EPieceColorType, string> FxColorMap = new Dictionary<EPieceColorType, string>
		{
			{
				EPieceColorType.Blue,
				"41AEFBFF"
			},
			{
				EPieceColorType.Green,
				"4F8040FF"
			},
			{
				EPieceColorType.Red,
				"F0477EFF"
			},
			{
				EPieceColorType.Yellow,
				"F8E56CFF"
			}
		};

		// Token: 0x0200CA00 RID: 51712
		[NullableContext(0)]
		public enum EComponents
		{
			// Token: 0x0403E104 RID: 254212
			SprDot,
			// Token: 0x0403E105 RID: 254213
			SprDotLight,
			// Token: 0x0403E106 RID: 254214
			SprCorner,
			// Token: 0x0403E107 RID: 254215
			SprCornerLight,
			// Token: 0x0403E108 RID: 254216
			PnlRota,
			// Token: 0x0403E109 RID: 254217
			SprUpper,
			// Token: 0x0403E10A RID: 254218
			SprRay,
			// Token: 0x0403E10B RID: 254219
			FxBoost,
			// Token: 0x0403E10C RID: 254220
			SprAnimLine,
			// Token: 0x0403E10D RID: 254221
			SprAnimLine1,
			// Token: 0x0403E10E RID: 254222
			SprAnimDot,
			// Token: 0x0403E10F RID: 254223
			AniCube,
			// Token: 0x0403E110 RID: 254224
			UINiagaraActor4,
			// Token: 0x0403E111 RID: 254225
			UiItem_LinkingCMDot
		}
	}
}
