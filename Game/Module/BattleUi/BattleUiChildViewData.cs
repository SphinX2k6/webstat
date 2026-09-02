using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.BattleUi
{
	// Token: 0x02005F52 RID: 24402
	[NullableContext(1)]
	[Nullable(0)]
	public class BattleUiChildViewData
	{
		// Token: 0x0603D495 RID: 251029 RVA: 0x00F96AE3 File Offset: 0x00F94CE3
		public void AddBattleUiCommonChildVisibleReason(EBattleUiCommonChildVisibleReason visibleReason)
		{
			this.BattleUiCommonChildReasonSet.Add(visibleReason);
			this.SetChildrenVisible(EBattleUiVisibleReason.Default, BattleUiChildViewData.BattleUiChildren, this.BattleUiCommonChildReasonSet.Count > 0, true, 0);
		}

		// Token: 0x0603D496 RID: 251030 RVA: 0x00F96B0E File Offset: 0x00F94D0E
		public void RemoveBattleUiCommonChildVisibleReason(EBattleUiCommonChildVisibleReason visibleReason)
		{
			this.BattleUiCommonChildReasonSet.Remove(visibleReason);
			this.SetChildrenVisible(EBattleUiVisibleReason.Default, BattleUiChildViewData.BattleUiChildren, this.BattleUiCommonChildReasonSet.Count > 0, true, 0);
		}

		// Token: 0x0603D497 RID: 251031 RVA: 0x00F96B3C File Offset: 0x00F94D3C
		public void Init()
		{
			this.VisibleStateList.Clear();
			this.SubVisibleStateList.Clear();
			for (int i = 0; i < 46; i++)
			{
				this.VisibleStateList.Add(1);
				int[] array = new int[21];
				array[0] = 1;
				this.SubVisibleStateList.Add(array);
			}
			this.VisibleStateList.Add(0);
			this.SubVisibleStateList.Add(new int[21]);
		}

		// Token: 0x0603D498 RID: 251032 RVA: 0x00F96BAE File Offset: 0x00F94DAE
		public void OnLeaveLevel()
		{
		}

		// Token: 0x0603D499 RID: 251033 RVA: 0x00F96BB0 File Offset: 0x00F94DB0
		public void Clear()
		{
		}

		// Token: 0x0603D49A RID: 251034 RVA: 0x00F96BB2 File Offset: 0x00F94DB2
		public bool GetChildVisible(EBattleUiChild childType)
		{
			return this.VisibleStateList[(int)childType] == 0;
		}

		// Token: 0x0603D49B RID: 251035 RVA: 0x00F96BC4 File Offset: 0x00F94DC4
		public bool SetChildVisible(EBattleUiVisibleReason visibleReason, EBattleUiChild childType, bool bVisible, bool dispatchEvent = true, int subVisibleReason = 0)
		{
			int num = this.VisibleStateList[(int)childType];
			int num2 = VisibleStateUtil.SetVisible(this.SubVisibleStateList[(int)childType][(int)visibleReason], bVisible, subVisibleReason);
			this.SubVisibleStateList[(int)childType][(int)visibleReason] = num2;
			bool bVisible2 = num2 == 0;
			int num3 = VisibleStateUtil.SetVisible(num, bVisible2, (int)visibleReason);
			this.VisibleStateList[(int)childType] = num3;
			if (dispatchEvent && num != num3 && (num == 0 || num3 == 0))
			{
				this.HandleCallback(childType);
			}
			return num3 == 0;
		}

		// Token: 0x0603D49C RID: 251036 RVA: 0x00F96C38 File Offset: 0x00F94E38
		public void SetChildrenVisible(EBattleUiVisibleReason visibleReason, IEnumerable<EBattleUiChild> childrenType, bool bVisible, bool dispatchEvent = true, int subVisibleReason = 0)
		{
			foreach (EBattleUiChild childType in childrenType)
			{
				this.SetChildVisible(visibleReason, childType, bVisible, dispatchEvent, subVisibleReason);
			}
		}

		// Token: 0x0603D49D RID: 251037 RVA: 0x00F96C88 File Offset: 0x00F94E88
		[NullableContext(2)]
		public void HideBattleView(EBattleUiVisibleReason visibleReason, IEnumerable<EBattleUiChild> excludeChildren = null, int subVisibleReason = 0)
		{
			for (int i = 0; i < 46; i++)
			{
				this.SetChildVisible(visibleReason, (EBattleUiChild)i, false, false, subVisibleReason);
			}
			if (excludeChildren != null)
			{
				foreach (EBattleUiChild childType in excludeChildren)
				{
					this.SetChildVisible(visibleReason, childType, true, false, subVisibleReason);
				}
			}
			this.HandleAllCallback();
		}

		// Token: 0x0603D49E RID: 251038 RVA: 0x00F96CF8 File Offset: 0x00F94EF8
		public void ShowBattleView(EBattleUiVisibleReason visibleReason, int subVisibleReason = 0)
		{
			for (int i = 0; i < 46; i++)
			{
				this.SetChildVisible(visibleReason, (EBattleUiChild)i, true, false, subVisibleReason);
			}
			this.HandleAllCallback();
		}

		// Token: 0x0603D49F RID: 251039 RVA: 0x00F96D24 File Offset: 0x00F94F24
		public bool GetVisibleByReason(EBattleUiChild childType, EBattleUiVisibleReason reason)
		{
			return VisibleStateUtil.GetVisibleByType(this.VisibleStateList[(int)childType], (int)reason);
		}

		// Token: 0x0603D4A0 RID: 251040 RVA: 0x00F96D38 File Offset: 0x00F94F38
		public void AddCallback(EBattleUiChild childType, Action callback)
		{
			List<Action> list;
			if (!this.CallbackMap.TryGetValue(childType, out list))
			{
				list = new List<Action>();
				this.CallbackMap[childType] = list;
			}
			list.Add(callback);
		}

		// Token: 0x0603D4A1 RID: 251041 RVA: 0x00F96D70 File Offset: 0x00F94F70
		public void RemoveCallback(EBattleUiChild childType, Action callback)
		{
			List<Action> list;
			if (!this.CallbackMap.TryGetValue(childType, out list))
			{
				return;
			}
			list.Remove(callback);
		}

		// Token: 0x0603D4A2 RID: 251042 RVA: 0x00F96D98 File Offset: 0x00F94F98
		private void HandleCallback(EBattleUiChild childType)
		{
			List<Action> list;
			if (!this.CallbackMap.TryGetValue(childType, out list))
			{
				return;
			}
			foreach (Action action in list)
			{
				action();
			}
		}

		// Token: 0x0603D4A3 RID: 251043 RVA: 0x00F96DF4 File Offset: 0x00F94FF4
		private void HandleAllCallback()
		{
			try
			{
				foreach (List<Action> list in this.CallbackMap.Values)
				{
					foreach (Action action in list)
					{
						action();
					}
				}
			}
			catch (Exception ex)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Battle;
				ELogAuthor author = ELogAuthor.CFT;
				string message = "childViewError";
				Exception error = ex;
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("", ex.Message);
				instance.ErrorWithStack(module, author, message, error, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
		}

		// Token: 0x0603D4A4 RID: 251044 RVA: 0x00F96EBC File Offset: 0x00F950BC
		public void DebugLogAllChildState()
		{
			for (int i = 0; i < 47; i++)
			{
				if (this.VisibleStateList[i] != 0)
				{
					for (int j = 0; j < 21; j++)
					{
						if (!VisibleStateUtil.GetVisibleByType(this.VisibleStateList[i], j))
						{
							int visibleState = (i < this.SubVisibleStateList.Count) ? this.SubVisibleStateList[i][j] : 0;
							List<int> list = new List<int>();
							for (int k = 0; k < 31; k++)
							{
								if (!VisibleStateUtil.GetVisibleByType(visibleState, k))
								{
									list.Add(k);
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x04022668 RID: 140904
		private static readonly IReadOnlyList<EBattleUiChild> BattleUiChildren = new <>z__ReadOnlyArray<EBattleUiChild>(new EBattleUiChild[]
		{
			EBattleUiChild.Common,
			EBattleUiChild.HeadState,
			EBattleUiChild.PartState,
			EBattleUiChild.DamageView,
			EBattleUiChild.BattleHud,
			EBattleUiChild.BattleFloat,
			EBattleUiChild.InteractionHint,
			EBattleUiChild.PanelQTE,
			EBattleUiChild.GuideTipsView,
			EBattleUiChild.PositionOfficial,
			EBattleUiChild.MotorcycleControlTop,
			EBattleUiChild.MotorcycleMobileSkillButton,
			EBattleUiChild.MotorcycleMobileJoystick,
			EBattleUiChild.MotorcycleControlHud
		});

		// Token: 0x04022669 RID: 140905
		private readonly List<int> VisibleStateList = new List<int>();

		// Token: 0x0402266A RID: 140906
		private readonly List<int[]> SubVisibleStateList = new List<int[]>();

		// Token: 0x0402266B RID: 140907
		private readonly Dictionary<EBattleUiChild, List<Action>> CallbackMap = new Dictionary<EBattleUiChild, List<Action>>();

		// Token: 0x0402266C RID: 140908
		private readonly HashSet<EBattleUiCommonChildVisibleReason> BattleUiCommonChildReasonSet = new HashSet<EBattleUiCommonChildVisibleReason>();
	}
}
