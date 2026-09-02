using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.InputSetting
{
	// Token: 0x02006FFB RID: 28667
	[NullableContext(1)]
	[Nullable(0)]
	public class InputAxisKey
	{
		// Token: 0x06045666 RID: 284262 RVA: 0x012257C4 File Offset: 0x012239C4
		public void CreateUeData()
		{
			this.UeAxisName = FNameUtil.GetDynamicFName(this.AxisName).Value;
			this.UeKeyName = FNameUtil.GetDynamicFName(this.KeyName).Value;
			this.UeKey = new FKey(this.UeKeyName);
			this.UeInputAxisKeyMapping = new FInputAxisKeyMapping(this.UeAxisName, this.Scale, this.UeKey);
		}

		// Token: 0x06045667 RID: 284263 RVA: 0x01225831 File Offset: 0x01223A31
		public static InputAxisKey New(string axisName, float scale, string keyName)
		{
			InputAxisKey inputAxisKey = new InputAxisKey();
			inputAxisKey.AxisName = axisName;
			inputAxisKey.Scale = scale;
			inputAxisKey.KeyName = keyName;
			inputAxisKey.CreateUeData();
			return inputAxisKey;
		}

		// Token: 0x06045668 RID: 284264 RVA: 0x01225854 File Offset: 0x01223A54
		public static InputAxisKey NewByInputAxisKeyMapping(FInputAxisKeyMapping inputAxisKeyMapping)
		{
			InputAxisKey inputAxisKey = new InputAxisKey();
			inputAxisKey.AxisName = inputAxisKeyMapping.AxisName.ToString();
			inputAxisKey.Scale = inputAxisKeyMapping.Scale;
			inputAxisKey.KeyName = inputAxisKeyMapping.Key.KeyName.ToString();
			inputAxisKey.CreateUeData();
			return inputAxisKey;
		}

		// Token: 0x06045669 RID: 284265 RVA: 0x012258B4 File Offset: 0x01223AB4
		public static void Refresh(InputAxisKey inputAxisKey, string axisName, float scale, string keyName)
		{
			inputAxisKey.AxisName = axisName;
			inputAxisKey.Scale = scale;
			inputAxisKey.KeyName = keyName;
			inputAxisKey.UeAxisName = FNameUtil.GetDynamicFName(axisName).Value;
			inputAxisKey.UeKeyName = FNameUtil.GetDynamicFName(keyName).Value;
			inputAxisKey.UeKey.KeyName = inputAxisKey.UeKeyName;
			inputAxisKey.UeInputAxisKeyMapping.AxisName = inputAxisKey.UeAxisName;
			inputAxisKey.UeInputAxisKeyMapping.Scale = scale;
			inputAxisKey.UeInputAxisKeyMapping.Key = inputAxisKey.UeKey;
		}

		// Token: 0x0604566A RID: 284266 RVA: 0x0122593D File Offset: 0x01223B3D
		public FInputAxisKeyMapping ToUeInputAxisKeyMapping()
		{
			return this.UeInputAxisKeyMapping;
		}

		// Token: 0x0604566B RID: 284267 RVA: 0x01225945 File Offset: 0x01223B45
		[NullableContext(2)]
		public InputKey GetKey()
		{
			return Singleton<InputSettings>.Instance.GetKey(this.KeyName);
		}

		// Token: 0x0604566C RID: 284268 RVA: 0x01225958 File Offset: 0x01223B58
		public string GetKeyIconPath()
		{
			InputKey key = this.GetKey();
			if (key == null)
			{
				return "";
			}
			return key.GetKeyIconPath();
		}

		// Token: 0x0604566D RID: 284269 RVA: 0x0122597C File Offset: 0x01223B7C
		public bool IsEqual(FInputAxisKeyMapping inputAxisKeyMapping)
		{
			return this.AxisName == inputAxisKeyMapping.AxisName.ToString() && this.KeyName == inputAxisKeyMapping.Key.KeyName.ToString() && this.Scale == inputAxisKeyMapping.Scale;
		}

		// Token: 0x04026CB3 RID: 158899
		public string AxisName = "";

		// Token: 0x04026CB4 RID: 158900
		public float Scale;

		// Token: 0x04026CB5 RID: 158901
		public string KeyName = "";

		// Token: 0x04026CB6 RID: 158902
		public FName UeAxisName;

		// Token: 0x04026CB7 RID: 158903
		public FName UeKeyName;

		// Token: 0x04026CB8 RID: 158904
		public FKey UeKey;

		// Token: 0x04026CB9 RID: 158905
		public FInputAxisKeyMapping UeInputAxisKeyMapping;
	}
}
