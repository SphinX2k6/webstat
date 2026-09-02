using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.InputSetting
{
	// Token: 0x02006FFA RID: 28666
	[NullableContext(1)]
	[Nullable(0)]
	public class InputActionKey
	{
		// Token: 0x0604565D RID: 284253 RVA: 0x012254F4 File Offset: 0x012236F4
		public void CreateUeData()
		{
			this.UeActionName = FNameUtil.GetCheckDynamicFName(this.ActionName);
			this.UeKeyName = FNameUtil.GetCheckDynamicFName(this.KeyName);
			this.UeKey = new FKey(this.UeKeyName);
			this.UeInputActionKeyMapping = new FInputActionKeyMapping(this.UeActionName, this.IsShift, this.IsCtrl, this.IsAlt, this.IsCmd, this.UeKey);
		}

		// Token: 0x0604565E RID: 284254 RVA: 0x01225563 File Offset: 0x01223763
		public static InputActionKey New(string actionName, bool bShift, bool bCtrl, bool bAlt, bool bCmd, string keyName)
		{
			InputActionKey inputActionKey = new InputActionKey();
			inputActionKey.ActionName = actionName;
			inputActionKey.IsShift = bShift;
			inputActionKey.IsCtrl = bCtrl;
			inputActionKey.IsAlt = bAlt;
			inputActionKey.IsCmd = bCmd;
			inputActionKey.KeyName = keyName;
			inputActionKey.CreateUeData();
			return inputActionKey;
		}

		// Token: 0x0604565F RID: 284255 RVA: 0x0122559C File Offset: 0x0122379C
		public static InputActionKey NewByInputActionKeyMapping(FInputActionKeyMapping inputActionKeyMapping)
		{
			InputActionKey inputActionKey = new InputActionKey();
			inputActionKey.ActionName = inputActionKeyMapping.ActionName.ToString();
			inputActionKey.IsShift = inputActionKeyMapping.bShift;
			inputActionKey.IsCtrl = inputActionKeyMapping.bCtrl;
			inputActionKey.IsAlt = inputActionKeyMapping.bAlt;
			inputActionKey.IsCmd = inputActionKeyMapping.bCmd;
			inputActionKey.KeyName = inputActionKeyMapping.Key.KeyName.ToString();
			inputActionKey.CreateUeData();
			return inputActionKey;
		}

		// Token: 0x06045660 RID: 284256 RVA: 0x01225620 File Offset: 0x01223820
		public static void Refresh(InputActionKey inputActionKey, string actionName, bool bShift, bool bCtrl, bool bAlt, bool bCmd, string keyName)
		{
			inputActionKey.ActionName = actionName;
			inputActionKey.IsShift = bShift;
			inputActionKey.IsCtrl = bCtrl;
			inputActionKey.IsAlt = bAlt;
			inputActionKey.IsCmd = bCmd;
			inputActionKey.KeyName = keyName;
			inputActionKey.UeActionName = FNameUtil.GetCheckDynamicFName(actionName);
			inputActionKey.UeKeyName = FNameUtil.GetCheckDynamicFName(keyName);
			inputActionKey.UeKey.KeyName = inputActionKey.UeKeyName;
			inputActionKey.UeInputActionKeyMapping.ActionName = inputActionKey.UeActionName;
			inputActionKey.UeInputActionKeyMapping.bShift = bShift;
			inputActionKey.UeInputActionKeyMapping.bCtrl = bCtrl;
			inputActionKey.UeInputActionKeyMapping.bAlt = bAlt;
			inputActionKey.UeInputActionKeyMapping.bCmd = bCmd;
			inputActionKey.UeInputActionKeyMapping.Key = inputActionKey.UeKey;
		}

		// Token: 0x06045661 RID: 284257 RVA: 0x012256D8 File Offset: 0x012238D8
		public FInputActionKeyMapping ToUeInputActionKeyMapping()
		{
			return this.UeInputActionKeyMapping;
		}

		// Token: 0x06045662 RID: 284258 RVA: 0x012256E0 File Offset: 0x012238E0
		[NullableContext(2)]
		public InputKey GetKey()
		{
			return Singleton<InputSettings>.Instance.GetKey(this.KeyName);
		}

		// Token: 0x06045663 RID: 284259 RVA: 0x012256F4 File Offset: 0x012238F4
		public string GetKeyIconPath()
		{
			InputKey key = this.GetKey();
			if (key == null)
			{
				return string.Empty;
			}
			return key.GetKeyIconPath();
		}

		// Token: 0x06045664 RID: 284260 RVA: 0x01225718 File Offset: 0x01223918
		public bool IsEqual(FInputActionKeyMapping inputActionKeyMapping)
		{
			return this.ActionName == inputActionKeyMapping.ActionName.ToString() && this.KeyName == inputActionKeyMapping.Key.KeyName.ToString() && this.IsAlt == inputActionKeyMapping.bAlt && this.IsCmd == inputActionKeyMapping.bCmd && this.IsCtrl == inputActionKeyMapping.bCtrl && this.IsShift == inputActionKeyMapping.bShift;
		}

		// Token: 0x04026CA9 RID: 158889
		public string ActionName = "";

		// Token: 0x04026CAA RID: 158890
		public bool IsAlt;

		// Token: 0x04026CAB RID: 158891
		public bool IsCmd;

		// Token: 0x04026CAC RID: 158892
		public bool IsCtrl;

		// Token: 0x04026CAD RID: 158893
		public bool IsShift;

		// Token: 0x04026CAE RID: 158894
		public string KeyName = "";

		// Token: 0x04026CAF RID: 158895
		public FName UeActionName;

		// Token: 0x04026CB0 RID: 158896
		public FName UeKeyName;

		// Token: 0x04026CB1 RID: 158897
		public FKey UeKey;

		// Token: 0x04026CB2 RID: 158898
		public FInputActionKeyMapping UeInputActionKeyMapping;
	}
}
