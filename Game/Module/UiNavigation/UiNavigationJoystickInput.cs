using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004C88 RID: 19592
	[NullableContext(1)]
	[Nullable(0)]
	public class UiNavigationJoystickInput : IStaticVariableResetter
	{
		// Token: 0x0603312A RID: 209194 RVA: 0x00CCA97C File Offset: 0x00CC8B7C
		static UiNavigationJoystickInput()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(UiNavigationJoystickInput.CreateStaticDefaultValue), new Action(UiNavigationJoystickInput.ResetStaticDefaultValue));
		}

		// Token: 0x1700879D RID: 34717
		// (get) Token: 0x0603312B RID: 209195 RVA: 0x00CCAA10 File Offset: 0x00CC8C10
		private static Dictionary<Action<ENavigationDirectionType>, bool> LeftJoystickFunctionMap
		{
			get
			{
				return UiNavigationJoystickInput._leftJoystickFunctionMap;
			}
		}

		// Token: 0x1700879E RID: 34718
		// (get) Token: 0x0603312C RID: 209196 RVA: 0x00CCAA17 File Offset: 0x00CC8C17
		private static IReadOnlyDictionary<string, ENavigationDirectionType> TypeMap
		{
			get
			{
				return UiNavigationJoystickInput._typeMap;
			}
		}

		// Token: 0x0603312D RID: 209197 RVA: 0x00CCAA1E File Offset: 0x00CC8C1E
		public static void Tick(float delta)
		{
			UiNavigationJoystickInput.TickAxis(delta);
			UiNavigationJoystickInput.TickFirstAction(delta);
			UiNavigationJoystickInput.TickAction(delta);
		}

		// Token: 0x0603312E RID: 209198 RVA: 0x00CCAA34 File Offset: 0x00CC8C34
		private static void TickAxis(float delta)
		{
			if (UiNavigationJoystickInput.IsTickRepeatAction)
			{
				return;
			}
			float axisValue = ModelBase<InputDistributeModel>.Instance.GetAxisValue("NavigationTopDown");
			float axisValue2 = ModelBase<InputDistributeModel>.Instance.GetAxisValue("NavigationLeftRight");
			bool flag = UiNavigationJoystickInput.IsSmallerThenPressThreshold(axisValue2);
			bool flag2 = UiNavigationJoystickInput.IsSmallerThenPressThreshold(axisValue);
			if (flag && flag2 && !UiNavigationJoystickInput.IsPress)
			{
				return;
			}
			if (UiNavigationJoystickInput.IsPress)
			{
				UiNavigationJoystickInput.HandleCanTriggerTag(axisValue2, axisValue);
				bool flag3 = UiNavigationJoystickInput.IsSmallerThenReleaseThreshold(axisValue2);
				bool flag4 = UiNavigationJoystickInput.IsSmallerThenReleaseThreshold(axisValue);
				if (flag3 && flag4)
				{
					UiNavigationJoystickInput.IsPress = false;
					UiNavigationJoystickInput.TriggerLeftJoystickFunction();
					UiNavigationJoystickInput.DirectionRelease();
					return;
				}
			}
			UiNavigationJoystickInput.HandleDirectionPress(axisValue2, axisValue);
			UiNavigationJoystickInput.RepeatPressHandle(UiNavigationJoystickInput.Direction, delta);
			UiNavigationJoystickInput.LastLeftJoystickX = axisValue2;
			UiNavigationJoystickInput.LastLeftJoystickY = axisValue;
			UiNavigationJoystickInput.IsPress = true;
		}

		// Token: 0x0603312F RID: 209199 RVA: 0x00CCAAD6 File Offset: 0x00CC8CD6
		private static void TickFirstAction(float delta)
		{
			if (!UiNavigationJoystickInput.IsTickFirstAction)
			{
				return;
			}
			UiNavigationLogic.ExecuteInputNavigation(UiNavigationJoystickInput.InputActionName, UiNavigationJoystickInput.InputActionType.Value);
			UiNavigationJoystickInput.IsTickFirstAction = false;
			if (UiNavigationJoystickInput.InputActionType.GetValueOrDefault() == InputDistributeDefine.EActionType.Release)
			{
				UiNavigationJoystickInput.InputActionName = "";
			}
		}

		// Token: 0x06033130 RID: 209200 RVA: 0x00CCAB11 File Offset: 0x00CC8D11
		private static void TickAction(float delta)
		{
			if (!UiNavigationJoystickInput.IsTickRepeatAction)
			{
				return;
			}
			UiNavigationJoystickInput.RepeatPressHandle(UiNavigationJoystickInput.InputActionName, delta);
		}

		// Token: 0x06033131 RID: 209201 RVA: 0x00CCAB28 File Offset: 0x00CC8D28
		private static void HandleDirectionPress(float leftJoystickX, float leftJoystickY)
		{
			bool flag = UiNavigationJoystickInput.IsSmallerThenPressThreshold(leftJoystickX);
			bool flag2 = UiNavigationJoystickInput.IsSmallerThenPressThreshold(leftJoystickY);
			if (flag && flag2)
			{
				return;
			}
			float num = flag ? 0f : leftJoystickX;
			float num2 = flag2 ? 0f : leftJoystickY;
			UiNavigationJoystickInput.TempVector.Set((double)num, (double)num2, 0.0);
			double angleByVector2D = Vector.GetAngleByVector2D(UiNavigationJoystickInput.TempVector);
			if (angleByVector2D >= -143.0 && angleByVector2D < -37.0)
			{
				UiNavigationJoystickInput.DirectionPress("UI方向下");
				return;
			}
			if (angleByVector2D >= -37.0 && angleByVector2D < 37.0)
			{
				UiNavigationJoystickInput.DirectionPress("UI方向右");
				return;
			}
			if (angleByVector2D >= 37.0 && angleByVector2D < 143.0)
			{
				UiNavigationJoystickInput.DirectionPress("UI方向上");
				return;
			}
			UiNavigationJoystickInput.DirectionPress("UI方向左");
		}

		// Token: 0x06033132 RID: 209202 RVA: 0x00CCABFD File Offset: 0x00CC8DFD
		private static bool IsSmallerThenPressThreshold(float value)
		{
			return Math.Abs(value) < 0.7f;
		}

		// Token: 0x06033133 RID: 209203 RVA: 0x00CCAC0C File Offset: 0x00CC8E0C
		private static bool IsSmallerThenReleaseThreshold(float value)
		{
			return Math.Abs(value) < 0.2f;
		}

		// Token: 0x06033134 RID: 209204 RVA: 0x00CCAC1C File Offset: 0x00CC8E1C
		private static void DirectionPress(string direction)
		{
			if (direction == UiNavigationJoystickInput.Direction)
			{
				return;
			}
			UiNavigationJoystickInput.Direction = direction;
			UiNavigationJoystickInput.IsCanTrigger = false;
			UiNavigationJoystickInput.RepeatPressTime = 0f;
			UiNavigationJoystickInput.PressInterval = 500f;
			UiNavigationJoystickInput.TargetActionType = new InputDistributeDefine.EActionType?(InputDistributeDefine.EActionType.Release);
			UiNavigationLogic.ExecuteInputNavigation(UiNavigationJoystickInput.Direction, InputDistributeDefine.EActionType.Press);
		}

		// Token: 0x06033135 RID: 209205 RVA: 0x00CCAC70 File Offset: 0x00CC8E70
		private static void DirectionRelease()
		{
			if (string.IsNullOrEmpty(UiNavigationJoystickInput.Direction))
			{
				return;
			}
			string direction = UiNavigationJoystickInput.Direction;
			UiNavigationJoystickInput.Direction = "";
			UiNavigationJoystickInput.RepeatPressTime = 0f;
			UiNavigationJoystickInput.LastLeftJoystickX = 0f;
			UiNavigationJoystickInput.LastLeftJoystickY = 0f;
			UiNavigationJoystickInput.IsCanTrigger = false;
			UiNavigationLogic.ExecuteInputNavigation(direction, InputDistributeDefine.EActionType.Release);
		}

		// Token: 0x06033136 RID: 209206 RVA: 0x00CCACC4 File Offset: 0x00CC8EC4
		private static void RepeatPressHandle(string actionName, float delta)
		{
			if (string.IsNullOrEmpty(actionName))
			{
				return;
			}
			UiNavigationJoystickInput.RepeatPressTime += delta;
			InputDistributeDefine.EActionType? targetActionType = UiNavigationJoystickInput.TargetActionType;
			InputDistributeDefine.EActionType eactionType = InputDistributeDefine.EActionType.Press;
			if (targetActionType.GetValueOrDefault() == eactionType & targetActionType != null)
			{
				if (UiNavigationJoystickInput.RepeatPressTime > 100f)
				{
					UiNavigationJoystickInput.RepeatPressTime -= 100f;
					UiNavigationJoystickInput.PressInterval = 100f;
					UiNavigationJoystickInput.TargetActionType = new InputDistributeDefine.EActionType?(InputDistributeDefine.EActionType.Release);
					UiNavigationLogic.ExecuteInputNavigation(actionName, InputDistributeDefine.EActionType.Press);
				}
				return;
			}
			if (UiNavigationJoystickInput.TargetActionType.GetValueOrDefault() == InputDistributeDefine.EActionType.Release && UiNavigationJoystickInput.RepeatPressTime > UiNavigationJoystickInput.PressInterval)
			{
				UiNavigationJoystickInput.RepeatPressTime -= UiNavigationJoystickInput.PressInterval;
				UiNavigationJoystickInput.TargetActionType = new InputDistributeDefine.EActionType?(InputDistributeDefine.EActionType.Press);
				UiNavigationLogic.ExecuteInputNavigation(actionName, InputDistributeDefine.EActionType.Release);
			}
		}

		// Token: 0x06033137 RID: 209207 RVA: 0x00CCAD78 File Offset: 0x00CC8F78
		private static void HandleCanTriggerTag(float leftJoystickX, float leftJoystickY)
		{
			float num;
			float num2;
			if (UiNavigationJoystickInput.Direction == "UI方向右" || UiNavigationJoystickInput.Direction == "UI方向上")
			{
				num = UiNavigationJoystickInput.LastLeftJoystickX - leftJoystickX;
				num2 = UiNavigationJoystickInput.LastLeftJoystickY - leftJoystickY;
			}
			else
			{
				num = leftJoystickX - UiNavigationJoystickInput.LastLeftJoystickX;
				num2 = leftJoystickY - UiNavigationJoystickInput.LastLeftJoystickY;
			}
			if (num > 0.2f || num2 > 0.2f)
			{
				UiNavigationJoystickInput.IsCanTrigger = true;
			}
		}

		// Token: 0x06033138 RID: 209208 RVA: 0x00CCADE0 File Offset: 0x00CC8FE0
		private static void TriggerLeftJoystickFunction()
		{
			if (UiNavigationJoystickInput.IsCanTrigger)
			{
				if (string.IsNullOrEmpty(UiNavigationJoystickInput.Direction))
				{
					return;
				}
				ENavigationDirectionType obj = UiNavigationJoystickInput.TypeMap[UiNavigationJoystickInput.Direction];
				foreach (KeyValuePair<Action<ENavigationDirectionType>, bool> keyValuePair in UiNavigationJoystickInput.LeftJoystickFunctionMap)
				{
					if (!keyValuePair.Value)
					{
						keyValuePair.Key(obj);
					}
				}
			}
			foreach (Action<ENavigationDirectionType> key in new List<Action<ENavigationDirectionType>>(UiNavigationJoystickInput.LeftJoystickFunctionMap.Keys))
			{
				UiNavigationJoystickInput.LeftJoystickFunctionMap[key] = false;
			}
		}

		// Token: 0x06033139 RID: 209209 RVA: 0x00CCAEB8 File Offset: 0x00CC90B8
		public static void RegisterLeftJoystickFunction(Action<ENavigationDirectionType> callback)
		{
			UiNavigationJoystickInput.LeftJoystickFunctionMap[callback] = UiNavigationJoystickInput.IsPress;
		}

		// Token: 0x0603313A RID: 209210 RVA: 0x00CCAECA File Offset: 0x00CC90CA
		public static void UnRegisterLeftJoystickFunction(Action<ENavigationDirectionType> callback)
		{
			UiNavigationJoystickInput.LeftJoystickFunctionMap.Remove(callback);
		}

		// Token: 0x0603313B RID: 209211 RVA: 0x00CCAED8 File Offset: 0x00CC90D8
		public static void TriggerActionInputTick(string actionName, InputDistributeDefine.EActionType actionType)
		{
			if (UiNavigationJoystickInput.IsPress)
			{
				return;
			}
			if (!string.IsNullOrEmpty(UiNavigationJoystickInput.InputActionName) && UiNavigationJoystickInput.InputActionName != actionName)
			{
				return;
			}
			if (actionType == InputDistributeDefine.EActionType.Press)
			{
				UiNavigationJoystickInput.InputActionName = actionName;
				UiNavigationJoystickInput.InputActionType = new InputDistributeDefine.EActionType?(actionType);
				UiNavigationJoystickInput.IsTickFirstAction = true;
				UiNavigationJoystickInput.IsTickRepeatAction = true;
				UiNavigationJoystickInput.TargetActionType = new InputDistributeDefine.EActionType?(InputDistributeDefine.EActionType.Release);
				UiNavigationJoystickInput.RepeatPressTime = 0f;
				UiNavigationJoystickInput.PressInterval = 500f;
				return;
			}
			UiNavigationJoystickInput.InputActionName = actionName;
			UiNavigationJoystickInput.InputActionType = new InputDistributeDefine.EActionType?(actionType);
			UiNavigationJoystickInput.IsTickFirstAction = true;
			UiNavigationJoystickInput.IsTickRepeatAction = false;
			UiNavigationJoystickInput.TargetActionType = new InputDistributeDefine.EActionType?(InputDistributeDefine.EActionType.Press);
		}

		// Token: 0x0603313C RID: 209212 RVA: 0x00CCAF70 File Offset: 0x00CC9170
		public static void ResetJoystickActionInput()
		{
			if (!string.IsNullOrEmpty(UiNavigationJoystickInput.InputActionName))
			{
				Singleton<Log>.Instance.Info(ELogModule.UiNavigation, ELogAuthor.XXJ, "ResetJoystickActionInput", default(ReadOnlySpan<ValueTuple<string, object>>));
				UiNavigationLogic.ExecuteInputNavigation(UiNavigationJoystickInput.InputActionName, InputDistributeDefine.EActionType.Release);
				UiNavigationJoystickInput.InputActionName = "";
				UiNavigationJoystickInput.IsTickRepeatAction = false;
				UiNavigationJoystickInput.InputActionType = null;
				UiNavigationJoystickInput.IsTickFirstAction = false;
				UiNavigationJoystickInput.TargetActionType = new InputDistributeDefine.EActionType?(InputDistributeDefine.EActionType.Press);
			}
		}

		// Token: 0x0603313D RID: 209213 RVA: 0x00CCAFE0 File Offset: 0x00CC91E0
		public static void CreateStaticDefaultValue()
		{
			UiNavigationJoystickInput.TempVector = new Vector();
			UiNavigationJoystickInput._leftJoystickFunctionMap = new Dictionary<Action<ENavigationDirectionType>, bool>();
			UiNavigationJoystickInput._typeMap = new Dictionary<string, ENavigationDirectionType>
			{
				{
					"UI方向下",
					ENavigationDirectionType.Down
				},
				{
					"UI方向右",
					ENavigationDirectionType.Right
				},
				{
					"UI方向上",
					ENavigationDirectionType.Up
				},
				{
					"UI方向左",
					ENavigationDirectionType.Left
				}
			};
		}

		// Token: 0x0603313E RID: 209214 RVA: 0x00CCB03C File Offset: 0x00CC923C
		public static void ResetStaticDefaultValue()
		{
			UiNavigationJoystickInput.Direction = "";
			UiNavigationJoystickInput.PressInterval = 0f;
			UiNavigationJoystickInput.RepeatPressTime = 0f;
			UiNavigationJoystickInput.TargetActionType = null;
			UiNavigationJoystickInput.IsPress = false;
			UiNavigationJoystickInput.InputActionName = "";
			UiNavigationJoystickInput.InputActionType = null;
			UiNavigationJoystickInput.IsTickRepeatAction = false;
			UiNavigationJoystickInput.IsTickFirstAction = false;
			UiNavigationJoystickInput.LastLeftJoystickX = 0f;
			UiNavigationJoystickInput.LastLeftJoystickY = 0f;
			UiNavigationJoystickInput.IsCanTrigger = false;
			UiNavigationJoystickInput.TempVector = null;
			UiNavigationJoystickInput._leftJoystickFunctionMap = null;
			UiNavigationJoystickInput._typeMap = null;
		}

		// Token: 0x0401DB2C RID: 121644
		private const float PressThreshold = 0.7f;

		// Token: 0x0401DB2D RID: 121645
		private const float ReleaseThreshold = 0.2f;

		// Token: 0x0401DB2E RID: 121646
		private const float ReleaseDistance = 0.2f;

		// Token: 0x0401DB2F RID: 121647
		private const float FirstPressInterval = 500f;

		// Token: 0x0401DB30 RID: 121648
		private const float RepeatPressInterval = 100f;

		// Token: 0x0401DB31 RID: 121649
		private const float ReleaseInterval = 100f;

		// Token: 0x0401DB32 RID: 121650
		private static string Direction = "";

		// Token: 0x0401DB33 RID: 121651
		private static float PressInterval = 0f;

		// Token: 0x0401DB34 RID: 121652
		private static float RepeatPressTime = 0f;

		// Token: 0x0401DB35 RID: 121653
		private static InputDistributeDefine.EActionType? TargetActionType = null;

		// Token: 0x0401DB36 RID: 121654
		[Nullable(2)]
		private static Vector TempVector;

		// Token: 0x0401DB37 RID: 121655
		private static bool IsPress = false;

		// Token: 0x0401DB38 RID: 121656
		private static string InputActionName = "";

		// Token: 0x0401DB39 RID: 121657
		private static InputDistributeDefine.EActionType? InputActionType = null;

		// Token: 0x0401DB3A RID: 121658
		private static bool IsTickRepeatAction = false;

		// Token: 0x0401DB3B RID: 121659
		private static bool IsTickFirstAction = false;

		// Token: 0x0401DB3C RID: 121660
		private static float LastLeftJoystickX = 0f;

		// Token: 0x0401DB3D RID: 121661
		private static float LastLeftJoystickY = 0f;

		// Token: 0x0401DB3E RID: 121662
		private static bool IsCanTrigger = false;

		// Token: 0x0401DB3F RID: 121663
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private static Dictionary<Action<ENavigationDirectionType>, bool> _leftJoystickFunctionMap;

		// Token: 0x0401DB40 RID: 121664
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private static IReadOnlyDictionary<string, ENavigationDirectionType> _typeMap;
	}
}
