using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.SignalDeviceControl.SiganalDeviceUIItem
{
	// Token: 0x02006B02 RID: 27394
	[NullableContext(2)]
	[Nullable(0)]
	public class LinkingLineItem : UiPanelBase
	{
		// Token: 0x06043B56 RID: 277334 RVA: 0x0117719E File Offset: 0x0117539E
		protected LinkingLineItem(ELineType lineType)
		{
			this.LineType = lineType;
		}

		// Token: 0x06043B57 RID: 277335 RVA: 0x011771B4 File Offset: 0x011753B4
		[NullableContext(1)]
		public static LinkingLineItem Create(ELineType lineType)
		{
			return new LinkingLineItem(lineType);
		}

		// Token: 0x06043B58 RID: 277336 RVA: 0x011771BC File Offset: 0x011753BC
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUISprite)),
				new ValueTuple<int, Type>(1, typeof(UUISprite)),
				new ValueTuple<int, Type>(2, typeof(UUISprite)),
				new ValueTuple<int, Type>(3, typeof(UUISprite)),
				new ValueTuple<int, Type>(4, typeof(UUISprite)),
				new ValueTuple<int, Type>(5, typeof(UUISprite))
			};
		}

		// Token: 0x06043B59 RID: 277337 RVA: 0x01177258 File Offset: 0x01175458
		protected override void OnStart()
		{
			this.SprBg = base.GetSprite(0);
			this.SprLine = base.GetSprite(1);
			this.SprLineHalf = base.GetSprite(2);
			this.SprSpot = base.GetSprite(3);
			this.SprRay = base.GetSprite(4);
			this.SprRayHalf = base.GetSprite(5);
			this.SprBg.SetUIActive(false);
			this.SprLine.SetUIActive(false);
			this.SprLineHalf.SetUIActive(false);
			this.SprSpot.SetUIActive(false);
			this.SprRay.SetUIActive(false);
			this.SprRayHalf.SetUIActive(false);
		}

		// Token: 0x06043B5A RID: 277338 RVA: 0x011772FC File Offset: 0x011754FC
		public void InitIcon(ENeighborType neighborType, bool isHalf = false)
		{
			bool flag = ModelBase<SignalDeviceModel>.Instance.ViewType == EViewType.ChasingMoon;
			EPieceColorType currentColor = ModelBase<SignalDeviceModel>.Instance.CurrentColor;
			string text;
			LinkingLineItem.ColorSpotIconMap.TryGetValue(currentColor, out text);
			if (flag)
			{
				text += "CM";
			}
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(text);
			this.SetSpriteByPath(resourcePath, this.SprSpot, false, null, null);
			string text2;
			LinkingLineItem.ColorRayIconMap.TryGetValue(currentColor, out text2);
			if (flag)
			{
				text2 += "CM";
			}
			string resourcePath2 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(text2);
			this.SetSpriteByPath(resourcePath2, this.SprRay, false, null, null);
			this.SetSpriteByPath(resourcePath2, this.SprRayHalf, false, null, null);
			string hexStr;
			LinkingLineItem.ColorMap.TryGetValue(currentColor, out hexStr);
			if (ModelBase<SignalDeviceModel>.Instance.ViewType == EViewType.ChasingMoon)
			{
				string resourceId;
				LinkingLineItem.ColorSprBgMap.TryGetValue(currentColor, out resourceId);
				string resourcePath3 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
				this.SetSpriteByPath(resourcePath3, this.SprBg, false, null, null);
			}
			else
			{
				this.SprBg.SetColor(FColor.FromHex(hexStr));
			}
			this.SprLine.SetColor(FColor.FromHex(hexStr));
			this.SprLineHalf.SetColor(FColor.FromHex(hexStr));
			this.RotateLine(neighborType);
			bool flag2 = this.LineType == ELineType.LinkingLineStraight || this.LineType == ELineType.LinkingLineWithDotStraight;
			this.SprBg.SetUIActive(true);
			this.SprLine.SetUIActive(!isHalf);
			this.SprLineHalf.SetUIActive(isHalf);
			this.SprRay.SetUIActive(!isHalf);
			this.SprRayHalf.SetUIActive(isHalf || !flag2);
			this.SprSpot.SetUIActive(true);
		}

		// Token: 0x06043B5B RID: 277339 RVA: 0x011774C0 File Offset: 0x011756C0
		protected void RotateLine(ENeighborType neighborType)
		{
			int num;
			ModelBase<SignalDeviceModel>.Instance.RotateMap.TryGetValue(neighborType, out num);
			Rotator cacheRotator = ModelBase<SignalDeviceModel>.Instance.CacheRotator;
			cacheRotator.Yaw = (float)num;
			UUIItem rootItem = base.GetRootItem();
			FRotator frotator = cacheRotator.ToUeRotator();
			rootItem.SetUIRelativeRotation(frotator);
		}

		// Token: 0x06043B5C RID: 277340 RVA: 0x01177508 File Offset: 0x01175708
		public void SetLineHalf(ENeighborType neighborType)
		{
			this.SprLine.SetUIActive(false);
			this.SprLineHalf.SetUIActive(true);
			this.SprRay.SetUIActive(false);
			this.SprRayHalf.SetUIActive(true);
			Rotator cacheRotator = ModelBase<SignalDeviceModel>.Instance.CacheRotator;
			int num;
			ModelBase<SignalDeviceModel>.Instance.RotateMap.TryGetValue(neighborType, out num);
			cacheRotator.Yaw = (float)num;
			UUIItem rootItem = base.GetRootItem();
			FRotator frotator = cacheRotator.ToUeRotator();
			rootItem.SetUIRelativeRotation(frotator);
		}

		// Token: 0x04025D69 RID: 154985
		public ELineType LineType = ELineType.LinkingLineStraight;

		// Token: 0x04025D6A RID: 154986
		protected UUISprite SprBg;

		// Token: 0x04025D6B RID: 154987
		protected UUISprite SprLine;

		// Token: 0x04025D6C RID: 154988
		protected UUISprite SprLineHalf;

		// Token: 0x04025D6D RID: 154989
		protected UUISprite SprSpot;

		// Token: 0x04025D6E RID: 154990
		protected UUISprite SprRay;

		// Token: 0x04025D6F RID: 154991
		protected UUISprite SprRayHalf;

		// Token: 0x04025D70 RID: 154992
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		protected static readonly Dictionary<EPieceColorType, string> ColorSpotIconMap = new Dictionary<EPieceColorType, string>
		{
			{
				EPieceColorType.Blue,
				"SP_SpotBlue"
			},
			{
				EPieceColorType.Green,
				"SP_SpotGreen"
			},
			{
				EPieceColorType.Red,
				"SP_SpotRed"
			},
			{
				EPieceColorType.Yellow,
				"SP_SpotYellow"
			}
		};

		// Token: 0x04025D71 RID: 154993
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

		// Token: 0x04025D72 RID: 154994
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		protected static readonly Dictionary<EPieceColorType, string> ColorSprBgMap = new Dictionary<EPieceColorType, string>
		{
			{
				EPieceColorType.Blue,
				"SP_GridBgCMBlue"
			},
			{
				EPieceColorType.Green,
				"SP_GridBgCMGreen"
			},
			{
				EPieceColorType.Red,
				"SP_GridBgCMRed"
			},
			{
				EPieceColorType.Yellow,
				"SP_GridBgCMYellow"
			}
		};

		// Token: 0x04025D73 RID: 154995
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
	}
}
