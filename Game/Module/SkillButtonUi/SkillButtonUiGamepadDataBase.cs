using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Input;

namespace CSharpScript.Game.Module.SkillButtonUi
{
	// Token: 0x02004F94 RID: 20372
	[NullableContext(1)]
	[Nullable(0)]
	public class SkillButtonUiGamepadDataBase
	{
		// Token: 0x06034927 RID: 215335 RVA: 0x00D2E863 File Offset: 0x00D2CA63
		public virtual void Init()
		{
		}

		// Token: 0x06034928 RID: 215336 RVA: 0x00D2E865 File Offset: 0x00D2CA65
		public virtual void Clear()
		{
		}

		// Token: 0x06034929 RID: 215337 RVA: 0x00D2E867 File Offset: 0x00D2CA67
		public virtual IReadOnlyList<string> GetAllActionNameList()
		{
			return Array.Empty<string>();
		}

		// Token: 0x0603492A RID: 215338 RVA: 0x00D2E86E File Offset: 0x00D2CA6E
		public virtual IReadOnlyList<string> GetAllAxisNameList()
		{
			return Array.Empty<string>();
		}

		// Token: 0x0603492B RID: 215339 RVA: 0x00D2E875 File Offset: 0x00D2CA75
		public virtual void RefreshBaseConfigByUserSetting()
		{
		}

		// Token: 0x0603492C RID: 215340 RVA: 0x00D2E877 File Offset: 0x00D2CA77
		public virtual void RefreshSwitchInteractOpen(bool isInit = false)
		{
			this.SwitchInteractData.RefreshSwitchInteractOpen(isInit);
		}

		// Token: 0x0603492D RID: 215341 RVA: 0x00D2E885 File Offset: 0x00D2CA85
		public virtual bool RefreshButtonData()
		{
			return false;
		}

		// Token: 0x0603492E RID: 215342 RVA: 0x00D2E888 File Offset: 0x00D2CA88
		public virtual int GetButtonTypeByActionName(string actionName)
		{
			return 0;
		}

		// Token: 0x0603492F RID: 215343 RVA: 0x00D2E88B File Offset: 0x00D2CA8B
		public virtual int GetButtonTypeByAxisName(string axisName, float value)
		{
			return 0;
		}

		// Token: 0x06034930 RID: 215344 RVA: 0x00D2E88E File Offset: 0x00D2CA8E
		public virtual bool IsAim()
		{
			return false;
		}

		// Token: 0x06034931 RID: 215345 RVA: 0x00D2E891 File Offset: 0x00D2CA91
		public virtual void SetIsPressCombineButton(bool value)
		{
		}

		// Token: 0x06034932 RID: 215346 RVA: 0x00D2E893 File Offset: 0x00D2CA93
		public virtual bool GetIsPressCombineButton()
		{
			return false;
		}

		// Token: 0x06034933 RID: 215347 RVA: 0x00D2E896 File Offset: 0x00D2CA96
		public virtual void RefreshSkillButtonData(ESkillButtonRefreshReason refreshReason)
		{
		}

		// Token: 0x06034934 RID: 215348 RVA: 0x00D2E898 File Offset: 0x00D2CA98
		public virtual bool RefreshAimState()
		{
			return false;
		}

		// Token: 0x06034935 RID: 215349 RVA: 0x00D2E89B File Offset: 0x00D2CA9B
		public virtual void RefreshInteractBehaviorData()
		{
		}

		// Token: 0x06034936 RID: 215350 RVA: 0x00D2E89D File Offset: 0x00D2CA9D
		public virtual void OnActionKeyChanged(string actionName)
		{
		}

		// Token: 0x06034937 RID: 215351 RVA: 0x00D2E89F File Offset: 0x00D2CA9F
		public virtual void AddChangeKeyReason(EGamepadChangeKeyReason reason)
		{
		}

		// Token: 0x06034938 RID: 215352 RVA: 0x00D2E8A1 File Offset: 0x00D2CAA1
		public virtual void RemoveChangeKeyReason(EGamepadChangeKeyReason reason)
		{
		}

		// Token: 0x06034939 RID: 215353 RVA: 0x00D2E8A3 File Offset: 0x00D2CAA3
		public virtual void AddAllowChangeKeyReason(string reason)
		{
		}

		// Token: 0x0603493A RID: 215354 RVA: 0x00D2E8A5 File Offset: 0x00D2CAA5
		public virtual void RemoveAllowChangeKeyReason(string reason)
		{
		}

		// Token: 0x0603493B RID: 215355 RVA: 0x00D2E8A7 File Offset: 0x00D2CAA7
		public virtual void CacheInputAxis(in EInputAxis axis, float value)
		{
		}

		// Token: 0x0603493C RID: 215356 RVA: 0x00D2E8A9 File Offset: 0x00D2CAA9
		public virtual float GetInputAxis(in EInputAxis axis)
		{
			return 0f;
		}

		// Token: 0x0603493D RID: 215357 RVA: 0x00D2E8B0 File Offset: 0x00D2CAB0
		public virtual void ClearInputAxis()
		{
		}

		// Token: 0x0401E4E6 RID: 124134
		public ESkillButtonGamepadDataType GamepadDataType;

		// Token: 0x0401E4E7 RID: 124135
		public List<string> ButtonKeyList = new List<string>();

		// Token: 0x0401E4E8 RID: 124136
		public string NoneIcon = "";

		// Token: 0x0401E4E9 RID: 124137
		public List<int?> CurButtonTypeList = new List<int?>();

		// Token: 0x0401E4EA RID: 124138
		public List<int?> LastButtonTypeList = new List<int?>();

		// Token: 0x0401E4EB RID: 124139
		public string CombineButtonKey = "";

		// Token: 0x0401E4EC RID: 124140
		public int[] MainSkillButtonTypeList = Array.Empty<int>();

		// Token: 0x0401E4ED RID: 124141
		public int[] MainSkillCombineButtonTypeList = Array.Empty<int>();

		// Token: 0x0401E4EE RID: 124142
		public int[] DpadSkillButtonTypeList = Array.Empty<int>();

		// Token: 0x0401E4EF RID: 124143
		public int[] DpadSkillCombineButtonTypeList = Array.Empty<int>();

		// Token: 0x0401E4F0 RID: 124144
		public int[] SubSkillButtonTypeList = Array.Empty<int>();

		// Token: 0x0401E4F1 RID: 124145
		public int[] SubSkillCombineButtonTypeList = Array.Empty<int>();

		// Token: 0x0401E4F2 RID: 124146
		public int[] SubAimSkillButtonTypeList = Array.Empty<int>();

		// Token: 0x0401E4F3 RID: 124147
		public bool ControlCameraByMoveAxis;

		// Token: 0x0401E4F4 RID: 124148
		[Nullable(2)]
		public string RouletteKey;

		// Token: 0x0401E4F5 RID: 124149
		[Nullable(2)]
		public string RouletteMainKey;

		// Token: 0x0401E4F6 RID: 124150
		[Nullable(2)]
		public string RouletteSecondKey;

		// Token: 0x0401E4F7 RID: 124151
		public GamepadSwitchInteractData SwitchInteractData = new GamepadSwitchInteractData();
	}
}
