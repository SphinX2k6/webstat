using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.InputSetting;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Input.BattleInputData
{
	// Token: 0x02006FE0 RID: 28640
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class BattleInputData
	{
		// Token: 0x0604547F RID: 283775 RVA: 0x01218754 File Offset: 0x01216954
		public BattleInputData(EInputDataType type, EInputBindingType bindType = EInputBindingType.Original)
		{
			this.Type = type;
			this.KeyBindingType = bindType;
		}

		// Token: 0x06045480 RID: 283776 RVA: 0x0121876C File Offset: 0x0121696C
		public EInputAction? GetAction(string actionName)
		{
			Dictionary<string, EInputAction> dictionary = this.OnGetActionMap();
			if (dictionary.ContainsKey(actionName))
			{
				return new EInputAction?(dictionary[actionName]);
			}
			return null;
		}

		// Token: 0x06045481 RID: 283777 RVA: 0x012187A0 File Offset: 0x012169A0
		public EInputAxis? GetAxis(string axisName)
		{
			Dictionary<string, EInputAxis> dictionary = this.OnGetAxisMap();
			if (dictionary.ContainsKey(axisName))
			{
				return new EInputAxis?(dictionary[axisName]);
			}
			return null;
		}

		// Token: 0x06045482 RID: 283778 RVA: 0x012187D4 File Offset: 0x012169D4
		public string[] GetActionNameList()
		{
			Dictionary<string, EInputAction> dictionary = this.OnGetActionMap();
			string[] array = new string[dictionary.Count];
			int num = 0;
			foreach (string text in dictionary.Keys)
			{
				array[num] = text;
				num++;
			}
			return array;
		}

		// Token: 0x06045483 RID: 283779 RVA: 0x0121883C File Offset: 0x01216A3C
		public string[] GetAxisNameList()
		{
			Dictionary<string, EInputAxis> dictionary = this.OnGetAxisMap();
			string[] array = new string[dictionary.Count];
			int num = 0;
			foreach (string text in dictionary.Keys)
			{
				array[num] = text;
				num++;
			}
			return array;
		}

		// Token: 0x06045484 RID: 283780 RVA: 0x012188A4 File Offset: 0x01216AA4
		[NullableContext(2)]
		public string GetActionNameByInputAction(EInputAction inputAction)
		{
			foreach (KeyValuePair<string, EInputAction> keyValuePair in this.OnGetActionMap())
			{
				if (keyValuePair.Value == inputAction)
				{
					return keyValuePair.Key;
				}
			}
			return null;
		}

		// Token: 0x06045485 RID: 283781 RVA: 0x0121890C File Offset: 0x01216B0C
		public string[] GetMoveAxisList()
		{
			Dictionary<string, EInputAxis> dictionary = this.OnGetAxisMap();
			List<string> list = new List<string>();
			foreach (KeyValuePair<string, EInputAxis> keyValuePair in dictionary)
			{
				if (keyValuePair.Value == EInputAxis.MoveForward || keyValuePair.Value == EInputAxis.MoveRight)
				{
					list.Add(keyValuePair.Key);
				}
			}
			string[] array = new string[list.Count];
			for (int i = 0; i < list.Count; i++)
			{
				array[i] = list[i];
			}
			return array;
		}

		// Token: 0x06045486 RID: 283782 RVA: 0x012189C0 File Offset: 0x01216BC0
		public string[] GetCameraAxisList()
		{
			Dictionary<string, EInputAxis> dictionary = this.OnGetAxisMap();
			List<string> list = new List<string>();
			foreach (KeyValuePair<string, EInputAxis> keyValuePair in dictionary)
			{
				if (keyValuePair.Value == EInputAxis.LookUp || keyValuePair.Value == EInputAxis.Turn || keyValuePair.Value == EInputAxis.Zoom)
				{
					list.Add(keyValuePair.Key);
				}
			}
			string[] array = new string[list.Count];
			for (int i = 0; i < list.Count; i++)
			{
				array[i] = list[i];
			}
			return array;
		}

		// Token: 0x06045487 RID: 283783 RVA: 0x01218A88 File Offset: 0x01216C88
		public bool CheckActionInAllowFightActionNameList(string actionName, InputActionHandle inputActionHandle)
		{
			return this.OnCheckActionInAllowFightActionNameList(actionName, inputActionHandle);
		}

		// Token: 0x06045488 RID: 283784 RVA: 0x01218A92 File Offset: 0x01216C92
		public bool CheckAxisInAllowFightAxisNameList(string axisName, InputAxisHandle inputAxisHandle)
		{
			return this.OnCheckAxisInAllowFightAxisNameList(axisName, inputAxisHandle);
		}

		// Token: 0x06045489 RID: 283785
		protected abstract Dictionary<string, EInputAction> OnGetActionMap();

		// Token: 0x0604548A RID: 283786
		protected abstract Dictionary<string, EInputAxis> OnGetAxisMap();

		// Token: 0x0604548B RID: 283787 RVA: 0x01218A9C File Offset: 0x01216C9C
		protected virtual bool OnCheckActionInAllowFightActionNameList(string actionName, InputActionHandle inputActionHandle)
		{
			return true;
		}

		// Token: 0x0604548C RID: 283788 RVA: 0x01218A9F File Offset: 0x01216C9F
		protected virtual bool OnCheckAxisInAllowFightAxisNameList(string axisName, InputAxisHandle inputAxisHandle)
		{
			return true;
		}

		// Token: 0x04026A86 RID: 158342
		public EInputDataType Type;

		// Token: 0x04026A87 RID: 158343
		public EInputBindingType KeyBindingType;
	}
}
