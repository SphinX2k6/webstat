using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;

namespace CSharpScript.Game.Module.AutoPilot
{
	// Token: 0x02006142 RID: 24898
	[NullableContext(1)]
	[Nullable(0)]
	public class AutoPilotDefine
	{
		// Token: 0x04023496 RID: 144534
		public static readonly string STARTPOPINT_ICONPATH = "/Game/Aki/UI/UIResources/UiWorldMap/Atlas/Motorcycle/SP_IconWorldEnterPoint.SP_IconWorldEnterPoint";

		// Token: 0x04023497 RID: 144535
		public static readonly string ENDPOINT_ICONPATH = "/Game/Aki/UI/UIResources/UiWorldMap/Atlas/Motorcycle/SP_IconWorldEndPoint.SP_IconWorldEndPoint";

		// Token: 0x04023498 RID: 144536
		public static readonly int HIGHLIGHTLINEDISTANCEINTERVAL = 1250;

		// Token: 0x04023499 RID: 144537
		[StaticVariableRuleIgnore]
		public static readonly Dictionary<AutoPilotDefine.EDisableAutoPilotReason, string> failReasonTxt = new Dictionary<AutoPilotDefine.EDisableAutoPilotReason, string>
		{
			{
				AutoPilotDefine.EDisableAutoPilotReason.NoCirclePath,
				AutoPilotDefine.EAutoPilotTextId.TextNoCirclePath
			},
			{
				AutoPilotDefine.EDisableAutoPilotReason.NotInAutoPilotArea,
				AutoPilotDefine.EAutoPilotTextId.TextNotInAutoPilotArea
			},
			{
				AutoPilotDefine.EDisableAutoPilotReason.NotNearRoad,
				AutoPilotDefine.EAutoPilotTextId.TextNotNearRoad
			},
			{
				AutoPilotDefine.EDisableAutoPilotReason.NotValidRole,
				AutoPilotDefine.EAutoPilotTextId.TextNotValidRole
			},
			{
				AutoPilotDefine.EDisableAutoPilotReason.InAutoPilot,
				AutoPilotDefine.EAutoPilotTextId.TextInAutoPilot
			},
			{
				AutoPilotDefine.EDisableAutoPilotReason.NoDest,
				AutoPilotDefine.EAutoPilotTextId.TextNoDest
			},
			{
				AutoPilotDefine.EDisableAutoPilotReason.NoHighLightLine,
				AutoPilotDefine.EAutoPilotTextId.TextNoHighLightLine
			}
		};

		// Token: 0x0402349A RID: 144538
		public static readonly int SUMMONMOTOR_SKILLID = 800001;

		// Token: 0x0402349B RID: 144539
		public static readonly string HIGHLIGHT_TAG_NAME = "角色.Common.技能通用标识.探索技能高亮黄色";

		// Token: 0x0402349C RID: 144540
		public static readonly int FINDPATH_TICK_INTERVAL = 30;

		// Token: 0x0402349D RID: 144541
		public static readonly float MOVIEMODE_UIVISIBLE_ANIM_TIME = 0.5f;

		// Token: 0x0402349E RID: 144542
		public static readonly int autoPilotTag = GameplayTagDefine.EGameplayTagId["载具.摩托.自动巡航"];

		// Token: 0x0200C2C6 RID: 49862
		[NullableContext(0)]
		[EnumExtensions]
		public enum EAutoPilotResourceId
		{
			// Token: 0x0403C0DA RID: 245978
			[EnumStringMember("UiItem_AutocruiseNavBtn")]
			AutoPilotNavBtn,
			// Token: 0x0403C0DB RID: 245979
			[EnumStringMember("PnlSetOutBtn")]
			AutoPilotGoBtnGroup,
			// Token: 0x0403C0DC RID: 245980
			[EnumStringMember("UiItem_AutoPilot_Line")]
			AutoPilotLineComp,
			// Token: 0x0403C0DD RID: 245981
			[EnumStringMember("UiItem_AutocruiseMark")]
			AutoPilotTrackMark,
			// Token: 0x0403C0DE RID: 245982
			[EnumStringMember("UiView_MotorcycleAutoCruise")]
			AutoPilotView,
			// Token: 0x0403C0DF RID: 245983
			[EnumStringMember("UiItem_MotorAutoCruise")]
			AutoPilotState
		}

		// Token: 0x0200C2C7 RID: 49863
		[Nullable(0)]
		public class EAutoPilotTextId
		{
			// Token: 0x0403C0E0 RID: 245984
			public static readonly string TextAutoPilotTrack = "AutoPilot_NavigationConfirm";

