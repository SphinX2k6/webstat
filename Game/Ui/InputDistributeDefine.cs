using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049F0 RID: 18928
	[NullableContext(1)]
	[Nullable(0)]
	public class InputDistributeDefine
	{
		// Token: 0x06031823 RID: 202787 RVA: 0x00C566D8 File Offset: 0x00C548D8
		// Note: this type is marked as 'beforefieldinit'.
		static InputDistributeDefine()
		{
			Dictionary<int, string> dictionary = new Dictionary<int, string>();
			dictionary[0] = null;
			dictionary[1] = null;
			dictionary[2] = null;
			dictionary[3] = null;
			dictionary[4] = null;
			dictionary[5] = null;
			dictionary[6] = null;
			dictionary[7] = null;
			dictionary[8] = null;
			dictionary[9] = null;
			InputDistributeDefine.touchTagMap = dictionary;
			Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
			dictionary2["Android_Back"] = null;
			dictionary2["C"] = null;
			InputDistributeDefine.keyTagMap = dictionary2;
			InputDistributeDefine.inputDistributeEvents = new EEventName[]
			{
				EEventName.OnAddNotAllowFightInputViewName,
				EEventName.OnRemoveNotAllowFightInputViewName,
				EEventName.OnClearNotAllowFightInputViewName,
				EEventName.ShowHUD,
				EEventName.HideHUD,
				EEventName.ReConnectBegin,
				EEventName.ReConnectSuccess,
				EEventName.LogOut,
				EEventName.OnShowMouseCursor,
				EEventName.OnStartLoadingState,
				EEventName.OnFinishLoadingState,
				EEventName.WorldDone,
				EEventName.ResetModuleByResetToBattleView,
				EEventName.SdkKick,
				EEventName.CharOnRoleDrown,
				EEventName.OnPlotWaitViewDone,
				EEventName.ShowTypeChange,
				EEventName.OnCameraSequenceSetUiVisible,
				EEventName.OnEnterTransitionMap,
				EEventName.OnSequenceCameraStatus,
				EEventName.OnOnlyAllowFightInputStateChanged
			};
		}

		// Token: 0x0401CCAF RID: 117935
		[TupleElementNames(new string[]
		{
			"Tag",
			"ParentTag"
		})]
		[Nullable(new byte[]
		{
			1,
			0,
			1,
			2
		})]
		[StaticVariableRuleIgnore]
		public static readonly List<ValueTuple<string, string>> InitializeInputDistributeTagDefine = new List<ValueTuple<string, string>>
		{
			new ValueTuple<string, string>("FightInputRoot", null),
			new ValueTuple<string, string>("FightInputRoot.FightInput.ActionInput", "FightInputRoot"),
			new ValueTuple<string, string>("FightInputRoot.FightInput.ActionInput.CharacterSkillInput", "FightInputRoot.FightInput.ActionInput"),
			new ValueTuple<string, string>("FightInputRoot.FightInput.ActionInput.VehicleMusicInputTag", "FightInputRoot.FightInput.ActionInput"),
			new ValueTuple<string, string>("FightInputRoot.FightInput.AxisInput", "FightInputRoot"),
			new ValueTuple<string, string>("FightInputRoot.FightInput.AxisInput.CameraInput", "FightInputRoot.FightInput.AxisInput"),
			new ValueTuple<string, string>("FightInputRoot.FightInput.AxisInput.CameraInput.CameraRotation", "FightInputRoot.FightInput.AxisInput.CameraInput"),
			new ValueTuple<string, string>("FightInputRoot.FightInput.AxisInput.CameraInput.CameraZoom", "FightInputRoot.FightInput.AxisInput.CameraInput"),
			new ValueTuple<string, string>("FightInputRoot.FightInput.AxisInput.MoveInput", "FightInputRoot.FightInput.AxisInput"),
			new ValueTuple<string, string>("InteractionRoot", null),
			new ValueTuple<string, string>("UiInputRoot", null),
			new ValueTuple<string, string>("UiInputRoot.ShortcutKeyTag", "UiInputRoot"),
			new ValueTuple<string, string>("UiInputRoot.MouseInputTag", "UiInputRoot"),
			new ValueTuple<string, string>("UiInputRoot.Navigation", "UiInputRoot"),
			new ValueTuple<string, string>("BlockAllInputTag", null)
		};

		// Token: 0x0401CCB0 RID: 117936
		[Nullable(new byte[]
		{
			1,
			2
		})]
		[StaticVariableRuleIgnore]
		public static readonly Dictionary<int, string> touchTagMap;

		// Token: 0x0401CCB1 RID: 117937
		[Nullable(new byte[]
		{
			1,
			1,
			2
		})]
		[StaticVariableRuleIgnore]
		public static readonly Dictionary<string, string> keyTagMap;

		// Token: 0x0401CCB2 RID: 117938
		[StaticVariableRuleIgnore]
		public static readonly EEventName[] inputDistributeEvents;

		// Token: 0x0401CCB3 RID: 117939
		[StaticVariableRuleIgnore]
		public const float AXIS_TOLERANCE = 0.02f;

		// Token: 0x0200AA88 RID: 43656
		[Nullable(0)]
		public static class InputDistributeTagDefine
		{
			// Token: 0x04034C31 RID: 216113
			public const string FightInputRootTag = "FightInputRoot";

			// Token: 0x04034C32 RID: 216114
			public const string InteractionRootTag = "InteractionRoot";

			// Token: 0x04034C33 RID: 216115
			public const string UiInputRootTag = "UiInputRoot";

			// Token: 0x04034C34 RID: 216116
			public const string BlockAllInputTag = "BlockAllInputTag";

			// Token: 0x0200CEC1 RID: 52929
			[Nullable(0)]
			public static class FightInputRoot
			{
				// Token: 0x0403FB77 RID: 260983
				public const string ActionInputTag = "FightInputRoot.FightInput.ActionInput";

				// Token: 0x0403FB78 RID: 260984
				public const string AxisInputTag = "FightInputRoot.FightInput.AxisInput";

				// Token: 0x0200CF80 RID: 53120
				[Nullable(0)]
				public static class ActionInput
				{
					// Token: 0x0403FE8D RID: 261773
					public const string CharacterSkillInputTag = "FightInputRoot.FightInput.ActionInput.CharacterSkillInput";

					// Token: 0x0403FE8E RID: 261774
					public const string VehicleMusicInputTag = "FightInputRoot.FightInput.ActionInput.VehicleMusicInputTag";
				}

				// Token: 0x0200CF81 RID: 53121
				[Nullable(0)]
				public static class AxisInput
				{
					// Token: 0x0403FE8F RID: 261775
					public const string CameraInputTag = "FightInputRoot.FightInput.AxisInput.CameraInput";

					// Token: 0x0403FE90 RID: 261776
					public const string MoveInputTag = "FightInputRoot.FightInput.AxisInput.MoveInput";

					// Token: 0x0200CF82 RID: 53122
					[Nullable(0)]
					public static class CameraInput
					{
						// Token: 0x0403FE91 RID: 261777
						public const string CameraRotationTag = "FightInputRoot.FightInput.AxisInput.CameraInput.CameraRotation";

						// Token: 0x0403FE92 RID: 261778
						public const string CameraZoomTag = "FightInputRoot.FightInput.AxisInput.CameraInput.CameraZoom";
					}
				}
			}

			// Token: 0x0200CEC2 RID: 52930
			[Nullable(0)]
			public static class UiInputRoot
			{
				// Token: 0x0403FB79 RID: 260985
				public const string ShortcutKeyTag = "UiInputRoot.ShortcutKeyTag";

				// Token: 0x0403FB7A RID: 260986
				public const string NavigationTag = "UiInputRoot.Navigation";

				// Token: 0x0403FB7B RID: 260987
				public const string MouseInputTag = "UiInputRoot.MouseInputTag";
			}
		}

		// Token: 0x0200AA89 RID: 43657
		[NullableContext(0)]
		public enum EActionType
		{
			// Token: 0x04034C36 RID: 216118
			Press,
			// Token: 0x04034C37 RID: 216119
			Release
		}

		// Token: 0x0200AA8A RID: 43658
		[NullableContext(0)]
		public enum ETouchType
		{
			// Token: 0x04034C39 RID: 216121
			TouchBegin,
			// Token: 0x04034C3A RID: 216122
			TouchEnd,
			// Token: 0x04034C3B RID: 216123
			TouchMove
		}

		// Token: 0x0200AA8B RID: 43659
		public interface ITouchData
		{
			// Token: 0x1700A942 RID: 43330
			// (get) Token: 0x0604B3D2 RID: 308178
			// (set) Token: 0x0604B3D3 RID: 308179
			InputDistributeDefine.ETouchType TouchType { get; set; }

			// Token: 0x1700A943 RID: 43331
			// (get) Token: 0x0604B3D4 RID: 308180
			// (set) Token: 0x0604B3D5 RID: 308181
			int TouchId { get; set; }

			// Token: 0x1700A944 RID: 43332
			// (get) Token: 0x0604B3D6 RID: 308182
			// (set) Token: 0x0604B3D7 RID: 308183
			Vector TouchPosition { get; set; }
		}

		// Token: 0x0200AA8C RID: 43660
		[Nullable(0)]
		public class TouchData : InputDistributeDefine.ITouchData
		{
			// Token: 0x1700A945 RID: 43333
			// (get) Token: 0x0604B3D8 RID: 308184 RVA: 0x0148314A File Offset: 0x0148134A
			// (set) Token: 0x0604B3D9 RID: 308185 RVA: 0x01483152 File Offset: 0x01481352
			public InputDistributeDefine.ETouchType TouchType { get; set; }

			// Token: 0x1700A946 RID: 43334
			// (get) Token: 0x0604B3DA RID: 308186 RVA: 0x0148315B File Offset: 0x0148135B
			// (set) Token: 0x0604B3DB RID: 308187 RVA: 0x01483163 File Offset: 0x01481363
			public int TouchId { get; set; }

			// Token: 0x1700A947 RID: 43335
			// (get) Token: 0x0604B3DC RID: 308188 RVA: 0x0148316C File Offset: 0x0148136C
			// (set) Token: 0x0604B3DD RID: 308189 RVA: 0x01483174 File Offset: 0x01481374
			public Vector TouchPosition { get; set; }
		}
	}
}
