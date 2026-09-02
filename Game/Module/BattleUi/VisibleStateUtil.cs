using System;

namespace CSharpScript.Game.Module.BattleUi
{
	// Token: 0x02005F90 RID: 24464
	public class VisibleStateUtil : IStaticVariableResetter
	{
		// Token: 0x0603D6AE RID: 251566 RVA: 0x00FA03C4 File Offset: 0x00F9E5C4
		public static int SetVisible(int visibleState, bool bVisible, int type = 0)
		{
			if (bVisible)
			{
				return visibleState & ~(1 << type);
			}
			return visibleState | 1 << type;
		}

		// Token: 0x0603D6AF RID: 251567 RVA: 0x00FA03DB File Offset: 0x00F9E5DB
		public static bool GetVisible(int visibleState)
		{
			return visibleState == 0;
		}

		// Token: 0x0603D6B0 RID: 251568 RVA: 0x00FA03E1 File Offset: 0x00F9E5E1
		public static bool GetVisibleByType(int visibleState, int type)
		{
			return (visibleState & 1 << type) == 0;
		}

		// Token: 0x0603D6B1 RID: 251569 RVA: 0x00FA03EE File Offset: 0x00F9E5EE
		public static void CreateStaticDefaultValue()
		{
		}

		// Token: 0x0603D6B2 RID: 251570 RVA: 0x00FA03F0 File Offset: 0x00F9E5F0
		public static void ResetStaticDefaultValue()
		{
		}
	}
}
