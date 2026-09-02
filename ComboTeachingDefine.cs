using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Input;

// Token: 0x02001871 RID: 6257
public class ComboTeachingDefine : IStaticVariableResetter
{
	// Token: 0x0600B35C RID: 45916 RVA: 0x002FDA27 File Offset: 0x002FBC27
	static ComboTeachingDefine()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(ComboTeachingDefine.CreateStaticDefaultValue), new Action(ComboTeachingDefine.ResetStaticDefaultValue));
	}

	// Token: 0x0600B35D RID: 45917 RVA: 0x002FDA48 File Offset: 0x002FBC48
	public static void CreateStaticDefaultValue()
	{
		Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
		dictionary["普攻"] = new List<string>
		{
			"战斗状态.输入限制.禁止攻击",
			"功能.功能制作.隐藏按钮功能.隐藏普攻按键"
		};
		dictionary["技能"] = new List<string>
		{
			"战斗状态.输入限制.禁止技能",
			"功能.功能制作.隐藏按钮功能.隐藏技能按键"
		};
		dictionary["大招"] = new List<string>
		{
			"战斗状态.输入限制.禁止大招",
			"功能.功能制作.隐藏按钮功能.隐藏大招按键"
		};
		dictionary["跳跃"] = new List<string>
		{
			"战斗状态.输入限制.禁止跳跃",
			"功能.功能制作.隐藏按钮功能.隐藏跳跃按键"
		};
		dictionary["幻象"] = new List<string>
		{
			"战斗状态.输入限制.禁止幻象1",
			"战斗状态.输入限制.禁止幻象2",
			"功能.功能制作.隐藏按钮功能.隐藏探索幻象按键",
			"功能.功能制作.隐藏按钮功能.隐藏攻击幻象按键"
		};
		dictionary["闪避"] = new List<string>
		{
			"战斗状态.输入限制.禁止闪避",
			"功能.功能制作.隐藏按钮功能.隐藏冲刺按键"
		};
		ComboTeachingDefine.banKeyMap = dictionary;
		Dictionary<EInputAction, string> dictionary2 = new Dictionary<EInputAction, string>();
		EInputAction 跳跃 = EInputAction.跳跃;
		dictionary2[跳跃] = "跳跃";
		EInputAction 攀爬 = EInputAction.攀爬;
		dictionary2[攀爬] = "攀爬";
		EInputAction 走跑切换 = EInputAction.走跑切换;
		dictionary2[走跑切换] = "走跑切换";
		EInputAction 攻击 = EInputAction.攻击;
		dictionary2[攻击] = "攻击";
		EInputAction 闪避 = EInputAction.闪避;
		dictionary2[闪避] = "闪避";
		EInputAction 技能 = EInputAction.技能1;
		dictionary2[技能] = "技能1";
		EInputAction 幻象 = EInputAction.幻象1;
		dictionary2[幻象] = "幻象1";
		EInputAction 大招 = EInputAction.大招;
		dictionary2[大招] = "大招";
		EInputAction 幻象2 = EInputAction.幻象2;
		dictionary2[幻象2] = "幻象2";
		EInputAction 切换角色 = EInputAction.切换角色1;
		dictionary2[切换角色] = "切换角色1";
		EInputAction 切换角色2 = EInputAction.切换角色2;
		dictionary2[切换角色2] = "切换角色2";
		EInputAction 切换角色3 = EInputAction.切换角色3;
		dictionary2[切换角色3] = "切换角色3";
		EInputAction 锁定目标 = EInputAction.锁定目标;
		dictionary2[锁定目标] = "锁定目标";
		EInputAction 瞄准 = EInputAction.瞄准;
		dictionary2[瞄准] = "瞄准";
		EInputAction 通用交互 = EInputAction.通用交互;
		dictionary2[通用交互] = "通用交互";
		ComboTeachingDefine.inputActionMap = dictionary2;
	}

	// Token: 0x0600B35E RID: 45918 RVA: 0x002FDC87 File Offset: 0x002FBE87
	public static void ResetStaticDefaultValue()
	{
		ComboTeachingDefine.banKeyMap = null;
		ComboTeachingDefine.inputActionMap = null;
	}

	// Token: 0x040054CC RID: 21708
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	public static Dictionary<string, List<string>> banKeyMap;

	// Token: 0x040054CD RID: 21709
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public static Dictionary<EInputAction, string> inputActionMap;
}
