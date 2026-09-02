using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x02001E21 RID: 7713
public class GuideDefine : IStaticVariableResetter
{
	// Token: 0x0600E3CB RID: 58315 RVA: 0x003D50D0 File Offset: 0x003D32D0
	static GuideDefine()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(GuideDefine.CreateStaticDefaultValue), new Action(GuideDefine.ResetStaticDefaultValue));
	}

	// Token: 0x0600E3CC RID: 58316 RVA: 0x003D50EF File Offset: 0x003D32EF
	public static void CreateStaticDefaultValue()
	{
		GuideDefine.guideTipsAllowedViews = new List<EUiViewName>
		{
			EUiViewName.BattleView,
			EUiViewName.CommonGameMainView
		};
	}

	// Token: 0x0600E3CD RID: 58317 RVA: 0x003D5111 File Offset: 0x003D3311
	public static void ResetStaticDefaultValue()
	{
		GuideDefine.guideTipsAllowedViews = null;
	}

	// Token: 0x0600E3CE RID: 58318 RVA: 0x003D511C File Offset: 0x003D331C
	[NullableContext(1)]
	public static bool isCustomTabViewForGuide(object viewObj)
	{
		GuideDefine.ICustomTabViewForGuide customTabViewForGuide = viewObj as GuideDefine.ICustomTabViewForGuide;
		return customTabViewForGuide != null && new Func<string>(customTabViewForGuide.GetViewName) != null;
	}

	// Token: 0x04006D88 RID: 28040
	[Nullable(1)]
	public static List<EUiViewName> guideTipsAllowedViews;

	// Token: 0x02008186 RID: 33158
	[NullableContext(1)]
	public interface ICustomTabViewForGuide
	{
		// Token: 0x060484D3 RID: 296147
		string GetViewName();
	}

	// Token: 0x02008187 RID: 33159
	public class CustomTabViewForGuide : GuideDefine.ICustomTabViewForGuide
	{
		// Token: 0x060484D4 RID: 296148 RVA: 0x0135F236 File Offset: 0x0135D436
		[NullableContext(1)]
		public string GetViewName()
		{
			throw new NotImplementedException();
		}
	}
}
