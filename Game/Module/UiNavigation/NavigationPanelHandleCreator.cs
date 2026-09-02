using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004C97 RID: 19607
	[NullableContext(1)]
	[Nullable(0)]
	public class NavigationPanelHandleCreator : IStaticVariableResetter
	{
		// Token: 0x06033193 RID: 209299 RVA: 0x00CCC2E0 File Offset: 0x00CCA4E0
		static NavigationPanelHandleCreator()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(NavigationPanelHandleCreator.CreateStaticDefaultValue), new Action(NavigationPanelHandleCreator.ResetStaticDefaultValue));
		}

		// Token: 0x170087BA RID: 34746
		// (get) Token: 0x06033194 RID: 209300 RVA: 0x00CCC2FF File Offset: 0x00CCA4FF
		private static Dictionary<string, Type> SpecialPanelHandleMap
		{
			get
			{
				return NavigationPanelHandleCreator._specialPanelHandleMap;
			}
		}

		// Token: 0x06033195 RID: 209301 RVA: 0x00CCC306 File Offset: 0x00CCA506
		public static void RegisterSpecialPanelHandle(string tag, Type ctor)
		{
			NavigationPanelHandleCreator.SpecialPanelHandleMap[tag] = ctor;
		}

		// Token: 0x06033196 RID: 209302 RVA: 0x00CCC314 File Offset: 0x00CCA514
		[return: Nullable(2)]
		public static SpecialPanelHandleBase GetPanelHandle(string tag)
		{
			Type type;
			if (!NavigationPanelHandleCreator.SpecialPanelHandleMap.TryGetValue(tag, out type))
			{
				type = NavigationPanelHandleCreator.SpecialPanelHandleMap["Default"];
				tag = "Default";
			}
			return Activator.CreateInstance(type, new object[]
			{
				tag
			}) as SpecialPanelHandleBase;
		}

		// Token: 0x06033197 RID: 209303 RVA: 0x00CCC35C File Offset: 0x00CCA55C
		public static void CreateStaticDefaultValue()
		{
			NavigationPanelHandleCreator._specialPanelHandleMap = new Dictionary<string, Type>();
		}

		// Token: 0x06033198 RID: 209304 RVA: 0x00CCC368 File Offset: 0x00CCA568
		public static void ResetStaticDefaultValue()
		{
			NavigationPanelHandleCreator._specialPanelHandleMap = null;
		}

		// Token: 0x0401DB67 RID: 121703
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private static Dictionary<string, Type> _specialPanelHandleMap;
	}
}