			// Token: 0x0403C0E1 RID: 245985
			public static readonly string TextAutoPilotTrackOff = "AutoPilot_NavigationCancel";

			// Token: 0x0403C0E2 RID: 245986
			public static readonly string TextAutoPilotActivated = "AutoPilot_AreaNotSupported";

			// Token: 0x0403C0E3 RID: 245987
			public static readonly string TextAutoPilotForbidden = "AutoPilot_NavigationForbidden";

			// Token: 0x0403C0E4 RID: 245988
			public static readonly string TextCanAutoPilot = "AutoPilot_RoutePointTips";

			// Token: 0x0403C0E5 RID: 245989
			public static readonly string TextNotInAutoPilotArea = "AutoPilot_NotPermitted";

			// Token: 0x0403C0E6 RID: 245990
			public static readonly string TextNoCirclePath = "AutoPilot_LoopNotSupported";

			// Token: 0x0403C0E7 RID: 245991
			public static readonly string TextNotNearRoad = "AutoPilot_NotPermitted";

			// Token: 0x0403C0E8 RID: 245992
			public static readonly string TextQuitTips = "AutoPilot_QuitTips";

			// Token: 0x0403C0E9 RID: 245993
			public static readonly string TextMarkToGuide = "AutoPilot_MarkToGuide";

			// Token: 0x0403C0EA RID: 245994
			public static readonly string TextDestState = "AutoPilot_PilotMode";

			// Token: 0x0403C0EB RID: 245995
			public static readonly string TextLoopState = "AutoPilot_LoopPilotMode";

			// Token: 0x0403C0EC RID: 245996
			public static readonly string TextNotValidRole = "AutoPilot_NotPermitted";

			// Token: 0x0403C0ED RID: 245997
			public static readonly string TextInAutoPilot = "AutoPilot_NotPermitted";

			// Token: 0x0403C0EE RID: 245998
			public static readonly string TextNoDest = "AutoPilot_NotPermitted";

			// Token: 0x0403C0EF RID: 245999
			public static readonly string TextNoHighLightLine = "AutoPilot_NotPermitted";

			// Token: 0x0403C0F0 RID: 246000
			public static readonly string TextAutoPilotAreaIsolatedTips = "AutoPilot_AreaIsolatedTips";

			// Token: 0x0403C0F1 RID: 246001
			public static readonly string TextAutoPilotUnValidTooNearTips = "AutoPilot_OverCloseTips_1";

			// Token: 0x0403C0F2 RID: 246002
			public static readonly string TextCancelAutoPilotTooNearTips = "AutoPilot_OverCloseTips_2";
		}

		// Token: 0x0200C2C8 RID: 49864
		public interface IAutoPilotTrackingData
		{
			// Token: 0x1700AA3E RID: 43582
			// (get) Token: 0x0604E6CB RID: 321227
			// (set) Token: 0x0604E6CC RID: 321228
			Vector TargetPos { get; set; }

			// Token: 0x1700AA3F RID: 43583
			// (get) Token: 0x0604E6CD RID: 321229
			// (set) Token: 0x0604E6CE RID: 321230
			int MapId { get; set; }
		}

		// Token: 0x0200C2C9 RID: 49865
		[Nullable(0)]
		[RequiredMember]
		public class AutoPilotTrackingData : AutoPilotDefine.IAutoPilotTrackingData
		{
			// Token: 0x1700AA40 RID: 43584
			// (get) Token: 0x0604E6CF RID: 321231 RVA: 0x015C1013 File Offset: 0x015BF213
			// (set) Token: 0x0604E6D0 RID: 321232 RVA: 0x015C101B File Offset: 0x015BF21B
			[RequiredMember]
			public Vector TargetPos { get; set; }

			// Token: 0x1700AA41 RID: 43585
			// (get) Token: 0x0604E6D1 RID: 321233 RVA: 0x015C1024 File Offset: 0x015BF224
			// (set) Token: 0x0604E6D2 RID: 321234 RVA: 0x015C102C File Offset: 0x015BF22C
			[RequiredMember]
			public int MapId { get; set; }

			// Token: 0x0604E6D3 RID: 321235 RVA: 0x015C1035 File Offset: 0x015BF235
			[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
			[CompilerFeatureRequired("RequiredMembers")]
			public AutoPilotTrackingData()
			{
			}
		}

		// Token: 0x0200C2CA RID: 49866
		[NullableContext(0)]
		public enum EDisableAutoPilotReason
		{
			// Token: 0x0403C0F6 RID: 246006
			NoCirclePath,
			// Token: 0x0403C0F7 RID: 246007
			NotInAutoPilotArea,
			// Token: 0x0403C0F8 RID: 246008
			NotNearRoad,
			// Token: 0x0403C0F9 RID: 246009
			NotValidRole,
			// Token: 0x0403C0FA RID: 246010
			InAutoPilot,
			// Token: 0x0403C0FB RID: 246011
			NoDest,
			// Token: 0x0403C0FC RID: 246012
			NoHighLightLine
		}

		// Token: 0x0200C2CB RID: 49867
		public interface IEnableAutoPilot
		{
			// Token: 0x1700AA42 RID: 43586
			// (get) Token: 0x0604E6D4 RID: 321236
			// (set) Token: 0x0604E6D5 RID: 321237
			AutoPilotDefine.EEnableAutoPilot Value { get; set; }

			// Token: 0x1700AA43 RID: 43587
			// (get) Token: 0x0604E6D6 RID: 321238
			// (set) Token: 0x0604E6D7 RID: 321239
			AutoPilotDefine.EDisableAutoPilotReason? DisableReason { get; set; }
		}

		// Token: 0x0200C2CC RID: 49868
		[NullableContext(0)]
		[RequiredMember]
		public class EnableAutoPilot : AutoPilotDefine.IEnableAutoPilot
		{
			// Token: 0x1700AA44 RID: 43588
			// (get) Token: 0x0604E6D8 RID: 321240 RVA: 0x015C103D File Offset: 0x015BF23D
			// (set) Token: 0x0604E6D9 RID: 321241 RVA: 0x015C1045 File Offset: 0x015BF245
			[RequiredMember]
			public AutoPilotDefine.EEnableAutoPilot Value { get; set; }

			// Token: 0x1700AA45 RID: 43589
			// (get) Token: 0x0604E6DA RID: 321242 RVA: 0x015C104E File Offset: 0x015BF24E
			// (set) Token: 0x0604E6DB RID: 321243 RVA: 0x015C1056 File Offset: 0x015BF256
			public AutoPilotDefine.EDisableAutoPilotReason? DisableReason { get; set; }

			// Token: 0x0604E6DC RID: 321244 RVA: 0x015C105F File Offset: 0x015BF25F
			[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
			[CompilerFeatureRequired("RequiredMembers")]
			public EnableAutoPilot()
			{
			}
		}

		// Token: 0x0200C2CD RID: 49869
		public interface IAutoPilotCircles
		{
			// Token: 0x1700AA46 RID: 43590
			// (get) Token: 0x0604E6DD RID: 321245
			// (set) Token: 0x0604E6DE RID: 321246
			List<int> RoadBuildIdArray { get; set; }

			// Token: 0x1700AA47 RID: 43591
			// (get) Token: 0x0604E6DF RID: 321247
			// (set) Token: 0x0604E6E0 RID: 321248
			List<int> CircleIds { get; set; }
		}

		// Token: 0x0200C2CE RID: 49870
		[Nullable(0)]
		[RequiredMember]
		public class AutoPilotCircles : AutoPilotDefine.IAutoPilotCircles
		{
			// Token: 0x1700AA48 RID: 43592
			// (get) Token: 0x0604E6E1 RID: 321249 RVA: 0x015C1067 File Offset: 0x015BF267
			// (set) Token: 0x0604E6E2 RID: 321250 RVA: 0x015C106F File Offset: 0x015BF26F
			[RequiredMember]
			public List<int> RoadBuildIdArray { get; set; }

			// Token: 0x1700AA49 RID: 43593
			// (get) Token: 0x0604E6E3 RID: 321251 RVA: 0x015C1078 File Offset: 0x015BF278
			// (set) Token: 0x0604E6E4 RID: 321252 RVA: 0x015C1080 File Offset: 0x015BF280
			[RequiredMember]
			public List<int> CircleIds { get; set; }

			// Token: 0x0604E6E5 RID: 321253 RVA: 0x015C1089 File Offset: 0x015BF289
			[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
			[CompilerFeatureRequired("RequiredMembers")]
			public AutoPilotCircles()
			{
			}
		}

		// Token: 0x0200C2CF RID: 49871
		[NullableContext(0)]
		public enum EAutoPilotState
		{
			// Token: 0x0403C102 RID: 246018
			None,
			// Token: 0x0403C103 RID: 246019
			Dest,
			// Token: 0x0403C104 RID: 246020
			Loop
		}

		// Token: 0x0200C2D0 RID: 49872
		[NullableContext(0)]
		public enum EEnableAutoPilot
		{
			// Token: 0x0403C106 RID: 246022
			Disable,
			// Token: 0x0403C107 RID: 246023
			Dest,
			// Token: 0x0403C108 RID: 246024
			Loop
		}
	}
}
